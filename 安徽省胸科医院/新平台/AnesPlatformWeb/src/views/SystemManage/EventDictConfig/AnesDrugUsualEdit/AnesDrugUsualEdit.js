import EventDictConfigApi from '@/api/EventDictConfigApi.js'
import BasicConfigApi from '@/api/BasicConfigApi.js'
import TempleteConfigApi from '@/api/TempleteConfigApi.js'

export default {
  name: 'AnesDrugUsualEdit',
  data () {
    return {
      loading: false,
      itemClass: this.$route.query.itemClass,
      itemCode: '',
      paginationInfo: this.newPaginationInfo(),
      formData: {},
      anesDrugItemList: [],
      medUnitsList: [],
      rules: {
        STANDARD_DOSAGE: [
          { required: true, message: '请输入常用量', trigger: 'blur' }
        ]
      },
      dialogEditVisible: false,
      dialogEditTitle: '新增',
      wayType: 0 // 弹出窗口类型，0-新增，1-修改
    }
  },
  watch: {
    $route: 'fetchData'
  },
  computed: {
    typeName: function () {
      return this.itemClass === '2'
        ? '麻药'
        : this.itemClass === '3'
          ? '输液'
          : this.itemClass === 'C'
            ? '用药'
            : this.itemClass === 'B'
              ? '输血'
              : '1111'
    }
  },
  created () {
    this.itemClassList()
    this.searchData(1)
    this.UnitsDict()
  },
  methods: {
    fetchData () {
      this.itemClass = this.$route.query.itemClass
      this.itemCode = ''
      this.paginationInfo = this.newPaginationInfo()
      this.itemClassList()
      this.searchData(1)
    },
    newPaginationInfo () {
      return {
        currentPage: 1,
        pageSize: 20,
        total: 0,
        currentData: []
      }
    },
    newData () {
      var _this = this
      var name = this.anesDrugItemList.find(
        d => d.EVENT_ITEM_CODE === this.itemCode
      )
      // this.$ajax
      //   .get('/Api/PlatformSysConfig/NewMedEventExtDict', {
      //     params: {
      //       itemClass: this.itemClass,
      //       itemCode: this.itemCode
      //     }
      //   })
      EventDictConfigApi.NewMedEventExtDict({
        itemClass: this.itemClass,
        itemCode: this.itemCode
      })
        .then(function (respose) {
          _this.formData = {
            EVENT_CLASS_CODE: respose.data.Data.EVENT_CLASS_CODE,
            EVENT_ITEM_NAME: name.EVENT_ITEM_NAME,
            EVENT_ITEM_CODE: respose.data.Data.EVENT_ITEM_CODE,
            DOSAGE_NO: respose.data.Data.DOSAGE_NO,
            EVENT_ITEM_SPEC: name.EVENT_ITEM_SPEC,
            STANDARD_DOSAGE: '',
            DOSAGE_UNITS: respose.data.Data.DOSAGE_UNITS,
            ADMINISTRATOR: '',
            SORT_NO: 0
          }
          console.log(_this.formData)
        })
        .catch(error => {
          console.log(error)
        })
    },
    UnitsDict () {
      var _this = this
      // this.$ajax
      //   .get('/Api/PlatformSysConfig/GetUnitDict', {
      //     params: {
      //       UnitType: '3'
      //     }
      //   })
      BasicConfigApi.GetUnitDict({
        UnitType: '3',
        PageSize: 99999
      })
        .then(function (respose) {
          _this.medUnitsList = respose.data.Data.CurrentData
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
      //   .get('/Api/PlatformSysConfig/GetMedEventDictExt', {
      //     params: {
      //       itemClass: this.itemClass,
      //       itemCode: this.itemCode
      //     }
      //   })
      EventDictConfigApi.GetMedEventDictExt({
        itemClass: this.itemClass,
        itemCode: this.itemCode === null ? '' : this.itemCode,
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
      //   .get('/Api/PlatformSysConfig/GetMedEventDict', {
      //     params: {
      //       itemClass: this.itemClass
      //     }
      //   })
      TempleteConfigApi.GetMedEventDict({
        itemClass: this.itemClass
      })
        .then(function (respose) {
          _this.anesDrugItemList = respose.data.Data
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
          var OperationDict = []
          OperationDict.push(row)
          // this.$ajax
          //   .post(
          //     '/Api/PlatformSysConfig/DeletedMedEventExtDict',
          //     OperationDict
          //   )
          EventDictConfigApi.DeletedMedEventExtDict(OperationDict)
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
          //     '/Api/PlatformSysConfig/EditMedEventExtDict?type=' + this.wayType,
          //     this.formData
          //   )
          EventDictConfigApi.EditMedEventExtDict(this.wayType, this.formData)
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
