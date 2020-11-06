import $ from 'jquery'

export default {
  name: 'NoticeList',
  data: function () {
    return {
      scheduleDateTime: this.$moment().format('YYYY-MM-DD'),
      operNoticeData: [],
      operNoticeList: [],
      operNoticeListPrint: [],
      operNoticeSelectData: [],
      exprotExcelColumns: []
    }
  },
  props: {
    width: {
      type: Number,
      default: 0
    },
    height: {
      type: Number,
      default: 0
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
    this.$ajax
      .get(
        location.protocol +
          '//' +
          location.host +
          '/static/config/noticeConfig.json'
      )
      .then(response => {
        this.operNoticeList = response.data.operNotice
        if (this.operNoticeList.length > 0) {
          this.exprotExcelColumns = []
          this.operNoticeList.forEach(element => {
            this.exprotExcelColumns.push({
              Title: element.lable,
              FieldName: element.field
            })
          })
        }
        this.operNoticeListPrint = response.data.operNoticePrint
        this.getOperNoticeList()
      })
  },
  methods: {
    getOperNoticeList: function () {
      var _this = this
      this.$ajax
        .get('/Api/ScheduleOperNotice/GetOperNoticeList', {
          params: {
            ScheduleDateTime: _this.scheduleDateTime
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
    // 导出
    exprotExcel () {
      var exportbtn = document.getElementById('hrefToExportTable')
      var _this = this
      this.$ajax
        .post('/Api/ScheduleOperNotice/ExportExcel', {
          reportMonth: _this.scheduleDateTime,
          reportName: 'NoticeList',
          exprotExcelColumns: this.exprotExcelColumns
        })
        .then(function (respose) {
          exportbtn.href =
            _this.webconfig.apiUrl + '/TempExprotExcel/' + respose.data.Data
          exportbtn.click()
        })
        .catch(error => {
          console.log(error)
        })
    }
  }
}
