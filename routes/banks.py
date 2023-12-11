from app import app, db
from bson.objectid import ObjectId
from fastapi import HTTPException
from app import app, db
from pymongo import MongoClient
from bson.objectid import ObjectId
from fastapi.responses import Response
from typing import List, Dict, Union
from pydantic import BaseModel
from fastapi.encoders import jsonable_encoder
from fastapi import Header, status

class Bank(BaseModel):
    name: str | None
    accounts: List[Dict[str, Union[str, None]]]


@app.post("/business/{id}/banks/add")
async def add_bank(id: str, body: Bank, token: str = Header()):
    business = await db["businesses"].find_one({"_id": ObjectId(id)})

    if not token == business["auth_token"]:
        return Response(
            status_code=status.HTTP_401_UNAUTHORIZED,
            content="Bad token"
        )

    bank = jsonable_encoder(body)
    await db['businesses'].update_one({"_id": ObjectId(id)}, {"$push" : {"banks" : bank} })
    return {"message": f"Bank added to business {id}", "bank_data": body.dict()}

@app.get('/business/{id}/banks')
async def banks(id: str, token: str = Header()):
    business = await db["businesses"].find_one({"_id": ObjectId(id)})
    if not business:
        raise HTTPException(status_code=404, detail="Business not found")

    if not token == business["auth_token"]:
        return Response(
            status_code=status.HTTP_401_UNAUTHORIZED,
            content="Bad token"
        )
    return business.get('banks')

@app.get('/business/{business_id}/banks/{bank_id}')
async def bank(business_id: str, bank_id: str, token: str = Header()):
    business = await db["businesses"].find_one({"_id": ObjectId(business_id)})
    if not business:
        raise HTTPException(status_code=404, detail="Business not found")

    if not token == business["auth_token"]:
        return Response(
            status_code=status.HTTP_401_UNAUTHORIZED,
            content="Bad token"
        )

    for bank in business['banks']:
        if bank['id'] == bank_id:
            return bank
