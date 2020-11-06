// import menuList from '../../../public/platformMenu.json'
import { loginByUsername } from '@/api/loginApi.js'
export default {
  name: 'Login',
  data () {
    return {
      acount: {
        loginName: '',
        passWord: ''
      },
      isRemember: false,
      errorMessage: '',
      fullscreenloading: false,
      menuList: []
    }
  },
  methods: {
    initMenuList () {
      this.axios('/platformMenu.json').then(response => {
        this.menuList = response.data
      }).catch(error => {
        console.log(error)
      })
    },
    login () {
      if (this.acount.loginName.trim() === '') {
        this.errorMessage = '用户名不能为空！'
        return
      } else if (this.acount.passWord.trim() === '') {
        this.errorMessage = '密码不能为空！'
        return
      }
      this.fullscreenloading = true
      loginByUsername({
        loginName: this.acount.loginName,
        passWord: this.acount.passWord,
        menuList: this.menuList
      }).then((response) => {
        this.fullscreenloading = false
        this.errorMessage = response.data.Message
        if (this.errorMessage === '') {
          this.setRemember()
          this.$store.dispatch('addUserInfo', response.data.Data)
          sessionStorage.setItem('user', JSON.stringify(response.data.Data))
          this.$router.push({ path: '/home' })
          // var roles = respose.data.Data.USER_ROLE
          // if (roles.indexOf('护士') >= 0) {
          //   _THIS.$router.push({ path: '/NurseIndex' })
          // } else {
          //   _THIS.$router.push({ path: '/DoctorIndex' })
          // }
        }
      }).catch((error) => {
        this.fullscreenloading = false
        console.log(error)
      })
    },
    focusPwd () {
      this.$refs['pwd'].focus()
    },
    iniData () {
      let strRememberUser = localStorage.rememberUser
      if (typeof (strRememberUser) !== 'undefined') {
        let rememberUser = JSON.parse(strRememberUser)
        this.isRemember = rememberUser.isRemember
        this.acount.loginName = rememberUser.loginName
      }
    },
    setRemember () {
      if (this.isRemember) {
        localStorage.setItem('rememberUser', JSON.stringify({ isRemember: this.isRemember, loginName: this.acount.loginName }))
      } else {
        localStorage.removeItem('rememberUser')
      }
    }
  },
  created: function () {
    this.initMenuList()
    this.iniData()
  }
}
