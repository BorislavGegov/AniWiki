from app import app, db
from bson.objectid import ObjectId



@app.get("/business/{id}/plots")
async def read_plots(id):
    query = await db.businesses.find({"_id": ObjectId(id)}).to_list(length=100)
    for business in query:
        plots = business["plots"]
        if len(plots) > 0:
            return plots
    return []

