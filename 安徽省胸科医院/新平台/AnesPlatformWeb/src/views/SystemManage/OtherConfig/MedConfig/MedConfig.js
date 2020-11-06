import OtherConfigApi from '@/api/OtherConfigApi.js'

export default {
  name: 'MedConfig',
  data () {
    return {
      DoublePrintDoc1: '',
      DoublePrintDoc2: '',
      DoublePrintDoc3: '',
      DoublePrintDoc4: '',
      DoublePrintDoc5: '',
      DoublePrintDoc6: '',
      MedConfig: {
        IsSync: false, // 是否同步接口
        AnesDocPageHours: 4, // 麻醉单每页显示的小时数
        IsSyncByInpNo: true, // 急诊根据住院号同步
        DoubleSelect: true, // 文书是否双击显示下拉
        IsOpenCoordinationCall: true, // 是否加载视频组件
        DrugAutoStop: false, // 持续用药自动结束
        IsVerificationAudit: false, // 是否手术过程中完成三方核查单
        DrugAutoStopOperationStatus: '出手术室', // 持续用药自动结束时的手术状态
        YouDaoRoomTitle: '', // 诱导室名称
        DrugShow: '', // 用药控件单点用药显示类型
        ProLonged: '', // 用药控件持续用药显示类型
        DrugLegend: '', // 用药图例
        IsModifyVitalSignShowDifferent: false, // 标记修改过的体征项
        IsPACUProcess: false, // 是否启用PACU管理
        IsUpdateScheduleStatus: false, // 是否更新排班程序状态
        IsUpdateHisStatus: false, // 是否更新HIS手术状态
        IsUpdateAnesCharge: false, // 是否回传麻醉收费信息
        AnesthesiaNumber: 1, // 麻醉编号
        PDFLocalUrl: '', // PDF本地生成地址
        PDFServerUrl: '', // PDF上传服务器地址
        IsDeleteAfterCommitDoc: true, // 文书上传后否删除本地文件
        PostPDF_Names: ['麻醉记录单'], // 文书是否上传列表
        IsAutomaticArchiving: true, // 是否支持自动归档
        ArchivOperAfterDay: 7, // 自动归档期限
        DocNameCheckList: [], // 文书完整性检查清单
        PrintPageName: 'A4', // 打印张数
        PrintPaperHeight: 29.7, // 打印纸张长度
        PrintPaperWidth: 21, // 打印纸张宽度
        PaperLeftOff: 0, // 打印纸张  左侧预留
        PaperTopOff: 0, // 打印纸张 上方预留
        DoublePrintDocNames:
          '' /* '麻醉记录单,麻醉同意书;麻醉处方单,术前访视单;' */, // 需要双面打印的文书
        IsOpenPatConfirm: false, // 是否启用患者核对模块
        BloodLiquidShow: '', // 输液输血显示类型
        DeptCodeStr: '', // 手术医生科室
        ShortCuts: [], // 快捷键
        ExamAddress: '', // 检查结果调阅地址
        // DocumentAddress: '', // 病历病程地址
        // AnesShiftDrugList: '', // 麻醉交班用药配置
        AnesShiftEmergencyPatCount: 1 // 急诊患者显示行数配置
      },
      interfaceDetailData: [],
      interfaceDetailDict: [
        { label: '网页', value: 1 },
        { label: 'EXE', value: 2 }
      ],
      DrugAutoStopOperationStatusItems: [
        {
          value: '麻醉结束',
          label: '麻醉结束'
        },
        {
          value: '手术结束',
          label: '手术结束'
        },
        {
          value: '出手术室',
          label: '出手术室'
        }
      ],
      // 输液输血下拉类型
      BloodLiquidShowItems: [
        {
          value: 'Mix',
          label: '混合显示'
        },
        {
          value: 'BloodInThree',
          label: '输血3行'
        },
        {
          value: 'BloodInOne',
          label: '输血仅1行'
        }
      ],
      // 用药值+单位类型（不包括途径）
      TypeDrugValueItems: [
        {
          value: '',
          label: ' '
        },
        {
          value: 'DOSAGE',
          label: '剂量'
        },
        {
          value: 'DOSAGE_UNITS',
          label: '剂量单位'
        },

        {
          value: 'PERFORM_SPEED',
          label: '流速'
        },
        {
          value: 'SPEED_UNIT',
          label: '流速单位'
        },
        {
          value: 'CONCENTRATION',
          label: '浓度'
        },
        {
          value: 'CONCENTRATION_UNIT',
          label: '浓度单位'
        }
      ],
      TypeDrugValueItems1: [
        {
          value: '',
          label: ' '
        },
        {
          value: 'DOSAGE',
          label: '剂量'
        },
        {
          value: 'DOSAGE_UNITS',
          label: '剂量单位'
        },

        {
          value: 'PERFORM_SPEED',
          label: '流速'
        },
        {
          value: 'SPEED_UNIT',
          label: '流速单位'
        },
        {
          value: 'CONCENTRATION',
          label: '浓度'
        },
        {
          value: 'CONCENTRATION_UNIT',
          label: '浓度单位'
        }
      ],
      TypeDrugValueItems2: [
        {
          value: '',
          label: ' '
        },
        {
          value: 'DOSAGE',
          label: '剂量'
        },
        {
          value: 'DOSAGE_UNITS',
          label: '剂量单位'
        },

        {
          value: 'PERFORM_SPEED',
          label: '流速'
        },
        {
          value: 'SPEED_UNIT',
          label: '流速单位'
        },
        {
          value: 'CONCENTRATION',
          label: '浓度'
        },
        {
          value: 'CONCENTRATION_UNIT',
          label: '浓度单位'
        }
      ],
      TypeDrugValueItems3: [
        {
          value: '',
          label: ' '
        },
        {
          value: 'DOSAGE',
          label: '剂量'
        },
        {
          value: 'DOSAGE_UNITS',
          label: '剂量单位'
        },

        {
          value: 'PERFORM_SPEED',
          label: '流速'
        },
        {
          value: 'SPEED_UNIT',
          label: '流速单位'
        },
        {
          value: 'CONCENTRATION',
          label: '浓度'
        },
        {
          value: 'CONCENTRATION_UNIT',
          label: '浓度单位'
        }
      ],
      TypeDrugValueItems4: [
        {
          value: '',
          label: ' '
        },
        {
          value: 'DOSAGE',
          label: '剂量'
        },
        {
          value: 'DOSAGE_UNITS',
          label: '剂量单位'
        },

        {
          value: 'PERFORM_SPEED',
          label: '流速'
        },
        {
          value: 'SPEED_UNIT',
          label: '流速单位'
        },
        {
          value: 'CONCENTRATION',
          label: '浓度'
        },
        {
          value: 'CONCENTRATION_UNIT',
          label: '浓度单位'
        }
      ],
      TypeDrugValueItems5: [
        {
          value: '',
          label: ' '
        },
        {
          value: 'DOSAGE',
          label: '剂量'
        },
        {
          value: 'DOSAGE_UNITS',
          label: '剂量单位'
        },

        {
          value: 'PERFORM_SPEED',
          label: '流速'
        },
        {
          value: 'SPEED_UNIT',
          label: '流速单位'
        },
        {
          value: 'CONCENTRATION',
          label: '浓度'
        },
        {
          value: 'CONCENTRATION_UNIT',
          label: '浓度单位'
        }
      ],
      TypeDrugValueItems6: [
        {
          value: '',
          label: ' '
        },
        {
          value: 'DOSAGE',
          label: '剂量'
        },
        {
          value: 'DOSAGE_UNITS',
          label: '剂量单位'
        },

        {
          value: 'PERFORM_SPEED',
          label: '流速'
        },
        {
          value: 'SPEED_UNIT',
          label: '流速单位'
        },
        {
          value: 'CONCENTRATION',
          label: '浓度'
        },
        {
          value: 'CONCENTRATION_UNIT',
          label: '浓度单位'
        }
      ],
      // 途径
      TypAdministratorItems: [
        {
          value: '',
          label: ' '
        },
        {
          value: 'ADMINISTRATOR',
          label: '用药途径'
        }
      ],

      // 用药分隔符类型
      TypeDrugOuterMarkItems: [
        {
          value: '',
          label: ' '
        },
        {
          value: '(',
          label: '('
        },
        {
          value: ')',
          label: ')'
        },
        {
          value: '[',
          label: '['
        },
        {
          value: ']',
          label: ']'
        },
        {
          value: '{',
          label: '{'
        },
        {
          value: '}',
          label: '}'
        }
      ],

      // 途径专用标识符
      TypeDrugRouteIdentifyItems: [
        {
          value: '',
          label: ''
        },
        {
          value: 'C1',
          label: '途径括号内'
        },
        {
          value: 'C2',
          label: '途径括号外'
        },
        {
          value: 'C3',
          label: '途径换行'
        }
      ],

      // 内部分割符
      TypeDrugInnerMarkItems: [
        {
          value: '',
          label: ' '
        },
        {
          value: '+',
          label: '+'
        }
      ],
      TypeDrugNameItems: [
        // { value: '', label: '' },
        {
          value: 'EVENT_ITEM_NAME',
          label: '药名'
        }
      ],
      // 用药分隔符类型
      TypeDrugNameUnitsItems: [
        {
          value: '',
          label: ' '
        },
        {
          value: 'DOSAGE_UNITS',
          label: '剂量单位'
        },
        {
          value: 'CONCENTRATION_UNIT',
          label: '浓度单位'
        },
        {
          value: 'SPEED_UNIT',
          label: '流速单位'
        },
        {
          value: 'ADMINISTRATOR',
          label: '用药途径'
        }
      ],
      // 用药分隔符类型
      TypeDrugNameUnitsItems1: [
        {
          value: '',
          label: ' '
        },
        {
          value: 'DOSAGE_UNITS',
          label: '剂量单位'
        },
        {
          value: 'CONCENTRATION_UNIT',
          label: '浓度单位'
        },
        {
          value: 'SPEED_UNIT',
          label: '流速单位'
        },
        {
          value: 'ADMINISTRATOR',
          label: '用药途径'
        }
      ],
      // 用药分隔符类型
      TypeDrugNameUnitsItems2: [
        {
          value: '',
          label: ' '
        },
        {
          value: 'DOSAGE_UNITS',
          label: '剂量单位'
        },
        {
          value: 'CONCENTRATION_UNIT',
          label: '浓度单位'
        },
        {
          value: 'SPEED_UNIT',
          label: '流速单位'
        },
        {
          value: 'ADMINISTRATOR',
          label: '用药途径'
        }
      ],
      // 用药分隔符类型
      TypeDrugNameUnitsItems3: [
        {
          value: '',
          label: ' '
        },
        {
          value: 'DOSAGE_UNITS',
          label: '剂量单位'
        },
        {
          value: 'CONCENTRATION_UNIT',
          label: '浓度单位'
        },
        {
          value: 'SPEED_UNIT',
          label: '流速单位'
        },
        {
          value: 'ADMINISTRATOR',
          label: '用药途径'
        }
      ],
      // 用药分隔符类型
      TypeDrugNameUnitsItems4: [
        {
          value: '',
          label: ' '
        },
        {
          value: 'DOSAGE_UNITS',
          label: '剂量单位'
        },
        {
          value: 'CONCENTRATION_UNIT',
          label: '浓度单位'
        },
        {
          value: 'SPEED_UNIT',
          label: '流速单位'
        },
        {
          value: 'ADMINISTRATOR',
          label: '用药途径'
        }
      ],
      // 打印纸张类型
      PrintPageNameItems: [
        {
          value: 'A3',
          label: 'A3'
        },
        {
          value: 'A4',
          label: 'A4'
        },
        {
          value: 'A5',
          label: 'A5'
        },
        {
          value: 'Acustom',
          label: '自定义'
        }
      ],
      allDocs: this.webconfig.DocumentList,
      // 新增6个allDocs用于双面打印的下拉内容
      allDocs1: this.webconfig.DocumentList,
      allDocs2: this.webconfig.DocumentList,
      allDocs3: this.webconfig.DocumentList,
      allDocs4: this.webconfig.DocumentList,
      allDocs5: this.webconfig.DocumentList,
      allDocs6: this.webconfig.DocumentList,
      allDocsNew: this.webconfig.DocumentList,
      // 用于存放选择的文书
      DoublePrintDocs: [],
      // dialogTypeSetVisible: '',
      // 新增两个弹窗，用于“用药显示”、“药名显示”
      dialogTypeSetVisible1: false,
      dialogTypeSetVisible3: false,
      dialogDrugShow: '',
      dialogDrugNameShow: '',

      // dialogTitle: '用药控件单点用药显示类型',

      dialogType: 1,

      items: [],
      DrugShow_show: '',
      ProLonged_show: '',
      DrugLegend_show: ''
    }
  },
  methods: {
    OperStatusChange () {
      var _this = this
      // this.$ajax
      //   .get('/Api/PlatformSysConfig/GetMedConfigSet', {})
      OtherConfigApi.GetMedConfigSet()
        .then(function (respose) {
          _this.MedConfig = respose.data.Data
          _this.SetTypeString(_this.MedConfig.DrugShow, 1)
          _this.SetTypeString(_this.MedConfig.ProLonged, 2)
          _this.SetTypeString(_this.MedConfig.DrugLegend, 3)
          // 新增双面打印文书显示 方法1
          _this.SetDoublePrintDocs(_this.MedConfig.DoublePrintDocNames)
          // 新增双面打印文书显示 方法2
          // _this.SetDoublePrintDocs2(_this.MedConfig.DoublePrintDocNames)
          // 若med_config中没有数据则初始化打印尺寸为A4
          _this.SetPrintDocName(_this.MedConfig.PrintPageName)
        })
        .catch(error => {
          console.log(error)
        })
    },
    // 当med_config没有打印尺寸时，自动显示A4大小
    SetPrintDocName (printPageName) {
      var _this = this
      if (
        printPageName === null ||
        printPageName === '' ||
        printPageName === undefined
      ) {
        this.MedConfig.PrintPageName = _this.PrintPageName
        this.MedConfig.PrintPaperHeight = _this.PrintPaperHeight
        this.MedConfig.PrintPaperWidth = _this.PrintPaperWidth
      }
    },
    SaveConfig () {
      var _this = this
      // this.$ajax
      //   .post('/Api/PlatformSysConfig/ModifyMedConfigSet', this.MedConfig)
      OtherConfigApi.ModifyMedConfigSet(this.MedConfig)
        .then(function (respose) {
          if (respose.data.Data === 1) {
            _this.$message({ message: '保存配置成功！', type: 'success' })
          } else {
            _this.$message.error('保存失败，请稍后再试！')
          }
        })
        .catch(function (error) {
          console.log(error)
        })
    },
    TypeSet (type) {
      var values = ''
      if (type === 1) {
        this.dialogTypeSetVisible1 = true

        this.dialogTitle = '用药控件单点用药显示类型'
        this.dialogType = 1

        values = this.MedConfig.DrugShow
      } else if (type === 2) {
        this.dialogTypeSetVisible1 = true
        this.dialogTitle = '用药控件持续用药显示类型'
        this.dialogType = 2

        values = this.MedConfig.ProLonged
      } else if (type === 3) {
        this.dialogTypeSetVisible3 = true
        this.dialogTitle = '用药图例显示类型'
        this.dialogType = 3
        values = this.MedConfig.DrugLegend
      }

      // 加载图例
      if (values === null) {
        return
      }
      const typeStings = values.split(',')
      // 用药显示
      if (typeStings.length === 11) {
        //   typeStings.forEach(t => {
        //     this.items.push(t)
        //   })
        this.items = []
        // this.items.type2 = this.GetLabel(typeStings[1])
        // for (let index = 0; index < typeStings.length; index++) {
        //   this.items.push(typeStings[index])
        // }

        this.items.type1 = typeStings[0]
        this.items.type2 = typeStings[1]
        this.items.type3 = typeStings[2]
        this.items.type4 = typeStings[3]
        this.items.type5 = typeStings[4]
        this.items.type6 = typeStings[5]
        this.items.type7 = typeStings[6]
        this.items.type8 = typeStings[7]
        this.items.type9 = typeStings[8]
        this.items.type10 = typeStings[9]
        this.items.type11 = typeStings[10]
      }
      // 药名
      if (typeStings.length === 13) {
        this.items.type1 = typeStings[0]
        this.items.type2 = typeStings[1]
        this.items.type3 = typeStings[2]
        this.items.type4 = typeStings[3]
        this.items.type5 = typeStings[4]
        this.items.type6 = typeStings[5]
        this.items.type7 = typeStings[6]
        this.items.type8 = typeStings[7]
        this.items.type9 = typeStings[8]
        this.items.type10 = typeStings[9]
        this.items.type11 = typeStings[10]
        this.items.type12 = typeStings[11]
        this.items.type13 = typeStings[12]
      }
      // 启动时 下拉数组初始化
      this.selectChange('DrugShow')
      this.selectChange('DrugLegend')
      // 以下是属于输入提示的做法

      //   this.items.p1 = this.GetLabel(typeStings[0])
      //   this.items.p2 = this.GetLabel(typeStings[1])
      //   if (typeStings[2] === undefined || typeStings[2] === '') {
      //     this.items.p3 = "选'左括号'"
      //   } else this.items.p3 = this.GetLabel(typeStings[2])
      //   this.items.p4 = this.GetLabel(typeStings[3])
      //   this.items.p5 = this.GetLabel(typeStings[4])
      //   if (typeStings[5] === undefined || typeStings[5] === '') {
      //     this.items.p6 = "选择'+号'"
      //   } else this.items.p6 = this.GetLabel(typeStings[5])
      //   this.items.p7 = this.GetLabel(typeStings[6])
      //   this.items.p8 = this.GetLabel(typeStings[7])
      //   if (typeStings[8] === undefined || typeStings[8] === '') {
      //     this.items.p9 = "'途径位置'"
      //   } else this.items.p9 = this.GetLabel(typeStings[8])
      //   if (typeStings[9] === undefined || typeStings[9] === '') {
      //     this.items.p10 = "选择'途径'"
      //   } else this.items.p10 = this.GetLabel(typeStings[9])
      //   if (typeStings[10] === undefined || typeStings[10] === '') {
      //     this.items.p11 = "选'右括号'"
      //   } else this.items.p11 = this.GetLabel(typeStings[10])
      // }
      // // 药名
      // if (typeStings.length === 13) {
      //   this.items = []
      //   this.items.p1 = this.GetLabel(typeStings[0])
      //   if (typeStings[1] === undefined || typeStings[1] === '') {
      //     this.items.p2 = "选'左括号'"
      //   } else this.items.p2 = this.GetLabel(typeStings[1])
      //   this.items.p3 = this.GetLabel(typeStings[2])
      //   if (typeStings[3] === undefined || typeStings[3] === '') {
      //     this.items.p4 = "选'右括号'"
      //   } else this.items.p4 = this.GetLabel(typeStings[3])
      //   this.items.p5 = this.items.p2
      //   this.items.p6 = this.GetLabel(typeStings[5])
      //   this.items.p7 = this.items.p4
      //   this.items.p8 = this.items.p2
      //   this.items.p9 = this.GetLabel(typeStings[8])
      //   this.items.p10 = this.items.p4
      //   this.items.p11 = this.items.p2
      //   if (typeStings[11] === undefined || typeStings[11] === '') {
      //     this.items.p12 = "选择'途径'"
      //   } else this.items.p12 = this.GetLabel(typeStings[11])
      //   this.items.p13 = this.items.p4
      // }
    },
    // 用药显示类型、药名显示类型清空按钮
    ClearDrug (durgNumber) {
      this.DoublePrintDocs = [] // 虽然没有用但是必须有。。。
      if (durgNumber === 1) {
        this.items.type1 = undefined
        this.items.type2 = undefined
        this.items.type3 = undefined
        this.items.type4 = undefined
        this.items.type5 = undefined
        this.items.type6 = undefined
        this.items.type7 = undefined
        this.items.type8 = undefined
        this.items.type9 = undefined
        this.items.type10 = undefined
        this.items.type11 = undefined

        // 以下是 清空后下拉数组得恢复原样
        this.TypeDrugValueItems1 = this.TypeDrugValueItems
        this.TypeDrugValueItems2 = this.TypeDrugValueItems
        this.TypeDrugValueItems3 = this.TypeDrugValueItems
        this.TypeDrugValueItems4 = this.TypeDrugValueItems
        this.TypeDrugValueItems5 = this.TypeDrugValueItems
        this.TypeDrugValueItems6 = this.TypeDrugValueItems
      } else if (durgNumber === 3) {
        this.items.type1 = undefined
        this.items.type2 = undefined
        this.items.type3 = undefined
        this.items.type4 = undefined
        this.items.type5 = undefined
        this.items.type6 = undefined
        this.items.type7 = undefined
        this.items.type8 = undefined
        this.items.type9 = undefined
        this.items.type10 = undefined
        this.items.type11 = undefined
        this.items.type12 = undefined
        this.items.type13 = undefined

        //  以下是 清空后下拉数组得恢复原样
        this.TypeDrugNameUnitsItems1 = this.TypeDrugNameUnitsItems
        this.TypeDrugNameUnitsItems2 = this.TypeDrugNameUnitsItems
        this.TypeDrugNameUnitsItems3 = this.TypeDrugNameUnitsItems
        this.TypeDrugNameUnitsItems4 = this.TypeDrugNameUnitsItems
      }
    },
    onSubmit () {
      if (this.dialogType === 1) {
        this.MedConfig.DrugShow = this.GetTypeSplitStrings()
      } else if (this.dialogType === 2) {
        this.MedConfig.ProLonged = this.GetTypeSplitStrings()
      } else if (this.dialogType === 3) {
        this.MedConfig.DrugLegend = this.GetTypeSplitStrings()
      }
      this.SetTypeString(this.GetTypeSplitStrings(), this.dialogType)

      this.dialogTypeSetVisible1 = false // 确认后关闭弹窗
      this.dialogTypeSetVisible3 = false
    },
    // 打印纸张的选择
    printPageNameSelect (name) {
      if (name === 'A3') {
        this.MedConfig.PrintPaperHeight = 42
        this.MedConfig.PrintPaperWidth = 29.7
      } else if (name === 'A4') {
        this.MedConfig.PrintPaperHeight = 29.7
        this.MedConfig.PrintPaperWidth = 21
      } else if (name === 'A5') {
        this.MedConfig.PrintPaperHeight = 21
        this.MedConfig.PrintPaperWidth = 14.8
      } else if (name === 'Acustom') {
        // 自定义
        this.MedConfig.PrintPaperHeight = 0
        this.MedConfig.PrintPaperWidth = 0
      }
    },
    // 双面打印下拉选择后方法
    selectDoubleDoc () {
      // 超级加强版
      this.allDocs1 = this.getLeftDocArray3(1)
      this.allDocs2 = this.getLeftDocArray3(2)
      this.allDocs3 = this.getLeftDocArray3(3)
      this.allDocs4 = this.getLeftDocArray3(4)
      this.allDocs5 = this.getLeftDocArray3(5)
      this.allDocs6 = this.getLeftDocArray3(6)
      this.setMedConfigDoubleDocs()
    },
    // 将双面打印文书 格式化成规定格式的字符串
    setMedConfigDoubleDocs () {
      if (
        this.DoublePrintDoc1 !== undefined &&
        this.DoublePrintDoc2 !== undefined &&
        this.DoublePrintDoc3 !== undefined &&
        this.DoublePrintDoc4 !== undefined &&
        this.DoublePrintDoc5 !== undefined &&
        this.DoublePrintDoc6 !== undefined
      ) {
        this.MedConfig.DoublePrintDocNames =
          this.DoublePrintDoc1 +
          ',' +
          this.DoublePrintDoc2 +
          ';' +
          this.DoublePrintDoc3 +
          ',' +
          this.DoublePrintDoc4 +
          ';' +
          this.DoublePrintDoc5 +
          ',' +
          this.DoublePrintDoc6 +
          ';'
      } else if (
        this.DoublePrintDoc1 !== undefined &&
        this.DoublePrintDoc2 !== undefined &&
        this.DoublePrintDoc3 !== undefined &&
        this.DoublePrintDoc4 !== undefined
      ) {
        this.MedConfig.DoublePrintDocNames =
          this.DoublePrintDoc1 +
          ',' +
          this.DoublePrintDoc2 +
          ';' +
          this.DoublePrintDoc3 +
          ',' +
          this.DoublePrintDoc4 +
          ';'
      } else if (
        this.DoublePrintDoc1 !== undefined &&
        this.DoublePrintDoc2 !== undefined &&
        this.DoublePrintDoc5 !== undefined &&
        this.DoublePrintDoc6 !== undefined
      ) {
        this.MedConfig.DoublePrintDocNames =
          this.DoublePrintDoc1 +
          ',' +
          this.DoublePrintDoc2 +
          ';' +
          this.DoublePrintDoc5 +
          ',' +
          this.DoublePrintDoc6 +
          ';'
      } else if (
        this.DoublePrintDoc3 !== undefined &&
        this.DoublePrintDoc4 !== undefined &&
        this.DoublePrintDoc5 !== undefined &&
        this.DoublePrintDoc6 !== undefined
      ) {
        this.MedConfig.DoublePrintDocNames =
          this.DoublePrintDoc3 +
          ',' +
          this.DoublePrintDoc4 +
          ';' +
          this.DoublePrintDoc5 +
          ',' +
          this.DoublePrintDoc6 +
          ';'
      } else if (
        this.DoublePrintDoc1 !== undefined &&
        this.DoublePrintDoc2 !== undefined
      ) {
        this.MedConfig.DoublePrintDocNames =
          this.DoublePrintDoc1 + ',' + this.DoublePrintDoc2 + ';'
      } else if (
        this.DoublePrintDoc3 !== undefined &&
        this.DoublePrintDoc4 !== undefined
      ) {
        this.MedConfig.DoublePrintDocNames =
          this.DoublePrintDoc3 + ',' + this.DoublePrintDoc4 + ';'
      } else if (
        this.DoublePrintDoc5 !== undefined &&
        this.DoublePrintDoc6 !== undefined
      ) {
        this.MedConfig.DoublePrintDocNames =
          this.DoublePrintDoc5 + ',' + this.DoublePrintDoc6 + ';'
      } else if (
        this.DoublePrintDoc1 === undefined &&
        this.DoublePrintDoc2 === undefined &&
        this.DoublePrintDoc3 === undefined &&
        this.DoublePrintDoc4 === undefined &&
        this.DoublePrintDoc5 === undefined &&
        this.DoublePrintDoc6 === undefined
      ) {
        // 都为空 传空
        this.MedConfig.DoublePrintDocNames = ''
      }
    },
    // 初回限定版 双面打印 获取剩余下拉数组功能（只能按顺序选）
    getLeftDocArray (docArray, docItem) {
      let temp = []

      docArray.forEach(t => {
        if (t !== docItem) {
          temp.push(t)
        }
      })
      return temp
    },
    // 加强版 双面打印 获取剩余下拉数组功能（随便选都没有问题，但有依赖性）
    getLeftDocArray2 (groupNumber) {
      var temp = []
      switch (groupNumber) {
        case 1:
          this.allDocs1.forEach(t => {
            if (
              t !== this.DoublePrintDoc2 &&
              t !== this.DoublePrintDoc3 &&
              t !== this.DoublePrintDoc4 &&
              t !== this.DoublePrintDoc5 &&
              t !== this.DoublePrintDoc6
            ) {
              temp.push(t)
            }
          })
          break
        case 2:
          this.allDocs2.forEach(t => {
            if (
              t !== this.DoublePrintDoc1 &&
              t !== this.DoublePrintDoc3 &&
              t !== this.DoublePrintDoc4 &&
              t !== this.DoublePrintDoc5 &&
              t !== this.DoublePrintDoc6
            ) {
              temp.push(t)
            }
          })
          break
        case 3:
          this.allDocs3.forEach(t => {
            if (
              t !== this.DoublePrintDoc1 &&
              t !== this.DoublePrintDoc2 &&
              t !== this.DoublePrintDoc4 &&
              t !== this.DoublePrintDoc5 &&
              t !== this.DoublePrintDoc6
            ) {
              temp.push(t)
            }
          })
          break
        case 4:
          this.allDocs4.forEach(t => {
            if (
              t !== this.DoublePrintDoc1 &&
              t !== this.DoublePrintDoc2 &&
              t !== this.DoublePrintDoc3 &&
              t !== this.DoublePrintDoc5 &&
              t !== this.DoublePrintDoc6
            ) {
              temp.push(t)
            }
          })
          break
        case 5:
          this.allDocs5.forEach(t => {
            if (
              t !== this.DoublePrintDoc1 &&
              t !== this.DoublePrintDoc2 &&
              t !== this.DoublePrintDoc3 &&
              t !== this.DoublePrintDoc4 &&
              t !== this.DoublePrintDoc6
            ) {
              temp.push(t)
            }
          })
          break
        case 6:
          this.allDocs6.forEach(t => {
            if (
              t !== this.DoublePrintDoc1 &&
              t !== this.DoublePrintDoc2 &&
              t !== this.DoublePrintDoc3 &&
              t !== this.DoublePrintDoc4 &&
              t !== this.DoublePrintDoc5
            ) {
              temp.push(t)
            }
          })
          break
        default:
          break
      }

      return temp
    },

    //
    // 超级加强版 双面打印 获取剩余下拉数组功能（随便选都没有问题）
    getLeftDocArray3 (groupNumber) {
      var temp = []
      switch (groupNumber) {
        case 1:
          this.allDocs.forEach(t => {
            if (
              t !== this.DoublePrintDoc2 &&
              t !== this.DoublePrintDoc3 &&
              t !== this.DoublePrintDoc4 &&
              t !== this.DoublePrintDoc5 &&
              t !== this.DoublePrintDoc6
            ) {
              temp.push(t)
            }
          })
          break
        case 2:
          this.allDocs.forEach(t => {
            if (
              t !== this.DoublePrintDoc1 &&
              t !== this.DoublePrintDoc3 &&
              t !== this.DoublePrintDoc4 &&
              t !== this.DoublePrintDoc5 &&
              t !== this.DoublePrintDoc6
            ) {
              temp.push(t)
            }
          })
          break
        case 3:
          this.allDocs.forEach(t => {
            if (
              t !== this.DoublePrintDoc1 &&
              t !== this.DoublePrintDoc2 &&
              t !== this.DoublePrintDoc4 &&
              t !== this.DoublePrintDoc5 &&
              t !== this.DoublePrintDoc6
            ) {
              temp.push(t)
            }
          })
          break
        case 4:
          this.allDocs.forEach(t => {
            if (
              t !== this.DoublePrintDoc1 &&
              t !== this.DoublePrintDoc2 &&
              t !== this.DoublePrintDoc3 &&
              t !== this.DoublePrintDoc5 &&
              t !== this.DoublePrintDoc6
            ) {
              temp.push(t)
            }
          })
          break
        case 5:
          this.allDocs.forEach(t => {
            if (
              t !== this.DoublePrintDoc1 &&
              t !== this.DoublePrintDoc2 &&
              t !== this.DoublePrintDoc3 &&
              t !== this.DoublePrintDoc4 &&
              t !== this.DoublePrintDoc6
            ) {
              temp.push(t)
            }
          })
          break
        case 6:
          this.allDocs.forEach(t => {
            if (
              t !== this.DoublePrintDoc1 &&
              t !== this.DoublePrintDoc2 &&
              t !== this.DoublePrintDoc3 &&
              t !== this.DoublePrintDoc4 &&
              t !== this.DoublePrintDoc5
            ) {
              temp.push(t)
            }
          })
          break
        default:
          break
      }

      return temp
    },

    // 复选下拉控件 实现双面打印文书的选择(DoublePrintDocs最大6个)
    selectDoubleDoc2 (flag) {
      // 下拉收起来的时候触发
      if (flag === false) {
        // alert(this.DoublePrintDocs)
        // 双面打印必定是偶数，因此在文书是6个的前提下必定是3种情况
        if (
          this.DoublePrintDocs.length % 2 === 0 &&
          this.DoublePrintDocs.length !== 0
        ) {
          if (this.DoublePrintDocs.length === 2) {
            this.MedConfig.DoublePrintDocNames =
              this.DoublePrintDocs[0] + ',' + this.DoublePrintDocs[1] + ';'
          } else if (this.DoublePrintDocs.length === 4) {
            this.MedConfig.DoublePrintDocNames =
              this.DoublePrintDocs[0] +
              ',' +
              this.DoublePrintDocs[1] +
              ';' +
              this.DoublePrintDocs[2] +
              ',' +
              this.DoublePrintDocs[3] +
              ';'
          } else {
            this.MedConfig.DoublePrintDocNames =
              this.DoublePrintDocs[0] +
              ',' +
              this.DoublePrintDocs[1] +
              ';' +
              this.DoublePrintDocs[2] +
              ',' +
              this.DoublePrintDocs[3] +
              ';' +
              this.DoublePrintDocs[4] +
              ',' +
              this.DoublePrintDocs[5] +
              ';'
          }
        }
      }
    },
    // 清空双面打印文书操作--备用
    ClearDoubleDocs2 () {
      this.DoublePrintDocs = []
      this.DoublePrintDoc1 = undefined
      this.DoublePrintDoc2 = undefined
      this.DoublePrintDoc3 = undefined
      this.DoublePrintDoc4 = undefined
      this.DoublePrintDoc5 = undefined
      this.DoublePrintDoc6 = undefined
    },
    // 清空双面打印文书操作
    ClearDoubleDocs (groupNumber) {
      this.DoublePrintDocs = [] // 虽然没用但是必须有
      var temp = []
      switch (groupNumber) {
        case 1:
          this.DoublePrintDoc1 = undefined
          this.DoublePrintDoc2 = undefined

          // 清空第一组后，一组下拉数组重新获取数据
          this.allDocs.forEach(t => {
            // 采取this.allDocs，因为这个不会变化
            if (
              t !== this.DoublePrintDoc3 &&
              t !== this.DoublePrintDoc4 &&
              t !== this.DoublePrintDoc5 &&
              t !== this.DoublePrintDoc6
            ) {
              temp.push(t)
            }
          })
          this.allDocs1 = temp
          this.allDocs2 = temp
          // end
          break
        case 2:
          this.DoublePrintDoc3 = undefined
          this.DoublePrintDoc4 = undefined

          // 清空第二组后，二组下拉数组重新获取数据
          this.allDocs.forEach(t => {
            // 采取this.allDocs，因为这个不会变化
            if (
              t !== this.DoublePrintDoc1 &&
              t !== this.DoublePrintDoc2 &&
              t !== this.DoublePrintDoc5 &&
              t !== this.DoublePrintDoc6
            ) {
              temp.push(t)
            }
          })
          this.allDocs3 = temp
          this.allDocs4 = temp
          // end
          break
        case 3:
          this.DoublePrintDoc5 = undefined
          this.DoublePrintDoc6 = undefined

          // 清空第三组后，三组下拉数组重新获取数据
          this.allDocs.forEach(t => {
            // 采取this.allDocs，因为这个不会变化
            if (
              t !== this.DoublePrintDoc1 &&
              t !== this.DoublePrintDoc2 &&
              t !== this.DoublePrintDoc3 &&
              t !== this.DoublePrintDoc4
            ) {
              temp.push(t)
            }
          })
          this.allDocs5 = temp
          this.allDocs6 = temp
          // end
          break
        default:
          break
      }
      // 清空后需要 再次保存双面打印MedConfig的DoublePrintDocNames（清空不需要的文书）
      this.setMedConfigDoubleDocs()
    },

    // 药名、用药显示 选择事件函数
    selectChange (name) {
      // 必须加上这个操作，否则会有BUG，导致下拉选择了没有效果！！！
      this.DoublePrintDocs = []
      if (name === 'DrugShow') {
        // 加强版下拉处理
        this.TypeDrugValueItems1 = this.GetleftArray2(1, name)
        this.TypeDrugValueItems2 = this.GetleftArray2(2, name)
        this.TypeDrugValueItems3 = this.GetleftArray2(3, name)
        this.TypeDrugValueItems4 = this.GetleftArray2(4, name)
        this.TypeDrugValueItems5 = this.GetleftArray2(5, name)
        this.TypeDrugValueItems6 = this.GetleftArray2(6, name)
      } else if (name === 'DrugLegend') {
        // 加强版
        this.TypeDrugNameUnitsItems1 = this.GetleftArray2(1, name)
        this.TypeDrugNameUnitsItems2 = this.GetleftArray2(2, name)
        this.TypeDrugNameUnitsItems3 = this.GetleftArray2(3, name)
        this.TypeDrugNameUnitsItems4 = this.GetleftArray2(4, name)
      }
    },
    // 初回限定版 用药显示、药名显示剩余下拉数组的处理方法（必须从前往后）
    GetleftArray (arrayItem, val) {
      let temp = []
      temp.push({ label: ' ', value: '' })
      arrayItem.forEach(t => {
        if (t.value !== val && t.value !== '' /* && val !== undefined */) {
          temp.push(t)
        }
      })
      return temp
    },

    // 加强版 用药显示、药名显示剩余下拉数组的处理方法(随便选)
    // t.label 用于第一加载时的下拉，t.value用于之后的下拉
    GetleftArray2 (groupNumber, name) {
      var temp = []
      switch (groupNumber) {
        case 1:
          if (name === 'DrugShow') {
            this.TypeDrugValueItems.forEach(t => {
              if (
                t.value !== this.items.type2 &&
                t.value !== this.items.type4 &&
                t.value !== this.items.type5 &&
                t.value !== this.items.type7 &&
                t.value !== this.items.type8 &&
                t.label !== this.items.type2 &&
                t.label !== this.items.type4 &&
                t.label !== this.items.type5 &&
                t.label !== this.items.type7 &&
                t.label !== this.items.type8
              ) {
                temp.push(t)
              }
            })
          } else if (name === 'DrugLegend') {
            this.TypeDrugNameUnitsItems.forEach(t => {
              if (
                t.value !== this.items.type6 &&
                t.value !== this.items.type9 &&
                t.value !== this.items.type12 &&
                t.label !== this.items.type6 &&
                t.label !== this.items.type9 &&
                t.label !== this.items.type12
              ) {
                temp.push(t)
              }
            })
          }
          break
        case 2:
          if (name === 'DrugShow') {
            this.TypeDrugValueItems.forEach(t => {
              if (
                t.value !== this.items.type1 &&
                t.value !== this.items.type4 &&
                t.value !== this.items.type5 &&
                t.value !== this.items.type7 &&
                t.value !== this.items.type8 &&
                t.label !== this.items.type1 &&
                t.label !== this.items.type4 &&
                t.label !== this.items.type5 &&
                t.label !== this.items.type7 &&
                t.label !== this.items.type8
              ) {
                temp.push(t)
              }
            })
          } else if (name === 'DrugLegend') {
            this.TypeDrugNameUnitsItems.forEach(t => {
              if (
                t.value !== this.items.type3 &&
                t.value !== this.items.type9 &&
                t.value !== this.items.type12 &&
                t.label !== this.items.type3 &&
                t.label !== this.items.type9 &&
                t.label !== this.items.type12
              ) {
                temp.push(t)
              }
            })
          }
          break
        case 3:
          if (name === 'DrugShow') {
            this.TypeDrugValueItems.forEach(t => {
              if (
                t.value !== this.items.type1 &&
                t.value !== this.items.type2 &&
                t.value !== this.items.type5 &&
                t.value !== this.items.type7 &&
                t.value !== this.items.type8 &&
                t.label !== this.items.type1 &&
                t.label !== this.items.type2 &&
                t.label !== this.items.type5 &&
                t.label !== this.items.type7 &&
                t.label !== this.items.type8
              ) {
                temp.push(t)
              }
            })
          } else if (name === 'DrugLegend') {
            this.TypeDrugNameUnitsItems.forEach(t => {
              if (
                t.value !== this.items.type3 &&
                t.value !== this.items.type6 &&
                t.value !== this.items.type12 &&
                t.label !== this.items.type3 &&
                t.label !== this.items.type6 &&
                t.label !== this.items.type12
              ) {
                temp.push(t)
              }
            })
          }
          break
        case 4:
          if (name === 'DrugShow') {
            this.TypeDrugValueItems.forEach(t => {
              if (
                t.value !== this.items.type1 &&
                t.value !== this.items.type2 &&
                t.value !== this.items.type4 &&
                t.value !== this.items.type7 &&
                t.value !== this.items.type8 &&
                t.label !== this.items.type1 &&
                t.label !== this.items.type2 &&
                t.label !== this.items.type4 &&
                t.label !== this.items.type7 &&
                t.label !== this.items.type8
              ) {
                temp.push(t)
              }
            })
          } else if (name === 'DrugLegend') {
            this.TypeDrugNameUnitsItems.forEach(t => {
              if (
                t.value !== this.items.type3 &&
                t.value !== this.items.type6 &&
                t.value !== this.items.type9 &&
                t.label !== this.items.type3 &&
                t.label !== this.items.type6 &&
                t.label !== this.items.type9
              ) {
                temp.push(t)
              }
            })
          }
          break
        case 5:
          if (name === 'DrugShow') {
            this.TypeDrugValueItems.forEach(t => {
              if (
                t.value !== this.items.type1 &&
                t.value !== this.items.type2 &&
                t.value !== this.items.type4 &&
                t.value !== this.items.type5 &&
                t.value !== this.items.type8 &&
                t.label !== this.items.type1 &&
                t.label !== this.items.type2 &&
                t.label !== this.items.type4 &&
                t.label !== this.items.type5 &&
                t.label !== this.items.type8
              ) {
                temp.push(t)
              }
            })
          }
          break
        case 6:
          if (name === 'DrugShow') {
            this.TypeDrugValueItems.forEach(t => {
              if (
                t.value !== this.items.type1 &&
                t.value !== this.items.type2 &&
                t.value !== this.items.type4 &&
                t.value !== this.items.type5 &&
                t.value !== this.items.type7 &&
                t.label !== this.items.type1 &&
                t.label !== this.items.type2 &&
                t.label !== this.items.type4 &&
                t.label !== this.items.type5 &&
                t.label !== this.items.type7
              ) {
                temp.push(t)
              }
            })
          }
          break
        default:
          break
      }

      return temp
    },
    GetTypeSplitStrings () {
      if (this.dialogTypeSetVisible1 === true) {
        // const str = this.items.join()
        const str =
          this.GetTypeValue(this.items.type1) +
          ',' +
          this.GetTypeValue(this.items.type2) +
          ',' +
          this.GetTypeValue(this.items.type3) +
          ',' +
          this.GetTypeValue(this.items.type4) +
          ',' +
          this.GetTypeValue(this.items.type5) +
          ',' +
          this.GetTypeValue(this.items.type6) +
          ',' +
          this.GetTypeValue(this.items.type7) +
          ',' +
          this.GetTypeValue(this.items.type8) +
          ',' +
          this.GetTypeValue(this.items.type9) +
          ',' +
          this.GetTypeValue(this.items.type10) +
          ',' +
          this.GetTypeValue(this.items.type11)

        return str
      }
      // 药名的显示，当内部没有值时，不显示括号
      if (this.dialogTypeSetVisible3 === true) {
        const str =
          this.GetTypeValue(this.items.type1) +
          ',' +
          (this.GetTypeValue(this.items.type3) === ''
            ? ',' + this.GetTypeValue(this.items.type3) + ','
            : this.GetTypeValue(this.items.type2) +
              ',' +
              this.GetTypeValue(this.items.type3) +
              ',' +
              this.GetTypeValue(this.items.type4)) +
          ',' +
          (this.GetTypeValue(this.items.type6) === ''
            ? ',' + this.GetTypeValue(this.items.type6) + ','
            : this.GetTypeValue(this.items.type2) +
              ',' +
              this.GetTypeValue(this.items.type6) +
              ',' +
              this.GetTypeValue(this.items.type4)) +
          ',' +
          (this.GetTypeValue(this.items.type9) === ''
            ? ',' + this.GetTypeValue(this.items.type9) + ','
            : this.GetTypeValue(this.items.type2) +
              ',' +
              this.GetTypeValue(this.items.type9) +
              ',' +
              this.GetTypeValue(this.items.type4)) +
          ',' +
          (this.GetTypeValue(this.items.type12) === ''
            ? ',' + this.GetTypeValue(this.items.type12) + ','
            : this.GetTypeValue(this.items.type2) +
              ',' +
              this.GetTypeValue(this.items.type12) +
              ',' +
              this.GetTypeValue(this.items.type4))

        return str
      }
    },
    // 不取未定义值，以及‘请选择’这个字符串
    GetTypeValue (value) {
      if (value === undefined || value === '请选择') {
        return ''
      }
      return value
    },
    // 将placeholder赋值
    GetLabel (value) {
      if (value === 'DOSAGE') {
        return '剂量'
      } else if (value === 'DOSAGE_UNITS') {
        return '剂量单位'
      } else if (value === 'ADMINISTRATOR') {
        return '用药途径'
      } else if (value === 'PERFORM_SPEED') {
        return '流速'
      } else if (value === 'SPEED_UNIT') {
        return '流速单位'
      } else if (value === 'DOSAGE') {
        return '剂量'
      } else if (value === 'CONCENTRATION') {
        return '浓度'
      } else if (value === 'CONCENTRATION_UNIT') {
        return '浓度单位'
      } else if (value === 'EVENT_ITEM_NAME') {
        return '药名'
      } else if (value === 'C1') {
        return '括号内'
      } else if (value === 'C2') {
        return '括号外'
      } else if (value === 'C3') {
        return '途径换行 '
      } else if (value === undefined || value === null || value === '') {
        return '请选择'
      } else return value // 括号之类
    },
    // 用于初始化双面打印显示 方法1
    SetDoublePrintDocs (strings) {
      if (strings !== null) {
        const DoubleDocs = strings.split(';')
        if (DoubleDocs.length === 2) {
          let DoubleDocsPair1 = DoubleDocs[0].split(',')
          this.DoublePrintDoc1 = DoubleDocsPair1[0]
          this.DoublePrintDoc2 = DoubleDocsPair1[1]
        } else if (DoubleDocs.length === 3) {
          let DoubleDocsPair1 = DoubleDocs[0].split(',')
          let DoubleDocsPair2 = DoubleDocs[1].split(',')
          this.DoublePrintDoc1 = DoubleDocsPair1[0]
          this.DoublePrintDoc2 = DoubleDocsPair1[1]
          this.DoublePrintDoc3 = DoubleDocsPair2[0]
          this.DoublePrintDoc4 = DoubleDocsPair2[1]
        } else if (DoubleDocs.length === 4) {
          let DoubleDocsPair1 = DoubleDocs[0].split(',')
          let DoubleDocsPair2 = DoubleDocs[1].split(',')
          let DoubleDocsPair3 = DoubleDocs[2].split(',')
          this.DoublePrintDoc1 = DoubleDocsPair1[0]
          this.DoublePrintDoc2 = DoubleDocsPair1[1]
          this.DoublePrintDoc3 = DoubleDocsPair2[0]
          this.DoublePrintDoc4 = DoubleDocsPair2[1]
          this.DoublePrintDoc5 = DoubleDocsPair3[0]
          this.DoublePrintDoc6 = DoubleDocsPair3[1]
        }
        // 用于第一次进入页面时初始化 对于已经选择过的那些下拉框，所对应的剩余的下拉框数组
        this.selectDoubleDoc()
      }
    },
    // 用于初始化双面打印显示 方法2
    SetDoublePrintDocs2 (strings) {
      if (strings === null) {
        return
      }
      let temp1 = []
      let temp2 = []
      let doubleDocs = strings.split(';')
      doubleDocs.forEach(t => {
        if (t.length > 0) {
          temp1 = t.split(',')
          temp1.forEach(t => {
            if (t.length > 0) {
              temp2.push(t)
            }
          })
        }
      })
      this.DoublePrintDocs = temp2
    },
    SetTypeString (strings, type) {
      if (strings !== null) {
        const typeStings = strings.split(',')
        var total
        if (typeStings.length === 11) {
          let arry = Array.of()
          typeStings.forEach(function (value) {
            if (value === 'DOSAGE') {
              value = ' 剂量 '
            }
            if (value === 'DOSAGE_UNITS') {
              value = ' 剂量单位 '
            }
            if (value === 'ADMINISTRATOR') {
              value = ' 用药途径 '
            }
            if (value === 'PERFORM_SPEED') {
              value = ' 流速 '
            }
            if (value === 'SPEED_UNIT') {
              value = ' 流速单位 '
            }
            if (value === 'DOSAGE') {
              value = ' 剂量 '
            }
            if (value === 'CONCENTRATION') {
              value = ' 浓度 '
            }
            if (value === 'CONCENTRATION_UNIT') {
              value = ' 浓度单位 '
            }
            if (value === 'EVENT_ITEM_NAME') {
              value = ' 药名 '
            }
            if (value === 'C1') {
              // 括号内
              value = typeStings[5]
            }
            if (value === 'C2') {
              // 括号外
              value = typeStings[10]
              typeStings[10] = ''
            }
            if (value === 'C3') {
              // 换行
              value = typeStings[10]
              typeStings[10] = ' 途径换行 '
              // value = ' 途径换行 '
            }

            if (value === undefined) {
              value = ' '
            }
            if (value !== '') {
              arry.push(value)
            }
          })
          total = arry.reduce(function (first, second) {
            return first + second
          }, '')
        }
        if (typeStings.length === 13) {
          let arry = Array.of()
          typeStings.forEach(function (value) {
            if (value === 'DOSAGE_UNITS') {
              value = ' 剂量单位 '
            }
            if (value === 'ADMINISTRATOR') {
              value = ' 用药途径 '
            }

            if (value === 'SPEED_UNIT') {
              value = ' 流速单位 '
            }

            if (value === 'CONCENTRATION_UNIT') {
              value = ' 浓度单位 '
            }
            if (value === 'EVENT_ITEM_NAME') {
              value = ' 药名 '
            }

            if (value !== '') {
              arry.push(value)
            }
          })
          total = arry.reduce(function (first, second) {
            return first + second
          }, '')
        }
        if (type === 1) {
          this.DrugShow_show = total
        } else if (type === 2) {
          this.ProLonged_show = total
        } else if (type === 3) {
          this.DrugLegend_show = total
        }
      }
    },
    addKeyValue () {
      this.MedConfig.ShortCuts.push({
        Key: '',
        Value: ''
      })
    },
    deleteKeyValue (index, row) {
      this.MedConfig.ShortCuts.splice(index, 1)
    },
    addInterfaceKeyValue () {
      this.interfaceDetailData.push({
        Key: '',
        Value: ''
      })
    },
    deleteInterfaceRow (index, row) {
      this.interfaceDetailData.splice(index, 1)
    },
    GetInterfaceDetailData () {
      var _this = this
      // this.$ajax
      //   .get('/Api/PlatformSysConfig/GetInterfaceDetailList')
      OtherConfigApi.GetInterfaceDetailList()
        .then(function (respose) {
          _this.interfaceDetailData = respose.data.Data
        })
        .catch(error => {
          console.log(error)
        })
    },
    SaveInterfaceDetailData () {
      var _this = this

      // _this.$ajax
      //   .post(
      //     '/Api/PlatformSysConfig/SaveInterfaceDetailData',
      //     this.interfaceDetailData
      //   )
      OtherConfigApi.SaveInterfaceDetailData(this.interfaceDetailData)
        .then(function (respose) {
          if (respose.data.Data === 1) {
            _this.$message({
              message: '保存第三方配置成功！',
              type: 'success'
            })
          } else if (respose.data.Data === 2) {
            _this.$message.warning('链接类型不能为空！')
          } else if (respose.data.Data === 3) {
            _this.$message.warning('链接名称不能为空！')
          } else if (respose.data.Data === 4) {
            _this.$message.warning('链接地址不能为空！')
          } else {
            _this.$message.error('保存第三方配置失败，请稍后再试！')
          }
        })
        .catch(function (error) {
          console.log(error)
        })
    }
  },
  created: function () {
    this.OperStatusChange()
  }
}
