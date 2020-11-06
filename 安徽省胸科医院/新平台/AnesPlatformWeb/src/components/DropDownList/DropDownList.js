import AnesReportApi from '@/api/AnesReportApi.js'

export default {
  name: 'DropDownList',
  data () {
    return {
      options: [{ Key: '', Value: '' }]
    }
  },
  props: ['condition'],
  methods: {
    GetData () {
      this.options = [{ Key: '', Value: '' }]
      if (this.condition.DictType === 'DiyDict') {
        this.options = this.condition.BindDict
      } else {
        AnesReportApi.getDict(this.condition).then((respose) => {
          // 显示数据条数：总数<100?总数：100
          var count = respose.data.Data.length
          if (count < 100) {
            this.options = respose.data.Data.slice(0, count)
          } else {
            this.options = respose.data.Data.slice(0, 100)
          }
          sessionStorage.setItem(this.condition.Title, JSON.stringify(respose.data.Data))
        }).catch((error) => {
          console.log(error)
        })
      }
    },
    handleFilter (Value) {
      var showData = [] // 展现的数据
      this.options = [{ Key: '', Value: '' }]
      var valueToUp = Value.toUpperCase()// 助记码
      this.condition.Value = Value // 持续输入
      if (this.condition.DictType === 'DiyDict') {
        this.options = this.condition.BindDict
      } else {
        var data = JSON.parse(sessionStorage.getItem(this.condition.Title))
        // 判断是否为空
        if (Value === null || Value === undefined || Value === '') {
          this.options = data.slice(0, 100)
        } else {
          for (var i = 0; i < data.length; i++) {
            if (data[i].InputCode.indexOf(valueToUp) >= 0) {
              if (showData.length === 0) {
                showData.push(data[i])
              } else {
                var flag = 0
                for (var j = 0; j < showData.length; j++) {
                  if (showData[j].InputCode.indexOf(data[i].InputCode) >= 0) {
                    flag++
                  }
                }
                if (flag === 0) {
                  showData.push(data[i])
                }
              }
            }
            if (data[i].Value.indexOf(valueToUp) >= 0) {
              if (showData.length === 0) {
                showData.push(data[i])
              } else {
                let flag = 0
                for (let j = 0; j < showData.length; j++) {
                  if (showData[j].Value.indexOf(data[i].Value) >= 0) {
                    flag++
                  }
                }
                if (flag === 0) {
                  showData.push(data[i])
                }
              }
            }
            if (data[i].Key.indexOf(valueToUp) >= 0) {
              if (showData.length === 0) {
                showData.push(data[i])
              } else {
                let flag = 0
                for (let j = 0; j < showData.length; j++) {
                  if (showData[j].Key.indexOf(data[i].Key) >= 0) {
                    flag++
                    break
                  }
                }
                if (flag === 0) {
                  showData.push(data[i])
                }
              }
            }
          }
          var count = showData.length
          if (count < 100) {
            this.options = showData
          } else {
            this.options = showData.slice(0, 100)
          }
        }
      }
    },
    selectChange () {
      this.options = [{ Key: '', Value: '' }]
      if (this.condition.DictType === 'DiyDict') {
        this.options = this.condition.BindDict
      } else {
        var data = JSON.parse(sessionStorage.getItem(this.condition.Title))
        if (data.length < 100) {
          this.options = data
        } else {
          this.options = data.slice(0, 100)
        }
      }
    }
  },
  created: function () {
    this.GetData()
  }
}
