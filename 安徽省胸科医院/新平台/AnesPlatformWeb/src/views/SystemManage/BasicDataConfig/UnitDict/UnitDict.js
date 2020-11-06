import BasicConfigApi from '@/api/BasicConfigApi.js'

export default {
  name: 'UnitDict',
  data () {
    return {
      loading: false,
      unitType: '',
      paginationInfo: {
        currentPage: 1,
        pageSize: 20,
        total: 0,
        currentData: []
      },
      formData: this.newData(),
      unitTypeList: [
        {
          value: 1,
          label: '浓度单位'
        },
        {
          value: 2,
          label: '速度单位'
        },
        {
          value: 3,
          label: '剂量单位'
        }
      ],
      rules: {
        UNIT_CODE: [
          { required: true, message: '请输入单位代码', trigger: 'blur' }
        ],
        UNIT_NAME: [
          { required: true, message: '请输入单位名称', trigger: 'blur' }
        ],
        UNIT_TYPE: [
          {
            required: true,
            type: 'number',
            message: '请输入单位类型',
            trigger: 'change'
          }
        ]
      },
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
      return {
        UNIT_CODE: '',
        UNIT_NAME: '',
        UNIT_TYPE: 1,
        ITEM_CODE: '',
        INPUT_CODE: ''
      }
    },
    searchData (index) {
      var _this = this
      this.loading = true
      this.paginationInfo.currentPage = index
      // this.$ajax
      //   .get('/Api/PlatformSysConfig/GetUnitDict', {
      //     params: {
      //       UnitType: this.unitType
      //     }
      //   })
      BasicConfigApi.GetUnitDict({
        UnitType: this.unitType === null ? '' : this.unitType,
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
      // this.$ajax
      //   .get('/Api/PlatformSysConfig/GetAnesInputDictItemClassList')
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
          var UnitDict = []
          UnitDict.push(row)
          // this.$ajax
          //   .post('/Api/PlatformSysConfig/DeletedUnitDict', UnitDict)
          BasicConfigApi.DeletedUnitDict(UnitDict)
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
          // this.$ajax
          //   .post(
          //     '/Api/PlatformSysConfig/EditUnitDict?type=' + this.wayType,
          //     this.formData
          //   )
          BasicConfigApi.EditUnitDict(this.wayType, this.formData)
            .then(function (respose) {
              console.log(respose.data.Data)
              if (respose.data.Data === 2) {
                _this.$alert('该项目已存在', {
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
