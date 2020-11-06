import AssayReportApi from '@/api/AssayReportApi.js'
export default {
  name: 'AssayReport',
  data () {
    return {
      checkResultMasterData: [],
      checkResultDetailData: [],
      checkDateDict: [],
      selected: ''
    }
  },
  props: {
    inWidth: Number,
    inHeight: Number
  },
  computed: {
    osWidth: function () {
      return this.inWidth
    },
    osHeight: function () {
      return this.inHeight
    }
  },
  methods: {
    operLIS101 () {
      var patientID = this.$route.query.pid
      var visitID = this.$route.query.vid
      // var patientID = '2002566'
      // var visitID = '1'
      AssayReportApi.GetMedLabTestMaster({
        patientID: patientID,
        visitID: visitID
      })
        .then(respose => {
          this.checkResultMasterData = respose.data.Data
          let dateArray = []
          this.checkResultMasterData.forEach(function (key) {
            if (key.SPCM_RECEIVED_DATE_TIME_SHOW.length > 0) {
              dateArray.push(key.SPCM_RECEIVED_DATE_TIME_SHOW)
            }
          })
          this.checkDateDict = Array.from(new Set(dateArray))
          if (this.checkResultMasterData.length > 0) {
            this.selected = this.checkResultMasterData[0].TEST_NO
            this.resultMasterCurrentChange(this.selected)
          } else {
            this.checkResultDetailData = []
          }
        })
        .catch(error => {
          console.log(error)
        })
    },
    resultMasterCurrentChange (val) {
      this.selected = val
      AssayReportApi.GetMedLabResult({
        testNo: this.selected
      })
        .then(respose => {
          this.checkResultDetailData = respose.data.Data
        })
        .catch(error => {
          console.log(error)
        })
    },
    rowIndex (index) {
      if (index % 2 === 0) {
        return { tableDoubleRow: true }
      } else {
        return { tableSingleRow: true }
      }
    },
    getCount (item) {
      return this.checkResultMasterData.filter(r => {
        return r.SPCM_RECEIVED_DATE_TIME_SHOW === item
      }).length
    }
  },
  created: function () {
    this.operLIS101()
  }
}
