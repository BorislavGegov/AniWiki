import token
import stripe
from fastapi import Header
from requests import Response
from starlette import status
from app import app, db
from routes import bookings, business

stripe.api_key = "sk_test_CGGvfNiIPwLXiDwaOfZ3oX6Y"




