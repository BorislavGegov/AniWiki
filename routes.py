from app import app, db
from pymongo import MongoClient
from bson.objectid import ObjectId
import json

@app.get("/")
def read_root():
    return {"Hello": "World"}

@app.get("/business/{id}/invoices")
async def read_invoices(id):
    query = await db.businesses.find({"_id": ObjectId(id)}).to_list(length=100)
    # tu sprawdzic token gdzies
    for business in query:  
        invoice = business["invoices"]
        if len(invoice) > 0:
            return invoice
    return []
