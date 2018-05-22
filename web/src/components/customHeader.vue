<template>
    <div>
        <el-row>
            <el-col :span="10">
                <h1>TroubleTicket</h1>
            </el-col>
            <el-col class="logoutBtn" :span="3" :offset="9">
                <div v-if="user.id !== '' && user.id !== null">
                    <el-button type="primary" @click="logout">Logout</el-button>
                </div>
            </el-col>
        </el-row>
    </div>
</template>

<script>
export default {
  name: 'customHeader',
  data () {
    return {
      user: {
        id: '',
        name: '',
        email: ''
      }
    }
  },
  methods: {
    logout () {
      localStorage.setItem('id', '')
      localStorage.setItem('name', '')
      localStorage.setItem('email', '')
      console.log(this.user)
      this.$router.push({name: 'Home'})
    }
  },
  mounted () {
    this.user.id = localStorage.getItem('id')
    this.user.name = localStorage.getItem('name')
    this.user.email = localStorage.getItem('email')
  }
}
</script>

<style>
    .logoutBtn {
        margin-top: 1%;
    }
</style>