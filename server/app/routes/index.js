module.exports = (app) => {
   require('./note.routes.js')(app);
   require('./ticket.routes.js')(app);
   require('./user.routes.js')(app);
   require('./solver.routes.js')(app);
}