import ajax from '@/utils/ajax.js'

export default {
  searchInfos: function () {
    return ajax({
      url: '/Api/PlatformQuanlityControl/GetQuanlityControlReportInd',
      method: 'get'
    })
  },
  SubmitReport: function (data) {
    return ajax({
      url: '/Api/PlatformQuanlityControl/SaveQuanlityControlReportInd',
      method: 'post',
      data: data
    })
  },
  getDeptList: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetMedDeptDict',
      method: 'get',
      params: data
    })
  },
  getAnesMethodList: function (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetAnesthesiaDict',
      method: 'get',
      params: data
    })
  },
  getPatientBaseInfo: function (data) {
    return ajax({
      url: '/Api/PlatformQuanlityControl/GetQCPatientBaseInfo',
      method: 'get',
      params: data
    })
  },
  getPatientBaseInfo2: function (data) {
    return ajax({
      url: '/Api/PlatformQuanlityControl/GetQCPatientBaseInfo2',
      method: 'get',
      params: data
    })
  },
  // 获取质控数据
  getAnesInputData: function (data) {
    return ajax({
      url: '/Api/PlatformQuanlityControl/GetMedAnesthesiaInputData',
      method: 'get',
      params: data
    })
  },
  // 保存不良事件登记数据
  saveAnesInputData: function (data) {
    return ajax({
      url: '/Api/PlatformQuanlityControl/SaveMedAnesthesiaInputData',
      method: 'post',
      data: data
    })
  },
  // 查询质控数据统计数据
  searchQuanlityReportInfo: function (data) {
    return ajax({
      url: '/Api/PlatformQuanlityControl/GetQuanlityControlReportItemList',
      method: 'get',
      params: data
    })
  },
  // 质控数据统计统计数据
  extractInfos: function (data) {
    return ajax({
      url: '/Api/PlatformQuanlityControl/SyncQuanlityControlData',
      method: 'get',
      params: data
    })
  },
  // 质控数据统计是否已经上报质控数据
  quanlityIsUploadData: function (data) {
    return ajax({
      url: '/Api/PlatformQuanlityControl/IsQuanlityControlDataUpload',
      method: 'get',
      params: data
    })
  },
  // 质控数据统计生成指控报告数据
  quanlitySaveInfos: function () {
    return ajax({
      url: '/Api/PlatformQuanlityControl/GetQuanlityControlReportInd2',
      method: 'get'
    })
  },
  // 质控数据统计 提交质控数据
  quanlitySubmitData: function (data) {
    return ajax({
      url: '/Api/PlatformQuanlityControl/AddQuanlityControlReportDataBak',
      method: 'get',
      params: data
    })
  },
  // 质控数据统计 导出质控报表
  quanlityExportData: function (data) {
    return ajax({
      url: '/Api/PlatformQuanlityControl/ExportExcel',
      method: 'post',
      data: data
    })
  },
  // 不良事件登记附件上传
  submitFileData: function (data) {
    return ajax({
      url: '/Api/PlatformQuanlityControl/PostFile',
      method: 'post',
      data: data
    })
  },
  // 质控上报数据维护
  GetQuanlityControlReportBakItemList: function (data) {
    return ajax({
      url: '/Api/PlatformQuanlityControl/GetQuanlityControlReportBakItemList',
      method: 'get',
      params: data
    })
  },
  // 保存质控上报数据维护
  SaveQuanlityControlReportInd: function (data) {
    return ajax({
      url: '/Api/PlatformQuanlityControl/SaveQuanlityControlReportInd',
      method: 'post',
      data: data
    })
  },
  // 保存质控上报数据维护
  IsQuanlityControlDataUploadByReportName: function (data) {
    return ajax({
      url:
        '/Api/PlatformQuanlityControl/IsQuanlityControlDataUploadByReportName',
      method: 'get',
      params: data
    })
  },
  // 修改不良事件上报标识
  UploadQuanlityControlAeBakData: function (data) {
    return ajax({
      url: '/Api/PlatformQuanlityControl/UploadQuanlityControlAeBakData',
      method: 'post',
      data: data
    })
  },
  // 查询上报数据明细
  GetQuanlityControlAeBakPatientInfoDataByReportNameAndReportNo: function (
    data
  ) {
    return ajax({
      url:
        '/Api/PlatformQuanlityControl/GetQuanlityControlAeBakPatientInfoDataByReportNameAndReportNo',
      method: 'get',
      params: data
    })
  },
  // 保存上报数据维护
  SaveQuanlityControlReportDataBak: function (data) {
    return ajax({
      url: '/Api/PlatformQuanlityControl/SaveQuanlityControlReportDataBak',
      method: 'post',
      data: data
    })
  },

  // 保存不良事件登记数据----室外
  saveOutAnesInputData: function (data) {
    return ajax({
      url: '/Api/PlatformQuanlityControl/SaveOutMedAnesthesiaInputData',
      method: 'post',
      data: data
    })
  },
  getPatientBaseInfoOut: function (data) {
    return ajax({
      url: '/Api/PlatformQuanlityControl/GetQCPatientBaseInfoOut',
      method: 'get',
      params: data
    })
  },
  // 获取质控数据
  getAnesInputDataOut: function (data) {
    return ajax({
      url: '/Api/PlatformQuanlityControl/GetMedAnesthesiaInputDataOut',
      method: 'get',
      params: data
    })
  },
  getPatientBaseInfoOut2: function (data) {
    return ajax({
      url: '/Api/PlatformQuanlityControl/GetQCPatientBaseInfoOut2',
      method: 'get',
      params: data
    })
  },
  // 查询上报数据明细
  GetQuanlityControlAeBakPatientInfoDataByReportNameAndReportNoOut: function (
    data
  ) {
    return ajax({
      url:
        '/Api/PlatformQuanlityControl/GetQuanlityControlAeBakPatientInfoDataByReportNameAndReportNoOut',
      method: 'get',
      params: data
    })
  }
}
