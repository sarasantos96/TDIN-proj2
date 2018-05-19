<template>
  <div id="app">
    <router-view/>
  </div>
</template>

<script>
import ElCol from 'element-ui/packages/col/src/col'

export default {
  components: {ElCol},
  name: 'App'
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}
</style>
