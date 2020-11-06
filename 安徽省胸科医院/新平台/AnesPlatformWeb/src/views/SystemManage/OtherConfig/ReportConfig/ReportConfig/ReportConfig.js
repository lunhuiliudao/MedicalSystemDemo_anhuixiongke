import AnesReportApi from '@/api/AnesReportApi.js'
import ConditionConfig from '../ConditionConfig/ConditionConfig.vue'
import ColumnConfig from '../ColumnConfig/ColumnConfig.vue'

export default {
  name: 'ReportConfig',
  data () {
    return {
      userInfo: this.$store.getters.user,
      navMenu: [],
      selectReport: [],
      selectSubReport: '',
      cascaderProps: {
        label: 'Key',
        value: 'Key',
        children: 'listItem'
      },
      MainReportInformation: this.createReportInfo(),
      isSubReport: false,
      reportInformation: this.createReportInfo(),
      rulesReportTitle: {
        ReportName: [
          { required: true, message: '请输入报表名称', trigger: 'blur' }
        ],
        Menu: [
          {
            validator: (rule, value, callback) => {
              if (this.isSubReport === false && value === '') {
                callback(new Error('请选择所属菜单'))
              } else {
                callback()
              }
            },
            trigger: 'change'
          }
        ],
        StrSql: [{ required: true, message: '请输入查询SQL', trigger: 'blur' }]
      },
      dialogConditionVisible: false,
      ReportCondition: {},
      EditCondition: false,
      EditConditionIndex: 0,
      dialogtColumnVisible: false,
      ReportColumn: {},
      EditColumn: false,
      EditColumnParent: {},
      defaultProps: {
        children: 'ReportColumnList',
        label: 'Title'
      },
      // 导出模板
      execleOptions: [{ Key: '', Value: '' }],
      isChange: false, // 页面内容是否改变
      ischangeReport: false, // 是否changeReport方法
      updateCount: 0,
      tempNum: 0
    }
  },
  computed: {
    comReportColumnList: function () {
      let temparry = []
      this.reportInformation.ReportColumnList.forEach(function (element) {
        if (element.ReportColumnList.length === 0) {
          temparry.push({ key: element.FieldName, value: element.Title })
        } else {
          for (
            var index = 0;
            index < element.ReportColumnList.length;
            index++
          ) {
            temparry.push({
              key: element.ReportColumnList[index].FieldName,
              value:
                element.Title + '——' + element.ReportColumnList[index].Title
            })
          }
        }
      }, this)
      return temparry
    },
    comParentReportColumnList: function () {
      let temparry = []
      this.MainReportInformation.ReportColumnList.forEach(function (element) {
        if (element.ReportColumnList.length === 0) {
          temparry.push({ key: element.FieldName, value: element.Title })
        } else {
          for (
            var index = 0;
            index < element.ReportColumnList.length;
            index++
          ) {
            temparry.push({
              key: element.ReportColumnList[index].FieldName,
              value:
                element.Title + '——' + element.ReportColumnList[index].Title
            })
          }
        }
      }, this)
      return temparry
    }
  },
  components: { ConditionConfig, ColumnConfig },
  // 路由跳转添加监视
  watch: {
    reportInformation: {
      handler: function () {
        if (this.ischangeReport) {
          this.ischangeReport = false
        } else {
          this.isChange = true
        }
      },
      deep: true
    }
  },
  updated: function () {
    this.updateCount = this.updateCount + 1
  },
  methods: {
    comStatisticsMenu () {
      let tempMenu = []
      let rccxmenu = this.userInfo.MenuList.find(x => { return x.name === '日常查询' }).childMenuList
      rccxmenu.forEach(element => {
        tempMenu.push({ Key: element.name, 'listItem': [] })
      })
      tempMenu.push({ Key: '质控数据统计', 'listItem': [] })
      return tempMenu
    },
    getReportConfig: function () {
      this.navMenu = this.comStatisticsMenu()
      AnesReportApi.getReportConfig().then((respose) => {
        let tempData = respose.data.Data
        for (let index = 0; index < tempData.length; index++) {
          var element = tempData[index]
          for (let indexMenu = 0; indexMenu < this.navMenu.length; indexMenu++) {
            var elementMenu = this.navMenu[indexMenu]
            if (element.Value === elementMenu.Key) {
              elementMenu.listItem.push(element)
              break
            }
          }
        }
      }).catch(error => {
        console.log(error)
      })
    },
    changeReport: function (val) {
      console.log(val)
      this.isSubReport = false
      this.selectSubReport = ''
      if (val.length > 0) {
        AnesReportApi.getReportConfigByKey({ reportKey: val[val.length - 1], clearSql: false }).then((respose) => {
          this.reportInformation = respose.data.Data
          this.MainReportInformation = JSON.parse(JSON.stringify(this.reportInformation))
          this.$refs.selectExeclM.selectedLabel = this.reportInformation.ReportTitle.ModelFileName
          this.isChange = false
          this.ischangeReport = true
          this.tempNum = this.updateCount
        }).catch(error => {
          console.log(error)
        })
      } else {
        this.reportInformation = this.createReportInfo()
      }
    },
    changeSubReport: function (val) {
      if (val !== '') {
        this.isSubReport = true
        let tempobj = this.MainReportInformation.SubReportInformationList.find(r => r.ReportTitle.ReportName === val)
        this.reportInformation = JSON.parse(JSON.stringify(tempobj))
        AnesReportApi.getSubReportSQL({ key: val, type: 1 }, this.MainReportInformation).then((respose) => {
          this.reportInformation.ReportTitle.StrSql = respose.data.Data
        }).catch(error => {
          console.log(error)
        })
      } else {
        this.reportInformation = this.createReportInfo()
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
          PageSize: 10,
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
    createReportCondition () {
      return {
        Title: '',
        ControlType: 'TextBox',
        FieldName: '',
        DataType: 'String',
        DictType: 'NurseDict',
        BindDict: [],
        DynamicDictDes: {
          TableName: '',
          KeyColumn: '',
          ValColumn: '',
          Condition: ''
        },
        DateControlType: 'date',
        DateDefaultVal: 'CurrentDate',
        Value: ''
      }
    },
    showDialogCondition (index, row) {
      if (row == null) {
        this.ReportCondition = this.createReportCondition()
        this.EditCondition = false
      } else {
        this.EditConditionIndex = index
        this.ReportCondition = this.createReportCondition()
        Object.assign(this.ReportCondition, row)
        this.EditCondition = true
      }
      this.dialogConditionVisible = true
    },
    saveReportCondition () {
      this.$refs.ConditionConfig.$refs.formConditionConfig.validate(valid => {
        if (valid) {
          if (this.EditCondition === false) {
            this.reportInformation.ReportConditionList.push(
              this.ReportCondition
            )
          } else {
            Object.assign(this.reportInformation.ReportConditionList[this.EditConditionIndex], this.$refs.ConditionConfig.ReportCondition)
          }
          this.dialogConditionVisible = false
        } else {
          console.log('error submit')
          return false
        }
      })
    },
    deleteReportCondition (index, row) {
      this.reportInformation.ReportConditionList.splice(index, 1)
    },
    createReportColumn () {
      return {
        FieldName: '',
        Title: '',
        Width: '',
        IsSHow: true,
        IsSort: false,
        IsSum: false,
        IsSubReportCondition: false,
        SubReportName: '',
        IsExport: true,
        Align: 'center',
        ReportColumnList: []
      }
    },
    showDialogColumn (column, row) {
      this.EditColumnParent = column
      if (row == null) {
        this.ReportColumn = this.createReportColumn()
        this.EditColumn = false
      } else {
        this.ReportColumn = this.createReportColumn()
        Object.assign(this.ReportColumn, row)
        this.EditColumn = true
      }
      this.dialogtColumnVisible = true
      setTimeout(() => {
        this.$refs.ColumnConfig.GetData()
      }, 10)
    },
    saveReportColumn () {
      this.$refs.ColumnConfig.$refs.formColumnConfig.validate(valid => {
        if (valid) {
          if (this.EditColumn === false) {
            if (this.EditColumnParent == null) {
              this.reportInformation.ReportColumnList.push(this.ReportColumn)
            } else {
              this.EditColumnParent.ReportColumnList.push(this.ReportColumn)
            }
          } else {
            Object.assign(
              this.EditColumnParent,
              this.$refs.ColumnConfig.ReportColumn
            )
          }
          this.dialogtColumnVisible = false
        } else {
          console.log('error submit')
          return false
        }
      })
    },
    appendTreeNode (store, data) {
      this.showDialogColumn(data, null)
    },
    EditTreeNode (store, data) {
      this.showDialogColumn(data, data)
    },
    removeTreeNode (store, data, node) {
      this.$confirm('确认删除该数据吗?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'info'
      }).then(() => {
        let deleteindex = -1
        if (node.level === 1) {
          deleteindex = this.reportInformation.ReportColumnList.findIndex(
            function (value, index, arr) {
              return value.Title === data.Title
            }
          )
          if (deleteindex > -1) {
            this.reportInformation.ReportColumnList.splice(deleteindex, 1)
          }
        } else {
          deleteindex = node.parent.data.ReportColumnList.findIndex(function (value, index, arr) {
            return value.Title === data.Title
          })
          if (deleteindex > -1) {
            node.parent.data.ReportColumnList.splice(deleteindex, 1)
          }
        }
      }).catch(error => {
        console.log(error)
      })
    },
    renderContent (h, { node, data, store }) {
      // + ' | 宽度：' + data.Width + ' | 对齐方式：' + data.Align + ' | 排序：' + data.IsSort + ' | 合计列：' + data.IsSum + ' | 子报表条件：' + data.IsSubReportCondition + ' | 子报表名称：' + data.SubReportName
      return h('span', { style: {
        flex: '1 1 0%',
        display: 'flex',
        'justify-content': 'space-between',
        'padding-right': '8px'
      } }, [
        h(
          'div',
          {
            style: {
              display: 'inline-block',
              width: '50%',
              'line-height': '32px'
            }
          },
          [
            h(
              'span',
              '标题：' +
                node.label +
                ' | 字段名：' +
                data.FieldName +
                ' | 显示表头：' +
                data.IsSHow +
                ' | 导出列：' +
                data.IsExport
            )
          ]
        ),
        h(
          'div',
          {
            style: {
              // 'float': 'right',
              display: 'inline-block',
              width: '45%',
              'text-align': 'right'
              // 'margin-right': '20px'
            }
          },
          [
            h(
              'el-button',
              {
                props: {
                  type: 'success',
                  size: 'small'
                },
                on: {
                  click: () => this.appendTreeNode(store, data)
                }
              },
              '添加'
            ),
            h(
              'el-button',
              {
                props: {
                  type: 'primary',
                  size: 'small'
                },
                on: {
                  click: () => this.EditTreeNode(store, data)
                }
              },
              '编辑'
            ),
            h(
              'el-button',
              {
                props: {
                  type: 'danger',
                  size: 'small'
                },
                on: {
                  click: () => this.removeTreeNode(store, data, node)
                }
              },
              '删除'
            )
          ]
        )
      ])
    },
    submitReport () {
      this.$refs.formReportTitle.validate(valid => {
        if (valid) {
          if (this.isSubReport) {
            if (this.MainReportInformation.ReportTitle.ReportName === '') {
              this.$alert('请先配置主报表', '提示', {
                confirmButtonText: '确定',
                type: 'error'
              })
              return
            } else {
              let tempObj = this.MainReportInformation.SubReportInformationList.find(r => r.ReportTitle.ReportName === this.reportInformation.ReportTitle.ReportName)
              if (typeof tempObj === 'undefined') {
                this.MainReportInformation.SubReportInformationList.push(
                  JSON.parse(JSON.stringify(this.reportInformation))
                )
              } else {
                Object.assign(tempObj, JSON.parse(JSON.stringify(this.reportInformation)))
              }
            }
          } else {
            this.MainReportInformation.ReportTitle = JSON.parse(
              JSON.stringify(this.reportInformation.ReportTitle)
            )
            this.MainReportInformation.ReportSubConditionList = JSON.parse(
              JSON.stringify(this.reportInformation.ReportSubConditionList)
            )
            this.MainReportInformation.ReportConditionList = JSON.parse(
              JSON.stringify(this.reportInformation.ReportConditionList)
            )
            this.MainReportInformation.ReportColumnList = JSON.parse(
              JSON.stringify(this.reportInformation.ReportColumnList)
            )
            this.MainReportInformation.ReportChartInfo = JSON.parse(
              JSON.stringify(this.reportInformation.ReportChartInfo)
            )
          }
          // 添加一级菜单信息
          if (this.MainReportInformation.ReportTitle.Menu !== null && this.MainReportInformation.ReportTitle.Menu !== undefined && this.MainReportInformation.ReportTitle.Menu !== '') {
            var temp = this.comStatisticsMenu().filter(r => r.Key === this.MainReportInformation.ReportTitle.Menu)
            if (temp.length > 0) {
              this.MainReportInformation.ReportTitle.ParentMenu = temp[0].Parent
            }
          }
          // 保存导出模板名称20190115
          if (this.$refs.selectExeclM.selectedLabel === '' || this.$refs.selectExeclM.selectedLabel === undefined) {
            this.MainReportInformation.ReportTitle.ModelFileName = ''
          } else {
            this.MainReportInformation.ReportTitle.ModelFileName = this.$refs.selectExeclM.selectedLabel
          }
          AnesReportApi.saveReportInformation(this.MainReportInformation).then((respose) => {
            if (respose.data.Data === '') {
              this.getReportConfig()
              this.reportInformation = this.createReportInfo()
              if (this.isSubReport) {
                this.selectSubReport = ''
              }
              this.$refs.selectExeclM.selectedLabel = ''
              this.$alert('保存成功', '提示', {
                confirmButtonText: '确定',
                type: 'success'
              })
            } else {
              this.$alert(respose.data.Data, '提示', {
                confirmButtonText: '确定',
                type: 'error'
              })
            }
          }).catch(error => {
            console.log(error)
          })
        } else {
          return false
        }
      })
    },
    clearReport () {
      this.reportInformation = this.createReportInfo()
    },
    addReportSubCondition () {
      this.reportInformation.ReportSubConditionList.push({
        FieldName: '',
        ParamName: '',
        DataType: 'String',
        Value: ''
      })
    },
    deleteReportSubCondition (index, row) {
      this.reportInformation.ReportSubConditionList.splice(index, 1)
    },
    addReportChartSeriesDataSet () {
      this.reportInformation.ReportChartInfo.SeriesData.push({
        Title: '',
        Field: ''
      })
    },
    deleteReportChartSeriesDataSet (index, row) {
      this.reportInformation.ReportChartInfo.SeriesData.splice(index, 1)
    },
    beforeUpload (file) {
      var testmsg = file.name.substring(file.name.lastIndexOf('.') + 1)
      const extension = testmsg === 'xls'
      const extension2 = testmsg === 'xlsx'
      const isLt2M = file.size / 1024 / 1024 < 5
      if (!extension && !extension2) {
        this.$message({
          message: '上传文件只能是 xls、xlsx格式!',
          type: 'warning'
        })
      }
      if (!isLt2M) {
        this.$message({
          message: '上传文件大小不能超过 5MB!',
          type: 'warning'
        })
      }
      return (extension || extension2) && isLt2M
    },
    // 加载模板
    getExceleM () {
      AnesReportApi.getAnesQueryExeclModelList().then((respose) => {
        this.execleOptions = respose.data.Data
      }).catch((error) => {
        console.log(error)
      })
    },
    // 模板选择change事件
    changeExceleM (Key) {
      this.reportInformation.ReportTitle.ModelFileName = Key
    },
    // 上传文件个数超过定义的数量
    handleExceed (files, fileList) {
      // this.$message.warning(`当前限制选择 2 个文件，请删除后继续上传`)
    },
    // 点击上传
    upLoadTemplate (item) {
      const fileObj = item.file
      var messageShow = '请确定上传--"' + item.file.name + '"--模板文件！'
      const formData = new FormData()
      formData.append('file', fileObj)
      // 确定是否上传提示
      this.$confirm(messageShow, '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning'
      }).then(() => {
        AnesReportApi.uploadExcelToAnesQueryPath(formData).then((res) => {
          if (res.data.Data === '成功上传了') {
            // 重新加载Execle模板
            this.getExceleM()
            this.$message({
              showClose: true,
              message: '上传成功!'
            })
          }
        }).catch((error) => {
          console.log(error)
        })
      }).catch(() => {})
    },
    // 模板下载
    downLoad () {
      let execlName = this.$refs.selectExeclM.selectedLabel
      if (execlName === null || execlName === undefined || execlName === '') {
        this.$alert('<strong>请先选择模板 ！</strong>', '提示', {
          dangerouslyUseHTMLString: true
        })
        return
      }
      let url = this.webconfig.apiUrl + '/Config/ExcelModel/AnesQueryExcelModel/' + execlName
      window.open(url)
    },
    // 删除模板
    iFun (name) {
      var messageShow = '请确定删除--"' + name + '"--模板文件！'
      this.$confirm(messageShow, '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning'
      }).then(() => {
        // 删除execle模板
        AnesReportApi.deleteAnesQueryExcelModele({ 'ExcelModeleName': name }).then((respose) => {
          this.getExceleM()
          this.execleOptions.Value = ''
        }).catch((error) => {
          console.log(error)
        })
      })
    },
    // 判断两个对象的属性是否相等
    isObjectValueEqual (a, b) {
      var aProps = Object.getOwnPropertyNames(a)
      var bProps = Object.getOwnPropertyNames(b)
      if (aProps.length !== bProps.length) {
        return false
      }
      for (var i = 0; i < aProps.length; i++) {
        var propName = aProps[i]
        if (a[propName] !== b[propName]) {
          if (propName === '__ob__') {
          } else {
            return false
          }
        }
      }
      return true
    }
  },
  created: function () {
    this.getReportConfig()
    this.getExceleM()
  }
}
