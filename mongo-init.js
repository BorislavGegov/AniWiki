db.createUser({
  user: 'buddy',
  pwd: 'password',
  roles: [
    {
      role: 'dbAdmin',
      db: 'buddyapi'
    },
    {
      role: 'readWrite',
      db: 'buddyapi'
    },
  ]
})
