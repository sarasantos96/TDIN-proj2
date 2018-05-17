const mongoose = require('mongoose');

const TicketSchema = mongoose.Schema({
    name: String,
    email: String,
    title: String,
    description: String,
    status: String,
    date: { type: Date, default: Date.now }
}, {
    timestamps: true
});

module.exports = mongoose.model('Ticket', TicketSchema);