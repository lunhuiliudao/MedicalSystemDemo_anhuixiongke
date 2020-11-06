import BasicConfigApi from '@/api/BasicConfigApi.js'

export default {
  name: 'AnesInputDict',
  data () {
    return {
      loading: false,
      itemClass: '',
      paginationInfo: {
        currentPage: 1,
        pageSize: 20,
        total: 0,
        currentData: []
      },
      formData: this.newData(),
      rules: {
        ITEM_NAME: [{ required: true, message: '请输入名称', trigger: 'blur' }]
      },
      anesInputDictItemClassList: [],
      dialogEditVisible: false,
      dialogEditTitle: '新增',
      wayType: 0 // 弹出窗口类型，0-新增，1-修改
    }
  },
  created () {
    this.itemClassList()
    this.searchData(1)
  },
  methods: {
    newData () {
      return { ITEM_CLASS: '', ITEM_NAME: '', ITEM_CODE: '', INPUT_CODE: '' }
    },
    searchData (index) {
      var _this = this
      this.loading = true
      this.paginationInfo.currentPage = index
      BasicConfigApi.GetAnesInputDictByItemClass({
        ItemClass: this.itemClass === null ? '' : this.itemClass,
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
    itemClassList () {
      var _this = this
      BasicConfigApi.GetAnesInputDictItemClassList()
        .then(function (respose) {
          _this.anesInputDictItemClassList = respose.data.Data
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
          var AnesInputDict = []
          AnesInputDict.push(row)
          BasicConfigApi.DeletedAnesInputDict(AnesInputDict)
            .then(function (respose) {
              if (respose.data.Data > 0) {
                _this.searchData(_this.paginationInfo.currentPage)
                _this.itemClassList()
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
          BasicConfigApi.EditAnesInputDict(this.wayType, this.formData)
            .then(function (respose) {
              if (respose.data.Data === 2) {
                _this.$alert('该项目已存在', {
                  confirmButtonText: '确定',
                  type: 'error'
                })
              } else if (respose.data.Data === 1) {
                _this.dialogEditVisible = false
                if (_this.wayType === 0) {
                  _this.searchData(1)
                  _this.itemClassList()
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
