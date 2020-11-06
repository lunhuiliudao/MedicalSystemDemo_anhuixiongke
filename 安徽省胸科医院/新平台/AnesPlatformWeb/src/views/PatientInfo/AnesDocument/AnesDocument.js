import AssayReportApi from '@/api/AssayReportApi.js'
import pdf from 'vue-pdf'
export default {
  name: 'AnesDocument',
  data () {
    return {
      checkDateDict: [],
      DoucumentList: [],
      selected: '',
      selectedPath: '',
      loadedRatio: 0,
      page: 1,
      numPages: 0,
      rotate: 0,
      pdfwidth: 100,
      pdfheight: 100
    }
  },
  props: {
    inWidth: Number,
    inHeight: Number
  },
  components: { pdf },
  computed: {
    osWidth: function () {
      return this.inWidth
    },
    osHeight: function () {
      return this.inHeight
    },
    GetCurrentDocPDF: function () {
      console.log(this.webconfig.EmrService + this.selectedPath)
      return this.webconfig.EmrService + this.selectedPath
    }
  },

  methods: {
    GetPatientDocument () {
      var patientID = this.$route.query.pid
      var visitID = this.$route.query.vid
      var operID = this.$route.query.oid
      AssayReportApi.GetPatientDocument({
        patientID: patientID,
        visitID: visitID,
        operId: operID
      })
        .then(respose => {
          this.DoucumentList = respose.data.Data
          if (this.DoucumentList.length > 0) {
            this.selected = this.DoucumentList[0].MR_SUB_CLASS
            this.selectedPath = this.DoucumentList[0].DOCPATH
          }
        })
        .catch(error => {
          console.log(error)
        })
    },
    DocChange (doc, path) {
      this.page = 1
      this.selected = doc
      this.selectedPath = path
    },
    password: function (updatePassword, reason) {
      updatePassword(prompt('password is "test"'))
    },
    error: function (err) {
      console.log(err)
    },
    pdfZoomIn: function () {
      this.$refs.pdf.$el.style.width =
        this.$refs.pdf.$el.offsetWidth * 1.1 + 'px'
      this.$refs.pdf.$el.style.height =
        this.$refs.pdf.$el.offsetHeight * 1.1 + 'px'
      this.$refs.pdf.$el.style.margin = '0px auto'
      // this.pdfwidth = this.pdfwidth + 10
      // this.pdfheight = this.pdfheight + 10
      // this.$refs.pdf.resize()
    },
    pdfZoomOut: function () {
      this.$refs.pdf.$el.style.width =
        this.$refs.pdf.$el.offsetWidth * 0.9 + 'px'
      this.$refs.pdf.$el.style.height =
        this.$refs.pdf.$el.offsetHeight * 0.9 + 'px'
      this.$refs.pdf.$el.style.margin = '0px auto'
      // this.pdfwidth = this.pdfwidth - 10
      // this.pdfheight = this.pdfheight - 10
      // this.$refs.pdf.resize()
    },
    CalDocWidth () {
      return this.osWidth - 80 > 950 ? 950 : this.osWidth - 80
    }
  },
  created: function () {
    this.GetPatientDocument()
  }
}
