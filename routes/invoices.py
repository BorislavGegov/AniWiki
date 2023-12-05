from app import app, db
from pymongo import MongoClient
from bson.objectid import ObjectId
import json, datetime

@app.get("/business/{id}/invoices")
async def read_invoices(id):
    query = await db.businesses.find({"_id": ObjectId(id)}).to_list(length=100)
    # tu sprawdzic token gdzies
    for business in query:  
        invoices = business["invoices"]
        if len(invoices) > 0:
            return invoices
    return []

@app.get("/business/{id}/invoices/issue_date/before/{date}")
async def read_invoices_before(id, date):
    query = await db.businesses.find({"_id": ObjectId(id)}).to_list(length=100  )
    # tu sprawdzic token gdzies
    format = '%Y-%m-%d'
    converted_date = datetime.datetime.strptime(date, format)
    result = []
    for business in query:  
        invoices = business["invoices"]
        if len(invoices) > 0:
            for invoice in invoices:
                if invoice["issue_date"] < converted_date:
                    result.append(invoice)
    return result

@app.get("/business/{id}/invoices/issue_date/after/{date}")
async def read_invoices_after(id, date):
    query = await db.businesses.find({"_id": ObjectId(id)}).to_list(length=100)
    # tu sprawdzic token gdzies
    format = '%Y-%m-%d'
    converted_date = datetime.datetime.strptime(date, format)
    result = []
    for business in query:
        invoices = business["invoices"]
        if len(invoices) > 0:
            for invoice in invoices:
                if invoice["issue_date"] > converted_date:
                    result.append(invoice)
    return result