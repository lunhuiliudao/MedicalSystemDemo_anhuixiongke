import TempleteConfigApi from '@/api/TempleteConfigApi.js'
import BasicConfigApi from '@/api/BasicConfigApi.js'
// import OtherConfigApi from '@/api/OtherConfigApi.js'
import CommonApi from '@/api/CommonApi.js'

export default {
  name: 'EventTemplete',
  data () {
    return {
      loading: false,
      itemClass: '',
      itemClassDict: [
        // { code: '1', name: '事件' },
        // { code: '2', name: '麻药' },
        // { code: '3', name: '输液' },
        // { code: '4', name: '输氧' },
        // // { code: '5', name: '手术' },
        // // { code: '6', name: '麻醉' },
        // { code: '7', name: '置管' },
        // { code: '8', name: '拔管' },
        // { code: 'Y', name: '自主呼吸' },
        // { code: '9', name: '辅助呼吸' },
        // { code: 'A', name: '控制呼吸' },
        // { code: 'B', name: '输血' },
        // { code: 'C', name: '用药' },
        // { code: 'D', name: '出液' }
      ],
      options: [
        {
          value: '椎管内麻醉',
          label: '椎管内麻醉'
        },
        {
          value: '插管全麻',
          label: '插管全麻'
        },
        {
          value: '非插管全麻',
          label: '非插管全麻'
        },
        {
          value: '复合麻醉',
          label: '复合麻醉'
        },
        {
          value: '其他麻醉',
          label: '其他麻醉'
        }
      ],
      itemName: '',
      TempleteDta: [],
      EventData: [],
      formData: {
        EVENT_ITEM_CLASS: '',
        EVENT_CLASS_NAME: '',
        EVENT_ITEM_CODE: '',
        EVENT_ITEM_NAME: '',
        SPEED_UNIT: '',
        CONCENTRATION_UNIT: '',
        DOSAGE_UNITS: '',
        ADMINISTRATOR: ''
      },
      medUnitsList: [],
      medUnitsListType1: [],
      medUnitsListType2: [],
      medUnitsListType3: [],
      medAdministratorList: [],
      rules: {
        EVENT_CLASS_NAME: [
          { required: true, message: '请输入分类', trigger: 'blur' }
        ],
        EVENT_ITEM_NAME: [
          { required: true, message: '请输入事件名称', trigger: 'blur' }
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
      currentTemplete: '',
      radioType: '0',
      isPublic: false
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
    // this.Dict();
    this.getEventItemClassDictClass()
    // this.getAnesMethodClass()
    this.TempleteMenu()
    this.UnitsDict()
    this.AdministratorDict()
  },
  methods: {
    selectTypeChanged () {
      this.TempleteMenu()
    },
    TempleteMenu () {
      var _this = this
      var userid = JSON.parse(sessionStorage.user).USER_JOB_ID
      // this.$ajax
      //   .get('/Api/PlatformSysConfig/GetTempletMenu', {
      //     params: {
      //       Create_By: userid
      //     }
      //   })
      TempleteConfigApi.GetTempletMenu({
        Create_By: userid,
        TempletClass: _this.radioType
      })
        .then(function (respose) {
          _this.templetMenu = respose.data.Data
          var menus = ''
          _this.firstMenu = []
          for (var i = 0; i < _this.templetMenu.length; i++) {
            var value = _this.templetMenu[i].ANESTHESIA_METHOD
            if (menus.indexOf(value) < 0) {
              _this.firstMenu.push(value)
              menus += value + ','
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
    newData () {
      var _this = this
      var userid = JSON.parse(sessionStorage.user).USER_JOB_ID
      // this.$ajax
      //   .get('/Api/PlatformSysConfig/GetNewTEMPLETE', {
      //     params: {
      //       TEMPLET_NAME: this.currentTemplete,
      //       CREATE_BY: userid,
      //       ANESTHESIA_METHOD: this.currentMenu
      //     }
      //   })
      TempleteConfigApi.GetNewTEMPLETE({
        TEMPLET_NAME: this.currentTemplete,
        CREATE_BY: userid,
        ANESTHESIA_METHOD: this.currentMenu
      })
        .then(function (respose) {
          // console.log(respose.data)
          _this.formData = respose.data // { EVENT_CLASS_CODE: '2', EVENT_ITEM_CODE: respose.data.Data.EVENT_ITEM_CODE, EVENT_ITEM_NAME: '', EVENT_ITEM_SPEC: '', DOSAGE: '', DOSAGE_UNITS: '', ADMINISTRATOR: '', SORT_NO: 0 }
        })
        .catch(error => {
          console.log(error)
        })
    },
    GetEventData (obj) {
      var _this = this
      // this.$ajax
      //   .get('/Api/PlatformSysConfig/GetMedEventDict', {
      //     params: {
      //       itemClass: obj
      //     }
      //   })
      TempleteConfigApi.GetMedEventDict({
        itemClass: obj
      })
        .then(function (respose) {
          _this.EventData = respose.data.Data
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
        UnitType: '',
        PageSize: 9999999
      })
        .then(function (respose) {
          _this.medUnitsList = respose.data.Data.CurrentData
          _this.medUnitsListType1 = _this.medUnitsList.filter(
            t => t.UNIT_TYPE === 1 || t.UNIT_TYPE === '1'
          )
          _this.medUnitsListType2 = _this.medUnitsList.filter(
            t => t.UNIT_TYPE === 2 || t.UNIT_TYPE === '2'
          )
          _this.medUnitsListType3 = _this.medUnitsList.filter(
            t => t.UNIT_TYPE === 3 || t.UNIT_TYPE === '3'
          )
        })
        .catch(error => {
          console.log(error)
        })
    },
    getEventItemClassDictClass: function () {
      var _this = this
      // this.$ajax
      //   .get('/Api/PlatformSysConfig/GetAnesMethodClass')
      CommonApi.GetEventItemClassDictClass()
        .then(function (response) {
          _this.itemClassDict = response.data.Data
          console.log()
        })
        .catch(error => {
          console.log(error)
        })
    },
    // getAnesMethodClass: function () {
    //   var _this = this
    //   // this.$ajax
    //   //   .get('/Api/PlatformSysConfig/GetAnesMethodClass')
    //   OtherConfigApi.GetAnesMethodClass()
    //     .then(function (response) {
    //       var data = JSON.parse(response.data.Data)
    //       console.log(data)
    //       _this.options = data
    //     })
    //     .catch(error => {
    //       console.log(error)
    //     })
    // },
    AdministratorDict () {
      var _this = this
      // this.$ajax
      //   .get('/Api/PlatformSysConfig/GetAdministrationDict', {
      //     params: {
      //       Administration: '',
      //       PageSize: 200,
      //       CurrentPage: 1
      //     }
      //   })
      BasicConfigApi.GetAdministrationDict({
        Administration: '',
        PageSize: 200,
        CurrentPage: 1
      })
        .then(function (respose) {
          _this.medAdministratorList = respose.data.Data.CurrentData
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
    filterAdministrator (val) {
      var _this = this
      if (val) {
        var length = _this.medAdministratorList.length
        var tmpList = []
        for (var i = 0; i < length; i++) {
          if (_this.medAdministratorList[i].ADMINISTRATION_NAME.indexOf(val)) {
            tmpList.push(_this.medAdministratorList[i])
          }
        }
        _this.medAdministratorList = tmpList
      } else {
        this.AdministratorDict()
      }
    },
    Dict () {
      var _this = this
      var userid = JSON.parse(sessionStorage.user).USER_JOB_ID
      // this.$ajax
      //   .get('/Api/PlatformSysConfig/GetTempletDetailList', {
      //     params: {
      //       TEMPLET_NAME: this.currentTemplete,
      //       CREATE_BY: userid,
      //       ANESTHESIA_METHOD: this.currentMenu
      //     }
      //   })
      TempleteConfigApi.GetTempletDetailList({
        TEMPLET_NAME: this.currentTemplete,
        CREATE_BY: userid,
        ANESTHESIA_METHOD: this.currentMenu,
        TEMPLET_CLASS: this.radioType
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
      Object.assign(this.formData, this.newData())
      this.dialogEditVisible = true
      this.wayType = 0
    },
    addTemplete () {
      this.dialogTempleteVisible = true
    },
    editData (index, row) {
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
          Object.assign(this.formData, row)
          // this.$ajax
          //   .post(
          //     '/Api/PlatformSysConfig/DeleteTempleteEvent?type=0',
          //     this.formData
          //   )
          TempleteConfigApi.DeleteTempleteEvent(0, this.formData)
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
      if (this.TempleteDta.length > 0) {
        if (this.TempleteDta[0].CREATE_BY === '公用') {
          this.$message('公共模版无法删除！')
          return
        }
      }
      this.$confirm('确认删除模版（' + this.currentTemplete + '）吗?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'info'
      })
        .then(() => {
          var _this = this
          // this.$ajax
          //   .post(
          //     '/Api/PlatformSysConfig/DeleteTempleteEvent?type=1',
          //     _this.TempleteDta[0]
          //   )
          TempleteConfigApi.DeleteTempleteEvent(1, _this.TempleteDta[0])
            .then(function (respose) {
              if (respose.data.Data > 0) {
                _this.TempleteMenu()
                _this.Dict()
                _this.currentTemplete = ''
              } else if (respose.data.Data === -1) {
                var index = -1
                for (var i = 0; i < _this.templetMenu.length; i++) {
                  if (
                    _this.templetMenu[i].templeteName === _this.currentTemplete
                  ) {
                    index = i
                  }
                }
                _this.templetMenu.splice(index, 1)
                _this.currentTemplete = ''
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
      if (
        this.currentMenu !== '' &&
        this.currentMenu !== null &&
        this.currentTemplete !== '' &&
        this.currentTemplete !== null
      ) {
        this.formData.TEMPLET_NAME = this.currentTemplete
        if (this.radioType === '0') {
          this.formData.CREATE_BY = '公用'
        } else {
          this.formData.CREATE_BY = JSON.parse(sessionStorage.user).USER_JOB_ID
        }
        this.formData.ANESTHESIA_METHOD = this.currentMenu
        this.formData.TEMPLET_CLASS = this.radioType
        this.$refs[formName].validate(valid => {
          if (valid) {
            var _this = this
            TempleteConfigApi.EditTemplete(this.wayType, this.formData)
              .then(function (respose) {
                if (respose.data.Data === 0) {
                  _this.$message({
                    message: '保存失败，请稍后再试！',
                    type: 'error'
                  })
                } else if (respose.data.Data === 1) {
                  _this.$message({
                    message: '保存成功！',
                    type: 'success'
                  })
                  _this.dialogEditVisible = false
                  _this.Dict()
                  // alert(_this.wayType)
                  // if (_this.wayType === 0) {
                  //     _this.searchData(1)
                  // }
                  // else {
                  //     _this.searchData(_this.paginationInfo.currentPage)
                  // }
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
      } else {
        if (this.currentMenu === '' || this.currentMenu === null) {
          this.$message({
            message: '请选择模板分类',
            type: 'warning'
          })
        }
        if (this.currentTemplete === '' || this.currentTemplete === null) {
          this.$message({
            message: '请输入模版名称',
            type: 'warning'
          })
        }
      }
    },
    onSubmitTemplete (formName) {
      var _this = this
      var isVail = true
      if (this.currentTemplete === '') {
        isVail = false
        this.$message('保存失败，请输入模版名称！')
      }
      // 判断模版是否存在
      var templete = _this.templetMenu.filter(item => {
        return item.TEMPLET_NAME === this.currentTemplete
      })

      if (templete.length > 0) {
        isVail = false
        this.$message('保存失败，该模板名称已存在！')
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
        // console.log(this.templetMenu)
      }
    },
    SelItemClass (obj) {
      if (this.formData !== null) {
        this.formData.EVENT_ITEM_NAME = ''
        this.formData.ADMINISTRATOR = ''
        this.formData.PERFORM_SPEED = ''
        this.formData.CONCENTRATION = ''
        this.formData.CONCENTRATION_UNIT = ''
        this.formData.DOSAGE = ''
        this.formData.DOSAGE_UNITS = ''
        this.formData.START_AFTER_INPUT = ''
        this.formData.DURATIVE = ''
      }

      var classitem = this.itemClassDict.filter(item => {
        return item.EVENT_CLASS_CODE === obj
      })

      this.formData.EVENT_ITEM_CLASS = classitem[0].EVENT_CLASS_CODE
      this.GetEventData(classitem[0].EVENT_CLASS_CODE)
    },

    SelEventCode (obj) {
      var classitem = this.EventData.filter(item => {
        return item.EVENT_ITEM_NAME === obj
      })
      if (classitem.length > 0) {
        this.formData.EVENT_ITEM_CODE = classitem[0].EVENT_ITEM_CODE
        this.formData.EVENT_ITEM_SPEC = classitem[0].EVENT_ITEM_SPEC
        this.formData.ADMINISTRATOR = classitem[0].ADMINISTRATOR
        this.formData.SPEED_UNIT = classitem[0].SPEED_UNIT
        this.formData.CONCENTRATION_UNIT = classitem[0].CONCENTRATION_UNIT
        this.formData.DOSAGE_UNITS = classitem[0].DOSAGE_UNITS
      }
    }
  }
}
