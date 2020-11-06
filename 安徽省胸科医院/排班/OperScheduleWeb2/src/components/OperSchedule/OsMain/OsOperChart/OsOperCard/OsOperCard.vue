<template>
  <div
    class="resizediv"
    v-bind:style="{width: comCardWidth+'px','margin-left':startPosition+'px','border-color':(operDetail.OPER_STATUS_CODE===1?'#32C989':(operDetail.OPER_STATUS_CODE===2?'#F98A5C':'#2B9AF0'))}"
    v-on:dragover="allowDrop"
    v-on:drop="drop"
  >
    <el-dialog
      :visible.sync="dialogOperCancelVisible"
      custom-class="cancelView"
      v-bind:close-on-click-modal="false"
    >
      <CancelView
        v-on:closeView="closeShow"
        v-bind:operDetail="operDetail"
        v-bind:endTime="comEndDateTime"
      ></CancelView>
    </el-dialog>
    <el-dialog
      :visible.sync="dialogOperEditVisible"
      custom-class="operEdit"
      v-bind:close-on-click-modal="false"
    >
      <OperEdit
        v-if="dialogOperEditVisible"
        v-bind:comOperDetail="operDetail"
        v-on:closeOperEditView="closeOperEditShow"
      ></OperEdit>
    </el-dialog>
    <el-popover
      ref="popover1"
      placement="right"
      :disabled="operDetail.OPER_STATUS_CODE > 2?true:false"
      trigger="click"
    >
      <ul class="popUl">
        <li
          v-if="operDetail.OPER_STATUS_CODE===1?true:false"
          @click="dialogOperCancelVisible = true"
        >手术取消</li>
        <li
          v-if="operDetail.OPER_STATUS_CODE===1?true:false"
          @click="dialogOperEditVisible = true"
        >排班调整</li>
        <li v-if="operDetail.OPER_STATUS_CODE < 3?true:false" @click="opertionRevoked">手术撤销</li>
      </ul>
    </el-popover>
    <div class="lefthandler"></div>
    <div class="content" v-popover:popover1>
      <div class="divwidth div1">
        <div style="display:inline-block; vertical-align:top;">{{'台'+operDetail.SEQUENCE}}</div>
        <div
          style="display:inline-block; vertical-align:top;"
        >{{operDetail.SCHEDULED_DATE_TIME | formatDate('HH:mm')}}-{{comEndDateTime}}</div>
        <div class="divInd" style="width:25px;">
          <img
            v-if="operDetail.EMERGENCY_IND === 1"
            src="../../../../../assets/emergencycheck.png"
            width="17"
            height="17"
            title="急救"
          >
        </div>
        <div style="display:inline-block; vertical-align:top;">{{operDetail.SURGEON_NAME}}</div>

        <div class="divInd">
          <img
            v-if="operDetail.INFECTED_IND === 2"
            src="../../../../../assets/infected_ind.png"
            width="17"
            height="17"
            title="感染"
          >
        </div>
        <div class="divInd">
          <img
            v-if="operDetail.RADIATE_IND === 2"
            src="../../../../../assets/radiatecheck.png"
            width="17"
            height="17"
            title="放射"
          >
        </div>
        <i class="IsFinishOper el-icon-time" v-if="operDetail.OPER_STATUS_CODE===3" title="手术中"></i>
        <i class="IsFinishOper el-icon-success" v-if="operDetail.OPER_STATUS_CODE===4" title="已完成"></i>
      </div>
      <div
        class="divwidth div2"
      >{{operDetail.NAME}}&nbsp;&nbsp;&nbsp;{{operDetail.INP_NO}}&nbsp;&nbsp;&nbsp;{{operDetail.SEX}}&nbsp;&nbsp;&nbsp;{{operDetail.AGE}}</div>
      <div
        class="divwidth div3"
        v-bind:title="operDetail.TEMP_OPER_NAME"
      >{{valSubStr(operDetail.TEMP_OPER_NAME,20)}}</div>
      <div class="divwidth" v-if="userRole.indexOf('护士')>-1?true:false">
        <input placeholder="洗手护士" readonly v-model="operDetail.FIRST_OPER_NURSE_NAME">
        <input placeholder="巡回护士" readonly v-model="operDetail.FIRST_SUPPLY_NURSE_NAME">
      </div>
      <div class="divwidth" v-if="userRole.indexOf('医生')>-1?true:false">
        <input placeholder="主 麻" readonly v-model="operDetail.ANES_DOCTOR_NAME">
        <input placeholder="副 麻" readonly v-model="operDetail.FIRST_ANES_ASSISTANT_NAME">
      </div>
      <div class="divwidth div3" v-bind:title="comShowTitleContent">
        备注：
        <span
          style="color: red;margin-right: 5px;"
        >{{(operDetail.NOTES_ON_OPERATION !==null && operDetail.NOTES_ON_OPERATION !=='') ? operDetail.NOTES_ON_OPERATION:'无'}}</span>
        感染：
        <span
          style="color: red;"
        >{{(operDetail.SPECIAL_INFECT !==null && operDetail.SPECIAL_INFECT !=='') ? operDetail.SPECIAL_INFECT:'无'}}</span>
      </div>
    </div>
    <div class="handler"></div>
  </div>
</template>

<script>
import OsOperCard from './OsOperCard.js'
export default OsOperCard
</script>

<style>
.resizediv {
  height: 110px;
  background-color: white;
  position: relative;
  font-size: 12px;
  border: 2px solid #cdd9df;
  -moz-border-radius: 6px;
  -webkit-border-radius: 6px;
  border-radius: 6px;
  float: left;
  overflow: hidden;
}

.resizediv div.content {
  padding-bottom: 5px;
  padding-left: 5px;
  padding-right: 5px;
  padding-top: 5px;
  height: 100px;
  cursor: move;
}

.resizediv .lefthandler {
  height: 110px;
  width: 5px;
  position: absolute;
  cursor: e-resize;
  bottom: 0px;
  left: 0px;
}

.resizediv .handler {
  height: 110px;
  width: 5px;
  position: absolute;
  cursor: e-resize;
  bottom: 0px;
  right: 0px;
}

.resizediv div.content .divwidth {
  min-width: 300px;
  width: 100%;
}

.resizediv div.content .div1 {
  color: #349df1;
  font-weight: 600;
  border-bottom: 1px solid #e5e6ea;
  height: 20px;
}

.resizediv div.content .div2 {
  height: 20px;
  line-height: 20px;
}

.resizediv div.content .div3 {
  font-weight: 600;
  height: 20px;
  line-height: 20px;
}

.resizediv div.content .divInd {
  width: 17px;
  height: 17px;
  display: inline-block;
  text-align: center;
  cursor: default;
}

.resizediv div.content .divwidth input {
  border: 1px dashed #cdd9df;
  width: 60px;
  height: 16px;
  text-align: center;
  border-radius: 6px;
}

.resizediv div.content .IsFinishOper {
  position: absolute;
  right: 2%;
  color: #32c989;
  font-size: 15px;
  vertical-align: middle;
  cursor: default;
}

.el-popover[x-placement^="right"] {
  min-width: 60px;
  background-color: #1d334a;
  background: #1d334a;
  border: 0px;
  padding: 2px;
  margin-left: 0px;
  opacity: 0.7;
  border-radius: 5px;
}

.el-popover[x-placement^="right"] .popper__arrow::after {
  border-right-color: #1d334a;
  opacity: 0.7;
}

.el-popover[x-placement^="left"] {
  min-width: 60px;
  background-color: #1d334a;
  background: #1d334a;
  border: 0px;
  padding: 2px;
  margin-right: 0px;
  opacity: 0.7;
  border-radius: 5px;
}

.el-popover[x-placement^="left"] .popper__arrow::after {
  border-left-color: #1d334a;
  opacity: 0.7;
}

.popUl {
  margin: 0px;
  padding: 0px;
  font-size: 11px;
  color: white;
}

.popUl li {
  list-style: none;
  text-align: center;
  height: 20px;
  line-height: 20px;
}

.popUl li:hover {
  background-color: #2d9fef;
  border-radius: 5px;
  cursor: pointer;
}
</style>
