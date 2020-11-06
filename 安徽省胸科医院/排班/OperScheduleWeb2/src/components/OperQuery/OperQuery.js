import $ from 'jquery'

export default {
  name: 'OperQuery',
  data: function () {
    return {
      scheduleDateTime: this.$moment().format('YYYY-MM-DD'),
      operNoticeData: [],
      operNoticeList: [],
      operNoticeListPrint: [],
      operNoticeSelectData: [],
      selectDept: '',
      selectDoctor: '',
      condition: {DictType: ''},
      options: [],
      options2: []
    }
  },
  props: {
    width: {
      type: Number,
      default: parseInt(document.documentElement.clientWidth)
    },
    height: {
      type: Number,
      default: parseInt(document.documentElement.clientHeight) - 70
    }
  },
  computed: {
    comScheduleDateTime: function () {
      return this.$moment(this.scheduleDateTime).format('YYYY-MM-DD')
    },
    comOperNoticeList: function () {
      this.operNoticeList.forEach(function (eletemp) {
        if (eletemp.width === 0) {
          eletemp.widthObj = { 'min-width': eletemp.width }
        } else {
          eletemp.widthObj = { width: eletemp.width }
        }
      }, this)
      return this.operNoticeList
    },
    comOperNoticeListPrint: function () {
      this.operNoticeListPrint.forEach(function (eletemp) {
        if (eletemp.width === 0) {
          eletemp.widthObj = ''
        } else {
          eletemp.widthObj = { width: eletemp.width }
        }
      }, this)
      return this.operNoticeListPrint
    }
  },
  created: function () {
    // 第三方链接路由跳转
    this.GetParams().then(val => {
      this.GetData()
    })

    this.$ajax
      .get(
        location.protocol +
          '//' +
          location.host +
          '/static/config/noticeConfig.json'
      )
      .then(response => {
        this.operNoticeList = response.data.operNotice
        this.operNoticeListPrint = response.data.operNoticePrint
        this.getOperNoticeList()
      })
  },
  methods: {
    getOperNoticeList: function () {
      var _this = this
      this.$ajax
        .get('/Api/ScheduleOperNotice/GetOperScheduleQueryList', {
          params: {
            ScheduleDateTime: _this.scheduleDateTime,
            DeptCode: _this.selectDept,
            Doctor: _this.selectDoctor
          }
        })
        .then(function (response) {
          _this.operNoticeData = response.data.Data
        })
    },
    preview: function (oper) {
      var printHtml = $('#noticePrintArea').html()
      let newWindow = window.open('_blank')
      newWindow.document.write(printHtml)
      newWindow.document.close()
      newWindow.print()
      newWindow.close()
    },
    previewPage: function (oper) {
      var printHtml = $('#noticePrintPageArea').html()
      let newWindow = window.open('_blank')
      newWindow.document.write(printHtml)
      newWindow.document.close()
      newWindow.print()
      newWindow.close()
    },
    selectionChangeFun: function (selection) {
      this.operNoticeSelectData = selection
    },
    GetParams () {
      // 第三方链接路由跳转
      if (this.$route.query.DeptCode !== null && this.$route.query.DeptCode !== undefined) {
        this.selectDept = this.$route.query.DeptCode
      }
      if (this.$route.query.Doctor !== null && this.$route.query.Doctor !== undefined) {
        this.selectDoctor = this.$route.query.Doctor
      }

      return Promise.resolve()
    },
    GetData () {
      var _this = this
      this.condition.DictType = 'DeptDict'
      this.$ajax
        .post('/Api/PlatformAnesQuery/GetDict', this.condition)
        .then((respose) => {
          if (_this.selectDept !== null && _this.selectDept !== '') {
            var ops = respose.data.Data.filter(item => {
              return (
                item.Key.toUpperCase().indexOf(_this.selectDept.toUpperCase()) > -1 ||
                item.Value.toUpperCase().indexOf(_this.selectDept.toUpperCase()) > -1
              )
            })
            _this.options = ops
          }
          if (sessionStorage.getItem('deptlistOperQuery') === null) {
            sessionStorage.setItem(
              'deptlistOperQuery',
              JSON.stringify(respose.data.Data)
            )
          }
          this.GetData2()
        })
        .catch(error => {
          console.log(error)
        })
    },
    remoteMethod (query) {
      if (query !== '') {
        var list = JSON.parse(sessionStorage.getItem('deptlistOperQuery'))
        var ops = list.filter(item => {
          if (
            item.InputCode !== null &&
            item.InputCode !== '' &&
            item.InputCode !== undefined
          ) {
            return (
              item.InputCode.toUpperCase().indexOf(query.toUpperCase()) > -1
            )
          }
        })
        if (ops.length > 100) {
          this.options = ops.slice(0, 100)
        } else {
          this.options = ops
        }
      }
    },
    GetData2 () {
      var _this = this
      this.condition.DictType = 'DoctorNurseDict'
      this.$ajax
        .post('/Api/PlatformAnesQuery/GetDict', this.condition)
        .then(function (respose) {
          if (_this.selectDoctor !== null && _this.selectDoctor !== '') {
            var ops = respose.data.Data.filter(item => {
              return (
                item.Key.toUpperCase().indexOf(_this.selectDoctor.toUpperCase()) > -1 ||
                item.Value.toUpperCase().indexOf(_this.selectDoctor.toUpperCase()) > -1
              )
            })
            _this.options2 = ops
          }
          if (sessionStorage.getItem('DoctorNurseDictOperQuery') === null) {
            sessionStorage.setItem(
              'DoctorNurseDictOperQuery',
              JSON.stringify(respose.data.Data)
            )
          }
        })
        .catch(error => {
          console.log(error)
        })
    },
    remoteMethod2 (query) {
      if (query !== '') {
        var list = JSON.parse(sessionStorage.getItem('DoctorNurseDictOperQuery'))
        var ops = list.filter(item => {
          if (
            item.InputCode !== null &&
            item.InputCode !== '' &&
            item.InputCode !== undefined
          ) {
            return (
              item.InputCode.toUpperCase().indexOf(query.toUpperCase()) > -1
            )
          }
        })

        if (ops.length > 100) {
          this.options2 = ops.slice(0, 100)
        } else {
          this.options2 = ops
        }
      }
    }
  }
}
