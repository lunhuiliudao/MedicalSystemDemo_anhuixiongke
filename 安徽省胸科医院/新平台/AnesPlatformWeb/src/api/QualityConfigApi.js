import ajax from '@/utils/ajax.js'

export default {
  // 获取质控项目字典数据
  GetQuanlityControlItemList: function () {
    return ajax({
      url: '/Api/PlatformQuanlityControl/GetQuanlityControlItemList',
      method: 'get'
    })
  },
  DeletedQuanlityControlItemList: function (data) {
    return ajax({
      url: '/Api/PlatformQuanlityControl/DeletedQuanlityControlItemList',
      method: 'post',
      data: data
    })
  },
  EditQuanlityControlItem: function (type, data) {
    return ajax({
      url: '/Api/PlatformQuanlityControl/EditQuanlityControlItem?type=' + type,
      method: 'post',
      data: data
    })
  },
  // 获取质控报表字典数据
  GetQuanlityControlReportList: function () {
    return ajax({
      url: '/Api/PlatformQuanlityControl/GetQuanlityControlReportList',
      method: 'get'
    })
  },
  DeletedQuanlityControlReportList: function (data) {
    return ajax({
      url: '/Api/PlatformQuanlityControl/DeletedQuanlityControlReportList',
      method: 'post',
      data: data
    })
  },
  EditQuanlityControlReportList: function (type, data) {
    return ajax({
      url:
        '/Api/PlatformQuanlityControl/EditQuanlityControlReportList?type=' +
        type,
      method: 'post',
      data: data
    })
  },
  // 获取质控上报配置数据
  GetXmlDataForQCNoByName: function () {
    return ajax({
      url: '/Api/PlatformQuanlityControl/GetXmlDataForQCNoByName',
      method: 'get'
    })
  },
  GetXmlDataForQC: function (data) {
    return ajax({
      url: '/Api/PlatformQuanlityControl/GetXmlDataForQC',
      method: 'get',
      params: data
    })
  },

  DeletedXmlDataForQC: function (data) {
    return ajax({
      url: '/Api/PlatformQuanlityControl/DeletedXmlDataForQC',
      method: 'post',
      data: data
    })
  },
  SaveXmlDataForQC: function (data) {
    return ajax({
      url: '/Api/PlatformQuanlityControl/SaveXmlDataForQC',
      method: 'post',
      data: data
    })
  }
}
