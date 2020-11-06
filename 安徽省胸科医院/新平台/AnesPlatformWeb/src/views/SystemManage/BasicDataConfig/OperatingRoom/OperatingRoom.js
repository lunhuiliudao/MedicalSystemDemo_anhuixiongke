import BasicConfigApi from '@/api/BasicConfigApi.js'

export default {
  name: 'OperatingRoom',
  data () {
    return {
      loading: false,
      roomNo: '',
      roomNoList: [],
      paginationInfo: {
        currentPage: 1,
        pageSize: 20,
        total: 0,
        currentData: []
      },
      formData: this.newData(),
      medDeptDictList: [],
      bedTypeName: [
        {
          value: '0',
          label: '手术间'
        },
        {
          value: '1',
          label: 'PACU'
        }
      ],
      statusName: [
        {
          value: '0',
          label: '可用'
        },
        {
          value: '1',
          label: '不可用'
        }
      ],
      rules: {
        ROOM_NO: [
          { required: true, message: '请输入手术间号', trigger: 'blur' }
        ],
        DEPT_CODE: [
          { required: true, message: '请输入所属科室', trigger: 'blur' }
        ]
      },
      dialogEditVisible: false,
      dialogEditTitle: '新增',
      wayType: 0 // 弹出窗口类型，0-新增，1-修改
    }
  },
  created () {
    this.deptDict()
    this.getRoomNoList()
    this.searchData(1)
  },
  methods: {
    newData () {
      return {
        ROOM_NO: '',
        DEPT_CODE: '',
        LOCATION: '',
        BED_LABEL: '',
        BED_TYPE: '',
        STATUS: '',
        SORT_NO: 0
      }
    },
    roomNoRemoteMethod (query) {
      if (query !== '') {
        var _this = this
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
      BasicConfigApi.GetOperatingRoomListAll()
        .then(function (respose) {
          _this.roomNoList = respose.data.Data
        })
        .catch(error => {
          console.log(error)
        })
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
            console.log(_this.medDeptDictList[i].DEPT_NAME.indexOf(val))
            tmpList.push(_this.medDeptDictList[i])
          }
        }
        console.log(tmpList)
        _this.medDeptDictList = tmpList
      } else {
        this.deptDict()
      }
    },
    searchData (index) {
      var _this = this
      this.loading = true
      this.paginationInfo.currentPage = index
      BasicConfigApi.GetOperatingRoomList({
        OperatingRoomNo: this.roomNo === null ? '' : this.roomNo,
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
          var OperatingRoomList = []
          OperatingRoomList.push(row)
          BasicConfigApi.DeletedOperatingRoomList(OperatingRoomList)
            .then(function (respose) {
              if (respose.data.Data > 0) {
                _this.searchData(_this.paginationInfo.currentPage)
                _this.getRoomNoList()
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
          BasicConfigApi.EditOperatingRoomList(this.wayType, this.formData)
            .then(function (respose) {
              if (respose.data.Data === 2) {
                _this.$alert('手术间号已存在', {
                  confirmButtonText: '确定',
                  type: 'error'
                })
              } else if (respose.data.Data === 1) {
                _this.dialogEditVisible = false
                if (_this.wayType === 0) {
                  _this.getRoomNoList()
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
