module.exports = {
  name: 'head-nav',
  data () {
    return {
      head2: require('../../assets/head-2.png'),
      headMenu: [{ name: '手术安排', path: '/OperSchedule' }, { name: '手术取消', path: '/OperCancel' }, { name: '手术通知单', path: '/OperNotice' }]
    }
  },
  computed: {
    userInfo: function () {
      return JSON.parse(sessionStorage.user)
    }
  },
  methods: {
    logout: function () {
      var _this = this
      this.$confirm('确认退出吗?', '提示', {
        type: 'info'
      }).then(() => {
        sessionStorage.removeItem('user')
        _this.$router.push('/login')
      }).catch(() => {})
    }
  }
}
