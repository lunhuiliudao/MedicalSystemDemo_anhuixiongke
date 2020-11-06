export default {
  name: 'OperTr',
  props: {
    operDetail: {}
  },
  methods: {
    valSubStr: function (value, length) {
      if (value !== null && value.length > length) {
        return value.substring(0, length) + '...'
      }
      return value
    },
    openDialogOperCancel: function () {
      this.$emit('openDialogOperCancel', this.operDetail)
    },
    openDialogOperEdit: function () {
      this.$emit('openDialogOperEdit', this.operDetail)
    }
  }
}
