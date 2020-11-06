import ajax from '@/utils/ajax.js'

export default {
  // 模板管理---个人路径管理
  GetTempletMenu: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetTempletMenu',
      method: 'get',
      params: data
    })
  },
  GetNewTEMPLETE: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetNewTEMPLETE',
      method: 'get',
      params: data
    })
  },
  GetMedEventDict: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetMedEventDict',
      method: 'get',
      params: data
    })
  },
  GetTempletDetailList: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetTempletDetailList',
      method: 'get',
      params: data
    })
  },
  DeleteTempleteEvent: function (type, data) {
    return ajax({
      url: '/Api/PlatformSysConfig/DeleteTempleteEvent?type=' + type,
      method: 'post',
      data: data
    })
  },
  EditTemplete: function (type, data) {
    return ajax({
      url: '/Api/PlatformSysConfig/EditTemplete?type=' + type,
      method: 'post',
      data: data
    })
  }
}
