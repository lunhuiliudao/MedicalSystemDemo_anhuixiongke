<template>
  <div class="QualityReported">
    <div class="top_row1">
      <span class="top_row1_span">选择年份</span>
      <el-date-picker
        v-model="searchDate"
        type="year"
        class="top_row1_date"
        placeholder="选择月份"
        style="width:100px;"
        :clearable="false"
        @change="searchInfos()"
      ></el-date-picker>
    </div>

    <div class="quanlityDiv">
      <div class="head_line"></div>
      <table class="qualityTable">
        <thead class="tableHead">
          <th width="71px" style="text-align:center;">序号</th>
          <th width="310px">报告名称</th>
          <th width="173px">上报日期</th>
          <th width="98px">上报人</th>
          <th width="142px" style="text-align:center;">状态</th>
          <th width="141px" style="text-align:center;">详情</th>
          <th width="110px" style="text-align:center;">上报操作</th>
        </thead>
        <tbody>
          <tr :class="rowIndex(index)" :key="index" v-for="(item,index) in tableData ">
            <td style="width:71px;text-align:center;" type="index">{{calIndex(index+1)}}</td>
            <td style="width:310px;">{{item.REPORT_NAME}}</td>
            <td style="width:173px;">{{item.REPORT_DATE}}</td>
            <td style="width:98px;">{{item.OPERATOR}}</td>
            <td style="width:142px;text-align:center;">
              <div v-if="item.STATUS === 1">
                <img
                  style="vertical-align:middle;margin-right:5px;"
                  src="@/assets/images/icon-已上报.png"
                >
                <span>已上报</span>
              </div>
              <div v-else>
                <img
                  style="vertical-align:middle;margin-right:5px;"
                  src="@/assets/images/icon-未上报.png"
                >
                <span>未上报</span>
              </div>
            </td>
            <td style="width:141px;text-align:center;">
              <img
                @click="searchDetailInfo(item)"
                style="vertical-align:middle;margin-right:5px;"
                src="@/assets/images/button数据维护.png"
              >
            </td>
            <td style="width:110px;text-align:center;" @click="uploadData(item.REPORT_ID)">
              <img
                style="margin-left:10px;vertical-align:middle;width:22px;"
                src="@/assets/images/icon-上报操作-上传到云.png"
                alt
              >
            </td>
          </tr>
        </tbody>
      </table>
    </div>
    <el-dialog
      title
      width="340px"
      top="25vh"
      :visible.sync="loginDialogVisible"
      :close-on-click-modal="true"
      custom-class="viewdialogLogin"
      @close="loginDialogVisible = false"
    >
      <div style="display: flex;flex-direction: column;">
        <div class="viewdialogLogin_Header"></div>
        <div class="viewdialogLogin_Top">质控云平台登录</div>
        <div class="viewdialogLogin_Content">
          <el-form v-bind:model="acount" label-width="75px" ref="acount" v-bind:rules="rules2">
            <el-form-item label="用户名：" prop="loginname">
              <el-input
                v-model="acount.loginname"
                placeholder="请输入用户名"
                auto-complete="off"
                style="width:200px;"
              ></el-input>
            </el-form-item>
            <el-form-item label="密 码：" prop="password" style="margin-top:10px;">
              <el-input
                type="password"
                ref="pwd"
                v-model="acount.password"
                placeholder="请输入密码"
                auto-complete="off"
                style="width:200px;"
              ></el-input>
            </el-form-item>
            <el-form-item style="margin-top:10px;margin-left:110px;">
              <el-button size="mini" type="primary" style="width:80px;" v-on:click="btnOk()">确定</el-button>
            </el-form-item>
            <el-form-item></el-form-item>
          </el-form>
        </div>
      </div>
    </el-dialog>
    <!-- <div class="botton_line"></div> -->
  </div>
</template>
<script>
import QualityReported from './QualityReported.js'
export default QualityReported
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";
.QualityReported {
  margin: 50px auto;
  font-size: 12px;
  height: 100%;

  .top_row1 {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    display: flex;
    flex-direction: row;
    .top_row1_span {
      margin: 30px 0 28px 53px;
      font-weight: 600;
    }
    .top_row1_date {
      margin: 23px 0 21px 7px;
    }
  }

  .quanlityDiv {
    width: 100%;
    display: flex;
    flex-direction: column;
    align-items: left;
    min-height: 768px;
    background: rgba(255, 255, 255, 1);
    margin-top: 15px;
    .head_line {
      width: 100%;
      height: 4px;
      background: rgba(43, 202, 234, 1);
    }
    .qualityTable {
      width: 100%;
      background: rgba(255, 255, 255, 1);
      box-shadow: 0px 0px 8px 0px rgba(112, 132, 142, 0.15);
    }
    .botton_line {
      width: 95%;
      height: 1px;
      background: rgba(159, 172, 178, 1);
      opacity: 0.3;
      margin-left: 34px;
    }
    .tableHead {
      text-align: left;
      height: 52px;
      background: rgba(255, 255, 255, 1);
      border: 1px solid rgba(233, 234, 235, 1);
      font-size: 12px;
      font-family: MicrosoftYaHei;
      font-weight: 400;
      color: rgba(141, 141, 141, 1);
      vertical-align: left;
      line-height: 52px;
    }
    .tableSingleRow {
      height: 49px;
      color: rgba(74, 74, 74, 1);
      background: rgba(255, 255, 255, 1);
      text-align: left;
    }
    .tableDoubleRow {
      height: 49px;
      color: rgba(74, 74, 74, 1);
      text-align: left;
      background: #e9f2f5;
    }
    td {
      vertical-align: middle;
      font-size: 12px;
    }
  }

  .viewdialogLogin {
    .viewdialogLogin_Header {
      width: 340px;
      height: 4px;
      background: rgba(0, 188, 241, 1);
      border-radius: 5px;
    }

    .viewdialogLogin_Top {
      height: 17px;
      font-size: 20px;
      font-family: MicrosoftYaHei;
      font-weight: 400;
      color: rgba(69, 69, 69, 1);
      margin: 13px 0 0 20px;
    }

    .viewdialogLogin_Content {
      margin: 23px 0 0 20px;
    }
  }
}

@media screen and (min-aspect-ratio: 1001/1000) {
  //横板
  .QualityReported {
    margin: 40px auto;
  }
}
@media screen and (max-aspect-ratio: 1000/1000) {
  // 竖版

  .top_row1 {
    height: 70px;
    background: #f5f9fb;
    box-shadow: 0px 0px 8px 0px rgba(112, 132, 142, 0.15);
    border-radius: 10px;
  }

  .QualityReported .quanlityDiv {
    min-height: 1366px;
  }
}
</style>
<style lang="scss">
@import "@/assets/styles/global.scss";
.top_row1 .el-input__inner {
  height: 26px;
  border: 1px solid rgba(220, 220, 220, 1);
  border-radius: 5px;
  line-height: 25px;
}

.top_row1 .el-input__icon {
  height: 100%;
  width: 25px;
  text-align: left;
  -webkit-transition: all 0.3s;
  transition: all 0.3s;
  line-height: 25px;
  margin-left: 5px;
}

.viewdialogLogin .el-button--primary {
  color: #fff;
  background-color: #00bcf1;
  border-color: #00bcf1;
}

.viewdialogLogin .el-input__inner {
  height: 26px;
  background-color: #fff;
}

.viewdialogLogin .el-dialog__header {
  padding: 0px 0px 0px;
}

.viewdialogLogin .el-dialog__body {
  padding: 0px 0px;
  color: #606266;
  font-size: 14px;
  height: 220px;
  background: rgba(255, 255, 255, 1);
  box-shadow: 0px 0px 8px 0px rgba(48, 50, 51, 0.55);
  border-radius: 5px;
}
</style>
