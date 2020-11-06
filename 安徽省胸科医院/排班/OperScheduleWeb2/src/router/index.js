import Vue from 'vue'
import Router from 'vue-router'
import Login from '@/components/Login/Login.vue'
import Home from '@/components/Home.vue'
import OperSchedule from '@/components/OperSchedule/OperSchedule.vue'
import OperCancel from '@/components/OperCancel/OperCancel.vue'
import OperNotice from '@/components/OperNotice/OperNotice.vue'
import OperQuery from '@/components/OperQuery/OperQuery.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/Login',
      component: Login
    },
    {
      path: '/',
      component: Home,
      alias: '/',
      children: [
        { path: '/', component: OperSchedule },
        { path: '/OperSchedule', component: OperSchedule }
      ]
    },
    {
      path: '/',
      component: Home,
      children: [
        { path: '/OperNotice', component: OperNotice }
      ]
    },
    {
      path: '/',
      component: Home,
      children: [
        { path: '/OperCancel', component: OperCancel }
      ]
    },
    {
      path: '/OperQuery',
      component: OperQuery
    }
  ]
})
