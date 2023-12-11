from fastapi.encoders import jsonable_encoder
from pydantic import BaseModel
from typing import Dict, Union
from app import app, db
from bson.objectid import ObjectId
from fastapi import Header, Response, status, Request
import datetime


@app.get("/business/{id}/invoices")
async def read_invoices(id, token: str = Header()):
    business = await db.businesses.find_one({"_id": ObjectId(id)})
    if not business:
        return Response(status_code=status.HTTP_404_NOT_FOUND, content="Business not found")
    if not token == business["auth_token"]:
        return Response(status_code=status.HTTP_401_UNAUTHORIZED, content="Bad token")
    invoices = business["invoices"]
    if len(invoices) > 0:
        return invoices
    return []


@app.get("/business/{id}/invoices/issue_date/before/{date}")
async def read_invoices_before(id, date, token: str = Header()):
    business = await db.businesses.find_one({"_id": ObjectId(id)})
    if not business:
        return Response(status_code=status.HTTP_404_NOT_FOUND, content="Business not found")
    if not token == business["auth_token"]:
        return Response(status_code=status.HTTP_401_UNAUTHORIZED, content="Bad token")
    format = '%Y-%m-%d'
    try:
        converted_date = datetime.datetime.strptime(date, format)
    except ValueError:
        return Response(
            status_code=status.HTTP_422_UNPROCESSABLE_ENTITY,
            content="Invalid date, use the %Y-%m-%d format"
        )
    result = []
    invoices = business["invoices"]
    if len(invoices) > 0:
        for invoice in invoices:
            try:
                if invoice["issue_date"] < converted_date:
                    result.append(invoice)
            except TypeError:
                return []
    return result


@app.get("/business/{id}/invoices/issue_date/after/{date}")
async def read_invoices_after(id, date, token: str = Header()):
    business = await db.businesses.find_one({"_id": ObjectId(id)})
    if not business:
        return Response(status_code=status.HTTP_404_NOT_FOUND, content="Business not found")
    if not token == business["auth_token"]:
        return Response(status_code=status.HTTP_401_UNAUTHORIZED, content="Bad token")
    format = '%Y-%m-%d'
    try:
        converted_date = datetime.datetime.strptime(date, format)
    except ValueError:
        return Response(
            status_code=status.HTTP_422_UNPROCESSABLE_ENTITY,
            content="Invalid date, use the %Y-%m-%d format"
        )
    result = []
    invoices = business["invoices"]
    if len(invoices) > 0:
        for invoice in invoices:
            try:
                if invoice["issue_date"] > converted_date:
                    result.append(invoice)
            except TypeError:
                return []
    return result


@app.get("/business/{id}/invoices/issue_date/between/{date1}/{date2}")
async def read_invoices_between(id, date1, date2, token: str = Header()):
    business = await db.businesses.find_one({"_id": ObjectId(id)})
    if not business:
        return Response(status_code=status.HTTP_404_NOT_FOUND, content="Business not found")
    if not token == business["auth_token"]:
        return Response(status_code=status.HTTP_401_UNAUTHORIZED, content="Bad token")
    format = '%Y-%m-%d'
    try:
        converted_date1 = datetime.datetime.strptime(date1, format)
        converted_date2 = datetime.datetime.strptime(date2, format)
    except ValueError:
        return Response(
            status_code=status.HTTP_422_UNPROCESSABLE_ENTITY,
            content="Invalid date or dates, use the %Y-%m-%d format"
        )
    result = []
    invoices = business["invoices"]
    if len(invoices) > 0:
        for invoice in invoices:
            try:
                if (invoice["issue_date"] > converted_date1) and (invoice["issue_date"] < converted_date2):
                    result.append(invoice)
            except TypeError:
                return []
    return result


@app.get("/business/{id}/invoices/search")
async def read_invoices_search(id, token: str = Header(), request: Request = Request):
    business = await db.businesses.find_one({"_id": ObjectId(id)})
    if not business:
        return Response(status_code=status.HTTP_404_NOT_FOUND, content="Business not found")
    if not token == business["auth_token"]:
        return Response(status_code=status.HTTP_401_UNAUTHORIZED, content="Bad token")
    try:
        jsonb = await request.json()
    except:
        return Response(
            status_code=status.HTTP_422_UNPROCESSABLE_ENTITY,
            content="Invalid JSON body"
        )
    result = []
    query_keywords = []
    invoices = business["invoices"]
    # EXAMPLE USAGE:
    # In request body, use a JSON object
    # such as {"currency": "USD"}
    # and look for the specified values!
    if len(invoices) > 0:
        for attribute, value in jsonb.items():
            query_keywords.append([attribute, value])
        for invoice in invoices:
            invoice_keywords = []
            query_keywords_length = len(query_keywords)
            query_found_keywords = 0
            for attribute, value in invoice.items():
                invoice_keywords.append([attribute, value])
            for keyword in query_keywords:
                if keyword in invoice_keywords:
                    query_found_keywords += 1
            if query_found_keywords == query_keywords_length:
                result.append(invoice)
    return result


class Invoice(BaseModel):
    invoice_number: str | None = None
    issue_date: str | None = None
    due_date: str | None = None
    currency: str | None = None
    net_amount: float | None = None
    gross_amount: float | None = None
    seller_name: str | None = None
    seller_address_1: str | None = None
    seller_address_2: str | None = None
    seller_address_city: str | None = None
    seller_address_region: str | None = None
    seller_address_postcode: str | None = None
    seller_address_country: str | None = None
    buyer_name: str | None = None
    buyer_address_1: str | None = None
    buyer_address_2: str | None = None
    buyer_address_city: str | None = None
    buyer_address_region: str | None = None
    buyer_address_postcode: str | None = None
    buyer_address_country: str | None = None
    buyer_bank: Dict[str, Union[str, None]]


@app.post("/business/{id}/invoices/add")
async def add_invoice(id: str, body: Invoice, token: str = Header()):
    business = await db.businesses.find_one({"_id": ObjectId(id)})

    if not business:
        return Response(
            status_code=status.HTTP_404_NOT_FOUND,
            content="Business not found"
        )

    if not token == business["auth_token"]:
        return Response(
            status_code=status.HTTP_401_UNAUTHORIZED,
            content="Bad token"
        )

    await db["businesses"].update_one(
        {"_id": ObjectId(id)},
        {"$push": {"invoices": jsonable_encoder(body)}}
    )

    return {"message": f"Invoice added to business {id}", "invoice_data": body.dict()}


@app.put("/business/{id}/invoices/{invoice_number}")
async def update_invoice(id: str, invoice_number: str, body: Invoice, token: str = Header()):
    business = await db["businesses"].find_one({"_id": ObjectId(id)})

    if not token == business["auth_token"]:
        return Response(
            status_code=status.HTTP_401_UNAUTHORIZED,
            content="Bad token"
        )

    invoices = business["invoices"]
    for index, invoice in enumerate(invoices):
        if invoice["invoice_number"] == invoice_number:
            invoices[index] = jsonable_encoder(body)

    await db["businesses"].update_one(
        {"_id": ObjectId(id)},
        {"$set": {"invoices": invoices}}
    )

    return {"message": f"Invoice {invoice_number} in business {id} updated", "invoice_data": body.dict()}


@app.delete("/business/{id}/invoices/{invoice_number}")
async def delete_invoice(id: str, invoice_number: str, token: str = Header()):
    business = await db["businesses"].find_one({"_id": ObjectId(id)})

    if not token == business["auth_token"]:
        return Response(
            status_code=status.HTTP_401_UNAUTHORIZED,
            content="Bad token"
        )

    invoices = business["invoices"]
    for index, invoice in enumerate(invoices):
        if invoice["invoice_number"] == invoice_number:
            del invoices[index]

    await db["businesses"].update_one(
        {"_id": ObjectId(id)},
        {"$set": {"invoices": invoices}}
    )

    return f"Invoice {invoice_number} in business {id} deleted"
