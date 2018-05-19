<template>
  <div>
    <custom-header></custom-header>
    <div class="mainDiv">
      <el-row>
        <el-col :span="10" :offset="1">
          <h3>Current Tickets:</h3>
        </el-col>
        <el-col :span="8" :offset="2">
          <h3>Create new Ticket:</h3>
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
              <div class="state">
                <div v-if="ticket.status === 'unassigned'">State: <el-tag type="info">Unassigned</el-tag></div>
                <div v-else-if="ticket.status === 'assigned to'">State: <el-tag>Assigned to</el-tag></div>
                <div v-else-if="ticket.status === 'waiting for answers'">Status: <el-tag type="warning">waiting for answers</el-tag></div>
                <div v-else>State: <el-tag type="success">Solved</el-tag></div>
              </div>
            </el-collapse-item>
          </el-collapse>
        </el-col>
        <el-col :span="8" :offset="2">
          <el-row>
            <el-form ref="newTicket" :model="newTicket">
              <el-form-item label="Title">
                <el-input placeholder="Title" v-model="newTicket.title"></el-input>
              </el-form-item>
              <el-form-item label="Description">
                <el-input rows="5" placeholder="Enter description here" type="textarea" v-model="newTicket.description"></el-input>
              </el-form-item>
              <el-form-item class="ticket-button">
                <el-button type="primary" @click="createTicket">Submit Ticket</el-button>
              </el-form-item>
            </el-form>
          </el-row>
        </el-col>
      </el-row>
    </div>
  </div>
</template>

<script>
import customHeader from './customHeader'

export default {
  components: {customHeader},
  name: 'TicketArea',
  data () {
    return {
      user: {
        id: '',
        name: '',
        email: ''
      },
      tickets: [],
      newTicket: {
        title: '',
        description: ''
      }
    }
  },
  methods: {
    updateTable () {
      let request = 'api/ticket/user/' + this.user.id

      this.axios.get(request)
        .then(response => {
          this.tickets = response.data
        })
        .catch(error => {
          console.log('GET request failed with error ' + error)
        })
    },
    createTicket () {
      if (this.newTicket.title === '' || this.newTicket.description === '') {
        alert('You have to fill the title and description fields|')
      }
      else {
        let newTicket = {
          userId: this.user.id,
          name: this.user.name,
          email: this.user.email,
          title: this.newTicket.title,
          description: this.newTicket.description,
          status: 'unassigned'
        }

        this.axios.post('api/ticket', newTicket)
          .then(() => {
            console.log('New ticket created successfully!')
            this.updateTable()
            this.newTicket.title = ''
            this.newTicket.description = ''
          })
          .catch(error => {
            console.log('POST request failed with error ' + error)
          })
      }
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
    margin-bottom: 5%;
  }

  .title {
    font-weight: bold;
  }

  .state {
    margin-top: 4%;
    text-align: right;
    font-weight: bold;
  }

  .ticket-button {
    float: right;
  }

</style>
