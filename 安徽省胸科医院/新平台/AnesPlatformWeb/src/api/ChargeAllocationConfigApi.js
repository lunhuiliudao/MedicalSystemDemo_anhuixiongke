import ajax from '@/utils/ajax.js'

export default {
  // 收费管理---收费项目字典管理
  GetValuationItemList: function (data) {
    return ajax({
      url: '/Api/PlatformChargeInfo/GetValuationItemList',
      method: 'get',
      params: data
    })
  },
  GetBillDict: function (data) {
    return ajax({
      url: '/Api/PlatformChargeInfo/GetBillDict',
      method: 'get',
      params: data
    })
  },
  GetAnesVsCharge: function (data) {
    return ajax({
      url: '/Api/PlatformChargeInfo/GetAnesVsCharge',
      method: 'get',
      params: data
    })
  },
  GetPriceList: function (data) {
    return ajax({
      url: '/Api/PlatformChargeInfo/GetPriceList',
      method: 'get',
      params: data
    })
  },
  GetTimeoutAnesVsCharge: function (data) {
    return ajax({
      url: '/Api/PlatformChargeInfo/GetTimeoutAnesVsCharge',
      method: 'get',
      params: data
    })
  },

  DeletedAnesVsCharge: function (data) {
    return ajax({
      url: '/Api/PlatformChargeInfo/DeletedAnesVsCharge',
      method: 'post',
      data: data
    })
  },
  DeletedMedValuationItemList: function (data) {
    return ajax({
      url: '/Api/PlatformChargeInfo/DeletedMedValuationItemList',
      method: 'post',
      data: data
    })
  },

  EditMedValuationItemList: function (type, data) {
    return ajax({
      url: '/Api/PlatformChargeInfo/EditMedValuationItemList?type=' + type,
      method: 'post',
      data: data
    })
  },
  EditAnesVsCharge: function (type, data) {
    return ajax({
      url: '/Api/PlatformChargeInfo/EditAnesVsCharge?type=' + type,
      method: 'post',
      data: data
    })
  },
  EditAnesVsChargeAll: function (data) {
    return ajax({
      url: '/Api/PlatformChargeInfo/EditAnesVsCharge',
      method: 'post',
      data: data
    })
  },
  // 收费管理---收费模板管理
  GetTempletBillMenu: function () {
    return ajax({
      url: '/Api/PlatformChargeInfo/GetTempletBillMenu',
      method: 'get'
    })
  },
  GetAnesBillTemplet: function (data) {
    return ajax({
      url: '/Api/PlatformChargeInfo/GetAnesBillTemplet',
      method: 'get',
      params: data
    })
  },
  DeleteAnesBillTemplete: function (type, data) {
    return ajax({
      url: '/Api/PlatformChargeInfo/DeleteAnesBillTemplete?type=' + type,
      method: 'post',
      data: data
    })
  },

  EditAnesBillTemplete: function (type, data) {
    return ajax({
      url: '/Api/PlatformChargeInfo/EditAnesBillTemplete?type=' + type,
      method: 'post',
      data: data
    })
  }
}
