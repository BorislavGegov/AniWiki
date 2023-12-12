from pydantic import BaseModel
from app import app, db
from bson.objectid import ObjectId
from app import app, db
from bson.objectid import ObjectId
from fastapi.responses import Response
from fastapi.encoders import jsonable_encoder
from fastapi import Header, status
from pymongo.results import UpdateResult

class Prices(BaseModel):
    adult: int | None
    child: int | None
    pet: int | None
    car: int | None
    night: int | None

@app.put("/business/{id}/plots/{plot_id}/pitches/{pitch_id}/prices")
async def change_prices(id: str, plot_id: str, pitch_id: str, body: Prices, token: str = Header()):
    business = await db["businesses"].find_one({"_id": ObjectId(id)})
    if not token == business["auth_token"]:
        return Response(
            status_code=status.HTTP_401_UNAUTHORIZED,
            content="Bad token"
        )

    prices = jsonable_encoder(body)
    plot_ids = []
    pitch_ids = []
    for plot in business['plots']:
        plot_ids.append(plot["id"])
        for pitch in plot['pitches']:
            pitch_ids.append(pitch["id"])
    if plot_id not in plot_ids or pitch_id not in pitch_ids:
        return Response(status_code=404, content="Id not found")
    
    await db["businesses"].update_one(
        {"_id": ObjectId(id)},
        {
            "$set": {
                "plots.$[plotElement].pitches.$[pitchElement].prices": prices
            }
        },
        array_filters=[
            {"plotElement.id": plot_id},
            {"pitchElement.id": pitch_id}
        ]
    )
    return {"message": f"Prices updated for plot {plot_id} and pitch {pitch_id}", "prices_data": body.dict()}

@app.get("/business/{id}/plots/{plot_id}/pitches/{pitch_id}/prices")
async def read_prices(id: str, plot_id: str, pitch_id: str, token: str = Header()):
    business = await db.businesses.find_one({"_id": ObjectId(id)})

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
                    return pitch["prices"]
                
    return Response(
        status_code=status.HTTP_404_NOT_FOUND,
        content="Bad plot_id"
    )
    
