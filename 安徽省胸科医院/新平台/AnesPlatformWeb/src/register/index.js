import Vue from 'vue'
import moment from 'moment'

Vue.use({
  install (Vue, options) {
    Vue.prototype.$$moment = moment
  }
})

Vue.filter('formatDate', function (value, format) {
  if (value === null) {
    return ''
  } else {
    return moment(value).format(format)
  }
})
