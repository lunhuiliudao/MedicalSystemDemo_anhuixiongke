import draggable from 'vuedraggable'

export default {
  name: 'OperSurgeonList',
  data () {
    return {
      opersortway: 1,
      dataIsOpen: [],
      dragOptions: {
        animation: 0,
        group: 'operRooms',
        disabled: false,
        sort: false,
        ghostClass: 'ghost',
        handle: '.surgeonTitle'
        // filter: '.ignore-elements'
        // forceFallback: true
        // fallbackOnBody: true
      }
    }
  },
  components: {
    draggable
  },
  computed: {
    surgeonBodyHeight: function () {
      return (parseInt(document.documentElement.clientHeight) - 73 - 131) + 'px'
    },
    comOperListGroupSurgeon: {
      get: function () {
        var operList = this.$store.state.allOperList.filter((item) => { return item.OPER_STATUS_CODE === 0 })
        this.dataIsOpen = []
        var map = {}
        var dest = []
        for (var i = 0; i < operList.length; i++) {
          var temp = operList[i]
          if (!map[temp.SURGEON]) {
            dest.push({
              id: temp.SURGEON,
              surgeonName: temp.SURGEON_NAME,
              deptName: temp.DEPT_NAME,
              data: [temp]
            })
            this.dataIsOpen.push({id: temp.SURGEON, isOpen: false})
            map[temp.SURGEON] = temp
          } else {
            for (var j = 0; j < dest.length; j++) {
              var dj = dest[j]
              if (dj.id === temp.SURGEON) {
                dj.data.push(temp)
                break
              }
            }
          }
        }
        return dest.sort((a, b) => {
          if (a.deptName === b.deptName) {
            if (a.deptName > b.deptName) {
              return 1
            } else if (a.deptName < b.deptName) {
              return -1
            } else {
              return 0
            }
          } else {
            if (a.deptName > b.deptName) {
              return 1
            } else {
              return -1
            }
          }
        })
      },
      set: function (newValue) {
      }
    }
  },
  methods: {
    openList: function (obj) {
      if (this.dataIsOpen[obj].isOpen) {
        this.dataIsOpen[obj].isOpen = false
      } else {
        this.dataIsOpen[obj].isOpen = true
      }
    },
    onMove ({relatedContext, draggedContext}) {
      var draggedElement = draggedContext.element
      this.$store.commit('DRAG_OPER_INFO', draggedElement)
      return true
    }
  }
}
