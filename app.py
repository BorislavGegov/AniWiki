import os
import motor.motor_asyncio
from fastapi import FastAPI
from dotenv import load_dotenv
import json
from pymongo import MongoClient

load_dotenv()

app = FastAPI(
    title="Student Course API",
    summary="A sample application showing how to use FastAPI to add a ReST API to a MongoDB collection.",
)
client = motor.motor_asyncio.AsyncIOMotorClient(os.environ["MONGODB_URL"])
db = client.get_database("buddyapi")

if db.get_collection("businesses").is_mongos:
    businesses_collection = db.get_collection("businesses")
    print(businesses_collection)
else:
    with open('./schema.json', 'r') as file:
        schema = json.load(file)
    businesses_collection = db.create_collection("businesses", validator={'$jsonSchema': schema})

import routes