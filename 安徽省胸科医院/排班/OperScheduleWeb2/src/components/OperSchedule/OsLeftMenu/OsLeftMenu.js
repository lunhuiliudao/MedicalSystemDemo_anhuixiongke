import OperList from './OperList/OperList.vue'
import NurseList from './NurseList/NurseList.vue'
import DoctorList from './DoctorList/DoctorList.vue'
import api from '../../../api'
// import moment from 'moment'

export default {
  data () {
    return {
      listType: 1,
      opersortway: 2,
      scheduleDateTime: this.$store.state.scheduleDateTime,
      leftHeightObj: { leftContentHeight: '0px' },
      userRole: JSON.parse(sessionStorage.user).USER_ROLE,
      syncLoading: false,
      fullscreenLoading: false
      // leftOperInfo: this.$store.state.leftOperInfo,
    }
  },
  components: {
    OperList,
    NurseList,
    DoctorList
  },
  created: function () {
    this.leftHeight()
    this.getLeftOperInfoList()
  },
  methods: {
    getLeftOperInfoList: function () {
      this.fullscreenLoading = true
      this.$store.commit('UPDATE_OPERTIME', this.$moment(this.scheduleDateTime).format('YYYY-MM-DD'))
      var _this = this
      this.$ajax.get('/Api/ScheduleOperSchedule/GetOperList', {
        params: {
          ScheduleDateTime: this.scheduleDateTime
        }
      }).then(function (response) {
        _this.$store.commit('ALLOPERLIST', response.data.Data)
        _this.fullscreenLoading = false
      }).catch(function (error) {
        _this.fullscreenLoading = false
        console.log(error)
      })
    },
    changeScheduleDateTime: function () {
      this.getLeftOperInfoList()
    },
    leftHeight: function () {
      this.leftHeightObj.leftContentHeight = (parseInt(document.documentElement.clientHeight) - 73) + 'px'
    },
    selectTab: function (selectType) {
      if (this.listType !== selectType) {
        this.listType = selectType
      }
    },
    SyncOperinfoList: function () {
      this.$confirm('确认同步手术数据吗?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'info'
      }).then(() => {
        this.syncLoading = true
        this.$message({
          type: 'info',
          duration: 1200,
          message: '已开始同步!'
        })
        var _this = this
        api.SyncOperList({ScheduleDateTime: this.scheduleDateTime}).then(function (response) {
          console.log(response.data.Data)
          _this.syncLoading = false
          _this.getLeftOperInfoList()
        })
      }).catch(() => {
        this.syncLoading = false
        this.$message({
          type: 'info',
          duration: 1200,
          message: '已取消同步!'
        })
      })
    }
  }
}
