<template>
  <div>
    <custom-header></custom-header>
    <div class="mainDiv">
      <el-row>
        <el-col :span="6" :offset="8">
          <el-tabs v-model="activeName" @tab-click="handleClick">
            <el-tab-pane label="Login" name="first">
              <el-form ref="login" :model="loginForm">
                <el-form-item label="Email">
                  <el-input placeholder="example@example.com" v-model="loginForm.email"></el-input>
                </el-form-item>
                <el-form-item label="Password">
                  <el-input type="password" placeholder="*************" v-model="loginForm.password"></el-input>
                </el-form-item>
                <el-form-item class="formBtn">
                  <el-button type="primary" @click="login('login')">Login</el-button>
                </el-form-item>
              </el-form>
            </el-tab-pane>
            <el-tab-pane label="Register" name="second">
              <el-form ref="register" :model="registerForm">
                <el-form-item label="Name">
                  <el-input placeholder="example@example.com" v-model="registerForm.name"></el-input>
                </el-form-item>
                <el-form-item label="Email">
                  <el-input placeholder="example@example.com" v-model="registerForm.email"></el-input>
                </el-form-item>
                <el-form-item label="Password">
                  <el-input type="password" placeholder="*************" v-model="registerForm.password"></el-input>
                </el-form-item>
                <el-form-item class="formBtn">
                  <el-button type="primary" @click="register('register')">Register</el-button>
                </el-form-item>
              </el-form>
            </el-tab-pane>
          </el-tabs>
        </el-col>
      </el-row>
    </div>
  </div>
</template>

<script>
import ElCol from 'element-ui/packages/col/src/col'
import ElFormItem from '../../node_modules/element-ui/packages/form/src/form-item.vue'
import customHeader from './customHeader'

export default {
  components: {
    ElFormItem,
    ElCol,
    customHeader},
  name: 'Home',
  data () {
    return {
      activeName: 'first',
      loginForm: {
        email: '',
        password: ''
      },
      registerForm: {
        name: '',
        email: '',
        password: ''
      }
    }
  },
  methods: {
    handleClick (tab, event) {
      console.log(tab, event)
    },
    login () {
      if (this.loginForm.email === '' || this.loginForm.password === '') {
        alert('Invalid inputs. Try again!')
      }
      else {
        let app = this
        this.axios.post('api/user/auth', {
          email: this.loginForm.email,
          password: this.loginForm.password
        })
          .then(function (response) {
            localStorage.setItem('id', response.data.user.id)
            localStorage.setItem('name', response.data.user.name)
            localStorage.setItem('email', response.data.user.email)
            app.$router.push({
              name: 'TicketArea'
            })
          })
      }
    },
    register () {
      if (this.registerForm.name === '' || this.registerForm.email === '' || this.registerForm.password === '') {
        alert('Invalid inputs. Try again!')
      }
      else {
        this.axios.post('api/user/create', {
          name: this.registerForm.name,
          email: this.registerForm.email,
          password: this.registerForm.password
        })
          .then(function () {
            alert('registered successfully')
          })
      }
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  .formBtn {
    display: flex;
    align-items: center;
    justify-content: center;
  }

  .mainDiv {
    margin-top: 5%;
  }
</style>
