import * as types from './mutations_types.js'
import api from '../api'

export default {
  actionGetOperRoomNoList ({ commit }) {
    api.getOperRoomByDeptCode(dataObj => {
      commit(types.SELECT_OPERROOMNOLIST, dataObj)
    })
  },
  actionUpdateOperDetail ({ commit }, operDetail) {
    api.updateOperDetail(operDetail, dataObj => {
      commit(types.UPDATE_OPERDETAIL, dataObj)
    })
  },
  actionUpdateOpertingTime ({ commit }, operInfoList) {
    api.UpdateOpertingTime(operInfoList, dataObj => {
      commit(types.UPDATE_OPERTING_TIME, dataObj)
    })
  },
  actionUpdateOpertingNurse ({ commit }, operDetail) {
    api.UpdateOpertingNurse(operDetail, dataObj => {
      commit(types.UPDATE_OPERDETAIL, dataObj)
    })
  },
  actionUpdateOpertingDoctor ({ commit }, operDetail) {
    api.UpdateOpertingDoctor(operDetail, dataObj => {
      commit(types.UPDATE_OPERDETAIL, dataObj)
    })
  },
  actionSubmitOpertionList ({ commit }, operInfoList) {
    api.SubmitOpertionList(operInfoList, (dataObj, returnDataObj) => {
      commit(types.SUBMIT_OPERTION_LIST, dataObj)
      commit(types.SUBMIT_UPDATE_OPERTION_LIST, returnDataObj)
    })
  },
  actionCancelOpertion ({ commit }, operCanceledInfo) {
    api.CancelOpertion(operCanceledInfo, dataObj => {
      commit(types.CANCEL_OPERTION, dataObj)
    })
  },
  actionRevokedOpertion ({ commit }, opertionRevoked) {
    api.RevokedOpertion(opertionRevoked, dataObj => {
      commit(types.REVOKED_OPERTION, dataObj)
    })
  },
  actionBatchUpdateOperScheduleList ({ commit }, operInfoList) {
    api.BatchUpdateOperScheduleList(operInfoList, dataObj => {
      commit(types.UPDATE_OPERTING_TIME, dataObj)
    })
  },
  actionUpdateOpertingNurseList ({ commit }, operInfoList) {
    api.UpdateOpertingNurseList(operInfoList, dataObj => {
      commit(types.BATUCH_UPDATE_OPERNURSE, dataObj)
    })
  }
}
