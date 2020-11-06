import OtherConfigApi from '@/api/OtherConfigApi.js'
// import AnesDatePicker from '@/components/anes-date-picker'

export default {
  name: 'WeChatSyn',
  data () {
    return {
      StartDate: this.$$moment()
        .add(-1, 'months')
        .format('YYYY-MM'),
      EndDate: this.$$moment().format('YYYY-MM'),
      dictList: [
        { key: 'MED_OPERATION_DICT' },
        { key: 'MED_DIAGNOSIS_DICT' },
        { key: 'MED_ANESTHESIA_DICT' }
      ],
      selectDict: ''
    }
  },
  components: { },
  computed: {},
  created () {},
  methods: {
    SynWeChatReport () {
      var _THIS = this
      // this.$ajax
      //   .post('/Api/PlatformSendWeChatData/SaveWeChatCloudStatisticsDataAll', {
      //     StartDate: _THIS.StartDate,
      //     EndDate: _THIS.EndDate
      //   })
      OtherConfigApi.SaveWeChatCloudStatisticsDataAll({
        StartDate: _THIS.StartDate,
        EndDate: _THIS.EndDate
      })
        .then(function (respose) {
          if (respose.data === true) {
            _THIS.$message({
              message: '同步成功！',
              type: 'success'
            })
          }
        })
        .catch(function (error) {
          console.log(error)
          _THIS.loading = false
        })
    },
    SynWeChatQualityControl () {
      var _THIS = this
      // this.$ajax
      //   .post('/Api/PlatformSendWeChatData/SaveWeChatCloudQuanlityDataAll', {
      //     StartDate: _THIS.StartDate,
      //     EndDate: _THIS.EndDate
      //   })
      OtherConfigApi.SaveWeChatCloudQuanlityDataAll({
        StartDate: _THIS.StartDate,
        EndDate: _THIS.EndDate
      })
        .then(function (respose) {
          if (respose.data === true) {
            _THIS.$message({
              message: '同步成功！',
              type: 'success'
            })
          }
        })
        .catch(function (error) {
          console.log(error)
          _THIS.loading = false
        })
    },
    // 保存字典数据
    SaveDictData () {
      var _this = this
      // _this.$ajax
      //   .get('/Api/PlatformSysConfig/SaveDictDataByTableName', {
      //     params: {
      //       tableName: _this.selectDict
      //     }
      //   })
      if (
        _this.selectDict !== '' &&
        _this.selectDict !== null &&
        _this.selectDict !== undefined
      ) {
        OtherConfigApi.SaveDictDataByTableName({
          tableName: _this.selectDict
        })
          .then(function (respose) {
            if (respose.data.Data === 1) {
              _this.$message({
                message: '转换成功',
                type: 'success'
              })
            } else {
              _this.$message({
                message: '转换失败',
                type: 'warning'
              })
            }
          })
          .catch(error => {
            console.log(error)
          })
      } else {
        _this.$message({
          message: '请先选择转换字典！',
          type: 'warning'
        })
      }
    }
  }
}
