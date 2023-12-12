from http.client import HTTPException

from app import app, db
from bson.objectid import ObjectId
from fastapi import Header, status
from fastapi.responses import Response
import stripe
from bookings import Transaction

stripe.api_key = "sk_test_CGGvfNiIPwLXiDwaOfZ3oX6Y"
@app.post("/business/{id}/transaction")
async def transactions(id: str, body: Transaction, token: str = Header()):
    # Validate the business and token
    business = await db.businesses.find_one({"_id": ObjectId(id)})
    if not business:
        return Response(status_code=status.HTTP_404_NOT_FOUND, content="Business not found")
    if not token == business["auth_token"]:
        return Response(status_code=status.HTTP_401_UNAUTHORIZED, content="Bad token")



