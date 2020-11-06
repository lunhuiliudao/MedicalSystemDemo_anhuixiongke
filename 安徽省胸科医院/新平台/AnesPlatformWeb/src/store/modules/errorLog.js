const errorLog = {
  state: {
    logs: new Array(0)
  },
  mutations: {
    ADD_ERROR_LOG: (state, log) => {
      state.logs.push(log)
    },
    DELETE_ERROR_LOG: (state) => {
      state.logs = []
    }
  },
  actions: {
    addErrorLog ({ commit }, log) {
      commit('ADD_ERROR_LOG', log)
    },
    deleteErrorLog ({ commit }) {
      commit('DELETE_ERROR_LOG')
    }
  }
}

export default errorLog
