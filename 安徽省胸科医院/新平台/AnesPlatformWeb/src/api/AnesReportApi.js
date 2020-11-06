import ajax from '@/utils/ajax.js'

export default {
  getReportConfigByKey (data) {
    return ajax({
      url: '/Api/PlatformAnesQuery/GetReportConfigByKey',
      method: 'get',
      params: data
    })
  },
  execSql (params, data) {
    return ajax({
      url: '/Api/PlatformAnesQuery/ExecSql',
      method: 'post',
      params: params,
      data: data
    })
  },
  exprotExcel (params, data) {
    return ajax({
      url: '/Api/PlatformAnesQuery/ExportExcel',
      method: 'post',
      params: params,
      data: data
    })
  },
  getReportSQL (params, data) {
    return ajax({
      url: '/Api/PlatformAnesQuery/GetReportSQL',
      method: 'post',
      params: params,
      data: data
    })
  },
  getSubReportSQL (params, data) {
    return ajax({
      url: '/Api/PlatformAnesQuery/GetSubReportSQL',
      method: 'post',
      params: params,
      data: data
    })
  },
  getDict (data) {
    return ajax({
      url: '/Api/PlatformAnesQuery/GetDict',
      method: 'post',
      data: data
    })
  },
  execSubSql (params, data) {
    return ajax({
      url: '/Api/PlatformAnesQuery/ExecSubSql',
      method: 'post',
      params: params,
      data: data
    })
  },
  exportSubReportExcel (params, data) {
    return ajax({
      url: '/Api/PlatformAnesQuery/ExportSubReportExcel',
      method: 'post',
      params: params,
      data: data
    })
  },
  getReportConfig () {
    return ajax({
      url: '/Api/PlatformAnesQuery/GetReportConfig',
      method: 'get'
    })
  },
  saveReportInformation (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/SaveReportInformation',
      method: 'post',
      data: data
    })
  },
  getAnesQueryExeclModelList () {
    return ajax({
      url: '/Api/PlatformAnesQuery/GetAnesQueryExeclModelList',
      method: 'post'
    })
  },
  uploadExcelToAnesQueryPath (data) {
    return ajax({
      headers: {
        'Content-Type': 'multipart/form-data'
      },
      url: '/Api/PlatformAnesQuery/UploadExcelToAnesQueryPath',
      method: 'post',
      data: data
    })
  },
  deleteAnesQueryExcelModele (params) {
    return ajax({
      url: '/Api/PlatformAnesQuery/DeleteAnesQueryExcelModele',
      method: 'post',
      params: params
    })
  },
  getReportColumList (params, data) {
    return ajax({
      url: '/Api/PlatformAnesQuery/GetReportColumList',
      method: 'post',
      params: params,
      data: data
    })
  },
  getExeclModelName () {
    return ajax({
      url: '/Api/PlatformAnesQuery/GetExeclModelName',
      method: 'post'
    })
  },
  getReportQueryFromExeclModel (params) {
    return ajax({
      url: '/Api/PlatformAnesQuery/GetReportQueryFromExeclModel',
      method: 'get',
      params: params
    })
  },
  getExcelModleDataDictDefautPath (params) {
    return ajax({
      url: '/Api/PlatformAnesQuery/GetExcelModleDataDictDefautPath',
      method: 'get',
      params: params
    })
  },
  executeOrTestSQLFromUser (data) {
    return ajax({
      url: '/Api/PlatformAnesQuery/ExecuteOrTestSQLFromUser',
      method: 'post',
      data: data
    })
  },
  insertOrUpdateSqlToExcelModleData (data) {
    return ajax({
      url: '/Api/PlatformAnesQuery/InsertOrUpdateSqlToExcelModleData',
      method: 'post',
      data: data
    })
  },
  uploadExcelToDefautPath (data) {
    return ajax({
      headers: {
        'Content-Type': 'multipart/form-data'
      },
      url: '/Api/PlatformAnesQuery/UploadExcelToDefautPath',
      method: 'post',
      data: data
    })
  },
  deleteExcelModele (params) {
    return ajax({
      url: '/Api/PlatformAnesQuery/DeleteExcelModele',
      method: 'get',
      params: params
    })
  }
}
