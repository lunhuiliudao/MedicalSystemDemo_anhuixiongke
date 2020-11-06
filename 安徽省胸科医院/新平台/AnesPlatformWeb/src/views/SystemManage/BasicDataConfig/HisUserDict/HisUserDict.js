import BasicConfigApi from '@/api/BasicConfigApi.js'

export default {
  name: 'HisUserDict',
  data () {
    return {
      loading: false,
      userName: '',
      deptNameList: [],
      DEPT_NAME: '',
      paginationInfo: {
        currentPage: 1,
        pageSize: 20,
        total: 0,
        currentData: []
      },
      formData: this.newData(),
      medDeptDictList: [],
      userTypeList: [],
      rules: {
        USER_JOB_ID: [
          { required: true, message: '请输入用户工号', trigger: 'blur' }
        ],
        USER_NAME: [
          { required: true, message: '请输入用户姓名', trigger: 'blur' }
        ]
      },
      dialogEditVisible: false,
      dialogEditTitle: '新增',
      wayType: 0, // 弹出窗口类型，0-新增，1-修改
      userStatus: 1
    }
  },
  created () {
    this.deptDict()

    this.getuserTypeList()

    this.searchData(1)
  },
  methods: {
    newData () {
      return {
        USER_JOB_ID: '',
        USER_NAME: '',
        USER_DEPT_CODE: '',
        USER_JOB: '',
        INPUT_CODE: '',
        USER_STATUS: 0,
        SORT_NO: 0
      }
    },
    deptDict () {
      var _this = this

      BasicConfigApi.GetMedDeptDict({
        DeptName: '',
        PageSize: 10000,
        CurrentPage: 1
      })
        .then(function (respose) {
          _this.medDeptDictList = respose.data.Data.CurrentData
        })
        .catch(error => {
          console.log(error)
        })
    },
    getuserTypeList () {
      var _this = this
      BasicConfigApi.GetAnesInputDictByClass({
        ItemClass: '人员职别'
      })
        .then(function (respose) {
          _this.userTypeList = respose.data.Data
        })
        .catch(error => {
          console.log(error)
        })
    },
    deptNameRemoteMethod (query) {
      if (query !== '') {
        var _this = this
        BasicConfigApi.GetDictList({
          name: 'MED_DEPT_DICT',
          inputContent: query.toUpperCase()
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
    filterDept (val) {
      var _this = this
      if (val) {
        var length = _this.medDeptDictList.length
        var tmpList = []
        for (var i = 0; i < length; i++) {
          if (
            (_this.medDeptDictList[i].INPUT_CODE != null &&
              _this.medDeptDictList[i].INPUT_CODE.toUpperCase().indexOf(
                val.toUpperCase()
              ) > -1) ||
            _this.medDeptDictList[i].DEPT_NAME.indexOf(val) > -1
          ) {
            tmpList.push(_this.medDeptDictList[i])
          }
        }
        _this.medDeptDictList = tmpList
      } else {
        this.deptDict()
      }
    },
    userStatusChanged () {
      this.searchData()
    },
    searchData (index) {
      var _this = this
      this.loading = true
      this.paginationInfo.currentPage = index

      BasicConfigApi.GetMedHisUserDict({
        HisUserName: this.userName,
        DeptName: this.DEPT_NAME === null ? '' : this.DEPT_NAME,
        UserStatus: this.userStatus,
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
          var MedHisUserDict = []
          MedHisUserDict.push(row)

          BasicConfigApi.DeletedMedHisUserDict(MedHisUserDict)
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
          BasicConfigApi.EditMedHisUserDict(this.wayType, this.formData)
            .then(function (respose) {
              if (respose.data.Data === 2) {
                _this.$alert('用户工号已存在', {
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
