export default {
  name: 'Yesteday',
  data () {
    return {}
  },
  props: {
    count: {
      type: Number,
      default: 100
    },
    emergencyCount: {
      type: Number,
      default: 100
    },
    pacuCount: {
      type: Number,
      default: 100
    },
    icuCount: {
      type: Number,
      default: 1
    },
    unExpectedCount: {
      type: Number,
      default: 1
    }
  },
  computed: {
    OperInfos () {
      return this.$store.state.HomeData.OperInfos
    }
  }
}
