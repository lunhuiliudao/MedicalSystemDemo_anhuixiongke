const anesReport = {
  state: {
    currentReportInformation: null,
    ISFROMMEDICALRECORD: false
  },
  mutations: {
    SET_REPORTCONDITION: (state, info) => {
      state.currentReportInformation = info
    },
    SET_ISFROMMEDICALRECORD: (state, fromType) => {
      state.ISFROMMEDICALRECORD = fromType
    }
  }
}

export default anesReport
