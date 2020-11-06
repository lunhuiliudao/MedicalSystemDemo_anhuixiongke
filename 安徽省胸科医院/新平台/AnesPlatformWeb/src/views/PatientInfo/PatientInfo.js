import HorizontalBasicInfo from './BasicInfo/HorizontalBasicInfo.vue'
import VerticalBasicInfo from './BasicInfo/VerticalBasicInfo.vue'
import AssayReport from './AssayReport/AssayReport.vue'
import AnesDocument from './AnesDocument/AnesDocument.vue'
export default {
  name: 'PatientInfo',
  data () {
    return {
      osmainWith: 0,
      osmainHeight: 0,
      patientInfo: [],
      activeName: 'first'
    }
  },
  components: { HorizontalBasicInfo, VerticalBasicInfo, AssayReport, AnesDocument },
  computed: {
    leftWidth: function () {
      return this.$store.state.HomeData.miniBasicInfo ? 68 : 546
    },
    showfull: function () {
      return this.$store.state.HomeData.showfull
    }
  },
  methods: {
    mainStyle: function () {
      this.osmainHeight = parseInt(document.documentElement.clientHeight)
      this.osmainWith = parseInt(document.documentElement.clientWidth)
    }
  },
  created: function () {
    this.mainStyle()
    if (parseInt(document.documentElement.clientWidth) > 1560) {
      this.$store.state.HomeData.miniBasicInfo = false
    } else {
      this.$store.state.HomeData.miniBasicInfo = true
    }
  }
}
