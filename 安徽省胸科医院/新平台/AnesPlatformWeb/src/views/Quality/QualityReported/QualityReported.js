import QualityApi from '@/api/QualityApi.js'
// import AnesDatePicker from '@/components/anes-date-picker'

export default {
  name: 'QualityReported',
  data () {
    return {
      tableData: [],
      searchDate: this.$$moment().format('YYYY'),
      loginDialogVisible: false,
      acount: {
        loginname: '',
        password: ''
      },
      rules2: {
        loginname: [
          {
            validator: function (rule, value, callback) {
              if (!value) {
                return callback(new Error('用户名不能为空！'))
              } else {
                callback()
              }
            },
            trigger: 'blur'
          }
        ],
        password: [
          {
            validator: function (rule, value, callback) {
              if (!value) {
                return callback(new Error('密码不能为空！'))
              } else {
                callback()
              }
            },
            trigger: 'blur'
          }
        ]
      },
      reportIdTemp: ''
    }
  },
  props: {
    count: {
      type: Number,
      default: 0
    }
  },
  components: { },
  methods: {
    // 查询数据
    searchInfos () {
      var _this = this
      if (_this.searchDate === null || _this.searchDate === '') {
        _this.$message({
          message: '请选择年份',
          type: 'warning'
        })
      } else {
        QualityApi.searchInfos()
          .then(function (respose) {
            _this.tableData = respose.data.Data.filter(d =>
              d.REPORT_MONTH.includes(
                _this.$$moment(_this.searchDate).format('YYYY')
              )
            )
          })
          .catch(error => {
            console.log(error)
          })
      }
    },
    searchDetailInfo (row) {
      this.$router.push({
        path: '/quality/reportmaintain',
        query: { reportMonth: row.REPORT_NAME }
      })
    },
    // 上报数据
    uploadData (reportId) {
      var _THIS = this
      if (
        _THIS.tableData.filter(d => d.REPORT_ID === reportId && d.STATUS === 1)
          .length > 0
      ) {
        _THIS
          .$confirm('该月份报告已经上报过，是否确定需要重新上报?', '提示', {
            confirmButtonText: '确定',
            cancelButtonText: '取消',
            type: 'warning'
          })
          .then(() => {
            _THIS.loginDialogVisible = true
            _THIS.reportIdTemp = reportId
            // _THIS.submitData(reportId)
          })
          .catch(() => {})
      } else {
        _THIS.loginDialogVisible = true
        _THIS.reportIdTemp = reportId
        // _THIS.submitData(reportId)
      }
    },
    // 确定
    btnOk () {
      var _this = this
      if (
        typeof _this.acount.loginname !== 'undefined' &&
        _this.acount.loginname !== null &&
        _this.acount.loginname !== '' &&
        typeof _this.acount.password !== 'undefined' &&
        _this.acount.password !== null &&
        _this.acount.password !== ''
      ) {
        _this.loginDialogVisible = false

        if (
          typeof _this.reportIdTemp !== 'undefined' &&
          _this.reportIdTemp !== null &&
          _this.reportIdTemp !== ''
        ) {
          _this.submitData(_this.reportIdTemp)
        }
      }
    },
    // 提交数据
    submitData (reportId) {
      var _this = this
      QualityApi.SubmitReport({
        reportId: reportId,
        status: 1,
        LoginUserId: this.$store.getters.user.USER_JOB_ID,
        QcCloudName: _this.acount.loginname,
        QcCloudPwd: _this.acount.password
      }).then(function (response) {
        // console.log(response.data)
        if (response.data.Data === 0) {
          _this.$message({
            message: response.data.Message,
            type: 'warning'
          })
          _this.searchInfos()
        } else if (response.data.Data === 1) {
          _this.$message({
            message: response.data.Message,
            type: 'success'
          })
          _this.searchInfos()
        }

        _this.$refs['acount'].resetFields()
      })
    },
    rowIndex (index) {
      if (index % 2 === 0) {
        return { tableDoubleRow: true }
      } else {
        return { tableSingleRow: true }
      }
    },
    calIndex (n) {
      return n < 10 ? '0' + n : n
    }
  },
  created: function () {
    this.searchInfos()
  }
}
