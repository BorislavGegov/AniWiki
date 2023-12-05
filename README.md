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
# Import the token validation function
from auth import is_token_valid

# Add the token header argument to the endpoint
async def some_endpoint(id: str, token: str = Header()):
    ...

# Add this snippet on top of every request
if not await is_token_valid(id, token):
    return Response(
        status_code=status.HTTP_401_UNAUTHORIZED,
        content="Bad token"
    )
```
