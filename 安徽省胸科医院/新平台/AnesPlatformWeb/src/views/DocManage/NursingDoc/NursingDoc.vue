<template>
  <div class="MainContent" id="MainContent">
    <!--确保文书打印主体的ID=printaArea,千万不要拼写错误，不然无法上传-->
    <div class="MainPrint" id="printaArea" ref="print" style="font-family:'宋体';">
      <div class="Title">安徽省胸科医院</div>
      <div class="Title" style="font-size:23px;">手术护理记录单</div>
      <div class="Info">
        <div class="InfoKey" style="width:60px;text-align:right;">姓名：</div>
        <div class="InfoValue" style="min-width:120px;">{{MedicalBasicDoc.PatientDetail.NAME}}</div>
        <div class="InfoKey" style="width:60px;text-align:right;">病区：</div>
        <div class="InfoValue" style="min-width:250px;">{{MedicalBasicDoc.PatientDetail.DEPT_NAME}}</div>
        <div class="InfoKey" style="width:80px;text-align:right;">床号：</div>
        <div class="InfoValue" style="min-width:80px;">{{MedicalBasicDoc.PatientDetail.BED_NO}}</div>
        <div class="InfoKey" style="width:80px;text-align:right;">住院号：</div>
        <div class="InfoValue">{{MedicalBasicDoc.PatientDetail.INP_NO}}</div>
      </div>
      <div class="Info">
        <div class="InfoKey" style="width:60px;text-align:right;">年龄：</div>
        <div class="InfoValue" style="min-width:120px;">{{MedicalBasicDoc.PatientDetail.AGE}}</div>
        <div class="InfoKey" style="width:60px;text-align:right;">性别：</div>
        <div class="InfoValue" style="min-width:250px;">{{MedicalBasicDoc.PatientDetail.SEX}}</div>
        <div class="InfoKey" style="width:80px;text-align:right;">手术间：</div>
        <div
          class="InfoValue"
          style="min-width:80px;"
        >{{MedicalBasicDoc.PatientDetail.OPER_ROOM_NO}}</div>
        <div class="InfoKey" style="width:80px;text-align:right;">台次：</div>
        <div class="InfoValue">{{MedicalBasicDoc.MED_OPERATION_MASTER.SEQUENCE}}</div>
      </div>
      <div class="Info">
        <div class="InfoKey" style="margin-top:18px;">手术体位：</div>
        <div class="InfoValue">
          <div class="no-print">
            <InputSelect
              type="OperPosition"
              style="width:320px;"
              placeholder="手术体位"
              v-model="MedicalBasicDoc.MED_OPERATION_MASTER.OPER_POSITION"
            ></InputSelect>
          </div>
          <div
            class="show-print"
            style="border-bottom:1px dashed;width:320px;margin-top:5px;line-height: 20px;height:20px;"
          >{{MedicalBasicDoc.MED_OPERATION_MASTER.OPER_POSITION}}</div>
        </div>

        <div class="InfoKey" style="margin-top:18px;margin-left:10px;">术前诊断：</div>
        <div class="InfoValue">
          <div class="no-print">
            <InputSelect
              type="OperPosition"
              style="width:320px;"
              placeholder="手术体位"
              v-model="MedicalBasicDoc.MED_OPERATION_MASTER.DIAG_BEFORE_OPERATION"
            ></InputSelect>
          </div>
          <div
            class="show-print"
            style="border-bottom:1px dashed;width:320px;margin-top:5px;line-height: 20px;height:20px;"
          >{{MedicalBasicDoc.MED_OPERATION_MASTER.OPER_POSITION}}</div>
        </div>
      </div>

      <div class="Info">
        <div class="InfoKey" style="margin-top:18px;">麻醉方式：</div>
        <div class="InfoValue">
          <div class="no-print">
            <InputSelect
              type="AnesMethodDict"
              style="width:320px;"
              placeholder="麻醉方式"
              v-model="MedicalBasicDoc.MED_OPERATION_MASTER.ANES_METHOD"
            ></InputSelect>
          </div>
          <div
            class="show-print"
            style="border-bottom:1px dashed;width:320px;margin-top:5px;line-height: 20px;height:20px;"
          >{{MedicalBasicDoc.MED_OPERATION_MASTER.ANES_METHOD}}</div>
        </div>

        <div class="InfoKey" style="margin-top:18px;margin-left:10px;">手术名称：</div>
        <div class="InfoValue">
          <div class="no-print">
            <InputSelect
              type="OperNameDict"
              style="width:320px;"
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
            style="border-bottom:1px dashed;width:320px;margin-top:5px;line-height: 20px;height:20px;"
          >{{MedicalBasicDoc.MED_OPERATION_MASTER.OPERATION_NAME}}</div>
        </div>
      </div>

      <div class="InfoColumn">
        <div class="InfoColumnTitle">一 病区护士与手术护士术前交接记录</div>
        <div class="InfoNoTopBorder">
          <div class="InfoKey">1、</div>
          <div class="InfoValue">
            <div class="no-print">
              <el-checkbox
                label="病历"
                v-model="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.BINGLI"
                true-label="是"
                false-label
              ></el-checkbox>
            </div>
            <div class="show-print">
              <input
                type="checkbox"
                id="u1"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.BINGLI==='是'?'checked':''"
              />
              <label for="u1">病历</label>
            </div>
          </div>

          <div class="InfoKey">2、药品名称与数量</div>
          <div class="InfoValue" style="margin-top:-5px; margin-left:5px;width:100px;">
            <div class="no-print" style="text-align:center;">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.YP_NAME_COUNT"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;text-align:center;"
            >{{MedicalBasicDoc.MED_NURSING_BEFORESHIFT.YP_NAME_COUNT}}</div>
          </div>

          <div class="InfoKey">3、</div>
          <div class="InfoValue">
            <div class="no-print">
              <el-checkbox
                label="影像学资料"
                v-model="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.YXXZL"
                true-label="是"
                false-label
              ></el-checkbox>
            </div>
            <div class="show-print">
              <input
                type="checkbox"
                id="u1"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.YXXZL==='是'?'checked':''"
              />
              <label for="u1">影像学资料</label>
            </div>
          </div>
          <div class="InfoValue">共</div>
          <div class="InfoValue" style="margin-top:-5px; margin-left:-10px;width:40px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.YXXZL_COUNT"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_BEFORESHIFT.YXXZL_COUNT}}</div>
          </div>
          <div class="InfoValue">张</div>

          <div class="InfoKey">4、</div>
          <div class="InfoValue">
            <div class="no-print">
              <el-checkbox
                label="病人核对"
                v-model="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.BRHD"
                true-label="是"
                false-label
              ></el-checkbox>
            </div>
            <div class="show-print">
              <input
                type="checkbox"
                id="u1"
                value="是"
                v-bind:checked="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.BRHD==='是'?'checked':''"
              />
              <label for="u1">病人核对</label>
            </div>
          </div>

          <div class="InfoKey">5、</div>
          <div class="InfoValue">
            <div class="no-print">
              <el-checkbox
                label="手术部位核对"
                v-model="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.SSBWHD"
                true-label="是"
                false-label
              ></el-checkbox>
            </div>
            <div class="show-print">
              <input
                type="checkbox"
                id="u1"
                value="是"
                v-bind:checked="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.SSBWHD==='是'?'checked':''"
              />
              <label for="u1">手术部位核对</label>
            </div>
          </div>
        </div>

        <div class="InfoNoTopBorder">
          <div class="InfoKey">6、核查术前准备项目：</div>
          <div class="InfoValue">
            <div class="no-print">
              <el-checkbox
                label="禁食水"
                v-model="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.JSS"
                true-label="是"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="入室前排尿"
                v-model="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.RSQPN"
                true-label="是"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="备皮"
                v-model="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.BP"
                true-label="是"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="家属同意签字"
                v-model="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.JSTYQZ"
                true-label="是"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="去除首饰及隐形眼镜、假牙等物品"
                v-model="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.QCSSYXYJJA"
                true-label="是"
                false-label
              ></el-checkbox>
            </div>
            <div class="show-print">
              <input
                type="checkbox"
                id="u1"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.JSS==='是'?'checked':''"
              />
              <label for="u1">禁食水</label>

              <input
                type="checkbox"
                id="u2"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.RSQPN==='是'?'checked':''"
              />
              <label for="u2">入室前排尿</label>

              <input
                type="checkbox"
                id="u3"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.BP==='是'?'checked':''"
              />
              <label for="u3">备皮</label>

              <input
                type="checkbox"
                id="u4"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.JSTYQZ==='是'?'checked':''"
              />
              <label for="u4">家属同意签字</label>

              <input
                type="checkbox"
                id="u5"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.QCSSYXYJJA==='是'?'checked':''"
              />
              <label for="u5">去除首饰及隐形眼镜、假牙等物品</label>
            </div>
          </div>
        </div>

        <div class="InfoNoTopBorder">
          <div class="InfoValue" style="margin-left:10px;">
            <div class="no-print">
              术前用药：
              <el-checkbox
                style="margin-left:-10px;"
                label="有"
                v-model="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.SQYY"
                true-label="有"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="无"
                v-model="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.SQYY"
                true-label="无"
                false-label
              ></el-checkbox>&nbsp;月经来潮：
              <el-checkbox
                style="margin-left:-10px;"
                label="有"
                v-model="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.THKC"
                true-label="有"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="无"
                v-model="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.THKC"
                true-label="无"
                false-label
              ></el-checkbox>&nbsp;发热：
              <el-checkbox
                style="margin-left:-10px;"
                label="有"
                v-model="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.FR"
                true-label="有"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="无"
                v-model="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.FR"
                true-label="无"
                false-label
              ></el-checkbox>&nbsp;咳嗽：
              <el-checkbox
                style="margin-left:-10px;"
                label="有"
                v-model="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.KS"
                true-label="有"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="无"
                v-model="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.KS"
                true-label="无"
                false-label
              ></el-checkbox>&nbsp;松动牙：
              <el-checkbox
                style="margin-left:-10px;"
                label="有"
                v-model="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.SDY"
                true-label="有"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="无"
                v-model="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.SDY"
                true-label="无"
                false-label
              ></el-checkbox>
            </div>
            <div class="show-print">
              术前用药：
              <input
                type="checkbox"
                id="u1"
                value="有"
                :checked="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.SQYY==='有'?'checked':''"
              />
              <label for="u1">有</label>

              <input
                type="checkbox"
                id="u2"
                value="无"
                :checked="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.SQYY==='无'?'checked':''"
              />
              <label for="u2">无</label>
              &nbsp;月经来潮：
              <input
                type="checkbox"
                id="u3"
                value="有"
                :checked="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.THKC==='有'?'checked':''"
              />
              <label for="u3">有</label>

              <input
                type="checkbox"
                id="u4"
                value="无"
                :checked="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.THKC==='无'?'checked':''"
              />
              <label for="u4">无</label>
              &nbsp;发热：
              <input
                type="checkbox"
                id="u5"
                value="有"
                :checked="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.FR==='有'?'checked':''"
              />
              <label for="u5">有</label>

              <input
                type="checkbox"
                id="u6"
                value="无"
                :checked="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.FR==='无'?'checked':''"
              />
              <label for="u6">无</label>
              &nbsp;咳嗽：
              <input
                type="checkbox"
                id="u7"
                value="有"
                :checked="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.KS==='有'?'checked':''"
              />
              <label for="u7">有</label>

              <input
                type="checkbox"
                id="u8"
                value="无"
                :checked="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.KS==='无'?'checked':''"
              />
              <label for="u8">无</label>
              &nbsp;松动牙：
              <input
                type="checkbox"
                id="u9"
                value="有"
                :checked="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.SDY==='有'?'checked':''"
              />
              <label for="u9">有</label>

              <input
                type="checkbox"
                id="u10"
                value="无"
                :checked="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.SDY==='无'?'checked':''"
              />
              <label for="u10">无</label>
            </div>
          </div>
        </div>

        <div class="InfoNoTopBorder">
          <div class="InfoKey">7、术前宣传：</div>
          <div class="InfoValue">
            <div class="no-print">
              <el-checkbox
                label="麻醉相关知识"
                v-model="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.MZXGZS"
                true-label="是"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="手术相关知识"
                v-model="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.SSXGZS"
                true-label="是"
                false-label
              ></el-checkbox>（麻醉及手术方式、体位、术中可能出现的不适）
            </div>
            <div class="show-print">
              <input
                type="checkbox"
                id="u1"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.MZXGZS==='是'?'checked':''"
              />
              <label for="u1">麻醉相关知识</label>

              <input
                type="checkbox"
                id="u2"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.SSXGZS==='是'?'checked':''"
              />
              <label for="u2">手术相关知识</label>
              （麻醉及手术方式、体位、术中可能出现的不适）
            </div>
          </div>
        </div>

        <div class="InfoNoTopBorder">
          <div class="InfoKey">8、传染病及感染情况：</div>
          <div class="InfoValue">
            <div class="no-print">
              乙肝相关：
              <el-checkbox
                style="margin-left:-10px;"
                label="阴性"
                v-model="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.YG_YING_YANG"
                true-label="阴性"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="阳性"
                v-model="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.YG_YING_YANG"
                true-label="阳性"
                false-label
              ></el-checkbox>&nbsp;HIV：
              <el-checkbox
                style="margin-left:-10px;"
                label="阴性"
                v-model="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.HIV_YING_YNAG"
                true-label="阴性"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="阳性"
                v-model="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.HIV_YING_YNAG"
                true-label="阳性"
                false-label
              ></el-checkbox>
            </div>
            <div class="show-print">
              乙肝相关：
              <input
                type="checkbox"
                id="u1"
                value="阴性"
                :checked="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.YG_YING_YANG==='阴性'?'checked':''"
              />
              <label for="u1">阴性</label>

              <input
                type="checkbox"
                id="u2"
                value="阳性"
                :checked="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.YG_YING_YANG==='阳性'?'checked':''"
              />
              <label for="u2">阳性</label>
              &nbsp;HIV：
              <input
                type="checkbox"
                id="u3"
                value="阴性"
                :checked="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.HIV_YING_YNAG==='阴性'?'checked':''"
              />
              <label for="u3">阴性</label>

              <input
                type="checkbox"
                id="u4"
                value="阳性"
                :checked="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.HIV_YING_YNAG==='阳性'?'checked':''"
              />
              <label for="u4">阳性</label>
            </div>
          </div>
          <div class="InfoKey">其他：</div>
          <div class="InfoValue" style="margin-top:-5px; margin-left:5px;width:150px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.HIV_OTHER"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_BEFORESHIFT.HIV_OTHER}}</div>
          </div>
        </div>

        <div class="InfoNoTopBorder" style="margin-top:5px;">
          <div class="InfoKey">病房护士：</div>
          <div class="InfoValue" style="margin-top:-5px; margin-left:-10px;width:100px;">
            <div class="no-print">
              <MedSelect
                type="NurseDict"
                style="width:100px;margin-top:3px;"
                :remote="true"
                :filterable="true"
                placeholder="病房护士"
                clearable
                v-model="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.BF_NURSE"
                @GetDiaplayValue="GetDiaplayValue"
              ></MedSelect>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
            >{{BF_NURSE_DISPLAY}}</div>
          </div>
          <div class="InfoKey" style="margin-left:20px;">手术室护士：</div>
          <div class="InfoValue" style="margin-top:-5px; margin-left:-10px;width:100px;">
            <div class="no-print">
              <MedSelect
                type="NurseDictInOperRoom"
                style="width:100px;margin-top:3px;"
                :remote="true"
                :filterable="true"
                placeholder="手术室护士"
                clearable
                v-model="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.SSS_NURSE"
                @GetDiaplayValue="GetDiaplayValue"
              ></MedSelect>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
            >{{SSS_NURSE_DISPLAY}}</div>
          </div>
          <div class="InfoKey" style="margin-left:20px;">交接时间：</div>
          <div class="el-date-picker">
            <div class="no-print">
              <el-date-picker
                style="width:200px;margin-top:-5px;"
                type="datetime"
                clearable
                placeholder="交接时间"
                v-model="MedicalBasicDoc.MED_NURSING_BEFORESHIFT.SHIFT_DATE"
                id="inDate"
              ></el-date-picker>
            </div>
            <div
              class="show-print"
              style="border-bottom:1px dashed;width:200px;margin-top:2px;line-height: 20px;height:20px;"
            >{{MedicalBasicDoc.MED_NURSING_BEFORESHIFT.SHIFT_DATE | formatDate('YYYY-MM-DD HH:mm:ss')}}</div>
          </div>
        </div>
      </div>

      <div class="InfoColumn">
        <div class="InfoNoTopBorder">
          <div class="InfoColumnTitle">二 手术病人术前入室核对评估</div>
          <div class="InfoKey" style="margin-left:20px;">入室时间：</div>
          <div class="el-date-picker" style="width:220px;">
            <div class="no-print">
              <el-date-picker
                style="width:200px;margin-top:-5px;"
                type="datetime"
                clearable
                placeholder="交接时间"
                v-model="MedicalBasicDoc.MED_OPERATION_MASTER.IN_DATE_TIME"
                id="inDate"
              ></el-date-picker>
            </div>
            <div
              class="show-print"
              style="border-bottom:1px dashed;width:200px;margin-top:2px;line-height: 20px;height:20px;"
            >{{MedicalBasicDoc.MED_OPERATION_MASTER.IN_DATE_TIME | formatDate('YYYY-MM-DD HH:mm:ss')}}</div>
          </div>
          <div class="InfoValue">
            <div class="no-print">
              <el-checkbox
                label="急诊"
                true-label="1"
                false-label
                v-model="MedicalBasicDoc.MED_OPERATION_MASTER.EMERGENCY_IND"
                :checked="MedicalBasicDoc.MED_OPERATION_MASTER.EMERGENCY_IND===1?true:false"
              ></el-checkbox>
              <el-checkbox
                label="慢诊"
                true-label="0"
                false-label
                v-model="MedicalBasicDoc.MED_OPERATION_MASTER.EMERGENCY_IND"
                :checked="MedicalBasicDoc.MED_OPERATION_MASTER.EMERGENCY_IND!==1?true:false"
              ></el-checkbox>
              <el-checkbox
                label="手术时间确认"
                true-label="是"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.SSJQR"
                false-label
              ></el-checkbox>
            </div>
            <div class="show-print">
              <input
                type="checkbox"
                id="u1"
                value="1"
                :checked="MedicalBasicDoc.MED_OPERATION_MASTER.EMERGENCY_IND===1?'checked':''"
              />
              <label for="u1">急诊</label>

              <input
                type="checkbox"
                id="u2"
                value="0"
                :checked="MedicalBasicDoc.MED_OPERATION_MASTER.EMERGENCY_IND!==1?'checked':''"
              />
              <label for="u2">慢诊</label>

              <input
                type="checkbox"
                id="u3"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.SSJQR==='是'?'checked':''"
              />
              <label for="u3">手术时间确认</label>
            </div>
          </div>
        </div>

        <div class="InfoNoTopBorder">
          <div class="InfoKey">1、根据</div>
          <div class="InfoValue">
            <div class="no-print">
              （
              <el-checkbox
                label="通知单"
                true-label="是"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.TZD"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="病历"
                true-label="是"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.BL"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="腕带"
                true-label="是"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.WD"
                false-label
              ></el-checkbox>）与
              <el-checkbox
                label="病人"
                true-label="是"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.HD_BR"
                false-label
              ></el-checkbox>或
              <el-checkbox
                label="家属"
                true-label="是"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.HD_JS"
                false-label
              ></el-checkbox>核对：
              <el-checkbox
                label="姓名"
                true-label="是"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.HD_XM"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="手术名称"
                true-label="是"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.HD_SSMC"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="手术部位"
                true-label="是"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.HD_SSBW"
                false-label
              ></el-checkbox>
            </div>
            <div class="show-print">
              （
              <input
                type="checkbox"
                id="u1"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.TZD==='是'?'checked':''"
              />
              <label for="u1">通知单</label>

              <input
                type="checkbox"
                id="u2"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.BL==='是'?'checked':''"
              />
              <label for="u2">病历</label>

              <input
                type="checkbox"
                id="u3"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.WD==='是'?'checked':''"
              />
              <label for="u3">腕带</label>
              ）与
              <input
                type="checkbox"
                id="u4"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.HD_BR==='是'?'checked':''"
              />
              <label for="u4">病人</label>
              或
              <input
                type="checkbox"
                id="u5"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.HD_JS==='是'?'checked':''"
              />
              <label for="u5">家属</label>
              核对：
              <input
                type="checkbox"
                id="u6"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.HD_XM==='是'?'checked':''"
              />
              <label for="u6">姓名</label>

              <input
                type="checkbox"
                id="u7"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.HD_SSMC==='是'?'checked':''"
              />
              <label for="u7">手术名称</label>

              <input
                type="checkbox"
                id="u8"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.HD_SSBW==='是'?'checked':''"
              />
              <label for="u8">手术部位</label>
            </div>
          </div>
        </div>

        <div class="InfoNoTopBorder">
          <div class="InfoKey">
            <div class="no-print">
              2、病人所知的过敏史
              <el-checkbox
                label="有"
                true-label="有"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.GMS"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="无"
                true-label="无"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.GMS"
                false-label
              ></el-checkbox>&nbsp; 既往手术史
              <el-checkbox
                label="有"
                true-label="有"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.JWSSS"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="无"
                true-label="无"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.JWSSS"
                false-label
              ></el-checkbox>&nbsp; 慢性病史
              <el-checkbox
                label="有"
                true-label="有"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.MXBS"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="无"
                true-label="无"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.MXBS"
                false-label
              ></el-checkbox>
            </div>
            <div class="show-print">
              2、病人所知的过敏史
              <input
                type="checkbox"
                id="u1"
                value="有"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.GMS==='有'?'checked':''"
              />
              <label for="u1">有</label>

              <input
                type="checkbox"
                id="u2"
                value="无"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.GMS==='无'?'checked':''"
              />
              <label for="u2">无</label>
              &nbsp; 既往手术史
              <input
                type="checkbox"
                id="u1"
                value="有"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.JWSSS==='有'?'checked':''"
              />
              <label for="u1">有</label>

              <input
                type="checkbox"
                id="u2"
                value="无"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.JWSSS==='无'?'checked':''"
              />
              <label for="u2">无</label>
              &nbsp; 慢性病史
              <input
                type="checkbox"
                id="u1"
                value="有"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.MXBS==='有'?'checked':''"
              />
              <label for="u1">有</label>

              <input
                type="checkbox"
                id="u2"
                value="无"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.MXBS==='无'?'checked':''"
              />
              <label for="u2">无</label>
            </div>
          </div>
        </div>

        <div class="InfoNoTopBorder">
          <div class="InfoKey">
            <div class="no-print">
              3、体内植入物：
              <el-checkbox
                label="义眼"
                true-label="是"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.ZRW_YY"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="心脏起搏器"
                true-label="是"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.ZRW_XZQBQ"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="人工瓣膜(金属)"
                true-label="是"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.ZRW_RGBM"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="假肢"
                true-label="是"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.ZRW_JZ"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="钢板"
                true-label="是"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.ZRW_GB"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="助听器"
                true-label="是"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.ZRW_ZTQ"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="其他"
                true-label="是"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.ZRW_OTHER"
                false-label
              ></el-checkbox>
            </div>
            <div class="show-print">
              3、体内植入物：
              <input
                type="checkbox"
                id="u1"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.ZRW_YY==='是'?'checked':''"
              />
              <label for="u1">义眼</label>

              <input
                type="checkbox"
                id="u2"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.ZRW_XZQBQ==='是'?'checked':''"
              />
              <label for="u2">心脏起搏器</label>

              <input
                type="checkbox"
                id="u3"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.ZRW_RGBM==='是'?'checked':''"
              />
              <label for="u3">人工瓣膜(金属)</label>

              <input
                type="checkbox"
                id="u4"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.ZRW_JZ==='是'?'checked':''"
              />
              <label for="u4">假肢</label>

              <input
                type="checkbox"
                id="u5"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.ZRW_GB==='是'?'checked':''"
              />
              <label for="u5">钢板</label>

              <input
                type="checkbox"
                id="u6"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.ZRW_ZTQ==='是'?'checked':''"
              />
              <label for="u6">助听器</label>

              <input
                type="checkbox"
                id="u7"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.ZRW_OTHER==='是'?'checked':''"
              />
              <label for="u7">其他</label>
            </div>
          </div>
        </div>

        <div class="InfoNoTopBorder">
          <div class="InfoKey">
            <div class="no-print">
              4、意识状态：
              <el-checkbox
                label="清醒"
                true-label="清醒"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.YSZT"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="嗜睡"
                true-label="嗜睡"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.YSZT"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="躁动"
                true-label="躁动"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.YSZT"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="昏迷"
                true-label="昏迷"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.YSZT"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="其他"
                true-label="其他"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.YSZT"
                false-label
              ></el-checkbox>
            </div>
            <div class="show-print">
              4、意识状态：
              <input
                type="checkbox"
                id="u1"
                value="清醒"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.YSZT==='清醒'?'checked':''"
              />
              <label for="u1">清醒</label>

              <input
                type="checkbox"
                id="u2"
                value="嗜睡"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.YSZT==='嗜睡'?'checked':''"
              />
              <label for="u2">嗜睡</label>

              <input
                type="checkbox"
                id="u3"
                value="躁动"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.YSZT==='躁动'?'checked':''"
              />
              <label for="u3">躁动</label>

              <input
                type="checkbox"
                id="u4"
                value="昏迷"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.YSZT==='昏迷'?'checked':''"
              />
              <label for="u4">昏迷</label>

              <input
                type="checkbox"
                id="u5"
                value="其他"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.YSZT==='其他'?'checked':''"
              />
              <label for="u5">其他</label>
            </div>
          </div>
          <div class="InfoValue" style="margin-top:-5px; margin-left:-10px;width:150px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.YSZT_OTHER"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:20px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_BEFOREASSESS.YSZT_OTHER}}</div>
          </div>
        </div>

        <div class="InfoNoTopBorder">
          <div class="InfoKey">
            <div class="no-print">
              5、心理状态：
              <el-checkbox
                label="平静、稳定"
                true-label="平静、稳定"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.XLZT"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="紧张"
                true-label="紧张"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.XLZT"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="焦虑"
                true-label="焦虑"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.XLZT"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="恐惧"
                true-label="恐惧"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.XLZT"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="悲哀"
                true-label="悲哀"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.XLZT"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="压抑"
                true-label="压抑"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.XLZT"
                false-label
              ></el-checkbox>
            </div>
            <div class="show-print">
              5、心理状态：
              <input
                type="checkbox"
                id="u1"
                value="平静、稳定"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.XLZT==='平静、稳定'?'checked':''"
              />
              <label for="u1">平静、稳定</label>

              <input
                type="checkbox"
                id="u2"
                value="紧张"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.XLZT==='紧张'?'checked':''"
              />
              <label for="u2">紧张</label>

              <input
                type="checkbox"
                id="u3"
                value="焦虑"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.XLZT==='焦虑'?'checked':''"
              />
              <label for="u3">焦虑</label>

              <input
                type="checkbox"
                id="u4"
                value="恐惧"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.XLZT==='恐惧'?'checked':''"
              />
              <label for="u4">恐惧</label>

              <input
                type="checkbox"
                id="u5"
                value="悲哀"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.XLZT==='悲哀'?'checked':''"
              />
              <label for="u5">悲哀</label>

              <input
                type="checkbox"
                id="u6"
                value="压抑"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.XLZT==='压抑'?'checked':''"
              />
              <label for="u6">压抑</label>
            </div>
          </div>
        </div>

        <div class="InfoNoTopBorder">
          <div class="InfoKey">
            <div class="no-print">
              6、皮肤黏膜：
              <el-checkbox
                label="正常"
                true-label="正常"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.PFNM_STATUS"
                false-label
              ></el-checkbox>
              <el-checkbox
                label="破损"
                true-label="破损"
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.PFNM_STATUS"
                false-label
              ></el-checkbox>(部位：
            </div>
            <div class="show-print">
              6、皮肤黏膜：
              <input
                type="checkbox"
                id="u1"
                value="正常"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.PFNM_STATUS==='正常'?'checked':''"
              />
              <label for="u1">正常</label>

              <input
                type="checkbox"
                id="u2"
                value="破损"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.PFNM_STATUS==='破损'?'checked':''"
              />
              <label for="u2">破损</label>
              (部位：
            </div>
          </div>
          <div class="InfoValue" style="margin-top:-5px; margin-left:-10px;width:150px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.PFNM_BW"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_BEFOREASSESS.PFNM_BW}}</div>
          </div>
          <div class="InfoKey">性质：</div>
          <div class="InfoValue" style="margin-top:-5px; margin-left:-10px;width:150px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.PFNM_XZ"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:5px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_BEFOREASSESS.PFNM_XZ}}</div>
          </div>
          <div class="InfoKey">)</div>
        </div>

        <div class="InfoNoTopBorder">
          <div class="InfoKey">
            <div class="no-print">
              7、四肢活动：
              <el-checkbox
                label="正常"
                true-label="正常"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.SZHD_STATUS"
              ></el-checkbox>
              <el-checkbox
                label="残障"
                true-label="残障"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.SZHD_STATUS"
              ></el-checkbox>(部位：
            </div>
            <div class="show-print">
              7、四肢活动：
              <input
                type="checkbox"
                id="u1"
                value="正常"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.SZHD_STATUS==='正常'?'checked':''"
              />
              <label for="u1">正常</label>

              <input
                type="checkbox"
                id="u2"
                value="残障"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.SZHD_STATUS==='残障'?'checked':''"
              />
              <label for="u2">残障</label>
              (部位：
            </div>
          </div>
          <div class="InfoValue" style="margin-top:-5px; margin-left:-10px;width:150px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.SZHD_BW"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_BEFOREASSESS.SZHD_BW}}</div>
          </div>
          <div class="InfoKey">
            <div class="no-print">
              性质：
              <el-checkbox
                label="瘫痪"
                true-label="瘫痪"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.SZHD_XZ"
              ></el-checkbox>
              <el-checkbox
                label="畸形"
                true-label="畸形"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.SZHD_XZ"
              ></el-checkbox>
              <el-checkbox
                label="其他"
                true-label="其他"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.SZHD_XZ"
              ></el-checkbox>
            </div>
            <div class="show-print">
              性质：
              <input
                type="checkbox"
                id="u1"
                value="瘫痪"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.SZHD_XZ==='瘫痪'?'checked':''"
              />
              <label for="u1">瘫痪</label>

              <input
                type="checkbox"
                id="u2"
                value="畸形"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.SZHD_XZ==='畸形'?'checked':''"
              />
              <label for="u2">畸形</label>

              <input
                type="checkbox"
                id="u3"
                value="其他"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.SZHD_XZ==='其他'?'checked':''"
              />
              <label for="u3">其他</label>
            </div>
          </div>
          <div class="InfoValue" style="margin-top:-5px; margin-left:-10px;width:150px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.SZHD_OTHER"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:20px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_BEFOREASSESS.SZHD_OTHER}}</div>
          </div>
          <div class="InfoKey">)</div>
        </div>

        <div class="InfoNoTopBorder">
          <div class="InfoKey">
            <div class="no-print">
              8、肢体感觉：
              <el-checkbox
                label="正常"
                true-label="正常"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.ZTGJ_STATUS"
              ></el-checkbox>
              <el-checkbox
                label="异常"
                true-label="异常"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.ZTGJ_STATUS"
              ></el-checkbox>(部位：
            </div>
            <div class="show-print">
              8、肢体感觉：
              <input
                type="checkbox"
                id="u1"
                value="正常"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.ZTGJ_STATUS==='正常'?'checked':''"
              />
              <label for="u1">正常</label>

              <input
                type="checkbox"
                id="u2"
                value="异常"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.ZTGJ_STATUS==='异常'?'checked':''"
              />
              <label for="u2">异常</label>
              (部位：
            </div>
          </div>
          <div class="InfoValue" style="margin-top:-5px; margin-left:-10px;width:150px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.ZTGJ_BW"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_BEFOREASSESS.ZTGJ_BW}}</div>
          </div>
          <div class="InfoKey">
            <div class="no-print">
              性质：
              <el-checkbox
                label="瘫痪"
                true-label="瘫痪"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.ZTGJ_XZ"
              ></el-checkbox>
              <el-checkbox
                label="畸形"
                true-label="畸形"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.ZTGJ_XZ"
              ></el-checkbox>
              <el-checkbox
                label="其他"
                true-label="其他"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.ZTGJ_XZ"
              ></el-checkbox>
            </div>
            <div class="show-print">
              性质：
              <input
                type="checkbox"
                id="u1"
                value="瘫痪"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.ZTGJ_XZ==='瘫痪'?'checked':''"
              />
              <label for="u1">瘫痪</label>

              <input
                type="checkbox"
                id="u2"
                value="畸形"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.ZTGJ_XZ==='畸形'?'checked':''"
              />
              <label for="u2">畸形</label>

              <input
                type="checkbox"
                id="u3"
                value="其他"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.ZTGJ_XZ==='其他'?'checked':''"
              />
              <label for="u3">其他</label>
            </div>
          </div>
          <div class="InfoValue" style="margin-top:-5px; margin-left:-10px;width:150px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.ZTGJ_OTHER"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:20px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_BEFOREASSESS.ZTGJ_OTHER}}</div>
          </div>
          <div class="InfoKey">)</div>
        </div>

        <div class="InfoNoTopBorder">
          <div class="InfoKey">
            <div class="no-print">
              9、各种管道：
              <el-checkbox
                label="无"
                true-label="无"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.GD_STATUS"
              ></el-checkbox>
              <el-checkbox
                label="有"
                true-label="有"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.GD_STATUS"
              ></el-checkbox>
              <el-checkbox
                label="胃管"
                true-label="是"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.GD_WG"
              ></el-checkbox>
              <el-checkbox
                label="尿管"
                true-label="是"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.GD_NG"
              ></el-checkbox>
              <el-checkbox
                label="胸引管"
                true-label="是"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.GD_XYG"
              ></el-checkbox>
              <el-checkbox
                label="腹腔引流管"
                true-label="是"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.GD_FQYLG"
              ></el-checkbox>
              <el-checkbox
                label="输液管"
                true-label="是"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.GD_SYG"
              ></el-checkbox>部位：
            </div>
            <div class="show-print">
              9、各种管道：
              <input
                type="checkbox"
                id="u1"
                value="无"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.GD_STATUS==='无'?'checked':''"
              />
              <label for="u1">无</label>

              <input
                type="checkbox"
                id="u2"
                value="有"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.GD_STATUS==='有'?'checked':''"
              />
              <label for="u2">有</label>

              <input
                type="checkbox"
                id="u3"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.GD_WG==='瘫痪'?'checked':''"
              />
              <label for="u3">胃管</label>

              <input
                type="checkbox"
                id="u4"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.GD_NG==='瘫痪'?'checked':''"
              />
              <label for="u4">尿管</label>

              <input
                type="checkbox"
                id="u5"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.GD_XYG==='瘫痪'?'checked':''"
              />
              <label for="u5">胸引管</label>

              <input
                type="checkbox"
                id="u6"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.GD_FQYLG==='瘫痪'?'checked':''"
              />
              <label for="u6">腹腔引流管</label>

              <input
                type="checkbox"
                id="u7"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.GD_SYG==='瘫痪'?'checked':''"
              />
              <label for="u7">输液管</label>
            </div>
          </div>
          <div class="InfoValue" style="margin-top:-5px; margin-left:0px;width:150px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.GD_BW"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_BEFOREASSESS.GD_BW}}</div>
          </div>
        </div>

        <div class="InfoNoTopBorder">
          <div class="InfoKey" style="margin-left:115px;">其他：</div>
          <div class="InfoValue" style="margin-top:-5px; margin-left:0px;width:150px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.GD_OTHER"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_BEFOREASSESS.GD_OTHER}}</div>
          </div>
          <div class="InfoValue">
            <div class="no-print">
              (
              <el-checkbox
                label="通畅、固定"
                true-label="通畅、固定"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.GD__STATUS_DES"
              ></el-checkbox>
              <el-checkbox
                label="堵塞口"
                true-label="堵塞口"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.GD__STATUS_DES"
              ></el-checkbox>
              <el-checkbox
                label="松动口"
                true-label="松动口"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.GD__STATUS_DES"
              ></el-checkbox>)
            </div>
            <div class="show-print">
              （
              <input
                type="checkbox"
                id="u1"
                value="通畅、固定"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.GD__STATUS_DES==='通畅、固定'?'checked':''"
              />
              <label for="u1">通畅、固定</label>

              <input
                type="checkbox"
                id="u1"
                value="堵塞口"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.GD__STATUS_DES==='堵塞口'?'checked':''"
              />
              <label for="u1">堵塞口</label>

              <input
                type="checkbox"
                id="u1"
                value="松动口"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.GD__STATUS_DES==='松动口'?'checked':''"
              />
              <label for="u1">松动口</label>
              )
            </div>
          </div>
        </div>

        <div class="InfoNoTopBorder">
          <div class="InfoKey">
            <div class="no-print">
              10、病房带来的物品：摄片：
              <el-checkbox
                label="无"
                true-label="无"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.BFDLW_SP"
              ></el-checkbox>
              <el-checkbox
                label="有"
                true-label="有"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.BFDLW_SP"
              ></el-checkbox>
            </div>
            <div class="show-print">
              10、病房带来的物品：摄片：
              <input
                type="checkbox"
                id="u1"
                value="无"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.BFDLW_SP==='无'?'checked':''"
              />
              <label for="u1">无</label>

              <input
                type="checkbox"
                id="u2"
                value="有"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.BFDLW_SP==='有'?'checked':''"
              />
              <label for="u2">有</label>
            </div>
          </div>
          <div class="InfoValue" style="margin-top:-5px; margin-left:0px;width:50px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.BFDLW_SP_COUNT"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;text-align:center;"
            >{{MedicalBasicDoc.MED_NURSING_BEFOREASSESS.BFDLW_SP_COUNT}}</div>
          </div>
          <div class="InfoKey">
            <div class="no-print">
              张&nbsp;&nbsp;药物：
              <el-checkbox
                label="无"
                true-label="无"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.BFDLW_YP"
              ></el-checkbox>
              <el-checkbox
                label="有"
                true-label="有"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.BFDLW_YP"
              ></el-checkbox>名称
            </div>
            <div class="show-print">
              张&nbsp;&nbsp;药物：
              <input
                type="checkbox"
                id="u1"
                value="无"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.BFDLW_YP==='无'?'checked':''"
              />
              <label for="u1">无</label>

              <input
                type="checkbox"
                id="u2"
                value="有"
                :checked="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.BFDLW_YP==='有'?'checked':''"
              />
              <label for="u2">有</label>
              名称
            </div>
          </div>
          <div class="InfoValue" style="margin-top:-5px; margin-left:0px;width:100px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.BFDLW_YP_NAME"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:10px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_BEFOREASSESS.BFDLW_YP_NAME}}</div>
          </div>
          <div class="InfoKey">其他：</div>
          <div class="InfoValue" style="margin-top:-5px; margin-left:0px;width:100px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_BEFOREASSESS.BFDLW_OTHER"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_BEFOREASSESS.BFDLW_OTHER}}</div>
          </div>
        </div>
      </div>

      <div class="InfoColumn">
        <div class="InfoNoTopBorder">
          <div class="InfoColumnTitle">三 手术用物评估</div>
          <div class="InfoKey">
            <div class="no-print">
              1、手术器械准备：
              <el-checkbox
                label="齐全"
                true-label="是"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.SSQX"
              ></el-checkbox>
              <el-checkbox
                label="不齐全"
                true-label="否"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.SSQX"
              ></el-checkbox>2、仪器设备准备：
              <el-checkbox
                label="完好备用"
                true-label="是"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.YQSB"
              ></el-checkbox>
            </div>
            <div class="show-print">
              1、手术器械准备：
              <input
                type="checkbox"
                id="u1"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.SSQX==='是'?'checked':''"
              />
              <label for="u1">齐全</label>

              <input
                type="checkbox"
                id="u2"
                value="否"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.SSQX==='否'?'checked':''"
              />
              <label for="u2">不齐全</label>
              2、仪器设备准备：
              <input
                type="checkbox"
                id="u3"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.YQSB==='是'?'checked':''"
              />
              <label for="u3">完好备用</label>
            </div>
          </div>
        </div>

        <div class="InfoNoTopBorder">
          <div class="InfoKey" style="margin-left:125px;">
            <div class="no-print">
              3、体位用品准备：
              <el-checkbox
                label="齐全"
                true-label="是"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.TWYP"
              ></el-checkbox>
              <el-checkbox
                label="不齐全"
                true-label="否"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.TWYP"
              ></el-checkbox>4、手术环境准备：
              <el-checkbox
                label="合格"
                true-label="是"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.SSHJ"
              ></el-checkbox>
              <el-checkbox
                label="不合格"
                true-label="否"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.SSHJ"
              ></el-checkbox>
            </div>
            <div class="show-print">
              3、体位用品准备：
              <input
                type="checkbox"
                id="u1"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.TWYP==='是'?'checked':''"
              />
              <label for="u1">齐全</label>

              <input
                type="checkbox"
                id="u2"
                value="否"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.TWYP==='否'?'checked':''"
              />
              <label for="u2">不齐全</label>
              4、手术环境准备：
              <input
                type="checkbox"
                id="u3"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.SSHJ==='是'?'checked':''"
              />
              <label for="u3">合格</label>

              <input
                type="checkbox"
                id="u4"
                value="否"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.SSHJ==='否'?'checked':''"
              />
              <label for="u4">不合格</label>
            </div>
          </div>
        </div>
      </div>

      <div class="InfoColumn">
        <div class="InfoNoTopBorder">
          <div class="InfoColumnTitle">四 术中护理</div>
          <div class="InfoKey">
            <div class="no-print">
              1、预防低体温：
              <el-checkbox
                label="室温22-24℃"
                true-label="是"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.YFDTW_SW"
              ></el-checkbox>
              <el-checkbox
                label="保温毯"
                true-label="是"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.YFDTW_BWT"
              ></el-checkbox>
              <el-checkbox
                label="温盐水"
                true-label="是"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.YFDTW_WYS"
              ></el-checkbox>
              <el-checkbox
                label="及时加盖非手术区"
                true-label="是"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.YFDTW_JSJG"
              ></el-checkbox>
            </div>
            <div class="show-print">
              1、预防低体温：
              <input
                type="checkbox"
                id="u1"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.YFDTW_SW==='是'?'checked':''"
              />
              <label for="u1">室温22-24℃</label>

              <input
                type="checkbox"
                id="u2"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.YFDTW_BWT==='是'?'checked':''"
              />
              <label for="u2">保温毯</label>

              <input
                type="checkbox"
                id="u3"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.YFDTW_WYS==='是'?'checked':''"
              />
              <label for="u3">温盐水</label>

              <input
                type="checkbox"
                id="u4"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.YFDTW_JSJG==='是'?'checked':''"
              />
              <label for="u4">及时加盖非手术区</label>
            </div>
          </div>
        </div>

        <div class="InfoNoTopBorder" style="margin-left:5px;">
          <div class="InfoValue">2、体位</div>
          <div class="InfoKey" style="margin-top:-5px; margin-left:5px;width:100px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_OPERATION_MASTER.OPER_POSITION"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_OPERATION_MASTER.OPER_POSITION}}</div>
          </div>
          <div class="InfoKey" style="margin-left:5px;">
            <div class="no-print">
              <el-checkbox
                label="使用啫喱垫"
                true-label="是"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.SYZLD"
              ></el-checkbox>
              <el-checkbox
                label="眼贴"
                true-label="是"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.YT"
              ></el-checkbox>&nbsp;更换体位：
              <el-checkbox
                label="无"
                true-label="无"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.GHTW_STATUS"
              ></el-checkbox>
              <el-checkbox
                label="有"
                true-label="有"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.GHTW_STATUS"
              ></el-checkbox>&nbsp;更换时间：
            </div>
            <div class="show-print">
              <input
                type="checkbox"
                id="u1"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.SYZLD==='是'?'checked':''"
              />
              <label for="u1">使用啫喱垫</label>

              <input
                type="checkbox"
                id="u1"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.YT==='是'?'checked':''"
              />
              <label for="u1">眼贴</label>
              &nbsp;更换体位：
              <input
                type="checkbox"
                id="u1"
                value="无"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.GHTW_STATUS==='无'?'checked':''"
              />
              <label for="u1">无</label>

              <input
                type="checkbox"
                id="u1"
                value="有"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.GHTW_STATUS==='有'?'checked':''"
              />
              <label for="u1">有</label>
              &nbsp;更换时间：
            </div>
          </div>
          <div class="InfoKey" style="margin-top:-5px; margin-left:-10px;width:80px;">
            <div class="no-print">
              <div class="el-date-picker">
                <el-date-picker
                  style="width:80px;margin-top:0px;"
                  type="datetime"
                  clearable
                  format="HH:mm"
                  default-time="08:00"
                  placeholder="更换时间"
                  v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.GHTW_DATE"
                  id="inDate"
                ></el-date-picker>
              </div>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:5px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_YWASSESS.GHTW_DATE | formatDate('HH:mm')}}</div>
          </div>
          <div class="InfoValue">更换方式：</div>
          <div class="InfoKey" style="margin-top:-5px; margin-left:0px;width:80px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.GHTW_FS"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:5px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_YWASSESS.GHTW_FS}}</div>
          </div>
        </div>

        <div class="InfoNoTopBorder" style="margin-left:5px;">
          <div class="InfoValue">3、电刀使用：</div>
          <div class="InfoKey" style="margin-left:5px;">
            <div class="no-print">
              <el-checkbox
                label="无"
                true-label="无"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.DDSY"
              ></el-checkbox>
              <el-checkbox
                label="有"
                true-label="有"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.DDSY"
              ></el-checkbox>
            </div>
            <div class="show-print">
              <input
                type="checkbox"
                id="u1"
                value="无"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.DDSY==='无'?'checked':''"
              />
              <label for="u1">无</label>

              <input
                type="checkbox"
                id="u2"
                value="有"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.DDSY==='有'?'checked':''"
              />
              <label for="u2">有</label>
            </div>
          </div>
          <div class="InfoValue">负极板黏贴位置：</div>
          <div class="InfoKey" style="margin-top:-5px; margin-left:5px;width:100px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.FJBZTWZ"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_YWASSESS.FJBZTWZ}}</div>
          </div>

          <div class="InfoValue">局部皮肤情况：</div>
          <div class="InfoKey" style="margin-top:-5px; margin-left:5px;width:100px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.JBPFQK"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_YWASSESS.JBPFQK}}</div>
          </div>
        </div>

        <div class="InfoNoTopBorder" style="margin-left:5px;">
          <div class="InfoValue">4、气压止血带使用：</div>
          <div class="InfoKey" style="margin-left:5px;">
            <div class="no-print">
              <el-checkbox
                label="无"
                true-label="无"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.QYZXD_STATUS"
              ></el-checkbox>
              <el-checkbox
                label="有"
                true-label="有"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.QYZXD_STATUS"
              ></el-checkbox>
            </div>
            <div class="show-print">
              <input
                type="checkbox"
                id="u1"
                value="无"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.QYZXD_STATUS==='无'?'checked':''"
              />
              <label for="u1">无</label>

              <input
                type="checkbox"
                id="u2"
                value="有"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.QYZXD_STATUS==='有'?'checked':''"
              />
              <label for="u2">有</label>
            </div>
          </div>
          <div class="InfoValue">绑扎位置：</div>
          <div class="InfoKey" style="margin-top:-5px; margin-left:5px;width:50px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.QYZXD_BZWZ"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_YWASSESS.QYZXD_BZWZ}}</div>
          </div>
          <div class="InfoValue">压力</div>
          <div class="InfoKey" style="margin-top:-5px; margin-left:5px;width:50px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.QYZXD_YL"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_YWASSESS.QYZXD_YL}}</div>
          </div>
          <div class="InfoValue">绑扎时间：</div>
          <div class="InfoKey" style="margin-top:-5px; margin-left:-10px;width:50px;">
            <div class="no-print">
              <div class="el-date-picker">
                <el-date-picker
                  style="width:50px;margin-top:0px;"
                  type="datetime"
                  clearable
                  format="HH:mm"
                  default-time="08:00"
                  placeholder="绑扎时间"
                  v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.QYZXD_DATE"
                  id="inDate"
                ></el-date-picker>
              </div>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:5px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_YWASSESS.QYZXD_DATE | formatDate('HH:mm')}}</div>
          </div>

          <div class="InfoValue">放松时间：</div>
          <div class="InfoKey" style="margin-top:-5px; margin-left:-10px;width:50px;">
            <div class="no-print">
              <div class="el-date-picker">
                <el-date-picker
                  style="width:50px;margin-top:0px;"
                  type="datetime"
                  clearable
                  format="HH:mm"
                  default-time="08:00"
                  placeholder="放松时间"
                  v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.QYZXD_SBDATE"
                  id="inDate"
                ></el-date-picker>
              </div>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:5px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_YWASSESS.QYZXD_SBDATE | formatDate('HH:mm')}}</div>
          </div>

          <div class="InfoValue">局部皮肤：</div>
          <div class="InfoKey" style="margin-top:-5px; margin-left:0px;width:50px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.QYZXD_JBPF"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:5px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_YWASSESS.QYZXD_JBPF}}</div>
          </div>
        </div>

        <div class="InfoNoTopBorder" style="margin-left:5px;">
          <div class="InfoValue">5、</div>
          <div class="InfoKey" style="margin-left:5px;">
            <div class="no-print">
              <el-checkbox
                label="术中冰冻"
                true-label="是"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.SZBD"
              ></el-checkbox>
              <el-checkbox
                label="病历标本"
                true-label="是"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.BLBB"
              ></el-checkbox>
            </div>
            <div class="show-print">
              <input
                type="checkbox"
                id="u1"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.SZBD==='是'?'checked':''"
              />
              <label for="u1">术中冰冻</label>

              <input
                type="checkbox"
                id="u2"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.BLBB==='是'?'checked':''"
              />
              <label for="u2">病历标本</label>
            </div>
          </div>
        </div>

        <div class="InfoNoTopBorder" style="margin-left:5px;">
          <div class="InfoValue">6、术中观察巡视项目（手术时间1小时内无需填写）</div>
        </div>
        <div class="InfoNoTopBorder">
          <div class="TableBase" id="tdCenter">
            <table cellspacing="0" cellpadding="0" style="width:880px">
              <tr>
                <td>时间</td>
                <td>静脉输液</td>
                <td>皮肤颜色（面部、耳廊、眼、四肢、其他____）</td>
                <td>肢体位置</td>
                <td>负极板</td>
                <td>仪器设置</td>
                <td>签名</td>
              </tr>
              <tr v-for="item in MedicalBasicDoc.MED_NURSING_TOUR" :key="item.ITEM_NO">
                <td>
                  <div class="no-print">
                    <div class="el-date-picker" style="width:60px;">
                      <el-date-picker
                        style="width:50px;margin-top:0px;"
                        type="datetime"
                        clearable
                        format="HH:mm"
                        default-time="08:00"
                        placeholder="时间"
                        v-model="item.TIME_POINT"
                        id="inDate"
                      ></el-date-picker>
                    </div>
                  </div>
                  <div
                    class="show-print"
                    style="margin-top:10px;margin-left:5px;width:60px;"
                  >{{item.TIME_POINT | formatDate('HH:mm')}}</div>
                </td>
                <td>
                  <div class="InfoKey" style="margin-left:5px;text-align:left;width:140px;">
                    <div class="no-print">
                      <el-checkbox label="外渗" true-label="外渗" false-label v-model="item.JMSY"></el-checkbox>
                      <el-checkbox label="畅通畅" true-label="畅通畅" false-label v-model="item.JMSY"></el-checkbox>
                    </div>
                    <div class="show-print">
                      <input
                        type="checkbox"
                        id="u2"
                        value="外渗"
                        :checked="item.JMSY==='外渗'?'checked':''"
                      />
                      <label for="u2">外渗</label>
                      <input
                        type="checkbox"
                        id="u1"
                        value="畅通畅"
                        :checked="item.JMSY==='畅通畅'?'checked':''"
                      />
                      <label for="u1">畅通畅</label>
                    </div>
                  </div>
                </td>
                <td>
                  <div class="InfoKey" style="margin-left:5px;">
                    <div class="no-print">
                      <el-checkbox label="正常" true-label="正常" false-label v-model="item.PFYS"></el-checkbox>
                      <el-checkbox label="发红" true-label="发红" false-label v-model="item.PFYS"></el-checkbox>
                      <el-checkbox label="水泡" true-label="水泡" false-label v-model="item.PFYS"></el-checkbox>
                    </div>
                    <div class="show-print">
                      <input
                        type="checkbox"
                        id="u1"
                        value="正常"
                        :checked="item.PFYS==='正常'?'checked':''"
                      />
                      <label for="u1">正常</label>

                      <input
                        type="checkbox"
                        id="u2"
                        value="发红"
                        :checked="item.PFYS==='发红'?'checked':''"
                      />
                      <label for="u2">发红</label>

                      <input
                        type="checkbox"
                        id="u2"
                        value="水泡"
                        :checked="item.PFYS==='水泡'?'checked':''"
                      />
                      <label for="u2">水泡</label>
                    </div>
                  </div>
                </td>
                <td>
                  <div class="InfoKey" style="margin-left:5px;text-align:left;width:170px;">
                    <div class="no-print">
                      <el-checkbox label="无受压" true-label="无受压" false-label v-model="item.ZTWZ"></el-checkbox>
                      <el-checkbox label="可能受压" true-label="可能受压" false-label v-model="item.ZTWZ"></el-checkbox>
                    </div>
                    <div class="show-print">
                      <input
                        type="checkbox"
                        id="u1"
                        value="无受压"
                        :checked="item.ZTWZ==='无受压'?'checked':''"
                      />
                      <label for="u1">无受压</label>
                      <input
                        type="checkbox"
                        id="u2"
                        value="可能受压"
                        :checked="item.ZTWZ==='可能受压'?'checked':''"
                      />
                      <label for="u2">可能受压</label>
                    </div>
                  </div>
                </td>
                <td>
                  <div class="InfoKey" style="margin-left:5px;width:80px;text-align:center;">
                    <div class="no-print">
                      <el-checkbox label="无移位" true-label="是" false-label v-model="item.FJB"></el-checkbox>
                    </div>
                    <div class="show-print">
                      <input
                        type="checkbox"
                        id="u1"
                        value="是"
                        :checked="item.FJB==='是'?'checked':''"
                      />
                      <label for="u1">无移位</label>
                    </div>
                  </div>
                </td>
                <td>
                  <div class="InfoKey" style="margin-left:5px;width:85px;">
                    <div class="no-print">
                      <el-checkbox label="功能正常" true-label="是" false-label v-model="item.YQSB"></el-checkbox>
                    </div>
                    <div class="show-print">
                      <input
                        type="checkbox"
                        id="u1"
                        value="是"
                        :checked="item.YQSB==='是'?'checked':''"
                      />
                      <label for="u1">功能正常</label>
                    </div>
                  </div>
                </td>
                <td>
                  <div
                    class="InfoValue"
                    style="margin-top:-5px; margin-left:0px;width:70px;text-align:center;"
                  >
                    <div class="no-print">
                      <MedSelect
                        type="NurseDict"
                        style="width:60px;margin-top:3px;"
                        :remote="true"
                        :filterable="true"
                        placeholder="签名"
                        v-model="item.NURSE"
                        clearable
                        @GetDiaplayValue="GetTableDiaplayValue"
                      ></MedSelect>
                    </div>
                    <div
                      class="show-print"
                      style="margin-top:10px;margin-left:0px;"
                    >{{item.NURSE_NAME}}</div>
                  </div>
                </td>
              </tr>
            </table>
          </div>
        </div>
      </div>

      <div class="InfoColumn" style="border-top:0px;margin-top:5px;">
        <div class="InfoNoTopBorder">
          <div class="InfoColumnTitle">五 巡回护士交接班内容</div>
          <div class="InfoKey" style="margin-left:20px;">
            <div class="no-print">
              <el-checkbox
                label="无"
                true-label="无"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.XHHSJB_STATUS"
              ></el-checkbox>不需填
              <el-checkbox
                label="有"
                true-label="有"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.XHHSJB_STATUS"
              ></el-checkbox>除上述巡视内容，另交接1、手术名称、负极板粘贴位置、体位
            </div>
            <div class="show-print">
              <input
                type="checkbox"
                id="u1"
                value="无"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.XHHSJB_STATUS==='无'?'checked':''"
              />
              <label for="u1">无</label>
              不需填
              <input
                type="checkbox"
                id="u2"
                value="有"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.XHHSJB_STATUS==='有'?'checked':''"
              />
              <label for="u2">有</label>
              除上述巡视内容，另交接1、手术名称、负极板粘贴位置、体位
            </div>
          </div>
        </div>
        <div class="InfoNoTopBorder">
          <div class="InfoKey">2、输液部位：上肢</div>
          <div class="InfoKey">
            <div class="no-print">
              <el-checkbox
                label="左"
                true-label="左"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.SYBW_SZ"
              ></el-checkbox>
              <el-checkbox
                label="右"
                true-label="右"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.SYBW_SZ"
              ></el-checkbox>
            </div>
            <div class="show-print">
              <input
                type="checkbox"
                id="u1"
                value="左"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.SYBW_SZ==='左'?'checked':''"
              />
              <label for="u1">左</label>

              <input
                type="checkbox"
                id="u2"
                value="右"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.SYBW_SZ==='右'?'checked':''"
              />
              <label for="u2">右</label>
            </div>
          </div>
          <div class="InfoKey">
            <div class="no-print">
              下肢
              <el-checkbox
                label="左"
                true-label="左"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.SYBW_XZ"
              ></el-checkbox>
              <el-checkbox
                label="右"
                true-label="右"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.SYBW_XZ"
              ></el-checkbox>
              <el-checkbox
                label="锁骨下"
                true-label="是"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.SYBW_SGX"
              ></el-checkbox>
              <el-checkbox
                label="颈内"
                true-label="是"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.SYBW_JN"
              ></el-checkbox>
            </div>
            <div class="show-print">
              下肢
              <input
                type="checkbox"
                id="u1"
                value="左"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.SYBW_XZ==='左'?'checked':''"
              />
              <label for="u1">左</label>

              <input
                type="checkbox"
                id="u2"
                value="右"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.SYBW_XZ==='右'?'checked':''"
              />
              <label for="u2">右</label>

              <input
                type="checkbox"
                id="u3"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.SYBW_SGX==='是'?'checked':''"
              />
              <label for="u3">锁骨下</label>

              <input
                type="checkbox"
                id="u4"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.SYBW_JN==='是'?'checked':''"
              />
              <label for="u4">颈内</label>
            </div>
          </div>
          <div class="InfoKey">3、病人带来的物品：</div>
          <div class="InfoKey">
            <div class="no-print">
              <el-checkbox
                label="X光片"
                true-label="是"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.BRDLW_X"
              ></el-checkbox>药物:
              <el-checkbox
                label="已用"
                true-label="已用"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.BRDLW_YW"
              ></el-checkbox>
            </div>
            <div class="show-print">
              <input
                type="checkbox"
                id="u1"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.BRDLW_X==='是'?'checked':''"
              />
              <label for="u1">X光片</label>
              药物:
              <input
                type="checkbox"
                id="u2"
                value="已用"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.BRDLW_YW==='已用'?'checked':''"
              />
              <label for="u2">已用</label>
            </div>
          </div>
        </div>
        <div class="InfoNoTopBorder">
          <div class="InfoKey">
            <div class="no-print">
              <el-checkbox
                label="未用"
                true-label="未用"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.BRDLW_YW"
              ></el-checkbox>
            </div>
            <div class="show-print">
              <input
                type="checkbox"
                id="u3"
                value="未用"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.BRDLW_YW==='未用'?'checked':''"
              />
              <label for="u3">未用</label>
            </div>
          </div>
          <div class="InfoKey">4、剩余血制品</div>
          <div class="InfoValue" style="margin-top:-5px; margin-left:0px;width:30px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.SYXZP"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_YWASSESS.SYXZP}}</div>
          </div>
          <div class="InfoKey">ml，正在申请领用的制品</div>
          <div class="InfoValue" style="margin-top:-5px; margin-left:0px;width:50px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.ZZSQLYZP"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_YWASSESS.ZZSQLYZP}}</div>
          </div>
          <div class="InfoKey" style="width:10px;">5、</div>
          <div class="InfoKey">
            <div class="no-print">
              <el-checkbox
                label="手术台上物品及数量交接"
                true-label="是"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.SSTWPSL"
              ></el-checkbox>
            </div>
            <div class="show-print">
              <input
                type="checkbox"
                id="u1"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.SSTWPSL==='是'?'checked':''"
              />
              <label for="u1">手术台上物品及数量交接</label>
            </div>
          </div>
          <div class="InfoKey" style="width:10px;">6、</div>
          <div class="InfoKey">
            <div class="no-print">
              <el-checkbox
                label="高值或特殊耗材交接"
                true-label="是"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_YWASSESS.GZTSHC"
              ></el-checkbox>
            </div>
            <div class="show-print">
              <input
                type="checkbox"
                id="u1"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_YWASSESS.GZTSHC==='是'?'checked':''"
              />
              <label for="u1">高值或特殊耗材交接</label>
            </div>
          </div>
        </div>
      </div>

      <div
        class="InfoColumn"
        style="margin-top:5px;border-left:1px solid #FFFFFF;margin-left:-1px;border-right:1px solid #FFFFFF;margin-right:-1px; height:60px;"
      ></div>

      <div class="InfoColumn" style="margin-top:-1px;">
        <div class="InfoNoTopBorder">
          <div class="InfoColumnTitle">六 术中物品清点</div>
        </div>
        <div class="InfoNoTopBorder">
          <div class="TableBase" id="tdCenter">
            <table cellspacing="0" cellpadding="0" style="width:880px">
              <tr>
                <td rowspan="2">物品名称</td>
                <td colspan="4">核对数目</td>
                <td rowspan="2">物品名称</td>
                <td colspan="4">核对数目</td>
              </tr>
              <tr>
                <td>手术前</td>
                <td>关体腔前</td>
                <td>关体腔后</td>
                <td>缝皮后</td>
                <td>手术前</td>
                <td>关体腔前</td>
                <td>关体腔后</td>
                <td>缝皮后</td>
              </tr>

              <!--循环创建行-->
              <tr v-for="item in MedicalBasicDoc.MED_NURSING_QINGDIAN" :key="item.ITEM_NO">
                <td>
                  <div style="width:120px;">{{item.ITEM_NAME1}}</div>
                </td>
                <td>
                  <div>
                    <div class="no-print">
                      <el-input v-model="item.SSQ1"></el-input>
                    </div>
                    <div class="show-print">{{item.SSQ1}}</div>
                  </div>
                </td>

                <td>
                  <div class="no-print">
                    <el-input v-model="item.GTQQ1"></el-input>
                  </div>
                  <div class="show-print">{{item.GTQQ1}}</div>
                </td>

                <td>
                  <div class="no-print">
                    <el-input v-model="item.GTQH1"></el-input>
                  </div>
                  <div class="show-print">{{item.GTQH1}}</div>
                </td>

                <td>
                  <div class="no-print">
                    <el-input v-model="item.FPH1"></el-input>
                  </div>
                  <div class="show-print">{{item.FPH1}}</div>
                </td>

                <td>
                  <div style="width:120px;">{{item.ITEM_NAME2}}</div>
                </td>
                <td>
                  <div class="no-print">
                    <el-input v-model="item.SSQ2"></el-input>
                  </div>
                  <div class="show-print">{{item.SSQ2}}</div>
                </td>

                <td>
                  <div class="no-print">
                    <el-input v-model="item.GTQQ2"></el-input>
                  </div>
                  <div class="show-print">{{item.GTQQ2}}</div>
                </td>

                <td>
                  <div class="no-print">
                    <el-input v-model="item.GTQH2"></el-input>
                  </div>
                  <div class="show-print">{{item.GTQH2}}</div>
                </td>

                <td>
                  <div class="no-print">
                    <el-input v-model="item.FPH2"></el-input>
                  </div>
                  <div class="show-print">{{item.FPH2}}</div>
                </td>
              </tr>

              <tr>
                <td>备注</td>
                <td colspan="9">
                  <div class="no-print">
                    <el-input placeholder="备注" v-model="MedicalBasicDoc.MED_NURSING_QDNURSE.COMMEN"></el-input>
                  </div>
                  <div
                    class="show-print"
                    style="margin-top:10px;margin-left:10px;"
                  >{{MedicalBasicDoc.MED_NURSING_QDNURSE.COMMEN}}</div>
                </td>
              </tr>
            </table>

            <!-- <div class="xiexian" style="width:100px;height:100px;"></div> -->
            <table cellspacing="0" cellpadding="0" style="width:880px" class="TableBase">
              <tr>
                <td rowspan="2">
                  <div class="xiexian" style="width:100px;">
                    <div style="text-align:right;">项目</div>
                    <div style="text-align:left;">责任人</div>
                  </div>
                </td>
                <td rowspan="2">术前清点</td>
                <td rowspan="2">关体腔前</td>
                <td rowspan="2">关体腔后</td>
                <td colspan="2">交接班</td>
              </tr>
              <tr>
                <td>接班者</td>
                <td>交接时间</td>
              </tr>
              <tr>
                <td style="width:100px;">器械护士</td>
                <td>
                  <div class="no-print">
                    <MedSelect
                      type="NurseDictInOperRoom"
                      style="width:100px;margin-top:3px;"
                      :remote="true"
                      :filterable="true"
                      placeholder="器械护士"
                      v-model="MedicalBasicDoc.MED_NURSING_QDNURSE.QX_SQQD"
                      clearable
                      @GetDiaplayValue="GetDiaplayValue"
                    ></MedSelect>
                  </div>
                  <div
                    class="show-print"
                    style="margin-left:0px;margin-top:0px;"
                  >{{QX_SQQD_DISPLAY}}</div>
                </td>
                <td>
                  <div class="no-print">
                    <MedSelect
                      type="NurseDictInOperRoom"
                      style="width:100px;margin-top:3px;"
                      :remote="true"
                      :filterable="true"
                      placeholder="器械护士"
                      v-model="MedicalBasicDoc.MED_NURSING_QDNURSE.QX_GTQQ"
                      clearable
                      @GetDiaplayValue="GetDiaplayValue"
                    ></MedSelect>
                  </div>
                  <div class="show-print" style="margin-left:0px;">{{QX_GTQQ_DISPLAY}}</div>
                </td>
                <td>
                  <div class="no-print">
                    <MedSelect
                      type="NurseDictInOperRoom"
                      style="width:100px;margin-top:3px;"
                      :remote="true"
                      :filterable="true"
                      placeholder="器械护士"
                      v-model="MedicalBasicDoc.MED_NURSING_QDNURSE.QX_GTQH"
                      clearable
                      @GetDiaplayValue="GetDiaplayValue"
                    ></MedSelect>
                  </div>
                  <div class="show-print" style="margin-left:0px;">{{QX_GTQH_DISPLAY}}</div>
                </td>
                <td>
                  <div class="no-print">
                    <MedSelect
                      type="NurseDictInOperRoom"
                      style="width:100px;margin-top:3px;"
                      :remote="true"
                      :filterable="true"
                      placeholder="交班者"
                      v-model="MedicalBasicDoc.MED_NURSING_QDNURSE.QX_JB_NURSE"
                      clearable
                      @GetDiaplayValue="GetDiaplayValue"
                    ></MedSelect>
                  </div>
                  <div class="show-print" style="margin-left:0px;">{{QX_JB_NURSE_DISPLAY}}</div>
                </td>
                <td>
                  <div class="no-print">
                    <el-date-picker
                      style="width:200px;"
                      type="datetime"
                      clearable
                      placeholder="交接时间"
                      v-model="MedicalBasicDoc.MED_NURSING_QDNURSE.QX_JB_DATE"
                      id="inDate"
                    ></el-date-picker>
                  </div>
                  <div
                    class="show-print"
                    style="text-align:center;"
                  >{{MedicalBasicDoc.MED_NURSING_QDNURSE.QX_JB_DATE | formatDate('YYYY-MM-DD HH:mm:ss')}}</div>
                </td>
              </tr>

              <tr>
                <td style="width:100px;">巡回护士</td>
                <td>
                  <div class="no-print">
                    <MedSelect
                      type="NurseDictInOperRoom"
                      style="width:100px;margin-top:3px;"
                      :remote="true"
                      :filterable="true"
                      placeholder="巡回护士"
                      v-model="MedicalBasicDoc.MED_NURSING_QDNURSE.XH_SQQD"
                      clearable
                      @GetDiaplayValue="GetDiaplayValue"
                    ></MedSelect>
                  </div>
                  <div class="show-print" style="margin-left:0px;">{{XH_SQQD_DISPLAY}}</div>
                </td>
                <td>
                  <div class="no-print">
                    <MedSelect
                      type="NurseDictInOperRoom"
                      style="width:100px;margin-top:3px;"
                      :remote="true"
                      :filterable="true"
                      placeholder="巡回护士"
                      v-model="MedicalBasicDoc.MED_NURSING_QDNURSE.XH_GTQQ"
                      clearable
                      @GetDiaplayValue="GetDiaplayValue"
                    ></MedSelect>
                  </div>
                  <div class="show-print" style="margin-left:0px;">{{XH_GTQQ_DISPLAY}}</div>
                </td>
                <td>
                  <div class="no-print">
                    <MedSelect
                      type="NurseDictInOperRoom"
                      style="width:100px;margin-top:3px;"
                      :remote="true"
                      :filterable="true"
                      placeholder="巡回护士"
                      v-model="MedicalBasicDoc.MED_NURSING_QDNURSE.XH_GTQH"
                      clearable
                      @GetDiaplayValue="GetDiaplayValue"
                    ></MedSelect>
                  </div>
                  <div class="show-print" style="margin-left:0px;">{{XH_GTQH_DISPLAY}}</div>
                </td>
                <td>
                  <div class="no-print">
                    <MedSelect
                      type="NurseDictInOperRoom"
                      style="width:100px;margin-top:3px;"
                      :remote="true"
                      :filterable="true"
                      placeholder="接班者"
                      v-model="MedicalBasicDoc.MED_NURSING_QDNURSE.XH_JB_NURSE"
                      clearable
                      @GetDiaplayValue="GetDiaplayValue"
                    ></MedSelect>
                  </div>
                  <div class="show-print" style="margin-left:0px;">{{XH_JB_NURSE_DISPLAY}}</div>
                </td>
                <td>
                  <div class="no-print">
                    <!-- <div class="el-date-picker"> -->
                    <el-date-picker
                      style="width:200px;"
                      type="datetime"
                      clearable
                      placeholder="交接时间"
                      v-model="MedicalBasicDoc.MED_NURSING_QDNURSE.XH_JB_DATE"
                      id="inDate"
                    ></el-date-picker>
                    <!-- </div> -->
                  </div>
                  <div
                    class="show-print"
                    style="text-align:center;"
                  >{{MedicalBasicDoc.MED_NURSING_QDNURSE.XH_JB_DATE | formatDate('YYYY-MM-DD HH:mm:ss')}}</div>
                </td>
              </tr>
            </table>
          </div>
        </div>
      </div>

      <div class="InfoColumn" style="border-top:0px;margin-top:5px;">
        <div class="InfoNoTopBorder">
          <div class="InfoColumnTitle">七 术后记录</div>
        </div>
        <div class="InfoNoTopBorder">
          <div class="InfoKey">1、返回：</div>
          <div class="InfoKey">
            <div class="no-print">
              <el-checkbox
                label="病房"
                true-label="60"
                false-label
                v-model="OUT_OPER_WHEREABORTS_DISPLAY"
              ></el-checkbox>
              <el-checkbox
                label="ICU"
                true-label="65"
                false-label
                v-model="OUT_OPER_WHEREABORTS_DISPLAY"
              ></el-checkbox>
              <el-checkbox
                label="PACU"
                true-label="40"
                false-label
                v-model="OUT_OPER_WHEREABORTS_DISPLAY"
              ></el-checkbox>&nbsp;&nbsp;意识：
              <el-checkbox
                label="未醒"
                true-label="未醒"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_AFTER.YS"
              ></el-checkbox>
              <el-checkbox
                label="初醒"
                true-label="初醒"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_AFTER.YS"
              ></el-checkbox>
              <el-checkbox
                label="清醒"
                true-label="清醒"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_AFTER.YS"
              ></el-checkbox>&nbsp;&nbsp;气管插管：
              <el-checkbox
                label="有"
                true-label="有"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_AFTER.QGCG"
              ></el-checkbox>
              <el-checkbox
                label="无"
                true-label="无"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_AFTER.QGCG"
              ></el-checkbox>
            </div>
            <div class="show-print">
              <input
                type="checkbox"
                id="u1"
                value="是"
                :checked="MedicalBasicDoc.MED_OPERATION_MASTER.OUT_OPER_WHEREABORTS===60?'checked':''"
              />
              <label for="u1">病房</label>

              <input
                type="checkbox"
                id="u2"
                value="是"
                :checked="MedicalBasicDoc.MED_OPERATION_MASTER.OUT_OPER_WHEREABORTS===65?'checked':''"
              />
              <label for="u2">ICU</label>

              <input
                type="checkbox"
                id="u3"
                value="是"
                :checked="MedicalBasicDoc.MED_OPERATION_MASTER.OUT_OPER_WHEREABORTS===40?'checked':''"
              />
              <label for="u3">PACU</label>
              意识：
              <input
                type="checkbox"
                id="u4"
                value="未醒"
                :checked="MedicalBasicDoc.MED_NURSING_AFTER.YS==='未醒'?'checked':''"
              />
              <label for="u4">未醒</label>

              <input
                type="checkbox"
                id="u5"
                value="初醒"
                :checked="MedicalBasicDoc.MED_NURSING_AFTER.YS==='初醒'?'checked':''"
              />
              <label for="u5">初醒</label>

              <input
                type="checkbox"
                id="u6"
                value="清醒"
                :checked="MedicalBasicDoc.MED_NURSING_AFTER.YS==='清醒'?'checked':''"
              />
              <label for="u6">清醒</label>
              气管插管：
              <input
                type="checkbox"
                id="u7"
                value="有"
                :checked="MedicalBasicDoc.MED_NURSING_AFTER.QGCG==='有'?'checked':''"
              />
              <label for="u7">有</label>

              <input
                type="checkbox"
                id="u8"
                value="无"
                :checked="MedicalBasicDoc.MED_NURSING_AFTER.QGCG==='无'?'checked':''"
              />
              <label for="u8">无</label>
            </div>
          </div>
        </div>
        <div class="InfoNoTopBorder">
          <div class="InfoKey">2、血压</div>
          <div class="InfoValue" style="margin-top:-5px; margin-left:5px;width:100px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_AFTER.XY"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_AFTER.XY}}</div>
          </div>
          <div class="InfoKey">mmHg 脉搏</div>
          <div class="InfoValue" style="margin-top:-5px; margin-left:5px;width:100px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_AFTER.MB"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_AFTER.MB}}</div>
          </div>
          <div class="InfoKey">次/分 呼吸</div>
          <div class="InfoValue" style="margin-top:-5px; margin-left:5px;width:100px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_AFTER.HX"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_AFTER.HX}}</div>
          </div>
          <div class="InfoKey">次/分</div>
        </div>
        <div class="InfoNoTopBorder">
          <div class="InfoKey">3、皮肤情况：</div>
          <div class="InfoKey">
            <div class="no-print">
              <el-checkbox
                label="完好"
                true-label="完好"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_AFTER.PF"
              ></el-checkbox>
              <el-checkbox
                label="红肿"
                true-label="红肿"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_AFTER.PF"
              ></el-checkbox>
              <el-checkbox
                label="水泡"
                true-label="水泡"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_AFTER.PF"
              ></el-checkbox>
              <el-checkbox
                label="破损"
                true-label="破损"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_AFTER.PF"
              ></el-checkbox>其他
            </div>
            <div class="show-print">
              <input
                type="checkbox"
                id="u1"
                value="完好"
                :checked="MedicalBasicDoc.MED_NURSING_AFTER.PF==='完好'?'checked':''"
              />
              <label for="u1">完好</label>

              <input
                type="checkbox"
                id="u2"
                value="红肿"
                :checked="MedicalBasicDoc.MED_NURSING_AFTER.PF==='红肿'?'checked':''"
              />
              <label for="u2">红肿</label>

              <input
                type="checkbox"
                id="u3"
                value="水泡"
                :checked="MedicalBasicDoc.MED_NURSING_AFTER.PF==='水泡'?'checked':''"
              />
              <label for="u3">水泡</label>

              <input
                type="checkbox"
                id="u4"
                value="破损"
                :checked="MedicalBasicDoc.MED_NURSING_AFTER.PF==='破损'?'checked':''"
              />
              <label for="u4">破损</label>
              其他
            </div>
          </div>

          <div class="InfoValue" style="margin-top:-5px; margin-left:5px;width:100px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_AFTER.PF_OTHER"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_AFTER.PF_OTHER}}</div>
          </div>

          <div class="InfoKey">出血量</div>
          <div class="InfoValue" style="margin-top:-5px; margin-left:5px;width:100px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_AFTER.PF_CXL"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_AFTER.PF_CXL}}</div>
          </div>
          <div class="InfoKey">ml</div>
        </div>

        <div class="InfoNoTopBorder">
          <div class="InfoKey">4、引流管：</div>
          <div class="InfoKey" style="margin-left:0px;">
            <div class="no-print">
              <el-checkbox
                label="无"
                true-label="无"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_AFTER.YLG_STATUS"
              ></el-checkbox>
              <el-checkbox
                label="有"
                true-label="有"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_AFTER.YLG_STATUS"
              ></el-checkbox>:
              <el-checkbox
                label="胃管"
                true-label="是"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_AFTER.YLG_WG"
              ></el-checkbox>
              <el-checkbox
                label="尿管"
                true-label="是"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_AFTER.YLG_NG"
              ></el-checkbox>
              <el-checkbox
                label="胸引管"
                true-label="是"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_AFTER.YLG_XYG"
              ></el-checkbox>
              <el-checkbox
                label="腹腔引流管"
                true-label="是"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_AFTER.YLG_FQYLG"
              ></el-checkbox>
              <el-checkbox
                label="输液管"
                true-label="是"
                false-label
                v-model="MedicalBasicDoc.MED_NURSING_AFTER.YLG_SYG"
              ></el-checkbox>
            </div>
            <div class="show-print">
              <input
                type="checkbox"
                id="u1"
                value="无"
                :checked="MedicalBasicDoc.MED_NURSING_AFTER.YLG_STATUS==='无'?'checked':''"
              />
              <label for="u1">无</label>

              <input
                type="checkbox"
                id="u2"
                value="有"
                :checked="MedicalBasicDoc.MED_NURSING_AFTER.YLG_STATUS==='有'?'checked':''"
              />
              <label for="u2">有</label>

              <input
                type="checkbox"
                id="u3"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_AFTER.YLG_WG==='是'?'checked':''"
              />
              <label for="u3">胃管</label>

              <input
                type="checkbox"
                id="u4"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_AFTER.YLG_NG==='是'?'checked':''"
              />
              <label for="u4">尿管</label>

              <input
                type="checkbox"
                id="u5"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_AFTER.YLG_XYG==='是'?'checked':''"
              />
              <label for="u5">胸引管</label>

              <input
                type="checkbox"
                id="u6"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_AFTER.YLG_FQYLG==='是'?'checked':''"
              />
              <label for="u6">腹腔引流管</label>

              <input
                type="checkbox"
                id="u7"
                value="是"
                :checked="MedicalBasicDoc.MED_NURSING_AFTER.YLG_SYG==='是'?'checked':''"
              />
              <label for="u7">输液管</label>
            </div>
          </div>
        </div>
        <div class="InfoNoTopBorder">
          <div class="InfoKey" style="margin-left:30px;">其他：</div>
          <div class="InfoValue" style="margin-top:-5px; margin-left:5px;width:50px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_AFTER.YLG_OTHER"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_AFTER.YLG_OTHER}}</div>
          </div>

          <div class="InfoKey">总数量</div>
          <div class="InfoValue" style="margin-top:-5px; margin-left:5px;width:50px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_AFTER.YLG_COUNT"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_AFTER.YLG_COUNT}}</div>
          </div>
          <div class="InfoKey">条，尿量</div>
          <div class="InfoValue" style="margin-top:-5px; margin-left:5px;width:50px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_AFTER.YLG_NL"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_AFTER.YLG_NL}}</div>
          </div>
          <div class="InfoKey">ml</div>
        </div>

        <div class="InfoNoTopBorder">
          <div class="InfoKey">5、余液品种及量：外周</div>
          <div class="InfoValue" style="margin-top:-5px; margin-left:5px;width:50px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_AFTER.YY_WZ"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_AFTER.YY_WZ}}</div>
          </div>

          <div class="InfoKey">中心静脉</div>
          <div class="InfoValue" style="margin-top:-5px; margin-left:5px;width:50px;">
            <div class="no-print">
              <el-input v-model="MedicalBasicDoc.MED_NURSING_AFTER.YY_ZXJM"></el-input>
            </div>
            <div
              class="show-print"
              style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_AFTER.YY_ZXJM}}</div>
          </div>

          <div class="InfoKey">巡回护士</div>
          <div class="InfoValue">
            <div class="no-print">
              <MedSelect
                type="NurseDictInOperRoom"
                style="width:100px;margin-top:-13px;"
                :remote="true"
                :filterable="true"
                placeholder="巡回护士"
                v-model="MedicalBasicDoc.MED_NURSING_AFTER.NURSE"
                clearable
                @GetDiaplayValue="GetDiaplayValue"
              ></MedSelect>
            </div>
            <div
              class="show-print"
              style="width:100px;margin-top:0px;margin-left:0px;border-bottom:1px dashed;"
            >{{AFTER_NURSE_DISPLAY}}</div>
          </div>
          <div class="InfoKey">离室时间</div>
          <div class="InfoKey">
            <div class="no-print">
              <div class="el-date-picker" style="width:150px;">
                <el-date-picker
                  style="width:150px;margin-top:-13px;"
                  type="datetime"
                  clearable
                  placeholder="离室时间"
                  v-model="MedicalBasicDoc.MED_NURSING_AFTER.OUT_DATE"
                  id="inDate"
                ></el-date-picker>
              </div>
            </div>
            <div
              class="show-print"
              style="margin-top:2px;text-align:center;border-bottom:1px dashed;"
            >{{MedicalBasicDoc.MED_NURSING_AFTER.OUT_DATE | formatDate('YYYY-MM-DD HH:mm:ss')}}</div>
          </div>
        </div>
      </div>

      <div class="Info">
        <div
          class="InfoColumn"
          style="border-top:0px;width:440px;border-right:1px solid;margin-top:0px;"
        >
          <div class="InfoColumn" style="border-top:0px;margin-top:0px;">
            <div class="InfoNoTopBorder">
              <div class="InfoColumnTitle">八 与</div>
              <div class="InfoKey" style="weight:600;">
                <div class="no-print">
                  <el-checkbox
                    label="复苏室护士"
                    true-label="复苏室护士"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.JBLX_NURSE"
                  ></el-checkbox>或
                  <el-checkbox
                    label="病区护士(含ICU)"
                    true-label="病区护士"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.JBLX_NURSE"
                  ></el-checkbox>交接记录
                </div>
                <div class="show-print">
                  <input
                    type="checkbox"
                    id="u1"
                    value="复苏室护士"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.JBLX_NURSE==='复苏室护士'?'checked':''"
                  />
                  <label for="u1">复苏室护士</label>
                  或
                  <input
                    type="checkbox"
                    id="u2"
                    value="病区护士"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.JBLX_NURSE==='病区护士'?'checked':''"
                  />
                  <label for="u2">病区护士(含ICU)</label>
                  交接记录
                </div>
              </div>
            </div>
            <div class="InfoNoTopBorder">
              <div class="InfoKey">1、口头交班项目：</div>
              <div class="InfoKey">
                <div class="no-print">
                  <el-checkbox
                    label="手术名称"
                    true-label="是"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.KTJB_SSMC"
                  ></el-checkbox>
                  <el-checkbox
                    label="手术部位"
                    true-label="是"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.KTJB_SSBW"
                  ></el-checkbox>
                  <el-checkbox
                    label="麻醉方式"
                    true-label="是"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.KTJB_MZFS"
                  ></el-checkbox>
                </div>
                <div class="show-print">
                  <input
                    type="checkbox"
                    id="u1"
                    value="是"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.KTJB_SSMC==='是'?'checked':''"
                  />
                  <label for="u1">手术名称</label>

                  <input
                    type="checkbox"
                    id="u2"
                    value="是"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.KTJB_SSBW==='是'?'checked':''"
                  />
                  <label for="u2">手术部位</label>

                  <input
                    type="checkbox"
                    id="u3"
                    value="是"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.KTJB_MZFS==='是'?'checked':''"
                  />
                  <label for="u3">麻醉方式</label>
                </div>
              </div>
            </div>
            <div class="InfoNoTopBorder">
              <div class="InfoKey">
                <div class="no-print">
                  <el-checkbox
                    label="手术体位"
                    true-label="是"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.KTJB_SSTW"
                  ></el-checkbox>
                  <el-checkbox
                    label="止血带"
                    true-label="是"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.KTJB_ZXD"
                  ></el-checkbox>
                  <el-checkbox
                    label="出血量(见记录单)"
                    true-label="是"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.KTJB_CXL"
                  ></el-checkbox>
                </div>
                <div class="show-print">
                  <input
                    type="checkbox"
                    id="u1"
                    value="是"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.KTJB_SSTW==='是'?'checked':''"
                  />
                  <label for="u1">手术体位</label>

                  <input
                    type="checkbox"
                    id="u2"
                    value="是"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.KTJB_ZXD==='是'?'checked':''"
                  />
                  <label for="u2">止血带</label>

                  <input
                    type="checkbox"
                    id="u3"
                    value="是"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.KTJB_CXL==='是'?'checked':''"
                  />
                  <label for="u3">出血量(见记录单)</label>
                </div>
              </div>
            </div>

            <div class="InfoNoTopBorder">
              <div class="InfoKey">2、皮肤情况：</div>
              <div class="InfoKey">
                <div class="no-print">
                  <el-checkbox
                    label="正常"
                    true-label="正常"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.PF_STATUS"
                  ></el-checkbox>
                  <el-checkbox
                    label="异常"
                    true-label="异常"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.PF_STATUS"
                  ></el-checkbox>
                </div>
                <div class="show-print">
                  <input
                    type="checkbox"
                    id="u1"
                    value="正常"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.PF_STATUS==='正常'?'checked':''"
                  />
                  <label for="u1">正常</label>

                  <input
                    type="checkbox"
                    id="u2"
                    value="异常"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.PF_STATUS==='异常'?'checked':''"
                  />
                  <label for="u2">异常</label>
                </div>
              </div>
              <div class="InfoValue" style="margin-top:-5px; margin-left:5px;width:50px;">
                <div class="no-print">
                  <el-input v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.PF_OTHER"></el-input>
                </div>
                <div
                  class="show-print"
                  style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
                >{{MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.PF_OTHER}}</div>
              </div>
              <div class="InfoKey">见术后记录各项</div>
            </div>

            <div class="InfoNoTopBorder">
              <div class="InfoKey">3、带回病区的用物：X光片：</div>
              <div class="InfoKey">
                <div class="no-print">
                  <el-checkbox
                    label="无"
                    true-label="无"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.DHBQYW_X"
                  ></el-checkbox>
                  <el-checkbox
                    label="有"
                    true-label="有"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.DHBQYW_X"
                  ></el-checkbox>
                </div>
                <div class="show-print">
                  <input
                    type="checkbox"
                    id="u1"
                    value="无"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.DHBQYW_X==='无'?'checked':''"
                  />
                  <label for="u1">无</label>

                  <input
                    type="checkbox"
                    id="u2"
                    value="有"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.DHBQYW_X==='有'?'checked':''"
                  />
                  <label for="u2">有</label>
                </div>
              </div>
              <div class="InfoValue" style="margin-top:-5px; margin-left:5px;width:50px;">
                <div class="no-print">
                  <el-input v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.DHBQYW_X_COUNT"></el-input>
                </div>
                <div
                  class="show-print"
                  style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
                >{{MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.DHBQYW_X_COUNT}}</div>
              </div>
              <div class="InfoKey">张</div>
            </div>
            <div class="InfoNoTopBorder">
              <div class="InfoKey">药物：</div>
              <div class="InfoKey">
                <div class="no-print">
                  <el-checkbox
                    label="无"
                    true-label="无"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.DHBQYW_YW"
                  ></el-checkbox>
                  <el-checkbox
                    label="有"
                    true-label="有"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.DHBQYW_YW"
                  ></el-checkbox>名称：
                </div>
                <div class="show-print">
                  <input
                    type="checkbox"
                    id="u1"
                    value="无"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.DHBQYW_YW==='无'?'checked':''"
                  />
                  <label for="u1">无</label>

                  <input
                    type="checkbox"
                    id="u2"
                    value="有"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.DHBQYW_YW==='有'?'checked':''"
                  />
                  <label for="u2">有</label>
                </div>
              </div>
              <div class="InfoValue" style="margin-top:-5px; margin-left:5px;width:50px;">
                <div class="no-print">
                  <el-input v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.DHBQYW_YW_NAME"></el-input>
                </div>
                <div
                  class="show-print"
                  style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
                >{{MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.DHBQYW_YW_NAME}}</div>
              </div>
              <div class="InfoKey">其他：</div>
              <div class="InfoValue" style="margin-top:-5px; margin-left:5px;width:50px;">
                <div class="no-print">
                  <el-input v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.DHBQYW_YW_OTHER"></el-input>
                </div>
                <div
                  class="show-print"
                  style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
                >{{MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.DHBQYW_YW_OTHER}}</div>
              </div>
            </div>

            <div class="InfoNoTopBorder">
              <div class="InfoKey">4、输液部位：上肢</div>
              <div class="InfoKey">
                <div class="no-print">
                  <el-checkbox
                    label="左"
                    true-label="左"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.SYBW_SZ"
                  ></el-checkbox>
                  <el-checkbox
                    label="右"
                    true-label="右"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.SYBW_SZ"
                  ></el-checkbox>
                </div>
                <div class="show-print">
                  <input
                    type="checkbox"
                    id="u1"
                    value="左"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.SYBW_SZ==='左'?'checked':''"
                  />
                  <label for="u1">左</label>

                  <input
                    type="checkbox"
                    id="u2"
                    value="右"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.SYBW_SZ==='右'?'checked':''"
                  />
                  <label for="u2">右</label>
                </div>
              </div>
              <div class="InfoKey">下肢</div>
              <div class="InfoKey">
                <div class="no-print">
                  <el-checkbox
                    label="左"
                    true-label="左"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.SYBW_XZ"
                  ></el-checkbox>
                  <el-checkbox
                    label="右"
                    true-label="右"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.SYBW_XZ"
                  ></el-checkbox>
                </div>
                <div class="show-print">
                  <input
                    type="checkbox"
                    id="u1"
                    value="左"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.SYBW_XZ==='左'?'checked':''"
                  />
                  <label for="u1">左</label>

                  <input
                    type="checkbox"
                    id="u2"
                    value="右"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.SYBW_XZ==='右'?'checked':''"
                  />
                  <label for="u2">右</label>
                </div>
              </div>
            </div>
            <div class="InfoNoTopBorder">
              <div class="InfoKey">
                <div class="no-print">
                  <el-checkbox
                    label="锁骨下"
                    true-label="是"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.SYBW_SGX"
                  ></el-checkbox>
                  <el-checkbox
                    label="颈内"
                    true-label="是"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.SYBW_JN"
                  ></el-checkbox>
                  <el-checkbox
                    label="其他"
                    true-label="是"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.SYBW_OTHER"
                  ></el-checkbox>
                </div>
                <div class="show-print">
                  <input
                    type="checkbox"
                    id="u1"
                    value="是"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.SYBW_SGX==='是'?'checked':''"
                  />
                  <label for="u1">锁骨下</label>

                  <input
                    type="checkbox"
                    id="u2"
                    value="是"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.SYBW_JN==='是'?'checked':''"
                  />
                  <label for="u2">颈内</label>

                  <input
                    type="checkbox"
                    id="u3"
                    value="是"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.SYBW_OTHER==='是'?'checked':''"
                  />
                  <label for="u3">其他</label>
                </div>
              </div>
            </div>

            <div class="InfoNoTopBorder">
              <div class="InfoKey">5、带回血制品：红细胞</div>
              <div class="InfoValue" style="margin-top:-5px; margin-left:5px;width:50px;">
                <div class="no-print">
                  <el-input v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.DHXZP_H"></el-input>
                </div>
                <div
                  class="show-print"
                  style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
                >{{MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.DHXZP_H}}</div>
              </div>
              <div class="InfoKey">μ 血浆</div>
              <div class="InfoValue" style="margin-top:-5px; margin-left:5px;width:50px;">
                <div class="no-print">
                  <el-input v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.DHXZP_X"></el-input>
                </div>
                <div
                  class="show-print"
                  style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
                >{{MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.DHXZP_X}}</div>
              </div>
              <div class="InfoKey">μ</div>
            </div>

            <div class="InfoNoTopBorder">
              <div class="InfoKey">6、留置尿管：</div>
              <div class="InfoKey">
                <div class="no-print">
                  <el-checkbox
                    label="无"
                    true-label="无"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.LZNG_STATUS"
                  ></el-checkbox>
                  <el-checkbox
                    label="有"
                    true-label="有"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.LZNG_STATUS"
                  ></el-checkbox>
                </div>
                <div class="show-print">
                  <input
                    type="checkbox"
                    id="u1"
                    value="无"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.LZNG_STATUS==='无'?'checked':''"
                  />
                  <label for="u1">无</label>

                  <input
                    type="checkbox"
                    id="u2"
                    value="有"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.LZNG_STATUS==='有'?'checked':''"
                  />
                  <label for="u2">有</label>
                </div>
              </div>
            </div>

            <div class="InfoNoTopBorder">
              <div class="InfoKey">7、病人体表及衣裤是否有污血：</div>
              <div class="InfoKey">
                <div class="no-print">
                  <el-checkbox
                    label="无"
                    true-label="无"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.WX"
                  ></el-checkbox>
                  <el-checkbox
                    label="有"
                    true-label="有"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.WX"
                  ></el-checkbox>需更换
                </div>
                <div class="show-print">
                  <input
                    type="checkbox"
                    id="u1"
                    value="无"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.WX==='无'?'checked':''"
                  />
                  <label for="u1">无</label>

                  <input
                    type="checkbox"
                    id="u2"
                    value="有"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.WX==='有'?'checked':''"
                  />
                  <label for="u2">有</label>
                  需更换
                </div>
              </div>
            </div>

            <div class="InfoNoTopBorder">
              <div class="InfoKey">巡回护士</div>
              <div class="InfoKey">
                <div class="no-print">
                  <MedSelect
                    type="NurseDictInOperRoom"
                    style="width:70px;margin-top:-13px;"
                    :remote="true"
                    :filterable="true"
                    placeholder="巡回护士"
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.XH_NURSE"
                    clearable
                    @GetDiaplayValue="GetDiaplayValue"
                  ></MedSelect>
                </div>
                <div
                  class="show-print"
                  style="margin-top:0px;margin-left:0px;border-bottom:1px dashed;"
                >{{WARD_XH_NURSE_DISPLAY}}</div>
              </div>

              <div class="InfoKey">
                <div class="no-print">
                  <el-checkbox
                    label="复苏护士"
                    true-label="复苏护士"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.FS_BQ"
                  ></el-checkbox>
                  <el-checkbox
                    label="病区护士"
                    true-label="病区护士"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.FS_BQ"
                  ></el-checkbox>
                </div>
                <div class="show-print">
                  <input
                    type="checkbox"
                    id="u1"
                    value="复苏护士"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.FS_BQ==='复苏护士'?'checked':''"
                  />
                  <label for="u1">复苏护士</label>

                  <input
                    type="checkbox"
                    id="u2"
                    value="病区护士"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.FS_BQ==='病区护士'?'checked':''"
                  />
                  <label for="u2">病区护士</label>
                </div>
              </div>

              <div class="InfoKey">
                <div class="no-print">
                  <MedSelect
                    type="NurseDict"
                    style="width:70px;margin-top:-13px;"
                    :remote="true"
                    :filterable="true"
                    placeholder="护士"
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.FS_BQ_NURSE"
                    clearable
                    @GetDiaplayValue="GetDiaplayValue"
                  ></MedSelect>
                </div>
                <div
                  class="show-print"
                  style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
                >{{FS_BQ_NURSE_DISPLAY}}</div>
              </div>
            </div>

            <div class="InfoNoTopBorder">
              <div class="InfoKey">时间：</div>

              <div class="no-print">
                <div class="el-date-picker" style="width:150px;">
                  <el-date-picker
                    style="width:150px;margin-top:-5px;"
                    type="datetime"
                    clearable
                    placeholder="交接时间"
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.TIME_POINT"
                    id="inDate"
                  ></el-date-picker>
                </div>
              </div>
              <div
                class="show-print"
                style="border-bottom:1px dashed;width:150px;margin-top:2px;line-height: 20px;height:20px;"
              >{{MedicalBasicDoc.MED_NURSING_AFTERSHIFT_WARD.TIME_POINT | formatDate('YYYY-MM-DD HH:mm')}}</div>
            </div>
          </div>
        </div>
        <div class="InfoColumn" style="border-top:0px;width:440px;margin-top:0px;">
          <div class="InfoColumn" style="border-top:0px;margin-top:0px;">
            <div class="InfoNoTopBorder">
              <div class="InfoColumnTitle">九 复苏室护士观察记录</div>
            </div>
            <div class="InfoNoTopBorder">
              <div class="InfoKey">1、引流管部位</div>
              <div class="InfoValue" style="margin-top:-5px; margin-left:5px;width:50px;">
                <div class="no-print">
                  <el-input v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.YLG_BW"></el-input>
                </div>
                <div
                  class="show-print"
                  style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
                >{{MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.YLG_BW}}</div>
              </div>
              <div class="InfoKey">数量</div>
              <div class="InfoValue" style="margin-top:-5px; margin-left:5px;width:50px;">
                <div class="no-print">
                  <el-input v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.YLG_COUNT"></el-input>
                </div>
                <div
                  class="show-print"
                  style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
                >{{MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.YLG_COUNT}}</div>
              </div>
              <div class="InfoKey">条</div>
            </div>

            <div class="InfoNoTopBorder">
              <div class="InfoKey">2、皮肤情况：</div>
              <div class="InfoKey">
                <div class="no-print">
                  <el-checkbox
                    label="正常"
                    true-label="正常"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.PF_STATUS"
                  ></el-checkbox>
                  <el-checkbox
                    label="异常"
                    true-label="异常"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.PF_STATUS"
                  ></el-checkbox>
                </div>
                <div class="show-print">
                  <input
                    type="checkbox"
                    id="u1"
                    value="正常"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.PF_STATUS==='正常'?'checked':''"
                  />
                  <label for="u1">正常</label>

                  <input
                    type="checkbox"
                    id="u2"
                    value="异常"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.PF_STATUS==='异常'?'checked':''"
                  />
                  <label for="u2">异常</label>
                </div>
              </div>

              <div class="InfoValue" style="margin-top:-5px; margin-left:5px;width:50px;">
                <div class="no-print">
                  <el-input v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.PF_OTHER"></el-input>
                </div>
                <div
                  class="show-print"
                  style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
                >{{MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.PF_OTHER}}</div>
              </div>
            </div>

            <div class="InfoNoTopBorder">
              <div class="InfoKey">3、意识情况：</div>
              <div class="InfoKey">
                <div class="no-print">
                  <el-checkbox
                    label="清醒"
                    true-label="清醒"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.YS"
                  ></el-checkbox>
                  <el-checkbox
                    label="嗜睡"
                    true-label="嗜睡"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.YS"
                  ></el-checkbox>
                  <el-checkbox
                    label="昏迷"
                    true-label="昏迷"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.YS"
                  ></el-checkbox>
                  <el-checkbox
                    label="其他"
                    true-label="其他"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.YS"
                  ></el-checkbox>
                </div>
                <div class="show-print">
                  <input
                    type="checkbox"
                    id="u1"
                    value="清醒"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.YS==='清醒'?'checked':''"
                  />
                  <label for="u1">清醒</label>

                  <input
                    type="checkbox"
                    id="u2"
                    value="嗜睡"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.YS==='嗜睡'?'checked':''"
                  />
                  <label for="u2">嗜睡</label>

                  <input
                    type="checkbox"
                    id="u3"
                    value="昏迷"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.YS==='昏迷'?'checked':''"
                  />
                  <label for="u3">昏迷</label>

                  <input
                    type="checkbox"
                    id="u4"
                    value="其他"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.YS==='其他'?'checked':''"
                  />
                  <label for="u4">其他</label>
                </div>
              </div>
            </div>

            <div class="InfoNoTopBorder">
              <div class="InfoKey">4、带回病区的用物：X光片：</div>
              <div class="InfoKey">
                <div class="no-print">
                  <el-checkbox
                    label="无"
                    true-label="无"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.DHBQYW_X"
                  ></el-checkbox>
                  <el-checkbox
                    label="有"
                    true-label="有"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.DHBQYW_X"
                  ></el-checkbox>
                </div>
                <div class="show-print">
                  <input
                    type="checkbox"
                    id="u1"
                    value="无"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.DHBQYW_X==='无'?'checked':''"
                  />
                  <label for="u1">无</label>

                  <input
                    type="checkbox"
                    id="u2"
                    value="有"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.DHBQYW_X==='有'?'checked':''"
                  />
                  <label for="u2">有</label>
                </div>
              </div>
              <div class="InfoValue" style="margin-top:-5px; margin-left:5px;width:50px;">
                <div class="no-print">
                  <el-input v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.DHBQYW_X_COUNT"></el-input>
                </div>
                <div
                  class="show-print"
                  style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
                >{{MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.DHBQYW_X_COUNT}}</div>
              </div>
              <div class="InfoKey">张</div>
            </div>
            <div class="InfoNoTopBorder">
              <div class="InfoKey">药物：</div>
              <div class="InfoKey">
                <div class="no-print">
                  <el-checkbox
                    label="无"
                    true-label="无"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.DHBQYW_YW"
                  ></el-checkbox>
                  <el-checkbox
                    label="有"
                    true-label="有"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.DHBQYW_YW"
                  ></el-checkbox>名称：
                </div>
                <div class="show-print">
                  <input
                    type="checkbox"
                    id="u1"
                    value="无"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.DHBQYW_YW==='无'?'checked':''"
                  />
                  <label for="u1">无</label>

                  <input
                    type="checkbox"
                    id="u2"
                    value="有"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.DHBQYW_YW==='有'?'checked':''"
                  />
                  <label for="u2">有</label>
                </div>
              </div>
              <div class="InfoValue" style="margin-top:-5px; margin-left:5px;width:50px;">
                <div class="no-print">
                  <el-input v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.DHBQYW_YW_NAME"></el-input>
                </div>
                <div
                  class="show-print"
                  style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
                >{{MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.DHBQYW_YW_NAME}}</div>
              </div>
              <div class="InfoKey">其他：</div>
              <div class="InfoValue" style="margin-top:-5px; margin-left:5px;width:80px;">
                <div class="no-print">
                  <el-input v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.DHBQYW_YW_OTHER"></el-input>
                </div>
                <div
                  class="show-print"
                  style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;width:80px;"
                >{{MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.DHBQYW_YW_OTHER}}</div>
              </div>
            </div>

            <div class="InfoNoTopBorder">
              <div class="InfoKey">5、输液部位：上肢</div>
              <div class="InfoKey">
                <div class="no-print">
                  <el-checkbox
                    label="左"
                    true-label="左"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.SYBW_SZ"
                  ></el-checkbox>
                  <el-checkbox
                    label="右"
                    true-label="右"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.SYBW_SZ"
                  ></el-checkbox>
                </div>
                <div class="show-print">
                  <input
                    type="checkbox"
                    id="u1"
                    value="左"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.SYBW_SZ==='左'?'checked':''"
                  />
                  <label for="u1">左</label>

                  <input
                    type="checkbox"
                    id="u2"
                    value="右"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.SYBW_SZ==='右'?'checked':''"
                  />
                  <label for="u2">右</label>
                </div>
              </div>
              <div class="InfoKey">下肢</div>
              <div class="InfoKey">
                <div class="no-print">
                  <el-checkbox
                    label="左"
                    true-label="左"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.SYBW_XZ"
                  ></el-checkbox>
                  <el-checkbox
                    label="右"
                    true-label="右"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.SYBW_XZ"
                  ></el-checkbox>
                </div>
                <div class="show-print">
                  <input
                    type="checkbox"
                    id="u1"
                    value="左"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.SYBW_XZ==='左'?'checked':''"
                  />
                  <label for="u1">左</label>

                  <input
                    type="checkbox"
                    id="u2"
                    value="右"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.SYBW_XZ==='右'?'checked':''"
                  />
                  <label for="u2">右</label>
                </div>
              </div>
            </div>
            <div class="InfoNoTopBorder">
              <div class="InfoKey">
                <div class="no-print">
                  <el-checkbox
                    label="锁骨下"
                    true-label="是"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.SYBW_SGX"
                  ></el-checkbox>
                  <el-checkbox
                    label="颈内"
                    true-label="是"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.SYBW_JN"
                  ></el-checkbox>
                  <el-checkbox
                    label="其他"
                    true-label="是"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.SYBW_OTHER"
                  ></el-checkbox>
                </div>
                <div class="show-print">
                  <input
                    type="checkbox"
                    id="u1"
                    value="是"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.SYBW_SGX==='是'?'checked':''"
                  />
                  <label for="u1">锁骨下</label>

                  <input
                    type="checkbox"
                    id="u2"
                    value="是"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.SYBW_JN==='是'?'checked':''"
                  />
                  <label for="u2">颈内</label>

                  <input
                    type="checkbox"
                    id="u3"
                    value="是"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.SYBW_OTHER==='是'?'checked':''"
                  />
                  <label for="u3">其他</label>
                </div>
              </div>
            </div>

            <div class="InfoNoTopBorder">
              <div class="InfoKey">6、带回血制品：红细胞</div>
              <div class="InfoValue" style="margin-top:-5px; margin-left:5px;width:50px;">
                <div class="no-print">
                  <el-input v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.DHXZP_H"></el-input>
                </div>
                <div
                  class="show-print"
                  style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
                >{{MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.DHXZP_H}}</div>
              </div>
              <div class="InfoKey">μ 血浆</div>
              <div class="InfoValue" style="margin-top:-5px; margin-left:5px;width:50px;">
                <div class="no-print">
                  <el-input v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.DHXZP_X"></el-input>
                </div>
                <div
                  class="show-print"
                  style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
                >{{MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.DHXZP_X}}</div>
              </div>
              <div class="InfoKey">μ</div>
            </div>

            <div class="InfoNoTopBorder">
              <div class="InfoKey">7、留置尿管：</div>
              <div class="InfoKey">
                <div class="no-print">
                  <el-checkbox
                    label="无"
                    true-label="无"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.LZNG_STATUS"
                  ></el-checkbox>
                  <el-checkbox
                    label="有"
                    true-label="有"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.LZNG_STATUS"
                  ></el-checkbox>
                </div>
                <div class="show-print">
                  <input
                    type="checkbox"
                    id="u1"
                    value="无"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.LZNG_STATUS==='无'?'checked':''"
                  />
                  <label for="u1">无</label>

                  <input
                    type="checkbox"
                    id="u2"
                    value="有"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.LZNG_STATUS==='有'?'checked':''"
                  />
                  <label for="u2">有</label>
                </div>
              </div>
              <div class="InfoKey">尿量：</div>
              <div class="InfoValue" style="margin-top:-5px; margin-left:5px;width:50px;">
                <div class="no-print">
                  <el-input v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.LZNG_NL"></el-input>
                </div>
                <div
                  class="show-print"
                  style="margin-top:10px;margin-left:0px;border-bottom:1px dashed;"
                >{{MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.LZNG_NL}}ml</div>
              </div>
              <div class="InfoKey">ml</div>
            </div>

            <div class="InfoNoTopBorder">
              <div class="InfoKey">8、病人体表及衣裤是否有污血：</div>
              <div class="InfoKey">
                <div class="no-print">
                  <el-checkbox
                    label="无"
                    true-label="无"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.WX"
                  ></el-checkbox>
                  <el-checkbox
                    label="有"
                    true-label="有"
                    false-label
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.WX"
                  ></el-checkbox>需更换
                </div>
                <div class="show-print">
                  <input
                    type="checkbox"
                    id="u1"
                    value="无"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.WX==='有'?'checked':''"
                  />
                  <label for="u1">无</label>

                  <input
                    type="checkbox"
                    id="u2"
                    value="有"
                    :checked="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.WX==='有'?'checked':''"
                  />
                  <label for="u2">有</label>
                  需更换
                </div>
              </div>
            </div>

            <div class="InfoNoTopBorder">
              <div class="InfoKey">复苏室护士</div>
              <div class="InfoKey">
                <div class="no-print">
                  <MedSelect
                    type="NurseDictInOperRoom"
                    style="width:70px;margin-top:-13px;"
                    :remote="true"
                    :filterable="true"
                    placeholder="复苏室护士"
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.XH_NURSE"
                    clearable
                    @GetDiaplayValue="GetDiaplayValue"
                  ></MedSelect>
                </div>
                <div
                  class="show-print"
                  style="margin-left:10px;border-bottom:1px dashed;"
                >{{PACU_XH_NURSE_DISPLAY}}</div>
              </div>

              <div class="InfoKey">病区护士</div>
              <div class="InfoKey">
                <div class="no-print">
                  <MedSelect
                    type="NurseDict"
                    style="width:70px;margin-top:-13px;"
                    :remote="true"
                    :filterable="true"
                    placeholder="病区护士"
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.BQ_NURSE"
                    clearable
                    @GetDiaplayValue="GetDiaplayValue"
                  ></MedSelect>
                </div>
                <div
                  class="show-print"
                  style="margin-left:10px;border-bottom:1px dashed;"
                >{{PACU_BQ_NURSE_DISPLAY}}</div>
              </div>
            </div>

            <div class="InfoNoTopBorder">
              <div class="InfoKey">时间：</div>

              <div class="no-print">
                <div class="el-date-picker" style="width:150px;">
                  <el-date-picker
                    style="width:150px;margin-top:-5px;"
                    type="datetime"
                    clearable
                    placeholder="交接时间"
                    v-model="MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.TIME_POINT"
                    id="inDate"
                  ></el-date-picker>
                </div>
              </div>
              <div
                class="show-print"
                style="border-bottom:1px dashed;width:200px;margin-top:2px;line-height: 20px;height:20px;"
              >{{MedicalBasicDoc.MED_NURSING_AFTERSHIFT_PACU.TIME_POINT | formatDate('YYYY-MM-DD HH:mm:ss')}}</div>
            </div>
          </div>
        </div>
      </div>

      <div class="InfoColumn" style="margin-top:5px;margin-bottom:5px;">
        <div class="InfoNoTopBorder">
          <div class="InfoColumnTitle">备注：病人直接回病区只需填写第八项，术后会PACU时第八、第九项都需要填写。</div>
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
import NursingDoc from './NursingDoc.js'
export default NursingDoc
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";
@media screen {
  .MainContent {
    width: 880px;
    color: black;
    font-size: 15px;
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
    .InfoNoTopBorder {
      margin-top: 5px;
      display: flex;
      flex-direction: row;
    }
    .InfoKey {
      margin-top: 5px;
      margin-left: 5px;
      min-width: 30px;
    }
    .InfoValue {
      margin-left: 0px;
      margin-top: 5px;
      min-width: 30px;
    }
    .InfoColumn {
      margin-top: 10px;
      display: flex;
      flex-direction: column;
      border-top: 1px solid;
    }
    .InfoColumnTitle {
      text-align: left;
      margin-left: 5px;
      margin-top: 5px;
      font-size: 15px;
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
    .TableBase table {
      border-right: 1px solid;
      border-bottom: 1px solid;
      border-collapse: collapse;
    }
    .TableBase table td {
      border-left: 1px solid;
      border-top: 1px solid;
      text-align: center;
      height: 50px;
      vertical-align: middle;
    }
    .xiexian {
      box-sizing: border-box;
      line-height: 50px;
      text-indent: 5px;
      // border: 1px solid;
      background: linear-gradient(
        45deg,
        transparent 49.5%,
        black 49.5%,
        black 50.5%,
        transparent 50.5%
      );
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
    .InfoNoTopBorder {
      margin-top: 4px;
      display: flex;
      flex-direction: row;
    }
    .InfoKey {
      margin-top: 3px;
      margin-left: 5px;
      min-width: 30px;
    }
    .InfoValue {
      margin-left: 0px;
      margin-top: 3px;
      min-width: 30px;
    }
    .InfoColumn {
      margin-top: 5px;
      display: flex;
      flex-direction: column;
      border-top: 1px solid;
    }
    .InfoColumnTitle {
      text-align: left;
      margin-left: 5px;
      margin-top: 5px;
      font-size: 15px;
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
    .TableBase table {
      border-right: 1px solid;
      border-bottom: 1px solid;
      border-collapse: collapse;
    }
    .TableBase table td {
      border-left: 1px solid;
      border-top: 1px solid;
      text-align: center;
      height: 20px;
      vertical-align: middle;
    }
    .xiexian {
      box-sizing: border-box;
      line-height: 20px;
      text-indent: 5px;
      // border: 1px solid;
      background: linear-gradient(
        45deg,
        transparent 49.5%,
        black 49.5%,
        black 50.5%,
        transparent 50.5%
      );
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

#tdCenter .el-input__inner {
  text-align: center;
  // border: 1px px solid;
}

#tdCenter .el-input-number {
  position: relative;
  display: inline-block;
  width: 100px;
}

#tdCenter .el-input-number__increase {
  right: 1px;
  border-radius: 0 4px 4px 0;
  border-left: 1px solid #dcdfe6;
  width: 20px;
  background: #dcdfe6;
}

#tdCenter .el-input-number__decrease {
  left: 1px;
  border-radius: 4px 0 0 4px;
  border-right: 1px solid #dcdfe6;
  width: 20px;
  background: #dcdfe6;
}
</style>
<style>
.anesreport-table .success-row {
  background: #d8f0fa;
}
.anesreport-table .default-row {
  background: white;
}
.el-table tbody .success-row:hover > td {
  background-color: #f9f2d4;
}
.el-table tbody .default-row:hover > td {
  background-color: #f9f2d4;
}
.el-table--enable-row-hover .el-table__body .success-row:hover > td {
  background-color: #f9f2d4;
}
.el-table--enable-row-hover .el-table__body .default-row:hover > td {
  background: #f9f2d4;
}
.el-table__body .success-row.hover-row > td {
  background-color: #f9f2d4;
}
.el-table__body .default-row.hover-row > td {
  background-color: #f9f2d4;
}

.report-wrapper .el-input__inner {
  height: 26px;
  background: #f7f7f7;
  border-radius: 5px;
}
.report-wrapper .el-input--small .el-input__inner {
  height: 26px;
  line-height: 26px;
}
.report-wrapper .el-input--small .el-input__icon {
  line-height: 22px;
}

.el-select-dropdown__item {
  font-size: 12px;
  height: 26px;
  line-height: 26px;
}

.el-table--border th {
  border-right: 1px solid #ebeef5;
}

.el-table th > .cell {
  font-size: 12px;
}

.sqlqueryViewdialog .el-dialog__header {
  padding: 0px 0px 0px;
}

.sqlqueryViewdialog .el-dialog__body {
  /* width: 90%; */
  padding: 0px 0px;
  color: #606266;
  font-size: 14px;
  height: 540px;
  background: rgba(255, 255, 255, 1);
  box-shadow: 0px 0px 8px 0px rgba(48, 50, 51, 0.55);
  border-radius: 5px;
}

/* .sqlqueryViewdialog .el-dialog__headerbtn {
  right: -20px;
} */

/* .chartqueryViewdialog .el-dialog__header {
  padding: 0px 0px 0px;
}

.chartqueryViewdialog .el-dialog__body {
  width: 1000px;
  padding: 0px 0px;
  color: #606266;
  font-size: 14px;
  height: 540px;
  background: rgba(255, 255, 255, 1);
  box-shadow: 0px 0px 8px 0px rgba(48, 50, 51, 0.55);
  border-radius: 5px;
}

.chartqueryViewdialog .el-dialog__headerbtn {
  right: -20px;
} */

.report-wrapper .el-table--scrollable-x .el-table__body-wrapper {
  overflow-x: auto;
}
</style>
