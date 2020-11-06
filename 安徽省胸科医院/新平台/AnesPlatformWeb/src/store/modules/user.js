const user = {
  state: {
    userInfo: typeof sessionStorage.user === 'undefined' ? {} : JSON.parse(sessionStorage.user)
  },
  mutations: {
    ADD_USERINFO: (state, userinfo) => {
      state.userInfo = userinfo
    }
  },
  actions: {
    addUserInfo ({ commit }, userinfo) {
      commit('ADD_USERINFO', userinfo)
    }
  }
}

export default user
