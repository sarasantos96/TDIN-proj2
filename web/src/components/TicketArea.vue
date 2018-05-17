<template>
  <div class="mainDiv">
    <el-row>
      <el-col :span="5" :offset="1">
        <h3>Current Tickets:</h3>
      </el-col>
    </el-row>
    <el-row>
      <el-col :span="10" :offset="1">
        <el-collapse v-for="ticket in tickets" :key="ticket.title">
          <el-collapse-item :name="ticket.title">
            <template class="title" slot="title">
              <div class="title">
                {{ ticket.title }}
              </div>
            </template>
            <div>{{ ticket.description }}</div>
          </el-collapse-item>
        </el-collapse>
      </el-col>
    </el-row>
  </div>
</template>

<script>
export default {
  name: 'TicketArea',
  data () {
    return {
      user: {
        id: '',
        name: '',
        email: ''
      },
      tickets: []
    }
  },
  mounted () {
    this.user.id = localStorage.getItem('id')
    this.user.name = localStorage.getItem('name')
    this.user.email = localStorage.getItem('email')

    let request = 'api/ticket/user/' + this.user.id

    this.axios.get(request)
      .then(response => {
        this.tickets = response.data
        console.log(this.tickets)
        console.log(this.tickets.length)
      })
      .catch(error => {
        console.log('GET request failed with error ' + error)
      })
  }
}
</script>

<style>
  .mainDiv {
    margin-top: 5%;
  }

  .title {
    font-weight: bold;
  }
</style>
