import EventDictConfigApi from '@/api/EventDictConfigApi.js'
// import BasicConfigApi from '@/api/BasicConfigApi.js'
import TempleteConfigApi from '@/api/TempleteConfigApi.js'

export default {
  name: 'PullPipeEdit',
  data () {
    return {
      loading: false,
      itemClass: '8',
      itemName: '',
      paginationInfo: {
        currentPage: 1,
        pageSize: 20,
        total: 0,
        currentData: []
      },
      formData: {},
      medUnitsList: [],
      medAdministratorList: [],
      rules: {
        EVENT_ITEM_NAME: [
          { required: true, message: '请输入拔管名称', trigger: 'blur' }
        ]
      },
      dialogEditVisible: false,
      dialogEditTitle: '新增',
      wayType: 0 // 弹出窗口类型，0-新增，1-修改
    }
  },
  created () {
    this.searchData(1)
  },
  methods: {
    newData () {
      var _this = this
      // this.$ajax
      //   .get('/Api/PlatformSysConfig/NewMedEventDict', {
      //     params: {
      //       itemClass: '8'
      //     }
      //   })
      EventDictConfigApi.NewMedEventDict({
        itemClass: '8'
      })
        .then(function (respose) {
          _this.formData = {
            EVENT_CLASS_CODE: '8',
            EVENT_ITEM_CODE: respose.data.Data.EVENT_ITEM_CODE,
            EVENT_ITEM_NAME: '',
            EVENT_ITEM_SPEC: '',
            DOSAGE: '',
            DOSAGE_UNITS: '',
            ADMINISTRATOR: '',
            SORT_NO: 0
          }
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
      //   .get('/Api/PlatformSysConfig/GetMedEventDict', {
      //     params: {
      //       itemClass: this.itemClass,
      //       itemName: this.itemName,
      //       PageSize: this.paginationInfo.pageSize,
      //       CurrentPage: this.paginationInfo.currentPage
      //     }
      //   })
      TempleteConfigApi.GetMedEventDict({
        itemClass: this.itemClass,
        itemName: this.itemName,
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
      this.formData = JSON.parse(JSON.stringify(row))
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
          var medAnesDrugDictList = []
          medAnesDrugDictList.push(row)
          // this.$ajax
          //   .post(
          //     '/Api/PlatformSysConfig/DeletedMedEventDict',
          //     medAnesDrugDictList
          //   )
          EventDictConfigApi.DeletedMedEventDict(medAnesDrugDictList)
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
          // this.$ajax
          //   .post(
          //     '/Api/PlatformSysConfig/EditMedEventDict?type=' + this.wayType,
          //     this.formData
          //   )
          EventDictConfigApi.EditMedEventDict(this.wayType, this.formData)
            .then(function (respose) {
              if (respose.data.Data === 2) {
                _this.$alert('该拔管已存在', {
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
