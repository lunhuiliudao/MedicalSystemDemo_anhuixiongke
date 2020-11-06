export default {
  name: 'Today',
  data () {
    return {
      userInfo: this.$store.getters.user
    }
  },
  props: {
    count: {
      type: Number,
      default: 0
    }
  },
  computed: {
    FinishInfo () {
      return this.$store.state.HomeData.dataInfo.filter(x => {
        return x.Oper_Status === '术后' || x.Oper_Status === '复苏'
      })
    },
    UnFinishInfo () {
      return this.$store.state.HomeData.dataInfo.filter(x => {
        return x.Oper_Status !== '术后' && x.Oper_Status !== '复苏'
      })
    },
    OperInfos () {
      return this.$store.state.HomeData.OperInfos
    }
  },
  methods: {
    rowIndex (index) {
      if (index % 2 === 0) {
        return { tableSingleRow: true }
      } else {
        return { tableDoubleRow: true }
      }
    },
    splitUserName: function (username) {
      return username.substring(1, 0)
    },
    getTimeDesc () {
      return new Date().getHours() > 11 ? '下午' : '上午'
    }
  }
}
