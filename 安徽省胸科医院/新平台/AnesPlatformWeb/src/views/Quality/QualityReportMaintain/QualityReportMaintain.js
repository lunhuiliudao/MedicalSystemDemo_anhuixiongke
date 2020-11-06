import QualityApi from '@/api/QualityApi.js'
export default {
  name: 'QualityReportMaintain',
  data () {
    return {
      value2: true,
      selected: '',
      editFlag: false,
      dialogVisible: false,
      tableData: [],
      tableDetailData: [],
      reportNoTemp: '',
      reportNameList: [],
      exprotExcelColumns: [
        { Title: '序号', FieldName: 'GROUP_NO' },
        { Title: '名称', FieldName: 'REPORT_NAME' },
        { Title: '分子', FieldName: 'NMRTR_CODE_VALUE' },
        { Title: '分母', FieldName: 'DNMTR_CODE_VALUE' },
        { Title: '指标率', FieldName: 'PERCENT' }
      ],
      isUpload: false,
      printHeaderText: '',
      isOutRoomOper: '全部',
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
      }
    }
  },
  props: {
    count: {
      type: Number,
      default: 0
    }
  },
  methods: {
    searchRegisterInfo (row) {
      this.$router.push({
        path: '/quality/register',
        query: {
          patientId: row.PATIENT_ID,
          visitId: row.VISIT_ID,
          operId: row.OPER_ID,
          isOutRoomOper: this.isOutRoomOper,
          isUpload: this.isUpload
        }
      })
    },
    clickitemOut (e) {
      e === this.isOutRoomOper
        ? (this.isOutRoomOper = '')
        : (this.isOutRoomOper = e)
      if (
        this.isOutRoomOper === '全部' ||
        this.isOutRoomOper === '室外' ||
        this.isOutRoomOper === '室内'
      ) {
        this.searchInfos()
      }
    },
    calIndex (n) {
      return n < 10 ? '0' + n : n
    },
    editInfos () {
      if (
        !this.editFlag &&
        this.isOutRoomOper !== '全部' &&
        this.isUpload === false
      ) {
        this.editFlag = true
      }
    },
    rowIndex (item) {
      if (item.FATHER_CHILD === 1) {
        if (item.GROUP_NO % 2 === 0) {
          return { tableDoubleRow: true }
        } else {
          return { tableSingleRow: true }
        }
      } else {
        return { tableChildRow: true }
      }
    },
    calDetailClass (index) {
      if (index % 2 === 0) {
        return { tableDoubleRow: true }
      } else {
        return { tableSingleRow: true }
      }
    },
    showDetail () {
      this.dialogDetailVisible = true
    },
    loadReportName () {
      var _THIS = this
      QualityApi.searchInfos()
        .then(function (respose) {
          _THIS.reportNameList = respose.data.Data
        })
        .catch(error => {
          console.log(error)
        })
    },
    setSelected (val) {
      this.selected = val
      this.searchInfos()
    },
    // 查询数据
    searchInfos () {
      this.printHeaderText = this.selected
      var _THIS = this
      this.editFlag = false
      QualityApi.GetQuanlityControlReportBakItemList({
        reportName: this.selected,
        isOutRoomOper: this.isOutRoomOper
      })
        .then(function (respose) {
          _THIS.tableData = respose.data.Data
        })
        .catch(error => {
          console.log(error)
        })
      _THIS.IsUploadData()
    },
    // 查询数据明细
    searchDetailInfos (reportNo) {
      var _THIS = this
      _THIS.reportNoTemp = reportNo
      if (this.isOutRoomOper === '室内') {
        QualityApi.GetQuanlityControlAeBakPatientInfoDataByReportNameAndReportNo(
          {
            reportName: this.selected,
            reportNo: reportNo
          }
        )
          .then(function (respose) {
            _THIS.tableDetailData = respose.data.Data
          })
          .catch(error => {
            console.log(error)
          })
      } else if (this.isOutRoomOper === '室外') {
        QualityApi.GetQuanlityControlAeBakPatientInfoDataByReportNameAndReportNoOut(
          {
            reportName: this.selected,
            reportNo: reportNo
          }
        )
          .then(function (respose) {
            _THIS.tableDetailData = respose.data.Data
          })
          .catch(error => {
            console.log(error)
          })
      }
    },
    // 是否已经上报质控数据
    IsUploadData () {
      var _THIS = this
      QualityApi.IsQuanlityControlDataUploadByReportName({
        reportName: this.selected
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

    // 数据验证
    check_num (row) {
      var minValue = row.NMRTR_CODE_VALUE
      var maxValue = row.DNMTR_CODE_VALUE
      if (row.REPORT_NAME.includes('麻醉科医患比（GB）')) {
        maxValue = maxValue * 10000
        return true
      }
      if (isNaN(minValue) || isNaN(maxValue)) {
        // 用于检查其参数是否是非数字值
        this.$message({
          message: '必须输入数字！',
          type: 'warning'
        })
        return false
      } else if (parseInt(minValue) < 0 || parseInt(maxValue) < 0) {
        // 注意‘或’的写法
        this.$message({
          message: '必须输入非负整数！',
          type: 'warning'
        })
        return false
      } else if (parseInt(minValue) > parseInt(maxValue)) {
        // 注意‘或’的写法
        this.$message({
          message: '分子必须小于等于分母！',
          type: 'warning'
        })
        return false
      }
    },
    // 分母改变事件
    valueChange (row) {
      this.tableData.forEach(element => {
        if (element.DNMTR_CODE === row.DNMTR_CODE) {
          if (!element.REPORT_NAME.includes('麻醉科医患比')) {
            element.DNMTR_CODE_VALUE = row.DNMTR_CODE_VALUE

            if (element.DNMTR_CODE_VALUE > 0) {
              if (element.UNIT === '%') {
                element.PERCENT =
                  Math.floor(
                    (element.NMRTR_CODE_VALUE / element.DNMTR_CODE_VALUE) *
                      100 *
                      100
                  ) /
                    100 +
                  element.UNIT
              } else if (element.UNIT === '‰') {
                element.PERCENT =
                  Math.floor(
                    (element.NMRTR_CODE_VALUE / element.DNMTR_CODE_VALUE) *
                      1000 *
                      100
                  ) /
                    100 +
                  element.UNIT
              } else if (element.UNIT === '‱') {
                element.PERCENT =
                  Math.floor(
                    (element.NMRTR_CODE_VALUE / element.DNMTR_CODE_VALUE) *
                      10000 *
                      100
                  ) /
                    100 +
                  element.UNIT
              }
            } else {
              element.PERCENT = '0' + element.UNIT
            }
          } else {
            if (element.REPORT_NAME.includes('GB')) {
              element.DNMTR_CODE_VALUE = row.DNMTR_CODE_VALUE
              element.PERCENT =
                Math.floor(
                  (element.NMRTR_CODE_VALUE / element.DNMTR_CODE_VALUE) *
                    100 *
                    100
                ) /
                  100 +
                element.UNIT
            } else if (element.REPORT_NAME.includes('DB')) {
              element.NMRTR_CODE_VALUE = row.DNMTR_CODE_VALUE
              element.PERCENT =
                Math.floor(
                  (element.NMRTR_CODE_VALUE / element.DNMTR_CODE_VALUE) *
                    100 *
                    100
                ) /
                  100 +
                element.UNIT
            }
          }
        } else if (element.NMRTR_CODE === row.DNMTR_CODE) {
          element.NMRTR_CODE_VALUE = row.DNMTR_CODE_VALUE
          element.PERCENT =
            Math.floor(
              (element.NMRTR_CODE_VALUE / element.DNMTR_CODE_VALUE) * 100 * 100
            ) /
              100 +
            element.UNIT
        } else {
          if (element.DNMTR_CODE === 'A0102' && row.DNMTR_CODE === 'A0103') {
            // 麻醉科完成麻醉总例次数（万例次）
            element.DNMTR_CODE_VALUE = row.DNMTR_CODE_VALUE / 10000
          }
        }
      })

      var rowList = this.groupArray(this.tableData)

      rowList.forEach(t => {
        if (t.length > 0) {
          var sum = 0

          t.forEach(p => {
            if (
              Number.isNaN(p.NMRTR_CODE_VALUE) === false &&
              p.NMRTR_CODE_VALUE !== null &&
              p.NMRTR_CODE_VALUE !== undefined
            ) {
              sum = sum + parseInt(p.NMRTR_CODE_VALUE)
            }
          })
          t.forEach(p => {
            if (
              p.REPORT_NAME.includes('其他') ||
              p.REPORT_NAME.includes('其它')
            ) {
              if (sum < parseInt(p.DNMTR_CODE_VALUE)) {
                p.NMRTR_CODE_VALUE =
                  parseInt(p.DNMTR_CODE_VALUE) -
                  sum +
                  parseInt(p.NMRTR_CODE_VALUE)
              } else if (sum > parseInt(p.DNMTR_CODE_VALUE)) {
                var chaZhi =
                  parseInt(p.NMRTR_CODE_VALUE) -
                  sum +
                  parseInt(p.DNMTR_CODE_VALUE)
                if (chaZhi >= 0) {
                  p.NMRTR_CODE_VALUE = chaZhi
                } else {
                  this.tableData.forEach(el => {
                    if (el.DNMTR_CODE === row.DNMTR_CODE) {
                      if (!el.REPORT_NAME.includes('麻醉科医患比')) {
                        el.DNMTR_CODE_VALUE = sum

                        if (el.UNIT === '%') {
                          el.PERCENT =
                            Math.floor(
                              (el.NMRTR_CODE_VALUE / el.DNMTR_CODE_VALUE) *
                                100 *
                                100
                            ) /
                              100 +
                            el.UNIT
                        } else if (el.UNIT === '‰') {
                          el.PERCENT =
                            Math.floor(
                              (el.NMRTR_CODE_VALUE / el.DNMTR_CODE_VALUE) *
                                1000 *
                                100
                            ) /
                              100 +
                            el.UNIT
                        } else if (el.UNIT === '‱') {
                          el.PERCENT =
                            Math.floor(
                              (el.NMRTR_CODE_VALUE / el.DNMTR_CODE_VALUE) *
                                10000 *
                                100
                            ) /
                              100 +
                            el.UNIT
                        }
                      } else {
                        if (el.REPORT_NAME.includes('GB')) {
                          el.DNMTR_CODE_VALUE = row.DNMTR_CODE_VALUE
                          el.PERCENT =
                            Math.floor(
                              (el.NMRTR_CODE_VALUE / el.DNMTR_CODE_VALUE) *
                                100 *
                                100
                            ) /
                              100 +
                            el.UNIT
                        } else if (el.REPORT_NAME.includes('DB')) {
                          el.NMRTR_CODE_VALUE = row.DNMTR_CODE_VALUE
                          el.PERCENT =
                            Math.floor(
                              (el.NMRTR_CODE_VALUE / el.DNMTR_CODE_VALUE) *
                                100 *
                                100
                            ) /
                              100 +
                            el.UNIT
                        }
                      }
                    }
                  })
                }
              }
            }
          })
        }
      })
    },
    // 分组
    groupArray (data) {
      let list = []
      let current = []
      var grpno = -99999
      data.forEach(t => {
        if (grpno !== t.GROUP_NO) {
          grpno = t.GROUP_NO
          current = data.filter(d => d.GROUP_NO === grpno)
          if (current.length > 1) {
            list.push(current)
          }
        }
      })

      return list
    },
    // 修改不良事件上报标识
    uploadAdverseEvent (row) {
      var _THIS = this
      QualityApi.UploadQuanlityControlAeBakData({
        REPORT_ID: row.REPORT_ID,
        PATIENT_ID: row.PATIENT_ID,
        VISIT_ID: row.VISIT_ID,
        OPER_ID: row.OPER_ID,
        REPORT_NO: _THIS.reportNoTemp,
        UPLOAD: row.UPLOAD
      }).then(function (response) {
        if (response.data.Data === 0) {
          _THIS.$message({
            message: '更改失败',
            type: 'warning'
          })
        } else if (response.data.Data > 0) {
          _THIS.$message({
            message: '更改成功',
            type: 'success'
          })
          _THIS.searchInfos()
        }
      })
    },
    // 上报数据
    uploadData () {
      var _THIS = this

      if (_THIS._data.tableData.length > 0) {
        var reportId = _THIS._data.tableData[0].REPORT_ID
        if (reportId !== 'undefined') {
          QualityApi.searchInfos()
            .then(function (respose) {
              if (
                respose.data.Data.filter(
                  d => d.REPORT_ID === reportId && d.STATUS === 1
                ).length > 0
              ) {
                _THIS
                  .$confirm(
                    '该月份报告已经上报过，是否确定需要重新上报?',
                    '提示',
                    {
                      confirmButtonText: '确定',
                      cancelButtonText: '取消',
                      type: 'warning'
                    }
                  )
                  .then(() => {
                    _THIS.loginDialogVisible = true
                    // _THIS.submitData(reportId)
                  })
                  .catch(() => {})
              } else {
                _THIS
                  .$confirm('是否将该月质控统计数据进行上报?', '提示', {
                    confirmButtonText: '确定',
                    cancelButtonText: '取消',
                    type: 'warning'
                  })
                  .then(() => {
                    _THIS.loginDialogVisible = true
                    // _THIS.submitData(reportId)
                  })
                  .catch(() => {})
              }
            })
            .catch(error => {
              console.log(error)
            })
        }
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

        if (_this._data.tableData.length > 0) {
          var reportId = _this._data.tableData[0].REPORT_ID

          if (
            reportId !== 'undefined' &&
            reportId !== '' &&
            reportId !== null
          ) {
            _this.submitData(reportId)
          }
        }
      }
    },
    // 提交数据
    submitData (reportId) {
      var _THIS = this
      QualityApi.SaveQuanlityControlReportInd({
        reportId: reportId,
        status: 1,
        LoginUserId: JSON.parse(sessionStorage.user).USER_JOB_ID,
        QcCloudName: _THIS.acount.loginname,
        QcCloudPwd: _THIS.acount.password
      }).then(function (response) {
        if (response.data.Data === 0) {
          _THIS.$message({
            message: response.data.Message,
            type: 'warning'
          })
        } else if (response.data.Data === 1) {
          _THIS.$message({
            message: response.data.Message,
            type: 'success'
          })
          _THIS.searchInfos()
        }
        _THIS.$refs['acount'].resetFields()
      })
    },
    // 保存信息
    saveInfos () {
      var _THIS = this
      QualityApi.SaveQuanlityControlReportDataBak({
        medQcReportList: this._data.tableData,
        isOutRoomOper: this.isOutRoomOper
      }).then(function (response) {
        if (response.data.Data === 0) {
          _THIS.$message({
            message: response.data.Message,
            type: 'warning'
          })
        } else if (response.data.Data > 0) {
          _THIS.$message({
            message: response.data.Message,
            type: 'success'
          })
          _THIS.editFlag = !_THIS.editFlag
          _THIS.searchInfos()
        }
      })
    },
    // 导出
    exprotExcel () {
      var exportbtn = document.getElementById('hrefToExportTable')
      var _THIS = this
      QualityApi.quanlityExportData({
        reportMonth: this.selected,
        reportName: 'UpLoadQuanlityDataModify',
        exprotExcelColumns: this.exprotExcelColumns,
        isOutRoomOper: this.isOutRoomOper
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
    // 预览打印
    print () {
      var printHtml = this.$refs['refq'].innerHTML
      let newWindow = window.open('_blank')
      newWindow.document.write(printHtml)
      newWindow.document.close()
      newWindow.print()
      newWindow.close()
    }
  },

  created: function () {
    if (typeof this.$route.query.reportMonth !== 'undefined') {
      this.selected = this.$route.query.reportMonth
    }
    this.loadReportName()
    this.searchInfos()
  }
}
