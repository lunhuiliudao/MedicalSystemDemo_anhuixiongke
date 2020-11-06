import EventDictConfigApi from '@/api/EventDictConfigApi.js'
import BasicConfigApi from '@/api/BasicConfigApi.js'
import TempleteConfigApi from '@/api/TempleteConfigApi.js'

export default {
  name: 'InLiquidEdit',
  data () {
    return {
      loading: false,
      itemClass: '3',
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
      medAttrList: [],
      rules: {
        EVENT_ITEM_NAME: [
          { required: true, message: '请输入输液名称', trigger: 'blur' }
        ]
      },
      dialogEditVisible: false,
      dialogEditTitle: '新增',
      wayType: 0 // 弹出窗口类型，0-新增，1-修改
    }
  },
  created () {
    this.UnitsDict()
    this.AttrDict()
    this.AdministratorDict()
    this.searchData(1)
  },
  methods: {
    newData () {
      var _this = this
      // this.$ajax.get('/Api/PlatformSysConfig/NewMedEventDict', {
      //   params: {
      //     itemClass: this.itemClass
      //   }
      // })
      EventDictConfigApi.NewMedEventDict({
        itemClass: this.itemClass
      })
        .then(function (respose) {
          _this.formData = {
            EVENT_CLASS_CODE: '3',
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
    AdministratorDict () {
      var _this = this
      // this.$ajax
      //   .get('/Api/PlatformCommon/GetAdministrationDict')
      EventDictConfigApi.GetAdministrationDict()
        .then(function (respose) {
          _this.medAdministratorList = respose.data.Data
        })
        .catch(error => {
          console.log(error)
        })
    },
    AttrDict () {
      var _this = this
      // this.$ajax
      //   .get('/Api/PlatformCommon/GetAnesInputDictByClass', {
      //     params: {
      //       ItemClass: '液体属性'
      //     }
      //   })
      BasicConfigApi.GetAnesInputDictByClass({
        ItemClass: '液体属性'
      })
        .then(function (respose) {
          _this.medAttrList = respose.data.Data
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
                _this.$alert('输液已存在', {
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
