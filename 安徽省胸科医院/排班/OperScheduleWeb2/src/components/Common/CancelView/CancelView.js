import moment from 'moment'

export default {
  name: 'CancelView',
  data () {
    return {
      cancelClass: [{
        CLASS_VALUE: '1',
        CLASS_NAME: '医院因素',
        CLASS_CHECKED: false,
        CLASS_ITEMS: []
      },
      {
        CLASS_VALUE: '2',
        CLASS_NAME: '医护因素',
        CLASS_CHECKED: false,
        CLASS_ITEMS: []
      },
      {
        CLASS_VALUE: '3',
        CLASS_NAME: '患者因素',
        CLASS_CHECKED: false,
        CLASS_ITEMS: [
        ]
      }],
      selectClass: '1',
      cancelReason: ''
    }
  },
  props: {
    operDetail: {},
    endTime: ''
  },
  watch: {
    operDetail: function (n, o) {
      this.getCancelClass()
    }
  },
  filters: {
    formatDate: function (value, format) {
      return moment(value).format(format)
    }
  },
  computed: {
    comCancelType: function () {
      var tempArry = []
      this.cancelClass.forEach(eleClass => {
        eleClass.CLASS_ITEMS.forEach(eleItem => {
          tempArry.push(eleItem)
        })
      })
      return tempArry.filter(r => { return r.ITEM_CHECKED === true })
    },
    userInfo: function () {
      return JSON.parse(sessionStorage.user)
    }
  },
  created: function () {
    this.getCancelClass()
  },
  methods: {
    saveCancelInfo: function () {
      if (this.comCancelType.length > 0 && this.cancelReason !== '') {
        var operationCanceled = {
          PATIENT_ID: this.operDetail.PATIENT_ID,
          VISIT_ID: this.operDetail.VISIT_ID,
          CANCEL_ID: 0,
          SCHEDULE_ID: this.operDetail.SCHEDULE_ID,
          OPER_ID: this.operDetail.OPER_ID,
          OPER_STATUS_CODE: this.operDetail.OPER_STATUS_CODE,
          CANCEL_REASON: this.cancelReason,
          CANCEL_DATE: moment().format('YYYY-MM-DD HH:mm:ss'),
          CANCEL_BY: this.operDetail.NAME,
          ENTERED_BY: this.userInfo.USER_NAME
        }
        this.$store.dispatch('actionCancelOpertion', {OperCanceled: operationCanceled, AnesInputDict: this.comCancelType})
        this.$emit('closeView')
      } else {
        this.$alert('取消分类和说明不能为空', {
          confirmButtonText: '确定',
          type: 'error'
        })
      }
    },
    getCancelClass: function () {
      for (let index = 0; index < this.cancelClass.length; index++) {
        let element = this.cancelClass[index]
        element.CLASS_ITEMS = []
        this.$ajax.get('/Api/ScheduleCommon/GetAnesInputDict', {
          params: {
            itemClass: element.CLASS_NAME
          }
        }).then(function (respose) {
          element.CLASS_ITEMS = respose.data.Data
        }).catch(function (error) {
          console.log(error.config)
        })
      }
    }
  }
}
