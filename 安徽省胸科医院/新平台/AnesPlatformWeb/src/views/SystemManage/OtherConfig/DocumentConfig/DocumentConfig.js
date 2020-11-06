import OtherConfigApi from '@/api/OtherConfigApi.js'

export default {
  name: 'DocumentConfig',
  data () {
    const generatDocs = _ => {
      const docs = this.webconfig.DocumentList
      return docs
    }
    const generatMenus = _ => {
      const docs = this.webconfig.MenuList
      return docs
    }
    const generateDocData = _ => {
      const data = []
      const docs = generatDocs()
      for (let i = 0; i < docs.length; i++) {
        data.push({
          key: docs[i],
          label: docs[i]
        })
      }
      return data
    }
    const generateMenuData = _ => {
      const data = []
      const docs = generatMenus()
      for (let i = 0; i < docs.length; i++) {
        data.push({
          key: docs[i],
          label: docs[i]
        })
      }
      return data
    }
    return {
      allDocs: generatDocs(),
      allMenus: generatMenus(),
      rdoOperStatus: 1,
      checkList: [],
      checkMenuList: [],
      data: generateDocData(),
      menudata: generateMenuData(),
      titles: ['未选文书', '已选文书'],
      Menutitles: ['未选功能', '已选功能']
    }
  },
  methods: {
    OperStatusChange () {
      var _this = this
      // this.$ajax
      //   .get('/Api/PlatformSysConfig/GetMedConfig', {
      //     params: {
      //       key: _this.rdoOperStatus
      //     }
      //   })
      OtherConfigApi.GetMedConfig({
        key: _this.rdoOperStatus
      })
        .then(function (respose) {
          _this.checkList = respose.data.Data
        })
        .catch(error => {
          console.log(error)
        })
      // this.$ajax
      //   .get('/Api/PlatformSysConfig/GetMedConfig', {
      //     params: {
      //       key: _this.rdoOperStatus + 3
      //     }
      //   })
      OtherConfigApi.GetMedConfig({
        key: _this.rdoOperStatus + 3
      })
        .then(function (respose) {
          _this.checkMenuList = respose.data.Data
        })
        .catch(error => {
          console.log(error)
        })
    },
    SaveConfig () {
      var _this = this
      if (_this.checkList.length === 0) {
        _this.$message({ message: '请勾选配置项！', type: 'warning' })
        return
      }
      // this.$ajax
      //   .post('/Api/PlatformSysConfig/ModifyConfigTable', {
      //     KeyStr: _this.rdoOperStatus,
      //     ValueStr: _this.checkList
      //   })
      OtherConfigApi.ModifyConfigTable({
        KeyStr: _this.rdoOperStatus,
        ValueStr: _this.checkList
      })
        .then(function (respose) {
          if (respose.data.Data === 1) {
            _this.$message({ message: '保存配置成功！', type: 'success' })
          } else {
            _this.$message.error('保存失败，请稍后再试！')
          }
        })
        .catch(function (error) {
          console.log(error)
        })
    },
    SaveMenuConfig () {
      var _this = this
      if (_this.checkMenuList.length === 0) {
        _this.$message({ message: '请勾选配置项！', type: 'warning' })
        return
      }
      // this.$ajax
      //   .post('/Api/PlatformSysConfig/ModifyConfigTable', {
      //     KeyStr: _this.rdoOperStatus + 3,
      //     ValueStr: _this.checkMenuList
      //   })
      OtherConfigApi.ModifyConfigTable({
        KeyStr: _this.rdoOperStatus + 3,
        ValueStr: _this.checkMenuList
      })
        .then(function (respose) {
          if (respose.data.Data === 1) {
            _this.$message({ message: '保存配置成功！', type: 'success' })
          } else {
            _this.$message.error('保存失败，请稍后再试！')
          }
        })
        .catch(function (error) {
          console.log(error)
        })
    },
    Save () {
      var _this = this
      if (_this.checkList.length === 0) {
        _this.$message({ message: '请勾选文书配置项！', type: 'warning' })
        return
      }
      if (_this.checkMenuList.length === 0) {
        _this.$message({ message: '请勾选功能配置项！', type: 'warning' })
        return
      }
      this.SaveConfig()
      this.SaveMenuConfig()
    }
  },
  created: function () {
    this.OperStatusChange()
  }
}
