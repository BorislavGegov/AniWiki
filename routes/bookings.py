from app import app, db
from bson.objectid import ObjectId
from fastapi import Header, status
from fastapi.responses import Response

@app.get("/bussiness/{id}/bookings/available")
async def read_available_bookings(id, token: str = Header()):
    business = await db["businesses"].find_one({"_id": ObjectId(id)})

    if not token == business["auth_token"]:
        return Response(
            status_code=status.HTTP_401_UNAUTHORIZED,
            content="Bad token"
        )
    bookings = business["bookings"]
    available = []
    for booking in bookings:
        if booking['status'] == "available":
            available.append(booking)
    return available