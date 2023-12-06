import os
import motor.motor_asyncio
from fastapi import FastAPI
from dotenv import load_dotenv
import json
from pymongo import MongoClient
import asyncio

load_dotenv()

app = FastAPI(
    title="Student Course API",
    summary="",
)

client = motor.motor_asyncio.AsyncIOMotorClient(os.environ["MONGODB_URL"])
db = client['buddyapi']

async def check_and_create_collection():
    with open('./schema.json', 'r') as file:
        schema = json.load(file)
    
    collection_names = await db.list_collection_names()
    if 'businesses' in collection_names:
        collection_info = await db.command("listCollections", filter={"name": "businesses"})
        collection_options = collection_info['cursor']['firstBatch'][0].get('options', {})
        
        if 'validator' in collection_options:
            current_schema = collection_options['validator'].get('$jsonSchema')
            if current_schema == schema:
                print("Collection 'businesses' already exists with the matching schema.")
                return 0
            else:
                print("Collection 'businesses' already exists but with a different schema.")
                return 1
        else:
            print("Collection 'businesses' does not have a validator set. Setting schema now.")
            await db.command("collMod", "businesses", validator={'$jsonSchema': schema})
            return 0
    else:
        await db.create_collection("businesses", validator={'$jsonSchema': schema})
        print("Collection 'businesses' created with the specified schema.")
        return 0

@app.on_event("startup")
async def startup_event():
    await check_and_create_collection()

import routes.auth, routes.business, routes.invoices, routes.plots, routes.bookings, routes.banks