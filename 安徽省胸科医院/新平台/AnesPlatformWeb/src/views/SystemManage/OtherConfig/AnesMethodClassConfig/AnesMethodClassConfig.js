import OtherConfigApi from '@/api/OtherConfigApi.js'

export default {
  name: 'AnesMethodClassConfig',
  data () {
    return {
      ConfigList: [],
      defaultProps: {
        children: 'children',
        label: 'label'
      },
      dialogVisible: false,
      dialogHasSelect: false,
      dialogIsSwitch: true,
      dialogSelectOptions: [],
      formData: this.newData()
    }
  },
  methods: {
    newData: function () {
      return {
        ITEM_ID: 0,
        ITEM_PARENTID: 0,
        ITEM_VALUE: '',
        ITEM_TYPE: '',
        TEMP_ITEM_VALUE: []
      }
    },
    saveReportColumn: function () {
      if (
        (this.dialogHasSelect === true &&
          this.formData.TEMP_ITEM_VALUE.length === 0) ||
        (this.dialogHasSelect === false && this.formData.ITEM_VALUE === '')
      ) {
        this.$alert('请先填写【项目名称】', '提示', {
          confirmButtonText: '确定',
          type: 'error'
        })
        return
      }
      if (this.dialogHasSelect) {
        this.formData.ITEM_VALUE = ''
      } else {
        this.formData.TEMP_ITEM_VALUE = []
      }
      var _this = this
      // this.$ajax
      //   .post('/Api/PlatformSysConfig/AddAnesMethodClass', this.formData)
      OtherConfigApi.AddAnesMethodClass(this.formData)
        .then(function (response) {
          if (response.data.Data === '') {
            _this.dialogVisible = false
            _this.getAnesMethodClass()
            _this.$alert('保存成功', '提示', {
              confirmButtonText: '确定',
              type: 'success'
            })
          } else {
            _this.$alert(response.data.Data, '提示', {
              confirmButtonText: '确定',
              type: 'error'
            })
          }
        })
        .catch(error => {
          console.log(error)
        })
    },
    getAnesMethodClass: function () {
      var _this = this
      // this.$ajax
      //   .get('/Api/PlatformSysConfig/GetAnesMethodClass')
      OtherConfigApi.GetAnesMethodClass()
        .then(function (response) {
          var data = JSON.parse(response.data.Data)
          _this.ConfigList = data
        })
        .catch(error => {
          console.log(error)
        })
    },
    showDialog: function (data) {
      this.formData = data
      var _this = this
      if (data.ITEM_TYPE.startsWith('MZFF')) {
        _this.dialogHasSelect = true
        _this.dialogIsSwitch = false
        // this.$ajax
        //   .get('/Api/PlatformSysConfig/GetAnesMethodOptions', {
        //     params: {
        //       ITEM_PARENTID: data.ITEM_PARENTID
        //     }
        //   })
        OtherConfigApi.GetAnesMethodOptions({
          ITEM_PARENTID: data.ITEM_PARENTID
        })
          .then(function (response) {
            _this.dialogSelectOptions = response.data.Data
          })
          .catch(error => {
            console.log(error)
          })
      } else {
        _this.dialogHasSelect = false
        _this.dialogIsSwitch = true
      }
      this.dialogVisible = true
    },
    appendTreeNode: function (store, data) {
      this.showDialog({
        ITEM_ID: 0,
        ITEM_PARENTID: data.id,
        ITEM_VALUE: '',
        ITEM_TYPE: data.ITEM_TYPE,
        TEMP_ITEM_VALUE: []
      })
    },
    removeTreeNode: function (store, data) {
      var _this = this
      this.$confirm('确认删除该数据吗?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'info'
      }).then(() => {
        // _this.$ajax
        //   .get('/Api/PlatformSysConfig/DeletedAnesMethodClass', {
        //     params: {
        //       id: data.id
        //     }
        //   })
        OtherConfigApi.DeletedAnesMethodClass({
          id: data.id
        })
          .then(function (response) {
            if (response.data.Data === '') {
              _this.dialogVisible = false
              _this.getAnesMethodClass()
              _this.$alert('删除成功', '提示', {
                confirmButtonText: '确定',
                type: 'success'
              })
            } else {
              _this.$alert(response.data.Data, '提示', {
                confirmButtonText: '确定',
                type: 'error'
              })
            }
          })
          .catch(error => {
            console.log(error)
          })
      })
    },
    renderContent (h, { node, data, store }) {
      return h(
        'span',
        {
          style: {
            flex: '1 1 0%',
            display: 'flex',
            'justify-content': 'space-between',
            'padding-right': '8px'
          }
        },
        [
          h(
            'div',
            {
              style: {
                display: 'inline-block',
                width: '50%'
              }
            },
            [h('span', node.label)]
          ),
          h(
            'div',
            {
              style: {
                display: 'inline-block',
                width: '45%',
                'text-align': 'right'
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
        ]
      )
    }
  },
  created: function () {
    this.getAnesMethodClass()
  }
}
