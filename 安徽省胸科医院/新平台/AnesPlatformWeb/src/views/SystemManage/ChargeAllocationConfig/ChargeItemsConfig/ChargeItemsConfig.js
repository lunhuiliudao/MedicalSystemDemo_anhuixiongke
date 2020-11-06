import ChargeAllocationConfigApi from '@/api/ChargeAllocationConfigApi.js'
import BasicConfigApi from '@/api/BasicConfigApi.js'

export default {
  name: 'ChargeItemsConfig',
  data () {
    return {
      itemClass: 'A', //  项目分类（计价单）
      itemCode: '', // 项目代码（计价单）
      itemName: '', //  项目名称（计价单）

      chargeClass: '', // 收费项目类型
      chargeItemCode: '', // 计费细则项目的计价单code
      isPricing: 'T', // 是否启用划价
      isRefShow: 'false', // 是否显示右侧关系表
      isAutoComDisabled: true, // 是否可以使用带输入建议的el-auto控件
      ispinyin: true, // 判断el-auto控件是否选择了下拉
      loading: false,
      isDisabled: false,

      timeoutChargeOptions: [], // 超时收费下拉
      tempTimeoutChargeOptions: [], // 超时收费变动下拉，去除了选中的计价单项目
      allValuatonData: [], // 当前类别所有计价单数据
      billItemClassOptions: [], // 关系表类别下拉
      billDictData: [], // 收费项目分类表所有数据
      billRadioDict: [], // 计价单RadioButton的数据源
      priceData: [], // 价表数据

      priceChargeOptions: [], // 价表的收费项目数据下拉
      unitData: [], // 单位字典数据
      paginationInfo: {
        currentPage: 1,
        pageSize: 15,
        total: 0,
        currentData: []
      },
      vtvsChargeInfo: [], // 对应的关联表数据
      formData: this.newData(), // 计价单记录
      refData: this.newRefData(), // 计价单价表对照表记录
      // 针对计价单新增、编辑窗口规则
      rules: {
        ITEM_NAME: [
          { required: true, message: '请输入术中项目', trigger: 'blur' }
        ],
        ITEM_SPEC: [{ type: 'number', message: '请输入数字' }]
      },
      // 关系表新增窗口规则
      refRules: {
        ITEM_CLASS: [
          { required: true, message: '请选择类别', trigger: 'change' }
        ],
        ITEM_NAME: [
          { required: true, message: '请选择收费项目', trigger: 'change' }
        ],
        SPEC: [{ type: 'number', message: '请输入数字' }]
      },
      // 关系表计费细则窗口规则（初始值，默认为空，由划价开关决定初始内容）
      refDetailRules: {},
      // 计价单
      dialogEditVisible: false,
      dialogEditTitle: '新增',
      // 关系表
      dialogRefVisible: false,
      dialogRefTitle: '新增',
      // 关系表细则
      dialogRefDetailVisible: false,
      dialogRefDetailTitle: '计费细则',

      wayType: 0, // 弹出窗口类型，0-新增，1-修改
      wayRefType: 0 // 关系表弹窗类型，0-新增，1-修改
    }
  },

  created: function () {
    this.getBillRadioDict() // 加载页面时，先获取计价单分类的数据用于填充RadioBUtton
    this.getBillDict() // 加载页面时，先获取收费项目分类表数据
    this.getUnitDict() // 加载页面时，获取按数量收费的单位下拉数据
  },

  methods: {
    // 计价单初始化数据预先注入类别
    newData () {
      return {
        ITEM_CLASS: this.itemClass, // 创建时，自动赋值给类别，避免弹出对话框时创建的是空数据
        ITEM_CODE: '',
        ITEM_NAME: '',
        //  ITEM_NO: null,
        ITEM_SPEC: null, // 单位数量（规格）
        UNITS: ''
      }
    },
    // 计价单与价表对照关系表，初始化数据
    newRefData () {
      return {
        VT_ITEM_CALSS: this.itemClass, // 项目类别(计价单)
        VT_ITEM_CODE: this.itemCode, // 项目编码(计价单)
        VS_NO: '', // 对照序号(计价单)
        ITEM_CLASS: '', // 项目分类(价表)
        ITEM_CODE: '', // 项目代码(价表)
        ITEM_NAME: '', // 项目名称(价表)
        ITEM_SPEC: '', // 项目规格(价表)
        UNITS: '', // 单位
        PRICE: null, // 价格
        BILL_INDICATOR: 'F', // 是否自动划价 T-划价；F-不划价
        METHOD: '', // 计价方式；1-时长；2-数量；3-剂量
        SPEC: null, // 计费规则
        BASE_TIME: null, // 按时长收费时使用(基础时长)，按剂量收费时使用(基础规格)
        BASE_UNIT: null, // 基础单位（按时间收费：h、按剂量收费：选择的数据）
        ITEM_CODE_ADD: '' // 超时加收编码
      }
    },

    // 获取对应收费项目类型
    ItemClassChange (val) {
      this.loading = true
      this.itemClass = val // 所选计价单类别
      this.isRefShow = 'false'
      this.searchData(1)
      this.searchAllData()
    },

    // 获取计价单表数据med_Valuation_item_list
    searchData (index) {
      var _this = this
      this.loading = true
      this.paginationInfo.currentPage = index
      // this.$ajax
      //   .get('/Api/PlatformChargeInfo/GetValuationItemList', {
      //     params: {
      //       ItemClass: this.itemClass, // 参数的大小写无关
      //       ItemName: '', // 调用此方法的地方，都不需要传入Item_Name
      //       PageSize: this.paginationInfo.pageSize,
      //       CurrentPage: this.paginationInfo.currentPage
      //     }
      //   })
      ChargeAllocationConfigApi.GetValuationItemList({
        ItemClass: this.itemClass, // 参数的大小写无关
        ItemName: '', // 调用此方法的地方，都不需要传入Item_Name
        PageSize: this.paginationInfo.pageSize,
        CurrentPage: this.paginationInfo.currentPage
      })
        .then(function (respose) {
          _this.paginationInfo.currentData = respose.data.Data.CurrentData
          _this.paginationInfo.total = respose.data.Data.Total // 总共有多少条记录
          _this.loading = false
        })
        .catch(error => {
          console.log(error)
        })
    },
    // 获取当前类别计价单所有数据
    getValuationItemList () {
      var _this = this
      this.loading = true

      // this.$ajax
      //   .get('/Api/PlatformChargeInfo/GetValuationItemList', {
      //     params: {
      //       ItemClass: '' // 参数的大小写无关
      //     }
      //   })
      ChargeAllocationConfigApi.GetValuationItemList({
        ItemClass: '' // 参数的大小写无关
      })
        .then(function (respose) {
          _this.allValuatonData = respose.data.Data // 和searchData中不一样，没有CurrentData
          _this.sortTimeoverOptions(_this.allValuatonData) // 超时收费下拉框
          _this.loading = false
        })
        .catch(error => {
          console.log(error)
        })
    },
    // 用于排序超时收费下拉框
    sortTimeoverOptions (val) {
      this.timeoutChargeOptions = [] // 每次下拉先制空
      var tempClass = ''
      // 将数据写入超时收费下拉
      val.forEach(element => {
        this.billRadioDict.forEach(billElement => {
          if (element.ITEM_CLASS === billElement.BILL_CLASS_CODE) {
            tempClass = billElement.BILL_CLASS_NAME
            this.timeoutChargeOptions.push({
              label:
                '[' +
                tempClass +
                ']' +
                '[' +
                element.ITEM_CODE +
                ']' +
                element.ITEM_NAME,
              value: element.ITEM_CODE
            })
          }
        })
      })
    },
    // 获取收费项目分类表所有价表相关数据,用于对应价表的的Item_Class 和关系表的 Item_Class
    getBillDict () {
      var _this = this
      this.loading = true

      // this.$ajax
      //   .get('/Api/PlatformChargeInfo/GetBillDict', {
      //     params: {
      //       type: '1' // 1表示查价表对应项
      //     }
      //   })
      ChargeAllocationConfigApi.GetBillDict({
        type: '1' // 1表示查价表对应项
      })
        .then(function (respose) {
          _this.billDictData = respose.data.Data // 和searchData中不一样，没有CurrentData
          _this.loading = false
        })
        .catch(error => {
          console.log(error)
        })
    },
    // 获取计价单分类数据
    getBillRadioDict () {
      var _this = this
      this.loading = true

      // this.$ajax
      //   .get('/Api/PlatformChargeInfo/GetBillDict', {
      //     params: {
      //       type: '0' // 0表示查计价单
      //     }
      //   })
      ChargeAllocationConfigApi.GetBillDict({
        type: '0' // 0表示查计价单
      })
        .then(function (respose) {
          _this.billRadioDict = respose.data.Data
          if (_this.billRadioDict.length > 0) {
            _this.chargeClass = _this.billRadioDict[0].BILL_CLASS_CODE // 取第一个Code值作为加载页面时的默认选择项
          }
          _this.ItemClassChange(_this.chargeClass) // 加载页面时首先选中默认项
          _this.loading = true // 保持加载状态，这样就看不出延迟了（延迟：ItemClassChange方法填充数据需要一定的时间，此时会暂时出现“无数据”）
        })
        .catch(error => {
          console.log(error)
        })
    },
    // 获取单位字典表的下拉数据
    getUnitDict () {
      var _this = this
      this.loading = true

      // this.$ajax
      //   .get('/Api/PlatformSysConfig/GetUnitDict', {
      //     params: {
      //       UnitType: '' // 传入空的时候，搜索所有单位
      //     }
      //   })
      BasicConfigApi.GetUnitDict({
        UnitType: '', // 传入空的时候，搜索所有单位
        PageSize: 99999
      })
        .then(function (respose) {
          _this.unitData = respose.data.Data.CurrentData

          _this.loading = false
        })
        .catch(error => {
          console.log(error)
        })
    },
    searchAllData () {
      this.getValuationItemList() // 获取当前类别计价单所有数据
    },
    // 获取当前计价单类别的关系表的所有数据
    // 注：params的参数必须和WebApi里的参数字母一样（大小写可以不一致）
    searchRefData (vtItemCode) {
      this.isRefShow = 'true' // 显示关系表数据
      var _this = this
      this.loading = true
      // this.$ajax
      //   .get('/Api/PlatformChargeInfo/GetAnesVsCharge', {
      //     params: {
      //       VtItemCode: vtItemCode // 所选的计价单的ITEM_CODE
      //     }
      //   })
      ChargeAllocationConfigApi.GetAnesVsCharge({
        VtItemCode: vtItemCode // 所选的计价单的ITEM_CODE
      })
        .then(function (respose) {
          _this.vtvsChargeInfo = respose.data.Data
          // 右侧展示关系表数据时，自动切换关系表的ITEM_CLASS的值为对应的中文值（MED_BILL_ITEM_CLASS_DICT表中字段转换）
          _this.vtvsChargeInfo.forEach(row => {
            _this.billDictData.forEach(element => {
              if (element.BILL_CLASS_CODE === row.ITEM_CLASS) {
                row.ITEM_CLASS_NAME = element.BILL_CLASS_NAME // 此处编造了一个Api中没有的字段ITEM_CLASS_NAME，用于显示中文的类别
              }
            })
            row.SPEC =
              row.SPEC === null ? null : Number(row.SPEC * 100).toFixed(0) // 关系表存的是真实数据，展现要是百分比,保留0位小数
          })
          _this.loading = false
        })
        .catch(error => {
          console.log(error)
        })
    },

    // 翻页按钮
    handleCurrentChange (val) {
      this.searchData(val)
    },
    // 新增按钮
    addData () {
      if (this.$refs['formView'] !== undefined) {
        this.$refs['formView'].resetFields()
      }
      Object.assign(this.formData, this.newData())
      this.dialogEditTitle = '新增计价单项目'
      this.dialogEditVisible = true
      this.wayType = 0
      // 注：在dialog弹出时赋值，因为此时生成了一个新的newData。。。
      // 注：或者在new 出的newData对象里面直接赋值
      // this.formData.ITEM_CLASS = this.itemClass // 自动赋值给类别
    },
    // 新增关系表数据
    addRefData () {
      // 目前做成一一对应，以后可能会有变化
      if (this.vtvsChargeInfo.length >= 1) {
        this.$message({
          message: '关联配置只能填写一条数据！',
          type: 'warning',
          duration: 4000 // 持续时间
        })
        return
      }
      this.isDisabled = false
      Object.assign(this.refData, this.newRefData())
      this.dialogRefTitle = '新增' + '‘' + this.itemName + '’' + '关联项目'
      this.dialogRefVisible = true
      this.priceData = null // 每次弹出新增窗口，新增关系表数据时，希望未选择类别的时候，收费项目下拉先没有数据
      this.wayRefType = 0
    },
    // 获取对应价表项目类型的收费项目
    // 获取对应Class的价表数据
    priceClassChange (val) {
      //  this.priceChargeOptions = [] // 每次下拉都置空
      //  this.refData.ITEM_NAME = ''
      var _this = this
      // this.$ajax
      //   .get('/Api/PlatformChargeInfo/GetPriceList', {
      //     params: {
      //       ItemClass: val
      //     }
      //   })
      ChargeAllocationConfigApi.GetPriceList({
        ItemClass: val
      })
        .then(function (respose) {
          _this.priceData = respose.data.Data
          _this.isAutoComDisabled = false // 当选择类别后，收费项目可以使用
          _this.ispinyin = true // 每次选类别，都不可以直接保存（防止拼音直接保存）
          _this.refData.ITEM_NAME = '' // 每次选择类别，先清空上一次的收费项目中的内容
        })
        .catch(error => {
          console.log(error)
        })
    },
    // 选择收费项目
    priceChargeChange (val) {
      this.priceData.forEach(element => {
        if (element.ITEM_CODE === val) {
          this.refData.ITEM_CLASS = element.ITEM_CLASS // 项目分类(价表)
          this.refData.ITEM_CODE = element.ITEM_CODE // 项目代码(价表)
          this.refData.ITEM_NAME = element.ITEM_NAME // 项目名称(价表)
          this.refData.ITEM_SPEC = element.ITEM_SPEC // 项目规格(价表)
          this.refData.UNITS = element.UNITS // 单位
          this.refData.PRICE = element.PRICE // 价格
          // this.refData.BILL_INDICATOR = this.isPricing // 是否自动划价 T-划价；F-不划价(默认)
        }
      })
    },
    // 是否启用划价按钮切换
    switchChange (val) {
      // 如果关闭，则没有规则；如果打开，则产生规则
      if (val === 'F') {
        this.refDetailRules = {}
      } else {
        this.refDetailRules = {
          METHOD: [
            { required: true, message: '请选择计费方式', trigger: 'change' }
          ],
          SPEC: [
            { required: true, message: '请输入计费规则', trigger: 'blur' },
            { type: 'number', message: '请输入数字' }
          ],
          BASE_TIME: [
            { required: true, message: '请填写基础时长', trigger: 'blur' },
            { type: 'number', message: '请输入数字' }
          ]
        }
      }
    },
    // 计费细则里，按时间、按数量、按剂量切换时需要改变验证规则
    rulesChange (val) {
      switch (val) {
        case '1': // 按时间
        case '3': // 按剂量
          this.refDetailRules = {
            METHOD: [
              { required: true, message: '请选择计费方式', trigger: 'change' }
            ],
            SPEC: [
              { required: true, message: '请输入计费规则', trigger: 'blur' },
              { type: 'number', message: '请输入数字' }
            ],
            BASE_TIME: [
              { required: true, message: '请填写基础时长', trigger: 'blur' },
              { type: 'number', message: '请输入数字' }
            ]
          }
          break
        case '2': // 按数量
          this.refDetailRules = {
            METHOD: [
              { required: true, message: '请选择计费方式', trigger: 'change' }
            ],
            SPEC: [
              { required: true, message: '请输入计费规则', trigger: 'blur' },
              { type: 'number', message: '请输入数字' }
            ]
          }
          break
      }
    },

    // 格式化关系表的折扣字段（加上％号）,Number类型的toFixed方法的参数表示取多少位小数
    // discountFormatter (row) {
    //   return row.SPEC === null ? '' : Number(row.SPEC).toFixed(1) + '%'
    // },
    // 计价单编辑按钮
    editData (index, row) {
      if (this.$refs['formView'] !== undefined) {
        this.$refs['formView'].resetFields()
      }
      this.dialogEditTitle = '编辑计价单项目'
      this.wayType = 1
      Object.assign(this.formData, row)
      this.formData.ITEM_SPEC = Number(row.ITEM_SPEC) // 由于Api中ITEM_SPEC字段是string类型，并且计价单在编辑界面有规则限制（数字），所以转换成数字类型，用以匹配规则
      this.dialogEditVisible = true
    },
    // 计费细则按钮
    editBillRule (index, row) {
      // 从选中的行（关系表数据）中取Code和Name做标题
      this.dialogRefDetailTitle =
        '[' + row.ITEM_CODE + ']' + '‘' + row.ITEM_NAME + '’' + '计费细则'
      this.wayRefType = 1 // 相当于编辑

      Object.assign(this.refData, row)
      // this.refData.BILL_INDICATOR = 'T' // 点了计费规则后，isPrcing默认为T（即关系表的BILL_INDICATOR字段为T）
      this.dialogRefDetailVisible = true
    },
    // el-auto边上的编辑按钮，用于修改当前收费项目
    editAutoComplete (event) {
      this.isAutoComDisabled = false // el-auto可用
      this.ispinyin = true

      this.$refs.elAutocom.focus() // 获取el-auto控件的焦点，但是只有第二次才有用。。。
      this.refData.ITEM_NAME = null // 清空收费项目
      // event.target.onclick()
      // this.$refs.elbutton._events.click.push(this.$refs.elbutton._events.click[0])
    },

    // 删除按钮
    deleteData (index, row, flag) {
      this.$confirm('确认删除该数据吗?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'info'
      })
        .then(() => {
          var _this = this
          switch (flag) {
            case 'anesVsCharge': // 关系表数据删除
              var AnesVsCharge = []
              AnesVsCharge.push(row)
              // this.$ajax
              //   .post(
              //     '/Api/PlatformChargeInfo/DeletedAnesVsCharge',
              //     AnesVsCharge
              //   )
              ChargeAllocationConfigApi.DeletedAnesVsCharge(AnesVsCharge)
                .then(function (respose) {
                  if (respose.data.Data > 0) {
                    _this.searchRefData(_this.itemCode)
                  }
                })
                .catch(error => {
                  console.log(error)
                })
              break
            case 'valuationItemList': // 计价单数据删除
              // 新增判断删除计价单项目是否存在被关系表，收费细则超时加收引用
              // this.$ajax
              //   .get('/Api/PlatformChargeInfo/GetTimeoutAnesVsCharge', {
              //     params: {
              //       VtItemCode: row.ITEM_CODE // 所选的计价单的ITEM_CODE
              //     }
              //   })
              ChargeAllocationConfigApi.GetTimeoutAnesVsCharge({
                VtItemCode: row.ITEM_CODE // 所选的计价单的ITEM_CODE
              })
                .then(function (respose) {
                  if (respose.data.Data.length >= 1) {
                    _this
                      .$confirm(
                        '该条项目存在超时加收关联项目，确认删除吗?',
                        '提示',
                        {
                          confirmButtonText: '确定',
                          cancelButtonText: '取消',
                          type: 'warning'
                        }
                      )
                      .then(() => {
                        _this.DeletedMedValuationItemList(_this, row) // 删除计价单数据
                      })
                  } else {
                    _this.DeletedMedValuationItemList(_this, row) // 删除计价单数据
                  }
                })
                .catch(error => {
                  console.log(error)
                })
              break
          }
        })
        .catch(error => {
          console.log(error)
        })
    },
    // 删除计价单数据
    DeletedMedValuationItemList (_this, row) {
      var MedValuationItemList = []
      MedValuationItemList.push(row)
      // _this.$ajax
      //   .post(
      //     '/Api/PlatformChargeInfo/DeletedMedValuationItemList',
      //     MedValuationItemList
      //   )
      ChargeAllocationConfigApi.DeletedMedValuationItemList(
        MedValuationItemList
      )
        .then(function (respose) {
          if (respose.data.Data > 0) {
            _this.searchData(_this.paginationInfo.currentPage)
            _this.searchAllData() // 测试
            _this.isRefShow = 'false' // 删除了计价单项目后，其对应的关系表数据也会删除，因此不用显示了
          }
        })
        .catch(error => {
          console.log(error)
        })
    },
    // 关联配置按钮
    configuration (index, row) {
      // this.isRefShow = 'true' // 显示关系表数据
      this.itemName = row.ITEM_NAME
      this.itemCode = row.ITEM_CODE
      this.isPricing = 'F' // 按了关系配置按钮，默认isPricing为F（即关系表的BILL_INDICATOR字段为F）
      this.searchRefData(row.ITEM_CODE) // 获取对应ITEM_CODE的关系表的数据
      // 将超时收费下拉付给变动下拉，用于去除所选的计价单项目，防止死循环
      this.tempTimeoutChargeOptions = this.timeoutChargeOptions
      for (
        let index = 0;
        index < this.tempTimeoutChargeOptions.length;
        index++
      ) {
        if (this.tempTimeoutChargeOptions[index].value === row.ITEM_CODE) {
          this.tempTimeoutChargeOptions.splice(index, 1) // 必须为1，删除1项
          break
        }
      }
    },

    // 保存按钮
    onSubmit (formName) {
      this.isDisabled = true
      switch (formName) {
        // 计价单保存按钮
        case 'formView':
          this.$refs[formName].validate(valid => {
            if (valid) {
              var _this = this
              // this.$ajax.post(
              //   '/Api/PlatformChargeInfo/EditMedValuationItemList?type=' +
              //     this.wayType,
              //   this.formData
              // )
              ChargeAllocationConfigApi.EditMedValuationItemList(
                this.wayType,
                this.formData
              )
                .then(function (respose) {
                  if (respose.data.Data === 2) {
                    _this.$alert('编码已存在', {
                      confirmButtonText: '确定',
                      type: 'error'
                    })
                  } else if (respose.data.Data === 1) {
                    _this.dialogEditVisible = false
                    if (_this.wayType === 0) {
                      _this.searchData(1)
                      _this.searchAllData() // 测试
                    } else {
                      _this.searchData(_this.paginationInfo.currentPage)
                      _this.searchAllData() // 测试
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
          break
        // 关系表 新增的保存按钮(wayRefType=0)、计费细则按钮（wayRefType=1）
        case 'refView':
        case 'refDetailView':
          if (this.refData.METHOD === '1') {
            this.refData.BASE_UNIT = 'h'
          }

          this.$refs[formName].validate(valid => {
            // 防止打了拼音直接保存
            if (this.ispinyin === true) {
              this.$message({
                message: '请在收费项目下拉中选择“收费项目”！',
                type: 'warning',
                duration: 4000 // 持续时间
              })
              return
            }

            if (valid) {
              var _this = this

              // this.$ajax
              //   .post(
              //     '/Api/PlatformChargeInfo/EditAnesVsCharge?type=' +
              //       this.wayRefType,
              //     this.refData
              //   )
              ChargeAllocationConfigApi.EditAnesVsCharge(
                this.wayRefType,
                this.refData
              )
                .then(function (respose) {
                  if (respose.data.Data === 2) {
                    _this.$alert('项目编码已存在', {
                      confirmButtonText: '确定',
                      type: 'error'
                    })
                  } else if (respose.data.Data === 1) {
                    _this.dialogRefVisible = false
                    _this.dialogRefDetailVisible = false
                    _this.searchRefData(_this.itemCode)
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
          break
      }
    },
    // 批量保存关系表数据，用于修改折扣
    saveRefData () {
      this.$confirm('确认修改折扣数据吗?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'info'
      }).then(() => {
        var _this = this
        // 正则表达式验证输入的折扣是否是整数
        // 正则表达式$后面多空格了也会识别不了的！
        // var reg = new RegExp('^[0-9]+(.[0-9]{1})?$')//（可带1位小数的）整数
        var reg = new RegExp('^[0-9]*$')
        for (let index = 0; index < _this.vtvsChargeInfo.length; index++) {
          if (!reg.test(_this.vtvsChargeInfo[index].SPEC)) {
            this.$message({
              message: '折扣不是数字，请重新填写！',
              type: 'warning',
              duration: 5000 // 持续时间
            })
            return
          }
        }

        // this.$ajax
        //   .post('/Api/PlatformChargeInfo/EditAnesVsCharge', this.vtvsChargeInfo)
        ChargeAllocationConfigApi.EditAnesVsChargeAll(this.vtvsChargeInfo)
          .then(function (respose) {
            if (respose.data.Data > 0) {
              _this.searchRefData(_this.itemCode)
            }
          })
          .catch(error => {
            console.log(error)
          })
      })
    },
    // 移植了小菜的拼音检索
    querySearch (queryString, cb) {
      var results = queryString
        ? this.priceData.filter(this.createFilter(queryString))
        : this.priceData
      cb(results) // 把结果返回到el-autocomplete 组件中
    },
    createFilter (queryString) {
      return priceItem => {
        return (
          priceItem.INPUT_CODE.toLowerCase().indexOf(
            queryString.toLowerCase()
          ) === 0
        )
      }
    },
    // 选择收费项目
    handleSelect (val) {
      this.refData.ITEM_CLASS = val.ITEM_CLASS // 项目分类(价表)
      this.refData.ITEM_CODE = val.ITEM_CODE // 项目代码(价表)
      this.refData.ITEM_NAME = val.ITEM_NAME // 项目名称(价表)
      this.refData.ITEM_SPEC = val.ITEM_SPEC // 项目规格(价表)
      this.refData.UNITS = val.UNITS // 单位
      this.refData.PRICE = val.PRICE // 价格
      this.isAutoComDisabled = true // 当收费项目下拉选中后，收费项目控件禁止使用
      this.ispinyin = false // 选中下拉项后，可以保存了
    }
  }
}
