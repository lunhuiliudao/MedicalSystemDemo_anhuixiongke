import BasicConfigApi from '@/api/BasicConfigApi.js'

export default {
  name: 'AnesMethodDict',
  data () {
    return {
      loading: false,
      anesMethod: '',
      anesMethodTypeOptions: [],
      paginationInfo: {
        currentPage: 1,
        pageSize: 20,
        total: 0,
        currentData: []
      },
      formData: this.newData(),
      rules: {
        ANAESTHESIA_CODE: [
          { required: true, message: '请输入麻醉方法代码', trigger: 'blur' }
        ],
        ANAESTHESIA_NAME: [
          { required: true, message: '请输入麻醉方法名称', trigger: 'blur' }
        ]
      },
      dialogEditVisible: false,
      dialogEditTitle: '新增',
      wayType: 0 // 弹出窗口类型，0-新增，1-修改
    }
  },
  created: function () {
    this.searchAnesMethodTypeDict()
    this.searchData(1)
  },
  methods: {
    newData () {
      return {
        ANAESTHESIA_CODE: '',
        ANAESTHESIA_NAME: '',
        ANAESTHESIA_TYPE: '',
        ANAESTHESIA_ABBR: '',
        INPUT_CODE: '',
        SORT_NO: 0
      }
    },
    // 查询麻醉方法分类项目字典数据
    searchAnesMethodTypeDict () {
      var _this = this
      // this.$ajax
      //   .get('/Api/PlatformSysConfig/GetAnesInputDictByItemClassNoPage', {
      //     params: {
      //       ItemClass: '麻醉分类'
      //     }
      //   })
      BasicConfigApi.GetAnesInputDictByItemClassNoPage({
        ItemClass: '麻醉分类'
      })
        .then(function (respose) {
          var data = respose.data.Data
          _this.anesMethodTypeOptions = data
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
      //   .get('/Api/PlatformSysConfig/GetAnesthesiaDict', {
      //     params: {
      //       AnesMethodName: this.anesMethod,
      //       PageSize: this.paginationInfo.pageSize,
      //       CurrentPage: this.paginationInfo.currentPage
      //     }
      //   })
      BasicConfigApi.GetAnesthesiaDict({
        AnesMethodName: this.anesMethod,
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
          var AnesthesiaDict = []
          AnesthesiaDict.push(row)
          // this.$ajax
          //   .post(
          //     '/Api/PlatformSysConfig/DeletedAnesthesiaDict',
          //     AnesthesiaDict
          //   )
          BasicConfigApi.DeletedAnesthesiaDict(AnesthesiaDict)
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
          //   '/Api/PlatformSysConfig/EditAnesthesiaDict?type=' + this.wayType,
          //   this.formData
          // )
          BasicConfigApi.EditAnesthesiaDict(this.wayType, this.formData)
            .then(function (respose) {
              if (respose.data.Data === 2) {
                _this.$alert('麻醉方法代码已存在', {
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
