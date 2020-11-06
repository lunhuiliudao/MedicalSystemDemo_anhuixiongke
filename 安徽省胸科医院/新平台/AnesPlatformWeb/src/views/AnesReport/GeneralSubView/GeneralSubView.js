import AnesReportApi from '@/api/AnesReportApi.js'

export default {
  name: 'GeneralSubView',
  data () {
    return {
      loading: false,
      newReportData: this.createNewData()
    }
  },
  props: ['parentReportName', 'reportInformation'],
  methods: {
    createNewData () {
      return {
        total: 0,
        currentPage: 1,
        currentData: []
      }
    },
    handleCurrentChange (val) {
      this.newReportData = this.createNewData()
      this.loading = true
      AnesReportApi.execSubSql(
        {
          key: this.parentReportName,
          subkey: this.reportInformation.ReportTitle.ReportName,
          CurrentPage: val,
          PageSize: this.reportInformation.ReportTitle.PageSize
        },
        {
          ReportConditionList: this.reportInformation.ReportConditionList,
          ReportSubConditionList: this.reportInformation.ReportSubConditionList
        }
      )
        .then(respose => {
          this.newReportData = respose.data.Data
          this.loading = false
        })
        .catch(error => {
          console.log(error)
        })
    },
    inMedicalRecordPath (row) {
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
      //   path: '/MedicalRecord',
      //   query: { InpNo: row.INP_NO, PatName: row.NAME, AnesDoctor: row.ANES_DOCTOR, OperDate: row.ANES_START_TIME
      //   }
      // })
    },
    subReportExecl () {
      return AnesReportApi.exportSubReportExcel(
        {
          key: this.parentReportName,
          subkey: this.reportInformation.ReportTitle.ReportName
        },
        this.reportInformation
      )
    },
    tableRowClassName ({ row, rowIndex }) {
      if (rowIndex % 2 === 0) {
        return 'success-row'
      } else {
        return 'default-row'
      }
    }
  }
}
