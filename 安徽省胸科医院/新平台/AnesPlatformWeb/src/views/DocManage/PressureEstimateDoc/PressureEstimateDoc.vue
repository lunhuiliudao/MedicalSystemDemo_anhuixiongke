<template>
  <div class="MainContent" id="MainContent">
    <!--确保文书打印主体的ID=printaArea,千万不要拼写错误，不然无法上传-->
    <div class="MainPrint" id="printaArea" ref="print" style="font-family:'宋体';">
      <div class="Title">安徽省胸科医院</div>
      <div class="Title" style="font-size:23px;">手术室手术患者压疮评估与护理表</div>
      <div class="Info">
        <div class="InfoKey">病区：</div>
        <div class="InfoValue">{{MedicalBasicDoc.PatientDetail.DEPT_NAME}}</div>
        <div class="InfoKey">床号：</div>
        <div class="InfoValue">{{MedicalBasicDoc.PatientDetail.BED_NO}}</div>
        <div class="InfoKey">住院号：</div>
        <div class="InfoValue">{{MedicalBasicDoc.PatientDetail.INP_NO}}</div>
        <div class="InfoKey" style="margin-left:30px;">姓名：</div>
        <div class="InfoValue">{{MedicalBasicDoc.PatientDetail.NAME}}</div>
        <div class="InfoKey" style="margin-left:30px;">性别：</div>
        <div class="InfoValue">{{MedicalBasicDoc.PatientDetail.SEX}}</div>
        <div class="InfoKey">年龄：</div>
        <div class="InfoValue">{{MedicalBasicDoc.PatientDetail.AGE}}</div>
      </div>

      <div class="Info">
        <div class="InfoKey">体重：</div>
        <div class="InfoValue">{{MedicalBasicDoc.MED_ANESTHESIA_PLAN_PMH.WEIGHT}} Kg</div>
        <div class="InfoKey">身高：</div>
        <div class="InfoValue">{{MedicalBasicDoc.MED_ANESTHESIA_PLAN_PMH.HEIGHT}} cm</div>
        <div class="InfoKey">手术日期：</div>
        <div
          class="InfoValue"
        >{{MedicalBasicDoc.MED_OPERATION_MASTER.SCHEDULED_DATE_TIME | formatDate('YYYY-MM-DD')}}</div>
        <div class="InfoKey" style="margin-left:50px;">手术起止时间：</div>
        <div
          class="InfoValue"
        >{{MedicalBasicDoc.MED_OPERATION_MASTER.START_DATE_TIME | formatDate('HH:mm')}} - {{MedicalBasicDoc.MED_OPERATION_MASTER.END_DATE_TIME | formatDate('HH:mm')}}</div>
      </div>

      <div class="Info">
        <div class="InfoKey" style="margin-top:18px;">手术体位：</div>
        <div class="InfoValue">
          <div class="no-print">
            <InputSelect
              type="OperPosition"
              style="width:680px;"
              placeholder="手术体位"
              v-model="MedicalBasicDoc.MED_OPERATION_MASTER.OPER_POSITION"
            ></InputSelect>
          </div>
          <div
            class="show-print"
            style="border-bottom:1px dashed;min-width:500px;margin-top:5px;line-height: 20px;height:20px;"
          >{{MedicalBasicDoc.MED_OPERATION_MASTER.OPER_POSITION}}</div>
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
        <div class="InfoKey" style="margin-top:18px;">手术名称：</div>
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

      <!--术前评估表格-->
      <div style="margin-top:10px;" class="TableBase" id="tdCenter">
        <table cellspacing="0" cellpadding="0">
          <tr>
            <td colspan="6">术前评估</td>
          </tr>
          <tr>
            <td rowspan="2" width="150">评估项目</td>
            <td colspan="4">评估细则</td>
            <td rowspan="2" width="150">得分</td>
          </tr>
          <tr>
            <td>1分</td>
            <td>2分</td>
            <td>3分</td>
            <td>4分</td>
          </tr>
          <tr>
            <td>年龄</td>
            <td>&lt;50岁</td>
            <td>50-64岁</td>
            <td>65-79岁</td>
            <td>&gt;= 80岁</td>
            <td>
              <div class="no-print" style="text-align:center;">
                <el-input-number
                  size="small"
                  :min="1"
                  :max="4"
                  v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AGE_SCORE"
                  v-on:change="ScoreChange"
                ></el-input-number>
              </div>
              <div
                class="show-print"
                style="text-align:center;"
              >{{MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AGE_SCORE}}</div>
            </td>
          </tr>
          <tr>
            <td>体重</td>
            <td>正常</td>
            <td>轻度消瘦或超重</td>
            <td>中度消瘦或肥胖</td>
            <td>重度消瘦或肥胖</td>
            <td>
              <div class="no-print" style="text-align:center;">
                <el-input-number
                  size="small"
                  :min="1"
                  :max="4"
                  v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.WEIGHT_SCORE"
                  v-on:change="ScoreChange"
                ></el-input-number>
              </div>
              <div
                class="show-print"
                style="text-align:center;"
              >{{MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.WEIGHT_SCORE}}</div>
            </td>
          </tr>

          <tr>
            <td>受力点皮肤</td>
            <td>完好</td>
            <td>红斑（瘀斑）或潮湿</td>
            <td>皮肤菲薄或水肿</td>
            <td>水疱或破损</td>
            <td>
              <div class="no-print" style="text-align:center;">
                <el-input-number
                  size="small"
                  :min="1"
                  :max="4"
                  v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.SLD_SCORE"
                  v-on:change="ScoreChange"
                ></el-input-number>
              </div>
              <div
                class="show-print"
                style="text-align:center;"
              >{{MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.SLD_SCORE}}</div>
            </td>
          </tr>

          <tr>
            <td>手术体位</td>
            <td>仰卧位</td>
            <td>局部麻醉俯卧或侧卧位</td>
            <td>斜坡卧位或截石位</td>
            <td>全身麻醉俯卧位、侧卧位、牵引位</td>
            <td>
              <div class="no-print" style="text-align:center;">
                <el-input-number
                  size="small"
                  :min="1"
                  :max="4"
                  v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.POSITION_SCORE"
                  v-on:change="ScoreChange"
                ></el-input-number>
              </div>
              <div
                class="show-print"
                style="text-align:center;"
              >{{MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.POSITION_SCORE}}</div>
            </td>
          </tr>

          <tr>
            <td>预计术中施加的外力</td>
            <td>未施加外作用力</td>
            <td>存在摩擦力或剪切力</td>
            <td>冲击力</td>
            <td>同时具有摩擦力、剪切力、冲击力</td>
            <td>
              <div class="no-print" style="text-align:center;">
                <el-input-number
                  size="small"
                  :min="1"
                  :max="4"
                  v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.SJWL_SCORE"
                  v-on:change="ScoreChange"
                ></el-input-number>
              </div>
              <div
                class="show-print"
                style="text-align:center;"
              >{{MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.SJWL_SCORE}}</div>
            </td>
          </tr>

          <tr>
            <td>预计手术时间</td>
            <td>&lt;3h</td>
            <td>3-4h</td>
            <td>&gt;4h且&lt;=5h</td>
            <td>&gt;5h</td>
            <td>
              <div class="no-print" style="text-align:center;">
                <el-input-number
                  size="small"
                  :min="1"
                  :max="4"
                  v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.SSSJ_SCORE"
                  v-on:change="ScoreChange"
                ></el-input-number>
              </div>
              <div
                class="show-print"
                style="text-align:center;"
              >{{MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.SSSJ_SCORE}}</div>
            </td>
          </tr>

          <tr>
            <td>预计手术出血</td>
            <td>&lt;500ml</td>
            <td>500-1000ml</td>
            <td>&gt;1000且&lt;=1500ml</td>
            <td>&gt;1500ml</td>
            <td>
              <div class="no-print" style="text-align:center;">
                <el-input-number
                  size="small"
                  :min="1"
                  :max="4"
                  v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.SSCX_SCORE"
                  v-on:change="ScoreChange"
                ></el-input-number>
              </div>
              <div
                class="show-print"
                style="text-align:center;"
              >{{MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.SSCX_SCORE}}</div>
            </td>
          </tr>

          <tr>
            <td>其他因素（无0分）</td>
            <td>糖尿病/外周血管病患者</td>
            <td>运动/感觉异常</td>
            <td>控制性降压或低体温</td>
            <td>休克或严重创伤</td>
            <td>
              <div class="no-print" style="text-align:center;">
                <el-input-number
                  size="small"
                  :min="1"
                  :max="4"
                  v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.OTHER_SCORE"
                  v-on:change="ScoreChange"
                ></el-input-number>
              </div>
              <div
                class="show-print"
                style="text-align:center;"
              >{{MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.OTHER_SCORE}}</div>
            </td>
          </tr>

          <tr>
            <td>合计</td>
            <td colspan="5">
              <div
                class="no-print"
                style="text-align:left;margin-left:20px;"
              >{{MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AMOUNT_SCORE}}</div>
              <div
                class="show-print"
                style="text-align:left;margin-left:20px;"
              >{{MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AMOUNT_SCORE}}</div>
            </td>
          </tr>
        </table>
      </div>

      <div class="InfoKey" style="font-weight:600;">备注：</div>
      <div class="InfoKey" style="margin-top:0px;">
        <div class="InfoValue" style="line-height:25px">
          <span style="font-weight:600;">1 标准体重</span>：身高(厘米) - 105=(公斤)。当体重低于（超过）标准体重的20%为轻度消瘦（肥胖）；当体重低于（超过）标准体重的30%为中度消瘦（肥胖）；当体重低于（超过）标准体重的40%为重度消瘦（肥胖）。
        </div>
        <div class="InfoValue" style="line-height:25px">
          <span style="font-weight:600;">2 受力点皮肤</span>：手术体位摆放后实际着力点的皮肤状况其中，其中红斑指压不褪色。
        </div>
        <div class="InfoValue" style="line-height:25px">
          <span style="font-weight:600;">3 术中施加的外力</span>：术中调整手术床角度、方向以及复位、内固定的凿、锤、拉、压等施加的外作用力。
        </div>
        <div class="InfoValue" style="line-height:25px">
          <span style="font-weight:600;">4 其他因素</span>：控制性降压指成年人收缩压降至60-70mmHg、老年人降至80mmHg，低体温指体核温度低于30℃。
        </div>
        <div class="InfoValue" style="line-height:25px">
          <span style="font-weight:600;">5 累计个条目总分</span>：12分为危险，>=13分为高度危险。分值越高，压疮风险越高。
        </div>
      </div>

      <div
        class="InfoKey"
        style="line-height:25px;font-size:18px;font-weight:550;"
      >附：对于年龄&gt;65岁、体重&gt;90kg或&lt;35kg、手术时间（从入室到出室）&gt;4h、特殊体位（俯卧位、侧卧位、截石位、牵引位）患者必须进行评估并采取相应预防压疮措施。</div>

      <div
        class="Info"
        style="border-left:1px solid #FFFFFF;margin-left:-1px;border-right:1px solid #FFFFFF;margin-right:-1px;"
      >
        <div
          class="InfoKey"
          style="margin-top:20px; margin-bottom:20px;margin-left:300px;width:90px;"
        >责任护士：</div>
        <div class="no-print">
          <div>
            <MedSelect
              type="NurseDict"
              style="width:100px;margin-top:10px;"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.NURSE"
              :remote="true"
              :filterable="true"
              placeholder="责任护士"
              clearable
              @GetDiaplayValue="GetDiaplayValue"
            ></MedSelect>
          </div>
        </div>
        <div
          class="show-print"
          style="border-bottom:1px dashed;margin-top:18px;height:20px;width:100px;"
        >{{NURSE_DISPLAY}}</div>

        <div class="InfoKey" style="margin-top:20px; margin-bottom:20px;margin-left:50px;">日期：</div>
        <div class="el-date-picker">
          <div class="no-print">
            <el-date-picker
              style="width:120px;margin-top:10px;"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.DOC_DATE"
              type="date"
              clearable
              id="inDate"
            ></el-date-picker>
          </div>
          <div
            class="show-print"
            style="border-bottom:1px dashed;width:120px;margin-top:15px;height:20px;"
          >{{MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.DOC_DATE | formatDate('YYYY-MM-DD')}}</div>
        </div>
      </div>

      <div
        style="height:30px;border-left:1px solid #FFFFFF;margin-left:-1px;border-right:1px solid #FFFFFF;margin-right:-1px;"
      ></div>

      <!--术中护理-->
      <div style="text-align:center;border-top:1px solid;font-weight:600;margin-top:0px;">
        <div style="margin-top:20px;margin-bottom:20px;">术中护理</div>
      </div>

      <div class="Info">
        <div style="width:150px;border-right:1px solid;margin-left:5px;">
          <div style="margin-top:15px;">减少剪切力与摩擦力</div>
        </div>
        <div style="line-height:25px;margin-left:10px;margin-top:10px;">
          <div class="no-print">
            <el-checkbox
              true-label="是"
              false-label
              label="床单平整无褶皱"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.POWER_CD"
            ></el-checkbox>
            <br />
            <el-checkbox
              true-label="是"
              false-label
              label="体位垫与皮肤之间平顺、无皱折、无皮肤挤压"
              style="margin-top:5px;"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.POWER_TWD"
            ></el-checkbox>
            <br />
            <el-checkbox
              true-label="是"
              false-label
              label="控制术中摇床的次数和角度"
              style="margin-top:5px;"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.POWER_YC"
            ></el-checkbox>
            <br />
            <el-checkbox
              true-label="是"
              false-label
              label="约束带柔软、平滑，松紧适宜"
              style="margin-top:5px;"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.POWER_YSD"
            ></el-checkbox>
            <br />
            <el-checkbox
              true-label="是"
              false-label
              label="其他"
              style="margin-top:5px;"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.POWER_OTHER"
            ></el-checkbox>
          </div>
          <div class="show-print">
            <input
              type="checkbox"
              id="u1"
              value="是"
              :checked="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.POWER_CD==='是'?'checked':''"
            />
            <label for="u1">床单平整无褶皱</label>
            <br />

            <input
              type="checkbox"
              id="u2"
              value="是"
              :checked="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.POWER_TWD==='是'?'checked':''"
            />
            <label for="u2">体位垫与皮肤之间平顺、无皱折、无皮肤挤压</label>
            <br />

            <input
              type="checkbox"
              id="u3"
              value="是"
              :checked="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.POWER_YC==='是'?'checked':''"
            />
            <label for="u3">控制术中摇床的次数和角度</label>
            <br />

            <input
              type="checkbox"
              id="u4"
              value="是"
              :checked="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.POWER_YSD==='是'?'checked':''"
            />
            <label for="u4">约束带柔软、平滑，松紧适宜</label>
            <br />

            <input
              type="checkbox"
              id="u5"
              value="是"
              :checked="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.POWER_OTHER==='是'?'checked':''"
            />
            <label for="u5">其他</label>
          </div>
        </div>
      </div>

      <div class="Info" style="margin-top:0px;">
        <div style="width:150px;border-right:1px solid;margin-left:5px;">
          <div style="margin-top:15px;">压力减缓用具使用</div>
        </div>
        <div style="line-height:25px;margin-left:10px;margin-top:10px;">
          <div class="no-print">
            <el-checkbox
              true-label="是"
              false-label
              label="吸收帖贴皮肤"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.REDPRE_ZT"
            ></el-checkbox>
            <br />
            <el-checkbox
              true-label="是"
              false-label
              label="体位垫"
              style="margin-top:5px;"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.REDPRE_TWD"
            ></el-checkbox>
            <br />
            <el-checkbox
              true-label="是"
              false-label
              label="在条件允许的情况下，隔1h轻抬受压部位，缓解局部压力"
              style="margin-top:5px;"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.REDPRE_HJ"
            ></el-checkbox>
            <br />
            <el-checkbox
              true-label="是"
              false-label
              label="其他"
              style="margin-top:5px;"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.REDPRE_OTHER"
            ></el-checkbox>
          </div>
          <div class="show-print">
            <input
              type="checkbox"
              id="u1"
              value="是"
              :checked="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.REDPRE_ZT==='是'?'checked':''"
            />
            <label for="u1">吸收帖贴皮肤</label>
            <br />

            <input
              type="checkbox"
              id="u2"
              value="是"
              :checked="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.REDPRE_TWD==='是'?'checked':''"
            />
            <label for="u2">体位垫</label>
            <br />

            <input
              type="checkbox"
              id="u3"
              value="是"
              :checked="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.REDPRE_HJ==='是'?'checked':''"
            />
            <label for="u3">在条件允许的情况下，隔1h轻抬受压部位，缓解局部压力</label>
            <br />

            <input
              type="checkbox"
              id="u4"
              value="是"
              :checked="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.REDPRE_OTHER==='是'?'checked':''"
            />
            <label for="u4">其他</label>
          </div>
        </div>
      </div>

      <div class="Info" style="margin-top:0px;">
        <div style="width:150px;border-right:1px solid;margin-left:5px;">
          <div style="margin-top:15px;">皮肤护理</div>
        </div>
        <div style="line-height:25px;margin-left:10px;margin-top:10px;">
          <div class="no-print">
            <el-checkbox
              true-label="是"
              false-label
              label="保暖：暖风机 盖被 液体恒温 输液铺单前、手术缝皮后将室温调高"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.SKIN_BN"
            ></el-checkbox>
            <br />
            <el-checkbox
              true-label="是"
              false-label
              label="防止消毒液浸湿消毒区以外皮肤"
              style="margin-top:5px;"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.SKIN_XD"
            ></el-checkbox>
            <br />
            <el-checkbox
              true-label="是"
              false-label
              label="保持手术铺巾干燥、平整"
              style="margin-top:5px;"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.SKIN_PJGZ"
            ></el-checkbox>
            <br />
            <el-checkbox
              true-label="是"
              false-label
              label="保护眼角膜"
              style="margin-top:5px;"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.SKIN_YJM"
            ></el-checkbox>
            <br />
            <el-checkbox
              true-label="是"
              false-label
              label="眼眶、耳廊不受压"
              style="margin-top:5px;"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.SKIN_YKEL"
            ></el-checkbox>
            <br />
            <el-checkbox
              true-label="是"
              false-label
              label="其他"
              style="margin-top:5px;"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.SKIN_OTHER"
            ></el-checkbox>
          </div>
          <div class="show-print">
            <input
              type="checkbox"
              id="u1"
              value="是"
              :checked="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.SKIN_BN==='是'?'checked':''"
            />
            <label for="u1">保暖：暖风机 盖被 液体恒温 输液铺单前、手术缝皮后将室温调高</label>
            <br />

            <input
              type="checkbox"
              id="u2"
              value="是"
              :checked="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.SKIN_XD==='是'?'checked':''"
            />
            <label for="u2">防止消毒液浸湿消毒区以外皮肤</label>
            <br />

            <input
              type="checkbox"
              id="u3"
              value="是"
              :checked="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.SKIN_PJGZ==='是'?'checked':''"
            />
            <label for="u3">保持手术铺巾干燥、平整</label>
            <br />

            <input
              type="checkbox"
              id="u4"
              value="是"
              :checked="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.SKIN_YJM==='是'?'checked':''"
            />
            <label for="u4">保护眼角膜</label>
            <br />

            <input
              type="checkbox"
              id="u5"
              value="是"
              :checked="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.SKIN_YKEL==='是'?'checked':''"
            />
            <label for="u5">眼眶、耳廊不受压</label>
            <br />

            <input
              type="checkbox"
              id="u6"
              value="是"
              :checked="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.SKIN_OTHER==='是'?'checked':''"
            />
            <label for="u6">其他</label>
          </div>
        </div>
      </div>

      <div class="Info" style="margin-top:0px;border-bottom:1px solid;">
        <div style="width:150px;border-right:1px solid;margin-left:5px;">
          <div style="margin-top:15px;">体位观察与护理</div>
        </div>
        <div style="line-height:25px;margin-left:10px;margin-top:10px;">
          <div class="no-print">
            <el-checkbox
              true-label="是"
              false-label
              label="安全固定"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.POS_SAVE"
            ></el-checkbox>
            <br />
            <el-checkbox
              true-label="是"
              false-label
              label="术中摇床后避免身体移位，变换体位后及时检查"
              style="margin-top:5px;"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.POS_YC"
            ></el-checkbox>
            <br />
            <el-checkbox
              true-label="是"
              false-label
              label="保持卧位稳定、肢体舒展，衔接部位凹陷处用软垫支撑"
              style="margin-top:5px;"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.POS_WW"
            ></el-checkbox>
            <br />
            <el-checkbox
              true-label="是"
              false-label
              label="肢体功能位"
              style="margin-top:5px;"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.POS_ZT"
            ></el-checkbox>
            <br />
            <el-checkbox
              true-label="是"
              false-label
              label="肢体无接触金属"
              style="margin-top:5px;"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.POS_ZTWJS"
            ></el-checkbox>
            <br />
            <el-checkbox
              true-label="是"
              false-label
              label="各管道电极线无受压"
              style="margin-top:5px;"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.POS_GD"
            ></el-checkbox>
            <br />
            <el-checkbox
              true-label="是"
              false-label
              label="其他"
              style="margin-top:5px;"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.POS_OTHER"
            ></el-checkbox>
          </div>
          <div class="show-print">
            <input
              type="checkbox"
              id="u1"
              value="是"
              :checked="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.POS_SAVE==='是'?'checked':''"
            />
            <label for="u1">安全固定</label>
            <br />

            <input
              type="checkbox"
              id="u2"
              value="是"
              :checked="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.POS_YC==='是'?'checked':''"
            />
            <label for="u2">术中摇床后避免身体移位，变换体位后及时检查</label>
            <br />

            <input
              type="checkbox"
              id="u3"
              value="是"
              :checked="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.POS_WW==='是'?'checked':''"
            />
            <label for="u3">保持卧位稳定、肢体舒展，衔接部位凹陷处用软垫支撑</label>
            <br />

            <input
              type="checkbox"
              id="u4"
              value="是"
              :checked="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.POS_ZT==='是'?'checked':''"
            />
            <label for="u4">肢体功能位</label>
            <br />

            <input
              type="checkbox"
              id="u5"
              value="是"
              :checked="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.POS_ZTWJS==='是'?'checked':''"
            />
            <label for="u5">肢体无接触金属</label>
            <br />

            <input
              type="checkbox"
              id="u7"
              value="是"
              :checked="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.POS_GD==='是'?'checked':''"
            />
            <label for="u7">各管道电极线无受压</label>
            <br />

            <input
              type="checkbox"
              id="u6"
              value="是"
              :checked="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.POS_OTHER==='是'?'checked':''"
            />
            <label for="u6">其他</label>
          </div>
        </div>
      </div>

      <!--术后护理-->
      <div
        style="height:70px;border-left:1px solid #FFFFFF;margin-left:-1px;border-right:1px solid #FFFFFF;margin-right:-1px;"
      ></div>

      <div style="text-align:center;border-top:1px solid;font-weight:600;">
        <div style="margin-top:20px;margin-bottom:20px;">术后护理</div>
      </div>

      <div class="Info">
        <div style="width:150px;border-right:1px solid;margin-left:5px;">
          <div style="margin-top:13px;">检查皮肤</div>
        </div>
        <div style="line-height:25px;margin-left:10px;margin-top:10px;">
          <div class="no-print">
            <el-checkbox
              true-label="是"
              false-label
              label="完好"
              v-on:change="CheckboxChange"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_GOOD"
            ></el-checkbox>
            <br />
            <el-checkbox
              true-label="否"
              false-label
              label="有压疮"
              style="margin-top:5px;"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_GOOD"
            ></el-checkbox>

            <el-checkbox
              true-label="是"
              false-label
              label="一期"
              style="margin-top:5px;margin-left:20px;"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC_ONE"
            ></el-checkbox>

            <el-checkbox
              true-label="是"
              false-label
              label="二期"
              style="margin-top:5px;margin-left:20px;"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC_TWO"
            ></el-checkbox>

            <el-checkbox
              true-label="是"
              false-label
              label="三期"
              style="margin-top:5px;margin-left:20px;"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC_THREE"
            ></el-checkbox>

            <el-checkbox
              true-label="是"
              false-label
              label="四期"
              style="margin-top:5px;margin-left:20px;"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC_FOUR"
            ></el-checkbox>

            <el-checkbox
              true-label="是"
              false-label
              label="不可分期"
              style="margin-top:5px;margin-left:20px;"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC_NO"
            ></el-checkbox>

            <el-checkbox
              true-label="是"
              false-label
              label="深部组织损伤"
              style="margin-top:5px;margin-left:20px;"
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC_SBZZ"
            ></el-checkbox>
          </div>
          <div class="show-print">
            <input
              type="checkbox"
              id="u1"
              value="是"
              :checked="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_GOOD==='是'?'checked':''"
            />
            <label for="u1">完好</label>
            <br />

            <input
              type="checkbox"
              id="u1"
              value="是"
              :checked="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC==='是'?'checked':''"
            />
            <label for="u1">有压疮</label>

            <input
              type="checkbox"
              id="u1"
              value="是"
              :checked="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC_ONE==='是'?'checked':''"
            />
            <label for="u1">一期</label>

            <input
              type="checkbox"
              id="u1"
              value="是"
              :checked="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC_TWO==='是'?'checked':''"
            />
            <label for="u1">二期</label>

            <input
              type="checkbox"
              id="u1"
              value="是"
              :checked="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC_THREE==='是'?'checked':''"
            />
            <label for="u1">三期</label>

            <input
              type="checkbox"
              id="u1"
              value="是"
              :checked="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC_FOUR==='是'?'checked':''"
            />
            <label for="u1">四期</label>

            <input
              type="checkbox"
              id="u1"
              value="是"
              :checked="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC_NO==='是'?'checked':''"
            />
            <label for="u1">不可分期</label>

            <input
              type="checkbox"
              id="u1"
              value="是"
              :checked="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC_SBZZ==='是'?'checked':''"
            />
            <label for="u1">深部组织损伤</label>
          </div>
        </div>
      </div>

      <div class="Info" style="margin-top:0px;">
        <div style="width:150px;border-right:1px solid;margin-left:5px;">
          <div style="margin-top:13px;">术后交接</div>
        </div>
        <div style="line-height:25px;margin-left:-1px;margin-top:-1px;height:53px;width:725px">
          <div class="no-print">
            <el-input
              type="textarea"
              :autosize="{minRows:2, maxRow:2}"
              maxlength="100"
              show-word-limit
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AFTER_SHIFT"
            ></el-input>
          </div>
          <div
            class="show-print"
            style="margin-top:5px;margin-left:5px;"
          >{{MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AFTER_SHIFT}}</div>
        </div>
      </div>

      <div class="Info" style="margin-top:0px;">
        <div style="width:150px;border-right:1px solid;margin-left:5px;">
          <div style="margin-top:13px;">原因分析</div>
        </div>
        <div style="line-height:25px;margin-left:-1px;margin-top:-1px;height:95px;width:725px">
          <div class="no-print">
            <el-input
              type="textarea"
              :autosize="{minRows:4, maxRow:4}"
              maxlength="200"
              show-word-limit
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AFTER_SHIFT_CAUSE"
            ></el-input>
          </div>
          <div
            class="show-print"
            style="margin-top:5px;margin-left:5px;"
          >{{MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AFTER_SHIFT_CAUSE}}</div>
        </div>
      </div>

      <div class="Info" style="margin-top:0px;">
        <div style="width:150px;border-right:1px solid;margin-left:5px;">
          <div style="margin-top:13px;">整改措施</div>
        </div>
        <div style="line-height:25px;margin-left:-1px;margin-top:-1px;height:137px;width:725px;">
          <div class="no-print">
            <el-input
              type="textarea"
              :autosize="{minRows:6, maxRow:6}"
              maxlength="300"
              show-word-limit
              v-model="MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AFTER_SHIFT_RESOLVE"
            ></el-input>
          </div>
          <div
            class="show-print"
            style="margin-top:5px;margin-left:5px;"
          >{{MedicalBasicDoc.MED_PRESSUREESTIMATE_DOC.AFTER_SHIFT_RESOLVE}}</div>
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
import PressureEstimateDoc from './PressureEstimateDoc.js'
export default PressureEstimateDoc
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
  width: 120px;
  line-height: 38px;
}

#tdCenter .el-input-number__increase {
  right: 1px;
  border-radius: 0 4px 4px 0;
  border-left: 1px solid #dcdfe6;
}
</style>
