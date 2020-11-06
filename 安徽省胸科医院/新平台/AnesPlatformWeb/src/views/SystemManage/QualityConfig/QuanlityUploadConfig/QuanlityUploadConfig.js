import QualityConfigApi from '@/api/QualityConfigApi.js'

export default {
  name: 'QuanlityUploadConfig',
  data () {
    return {
      loading: false,
      tableData: [],
      formData: this.newData(),
      rules: {
        Key: [
          {
            required: true,
            message: '请输入质控平台级别定义主键',
            trigger: 'blur'
          }
        ],
        KeyName: [
          {
            required: true,
            message: '请输入质控平台级别定义名称',
            trigger: 'blur'
          }
        ],
        Value: [
          { required: true, message: '请输入适配值定义主键', trigger: 'blur' }
        ],
        ValueName: [
          { required: true, message: '请输入适配值定义名称', trigger: 'blur' }
        ]
      },
      dialogEditVisible: false,
      dialogEditTitle: '新增',
      wayType: 0, // 弹出窗口类型，0-新增，1-修改
      selected: '',
      groupNameList: []
    }
  },
  created () {
    this.loadGroupName()
  },
  methods: {
    newData () {
      return {
        Key: '',
        KeyName: '',
        Value: '',
        ValueName: ''
      }
    },
    loadGroupName () {
      var _THIS = this
      // this.$ajax
      //   .get('/Api/PlatformQuanlityControl/GetXmlDataForQCNoByName')
      QualityConfigApi.GetXmlDataForQCNoByName()
        .then(function (respose) {
          _THIS.groupNameList = respose.data.Data
        })
        .catch(error => {
          console.log(error)
        })
    },
    // 查询数据
    searchInfos () {
      var _THIS = this
      // this.$ajax
      //   .get('/Api/PlatformQuanlityControl/GetXmlDataForQC', {
      //     params: {
      //       groupName: this.selected
      //     }
      //   })
      QualityConfigApi.GetXmlDataForQC({
        groupName: this.selected === null ? '' : this.selected
      })
        .then(function (respose) {
          _THIS.tableData = respose.data.Data
        })
        .catch(error => {
          console.log(error)
        })
    },
    // 新增数据
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
    // 编辑数据
    editData (index, row) {
      if (this.$refs['formView'] !== undefined) {
        this.$refs['formView'].resetFields()
      }
      this.dialogEditTitle = '编辑'
      this.wayType = 1
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
          var medQuanlityQcData = []
          medQuanlityQcData.push(row)
          // this.$ajax
          //   .post('/Api/PlatformQuanlityControl/DeletedXmlDataForQC', {
          //     groupName: this.selected,
          //     xmlData: row
          //   })
          QualityConfigApi.DeletedXmlDataForQC({
            groupName: this.selected,
            xmlData: row
          })
            .then(function (respose) {
              console.log(respose.data.Data)
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
    // 保存信息
    saveInfos () {
      var _THIS = this
      // this.$ajax
      //   .post('/Api/PlatformQuanlityControl/SaveXmlDataForQC', {
      //     groupName: this.selected,
      //     xmlData: _THIS.formData
      //   })
      if (this.selected !== null && this.selected !== '') {
        QualityConfigApi.SaveXmlDataForQC({
          groupName: this.selected,
          xmlData: _THIS.formData
        }).then(function (response) {
          if (response.data.Data === 0) {
            _THIS.$message({
              message: '保存失败',
              type: 'warning'
            })
          } else if (response.data.Data > 0) {
            _THIS.$message({
              message: '保存成功',
              type: 'success'
            })
            _THIS.searchInfos()
            _THIS.dialogEditVisible = false
          }
        })
      } else {
        _THIS.$message({
          message: '请选择新增分类',
          type: 'warning'
        })
      }
    }
  }
}
