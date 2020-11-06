<template>
  <div>
    <div slot="title" class="dialogOperEditTitle">
      手术信息
    </div>
    <div class="dialogOperEditBody">
      <el-form ref="form" label-width="80px" v-bind:inline="true">
        <div style="text-align:center;width:97%;padding-top: 10px">
          <el-form-item label="手术间号">
            <el-tag>{{comOperDetail.OPER_ROOM_NO===null?'无':comOperDetail.OPER_ROOM_NO}}</el-tag>
          </el-form-item>
          <el-form-item label="台次">
            <el-tag>{{comOperDetail.SEQUENCE}}</el-tag>
          </el-form-item>
          <el-form-item label="申请时间">
            <el-tag v-if="comOperDetail.OPER_STATUS_CODE!==0">{{comDateTime}}</el-tag>
            <el-date-picker v-if="comOperDetail.OPER_STATUS_CODE===0" type="date" v-model="comOperDetail.SCHEDULED_DATE_TIME"  v-bind:editable="false" v-bind:clearable="false" placeholder="选择日期"></el-date-picker>
          </el-form-item>
        </div>
        <div>
          <el-form-item label="手术名称">
            <el-select  v-bind:title="comOperDetail.OPERATION_NAME" v-model="comOperDetail.OPERATION_NAME"  filterable remote :remote-method="remoteOperName" :loading="operNameLoading" placeholder="请选择">
              <el-option :key="index" v-for="(item,index) in operNameList" :value="item.OPER_NAME"></el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="手术医生">
            <el-select v-model="comOperDetail.SURGEON"  filterable remote :remote-method="remoteSurgeonName" :loading="surgeonLoading" placeholder="请选择">
              <el-option  :key="index" v-for="(item, index) in surgeonNameList"  :label="item.USER_NAME" :value="item.USER_JOB_ID"></el-option>
            </el-select>
          </el-form-item>
        </div>
        <div>
          <el-form-item label="麻醉方法">
            <el-select v-bind:title="comOperDetail.ANES_METHOD" v-model="comOperDetail.ANES_METHOD"  filterable remote :remote-method="remoteAnesthesiaName" :loading="anesthesiaNameLoading" placeholder="请选择">
              <el-option :key="index" v-for="(item,index) in anesthesiaNameList"  :value="item.ANAESTHESIA_NAME"></el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="主麻">
            <el-select v-model="comOperDetail.ANES_DOCTOR" v-bind:clearable="true" filterable remote :remote-method="remoteAnesDoctorName" :loading="anesDoctorNameLoding" placeholder="请选择">
              <el-option :key="item.USER_JOB_ID" v-for="item in anesDoctorNameList"  :label="item.USER_NAME" :value="item.USER_JOB_ID"></el-option>
            </el-select>
          </el-form-item>
        </div>
        <div>
          <el-form-item label="副麻1">
            <el-select v-model="comOperDetail.FIRST_ANES_ASSISTANT" v-bind:clearable="true" filterable remote :remote-method="remoteAnesDoctorName1" :loading="anesDoctorName1Loding" placeholder="请选择">
              <el-option  :key="item.USER_JOB_ID" v-for="item in anesDoctorName1List"  :label="item.USER_NAME" :value="item.USER_JOB_ID"></el-option>
            </el-select>
          </el-form-item>
           <el-form-item label="副麻2">
            <el-select v-model="comOperDetail.SECOND_ANES_ASSISTANT" v-bind:clearable="true"  filterable remote :remote-method="remoteAnesDoctorName2" :loading="anesDoctorName2Loding" placeholder="请选择">
              <el-option  :key="item.USER_JOB_ID" v-for="item in anesDoctorName2List"  :label="item.USER_NAME" :value="item.USER_JOB_ID"></el-option>
            </el-select>
          </el-form-item>
        </div>
        <div>
          <el-form-item label="洗手护士1">
            <el-select v-model="comOperDetail.FIRST_OPER_NURSE" v-bind:clearable="true" filterable remote :remote-method="remoteOperNurseName1" :loading="operNurse1Loading" placeholder="请选择">
              <el-option  :key="index" v-for="(item, index) in operNurseName1List"  :label="item.USER_NAME" :value="item.USER_JOB_ID"></el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="洗手护士2">
            <el-select v-model="comOperDetail.SECOND_OPER_NURSE" v-bind:clearable="true"  filterable remote :remote-method="remoteOperNurseName2" :loading="operNurse2Loading" placeholder="请选择">
              <el-option  :key="item.USER_JOB_ID" v-for="item in operNurseName2List"  :label="item.USER_NAME" :value="item.USER_JOB_ID"></el-option>
            </el-select>
          </el-form-item>
        </div>
        <div>
          <el-form-item label="巡回护士1">
            <el-select v-model="comOperDetail.FIRST_SUPPLY_NURSE" v-bind:clearable="true" filterable remote :remote-method="remoteSupplyNurseName1" :loading="supplyNurse1Loading" placeholder="请选择">
              <el-option  :key="item.USER_JOB_ID" v-for="item in supplyNurseName1List"  :label="item.USER_NAME" :value="item.USER_JOB_ID"></el-option>
            </el-select>
          </el-form-item>
          <el-form-item label="巡回护士2">
            <el-select v-model="comOperDetail.SECOND_SUPPLY_NURSE" v-bind:clearable="true"  filterable remote :remote-method="remoteSupplyNurseName2" :loading="supplyNurse2Loading" placeholder="请选择">
              <el-option  :key="item.USER_JOB_ID" v-for="item in supplyNurseName2List"  :label="item.USER_NAME" :value="item.USER_JOB_ID"></el-option>
            </el-select>
          </el-form-item>
        </div>
        <div>
          <el-form-item label="备注">
            <el-input type="textarea" v-model="comOperDetail.NOTES_ON_OPERATION"  v-bind:maxlength="50" :rows="2" style="width:490px" resize="none" placeholder="请输入备注"></el-input>
          </el-form-item>
        </div>
        <div class="operEdit_footer">
          <el-button type="primary" class="cancel_submit" v-on:click="saveOperDetailInfo">保 存</el-button>
        </div>
      </el-form>
    </div>
  </div>
</template>

<script>
import OperEdit from './OperEdit.js'
export default OperEdit
</script>

<style>
.operEdit {
  width: 650px;
}

.operEdit .el-dialog__header {
  padding-top: 5px;
}

.operEdit .el-dialog__body {
  padding: 0px 20px;
  color: #48576a;
  font-size: 14px;
}

.operEdit .el-dialog__footer {
  clear: left;
  height: 30px;
}

.dialogOperEditTitle {
  display: inline-block;
  text-align: center;
  width: 97%;
  height: 30px;
  line-height: 30px;
  font-weight: bolder;
  font-size: 15px;
  letter-spacing: 2px;
}

.dialogOperEditBody {
  border-top: 1px solid #E5E6EA;
  border-bottom: 1px solid #E5E6EA;
  width: 97%;
}

.operEdit .operEdit_footer {
  text-align: center;
}

.operEdit .cancel_submit {
    background-color: #33C88A;
    border-color: #33C88A;
    height: 30px;
    padding: 5px 15px;
    width: 150px;
    margin-bottom: 10px;
}
</style>
