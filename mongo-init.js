db.createUser({
  user: 'buddy',
  pwd: 'password',
  roles: [
    {
      role: 'readWrite',
      db: 'buddyapi'
    }
  ]
})
