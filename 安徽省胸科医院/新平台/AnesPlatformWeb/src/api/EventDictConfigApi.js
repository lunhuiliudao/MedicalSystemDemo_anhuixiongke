import ajax from '@/utils/ajax.js'

export default {
  // 术中用药管理---麻药维护
  NewMedEventDict: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/NewMedEventDict',
      method: 'get',
      params: data
    })
  },

  GetMedEventDictNoPage: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetMedEventDictNoPage',
      method: 'get',
      params: data
    })
  },
  GetAdministrationDict: function (data) {
    return ajax({
      url: '/Api/PlatformCommon/GetAdministrationDict',
      method: 'get',
      params: data
    })
  },
  DeletedMedEventDict: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/DeletedMedEventDict',
      method: 'post',
      data: data
    })
  },
  EditMedEventDict: function (type, data) {
    return ajax({
      url: '/Api/PlatformSysConfig/EditMedEventDict?type=' + type,
      method: 'post',
      data: data
    })
  },
  GetMedEventDictExt: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetMedEventDictExt',
      method: 'get',
      params: data
    })
  },
  NewMedEventExtDict: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/NewMedEventExtDict',
      method: 'get',
      params: data
    })
  },
  DeletedMedEventExtDict: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/DeletedMedEventExtDict',
      method: 'post',
      data: data
    })
  },
  EditMedEventExtDict: function (type, data) {
    return ajax({
      url: '/Api/PlatformSysConfig/EditMedEventExtDict?type=' + type,
      method: 'post',
      data: data
    })
  }
}
