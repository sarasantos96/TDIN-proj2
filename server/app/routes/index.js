module.exports = (app) => {
   require('./ticket.routes.js')(app);
   require('./user.routes.js')(app);
   require('./solver.routes.js')(app);
   require('./question.routes.js')(app);
}