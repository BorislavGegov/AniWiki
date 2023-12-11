from app import app, db
from bson.objectid import ObjectId
from fastapi import Header, status
from fastapi.responses import Response
from pydantic import BaseModel
from datetime import date
from fastapi.encoders import jsonable_encoder


@app.get("/business/{id}/bookings/available")
async def get_available_bookings(id, token: str = Header()):
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


@app.get("/business/{id}/bookings/{booking_id}")
async def get_booking(id: str, booking_id: str, token: str = Header()):
    business = await db["businesses"].find_one({"_id": ObjectId(id)})

    if not token == business["auth_token"]:
        return Response(
            status_code=status.HTTP_401_UNAUTHORIZED,
            content="Bad token"
        )

    for booking in business["bookings"]:
        if booking["id"] == booking_id:
            return booking

    return Response(
        status_code=status.HTTP_404_NOT_FOUND,
        content="No booking with specified id"
    )


class BookedPitch(BaseModel):
    plot_id: str | None = None
    pitches_id: list[str] | None = None


class BalanceImpact(BaseModel):
    cash: float | None = None
    inbound_pending: float | None = None
    outbound_pending: float | None = None


class TransitionStatus(BaseModel):
    posted_at: date | None = None
    void_at: date | None = None


class Transaction(BaseModel):
    id: str | None = None
    amount: float | None = None
    balance_impact: BalanceImpact | None = None
    created: date | None = None
    currency: str | None = None
    description: str | None = None
    financial_account: str | None = None
    flow: str | None = None
    flow_type: str | None = None
    livemode: bool | None = None
    status: str | None = None
    transition_status: TransitionStatus | None = None


class Booking(BaseModel):
    status: str
    id: str
    booked_pitches: list[BookedPitch]
    transaction: Transaction


@app.post("/business/{id}/bookings/add")
async def add_booking(id: str, body: Booking, token: str = Header()):
    business = await db["businesses"].find_one({"_id": ObjectId(id)})

    if not token == business["auth_token"]:
        return Response(
            status_code=status.HTTP_401_UNAUTHORIZED,
            content="Bad token"
        )

    booking = jsonable_encoder(body)
    await db["businesses"].update_one(
        {"_id": ObjectId(id)},
        {"$push": {"bookings": booking}}
    )

    return {"message": f"Booking added to business {id}", "booking_data": body.dict()}


@app.put("/business/{id}/bookings/{booking_id}")
async def update_booking(id: str, booking_id: str, body: Booking, token: str = Header()):
    business = await db["businesses"].find_one({"_id": ObjectId(id)})

    if not token == business["auth_token"]:
        return Response(
            status_code=status.HTTP_401_UNAUTHORIZED,
            content="Bad token"
        )

    bookings = business["bookings"]
    for index, booking in enumerate(bookings):
        if booking["id"] == booking_id:
            bookings[index] = jsonable_encoder(body)

    await db["businesses"].update_one(
        {"_id": ObjectId(id)},
        {"$set": {"bookings": bookings}}
    )

    return {"message": f"Booking {booking_id} in business {id} updated", "booking_data": body.dict()}


@app.delete("/business/{id}/bookings/{booking_id}")
async def delete_booking(id: str, booking_id: str, token: str = Header()):
    business = await db["businesses"].find_one({"_id": ObjectId(id)})

    if not token == business["auth_token"]:
        return Response(
            status_code=status.HTTP_401_UNAUTHORIZED,
            content="Bad token"
        )

    bookings = business["bookings"]
    for index, booking in enumerate(bookings):
        if booking["id"] == booking_id:
            del bookings[index]

    await db["businesses"].update_one(
        {"_id": ObjectId(id)},
        {"$set": {"bookings": bookings}}
    )

    return f"Booking {booking_id} in business {id} deleted"
