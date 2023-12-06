from app import app, db
from bson.objectid import ObjectId
from fastapi import Response, status, Header

@app.get("/business/{id}/plots")
async def read_plots(id, token: str = Header()):
    business = await db.businesses.find_one({"_id": ObjectId(id)})
    if not token == business["auth_token"]:
        return Response(
            status_code=status.HTTP_401_UNAUTHORIZED,
            content="Bad token"
        )
    plots = business["plots"]
    if len(plots) > 0:
        return plots
    return []


@app.get("/business/{id}/plots/{idp}")
async def read_plots(id, idp, token: str = Header()):
    business = await db.businesses.find_one({"_id": ObjectId(id)})
    if not token == business["auth_token"]:
        return Response(
            status_code=status.HTTP_401_UNAUTHORIZED,
            content="Bad token"
        )
    plots = business["plots"]
    for plot in plots:
        if plot["id"] == idp:
            return plot
    return "Plot not found"