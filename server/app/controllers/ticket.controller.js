const Ticket = require('../models/ticket.model.js');

// Create and Save a new Note
exports.create = (req, res) => {
    // Validate request
    if(!req.body) {
        return res.status(400).send({
            message: "Ticket body can not be empty"
        });
    }

    // Create a Ticket
    const ticket = new Ticket({
        name: req.body.name,
        email: req.body.email,
        title: req.body.title,
        description: req.body.description,
        status: req.body.status
    });

    // Save Ticket in the database
    ticket.save()
    .then(data => {
        res.send(data);
    }).catch(err => {
        res.status(500).send({
            message: err.message || "Some error occurred while creating the Ticket."
        });
    });
};

// Retrieve and return all tickets from the database.
exports.findAll = (req, res) => {
    Ticket.find()
    .then(tickets => {
        res.send(tickets);
    }).catch(err => {
        res.status(500).send({
            message: err.message || "Some error occurred while retrieving tickets."
        });
    });
};

// Find a single ticket with a ticketId
exports.findOne = (req, res) => {
    Ticket.findById(req.params.ticketId)
    .then(ticket => {
        if(!ticket) {
            return res.status(404).send({
                message: "Ticket not found with id " + req.params.ticketId
            });            
        }
        res.send(ticket);
    }).catch(err => {
        if(err.kind === 'ObjectId') {
            return res.status(404).send({
                message: "Ticket not found with id " + req.params.ticketId
            });                
        }
        return res.status(500).send({
            message: "Error retrieving ticket with id " + req.params.ticketId
        });
    });
};

// Update a Ticket identified by the TicketId in the request
exports.update = (req, res) => {
    // Validate Request
    if(!req.body) {
        return res.status(400).send({
            message: "Ticket content can not be empty"
        });
    }

    // Find Ticket and update it with the request body
    Ticket.findByIdAndUpdate(req.params.ticketId, {
        name: req.body.name,
        email: req.body.email,
        title: req.body.title,
        description: req.body.description,
        status: req.body.status
    }, {new: true})
    .then(ticket => {
        if(!ticket) {
            return res.status(404).send({
                message: "Ticket not found with id " + req.params.ticketId
            });
        }
        res.send(ticket);
    }).catch(err => {
        if(err.kind === 'ObjectId') {
            return res.status(404).send({
                message: "Ticket not found with id " + req.params.ticketId
            });                
        }
        return res.status(500).send({
            message: "Error updating ticket with id " + req.params.ticketId
        });
    });
};

// Delete a ticket with the specified ticketId in the request
exports.delete = (req, res) => {
    Ticket.findByIdAndRemove(req.params.ticketId)
    .then(ticket => {
        if(!ticket) {
            return res.status(404).send({
                message: "Ticket not found with id " + req.params.ticketId
            });
        }
        res.send({message: "Ticket deleted successfully!"});
    }).catch(err => {
        if(err.kind === 'ObjectId' || err.name === 'NotFound') {
            return res.status(404).send({
                message: "Ticket not found with id " + req.params.ticketId
            });                
        }
        return res.status(500).send({
            message: "Could not delete ticket with id " + req.params.ticketId
        });
    });
};

