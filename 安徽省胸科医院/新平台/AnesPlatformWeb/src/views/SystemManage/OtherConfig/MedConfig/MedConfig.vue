<template>
  <div class="medConfigDiv">
    <el-dialog width="60%" :title="dialogDrugShow" :visible.sync="dialogTypeSetVisible1 ">
      <el-select
        v-model="items.type1"
        style="width:120px;"
        :placeholder="items.p1"
        @change="selectChange('DrugShow')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugValueItems1"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <el-select
        v-model="items.type2"
        style="width:120px;"
        :placeholder="items.p2"
        @change="selectChange('DrugShow')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugValueItems2"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <el-select
        v-model="items.type3"
        style="width:120px;"
        :placeholder="items.p3"
        @change="selectChange('else')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugOuterMarkItems"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <el-select
        v-model="items.type4"
        style="width:120px;"
        :placeholder="items.p4"
        @change="selectChange('DrugShow')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugValueItems3"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <el-select
        v-model="items.type5"
        style="width:120px;"
        :placeholder="items.p5"
        @change="selectChange('DrugShow')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugValueItems4"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <el-select
        v-model="items.type6"
        style="width:120px;"
        :placeholder="items.p6"
        @change="selectChange('else')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugInnerMarkItems"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <br>
      <br>
      <el-select
        v-model="items.type7"
        style="width:120px;"
        :placeholder="items.p7"
        @change="selectChange('DrugShow')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugValueItems5"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <el-select
        v-model="items.type8"
        style="width:120px;"
        :placeholder="items.p8"
        @change="selectChange('DrugShow')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugValueItems6"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <el-select
        v-model="items.type9"
        style="width:120px;"
        :placeholder="items.p9"
        @change="selectChange('else')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugRouteIdentifyItems"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <el-select
        v-model="items.type10"
        style="width:120px;"
        :placeholder="items.p10"
        @change="selectChange('else')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypAdministratorItems"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <el-select
        v-model="items.type11"
        style="width:120px;"
        :placeholder="items.p11"
        @change="selectChange('else')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugOuterMarkItems"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <!-- <el-select v-model="items.type12" style="width:120px;" placeholder="">
        <el-option v-for="item in TypeDrugMarkItems" :key="item.value" :label="item.label" :value="item.value">
        </el-option>
      </el-select>-->
      <el-button type="primary" class="medConfigDivAdd" @click="onSubmit()">确认</el-button>
      <el-button type="primary" class="medConfigDivAdd" @click="ClearDrug(1)">清空</el-button>&nbsp;&nbsp;&nbsp;&nbsp;
      <br>
      <br>
      <br>
      <br>
      <br>
    </el-dialog>

    <el-dialog width="60%" :title="dialogDrugNameShow" :visible.sync="dialogTypeSetVisible3">
      <!-- <el-select v-model="type1" placeholder="请选择">
                            <el-option v-for="item in TypeItems" :key="item.value" :label="item.label" :value="item.value">
                            </el-option>
                          </el-select>
                          <el-select v-model="type2" placeholder="请选择">
                            <el-option v-for="item in TypeItems" :key="item.value" :label="item.label" :value="item.value">
                            </el-option>
      </el-select>-->

      <el-select
        v-model="items.type1"
        style="width:120px;"
        :placeholder="items.p1"
        @change="selectChange('else')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugNameItems"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <el-select
        v-model="items.type2"
        style="width:120px;"
        :placeholder="items.p2"
        @change="selectChange('else')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugOuterMarkItems"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <el-select
        v-model="items.type3"
        style="width:120px;"
        :placeholder="items.p3"
        @change="selectChange('DrugLegend')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugNameUnitsItems1"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <el-select
        v-model="items.type4"
        style="width:120px;"
        :placeholder="items.p4"
        @change="selectChange('else')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugOuterMarkItems"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <el-select
        v-model="items.type2"
        style="width:120px;"
        :placeholder="items.p5"
        @change="selectChange('else')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugOuterMarkItems"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <el-select
        v-model="items.type6"
        style="width:120px;"
        :placeholder="items.p6"
        @change="selectChange('DrugLegend')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugNameUnitsItems2"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <br>
      <br>
      <el-select
        v-model="items.type4"
        style="width:120px;"
        :placeholder="items.p7"
        @change="selectChange('else')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugOuterMarkItems"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <el-select
        v-model="items.type2"
        style="width:120px;"
        :placeholder="items.p8"
        @change="selectChange('else')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugOuterMarkItems"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <el-select
        v-model="items.type9"
        style="width:120px;"
        :placeholder="items.p9"
        @change="selectChange('DrugLegend')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugNameUnitsItems3"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <el-select
        v-model="items.type4"
        style="width:120px;"
        :placeholder="items.p10"
        @change="selectChange('else')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugOuterMarkItems"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <el-select
        v-model="items.type2"
        style="width:120px;"
        :placeholder="items.p11"
        @change="selectChange('else')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugOuterMarkItems"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <el-select
        v-model="items.type12"
        style="width:120px;"
        :placeholder="items.p12"
        @change="selectChange('DrugLegend')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugNameUnitsItems4"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <el-select
        v-model="items.type4"
        style="width:120px;"
        :placeholder="items.p13"
        @change="selectChange('else')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugOuterMarkItems"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>

      <el-button type="primary" class="medConfigDivAdd" @click="onSubmit()">确认</el-button>
      <el-button type="primary" class="medConfigDivAdd" @click="ClearDrug(3)">清空</el-button>&nbsp;&nbsp;&nbsp;&nbsp;
      <br>
      <br>
      <br>
      <br>
      <br>
    </el-dialog>

    <el-dialog width="60%" :title="dialogDrugNameShow" :visible.sync="dialogTypeSetVisible3">
      <!-- <el-select v-model="type1" placeholder="请选择">
                            <el-option v-for="item in TypeItems" :key="item.value" :label="item.label" :value="item.value">
                            </el-option>
                          </el-select>
                          <el-select v-model="type2" placeholder="请选择">
                            <el-option v-for="item in TypeItems" :key="item.value" :label="item.label" :value="item.value">
                            </el-option>
      </el-select>-->

      <el-select
        v-model="items.type1"
        style="width:120px;"
        :placeholder="items.p1"
        @change="selectChange('else')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugNameItems"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <el-select
        v-model="items.type2"
        style="width:120px;"
        :placeholder="items.p2"
        @change="selectChange('else')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugOuterMarkItems"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <el-select
        v-model="items.type3"
        style="width:120px;"
        :placeholder="items.p3"
        @change="selectChange('DrugLegend')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugNameUnitsItems1"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <el-select
        v-model="items.type4"
        style="width:120px;"
        :placeholder="items.p4"
        @change="selectChange('else')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugOuterMarkItems"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <el-select
        v-model="items.type2"
        style="width:120px;"
        :placeholder="items.p5"
        @change="selectChange('else')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugOuterMarkItems"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <el-select
        v-model="items.type6"
        style="width:120px;"
        :placeholder="items.p6"
        @change="selectChange('DrugLegend')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugNameUnitsItems2"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <br>
      <br>
      <el-select
        v-model="items.type4"
        style="width:120px;"
        :placeholder="items.p7"
        @change="selectChange('else')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugOuterMarkItems"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <el-select
        v-model="items.type2"
        style="width:120px;"
        :placeholder="items.p8"
        @change="selectChange('else')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugOuterMarkItems"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <el-select
        v-model="items.type9"
        style="width:120px;"
        :placeholder="items.p9"
        @change="selectChange('DrugLegend')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugNameUnitsItems3"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <el-select
        v-model="items.type4"
        style="width:120px;"
        :placeholder="items.p10"
        @change="selectChange('else')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugOuterMarkItems"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <el-select
        v-model="items.type2"
        style="width:120px;"
        :placeholder="items.p11"
        @change="selectChange('else')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugOuterMarkItems"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <el-select
        v-model="items.type12"
        style="width:120px;"
        :placeholder="items.p12"
        @change="selectChange('DrugLegend')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugNameUnitsItems4"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>
      <el-select
        v-model="items.type4"
        style="width:120px;"
        :placeholder="items.p13"
        @change="selectChange('else')"
      >
        <el-option
          style="font-size:14px;padding:0px 5px;"
          v-for="item in TypeDrugOuterMarkItems"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        ></el-option>
      </el-select>

      <el-button type="primary" class="medConfigDivAdd" @click="onSubmit()">确认</el-button>
      <el-button type="primary" class="medConfigDivAdd" @click="ClearDrug(3)">清空</el-button>&nbsp;&nbsp;&nbsp;&nbsp;
      <br>
      <br>
      <br>
      <br>
      <br>
    </el-dialog>
    <el-button
      type="primary"
      class="medConfigDivAdd"
      style="margin-left:30px; margin-top:10px;"
      @click="SaveConfig"
    >保存配置</el-button>
    <div style="background-color: #fff;min-height:600px;">
      <div class="report-main-top-wrapper"></div>
      <el-tabs type="border-card">
        <el-tab-pane style="min-height:700px;" label="一体机">
          <el-form :inline="true" label-position="right" class="demo-form-inline">
            <el-form-item label="调用接口同步">
              <el-tooltip placement="top">
                <div slot="content">说明：是否启用接口同步数据</div>
                <el-switch v-model="MedConfig.IsSync"></el-switch>
              </el-tooltip>
            </el-form-item>
            <el-form-item label="急诊根据住院号同步">
              <el-tooltip placement="top">
                <div slot="content">
                  说明：是-急诊登记根据住院号同步数据
                  <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;否-急诊登记根据患者ID同步数据
                </div>
                <el-switch v-model="MedConfig.IsSyncByInpNo"></el-switch>
              </el-tooltip>
            </el-form-item>
            <el-form-item label="文书双击显示下拉">
              <el-tooltip placement="top">
                <div slot="content">
                  说明：是-文书中文本框双击弹出下拉框
                  <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;否-文书中文本框单击弹出下拉框
                </div>
                <el-switch v-model="MedConfig.DoubleSelect"></el-switch>
              </el-tooltip>
            </el-form-item>
            <el-form-item label="启动协同功能">
              <el-tooltip placement="top">
                <div slot="content">说明：是否启用协同功能</div>
                <el-switch v-model="MedConfig.IsOpenCoordinationCall"></el-switch>
              </el-tooltip>
            </el-form-item>
            <br>
            <el-form-item label="标记修改过的体征项">
              <el-tooltip placement="top">
                <div slot="content">说明：修改过的体征显示不同的颜色</div>
                <el-switch v-model="MedConfig.IsModifyVitalSignShowDifferent"></el-switch>
              </el-tooltip>
            </el-form-item>
            <!-- <el-form-item label="启用PACU管理" v-show="fasle">
              <el-switch v-model="MedConfig.IsPACUProcess">
              </el-switch>
            </el-form-item>-->
            <el-form-item label="更新排班程序状态">
              <el-tooltip placement="top">
                <div slot="content">说明：麻醉中状态修改同步更新排班中状态</div>
                <el-switch v-model="MedConfig.IsUpdateScheduleStatus"></el-switch>
              </el-tooltip>
            </el-form-item>
            <el-form-item label="更新HIS手术状态">
              <el-tooltip placement="top">
                <div slot="content">说明：麻醉中状态修改同步更新HIS中状态</div>
                <el-switch v-model="MedConfig.IsUpdateHisStatus"></el-switch>
              </el-tooltip>
            </el-form-item>
            <!-- <el-form-item label="回传麻醉收费信息"  v-show="fasle">
              <el-switch v-model="MedConfig.IsUpdateAnesCharge">
              </el-switch>
                  </el-form-item>-->
                  <!-- <el-form-item label="手术过程中完成三方核查单" v-show="fasle">
              <el-switch v-model="MedConfig.IsVerificationAudit" > </el-switch>
            </el-form-item>-->
            <el-form-item label="启用患者核对模块">
              <el-tooltip placement="top">
                <div slot="content">说明：启用患者核对模块</div>
                <el-switch v-model="MedConfig.IsOpenPatConfirm"></el-switch>
              </el-tooltip>
            </el-form-item>
            <br>
            <el-form-item label="手术医生科室筛选">
              <el-tooltip placement="top">
                <div slot="content">请以英文逗号分隔,如('1501','1601','5643')</div>
                <!-- 必须设定像素,否则换行 -->
                <el-input placeholder="请输入内容" v-model="MedConfig.DeptCodeStr" style="width:400px;"></el-input>
              </el-tooltip>
            </el-form-item>
            <br>
            <el-form-item label="第三方接口配置">
              <el-button @click="addInterfaceKeyValue" type="primary" class="medConfigDivAdd">添加行</el-button>
              <el-button @click="SaveInterfaceDetailData" type="primary" class="medConfigDivAdd">保存</el-button>
              <el-table :data="interfaceDetailData" border style="width:880px;">
                <el-table-column prop="INT_TYPE" label="类型" width="95px" align="center">
                  <template slot-scope="scope">
                    <el-select v-model="scope.row.INT_TYPE">
                      <el-option
                        style="font-size:14px;padding:0px 5px;"
                        v-for="item in interfaceDetailDict"
                        :key="item.value"
                        :label="item.label"
                        :value="item.value"
                      ></el-option>
                    </el-select>
                  </template>
                </el-table-column>
                <el-table-column prop="INT_NAME" label="名称" width="174px" align="center">
                  <template slot-scope="scope">
                    <el-input v-model="scope.row.INT_NAME"></el-input>
                  </template>
                </el-table-column>
                <el-table-column prop="INT_ADDRESS" label="地址" width="280px" align="center">
                  <template slot-scope="scope">
                    <el-input type="textarea" :rows="2" v-model="scope.row.INT_ADDRESS"></el-input>
                  </template>
                </el-table-column>
                <el-table-column prop="INT_PARAMETERS" label="参数" width="200px" align="center">
                  <template slot-scope="scope">
                    <el-input type="textarea" :rows="2" v-model="scope.row.INT_PARAMETERS"></el-input>
                  </template>
                </el-table-column>
                <el-table-column prop="INT_ENABLE" label="是否启用" width="80px" align="center">
                  <template slot-scope="scope">
                    <el-switch
                      v-model="scope.row.INT_ENABLE"
                      :inactive-value="0"
                      :active-value="1"
                      active-color="#13ce66"
                      inactive-color="#ff4949"
                    ></el-switch>
                  </template>
                </el-table-column>
                <el-table-column label="操作" width="50px" align="center">
                  <template slot-scope="scope">
                    <el-button
                      size="mini"
                      type="danger"
                      icon="el-icon-minus"
                      class="medConfigDivDelete"
                      style="width:30px"
                      @click="deleteInterfaceRow(scope.$index, scope.row)"
                    ></el-button>
                  </template>
                </el-table-column>
              </el-table>
            </el-form-item>
            <br>
            <!-- <el-form-item label="麻醉交班用药配置">
              <el-tooltip placement="top">
                <div slot="content">请以英文逗号分隔,如(例如：舒芬太尼,瑞芬太尼,芬太尼,氨茶碱)</div>
                <el-input
                  placeholder="请输入内容"
                  v-model="MedConfig.AnesShiftDrugList"
                  style="width:400px;"
                ></el-input>
              </el-tooltip>
            </el-form-item> -->
            <!-- 必须设定像素,否则换行 -->
            <!-- <br>
            <el-form-item label="麻醉交班急诊患者显示行数配置">
              <el-tooltip placement="top">
                <div slot="content">请输入数量</div>
                <el-input-number
                  v-model="MedConfig.AnesShiftEmergencyPatCount"
                  :precision="0"
                  :step="1"
                  :min="1"
                  :max="10"
                ></el-input-number>
              </el-tooltip>
            </el-form-item> -->
          </el-form>
        </el-tab-pane>
        <el-tab-pane style="min-height:700px;" label="文书">
          <el-form :inline="true" label-position="right" class="demo-form-inline">
            <el-form-item label="麻醉单每页显示的小时数">
              <el-tooltip placement="top">
                <div slot="content">说明：麻醉单每页显示的小时数</div>
                <el-input-number
                  v-model="MedConfig.AnesDocPageHours"
                  :min="1"
                  :max="10"
                  label="描述文字"
                ></el-input-number>
              </el-tooltip>
            </el-form-item>
            <!-- <el-form-item label="诱导室名称" v-show="fasle">
              <el-input v-model="MedConfig.YouDaoRoomTitle" placeholder="诱导室名称" ></el-input>
            </el-form-item>-->
            <!-- <el-form-item label="麻醉编号">
              <el-tooltip placement="top">
                <div slot="content">说明：麻醉单上显示的起始麻醉编号</div>
                <el-input-number v-model="MedConfig.AnesthesiaNumber" :min="1" label="麻醉编号"></el-input-number>
              </el-tooltip>
            </el-form-item> -->
            <br>
            <el-form-item label="持续用药自动结束">
              <el-tooltip placement="top">
                <div slot="content">说明：持续用药是否自动结束</div>
                <el-switch v-model="MedConfig.DrugAutoStop"></el-switch>
              </el-tooltip>
            </el-form-item>

            <el-form-item label="持续用药自动结束时的手术状态">
              <el-tooltip placement="top">
                <div slot="content">说明：持续用药持续到哪个时间点自动结束</div>
                <el-select v-model="MedConfig.DrugAutoStopOperationStatus" placeholder="请选择">
                  <el-option
                    style="font-size:14px;padding:0px 5px;"
                    v-for="item in DrugAutoStopOperationStatusItems"
                    :key="item.value"
                    :label="item.label"
                    :value="item.value"
                  ></el-option>
                </el-select>
              </el-tooltip>
            </el-form-item>

            <br>
            <el-form-item label="用药控件单点用药显示类型">
              <!-- :disabled="true" autosize  type="textarea" -->
              <el-input
                placeholder="请输入内容"
                v-model="DrugShow_show"
                :readonly="true"
                style="width:350px;"
              ></el-input>

              <el-button type="primary" class="medConfigDivAdd" @click="TypeSet(1)">点击设置</el-button>
              <el-tooltip placement="top">
                <div slot="content">说明：设置麻醉单中单点用药的显示格式</div>
                <i style="font-size:20px;" class="el-icon-question"></i>
              </el-tooltip>
            </el-form-item>
            <br>
            <el-form-item label="用药控件持续用药显示类型">
              <el-input
                placeholder="请输入内容"
                v-model="ProLonged_show"
                :readonly="true"
                style="width:350px;"
              ></el-input>
              <el-button type="primary" class="medConfigDivAdd" @click="TypeSet(2)">点击设置</el-button>
              <el-tooltip placement="top">
                <div slot="content">说明：设置麻醉单中持续用药的显示格式</div>
                <i style="font-size:20px;" class="el-icon-question"></i>
              </el-tooltip>
            </el-form-item>
            <br>
            <el-form-item label="药品名称">
              <el-input
                placeholder="请输入内容"
                v-model="DrugLegend_show"
                :readonly="true"
                style="width:350px;"
              ></el-input>
              <el-button type="primary" class="medConfigDivAdd" @click="TypeSet(3)">点击设置</el-button>
              <el-tooltip placement="top">
                <div slot="content">说明：设置麻醉单中用药药名的显示格式</div>
                <i style="font-size:20px;" class="el-icon-question"></i>
              </el-tooltip>
            </el-form-item>

            <br>
            <!-- 新增下拉用于选择输血输液显示类型 -->
            <el-form-item label="输血输液显示类型">
              <el-tooltip placement="top">
                <div slot="content">说明：设置麻醉单中输液和输血的显示格式</div>
                <el-select v-model="MedConfig.BloodLiquidShow" placeholder="请选择">
                  <el-option
                    style="font-size:14px;padding:0px 5px;"
                    v-for="item in BloodLiquidShowItems"
                    :key="item.value"
                    :label="item.label"
                    :value="item.value"
                  ></el-option>
                </el-select>
              </el-tooltip>
            </el-form-item>
            <br>
            <br>
            <el-form-item label="文书完整性检查清单" class="mdsdCheckBoxNoBorder">
              <label slot="label">
                文书完整性检查清单
                <el-tooltip placement="top">
                  <div slot="content">说明：设置哪些文书需要进行完整性检查</div>
                  <i style="font-size:20px;" class="el-icon-question"></i>
                </el-tooltip>
              </label>
              <el-checkbox-group class="docCheckAll" v-model="MedConfig.DocNameCheckList">
                <el-checkbox
                  style="width:150px;"
                  v-for="doc in allDocs"
                  :label="doc"
                  :key="doc"
                >{{doc}}</el-checkbox>
              </el-checkbox-group>
            </el-form-item>
            <!-- <el-form-item label>
              <el-tooltip placement="top">
                <div slot="content">说明：设置哪些文书需要进行完整性检查</div>
                <i style="font-size:20px;" class="el-icon-question"></i>
              </el-tooltip>
            </el-form-item> -->
            <br>
          </el-form>
        </el-tab-pane>
        <el-tab-pane style="min-height:700px;" label="打印上传">
          <el-form :inline="true" label-position="right" class="demo-form-inline">
            <el-form-item label="PDF本地生成地址">
              <el-tooltip placement="top">
                <div slot="content">说明：设置麻醉信息工作站中生成PDF的目录地址(如:D:\PDF\)</div>
                <!-- 必须设定像素,否则换行 -->
                <el-input v-model="MedConfig.PDFLocalUrl" style="width:200px" label="PDF本地生成地址"></el-input>
              </el-tooltip>
            </el-form-item>
            <el-form-item label="PDF上传服务器地址">
              <el-tooltip placement="top">
                <div slot="content">说明：设置PDF上传的服务器目录地址</div>
                <el-input v-model="MedConfig.PDFServerUrl" style="width:250px" label="PDF上传服务器地址"></el-input>
              </el-tooltip>
            </el-form-item>

            <el-form-item label="文书上传后删除本地文件">
              <el-tooltip placement="top">
                <div slot="content">说明：设置PDF上传后是否删除本地的PDF文件</div>
                <el-switch v-model="MedConfig.IsDeleteAfterCommitDoc"></el-switch>
              </el-tooltip>
            </el-form-item>
            <br>
            <el-form-item label="文书上传列表" class="mdsdCheckBoxNoBorder">
              <label slot="label">
                文书上传列表
                <el-tooltip placement="top">
                  <div slot="content">设置哪些文书需要上传</div>
                  <i style="font-size:20px;" class="el-icon-question"></i>
                </el-tooltip>
              </label>
              <el-checkbox-group class="docCheckAll" v-model="MedConfig.PostPDF_Names">
                <el-checkbox
                  style="width:150px;"
                  v-for="doc in allDocs"
                  :label="doc"
                  :key="doc"
                >{{doc}}</el-checkbox>
              </el-checkbox-group>
            </el-form-item>
            <!-- <el-form-item label>
              <el-tooltip placement="top">
                <div slot="content">设置哪些文书需要上传</div>
                <i style="font-size:20px;" class="el-icon-question"></i>
              </el-tooltip>
            </el-form-item> -->
            <br>
            <el-form-item label="支持自动归档">
              <el-tooltip placement="top">
                <div slot="content">说明：设置是否要自动上传PDF文件</div>
                <el-switch v-model="MedConfig.IsAutomaticArchiving"></el-switch>
              </el-tooltip>
            </el-form-item>
            <el-form-item label="自动归档期限">
              <el-tooltip placement="top">
                <div slot="content">说明：设置过多久以后自动上传PDF文件</div>
                <el-input-number
                  v-model="MedConfig.ArchivOperAfterDay"
                  :min="1"
                  :max="100"
                  label="自动归档期限"
                ></el-input-number>
              </el-tooltip>&nbsp;&nbsp;&nbsp;小时
            </el-form-item>
            <br>
            <!-- 新增需要双面打印的文书 构思1-->
            <el-form-item label="需要双面打印的文书">
              &nbsp;第一组：
              <el-select v-model="DoublePrintDoc1" placeholder="请选择" @change="selectDoubleDoc()">
                <el-option
                  style="font-size:14px;padding:0px 5px;"
                  v-for="item in allDocs1"
                  :key="item"
                  :label="item"
                  :value="item"
                ></el-option>
              </el-select>&nbsp;
              <el-select v-model="DoublePrintDoc2" placeholder="请选择" @change="selectDoubleDoc()">
                <el-option
                  style="font-size:14px;padding:0px 5px;"
                  v-for="item in allDocs2"
                  :key="item"
                  :label="item"
                  :value="item"
                ></el-option>
              </el-select>

              <el-button type="primary" class="medConfigDivAdd" @click="ClearDoubleDocs(1)">清空</el-button>
              <el-tooltip placement="top">
                <div slot="content">说明：设置哪两个文件可以一起双面打印出来</div>
                <i style="font-size:20px;" class="el-icon-question"></i>
              </el-tooltip>

              <br>&nbsp;第二组：
              <el-select v-model="DoublePrintDoc3" placeholder="请选择" @change="selectDoubleDoc()">
                <el-option
                  style="font-size:14px;padding:0px 5px;"
                  v-for="item in allDocs3"
                  :key="item"
                  :label="item"
                  :value="item"
                ></el-option>
              </el-select>&nbsp;
              <el-select v-model="DoublePrintDoc4" placeholder="请选择" @change="selectDoubleDoc()">
                <el-option
                  style="font-size:14px;padding:0px 5px;"
                  v-for="item in allDocs4"
                  :key="item"
                  :label="item"
                  :value="item"
                ></el-option>
              </el-select>
              <el-button type="primary" class="medConfigDivAdd" @click="ClearDoubleDocs(2)">清空</el-button>
              <br>&nbsp;第三组：
              <el-select v-model="DoublePrintDoc5" placeholder="请选择" @change="selectDoubleDoc()">
                <el-option
                  style="font-size:14px;padding:0px 5px;"
                  v-for="item in allDocs5"
                  :key="item"
                  :label="item"
                  :value="item"
                ></el-option>
              </el-select>&nbsp;
              <el-select v-model="DoublePrintDoc6" placeholder="请选择" @change="selectDoubleDoc()">
                <el-option
                  style="font-size:14px;padding:0px 5px;"
                  v-for="item in allDocs6"
                  :key="item"
                  :label="item"
                  :value="item"
                ></el-option>
              </el-select>
              <el-button type="primary" class="medConfigDivAdd" @click="ClearDoubleDocs(3)">清空</el-button>
            </el-form-item>
            <br>
            <!-- 新增需要双面打印的文书 构思2-->
            <!-- allow-create filterable -->
            <el-form-item label="需要双面打印的文书：" v-show="false">
              <el-select
                v-model="DoublePrintDocs"
                multiple
                remote
                reserve-keyword
                clearable
                :filterable="true"
                placeholder="请选择需要双面打印的文书"
                style="width:575px;"
                @visible-change="selectDoubleDoc2"
              >
                <el-option
                  style="font-size:14px;padding:0px 5px;"
                  v-for="(item, index) in allDocsNew"
                  :key="index"
                  :label="item"
                  :value="item"
                ></el-option>
              </el-select>
              <el-button type="primary" class="medConfigDivAdd" @click="ClearDoubleDocs2()">清空</el-button>
            </el-form-item>
            <el-form-item label="打印纸张">
              <!-- <el-input v-model="MedConfig.PrintPageName" :min="1" :max="100" label="打印张数"></el-input> -->
              <el-select
                v-model="MedConfig.PrintPageName"
                placeholder="请选择"
                @change="printPageNameSelect(MedConfig.PrintPageName)"
              >
                <el-option
                  style="font-size:14px;padding:0px 5px;"
                  v-for="item in PrintPageNameItems"
                  :key="item.value"
                  :label="item.label"
                  :value="item.value"
                ></el-option>
              </el-select>
              <el-tooltip placement="top">
                <div slot="content">说明：设置文书打印纸张大小</div>
                <i style="font-size:20px;" class="el-icon-question"></i>
              </el-tooltip>
            </el-form-item>
            <br>
            <el-form-item label="打印纸张长度">
              <el-input-number v-model="MedConfig.PrintPaperHeight" :max="50" label="打印纸张长度"></el-input-number>&nbsp;&nbsp;&nbsp;cm
            </el-form-item>

            <el-form-item label="打印纸张宽度">
              <el-input-number v-model="MedConfig.PrintPaperWidth" :max="50" label="打印纸张宽度"></el-input-number>&nbsp;&nbsp;&nbsp;cm
            </el-form-item>
            <br>
            <el-form-item label="打印纸张左侧预留">
              <el-input-number v-model="MedConfig.PaperLeftOff" :max="20" label="打印纸张左侧预留"></el-input-number>&nbsp;&nbsp;&nbsp;cm
            </el-form-item>
            <el-form-item label="打印纸张上方预留">
              <el-input-number v-model="MedConfig.PaperTopOff" :max="20" label="打印纸张上方预留"></el-input-number>&nbsp;&nbsp;&nbsp;cm
            </el-form-item>
          </el-form>
        </el-tab-pane>
        <el-tab-pane style="min-height:700px;" label="快捷键">
          <!-- 键盘key:<el-input v-model="input" placeholder="请输入键盘key" style="width:250px;"></el-input>
          对应功能：<el-input v-model="input" placeholder="请输入对应功能" style="width:250px;"></el-input>-->
          <el-button @click="addKeyValue" type="primary" class="medConfigDivAdd">添加行</el-button>

          <el-table :data="MedConfig.ShortCuts" style="width: 100%;margin-bottom: 5px">
            <el-table-column label="键盘KEY">
              <template slot-scope="scope">
                <el-input v-model="scope.row.Key"></el-input>
              </template>
            </el-table-column>
            <el-table-column label="对应功能">
              <template slot-scope="scope">
                <el-input v-model="scope.row.Value"></el-input>
              </template>
            </el-table-column>
            <el-table-column label="操作">
              <template slot-scope="scope">
                <el-button
                  size="small"
                  type="danger"
                  icon="el-icon-minus"
                  class="medConfigDivDelete"
                  @click="deleteKeyValue(scope.$index, scope.row)"
                ></el-button>
              </template>
            </el-table-column>
          </el-table>
        </el-tab-pane>
      </el-tabs>
    </div>
  </div>
</template>

<script>
import MedConfig from './MedConfig.js'
export default MedConfig
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";

.medConfigDiv {
  margin-top: 5px;
  padding: 10px 0px;
  background-color: #f5f9fb;
  font-size: 14px;
  color: #606266;
  min-height: 768px;
  .medConfigDivAdd {
    width: 99px;
    height: 28px;
    background: rgba(61, 209, 138, 1);
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 0px 10px;
  }

  .medConfigDivEdit {
    width: 59px;
    height: 28px;
    //background: #d0dfe6;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 5px;
  }

  .medConfigDivDelete {
    width: 59px;
    height: 28px;
    background: #f56c6c;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 5px;
  }
  .docCheckAll {
    width: 100%;
    margin-left: 80px;
  }

  .report-main-top-wrapper {
    height: 2px;
    margin-top: 15px;
    background: linear-gradient(
      90deg,
      rgba(36, 197, 240, 1),
      rgba(103, 245, 184, 1)
    );
  }
}

@media screen and (min-aspect-ratio: 1001/1000) {
  /* 横屏 */
}

@media screen and (max-aspect-ratio: 1000/1000) {
  /* 竖屏 */
  .medConfigDiv {
    .docCheckAll {
      width: 100%;
      margin-left: 40px;
    }
  }
}
</style>
<style>
.medConfigDiv .el-input__inner {
  -webkit-appearance: none;
  background-color: #f7f7f7;
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
  font-size: 12px;
}
.medConfigDiv .el-input__icon {
  line-height: 25px;
}
.medConfigDiv .el-button {
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
  padding: 6px 0px;
  font-size: 14px;
  border-radius: 4px;
}

.medConfigDiv .el-table th {
  padding: 0;
}

.medConfigDiv .el-table td {
  padding: 4px 0;
}

.medConfigDiv .el-input-number {
  line-height: 24px;
}

.medConfigDiv .el-select-dropdown__list {
  padding: 0px 10px;
}
.medConfigDiv .el-radio__input {
  padding-left: 15px;
}

.medConfigDiv ::-webkit-input-placeholder {
  font-style: italic;
}

.medConfigDiv .mdsdCheckBoxNoBorder .el-checkbox__inner {
  width: 16px;
  height: 16px;
}

.medConfigDiv .mdsdCheckBoxNoBorder .el-checkbox__inner::after {
  height: 9px;
  left: 5px;
}

@media screen and (min-aspect-ratio: 1001/1000) {
  /* 横屏 */
  .medConfigDiv .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    width: 200px;
    line-height: 30px;
  }
}

@media screen and (max-aspect-ratio: 1000/1000) {
  /* 竖屏 */
  .medConfigDiv .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    line-height: 30px;
  }
}
</style>
