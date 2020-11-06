import Vue from 'vue'
import ElementUI from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'
import App from './App.vue'
import router from './router'
import store from './store/'
import VueHighlightJS from 'vue-highlightjs'
import animated from 'animate.css'
import './assets/styles/fonts/iconfont.css'
import './assets/styles/global.scss'
import './register'
import Print from 'vue-print-nb'
import axios from 'axios'
import service from '@/utils/ajax.js'
import Print2 from '@/plugs/print'
Vue.use(animated)
Vue.use(ElementUI)
Vue.use(VueHighlightJS)

Vue.use(Print) // 注册
Vue.use(Print2)

Vue.config.productionTip = false

function routerprocess (to, next) {
  if (to.path !== '/login') {
    if (to.path === '/PatientInfo') {
      next()
    } else {
      if (store.getters.user.hasOwnProperty('USER_ID')) {
        next()
      } else {
        router.push({ path: '/login' })
      }
    }
  }
  next()
}

router.beforeEach((to, from, next) => {
  if (Vue.prototype.webconfig) {
    routerprocess(to, next)
  } else {
    axios.get('/webconfig.json').then(response => {
      Vue.prototype.webconfig = response.data
      service.defaults.baseURL = response.data.apiUrl
      routerprocess(to, next)
    }).catch(error => {
      console.log(error)
    })
  }
})

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
