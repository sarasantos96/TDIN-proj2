const mongoose = require('mongoose');

const QuestionSchema = mongoose.Schema({
    solverId:          {type: String, require:true },
    otherId:           {type: String, require: true, default: null },
    question:          {type: String, require:true },
    response:          {type: String, default: null},
    ticketId:          {type: String, require:true },
}, {
    timestamps: true
});

module.exports = mongoose.model('Question', QuestionSchema);