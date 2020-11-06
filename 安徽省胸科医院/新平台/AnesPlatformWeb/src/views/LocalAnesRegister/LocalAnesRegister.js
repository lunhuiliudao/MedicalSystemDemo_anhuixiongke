import LoacalAnesEdit from './components/LoacalAnesEdit/LoacalAnesEdit.vue'
import LocalAnesRegisterApi from '@/api/LocalAnesRegisterApi.js'
// import AnesDatePicker from '@/components/anes-date-picker'

export default {
  name: 'LocalAnesRegister',
  data () {
    return {
      userInfo: this.$store.getters.user,
      paginationInfo: {
        currentPage: 1,
        pageSize: 20,
        total: 0,
        currentData: []
      },
      StartDate: this.$$moment().startOf('day'), // 取得今天0点
      EndDate: this.$$moment().endOf('day'), // 取得今天 23:59:59
      InpNo: '',
      AnesDoctor: '',
      key: this.$route + +new Date(),
      dialogVisible: false,
      dialogSelPatVisible: false,
      wayType: 0, // 弹出窗口类型，0-新增，1-修改
      patientInfo: {
        PATIENT_ID: '',
        VISIT_ID: 0,
        OPER_ID: 0,
        wayType: 0
      },
      patientBaseDataAll: [],
      checked: 0,
      myOperCheck: 0,
      calendarCongig: [
        {
          show: false,
          zero: true,
          range: false,
          display: this.$$moment(new Date()).format('YYYY-MM-DD HH:mm'),
          value: [
            new Date().getFullYear(),
            new Date().getMonth() + 1,
            new Date().getDate()
          ], // 默认日期
          lunar: false // 显示农历
        }
      ],
      searchTime: new Date()
    }
  },
  props: {
    inWidth: Number,
    inHeight: Number
  },
  components: { LoacalAnesEdit },
  mounted () {},
  methods: {
    editData (index, row) {
      this.dialogVisible = true
      this.key = this.$route + +new Date()
      this.wayType = 1
      this.patientInfo.PATIENT_ID = row.PATIENT_ID
      this.patientInfo.VISIT_ID = row.VISIT_ID
      this.patientInfo.OPER_ID = row.OPER_ID
      this.patientInfo.wayType = 1
    },
    // 查询手术列表
    searchData (index) {
      var _this = this
      this.loading = true
      this.paginationInfo.currentPage = index
      if (_this.myOperCheck === 1) {
        _this.AnesDoctor = _this.userInfo.USER_JOB_ID
      } else {
        _this.AnesDoctor = ''
      }
      LocalAnesRegisterApi.GetAnesRecordInfo({
        StartDate: this.StartDate,
        EndDate: this.EndDate,
        InpNo: this.InpNo,
        AnesDoctor: this.AnesDoctor,
        PageSize: this.paginationInfo.pageSize,
        CurrentPage: this.paginationInfo.currentPage
      })
        .then(function (respose) {
          _this.paginationInfo.currentData = respose.data.Data.CurrentData
          _this.paginationInfo.total = respose.data.Data.Total
        })
        .catch(error => {
          console.log(error)
        })
    },
    addData () {
      this.key = this.$route + +new Date()
      this.patientInfo.PATIENT_ID = ''
      this.patientInfo.VISIT_ID = 0
      this.patientInfo.OPER_ID = 0
      this.patientInfo.wayType = 0
      this.ClearForm()
      this.dialogVisible = true
      this.wayType = 0
      this.$nextTick(function () {
        this.$refs.refEditOut.loading = true
      })
    },
    // 重置页面
    ClearForm () {
      this.key = this.$route + +new Date()
    },
    closeForm () {
      this.dialogVisible = false
    },
    rowIndex (index) {
      if (index % 2 === 0) {
        return { tableDoubleRow: true }
      } else {
        return { tableSingleRow: true }
      }
    }
  },
  created () {}
}
