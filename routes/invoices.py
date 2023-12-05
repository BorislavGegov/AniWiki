from app import app, db
from pymongo import MongoClient
from bson.objectid import ObjectId
from fastapi import Header, Response, status
import json, datetime

@app.get("/business/{id}/invoices")
async def read_invoices(id, token: str = Header()):
    business = await db.businesses.find_one({"_id": ObjectId(id)})
    if token != business["auth_token"]:
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
    if token != business["auth_token"]:
        return Response(
            status_code=status.HTTP_401_UNAUTHORIZED,
            content="Bad token"
        )
    format = '%Y-%m-%d'
    converted_date = datetime.datetime.strptime(date, format)
    result = []  
    invoices = business["invoices"]
    if len(invoices) > 0:
        for invoice in invoices:
            if invoice["issue_date"] < converted_date:
                result.append(invoice)
    return result

@app.get("/business/{id}/invoices/issue_date/after/{date}")
async def read_invoices_after(id, date, token: str = Header()):
    business = await db.businesses.find_one({"_id": ObjectId(id)})
    if token != business["auth_token"]:
        return Response(
            status_code=status.HTTP_401_UNAUTHORIZED,
            content="Bad token"
        )
    format = '%Y-%m-%d'
    converted_date = datetime.datetime.strptime(date, format)
    result = []
    invoices = business["invoices"]
    if len(invoices) > 0:
        for invoice in invoices:
            if invoice["issue_date"] > converted_date:
                result.append(invoice)
    return result

@app.get("/business/{id}/invoices/issue_date/between/{date1}/{date2}")
async def read_invoices_between(id, date1, date2, token: str = Header()):
    business = await db.businesses.find_one({"_id": ObjectId(id)})
    if token != business["auth_token"]:
        return Response(
            status_code=status.HTTP_401_UNAUTHORIZED,
            content="Bad token"
        )
    format = '%Y-%m-%d'
    converted_date1 = datetime.datetime.strptime(date1, format)
    converted_date2 = datetime.datetime.strptime(date2, format)
    result = []
    invoices = business["invoices"]
    if len(invoices) > 0:
        for invoice in invoices:
            if (invoice["issue_date"] > converted_date1) and (invoice["issue_date"] < converted_date2):
                result.append(invoice)
    return result
