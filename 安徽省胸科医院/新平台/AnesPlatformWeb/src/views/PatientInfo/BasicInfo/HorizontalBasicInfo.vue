<template>
  <div class="basiHorizontal">
    <div class="BasicInfoSimple" v-show="showMiniInfo">
      <div style="height:10px;"></div>
      <div class="info1">
        <img
          style="width:40px; height:40px; margin-left:10px;"
          src="@/assets/images/info_tx.png"
          alt
        >
        <p style="font-size:14px; margin-left:10px">{{patientInfo.NAME}}</p>
      </div>
    </div>
    <div class="BasicInfo" v-show="!showMiniInfo">
      <div style="height:10px;"></div>
      <div class="info1">
        <img
          style="width:40px; height:40px; margin-left:10px;"
          src="@/assets/images/info_tx.png"
          alt
        >
        <span style="font-size:18px; margin-left:10px;">{{patientInfo.NAME}}</span>
        <div class="line1"></div>
        <div class="detailInfoMain">
          <div class="detailinfo">
            <span style=" margin-left:10px;">性别</span>
            <span style="width:50px;" class="txtInfo">{{patientInfo.SEX}}</span>
            <span style=" margin-left:10px;">年龄</span>
            <span style="width:50px;" class="txtInfo">{{patientInfo.AGE}}</span>
            <span style=" margin-left:10px;">体重</span>
            <span style="width:68px;" class="txtInfo">{{patientInfo.WEIGHT}}</span>
          </div>
          <div class="detailinfo">
            <span style=" margin-left:10px;">病区</span>
            <span style="width:265px;" class="txtInfo">{{patientInfo.DEPT_NAME}}</span>
          </div>
        </div>
      </div>
      <div class="info2">
        <div class="info2_detailinfo">
          <span style=" margin-left:10px;">床号</span>
          <span style="width:40px;" class="info2_txtInfo">{{patientInfo.BED_NO}}</span>
          <span style=" margin-left:10px;">住院号</span>
          <span style="width:121px;" class="info2_txtInfo">{{patientInfo.INP_NO}}</span>
          <span style=" margin-left:10px;">手术日期</span>
          <span
            style="width:133px;"
            class="info2_txtInfo"
          >{{patientInfo.SCHEDULED_DATE_TIME | formatDate('YYYY-MM-DD')}}</span>
        </div>
      </div>
      <div class="link-top"></div>
      <div class="info2">
        <div class="info2_detailinfo">
          <span style=" margin-left:10px;">血型</span>
          <span style="width:76px;" class="info2_txtInfo">{{patientInfo.BLOOD_TYPE}}</span>
          <span style=" margin-left:10px;">ASA分级</span>
          <span style="width:74px;" class="info2_txtInfo">{{patientInfo.ASA}}</span>
          <span style=" margin-left:10px;">手术体位</span>
          <span style="width:133px;" class="info2_txtInfo">{{patientInfo.OPER_POSITION}}</span>
        </div>
      </div>
      <!-- <div class="info2">
        <div class="info2_detailinfo">
          <span style=" margin-left:10px; margin-right:10px;">术前禁食</span>
          <el-checkbox :checked="true">是</el-checkbox>
          <el-checkbox style=" margin-left:10px;">否</el-checkbox>
          <span style=" margin-left:70px;margin-right:10px;">困难气道</span>
          <el-checkbox :checked="true">是</el-checkbox>
          <el-checkbox style=" margin-left:10px;">否</el-checkbox>
        </div>
      </div>-->
      <div class="info2">
        <div class="info2_detailinfo">
          <!-- <span style=" margin-left:10px; margin-right:10px;">输血</span>
          <el-checkbox style="margin-left:28px;" :checked="true">是</el-checkbox>
          <el-checkbox style=" margin-left:10px;">否</el-checkbox>-->
          <span style=" margin-left:10px;margin-right:32px;"></span>
          <el-checkbox disabled :checked="IsJZ(patientInfo.EMERGENCY_IND)">急诊</el-checkbox>
          <el-checkbox
            disabled
            :checked="!IsJZ(patientInfo.EMERGENCY_IND)"
            style=" margin-left:10px;"
          >择期</el-checkbox>
        </div>
      </div>
      <div class="link-top"></div>
      <div class="info2">
        <div class="info2_detailinfo">
          <span style=" width:57px; line-height:16px; margin-left:10px;">手术医生</span>
          <span
            style="width:389px; text-align:left;"
            class="info2_txtInfoMult"
          >{{patientInfo.SURGEON}}</span>
        </div>
      </div>
      <div class="info2">
        <div class="info2_detailinfo">
          <span style=" width:57px; line-height:16px; margin-left:10px;">麻醉医师</span>
          <span
            style="width:389px; text-align:left;"
            class="info2_txtInfoMult"
          >{{patientInfo.ANESDOCTOR}}</span>
        </div>
      </div>
      <div class="info2">
        <div class="info2_detailinfo">
          <span style=" width:57px; line-height:16px; margin-left:10px;">手术护士</span>
          <span style="width:389px;text-align:left;" class="info2_txtInfoMult">{{patientInfo.NURSE}}</span>
        </div>
      </div>
      <div class="link-top"></div>
      <div class="info2">
        <div class="info2_detailinfo">
          <span style=" margin-left:10px;">麻醉方法</span>
          <span
            style="width:389px; text-align:left;"
            class="info2_txtInfoMult"
          >{{patientInfo.ANESMETHOD}}</span>
        </div>
      </div>
      <div class="info2">
        <div class="info2_detailinfo">
          <span style=" margin-left:10px;">术前诊断</span>
          <span
            style="width:389px;height:51px; text-align:left;"
            class="info2_txtInfoMult"
          >{{patientInfo.DIAG_BEFORE_OPERATION}}</span>
        </div>
      </div>
      <div class="info2">
        <div class="info2_detailinfo">
          <span style=" margin-left:10px;">术后诊断</span>
          <span
            style="width:389px;height:51px; text-align:left;"
            class="info2_txtInfoMult"
          >{{patientInfo.DIAG_AFTER_OPERATION}}</span>
        </div>
      </div>
      <div class="link-top"></div>
      <div class="info2">
        <div class="info2_detailinfo">
          <span style=" width:57px; line-height:16px; margin-left:10px;">拟实施手术名称</span>
          <span
            style="width:389px;height:51px; text-align:left;"
            class="info2_txtInfoMult"
          >{{patientInfo.OPERATION_NAME}}</span>
        </div>
      </div>
      <div class="info2">
        <div class="info2_detailinfo">
          <span style=" width:57px; line-height:16px; margin-left:10px;">实施手术名称</span>
          <span
            style="width:389px;height:51px; text-align:left;"
            class="info2_txtInfoMult"
          >{{patientInfo.OPERATION_NAME_PLAN}}</span>
        </div>
      </div>
    </div>
    <div class="btnSize" @click="showMin()">
      <img
        style="width:18px; height:119px; "
        v-show="!$store.state.HomeData.miniBasicInfo"
        src="@/assets/images/info_suo.png"
        alt
      >
      <img
        style="width:18px; height:119px; "
        v-show="$store.state.HomeData.miniBasicInfo"
        src="@/assets/images/info_zk.png"
        alt
      >
    </div>
  </div>
</template>

<script>
import BasicInfo from './HorizontalBasicInfo.js'
export default BasicInfo
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";
.basiHorizontal {
  display: flex;
  flex-direction: row;
  min-height: 830px;

  .BasicInfoSimple {
    width: 68px;
    height: 100%;
    // background-color: #306588;
    background: url(../../../assets/images/info_bg.png) no-repeat;
    .info1 {
      font-size: 14px;
      font-family: MicrosoftYaHei;
      font-weight: 400;
      color: rgba(255, 255, 255, 1);
      line-height: 21px;
    }
  }
  .BasicInfo {
    width: 536px;
    height: 100%;
    // background-color: #306588;
    background: url(../../../assets/images/info_bg.png) no-repeat;
    background-size: 100% 100%;

    .info1 {
      margin: 0px auto;
      width: 491px;
      height: 105px;
      background: rgba(255, 255, 255, 1);
      box-shadow: 0px 3px 10px 0px rgba(255, 255, 255, 1);
      display: flex;
      flex-direction: row;
      align-items: center;
      .line1 {
        width: 4px;
        height: 72px;
        background: rgba(0, 188, 241, 1);
        border-radius: 2px;
        margin-left: 15px;
      }
      .detailinfo {
        display: flex;
        flex-direction: row;
        align-items: center;
        font-size: 14px;
        color: rgba(131, 131, 131, 1);
        line-height: 34px;
        .txtInfo {
          height: 29px;
          line-height: 29px;
          background: rgba(206, 243, 248, 1);
          border-radius: 5px;
          text-align: center;
          color: #5990b5;
          margin-left: 10px;
        }
      }
    }
    .info2 {
      font-size: 14px;
      font-family: MicrosoftYaHei;
      font-weight: 400;
      margin-top: 18px;
      margin-left: 20px;
      color: rgba(255, 255, 255, 1);
      .info2_detailinfo {
        display: flex;
        flex-direction: row;
        align-items: center;
        font-size: 14px;
        color: rgba(255, 255, 255, 1);
        line-height: 34px;
        .info2_txtInfo {
          height: 26px;
          line-height: 26px;
          background-color: #7399b6;
          border-radius: 5px;
          margin-left: 10px;
          text-align: center;
        }
        .info2_txtInfoMult {
          height: 26px;
          line-height: 26px;
          background-color: #7399b6;
          border-radius: 5px;
          margin-left: 10px;
          text-align: center;
          padding-left: 8px;
          padding-right: 8px;
        }
      }
    }
    .link-top {
      width: 100%;
      height: 1px;
      border-top: solid #908f9193 1px;
      margin-top: 20px;
    }
  }

  .btnSize {
    width: 18px;
    height: 118px;
    margin-top: 250px;
    margin-left: -18px;
    cursor: pointer;
    z-index: 1;
  }
}
</style>

<style>
.basiHorizontal .el-checkbox__input.is-disabled.is-checked .el-checkbox__inner {
  background-color: #409eff;
  border-color: #409eff;
}
.basiHorizontal .el-checkbox__input.is-disabled + span.el-checkbox__label {
  color: rgba(255, 255, 255, 1);
  cursor: not-allowed;
}
</style>
