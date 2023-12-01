db.createUser({
  user: 'buddy',
  pwd: 'password',
  roles: [
    {
      role: 'dbAdmin',
      db: 'buddyapi'
    }
  ]
})
