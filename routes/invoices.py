from app import app, db
from bson.objectid import ObjectId
from fastapi import Header, Response, status, Body, Request
import json, datetime

@app.get("/business/{id}/invoices")
async def read_invoices(id, token: str = Header()):
    business = await db.businesses.find_one({"_id": ObjectId(id)})
    if not token == business["auth_token"]:
        return Response(
            status_code=status.HTTP_401_UNAUTHORIZED,
            content="Bad token"
        )
    invoices = business["invoices"]
    if len(invoices) > 0:
        return invoices
    return []

@app.get("/business/{id}/invoices/issue_date/before/{date}")
async def read_invoices_before(id, date, token: str = Header()):
    business = await db.businesses.find_one({"_id": ObjectId(id)})
    if not token == business["auth_token"]:
        return Response(
            status_code=status.HTTP_401_UNAUTHORIZED,
            content="Bad token"
        )
    format = '%Y-%m-%d'
    try:
        converted_date = datetime.datetime.strptime(date, format)
    except ValueError:
        return []
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
    if not token == business["auth_token"]:
        return Response(
            status_code=status.HTTP_401_UNAUTHORIZED,
            content="Bad token"
        )
    format = '%Y-%m-%d'
    try:
        converted_date = datetime.datetime.strptime(date, format)
    except ValueError:
        return []
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
    if not token == business["auth_token"]:
        return Response(
            status_code=status.HTTP_401_UNAUTHORIZED,
            content="Bad token"
        )
    format = '%Y-%m-%d'
    try:
        converted_date1 = datetime.datetime.strptime(date1, format)
        converted_date2 = datetime.datetime.strptime(date2, format)
    except ValueError:
        return []
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
async def read_invoices_between(id, token: str = Header(), request: Request = Request):
    business = await db.businesses.find_one({"_id": ObjectId(id)})
    if not token == business["auth_token"]:
        return Response(
            status_code=status.HTTP_401_UNAUTHORIZED,
            content="Bad token"
        )
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
