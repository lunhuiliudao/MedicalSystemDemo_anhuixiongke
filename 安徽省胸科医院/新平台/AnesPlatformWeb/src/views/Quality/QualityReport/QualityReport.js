import QualityApi from '@/api/QualityApi.js'
// import AnesDatePicker from '@/components/anes-date-picker'

export default {
  name: 'QualityReport',
  data () {
    return {
      searchDate: this.$$moment().format('YYYY-MM'),
      tableData: [],
      dialogVisible: false,
      tipInfos: '',
      loading: false,
      exprotExcelColumns: [
        { Title: '序号', FieldName: 'GROUP_NO' },
        { Title: '名称', FieldName: 'REPORT_NAME' },
        { Title: '分子', FieldName: 'NMRTR_CODE' },
        { Title: '分母', FieldName: 'DNMTR_CODE' },
        { Title: '指标率', FieldName: 'PERCENT' }
      ],
      isUpload: false,
      printHeaderText: '',
      key: this.$route + +new Date() // 重置页面
    }
  },
  props: {
    count: {
      type: Number,
      default: 0
    }
  },
  components: { },
  created: function () {
    this.searchInfos()
    this.printHeaderText =
      this.$$moment(this.searchDate).format('YYYY年MM月') + '质控指标统计数据'
  },
  methods: {
    // 查询数据
    searchInfos () {
      if (this.searchDate === null || this.searchDate === '') {
        this.$message({
          message: '请选择月份',
          type: 'warning'
        })
      } else {
        QualityApi.searchQuanlityReportInfo({
          reportMonth: this.searchDate
        })
          .then(respose => {
            this.tableData = respose.data.Data
          })
          .catch(error => {
            console.log(error)
          })
        this.IsUploadData()
      }
    },
    // 统计数据
    extractInfos () {
      QualityApi.extractInfos({
        reportMonth: this.searchDate
      })
        .then(respose => {
          this.tableData = respose.data.Data
          if (respose.data.Message === '') {
            this.$message({
              message: '更新统计成功',
              type: 'success'
            })
          } else {
            this.$message.error('更新统计失败')
          }
        })
        .catch(error => {
          console.log(error)
        })
    },
    // 是否已经上报质控数据
    IsUploadData () {
      var _THIS = this
      var month =
        _THIS.$$moment(this.searchDate).format('YYYY') +
        _THIS.$$moment(this.searchDate).format('MM')

      QualityApi.quanlityIsUploadData({
        reportMonth: month
      })
        .then(function (respose) {
          if (respose.data.Data === 1) {
            _THIS.isUpload = true
          } else {
            _THIS.isUpload = false
          }
        })
        .catch(error => {
          console.log(error)
        })
    },
    // 生成质控报告数据
    saveInfos () {
      var _THIS = this
      _THIS.dialogVisible = false
      var month =
        _THIS.$$moment(this.searchDate).format('YYYY') +
        _THIS.$$moment(this.searchDate).format('MM')

      QualityApi.quanlitySaveInfos()
        .then(function (respose) {
          var filterRows = respose.data.Data.filter(
            d => d.REPORT_MONTH === month
          )
          if (filterRows.length > 0) {
            if (
              filterRows[0].REPORT_NAME !== '' &&
              filterRows[0].REPORT_NAME !== null
            ) {
              _THIS
                .$confirm('质控报告数据已经生成，是否替换？', '提示', {
                  confirmButtonText: '确定',
                  cancelButtonText: '取消',
                  type: 'warning'
                })
                .then(() => {
                  _THIS.submitData()
                })
                .catch(() => {
                  _THIS.dialogVisible = false
                })
            } else {
              _THIS.submitData()
            }
          } else {
            _THIS.submitData()
          }
        })
        .catch(error => {
          console.log(error)
        })
    },
    submitData () {
      var _THIS = this

      QualityApi.quanlitySubmitData({
        reportMonth: this.searchDate,
        name: this.tipInfos
      })
        .then(function (respose) {
          _THIS.loading = false
          if (respose.data.Data === '') {
            _THIS.$message({
              message: '质控报告生成成功',
              type: 'success'
            })
          } else {
            _THIS.$message.error('质控报告生成失败')
          }
        })
        .catch(error => {
          console.log(error)
        })
    },
    // 弹窗打开前处理事件
    handleOpen () {
      this.tipInfos =
        this.$$moment(this.searchDate).format('YYYY') +
        '年' +
        this.$$moment(this.searchDate).format('MM') +
        '月' +
        '质控上报数据' +
        '(' +
        this.$$moment().format('YYYYMMDD') +
        ')'
    },
    // 导出
    exprotExcel () {
      var exportbtn = document.getElementById('hrefToExportTable')
      var _THIS = this

      QualityApi.quanlityExportData({
        reportMonth: this.$$moment(this.searchDate).format('YYYY-MM'),
        reportName: 'QuanlityData',
        exprotExcelColumns: this.exprotExcelColumns,
        isOutRoomOper: ''
      })
        .then(function (respose) {
          exportbtn.href =
            _THIS.webconfig.apiUrl + '/TempExprotExcel/' + respose.data.Data
          exportbtn.click()
        })
        .catch(error => {
          console.log(error)
        })
    },
    print () {
      var printHtml = this.$refs['refq'].innerHTML
      let newWindow = window.open('_blank')
      newWindow.document.write(printHtml)
      newWindow.document.close()
      newWindow.print()
      newWindow.close()
    },
    calIndex (n) {
      return n < 10 ? '0' + n : n
    },
    filterFatherTable (data, item) {
      return data.filter(t => t.FATHER_CHILD === 1)
    },
    filterTable (data, item) {
      return data.filter(t => t.GROUP_NO === item.GROUP_NO)
    },
    rowIndex (item) {
      if (item.FATHER_CHILD === 1) {
        if (item.GROUP_NO % 2 === 0) {
          return { tableSingleRow: true }
        } else {
          return { tableDoubleRow: true }
        }
      } else {
        return { tableChildRow: true }
      }
    }
  }
}
