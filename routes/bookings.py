from app import app, db
from pymongo import MongoClient
from bson.objectid import ObjectId

@app.get("/bussiness/{id}/bookings/available")
async def read_available_bookings(id):
    query = await db.businesses.find({"_id": ObjectId(id)}).to_list(length=100)
    for business in query:  
        bookings = business["bookings"]
        available = []
        for booking in bookings:
            if booking['status'] == "available":
                available.append(booking)
        return available
    return []