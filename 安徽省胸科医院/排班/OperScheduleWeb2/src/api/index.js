import { Message } from 'element-ui'

// import webconfig from '../../webconfig.json'
// import axios from 'axios'
// axios.defaults.baseURL = webconfig.apiUrl

import axios from 'axios'
axios
  .get('static/webconfig.json')
  .then(result => {
    axios.defaults.baseURL = result.data.apiUrl
  })
  .catch(error => {
    console.log(error)
  })

export default {
  // 获取手术间列表
  getOperRoomByDeptCode: function (cb) {
    axios
      .get('/Api/ScheduleOperSchedule/GetOperRoomByDeptCode')
      .then(function (response) {
        cb(response.data.Data)
      })
  },
  updateOperDetail: function (operDetail, cb) {
    axios
      .post('/Api/ScheduleOperSchedule/UpdateOperationSchedule', operDetail)
      .then(function (response) {
        cb(operDetail)
      })
  },
  UpdateOpertingTime: function (operInfoList, cb) {
    axios
      .post(
        '/Api/ScheduleOperSchedule/UpdateOperationScheduleList',
        operInfoList
      )
      .then(function (response) {
        cb(operInfoList)
      })
  },
  UpdateOpertingNurse: function (operDetail, cb) {
    axios
      .post('/Api/ScheduleOperSchedule/UpdateOperationNurse', operDetail)
      .then(function (response) {
        cb(operDetail)
      })
  },
  UpdateOpertingDoctor: function (operDetail, cb) {
    axios
      .post('/Api/ScheduleOperSchedule/UpdateOperationDoctor', operDetail)
      .then(function (response) {
        cb(operDetail)
      })
  },
  // 提交手术
  SubmitOpertionList: function (operInfoList, cb) {
    axios
      .post(
        '/Api/ScheduleOperSchedule/SubmitOperationScheduleList',
        operInfoList
      )
      .then(function (response) {
        if (response.data.Data.length === operInfoList.length) {
          cb(operInfoList, response.data.Data)
          Message.success({
            duration: 1200,
            message: '提交成功!'
          })
        } else {
          Message.error({
            duration: 1200,
            message: '提交失败!'
          })
        }
      })
  },
  // 取消手术
  CancelOpertion: function (operCanceledInfo, cb) {
    axios
      .post(
        '/Api/ScheduleOperSchedule/CancelOperationSchedule',
        operCanceledInfo
      )
      .then(function (response) {
        if (response.data.Data === true) {
          cb(operCanceledInfo.OperCanceled)
          Message.success({
            duration: 1200,
            message: '手术取消成功!'
          })
        } else {
          Message.error({
            duration: 1200,
            message: '手术取消失败!'
          })
        }
      })
  },
  // 撤销手术
  RevokedOpertion: function (opertionRevoked, cb) {
    axios
      .post(
        '/Api/ScheduleOperSchedule/RevokedOpertionSchedule',
        opertionRevoked
      )
      .then(function (response) {
        if (response.data.Data > 0) {
          cb(opertionRevoked)
          Message.success({
            duration: 1200,
            message: '手术撤销成功!'
          })
        } else {
          Message.error({
            duration: 1200,
            message: '手术撤销失败!'
          })
        }
      })
  },
  // 同步手术信息
  SyncOperList: function (params) {
    return axios.get('/Api/ScheduleSysConfig/SyncOperList', { params: params })
  },
  // 手术名称
  GetOperName: function (params) {
    return axios.get('/Api/ScheduleCommon/GetMedOperationDict', {
      params: params
    })
  },
  // 麻醉名称
  GetAnesthesiaName: function (params) {
    return axios.get('/Api/ScheduleCommon/GetMedAnesthesiaDict', {
      params: params
    })
  },
  // 麻醉医生
  GetAnesDoctors: function (params) {
    return axios.get('/Api/ScheduleCommon/GetAnesDoctorDict', {
      params: params
    })
  },
  // 护士
  GetOperNurses: function (params) {
    return axios.get('/Api/ScheduleCommon/GetOPerNursesDic', { params: params })
  },
  // 手术医生
  GetGetSurgeons: function (params) {
    return axios.get('/Api/ScheduleCommon/GetSurgeonDic', { params: params })
  },
  // 修改手术信息
  ModifyOperDetailInfo: function (operDetail) {
    return axios.post(
      '/Api/ScheduleOperSchedule/UpdateOperDetailInfo',
      operDetail
    )
  },
  // 批量排班
  BatchUpdateOperScheduleList: function (operInfoList, cb) {
    axios
      .post(
        '/Api/ScheduleOperSchedule/BatchUpdateOperationScheduleList',
        operInfoList
      )
      .then(function (response) {
        cb(operInfoList)
      })
  },
  // 批量安排护士
  UpdateOpertingNurseList: function (operInfoList, cb) {
    axios
      .post('/Api/ScheduleOperSchedule/UpdateOperationNurseList', operInfoList)
      .then(function (response) {
        cb(operInfoList)
      })
  },
  // 同步病人检验结果
  SyncLIS101: function (params) {
    return axios.get('/Api/ScheduleSysConfig/SyncLIS101', { params: params })
  },
  // 同步病人医嘱
  SyncOrder103: function (params) {
    return axios.get('/Api/ScheduleSysConfig/SyncOrder103', { params: params })
  }
}
