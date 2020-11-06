import HomeApi from '@/api/HomeApi.js'
import MedSelect from '@/components/MedSelect/MedSelect.vue'
import InputSelect from '@/components/InputSelect/InputSelect.vue'

export default {
  name: 'Search',
  data () {
    return {
      userInfo: this.$store.getters.user,
      // 查询条件
      PatName: '',
      InpNo: '',
      OperDept: '',
      AnesDoctor: '',
      StartDate: this.$$moment(),
      myOperCheck: 0,
      TestItems: [
        {
          Key: '1',
          Value: 'AAA'
        },
        {
          Key: '2',
          Value: 'BBB'
        },
        {
          Key: '3',
          Value: 'CCC'
        }
      ]
    }
  },

  components: { MedSelect, InputSelect },
  props: {},
  methods: {
    search: function () {
      var _this = this
      var currentUserid = _this.userInfo.USER_JOB_ID
      var anesdoc = _this.AnesDoctor
      if (_this.myOperCheck === 1) {
        anesdoc = _this.userInfo.USER_JOB_ID
        _this.AnesDoctor = ''
      }
      HomeApi.GetOperListForDoctorInfo({
        PatName: _this.PatName,
        InpNo: _this.InpNo,
        OperDept: _this.OperDept,
        // OperDoctor: _this.OperDoctor,
        AnesDoctor: anesdoc,
        CurrentUserId: currentUserid,
        StartDate: _this.StartDate,
        EndDate: _this.EndDate,
        DeptType: '',
        CurrentPage: 1,
        PageSize: 99999
      })
        .then(response => {
          this.$store.dispatch('addSearchData', response.data.Data)
          var width = document.body.clientWidth
          var height = document.body.clientHeight
          if (width > height) {
            this.$store.state.HomeData.showfull = true
          }
        })
        .catch(error => {
          console.log(error)
        })
    }
  }
}
