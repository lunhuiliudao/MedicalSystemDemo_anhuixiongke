import ajax from '@/utils/ajax.js'

export function loginByUsername (data) {
  return ajax({
    url: '/Api/PlatformAccount/Login',
    method: 'post',
    data: data
  })
}

export function changePwd (data) {
  return ajax({
    url: '/Api/PlatformAccount/ChangePwd',
    method: 'post',
    data: data
  })
}
