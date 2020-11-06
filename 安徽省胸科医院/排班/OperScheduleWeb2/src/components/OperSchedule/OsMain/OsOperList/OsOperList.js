import api from '../../../../api'

var data = function () {
  return {
    // 自定义列名初始化数据
    columns: [{ fieldname: 'OPER_ROOM_NO', columnname: '手术间', width: 65, visible: true },
      { fieldname: 'SEQUENCE', columnname: '台次', width: 40, visible: true },
      { fieldname: 'SCHEDULED_DATE_TIME_SHORT', columnname: '时间', width: 55, visible: true },
      { fieldname: 'DEPT_NAME', columnname: '手术科室', width: 90, visible: true },
      { fieldname: 'INP_NO', columnname: '住院号', width: 60, visible: true },
      { fieldname: 'NAME', columnname: '姓名', width: 75, visible: true },
      { fieldname: '', columnname: '检验信息', width: 75, visible: this.webconfig.openLIS101 },
      { fieldname: '', columnname: '护理信息', width: 75, visible: true },
      { fieldname: '', columnname: '医嘱信息', width: 75, visible: this.webconfig.openORDER103 },
      { fieldname: 'AGE', columnname: '年龄', width: 60, visible: true },
      { fieldname: 'SEX', columnname: '性别', width: 40, visible: true },
      { fieldname: 'DIAG_BEFORE_OPERATION', columnname: '诊断', width: 115, visible: true },
      { fieldname: 'TEMP_OPER_NAME', columnname: '手术名称', width: 120, visible: true },
      { fieldname: 'SURGEON_NAME', columnname: '手术医生', width: 60, visible: true },
      { fieldname: 'ANES_METHOD', columnname: '麻醉方式', width: 100, visible: true },
      { fieldname: 'ANES_DOCTOR_NAME', columnname: '麻醉医生', width: 55, visible: true },
      { fieldname: 'FIRST_OPER_NURSE_NAME', columnname: '洗手护士1', width: 60, visible: true },
      { fieldname: 'SECOND_OPER_NURSE_NAME', columnname: '洗手护士2', width: 60, visible: true },
      { fieldname: 'FIRST_SUPPLY_NURSE_NAME', columnname: '巡回护士1', width: 60, visible: true },
      { fieldname: 'SECOND_SUPPLY_NURSE_NAME', columnname: '巡回护士2', width: 60, visible: true },
      { fieldname: 'FIRST_OPER_ASSISTANT_NAME', columnname: '助手1', width: 55, visible: true },
      { fieldname: 'SECOND_OPER_ASSISTANT_NAME', columnname: '助手2', width: 55, visible: true },
      { fieldname: 'THIRD_OPER_ASSISTANT_NAME', columnname: '助手3', width: 55, visible: true },
      { fieldname: 'FIRST_ANES_ASSISTANT_NAME', columnname: '副麻1', width: 55, visible: true },
      { fieldname: 'SECOND_ANES_ASSISTANT_NAME', columnname: '副麻2', width: 55, visible: true },
      { fieldname: 'ISOLATION_IND_NM', columnname: '隔离', width: 35, visible: true },
      { fieldname: 'NOTES_ON_OPERATION', columnname: '备注', width: 65, visible: true },
      { fieldname: 'OPER_STATUS_CODE', columnname: '状态', width: 65, visible: true }
    ],
    randomcolor: ['#319CF4', '#983CDF', '#FA8A59', '#FDBA08', '#6992EB'],
    dialogLIS101Visible: false,
    checkResultMasterData: [],
    checkResultDetailData: [],
    checkResultLoading: false,
    dialogORDER103Visible: false,
    ordersViewLoading: false,
    ordersData: [],
    currentRow: []
  }
}
export default {
  name: 'OsOperList',
  data: data,
  computed: {
    operRoomNoList: function () {
      return this.$store.state.OperRoomNoList
    },
    // 手术信息表
    tableData: function () {
      return this.$store.state.allOperList.filter((item) => { return item.OPER_STATUS_CODE !== 0 })
    },
    osWidth: function () {
      return this.inWidth
    },
    osHeight: function () {
      return this.inHeight
    },
    colunmtitlewidth: function () {
      let totalwidth = 0
      this.columns.forEach((i) => { totalwidth += i.width })
      return totalwidth + 17
    }
  },
  methods: {
    onscroll: function (obj) {
      document.getElementsByClassName('columntitle')[0].scrollLeft = document.getElementsByClassName('mainDiv')[0].scrollLeft
    },
    operLIS101: function (row) {
      this.currentRow = row
      var patientID = row.PATIENT_ID
      var visitID = row.VISIT_ID
      this.dialogLIS101Visible = true
      this.checkResultLoading = true
      api.SyncLIS101({patientID: patientID, visitID: visitID}).then((response) => {
        this.$ajax.get(this.webconfig.AnesWorkStationApiUrl + 'api/Common/GetMedLabTestMaster', { params: {
          patientId: patientID,
          visitId: visitID
        }}).then((r1) => {
          this.checkResultLoading = false
          this.checkResultMasterData = r1.data.Data
          if (this.checkResultMasterData.length > 0) {
            this.$nextTick(function () {
              this.$refs.checkResultMaster.setCurrentRow(this.checkResultMasterData[0])
            })
          } else {
            this.$nextTick(function () {
              this.checkResultDetailData = []
            })
          }
        }).catch((e1) => {
          console.log(e1)
        })
      }).catch((error) => {
        console.log(error)
      })
    },
    resultMasterCurrentChange: function (currentRow) {
      this.$ajax.get(this.webconfig.AnesWorkStationApiUrl + 'api/Common/GetMedLabResult', { params: {
        testNo: currentRow.TEST_NO
      }}).then((response) => {
        this.checkResultDetailData = response.data.Data
      }).catch((error) => {
        console.log(error)
      })
    },
    openORDER103: function (row) {
      this.currentRow = row
      var patientID = row.PATIENT_ID
      var visitID = row.VISIT_ID
      this.dialogORDER103Visible = true
      this.ordersViewLoading = true
      api.SyncOrder103({patientID: patientID, visitID: visitID}).then((response) => {
        this.$ajax.get('/api/ScheduleOperSchedule/GetMedOrdersList', { params: {
          patientId: patientID,
          visitId: visitID
        }}).then((r1) => {
          this.ordersViewLoading = false
          this.ordersData = r1.data.Data
        }).catch((e1) => {
          console.log(e1)
        })
      }).catch((error) => {
        console.log(error)
      })
    },
    getHLHref: function (row) {
      return 'medOpenIE:http://192.168.100.104:8091/DocView.aspx?seqno=' + row.INP_NO + '&visNum=' + row.VISIT_ID + '&timestamp=' + Math.ceil(Math.random() * 10000)
    }
  },
  props: {
    inWidth: Number,
    inHeight: Number
  }
}
