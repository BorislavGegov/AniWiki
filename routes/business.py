from app import app, db
from bson.objectid import ObjectId

@app.get("/business/{id}")
async def read_business(id):
    business = await db.businesses.find_one({"_id": ObjectId(id)})
    business["_id"] = ""
    return business