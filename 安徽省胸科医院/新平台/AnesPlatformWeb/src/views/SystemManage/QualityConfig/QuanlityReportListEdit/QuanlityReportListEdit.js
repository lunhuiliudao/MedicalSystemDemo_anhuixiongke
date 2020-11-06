import QualityConfigApi from '@/api/QualityConfigApi.js'

export default {
  name: 'QuanlityReportListEdit',
  data () {
    return {
      loading: false,
      tableData: [],
      formData: this.newData(),
      rules: {
        REPORT_NO: [
          { required: true, message: '请输入报表编号', trigger: 'blur' }
        ],
        REPORT_NAME: [
          { required: true, message: '请输入项目名称', trigger: 'blur' }
        ]
      },
      dialogEditVisible: false,
      dialogEditTitle: '新增',
      wayType: 0, // 弹出窗口类型，0-新增，1-修改
      options: []
    }
  },
  created () {
    this.searchQcDict()
    this.searchInfos()
  },
  methods: {
    newData () {
      return {
        REPORT_NO: '',
        REPORT_NAME: '',
        NMRTR_CODE: '',
        NMRTR_EDIT_MARK: 0,
        DNMTR_CODE: '',
        DNMTR_EDIT_MARK: 0,
        GROUP_NO: 0,
        FATHER_CHILD: 1,
        DESCRIBE: '',
        UNIT: ''
      }
    },
    // 查询质控项目字典数据
    searchQcDict () {
      var _THIS = this
      QualityConfigApi.GetQuanlityControlItemList()
        .then(function (respose) {
          var data = respose.data.Data
          _THIS.options = data
        })
        .catch(error => {
          console.log(error)
        })
    },
    // 查询数据
    searchInfos () {
      var _THIS = this
      QualityConfigApi.GetQuanlityControlReportList()
        .then(function (respose) {
          var data = respose.data.Data
          _THIS.tableData = data
        })
        .catch(error => {
          console.log(error)
        })
    },
    addData () {
      if (this.$refs['formView'] !== undefined) {
        this.$refs['formView'].resetFields()
      }
      var _THIS = this
      Object.assign(this.formData, _THIS.newData())
      _THIS.dialogEditTitle = '新增'
      _THIS.dialogEditVisible = true
      _THIS.wayType = 0
    },
    editData (index, row) {
      if (this.$refs['formView'] !== undefined) {
        this.$refs['formView'].resetFields()
      }
      this.dialogEditTitle = '编辑'
      this.wayType = 1
      // console.log(row)
      // this.formData = JSON.parse(JSON.stringify(row))
      Object.assign(this.formData, row)
      this.dialogEditVisible = true
    },
    deleteData (index, row) {
      this.$confirm('确认删除该数据吗?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'info'
      })
        .then(() => {
          var _THIS = this
          var medQuanlityReportList = []
          medQuanlityReportList.push(row)

          QualityConfigApi.DeletedQuanlityControlReportList(
            medQuanlityReportList
          )
            .then(function (respose) {
              if (respose.data.Data > 0) {
                _THIS.searchInfos()
                _THIS.$message({
                  message: '删除成功',
                  type: 'success'
                })
              } else {
                _THIS.$message({
                  message: '删除失败',
                  type: 'warning'
                })
              }
            })
            .catch(error => {
              console.log(error)
            })
        })
        .catch(error => {
          console.log(error)
        })
    },
    onSubmit (formName) {
      this.$refs[formName].validate(valid => {
        if (valid) {
          var _THIS = this
          console.log(_THIS.formData)

          QualityConfigApi.EditQuanlityControlReportList(
            _THIS.wayType,
            _THIS.formData
          )
            .then(function (respose) {
              if (respose.data.Data === 2) {
                _THIS.$message.error('该条目已存在')
              } else if (respose.data.Data === 1) {
                _THIS.dialogEditVisible = false
                _THIS.searchInfos()
                _THIS.$message({
                  message: '保存成功',
                  type: 'success'
                })
              }
            })
            .catch(error => {
              console.log(error)
            })
        } else {
          console.log('error submit')
          return false
        }
      })
    }
  }
}
