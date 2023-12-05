from fastapi import Header, status
from fastapi.responses import Response
from app import app, db
from bson.objectid import ObjectId
import hashlib
import random
import string


@app.put("/businesses/{id}/token/reset")
async def update_token(id: str, token: str = Header()):
    business = await db["businesses"].find_one({"_id": ObjectId(id)})

    if not token == business["auth_token"]:
        return Response(
            status_code=status.HTTP_401_UNAUTHORIZED,
            content="Bad token"
        )

    token = hashlib.sha256("".join(random.choices(
        string.ascii_letters + string.digits, k=16))
        .encode("UTF-8")).hexdigest()

    db["businesses"].update_one({"_id": ObjectId(id)}, {
                                "$set": {"auth_token": token}})

    return Response(status_code=status.HTTP_200_OK, content=token)
