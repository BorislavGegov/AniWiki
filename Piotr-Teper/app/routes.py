from app import app, db
from flask_login import current_user, login_user, logout_user, login_required
from app.models import User, Post
from app.forms import LoginForm, RegistrationForm, EditProfileForm, EmptyForm, PostForm, EditPostForm

from flask import Flask, redirect, url_for, render_template, flash, request
#from werkzeug.urls import url_parse
from app.extras.parse import urlsplit
from config import Config
from datetime import datetime

"""def get_posts():
    id = current_user.id
    user = User.query.get(id)
    return user.posts.all()"""

@app.before_request
def before_request():
    if current_user.is_authenticated:
        current_user.last_seen = datetime.utcnow()
        db.session.commit()

@app.route('/', methods=["POST", "GET"])
def index():
    if current_user.is_authenticated:
        form = PostForm()
        if form.validate_on_submit():
            post = Post(body=form.post.data, author=current_user)
            db.session.add(post)
            db.session.commit()
            flash('Your post is now live!')
            return redirect(url_for('index'))
        page = request.args.get('page', 1, type=int)
        posts = current_user.followed_posts().paginate(page=page, per_page=app.config['POSTS_PER_PAGE'], error_out=False)
        next_url = url_for('index', page=posts.next_num) \
            if posts.has_next else None
        prev_url = url_for('index', page=posts.prev_num) \
            if posts.has_prev else None
        return render_template("index.html", loggedIn=current_user.is_authenticated, page="index", posts=posts.items, user=current_user, form=form, next_url=next_url, prev_url=prev_url)
    # when not logged in
    return render_template("index.html", loggedIn=current_user.is_authenticated, page="index", posts=[], user=current_user)
    
@app.route('/login', methods=["POST", "GET"])
def login():
    if current_user.is_authenticated:
        return redirect(url_for('index'))
    login_form = LoginForm()
    if login_form.validate_on_submit():
        user = User.query.filter_by(username=login_form.username.data).first()
        if user is None or not user.check_password(login_form.password.data):
            flash('Invalid username or password')
            return redirect(url_for('login'))
        login_user(user, remember=login_form.remember_me.data)
        next_page = request.args.get('next')
        #if not next_page or url_parse(next_page).netloc != '':
        if not next_page or urlsplit(next_page).netloc != '':
            next_page = url_for('index')
        return redirect(next_page)
    return render_template("login.html", form=login_form, loggedIn=current_user.is_authenticated, page="login")

@app.route('/logout')
def logout():
    logout_user()
    return redirect(url_for('index'))

@app.route('/logpage')
@login_required
def logpage():
    return render_template("logpage.html", nr=0, loggedIn=current_user.is_authenticated, page="logpage")

@app.route('/register', methods=['GET', 'POST'])
def register():
    if current_user.is_authenticated:
        return redirect(url_for('index'))
    form = RegistrationForm()
    if form.validate_on_submit():
        user = User(username=form.username.data, email=form.email.data)
        user.set_password(form.password.data)
        db.session.add(user)
        db.session.commit()
        flash('Congratulations, you are now a registered user!')
        return redirect(url_for('login'))
    return render_template('register.html', loggedIn=current_user.is_authenticated, page="register", form=form)

@app.route('/user')
@login_required
def useralt():
    return redirect(url_for('index'))

@app.route('/user/<id>')
@login_required
def user(id):
    user = User.query.get(id)
    if user is None:
        return redirect(url_for('login'))
    page = request.args.get('page', 1, type=int)
    posts = user.posts.order_by(Post.timestamp.desc()).paginate(page=page, per_page=app.config['POSTS_PER_PAGE'], error_out=False)
    next_url = url_for('user', id=id, page=posts.next_num) \
        if posts.has_next else None
    prev_url = url_for('user', id=id, page=posts.prev_num) \
        if posts.has_prev else None
    form = EmptyForm()
    return render_template('user.html', loggedIn=current_user.is_authenticated, page="user", user=user, posts=posts, form=form, next_url=next_url, prev_url=prev_url)

@app.route('/edit_profile', methods=['GET', 'POST'])
@login_required
def edit_profile():
    form = EditProfileForm(current_user.username)
    if form.validate_on_submit():
        current_user.username = form.username.data
        current_user.about_me = form.about_me.data
        db.session.commit()
        flash('Your changes have been saved.')
        return redirect(url_for('edit_profile'))
    elif request.method == 'GET':
        form.username.data = current_user.username
        form.about_me.data = current_user.about_me
    return render_template('edit_profile.html', form=form, loggedIn=current_user.is_authenticated, page="edit_profile")

@app.route('/follow/<id>', methods=['POST'])
@login_required
def follow(id):
    form = EmptyForm()
    if form.validate_on_submit():
        user = User.query.get(id)
        if user is None:
            flash('User not found.')
            return redirect(url_for('index'))
        username = user.username
        if user == current_user:
            flash('You cannot follow yourself!')
            return redirect(url_for('user', id=id))
        current_user.follow(user)
        db.session.commit()
        flash('You are following {}!'.format(username))
        return redirect(url_for('user', id=id))
    else:
        return redirect(url_for('index'))

@app.route('/unfollow/<id>', methods=['POST'])
@login_required
def unfollow(id):
    form = EmptyForm()
    if form.validate_on_submit():
        user = User.query.get(id)
        if user is None:
            flash('User not found.')
            return redirect(url_for('index'))
        username = user.username
        if user == current_user:
            flash('You cannot unfollow yourself!')
            return redirect(url_for('user', id=id))
        current_user.unfollow(user)
        db.session.commit()
        flash('You are not following {}.'.format(username))
        return redirect(url_for('user', id=id))
    else:
        return redirect(url_for('index'))

@app.route('/explore')
def explore():
    page = request.args.get('page', 1, type=int)
    posts = Post.query.order_by(Post.timestamp.desc()).paginate(page=page, per_page=app.config['POSTS_PER_PAGE'], error_out=False)
    next_url = url_for('explore', page=posts.next_num) \
        if posts.has_next else None
    prev_url = url_for('explore', page=posts.prev_num) \
        if posts.has_prev else None
    return render_template('explore.html', page="explore", posts=posts, loggedIn=current_user.is_authenticated, next_url=next_url, prev_url=prev_url)

@app.route("/delete_post/<id>")
@login_required
def delete_post(id):
    post = Post.query.get(id)
    if post is None:
        flash("Post not found.")
        return redirect(url_for('user', id=current_user.id))
    if post.user_id == current_user.id:
        #post.delete()
        db.session.delete(post)
        db.session.commit()
        flash("Your post has been deleted!")
        return redirect(url_for('user', id=current_user.id))
    else:
        flash("You don't have permission to delete this post!")
        return redirect(url_for('user', id=current_user.id))

@app.route('/edit_post/<id>', methods=['GET', 'POST'])
@login_required
def edit_post(id):
    post = Post.query.get(id)
    if post is None:
        flash("Post not found.")
        return redirect(url_for('user', id=current_user.id))
    if post.user_id != current_user.id:
        flash("You don't have permission to edit this post!")
        return redirect(url_for('user', id=current_user.id))
    form = EditPostForm()
    if form.validate_on_submit():
        post.body = form.body.data
        post.edit_timestamp = datetime.utcnow()
        db.session.commit()
        flash('Your changes have been saved.')
        return redirect(url_for('user', id=current_user.id))
    elif request.method == 'GET':
        form.body.data = post.body
    return render_template('edit_post.html', form=form, loggedIn=current_user.is_authenticated, page="edit_post")