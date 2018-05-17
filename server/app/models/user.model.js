const mongoose = require('mongoose');
const APIError = require('../utils/APIError');
const httpStatus = require('http-status');
const bcrypt = require('bcryptjs');

const userSchema = new mongoose.Schema({
    name : {
        type: String,
        max: 128,
        required: true,
        trim: true
    },
    email: {
        type: String,
        match: /^\S+@\S+\.\S+$/,
        required: true,
        unique: true,
        trim: true,
        lowercase: true
    },
    password: {
        type: String,
        required: true,
        minlength: 6,
        maxlength: 128
    }

});

userSchema.pre('save', async function save(next) {
    try {
      if (!this.isModified('password')) return next();
  
      const rounds = 10;
  
      const hash = await bcrypt.hash(this.password, rounds);
      this.password = hash;
  
      return next();
    } catch (error) {
      return next(error);
    }
});

userSchema.method({
    transform() {
        const transformed = {};
        const fields = ['id', 'name', 'email', 'createdAt'];
    
        fields.forEach((field) => {
          transformed[field] = this[field];
        });
    
        return transformed;
    },

    async passwordMatches(password) {
        return bcrypt.compare(password, this.password);
    }
});

userSchema.statics = {
    /**
   * Get user
   *
   * @param {ObjectId} id - The objectId of user.
   * @returns {Promise<User, APIError>}
   */
  async get(id) {
    try {
      let user;

      if (mongoose.Types.ObjectId.isValid(id)) {
        user = await this.findById(id).exec();
      }
      if (user) {
        return user;
      }

      throw new APIError({
        message: 'User does not exist',
        status: httpStatus.NOT_FOUND,
      });
    } catch (error) {
      throw error;
    }
  },
  
  list() {
    return this.find();
  },

  checkDuplicateEmail(error) {
    if (error.name === 'MongoError' && error.code === 11000) {
      return new APIError({
        message: 'Validation Error',
        errors: [{
          field: 'email',
          location: 'body',
          messages: ['"email" already exists'],
        }],
        status: httpStatus.CONFLICT,
        isPublic: true,
        stack: error.stack,
      });
    }
    return error;
  },

  async findUser(options) {
    const { email, password, refreshObject } = options;
    if (!email) throw new APIError({ message: 'An email is required' });

    const user = await this.findOne({ email }).exec();
    const err = {
      status: httpStatus.UNAUTHORIZED,
      isPublic: true,
    };
    if (password) {
      if (user && await user.passwordMatches(password)) {
        return { user };
      }
      err.message = 'Incorrect email or password';
    } else if (refreshObject && refreshObject.userEmail === email) {
      return { user };
    } else {
      err.message = 'Incorrect email or refreshToken';
    }
    throw new APIError(err);
  },
};

module.exports = mongoose.model('User', userSchema);