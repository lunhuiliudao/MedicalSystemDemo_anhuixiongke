import LocalAnesRegisterApi from '@/api/LocalAnesRegisterApi.js'
import MedSelect from '@/components/MedSelect/MedSelect.vue'
import InputSelect from '@/components/InputSelect/InputSelect.vue'
// import AnesDatePicker from '@/components/anes-date-picker'

export default {
  name: 'LoacalAnesEdit',
  props: ['patientInfo'],
  data () {
    return {
      dialogVisible: false,
      patientBaseDataAll: [],
      patientBaseData: [],
      wayType: 0, // 弹出窗口类型，0-新增，1-修改
      MaxOperId: 0,

      OperDeptList: [], // 科室
      OperRoonNoListAll: [],
      OperRoonNoList: [],
      deptList: [],
      RoomDeptList: [],
      ischecked: 0
    }
  },
  components: { MedSelect, InputSelect },
  methods: {
    dateClick () {
      var aaa = document.getElementsByClassName(
        'el-picker-panel el-date-picker el-popper has-time'
      )
      aaa[0].style['z-index'] = aaa[0].style['z-index'] + 1
    },
    getMaxOperId (inpNo) {
      if (inpNo === null || inpNo === undefined) {
        inpNo = ''
      }
      LocalAnesRegisterApi.GetOutOperatingRoomAnesRecord({
        inpNo: inpNo
      })
        .then(respose => {
          var data = respose.data.Data

          if (data !== null && data.length > 0) {
            var maxNo = 0

            data.forEach(element => {
              if (parseInt(element.OPER_ID) > maxNo) {
                maxNo = parseInt(element.OPER_ID)
              }
            })
            this.MaxOperId = maxNo
          }
        })
        .catch(error => {
          console.log(error)
        })
    },
    // 选择患者
    getPatientBaseInfo (val) {
      this.ischecked = 0
      if (val === null || val === undefined) {
        val = ''
      }
      LocalAnesRegisterApi.GetOutOperatingRoomAnesRecord({
        inpNo: val
      })
        .then(respose => {
          var data = respose.data.Data
          this.patientBaseDataAll = data
          this.getMaxOperId(this.patientBaseData.INP_NO)
          if (this.patientBaseDataAll.length > 1) {
            this.dialogVisible = true
          } else if (this.patientBaseDataAll.length === 1) {
            this.patientBaseData = this.patientBaseDataAll[0]
          } else {
            this.$message({
              message: '该住院号未查询到患者住院记录',
              type: 'warning'
            })
          }
        })
        .catch(error => {
          console.log(error)
        })
    },
    selectPatient (row) {
      if (row != null) {
        this.patientBaseData = row
        this.dialogVisible = false
        this.ischecked = 0
      } else {
        this.$message({
          message: '请选择患者',
          type: 'warning'
        })
      }
    },
    GetDeptDict () {
      var _this = this
      // 获取当前患者手术信息
      LocalAnesRegisterApi.GetMedDeptInOperRoomDict({
        DeptName: ''
      })
        .then(respose => {
          _this.RoomDeptList = respose.data.Data
          _this.GetOperRoomList()
        })
        .catch(error => {
          console.log(error)
        })
    },
    // 获取手术间字典
    GetOperRoomList () {
      var _this = this
      // 获取当前患者手术信息
      LocalAnesRegisterApi.GetOperatingRoomListAll({})
        .then(respose => {
          _this.OperRoonNoListAll = []
          if (
            typeof respose.data.Data !== 'undefined' &&
            respose.data.Data.length > 0
          ) {
            _this.OperRoonNoListAll = respose.data.Data.filter(
              d => d.BED_TYPE === '0'
            )
          }
          _this.OperDeptList = []
          _this.OperRoonNoListAll.forEach(element => {
            // console.log(_this.OperDeptList.length)
            if (_this.OperDeptList.length > 0) {
              var findList = _this.OperDeptList.filter(
                d => d.DEPT_CODE === element.DEPT_CODE
              )

              if (findList.length === 0) {
                var findDept = _this.RoomDeptList.filter(
                  d => d.DEPT_CODE === element.DEPT_CODE
                )
                if (findDept.length > 0) {
                  _this.OperDeptList.push(findDept[0])
                }
              }
            } else {
              // console.log(_this.RoomDeptList.length)
              var findDept1 = _this.RoomDeptList.filter(
                d => d.DEPT_CODE === element.DEPT_CODE
              )
              if (findDept1.length > 0) {
                _this.OperDeptList.push(findDept1[0])
              }
            }
          })
          _this.selectChanged()
        })
        .catch(error => {
          console.log(error)
        })
    },
    selectChanged () {
      var _this = this
      if (_this.patientBaseData.OPER_ROOM !== '') {
        if (_this.OperRoonNoListAll.length > 0) {
          _this.OperRoonNoList = _this.OperRoonNoListAll.filter(
            d => d.DEPT_CODE === _this.patientBaseData.OPER_ROOM
          )
        }
      } else {
        _this.OperRoonNoList = _this.OperRoonNoListAll
      }
    },
    FilterOperRoom (query) {
      if (query !== '') {
        var _this = this
        LocalAnesRegisterApi.GetAnesRecordInfoByPatient({
          OperatingRoomNo: query
        })
          .then(function (respose) {
            _this.OperRoonNoList = respose.data.Data
          })
          .catch(error => {
            console.log(error)
          })
      } else {
        this.GetOperRoomList()
      }
    },
    getEditPatientData (pid, vid, oid) {
      LocalAnesRegisterApi.GetAnesRecordInfoByPatient({
        patientId: pid,
        visitId: vid,
        operId: oid
      })
        .then(respose => {
          var data = respose.data.Data
          this.patientBaseDataAll = data
          if (this.patientBaseDataAll.length === 1) {
            this.patientBaseData = this.patientBaseDataAll[0]
            this.getMaxOperId(this.patientBaseData.INP_NO)
          } else {
            this.patientBaseDataAll = []
            this.patientBaseData = []
            this.$message({
              message: '该住院号未查询到患者住院记录',
              type: 'warning'
            })
          }
          this.loading = true
        })
        .catch(error => {
          console.log(error)
        })
    },
    rowIndex (index) {
      if (index % 2 === 0) {
        return { tableDoubleRow: true }
      } else {
        return { tableSingleRow: true }
      }
    },
    // 重置页面
    ClearForm () {
      this.key = this.$route + +new Date()
      this.patientBaseData.OPERATION_NAMES = []
      this.patientBaseData = []
      this.medAnesthesiaInputData = []
    },
    // 关闭界面
    cancel () {
      this.$emit('closeForm', false)
    },
    // 保存数据
    SaveOutOperatingRoomAnesRecordData (formName) {
      if (
        this.patientBaseData.IN_DATE_TIME === '' ||
        this.patientBaseData.IN_DATE_TIME === null ||
        this.patientBaseData.IN_DATE_TIME === undefined
      ) {
        this.$message({
          message: '入手术室时间不能为空！',
          type: 'warning'
        })
        return
      }

      if (
        this.patientBaseData.START_DATE_TIME === '' ||
        this.patientBaseData.START_DATE_TIME === null ||
        this.patientBaseData.START_DATE_TIME === undefined
      ) {
        this.$message({
          message: '手术开始时间不能为空！',
          type: 'warning'
        })
        return
      }

      if (
        this.patientBaseData.END_DATE_TIME === '' ||
        this.patientBaseData.END_DATE_TIME === null ||
        this.patientBaseData.END_DATE_TIME === undefined
      ) {
        this.$message({
          message: '手术结束时间不能为空！',
          type: 'warning'
        })
        return
      }

      if (
        this.patientBaseData.OUT_DATE_TIME === '' ||
        this.patientBaseData.OUT_DATE_TIME === null ||
        this.patientBaseData.OUT_DATE_TIME === undefined
      ) {
        this.$message({
          message: '出手术室时间不能为空！',
          type: 'warning'
        })
        return
      }

      this.patientBaseData.IN_DATE_TIME = this.$$moment(
        this.patientBaseData.IN_DATE_TIME
      ).format('YYYY-MM-DD HH:mm:ss')
      this.patientBaseData.OUT_DATE_TIME = this.$$moment(
        this.patientBaseData.OUT_DATE_TIME
      ).format('YYYY-MM-DD HH:mm:ss')
      this.patientBaseData.START_DATE_TIME = this.$$moment(
        this.patientBaseData.START_DATE_TIME
      ).format('YYYY-MM-DD HH:mm:ss')
      this.patientBaseData.END_DATE_TIME = this.$$moment(
        this.patientBaseData.END_DATE_TIME
      ).format('YYYY-MM-DD HH:mm:ss')

      if (
        this.patientBaseData.IN_DATE_TIME > this.patientBaseData.START_DATE_TIME
      ) {
        this.$message({
          message: '入手术室时间必需在手术开始之前！',
          type: 'warning'
        })
        return
      }

      if (
        this.patientBaseData.START_DATE_TIME >
        this.patientBaseData.END_DATE_TIME
      ) {
        this.$message({
          message: '手术开始时间必需在手术结束时间之前！',
          type: 'warning'
        })
        return
      }
      if (
        this.patientBaseData.END_DATE_TIME > this.patientBaseData.OUT_DATE_TIME
      ) {
        this.$message({
          message: '出手术室时间必需大于手术结束时间！',
          type: 'warning'
        })
        return
      }

      var _THIS = this

      LocalAnesRegisterApi.SaveOutOperatingRoomAnesRecordData(
        this.patientBaseData
      )
        .then(function (respose) {
          if (respose.data.Data === 1) {
            _THIS.$message({
              message: '保存成功',
              type: 'success'
            })
            if (_THIS.wayType === 0) {
              // 新增的情况下，页面保存完需要重置，编辑状态下无需重置页面
              _THIS.ClearForm()
            }
            _THIS.$emit('update:dialogVisible', false)
            _THIS.dialogVisible = false
            _THIS.$emit('refreshList')
          } else if (respose.data.Data === 2) {
            _THIS.$message.error('手术回写HIS失败！')
          } else {
            _THIS.$message.error('保存失败')
          }
        })
        .catch(error => {
          console.log(error)
        })
    }
  },
  created () {
    if (this.patientInfo.PATIENT_ID !== '') {
      this.getEditPatientData(
        this.patientInfo.PATIENT_ID,
        this.patientInfo.VISIT_ID,
        this.patientInfo.OPER_ID
      )
      this.wayType = this.patientInfo.wayType
    }
    this.GetDeptDict()
  }
}
