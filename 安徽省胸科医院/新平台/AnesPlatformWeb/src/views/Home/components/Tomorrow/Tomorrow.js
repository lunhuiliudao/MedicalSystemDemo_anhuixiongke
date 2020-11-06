export default {
  name: 'Tomorrow',
  data () {
    return {}
  },
  props: {
    count: {
      type: Number,
      default: 100
    }
  },
  computed: {
    OperInfos () {
      return this.$store.state.HomeData.OperInfos
    }
  }
}
