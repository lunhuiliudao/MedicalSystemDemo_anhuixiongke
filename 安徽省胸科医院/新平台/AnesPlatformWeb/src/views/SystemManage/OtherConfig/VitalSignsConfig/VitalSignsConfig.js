import OtherConfigApi from '@/api/OtherConfigApi.js'
import BasicConfigApi from '@/api/BasicConfigApi.js'

export default {
  name: 'VitalSignsConfig',
  data () {
    return {
      selected: '',
      addFlag: false,
      tableData: [],
      ShowTypeList: [
        { value: 'Digit', label: '数字' },
        { value: 'Line', label: '曲线图' }
      ],
      SymbolTypeList: [
        { value: 'InOperationRoom', label: '入手术室标记' },
        { value: 'OutOperationRoom', label: '出手术室标记' },
        { value: 'Anesthesia', label: '麻醉标识' },
        { value: 'Operation', label: '手术标识' },
        { value: 'Point', label: '点' },
        { value: 'Square', label: '矩形' },
        { value: 'Diamond', label: '钻石型' },
        { value: 'VLetter', label: 'V形' },
        { value: 'VLetterLine', label: 'V形竖线' },
        { value: 'VLetterDown', label: '倒V形' },

        { value: 'VLetterDownLine', label: '倒V形竖线' },
        { value: 'Circle', label: '圆形' },
        { value: 'MiniCircle', label: '小圆形' },
        { value: 'MiniCircleLine', label: '小圆斜线' },
        { value: 'FillCircle', label: '实心圆' },
        { value: 'FillMiniCircle', label: '实心小圆' },
        { value: 'CircleDot', label: '圆中点' },
        { value: 'CircleHLine', label: '横线圆' },
        { value: 'CircleVLine', label: '竖线圆' },
        { value: 'CirclePlus', label: '圆内加号' },

        { value: 'CircleVArrow', label: '圆内垂直箭头' },
        { value: 'CircleHArrow', label: '圆内水平箭头' },
        { value: 'MachineAir', label: '机械通气' },
        { value: 'CircleXCross', label: '圆内交叉线' },
        { value: 'XCross', label: '交叉线' },
        { value: 'XCrossVLine', label: '米字交叉线' },
        { value: 'Star', label: '星形' },
        { value: 'Triangle', label: '三角形' },
        { value: 'TriangleDown', label: '倒三角形' },
        { value: 'Plus', label: '加号' },

        { value: 'PutPipe', label: '置管' },
        { value: 'PutPipe1', label: '置管1' },
        { value: 'PutPipe2', label: '置管2' },
        { value: 'PullPipe', label: '拔管' },
        { value: 'PullPipe1', label: '拔管1' }
      ],
      ShowTimeIntervalList: [
        { value: 'Five', label: '5分钟' },
        { value: 'Ten', label: '10分钟' },
        { value: 'Fifiteen', label: '15分钟' },
        { value: 'Twenty', label: '20分钟' },
        { value: 'HalfHour', label: '半小时' },
        { value: 'Hour', label: '1小时' },
        { value: 'AnyTime', label: '不限制' }
      ],
      ColorItemList: [],
      rules: {
        CurveName: [{ required: true, message: '请输入名称', trigger: 'blur' }]
      },
      MonitorFunctionCodeList: [],
      dialogEditVisible: false,
      dialogEditTitle: '新增',
      wayType: 0, // 弹出窗口类型，0-新增，1-修改
      formData: this.newData()
    }
  },
  methods: {
    newData () {
      return {
        CurveCode: '',
        CurveName: '',
        Visible: 'True',
        SymbolType: '',
        Color: '',
        ShowType: '',
        YAxisIndex: 0,
        DotNumber: 0,
        ShowTimeInterval: '',
        HideStartTime: '0001/1/1 0:00:00',
        HideEndTime: '0001/1/1 0:00:00'
      }
    },
    // 获取系统颜色
    getSystemColors () {
      var _THIS = this
      this.editFlag = false
      // this.$ajax
      //   .get('/Api/PlatformSurgicalMonitor/GetColors')
      OtherConfigApi.GetColors()
        .then(function (respose) {
          _THIS.ColorItemList = respose.data.Data
        })
        .catch(error => {
          console.log(error)
        })
    },
    // 获取采集项目字典表
    getMonitorFunctionCode () {
      var _THIS = this
      this.editFlag = false
      // this.$ajax
      //   .get('/Api/PlatformSysConfig/GetMonitorFunctionCodeNoPage', {
      //     params: {
      //       ItemName: ''
      //     }
      //   })
      BasicConfigApi.GetMonitorFunctionCodeNoPage({
        ItemName: ''
      })
        .then(function (respose) {
          _THIS.MonitorFunctionCodeList = respose.data.Data
        })
        .catch(error => {
          console.log(error)
        })
    },
    // 查询数据
    searchInfos () {
      var _THIS = this
      this.editFlag = false
      // this.$ajax
      //   .get('/Api/PlatformSurgicalMonitor/GetPatientMonitorConfig', {
      //     params: {
      //       patientID: '999',
      //       visitID: '0',
      //       operID: '0',
      //       eventNo: '0'
      //     }
      //   })
      OtherConfigApi.GetPatientMonitorConfig({
        patientID: '999',
        visitID: '0',
        operID: '0',
        eventNo: '0'
      })
        .then(function (respose) {
          _THIS.tableData = respose.data.Data
          if (_THIS.tableData === null) {
            _THIS.tableData = []
          }
        })
        .catch(error => {
          console.log(error)
        })
    },
    editInfos (index, row) {
      if (this.$refs['formView'] !== undefined) {
        this.$refs['formView'].resetFields()
      }
      this.dialogEditTitle = '编辑'
      this.wayType = 1
      Object.assign(this.formData, row)
      this.dialogEditVisible = true
    },
    // 新增数据
    addInfos () {
      if (this.$refs['formView'] !== undefined) {
        this.$refs['formView'].resetFields()
      }
      var _THIS = this
      Object.assign(this.formData, _THIS.newData())
      _THIS.dialogEditTitle = '新增'
      _THIS.dialogEditVisible = true
      _THIS.wayType = 0
    },
    // 删除数据
    deleteInfos (index, row) {
      this.$confirm('确认删除该数据吗?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'info'
      })
        .then(() => {
          var _THIS = this
          _THIS.tableData.splice(index, 1)
          _THIS.saveInfos()
        })
        .catch(error => {
          console.log(error)
        })
    },
    onSubmit (formName) {
      this.$refs[formName].validate(valid => {
        if (valid) {
          var _THIS = this
          if (this.wayType === 0) {
            _THIS.tableData.push(_THIS.formData)
          } else {
            _THIS.tableData.forEach(element => {
              if (
                element.CurveCode === _THIS.formData.CurveCode &&
                element.CurveName === _THIS.formData.CurveName
              ) {
                element.Visible = _THIS.formData.Visible
                element.ShowType = _THIS.formData.ShowType
                element.SymbolType = _THIS.formData.SymbolType
                element.Color = _THIS.formData.Color
                element.ShowTimeInterval = _THIS.formData.ShowTimeInterval
              }
            })
          }

          for (let index = 0; index < _THIS.tableData.length; index++) {
            var element = _THIS.tableData[index]

            if (
              element.CurveName === '' ||
              element.CurveName === null ||
              typeof element.CurveName === 'undefined'
            ) {
              _THIS.tableData.splice(index, 1)
            }
          }

          // this.$ajax
          //   .post('/Api/PlatformSurgicalMonitor/UpdatePatientMonitorConfig', {
          //     patientID: '999',
          //     visitID: '0',
          //     operID: '0',
          //     eventNo: '0',
          //     content: _THIS.tableData
          //   })
          OtherConfigApi.UpdatePatientMonitorConfig({
            patientID: '999',
            visitID: '0',
            operID: '0',
            eventNo: '0',
            content: _THIS.tableData
          }).then(function (response) {
            if (response.data.Data === 0) {
              _THIS.$message({
                message: '保存失败',
                type: 'warning'
              })
            } else if (response.data.Data > 0) {
              _THIS.$message({
                message: '保存成功',
                type: 'success'
              })
            }

            _THIS.dialogEditVisible = false
            _THIS.searchInfos()
          })
        } else {
          console.log('error submit')
          return false
        }
      })
    },
    // 保存信息
    saveInfos () {
      var _THIS = this

      for (let index = 0; index < _THIS.tableData.length; index++) {
        var element = _THIS.tableData[index]

        if (
          element.CurveName === '' ||
          element.CurveName === null ||
          typeof element.CurveName === 'undefined'
        ) {
          _THIS.tableData.splice(index, 1)
        }
      }

      // this.$ajax
      //   .post('/Api/PlatformSurgicalMonitor/UpdatePatientMonitorConfig', {
      //     patientID: '999',
      //     visitID: '0',
      //     operID: '0',
      //     eventNo: '0',
      //     content: _THIS.tableData
      //   })
      OtherConfigApi.UpdatePatientMonitorConfig({
        patientID: '999',
        visitID: '0',
        operID: '0',
        eventNo: '0',
        content: _THIS.tableData
      }).then(function (response) {
        if (response.data.Data === 0) {
          _THIS.$message({
            message: '保存失败',
            type: 'warning'
          })
        } else if (response.data.Data > 0) {
          _THIS.$message({
            message: '保存成功',
            type: 'success'
          })
        }

        _THIS.searchInfos()
      })
    },

    // 是否显示转换
    convertIsShow (Visible) {
      if (Visible === 'True') {
        return '是'
      } else {
        return '否'
      }
    },

    // 显示类型转换
    convertShowType (showType) {
      var type = this.ShowTypeList.filter(element => {
        return element.value === showType
      })

      if (type.length === 1) {
        return type[0].label
      } else {
        return showType
      }
    },

    // 显示图标转换
    convertSymbolType (symbolType) {
      var type = this.SymbolTypeList.filter(element => {
        return element.value === symbolType
      })

      if (type.length === 1) {
        return type[0].label
      } else {
        return symbolType
      }
    },
    // 时间间隔转换
    convertShowTimeInterval (showTimeInterval) {
      var type = this.ShowTimeIntervalList.filter(element => {
        return element.value === showTimeInterval
      })

      if (type.length === 1) {
        return type[0].label
      } else {
        return showTimeInterval
      }
    },
    // 设置曲线名称
    setCurveName (row) {
      var _THIS = this
      if (row.CurveCode === '') {
        _THIS.remoteCurveName('')
      } else {
        _THIS.MonitorFunctionCodeList.forEach(element => {
          if (element.ITEM_CODE === row.CurveCode) {
            row.CurveName = element.ITEM_NAME
          }
        })
      }
    },
    // 获取采集项目字典表
    remoteCurveName (query) {
      var _THIS = this
      // this.$ajax
      //   .get('/Api/PlatformSysConfig/GetMonitorFunctionCodeNoPage', {
      //     params: {
      //       ItemName: query.trim()
      //     }
      //   })
      BasicConfigApi.GetMonitorFunctionCodeNoPage({
        ItemName: query.trim()
      })
        .then(function (respose) {
          _THIS.MonitorFunctionCodeList = respose.data.Data
        })
        .catch(error => {
          console.log(error)
        })
    }
  },
  created: function () {
    this.getSystemColors()
    this.getMonitorFunctionCode()
    this.searchInfos()
  }
}
