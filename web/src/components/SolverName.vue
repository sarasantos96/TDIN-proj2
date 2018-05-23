<template>
    <el-tag>Assigned to: {{ this.solver }}</el-tag>
</template>

<script>
export default {
  name: 'SolverName',
  props: ['name'],
  data () {
    return {
      solver: ''
    }
  },
  mounted () {
    let app = this
    let request = 'api/solver/' + this.name
    this.axios.get(request)
      .then(response => {
        console.log(response.data)
        app.solver = response.data.user.name
      })
      .catch(error => {
        console.log('GET request failed with error ' + error)
      })
  }
}
</script>
