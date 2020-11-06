import $ from 'jquery'

export default {
  name: 'Login',
  data () {
    return {
      acount: {
        loginname: '',
        password: ''
      },
      remeberme: false,
      message: '',
      rules2: {
        loginname: [{
          validator: function (rule, value, callback) {
            if (!value) {
              return callback(new Error('用户名不能为空！'))
            } else {
              callback()
            }
          },
          trigger: 'blur'
        }],
        password: [{
          validator: function (rule, value, callback) {
            if (!value) {
              return callback(new Error('密码不能为空！'))
            } else {
              callback()
            }
          },
          trigger: 'blur'}]
      },
      fullscreenloading: false,
      winsize: {
        width: '',
        height: ''
      },
      formoffset: {
        left: '',
        top: '',
        width: '600px',
        height: '420px',
        position: 'absolute'
      }
    }
  },
  methods: {
    login: function (formname) {
      var _THIS = this
      this.$refs[formname].validate(function (valid) {
        if (valid) {
          _THIS.fullscreenloading = true
          _THIS.$ajax({
            method: 'post',
            url: '/Api/ScheduleAccount/Login',
            data: { loginName: _THIS.acount.loginname, passWord: _THIS.acount.password }
          }).then(function (respose) {
            _THIS.message = respose.data.Message
            if (_THIS.message !== '') {
              _THIS.fullscreenloading = false
              return
            }
            _THIS.setRemember()
            sessionStorage.setItem('user', JSON.stringify(respose.data.Data))
            _THIS.$router.push({ path: '/OperSchedule' })
            _THIS.fullscreenloading = false
          })
            .catch(function (error) {
              if (error.response) {
                console.log(error.response.data)
                console.log(error.response.status)
              } else {
                console.log('Error', error.message)
              }
              console.log(error.config)
              _THIS.fullscreenloading = false
            })
        } else {
          console.log('error submit!!')
          return false
        }
      })
    },
    reset: function (formname) {
      this.acount.loginname = ''
      this.acount.password = ''
      this.remeberme = false
      this.message = ''
    },
    resize: function () {
      this.winsize.width = $(window).width() + 'px'
      this.winsize.height = $(window).height() + 'px'
      this.formoffset.left = (parseInt(this.winsize.width) / 2 - 300) + 'px'
      this.formoffset.top = (parseInt(this.winsize.height) / 2 - 210) + 'px'
    },
    inidata: function () {
      var lsRemeberme = localStorage.remeberme
      if (typeof (lsRemeberme) !== 'undefined') {
        var jsonRemeberme = JSON.parse(lsRemeberme)
        this.remeberme = jsonRemeberme.isRemeberme
        this.acount.loginname = jsonRemeberme.userName
      }
    },
    setRemember: function () {
      if (this.remeberme === true) {
        localStorage.setItem('remeberme', JSON.stringify({isRemeberme: true, userName: this.acount.loginname}))
      } else {
        localStorage.removeItem('remeberme')
      }
    }
  },
  created: function () {
    this.resize()
    this.inidata()
    $(window).resize(this.resize)
  }
}
