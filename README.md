# BuddyAPI

## Development
1. Clone the `buddyapi` branch
```shell
git clone -b buddyapi <repo_link>
```
2. Create and activate a Python virtual environment
```shell
python -m venv venv
source venv/bin/activate
```
3. Install the dependencies
```shell
pip install -r requirements.txt
```
4. Create a `.env` file, and paste the following contents
```dotenv
MONGODB_URL="mongodb://buddy:password@192.168.1.136/buddyapi"
```
5. Start the development server
```shell
uvicorn app:app --reload
```

Authentication check for developing endpoints
```python
# Import the required libraries
from fastapi import Header, status
from fastapi.responses import Response
from bson.objectid import ObjectId

# Add the token header argument to the endpoint
async def some_endpoint(id: str, token: str = Header()):
    ...

# Add this snippet on top of every request
business = await db["businesses"].find_one({"_id": ObjectId(id)})

if not token == business["auth_token"]:
    return Response(
        status_code=status.HTTP_401_UNAUTHORIZED,
        content="Bad token"
    )

# You can reuse the `business` variable
```

For post endpoints use this to add records (of course it's an example)
```python
update_result = await db['businesses'].update_one({"_id": ObjectId(id)}, {"$push" : {"banks" : bank} })
```
