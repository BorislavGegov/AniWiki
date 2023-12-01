# BuddyAPI

## Development
```bash
# Clone the buddyapi branch
git clone -b buddyapi <repo_link>

# Create the docker-compose image
sudo docker-compose create && sudo docker-compose start

# Create python venv and install the dependencies
python -m venv venv && venv/bin/pip install -r requirements.txt

# Activate the venv and start the app
source venv/bin/activate && uvicorn app:app --reload
```
