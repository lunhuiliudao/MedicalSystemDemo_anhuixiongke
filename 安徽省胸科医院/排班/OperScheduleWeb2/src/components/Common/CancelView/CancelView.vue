<template>
  <div>
    <div slot="title" class="dialogOperCancelTitle">
      手术取消
    </div>
    <div class="dialogOperCancelExpan">
      <span style="margin-left:15px">
        <img style="vertical-align: middle" src="../../../assets/expan.png" alt="" />
      </span>
      <span style="margin-left:30px">{{operDetail.SCHEDULED_DATE_TIME | formatDate('HH:mm')}}-{{endTime}}</span>
      <span style="margin-left:30px">台次 {{operDetail.SEQUENCE}}</span>
      <span style="margin-left:30px">{{operDetail.DEPT_NAME}}</span>
      <span style="margin-left:30px">{{operDetail.SURGEON_NAME}}</span>
    </div>
    <div class="dialogOperCancelBody">
      <div class="personInfoDiv">
        <ul class="ul1">
          <li>{{operDetail.NAME}}</li>
          <li>
            <img v-if="operDetail.SEX==='男'?true:false" src="../../../assets/man.png" alt="" />
            <img v-if="operDetail.SEX==='女'?true:false" src="../../../assets/woman.png" alt="" />
          </li>
          <li>
            {{operDetail.PATIENT_ID}}
          </li>
          <li>
            {{operDetail.SEX}}&nbsp;{{operDetail.AGE}}
          </li>
        </ul>
        <ul class="ul2">
          <li v-bind:title="operDetail.DIAG_BEFORE_OPERATION">{{operDetail.DIAG_BEFORE_OPERATION}}</li>
          <li v-bind:title="operDetail.OPERATION_NAME">
            {{operDetail.OPERATION_NAME}}
          </li>
          <li>
            <span style="background-color: #3295D1;width:20px;height:20px;display:inline-block;text-align:center;line-height: 20px;">注</span> {{operDetail.NOTES_ON_OPERATION}}
          </li>
        </ul>
      </div>
      <div class="cancelClassDiv">
        <span class="cancelClassDiv-font">取消分类</span>
        <el-radio-group v-model="selectClass" class="cancelClassDiv-botton">
          <el-radio v-bind:label="item.CLASS_VALUE" v-bind:key="index" v-for="(item,index) in cancelClass">{{item.CLASS_NAME}}</el-radio>
        </el-radio-group>
      </div>
      <div class="cancelClassItemDiv">
        <ul class="cancelClassItemUl">
          <li :key="index" v-for="(item,index) in cancelClass.filter((r)=> {return r.CLASS_VALUE===selectClass})[0].CLASS_ITEMS"><el-checkbox v-model="item.ITEM_CHECKED" >{{item.ITEM_NAME}}</el-checkbox></li>
        </ul>
      </div>
      <div class="cancelDescription">
          <div class="cancelDescriptionDiv">&nbsp;&nbsp;说明</div>
          <div>
            <el-input type="textarea" :rows="2" v-bind:maxlength="100" v-model="cancelReason" resize="none" placeholder="点击填写取消原因">
            </el-input>
          </div>
      </div>
    </div>
    <div slot="footer" class="cancel_footer">
      <el-button type="primary" class="cancel_submit" v-on:click="saveCancelInfo" >保 存</el-button>
    </div>
  </div>
</template>

<script>
import CancelView from './CancelView.js'
export default CancelView
</script>

<style>
.cancelView {
  width: 473px;
}

.cancelView .el-dialog__header {
  padding-top: 5px;
}

.cancelView .el-dialog__body {
  padding: 0px 20px;
  color: #48576a;
  font-size: 14px;
}

.cancelView .el-dialog__footer {
  clear: left;
  height: 30px;
}

.dialogOperCancelTitle {
  display: inline-block;
  text-align: center;
  width: 97%;
  height: 25px;
  font-weight: bolder;
  font-size: 15px;
  letter-spacing: 2px;
  border-bottom: 1px solid #E1E2E2
}

.dialogOperCancelExpan {
  width: 97%;
  height: 35px;
  line-height: 35px;
  font-size: 13px;
  color: #349DF1;
  font-weight: 600;
}

.dialogOperCancelBody {
  border-top: 1px solid #E5E6EA;
  border-bottom: 1px solid #E5E6EA;
  height: 300px;
  width: 97%;
}

.dialogOperCancelBody .personInfoDiv {
  border-bottom: 1px solid #E5E6EA;
  height: 90px
}

.dialogOperCancelBody .cancelClassDiv {
  height: 25px;
  line-height: 25px;
  background-color: #DCECFC;
  width: 410px;
  margin: 5px 0px 5px 5px;
  -moz-border-radius: 3px;
  -webkit-border-radius: 3px;
  border-radius: 3px;
}

.cancelClassDiv-font {
  font-size: 11px;
  color: #349DF1;
  font-weight: 600;
  margin-left: 10px;
}

.cancelClassDiv-botton {
  margin-left: 20px;
}

.personInfoDiv .ul1 {
  list-style: none;
  margin: 5px 20px;
  padding: 0px;
  float: left;
  border-right: 1px dashed #C1C1C1;
}

.personInfoDiv .ul1 li {
  width: 80px;
  text-align: center;
  font-size: 11px;
  height: 20px;
  line-height: 20px;
}

.personInfoDiv .ul2 {
  list-style: none;
  margin: 5px 0px;
  padding: 0px;
  float: left;
}

.personInfoDiv .ul2 li {
  width: 295px;
  font-size: 11px;
  height: 25px;
  line-height: 25px;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
  text-align: left;
}

.cancelClassItemUl {
  list-style: none;
  margin: 5px 0px;
  padding: 0px 20px;
}

.cancelClassItemUl li {
  width: 190px;
  height: 28px;
  line-height: 28px;
  float: left;
  text-align: left;
}

.cancelDescription {
  clear: both;
  border-top: 1px solid #E5E6EA;
}
.cancelDescription .cancelDescriptionDiv {
  font-size: 11px;
  color: #349DF1;
  font-weight: 600;
  height: 25px;
  line-height: 25px;
}

.cancelView .cancel_footer {
  height: 50px;
  line-height: 50px;
  text-align: center;
}

.cancelView .cancel_submit {
    background-color: #33C88A;
    border-color: #33C88A;
    height: 30px;
    padding: 5px 15px;
    width: 150px
}
</style>
