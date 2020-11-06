import ajax from '@/utils/ajax.js'

export default {
  GetMedSelectDict: function (data) {
    return ajax({
      url: '/Api/Common/GetDict',
      method: 'post',
      data: data
    })
  },
  GetEventItemClassDictClass: function (data) {
    return ajax({
      url: '/Api/Dict/GetEventItemClassDictClass',
      method: 'get',
      data: data
    })
  }
}
