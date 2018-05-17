module.exports = (app) => {
    const solvers = require('../controllers/solver.controller.js');

    // Create a new solver
    app.post('/solver/create', solvers.create);

    // Retrieve all solvers
    app.get('/solvers', solvers.list);

    //login
    app.post('/solver/auth', solvers.login);

    // Retrieve a single Solver with solverId
    app.get('/solver/:solverId', solvers.get);
}