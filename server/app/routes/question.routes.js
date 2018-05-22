module.exports = (app) => {
    const questions = require('../controllers/question.controller.js');
  
    // Create a new Note
    app.post('/question', questions.create);

    // Retrieve all Notes
    app.get('/questions', questions.findAll);

    // Retrieve a single Note with noteId
    app.get('/question/:questionId', questions.findOne);

    // Update a Note with noteId
    app.put('/question/:questionId', questions.update);

    // Delete a Note with noteId
    app.delete('/question/:questionId', questions.delete);

    //Get user tickets
    app.get('/question/solver/:solverId',questions.getSolverQuestions);

    //Get solver tickets
    app.get('/question/other/:otherId', questions.getOtherQuestions);
}