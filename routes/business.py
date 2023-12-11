from app import app, db
from bson.objectid import ObjectId
from fastapi import Response, status, Header

@app.get("/businesses")
async def read_businesses():
    # CELOWO UNPROTECTED BO TYLKO
    # POKAZUJE ID I NAZWE !!!!
    businesses = await db.businesses.find({}).to_list(length=100)
    result = []
    for business in businesses:
        result.append({"name": business["name"], "id": str(business["_id"])})
    return result

@app.get("/business/{id}")
async def read_business(id, token: str = Header()):
    business = await db.businesses.find_one({"_id": ObjectId(id)})
    if not business:
        return Response(status_code=status.HTTP_404_NOT_FOUND, content="Business not found")
    if not token == business["auth_token"]:
        return Response(status_code=status.HTTP_401_UNAUTHORIZED, content="Bad token")
    business["_id"] = id
    return business