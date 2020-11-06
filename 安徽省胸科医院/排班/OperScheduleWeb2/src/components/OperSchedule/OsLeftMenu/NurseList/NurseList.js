
export default {
  name: 'NurseList',
  data () {
    return {
      opersortway: 1,
      nursesList: []
    }
  },
  computed: {
    leftBodyHeight: function () {
      return (parseInt(document.documentElement.clientHeight) - 73 - 131) + 'px'
    }
  },
  methods: {
    getMedHisUsersNurses: function () {
      var _this = this
      this.$ajax.get('/Api/ScheduleCommon/GetMedHisUsersNurses').then(function (response) {
        _this.nursesList = response.data.Data
      })
    },
    drag: function (ev, nurse) {
      ev.dataTransfer.setData('text', JSON.stringify({hisUserJob: 'nuser', hisUserType: this.opersortway, contentInfo: nurse}))
      // ev.dataTransfer.setData('nurseInfo', JSON.stringify({nurseType: this.opersortway, nuser: nurse}))
    }
  },
  created: function () {
    this.getMedHisUsersNurses()
  }
}
