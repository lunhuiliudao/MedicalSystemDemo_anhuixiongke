import AssayReportApi from '@/api/AssayReportApi.js'
import pdf from 'vue-pdf'
export default {
  name: 'BasicInfo',
  data () {
    return {
      patientInfo: []
    }
  },
  props: {},
  components: { pdf },
  computed: {
    showMiniInfo () {
      return this.$store.state.HomeData.miniBasicInfo
    }
  },

  methods: {
    showMin () {
      let ismini = this.$store.state.HomeData.miniBasicInfo
      // if (ismini) {
      //   ismini = false
      // } else {
      //   ismini = true
      // }
      this.$store.state.HomeData.miniBasicInfo = !ismini
    },
    CalLeft () {
      return this.$store.state.HomeData.miniBasicInfo ? 17 : 25
    },
    IsJZ (obj) {
      return obj === 1
    }
  },
  created: function () {
    // 接受参数
    var pid = this.$route.query.pid
    var vid = this.$route.query.vid
    var oid = this.$route.query.oid
    // if (typeof this.$route.query.id !== 'undefined') {
    //   alert(pidTemp)
    // } else {
    //   alert(pidTemp + '33')
    // }

    AssayReportApi.GetPatientInfo({
      patientId: pid,
      visitId: vid,
      operId: oid
    })
      .then(respose => {
        if (respose.data.Data.length > 0) {
          this.patientInfo = respose.data.Data[0]
        }
        console.log(this.patientInfo.EMERGENCY_IND)

        // alert(this.patientInfo[0].AGE)
      })
      .catch(error => {
        console.log(error)
      })
  }
}
