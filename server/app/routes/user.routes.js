module.exports = (app) => {
    const users = require('../controllers/user.controller.js');

    // Create a new User
    app.post('/user', users.create);

    // Retrieve all Users
    app.get('/users', users.list);

    //login
    app.post('/user/auth', users.login);

    /*
    // Retrieve a single User with userId
    app.get('/ticket/:ticketId', tickets.findOne);

    // Update a User with userId
    app.put('/ticket/:ticketId', tickets.update);

    // Delete a User with userId
    app.delete('/ticket/:ticketId', tickets.delete);
    */
}