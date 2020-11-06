<template>
  <div class="infoMain">
    <div class="PatientInfoMain">
      <HorizontalBasicInfo></HorizontalBasicInfo>
      <div>
        <el-tabs v-model="activeName">
          <el-tab-pane label="检验信息" name="first">
            <AssayReport
              v-bind:inWidth="osmainWith-leftWidth"
              v-bind:inHeight="osmainHeight - 90"
              :style="{width:(osmainWith-leftWidth) + 'px',height:(osmainHeight - 70) + 'px'}"
            ></AssayReport>
          </el-tab-pane>
          <el-tab-pane label="麻醉文书" name="second">
            <AnesDocument
              v-bind:inWidth="osmainWith-leftWidth"
              v-bind:inHeight="osmainHeight - 90"
              :style="{width:(osmainWith-leftWidth) + 'px',height:(osmainHeight - 80) + 'px'}"
            ></AnesDocument>
          </el-tab-pane>
        </el-tabs>
      </div>
    </div>
    <div class="PatientInfoVertivalMain">
      <VerticalBasicInfo></VerticalBasicInfo>
      <div>
        <el-tabs v-model="activeName">
          <el-tab-pane label="检验信息" name="first">
            <AssayReport
              v-bind:inWidth="osmainWith-15"
              v-bind:inHeight="osmainHeight - 90"
              :style="{width:(osmainWith-15) + 'px',height:(osmainHeight - 70) + 'px'}"
            ></AssayReport>
          </el-tab-pane>
          <el-tab-pane label="麻醉文书" name="second">
            <AnesDocument
              v-bind:inWidth="osmainWith-15"
              v-bind:inHeight="osmainHeight - 90"
              :style="{width:(osmainWith-15) + 'px',height:(osmainHeight - 80) + 'px'}"
            ></AnesDocument>
          </el-tab-pane>
        </el-tabs>
      </div>
    </div>
  </div>
</template>

<script>
import PatientInfo from './PatientInfo.js'
export default PatientInfo
</script>
<style lang="scss" scoped>
@import "@/assets/styles/global.scss";
@media screen and (min-aspect-ratio: 1001/1000) {
  //横版
  .infoMain {
    .PatientInfoVertivalMain {
      display: none;
    }
  }
}

@media screen and (max-aspect-ratio: 1000/1000) {
  //竖版
  .infoMain {
    .PatientInfoMain {
      display: none;
    }
  }
}
.PatientInfoMain {
  width: 100%;
  height: 100%;
  display: flex;
}
.PatientInfoVertivalMain {
  width: 100%;
  height: 100%;
  display: flex;
  flex-direction: column;
}
</style>
<style>
.infoMain .info2 .el-checkbox {
  color: rgba(255, 255, 255, 1);
}
.infoMain .el-tabs__item {
  height: 60px;
  line-height: 60px;
  font-size: 18px;
  padding-left: 40px;
  padding-right: 40px;
}
.infoMain .el-tabs__header {
  margin-left: 50px;
}
</style>
