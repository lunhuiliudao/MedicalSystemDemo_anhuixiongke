import Vue from 'vue'
import jquery from 'jquery'
import moment from 'moment'

Vue.use({
  install (Vue, options) {
    Vue.prototype.$$jquery = jquery
    Vue.prototype.$$moment = moment
  }
})
