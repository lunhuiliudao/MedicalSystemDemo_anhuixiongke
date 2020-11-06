import CommonApi from '@/api/CommonApi.js'
export default {
  name: 'InputSelect',
  data () {
    return {
      options: [{ Key: '', Value: '' }],
      model: this.value,
      selectArry: []
    }
  },
  props: {
    // 组件数据类型
    type: {
      type: String,
      default: ''
    },
    // 提示语
    placeholder: {
      type: String,
      default: ''
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
    // 是否禁用
    disabled: {
      type: Boolean,
      default: false
    },
    // 清除
    clearable: {
      type: Boolean,
      default: true
    },
    ismultiple: {
      // 是否多选，默认多选
      type: Boolean,
      default: false
    },
    splitKey: {
      type: String,
      default: '+'
    },
    replaceKeys: {
      type: String,
      default: '＋,﹢,﹢'
    },
    showKey: {
      type: String,
      default: '+'
    },
    value: {
      default: ''
    }
  },
  watch: {
    value: function (n, o) {
      this.model = n
    }
  },
  methods: {
    SetChange (val) {
      if (this.ismultiple) {
        var queryStringArray = this.model.split(this.splitKey)
        this.selectArry = queryStringArray
      }
      this.$emit('input', this.model)
    },
    GetData (query) {
      this.options = [{ Key: '', Value: '' }]
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
    },
    GetSqlData (key) {
      var _THIS = this
      CommonApi.GetMedSelectDict({
        DictType: _THIS.type,
        Key: key,
        Romote: _THIS.remote,
        DictObjStrings: ''
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
      if (key === '') {
        result = list
      }
      var options = []
      result.forEach(function (value, index) {
        if (index < 50) {
          options.push(value)
        }
      })
      this.options = options
    },
    querySearchAsync (queryString, cb) {
      if (this.ismultiple) {
        if (
          queryString !== '' &&
          queryString !== null &&
          queryString !== undefined
        ) {
          if (
            this.replaceKeys !== '' &&
            this.replaceKeys !== null &&
            this.replaceKeys !== undefined
          ) {
            this.replaceKeys.split(',').forEach(element => {
              queryString = queryString.replace(element, this.splitKey)
            })
          }

          var queryStringArray = queryString.split(this.splitKey)
          this.selectArry = queryStringArray
          queryString = queryStringArray[queryStringArray.length - 1].trim()
        } else {
          queryString = ''
          this.selectArry = []
        }
      } else {
        if (
          queryString !== '' &&
          queryString !== null &&
          queryString !== undefined
        ) {
          queryString = queryString.trim()
        } else {
          queryString = ''
        }
      }
      if (this.islocal) {
        this.GetStorageData(queryString)
      } else {
        this.GetSqlData(queryString)
      }
      clearTimeout(this.timeout)
      this.timeout = setTimeout(() => {
        cb(this.options)
      }, 500 * Math.random())
    },
    clear () {
      this.GetSqlData('')
    },
    handleSelect (item) {
      if (this.ismultiple) {
        // 多选处理
        var sacount = this.selectArry.length
        if (this.selectArry.length > 0) {
          this.selectArry.splice(sacount - 1, 1)
          this.selectArry.push(item.Key)
          this.model = this.selectArry.join('+')
        }
      }
      this.$emit('input', this.model)
    }
  },
  created: function () {
    this.GetData()
  }
}
