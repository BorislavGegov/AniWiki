from app import app, db, login
from datetime import datetime
from time import time
from werkzeug.security import generate_password_hash, check_password_hash
from flask_login import UserMixin
from hashlib import sha256
import jwt

followers = db.Table('followers',
    db.Column('follower_id', db.Integer, db.ForeignKey('user.id')),
    db.Column('followed_id', db.Integer, db.ForeignKey('user.id')),
)


class User(UserMixin, db.Model):
    id            = db.Column(db.Integer, primary_key=True)
    username      = db.Column(db.String(64), index=True, unique=True)
    email         = db.Column(db.String(120), index=True, unique=True)
    password_hash = db.Column(db.String(128))
    posts         = db.relationship('Post', backref='author', lazy='dynamic')
    about_me      = db.Column(db.String(540))
    last_seen     = db.Column(db.DateTime, default=datetime.utcnow)
    followed      = db.relationship(
                        'User',
                        secondary=followers,
                        primaryjoin=(followers.c.follower_id == id),
                        secondaryjoin=(followers.c.followed_id == id),
                        backref=db.backref('followers', lazy='dynamic'),
                        lazy='dynamic',
                    )

    def set_password(self, password: str):
        self.password_hash = generate_password_hash(password)

    def check_password(self, password: str):
        return check_password_hash(self.password_hash, password)

    def avatar(self, size: int):
        digest = sha256(self.email.lower().encode('utf-8')).hexdigest()
        return 'https://www.libravatar.org/avatar/{}?d=identicon&s={}'\
            .format(digest, size)

    def is_following(self, user):
        return self.followed.filter(
            followers.c.followed_id == user.id
        ).count() > 0

    def follow(self, user):
        if self.is_following(user): return;
        self.followed.append(user)

    def unfollow(self, user):
        if not self.is_following(user): return;
        self.followed.remove(user)

    def followed_posts(self):
        followed = Post.query.join(
            followers,
            followers.c.followed_id == Post.user_id,
        ).filter(followers.c.follower_id == self.id)
        own = Post.query.filter_by(user_id=self.id)
        return followed.union(own)\
            .order_by(Post.timestamp.desc())

    def get_reset_password_token(self, expires_in=600):
        return jwt.encode(
            {
                'reset_password': self.id,
                'exp': time() + expires_in,
            },
            app.config['SECRET_KEY'],
            algorithm='HS256',
        )

    @staticmethod
    def verify_reset_password_token(token: str):
        try:
            id = jwt.decode(
                token,
                app.config['SECRET_KEY'],
                algorithms=['HS256']
            )['reset_password']
        except:
            return
        
        return User.query.get(id)

    def __repr__(self):
        return '<User {} {} {}'.format(self.id, self.username, self.email)


@login.user_loader
def load_user(id: int):
    return User.query.get(int(id))


class Post(db.Model):
    id        = db.Column(db.Integer, primary_key=True)
    body      = db.Column(db.String(140))
    timestamp = db.Column(db.DateTime, index=True, default=datetime.utcnow)
    user_id   = db.Column(db.Integer, db.ForeignKey('user.id'))

    def __repr__(self):
        return 'Post {} {} {} {}'.format(self.id, self.body, self.timestamp, self.user_id)