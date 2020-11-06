// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import 'babel-polyfill'
import Vue from 'vue'
import ElementUI from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'
import moment from 'moment'
import axios from 'axios'
// import './register/'
import store from './store/store.js'
import router from './router'
import App from './App'

Vue.use(ElementUI)
Object.defineProperty(Vue.prototype, '$moment', { value: moment })

function tokenToSystem (to, from, next, paramWebconfig) {
  axios
    .get(paramWebconfig.ssoApiUrl, {
      params: {
        token: to.query.token
      }
    })
    .then(function (respose) {
      if (respose.data.Data !== null) {
        sessionStorage.setItem('token', to.query.token)
        sessionStorage.setItem('user', JSON.stringify(respose.data.Data))
        next({ path: '/OperSchedule' })
      } else {
        window.location.href = paramWebconfig.ssoWebUrl
      }
    })
    .catch(function (error) {
      console.log(error)
    })
}

function localToSystem (to, from, next, paramWebconfig) {
  let user = JSON.parse(sessionStorage.getItem('user'))
  if (paramWebconfig.sso) {
    if (!user) {
      window.location.href = paramWebconfig.ssoWebUrl
    } else {
      next()
    }
  } else {
    if (to.path === '/login') {
      sessionStorage.removeItem('user')
    }
    if (!user && to.path !== '/login') {
      if (to.path === '/OperQuery') {
        next()
      } else {
        next({ path: '/login' })
      }
    } else {
      next()
    }
  }
}

router.beforeEach((to, from, next) => {
  if (Vue.prototype.webconfig) {
    if (to.query.token) {
      tokenToSystem(to, from, next, Vue.prototype.webconfig)
    } else {
      localToSystem(to, from, next, Vue.prototype.webconfig)
    }
  } else {
    axios
      .get('static/webconfig.json')
      .then(result => {
        Vue.prototype.webconfig = result.data
        sessionStorage.setItem('webconfig', JSON.stringify(result.data))
        axios.defaults.baseURL = result.data.apiUrl
        Vue.prototype.$ajax = axios
        if (to.query.token) {
          tokenToSystem(to, from, next, result.data)
        } else {
          localToSystem(to, from, next, result.data)
        }
      })
      .catch(error => {
        console.log(error)
      })
  }
})

Vue.directive('focus', {
  inserted: function (el, option) {
    var defClass = 'el-input'
    var defTag = 'input'
    var value = option.value || true
    if (typeof value === 'boolean') {
      value = { cls: defClass, tag: defTag, foc: value }
    } else {
      value = {
        cls: value.cls || defClass,
        tag: value.tag || defTag,
        foc: value.foc || false
      }
    }
    if (el.classList.contains(value.cls) && value.foc) {
      el.getElementsByTagName(value.tag)[0].focus()
    }
  }
})

Vue.config.productionTip = false

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  store,
  components: { App },
  template: '<App/>'
})
