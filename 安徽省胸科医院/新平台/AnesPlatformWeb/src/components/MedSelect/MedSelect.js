import CommonApi from '@/api/CommonApi.js'
export default {
  name: 'MedSelect',
  data () {
    return {
      options: [{ Key: '', Value: '' }],
      model: this.value
    }
  },
  props: {
    // 组件数据类型
    type: {
      type: String,
      default: ''
    },
    // 自定义查询sql
    condition: {
      type: String,
      default: ''
    },
    // 自定义数据
    customdata: {
      type: Array
    },
    // 提示语
    placeholder: {
      type: String,
      default: ''
    },
    // 清除
    clearable: {
      type: Boolean,
      default: true
    },
    // 是否禁用
    disabled: {
      type: Boolean,
      default: false
    },
    filterable: {
      type: Boolean,
      default: true
    },
    // 远程检索
    remote: {
      type: Boolean,
      default: false
    },
    // 是否使用缓存
    islocal: {
      type: Boolean,
      default: true
    },
    value: {
      default: ''
    }
  },
  watch: {
    value: function (n, o) {
      this.model = n
      // 当前绑定值填充到数据源中
      var modelItem = this.options.filter(item => {
        return item.Key === n
      })
      if (modelItem.length === 0) {
        // 获取最新数据源
        if (this.islocal) {
          var list = JSON.parse(sessionStorage.getItem(this.type))
          list.forEach((value, index) => {
            if (value.Key === n) {
              this.options = [value, ...this.options]
            }
          })
        } else {
          var _this = this
          CommonApi.GetMedSelectDict({
            DictType: _this.type,
            Key: n,
            Romote: _this.remote,
            DictObjStrings: _this.DictObjStrings
          })
            .then(response => {
              let currentItem = response.data.Data
              // var itemOptions = []
              // currentItem.forEach((value, index) => {
              //   if (value.Key === n) {
              //     itemOptions.push(value)
              //   }
              // })
              _this.options = currentItem.concat(_this.options)
            })
            .catch(error => {
              console.log(error)
            })
        }
      }
    }
  },
  methods: {
    SetChange (val) {
      if (this.model === '') {
        this.GetSqlData(this.model)
      }
      this.$emit('input', this.model)
      var tmp = this.options.find(x => x.Key === this.model)
      this.$emit('GetDiaplayValue', tmp)
    },
    GetData (query) {
      this.options = [{ Key: '', Value: '' }]
      if (this.type === 'DiyDict') {
        this.options = this.customdata
      } else {
        if (this.islocal) {
          // 使用缓存
          if (sessionStorage.getItem(this.type) === null) {
            var _THIS = this
            CommonApi.GetMedSelectDict({
              DictType: _THIS.type,
              Key: '',
              Romote: _THIS.remote,
              IsLocal: _THIS.islocal,
              DictObjStrings: _THIS.condition
            })
              .then(response => {
                var result = response.data.Data
                var options = []
                // if (result.lenght > 50) {
                //   var modelitem = result.filter(item => {
                //     return (item.Key = _THIS.model)
                //   })
                //   options.push(modelitem)
                // }
                result.forEach(function (value, index) {
                  if (index < 50) {
                    options.push(value)
                  }
                })
                _THIS.options = options
                sessionStorage.setItem(
                  _THIS.type,
                  JSON.stringify(response.data.Data)
                )
              })
              .catch(error => {
                console.log(error)
              })
          } else {
            this.GetStorageData('')
          }
        } else {
          // 直连数据库
          this.GetSqlData('')
        }
      }
    },
    GetSqlData (key) {
      var _THIS = this
      CommonApi.GetMedSelectDict({
        DictType: _THIS.type,
        Key: key,
        Romote: _THIS.remote,
        DictObjStrings: _THIS.DictObjStrings
      })
        .then(response => {
          _THIS.options = response.data.Data
        })
        .catch(error => {
          console.log(error)
        })
    },

    GetStorageData (key) {
      var list = JSON.parse(sessionStorage.getItem(this.type))
      //  / this.options

      var result = list.filter(item => {
        return (
          (item.InputCode
            ? item.InputCode.toUpperCase().indexOf(key.toUpperCase()) > -1
            : false) ||
          item.Key.toUpperCase().indexOf(key.toUpperCase()) > -1 ||
          item.Value.toUpperCase().indexOf(key.toUpperCase()) > -1
        )
      })
      var options = []
      result.forEach(function (value, index) {
        if (index < 50) {
          options.push(value)
        }
      })
      this.options = options
    },
    remoteMethod (query) {
      if (this.islocal) {
        if (query !== '') {
          this.GetStorageData(query)
        }
      } else {
        this.GetSqlData(query)
      }
    },
    clear () {
      this.GetSqlData('')
    }
  },
  created: function () {
    this.model = this.value
    this.GetData()
  }
}
