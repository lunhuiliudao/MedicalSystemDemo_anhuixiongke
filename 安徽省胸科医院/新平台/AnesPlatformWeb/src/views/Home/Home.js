import Tomorrow from './components/Tomorrow/Tomorrow.vue'
import Yesteday from './components/Yesteday/Yesteday.vue'
import Month from './components/Month/Month.vue'
import Today from './components/Today/Today.vue'
import Search from './components/Search/Search.vue'
import SearchList from './components/SearchList/SearchList.vue'
import HomeApi from '@/api/HomeApi.js'

export default {
  name: 'Home',
  data () {
    return {
      userInfo: this.$store.getters.user,
      StartDate: this.$$moment()
    }
  },
  computed: {
    showfull: function () {
      return this.$store.state.HomeData.showfull
    }
  },
  components: { Tomorrow, Yesteday, Month, Today, Search, SearchList },
  methods: {
    search: function () {
      HomeApi.GetOperListForDoctorInfo({
        PatName: '',
        InpNo: '',
        OperDept: '',
        OperDoctor: '',
        AnesDoctor: this.userInfo.USER_JOB_ID,
        CurrentUserId: this.userInfo.USER_JOB_ID,
        StartDate: this.StartDate,
        EndDate: this.EndDate,
        DeptType: '',
        CurrentPage: 1,
        PageSize: 12
      })
        .then(response => {
          this.$store.dispatch('addDataInfo', response.data.Data)
        })
        .catch(error => {
          console.log(error)
        })
    },
    searchInfos: function () {
      HomeApi.GetOperInfosForDoctorIndex({
        StartDate: this.StartDate,
        AnesDoctor: this.userInfo.USER_JOB_ID,
        DeptType: ''
      }).then(response => {
        this.$store.dispatch('addOperInfo', response.data.Data)
      }).catch(error => {
        console.log(error)
      })
    }
  },
  created: function () {
    this.search()
    this.searchInfos()
  }
}
