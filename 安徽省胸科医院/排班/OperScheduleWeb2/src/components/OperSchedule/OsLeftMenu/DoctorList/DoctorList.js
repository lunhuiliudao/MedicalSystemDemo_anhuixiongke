
export default {
  name: 'DoctorList',
  data () {
    return {
      opersortway: 1,
      doctorList: []
    }
  },
  computed: {
    leftBodyHeight: function () {
      return (parseInt(document.documentElement.clientHeight) - 73 - 131) + 'px'
    }
  },
  methods: {
    getMedHisUsersDoctors: function () {
      var _this = this
      this.$ajax.get('/Api/ScheduleCommon/GetMedHisUsersDoctors').then(function (response) {
        _this.doctorList = response.data.Data
      })
    },
    drag: function (ev, doctor) {
      ev.dataTransfer.setData('text', JSON.stringify({hisUserJob: 'doctor', hisUserType: this.opersortway, contentInfo: doctor}))
      // ev.dataTransfer.setData('doctorInfo', JSON.stringify({doctorType: this.opersortway, doctor: doctor}))
    }
  },
  created: function () {
    this.getMedHisUsersDoctors()
  }
}
