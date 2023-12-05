from fastapi import Header, status
from fastapi.responses import Response
from app import app, db
from bson.objectid import ObjectId
import bcrypt
import random
import string


async def is_token_valid(id, token):
    business = await db["businesses"].find_one({"_id": ObjectId(id)})

    return token == business["auth_token"]


@app.put("/businesses/{id}/token/reset")
async def update_token(id: str, token: str = Header()):
    if not await is_token_valid(id, token):
        return Response(
            status_code=status.HTTP_401_UNAUTHORIZED,
            content="Bad token"
        )

    random_string = "".join(random.choices(
        string.ascii_letters + string.digits, k=16))
    token = bcrypt.hashpw(random_string.encode("UTF-8"),
                          bcrypt.gensalt()).decode("utf-8")

    db["businesses"].update_one({"_id": ObjectId(id)}, {
                                "$set": {"auth_token": token}})

    return Response(status_code=status.HTTP_200_OK, content=token)
