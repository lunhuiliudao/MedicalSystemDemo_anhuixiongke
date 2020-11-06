import OsOperCard from '../OsOperCard/OsOperCard.vue'
import draggable from 'vuedraggable'
// import moment from 'moment'

export default {
  name: 'OsOperRoom',
  data () {
    return {}
  },
  props: ['operChartWith', 'operChartHeight', 'RoomNo', 'spanWidth'],
  computed: {
    comSecondWidth: function () {
      return this.spanWidth / 60
    },
    comTimeSpanWidth: function () {
      return this.comSecondWidth * this.webconfig.timeSpan
    },
    operInfoList: {
      get: function () {
        return this.$store.state.allOperList
          .filter(item => {
            return (
              item.OPER_STATUS_CODE !== 0 && item.OPER_ROOM_NO === this.RoomNo
            )
          })
          .sort((a, b) => {
            return a.SEQUENCE - b.SEQUENCE
          })
      },
      set: function (newValue) { }
    },
    comOperSequence: function () {
      var max = 0
      for (var i = 0; i < this.operInfoList.length; i++) {
        if (this.operInfoList[i].SEQUENCE > max) {
          max = this.operInfoList[i].SEQUENCE
        }
      }
      max = max + 1
      return max
    },
    dragOptions () {
      return {
        animation: 0,
        group: 'operRooms',
        disabled: false,
        ghostClass: 'ghost',
        handle: '.content'
      }
    }
  },
  components: {
    draggable,
    OsOperCard
  },
  methods: {
    allowDrop: function (ev) {
      ev.preventDefault()
    },
    drop: function (ev) {
      ev.preventDefault()
      var strHisUserInfo = ev.dataTransfer.getData('text')
      if (strHisUserInfo !== '' && strHisUserInfo.indexOf('hisUserJob') > -1) {
        var selectOperInfo = this.operInfoList.filter(item => {
          return item.OPER_STATUS_CODE === 1
        })
        if (selectOperInfo.length > 0) {
          var HisUserInfo = JSON.parse(strHisUserInfo)
          if (HisUserInfo.hisUserJob === 'nuser') {
            if (HisUserInfo.hisUserType === 1) {
              // 洗手护士
              for (
                var xsindex = 0;
                xsindex < selectOperInfo.length;
                xsindex++
              ) {
                var xselement = selectOperInfo[xsindex]
                xselement.FIRST_OPER_NURSE = HisUserInfo.contentInfo.USER_JOB_ID
                xselement.FIRST_OPER_NURSE_NAME =
                  HisUserInfo.contentInfo.USER_NAME
              }
            } else if (HisUserInfo.hisUserType === 2) {
              // 巡回护士
              for (
                var xhindex = 0;
                xhindex < selectOperInfo.length;
                xhindex++
              ) {
                var xhelement = selectOperInfo[xhindex]
                xhelement.FIRST_SUPPLY_NURSE =
                  HisUserInfo.contentInfo.USER_JOB_ID
                xhelement.FIRST_SUPPLY_NURSE_NAME =
                  HisUserInfo.contentInfo.USER_NAME
              }
            }
          } else {
            if (HisUserInfo.hisUserType === 1) {
              // 主麻
              for (
                var zmindex = 0;
                zmindex < selectOperInfo.length;
                zmindex++
              ) {
                var zmelement = selectOperInfo[zmindex]
                zmelement.ANES_DOCTOR = HisUserInfo.contentInfo.USER_JOB_ID
                zmelement.ANES_DOCTOR_NAME = HisUserInfo.contentInfo.USER_NAME
              }
            } else if (HisUserInfo.hisUserType === 2) {
              // 副麻
              for (
                var fmindex = 0;
                fmindex < selectOperInfo.length;
                fmindex++
              ) {
                var fmelement = selectOperInfo[fmindex]
                fmelement.FIRST_ANES_ASSISTANT =
                  HisUserInfo.contentInfo.USER_JOB_ID
                fmelement.FIRST_ANES_ASSISTANT_NAME =
                  HisUserInfo.contentInfo.USER_NAME
              }
            }
          }
          this.$store.dispatch('actionUpdateOpertingNurseList', selectOperInfo)
        }
      }
      // // var operInfo = JSON.parse(ev.dataTransfer.getData('operInfo'))
      // operInfo.OPER_STATUS_CODE = 1
      // operInfo.OPER_ROOM_NO = this.RoomNo
      // operInfo.SEQUENCE = this.comOperSequence
      // operInfo.OPERATING_TIME = this.webconfig.operTimeLength
      // if (operInfo.SEQUENCE === 1) {
      //   operInfo.SCHEDULED_DATE_TIME = this.$moment(this.$store.state.scheduleDateTime).hours(this.webconfig.firstOperTime.hour).minutes(this.webconfig.firstOperTime.minute).seconds(0).format('YYYY-MM-DD HH:mm:ss')
      // } else {
      //   var lastOper = this.operInfoList[this.operInfoList.length - 1]
      //   operInfo.SCHEDULED_DATE_TIME = this.$moment(lastOper.SCHEDULED_DATE_TIME).add(lastOper.OPERATING_TIME + this.webconfig.timeSpan, 'minutes').format('YYYY-MM-DD HH:mm:ss')
      // }
      // operInfo.SCHEDULED_DATE_TIME_SHORT = this.$moment(operInfo.SCHEDULED_DATE_TIME).format('HH:mm')
      // this.$store.dispatch('actionUpdateOperDetail', operInfo)
    },
    onMove ({ relatedContext, draggedContext }) {
      var draggedElement = draggedContext.element
      this.$store.commit('DRAG_OPER_INFO', draggedElement)
      // if (draggedElement.OPER_STATUS_CODE > 1 || relatedContext.element.OPER_STATUS_CODE > 1) {
      //   return false
      // } else {
      //   this.$store.commit('DRAG_OPER_INFO', draggedElement)
      //   return true
      // }
    },
    datadragEnd: function (evt) {
      console.log('拖动前的索引：' + evt.oldIndex)
      console.log('拖动后的索引：' + evt.newIndex)
      var oldOper = this.operInfoList[evt.oldIndex]
      var newOper = this.operInfoList[evt.newIndex]
      var startIndex = Math.min(evt.oldIndex, evt.newIndex)
      // var endIndex = Math.max(evt.oldIndex, evt.newIndex)
      var operstarttime = this.operInfoList[startIndex].SCHEDULED_DATE_TIME

      var xjTimeArry = []
      for (
        let oindex = startIndex + 1;
        oindex < this.operInfoList.length;
        oindex++
      ) {
        let temobj = this.operInfoList[oindex]
        let cobj = this.operInfoList[oindex - 1]
        xjTimeArry.push(
          this.$moment(temobj.SCHEDULED_DATE_TIME).diff(
            this.$moment(cobj.SCHEDULED_DATE_TIME).add(
              cobj.OPERATING_TIME,
              'minutes'
            ),
            'minutes'
          )
        )
      }
      // 改手术台次
      var temp = oldOper.SEQUENCE
      oldOper.SEQUENCE = this.operInfoList[evt.newIndex].SEQUENCE
      newOper.SEQUENCE = temp
      var updateOper = []
      var numCount = 0
      for (var index = startIndex; index < this.operInfoList.length; index++) {
        var element = this.operInfoList[index]
        if (index === startIndex) {
          element.SCHEDULED_DATE_TIME = operstarttime
        } else {
          element.SCHEDULED_DATE_TIME = this.$moment(
            this.operInfoList[index - 1].SCHEDULED_DATE_TIME
          )
            .add(
              this.operInfoList[index - 1].OPERATING_TIME +
              xjTimeArry[numCount],
              'minutes'
            )
            .format('YYYY-MM-DD HH:mm:ss')
          numCount++
        }
        element.SCHEDULED_DATE_TIME_SHORT = this.$moment(
          element.SCHEDULED_DATE_TIME
        ).format('HH:mm')
        updateOper.push(element)
      }
      this.$store.dispatch('actionUpdateOpertingTime', updateOper)
    },
    onAddOper: function (evt) {
      var operInfo = this.$store.state.dragOperInfo
      if (evt.item.firstElementChild.className === 'surgeonTitle') {
        var currentSequence = this.comOperSequence
        var currentStartDateTime =
          this.operInfoList.length === 0
            ? this.$moment(this.$store.state.scheduleDateTime)
              .hours(this.webconfig.firstOperTime.hour)
              .minutes(this.webconfig.firstOperTime.minute)
              .seconds(0)
              .format('YYYY-MM-DD HH:mm:ss')
            : this.$moment(
              this.operInfoList[this.operInfoList.length - 1]
                .SCHEDULED_DATE_TIME
            )
              .add(
                this.operInfoList[this.operInfoList.length - 1]
                  .OPERATING_TIME + this.webconfig.timeSpan,
                'minutes'
              )
              .format('YYYY-MM-DD HH:mm:ss')
        var newOperInfoList = JSON.parse(JSON.stringify(operInfo.data))

        for (var nindex = 0; nindex < newOperInfoList.length; nindex++) {
          var nelement = newOperInfoList[nindex]
          nelement.OPER_STATUS_CODE = 1
          nelement.OPER_ROOM_NO = this.RoomNo
          operInfo.SEQUENCE = 0
          nelement.SEQUENCE = currentSequence + nindex
          nelement.OPERATING_TIME = this.webconfig.operTimeLength
          if (nindex === 0) {
            nelement.SCHEDULED_DATE_TIME = currentStartDateTime
          } else {
            nelement.SCHEDULED_DATE_TIME = this.$moment(
              newOperInfoList[nindex - 1].SCHEDULED_DATE_TIME
            )
              .add(
                newOperInfoList[nindex - 1].OPERATING_TIME +
                this.webconfig.timeSpan,
                'minutes'
              )
              .format('YYYY-MM-DD HH:mm:ss')
          }
          nelement.SCHEDULED_DATE_TIME_SHORT = this.$moment(
            nelement.SCHEDULED_DATE_TIME
          ).format('HH:mm')
        }
        if (newOperInfoList != null && newOperInfoList.length > 0) {
          let comOper = newOperInfoList[newOperInfoList.length - 1]
          if (
            this.$moment(comOper.SCHEDULED_DATE_TIME).add(
              comOper.OPERATING_TIME,
              'minutes'
            ) >
            this.$moment(this.$store.state.scheduleDateTime).add(
              this.webconfig.timeLineEnd,
              'hours'
            )
          ) {
            this.$alert('该手术间安排的手术时长已超出', {
              confirmButtonText: '确定',
              type: 'error'
            })
            return false
          } else {
            this.$store.dispatch(
              'actionBatchUpdateOperScheduleList',
              newOperInfoList
            )
          }
        }
      } else {
        let fromWhere = operInfo.OPER_STATUS_CODE === 0 ? 'left' : 'right'
        let oldRoomNo = operInfo.OPER_ROOM_NO
        let opertingTime =
          operInfo.OPERATING_TIME === 0
            ? this.webconfig.operTimeLength
            : operInfo.OPERATING_TIME
        let tempScheduleDateTime = null
        if (this.operInfoList.length === 0) {
          tempScheduleDateTime = this.$moment(
            this.$store.state.scheduleDateTime
          )
            .hours(this.webconfig.firstOperTime.hour)
            .minutes(this.webconfig.firstOperTime.minute)
            .seconds(0)
            .format('YYYY-MM-DD HH:mm:ss')
        } else {
          var lastOper = this.operInfoList[this.operInfoList.length - 1]
          tempScheduleDateTime = this.$moment(lastOper.SCHEDULED_DATE_TIME)
            .add(lastOper.OPERATING_TIME + this.webconfig.timeSpan, 'minutes')
            .format('YYYY-MM-DD HH:mm:ss')
        }
        if (
          this.$moment(tempScheduleDateTime).add(opertingTime, 'minutes') >
          this.$moment(this.$store.state.scheduleDateTime).add(
            this.webconfig.timeLineEnd,
            'hours'
          )
        ) {
          this.$alert('该手术间安排的手术时长已超出', {
            confirmButtonText: '确定',
            type: 'error'
          })
          return false
        }
        if (fromWhere === 'left') {
          operInfo.OPER_STATUS_CODE = 1
        }
        operInfo.OPER_ROOM_NO = this.RoomNo
        operInfo.SEQUENCE = 0
        operInfo.SEQUENCE = this.comOperSequence
        operInfo.OPERATING_TIME = opertingTime
        operInfo.SCHEDULED_DATE_TIME = tempScheduleDateTime
        // if (operInfo.SEQUENCE === 1) {
        //   operInfo.SCHEDULED_DATE_TIME = this.$moment(this.$store.state.scheduleDateTime).hours(this.webconfig.firstOperTime.hour).minutes(this.webconfig.firstOperTime.minute).seconds(0).format('YYYY-MM-DD HH:mm:ss')
        // } else {
        //   var lastOper = this.operInfoList[this.operInfoList.length - 2]
        //   operInfo.SCHEDULED_DATE_TIME = this.$moment(lastOper.SCHEDULED_DATE_TIME).add(lastOper.OPERATING_TIME + this.webconfig.timeSpan, 'minutes').format('YYYY-MM-DD HH:mm:ss')
        // }
        operInfo.SCHEDULED_DATE_TIME_SHORT = this.$moment(
          operInfo.SCHEDULED_DATE_TIME
        ).format('HH:mm')
        this.$store.dispatch('actionUpdateOperDetail', operInfo)
        // 更新原房间中的数据
        if (fromWhere === 'right') {
          var wasRoomOperList = this.$store.state.allOperList
            .filter(item => {
              return (
                item.OPER_STATUS_CODE !== 0 && item.OPER_ROOM_NO === oldRoomNo
              )
            })
            .sort((a, b) => {
              return a.SEQUENCE - b.SEQUENCE
            })
          var updateOper = []
          for (var index = 0; index < wasRoomOperList.length; index++) {
            var element = wasRoomOperList[index]
            element.SEQUENCE = index + 1
            console.log(element.SEQUENCE)
            if (index === 0) {
              element.SCHEDULED_DATE_TIME = this.$moment(
                element.SCHEDULED_DATE_TIME
              )
                .hours(this.webconfig.firstOperTime.hour)
                .minutes(this.webconfig.firstOperTime.minute)
                .seconds(0)
                .format('YYYY-MM-DD HH:mm:ss')
            } else {
              element.SCHEDULED_DATE_TIME = this.$moment(
                wasRoomOperList[index - 1].SCHEDULED_DATE_TIME
              )
                .add(
                  wasRoomOperList[index - 1].OPERATING_TIME +
                  this.webconfig.timeSpan,
                  'minutes'
                )
                .format('YYYY-MM-DD HH:mm:ss')
            }
            element.SCHEDULED_DATE_TIME_SHORT = this.$moment(
              element.SCHEDULED_DATE_TIME
            ).format('HH:mm')
            updateOper.push(element)
          }
          this.$store.dispatch('actionUpdateOpertingTime', updateOper)
        }
        return true
      }
    }
  }
}
