const HomeData = {
  state: {
    dataInfo: new Array(0),
    SearchData: new Array(0),
    OperInfos: new Array(0),
    showfull: false,
    miniBasicInfo: false
  },
  mutations: {
    ADD_DATA_INFO: (state, data) => {
      state.dataInfo = data
    },
    ADD_SEARCH_DATA: (state, data) => {
      state.SearchData = data
    },
    ADD_OPER_INFO: (state, data) => {
      state.OperInfos = data
    }
  },
  actions: {
    addDataInfo ({ commit }, data) {
      commit('ADD_DATA_INFO', data)
    },
    addSearchData ({ commit }, data) {
      commit('ADD_SEARCH_DATA', data)
    },
    addOperInfo ({ commit }, data) {
      commit('ADD_OPER_INFO', data)
    }
  }
}

export default HomeData
