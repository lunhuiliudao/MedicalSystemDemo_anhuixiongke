// import moment from 'moment'

var data = function () {
  return {
    // 原始表数据
    tableData: [],
    // 自定义列名初始化数据
    columns: [
      { fieldname: 'INP_NO', columnname: '住院号', width: {width: 90}, fixed: true, visible: true },
      { fieldname: 'PATIENT_ID', columnname: '患者ID', width: {width: 120}, fixed: true, visible: true },
      { fieldname: 'PAT_NAME', columnname: '患者姓名', width: {width: 100}, fixed: true, visible: true },
      { fieldname: 'AGE', columnname: '年龄', width: {width: 70}, fixed: true, visible: true },
      { fieldname: 'SEX', columnname: '性别', width: {width: 65}, fixed: true, visible: true },
      { fieldname: 'BED_NO', columnname: '床号', width: {width: 65}, fixed: true, visible: true },
      { fieldname: 'SCHEDULED_DATE_TIME', columnname: '时间', width: {width: 80}, visible: true },
      { fieldname: 'OPERATION_NAME', columnname: '手术名称', width: {width: 180}, visible: true },
      { fieldname: 'SURGEON_NAME', columnname: '手术医师', width: {width: 95}, visible: true },
      { fieldname: 'FIRST_OPER_ASSISTANT_NAME', columnname: '助手1', width: {width: 95}, visible: true },
      { fieldname: 'SECOND_OPER_ASSISTANT_NAME', columnname: '助手2', width: {width: 95}, visible: true },
      { fieldname: 'THIRD_OPER_ASSISTANT_NAME', columnname: '助手3', width: {width: 95}, visible: true },
      { fieldname: 'ANESTHESIA_METHOD', columnname: '麻醉方法', width: {'min-width': 0}, visible: true },
      { fieldname: 'NOTES_ON_OPERATION', columnname: '备注', width: {'min-width': 0}, visible: true }
    ],
    // 当前日期
    scheduledate: this.$moment().format('YYYY-MM-DD'),
    loading: false,
    // 当前状态
    operstate: '',
    // 选择行
    selectedrows: []
  }
}

export default {
  name: 'Oper-Cancel',
  data: data,
  methods: {
    // 查询手术
    search: function () {
      this.loading = true
      var _THIS = this
      this.$ajax.get('/Api/ScheduleOperCancel/GetOperCancelList', {
        params: {
          ScheduleDateTime: _THIS.scheduledate
        }
      }).then(function (respose) {
        _THIS.selectedrows = []
        _THIS.operstate = ''
        _THIS.tableData = respose.data.Data
        _THIS.loading = false
      }).catch(function (error) {
        if (error.response) {
          console.log(error.response.data)
          console.log(error.response.status)
          console.log(error.response.headers)
        } else {
          console.log('Error', error.message)
        }
        console.log(error.config)
        _THIS.loading = false
      })
    },
    // 撤销手术
    reback: function () {
      var _THIS = this
      _THIS.loading = true
      for (var i = 0; i < _THIS.selectedrows.length; i++) {
        for (var j = 0; j < _THIS.tableData.length; j++) {
          var curentrow = _THIS.selectedrows[i]
          if (curentrow.PATIENT_ID === _THIS.tableData[j].PATIENT_ID &&
            curentrow.VISIT_ID === _THIS.tableData[j].VISIT_ID &&
            curentrow.SCHEDULE_ID === _THIS.tableData[j].SCHEDULE_ID) {
            // 撤销取消的手术
            this.$ajax.post('/Api/ScheduleOperCancel/RebackCancelOper', {
              PatientID: curentrow.PATIENT_ID,
              VisitID: curentrow.VISIT_ID,
              ScheduleID: curentrow.SCHEDULE_ID
            }).then(function (respose) {
              _THIS.selectedrows = []
            }).catch(function (error) {
              if (error.response) {
                console.log(error.response.data)
                console.log(error.response.status)
                console.log(error.response.headers)
              } else {
                console.log('Error', error.message)
              }
              console.log(error.config)
            })
            this.tableData.splice(j, 1)
          }
        }
      }
      _THIS.selectedrows = []
      _THIS.loading = false
    },
    handleSelectionChange: function (val) {
      this.selectedrows = val
    }
  },
  created: function () {
    this.search()
  },
  computed: {
    // 手术信息表
    tmptableData: function () {
      return this.tableData
    },
    ocCancelWith: function () {
      return (parseInt(document.documentElement.clientWidth))
    },
    ocCancelHeight: function () {
      return (parseInt(document.documentElement.clientHeight) - 123)
    }
  }
}
