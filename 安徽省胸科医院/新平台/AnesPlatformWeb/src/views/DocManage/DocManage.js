import DocManageApi from '@/api/DocManageApi.js'
import NursingDoc from './NursingDoc/NursingDoc.vue'
import NursingVisitDoc from './NursingVisitDoc/NursingVisitDoc.vue'
import NursingSafeDoc from './NursingSafeDoc/NursingSafeDoc.vue'
import PressureEstimateDoc from './PressureEstimateDoc/PressureEstimateDoc.vue'

export default {
  name: 'DocManage',
  data: function () {
    return {
      InpNo: '',
      AnesDoctor: '',
      OperRoomNo: '',
      OperRoomNoListAll: [],
      OperRoomNoList: [], // 手术间字典
      OperDate: this.$$moment().format('YYYY-MM-DD'),
      Status: '全部',
      StatusList: ['全部', '术前', '术中', '术后'],
      SelfOperation: false,
      EmergencyInd: -1,
      EmergencyIndList: [{ label: '全部', value: -1 }, { label: '急诊', value: 1 }, { label: '择期', value: 0 }],
      CurrentDate: true,
      TableData: [],
      PageSize: 10,
      CurrentPage: 1,
      TotalCount: 0,
      SelectPatient: [],
      DocumentList: [
        { name: '手术访视记录单', component: NursingVisitDoc, StatusType: '1' },
        { name: '手术安全核查单', component: NursingSafeDoc, StatusType: '1' },
        { name: '护理记录单', component: NursingDoc, StatusType: '1' },
        { name: '压疮评估单', component: PressureEstimateDoc, StatusType: '1' }
      ],
      SelectDoc: '',
      MedicalBasicDoc: this.newMedicalBasicDoc()
    }
  },
  created: function () {
    this.GetOperRoomList()
    if (this.SelfOperation) {
      this.AnesDoctor = JSON.parse(sessionStorage.user).USER_JOB_ID
    } else {
      this.AnesDoctor = ''
    }
  },
  watch: {

  },
  computed: {
    mainWidth: function () {
      return parseInt(document.documentElement.clientWidth)
    },
    mainHeight: function () {
      return parseInt(document.documentElement.clientHeight) - 100
    }
  },
  methods: {
    FilterOperRoom (query) {
      if (query !== '') {
        var _this = this
        DocManageApi.GetOperatingRoomListNoPage({
          OperatingRoomNo: query
        }).then(function (respose) {
          _this.OperRoonNoList = respose.data.Data.filter(d => d.BED_TYPE === '0')
        }).catch(error => {
          console.log(error)
        })
      } else {
        this.GetOperRoomList()
      }
    },
    GetOperRoomList () {
      var _this = this
      DocManageApi.GetOperatingRoomListAll().then(respose => {
        _this.OperRoomNoListAll = []
        _this.OperRoomNoListAll = respose.data.Data.filter(d => d.BED_TYPE === '0')
        _this.OperRoomNoList = _this.OperRoomNoListAll
      }).catch(error => {
        console.log(error)
      })
    },
    SelectOperRoomNoChanged () {
      this.Search()
    },
    ClearOperRoomNo () {
      this.GetOperRoomList()
    },
    StatusChanged () {
      this.Search()
    },
    SelfOperationChanged () {
      if (this.SelfOperation) {
        this.AnesDoctor = JSON.parse(sessionStorage.user).USER_JOB_ID
      } else {
        this.AnesDoctor = ''
      }
      this.Search()
    },
    Search () {
      var _this = this
      if (!this.DataVail()) {
        this.$message('请输入查询条件！')
      } else {
        if (this.OperDate === this.$$moment().format('YYYY-MM-DD')) {
          this.CurrentDate = true
        } else {
          this.CurrentDate = false
        }

        this.loading = true
        DocManageApi.GetPatientInfoList({
          PatName: _this.InpNo,
          InpNo: _this.InpNo,
          AnesDoctor: _this.AnesDoctor,
          OperRoomNo: _this.OperRoomNo,
          StartDate: _this.OperDate,
          EndDate: _this.OperDate,
          Status: _this.Status,
          CurrentPage: _this.CurrentPage,
          PageSize: _this.PageSize,
          EMERGENCY_IND: _this.EmergencyInd,
          OperDept: ''
        }).then(respose => {
          _this.TableData = respose.data.Data
          _this.TotalCount = respose.data.TotalCount
          _this.loading = false
        }).catch(error => {
          this.loading = false
          console.log(error)
        })
      }
    },
    DataVail () {
      if (this.InpNo === '' && this.AnesDoctor === '' && (this.OperRoomNo === '' || this.OperRoomNo === null) && (this.OperDate === '' || this.OperDate === null || typeof (this.OperDate) === 'undefined')) {
        return false
      } else {
        return true
      }
    },
    PaginationSizeChange () {
      this.Search()
    },
    PaginationCurrentChange () {
      this.Search()
    },
    SwitchMenu (item) {
      this.SelectDoc = ''
      this.MedicalBasicDoc = this.newMedicalBasicDoc()
      if (this.SelectPatient === item) {
        this.SelectPatient = []
      } else {
        this.SelectPatient = item
      }
    },
    // 显示文书
    ShowDocument (item) {
      if (this.SelectDoc !== '' && this.SelectDoc.name !== item.name && typeof (this.$refs.docCom) !== 'undefined' && this.$refs.docCom.IsModify === true) {
        this.$confirm('您需要保存该页面吗？', '提示', { confrimButtonText: '确定', cancelButtonText: '取消', type: 'Warning' })
          .then(() => {
            if (this.SelectDoc !== '') {
              this.$refs.docCom.SaveDataReally().then(() => this.GetPatientOperInfo(item))
            }
          })
          .catch(() => {
            this.GetPatientOperInfo(item)
          })
      } else {
        this.GetPatientOperInfo(item)
      }
    },
    // 获取患者信息
    GetPatientOperInfo (item) {
      var _this = this
      _this.MedicalBasicDoc = _this.newMedicalBasicDoc()
      _this.SelectDoc = item
      DocManageApi.QueryMedicalBasicDoc({
        PATIENTID: _this.SelectPatient.PATIENT_ID,
        VISITID: _this.SelectPatient.VISIT_ID,
        OPERID: _this.SelectPatient.OPER_ID,
        StatusType: _this.SelectDoc.StatusType,
        DocName: this.SelectDoc.name
      }).then(respose => {
        _this.MedicalBasicDoc = respose.data.Data
        _this.MedicalBasicDoc.StatusType = _this.SelectDoc.StatusType
        _this.MedicalBasicDoc.DocName = _this.SelectDoc.name
      }).catch(error => console.log(error))
    },
    // 返回空对象
    newMedicalBasicDoc: function () {
      return {}
    },
    // 切换文书
    SelectMedicalBasicDoc () {
      DocManageApi.QueryMedicalBasicDoc({
        PATIENTID: this.SelectPatient.PATIENT_ID,
        VISITID: this.SelectPatient.VISIT_ID,
        OPERID: this.SelectPatient.OPER_ID,
        StatusType: this.SelectDoc.StatusType,
        DocName: this.SelectDoc.name
      })
        .then(respose => {
          this.MedicalBasicDoc = respose.data.Data
          this.MedicalBasicDoc.StatusType = this.SelectDoc.StatusType
          this.MedicalBasicDoc.DocName = this.SelectDoc.name
        })
        .catch(error => {
          console.log(error)
        })
    }
  },
  beforeRouteLeave (to, from, next) {
    this.$confirm('确定要离开？', '提示', { confrimButtonText: '确定', cancelButtonText: '取消', type: 'warning' }).then(() => {
      next()
    })
  }
}
