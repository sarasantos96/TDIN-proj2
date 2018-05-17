module.exports = (app) => {
   require('./note.routes.js')(app);
   require('./ticket.routes.js')(app);
}