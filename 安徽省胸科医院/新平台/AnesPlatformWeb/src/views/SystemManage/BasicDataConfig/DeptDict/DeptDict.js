import BasicConfigApi from '@/api/BasicConfigApi.js'

export default {
  name: 'DeptDict',
  data () {
    return {
      loading: false,
      deptName: '',
      deptNameList: [],
      deptTypeList: [],
      paginationInfo: {
        currentPage: 1,
        pageSize: 20,
        total: 0,
        currentData: []
      },
      formData: this.newData(),
      rules: {
        DEPT_CODE: [
          { required: true, message: '请输入科室代码', trigger: 'blur' }
        ],
        DEPT_NAME: [
          { required: true, message: '请输入科室名称', trigger: 'blur' }
        ]
      },
      dialogEditVisible: false,
      dialogEditTitle: '新增',
      wayType: 0 // 弹出窗口类型，0-新增，1-修改
    }
  },
  created: function () {
    this.searchData(1)
    this.getDeptTypeList()
    this.getDeptName()
  },
  methods: {
    newData () {
      return {
        DEPT_CODE: '',
        DEPT_NAME: '',
        DEPT_ALIAS: '',
        DEPT_TYPE: '',
        INPUT_CODE: '',
        SORT_NO: 0
      }
    },
    deptNameRemoteMethod (query) {
      if (query !== '') {
        var _this = this
        BasicConfigApi.GetDictList({
          name: 'MED_DEPT_DICT',
          inputContent: query
        })
          .then(function (respose) {
            _this.deptNameList = respose.data.Data
          })
          .catch(error => {
            console.log(error)
          })
      } else {
        this.getDeptName()
      }
    },
    getDeptName () {
      var _this = this
      BasicConfigApi.GetDictList({
        name: 'MED_DEPT_DICT',
        inputContent: ''
      })
        .then(function (respose) {
          _this.deptNameList = respose.data.Data
        })
        .catch(error => {
          console.log(error)
        })
    },
    getDeptTypeList () {
      var _this = this
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
      BasicConfigApi.GetMedDeptDict({
        DeptName: this.deptName,
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
          var MedDeptDictList = []
          MedDeptDictList.push(row)
          BasicConfigApi.DeletedMedDeptDict(MedDeptDictList)
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
          BasicConfigApi.EditMedDeptDict(this.wayType, this.formData)
            .then(function (respose) {
              console.log(respose.data.Data)
              if (respose.data.Data === 2) {
                _this.$alert('科室编码已存在', {
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
