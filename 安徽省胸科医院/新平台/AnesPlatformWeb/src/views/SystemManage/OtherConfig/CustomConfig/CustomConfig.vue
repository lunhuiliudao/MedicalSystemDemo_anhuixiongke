<template>
  <div class="customconfig-wrapper">
    <el-tabs type="border-card">
      <el-tab-pane label="基础报表配置">
        <reportconfig ref="reportconfig"></reportconfig>
      </el-tab-pane>
      <el-tab-pane label="自定义报表配置">
        <qualityConfig></qualityConfig>
      </el-tab-pane>
    </el-tabs>
  </div>
</template>

<script>
import reportconfig from '../ReportConfig/ReportConfig/ReportConfig.vue'
import qualityConfig from '../QualityControlConfig/QualityControlConfig.vue'
export default {
  components: { reportconfig, qualityConfig },
  beforeRouteLeave (to, from, next) {
    var title = this.$refs.reportconfig.reportInformation.ReportTitle.ReportName
    if (this.$refs.reportconfig.isChange && title !== '') {
      const answer = window.confirm('数据修改未保存!! 确定离开么 ?')
      if (answer) {
        next()
      } else {
        next(false)
      }
    } else {
      next()
    }
  }
}
</script>

<style lang="scss" scoped>
.customconfig-wrapper {
  margin-top: 5px;
}
</style>
