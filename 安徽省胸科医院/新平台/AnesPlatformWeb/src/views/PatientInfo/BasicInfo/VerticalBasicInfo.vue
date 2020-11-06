<template>
  <div class="basicVertical">
    <div class="info1">
      <div class="info1_photo">
        <img class="photo" src="@/assets/images/info_tx.png" alt>
        <span style="font-size:18px; width:70px; margin-left:15px;">{{patientInfo.NAME}}</span>
        <div class="line1"></div>
      </div>
      <div class="detailInfoMain">
        <div class="detailinfo">
          <span style=" margin-left:10px;">性别</span>
          <span class="txtInfo">{{patientInfo.SEX}}</span>
          <span style=" margin-left:10px;">住院号</span>
          <span class="txtInfo">{{patientInfo.INP_NO}}</span>
          <span style=" margin-left:10px;">年龄</span>
          <span class="txtInfo">{{patientInfo.AGE}}</span>
          <span style=" margin-left:10px;">体重</span>
          <span class="txtInfo">{{patientInfo.WEIGHT}}</span>
          <span style=" margin-left:10px;">床号</span>
          <span class="txtInfo">{{patientInfo.BED_NO}}</span>
          <span style=" margin-left:10px;">手术日期</span>
          <span class="txtInfo">{{patientInfo.SCHEDULED_DATE_TIME | formatDate('YYYY-MM-DD')}}</span>
          <span style=" margin-left:10px;">病区</span>
          <span class="txtInfo">{{patientInfo.DEPT_NAME}}</span>
        </div>
        <!-- <div class="detailinfo">
          <span style=" margin-left:10px;">病区</span>
          <span style="width:265px;" class="txtInfo">{{patientInfo.DEPT_NAME}}</span>
        </div>-->
      </div>
    </div>
    <div class="info2">
      <div class="info2_detailinfo">
        <span style=" margin-left:10px;">血型</span>
        <span style="width:76px;" class="info2_txtInfo">{{patientInfo.BLOOD_TYPE}}</span>
        <span style=" margin-left:10px;">ASA分级</span>
        <span style="width:74px;" class="info2_txtInfo">{{patientInfo.ASA}}</span>
        <span style=" margin-left:10px;">手术体位</span>
        <span style="width:133px;" class="info2_txtInfo">{{patientInfo.OPER_POSITION}}</span>
        <span style=" margin-left:10px;margin-right:32px;"></span>
        <el-checkbox disabled :checked="IsJZ(patientInfo.EMERGENCY_IND)">急诊</el-checkbox>
        <el-checkbox
          disabled
          :checked="!IsJZ(patientInfo.EMERGENCY_IND)"
          style=" margin-left:10px;"
        >择期</el-checkbox>
      </div>
      <div class="link-top"></div>
      <div class="info2_detailinfo1">
        <span style=" margin-left:10px;">手术医生</span>
        <span style="width:70%;" class="info2_txtInfoMult">{{patientInfo.SURGEON}}</span>
      </div>
      <div class="info2_detailinfo1">
        <span style=" margin-left:10px;">麻醉医师</span>
        <span style="width:70%;" class="info2_txtInfoMult">{{patientInfo.ANESDOCTOR}}</span>
      </div>
      <div class="info2_detailinfo1">
        <span style=" margin-left:10px;">手术护士</span>
        <span style="width:70%;" class="info2_txtInfoMult">{{patientInfo.NURSE}}</span>
      </div>
      <div class="info2_detailinfo1">
        <span style=" margin-left:10px;">麻醉方法</span>
        <span style="width:70%;" class="info2_txtInfoMult">{{patientInfo.ANESMETHOD}}</span>
      </div>
      <div class="info2_detailinfo1">
        <span style=" margin-left:10px; ">术前诊断</span>
        <span
          style="width:70%; height:51px;"
          class="info2_txtInfoMult"
        >{{patientInfo.DIAG_BEFORE_OPERATION}}</span>
      </div>
      <div class="info2_detailinfo1">
        <span style=" margin-left:10px;">术后诊断</span>
        <span
          style="width:70%; height:51px;"
          class="info2_txtInfoMult"
        >{{patientInfo.DIAG_AFTER_OPERATION}}</span>
      </div>
      <div class="info2_detailinfo1">
        <span style=" margin-left:10px; width:57px; line-height:15px; ">拟实施手术名称</span>
        <span
          style="width:70%; height:51px;"
          class="info2_txtInfoMult"
        >{{patientInfo.OPERATION_NAME}}</span>
      </div>
      <div class="info2_detailinfo1">
        <span style=" margin-left:10px; width:57px; line-height:15px;">实施手术名称</span>
        <span
          style="width:70%; height:51px;"
          class="info2_txtInfoMult"
        >{{patientInfo.OPERATION_NAME_PLAN}}</span>
      </div>
    </div>
  </div>
</template>

<script>
import VerticalBasicInfo from './VerticalBasicInfo.js'
export default VerticalBasicInfo
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";
.basicVertical {
  display: flex;
  flex-direction: column;
  height: 100%;

  .info1 {
    margin: 0px auto;
    width: 100%;
    min-width: 750px;
    height: 105px;
    background: rgba(255, 255, 255, 1);
    box-shadow: 0px 3px 10px 0px rgba(255, 255, 255, 1);
    display: flex;
    flex-direction: row;
    align-items: center;
    .info1_photo {
      width: 200px;
      display: flex;
      flex-direction: row;
      align-items: center;
      .photo {
        width: 40px;
        height: 40px;
        margin-left: 30px;
      }
      .line1 {
        width: 4px;
        height: 72px;
        background: rgba(0, 188, 241, 1);
        border-radius: 2px;
        margin-left: 10px;
      }
    }

    .detailInfoMain {
      margin-left: 1%;
      .detailinfo {
        display: flex;
        flex-direction: row;
        flex-wrap: wrap;
        align-items: center;
        font-size: 14px;
        color: rgba(131, 131, 131, 1);
        line-height: 34px;
        margin-right: 30px;
        .txtInfo {
          height: 29px;
          line-height: 29px;
          padding: 0px 15px 0px 10px;
          // background: rgba(206, 243, 248, 1);
          // border-radius: 5px;
          // text-align: center;
          color: #216fa6;
          margin-left: 10px;
        }
      }
    }
  }
  .info2 {
    font-size: 14px;
    font-family: MicrosoftYaHei;
    background: url(../../../assets/images/info_bg2.png) no-repeat;
    background-size: 100% 100%;
    padding: 20px;
    color: rgba(255, 255, 255, 1);
    display: flex;
    flex-direction: row;
    align-items: center;
    flex-wrap: wrap;
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
        margin-left: 20px;
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
    .link-top {
      width: 100%;
      height: 1px;
      border-top: solid #908f9193 1px;
      margin-top: 20px;
    }

    .info2_detailinfo1 {
      display: flex;
      flex-direction: row;
      align-items: center;
      font-size: 14px;
      width: 50%;
      color: rgba(255, 255, 255, 1);
      line-height: 34px;
      margin-top: 10px;
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
        text-align: left;
        padding-left: 8px;
        padding-right: 8px;
      }
    }
  }
}
</style>

<style>
.basicVertical .el-checkbox__input.is-disabled.is-checked .el-checkbox__inner {
  background-color: #409eff;
  border-color: #409eff;
}
.basicVertical .el-checkbox__input.is-disabled + span.el-checkbox__label {
  color: rgba(255, 255, 255, 1);
  cursor: not-allowed;
}
</style>
