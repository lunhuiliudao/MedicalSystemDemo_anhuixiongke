import NoticeList from './NoticeList/NoticeList.vue'
import PickUpList from './PickUpList/PickUpList.vue'

export default {
  components: {NoticeList, PickUpList},
  data: function () {
    return {
      activeName: 'first'
    }
  },
  computed: {
    onNoticeWidth: function () {
      return (parseInt(document.documentElement.clientWidth))
    },
    onNoticeHeight: function () {
      return (parseInt(document.documentElement.clientHeight) - 170)
    }
  }
}
