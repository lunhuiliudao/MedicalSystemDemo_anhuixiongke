<template>
  <div class="weChatSynDiv">
    <div id="conditionView">
      <br>
      <div style="margin:10px 10px 0px;height:36px">
        <div class="conditiontitle">
          <span style="font-size:20px;font-weight:bold;">微信=></span>
          <span>同步日期：</span>
        </div>
        <div style="width:140px;float:left">
          <el-date-picker
            type="date"
            format="yyyy-MM"
            placeholder="选择日期"
            v-model="StartDate"
            :clearable="false"
            style="width:120px"
          ></el-date-picker>
        </div>
        <div style="width:140px;float:left">
          <el-date-picker
            type="date"
            format="yyyy-MM"
            placeholder="选择日期"
            v-model="EndDate"
            style="width:120px"
          ></el-date-picker>
        </div>

        <div>
          <el-button
            type="primary"
            class="weChatSynDivAdd"
            @click="SynWeChatReport()"
            style="margin-right: 10px;width:100px;"
          >同步统计</el-button>
          <el-button
            type="primary"
            class="weChatSynDivAdd"
            @click="SynWeChatQualityControl()"
            style="margin-right: 10px;width:100px;"
          >同步质控</el-button>
        </div>
      </div>
      <div style="margin:30px 10px 0px;height:36px">
        <div class="conditiontitle">
          <span style="font-size:20px;font-weight:bold;">字典转换=></span>
        </div>
        <div style="width:280px;float:left">
          <el-select style="width:260px;" v-model="selectDict" placeholder="请选择" clearable>
            <el-option
              style="font-size:14px;padding:0 5px;"
              v-for="(item ,index) in dictList"
              :key="index"
              :label="item.key"
              :value="item.key"
            >
              <span style="float: left">{{ item.key }}</span>
            </el-option>
          </el-select>
        </div>
        <div>
          <!-- <el-button type="primary" @click="QueryDictData()" style="margin-right: 10px;width:100px;">查询</el-button> -->
          <el-button
            type="primary"
            class="weChatSynDivAdd"
            @click="SaveDictData()"
            style="margin-right: 10px;width:100px;"
          >转换拼音</el-button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import WeChatSyn from './WeChatSyn.js'
export default WeChatSyn
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";

.weChatSynDiv {
  margin-top: 5px;
  padding: 10px 0px;
  background-color: #ffffff;
  font-size: 14px;
  color: #606266;
  min-height: 768px;
  .weChatSynDivAdd {
    width: 99px;
    height: 28px;
    background: rgba(61, 209, 138, 1);
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 0px 10px;
  }

  .weChatSynDivEdit {
    width: 59px;
    height: 28px;
    //background: #d0dfe6;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 5px;
  }

  .weChatSynDivDelete {
    width: 59px;
    height: 28px;
    background: #f56c6c;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 5px;
  }
}

#conditionView .conditiontitle {
  width: 180px;
  float: left;
  text-align: left;
  height: 36px;
  line-height: 36px;
  font-weight: bolder;
  margin-left: 20px;
}
</style>
<style>
.weChatSynDiv .el-input__inner {
  -webkit-appearance: none;
  background-color: #f7f7f7;
  background-image: none;
  border-radius: 4px;
  border: 1px solid #dcdfe6;
  -webkit-box-sizing: border-box;
  box-sizing: border-box;
  color: #606266;
  display: inline-block;
  height: 26px;
  line-height: 20px;
  outline: 0;
  padding: 0 35px;
  -webkit-transition: border-color 0.2s cubic-bezier(0.645, 0.045, 0.355, 1);
  transition: border-color 0.2s cubic-bezier(0.645, 0.045, 0.355, 1);
  width: 100%;
  font-size: 12px;
}
.weChatSynDiv .el-input__icon {
  line-height: 25px;
}
.weChatSynDiv .el-button {
  display: inline-block;
  line-height: 1;
  white-space: nowrap;
  cursor: pointer;
  background: #fff;
  border: 1px solid #dcdfe6;

  -webkit-appearance: none;
  text-align: center;
  -webkit-box-sizing: border-box;
  box-sizing: border-box;
  outline: 0;
  margin: 0;
  -webkit-transition: 0.1s;
  transition: 0.1s;
  font-weight: 500;
  padding: 6px 0px;
  font-size: 14px;
  border-radius: 4px;
}

.weChatSynDiv ::-webkit-input-placeholder {
  font-style: italic;
}
</style>
