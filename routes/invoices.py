from app import app, db
from pymongo import MongoClient
from bson.objectid import ObjectId
import json, datetime

@app.get("/business/{id}/invoices")
async def read_invoices(id):
    business = await db.businesses.find_one({"_id": ObjectId(id)})
    # tu sprawdzic token gdzies
    invoices = business["invoices"]
    if len(invoices) > 0:
        return invoices
    return []

@app.get("/business/{id}/invoices/issue_date/before/{date}")
async def read_invoices_before(id, date):
    business = await db.businesses.find_one({"_id": ObjectId(id)})
    # tu sprawdzic token gdzies
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
async def read_invoices_after(id, date):
    business = await db.businesses.find_one({"_id": ObjectId(id)})
    # tu sprawdzic token gdzies
    format = '%Y-%m-%d'
    converted_date = datetime.datetime.strptime(date, format)
    result = []
    invoices = business["invoices"]
    if len(invoices) > 0:
        for invoice in invoices:
            if invoice["issue_date"] > converted_date:
                result.append(invoice)
    return result