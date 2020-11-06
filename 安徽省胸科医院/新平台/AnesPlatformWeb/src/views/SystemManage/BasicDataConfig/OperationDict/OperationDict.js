import BasicConfigApi from '@/api/BasicConfigApi.js'

export default {
  name: 'OperationDict',
  data () {
    return {
      loading: false,
      operationName: '',
      paginationInfo: {
        currentPage: 1,
        pageSize: 20,
        total: 0,
        currentData: []
      },
      formData: this.newData(),
      operationScaleList: [],
      rules: {
        OPER_CODE: [
          { required: true, message: '请输入手术编码', trigger: 'blur' }
        ],
        OPER_NAME: [
          { required: true, message: '请输入手术名称', trigger: 'blur' }
        ]
      },
      dialogEditVisible: false,
      dialogEditTitle: '新增',
      wayType: 0 // 弹出窗口类型，0-新增，1-修改
    }
  },
  created () {
    this.searchData(1)
    this.operationScaleDict()
  },
  methods: {
    newData () {
      return {
        OPER_CODE: '',
        OPER_NAME: '',
        OPER_SCALE: '',
        INPUT_CODE: '',
        SORT_NO: 0
      }
    },
    operationScaleDict () {
      var _this = this
      BasicConfigApi.GetAnesInputDictByClass({
        ItemClass: '手术等级'
      })
        .then(function (respose) {
          _this.operationScaleList = respose.data.Data
        })
        .catch(error => {
          console.log(error)
        })
    },
    searchData (index) {
      var _this = this
      this.loading = true
      this.paginationInfo.currentPage = index
      BasicConfigApi.GetOperationDict({
        OperationName: this.operationName,
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
          var OperationDict = []
          OperationDict.push(row)
          BasicConfigApi.DeletedOperationDict(OperationDict)
            .then(function (respose) {
              console.log(respose.data.Data)
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
          BasicConfigApi.EditOperationDict(this.wayType, this.formData)
            .then(function (respose) {
              if (respose.data.Data === 2) {
                _this.$alert('手术编码已存在', {
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
