import Vue from 'vue'
import Vuex from 'vuex'
import moment from 'moment'
import mutations from './mutations'
import actions from './actions'

Vue.use(Vuex)

const store = new Vuex.Store({
  // 定义状态
  state: {
    scheduleDateTime: moment().format('YYYY-MM-DD'),
    leftOperInfo: [],
    allOperList: [],
    OperRoomNoList: [],
    dragOperInfo: {}
  },
  mutations,
  actions
})

export default store
