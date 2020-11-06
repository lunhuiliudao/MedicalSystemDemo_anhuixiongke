<template>
  <div id="app">
    <el-dialog
      width="70%"
      :close-on-click-modal="false"
      :visible.sync="hasError"
      @close="errordialogclose"
    >
      <span slot="title" class="dialog-footer">
        <span class="el-icon-error" style="color:red;"></span> 错误信息
      </span>
      <el-table :data="errorlogs">
        <el-table-column property="status" label="状态" width="100"></el-table-column>
        <el-table-column property="statusText" label="状态描述" width="200"></el-table-column>
        <el-table-column property="path" label="请求地址"></el-table-column>
        <el-table-column label="错误">
          <template slot="header" slot-scope="scope">
            <span style="color:red;font-weight:bold;">{{scope.column.label}}</span>
          </template>
          <template slot-scope="scope">{{scope.row.message}}</template>
        </el-table-column>
      </el-table>
    </el-dialog>
    <router-view/>
  </div>
</template>

<script>
import commonfun from '@/utils/commonfun.js'
document.addEventListener('DOMContentLoaded', () => {
  const html = document.querySelector('html')
  let val = window.innerWidth > window.innerHeight ? window.innerWidth : window.innerHeight
  let fontsize = val / 100
  if (commonfun.getBrowser() !== 'Chrome') {
    fontsize = fontsize > 14 ? fontsize : 14
  }
  html.style.fontSize = (fontsize > 20 ? 20 : fontsize) + 'px'
})

export default {
  name: 'App',
  computed: {
    errorlogs () {
      return this.$store.state.errorLog.logs
    },
    hasError: {
      get: function () {
        return this.$store.state.errorLog.logs.length > 0
      },
      set: function (newValue) {}
    }
  },
  methods: {
    errordialogclose () {
      this.$store.dispatch('deleteErrorLog')
    }
  }
}
</script>

<style lang="scss">
#app {
  width: 100%;
  height: 100%;
  background: #f5f9fb;
}
</style>
