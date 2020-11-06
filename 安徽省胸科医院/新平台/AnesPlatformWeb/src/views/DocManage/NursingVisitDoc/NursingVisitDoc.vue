<template>
  <div class="MainContent">
    <!--确保文书打印主体的ID=printaArea,千万不要拼写错误，不然无法上传-->
    <div class="MainPrint" id="printaArea" ref="print" style="font-family:'宋体';">
      <div class="Title">安徽省胸科医院</div>
      <div class="Title" style="font-size:23px;">手术访视记录单</div>
      <div class="Info">
        <div class="InfoKey">姓名：</div>
        <div class="InfoValue" style="min-width:100px;">{{MedicalBasicDoc.PatientDetail.NAME}}</div>
        <div class="InfoKey">年龄：</div>
        <div class="InfoValue">{{MedicalBasicDoc.PatientDetail.AGE}}</div>
        <div class="InfoKey">性别：</div>
        <div class="InfoValue">{{MedicalBasicDoc.PatientDetail.SEX}}</div>
        <div class="InfoKey">病区：</div>
        <div class="InfoValue" style="min-width:200px;">{{MedicalBasicDoc.PatientDetail.DEPT_NAME}}</div>
        <div class="InfoKey">床号：</div>
        <div class="InfoValue">{{MedicalBasicDoc.PatientDetail.BED_NO}}</div>
      </div>
      <div class="Info">
        <div class="InfoKey" style="margin-top:18px;">入院诊断：</div>
        <div class="InfoValue">
          <div class="no-print">
            <InputSelect
              type="DiagnosisDict"
              style="width:680px;"
              replaceKeys="＋,﹢,﹢"
              showKey="+"
              placeholder="入院诊断"
              :ismultiple="true"
              v-model="MedicalBasicDoc.MED_OPERATION_MASTER.DIAG_BEFORE_OPERATION"
            ></InputSelect>
          </div>
          <div
            class="show-print"
            style="border-bottom:1px dashed;min-width:500px;margin-top:5px;line-height: 20px;height:20px;"
          >{{MedicalBasicDoc.MED_OPERATION_MASTER.DIAG_BEFORE_OPERATION}}</div>
        </div>
      </div>
      <div class="Info">
        <div class="InfoKey" style="margin-top:18px;">拟施手术：</div>
        <div class="InfoValue">
          <div class="no-print">
            <InputSelect
              type="OperNameDict"
              style="width:680px;"
              replaceKeys="＋,﹢,﹢"
              showKey="+"
              :ismultiple="true"
              placeholder="拟施手术"
              :islocal="true"
              v-model="MedicalBasicDoc.MED_ANESTHESIA_PLAN.OPERATION_NAME"
            ></InputSelect>
          </div>
          <div
            class="show-print"
            style="border-bottom:1px dashed;min-width:500px;margin-top:5px;line-height: 20px;height:20px;"
          >{{MedicalBasicDoc.MED_ANESTHESIA_PLAN.OPERATION_NAME}}</div>
        </div>
      </div>
      <div class="Info">
        <div class="InfoKey" style="margin-top:18px;">麻醉方式：</div>
        <div class="InfoValue">
          <div class="no-print">
            <InputSelect
              type="AnesMethodDict"
              style="width:680px;"
              placeholder="麻醉方式"
              v-model="MedicalBasicDoc.MED_ANESTHESIA_PLAN.ANESTHESIA_METHOD"
            ></InputSelect>
          </div>
          <div
            class="show-print"
            style="border-bottom:1px dashed;min-width:500px;margin-top:5px;line-height: 20px;height:20px;"
          >{{MedicalBasicDoc.MED_ANESTHESIA_PLAN.ANESTHESIA_METHOD}}</div>
        </div>
      </div>
      <div class="Info">
        <div class="InfoKey" style="margin-top:18px;">术前访视时间：</div>
        <div class="el-date-picker">
          <div class="no-print">
            <el-date-picker
              style="width:240px;margin-top:10px;"
              v-model="MedicalBasicDoc.MED_ANESTHESIA_PLAN.INQUIRY_BEFORE_DATE"
              type="datetime"
              clearable
              id="inDate"
            ></el-date-picker>
          </div>
          <div
            class="show-print"
            style="border-bottom:1px dashed;min-width:240px;margin-top:15px;line-height: 20px;height:20px;"
          >{{MedicalBasicDoc.MED_ANESTHESIA_PLAN.INQUIRY_BEFORE_DATE}}</div>
        </div>
      </div>
      <div class="Info">
        <div class="InfoKey">体温：</div>
        <div class="InfoValue">
          <div class="no-print">
            <el-input
              v-model="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.TEMPETURE"
              style="width:50px;height:20px;margin-top:-10px;"
            ></el-input>℃
          </div>
          <div
            class="show-print"
            style="border-bottom:1px dashed;min-width:50px;margin-top:-3px;line-height: 20px;height:20px;"
          >{{MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.TEMPETURE}} ℃</div>
        </div>
        <div class="InfoKey">脉搏：</div>
        <div class="InfoValue">
          <div class="no-print">
            <el-input
              v-model="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.PLUS"
              style="width:50px;height:20px;margin-top:-10px;"
            ></el-input>次/分
          </div>
          <div
            class="show-print"
            style="border-bottom:1px dashed;min-width:50px;margin-top:-3px;line-height: 20px;height:20px;"
          >{{MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.PLUS}} 次/分</div>
        </div>
        <div class="InfoKey">呼吸：</div>
        <div class="InfoValue">
          <div class="no-print">
            <el-input
              v-model="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.BREATH"
              style="width:50px;height:20px;margin-top:-10px;"
            ></el-input>次/分
          </div>
          <div
            class="show-print"
            style="border-bottom:1px dashed;min-width:50px;margin-top:-3px;line-height: 20px;height:20px;"
          >{{MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.BREATH}} 次/分</div>
        </div>
        <div class="InfoKey">血压：</div>
        <div class="InfoValue">
          <div class="no-print">
            <el-input
              v-model="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.BLOOD_PRESS_HIGH"
              style="width:50px;height:20px;margin-top:-10px;"
            ></el-input>mmHg
          </div>
          <div
            class="show-print"
            style="border-bottom:1px dashed;min-width:50px;margin-top:-3px;line-height: 20px;height:20px;"
          >{{MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.BLOOD_PRESS_HIGH}} mmHg</div>
        </div>
      </div>
      <div class="Info">
        <div class="InfoKey">神志：</div>
        <div class="InfoValue">
          <div class="no-print">
            <el-checkbox
              true-label="清醒"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.CONSCIOUSNESS"
            >清醒</el-checkbox>
            <el-checkbox
              true-label="嗜睡"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.CONSCIOUSNESS"
            >嗜睡</el-checkbox>
            <el-checkbox
              true-label="昏迷"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.CONSCIOUSNESS"
            >昏迷</el-checkbox>
          </div>
          <div class="show-print">
            <input
              type="checkbox"
              id="u1"
              value="清醒"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.CONSCIOUSNESS==='清醒'?'checked':''"
            />
            <label for="u1">清醒</label>
            <input
              type="checkbox"
              id="u2"
              value="嗜睡"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.CONSCIOUSNESS==='嗜睡'?'checked':''"
            />
            <label for="u2">嗜睡</label>
            <input
              type="checkbox"
              id="u3"
              value="昏迷"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.CONSCIOUSNESS==='昏迷'?'checked':''"
            />
            <label for="u3">昏迷</label>
          </div>
        </div>

        <div class="InfoKey">皮肤：</div>
        <div class="InfoValue">
          <div class="no-print">
            <el-checkbox
              true-label="完整"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.CERVIX"
            >完整</el-checkbox>
            <el-checkbox
              true-label="受损"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.CERVIX"
            >受损</el-checkbox>
          </div>
          <div class="show-print">
            <input
              type="checkbox"
              id="u3"
              value="完整"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.CERVIX==='完整'?'checked':''"
            />
            <label for="u3">完整</label>
            <input
              type="checkbox"
              id="u2"
              value="受损"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.CERVIX==='受损'?'checked':''"
            />
            <label for="u2">受损</label>
          </div>
        </div>

        <div class="InfoKey">肢体功能：</div>
        <div class="InfoValue">
          <div class="no-print">
            <el-checkbox
              true-label="活动自如"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.LIMB_FEEL"
            >活动自如</el-checkbox>
            <el-checkbox
              true-label="活动障碍"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.LIMB_FEEL"
            >活动障碍</el-checkbox>
          </div>
          <div class="show-print">
            <input
              type="checkbox"
              id="u2"
              value="活动自如"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.LIMB_FEEL==='活动自如'?'checked':''"
            />
            <label for="u2">活动自如</label>
            <input
              type="checkbox"
              id="u3"
              value="活动障碍"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.LIMB_FEEL==='活动障碍'?'checked':''"
            />
            <label for="u3">活动障碍</label>
          </div>
        </div>

        <div class="InfoKey">备血：</div>
        <div class="InfoValue">
          <div class="no-print">
            <el-checkbox
              true-label="已备"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.CRUOR_ITEM"
            >已备</el-checkbox>
            <el-checkbox
              true-label="未备"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.CRUOR_ITEM"
            >未备</el-checkbox>
          </div>
          <div class="show-print">
            <input
              type="checkbox"
              id="u3"
              value="已备"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.CRUOR_ITEM==='已备'?'checked':''"
            />
            <label for="u3">已备</label>
            <input
              type="checkbox"
              id="u2"
              value="未备"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.CRUOR_ITEM==='未备'?'checked':''"
            />
            <label for="u2">未备</label>
          </div>
        </div>
      </div>

      <div class="Info">
        <div class="InfoKey">血体液隔离：</div>
        <div class="InfoValue">
          <div class="no-print">
            <el-checkbox
              true-label="有"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_PLAN_PMH.ENDOCRINE_SYSTEM"
            >有</el-checkbox>
            <el-checkbox
              true-label="无"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_PLAN_PMH.ENDOCRINE_SYSTEM"
            >无</el-checkbox>
          </div>
          <div class="show-print">
            <input
              type="checkbox"
              id="u2"
              value="有"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_PLAN_PMH.ENDOCRINE_SYSTEM==='有'?'checked':''"
            />
            <label for="u2">有</label>
            <input
              type="checkbox"
              id="u3"
              value="无"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_PLAN_PMH.ENDOCRINE_SYSTEM==='无'?'checked':''"
            />
            <label for="u3">无</label>
          </div>
        </div>

        <div class="InfoKey">药物过敏：</div>
        <div class="InfoValue">
          <div class="no-print">
            <el-checkbox
              true-label="有"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_PLAN_PMH.ALERGY_DRUGS_HISTORY"
            >有</el-checkbox>
            <el-checkbox
              true-label="无"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_PLAN_PMH.ALERGY_DRUGS_HISTORY"
            >无</el-checkbox>
          </div>
          <div class="show-print">
            <input
              type="checkbox"
              id="u2"
              value="有"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_PLAN_PMH.ALERGY_DRUGS_HISTORY==='有'?'checked':''"
            />
            <label for="u2">有</label>
            <input
              type="checkbox"
              id="u3"
              value="无"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_PLAN_PMH.ALERGY_DRUGS_HISTORY==='无'?'checked':''"
            />
            <label for="u3">无</label>
          </div>
        </div>
        <div class="InfoValue">
          <div class="no-print">
            (青霉素、普鲁卡因、碘、其他
            <el-input
              v-model="MedicalBasicDoc.MED_ANESTHESIA_PLAN_PMH.MR_ABSTRACT"
              style="width:150px;height:20px;margin-top:-10px;"
            ></el-input>)
          </div>
          <div class="show-print">
            (青霉素、普鲁卡因、碘、其他
            <span
              style="border-bottom:1px dashed;min-width:150px;margin-top:-3px;line-height: 20px;height:20px;"
            >{{MedicalBasicDoc.MED_ANESTHESIA_PLAN_PMH.MR_ABSTRACT}}</span>)
          </div>
        </div>
      </div>

      <div class="Info">
        <div class="InfoKey">心电图：</div>
        <div class="InfoValue">
          <div class="no-print">
            <el-checkbox
              true-label="正常"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.ECG_EXAM"
            >正常</el-checkbox>
            <el-checkbox
              true-label="异常"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.ECG_EXAM"
            >异常</el-checkbox>
          </div>
          <div class="show-print">
            <input
              type="checkbox"
              id="u3"
              value="正常"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.ECG_EXAM==='正常'?'checked':''"
            />
            <label for="u3">正常</label>
            <input
              type="checkbox"
              id="u2"
              value="异常"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.ECG_EXAM==='异常'?'checked':''"
            />
            <label for="u2">异常</label>
          </div>
        </div>
        <div class="InfoKey">血糖：</div>
        <div class="InfoValue">
          <div class="no-print">
            <el-checkbox
              true-label="正常"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.LAB_GIU"
            >正常</el-checkbox>
            <el-checkbox
              true-label="偏高"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.LAB_GIU"
            >偏高</el-checkbox>
            <el-checkbox
              true-label="偏低"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.LAB_GIU"
            >偏低</el-checkbox>
          </div>
          <div class="show-print">
            <input
              type="checkbox"
              id="u2"
              value="正常"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.LAB_GIU==='正常'?'checked':''"
            />
            <label for="u2">正常</label>
            <input
              type="checkbox"
              id="u1"
              value="偏高"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.LAB_GIU==='偏高'?'checked':''"
            />
            <label for="u1">偏高</label>
            <input
              type="checkbox"
              id="u3"
              value="偏低"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.LAB_GIU==='偏低'?'checked':''"
            />
            <label for="u3">偏低</label>
          </div>
        </div>
        <div class="InfoKey">特殊情况</div>
        <div class="InfoValue">
          <div class="no-print">
            <el-input
              v-model="MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.OTHER"
              style="width:150px;height:20px;margin-top:-10px;"
            ></el-input>
          </div>
          <div
            class="show-print"
            style="border-bottom:1px dashed;min-width:150px;margin-top:-3px;line-height: 20px;height:20px;margin-left:10px;"
          >{{MedicalBasicDoc.MED_ANESTHESIA_PLAN_EXAM.OTHER}}</div>
        </div>
      </div>

      <div class="Info">
        <div class="InfoKey">术前宣教：</div>
        <div class="InfoColumn">
          <div class="InfoKey">1 自我介绍</div>
          <div class="InfoKey">2 术前需精神放松，密切配合。</div>
          <div class="InfoKey">3 术前注意事项：禁食、水、，无化妆，去掉饰物，假牙，打术前针等。</div>
          <div class="InfoKey">4 介绍手术环境，条件。</div>
          <div class="InfoKey">5 简述工作流程。</div>
          <div class="InfoKey">6 简述病人配合要点及注意事项。</div>
          <div class="InfoKey">7 安心休息，迎接手术。</div>
        </div>
      </div>

      <div class="InfoKey" style="margin-top:20px;">特殊情况及注意事项：</div>
      <div style="height:120px;">
        <div class="no-print">
          <el-input
            style="margin-top:10px;"
            type="textarea"
            :autosize="{ minRows: 4, maxRows: 4}"
            maxlength="100"
            show-word-limit
            v-model="MedicalBasicDoc.MED_ANESTHESIA_PLAN.INVESTIGATE_SUGGESTION"
          ></el-input>
        </div>
        <div class="show-print">
          <div
            style="margin-left:15px;margin-top:20px;"
          >{{MedicalBasicDoc.MED_ANESTHESIA_PLAN.INVESTIGATE_SUGGESTION}}</div>
        </div>
      </div>

      <div class="Info" style="border-top: 0px;">
        <div class="InfoKey" style="margin-top:18px;font-weight:600">术后访视时间：</div>
        <div class="el-date-picker">
          <div class="no-print">
            <el-date-picker
              style="width:240px;margin-top:10px;"
              v-model="MedicalBasicDoc.MED_ANESTHESIA_RECOVER.RECORD_DATE"
              type="datetime"
              clearable
              id="inDate"
            ></el-date-picker>
          </div>
          <div class="show-print">
            <div
              style="margin-left:10px; margin-top:18px;"
            >{{MedicalBasicDoc.MED_ANESTHESIA_RECOVER.RECORD_DATE}}</div>
          </div>
        </div>
      </div>

      <div class="Info">
        <div class="InfoKey">体温：</div>
        <div class="InfoValue">
          <div class="no-print">
            <el-input
              v-model="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.TEMPETURE"
              style="width:50px;height:20px;margin-top:-10px;"
            ></el-input>℃
          </div>
          <div
            class="show-print"
            style="border-bottom:1px dashed;min-width:50px;margin-top:-3px;line-height: 20px;height:20px;"
          >{{MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.TEMPETURE}} ℃</div>
        </div>
        <div class="InfoKey">脉搏：</div>
        <div class="InfoValue">
          <div class="no-print">
            <el-input
              v-model="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.PLUS"
              style="width:50px;height:20px;margin-top:-10px;"
            ></el-input>次/分
          </div>
          <div
            class="show-print"
            style="border-bottom:1px dashed;min-width:50px;margin-top:-3px;line-height: 20px;height:20px;"
          >{{MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.PLUS}}次/分</div>
        </div>
        <div class="InfoKey">呼吸：</div>
        <div class="InfoValue">
          <div class="no-print">
            <el-input
              v-model="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.BREATH"
              style="width:50px;height:20px;margin-top:-10px;"
            ></el-input>次/分
          </div>
          <div
            class="show-print"
            style="border-bottom:1px dashed;min-width:50px;margin-top:-3px;line-height: 20px;height:20px;"
          >{{MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.BREATH}}次/分</div>
        </div>
        <div class="InfoKey">血压：</div>
        <div class="InfoValue">
          <div class="no-print">
            <el-input
              v-model="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.BLOOD_PRESS_HIGH"
              style="width:50px;height:20px;margin-top:-10px;"
            ></el-input>mmHg
          </div>
          <div
            class="show-print"
            style="border-bottom:1px dashed;min-width:50px;margin-top:-3px;line-height: 20px;height:20px;"
          >{{MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.BLOOD_PRESS_HIGH}}</div>
        </div>
      </div>

      <div class="Info">
        <div class="InfoKey">皮肤：</div>
        <div class="InfoValue">
          <div class="no-print">
            <el-checkbox
              true-label="完整"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.CERVIX"
            >完整</el-checkbox>
            <el-checkbox
              true-label="受损"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.CERVIX"
            >受损</el-checkbox>
          </div>
          <div class="show-print">
            <input
              type="checkbox"
              id="u1"
              value="完整"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.CERVIX==='完整'?'checked':''"
            />
            <label for="u1">完整</label>

            <input
              type="checkbox"
              id="u2"
              value="受损"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.CERVIX==='受损'?'checked':''"
            />
            <label for="u2">受损</label>
          </div>
        </div>

        <div class="InfoKey">肢体功能：</div>
        <div class="InfoValue">
          <div class="no-print">
            <el-checkbox
              true-label="活动自如"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.BODY_SENSATION"
            >活动自如</el-checkbox>
            <el-checkbox
              true-label="活动障碍"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.BODY_SENSATION"
            >活动障碍</el-checkbox>
          </div>
          <div class="show-print">
            <input
              type="checkbox"
              id="u1"
              value="活动自如"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.BODY_SENSATION==='活动自如'?'checked':''"
            />
            <label for="u1">活动自如</label>

            <input
              type="checkbox"
              id="u2"
              value="活动障碍"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.BODY_SENSATION==='活动障碍'?'checked':''"
            />
            <label for="u2">活动障碍</label>
          </div>
        </div>
      </div>

      <div class="Info">
        <div class="InfoKey">伤口情况：</div>
        <div class="InfoValue">
          <div class="no-print">
            <el-checkbox
              true-label="红肿"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.LIMBS_FEEL"
            >红肿</el-checkbox>
            <el-checkbox
              true-label="缝线反应"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.LIMBS_FEEL"
            >缝线反应</el-checkbox>
            <el-checkbox
              true-label="感染"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.LIMBS_FEEL"
            >感染</el-checkbox>
            <el-checkbox
              true-label="渗血"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.LIMBS_FEEL"
            >渗血</el-checkbox>
            <el-checkbox
              true-label="出血"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.LIMBS_FEEL"
            >出血</el-checkbox>
          </div>
          <div class="show-print">
            <input
              type="checkbox"
              id="u1"
              value="红肿"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.LIMBS_FEEL==='红肿'?'checked':''"
            />
            <label for="u1">红肿</label>

            <input
              type="checkbox"
              id="u2"
              value="缝线反应"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.LIMBS_FEEL==='缝线反应'?'checked':''"
            />
            <label for="u2">缝线反应</label>

            <input
              type="checkbox"
              id="u3"
              value="感染"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.LIMBS_FEEL==='感染'?'checked':''"
            />
            <label for="u3">感染</label>

            <input
              type="checkbox"
              id="u4"
              value="渗血"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.LIMBS_FEEL==='渗血'?'checked':''"
            />
            <label for="u4">渗血</label>

            <input
              type="checkbox"
              id="u5"
              value="出血"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.LIMBS_FEEL==='出血'?'checked':''"
            />
            <label for="u5">出血</label>
          </div>
        </div>
      </div>

      <div class="Info">
        <div class="InfoKey">患者家属对手术室工作评价：</div>
        <div class="InfoValue">
          <div class="no-print">
            <el-checkbox
              true-label="良好"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.INQUIRY_FOLLOWUP"
            >良好</el-checkbox>
            <el-checkbox
              true-label="一般"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.INQUIRY_FOLLOWUP"
            >一般</el-checkbox>
            <el-checkbox
              true-label="较差"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.INQUIRY_FOLLOWUP"
            >较差</el-checkbox>
          </div>
          <div class="show-print">
            <input
              type="checkbox"
              id="u1"
              value="良好"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.INQUIRY_FOLLOWUP==='良好'?'checked':''"
            />
            <label for="u1">良好</label>

            <input
              type="checkbox"
              id="u2"
              value="一般"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.INQUIRY_FOLLOWUP==='一般'?'checked':''"
            />
            <label for="u2">一般</label>

            <input
              type="checkbox"
              id="u3"
              value="较差"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.INQUIRY_FOLLOWUP==='较差'?'checked':''"
            />
            <label for="u3">较差</label>
          </div>
        </div>
      </div>

      <div class="Info" style="border-top:0px;margin-top:-5px;">
        <div class="InfoKey">患者家属对访视所持的态度：</div>
        <div class="InfoValue">
          <div class="no-print">
            <el-checkbox
              true-label="欢迎"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.SATISFACTORY"
            >欢迎</el-checkbox>
            <el-checkbox
              true-label="不欢迎"
              false-label
              v-model="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.SATISFACTORY"
            >不欢迎</el-checkbox>
          </div>
          <div class="show-print">
            <input
              type="checkbox"
              id="u1"
              value="欢迎"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.SATISFACTORY==='欢迎'?'checked':''"
            />
            <label for="u1">欢迎</label>

            <input
              type="checkbox"
              id="u2"
              value="不欢迎"
              :checked="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.SATISFACTORY==='不欢迎'?'checked':''"
            />
            <label for="u2">不欢迎</label>
          </div>
        </div>
      </div>

      <div class="InfoKey" style="margin-top:5px;">特殊意见：</div>
      <div>
        <div class="no-print">
          <el-input
            style="margin-top:10px;"
            type="textarea"
            :autosize="{ minRows: 4, maxRows: 4}"
            maxlength="100"
            show-word-limit
            v-model="MedicalBasicDoc.MED_ANESTHESIA_RECOVER.SPECIAL_CONDITION"
          ></el-input>
        </div>
        <div
          class="show-print"
          style="margin-left:15px;margin-top:20px; height:100px;"
        >{{MedicalBasicDoc.MED_ANESTHESIA_RECOVER.SPECIAL_CONDITION}}</div>
      </div>

      <div class="Info" style="border-top: 10px;">
        <div style="margin-left:600px;">受访者：</div>
        <div>___________________</div>
      </div>
      <div class="Info" style="border-top: 0px;margin-bottom:20px;">
        <div style="margin-left:600px;margin-top:8px;">访视者：</div>
        <div>
          <div class="no-print">
            <div>
              <MedSelect
                type="AnesDoctorDict"
                style="width:150px;"
                :remote="true"
                :filterable="true"
                placeholder="访视者"
                clearable
                v-model="MedicalBasicDoc.MED_ANESTHESIA_INQUIRY.INQUIRY_DOCTOR"
                @GetDiaplayValue="GetDiaplayValue"
              ></MedSelect>
            </div>
          </div>
          <div
            class="show-print"
            style="border-bottom:1px dashed;margin-top:3px;line-height: 20px;height:20px;width:150px;"
          >{{INQUIRY_DOCTOR_NAME}}</div>
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
import NursingVisitDoc from './NursingVisitDoc.js'
export default NursingVisitDoc
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
