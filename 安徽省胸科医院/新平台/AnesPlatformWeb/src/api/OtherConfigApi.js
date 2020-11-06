import ajax from '@/utils/ajax.js'

export default {
  // 文书导航菜单配置
  GetMedConfig: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetMedConfig',
      method: 'get',
      params: data
    })
  },
  ModifyConfigTable: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/ModifyConfigTable',
      method: 'post',
      data: data
    })
  },
  // 数据归类项目配置
  GetAnesMethodClass: function () {
    return ajax({
      url: '/Api/PlatformSysConfig/GetAnesMethodClass',
      method: 'get'
    })
  },
  GetAnesMethodOptions: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetAnesMethodOptions',
      method: 'get',
      params: data
    })
  },

  DeletedAnesMethodClass: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/DeletedAnesMethodClass',
      method: 'get',
      params: data
    })
  },
  AddAnesMethodClass: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/AddAnesMethodClass',
      method: 'post',
      data: data
    })
  },
  // 默认体征项目配置
  GetColors: function () {
    return ajax({
      url: '/Api/PlatformSurgicalMonitor/GetColors',
      method: 'get'
    })
  },
  GetPatientMonitorConfig: function (data) {
    return ajax({
      url: '/Api/PlatformSurgicalMonitor/GetPatientMonitorConfig',
      method: 'get',
      params: data
    })
  },
  UpdatePatientMonitorConfig: function (data) {
    return ajax({
      url: '/Api/PlatformSurgicalMonitor/UpdatePatientMonitorConfig',
      method: 'post',
      data: data
    })
  },
  // 一体机配置
  GetMedConfigSet: function () {
    return ajax({
      url: '/Api/PlatformSysConfig/GetMedConfigSet',
      method: 'get'
    })
  },
  GetInterfaceDetailList: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetInterfaceDetailList',
      method: 'get',
      data: data
    })
  },
  ModifyMedConfigSet: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/ModifyMedConfigSet',
      method: 'post',
      data: data
    })
  },
  SaveInterfaceDetailData: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/SaveInterfaceDetailData',
      method: 'post',
      data: data
    })
  },
  // 工具
  SaveWeChatCloudStatisticsDataAll: function (data) {
    return ajax({
      url: '/Api/PlatformSendWeChatData/SaveWeChatCloudStatisticsDataAll',
      method: 'post',
      data: data
    })
  },
  SaveWeChatCloudQuanlityDataAll: function (data) {
    return ajax({
      url: '/Api/PlatformSendWeChatData/SaveWeChatCloudQuanlityDataAll',
      method: 'post',
      data: data
    })
  },
  SaveDictDataByTableName: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/SaveDictDataByTableName',
      method: 'get',
      params: data
    })
  }
}
