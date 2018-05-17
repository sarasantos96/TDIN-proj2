module.exports = (app) => {
    const tickets = require('../controllers/ticket.controller.js');
  
    // Create a new Note
    app.post('/ticket', tickets.create);

    // Retrieve all Notes
    app.get('/tickets', tickets.findAll);

    // Retrieve a single Note with noteId
    app.get('/ticket/:ticketId', tickets.findOne);

    // Update a Note with noteId
    app.put('/ticket/:ticketId', tickets.update);

    // Delete a Note with noteId
    app.delete('/ticket/:ticketId', tickets.delete);

    //Get user tickets
    app.get('/ticket/user/:userId',tickets.getUserTickets);

    //Get solver tickets
    app.get('/ticket/solver/:solverId', tickets.getSolverTickets);
}