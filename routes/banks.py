from app import app, db
from bson.objectid import ObjectId
from fastapi import HTTPException


@app.get('/business/{business_id}/banks')
async def banks(business_id: str):
    business = await db.businesses.find_one({'_id': ObjectId(business_id)})
    if not business:
        raise HTTPException(status_code=404, detail="Business not found")
    return business.get('banks')


