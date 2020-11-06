import * as types from './mutations_types.js'

export default {
  [types.SELECT_OPERING] (state, operlist) {
    state.leftOperInfo = operlist
  },
  [types.UPDATE_OPERTIME] (state, opertime) {
    state.scheduleDateTime = opertime
  },
  [types.ALLOPERLIST] (state, operlist) {
    state.allOperList = operlist
  },
  [types.SELECT_OPERROOMNOLIST] (state, operRoomNoList) {
    state.OperRoomNoList = operRoomNoList
  },
  [types.UPDATE_OPERDETAIL] (state, operDetail) {
    var tmp = state.allOperList.find(
      o =>
        o.PATIENT_ID === operDetail.PATIENT_ID &&
        o.VISIT_ID === operDetail.VISIT_ID &&
        o.SCHEDULE_ID === operDetail.SCHEDULE_ID
    )
    Object.assign(tmp, operDetail)
  },
  [types.DRAG_OPER_INFO] (state, dragOperInfo) {
    state.dragOperInfo = dragOperInfo
  },
  [types.UPDATE_OPERTING_TIME] (state, operInfoList) {
    for (var i = 0; i < operInfoList.length; i++) {
      var tmp = state.allOperList.find(
        o =>
          o.PATIENT_ID === operInfoList[i].PATIENT_ID &&
          o.VISIT_ID === operInfoList[i].VISIT_ID &&
          o.SCHEDULE_ID === operInfoList[i].SCHEDULE_ID
      )
      Object.assign(tmp, operInfoList[i])
    }
  },
  [types.SUBMIT_OPERTION_LIST] (state, operInfoList) {
    for (var i = 0; i < operInfoList.length; i++) {
      var tmp = state.allOperList.find(
        o =>
          o.PATIENT_ID === operInfoList[i].PATIENT_ID &&
          o.VISIT_ID === operInfoList[i].VISIT_ID &&
          o.SCHEDULE_ID === operInfoList[i].SCHEDULE_ID
      )
      Object.assign(tmp, operInfoList[i])
    }
  },
  [types.SUBMIT_UPDATE_OPERTION_LIST] (state, operInfoList) {
    for (var i = 0; i < operInfoList.length; i++) {
      var tmp = state.allOperList.find(
        o =>
          o.PATIENT_ID === operInfoList[i].PATIENT_ID &&
          o.VISIT_ID === operInfoList[i].VISIT_ID &&
          o.SCHEDULE_ID === operInfoList[i].SCHEDULE_ID
      )
      tmp.OPER_ID = operInfoList[i].OPER_ID
    }
  },
  [types.CANCEL_OPERTION] (state, operCanceled) {
    var tmp = state.allOperList.findIndex(
      o =>
        o.PATIENT_ID === operCanceled.PATIENT_ID &&
        o.VISIT_ID === operCanceled.VISIT_ID &&
        o.SCHEDULE_ID === operCanceled.SCHEDULE_ID
    )
    // tmp.OPER_STATUS_CODE = -80
    state.allOperList.splice(tmp, 1)
  },
  [types.REVOKED_OPERTION] (state, opertionRevoked) {
    var tmp = state.allOperList.find(
      o =>
        o.PATIENT_ID === opertionRevoked.PATIENT_ID &&
        o.VISIT_ID === opertionRevoked.VISIT_ID &&
        o.SCHEDULE_ID === opertionRevoked.SCHEDULE_ID
    )
    tmp.OPER_STATUS_CODE = opertionRevoked.OPER_STATUS_CODE
    if (opertionRevoked.OPER_STATUS_CODE === 0) {
      tmp.ANES_CONFIRM = 0
      tmp.NURSE_CONFIRM = 0
      tmp.FIRST_OPER_NURSE = null
      tmp.FIRST_OPER_NURSE_NAME = null
      tmp.FIRST_SUPPLY_NURSE = null
      tmp.FIRST_SUPPLY_NURSE_NAME = null
      tmp.ANES_DOCTOR = null
      tmp.ANES_DOCTOR_NAME = null
      tmp.FIRST_ANES_ASSISTANT = null
      tmp.FIRST_ANES_ASSISTANT_NAME = null
      tmp.OPER_ROOM_NO = null
      tmp.SEQUENCE = 0
      tmp.OPERATING_TIME = 0
    }
  },
  [types.BATUCH_UPDATE_OPERNURSE] (state, operInfoList) {
    for (var i = 0; i < operInfoList.length; i++) {
      var tmp = state.allOperList.find(
        o =>
          o.PATIENT_ID === operInfoList[i].PATIENT_ID &&
          o.VISIT_ID === operInfoList[i].VISIT_ID &&
          o.SCHEDULE_ID === operInfoList[i].SCHEDULE_ID
      )
      Object.assign(tmp, operInfoList[i])
    }
  }
}
