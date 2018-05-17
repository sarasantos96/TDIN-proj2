<template>
  <div>
    oi
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
  }
}
</script>

<style>
</style>
