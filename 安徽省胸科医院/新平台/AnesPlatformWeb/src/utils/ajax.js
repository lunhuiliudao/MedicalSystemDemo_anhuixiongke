
import Vue from 'vue'
import store from '@/store/'
import axios from 'axios'
import VueAxios from 'vue-axios'
Vue.use(VueAxios, axios)

const service = Vue.axios.create({
  // baseURL: webconfig.apiUrl,
  timeout: 15000 // 请求超时
})

// axios('/webconfig.json').then(response => {
//   Vue.prototype.webconfig = response.data
//   service.defaults.baseURL = response.data.apiUrl
// }).catch(error => {
//   console.log(error)
// })

service.interceptors.response.use(function (response) {
  // 请求正常则返回
  if (response.data.Result > 2) {
    const httpError = {
      status: 200,
      statusText: response.data.Result,
      message: response.data.Message,
      path: response.request.responseURL
    }
    store.dispatch('addErrorLog', httpError)
  }
  return Promise.resolve(response)
}, function (error) {
  // 请求错误则向store commit这个状态变化
  let httpError = {}
  if (error.response) {
    httpError = {
      status: error.response.status,
      statusText: error.response.statusText,
      message: error.message,
      path: error.request.responseURL
    }
  } else {
    httpError = {
      status: 'undefined',
      statusText: error.stack,
      message: error.message,
      path: error.config.url
    }
  }
  store.dispatch('addErrorLog', httpError)
  return Promise.reject(error)
})

export default service
