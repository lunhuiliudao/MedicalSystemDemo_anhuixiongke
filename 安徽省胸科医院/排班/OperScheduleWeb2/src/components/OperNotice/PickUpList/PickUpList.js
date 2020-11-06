import $ from 'jquery'

export default {
  name: 'PickUpList',
  data: function () {
    return {
      scheduleDateTime: this.$moment().format('YYYY-MM-DD'),
      pickUpListData: [],
      pickUpList: [],
      pickUpListPrint: [],
      pickUpListSelectData: [],
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
    comPickUpList: function () {
      this.pickUpList.forEach(function (eletemp) {
        if (eletemp.width === 0) {
          eletemp.widthObj = { 'min-width': eletemp.width }
        } else {
          eletemp.widthObj = { width: eletemp.width }
        }
      }, this)
      return this.pickUpList
    },
    comPickUpListPrint: function () {
      this.pickUpListPrint.forEach(function (eletemp) {
        if (eletemp.width === 0) {
          eletemp.widthObj = ''
        } else {
          eletemp.widthObj = { width: eletemp.width }
        }
      }, this)
      return this.pickUpListPrint
    }
  },
  created: function () {
    this.$ajax
      .get(
        location.protocol +
          '//' +
          location.host +
          '/static/config/pickUpConfig.json'
      )
      .then(response => {
        this.pickUpList = response.data.pickUp
        if (this.pickUpList.length > 0) {
          this.exprotExcelColumns = []
          this.pickUpList.forEach(element => {
            this.exprotExcelColumns.push({
              Title: element.lable,
              FieldName: element.field
            })
          })
        }
        this.pickUpListPrint = response.data.pickUpPrint
        this.getPickUpListData()
      })
  },
  methods: {
    getPickUpListData: function () {
      var _this = this
      this.$ajax
        .get('/Api/ScheduleOperNotice/GetOperNoticeList', {
          params: {
            ScheduleDateTime: _this.scheduleDateTime
          }
        })
        .then(function (response) {
          _this.pickUpListData = response.data.Data
        })
    },
    preview: function () {
      var printHtml = $('#pickUpListPrintArea').html()
      let newWindow = window.open('_blank')
      newWindow.document.write(printHtml)
      newWindow.document.close()
      newWindow.print()
      newWindow.close()
    },
    selectionChangeFun: function (selection) {
      this.pickUpListSelectData = selection
    },
    // 导出
    exprotExcel () {
      var exportbtn = document.getElementById('hrefToExportTable')
      var _this = this
      this.$ajax
        .post('/Api/ScheduleOperNotice/ExportExcel', {
          reportMonth: _this.scheduleDateTime,
          reportName: 'PickUpList',
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
