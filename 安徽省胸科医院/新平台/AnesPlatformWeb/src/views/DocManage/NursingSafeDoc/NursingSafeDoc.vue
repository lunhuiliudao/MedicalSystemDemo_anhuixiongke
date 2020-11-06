<template>
  <div class="MainContent" id="MainContent">
    <!--确保文书打印主体的ID=printaArea,千万不要拼写错误，不然无法上传-->
    <div class="MainPrint" id="printaArea" ref="print" style="font-family:'宋体';">
      <div class="Title">安徽省胸科医院</div>
      <div class="Title" style="font-size:23px;">手术安全核查单</div>
      <div class="Info">
        <div class="InfoKey">科别：</div>
        <div class="InfoValue">{{MedicalBasicDoc.PatientDetail.DEPT_NAME}}</div>
        <div class="InfoKey">姓名：</div>
        <div class="InfoValue">{{MedicalBasicDoc.PatientDetail.NAME}}</div>
        <div class="InfoKey">性别：</div>
        <div class="InfoValue">{{MedicalBasicDoc.PatientDetail.SEX}}</div>
        <div class="InfoKey">年龄：</div>
        <div class="InfoValue">{{MedicalBasicDoc.PatientDetail.AGE}}</div>
        <div class="InfoKey">病案号：</div>
        <div class="InfoValue">{{MedicalBasicDoc.PatientDetail.INP_NO}}</div>
      </div>

      <div class="Info">
        <div class="InfoKey" style="margin-top:18px;">麻醉方式：</div>
        <div class="InfoValue">
          <div class="no-print">
            <InputSelect
              type="AnesMethodDict"
              style="width:680px;"
              placeholder="麻醉方式"
              v-model="MedicalBasicDoc.MED_OPERATION_MASTER.ANES_METHOD"
            ></InputSelect>
          </div>
          <div
            class="show-print"
            style="border-bottom:1px dashed;min-width:500px;margin-top:5px;line-height: 20px;height:20px;"
          >{{MedicalBasicDoc.MED_OPERATION_MASTER.ANES_METHOD}}</div>
        </div>
      </div>

      <div class="Info">
        <div class="InfoKey" style="margin-top:18px;">手术方式：</div>
        <div class="InfoValue">
          <div class="no-print">
            <InputSelect
              type="OperNameDict"
              style="width:680px;"
              replaceKeys="＋,﹢,﹢"
              showKey="+"
              :ismultiple="true"
              placeholder="手术方式"
              :islocal="true"
              v-model="MedicalBasicDoc.PatientDetail.OPERATION_NAME"
            ></InputSelect>
          </div>
          <div
            class="show-print"
            style="border-bottom:1px dashed;min-width:500px;margin-top:5px;line-height: 20px;height:20px;"
          >{{MedicalBasicDoc.MED_OPERATION_MASTER.OPERATION_NAME}}</div>
        </div>
      </div>
      <div class="Info">
        <div class="InfoKey" style="margin-top:18px;">术者：</div>
        <div class="InfoValue" style="margin-top:0px;">
          <div class="no-print">
            <MedSelect
              type="SurgeonDict"
              style="width:200px;margin-top:10px;"
              :remote="true"
              :filterable="true"
              placeholder="术者"
              clearable
              @GetDiaplayValue="GetDiaplayValue"
              v-model="MedicalBasicDoc.MED_OPERATION_MASTER.SURGEON"
            ></MedSelect>
          </div>
          <div
            class="show-print"
            style="border-bottom:1px dashed;min-width:200px;margin-top:13px;line-height: 20px;height:20px;"
          >{{SURGEON_DISPLAY}}</div>
        </div>
        <div class="InfoKey" style="margin-top:18px;margin-left:150px;">手术日期：</div>
        <div class="el-date-picker">
          <div class="no-print">
            <el-date-picker
              style="width:240px;margin-top:10px;"
              v-model="MedicalBasicDoc.MED_OPERATION_MASTER.SCHEDULED_DATE_TIME"
              type="date"
              clearable
              id="inDate"
              :disabled="true"
            ></el-date-picker>
          </div>
          <div
            class="show-print"
            style="border-bottom:1px dashed;min-width:140px;margin-top:15px;line-height: 20px;height:20px;"
          >{{MedicalBasicDoc.MED_OPERATION_MASTER.SCHEDULED_DATE_TIME | formatDate('YYYY-MM-DD')}}</div>
        </div>
      </div>

      <div class="Info">
        <div class="InfoColumn" v-bind:style="{'width':perWidth + 'px'}">
          <div class="InfoColumnTitle">麻醉实施前</div>
          <div class="InfoColumnBaseContent">
            <div class="InfoColumnBaseContentKey" style="margin-top:10px;">患者姓名、性别、年龄正确：</div>
            <div class="InfoColumnBaseContentValue" style="margin-top:5px;">
              <div class="no-print">
                <el-checkbox
                  false-label
                  label="是"
                  true-label="是"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.PATIENT_CONFIRM1"
                ></el-checkbox>
                <el-checkbox
                  false-label
                  label="否"
                  true-label="否"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.PATIENT_CONFIRM1"
                ></el-checkbox>
              </div>
              <div class="show-print">
                <input
                  type="checkbox"
                  id="u1"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.PATIENT_CONFIRM1==='是'?'checked':''"
                />
                <label for="u1">是</label>

                <input
                  type="checkbox"
                  id="u2"
                  value="否"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.PATIENT_CONFIRM1==='否'?'checked':''"
                />
                <label for="u2">否</label>
              </div>
            </div>

            <div class="InfoColumnBaseContentKey">手术方式是否正确：</div>
            <div class="InfoColumnBaseContentValue">
              <div class="no-print">
                <el-checkbox
                  false-label
                  label="是"
                  true-label="是"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.OPERATION_CONFIRM1"
                ></el-checkbox>
                <el-checkbox
                  false-label
                  label="否"
                  true-label="否"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.OPERATION_CONFIRM1"
                ></el-checkbox>
              </div>
              <div class="show-print">
                <input
                  type="checkbox"
                  id="u1"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.OPERATION_CONFIRM1==='是'?'checked':''"
                />
                <label for="u1">是</label>

                <input
                  type="checkbox"
                  id="u2"
                  value="否"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.OPERATION_CONFIRM1==='否'?'checked':''"
                />
                <label for="u2">否</label>
              </div>
            </div>

            <div class="InfoColumnBaseContentKey">手术部位与标识是否正确：</div>
            <div class="InfoColumnBaseContentValue">
              <div class="no-print">
                <el-checkbox
                  false-label
                  label="是"
                  true-label="是"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.OPERATION_POSITION_CONFIRM1"
                ></el-checkbox>
                <el-checkbox
                  false-label
                  label="否"
                  true-label="否"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.OPERATION_POSITION_CONFIRM1"
                ></el-checkbox>
              </div>
              <div class="show-print">
                <input
                  type="checkbox"
                  id="u1"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.OPERATION_POSITION_CONFIRM1==='是'?'checked':''"
                />
                <label for="u1">是</label>

                <input
                  type="checkbox"
                  id="u2"
                  value="否"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.OPERATION_POSITION_CONFIRM1==='否'?'checked':''"
                />
                <label for="u2">否</label>
              </div>
            </div>

            <div class="InfoColumnBaseContentKey">手术知情同意是否正确：</div>
            <div class="InfoColumnBaseContentValue">
              <div class="no-print">
                <el-checkbox
                  false-label
                  label="是"
                  true-label="是"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.OPERATION_APPROVAL_CONFIRM"
                ></el-checkbox>
                <el-checkbox
                  false-label
                  label="否"
                  true-label="否"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.OPERATION_APPROVAL_CONFIRM"
                ></el-checkbox>
              </div>
              <div class="show-print">
                <input
                  type="checkbox"
                  id="u1"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.OPERATION_APPROVAL_CONFIRM==='是'?'checked':''"
                />
                <label for="u1">是</label>

                <input
                  type="checkbox"
                  id="u2"
                  value="否"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.OPERATION_APPROVAL_CONFIRM==='否'?'checked':''"
                />
                <label for="u2">否</label>
              </div>
            </div>

            <div class="InfoColumnBaseContentKey">麻醉知情同意是否正确：</div>
            <div class="InfoColumnBaseContentValue">
              <div class="no-print">
                <el-checkbox
                  false-label
                  label="是"
                  true-label="是"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.ANESTHESIA_APPROVAL_CONFIRM"
                ></el-checkbox>
                <el-checkbox
                  false-label
                  label="否"
                  true-label="否"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.ANESTHESIA_APPROVAL_CONFIRM"
                ></el-checkbox>
              </div>
              <div class="show-print">
                <input
                  type="checkbox"
                  id="u1"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.ANESTHESIA_APPROVAL_CONFIRM==='是'?'checked':''"
                />
                <label for="u1">是</label>

                <input
                  type="checkbox"
                  id="u2"
                  value="否"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.ANESTHESIA_APPROVAL_CONFIRM==='否'?'checked':''"
                />
                <label for="u2">否</label>
              </div>
            </div>

            <div class="InfoColumnBaseContentKey">麻醉方式是否正确：</div>
            <div class="InfoColumnBaseContentValue">
              <div class="no-print">
                <el-checkbox
                  false-label
                  label="是"
                  true-label="是"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.ANESTHESIA_METHOD_CONFIRM"
                ></el-checkbox>
                <el-checkbox
                  false-label
                  label="否"
                  true-label="否"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.ANESTHESIA_METHOD_CONFIRM"
                ></el-checkbox>
              </div>
              <div class="show-print">
                <input
                  type="checkbox"
                  id="u1"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.ANESTHESIA_METHOD_CONFIRM==='是'?'checked':''"
                />
                <label for="u1">是</label>

                <input
                  type="checkbox"
                  id="u2"
                  value="否"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.ANESTHESIA_METHOD_CONFIRM==='否'?'checked':''"
                />
                <label for="u2">否</label>
              </div>
            </div>

            <div class="InfoColumnBaseContentKey">麻醉设备安全检查完成：</div>
            <div class="InfoColumnBaseContentValue">
              <div class="no-print">
                <el-checkbox
                  false-label
                  label="是"
                  true-label="是"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.EQUIPMENT_CONFIRM"
                ></el-checkbox>
                <el-checkbox
                  false-label
                  label="否"
                  true-label="否"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.EQUIPMENT_CONFIRM"
                ></el-checkbox>
              </div>
              <div class="show-print">
                <input
                  type="checkbox"
                  id="u1"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.EQUIPMENT_CONFIRM==='是'?'checked':''"
                />
                <label for="u1">是</label>

                <input
                  type="checkbox"
                  id="u2"
                  value="否"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.EQUIPMENT_CONFIRM==='否'?'checked':''"
                />
                <label for="u2">否</label>
              </div>
            </div>

            <div class="InfoColumnBaseContentKey">皮肤是否完整：</div>
            <div class="InfoColumnBaseContentValue">
              <div class="no-print">
                <el-checkbox
                  false-label
                  label="是"
                  true-label="是"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.SKIN_INTEGRITY_CONFIRM1"
                ></el-checkbox>
                <el-checkbox
                  false-label
                  label="否"
                  true-label="否"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.SKIN_INTEGRITY_CONFIRM1"
                ></el-checkbox>
              </div>
              <div class="show-print">
                <input
                  type="checkbox"
                  id="u1"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.SKIN_INTEGRITY_CONFIRM1==='是'?'checked':''"
                />
                <label for="u1">是</label>

                <input
                  type="checkbox"
                  id="u2"
                  value="否"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.SKIN_INTEGRITY_CONFIRM1==='否'?'checked':''"
                />
                <label for="u2">否</label>
              </div>
            </div>

            <div class="InfoColumnBaseContentKey">术野皮肤准备正确：</div>
            <div class="InfoColumnBaseContentValue">
              <div class="no-print">
                <el-checkbox
                  false-label
                  label="是"
                  true-label="是"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.ALL_SKIN_CONFIRM"
                ></el-checkbox>
                <el-checkbox
                  false-label
                  label="否"
                  true-label="否"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.ALL_SKIN_CONFIRM"
                ></el-checkbox>
              </div>
              <div class="show-print">
                <input
                  type="checkbox"
                  id="u1"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.ALL_SKIN_CONFIRM==='是'?'checked':''"
                />
                <label for="u1">是</label>

                <input
                  type="checkbox"
                  id="u2"
                  value="否"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.ALL_SKIN_CONFIRM==='否'?'checked':''"
                />
                <label for="u2">否</label>
              </div>
            </div>

            <div class="InfoColumnBaseContentKey">静脉通道建立完成：</div>
            <div class="InfoColumnBaseContentValue">
              <div class="no-print">
                <el-checkbox
                  false-label
                  label="是"
                  true-label="是"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.VENOUS_ROUTE"
                ></el-checkbox>
                <el-checkbox
                  false-label
                  label="否"
                  true-label="否"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.VENOUS_ROUTE"
                ></el-checkbox>
              </div>
              <div class="show-print">
                <input
                  type="checkbox"
                  id="u1"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.VENOUS_ROUTE==='是'?'checked':''"
                />
                <label for="u1">是</label>

                <input
                  type="checkbox"
                  id="u2"
                  value="否"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.VENOUS_ROUTE==='否'?'checked':''"
                />
                <label for="u2">否</label>
              </div>
            </div>

            <div class="InfoColumnBaseContentKey">患者是否有过敏史：</div>
            <div class="InfoColumnBaseContentValue">
              <div class="no-print">
                <el-checkbox
                  false-label
                  label="是"
                  true-label="是"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.ALERGY_HISTORY_CONFIRM"
                ></el-checkbox>
                <el-checkbox
                  false-label
                  label="否"
                  true-label="否"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.ALERGY_HISTORY_CONFIRM"
                ></el-checkbox>
              </div>
              <div class="show-print">
                <input
                  type="checkbox"
                  id="u1"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.ALERGY_HISTORY_CONFIRM==='是'?'checked':''"
                />
                <label for="u1">是</label>

                <input
                  type="checkbox"
                  id="u2"
                  value="否"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.ALERGY_HISTORY_CONFIRM==='否'?'checked':''"
                />
                <label for="u2">否</label>
              </div>
            </div>

            <div class="InfoColumnBaseContentKey">抗菌药物皮试结果：</div>
            <div class="InfoColumnBaseContentValue">
              <div class="no-print">
                <el-checkbox
                  false-label
                  label="是"
                  true-label="是"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.SKIN_TEST_RESULT"
                ></el-checkbox>
                <el-checkbox
                  false-label
                  label="否"
                  true-label="否"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.SKIN_TEST_RESULT"
                ></el-checkbox>
              </div>
              <div class="show-print">
                <input
                  type="checkbox"
                  id="u1"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.SKIN_TEST_RESULT==='是'?'checked':''"
                />
                <label for="u1">是</label>

                <input
                  type="checkbox"
                  id="u2"
                  value="否"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.SKIN_TEST_RESULT==='否'?'checked':''"
                />
                <label for="u2">否</label>
              </div>
            </div>

            <div class="InfoColumnBaseContentKey">术前备血：</div>
            <div class="InfoColumnBaseContentValue">
              <div class="no-print">
                <el-checkbox
                  false-label
                  label="是"
                  true-label="是"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.BLOOD_PREPARATION"
                ></el-checkbox>
                <el-checkbox
                  false-label
                  label="否"
                  true-label="否"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.BLOOD_PREPARATION"
                ></el-checkbox>
              </div>
              <div class="show-print">
                <input
                  type="checkbox"
                  id="u1"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.BLOOD_PREPARATION==='是'?'checked':''"
                />
                <label for="u1">是</label>

                <input
                  type="checkbox"
                  id="u2"
                  value="否"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.BLOOD_PREPARATION==='否'?'checked':''"
                />
                <label for="u2">否</label>
              </div>
            </div>

            <div class="InfoColumnBaseContentKey">
              <div class="no-print">
                <el-checkbox
                  label="假体"
                  false-label
                  true-label="是"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.PROTHESIS"
                ></el-checkbox>
                <label>/</label>
                <el-checkbox
                  style="margin-left:10px;"
                  label="体内植入物"
                  false-label
                  true-label="是"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.IMPLANTED"
                ></el-checkbox>
                <label>/</label>
                <el-checkbox
                  label="影像学资料"
                  false-label
                  true-label="是"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.IMAGING_DATA1"
                ></el-checkbox>
              </div>
              <div class="show-print">
                <input
                  type="checkbox"
                  id="u1"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.PROTHESIS==='是'?'checked':''"
                />
                <label for="u1">假体 /</label>

                <input
                  type="checkbox"
                  id="u2"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.IMPLANTED==='是'?'checked':''"
                />
                <label for="u2">体内植入物 /</label>

                <input
                  type="checkbox"
                  id="u3"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.IMAGING_DATA1==='是'?'checked':''"
                />
                <label for="u3">影像学资料</label>
              </div>
            </div>

            <div
              class="InfoColumnBaseContentKey"
              style="margin-top:40px;display:flex; flex-direction:row;height:50px;"
            >
              <div class="no-print">
                其他：
                <el-input
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.ORTHER1"
                  style="width:150px;height:20px;margin-top:-7px;"
                ></el-input>
              </div>
              <div class="show-print" style="width:150px;margin-top:-3px;margin-left:0px;">
                其他：
                <label
                  style="border-bottom:1px dashed;width:150px;"
                >{{MedicalBasicDoc.MED_SAFETY_CHECKS.ORTHER1}}</label>
              </div>
            </div>
          </div>
        </div>
        <div class="InfoColumn" v-bind:style="{'width':perWidth + 'px'}">
          <div class="InfoColumnTitle">手术开始前</div>
          <div class="InfoColumnBaseContent">
            <div class="InfoColumnBaseContentKey" style="margin-top:10px;">患者姓名、性别、年龄正确：</div>
            <div class="InfoColumnBaseContentValue" style="margin-top:5px;">
              <div class="no-print">
                <el-checkbox
                  label="是"
                  true-label="是"
                  false-label
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.PATIENT_CONFIRM2"
                ></el-checkbox>
                <el-checkbox
                  label="否"
                  true-label="否"
                  false-label
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.PATIENT_CONFIRM2"
                ></el-checkbox>
              </div>
              <div class="show-print">
                <input
                  type="checkbox"
                  id="u1"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.PATIENT_CONFIRM2==='是'?'checked':''"
                />
                <label for="u1">是</label>

                <input
                  type="checkbox"
                  id="u2"
                  value="否"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.PATIENT_CONFIRM2==='否'?'checked':''"
                />
                <label for="u2">否</label>
              </div>
            </div>

            <div class="InfoColumnBaseContentKey">手术方式是否正确：</div>
            <div class="InfoColumnBaseContentValue">
              <div class="no-print">
                <el-checkbox
                  label="是"
                  true-label="是"
                  false-label
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.OPERATION_CONFIRM2"
                ></el-checkbox>
                <el-checkbox
                  label="否"
                  true-label="否"
                  false-label
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.OPERATION_CONFIRM2"
                ></el-checkbox>
              </div>
              <div class="show-print">
                <input
                  type="checkbox"
                  id="u1"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.OPERATION_CONFIRM2==='是'?'checked':''"
                />
                <label for="u1">是</label>

                <input
                  type="checkbox"
                  id="u2"
                  value="否"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.OPERATION_CONFIRM2==='否'?'checked':''"
                />
                <label for="u2">否</label>
              </div>
            </div>

            <div class="InfoColumnBaseContentKey">手术部位与标识是否正确：</div>
            <div class="InfoColumnBaseContentValue">
              <div class="no-print">
                <el-checkbox
                  label="是"
                  true-label="是"
                  false-label
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.OPERATION_POSITION_CONFIRM2"
                ></el-checkbox>
                <el-checkbox
                  label="否"
                  true-label="否"
                  false-label
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.OPERATION_POSITION_CONFIRM2"
                ></el-checkbox>
              </div>
              <div class="show-print">
                <input
                  type="checkbox"
                  id="u1"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.OPERATION_POSITION_CONFIRM2==='是'?'checked':''"
                />
                <label for="u1">是</label>

                <input
                  type="checkbox"
                  id="u2"
                  value="否"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.OPERATION_POSITION_CONFIRM2==='否'?'checked':''"
                />
                <label for="u2">否</label>
              </div>
            </div>

            <div class="InfoColumnBaseContentKey" style="margin-top:50px;">手术、麻醉风险预警：</div>
            <div class="InfoColumnBaseContentKey" style="margin-top:10px;">手术医师陈述：</div>
            <div class="InfoColumnBaseContentValue">
              <div class="no-print">
                <el-checkbox
                  true-label="是"
                  false-label
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.ESTIMATED_TIME"
                  label="预计手术时间"
                  style="margin-top:5px;"
                ></el-checkbox>
                <br />
                <el-checkbox
                  true-label="是"
                  false-label
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.ESTIMATED_BLOOD_LOSS"
                  label="预计失血量"
                  style="margin-top:5px;"
                ></el-checkbox>
                <br />
                <el-checkbox
                  true-label="是"
                  false-label
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.OPER_DOCTOR_FOCUSES"
                  label="手术关注点"
                  style="margin-top:5px;"
                ></el-checkbox>
                <br />
                <el-checkbox
                  true-label="是"
                  false-label
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.OPER_DOCTOR_OTHER"
                  label="其他"
                  style="margin-top:5px;"
                ></el-checkbox>
              </div>
              <div class="show-print">
                <input
                  type="checkbox"
                  id="u1"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.ESTIMATED_TIME==='是'?'checked':''"
                />
                <label for="u1">预计手术时间</label>
                <br />
                <input
                  style="margin-top:10px;"
                  type="checkbox"
                  id="u2"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.ESTIMATED_BLOOD_LOSS==='是'?'checked':''"
                />
                <label for="u2">预计失血量</label>
                <br />
                <input
                  style="margin-top:10px;"
                  type="checkbox"
                  id="u3"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.OPER_DOCTOR_FOCUSES==='是'?'checked':''"
                />
                <label for="u3">手术关注点</label>
                <br />
                <input
                  style="margin-top:10px;"
                  type="checkbox"
                  id="u4"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.OPER_DOCTOR_OTHER==='是'?'checked':''"
                />
                <label for="u4">其他</label>
              </div>
            </div>

            <div class="InfoColumnBaseContentKey" style="margin-top:50px;">麻醉医师陈述：</div>
            <div class="InfoColumnBaseContentValue">
              <div class="no-print">
                <el-checkbox
                  true-label="是"
                  false-label
                  label="是"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.ANES_DOCTOR_FOCUSES"
                ></el-checkbox>
                <br />
                <el-checkbox
                  true-label="是"
                  false-label
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.ANES_DOCTOR_OTHER"
                  label="其他"
                  style="margin-top:5px;"
                ></el-checkbox>
              </div>
              <div class="show-print">
                <input
                  type="checkbox"
                  id="u1"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.ANES_DOCTOR_FOCUSES==='是'?'checked':''"
                />
                <label for="u1">麻醉关注点</label>
                <br />
                <input
                  style="margin-top:10px;"
                  type="checkbox"
                  id="u2"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.ANES_DOCTOR_OTHER==='是'?'checked':''"
                />
                <label for="u2">其他</label>
              </div>
            </div>

            <div class="InfoColumnBaseContentKey" style="margin-top:50px;">手术护士陈述：</div>
            <div class="InfoColumnBaseContentValue">
              <div class="no-print">
                <el-checkbox
                  true-label="是"
                  false-label
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.STERILISATION_CONFIRM"
                  label="物品灭菌合格"
                ></el-checkbox>
                <br />
                <el-checkbox
                  true-label="是"
                  false-label
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.EQUIPMENT"
                  label="仪器设备"
                  style="margin-top:5px;"
                ></el-checkbox>
                <br />
                <el-checkbox
                  true-label="是"
                  false-label
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.SPECIFIC_MEDICATIONS"
                  label="术前术中特殊用药情况"
                  style="margin-top:5px;"
                ></el-checkbox>
                <br />
                <el-checkbox
                  true-label="是"
                  false-label
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.ANTIBIOTICS"
                  label="其他"
                  style="margin-top:5px;"
                ></el-checkbox>
              </div>
              <div class="show-print">
                <input
                  type="checkbox"
                  id="u1"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.STERILISATION_CONFIRM==='是'?'checked':''"
                />
                <label for="u1">物品灭菌合格</label>
                <br />
                <input
                  style="margin-top:10px;"
                  type="checkbox"
                  id="u2"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.EQUIPMENT==='是'?'checked':''"
                />
                <label for="u2">仪器设备</label>
                <br />
                <input
                  style="margin-top:10px;"
                  type="checkbox"
                  id="u3"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.SPECIFIC_MEDICATIONS==='是'?'checked':''"
                />
                <label for="u3">术前术中特殊用药情况</label>
                <br />
                <input
                  style="margin-top:10px;"
                  type="checkbox"
                  id="u4"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.ANTIBIOTICS==='是'?'checked':''"
                />
                <label for="u4">其他</label>
              </div>
            </div>

            <div class="InfoColumnBaseContentKey" style="margin-top:50px;">是否需要相关影像资料：</div>
            <div class="InfoColumnBaseContentValue">
              <div class="no-print">
                <el-checkbox
                  true-label="是"
                  false-label
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.IMAGING_DATA2"
                  label="是"
                ></el-checkbox>
                <el-checkbox
                  true-label="否"
                  false-label
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.IMAGING_DATA2"
                  label="否"
                ></el-checkbox>
              </div>
              <div class="show-print">
                <input
                  type="checkbox"
                  id="u1"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.IMAGING_DATA2==='是'?'checked':''"
                />
                <label for="u1">是</label>

                <input
                  type="checkbox"
                  id="u2"
                  value="否"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.IMAGING_DATA2==='否'?'checked':''"
                />
                <label for="u2">否</label>
              </div>
            </div>
            <div
              class="InfoColumnBaseContentKey"
              style="margin-top:40px;display:flex; flex-direction:row;"
            >
              <div class="no-print" style="margin-top:60px;">
                其他：
                <el-input
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.NURSE_OTHER"
                  style="width:150px;height:20px;margin-top:-7px;"
                ></el-input>
              </div>
              <div class="show-print" style="width:150px;margin-top:40px;margin-left:0px;">
                其他：
                <label
                  style="border-bottom:1px dashed;width:150px;"
                >{{MedicalBasicDoc.MED_SAFETY_CHECKS.NURSE_OTHER}}</label>
              </div>
            </div>
          </div>
        </div>
        <div class="InfoColumn" v-bind:style="{'width':perWidth + 'px',  'border-right':'0px'}">
          <div class="InfoColumnTitle">患者离开手术室前</div>
          <div class="InfoColumnBaseContent">
            <div class="InfoColumnBaseContentKey" style="margin-top:10px;">患者姓名、性别、年龄正确：</div>
            <div class="InfoColumnBaseContentValue" style="margin-top:5px;">
              <div class="no-print">
                <el-checkbox
                  false-label
                  label="是"
                  true-label="是"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.PATIENT_CONFIRM3"
                ></el-checkbox>
                <el-checkbox
                  false-label
                  label="否"
                  true-label="否"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.PATIENT_CONFIRM3"
                ></el-checkbox>
              </div>
              <div class="show-print">
                <input
                  type="checkbox"
                  id="u1"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.PATIENT_CONFIRM3==='是'?'checked':''"
                />
                <label for="u1">是</label>

                <input
                  type="checkbox"
                  id="u2"
                  value="否"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.PATIENT_CONFIRM3==='否'?'checked':''"
                />
                <label for="u2">否</label>
              </div>
            </div>

            <div class="InfoColumnBaseContentKey">实际手术方式确认：</div>
            <div class="InfoColumnBaseContentValue">
              <div class="no-print">
                <el-checkbox
                  false-label
                  label="是"
                  true-label="是"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.OPERATION_CONFIRM3"
                ></el-checkbox>
                <el-checkbox
                  false-label
                  label="否"
                  true-label="否"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.OPERATION_CONFIRM3"
                ></el-checkbox>
              </div>
              <div class="show-print">
                <input
                  type="checkbox"
                  id="u1"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.OPERATION_CONFIRM3==='是'?'checked':''"
                />
                <label for="u1">是</label>

                <input
                  type="checkbox"
                  id="u2"
                  value="否"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.OPERATION_CONFIRM3==='否'?'checked':''"
                />
                <label for="u2">否</label>
              </div>
            </div>

            <div class="InfoColumnBaseContentKey">手术用药、输血的核查</div>
            <div class="InfoColumnBaseContentValue">
              <div class="no-print">
                <el-checkbox
                  false-label
                  label="是"
                  true-label="是"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.MEDICATION_CONFIRM"
                ></el-checkbox>
                <el-checkbox
                  false-label
                  label="否"
                  true-label="否"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.MEDICATION_CONFIRM"
                ></el-checkbox>
              </div>
              <div class="show-print">
                <input
                  type="checkbox"
                  id="u1"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.MEDICATION_CONFIRM==='是'?'checked':''"
                />
                <label for="u1">是</label>

                <input
                  type="checkbox"
                  id="u2"
                  value="否"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.MEDICATION_CONFIRM==='否'?'checked':''"
                />
                <label for="u2">否</label>
              </div>
            </div>

            <div class="InfoColumnBaseContentKey">手术用物清点正确：</div>
            <div class="InfoColumnBaseContentValue">
              <div class="no-print">
                <el-checkbox
                  false-label
                  label="是"
                  true-label="是"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.OPERATION_EQUIP_INDICATOR"
                ></el-checkbox>
                <el-checkbox
                  false-label
                  label="否"
                  true-label="否"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.OPERATION_EQUIP_INDICATOR"
                ></el-checkbox>
              </div>
              <div class="show-print">
                <input
                  type="checkbox"
                  id="u1"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.OPERATION_EQUIP_INDICATOR==='是'?'checked':''"
                />
                <label for="u1">是</label>

                <input
                  type="checkbox"
                  id="u2"
                  value="否"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.OPERATION_EQUIP_INDICATOR==='否'?'checked':''"
                />
                <label for="u2">否</label>
              </div>
            </div>

            <div class="InfoColumnBaseContentKey">手术标本确认：</div>
            <div class="InfoColumnBaseContentValue">
              <div class="no-print">
                <el-checkbox
                  false-label
                  label="是"
                  true-label="是"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.PECIMENS"
                ></el-checkbox>
                <el-checkbox
                  false-label
                  label="否"
                  true-label="否"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.PECIMENS"
                ></el-checkbox>
              </div>
              <div class="show-print">
                <input
                  type="checkbox"
                  id="u1"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.PECIMENS==='是'?'checked':''"
                />
                <label for="u1">是</label>

                <input
                  type="checkbox"
                  id="u2"
                  value="否"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.PECIMENS==='否'?'checked':''"
                />
                <label for="u2">否</label>
              </div>
            </div>

            <div class="InfoColumnBaseContentKey">皮肤是否完整：</div>
            <div class="InfoColumnBaseContentValue">
              <div class="no-print">
                <el-checkbox
                  false-label
                  label="是"
                  true-label="是"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.SKIN_INTEGRITY_CONFIRM3"
                ></el-checkbox>
                <el-checkbox
                  false-label
                  label="否"
                  true-label="否"
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.SKIN_INTEGRITY_CONFIRM3"
                ></el-checkbox>
              </div>
              <div class="show-print">
                <input
                  type="checkbox"
                  id="u1"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.SKIN_INTEGRITY_CONFIRM3==='是'?'checked':''"
                />
                <label for="u1">是</label>

                <input
                  type="checkbox"
                  id="u2"
                  value="否"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.SKIN_INTEGRITY_CONFIRM3==='否'?'checked':''"
                />
                <label for="u2">否</label>
              </div>
            </div>

            <div class="InfoColumnBaseContentKey" style="margin-top:50px;">各种管路：</div>
            <div class="InfoColumnBaseContentValue">
              <div class="no-print">
                <el-checkbox
                  true-label="是"
                  false-label
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.CENTRAL_VENOUS"
                  label="中心静脉通路"
                  style="margin-top:5px;"
                ></el-checkbox>
                <br />
                <el-checkbox
                  true-label="是"
                  false-label
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.ARTERY_PATH"
                  label="动脉通路"
                  style="margin-top:5px;"
                ></el-checkbox>
                <br />
                <el-checkbox
                  true-label="是"
                  false-label
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.RACHEA_CANNULA"
                  label="气管插管"
                  style="margin-top:5px;"
                ></el-checkbox>
                <br />
                <el-checkbox
                  true-label="是"
                  false-label
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.SUCTION_DRAINAGE"
                  label="伤口引流"
                  style="margin-top:5px;"
                ></el-checkbox>
                <br />
                <el-checkbox
                  true-label="是"
                  false-label
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.STOMACH_TUBE"
                  label="胃管"
                  style="margin-top:5px;"
                ></el-checkbox>
                <br />
                <el-checkbox
                  true-label="是"
                  false-label
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.URINE_TUBE"
                  label="尿管"
                  style="margin-top:5px;"
                ></el-checkbox>
              </div>
              <div class="show-print">
                <input
                  type="checkbox"
                  id="u1"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.CENTRAL_VENOUS==='是'?'checked':''"
                />
                <label for="u1">中心静脉通路</label>
                <br />
                <input
                  style="margin-top:10px;"
                  type="checkbox"
                  id="u2"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.ARTERY_PATH==='是'?'checked':''"
                />
                <label for="u2">动脉通路</label>
                <br />
                <input
                  style="margin-top:10px;"
                  type="checkbox"
                  id="u3"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.RACHEA_CANNULA==='是'?'checked':''"
                />
                <label for="u3">气管插管</label>
                <br />
                <input
                  style="margin-top:10px;"
                  type="checkbox"
                  id="u4"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.SUCTION_DRAINAGE==='是'?'checked':''"
                />
                <label for="u4">伤口引流</label>
                <br />
                <input
                  style="margin-top:10px;"
                  type="checkbox"
                  id="u5"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.STOMACH_TUBE==='是'?'checked':''"
                />
                <label for="u5">胃管</label>
                <br />
                <input
                  style="margin-top:10px;"
                  type="checkbox"
                  id="u6"
                  value="是"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.URINE_TUBE==='是'?'checked':''"
                />
                <label for="u6">尿管</label>
              </div>
              <div class="Info" style="border-top:5px;margin-top:-5px;">
                <div class="InfoKey" style="margin-left:60px;">其他：</div>
                <div class="InfoValue">
                  <div class="no-print">
                    <el-input
                      v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.ORTHER2"
                      style="width:150px;height:20px;margin-top:-10px;"
                    ></el-input>
                    <el-checkbox
                      true-label="是"
                      false-label
                      v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.ORTHER3"
                      label
                    ></el-checkbox>
                  </div>

                  <div class="show-print">
                    <div style="display:flex;flex-direction:row;">
                      <div
                        style="border-bottom:1px dashed;width:200px;"
                      >{{MedicalBasicDoc.MED_SAFETY_CHECKS.ORTHER2}}</div>
                      <input
                        type="checkbox"
                        id="u1"
                        value="是"
                        :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.ORTHER3==='是'?'checked':''"
                      />
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <div class="InfoColumnBaseContentKey" style="margin-top:30px;">患者去向：</div>
            <div class="InfoColumnBaseContentValue">
              <div class="no-print">
                <el-checkbox
                  true-label="恢复室"
                  false-label
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.PAT_WHEREABORTS"
                  label="恢复室"
                ></el-checkbox>
                <br />
                <el-checkbox
                  true-label="病房"
                  false-label
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.PAT_WHEREABORTS"
                  label="病房"
                  style="margin-top:5px;"
                ></el-checkbox>
                <br />
                <el-checkbox
                  true-label="ICU病房"
                  false-label
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.PAT_WHEREABORTS"
                  label="ICU病房"
                  style="margin-top:5px;"
                ></el-checkbox>
                <br />
                <el-checkbox
                  true-label="急诊"
                  false-label
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.PAT_WHEREABORTS"
                  label="急诊"
                  style="margin-top:5px;"
                ></el-checkbox>
                <br />
                <el-checkbox
                  true-label="离院"
                  false-label
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.PAT_WHEREABORTS"
                  label="离院"
                  style="margin-top:5px;"
                ></el-checkbox>
              </div>
              <div class="show-print">
                <input
                  type="checkbox"
                  id="u1"
                  value="恢复室"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.PAT_WHEREABORTS==='恢复室'?'checked':''"
                />
                <label for="u1">恢复室</label>
                <br />
                <input
                  style="margin-top:10px;"
                  type="checkbox"
                  id="u2"
                  value="病房"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.PAT_WHEREABORTS==='病房'?'checked':''"
                />
                <label for="u2">病房</label>
                <br />
                <input
                  style="margin-top:10px;"
                  type="checkbox"
                  id="u3"
                  value="ICU病房"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.PAT_WHEREABORTS==='ICU病房'?'checked':''"
                />
                <label for="u3">ICU病房</label>
                <br />
                <input
                  style="margin-top:10px;"
                  type="checkbox"
                  id="u4"
                  value="急诊"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.PAT_WHEREABORTS==='急诊'?'checked':''"
                />
                <label for="u4">急诊</label>
                <br />
                <input
                  style="margin-top:10px;"
                  type="checkbox"
                  id="u5"
                  value="离院"
                  :checked="MedicalBasicDoc.MED_SAFETY_CHECKS.PAT_WHEREABORTS==='离院'?'checked':''"
                />
                <label for="u5">离院</label>
              </div>
            </div>
            <div
              class="InfoColumnBaseContentKey"
              style="margin-top:40px;display:flex; flex-direction:row;"
            >
              <div class="no-print" style="margin-top:40px;">
                其他：
                <el-input
                  v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.ORTHER4"
                  style="width:150px;height:20px;margin-top:-7px;"
                ></el-input>
              </div>
              <div class="show-print" style="width:150px;margin-top:15px;margin-left:0px;">
                其他：
                <label
                  style="border-bottom:1px dashed;width:150px;"
                >{{MedicalBasicDoc.MED_SAFETY_CHECKS.ORTHER4}}</label>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div class="Info" style="margin-top:0px;">
        <div class="InfoKey" style="margin-top:20px; margin-bottom:20px;">手术医师签名：</div>
        <div>
          <div class="no-print">
            <div>
              <MedSelect
                type="SurgeonDict"
                style="width:100px;margin-top:10px;"
                v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.OPER_DOCTOR3"
                :remote="true"
                :filterable="true"
                placeholder="手术医师"
                clearable
                @GetDiaplayValue="GetDiaplayValue"
              ></MedSelect>
            </div>
          </div>
          <div
            class="show-print"
            style="border-bottom:1px dashed;margin-top:18px;line-height: 20px;height:20px;width:100px;"
          >{{OPER_DOCTOR3_DISPLAY}}</div>
        </div>
        <div class="InfoKey" style="margin-top:20px; margin-bottom:20px; margin-left:50px;">麻醉医师签名：</div>
        <div>
          <div class="no-print">
            <div>
              <MedSelect
                type="AnesDoctorDict"
                style="width:100px;margin-top:10px;"
                v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.ANES_DOCTOR3"
                :remote="true"
                :filterable="true"
                placeholder="麻醉医师"
                clearable
                @GetDiaplayValue="GetDiaplayValue"
              ></MedSelect>
            </div>
          </div>
          <div
            class="show-print"
            style="border-bottom:1px dashed;margin-top:18px;line-height: 20px;height:20px;width:150px;"
          >{{ANES_DOCTOR3_DISPLAY}}</div>
        </div>
        <div class="InfoKey" style="margin-top:20px; margin-bottom:20px;margin-left:50px;">手术室护士签名：</div>
        <div>
          <div class="no-print">
            <div>
              <MedSelect
                type="NurseDictInOperRoom"
                style="width:100px;margin-top:10px;"
                v-model="MedicalBasicDoc.MED_SAFETY_CHECKS.NURSE3"
                :remote="true"
                :filterable="true"
                placeholder="手术室护士"
                clearable
                @GetDiaplayValue="GetDiaplayValue"
              ></MedSelect>
            </div>
          </div>
          <div
            class="show-print"
            style="border-bottom:1px dashed;margin-top:18px;line-height: 20px;height:20px;width:150px;"
          >{{NURSE3_DISPLAY}}</div>
        </div>
      </div>
    </div>

    <div style="float: right;">
      <div style="float:right;margin-right:80px;margin-bottom: 20px;">
        <DocUploadBtn :pdfEle="$refs" :pdfInfo="pdfInfo"></DocUploadBtn>
        <el-button type="primary" v-on:click="SaveData" size="small" icon="el-icon-edit-outline">保存</el-button>
        <el-button type="primary" v-on:click="PrintDoc" size="small" icon="el-icon-edit-outline">打印</el-button>
      </div>
    </div>
  </div>
</template>

<script>
import NursingSafeDoc from './NursingSafeDoc.js'
export default NursingSafeDoc
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";
@media screen {
  .MainContent {
    width: 880px;
    color: black;
  }

  .MainPrint {
    width: 880px;
    display: flex;
    flex-direction: column;
    border: 1px solid;
    margin: 10px 45px;
    .Title {
      text-align: center;
      font-size: 25px;
      margin-top: 10px;
      font-weight: 600;
    }
    .Info {
      margin-top: 10px;
      display: flex;
      flex-direction: row;
      border-top: 1px solid;
    }
    .InfoKey {
      margin-top: 10px;
      margin-left: 15px;
      min-width: 50px;
    }
    .InfoValue {
      margin-left: 5px;
      margin-top: 10px;
      min-width: 50px;
    }
    .InfoColumn {
      display: flex;
      flex-direction: column;
      border-right: 1px solid;
    }
    .InfoColumnTitle {
      text-align: center;
      margin-top: 10px;
      font-size: 18px;
      font-weight: 600;
    }
    .InfoColumnBaseContent {
      border-top: 1px solid;
      margin-top: 10px;
      margin-bottom: 10px;
    }
    .InfoColumnBaseContentKey {
      margin-top: 20px;
      margin-left: 5px;
    }
    .InfoColumnBaseContentValue {
      margin-top: 0px;
      text-align: right;
    }
    .LoacalAnesEdit_Main_Row9_Column2 {
      width: 84px;
      height: 28px;
      background: rgba(20, 68, 109, 1);
      border-radius: 5px;
    }
  }
}

@media print {
  .MainContent {
    width: 880px;
    color: black;
  }

  .MainPrint {
    width: 880px;
    display: flex;
    flex-direction: column;
    border: 1px solid;
    margin: 0px 5px;
    .Title {
      text-align: center;
      font-size: 25px;
      margin-top: 10px;
      font-weight: 600;
    }
    .Info {
      margin-top: 10px;
      display: flex;
      flex-direction: row;
      border-top: 1px solid;
    }
    .InfoKey {
      margin-top: 10px;
      margin-left: 15px;
      min-width: 50px;
    }
    .InfoValue {
      margin-left: 5px;
      margin-top: 10px;
      min-width: 50px;
    }
    .InfoColumn {
      display: flex;
      flex-direction: column;
      border-right: 1px solid;
    }
    .InfoColumnTitle {
      text-align: center;
      margin-top: 10px;
      font-size: 18px;
      font-weight: 600;
    }
    .InfoColumnBaseContent {
      border-top: 1px solid;
      margin-top: 10px;
      margin-bottom: 10px;
    }
    .InfoColumnBaseContentKey {
      margin-top: 20px;
      margin-left: 5px;
    }
    .InfoColumnBaseContentValue {
      margin-top: 0px;
      text-align: right;
    }
    .LoacalAnesEdit_Main_Row9_Column2 {
      width: 84px;
      height: 28px;
      background: rgba(20, 68, 109, 1);
      border-radius: 5px;
    }
  }
}
</style>

<style lang="scss">
@import "@/assets/styles/global.scss";

.el-date-picker .el-input__icon {
  color: blue;
  display: none;
}

.el-input_noboard .el-input__inner {
  border: 10px solid #e9e9e9;
  font-size: 50px;
}
</style>
