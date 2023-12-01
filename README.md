# BuddyAPI

## Development
1. Clone the repository (buddyapi branch)
2. Using the terminal, navigate to the project folder using "cd DIRECTORY"
3. Create a virtual environment using "python -m venv venv"
4. Install dependencies from the requirements.txt file using "venv\Scripts\pip install -r requirements.txt"
5. Create a `.env` file with the following contents:
```dotenv
MONGODB_URL="mongodb://buddy:password@192.168.1.136/buddyapi"
```
6. Start the app using "uvicorn app:app --reload"

