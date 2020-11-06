import BasicConfigApi from '@/api/BasicConfigApi.js'

export default {
  name: 'MonitorDict',
  data () {
    return {
      loading: false,
      monitorName: '',
      monitorNameList: [],
      statusList: [{ value: '允许', label: '允许' }, { value: '', label: '' }],
      mathionTypeList: [{ value: '1', label: '1' }, { value: '0', label: '0' }],
      comTypeList: [
        { value: '1', label: '网口' },
        { value: '0', label: '串口' }
      ],
      roomNoList: [],
      deptTypeList: [],
      paginationInfo: {
        currentPage: 1,
        pageSize: 20,
        total: 0,
        currentData: []
      },
      formData: this.newData(),
      rules: {
        MONITOR_LABEL: [
          { required: true, message: '请输入监护仪标识', trigger: 'blur' }
        ]
      },
      dialogEditVisible: false,
      dialogEditTitle: '新增',
      wayType: 0 // 弹出窗口类型，0-新增，1-修改
    }
  },
  created: function () {
    this.getMonitorNameList()
    this.getRoomNoList()
    this.getDeptTypeList()
    this.searchData(1)
  },
  methods: {
    newData () {
      return {
        MONITOR_LABEL: '',
        MANU_FIRM_NAME: '',
        MODEL: '',
        INTERFACE_TYPE: '',
        IP_ADDR: '',
        COMM_PORT: '',
        DRIVER_PROG: '',
        ITEM_TYPE: '',
        CURRENT_RECV_ITEMS: '',
        WARD_CODE: '',
        WARD_TYPE: '',
        BED_NO: '',
        PC_PORT: '',
        DEFAULT_RECV_FREQUENCY: '',
        CURRENT_RECV_FREQUENCY: '',
        DATALOG_STATUS: '',
        MEMO: ''
      }
    },
    roomNoRemoteMethod (query) {
      if (query !== '') {
        var _this = this
        // this.$ajax.get('/Api/PlatformSysConfig/GetOperatingRoomListNoPage', {
        //   params: {
        //     OperatingRoomNo: query
        //   }
        // })
        BasicConfigApi.GetOperatingRoomListNoPage({
          OperatingRoomNo: query
        })
          .then(function (respose) {
            _this.roomNoList = respose.data.Data
          })
          .catch(error => {
            console.log(error)
          })
      } else {
        this.getRoomNoList()
      }
    },
    getRoomNoList () {
      var _this = this
      // this.$ajax
      //   .get('/Api/PlatformSysConfig/GetOperatingRoomListAll')
      BasicConfigApi.GetOperatingRoomListAll()
        .then(function (respose) {
          _this.roomNoList = respose.data.Data
        })
        .catch(error => {
          console.log(error)
        })
    },
    monitorNameRemoteMethod (query) {
      if (query !== '') {
        var _this = this
        // this.$ajax
        //   .get('/Api/PlatformSysConfig/GetMonitorDictNoPage', {
        //     params: {
        //       MonitorName: query
        //     }
        //   })
        BasicConfigApi.GetMonitorDictNoPage({
          MonitorName: query
        })
          .then(function (respose) {
            _this.monitorNameList = respose.data.Data
          })
          .catch(error => {
            console.log(error)
          })
      } else {
        this.getMonitorNameList()
      }
    },
    getMonitorNameList () {
      var _this = this
      // this.$ajax
      //   .get('/Api/PlatformSysConfig/GetMonitorDict')
      BasicConfigApi.GetMonitorDict()
        .then(function (respose) {
          _this.monitorNameList = respose.data.Data
        })
        .catch(error => {
          console.log(error)
        })
    },
    getDeptTypeList () {
      var _this = this
      // this.$ajax
      //   .get('/Api/PlatformCommon/GetAnesInputDictByClass', {
      //     params: {
      //       ItemClass: '科室类别'
      //     }
      //   })
      BasicConfigApi.GetAnesInputDictByClass({
        ItemClass: '科室类别'
      })
        .then(function (respose) {
          _this.deptTypeList = respose.data.Data
        })
        .catch(error => {
          console.log(error)
        })
    },
    searchData (index) {
      var _this = this
      this.loading = true
      this.paginationInfo.currentPage = index
      // this.$ajax
      //   .get('/Api/PlatformSysConfig/GetMonitorDict', {
      //     params: {
      //       MonitorName: this.monitorName,
      //       PageSize: this.paginationInfo.pageSize,
      //       CurrentPage: this.paginationInfo.currentPage
      //     }
      //   })
      BasicConfigApi.GetMonitorDict({
        MonitorName: _this.monitorName === null ? '' : _this.monitorName,
        PageSize: this.paginationInfo.pageSize,
        CurrentPage: this.paginationInfo.currentPage
      })
        .then(function (respose) {
          _this.paginationInfo.currentData = respose.data.Data.CurrentData
          _this.paginationInfo.total = respose.data.Data.Total
          _this.loading = false
        })
        .catch(error => {
          console.log(error)
        })
    },
    handleCurrentChange (val) {
      this.searchData(val)
    },
    addData () {
      if (this.$refs['formView'] !== undefined) {
        this.$refs['formView'].resetFields()
      }
      Object.assign(this.formData, this.newData())
      this.dialogEditTitle = '新增'
      this.dialogEditVisible = true
      this.wayType = 0
    },
    editData (index, row) {
      if (this.$refs['formView'] !== undefined) {
        this.$refs['formView'].resetFields()
      }
      this.dialogEditTitle = '编辑'
      this.wayType = 1
      Object.assign(this.formData, row)
      this.dialogEditVisible = true
    },
    deleteData (index, row) {
      this.$confirm('确认删除该数据吗?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'info'
      })
        .then(() => {
          var _this = this
          var MonitorDict = []
          MonitorDict.push(row)
          // this.$ajax
          //   .post('/Api/PlatformSysConfig/DeletedMonitorDict', MonitorDict)
          BasicConfigApi.DeletedMonitorDict(MonitorDict)
            .then(function (respose) {
              if (respose.data.Data > 0) {
                _this.searchData(_this.paginationInfo.currentPage)
                _this.getMonitorNameList()
              }
            })
            .catch(error => {
              console.log(error)
            })
        })
        .catch(error => {
          console.log(error)
        })
    },
    onSubmit (formName) {
      this.$refs[formName].validate(valid => {
        if (valid) {
          var _this = this
          // this.$ajax
          //   .post(
          //     '/Api/PlatformSysConfig/EditMonitorDict?type=' + this.wayType,
          //     this.formData
          //   )
          BasicConfigApi.EditMonitorDict(this.wayType, this.formData)
            .then(function (respose) {
              if (respose.data.Data === 2) {
                _this.$alert('监护仪标识已存在', {
                  confirmButtonText: '确定',
                  type: 'error'
                })
              } else if (respose.data.Data === 1) {
                _this.dialogEditVisible = false
                if (_this.wayType === 0) {
                  _this.searchData(1)
                  _this.getMonitorNameList()
                } else {
                  _this.searchData(_this.paginationInfo.currentPage)
                }
              }
            })
            .catch(error => {
              console.log(error)
            })
        } else {
          console.log('error submit')
          return false
        }
      })
    },
    IpValidate (val) {
      if (val !== '') {
        var reg = /^((25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))$/
        if (!reg.test(val)) {
          this.$message({
            message: '不是有效的IP地址',
            type: 'warning'
          })
        }
      }
    }
  }
}
