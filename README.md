# internshop-201123
1. Clone the repository to your project (buddyapi branch)
2. Using the terminal, navigate to the project folder using "cd DIRECTORY"
3. Create a virtual environment using "python -m venv venv"
4. Install dependencies from the requirements.txt file using "venv\Scripts\pip install -r requirements.txt"
5. Connect to the local server 192.168.1.136 with the details:
    DATABASE PORT: 27017 (192.168.1.136:27017)
    MONGOEXPRESS PORT: 8081 (192.168.1.136:8081)
    USERNAME: root
    PASSWORD: password
6. Start the app using "uvicorn app:app --reload"