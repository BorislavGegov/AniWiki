from app import app, db
from pymongo import MongoClient
from bson.objectid import ObjectId
from auth import is_token_valid
from fastapi import Header, status
from fastapi.responses import Response

@app.get("/bussiness/{id}/bookings/available")
async def read_available_bookings(id, token: str = Header()):
    if not await is_token_valid(id, token):
        return Response(
            status_code=status.HTTP_401_UNAUTHORIZED,
            content="Bad token"
    )
    query = await db.businesses.find({"_id": ObjectId(id)}).to_list(length=100)
    for business in query:  
        bookings = business["bookings"]
        available = []
        for booking in bookings:
            if booking['status'] == "available":
                available.append(booking)
        return available
    return []