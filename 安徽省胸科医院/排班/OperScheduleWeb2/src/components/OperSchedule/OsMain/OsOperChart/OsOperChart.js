import OsOperRoom from './OsOperRoom/OsOperRoom.vue'

export default {
  name: 'OsOperChart',
  data () {
    return {
      // spanWidth: 0
    }
  },
  props: ['operChartWith', 'operChartHeight'],
  computed: {
    operRoomNoList: function () {
      return this.$store.state.OperRoomNoList
    },
    spanCount: function () {
      return this.webconfig.timeLineEnd - this.webconfig.timeLineStart
    },
    spanWidth: function () {
      return (this.operChartWith - 65 - 10) / this.spanCount
    }
  },
  components: {
    OsOperRoom
  },
  created: function () {
    this.webconfig = JSON.parse(sessionStorage.webconfig)
  },
  mounted: function () {
    this.createTimeLine()
  },
  methods: {
    // 创建时间轴
    createTimeLine: function () {
      // var spanCount = this.webconfig.timeLineEnd - this.webconfig.timeLineStart
      // this.spanWidth = (this.operChartWith - 65 - 17) / spanCount
      var timeLine = document.getElementById('timeLineCanvas')
      var cxt = timeLine.getContext('2d')

      cxt.beginPath()
      cxt.moveTo(0, 32)
      cxt.lineWidth = 5
      cxt.strokeStyle = '#F9D35A'
      cxt.lineTo(this.operChartWith - 10, 32)
      cxt.stroke()

      var tempTimeLineStart = parseInt(this.webconfig.timeLineStart)
      cxt.strokeStyle = '#5C5C5C'
      cxt.lineWidth = 1
      for (var i = 0; i < this.spanCount; i++) {
        cxt.beginPath();
        (function (arg, tempSpanWidth) {
          if (arg === 0) {
            cxt.moveTo(parseInt(tempSpanWidth * arg) + 0.5 + 65, 25)
            cxt.lineTo(parseInt(tempSpanWidth * arg) + 0.5 + 65, 32)
          } else {
            cxt.moveTo(parseInt(tempSpanWidth * arg) + 0.5 + 65, 25)
            cxt.lineTo(parseInt(tempSpanWidth * arg) + 0.5 + 65, 32)
          }
          cxt.font = 'bold 15px arial'
          if (tempTimeLineStart + arg < 10) {
            cxt.fillText((tempTimeLineStart + arg) + ':00', arg * tempSpanWidth + 54, 18)
          } else {
            cxt.fillText((tempTimeLineStart + arg) + ':00', arg * tempSpanWidth + 46, 18)
          }
        })(i, this.spanWidth)
        cxt.stroke()
      }
    }
  }
}
