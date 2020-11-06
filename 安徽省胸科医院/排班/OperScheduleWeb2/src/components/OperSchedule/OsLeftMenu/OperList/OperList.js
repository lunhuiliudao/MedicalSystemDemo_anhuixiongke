import draggable from 'vuedraggable'
import OperTr from '../../../Common/OperTr/OperTr.vue'
import CancelView from '../../../Common/CancelView/CancelView.vue'
import OperEdit from '../../../Common/OperEdit/OperEdit.vue'
import OperSurgeonList from '../OperSurgeonList/OperSurgeonList.vue'
// import moment from 'moment'

export default {
  name: 'OperList',
  data () {
    return {
      opersortway: 2,
      leftHeightObj: { leftBodyHeight: '0px' },
      dialogOperCancelVisible: false,
      OperCancelObj: {},
      dialogOperEditVisible: false,
      OperEditObj: {}
    }
  },
  components: {
    draggable,
    OperTr,
    CancelView,
    OperEdit,
    OperSurgeonList
  },
  computed: {
    leftOperInfo: {
      get: function () {
        return this.$store.state.allOperList.filter((item) => { return item.OPER_STATUS_CODE === 0 })
      },
      set: function (newValue) {
      }
    },
    dragOptions () {
      return {
        animation: 0,
        group: 'operRooms',
        disabled: false,
        sort: false,
        ghostClass: 'ghost',
        filter: '.ignore-elements'
        // forceFallback: true
        // fallbackOnBody: true
      }
    },
    comEndDateTime: function () {
      return this.$moment(this.OperCancelObj.SCHEDULED_DATE_TIME).add(this.OperCancelObj.OPERATING_TIME, 'minutes').format('HH:mm')
    }
  },
  created: function () {
    this.leftHeight()
  },
  methods: {
    leftHeight: function () {
      this.leftHeightObj.leftBodyHeight = (parseInt(document.documentElement.clientHeight) - 73 - 156) + 'px'
    },
    drag: function (ev, oper) {
      console.log(oper)
      ev.dataTransfer.setData('text', JSON.stringify(oper))
      // ev.dataTransfer.setData('operInfo', JSON.stringify(oper))
    },
    onMove ({ relatedContext, draggedContext }) {
      var draggedElement = draggedContext.element
      this.$store.commit('DRAG_OPER_INFO', draggedElement)
      return true
    },
    closeDialogOperCancel: function () {
      this.dialogOperCancelVisible = false
    },
    openDialogOperCancel: function (obj) {
      this.dialogOperCancelVisible = true
      this.OperCancelObj = obj
    },
    closeOperEditShow: function () {
      this.dialogOperEditVisible = false
    },
    openDialogOperEdit: function (obj) {
      this.OperEditObj = JSON.parse(JSON.stringify(obj))
      this.dialogOperEditVisible = true
    }
  }
}
