import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/components/Home'
import TicketArea from '@/components/TicketArea'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/ticketarea',
      name: 'TicketArea',
      component: TicketArea
    }
  ]
})
