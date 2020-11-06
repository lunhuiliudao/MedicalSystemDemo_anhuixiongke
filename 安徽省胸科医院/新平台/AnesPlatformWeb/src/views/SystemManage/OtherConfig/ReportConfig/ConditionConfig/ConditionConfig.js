export default {
  name: 'ConditionConfig',
  data () {
    return {
      rules: {
        Title: [{ required: true, message: '请输入标题', trigger: 'blur' }],
        FieldName: [
          { required: true, message: '请输入字段名', trigger: 'blur' }
        ],
        DataType: [
          {
            validator: (rule, value, callback) => {
              if (
                this.ReportCondition.ControlType === 'DatePick' &&
                value !== 'DateTime'
              ) {
                callback(new Error('请选择DateTime类型'))
              } else {
                callback()
              }
            },
            trigger: 'change'
          }
        ],
        DateControlType: [
          {
            validator: (rule, value, callback) => {
              if (this.ReportCondition.ControlType === 'DateTimePick') {
                this.ReportCondition.DateControlType = 'datetime'
              } else {
                callback()
              }
            },
            trigger: 'change'
          }
        ],
        ControlType: [
          {
            validator: (rule, value, callback) => {
              if (value !== 'DatePick' && this.ReportCondition.DataType === 'DateTime') {
                callback(new Error('请选择DatePick类型'))
              } else {
                callback()
              }
            },
            trigger: 'change'
          }
        ],
        DictType: [
          {
            validator: (rule, value, callback) => {
              if (
                value === 'DynamicDict' &&
                this.ReportCondition.ControlType === 'DropDownList' &&
                (this.ReportCondition.DynamicDictDes.TableName === '' ||
                  this.ReportCondition.DynamicDictDes.KeyColumn === '' ||
                  this.ReportCondition.DynamicDictDes.ValColumn === '')
              ) {
                callback(new Error('请填写“表名”、“值”、“显示文本”'))
              } else {
                callback()
              }
            },
            trigger: 'change'
          }
        ]
      }
    }
  },
  props: ['ReportCondition'],
  methods: {
    addBindDict: function () {
      this.ReportCondition.BindDict.push({ Key: '', Value: '' })
    },
    deleteBindDict: function (index) {
      this.ReportCondition.BindDict.splice(index, 1)
    }
  }
}
