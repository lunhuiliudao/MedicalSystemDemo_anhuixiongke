<template>
  <div class="regtister">
    <div class="register_Left">
      <ScrollBar></ScrollBar>
    </div>
    <div class="register_Right">
      <div class="register_Right_Top">
        <div class="register_Right_Top1">
          <el-button class="register_Right_Top_Left" type="info" @click="ClearForm()">清空</el-button>
          <el-button
            class="register_Right_Top_Right"
            type="primary"
            @click="saveAnesthesiaInputData()"
          >保存</el-button>
        </div>
      </div>
      <div class="register_Right_Menu">
        <div class="register_Right_Menu_Div" v-for="(item, index) in steps" :key="index">
          <span class="register_Right_Menu_Span">{{(index+1)+'.'+item.lable}}</span>
        </div>
      </div>
      <el-scrollbar class="register_Right_Content">
        <div id="roll1_top" class="register_Right_Content1">
          <div class="register_Right_Content1_Top"></div>

          <div class="register_Right_Content1_Main">
            <div class="register_Right_Content1_Main_1">
              1.基本信息
              <div class="mdsdRadioSingle2" style="margin-left:40px;">
                <el-radio-group v-model="isOutRoomOper">
                  <el-radio @click.native.prevent="clickitemOut('室内')" label="室内">室内</el-radio>
                  <el-radio @click.native.prevent="clickitemOut('室外')" label="室外">室外</el-radio>
                </el-radio-group>
              </div>
            </div>
            <div class="register_Right_Content1_Main_2">
              <div class="register_Right_Content1_Main_2_Row1">
                <div class="register_Right_Content1_Main_2_Row1_column1">住院/门诊号</div>
                <div class="register_Right_Content1_Main_2_Row1_column2">
                  <div class="register_Right_Content1_Main_2_Row1_column2_1">
                    <div class="register_Right_Content1_Main_2_Row1_column2_Left">
                      <el-input
                        placeholder="住院号"
                        v-model="patientBaseData.INP_NO"
                        clearable
                        :readonly="isUpload"
                        @keyup.enter.native="getPatientBaseInfo(patientBaseData.INP_NO)"
                      ></el-input>
                    </div>
                    <div class="register_Right_Content1_Main_2_Row1_column2_Center">选择手术</div>
                    <div class="register_Right_Content1_Main_2_Row1_column2_Right">
                      <div
                        class="register_Right_Content1_Main_2_Row1_column2_Right_Text"
                        @click="getPatientBaseInfo(patientBaseData.INP_NO)"
                      >{{MaxOperId}}</div>
                    </div>
                  </div>
                </div>
                <div class="register_Right_Content1_Main_2_Row1_column3">姓名</div>
                <div class="register_Right_Content1_Main_2_Row1_column4">
                  <el-input
                    placeholder="请输入姓名"
                    :readonly="isdisabled"
                    clearable
                    v-model="patientBaseData.NAME"
                  ></el-input>
                </div>
                <div class="register_Right_Content1_Main_2_Row1_column5">性别</div>
                <div class="register_Right_Content1_Main_2_Row1_column6 mdsdRadioSingle2">
                  <el-radio-group v-model="patientBaseData.SEX" :disabled="isdisabled">
                    <el-radio @click="clickitemSex('男')" label="男">男</el-radio>
                    <el-radio @click="clickitemSex('女')" label="女">女</el-radio>
                    <el-radio @click="clickitemSex('0')" label="0">未知</el-radio>
                  </el-radio-group>
                </div>
              </div>
              <div class="register_Right_Content1_Main_2_Row2">
                <div class="register_Right_Content1_Main_2_Row2_column1">出生日期</div>
                <div class="register_Right_Content1_Main_2_Row2_column2">
                  <el-date-picker
                    v-model="patientBaseData.DATE_OF_BIRTH"
                    type="date"
                    placeholder="选择日期"
                    style="width:153px;"
                    :readonly="isdisabled"
                  ></el-date-picker>
                </div>
                <div class="register_Right_Content1_Main_2_Row2_column3">身高|体重</div>
                <div class="register_Right_Content1_Main_2_Row2_column4">
                  <el-input
                    placeholder="身高"
                    :readonly="isdisabled"
                    clearable
                    v-model="patientBaseData.BODY_HEIGHT"
                  ></el-input>
                  <span style="color:#656565;">cm</span>
                  <el-input
                    placeholder="体重"
                    :readonly="isdisabled"
                    clearable
                    v-model="patientBaseData.BODY_WEIGHT"
                  ></el-input>
                  <span style="color:#656565;">kg</span>
                </div>
              </div>
              <div class="register_Right_Content1_Main_2_Row3">
                <div class="register_Right_Content1_Main_2_Row3_column1">手术类别</div>
                <div class="register_Right_Content1_Main_2_Row3_column2 mdsdRadioSingle2">
                  <el-radio-group v-model="patientBaseData.EMERGENCY_IND" :disabled="isdisabled">
                    <el-radio label="1">急诊</el-radio>
                    <el-radio label="0">择期</el-radio>
                  </el-radio-group>
                </div>
                <div class="register_Right_Content1_Main_2_Row3_column3">手术科室</div>
                <div class="register_Right_Content1_Main_2_Row3_column4">
                  <MedSelect
                    class="register_Right_Content1_Main_2_Row3_column4_operdept"
                    type="DeptDict"
                    :remote="false"
                    :islocal="false"
                    :filterable="false"
                    :disabled="isdisabled"
                    clearable
                    placeholder="手术科室"
                    v-model="patientBaseData.DEPT_CODE"
                  ></MedSelect>
                </div>
                <div class="register_Right_Content1_Main_2_Row3_column5">手术名称</div>
                <div class="register_Right_Content1_Main_2_Row3_column6">
                  <InputSelect
                    type="OperNameDict"
                    replaceKeys="＋,﹢,﹢"
                    showKey="+"
                    :ismultiple="true"
                    placeholder="手术名称"
                    :islocal="true"
                    :disabled="isdisabled"
                    v-model="patientBaseData.OPERATION_NAME"
                  ></InputSelect>
                </div>
              </div>
              <div class="register_Right_Content1_Main_2_Row4">
                <div class="register_Right_Content1_Main_2_Row4_column1">诊断名称</div>
                <div class="register_Right_Content1_Main_2_Row4_column2" style="width:261px;">
                  <InputSelect
                    style="width:261px;"
                    type="DiagnosisDict"
                    replaceKeys="＋,﹢,﹢"
                    showKey="+"
                    placeholder="诊断名称"
                    :disabled="isdisabled"
                    :ismultiple="true"
                    v-model="patientBaseData.DIAG_AFTER_OPERATION"
                  ></InputSelect>
                </div>
                <div class="register_Right_Content1_Main_2_Row4_column3">麻醉方式</div>
                <div class="register_Right_Content1_Main_2_Row4_column4">
                  <InputSelect
                    type="AnesMethodDict"
                    placeholder="麻醉方式"
                    :disabled="isdisabled"
                    :ismultiple="true"
                    v-model="patientBaseData.ANES_METHOD"
                  ></InputSelect>
                </div>
              </div>
              <div class="register_Right_Content1_Main_2_Row5">
                <div class="register_Right_Content1_Main_2_Row5_column1">ASA分级</div>
                <div class="register_Right_Content1_Main_2_Row5_column2">
                  <MedSelect
                    type="ASADict"
                    :remote="false"
                    :filterable="false"
                    clearable
                    placeholder="ASA分级"
                    :disabled="isdisabled"
                    v-model="patientBaseData.ASA_GRADE"
                  ></MedSelect>
                </div>
                <div class="register_Right_Content1_Main_2_Row5_column3">麻醉开始</div>
                <div class="register_Right_Content1_Main_2_Row5_column4">
                  <!-- <el-date-picker
                    v-model="patientBaseData.ANES_START_TIME"
                    type="datetime"
                    placeholder="麻醉开始"
                    style="width:163px;"
                    :disabled="isdisabled"
                    clearable
                  ></el-date-picker>-->
                  <el-date-picker
                    v-model="patientBaseData.ANES_START_TIME"
                    type="datetime"
                    style="width:163px;"
                    :disabled="isdisabled"
                    clearable
                    placeholder="麻醉开始"
                  ></el-date-picker>
                </div>
                <div class="register_Right_Content1_Main_2_Row5_column5">麻醉结束</div>
                <div class="register_Right_Content1_Main_2_Row5_column6">
                  <!-- <el-date-picker
                    v-model="patientBaseData.ANES_END_TIME"
                    type="datetime"
                    placeholder="麻醉结束"
                    class="register_Right_Content1_Main_2_Row5_column6_date"
                    :disabled="isdisabled"
                    clearable
                  ></el-date-picker>-->
                  <el-date-picker
                    v-model="patientBaseData.ANES_END_TIME"
                    type="datetime"
                    class="register_Right_Content1_Main_2_Row5_column6_date"
                    :disabled="isdisabled"
                    clearable
                    placeholder="麻醉开始"
                  ></el-date-picker>
                </div>
              </div>
            </div>
          </div>
        </div>

        <div id="roll2_top" class="register_Right_Content2">
          <div class="register_Right_Content2_Top"></div>
          <div class="register_Right_Content2_Main">
            <div class="register_Right_Content2_Main_1">2.不良事件报告要求及注意事项</div>
            <div class="register_Right_Content2_Main_2">
              1.实行无责上报制度
              <br>2.坚持非处罚，主动上报，保密的原则
              <br>3.24小时内报告当地质控中心
              <br>4.如药物不良反应（包括过敏反应）或器械不良事件，请注明药品，器械名称，厂家，批号/型号等相关信息。
            </div>
          </div>
        </div>

        <div id="roll3_top" class="register_Right_Content3">
          <div class="register_Right_Content3_Top"></div>
          <div class="register_Right_Content3_Main">
            <div class="register_Right_Content3_Main_1">3.简述不良事件的发生经过</div>
            <div class="register_Right_Content3_Main_2">
              <el-input
                v-model="medAnesthesiaInputData.EVENT_COURSE"
                type="textarea"
                :rows="4"
                resize="none"
                style="height:120px;font-family:MicrosoftYaHei;"
                placeholder="简述不良事件的发生经过"
                :readonly="isUpload"
              ></el-input>
            </div>
          </div>
        </div>

        <div id="roll4_top" class="register_Right_Content4">
          <div class="register_Right_Content4_Top"></div>
          <div class="register_Right_Content4_Main">
            <div class="register_Right_Content4_Main_1">4.不良事件选择（多选）</div>
            <div class="register_Right_Content4_Main_2 mdsdCheckBox">
              <div class="register_Right_Content4_Main_2_1">
                <el-checkbox
                  v-model="medAnesthesiaInputData.CANCELED_TYPE"
                  style="width:220px;"
                  true-label="1"
                  false-label="0"
                  label="麻醉开始后手术取消"
                  border
                  :disabled="isUpload"
                ></el-checkbox>
                <el-checkbox
                  v-model="medAnesthesiaInputData.PACU_3H"
                  style="width:220px;"
                  true-label="1"
                  false-label="0"
                  label="入PACU超过3小时"
                  border
                  :disabled="isUpload"
                ></el-checkbox>
                <el-checkbox
                  v-model="medAnesthesiaInputData.PACU_TEMPERATURE"
                  style="width:220px;"
                  :true-label="1"
                  :false-label="0"
                  label="PACU入室低体温"
                  border
                  :disabled="isUpload"
                ></el-checkbox>
                <el-checkbox
                  v-model="medAnesthesiaInputData.NO_PLAN_IN_ICU"
                  style="width:220px;"
                  :true-label="1"
                  :false-label="0"
                  label="非计划转入ICU"
                  border
                  :disabled="isUpload"
                ></el-checkbox>
              </div>
              <div class="register_Right_Content4_Main_2_1">
                <el-checkbox
                  v-model="medAnesthesiaInputData.TRACHEA_6H"
                  style="width:220px;"
                  :true-label="1"
                  :false-label="0"
                  label="非计划二次气管插管"
                  border
                  :disabled="isUpload"
                ></el-checkbox>
                <el-checkbox
                  v-model="medAnesthesiaInputData.ANES_START_24H_DEATH"
                  style="width:220px;"
                  :true-label="1"
                  :false-label="0"
                  label="麻醉开始后24小时内死亡"
                  border
                  :disabled="isUpload"
                ></el-checkbox>
                <el-checkbox
                  v-model="medAnesthesiaInputData.ANES_START_24H_STOP"
                  style="width:220px;"
                  :true-label="1"
                  :false-label="0"
                  label="麻醉开始后24小时内心跳骤停"
                  border
                  :disabled="isUpload"
                ></el-checkbox>
                <el-checkbox
                  v-model="medAnesthesiaInputData.ANES_ANAPHYLAXIS"
                  style="width:220px;"
                  :true-label="1"
                  :false-label="0"
                  label="麻醉期间严重过敏反应"
                  border
                  :disabled="isUpload"
                ></el-checkbox>
              </div>
              <div class="register_Right_Content4_Main_2_1">
                <el-checkbox
                  v-model="medAnesthesiaInputData.SPINAL_ANES_COMP"
                  style="width:220px;"
                  :true-label="1"
                  :false-label="0"
                  label="椎管内麻醉后严重神经并发症"
                  border
                  :disabled="isUpload"
                ></el-checkbox>
                <el-checkbox
                  v-model="medAnesthesiaInputData.CENTRAL_VENOUS"
                  style="width:220px;"
                  :true-label="1"
                  :false-label="0"
                  label="中心静脉穿刺严重并发症"
                  border
                  :disabled="isUpload"
                ></el-checkbox>
                <el-checkbox
                  v-model="medAnesthesiaInputData.TRACHEA_HOARSE"
                  style="width:220px;"
                  :true-label="1"
                  :false-label="0"
                  label="全麻气管插管拔管后声音嘶哑"
                  border
                  :disabled="isUpload"
                ></el-checkbox>
                <el-checkbox
                  v-model="medAnesthesiaInputData.AFTER_ANES_COMA"
                  style="width:220px;"
                  :true-label="1"
                  :false-label="0"
                  label="麻醉后新发昏迷"
                  border
                  :disabled="isUpload"
                ></el-checkbox>
              </div>
            </div>
          </div>
        </div>

        <div id="roll5_top" class="register_Right_Content5">
          <div class="register_Right_Content5_Top"></div>
          <div class="register_Right_Content5_Main">
            <div class="register_Right_Content5_Main_1">5.不良事件分级</div>
            <div class="register_Right_Content5_Main_2 mdsdRadioSingle">
              <el-radio-group
                class="radioEventGrade"
                style="width:220px;"
                v-model="medAnesthesiaInputData.EVENT_GRADE"
                :disabled="isUpload"
              >
                <el-radio @click.native.prevent="clickitemEventGrade('1')" label="1">Ⅰ级（警讯事件）</el-radio>
                <el-radio @click.native.prevent="clickitemEventGrade('2')" label="2">Ⅱ级（不良后果事件）</el-radio>
                <el-radio @click.native.prevent="clickitemEventGrade('3')" label="3">Ⅲ级（未造成后果事件）</el-radio>
                <el-radio @click.native.prevent="clickitemEventGrade('4')" label="4">Ⅳ级（隐患事件）</el-radio>
              </el-radio-group>
            </div>
          </div>
        </div>

        <div id="roll6_top" class="register_Right_Content6">
          <div class="register_Right_Content6_Top"></div>
          <div class="register_Right_Content6_Main">
            <div class="register_Right_Content6_Main_1">6.不良事件发生原因（多选）</div>
            <div class="register_Right_Content6_Main_2 mdsdCheckBox">
              <el-checkbox
                v-model="medAnesthesiaInputData.OPER_EVENT"
                style="width:158px;"
                :true-label="1"
                :false-label="0"
                label="手术因素"
                border
                :disabled="isUpload"
              ></el-checkbox>
              <el-checkbox
                v-model="medAnesthesiaInputData.ANES_EVENT"
                style="width:158px;"
                :true-label="1"
                :false-label="0"
                label="麻醉因素"
                border
                :disabled="isUpload"
              ></el-checkbox>
              <el-checkbox
                v-model="medAnesthesiaInputData.PAT_INDETIFICATION"
                style="width:158px;"
                :true-label="1"
                :false-label="0"
                label="患者因素"
                border
                :disabled="isUpload"
              ></el-checkbox>
              <el-checkbox
                v-model="medAnesthesiaInputData.OTHER_EVENT"
                style="width:158px;"
                :true-label="1"
                :false-label="0"
                label="其他因素"
                border
                :disabled="isUpload"
              ></el-checkbox>
            </div>
          </div>
        </div>

        <div id="roll7_top" class="register_Right_Content7">
          <div class="register_Right_Content7_Top"></div>
          <div class="register_Right_Content7_Main">
            <div class="register_Right_Content7_Main_1">7.预防措施</div>
            <div class="register_Right_Content7_Main_2">
              <el-input
                type="textarea"
                :rows="4"
                resize="none"
                placeholder="请详细描述预防措施"
                v-model="medAnesthesiaInputData.PREVENT_STEP"
                :readonly="isUpload"
              ></el-input>
            </div>
          </div>
        </div>

        <div id="roll8_top" class="register_Right_Content8">
          <div class="register_Right_Content8_Top"></div>
          <div class="register_Right_Content8_Main">
            <div class="register_Right_Content8_Main_1">
              <div class="register_Right_Content8_Main_1_1">8.上传附件</div>
              <div class="register_Right_Content8_Main_1_2">只能上传word/excel/pdf/txt文件，且不超过100M</div>
            </div>
            <div class="register_Right_Content8_Main_2">
              <el-upload
                class="register_Right_Content8_Main_2_Upload"
                enctype="multipart/form-data;charset=utf-8"
                ref="upload"
                action="aaa"
                name="importfile"
                :onError="uploadError"
                :onSuccess="uploadSuccess"
                :beforeUpload="beforeAvatarUpload"
                :on-change="selectDocChanged"
                drag
                multiple
                :on-preview="handlePreview"
                :on-remove="handleRemove"
                :file-list="fileList"
                :auto-upload="false"
                :limit="5"
                list-type="picture"
                :disabled="isUpload"
              >
                <i class="el-icon-upload"></i>
                <div class="el-upload__text">选择或拖拽附件</div>
              </el-upload>
            </div>
          </div>
          <div class="register_Right_Content8_Bottom"></div>
        </div>
        <div class="register_Right_Bottom">
          <div class="register_Right_Bottom1">
            <el-button class="register_Right_Bottom_Left" type="info" @click="ClearForm()">清空</el-button>
            <el-button
              class="register_Right_Bottom_Right"
              type="primary"
              @click="saveAnesthesiaInputData()"
            >保存</el-button>
          </div>
        </div>
      </el-scrollbar>
    </div>
    <el-dialog
      custom-class="Register_viewdialog"
      width="1000px"
      :visible.sync="dialogVisible"
      :append-to-body="false"
      :close-on-click-modal="true"
      :key="key"
      @close="dialogVisible = false"
    >
      <div class="registerSelect">
        <div class="registerSelect_Header"></div>
        <div class="registerSelect_Top">选择患者手术</div>
        <div class="registerSelect_Main">
          <table style="width:99.2%; table-layout:fixed;word-break:break-all;">
            <thead class="tableHead">
              <th width="110px">住院号</th>
              <th width="70px">住院次数</th>
              <th width="70px">手术次数</th>
              <th width="100px">姓名</th>
              <th width="30%">手术科室</th>
              <th width="40%" style="min-width:180px;">手术名称</th>
              <th width="30%">麻醉方法</th>
              <th width="80px">ASA分级</th>
              <th width="80px">手术日期</th>
            </thead>
          </table>
          <el-scrollbar style="height:400px; width:100%;">
            <div style="width:100%; margin:0px auto; display: flex;
        align-items: center;">
              <table style="width:99.2%;table-layout:fixed;word-break:break-all;">
                <thead class="tableHeadDisplay">
                  <th width="110px"></th>
                  <th width="70px"></th>
                  <th width="70px"></th>
                  <th width="100px"></th>
                  <th width="30%"></th>
                  <th width="40%" style="min-width:180px;"></th>
                  <th width="30%"></th>
                  <th width="80px"></th>
                  <th width="80px"></th>
                </thead>
                <tbody>
                  <tr
                    :class="rowIndex(index)"
                    :key="item.PATIENT_ID + index"
                    v-for="(item,index) in patientBaseDataAll "
                  >
                    <td style="width:110px;">
                      <el-checkbox
                        style="margin-left:14px;"
                        v-model="item.UPLOAD"
                        :true-label="1"
                        :false-label="0"
                        :checked="false"
                        v-on:change.native="selectPatient(item)"
                      >{{item.INP_NO}}</el-checkbox>
                    </td>
                    <td style="width:70px;">{{item.VISIT_ID}}</td>
                    <td style="width:70px;">{{item.OPER_ID}}</td>
                    <td style="width:100px;">
                      <p style="line-height:24px;font-weight:bold;">{{item.NAME}}</p>
                      <p>{{item.SEX}} {{item.AGE}}</p>
                    </td>
                    <td style="width:30%;">{{item.DEPT_NAME}}</td>
                    <td style="width:40%;">
                      <span style="line-height:13px;">{{item.OPERATION_NAME}}</span>
                    </td>
                    <td style="width:30%;">{{item.ANES_METHOD}}</td>
                    <td style="width:80px;">{{item.Asa_Grade}}</td>
                    <td style="width:80px;">
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
import Register from './Register.js'
export default Register
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";

.regtister {
  width: 100%;
  height: 100%;
  display: flex;
  flex-direction: row;
  margin-top: 50px;
}

.register_Left {
  margin-top: 50px;
  height: 768px;
}

.register_Right {
  height: 100%;
  width: 100%;
  margin-left: 30px;

  display: flex;
  flex-direction: column;
}
.register_Right_Content {
  height: 800px;
  width: 100%;
}

.register_Right_Content1 {
  width: 100%;
  height: 251px;
  background: rgba(255, 255, 255, 1);
  box-shadow: 0px 0px 8px 0px rgba(112, 132, 142, 0.15);
  display: flex;
  flex-direction: column;
  margin: 0 0 0 0;

  .register_Right_Content1_Top {
    width: 100%;
    height: 4px;
    background: rgba(43, 202, 234, 1);
  }
  .register_Right_Content1_Main {
    height: 259px;
    display: flex;
    flex-direction: column;
    .register_Right_Content1_Main_1 {
      height: 15px;
      font-size: 14px;
      font-family: MicrosoftYaHei;
      font-weight: 400;
      color: rgba(69, 69, 69, 1);
      margin: 23px 0 0 40px;
      display: flex;
      flex-direction: row;
    }
    .register_Right_Content1_Main_2 {
      width: 100%;
      font-size: 12px;
      font-family: MicrosoftYaHei;
      font-weight: 400;
      color: rgba(49, 49, 49, 1);
      line-height: 22px;
      margin: 0 0 0 43px;
      display: flex;
      flex-direction: column;
      ::-webkit-input-placeholder {
        font-style: italic;
      }
      .register_Right_Content1_Main_2_Row1 {
        width: 100%;
        display: flex;
        flex-direction: row;
        margin: 12px 0 0px 0;
        height: 26px;
        .register_Right_Content1_Main_2_Row1_column1 {
          width: 80px;
          height: 26px;
          font-size: 12px;
          font-family: MicrosoftYaHei;
          font-weight: 400;
          color: rgba(101, 101, 101, 1);
          margin: 2px 0 0 0px;
        }
        .register_Right_Content1_Main_2_Row1_column2 {
          width: 163px;
          height: 26px;
          border-radius: 5px;
          margin: 0 0 0 22px;
          display: flex;
          flex-direction: row;
          .register_Right_Content1_Main_2_Row1_column2_1 {
            width: 163px;
            background: #f7f7f7;
            border: 0px solid #dcdfe6;
            border-radius: 5px;
            display: flex;
            flex-direction: row;
            margin: 0 0 0 3px;
            .register_Right_Content1_Main_2_Row1_column2_Left {
              width: 100px;
              height: 26px;
            }
            .register_Right_Content1_Main_2_Row1_column2_Center {
              width: 60px;
              height: 11px;
              font-size: 10px;
              font-family: MicrosoftYaHei;
              font-weight: 400;
              color: rgba(250, 160, 82, 1);
              line-height: 26px;
            }
            .register_Right_Content1_Main_2_Row1_column2_Right {
              width: 20px;
              height: 16px;
              background: rgba(250, 153, 68, 1);
              border-radius: 5px;
              margin: 4px 0 0 0;
              .register_Right_Content1_Main_2_Row1_column2_Right_Text {
                display: block;
                width: 16px;
                height: 16px;
                font-size: 12px;
                font-family: MicrosoftYaHei-Bold;
                font-weight: bold;
                color: rgba(255, 255, 255, 1);
                margin: -3px auto;
                text-align: center;
              }
            }
          }
        }
        .register_Right_Content1_Main_2_Row1_column3 {
          width: 40px;
          height: 26px;
          font-size: 12px;
          font-family: MicrosoftYaHei;
          font-weight: 400;
          color: rgba(101, 101, 101, 1);
          margin: 2px 0 0 89px;
        }
        .register_Right_Content1_Main_2_Row1_column4 {
          display: flex;
          flex-direction: row;
          width: 163px;
          height: 26px;
          border-radius: 5px;
          margin: 0 0 0 27px;
        }
        .register_Right_Content1_Main_2_Row1_column5 {
          width: 40px;
          height: 26px;
          font-size: 12px;
          font-family: MicrosoftYaHei;
          font-weight: 400;
          color: rgba(101, 101, 101, 1);
          margin: 2px 0 0 69px;
        }
        .register_Right_Content1_Main_2_Row1_column6 {
          width: 150px;
          height: 26px;
          border-radius: 5px;
          margin: 0 0 0 16px;
          font-style: italic;
          .register_Right_Content1_Main_2_Radio {
            font-size: 12px;
            font-family: MicrosoftYaHei;
            font-weight: 400;
            font-style: italic;
          }
        }
      }
      .register_Right_Content1_Main_2_Row2 {
        width: 100%;
        display: flex;
        flex-direction: row;
        margin: 12px 0 0px 0;
        height: 26px;
        .register_Right_Content1_Main_2_Row2_column1 {
          width: 50px;
          height: 26px;
          font-size: 12px;
          font-family: MicrosoftYaHei;
          font-weight: 400;
          color: rgba(101, 101, 101, 1);
          margin: 2px 0 0 17px;
        }
        .register_Right_Content1_Main_2_Row2_column2 {
          width: 163px;
          height: 26px;
          border-radius: 5px;
          margin: 0 0 0 38px;
          display: flex;
          flex-direction: row;
        }
        .register_Right_Content1_Main_2_Row2_column3 {
          width: 55px;
          height: 26px;
          font-size: 12px;
          font-family: MicrosoftYaHei;
          font-weight: 400;
          color: rgba(101, 101, 101, 1);
          margin: 2px 0 0 57px;
        }
        .register_Right_Content1_Main_2_Row2_column4 {
          display: flex;
          flex-direction: row;
          width: 163px;
          height: 26px;
          border-radius: 5px;
          margin: 0 0 0 40px;
        }
      }
      .register_Right_Content1_Main_2_Row3 {
        width: 100%;
        display: flex;
        flex-direction: row;
        margin: 12px 0 0px 0;
        height: 26px;
        .register_Right_Content1_Main_2_Row3_column1 {
          width: 80px;
          height: 26px;
          font-size: 12px;
          font-family: MicrosoftYaHei;
          font-weight: 400;
          color: rgba(101, 101, 101, 1);
          margin: 2px 0 0 17px;
        }
        .register_Right_Content1_Main_2_Row3_column2 {
          width: 163px;
          height: 26px;
          border-radius: 5px;
          margin: 0 0 0 17px;
          display: flex;
          flex-direction: row;
        }
        .register_Right_Content1_Main_2_Row3_column3 {
          width: 55px;
          height: 26px;
          font-size: 12px;
          font-family: MicrosoftYaHei;
          font-weight: 400;
          color: rgba(101, 101, 101, 1);
          margin: 2px 0 0 51px;
        }
        .register_Right_Content1_Main_2_Row3_column4 {
          width: 163px;
          height: 26px;
          border-radius: 5px;
          margin: 0 0 0 39px;
          .register_Right_Content1_Main_2_Row3_column4_operdept {
            width: 163px;
          }
        }
        .register_Right_Content1_Main_2_Row3_column5 {
          width: 55px;
          height: 26px;
          font-size: 12px;
          font-family: MicrosoftYaHei;
          font-weight: 400;
          color: rgba(101, 101, 101, 1);
          margin: 2px 0 0 44px;
        }
        .register_Right_Content1_Main_2_Row3_column6 {
          width: 251px;
          height: 26px;
          border-radius: 5px;
          margin: 0 0 0 34px;
          font-style: italic;
          .register_Right_Content1_Main_2_Radio {
            font-size: 12px;
            font-family: MicrosoftYaHei;
            font-weight: 400;
            font-style: italic;
          }
        }
      }
      .register_Right_Content1_Main_2_Row4 {
        width: 100%;
        display: flex;
        flex-direction: row;
        margin: 12px 0 0px 0;
        height: 26px;
        .register_Right_Content1_Main_2_Row4_column1 {
          width: 80px;
          height: 26px;
          font-size: 12px;
          font-family: MicrosoftYaHei;
          font-weight: 400;
          color: rgba(101, 101, 101, 1);
          margin: 2px 0 0 17px;
        }
        .register_Right_Content1_Main_2_Row4_column2 {
          width: 261px;
          height: 26px;
          border-radius: 5px;
          margin: 0 0 0 11px;
          display: flex;
          flex-direction: row;
        }
        .register_Right_Content1_Main_2_Row4_column3 {
          width: 55px;
          height: 26px;
          font-size: 12px;
          font-family: MicrosoftYaHei;
          font-weight: 400;
          color: rgba(101, 101, 101, 1);
          margin: 2px 0 0 260px;
        }
        .register_Right_Content1_Main_2_Row4_column4 {
          display: flex;
          flex-direction: row;
          width: 251px;
          height: 26px;
          border-radius: 5px;
          margin: 0 0 0 34px;
        }
      }
      .register_Right_Content1_Main_2_Row5 {
        width: 100%;
        display: flex;
        flex-direction: row;
        margin: 12px 0 0px 0;
        height: 26px;
        .register_Right_Content1_Main_2_Row5_column1 {
          width: 80px;
          height: 26px;
          font-size: 12px;
          font-family: MicrosoftYaHei;
          font-weight: 400;
          color: rgba(101, 101, 101, 1);
          margin: 2px 0 0 17px;
        }
        .register_Right_Content1_Main_2_Row5_column2 {
          width: 163px;
          height: 26px;
          border-radius: 5px;
          margin: 0 0 0 11px;
          display: flex;
          flex-direction: row;
        }
        .register_Right_Content1_Main_2_Row5_column3 {
          width: 55px;
          height: 26px;
          font-size: 12px;
          font-family: MicrosoftYaHei;
          font-weight: 400;
          color: rgba(101, 101, 101, 1);
          margin: 2px 0 0 58px;
        }
        .register_Right_Content1_Main_2_Row5_column4 {
          display: flex;
          flex-direction: row;
          width: 163px;
          height: 26px;
          border-radius: 5px;
          margin: 0 0 0 39px;
        }
        .register_Right_Content1_Main_2_Row5_column5 {
          width: 55px;
          height: 26px;
          font-size: 12px;
          font-family: MicrosoftYaHei;
          font-weight: 400;
          color: rgba(101, 101, 101, 1);
          margin: 2px 0 0 44px;
        }
        .register_Right_Content1_Main_2_Row5_column6 {
          width: 156px;
          height: 26px;
          border-radius: 5px;
          margin: 0 0 0 34px;
          .register_Right_Content1_Main_2_Row5_column6_date {
            width: 156px;
          }
        }
      }
    }
  }
}

.register_Right_Content2 {
  width: 100%;
  height: 159px;
  background: rgba(255, 255, 255, 1);
  box-shadow: 0px 0px 8px 0px rgba(112, 132, 142, 0.15);
  display: flex;
  flex-direction: column;
  margin: 14px 0 0 0;
  .register_Right_Content2_Top {
    width: 100%;
    height: 4px;
    background: rgba(246, 204, 93, 1);
  }
  .register_Right_Content2_Main {
    height: 155px;
    display: flex;
    flex-direction: column;
    .register_Right_Content2_Main_1 {
      height: 15px;
      font-size: 14px;
      font-family: MicrosoftYaHei;
      font-weight: 400;
      color: rgba(229, 135, 13, 1);
      margin: 21px 0 0 40px;
    }
    .register_Right_Content2_Main_2 {
      height: 85px;
      font-size: 12px;
      font-family: MicrosoftYaHei;
      font-weight: 400;
      color: rgba(49, 49, 49, 1);
      line-height: 22px;
      margin: 15px 0 0 43px;
    }
  }
}

.register_Right_Content3 {
  width: 100%;
  height: 197px;
  background: rgba(255, 255, 255, 1);
  box-shadow: 0px 0px 8px 0px rgba(112, 132, 142, 0.15);
  display: flex;
  flex-direction: column;
  margin: 14px 0 0 0;
  .register_Right_Content3_Top {
    width: 100%;
    height: 4px;
    background: rgba(43, 202, 234, 1);
  }
  .register_Right_Content3_Main {
    height: 193px;
    display: flex;
    flex-direction: column;
    ::-webkit-input-placeholder {
      font-style: italic;
    }
    .register_Right_Content3_Main_1 {
      height: 15px;
      font-size: 14px;
      font-family: MicrosoftYaHei;
      font-weight: 400;
      color: rgba(69, 69, 69, 1);
      margin: 19px 0 0 40px;
    }
    .register_Right_Content3_Main_2 {
      width: 955px;
      font-family: MicrosoftYaHei;
      margin: 16px 0 0 43px;
    }
  }
}

.register_Right_Content4 {
  width: 100%;
  height: 215px;
  background: rgba(255, 255, 255, 1);
  box-shadow: 0px 0px 8px 0px rgba(112, 132, 142, 0.15);
  display: flex;
  flex-direction: column;
  margin: 14px 0 0 0;
  .register_Right_Content4_Top {
    width: 100%;
    height: 4px;
    background: rgba(43, 202, 234, 1);
  }
  .register_Right_Content4_Main {
    height: 211px;
    display: flex;
    flex-direction: column;
    .register_Right_Content4_Main_1 {
      height: 15px;
      font-size: 14px;
      font-family: MicrosoftYaHei;
      font-weight: 400;
      color: rgba(101, 101, 101, 1);
      margin: 21px 0 0 40px;
    }
    .register_Right_Content4_Main_2 {
      width: 100%;
      margin: 16px 0 0 43px;
      display: flex;
      flex-direction: column;
      .register_Right_Content4_Main_2_1 {
        margin: 5px 0 5px 5px;
        display: flex;
        flex-direction: row;
      }
      .register_Right_Content4_Main_2_2 {
        margin: 10px 0 0 5px;
      }
      .register_Right_Content4_Main_2_3 {
        margin: 10px 0 0 5px;
      }
      .register_Right_Content4_Main_2_CheckBox {
        font-size: 12px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: rgba(119, 119, 119, 1);
      }
    }
  }
}

.register_Right_Content5 {
  width: 100%;
  height: 191px;
  background: rgba(255, 255, 255, 1);
  box-shadow: 0px 0px 8px 0px rgba(112, 132, 142, 0.15);
  display: flex;
  flex-direction: column;
  margin: 14px 0 0 0;
  .register_Right_Content5_Top {
    width: 100%;
    height: 4px;
    background: rgba(43, 202, 234, 1);
  }
  .register_Right_Content5_Main {
    height: 187px;
    display: flex;
    flex-direction: column;
    .register_Right_Content5_Main_1 {
      height: 15px;
      font-size: 14px;
      font-family: MicrosoftYaHei;
      font-weight: 400;
      color: rgba(101, 101, 101, 1);
      margin: 21px 0 0 40px;
    }
    .register_Right_Content5_Main_2 {
      margin: 20px 0 0 68px;
      .register_Right_Content5_Main_2_Radio {
        width: 220px;
        margin: 0 0 8px 0;
        font-size: 12px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: rgba(119, 119, 119, 1);
      }
    }
  }
}

.register_Right_Content6 {
  width: 100%;
  height: 123px;
  background: rgba(255, 255, 255, 1);
  box-shadow: 0px 0px 8px 0px rgba(112, 132, 142, 0.15);
  display: flex;
  flex-direction: column;
  margin: 14px 0 0 0;
  .register_Right_Content6_Top {
    width: 100%;
    height: 4px;
    background: rgba(43, 202, 234, 1);
  }
  .register_Right_Content6_Main {
    height: 119px;
    display: flex;
    flex-direction: column;
    .register_Right_Content6_Main_1 {
      height: 15px;
      font-size: 14px;
      font-family: MicrosoftYaHei;
      font-weight: 400;
      color: rgba(101, 101, 101, 1);
      margin: 21px 0 0 40px;
    }
    .register_Right_Content6_Main_2 {
      margin: 18px 0 0 48px;
    }
    .register_Right_Content6_Main_2_CheckBox {
      font-size: 12px;
      font-family: MicrosoftYaHei;
      font-weight: 400;
      color: rgba(119, 119, 119, 1);
    }
  }
}

.register_Right_Content7 {
  width: 100%;
  height: 197px;
  background: rgba(255, 255, 255, 1);
  box-shadow: 0px 0px 8px 0px rgba(112, 132, 142, 0.15);
  display: flex;
  flex-direction: column;
  margin: 14px 0 0 0;
  .register_Right_Content7_Top {
    width: 100%;
    height: 4px;
    background: rgba(43, 202, 234, 1);
  }
  .register_Right_Content7_Main {
    height: 193px;
    display: flex;
    flex-direction: column;
    ::-webkit-input-placeholder {
      font-style: italic;
    }
    .register_Right_Content7_Main_1 {
      height: 15px;
      font-size: 14px;
      font-family: MicrosoftYaHei;
      font-weight: 400;
      color: rgba(101, 101, 101, 1);
      margin: 19px 0 0 40px;
    }
    .register_Right_Content7_Main_2 {
      width: 955px;
      margin: 16px 0 0 43px;
    }
  }
}

.register_Right_Content8 {
  width: 100%;
  height: 197px;
  background: rgba(255, 255, 255, 1);
  box-shadow: 0px 0px 8px 0px rgba(112, 132, 142, 0.15);
  display: flex;
  flex-direction: column;
  margin: 14px 0 0 0;
  .register_Right_Content8_Top {
    width: 100%;
    height: 4px;
    background: rgba(43, 202, 234, 1);
  }
  .register_Right_Content8_Main {
    height: 248px;

    .register_Right_Content8_Main_1 {
      display: flex;
      flex-direction: row;
      margin: 20px 0 0 40px;
      .register_Right_Content8_Main_1_1 {
        width: 68px;
        height: 14px;
        font-size: 14px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: rgba(101, 101, 101, 1);
        margin: 0 0 0 0;
      }
      .register_Right_Content8_Main_1_2 {
        width: 300px;
        height: 13px;
        font-size: 11px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: rgba(169, 169, 169, 1);
        margin: 0 0 0 20px;
      }
    }

    .register_Right_Content8_Main_2 {
      .register_Right_Content8_Main_2_Upload {
        width: 154px;
        height: 135px;
        //background: rgba(20, 68, 109, 1);
        border: 1px solid rgba(210, 210, 210, 1);
        border-radius: 5px;
        margin: 17px 0 0 49px;
        display: flex;
        flex-direction: row;
      }
    }
  }
}

.register_Right_Bottom {
  height: 200px;
  .register_Right_Bottom1 {
    width: 300px;
    float: right;
    .register_Right_Bottom_Left {
      width: 99px;
      height: 28px;
      background: rgba(208, 223, 230, 1);
      box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
      border-radius: 3px;
      //float: right;
      margin: 34px 17px 0 0;
    }
    .register_Right_Bottom_Right {
      width: 99px;
      height: 28px;
      background: rgba(0, 188, 241, 1);
      box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
      border-radius: 3px;
      //float: right;
      margin: 34px 0 0 0;
    }
  }
}

.register_Right_Top {
  //height: 200px;
  margin-top: -130px;
  .register_Right_Top1 {
    width: 300px;
    float: right;
    .register_Right_Top_Left {
      width: 99px;
      height: 28px;
      background: rgba(208, 223, 230, 1);
      box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
      border-radius: 3px;
      //float: right;
      margin: 34px 17px 0 0;
      color: rgba(80, 80, 80, 1);
    }
    .register_Right_Top_Right {
      width: 99px;
      height: 28px;
      background: rgba(0, 188, 241, 1);
      box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
      border-radius: 3px;
      //float: right;
      margin: 34px 0 0 0;
    }
  }
}

.register_Right_Menu {
  width: 100%;
  height: 70px;
  background: rgba(255, 255, 255, 1);
  box-shadow: 0px 0px 8px 0px rgba(112, 132, 142, 0.15);
  border-radius: 10px;
  margin: 21px 0 15px 0;
  display: flex;
  flex-direction: row;
  .register_Right_Menu_Div {
    width: 12.5%;
    line-height: 70px;
    height: 70px;
    margin: 0 px2rem(18) 0 px2rem(18);
    border-radius: 3px;
    align-items: center;
    .register_Right_Menu_Span {
      margin-top: 10px;
      line-height: 30px;
      width: 100%;
      height: 70px;
      font-size: px2rem(14);
      font-family: MicrosoftYaHei;
      font-weight: 400;
      color: rgba(101, 101, 101, 1);
      display: inline-block;
      word-wrap: break-word;
      white-space: normal;
      //align-items: center;
      // float: left !important;
      // overflow: hidden !important;
      // text-overflow: ellipsis !important;
      // white-space: normal !important;
    }
  }
}
.registerSelect {
  width: 1000px;
  height: 540px;
  background: rgba(255, 255, 255, 1);
  box-shadow: 0px 0px 8px 0px rgba(48, 50, 51, 0.55);
  border-radius: 5px;
  display: flex;
  flex-direction: column;
  .registerSelect_Header {
    width: 1000px;
    height: 4px;
    background: rgba(29, 174, 241, 1);
    border-radius: 5px;
  }
  .registerSelect_Top {
    width: 84px;
    height: 15px;
    font-size: 14px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(80, 80, 80, 1);
    margin: 20px 0 0 25px;
  }

  .registerSelect_Main {
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
@media screen and (min-aspect-ratio: 1001/1000) {
  //横板
  .register_Right_Top {
    display: none;
  }
  .register_Right_Menu {
    display: none;
  }
}

@media screen and (max-width: 768px) and (max-aspect-ratio: 1000/1000) {
  //竖版
  .regtister {
    margin-top: 90px !important;
  }
  .register_Left {
    display: none !important;
  }
  .register_Right {
    width: 100% !important;
    margin-left: 0px !important;
  }
  .register_Right_Content {
    height: 100% !important;
    width: 100% !important;
  }
  .register_Right_Content1 {
    height: 231px !important;
  }

  .register_Right_Content2 {
    height: 154px !important;
  }

  .register_Right_Content3 {
    height: 157px !important;
  }

  .register_Right_Content5 {
    height: 171px !important;
  }

  .register_Right_Content6 {
    height: 113px !important;
  }

  .register_Right_Content7 {
    height: 157px !important;
  }

  .register_Right_Content8 {
    margin: 14px 0 20px 0 !important;
  }
  .register_Right_Bottom {
    display: none !important;
  }

  .register_Right_Content1_Main_1 {
    margin: 13px 0 0 10px !important;
  }

  .register_Right_Content1_Main_2 {
    font-size: 10px !important;
    margin: 0 0 0 10px !important;

    .register_Right_Content1_Main_2_Row1 {
      .register_Right_Content1_Main_2_Row1_column1 {
        width: 80px !important;
        font-size: 10px !important;
        margin: 2px 0 0 0 !important;
      }
      .register_Right_Content1_Main_2_Row1_column2 {
        width: 163px !important;
        margin: 0 0 0 3px !important;

        .register_Right_Content1_Main_2_Row1_column2_1 {
          width: 163px !important;
          margin: 0 0 0 3px !important;
          .register_Right_Content1_Main_2_Row1_column2_Left {
            width: 100px !important;
          }
          .register_Right_Content1_Main_2_Row1_column2_Center {
            width: 60px !important;
            font-size: 10px !important;
          }
          .register_Right_Content1_Main_2_Row1_column2_Right {
            width: 20px !important;
            height: 16px !important;
            margin: 4px 0 0 0 !important;
            .register_Right_Content1_Main_2_Row1_column2_Right_Text {
              font-size: 10px !important;
            }
          }
        }
      }
      .register_Right_Content1_Main_2_Row1_column3 {
        width: 40px !important;
        font-size: 10px !important;
        margin: 2px 0 0 36px !important;
      }
      .register_Right_Content1_Main_2_Row1_column4 {
        width: 143px !important;
        margin: 0 0 0 3px !important;
      }
      .register_Right_Content1_Main_2_Row1_column5 {
        width: 40px !important;
        font-size: 10px !important;
        margin: 2px 0 0 34px !important;
      }
      .register_Right_Content1_Main_2_Row1_column6 {
        width: 150px !important;
        margin: 0 0 0 0px !important;
        .register_Right_Content1_Main_2_Radio {
          font-size: 10px !important;
        }
      }
    }
    .register_Right_Content1_Main_2_Row2 {
      .register_Right_Content1_Main_2_Row2_column1 {
        width: 60px !important;
        font-size: 10px !important;
        margin: 2px 0 0 17px !important;
      }
      .register_Right_Content1_Main_2_Row2_column2 {
        width: 163px !important;
        font-size: 10px !important;
        margin: 0 0 0 10px !important;
      }
      .register_Right_Content1_Main_2_Row2_column3 {
        width: 55px;
        font-size: 10px !important;
        margin: 2px 0 0 4px !important;
      }
      .register_Right_Content1_Main_2_Row2_column4 {
        width: 160px !important;
        margin: 0 0 0 15px !important;
      }
    }
    .register_Right_Content1_Main_2_Row3 {
      .register_Right_Content1_Main_2_Row3_column1 {
        width: 60px !important;
        font-size: 10px !important;
        margin: 2px 0 0 17px !important;
      }
      .register_Right_Content1_Main_2_Row3_column2 {
        width: 163px !important;
        margin: 0 0 0 13px !important;
      }
      .register_Right_Content1_Main_2_Row3_column3 {
        width: 60px !important;
        font-size: 10px !important;
        margin: 2px 0 0 3px !important;
      }
      .register_Right_Content1_Main_2_Row3_column4 {
        width: 143px !important;
        margin: 0 0 0 10px !important;
        .register_Right_Content1_Main_2_Row3_column4_operdept {
          width: 143px !important;
        }
      }
      .register_Right_Content1_Main_2_Row3_column5 {
        width: 60px !important;
        font-size: 10px !important;
        margin: 2px 0 0 10px !important;
      }
      .register_Right_Content1_Main_2_Row3_column6 {
        width: 143px !important;
        margin: 0 0 0 4px !important;
        .register_Right_Content1_Main_2_Radio {
          font-size: 10px !important;
        }
      }
    }
    .register_Right_Content1_Main_2_Row4 {
      .register_Right_Content1_Main_2_Row4_column1 {
        width: 60px !important;
        font-size: 10px !important;
        margin: 2px 0 0 17px !important;
      }
      .register_Right_Content1_Main_2_Row4_column2 {
        width: 261px !important;
        margin: 0 0 0 13px !important;
      }
      .register_Right_Content1_Main_2_Row4_column3 {
        width: 60px !important;
        font-size: 10px !important;
        margin: 2px 0 0 127px !important;
      }
      .register_Right_Content1_Main_2_Row4_column4 {
        width: 143px !important;
        margin: 0 0 0 4px !important;
      }
    }
    .register_Right_Content1_Main_2_Row5 {
      .register_Right_Content1_Main_2_Row5_column1 {
        width: 60px !important;
        font-size: 10px !important;
        margin: 2px 0 0 17px !important;
      }
      .register_Right_Content1_Main_2_Row5_column2 {
        width: 143px !important;
        margin: 0 0 0 13px !important;
      }
      .register_Right_Content1_Main_2_Row5_column3 {
        width: 60px !important;
        font-size: 10px !important;
        margin: 2px 0 0 23px !important;
      }
      .register_Right_Content1_Main_2_Row5_column4 {
        width: 143px !important;
        margin: 0 0 0 9px !important;
      }
      .register_Right_Content1_Main_2_Row5_column5 {
        width: 60px !important;
        font-size: 10px !important;
        margin: 2px 0 0 11px !important;
      }
      .register_Right_Content1_Main_2_Row5_column6 {
        width: 143px !important;
        margin: 0 0 0 4px !important;
        .register_Right_Content1_Main_2_Row5_column6_date {
          width: 143px !important;
        }
      }
    }
  }

  .register_Right_Content2_Main_1 {
    margin: 21px 0 0 10px !important;
  }
  .register_Right_Content2_Main_2 {
    margin: 15px 0 0 13px !important;
  }
  .register_Right_Content3_Main_1 {
    margin: 19px 0 0 10px !important;
  }
  .register_Right_Content3_Main_2 {
    width: 685px !important;
    margin: 16px 0 0 13px !important;
  }

  .register_Right_Content4_Main_1 {
    margin: 21px 0 0 10px !important;
  }
  .register_Right_Content4_Main_2 {
    width: 685px !important;
    font-size: 12px !important;
    margin: 16px 0 0 13px !important;
  }

  .register_Right_Content5_Main_1 {
    margin: 21px 0 0 10px !important;
  }
  .register_Right_Content5_Main_2 {
    margin: 20px 0 0 23px !important;
  }

  .register_Right_Content6_Main_1 {
    margin: 21px 0 0 10px !important;
  }
  .register_Right_Content6_Main_2 {
    margin: 18px 0 0 13px !important;
  }

  .register_Right_Content7_Main_1 {
    margin: 19px 0 0 10px !important;
  }
  .register_Right_Content7_Main_2 {
    width: 685px !important;
    margin: 16px 0 0 13px !important;
  }
  .register_Right_Content8_Main_1 {
    margin: 20px 0 0 10px !important;
  }

  .register_Right_Content8_Main_2 {
    .register_Right_Content8_Main_2_Upload {
      margin: 17px 0 0 13px !important;
    }
  }
}
@media screen and (max-width: 1080px) and (max-aspect-ratio: 1000/1000) {
  //竖版
  .regtister {
    margin-top: 90px !important;
  }
  .register_Left {
    display: none !important;
  }
  .register_Right {
    width: 100% !important;
    margin-left: 0px !important;
  }
  .register_Right_Content {
    height: 100% !important;
    width: 100% !important;
  }
  .register_Right_Content1 {
    height: 231px !important;
  }

  .register_Right_Content2 {
    height: 154px !important;
  }

  .register_Right_Content3 {
    height: 187px !important;
  }

  .register_Right_Content5 {
    height: 171px !important;
  }

  .register_Right_Content6 {
    height: 113px !important;
  }

  .register_Right_Content7 {
    height: 187px !important;
  }

  .register_Right_Content8 {
    margin: 14px 0 20px 0 !important;
  }
  .register_Right_Bottom {
    display: none !important;
  }
}
</style>

<style>
.regtister .el-scrollbar__wrap {
  overflow-x: hidden;
}
.regtister .el-scrollbar__thumb {
  background-color: #1896ca;
  display: none;
}

.register_Right_Content1_Main_2_Row .el-input__inner {
  -webkit-appearance: none;
  background-color: #fff;
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
  padding: 0 15px;
  -webkit-transition: border-color 0.2s cubic-bezier(0.645, 0.045, 0.355, 1);
  transition: border-color 0.2s cubic-bezier(0.645, 0.045, 0.355, 1);
  width: 100%;
}
.register_Right_Content8_Main_2 .el-upload-dragger {
  background-color: #fff;
  border: 1px dashed #d9d9d9;
  border-radius: 6px;
  -webkit-box-sizing: border-box;
  box-sizing: border-box;
  width: 154px;
  height: 135px;
  text-align: center;
  position: relative;
  overflow: hidden;
}

.register_Right_Bottom1 .el-button {
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

.register_Right_Top .el-button {
  display: inline-block;
  line-height: 1;
  white-space: nowrap;
  cursor: pointer;
  background: rgba(208, 223, 230, 1);
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

.regtister .el-textarea__inner {
  font-family: MicrosoftYaHei;
}

.Register_viewdialog .el-dialog__header {
  padding: 0px 0px 0px;
}

.Register_viewdialog .el-dialog__body {
  width: 1000px;
  padding: 0px 0px;
  color: #606266;
  font-size: 14px;
  height: 540px;
  background: rgba(255, 255, 255, 1);
  box-shadow: 0px 0px 8px 0px rgba(48, 50, 51, 0.55);
  border-radius: 5px;
}

.regtisterSelect_Main .el-checkbox__inner {
  border-color: rgba(137, 201, 151, 1);
}
.regtisterSelect_Main .el-checkbox__input.is-checked + .el-checkbox__label {
  color: #4a4a4a;
}
.regtisterSelect_Main .el-checkbox__label {
  display: inline-block;
  padding-left: 10px;
  line-height: 19px;
  font-size: 12px;
}
.radioEventGrade .el-radio + .el-radio {
  margin-left: 0px;
  margin-top: 8px;
}

.register_Right_Content1 .el-input__inner {
  border: 0px;
  background: #f7f7f7;
  height: 22px;
  font-size: 12px;
  padding: 0 5px;
  line-height: 20px;
}
.register_Right_Content1 .el-input.is-disabled .el-input__inner {
  color: #606266;
}

.register_Right_Content1 .el-input__icon {
  line-height: 25px;
}

.register_Right_Content1_Main_2_Row_column2_date .el-input__inner {
  padding-left: 30px;
}

.register_Right_Content3 .el-textarea__inner {
  border: 0px;
  background: #f7f7f7;
}

.register_Right_Content7 .el-textarea__inner {
  border: 0px;
  background: #f7f7f7;
}

.register_Right_Content8_Main_2_Upload .el-upload-list {
  /* padding-left: 10px; */
  margin-top: -10px;
  height: 135px;
  /* width: 135px; */
  display: flex;
  flex-direction: row;
}
.register_Right_Content8_Main_2_Upload
  .el-upload-list--picture
  .el-upload-list__item {
  padding: 10px 10px 10px 10px;
  margin-left: 5px;
  height: 135px;
  width: 135px;
  display: flex;
  flex-direction: column;
}
.register_Right_Content8_Main_2_Upload .el-upload-list__item-name {
  margin-right: 0px;
  text-align: center;
}
.register_Right_Content8_Main_2_Upload
  .el-upload-list--picture
  .el-upload-list__item-thumbnail {
  margin-left: 0px;
}

.register_Right_Content8_Main_2_Upload
  .el-upload-list--picture
  .el-upload-list__item-name
  i {
  margin-left: 23px;
}

.register_Right_Content1_Main_2 .el-input__prefix {
  display: none;
}

@media screen and (max-width: 768px) and (max-aspect-ratio: 1000/1000) {
  .mdsdCheckBox .el-checkbox__input {
    margin-top: 2px !important;
    width: 22px !important;
    height: 22px !important;
  }
  .mdsdCheckBox .el-checkbox.is-bordered {
    padding: 7px 5px 9px 5px !important;
  }
  .mdsdCheckBox .el-checkbox__label {
    font-size: 10px !important;
    line-height: 16px !important;
    padding-left: 2px;
  }
}
</style>
