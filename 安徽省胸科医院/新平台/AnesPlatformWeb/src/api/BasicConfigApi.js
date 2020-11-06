import ajax from '@/utils/ajax.js'

export default {
  // 基础数据管理---科室字典管理
  GetDictList: function (data) {
    return ajax({
      url: '/Api/PlatformCommon/GetDictList',
      method: 'get',
      params: data
    })
  },
  GetAnesInputDictByClass: function (data) {
    return ajax({
      url: '/Api/PlatformCommon/GetAnesInputDictByClass',
      method: 'get',
      params: data
    })
  },
  GetMedDeptDict: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetMedDeptDict',
      method: 'get',
      params: data
    })
  },

  DeletedMedDeptDict: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/DeletedMedDeptDict',
      method: 'post',
      data: data
    })
  },
  EditMedDeptDict: function (type, data) {
    return ajax({
      url: '/Api/PlatformSysConfig/EditMedDeptDict?type=' + type,
      method: 'post',
      data: data
    })
  },
  // 基础数据管理---人员字典管理

  GetMedHisUserDict: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetMedHisUserDict',
      method: 'get',
      params: data
    })
  },
  DeletedMedHisUserDict: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/DeletedMedHisUserDict',
      method: 'post',
      data: data
    })
  },
  EditMedHisUserDict: function (type, data) {
    return ajax({
      url: '/Api/PlatformSysConfig/EditMedHisUserDict?type=' + type,
      method: 'post',
      data: data
    })
  },
  // 基础数据管理---手术字典管理
  GetOperationDict: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetOperationDict',
      method: 'get',
      params: data
    })
  },
  DeletedOperationDict: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/DeletedOperationDict',
      method: 'post',
      data: data
    })
  },
  EditOperationDict: function (type, data) {
    return ajax({
      url: '/Api/PlatformSysConfig/EditOperationDict?type=' + type,
      method: 'post',
      data: data
    })
  },
  // 基础数据管理---诊断字典管理
  GetDiagnosisDict: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetDiagnosisDict',
      method: 'get',
      params: data
    })
  },
  DeletedDiagnosisDict: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/DeletedDiagnosisDict',
      method: 'post',
      data: data
    })
  },
  EditDiagnosisDict: function (type, data) {
    return ajax({
      url: '/Api/PlatformSysConfig/EditDiagnosisDict?type=' + type,
      method: 'post',
      data: data
    })
  },
  // 基础数据管理---常用术语管理
  GetAnesInputDictByItemClass: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetAnesInputDictByItemClass',
      method: 'get',
      params: data
    })
  },
  GetAnesInputDictItemClassList: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetAnesInputDictItemClassList',
      method: 'get',
      params: data
    })
  },
  DeletedAnesInputDict: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/DeletedAnesInputDict',
      method: 'post',
      data: data
    })
  },
  EditAnesInputDict: function (type, data) {
    return ajax({
      url: '/Api/PlatformSysConfig/EditAnesInputDict?type=' + type,
      method: 'post',
      data: data
    })
  },
  // 基础数据管理---给药途径字典维护管理
  GetAdministrationDict: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetAdministrationDict',
      method: 'get',
      params: data
    })
  },
  DeletedAdministrationDict: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/DeletedAdministrationDict',
      method: 'post',
      data: data
    })
  },
  EditAdministrationDict: function (type, data) {
    return ajax({
      url: '/Api/PlatformSysConfig/EditAdministrationDict?type=' + type,
      method: 'post',
      data: data
    })
  },
  // 基础数据管理---麻醉方法字典管理
  GetAnesInputDictByItemClassNoPage: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetAnesInputDictByItemClassNoPage',
      method: 'get',
      params: data
    })
  },
  GetAnesthesiaDict: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetAnesthesiaDict',
      method: 'get',
      params: data
    })
  },

  DeletedAnesthesiaDict: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/DeletedAnesthesiaDict',
      method: 'post',
      data: data
    })
  },
  EditAnesthesiaDict: function (type, data) {
    return ajax({
      url: '/Api/PlatformSysConfig/EditAnesthesiaDict?type=' + type,
      method: 'post',
      data: data
    })
  },
  // 基础数据管理---手术间字典管理
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
  GetOperatingRoomList: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetOperatingRoomList',
      method: 'get',
      params: data
    })
  },
  DeletedOperatingRoomList: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/DeletedOperatingRoomList',
      method: 'post',
      data: data
    })
  },
  EditOperatingRoomList: function (type, data) {
    return ajax({
      url: '/Api/PlatformSysConfig/EditOperatingRoomList?type=' + type,
      method: 'post',
      data: data
    })
  },
  // 基础数据管理---采集仪器字典管理
  GetMonitorDictNoPage: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetMonitorDictNoPage',
      method: 'get',
      params: data
    })
  },
  GetMonitorDict: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetMonitorDict',
      method: 'get',
      params: data
    })
  },

  DeletedMonitorDict: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/DeletedMonitorDict',
      method: 'post',
      data: data
    })
  },
  EditMonitorDict: function (type, data) {
    return ajax({
      url: '/Api/PlatformSysConfig/EditMonitorDict?type=' + type,
      method: 'post',
      data: data
    })
  },
  // 基础数据管理---单位字典管理
  GetUnitDict: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetUnitDict',
      method: 'get',
      params: data
    })
  },

  DeletedUnitDict: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/DeletedUnitDict',
      method: 'post',
      data: data
    })
  },
  EditUnitDict: function (type, data) {
    return ajax({
      url: '/Api/PlatformSysConfig/EditUnitDict?type=' + type,
      method: 'post',
      data: data
    })
  },
  // 基础数据管理---采集项目字典管理
  GetMonitorFunctionCodeNoPage: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetMonitorFunctionCodeNoPage',
      method: 'get',
      params: data
    })
  },
  GetMonitorFunctionCode: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetMonitorFunctionCode',
      method: 'get',
      params: data
    })
  },

  DeletedMonitorFunctionCodeList: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/DeletedMonitorFunctionCodeList',
      method: 'post',
      data: data
    })
  },
  EditMonitorFunctionCodeList: function (type, data) {
    return ajax({
      url: '/Api/PlatformSysConfig/EditMonitorFunctionCodeList?type=' + type,
      method: 'post',
      data: data
    })
  }
}
