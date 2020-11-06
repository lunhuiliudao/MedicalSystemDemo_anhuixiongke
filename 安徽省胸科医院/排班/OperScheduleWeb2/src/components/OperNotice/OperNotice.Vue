<template>
  <el-tabs v-model="activeName" type="border-card">
    <el-tab-pane label="手术通知单" name="first">
      <NoticeList v-bind:width="onNoticeWidth" v-bind:height="onNoticeHeight"></NoticeList>
    </el-tab-pane>
    <el-tab-pane label="手术接送单" name="second">
      <PickUpList v-bind:width="onNoticeWidth" v-bind:height="onNoticeHeight"></PickUpList>
    </el-tab-pane>
  </el-tabs>
</template>

<script>
import OperNotice from './OperNotice.js'
export default OperNotice
</script>

<style>
/* .el-tabs__header {
 margin: 0px;
 background-color: white;
} */
.el-tabs--border-card>.el-tabs__content {
  padding: 0px;
}
</style>
