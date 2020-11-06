import ajax from '@/utils/ajax.js'

export default {
  getSyncLIS101 (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/SyncLIS101',
      method: 'get',
      params: data
    })
  },
  GetMedLabTestMaster (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetMedLabTestMaster',
      method: 'get',
      params: data
    })
  },
  GetMedLabResult (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetMedLabResult',
      method: 'get',
      params: data
    })
  },
  GetPatientInfo (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetPatientInfo',
      method: 'get',
      params: data
    })
  },
  GetPatientDocument (data) {
    return ajax({
      url: '/Api/PlatformSysConfig/GetPatientDocument',
      method: 'get',
      params: data
    })
  }
}
