import ajax from '@/utils/ajax.js'

export default {
  GetOperatingRoomListNoPage: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetOperatingRoomListNoPage',
      method: 'get',
      params: data
    })
  },
  GetOperatingRoomListAll: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetOperatingRoomListAll',
      method: 'get',
      params: data
    })
  },
  GetPatientInfoList: function (data) {
    return ajax({
      url: '/Api/PlatformNurseManage/GetPatientInfoList',
      method: 'post',
      data: data
    })
  },
  QueryMedicalBasicDoc: function (data) {
    return ajax({
      url: '/Api/PlatformNurseManage/QueryMedicalBasicDoc',
      method: 'get',
      params: data
    })
  },
  PDFUpload: function (data) {
    return ajax({
      url: '/Api/PlatformNurseManage/PDFUpload',
      method: 'post',
      data: data
    })
  },
  GetPlanData: function (data) {
    return ajax({
      url: '/Api/PlatformNurseManage/GetPlanData',
      method: 'get',
      data: data
    })
  },
  SaveMedicalBasicDoc: function (data) {
    return ajax({
      url: '/Api/PlatformNurseManage/SaveMedicalBasicDoc',
      method: 'post',
      data: data
    })
  }
}
