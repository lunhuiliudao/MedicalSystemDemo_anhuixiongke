import OsOperChart from './OsOperChart/OsOperChart.vue'
import OsOperList from './OsOperList/OsOperList.vue'
export default {
  name: 'OsMain',
  data () {
    return {
      osmainWith: 0,
      osmainHeight: 0,
      showtype: 1,
      userRole: JSON.parse(sessionStorage.user).USER_ROLE
    }
  },
  components: { OsOperChart, OsOperList },
  created: function () {
    this.mainStyle()
    this.$store.dispatch('actionGetOperRoomNoList')
  },
  methods: {
    mainStyle: function () {
      this.osmainHeight = parseInt(document.documentElement.clientHeight) - 81
      this.osmainWith = parseInt(document.documentElement.clientWidth) - 387
    },
    selectchange: function (showtype) {
      if (this.showtype !== showtype) {
        this.showtype = showtype
      }
    },
    submitOpertionList: function () {
      this.$confirm('确认提交排班手术吗?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'info'
      })
        .then(() => {
          var submitOpertions = this.$store.state.allOperList.filter(item => {
            return item.OPER_STATUS_CODE === 1
          })
          var anesTemp = []
          if (submitOpertions.length > 0) {
            for (var index = 0; index < submitOpertions.length; index++) {
              var element = submitOpertions[index]
              if (this.userRole.indexOf('医生') > -1) {
                element.ANES_CONFIRM = 1
                if (
                  (element.ANES_DOCTOR === '' ||
                    element.ANES_DOCTOR === null ||
                    element.ANES_DOCTOR === undefined) &&
                  (element.FIRST_ANES_ASSISTANT === '' ||
                    element.FIRST_ANES_ASSISTANT === null ||
                    element.FIRST_ANES_ASSISTANT === undefined)
                ) {
                  anesTemp.push(element)
                  submitOpertions.splice(index, 1)
                }
              } else {
                // 医院要求，医生不想排班，直接让护士排班，麻醉医生给出默认值：112742
                // 护士提交后，就相当于医生和护士都提交了
                element.ANES_CONFIRM = 1
                if (element.ANES_DOCTOR === '' || element.ANES_DOCTOR === null || element.ANES_DOCTOR === undefined) {
                  element.ANES_DOCTOR = '112742'
                }

                element.NURSE_CONFIRM = 1
                if (
                  (element.FIRST_OPER_NURSE === '' ||
                    element.FIRST_OPER_NURSE === null ||
                    element.FIRST_OPER_NURSE === undefined) &&
                  (element.FIRST_SUPPLY_NURSE === '' ||
                    element.FIRST_SUPPLY_NURSE === null ||
                    element.FIRST_SUPPLY_NURSE === undefined)
                ) {
                  anesTemp.push(element)
                  submitOpertions.splice(index, 1)
                }
              }
              if (element.ANES_CONFIRM === 1 && element.NURSE_CONFIRM === 1) {
                element.OPER_STATUS_CODE = 2
              }
            }

            if (anesTemp.length > 0) {
              if (this.userRole.indexOf('医生') > -1) {
                this.$message.warning({
                  duration: 3600,
                  message: '还未安排麻醉医生、该手术暂不能提交!'
                })
              } else {
                this.$message.warning({
                  duration: 3600,
                  message: '还未安排手术护士、该手术暂不能提交!'
                })
              }
            }
            this.$store.dispatch('actionSubmitOpertionList', submitOpertions)
          }
        })
        .catch(() => { })
    }
  },
  computed: {
    totalcnt: function () {
      return this.$store.state.allOperList.length
    },
    finishedcnt: function () {
      return this.$store.state.allOperList.filter(item => {
        return item.OPER_STATUS_CODE !== 0
      }).length
    },
    nofinishedcnt: function () {
      return this.$store.state.allOperList.filter(item => {
        return item.OPER_STATUS_CODE === 0
      }).length
    }
  }
}
