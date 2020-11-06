import ajax from '@/utils/ajax.js'

export default {
  GetOperListForDoctorInfo: function (data) {
    return ajax({
      url: '/Api/PlatformAnesQuery/QueryOperListForDoctorIndex',
      method: 'post',
      data: data
    })
  },
  GetOperInfosForDoctorIndex: function (data) {
    return ajax({
      url: '/Api/PlatformAnesQuery/QueryOperInfosForDoctorIndex',
      method: 'post',
      data: data
    })
  },
  GetOperListForNurseInfo: function (data) {
    return ajax({
      url: '/Api/PlatformAnesQuery/QueryOperListForNurseIndex',
      method: 'post',
      data: data
    })
  }
}
