export default {
  name: 'Month',
  data () {
    return {}
  },
  props: {
    count: {
      type: Number,
      default: 100
    },
    hours: {
      type: Number,
      default: 100
    },
    rescueCount: {
      type: Number,
      default: 1
    },
    emergencyCount: {
      type: Number,
      default: 10
    }
  },
  computed: {
    OperInfos () {
      return this.$store.state.HomeData.OperInfos
    }
  }
}
