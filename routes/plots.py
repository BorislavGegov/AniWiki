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
async def read_plot_id(id, idp, token: str = Header()):
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
    return Response(
        status_code=status.HTTP_404_NOT_FOUND,
        content="Bad plot id"
    )

@app.get("/business/{id}/plots/{plot_id}/pitches/{pitch_id}")
async def get_pitch(id: str, plot_id: str, pitch_id: str, token: str = Header()):
    
    business = await db["businesses"].find_one({"_id": ObjectId(id)})

    if not token == business["auth_token"]:
        return Response(
            status_code=status.HTTP_401_UNAUTHORIZED,
            content="Bad token"
        )

    plots = business["plots"]
    for plot in plots:
        if plot["id"] == plot_id:
            pitches = plot["pitches"]
            for pitch in pitches:
                if pitch["id"] == pitch_id:
                    return pitch
        return Response(
        status_code=status.HTTP_404_NOT_FOUND,
        content="Pitch not found"
    )

@app.get("/business/{id}/plots/{plot_id}/pitches")
async def get_pitches(id: str, plot_id: str, token: str = Header()):
    
    business = await db["businesses"].find_one({"_id": ObjectId(id)})

    if not token == business["auth_token"]:
        return Response(
            status_code=status.HTTP_401_UNAUTHORIZED,
            content="Bad token"
        )
    
    
    plots = business["plots"]
    for plot in plots:
        if plot["id"] == plot_id:
            return plot["pitches"]
    return Response(
        status_code=status.HTTP_404_NOT_FOUND,
        content="Bad plot id"
    )