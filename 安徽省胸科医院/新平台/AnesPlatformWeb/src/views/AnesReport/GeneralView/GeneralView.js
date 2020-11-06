import AnesReportApi from '@/api/AnesReportApi.js'
import GeneralSubView from '../GeneralSubView/GeneralSubView.vue'
import ChartReportView from '../ChartReportView/ChartReportView.vue'
import DropDownList from '@/components/DropDownList/DropDownList.vue'

export default {
  name: 'GeneralView',
  data () {
    return {
      loading: false,
      reportInformation: this.createReportInfo(), // 父报表信息
      reportData: this.newData(), // 父报表数据
      reportSubInformation: this.createReportInfo(), // 子报表信息
      dialogSubDataVisible: false,
      dialogSQLViewVisible: false,
      dialogSubSQLViewVisible: false,
      conditionCount: 3,
      conditionWidth:
        document.documentElement.clientWidth > 1366 ? '210px' : '90px',
      dialogChartViewVisible: false,
      comChartReportKey: ''
      // myOperCheck: 0
    }
  },
  computed: {
    comReportConditionList () {
      return this.reportInformation.ReportConditionList.filter(
        d => d.ControlType !== 'CheckBox'
      )
    },
    comCheckBoxConditionList () {
      return this.reportInformation.ReportConditionList.filter(
        d => d.ControlType === 'CheckBox'
      )
    }
  },
  components: { GeneralSubView, ChartReportView, DropDownList },
  created: function () {
    this.fetchData(this.$route.params.name)
  },
  beforeRouteUpdate (to, from, next) {
    this.fetchData(to.params.name)
    next()
  },
  beforeRouteEnter (to, from, next) {
    next(vm => {
      vm.fetchData(to.params.name)
    })
  },
  methods: {
    createReportInfo () {
      return {
        SubReportInformationList: [],
        ReportColumnList: [],
        ReportConditionList: [],
        ReportSubConditionList: [],
        ReportTitle: { ReportName: '', PageSize: 0, StrSql: '' },
        ReportChartInfo: { ChartType: '' }
      }
    },
    newData () {
      return {
        total: 0,
        currentPage: 1,
        currentData: [],
        allData: []
      }
    },
    fetchData (reportname) {
      this.reportInformation = this.createReportInfo()
      this.reportData = this.newData()
      this.reportSubInformation = this.createReportInfo()
      this.getReportConfigByKey(reportname)
    },
    getReportConfigByKey (name) {
      if (typeof name !== 'undefined') {
        AnesReportApi.getReportConfigByKey({ reportKey: name, clearSql: true })
          .then(respose => {
            this.reportInformation = respose.data.Data
            if (
              this.$store.state.AnesReport.currentReportInformation !== null &&
              this.$store.state.AnesReport.currentReportInformation.ReportTitle
                .ReportName === this.reportInformation.ReportTitle.ReportName
            ) {
              this.reportInformation = this.$store.state.AnesReport.currentReportInformation
              this.searchData(
                this.$store.state.AnesReport.currentReportInformation
                  .currentPage
              )
            }
            this.reportInformation.ReportColumnList.forEach(function (element) {
              if (element.Width === '0') {
                element.widthObj = { 'min-width': element.Width }
              } else {
                element.widthObj = { width: element.Width }
              }
            }, this)
          })
          .catch(error => {
            console.log(error)
          })
      }
    },
    searchData (index) {
      this.reportData.currentPage = index
      this.loading = true
      AnesReportApi.execSql(
        {
          key: this.reportInformation.ReportTitle.ReportName,
          CurrentPage: this.reportData.currentPage,
          PageSize: this.reportInformation.ReportTitle.PageSize
        },
        {
          ReportConditionList: this.reportInformation.ReportConditionList,
          ReportSubConditionList: this.reportInformation.ReportSubConditionList
        }
      )
        .then(respose => {
          this.reportData = respose.data.Data
          this.loading = false
        })
        .catch(error => {
          console.log(error)
        })
    },
    getSummaries (param) {
      param.data = this.reportData.allData
      const { columns, data } = param
      const sums = []
      columns.forEach((column, index) => {
        if (index === 0) {
          sums[index] = '总计'
          return
        }
        const values = data.map(item => Number(item[column.property]))
        if (!values.every(value => isNaN(value))) {
          sums[index] = values.reduce((prev, curr) => {
            const value = Number(curr)
            if (!isNaN(value)) {
              return prev + curr
            } else {
              return prev
            }
          }, 0)
        } else {
          sums[index] = 'N/A'
        }
      })

      return sums
    },
    handleCurrentChange (val) {
      this.searchData(val)
    },
    searchSubData (column, row, index, store) {
      // 获取子报表名称
      let SubReportName = ''
      // 点击第一层级
      if (column.level === 1) {
        SubReportName = this.reportInformation.ReportColumnList.find(
          d => d.Title === column.label
        ).SubReportName
      } else {
        // 点击第二层级
        for (
          let columi = 0;
          columi < this.reportInformation.ReportColumnList.length;
          columi++
        ) {
          let tempelement = this.reportInformation.ReportColumnList[columi]
          if (
            tempelement.ReportColumnList.length > 0 &&
            column.labelClassName === tempelement.Title
          ) {
            SubReportName = tempelement.ReportColumnList.find(
              d => d.Title === column.label
            ).SubReportName
            break
          }
        }
      }
      // 子报表需要用到的附属查询条件
      let subReportSubConditionList = []
      // 深拷贝父报表的附属查询条件
      Object.assign(
        subReportSubConditionList,
        this.reportInformation.ReportSubConditionList
      )
      // console.log(row[this.reportInformation.ReportColumnList.find((d) => d.Title === column.label)["FieldName"]])
      if (this.reportInformation.SubReportInformationList != null) {
        // 获取子报表对象
        this.reportSubInformation = this.reportInformation.SubReportInformationList.find(
          d => d.ReportTitle.ReportName === SubReportName
        )
        if (typeof this.reportSubInformation !== 'undefined') {
          this.reportSubInformation.ReportSubConditionList.forEach(function (
            element
          ) {
            element.Value = row[element.FieldName]
          },
          this)
          // 子报表和父报表的附属条件合并
          this.reportSubInformation.ReportSubConditionList.forEach(function (
            subobj
          ) {
            subReportSubConditionList.push(subobj)
          },
          this)
          // 父报表查询条件给子报表
          this.reportSubInformation.ReportConditionList = this.reportInformation.ReportConditionList
          this.reportSubInformation.ReportSubConditionList = subReportSubConditionList
          this.reportSubInformation.ReportColumnList.forEach(function (eletemp) {
            if (eletemp.Width === '0') {
              eletemp.widthObj = { 'min-width': eletemp.Width }
            } else {
              eletemp.widthObj = { width: eletemp.Width }
            }
          }, this)
          this.dialogSubDataVisible = true
          // 调用子组件方法
          this.$nextTick(function () {
            this.$refs.genesuview.handleCurrentChange(1)
          })
        } else {
          console.log('未找到对应的子报表')
        }
      } else {
        console.log('未配置子报表')
      }
    },
    exprotExcel () {
      var exportbtn = document.getElementById('hrefToExportTable')
      AnesReportApi.exprotExcel(
        { key: this.reportInformation.ReportTitle.ReportName },
        {
          ReportTitle: this.reportInformation.ReportTitle,
          ReportConditionList: this.reportInformation.ReportConditionList,
          ReportSubConditionList: this.reportInformation.ReportSubConditionList
        }
      )
        .then(respose => {
          exportbtn.href =
            this.webconfig.apiUrl + '/TempExprotExcel/' + respose.data.Data
          exportbtn.click()
        })
        .catch(error => {
          console.log(error)
        })
    },
    showSqlDialog () {
      AnesReportApi.getReportSQL(
        { key: this.reportInformation.ReportTitle.ReportName, type: 0 },
        {
          ReportConditionList: this.reportInformation.ReportConditionList,
          ReportSubConditionList: this.reportInformation.ReportSubConditionList
        }
      )
        .then(respose => {
          this.reportInformation.ReportTitle.StrSql = respose.data.Data
          this.dialogSQLViewVisible = true
        })
        .catch(error => {
          console.log(error)
        })
    },
    showSubSqlDialog () {
      AnesReportApi.getSubReportSQL(
        { key: this.reportSubInformation.ReportTitle.ReportName, type: 0 },
        {
          ReportConditionList: this.reportInformation.ReportConditionList,
          ReportSubConditionList: this.reportInformation.ReportSubConditionList,
          ReportTitle: this.reportInformation.ReportTitle
        }
      )
        .then(respose => {
          this.reportSubInformation.ReportTitle.StrSql = respose.data.Data
          this.dialogSubSQLViewVisible = true
        })
        .catch(error => {
          console.log(error)
        })
    },
    copySql () {
      var sqlarea = document.getElementById('sqlarea')
      var userAgent = navigator.userAgent
      // 判断Ie
      if (userAgent.indexOf('MSIE') > 0) {
        window.clipboardData.setData('text', sqlarea.value)
      } else {
        sqlarea.select()
        document.execCommand('Copy')
      }
    },
    inMedicalRecordPath (row) {
      this.reportInformation.currentPage = this.reportData.currentPage
      this.$store.commit('SET_REPORTCONDITION', this.reportInformation)
      window.open(
        '/PatientInfo?pid=' +
          row.PATIENT_ID +
          '&vid=' +
          row.VISIT_ID +
          '&oid=' +
          row.OPER_ID,
        '_blank'
      )
      // this.$router.push({
      //   path: '/PatientInfo',
      //   query: {
      //     pid: row.PATIENT_ID,
      //     vid: 1,
      //     oid: 1
      //   }
      // })
    },
    exprotSubReportExcel () {
      let exportSubbtn = document.getElementById('hrefToExportSubTable')
      this.$refs.genesuview
        .subReportExecl()
        .then(respose => {
          exportSubbtn.href =
            this.webconfig.apiUrl + '/TempExprotExcel/' + respose.data.Data
          exportSubbtn.click()
        })
        .catch(error => {
          console.log(error)
        })
    },
    showChartData () {
      this.comChartReportKey = '' + +new Date()
      this.dialogChartViewVisible = true
    },
    tableRowClassName ({ row, rowIndex }) {
      if (rowIndex % 2 === 0) {
        return 'success-row'
      } else {
        return 'default-row'
      }
    },
    tablePrintCom (item) {
      let obj = {}
      if (item.ReportColumnList.length === 0) {
        obj.rowspan = 2
      }
      if (item.ReportColumnList.length > 0) {
        obj.colspan = item.ReportColumnList.length
      }
      return obj
    },
    tableColumnList () {
      let tempcolumnList = []
      this.reportInformation.ReportColumnList.forEach(t => {
        if (t.ReportColumnList.length === 0) {
          tempcolumnList.push(t)
        } else {
          t.ReportColumnList.forEach(element => {
            tempcolumnList.push(element)
          })
        }
      })
      return tempcolumnList
    }
  }
}
