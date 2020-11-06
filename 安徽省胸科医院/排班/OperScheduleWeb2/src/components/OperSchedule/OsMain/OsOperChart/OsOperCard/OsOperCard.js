import $ from 'jquery'
import '../../../../../../static/lib/jquery.resizable.js'
import '../../../../../../static/lib/jquery.changeTime.js'
import CancelView from '../../../../Common/CancelView/CancelView.vue'
import OperEdit from '../../../../Common/OperEdit/OperEdit.vue'
import moment from 'moment'

export default {
  name: 'OsOperCard',
  data () {
    return {
      userRole: JSON.parse(sessionStorage.user).USER_ROLE,
      dialogOperCancelVisible: false,
      dialogOperEditVisible: false,
      startPosition: 0,
      operDetailClone: {},
      lineStartTime: moment(this.$store.state.scheduleDateTime).add(
        this.webconfig.timeLineStart,
        'hours'
      ),
      lineEndTime: moment(this.$store.state.scheduleDateTime).add(
        this.webconfig.timeLineEnd,
        'hours'
      )
    }
  },
  props: {
    secondWidth: Number,
    timeSpanWidth: Number,
    operList: {},
    operDetail: {},
    operIndex: 0,
    isFirst: Boolean
  },
  watch: {
    'operDetail.SEQUENCE': function (n, o) {
      this.comStartPosition()
    },
    'operDetail.SCHEDULED_DATE_TIME': function (n, o) {
      this.comStartPosition()
    }
  },
  components: { CancelView, OperEdit },
  computed: {
    comFirstTimeWidth: function () {
      return (
        (this.webconfig.firstOperTime.hour +
          this.webconfig.firstOperTime.minute / 60 -
          this.webconfig.timeLineStart) *
        60 *
        this.secondWidth
      )
    },
    comCardWidth: function () {
      return this.operDetail.OPERATING_TIME * this.secondWidth - 2
    },
    comEndDateTime: function () {
      return moment(this.operDetail.SCHEDULED_DATE_TIME)
        .add(this.operDetail.OPERATING_TIME, 'minutes')
        .format('HH:mm')
    },
    comShowTitleContent: function () {
      return (
        '备注：' +
        (this.operDetail.NOTES_ON_OPERATION !== null &&
        this.operDetail.NOTES_ON_OPERATION !== ''
          ? this.operDetail.NOTES_ON_OPERATION
          : '无') +
        '  感染：' +
        (this.operDetail.SPECIAL_INFECT !== null &&
        this.operDetail.SPECIAL_INFECT !== ''
          ? this.operDetail.SPECIAL_INFECT
          : '无')
      )
    }
  },
  filters: {
    formatDate: function (value, format) {
      return moment(value).format(format)
    }
  },
  created: function () {
    this.comStartPosition()
  },
  methods: {
    valSubStr: function (value, length) {
      if (value !== null && value.length > length) {
        return value.substring(0, length) + '...'
      }
      return value
    },
    closeOperEditShow: function () {
      this.dialogOperEditVisible = false
    },
    closeShow: function () {
      this.dialogOperCancelVisible = false
      this.updateOperInfoCanceling()
    },
    updateOperInfoCanceling: function () {
      var updateOper = []
      for (var index = 0; index < this.operList.length; index++) {
        var element = this.operList[index]
        element.SEQUENCE = index + 1
        updateOper.push(element)
      }
      this.$store.dispatch('actionUpdateOpertingTime', updateOper)
    },
    setCardTelescopic: function () {
      var _this = this
      let changeOperTimeAble = 0
      $(this.$el).resizable({
        handler: '.handler',
        min: { width: this.secondWidth * 30, height: 110 },
        max: { width: this.secondWidth * 600, height: 110 },
        onStart: function (e) {
          _this.operDetailClone = JSON.parse(JSON.stringify(_this.operDetail))
          let lastoperObj = _this.operList[_this.operList.length - 1]
          changeOperTimeAble = _this.lineEndTime.diff(
            moment(lastoperObj.SCHEDULED_DATE_TIME).add(
              lastoperObj.OPERATING_TIME,
              'minutes'
            ),
            'minutes'
          ) - 4
        },
        onResize: function (e) {
          var tempOperTime =
            Math.round(e.data.resizeData.tempChangeWidth / _this.secondWidth) +
            1
          if (
            tempOperTime <
            changeOperTimeAble + _this.operDetailClone.OPERATING_TIME
          ) {
            e.data.resizeData.target.css({
              width: e.data.resizeData.tempChangeWidth
            })
            _this.operDetail.OPERATING_TIME = tempOperTime
          }
        },
        onStop: function (e) {
          changeOperTimeAble = 0
          var updateOper = []
          var tzTime =
            _this.operDetail.OPERATING_TIME -
            _this.operDetailClone.OPERATING_TIME
          for (
            var index = _this.operIndex;
            index < _this.operList.length;
            index++
          ) {
            var element = _this.operList[index]
            if (index > _this.operIndex) {
              element.SCHEDULED_DATE_TIME = moment(element.SCHEDULED_DATE_TIME)
                .add(tzTime, 'minutes')
                .format('YYYY-MM-DD HH:mm:ss')
            }
            updateOper.push(element)
          }
          _this.$store.dispatch('actionUpdateOpertingTime', updateOper)
        }
      })
    },
    opertionRevoked: function () {
      var _this = this
      _this
        .$confirm('确认撤销该手术吗?', '提示', {
          type: 'info'
        })
        .then(() => {
          _this.$ajax
            .post(
              '/Api/ScheduleOperSchedule/IsCanRevokedOpertionSchedule',
              _this.operDetail
            )
            .then(function (response) {
              if (response.data.Data.OPER_STATUS_CODE > 2) {
                var tmp = _this.$store.state.allOperList.find(
                  o =>
                    o.PATIENT_ID === _this.operDetail.PATIENT_ID &&
                    o.VISIT_ID === _this.operDetail.VISIT_ID &&
                    o.SCHEDULE_ID === _this.operDetail.SCHEDULE_ID
                )

                tmp.OPER_STATUS_CODE = response.data.Data.OPER_STATUS_CODE

                _this.$message.error({
                  duration: 1200,
                  message: '手术已开始，不能撤销!'
                })
              } else {
                _this.operDetail.OPER_STATUS_CODE =
                  _this.operDetail.OPER_STATUS_CODE - 1

                _this.$store.dispatch('actionRevokedOpertion', _this.operDetail)

                // setTimeout(_this.GetOperList(), 4000)
              }
            })
        })
        .catch(() => {})
    },
    GetOperList: function () {
      var _this = this
      _this.$ajax
        .get('/Api/ScheduleOperSchedule/GetOperList', {
          params: {
            ScheduleDateTime: _this.$store.state.scheduleDateTime
          }
        })
        .then(function (response) {
          _this.$store.commit('ALLOPERLIST', response.data.Data)
        })
        .catch(function (error) {
          console.log(error)
        })
    },
    allowDrop: function (ev) {
      ev.preventDefault()
    },
    drop: function (ev) {
      ev.preventDefault()
      var strHisUserInfo = ev.dataTransfer.getData('text')
      if (
        this.operDetail.OPER_STATUS_CODE < 2 &&
        strHisUserInfo !== '' &&
        strHisUserInfo.indexOf('hisUserJob') > -1
      ) {
        var HisUserInfo = JSON.parse(strHisUserInfo)
        if (HisUserInfo.hisUserJob === 'nuser') {
          if (HisUserInfo.hisUserType === 1) {
            // 洗手护士
            this.operDetail.FIRST_OPER_NURSE =
              HisUserInfo.contentInfo.USER_JOB_ID
            this.operDetail.FIRST_OPER_NURSE_NAME =
              HisUserInfo.contentInfo.USER_NAME
          } else if (HisUserInfo.hisUserType === 2) {
            // 巡回护士
            this.operDetail.FIRST_SUPPLY_NURSE =
              HisUserInfo.contentInfo.USER_JOB_ID
            this.operDetail.FIRST_SUPPLY_NURSE_NAME =
              HisUserInfo.contentInfo.USER_NAME
          }
          this.$store.dispatch('actionUpdateOpertingNurse', this.operDetail)
        } else {
          if (HisUserInfo.hisUserType === 1) {
            // 主麻
            this.operDetail.ANES_DOCTOR = HisUserInfo.contentInfo.USER_JOB_ID
            this.operDetail.ANES_DOCTOR_NAME = HisUserInfo.contentInfo.USER_NAME
          } else if (HisUserInfo.hisUserType === 2) {
            // 副麻
            this.operDetail.FIRST_ANES_ASSISTANT =
              HisUserInfo.contentInfo.USER_JOB_ID
            this.operDetail.FIRST_ANES_ASSISTANT_NAME =
              HisUserInfo.contentInfo.USER_NAME
          }
          this.$store.dispatch('actionUpdateOpertingDoctor', this.operDetail)
        }
      }
      // var strNurseInfo = ev.dataTransfer.getData('nurseInfo')
      // if (strNurseInfo !== '') {
      //   var nurseInfo = JSON.parse(strNurseInfo)
      //   if (nurseInfo.nurseType === 1) {
      //     // 洗手护士
      //     this.operDetail.FIRST_OPER_NURSE = nurseInfo.nuser.USER_JOB_ID
      //     this.operDetail.FIRST_OPER_NURSE_NAME = nurseInfo.nuser.USER_NAME
      //   } else if (nurseInfo.nurseType === 2) {
      //     // 巡回护士
      //     this.operDetail.FIRST_SUPPLY_NURSE = nurseInfo.nuser.USER_JOB_ID
      //     this.operDetail.FIRST_SUPPLY_NURSE_NAME = nurseInfo.nuser.USER_NAME
      //   }
      //   this.$store.dispatch('actionUpdateOpertingNurse', this.operDetail)
      // }
      // var strDoctorInfo = ev.dataTransfer.getData('doctorInfo')
      // if (strDoctorInfo !== '') {
      //   var doctorInfo = JSON.parse(strDoctorInfo)
      //   if (doctorInfo.doctorType === 1) {
      //     // 主麻
      //     this.operDetail.ANES_DOCTOR = doctorInfo.doctor.USER_JOB_ID
      //     this.operDetail.ANES_DOCTOR_NAME = doctorInfo.doctor.USER_NAME
      //   } else if (doctorInfo.doctorType === 2) {
      //     // 副麻
      //     this.operDetail.FIRST_ANES_ASSISTANT = doctorInfo.doctor.USER_JOB_ID
      //     this.operDetail.FIRST_ANES_ASSISTANT_NAME = doctorInfo.doctor.USER_NAME
      //   }
      //   this.$store.dispatch('actionUpdateOpertingDoctor', this.operDetail)
      // }
    },
    changeStartTime: function () {
      var _this = this
      let nMarginLeft = -1
      let changeTimeAble = 0
      let canChangejl = 0
      $(this.$el).changeTime({
        handler: '.lefthandler',
        onStart: function (e) {
          nMarginLeft = -1
          canChangejl = 0
          _this.operDetailClone = JSON.parse(JSON.stringify(_this.operDetail))
          let lastoperObj = _this.operList[_this.operList.length - 1]
          changeTimeAble = _this.lineEndTime.diff(
            moment(lastoperObj.SCHEDULED_DATE_TIME).add(
              lastoperObj.OPERATING_TIME,
              'minutes'
            ),
            'minutes'
          ) - 4
        },
        onChange: function (e) {
          var temobj = {
            SCHEDULED_DATE_TIME: _this.lineStartTime,
            OPERATING_TIME: 0
          }
          if (_this.operIndex > 0) {
            temobj = _this.operList[_this.operIndex - 1]
          }
          var startmarginLeft =
            moment(_this.operDetailClone.SCHEDULED_DATE_TIME).diff(
              moment(temobj.SCHEDULED_DATE_TIME).add(
                temobj.OPERATING_TIME,
                'minutes'
              ),
              'minutes'
            ) * _this.secondWidth
          var njl =
            changeTimeAble -
            Math.round(e.data.changeData.nl / _this.secondWidth)
          if (njl > 0) {
            nMarginLeft = startmarginLeft + e.data.changeData.nl
            if (nMarginLeft > -1) {
              canChangejl = e.data.changeData.nl
              let xjTime = Math.round(nMarginLeft / _this.secondWidth)
              _this.operDetail.SCHEDULED_DATE_TIME = moment(
                temobj.SCHEDULED_DATE_TIME
              )
                .add(temobj.OPERATING_TIME + xjTime, 'minutes')
                .format('YYYY-MM-DD HH:mm:ss')
              e.data.changeData.target.css({
                'margin-left': nMarginLeft + 'px'
              })
            }
          }
        },
        onStop: function (e) {
          _this.operDetailClone.SCHEDULED_DATE_TIME =
            _this.operDetail.SCHEDULED_DATE_TIME
          nMarginLeft = -1
          changeTimeAble = 0
          let xdTime = Math.round(canChangejl / _this.secondWidth)
          var updateOper = []
          for (
            var index = _this.operIndex;
            index < _this.operList.length;
            index++
          ) {
            var element = _this.operList[index]
            if (index > _this.operIndex) {
              element.SCHEDULED_DATE_TIME = moment(element.SCHEDULED_DATE_TIME)
                .add(xdTime, 'minutes')
                .format('YYYY-MM-DD HH:mm:ss')
            }
            updateOper.push(element)
          }
          canChangejl = 0
          _this.$store.dispatch('actionUpdateOpertingTime', updateOper)
        }
      })
    },
    comStartPosition: function () {
      // console.log('card')
      // console.log(this.operList)
      // console.log(this.operIndex)
      // console.log(this.operDetail)

      if (this.operIndex === 0) {
        this.startPosition =
          moment(this.operDetail.SCHEDULED_DATE_TIME).diff(
            this.lineStartTime,
            'minutes'
          ) * this.secondWidth
      } else {
        let temobj = this.operList[this.operIndex - 1]

        this.startPosition =
          moment(this.operDetail.SCHEDULED_DATE_TIME).diff(
            moment(temobj.SCHEDULED_DATE_TIME).add(
              temobj.OPERATING_TIME,
              'minutes'
            ),
            'minutes'
          ) * this.secondWidth
      }
    }
  },
  mounted: function () {
    if (this.operDetail.OPER_STATUS_CODE < 2) {
      this.setCardTelescopic()
      this.changeStartTime()
    }
  }
}
