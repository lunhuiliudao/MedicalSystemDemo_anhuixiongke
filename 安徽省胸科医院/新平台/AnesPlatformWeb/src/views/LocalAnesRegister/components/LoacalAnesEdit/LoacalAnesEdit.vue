<template>
  <div class="LoacalAnesEdit">
    <div class="LoacalAnesEdit_Top">
      <div class="LoacalAnesEdit_Top_Left"></div>
      <div class="LoacalAnesEdit_Top_Right">编辑</div>
    </div>
    <div class="LoacalAnesEdit_Main">
      <div class="LoacalAnesEdit_Main_Row1">
        <div class="LoacalAnesEdit_Main_Row1_Column1">住院/门诊号</div>
        <div class="LoacalAnesEdit_Main_Row1_Column2">
          <div class="LoacalAnesEdit_Main_Row1_Column2_Left">
            <el-input
              :disabled="wayType===1?true:false"
              placeholder="住院号"
              v-model="patientBaseData.INP_NO"
              clearable
              :autofocus="true"
              @keyup.enter.native="getPatientBaseInfo(patientBaseData.INP_NO)"
            ></el-input>
          </div>
          <div class="LoacalAnesEdit_Main_Row1_Column2_Center">选择手术</div>
          <div class="LoacalAnesEdit_Main_Row1_Column2_Right">
            <div
              class="LoacalAnesEdit_Main_Row1_Column2_Right_Text"
              @click="getPatientBaseInfo(patientBaseData.INP_NO)"
            >{{MaxOperId}}</div>
          </div>
        </div>
        <div class="LoacalAnesEdit_Main_Row1_Column2_Icon">
          <i class="el-icon-warning LoacalAnesEdit_Main_Row1_Column2_Icon_i"></i>
        </div>
        <div class="LoacalAnesEdit_Main_Row1_Column3">患者</div>
        <div class="LoacalAnesEdit_Main_Row1_Column4">{{patientBaseData.NAME}}</div>
        <div class="LoacalAnesEdit_Main_Row1_Column5">性别</div>
        <div class="LoacalAnesEdit_Main_Row1_Column6">{{patientBaseData.SEX}}</div>
        <div class="LoacalAnesEdit_Main_Row1_Column7">年龄</div>
        <div class="LoacalAnesEdit_Main_Row1_Column8">{{patientBaseData.AGE}}</div>
        <div class="LoacalAnesEdit_Main_Row1_Column9">床号</div>
        <div class="LoacalAnesEdit_Main_Row1_Column10">{{patientBaseData.BED_NO}}</div>
      </div>
      <div class="LoacalAnesEdit_Main_Row2"></div>
      <div class="LoacalAnesEdit_Main_Row3">
        <div class="LoacalAnesEdit_Main_Row3_Column1">手术科室</div>
        <div class="LoacalAnesEdit_Main_Row3_Column2">
          <MedSelect
            style="width:241px;"
            type="DeptDict"
            :remote="true"
            :filterable="true"
            :islocal="false"
            clearable
            placeholder="手术科室"
            v-model="patientBaseData.DEPT_CODE"
          ></MedSelect>
        </div>
        <div class="LoacalAnesEdit_Main_Row3_Column3">手术间</div>
        <div class="LoacalAnesEdit_Main_Row3_Column4">
          <el-select
            v-model="patientBaseData.OPER_ROOM"
            clearable
            placeholder="科室"
            @change="selectChanged"
          >
            <el-option
              class="selectItem"
              style=" font-size: 14px;padding-left:10px;
          line-height: 34px;"
              v-for="(item, index) in OperDeptList"
              :key="index"
              :label="item.DEPT_NAME"
              :value="item.DEPT_CODE"
            ></el-option>
          </el-select>
        </div>
        <div class="LoacalAnesEdit_Main_Row3_Column5">
          <el-select
            style="width:90px;"
            v-model="patientBaseData.OPER_ROOM_NO"
            clearable
            placeholder="手术间"
            :filterable="true"
            :remote="true"
            :remote-method="FilterOperRoom"
          >
            <el-option
              class="selectItem"
              style=" font-size: 14px; padding-left:10px;
          line-height: 34px;"
              v-for="(item, index) in OperRoonNoList"
              :key="index"
              :label="item.ROOM_NO"
              :value="item.ROOM_NO"
            ></el-option>
          </el-select>
        </div>
      </div>
      <div class="LoacalAnesEdit_Main_Row4">
        <div class="LoacalAnesEdit_Main_Row4_Column1">手术等级</div>
        <div class="LoacalAnesEdit_Main_Row4_Column2">
          <MedSelect
            type="OperScaleDict"
            style="width:241px;"
            :remote="false"
            :filterable="false"
            clearable
            placeholder="手术等级"
            v-model="patientBaseData.OPER_SCALE"
          ></MedSelect>
        </div>
        <div class="LoacalAnesEdit_Main_Row4_Column3" style="margin-left:50px;">手术类别</div>
        <div class="LoacalAnesEdit_Main_Row4_Column4 mdsdRadioSingle2">
          <el-radio-group v-model="patientBaseData.EMERGENCY_IND">
            <el-radio label="1">急诊</el-radio>
            <el-radio label="0">择期</el-radio>
          </el-radio-group>
        </div>
      </div>
      <div class="LoacalAnesEdit_Main_Row5">
        <div class="LoacalAnesEdit_Main_Row5_Column1">主刀医生</div>
        <div class="LoacalAnesEdit_Main_Row5_Column2">
          <MedSelect
            type="SurgeonDict"
            style="width:84px;"
            :remote="true"
            :filterable="true"
            :islocal="true"
            clearable
            v-model="patientBaseData.SURGEON"
          ></MedSelect>
        </div>
        <div class="LoacalAnesEdit_Main_Row5_Column3" style="margin-left:10px;">
          <MedSelect
            type="SurgeonDict"
            style="width:84px;"
            :remote="true"
            :filterable="true"
            clearable
            v-model="patientBaseData.FIRST_OPER_ASSISTANT"
          ></MedSelect>
        </div>
        <div class="LoacalAnesEdit_Main_Row5_Column4" style="margin-left:115px;">体重</div>
        <div class="LoacalAnesEdit_Main_Row5_Column5">
          <el-input clearable v-model="patientBaseData.WEIGHT"></el-input>
          <span class="LoacalAnesEdit_Main_Row5_Column5_Span">kg</span>
        </div>
      </div>
      <div class="LoacalAnesEdit_Main_Row6">
        <div class="LoacalAnesEdit_Main_Row6_Column1">诊断名称</div>
        <div class="LoacalAnesEdit_Main_Row6_Column2">
          <InputSelect
            type="DiagnosisDict"
            style="width:587px;"
            replaceKeys="＋,﹢,﹢"
            showKey="+"
            placeholder="诊断名称"
            :ismultiple="true"
            v-model="patientBaseData.DIAG_BEFORE_OPERATION"
          ></InputSelect>
        </div>
      </div>
      <div class="LoacalAnesEdit_Main_Row7">
        <div class="LoacalAnesEdit_Main_Row7_Column1">麻醉方式</div>
        <div class="LoacalAnesEdit_Main_Row7_Column2">
          <InputSelect
            type="AnesMethodDict"
            style="width:244px;"
            placeholder="麻醉方式"
            v-model="patientBaseData.ANES_METHOD"
          ></InputSelect>
        </div>
        <div class="LoacalAnesEdit_Main_Row7_Column3" style="margin-left:49px;">ASA分级</div>
        <div class="LoacalAnesEdit_Main_Row7_Column4" style="margin-left:17px;">
          <MedSelect
            type="ASADict"
            style="width:84px;"
            :remote="false"
            :filterable="false"
            clearable
            placeholder="ASA分级"
            v-model="patientBaseData.ASA_GRADE"
          ></MedSelect>
        </div>
      </div>
      <div class="LoacalAnesEdit_Main_Row8">
        <div class="LoacalAnesEdit_Main_Row8_Column1">手术名称</div>
        <div class="LoacalAnesEdit_Main_Row8_Column2">
          <InputSelect
            type="OperNameDict"
            style="width:587px;"
            replaceKeys="＋,﹢,﹢"
            showKey="+"
            :ismultiple="true"
            placeholder="手术名称"
            :islocal="true"
            v-model="patientBaseData.OPERATION_NAME"
          ></InputSelect>
        </div>
      </div>
      <div class="LoacalAnesEdit_Main_Row9">
        <div class="LoacalAnesEdit_Main_Row9_Column1">麻醉医生</div>
        <div class="LoacalAnesEdit_Main_Row9_Column2">
          <MedSelect
            type="AnesDoctorDict"
            style="width:84px;"
            :remote="true"
            :filterable="true"
            clearable
            v-model="patientBaseData.ANES_DOCTOR"
          ></MedSelect>
        </div>
        <div class="LoacalAnesEdit_Main_Row9_Column3">
          <MedSelect
            type="AnesDoctorDict"
            style="width:84px;"
            :remote="true"
            :filterable="true"
            clearable
            v-model="patientBaseData.FIRST_ANES_ASSISTANT"
          ></MedSelect>
        </div>
        <div class="LoacalAnesEdit_Main_Row9_Column4" style="margin-left:115px;">护士</div>
        <div class="LoacalAnesEdit_Main_Row9_Column5">
          <MedSelect
            type="NurseDict"
            style="width:84px;"
            :remote="true"
            :filterable="true"
            clearable
            v-model="patientBaseData.FIRST_OPER_NURSE"
          ></MedSelect>
        </div>
        <div class="LoacalAnesEdit_Main_Row9_Column6">
          <MedSelect
            type="NurseDict"
            style="width:84px;"
            :remote="true"
            :filterable="true"
            clearable
            v-model="patientBaseData.SECOND_OPER_NURSE"
          ></MedSelect>
        </div>
      </div>
      <div class="LoacalAnesEdit_Main_Row10">
        <div class="LoacalAnesEdit_Main_Row10_Left"></div>
        <div class="LoacalAnesEdit_Main_Row10_Content">手术进程时间</div>
        <div class="LoacalAnesEdit_Main_Row10_Right"></div>
      </div>
      <div class="LoacalAnesEdit_Main_Row11">
        <div class="LoacalAnesEdit_Main_Row11_Column1">
          <div class="LoacalAnesEdit_Main_Row11_Column1_Top">入手术室</div>
          <div class="LoacalAnesEdit_Main_Row11_Column1_Main">
            <el-date-picker
              v-model="patientBaseData.IN_DATE_TIME"
              type="datetime"
              clearable
              placeholder="选择日期"
              id="inDate"
              @click.native="dateClick()"
            ></el-date-picker>
          </div>
        </div>
        <div class="LoacalAnesEdit_Main_Row11_Column1">
          <div class="LoacalAnesEdit_Main_Row11_Column1_Top">手术开始</div>
          <div class="LoacalAnesEdit_Main_Row11_Column1_Main">
            <el-date-picker
              v-model="patientBaseData.START_DATE_TIME"
              type="datetime"
              clearable
              placeholder="选择日期"
              @click.native="dateClick()"
            ></el-date-picker>
          </div>
        </div>
        <div class="LoacalAnesEdit_Main_Row11_Column1">
          <div class="LoacalAnesEdit_Main_Row11_Column1_Top">手术结束</div>
          <div class="LoacalAnesEdit_Main_Row11_Column1_Main">
            <el-date-picker
              v-model="patientBaseData.END_DATE_TIME"
              type="datetime"
              clearable
              placeholder="选择日期"
              @click.native="dateClick()"
            ></el-date-picker>
          </div>
        </div>
        <div class="LoacalAnesEdit_Main_Row11_Column1">
          <div class="LoacalAnesEdit_Main_Row11_Column1_Top">出手术室</div>
          <div class="LoacalAnesEdit_Main_Row11_Column1_Main">
            <el-date-picker
              v-model="patientBaseData.OUT_DATE_TIME"
              type="datetime"
              clearable
              placeholder="选择日期"
              @click.native="dateClick()"
            ></el-date-picker>
          </div>
        </div>
      </div>
    </div>
    <div class="LoacalAnesEdit_Bottom">
      <div class="LoacalAnesEdit_Bottom1">
        <el-button class="LoacalAnesEdit_Bottom_Left" type="info" @click="cancel()">取消</el-button>
        <el-button
          class="LoacalAnesEdit_Bottom_Right"
          type="primary"
          v-show="wayType===0?true:false"
          @click="ClearForm()"
        >重置</el-button>
        <el-button
          class="LoacalAnesEdit_Bottom_Right"
          type="primary"
          @click="SaveOutOperatingRoomAnesRecordData()"
        >保存</el-button>
      </div>
    </div>

    <el-dialog
      custom-class="LoacalAnesEdit_viewdialog"
      width="1276px"
      :visible.sync="dialogVisible"
      :append-to-body="true"
      :close-on-click-modal="true"
      @close="dialogVisible = false"
    >
      <div class="LocalAnesSelect">
        <div class="LocalAnesSelect_Header"></div>
        <div class="LocalAnesSelect_Top">选择患者手术</div>
        <div class="LocalAnesSelect_Main">
          <table style="width:99.2%; table-layout:fixed;word-break:break-all;">
            <thead class="tableHead">
              <th width="140px">住院号</th>
              <th width="70px">住院次数</th>
              <th width="70px">手术次数</th>
              <th width="120px">姓名</th>
              <th width="15%">手术科室</th>
              <th width="40%" style="min-width:180px;">手术名称</th>
              <th width="30%">麻醉方法</th>
              <th width="120px">ASA分级</th>
              <th width="120px">手术日期</th>
            </thead>
          </table>
          <el-scrollbar style="height:400px; width:100%;">
            <div style="width:100%; margin:0px auto; display: flex;
        align-items: center;">
              <table style="width:99.2%;table-layout:fixed;word-break:break-all;">
                <thead class="tableHeadDisplay">
                  <th width="140px"></th>
                  <th width="70px"></th>
                  <th width="70px"></th>
                  <th width="120px"></th>
                  <th width="15%"></th>
                  <th width="40%" style="min-width:180px;"></th>
                  <th width="30%"></th>
                  <th width="120px"></th>
                  <th width="120px"></th>
                </thead>
                <tbody>
                  <tr
                    :class="rowIndex(index)"
                    :key="item.PATIENT_ID + index"
                    v-for="(item,index) in patientBaseDataAll "
                  >
                    <td style="width:140px;">
                      <el-checkbox
                        style="margin-left:14px;"
                        :true-label="1"
                        :false-label="0"
                        v-model="ischecked"
                        v-on:change.native="selectPatient(item)"
                      >{{item.INP_NO}}</el-checkbox>
                    </td>
                    <td style="width:70px;">{{item.VISIT_ID}}</td>
                    <td style="width:70px;">{{item.OPER_ID}}</td>
                    <td style="width:120px;">
                      <p style="line-height:24px;font-weight:bold;">{{item.NAME}}</p>
                      <p>{{item.SEX}} {{item.AGE}}</p>
                    </td>
                    <td style="width:15%;">{{item.DEPT_NAME}}</td>
                    <td style="width:40%;">
                      <span style="line-height:13px;">{{item.OPERATION_NAME}}</span>
                    </td>
                    <td style="width:30%;">{{item.ANES_METHOD}}</td>
                    <td style="width:120px;">{{item.ASA_GRADE}}</td>
                    <td style="width:120px;">
                      <p
                        style="line-height:22px"
                      >{{item.SCHEDULED_DATE_TIME | formatDate('YYYY-MM-DD')}}</p>
                      <p>{{item.SCHEDULED_DATE_TIME | formatDate('HH:mm')}}</p>
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
          </el-scrollbar>
        </div>
      </div>
    </el-dialog>
  </div>
</template>
<script>
import LoacalAnesEdit from './LoacalAnesEdit.js'
export default LoacalAnesEdit
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";
.LoacalAnesEdit {
  display: flex;
  flex-direction: column;

  .LoacalAnesEdit_Top {
    height: 30px;
    display: flex;
    flex-direction: row;
    margin: 20px 0 0 0;
    .LoacalAnesEdit_Top_Left {
      width: 30px;
      height: 30px;
      background: rgba(219, 246, 251, 1)
        url(../../../../assets/images/edit2.svg);
      border-radius: 50%;
      margin: 0 0 0 20px;
    }
    .LoacalAnesEdit_Top_Right {
      width: 32px;
      height: 16px;
      font-size: 16px;
      font-family: MicrosoftYaHei;
      font-weight: 400;
      color: rgba(22, 22, 22, 1);
      margin: 8px 0 0 20px;
    }
  }

  .LoacalAnesEdit_Main {
    display: flex;
    flex-direction: column;
    margin: 45px 0 0 63px;
    .LoacalAnesEdit_Main_Row1 {
      height: 35px;
      display: flex;
      flex-direction: row;
      .LoacalAnesEdit_Main_Row1_Column1 {
        width: 75px;
        height: 12px;
        font-size: 12px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: rgba(101, 101, 101, 1);
        margin: 8px 0 0 16px;
      }
      .LoacalAnesEdit_Main_Row1_Column2 {
        width: 187px;
        height: 28px;
        background: #f7f7f7;
        border: 1px solid #dcdfe6;
        border-radius: 5px;
        display: flex;
        flex-direction: row;

        .LoacalAnesEdit_Main_Row1_Column2_Left {
          width: 120px;
          height: 28px;
        }
        .LoacalAnesEdit_Main_Row1_Column2_Center {
          width: 50px;
          height: 11px;
          font-size: 10px;
          font-family: MicrosoftYaHei;
          font-weight: 400;
          color: rgba(250, 160, 82, 1);
          line-height: 27px;
          margin: 2px 0 0 0;
        }
        .LoacalAnesEdit_Main_Row1_Column2_Right {
          width: 20px;
          height: 16px;
          background: rgba(250, 153, 68, 1);
          border-radius: 5px;
          margin: 7px 0 0 0;
          .LoacalAnesEdit_Main_Row1_Column2_Right_Text {
            display: block;
            width: 16px;
            height: 16px;
            font-size: 12px;
            font-family: MicrosoftYaHei-Bold;
            font-weight: bold;
            color: rgba(255, 255, 255, 1);
            margin: 1px auto;
            text-align: center;
          }
        }
      }
      .LoacalAnesEdit_Main_Row1_Column2_Icon {
        width: 16px;
        height: 16px;
        background: rgba(250, 153, 68, 1);
        border-radius: 50px;
        margin: 7px 0 0 4px;
        .LoacalAnesEdit_Main_Row1_Column2_Icon_i {
          color: white;
          margin: auto;
        }
      }
      .LoacalAnesEdit_Main_Row1_Column3 {
        width: 24px;
        height: 12px;
        font-size: 12px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: rgba(101, 101, 101, 1);
        margin: 8px 0 0 20px;
      }
      .LoacalAnesEdit_Main_Row1_Column4 {
        width: 68px;
        height: 12px;
        font-size: 12px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: rgba(84, 82, 86, 1);

        margin: 8px 0 0 10px;
      }
      .LoacalAnesEdit_Main_Row1_Column5 {
        width: 24px;
        height: 13px;
        font-size: 12px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: rgba(101, 101, 101, 1);
        margin: 8px 0 0 10px;
      }
      .LoacalAnesEdit_Main_Row1_Column6 {
        width: 40px;
        height: 12px;
        font-size: 12px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        font-style: italic;
        color: rgba(158, 160, 163, 1);
        margin: 8px 0 0 10px;
      }
      .LoacalAnesEdit_Main_Row1_Column7 {
        width: 24px;
        height: 12px;
        font-size: 12px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: rgba(101, 101, 101, 1);
        margin: 8px 0 0 10px;
      }
      .LoacalAnesEdit_Main_Row1_Column8 {
        width: 52px;
        height: 11px;
        font-size: 12px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        font-style: italic;
        color: rgba(158, 160, 163, 1);
        margin: 8px 0 0 10px;
      }
      .LoacalAnesEdit_Main_Row1_Column9 {
        width: 24px;
        height: 12px;
        font-size: 12px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: rgba(101, 101, 101, 1);
        margin: 8px 0 0 10px;
      }
      .LoacalAnesEdit_Main_Row1_Column10 {
        width: 68px;
        height: 11px;
        font-size: 12px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        font-style: italic;
        color: rgba(158, 160, 163, 1);
        margin: 8px 0 0 12px;
      }
    }
    .LoacalAnesEdit_Main_Row2 {
      width: 705px;
      height: 1px;
      background: rgba(224, 224, 224, 1);
      margin: 15px 0 0 0;
    }
    .LoacalAnesEdit_Main_Row3 {
      height: 35px;
      display: flex;
      flex-direction: row;
      margin: 20px 0 0 0;
      .LoacalAnesEdit_Main_Row3_Column1 {
        width: 48px;
        height: 12px;
        font-size: 12px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: rgba(101, 101, 101, 1);
        margin: 8px 0 0 16px;
      }
      .LoacalAnesEdit_Main_Row3_Column2 {
        width: 241px;
        height: 28px;
        background: rgba(20, 68, 109, 1);
        border-radius: 5px;
        margin: 0 0 0 27px;
      }
      .LoacalAnesEdit_Main_Row3_Column3 {
        width: 36px;
        height: 12px;
        font-size: 12px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: rgba(101, 101, 101, 1);
        margin: 8px 0 0 51px;
      }
      .LoacalAnesEdit_Main_Row3_Column4 {
        width: 138px;
        height: 28px;
        background: rgba(20, 68, 109, 1);
        border-radius: 5px;
        margin: 0 0 0 28px;
        font-size: 12px;
      }
      .LoacalAnesEdit_Main_Row3_Column5 {
        width: 84px;
        height: 28px;
        background: rgba(20, 68, 109, 1);
        border-radius: 5px;
        margin: 0 0 0 7px;
        .selectItem {
          font-size: 14px;
          line-height: 34px;
        }
        .selectItem span {
          margin-left: 10px;
        }
      }
    }
    .LoacalAnesEdit_Main_Row4 {
      height: 35px;
      display: flex;
      flex-direction: row;
      margin: 20px 0 0 0;
      .LoacalAnesEdit_Main_Row4_Column1 {
        width: 48px;
        height: 12px;
        font-size: 12px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: rgba(101, 101, 101, 1);
        margin: 8px 0 0 16px;
      }
      .LoacalAnesEdit_Main_Row4_Column2 {
        width: 241px;
        height: 28px;
        background: rgba(20, 68, 109, 1);
        border-radius: 5px;
        margin: 0 0 0 27px;
      }
      .LoacalAnesEdit_Main_Row4_Column3 {
        width: 48px;
        height: 13px;
        font-size: 12px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: rgba(101, 101, 101, 1);
        margin: 8px 0 0 53px;
      }
      .LoacalAnesEdit_Main_Row4_Column4 {
        width: 135px;
        height: 12px;
        font-size: 12px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: rgba(158, 160, 163, 1);
        margin: 8px 0 0 33px;
      }
    }
    .LoacalAnesEdit_Main_Row5 {
      height: 35px;
      display: flex;
      flex-direction: row;
      margin: 20px 0 0 0;
      .LoacalAnesEdit_Main_Row5_Column1 {
        width: 48px;
        height: 12px;
        font-size: 12px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: rgba(101, 101, 101, 1);
        margin: 8px 0 0 16px;
      }
      .LoacalAnesEdit_Main_Row5_Column2 {
        width: 84px;
        height: 28px;
        background: rgba(20, 68, 109, 1);
        border-radius: 5px;
        margin: 0 0 0 27px;
      }
      .LoacalAnesEdit_Main_Row5_Column3 {
        width: 84px;
        height: 28px;
        background: rgba(20, 68, 109, 1);
        border-radius: 5px;
        margin: 0 0 0 3px;
      }
      .LoacalAnesEdit_Main_Row5_Column4 {
        width: 24px;
        height: 12px;
        font-size: 12px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: rgba(101, 101, 101, 1);
        margin: 8px 0 0 123px;
      }
      .LoacalAnesEdit_Main_Row5_Column5 {
        width: 82px;
        height: 28px;
        display: flex;
        flex-direction: row;
        border-radius: 5px;
        margin: 0 0 0 40px;

        .LoacalAnesEdit_Main_Row5_Column5_Span {
          color: #656565;
          line-height: 28px;
          margin: 0 0 0 2px;
        }
      }
    }
    .LoacalAnesEdit_Main_Row6 {
      height: 35px;
      display: flex;
      flex-direction: row;
      margin: 20px 0 0 0;
      .LoacalAnesEdit_Main_Row6_Column1 {
        width: 48px;
        height: 12px;
        font-size: 12px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: rgba(101, 101, 101, 1);
        margin: 8px 0 0 16px;
      }
      .LoacalAnesEdit_Main_Row6_Column2 {
        width: 587px;
        height: 28px;
        background: rgba(20, 68, 109, 1);
        border-radius: 5px;
        margin: 0 0 0 27px;
      }
    }
    .LoacalAnesEdit_Main_Row7 {
      height: 35px;
      display: flex;
      flex-direction: row;
      margin: 20px 0 0 0;
      .LoacalAnesEdit_Main_Row7_Column1 {
        width: 48px;
        height: 12px;
        font-size: 12px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: rgba(101, 101, 101, 1);
        margin: 8px 0 0 16px;
      }
      .LoacalAnesEdit_Main_Row7_Column2 {
        width: 244px;
        height: 28px;
        background: rgba(20, 68, 109, 1);
        border-radius: 5px;
        margin: 0 0 0 27px;
      }
      .LoacalAnesEdit_Main_Row7_Column3 {
        width: 48px;
        height: 13px;
        font-size: 12px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: rgba(101, 101, 101, 1);
        margin: 8px 0 0 50px;
      }
      .LoacalAnesEdit_Main_Row7_Column4 {
        width: 84px;
        height: 28px;
        background: rgba(20, 68, 109, 1);
        border-radius: 5px;
        margin: 0 0 0 27px;
      }
    }
    .LoacalAnesEdit_Main_Row8 {
      height: 35px;
      display: flex;
      flex-direction: row;
      margin: 20px 0 0 0;
      .LoacalAnesEdit_Main_Row8_Column1 {
        width: 48px;
        height: 12px;
        font-size: 12px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: rgba(101, 101, 101, 1);
        margin: 8px 0 0 16px;
      }
      .LoacalAnesEdit_Main_Row8_Column2 {
        width: 587px;
        height: 28px;
        background: rgba(20, 68, 109, 1);
        border-radius: 5px;
        margin: 0 0 0 27px;
      }
    }
    .LoacalAnesEdit_Main_Row9 {
      height: 35px;
      display: flex;
      flex-direction: row;
      margin: 20px 0 0 0;
      .LoacalAnesEdit_Main_Row9_Column1 {
        width: 48px;
        height: 12px;
        font-size: 12px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: rgba(101, 101, 101, 1);
        margin: 8px 0 0 16px;
      }
      .LoacalAnesEdit_Main_Row9_Column2 {
        width: 84px;
        height: 28px;
        background: rgba(20, 68, 109, 1);
        border-radius: 5px;
        margin: 0 0 0 27px;
      }
      .LoacalAnesEdit_Main_Row9_Column3 {
        width: 84px;
        height: 28px;
        background: rgba(20, 68, 109, 1);
        border-radius: 5px;
        margin: 0 0 0 10px;
      }
      .LoacalAnesEdit_Main_Row9_Column4 {
        width: 24px;
        height: 12px;
        font-size: 12px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: rgba(101, 101, 101, 1);
        margin: 8px 0 0 126px;
      }
      .LoacalAnesEdit_Main_Row9_Column5 {
        width: 84px;
        height: 28px;
        background: rgba(20, 68, 109, 1);
        border-radius: 5px;
        margin: 0 0 0 39px;
      }
      .LoacalAnesEdit_Main_Row9_Column6 {
        width: 84px;
        height: 28px;
        background: rgba(20, 68, 109, 1);
        border-radius: 5px;
        margin: 0 0 0 10px;
      }
    }
    .LoacalAnesEdit_Main_Row10 {
      height: 35px;
      width: 705px;
      display: flex;
      flex-direction: row;
      margin: 20px 0 0 0;
      .LoacalAnesEdit_Main_Row10_Left {
        width: 352px;
        height: 1px;
        background: rgba(224, 224, 224, 1);
        margin: 4px 0 0 0;
      }
      .LoacalAnesEdit_Main_Row10_Content {
        width: 140px;
        height: 12px;
        font-size: 12px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: rgba(175, 175, 175, 1);
        text-align: center;
      }
      .LoacalAnesEdit_Main_Row10_Right {
        width: 353px;
        height: 1px;
        background: rgba(224, 224, 224, 1);
        margin: 4px 0 0 0;
      }
    }
    .LoacalAnesEdit_Main_Row11 {
      height: 35px;
      font-size: 10px;
      display: flex;
      flex-direction: row;
      margin: 20px 0 0 0;
      .LoacalAnesEdit_Main_Row11_Column1 {
        width: 174px;
        height: 78px;
        background: rgba(51, 178, 244, 1);
        border-radius: 5px;
        margin: 0 0 0 5px;
        .LoacalAnesEdit_Main_Row11_Column1_Top {
          width: 48px;
          height: 12px;
          font-size: 12px;
          font-family: MicrosoftYaHei-Bold;
          font-weight: bold;
          color: rgba(255, 255, 255, 1);
          margin: 14px 62px 0 64px;
        }
        .LoacalAnesEdit_Main_Row11_Column1_Main {
          width: 153px;
          height: 26px;
          background: rgba(255, 255, 255, 1);
          border-radius: 5px;
          margin: 12px 11px 14px 10px;
        }
      }
    }
  }

  .LoacalAnesEdit_Bottom {
    margin: 59px 0 0 0;
    .LoacalAnesEdit_Bottom1 {
      float: right;
      margin: 0 55px 0 0;
      .LoacalAnesEdit_Bottom_Left {
        width: 99px;
        height: 28px;
        background: #ffffff;
        color: rgba(80, 80, 80, 1);
        box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
        border-radius: 3px;
        margin: 34px 17px 0 0;
      }
      .LoacalAnesEdit_Bottom_Right {
        width: 99px;
        height: 28px;
        background: rgba(0, 188, 241, 1);
        box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
        border-radius: 3px;
        margin: 34px 17px 0 0;
      }
    }
  }
}
.LocalAnesSelect {
  width: 1276px;
  height: 540px;
  background: rgba(255, 255, 255, 1);
  box-shadow: 0px 0px 8px 0px rgba(48, 50, 51, 0.55);
  border-radius: 5px;
  display: flex;
  flex-direction: column;
  .LocalAnesSelect_Header {
    width: 1276px;
    height: 4px;
    background: rgba(29, 174, 241, 1);
    border-radius: 5px;
  }
  .LocalAnesSelect_Top {
    width: 84px;
    height: 15px;
    font-size: 14px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(80, 80, 80, 1);
    margin: 20px 0 0 25px;
  }

  .LocalAnesSelect_Main {
    margin: 21px 11px 0 12px;
    .tableHead {
      text-align: center;
      height: 53px;
      background: rgba(255, 255, 255, 1);
      border: 1px solid rgba(233, 234, 235, 1);
      font-size: 12px;
      font-family: MicrosoftYaHei;
      font-weight: 400;
      color: rgba(74, 74, 74, 1);
      vertical-align: middle;
      line-height: 53px;
    }
    .tableHeadDisplay {
      text-align: center;
      height: 0px;
      background: rgba(255, 255, 255, 1);
      border: 0px solid rgba(233, 234, 235, 1);
      font-size: 12px;
      font-family: MicrosoftYaHei;
      font-weight: 400;
      color: rgba(74, 74, 74, 1);
      vertical-align: middle;
      line-height: 53px;
    }
    .tableSingleRow {
      height: 53px;
      color: rgba(74, 74, 74, 1);
      background: #d8f0fa;
      text-align: center;
      border-right: 1px solid #d8f0fa;
    }
    .tableDoubleRow {
      height: 53px;
      color: rgba(74, 74, 74, 1);
      text-align: center;
      background: rgba(255, 255, 255, 1);
      border-right: 1px solid rgba(233, 234, 235, 1);
    }
    td {
      vertical-align: middle;
      font-size: 12px;
    }
  }
}
</style>
<style>
.LoacalAnesEdit_Main .el-input__inner {
  -webkit-appearance: none;
  background: #f7f7f7;
  background-image: none;
  border-radius: 4px;
  border: 0px solid #dcdfe6;
  -webkit-box-sizing: border-box;
  box-sizing: border-box;
  color: #606266;
  display: inline-block;
  /* font-size: inherit; */
  height: 28px;
  line-height: 28px;
  outline: 0;
  padding: 0 15px;
  -webkit-transition: border-color 0.2s cubic-bezier(0.645, 0.045, 0.355, 1);
  transition: border-color 0.2s cubic-bezier(0.645, 0.045, 0.355, 1);
  width: 100%;
}

.LoacalAnesEdit_Main_Row11 .el-input__inner {
  width: 153px;
  height: 26px;
  padding: 0 10px;
  text-align: center;
}

.LoacalAnesEdit_Main_Row11 .el-input__icon {
  height: 100%;
  width: 15px;
  text-align: center;
  -webkit-transition: all 0.3s;
  transition: all 0.3s;
  line-height: 25px;
  display: none;
}

.LoacalAnesEdit_Bottom .el-button {
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
  padding: 6px 20px;
  font-size: 14px;
  border-radius: 4px;
}

.LoacalAnesEdit_Main_Row1_Column2_Left .el-input__inner {
  border: 0px;
}
.LoacalAnesEdit_viewdialog .el-dialog__header {
  padding: 0px 0px 0px;
}

.LoacalAnesEdit_viewdialog .el-dialog__body {
  padding: 0px 0px;
  color: #606266;
  font-size: 14px;
  height: 540px;
  background: rgba(255, 255, 255, 1);
  box-shadow: 0px 0px 8px 0px rgba(48, 50, 51, 0.55);
  border-radius: 5px;
}

.LocalAnesSelect_Main .el-checkbox__inner {
  border-color: rgba(137, 201, 151, 1);
}
.LocalAnesSelect_Main .el-checkbox__input.is-checked + .el-checkbox__label {
  color: #4a4a4a;
}
.LocalAnesSelect_Main .el-checkbox__label {
  display: inline-block;
  padding-left: 10px;
  line-height: 19px;
  font-size: 12px;
}
.LoacalAnesEdit ::-webkit-input-placeholder {
  font-style: italic;
}

.LoacalAnesEdit_Main_Row3_Column4 .el-input__icon {
  line-height: 26px;
}
</style>
