from app import app, db
from app.models import User, Post

# flask shell
# @globodain
@app.shell_context_processor
def make_shell_context():
    return {'app': app, 'db': db, 'User': User, 'Post': Post}


"""from flask import Flask, redirect, url_for, render_template, flash
from config import Config
from forms import LoginForm

app = Flask(__name__)
app.config.from_object(Config)
# https://www.youtube.com/watch?v=SHZwgeshSOs


@app.route('/')
def main():
    return render_template("index.html", nr=0)

@app.route('/<nr>')
def maina(nr):
    return render_template("index.html", nr=int(nr))

@app.route('/login', methods=["POST", "GET"])
def login():
    login_form = LoginForm()
    if login_form.validate_on_submit():
        print("dffdfd")
    return render_template("login.html", form=login_form)

if __name__ == '__main__':
    app.run(host='127.0.0.1', port=8080, debug=True)
"""