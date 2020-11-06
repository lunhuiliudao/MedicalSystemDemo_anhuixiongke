import ajax from '@/utils/ajax.js'

export default {
  GetAnesRecordInfo: function (data) {
    return ajax({
      url: '/Api/PlatformAnesInfo/QueryOutOperatingAnesRecord',
      method: 'post',
      data: data
    })
  },
  GetAnesRecordInfoByPatient: function (data) {
    return ajax({
      url: '/Api/PlatformAnesInfo/GetOutOperatingRoomAnesRecordByPatient',
      method: 'get',
      params: data
    })
  },
  GetOutOperatingRoomAnesRecord: function (data) {
    return ajax({
      url: '/Api/PlatformAnesInfo/GetOutOperatingRoomAnesRecord',
      method: 'get',
      params: data
    })
  },
  SaveOutOperatingRoomAnesRecordData: function (data) {
    return ajax({
      url: '/Api/PlatformAnesInfo/SaveOutOperatingRoomAnesRecordData',
      method: 'post',
      data: data
    })
  },
  GetOperatingRoomListAll: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetOperatingRoomListAll',
      method: 'get',
      params: data
    })
  },
  GetOperatingRoomListNoPage: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetOperatingRoomListNoPage',
      method: 'get',
      params: data
    })
  },
  GetMedDeptInOperRoomDict: function (data) {
    return ajax({
      url: '/Api/PlatformNurseManage/GetMedDeptInOperRoomDict',
      method: 'get',
      params: data
    })
  }
}
