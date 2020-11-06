import AnesReportApi from '@/api/AnesReportApi.js'

export default {
  name: 'ColumnConfig',
  data () {
    return {
      rules: {
        Title: [{ required: true, message: '请输入标题', trigger: 'blur' }],
        FieldName: [
          { required: true, message: '请输入字段名', trigger: 'blur' }
        ],
        SubReportName: [
          {
            validator: (rule, value, callback) => {
              if (
                this.ReportColumn.IsSubReportCondition === true &&
                value === ''
              ) {
                callback(new Error('请选择子报表'))
              } else {
                callback()
              }
            },
            trigger: 'change'
          }
        ]
      },
      dataList: [],
      showSelect: ''
    }
  },
  props: {
    ReportColumn: {},
    SubReportInformationList: {
      type: Array
    },
    reportInformation: {
      SubReportInformationList: [],
      ReportColumnList: [],
      ReportConditionList: [],
      ReportSubConditionList: [],
      ReportTitle: {
        ParentMenu: '',
        ReportName: '',
        Menu: '',
        SortNumber: 0,
        PageSize: 0,
        ModelFileName: '',
        StrSql: '',
        ShowSummary: false
      },
      ReportChartInfo: {
        ChartType: '',
        SeriesData: [],
        XAxisInfo: { Type: 'value', DataColumn: '', Data: [] },
        YAxisInfo: { Type: 'value', DataColumn: '', Data: [] }
      }
    },
    isSubReport: Boolean,
    pkey: String
  },
  methods: {
    GetData () {
      if (this.reportInformation.ReportTitle.StrSql === '' || this.reportInformation.ReportTitle.StrSql === null) {
        this.dataList = []
      } else {
        AnesReportApi.getReportColumList({ 'pkey': this.pkey, 'isSubReport': this.isSubReport }, this.reportInformation).then((respose) => {
          if (respose.data.Data === null || respose.data.Data === undefined) {
            this.dataList = []
          } else {
            this.dataList = respose.data.Data
          }
        }).catch(error => {
          console.log(error)
        })
      }
    },
    createReportInfo () {
      return {
        SubReportInformationList: [],
        ReportColumnList: [],
        ReportConditionList: [],
        ReportSubConditionList: [],
        ReportTitle: {
          ParentMenu: '',
          ReportName: '',
          Menu: '',
          SortNumber: 0,
          PageSize: 0,
          ModelFileName: '',
          StrSql: '',
          ShowSummary: false
        },
        ReportChartInfo: {
          ChartType: '',
          SeriesData: [],
          XAxisInfo: { Type: 'value', DataColumn: '', Data: [] },
          YAxisInfo: { Type: 'value', DataColumn: '', Data: [] }
        }
      }
    },
    changeSelect (selectData) {
      this.ReportColumn.FieldName = selectData
    }
  },
  created: function () {
    this.GetData()
    console.log('data')
    console.log(this.reportInformation)
  }
}
