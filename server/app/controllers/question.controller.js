const Question = require('../models/question.model.js');

exports.create = (req, res) => {
    // Validate request
    if(!req.body) {
        return res.status(400).send({
            message: "Question body can not be empty"
        });
    }

    const question = new Question({
        solverId:         req.body.solverId,
        otherId:          req.body.otherId,
        question:         req.body.question,
        response:         req.body.response,
        ticketId:         req.body.ticketId
    });

    question.save()
    .then(data => {
        res.send(data);
    }).catch(err => {
        res.status(500).send({
            message: err.message || "Some error occurred while creating the Question."
        });
    });
};

exports.findAll = (req, res) => {
    Question.find()
    .then(questions => {
        res.send(questions);
    }).catch(err => {
        res.status(500).send({
            message: err.message || "Some error occurred while retrieving questions."
        });
    });
};

exports.findOne = (req, res) => {
    Question.findById(req.params.questionId)
    .then(question => {
        if(!question) {
            return res.status(404).send({
                message: "question not found with id " + req.params.questionId
            });            
        }
        res.send(question);
    }).catch(err => {
        if(err.kind === 'ObjectId') {
            return res.status(404).send({
                message: "question not found with id " + req.params.questionId
            });                
        }
        return res.status(500).send({
            message: "Error retrieving question with id " + req.params.questionId
        });
    });
};

exports.update = (req, res) => {
    // Validate Request
    if(!req.body) {
        return res.status(400).send({
            message: "question content can not be empty"
        });
    }

    // Find Ticket and update it with the request body
    Question.findByIdAndUpdate(req.params.questionId, {
        solverId:         req.body.solverId,
        otherId:          req.body.otherId,
        question:         req.body.question,
        response:         req.body.response,
        ticketId:         req.body.ticketId
    }, {new: true})
    .then(question => {
        if(!question) {
            return res.status(404).send({
                message: "question not found with id " + req.params.questionId
            });
        }
        res.send(question);
    }).catch(err => {
        if(err.kind === 'ObjectId') {
            return res.status(404).send({
                message: "question not found with id " + req.params.questionId
            });                
        }
        return res.status(500).send({
            message: "Error updating question with id " + req.params.questionId
        });
    });
};

exports.delete = (req, res) => {
    Question.findByIdAndRemove(req.params.questionId)
    .then(question => {
        if(!question) {
            return res.status(404).send({
                message: "question not found with id " + req.params.questionId
            });
        }
        res.send({message: "question deleted successfully!"});
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

exports.getSolverQuestions = (req, res) => {
    Question.find({solverId: req.params.solverId})
    .then(questions => {
        res.send(questions);
    }).catch(err => {
        res.status(500).send({
            message: err.message || "Some error occurred while retrieving questions."
        });
    });
};

exports.getOtherQuestions = (req, res) => {
    Question.find({otherId: req.params.otherId})
    .then(questions => {
        res.send(questions);
    }).catch(err => {
        res.status(500).send({
            message: err.message || "Some error occurred while retrieving question."
        });
    });
};

