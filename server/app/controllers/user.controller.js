const User = require('../models/user.model');
const httpStatus = require('http-status');


/**
 * Create new user
 * @public
 */
exports.create = async (req, res, next) => {
    try {
        const user = new User(req.body);
        const savedUser = await user.save();
        res.status(httpStatus.CREATED);
        res.json(savedUser.transform());
    } catch (error) {
        return res.json({error: error});
    }
  };

/**
 * Get user list
 * @public
 */
exports.list = async (req, res, next) => {
    try {
      const users = await User.list(req.query);
      const transformedUsers = users.map(user => user.transform());
      res.json(transformedUsers);
    } catch (error) {
      next(error);
    }
};

exports.login = async (req, res, next) => {
    try {
      const { user } = await User.findUser(req.body);
      const userTransformed = user.transform();
      return res.json({user: userTransformed });
    } catch (error) {
      return res.json({error : error});
    }
};

exports.get = async (req, res, next) => {
  try{
    console.log(req.params.userId);
    const user = await User.get(req.params.userId);
    const userTransformed = user.transform();
    return res.json({user: userTransformed });
  }catch(error){
    next(error);
  }
};