import BasicConfigApi from '@/api/BasicConfigApi.js'

export default {
  name: 'MonitorFunctionCode',
  data () {
    return {
      loading: false,
      itemName: '',
      itemNameList: [],
      paginationInfo: {
        currentPage: 1,
        pageSize: 20,
        total: 0,
        currentData: []
      },
      formData: this.newData(),
      rules: {
        ITEM_CODE: [
          { required: true, message: '请输入生命体征代码', trigger: 'blur' }
        ],
        ITEM_NAME: [
          { required: true, message: '请输入生命体征名称', trigger: 'blur' }
        ]
      },
      dialogEditVisible: false,
      dialogEditTitle: '新增',
      wayType: 0 // 弹出窗口类型，0-新增，1-修改
    }
  },
  created () {
    this.getItemNameList()
    this.searchData(1)
  },
  methods: {
    newData () {
      return {
        ITEM_CODE: '',
        ITEM_NAME: '',
        ITEM_UNIT: '',
        DIS_COLOR: '',
        DRAW_ICON: '',
        MEMO: ''
      }
    },
    itemNameRemoteMethod (query) {
      if (query !== '') {
        var _this = this
        // this.$ajax
        //   .get('/Api/PlatformSysConfig/GetMonitorFunctionCodeNoPage', {
        //     params: {
        //       ItemName: query
        //     }
        //   })
        BasicConfigApi.GetMonitorFunctionCodeNoPage({
          ItemName: query
        })
          .then(function (respose) {
            _this.itemNameList = respose.data.Data
          })
          .catch(error => {
            console.log(error)
          })
      } else {
        this.getItemNameList()
      }
    },
    getItemNameList () {
      var _this = this
      // this.$ajax.get('/Api/PlatformSysConfig/GetMonitorFunctionCodeNoPage', {
      //   params: {
      //     ItemName: ''
      //   }
      // })
      BasicConfigApi.GetMonitorFunctionCodeNoPage({
        ItemName: ''
      })
        .then(function (respose) {
          _this.itemNameList = respose.data.Data
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
      //   .get('/Api/PlatformSysConfig/GetMonitorFunctionCode', {
      //     params: {
      //       ItemName: this.itemName,
      //       PageSize: this.paginationInfo.pageSize,
      //       CurrentPage: this.paginationInfo.currentPage
      //     }
      //   })
      BasicConfigApi.GetMonitorFunctionCode({
        ItemName: this.itemName,
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
          var MonitorFunctionCodeList = []
          MonitorFunctionCodeList.push(row)
          // this.$ajax
          //   .post(
          //     '/Api/PlatformSysConfig/DeletedMonitorFunctionCodeList',
          //     MonitorFunctionCodeList
          //   )
          BasicConfigApi.DeletedMonitorFunctionCodeList(MonitorFunctionCodeList)
            .then(function (respose) {
              if (respose.data.Data > 0) {
                _this.searchData(_this.paginationInfo.currentPage)
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
          // this.$ajax.post(
          //   '/Api/PlatformSysConfig/EditMonitorFunctionCodeList?type=' +
          //     this.wayType,
          //   this.formData
          // )
          BasicConfigApi.EditMonitorFunctionCodeList(
            this.wayType,
            this.formData
          )
            .then(function (respose) {
              if (respose.data.Data === 2) {
                _this.$alert('生命体征项目已存在', {
                  confirmButtonText: '确定',
                  type: 'error'
                })
              } else if (respose.data.Data === 1) {
                _this.dialogEditVisible = false
                if (_this.wayType === 0) {
                  _this.searchData(1)
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
    }
  }
}
