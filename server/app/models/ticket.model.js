const mongoose = require('mongoose');

const TicketSchema = mongoose.Schema({
    userId:         {type: String, require:true },
    solverId:       {type: String, require: true, default: null },
    name:           {type: String, require:true },
    email:          {type: String, require:true },
    title:          {type: String, require:true },
    description:    {type: String, require:true },
    status:         {type: String, require:true },
    date:           {type: Date, default: Date.now }
}, {
    timestamps: true
});

module.exports = mongoose.model('Ticket', TicketSchema);