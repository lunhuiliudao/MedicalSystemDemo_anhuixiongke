import Vue from 'vue'
import Vuex from 'vuex'
import errorLog from './modules/errorLog'
import HomeData from './modules/HomeData'
import user from './modules/user'
import AnesReport from './modules/anesReport'
import getters from './getters'

Vue.use(Vuex)

const store = new Vuex.Store({
  modules: {
    errorLog,
    HomeData,
    user,
    AnesReport
  },
  getters
})

export default store
