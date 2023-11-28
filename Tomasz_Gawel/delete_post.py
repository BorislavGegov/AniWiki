from microblog import app, db, Post

with app.app_context():
 post_without_author = Post.query.filter_by(id=1, author=None).first()
 if post_without_author is not None:
    db.session.delete(post_without_author)
    db.session.commit()
    print(f"Post id: {post_without_author.id} has been deleted")
 else:
    print("No post with id 1 and no author found")