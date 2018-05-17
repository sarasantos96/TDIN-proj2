const Solver = require('../models/solver.model');
const httpStatus = require('http-status');


/**
 * Create new user
 * @public
 */
exports.create = async (req, res, next) => {
    try {
        const user = new Solver(req.body);
        const savedUser = await user.save();
        res.status(httpStatus.CREATED);
        res.json(savedUser.transform());
    } catch (error) {
        next(User.checkDuplicateEmail(error));
    }
  };

/**
 * Get user list
 * @public
 */
exports.list = async (req, res, next) => {
    try {
      const users = await Solver.list(req.query);
      const transformedUsers = users.map(user => user.transform());
      res.json(transformedUsers);
    } catch (error) {
      next(error);
    }
};

exports.login = async (req, res, next) => {
    try {
      const { user } = await Solver.findSolver(req.body);
      const userTransformed = user.transform();
      return res.json({user: userTransformed });
    } catch (error) {
      return next(error);
    }
};

exports.get = async (req, res, next) => {
  try{
    console.log(req.params.userId);
    const user = await Solver.get(req.params.solverId);
    const userTransformed = user.transform();
    return res.json({user: userTransformed });
  }catch(error){
    next(error);
  }
};