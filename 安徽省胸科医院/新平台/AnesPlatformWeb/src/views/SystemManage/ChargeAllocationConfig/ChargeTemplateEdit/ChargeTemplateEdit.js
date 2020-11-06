import ChargeAllocationConfigApi from '@/api/ChargeAllocationConfigApi.js'
import BasicConfigApi from '@/api/BasicConfigApi.js'

export default {
  name: 'ChargeTemplateEdit',
  data () {
    return {
      loading: false,
      isDisabled: false,
      itemClass: '',
      itemName: '',
      TempleteDta: [],
      EventData: [],
      ItemTypeData: [],
      formData: this.newData(),
      medAnesthesiaList: [],
      medUnitsList: [],
      medUnitsList1: [],
      rules: {
        templeteName: [
          { required: true, message: '请输入名称', trigger: 'blur' }
        ]
      },
      dialogEditVisible: false,
      dialogTempleteVisible: false,
      dialogEditTitle: '新增事件',
      dialogTemplete: '新增模版',
      addTempleteButtonName: '保存模版',
      wayType: 0, // 弹出窗口类型，0-
      templetMenu: [],
      firstMenu: [],
      currentMenu: '',
      currentTemplete: ''
    }
  },
  computed: {
    mainHeight: function () {
      return parseInt(document.documentElement.clientHeight) - 129
    },
    mainWith: function () {
      return parseInt(document.documentElement.clientWidth)
    }
  },
  created () {
    this.TempleteMenu()
    this.UnitsDict()
    this.AnesthesiaDict()
    this.GetItemTypeData()
  },
  methods: {
    newData () {
      return {
        ITEM_NO: '',
        ITEM_CLASS: '',
        ITEM_CODE: '',
        ITEM_NAME: '',
        ITEM_SPEC: '',
        UNITS: '',
        AMOUNT: '',
        TEMPLET: this.currentTemplete,
        TEMPLET_CLASS: '公用',
        ANESTHESIA_METHOD: this.currentMenu
      }
    },
    TempleteMenu () {
      var _this = this
      // this.$ajax
      //   .get('/Api/PlatformChargeInfo/GetTempletBillMenu', {})
      ChargeAllocationConfigApi.GetTempletBillMenu()
        .then(function (respose) {
          _this.templetMenu = respose.data.Data
          // var menus = ''
          _this.firstMenu = []

          for (var i = 0; i < _this.templetMenu.length; i++) {
            var value = _this.templetMenu[i].ANESTHESIA_METHOD.trim()

            var filterValues = []
            filterValues = _this.firstMenu.filter(t => t === value.trim())

            if (filterValues.length === 0) {
              _this.firstMenu.push(value.trim())
            }
          }
          if (_this.firstMenu.length > 0) {
            _this.currentMenu = _this.firstMenu[0]
          }
        })
        .catch(error => {
          console.log(error)
        })
    },
    SwitchMenu: function (menu) {
      this.currentMenu = menu
    },
    ShowTemplete: function (templete) {
      this.currentTemplete = templete
      this.Dict()
    },
    GetEventData (obj) {
      var _this = this
      // this.$ajax
      //   .get('/Api/PlatformChargeInfo/GetValuationItemList', {
      //     params: {
      //       itemClass: obj
      //     }
      //   })
      ChargeAllocationConfigApi.GetValuationItemList({
        itemClass: obj
      })
        .then(function (respose) {
          _this.EventData = respose.data.Data
        })
        .catch(error => {
          console.log(error)
        })
    },
    GetItemTypeData () {
      var _this = this
      // this.$ajax
      //   .get('/Api/PlatformChargeInfo/GetBillDict', {
      //     params: {
      //       type: '0'
      //     }
      //   })
      ChargeAllocationConfigApi.GetBillDict({
        type: '0'
      })
        .then(function (respose) {
          _this.ItemTypeData = respose.data.Data
        })
        .catch(error => {
          console.log(error)
        })
    },
    getItemClassName (val) {
      var _this = this
      var returnVal = val
      if (val !== '' && val !== null && _this.ItemTypeData.length > 0) {
        let tt = _this.ItemTypeData.filter(t => t.BILL_CLASS_CODE === val)
        if (tt.length > 0) {
          returnVal = tt[0].BILL_CLASS_NAME
        }
      }
      return returnVal
    },
    AnesthesiaDict () {
      var _this = this
      // this.$ajax
      //   .get('/Api/PlatformSysConfig/GetAnesthesiaDict', {
      //     params: {
      //       AnesMethodName: ''
      //     }
      //   })
      BasicConfigApi.GetAnesthesiaDict({
        AnesMethodName: ''
      })
        .then(function (respose) {
          _this.medAnesthesiaList = respose.data.Data.CurrentData
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
      //       UnitType: ''
      //     }
      //   })
      BasicConfigApi.GetUnitDict({
        UnitType: ''
      })
        .then(function (respose) {
          _this.medUnitsList = respose.data.Data.CurrentData
          _this.medUnitsList1 = _this.medUnitsList.filter(
            t => t.UNIT_TYPE === '1'
          )
        })
        .catch(error => {
          console.log(error)
        })
    },
    filterUnits (val) {
      var _this = this
      if (val) {
        var length = _this.medUnitsList.length
        var tmpList = []
        for (var i = 0; i < length; i++) {
          if (_this.medUnitsList[i].UNIT_NAME.indexOf(val)) {
            tmpList.push(_this.medUnitsList[i])
          }
        }
        _this.medUnitsList = tmpList
      } else {
        this.UnitsDict()
      }
    },
    Dict () {
      var _this = this
      // this.$ajax
      //   .get('/Api/PlatformChargeInfo/GetAnesBillTemplet', {
      //     params: {
      //       TEMPLET: this.currentTemplete,
      //       ANESTHESIA_METHOD: this.currentMenu
      //     }
      //   })
      ChargeAllocationConfigApi.GetAnesBillTemplet({
        TEMPLET: this.currentTemplete,
        ANESTHESIA_METHOD: this.currentMenu
      })
        .then(function (respose) {
          _this.TempleteDta = respose.data.Data
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
      BasicConfigApi.GetMedEventDict({
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
      this.isDisabled = false
      this.formData = this.newData()
      this.dialogEditVisible = true
      this.wayType = 0
    },
    addTemplete () {
      this.dialogTempleteVisible = true
    },
    editData (index, row) {
      this.isDisabled = false
      this.dialogEditTitle = '编辑'
      this.wayType = 1
      this.GetEventData(row.ITEM_CLASS)
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
          Object.assign(this.formData, row)
          // this.$ajax
          //   .post(
          //     '/Api/PlatformChargeInfo/DeleteAnesBillTemplete?type=0',
          //     this.formData
          //   )
          ChargeAllocationConfigApi.DeleteAnesBillTemplete(0, this.formData)
            .then(function (respose) {
              if (respose.data.Data === 1) {
                _this.Dict()
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
    deleteTemplete () {
      this.$confirm('确认删除模版（' + this.currentTemplete + '）吗?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'info'
      })
        .then(() => {
          var _this = this
          // this.$ajax
          //   .post(
          //     '/Api/PlatformChargeInfo/DeleteAnesBillTemplete?type=1',
          //     _this.TempleteDta[0]
          //   )
          ChargeAllocationConfigApi.DeleteAnesBillTemplete(
            1,
            _this.TempleteDta[0]
          )
            .then(function (respose) {
              _this.TempleteMenu()
              _this.Dict()
              _this.currentTemplete = ''
              _this.currentMenu = ''
              // if (respose.data.Data === 1) {
              //   _this.TempleteMenu()
              //   _this.Dict()
              //   _this.currentTemplete = ''
              // } else if (respose.data.Data === -1) {
              //   var index = -1
              //   for (var i = 0; i < _this.templetMenu.length; i++) {
              //     if (
              //       _this.templetMenu[i].templeteName === _this.currentTemplete
              //     ) {
              //       index = i
              //     }
              //   }
              //   _this.templetMenu.splice(index, 1)
              //   _this.currentTemplete = ''
              // }
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
      var isSubmit = true
      this.isDisabled = true
      if (
        this.formData.ITEM_CLASS.trim() === '' ||
        this.formData.ITEM_NAME.trim() === ''
      ) {
        isSubmit = false
        this.$message('类型和项目名称不能为空！')
      }
      if (isSubmit) {
        this.formData.TEMPLET = this.currentTemplete
        this.formData.ANESTHESIA_METHOD = this.currentMenu
        this.$refs[formName].validate(valid => {
          if (valid) {
            var _this = this
            // this.$ajax
            //   .post(
            //     '/Api/PlatformChargeInfo/EditAnesBillTemplete?type=' +
            //       this.wayType,
            //     this.formData
            //   )
            ChargeAllocationConfigApi.EditAnesBillTemplete(
              this.wayType,
              this.formData
            )
              .then(function (respose) {
                if (respose.data.Data === 0) {
                  _this.$message('保存失败，请稍后再试！')
                } else if (respose.data.Data === 1) {
                  _this.$message('保存成功！')
                  _this.dialogEditVisible = false
                  _this.Dict()
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
    },
    onSubmitTemplete (formName) {
      var _this = this
      var isVail = true
      if (
        this.currentTemplete.trim() === '' ||
        this.currentMenu.trim() === ''
      ) {
        isVail = false
        this.$message('模板分类和模板名称不能为空！')
      }
      // 判断模版是否存在
      var templete = _this.templetMenu.filter(item => {
        return (
          item.TEMPLET_NAME === this.currentTemplete &&
          item.ANESTHESIA_METHOD === this.currentMenu
        )
      })

      if (templete.length > 0) {
        isVail = false
        this.$message('保存失败，该模板名已存在！')
      }

      if (isVail) {
        this.templetMenu.push({
          ANESTHESIA_METHOD: this.currentMenu,
          TEMPLET_NAME: this.currentTemplete
        })
        var menus = ''
        for (var a = 0; a < _this.firstMenu.length; a++) {
          menus += _this.firstMenu[a]
        }

        for (var i = 0; i < _this.templetMenu.length; i++) {
          var value = _this.templetMenu[i].ANESTHESIA_METHOD
          if (menus.indexOf(value) < 0) {
            _this.firstMenu.push(value)
            menus += value + ','
          }
        }
        this.dialogTempleteVisible = false
        this.Dict()
      }
    },
    SelItemClass (obj) {
      var classitem = this.ItemTypeData.filter(item => {
        return item.BILL_CLASS_CODE === obj
      })
      this.formData.ITEM_CLASS = classitem[0].BILL_CLASS_CODE
      this.formData.ITEM_NAME = ''
      this.formData.ITEM_SPEC = ''
      this.formData.UNITS = ''
      this.formData.AMOUNT = ''
      this.GetEventData(classitem[0].BILL_CLASS_CODE)
    },
    SelEventCode (obj) {
      var classitem = this.EventData.filter(item => {
        return item.ITEM_NAME === obj
      })
      if (classitem.length > 0) {
        this.formData.ITEM_CODE = classitem[0].ITEM_CODE
        this.formData.ITEM_SPEC = classitem[0].ITEM_SPEC
        this.formData.UNITS = classitem[0].UNITS
      }
    }
  }
}
