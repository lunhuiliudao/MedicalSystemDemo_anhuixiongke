import AnesReportApi from '@/api/AnesReportApi.js'

export default {
  name: 'QualityControlConfig',
  data () {
    return {
      selected: '',
      startTime: '',
      endTime: '',
      searchDate: this.$$moment().format('YYYY-MM'),
      tableData: [],
      isUpload: false,
      outputs: [],
      showPuts: [],
      html: '',
      strSql: '',
      dialogSQLViewVisible: false,
      condition: [],
      options: [{ Key: '', Value: '' }],
      preIsShow: false,
      showResult: '',
      btnSql: false,
      execleOptions: [{ Key: '', Value: '' }],
      execlName: '', // Execl模板选择
      documentExplainStr: '',
      dialogExecleFileVisible: false,
      Value: '',
      optionsBackUp: [{ Key: '', Value: '' }],
      formData: '',
      selectValueM: '',
      isDelete: false // 是否什删除模板
    }
  },
  methods: {
    // 加载模板
    getExceleM () {
      AnesReportApi.getExeclModelName().then((respose) => {
        this.execleOptions = respose.data.Data
      }).catch(error => {
        console.log(error)
      })
    },
    // 模板选择change事件
    changeExceleM (Key) {
      this.execlName = Key
      if (Key === null || Key === undefined || Key === '') {
      } else {
        setTimeout(() => {
          this.searchInfos()
        }, 10)
      }
    },
    // 查询数据
    searchInfos () {
      let sTime = this.startTime.getFullYear() + '-' + (this.startTime.getMonth() + 1) + '-' + this.startTime.getDate() + ' ' + this.startTime.getHours() + ':' + this.startTime.getMinutes() + ':' + this.startTime.getSeconds()
      let endTime = this.endTime.getFullYear() + '-' + (this.endTime.getMonth() + 1) + '-' + this.endTime.getDate() + ' ' + this.endTime.getHours() + ':' + this.endTime.getMinutes() + ':' + this.endTime.getSeconds()
      this.execlName = this.$refs.selectExeclM.selectedLabel
      if (this.execlName === null || this.execlName === undefined || this.execlName === '') {
        this.$alert('<strong> ~ 请先选择Execle质控模板 ！</strong>', '提示', {
          dangerouslyUseHTMLString: true
        })
        return
      }
      // 加载进度条
      var loading = this.$loading({
        text: '拼命加载中...',
        background: 'rgba(255, 255, 255, 0.5)',
        target: document.querySelector('.customconfig-wrapper')
      })
      // 加载html
      AnesReportApi.getReportQueryFromExeclModel({ 'StartTime': sTime, 'EndTime': endTime, 'ExeclModelName': this.execlName }).then((respose) => {
        if (respose.data.Data.Data === null) {
          this.html = '解析不出！！请联系管理员.'
        } else {
          this.html = respose.data.Data
        }
        loading.close() // 关闭进度条
      }).catch(error => {
        console.log(error)
      })
    },
    // sql查看
    showSqlDialog () {
      this.Value = ''
      if (this.execlName === null || this.execlName === undefined || this.execlName === '') {
        this.$alert('<strong> ~ 请先选择Execle质控模板 ！</strong>', '提示', {
          dangerouslyUseHTMLString: true
        })
        return
      }
      AnesReportApi.getExcelModleDataDictDefautPath({ 'GroupName': this.execlName }).then((respose) => {
        if (respose.data.Data.length > 0) {
          this.options = respose.data.Data
          // 备份数据
          this.optionsBackUp = respose.data.Data
        }
      }).catch((error) => {
        console.log(error)
      })
      this.strSql = ''
      this.showResult = ''
      this.dialogSQLViewVisible = true
    },
    // 下拉首字母过滤
    handleFilter (Value) {
      let valueToUp = Value.toUpperCase() // 助记码
      let showData = [] // 展现的数据
      this.Value = Value
      for (var i = 0; i < this.optionsBackUp.length; i++) {
        let inputCode = this.optionsBackUp[i].InputCode.substring(4)
        if (inputCode.indexOf(valueToUp) >= 0) {
          if (showData.length === 0) {
            showData.push(this.optionsBackUp[i])
          } else {
            let flag = 0
            for (var j = 0; j < showData.length; j++) {
              if (showData[j].InputCode.indexOf(this.optionsBackUp[i].InputCode) >= 0) {
                flag++
              }
            }
            if (flag === 0) {
              showData.push(this.optionsBackUp[i])
            }
          }
        }
      }
      this.options = showData
    },
    selectChange (Key) {
      var keyToSql = ''
      for (var i = 0; i < this.options.length; i++) {
        if (Key === this.options[i].Key) {
          keyToSql = this.options[i].Value
          break
        }
      }
      if (keyToSql === '' || keyToSql === undefined || keyToSql === null) {
        this.preIsShow = false
      } else {
        this.preIsShow = true
      }
      this.strSql = keyToSql
      this.showResult = ''
    },
    // 显示sql执行结果
    showSqlResult () {
      var showSql = this.strSql.toUpperCase()
      if (showSql === '' || showSql === null || showSql === undefined) {
        this.$alert('<strong> ~ 请先写入对应SQL ！</strong>', '提示', {
          dangerouslyUseHTMLString: true
        })
        return
      }
      AnesReportApi.executeOrTestSQLFromUser({
        'StartTime': this.startTime,
        'EndTime': this.endTime,
        'Key': this.$refs.selectValue.selectedLabel,
        'Value': showSql
      }).then((respose) => {
        this.showResult = respose.data.Data
      }).catch((error) => {
        console.log(error)
      })
    },
    // 关闭
    closeSqlDialog () {
      this.dialogSQLViewVisible = false
      this.searchInfos()
    },
    // 关闭
    closeDialog () {
      this.dialogSQLViewVisible = false
      this.searchInfos()
    },
    // 保存
    saveSqlDialog () {
      let key = this.$refs.selectValue.selectedLabel
      if (key === '' || key === undefined || key === null) {
        this.$alert('<strong> ~ 请先选择单元格 ！</strong>', '提示', {
          dangerouslyUseHTMLString: true
        })
        return
      }
      let sql = this.strSql
      AnesReportApi.insertOrUpdateSqlToExcelModleData({
        'Key': key,
        'Value': sql,
        'GroupName': this.execlName
      }).then((respose) => {
        this.$message('保存成功！', 0)
        // 重新加载单元格sql
        AnesReportApi.getExcelModleDataDictDefautPath({ 'GroupName': this.execlName }).then((resposeA) => {
          this.options = resposeA.data.Data
          this.$refs.selectValue.selectedLabel = key
          for (var i = 0; i < this.options.length; i++) {
            if (key === this.options[i].Key) {
              this.strSql = this.options[i].Value
              break
            }
          }
        }).catch((error) => {
          console.log(error)
        })
      }).catch((error) => {
        console.log(error)
      })
    },
    textareaChange () {
      if (this.strSql === '' || this.strSql === null) {
        this.showResult = ''
      }
    },
    documentExplain () {
      if (this.execlName === null || this.execlName === undefined || this.execlName === '') {
        this.$alert('<strong> ~ 请先选择Execle质控模板 ！</strong>', '提示', {
          dangerouslyUseHTMLString: true
        })
        return
      }
      var flag = this.execlName.indexOf('.')
      var explainUrl = this.execlName.substring(0, flag)
      var htmlUrl = this.webconfig.apiUrl + '/Config/Help/' + explainUrl + '.html'
      this.axios.get(htmlUrl).then((respose) => {
        window.open(htmlUrl)
      }).catch(error => {
        console.log(error)
        this.$alert('<strong> ~ 当前-- ' + this.execlName + ' --不存在说明文档！</strong>', '提示', {
          dangerouslyUseHTMLString: true
        })
      })
    },
    closeDocumentDialog () {
      this.dialogExecleFileVisible = false
    },
    upFile () {
      this.dialogExecleFileVisible = true
    },
    // 预览打印
    preview () {
      this.execlName = this.$refs.selectExeclM.selectedLabel
      if (this.execlName === null || this.execlName === undefined || this.execlName === '') {
        this.$alert('<strong> ~ 请先选择Execle质控模板 ！</strong>', '提示', {
          dangerouslyUseHTMLString: true
        })
        return
      }
      var printHtml = this.html
      let newWindow = window.open('_blank')
      newWindow.document.write(printHtml)
      newWindow.document.close()
      newWindow.print()
      newWindow.close()
    },
    // 上传文件之前的钩子
    beforeUpload1 (file) {
      const isText = file.type === 'application/vnd.ms-excel'
      const isTextComputer = file.type === 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet'
      if (!(isText | isTextComputer)) {
        this.$alert('<strong> ~ 上传的模板只能是 Execle 格式 ！</strong>', '提示', {
          dangerouslyUseHTMLString: true
        })
        return false
      }
      return (isText | isTextComputer)
    },
    beforeUpload (file) {
      var testmsg = file.name.substring(file.name.lastIndexOf('.') + 1)
      const extension = testmsg === 'xls'
      const extension2 = testmsg === 'xlsx'
      const isLt2M = file.size / 1024 / 1024 < 5
      if (!extension && !extension2) {
        this.$message({
          message: '上传文件只能是 xls、xlsx格式!',
          type: 'warning'
        })
      }
      if (!isLt2M) {
        this.$message({
          message: '上传文件大小不能超过 5MB!',
          type: 'warning'
        })
      }
      return (extension || extension2) && isLt2M
    },
    // 上传文件个数超过定义的数量
    handleExceed (files, fileList) {
      this.$message.warning(`当前限制选择 2 个文件，请删除后继续上传`)
    },
    downFile () {
      if (this.execlName === null || this.execlName === undefined || this.execlName === '') {
        this.$alert('<strong> ~ 请先选择Execle模板 ！</strong>', '提示', {
          dangerouslyUseHTMLString: true
        })
        return
      }
      var url = this.webconfig.apiUrl + '/Config/ExcelModel/IndexExcelModel/' + this.execlName
      window.open(url)
    },
    uploadFile4 (item) {
      const fileObj = item.file
      var messageShow = '是否确定上传-- ' + item.file.name + '文件'
      const formData = new FormData()
      formData.append('file', fileObj)
      // 确定是否上传提示
      this.$confirm(messageShow, '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning'
      }).then(() => {
        AnesReportApi.uploadExcelToDefautPath(formData).then((res) => {
          if (res.data.Data === '成功上传了') {
            // 重新加载Execle模板
            this.getExceleM()
            this.$message({
              showClose: true,
              message: ' 上传成功 !!'
            })
          }
          this.dialogExecleFileVisible = false
          this.execlName = item.file.name
          setTimeout(() => {
            this.searchInfos()
          }, 10)
        }).catch((error) => {
          console.log(error)
        })
      }).catch(() => {
        this.$message({
          type: 'info',
          message: '已取消上传'
        })
      })
    },
    iFun (name) {
      var messageShow = '是否确定删除  ' + name + '  模板文件 ！！'
      this.$confirm(messageShow, '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning'
      }).then(() => {
        // 删除execle模板
        AnesReportApi.deleteExcelModele({ 'ExcelModeleName': name }).then((respose) => {
          this.getExceleM()
          this.execlName = ''
          this.$message({
            showClose: true,
            message: ' 删除成功 !!'
          })
        }).catch(error => {
          console.log(error)
        })
      }).catch(() => {
        this.$message({
          type: 'info',
          message: '已取消删除'
        })
      })
    }
  },
  created: function () {
    this.getExceleM()
    this.endTime = new Date()
    this.startTime = new Date()
    this.startTime.setMonth(new Date().getMonth() - 1)
  }
}
