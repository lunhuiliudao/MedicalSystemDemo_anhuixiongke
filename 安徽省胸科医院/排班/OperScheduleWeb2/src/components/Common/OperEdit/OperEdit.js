// import moment from 'moment'
import api from '../../../api'

export default {
  name: 'OperEdit',
  data () {
    return {
      operNameLoading: false,
      operNameList: [],
      surgeonLoading: false,
      surgeonNameList: [],
      anesthesiaNameLoading: false,
      anesthesiaNameList: [],
      anesDoctorNameLoding: false,
      anesDoctorNameList: [],
      anesDoctorName1Loding: false,
      anesDoctorName1List: [],
      anesDoctorName2Loding: false,
      anesDoctorName2List: [],
      operNurse1Loading: false,
      operNurseName1List: [],
      operNurse2Loading: false,
      operNurseName2List: [],
      supplyNurse1Loading: false,
      supplyNurseName1List: [],
      supplyNurse2Loading: false,
      supplyNurseName2List: []
    }
  },
  props: {
    comOperDetail: {
      type: Object,
      default: function () {
        return {PATIENT_ID: ''}
      }
    }
  },
  computed: {
    comDateTime: function () {
      return this.$moment(this.comOperDetail.SCHEDULED_DATE_TIME).format('HH:mm')
    }
  },
  methods: {
    remoteOperName (query) {
      if (query != null && query.trim() !== '') {
        this.operNameLoading = true
        var _this = this
        api.GetOperName({inputContent: query}).then(function (response) {
          _this.operNameList = response.data.Data
          _this.operNameLoading = false
        }).catch(function (error) {
          _this.operNameLoading = false
          console.log(error)
        })
      } else {
        this.operNameList = []
      }
    },
    remoteSurgeonName (query) {
      if (query != null && query.trim() !== '') {
        this.surgeonLoading = true
        var _this = this
        api.GetGetSurgeons({inputContent: query}).then(function (response) {
          _this.surgeonNameList = response.data.Data
          _this.surgeonLoading = false
        }).catch(function (error) {
          _this.surgeonLoading = false
          console.log(error)
        })
      } else {
        this.surgeonNameList = []
      }
    },
    remoteAnesthesiaName (query) {
      if (query != null && query.trim() !== '') {
        this.anesthesiaNameLoading = true
        var _this = this
        api.GetAnesthesiaName({inputContent: query}).then(function (response) {
          _this.anesthesiaNameList = response.data.Data
          _this.anesthesiaNameLoading = false
        }).catch(function (error) {
          _this.anesthesiaNameLoading = false
          console.log(error)
        })
      } else {
        this.anesthesiaNameList = []
      }
    },
    remoteAnesDoctorName (query) {
      if (query != null && query.trim() !== '') {
        this.anesDoctorNameLoding = true
        var _this = this
        api.GetAnesDoctors({inputContent: query}).then(function (response) {
          _this.anesDoctorNameList = response.data.Data
          _this.anesDoctorNameLoding = false
        }).catch(function (error) {
          _this.anesDoctorNameLoding = false
          console.log(error)
        })
      } else {
        this.anesDoctorNameList = []
      }
    },
    remoteAnesDoctorName1 (query) {
      if (query != null && query.trim() !== '') {
        this.anesDoctorName1Loding = true
        var _this = this
        api.GetAnesDoctors({inputContent: query}).then(function (response) {
          _this.anesDoctorName1List = response.data.Data
          _this.anesDoctorName1Loding = false
        }).catch(function (error) {
          _this.anesDoctorName1Loding = false
          console.log(error)
        })
      } else {
        this.anesDoctorName1List = []
      }
    },
    remoteAnesDoctorName2 (query) {
      if (query != null && query.trim() !== '') {
        this.anesDoctorName2Loding = true
        var _this = this
        api.GetAnesDoctors({inputContent: query}).then(function (response) {
          _this.anesDoctorName2List = response.data.Data
          _this.anesDoctorName2Loding = false
        }).catch(function (error) {
          _this.anesDoctorName2Loding = false
          console.log(error)
        })
      } else {
        this.anesDoctorName2List = []
      }
    },
    remoteOperNurseName1 (query) {
      if (query != null && query.trim() !== '') {
        this.operNurse1Loading = true
        var _this = this
        api.GetOperNurses({inputContent: query}).then(function (response) {
          _this.operNurseName1List = response.data.Data
          _this.operNurse1Loading = false
        }).catch(function (error) {
          _this.operNurse1Loading = false
          console.log(error)
        })
      } else {
        this.operNurseName1List = []
      }
    },
    remoteOperNurseName2 (query) {
      if (query != null && query.trim() !== '') {
        this.operNurse2Loading = true
        var _this = this
        api.GetOperNurses({inputContent: query}).then(function (response) {
          _this.operNurseName2List = response.data.Data
          _this.operNurse2Loading = false
        }).catch(function (error) {
          _this.operNurse2Loading = false
          console.log(error)
        })
      } else {
        this.operNurseName2List = []
      }
    },
    remoteSupplyNurseName1 (query) {
      if (query != null && query != null && query.trim() !== '') {
        this.supplyNurse1Loading = true
        var _this = this
        api.GetOperNurses({inputContent: query}).then(function (response) {
          _this.supplyNurseName1List = response.data.Data
          _this.supplyNurse1Loading = false
        }).catch(function (error) {
          _this.supplyNurse1Loading = false
          console.log(error)
        })
      } else {
        this.supplyNurseName1List = []
      }
    },
    remoteSupplyNurseName2 (query) {
      if (query != null && query.trim() !== '') {
        this.supplyNurse2Loading = true
        var _this = this
        api.GetOperNurses({inputContent: query}).then(function (response) {
          _this.supplyNurseName2List = response.data.Data
          _this.supplyNurse2Loading = false
        }).catch(function (error) {
          _this.supplyNurse2Loading = false
          console.log(error)
        })
      } else {
        this.supplyNurseName2List = []
      }
    },
    saveOperDetailInfo: function () {
      this.$confirm('确认保存手术数据吗?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'info'
      }).then(() => {
        var _this = this
        this.comOperDetail.SCHEDULED_DATE_TIME = this.$moment(this.comOperDetail.SCHEDULED_DATE_TIME).format('YYYY-MM-DD HH:mm:ss')
        api.ModifyOperDetailInfo(this.comOperDetail).then(function (response) {
          _this.$emit('closeOperEditView')
          if (response.data.Data.count > 0) {
            _this.$store.commit('UPDATE_OPERDETAIL', response.data.Data.operDetail)
            _this.getLeftOperInfoList()
            _this.$message({
              type: 'success',
              duration: 1200,
              message: '保存成功!'
            })
          } else {
            _this.$message({
              type: 'error',
              duration: 1200,
              message: '保存失败!'
            })
          }
        }).catch(function (error) {
          console.log(error)
        })
      }).catch((error) => {
        console.log(error)
      })
    },
    getLeftOperInfoList: function () {
      var selectScheduleDateTime = this.$store.state.scheduleDateTime
      var _this = this
      this.$ajax.get('/Api/ScheduleOperSchedule/GetOperList', {
        params: {
          ScheduleDateTime: selectScheduleDateTime
        }
      }).then(function (response) {
        _this.$store.commit('ALLOPERLIST', response.data.Data)
      }).catch(function (error) {
        console.log(error)
      })
    }
  },
  created: function () {
    this.remoteSurgeonName(this.comOperDetail.SURGEON)
    this.remoteAnesDoctorName(this.comOperDetail.ANES_DOCTOR)
    this.remoteAnesDoctorName1(this.comOperDetail.FIRST_ANES_ASSISTANT)
    this.remoteAnesDoctorName2(this.comOperDetail.SECOND_ANES_ASSISTANT)
    this.remoteOperNurseName1(this.comOperDetail.FIRST_OPER_NURSE)
    this.remoteOperNurseName2(this.comOperDetail.SECOND_OPER_NURSE)
    this.remoteSupplyNurseName1(this.comOperDetail.FIRST_SUPPLY_NURSE)
    this.remoteSupplyNurseName2(this.comOperDetail.SECOND_SUPPLY_NURSE)
  }
}
