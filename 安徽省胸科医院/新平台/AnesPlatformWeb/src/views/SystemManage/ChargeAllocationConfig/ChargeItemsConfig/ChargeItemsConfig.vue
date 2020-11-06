<template>
  <div class="ChargeItemsConfigDiv">
    <!-- 编辑、新增 弹窗 -->
    <el-dialog
      :title="dialogEditTitle"
      :visible.sync="dialogEditVisible"
      :close-on-click-modal="false"
    >
      <el-form :model="formData" :rules="rules" ref="formView" inline label-width="80px">
        <el-form-item label="编号" prop="ITEM_CODE" v-show="wayType===1?true:false">
          <el-input v-model="formData.ITEM_CODE" :maxlength="10" disabled></el-input>
        </el-form-item>
        <el-form-item label="术中项目" prop="ITEM_NAME">
          <el-input v-model="formData.ITEM_NAME" :maxlength="20" placeholder="请输入术中项目" clearable></el-input>
        </el-form-item>
        <el-form-item label="单位数量" prop="ITEM_SPEC">
          <el-input v-model.number="formData.ITEM_SPEC" clearable placeholder="请输入单位数量"></el-input>
        </el-form-item>
        <el-form-item label="单位">
          <!-- allow-create表示可以手写单位输入,当然希望在单位字典表里添加所需单位 -->
          <el-select v-model="formData.UNITS" clearable filterable allow-create>
            <!-- 从字典数据中直接获取下拉 -->
            <el-option
              v-for="item in unitData"
              :key="item.UNIT_CODE"
              :label="item.UNIT_NAME"
              :value="item.UNIT_NAME"
            ></el-option>
          </el-select>
          <!-- <span style="color:#F56C6C;">(建议：新单位请在右侧"基础数据管理"里的"单位字典维护"中添加)</span> -->
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button type="primary" class="ChargeItemsConfigDivSave" @click="onSubmit('formView')">保 存</el-button>&nbsp;&nbsp;&nbsp;&nbsp;
        <el-button
          type="primary"
          class="ChargeItemsConfigDivSave"
          @click="dialogEditVisible = false"
        >取 消</el-button>
      </div>
    </el-dialog>

    <!-- 计费规则弹窗 -->
    <el-dialog
      :title="dialogRefDetailTitle"
      :visible.sync="dialogRefDetailVisible"
      :close-on-click-modal="false"
    >
      <el-form :model="refData" :rules="refDetailRules" ref="refDetailView" :inline="false">
        <el-form-item prop="BILL_INDICATOR">
          <span>启用自动划价规则：</span>
          <el-switch
            v-model="refData.BILL_INDICATOR"
            active-value="T"
            inactive-value="F"
            @change="switchChange"
          ></el-switch>
        </el-form-item>

        <el-form-item v-show="refData.BILL_INDICATOR==='T'?true:false">
          <el-form-item label="计费方式：" label-width="100px" prop="METHOD">
            <el-radio-group v-model="refData.METHOD" @change="rulesChange">
              <el-radio label="1" border>按时长</el-radio>
              <el-radio label="2" border>按数量</el-radio>
              <el-radio label="3" border>按剂量</el-radio>
            </el-radio-group>
          </el-form-item>

          <!-- 写成字符串的1比较好识别，写成数字1可能第一次点击radioButton不成功 -->
          <!-- 1-按时长 -->
          <el-form-item v-show="refData.METHOD==='1'?true:false">
            <!-- 计费规则 -->

            <el-form-item style="margin:20px;" label="计费规则：" prop="SPEC" label-width="100px">
              <span>收取</span>
              <!-- v-model.number输入配合rules进行验证 -->
              <el-input
                v-model.number="refData.SPEC"
                :maxlength="3"
                style="width:80px;"
                clearable
                placeholder="请输入"
              ></el-input>
              <span>%</span>
            </el-form-item>

            <!-- 基础时长允许小数，小数点占一位 -->

            <el-form-item style="margin:20px;" label="基础时长：" prop="BASE_TIME" label-width="100px">
              <el-input
                v-model.number="refData.BASE_TIME"
                :maxlength="4"
                style="width:80px;"
                clearable
                placeholder="请输入"
              ></el-input>
              <span>小时</span>
            </el-form-item>

            <!-- 超时加收 -->

            <el-form-item
              style="margin:20px;"
              label="超时加收："
              prop="ITEM_CODE_ADD"
              label-width="100px"
            >
              <!-- 带清空功能的下拉 -->
              <el-select v-model="refData.ITEM_CODE_ADD" clearable filterable style="width:400px;">
                <el-option
                  v-for="item in tempTimeoutChargeOptions"
                  :key="item.value"
                  :label="item.label"
                  :value="item.value"
                ></el-option>
              </el-select>
            </el-form-item>
          </el-form-item>
          <!-- 2-按数量 -->
          <el-form-item v-show="refData.METHOD==='2'?true:false">
            <!-- 计费规则 -->

            <el-form-item style="margin:20px;" label="计费规则：" prop="SPEC" label-width="100px">
              <span>收取</span>
              <el-input
                v-model.number="refData.SPEC"
                :maxlength="3"
                style="width:80px;"
                clearable
                placeholder="请输入"
              ></el-input>
              <span>%</span>
            </el-form-item>
          </el-form-item>
          <!-- 3-按剂量 -->
          <el-form-item v-show="refData.METHOD==='3'?true:false">
            <!-- 计费规则 -->

            <el-form-item style="margin:20px;" label="计费规则：" prop="SPEC" label-width="100px">
              <span>收取</span>
              <el-input
                v-model.number="refData.SPEC"
                :maxlength="3"
                style="width:80px;"
                clearable
                placeholder="请输入"
              ></el-input>
              <span>%</span>
            </el-form-item>

            <!-- 基础规格 -->

            <el-form-item style="margin:20px;" label="基础规格：" prop="BASE_TIME" label-width="100px">
              <!-- 基础规格数量 -->
              <el-input
                v-model.number="refData.BASE_TIME"
                :maxlength="4"
                style="width:100px;"
                placeholder="输入数量"
                clearable
              ></el-input>
              <!-- 基础单位 -->
              <el-select
                v-model="refData.BASE_UNIT"
                clearable
                style="width:120px;"
                placeholder="选择单位"
                filterable
                allow-create
              >
                <el-option
                  v-for="item in unitData"
                  :key="item.UNIT_CODE"
                  :label="item.UNIT_NAME"
                  :value="item.UNIT_NAME"
                ></el-option>
              </el-select>
              <span style="color:#F56C6C;">(填写后，将以此规格为标准)</span>
            </el-form-item>
          </el-form-item>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button
          type="primary"
          class="ChargeItemsConfigDivSave"
          @click="onSubmit('refDetailView')"
        >保 存</el-button>&nbsp;&nbsp;&nbsp;&nbsp;
        <el-button
          type="primary"
          class="ChargeItemsConfigDivSave"
          @click="dialogRefDetailVisible = false"
        >取 消</el-button>
      </div>
    </el-dialog>

    <!-- 关系表弹窗 -->
    <el-dialog
      :title="dialogRefTitle"
      :visible.sync="dialogRefVisible"
      :close-on-click-modal="false"
    >
      <el-form :model="refData" :rules="refRules" ref="refView" inline label-width="80px">
        <el-form-item label="类别" prop="ITEM_CLASS">
          <template>
            <el-select v-model="refData.ITEM_CLASS" @change="priceClassChange">
              <!-- 直接从收费项目分类表价表相关数据做下拉 -->
              <el-option
                v-for="item in billDictData"
                v-bind:key="item.BILL_CLASS_CODE"
                :label="item.BILL_CLASS_NAME"
                :value="item.BILL_CLASS_CODE"
              ></el-option>
            </el-select>
          </template>
        </el-form-item>
        <el-form-item label="收费项目" prop="ITEM_NAME">
          <!-- 老版收费项目下拉框
            <template slot-scope="scope">
            <el-select v-model="refData.ITEM_NAME" @change="priceChargeChange" filterable>
              <el-option v-for="item in priceChargeOptions" :key="item.value" :label="item.label" :value="item.value"></el-option>
            </el-select>
          </template>-->

          <template>
            <!-- el-autocomplete 是一个可带输入建议的输入框组件 -->
            <!-- fetch-suggestions 是一个返回输入建议的方法属性 -->
            <!-- select 点击选中建议项时触发，传入选中的建议项 -->
            <!-- 根据拼音首字母检索 -->
            <el-autocomplete
              v-model="refData.ITEM_NAME"
              value-key="ITEM_NAME"
              :fetch-suggestions="querySearch"
              @select="handleSelect"
              placeholder="请输入内容"
              style="width:350px"
              :disabled="isAutoComDisabled"
              ref="elAutocom"
            ></el-autocomplete>
          </template>
        </el-form-item>
        <el-button
          circle
          type="primary"
          class="ChargeItemsConfigDivSave"
          icon="el-icon-edit"
          @click="editAutoComplete($event)"
        ></el-button>
        <el-form-item label="代码" prop="ITEM_CODE">
          <el-input v-model="refData.ITEM_CODE" :maxlength="20" disabled></el-input>
        </el-form-item>

        <el-form-item label="规格">
          <el-input v-model="refData.ITEM_SPEC" disabled></el-input>
        </el-form-item>
        <el-form-item label="单位">
          <el-input v-model="refData.UNITS" disabled></el-input>
        </el-form-item>
        <el-form-item label="价格">
          <el-input v-model="refData.PRICE" disabled></el-input>
        </el-form-item>
        <!-- 折扣即计费细则的计费规则 -->
        <el-form-item label="折扣" prop="SPEC">
          <!-- 设定内联样式，防止%号换行 -->
          <el-input
            v-model.number="refData.SPEC"
            :maxlength="4"
            clearable
            placeholder="请输入"
            style="width:180px;"
          ></el-input>
          <span>%</span>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button
          type="primary"
          class="ChargeItemsConfigDivSave"
          @click="onSubmit('refView')"
          :disabled="isDisabled"
        >保 存</el-button>&nbsp;&nbsp;&nbsp;&nbsp;
        <el-button
          type="primary"
          class="ChargeItemsConfigDivSave"
          @click="dialogRefVisible = false"
        >取 消</el-button>
      </div>
    </el-dialog>
    <el-row :gutter="20" type="flex" justify="center">
      <el-col :span="13">
        <div class="grid-content">
          <!-- 计价单表格 -->
          <div id="conditionView">
            <!-- 有对应的css -->
            <div class="conditiontitle">计价单</div>
            <br>
            <br>

            <div class="conditionRadioButton">
              <span style="font-size:20px;">请选择项目类型：</span>
              <!-- 老版静态处理 -->
              <!-- <el-radio-group v-model="chargeClass" @change="ItemClassChange">
                <el-radio-button :label="1"> 麻醉 </el-radio-button>
                <el-radio-button :label="2"> 药品 </el-radio-button>
                <el-radio-button :label="3"> 其他 </el-radio-button>
              </el-radio-group>-->

              <!-- 动态生成RadioButton -->
              <el-radio-group v-model="chargeClass" @change="ItemClassChange">
                <el-radio-button
                  :label="item.BILL_CLASS_CODE"
                  v-for="item in billRadioDict"
                  :key="item.BILL_CLASS_CODE"
                >{{item.BILL_CLASS_NAME}}</el-radio-button>
              </el-radio-group>
            </div>
            <!-- 2个按钮 -->
            <div style="float: right;margin-bottom: 10px;">
              <el-button
                type="primary"
                class="ChargeItemsConfigDivAdd"
                @click="addData"
                style="margin-right: 10px"
              >新增</el-button>
            </div>
          </div>
          <el-table
            :data="paginationInfo.currentData"
            v-loading="loading"
            element-loading-text="拼命加载中"
            border
            style="width: 100%"
          >
            <!-- 表格列的width属性用于确定特殊列的宽度，剩余列自动匹配 -->
            <el-table-column prop="ITEM_CODE" header-align="center" align="center" label="编号"></el-table-column>

            <el-table-column prop="ITEM_NAME" header-align="center" align="center" label="术中项目"></el-table-column>>
            <el-table-column
              prop="ITEM_SPEC"
              width="80px"
              header-align="center"
              align="center"
              label="单位数量"
            ></el-table-column>

            <el-table-column
              prop="UNITS"
              width="80px"
              header-align="center"
              align="center"
              label="单位"
            ></el-table-column>

            <el-table-column min-width="170px" label="操作" align="center" fixed="right">
              <template slot-scope="scope">
                <!-- el-button-group 用于将按钮之间的界限缩小 -->
                <div style="display:flex;">
                  <el-button
                    class="ChargeItemsConfigDivEdit"
                    @click="editData(scope.$index, scope.row)"
                  >编辑</el-button>
                  <el-button
                    type="primary"
                    class="ChargeItemsConfigDivDelete"
                    @click="deleteData(scope.$index, scope.row,'valuationItemList')"
                  >删除</el-button>
                  <el-button
                    type="primary"
                    class="ChargeItemsConfigDivAdd"
                    @click="configuration(scope.$index, scope.row)"
                  >关联配置</el-button>
                </div>
              </template>
            </el-table-column>
          </el-table>

          <!-- 表示统计多少页 -->
          <div id="PaginationView">
            <el-pagination
              :current-page="paginationInfo.currentPage"
              :page-size="paginationInfo.pageSize"
              layout="total, prev, pager, next"
              :total="paginationInfo.total"
              @current-change="handleCurrentChange"
            ></el-pagination>
          </div>
        </div>
      </el-col>
      <el-col :span="11">
        <div class="grid-content" v-show="isRefShow==='true'?true:false">
          <!-- 关系表 -->
          <div>
            <div
              style="font-size:25px;color:red;font-weight: bolder;margin-left:10px;margin-bottom:50px;"
            >{{'['+itemCode+']'+itemName}}</div>
            <div style="margin-bottom:10px;">
              <span style="font-size:20px;font-weight: bolder;margin-left:10px;">关联收费项目</span>

              <el-button
                type="primary"
                class="ChargeItemsConfigDivAdd"
                style="float:right;margin-top:-10px;margin-right:10px;"
                @click="addRefData"
              >新增</el-button>
              <el-button
                type="primary"
                class="ChargeItemsConfigDivAdd"
                style="float:right;margin-top:-10px;margin-right:10px;"
                @click="saveRefData"
              >保存</el-button>
            </div>
          </div>

          <el-table :data="vtvsChargeInfo" v-loading="loading" element-loading-text="拼命加载中" border>
            <!-- 注：关系表里并没有ITEM_CLASS_NAME这个字段，它只是用于中文显示类别名字 -->
            <el-table-column prop="ITEM_CLASS_NAME" header-align="center" align="center" label="类别"></el-table-column>
            <el-table-column prop="ITEM_CODE" header-align="center" align="center" label="代码"></el-table-column>
            <el-table-column prop="ITEM_NAME" header-align="center" align="center" label="收费项目"></el-table-column>
            <el-table-column prop="ITEM_SPEC" header-align="center" align="center" label="规格"></el-table-column>
            <el-table-column prop="UNITS" header-align="center" align="center" label="单位"></el-table-column>
            <el-table-column prop="PRICE" header-align="center" align="center" label="价格"></el-table-column>
            <!-- :formatter="discountFormatter" 格式化该列，加上百分号,只有没有template时有用 -->
            <el-table-column
              prop="SPEC"
              header-align="center"
              align="center"
              label="折扣(%)"
              width="100px"
            >
              <template slot-scope="scope">
                <el-input v-model="scope.row.SPEC" clearable></el-input>
              </template>
            </el-table-column>
            <!-- width="160px" 操作有两个按钮时的间距 -->
            <el-table-column label="操作" align="center" fixed="right">
              <template slot-scope="scope">
                <!-- el-button-group 用于将按钮之间的界限缩小 -->
                <!-- <el-button-group> -->
                <!-- 目前暂时不需要计费细则，先隐藏 -->
                <!-- <el-button size="mini" @click="editBillRule(scope.$index, scope.row)" v-show="false">计费细则</el-button> -->
                <!-- <el-button size="mini" type="danger" @click="deleteData(scope.$index, scope.row,'anesVsCharge')">删除</el-button> -->
                <!-- </el-button-group> -->
                <el-button
                  size="mini"
                  type="primary"
                  class="ChargeItemsConfigDivDelete"
                  @click="deleteData(scope.$index, scope.row,'anesVsCharge')"
                >删除</el-button>
              </template>
            </el-table-column>
          </el-table>
        </div>
      </el-col>
    </el-row>
  </div>
</template>

<script>
import ChargeItemsConfig from './ChargeItemsConfig.js'
export default ChargeItemsConfig
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";

.ChargeItemsConfigDiv {
  margin-top: 5px;
  padding: 10px 0px;
  background-color: #ffffff;
  font-size: 14px;
  color: #606266;
  min-height: 768px;

  .ChargeItemsConfigDivAdd {
    width: 99px;
    height: 28px;
    background: rgba(61, 209, 138, 1);
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 5px;
  }

  .ChargeItemsConfigDivEdit {
    width: 59px;
    height: 28px;
    //background: #d0dfe6;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 5px;
  }

  .ChargeItemsConfigDivDelete {
    width: 59px;
    height: 28px;
    background: #f56c6c;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 5px;
  }
  .ChargeItemsConfigDivSave {
    width: 99px;
    height: 28px;
    background: rgba(0, 188, 241, 1);
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 0px 0px 0px 10px;
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

  .czCss {
    display: flex;
    flex-direction: row;
    margin-left: 40px;
  }

  .conditionName {
    width: 50px;
    float: left;
    text-align: right;
    height: 26px;
    line-height: 26px;
    font-weight: bolder;
    margin-left: 10px;
  }

  .dialog-footer {
    text-align: center;
  }
  /* text-align 对应文字的对齐方向 */
  #conditionView .conditiontitle {
    width: 150px;
    float: none;
    text-align: left;
    height: 36px;
    line-height: 36px;
    font-weight: bolder;
    font-size: 35px;
    margin-left: 10px;
    margin-bottom: 10px;
  }
  #conditionView .conditionRadioButton {
    float: left;
    margin: 0px 0px 10px 25px;
    line-height: 26px;
  }

  #funView {
    clear: both;
    text-align: right;
  }

  #dataView {
    margin-top: 5px;
  }

  #PaginationView {
    text-align: center;
  }
  /* 以下为计价单和关系表布局样式 */
  .el-row {
    margin-top: 15px;
    width: 100%; /*如果不设定这项，则会出现底部的滚动条*/
  }

  .grid-content {
    border-radius: 7px;
  }
}

@media screen and (min-aspect-ratio: 1001/1000) {
  // 横屏
}

@media screen and (max-aspect-ratio: 1000/1000) {
  // 竖屏
  .ChargeItemsConfigDiv {
    .ChargeItemsConfigDivEdit {
      margin: 5px 2px;
    }
    .ChargeItemsConfigDivDelete {
      margin: 5px 2px;
    }
    .czCss {
      margin-left: 0px;
    }
    .conditionName {
      margin-left: 10px;
    }
  }
}
</style>
<style>
.ChargeItemsConfigDiv .el-input__inner {
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
.ChargeItemsConfigDiv .el-input__icon {
  line-height: 25px;
}
.ChargeItemsConfigDiv .el-button {
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

.ChargeItemsConfigDiv .el-table th {
  padding: 6px 0;
}

.ChargeItemsConfigDiv .el-table td {
  padding: 4px 0;
}

.ChargeItemsConfigDiv .el-input-number {
  line-height: 24px;
}

.ChargeItemsConfigDiv .el-select-dropdown__list {
  padding: 0px 10px;
}

.ChargeItemsConfigDiv .el-radio-button__orig-radio + .el-radio-button__inner {
  line-height: 10px;
}

.ChargeItemsConfigDiv .el-radio-button__inner {
  padding: 10px 20px;
}

.ChargeItemsConfigDiv
  .el-radio-button__orig-radio:checked
  + .el-radio-button__inner {
  background-color: rgba(61, 209, 138, 1);
  border-color: rgba(61, 209, 138, 1);
  line-height: 10px;
}

.ChargeItemsConfigDiv ::-webkit-input-placeholder {
  font-style: italic;
}

@media screen and (min-aspect-ratio: 1001/1000) {
  /* 横屏 */
  .ChargeItemsConfigDiv .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    width: 200px;
  }
}

@media screen and (max-aspect-ratio: 1000/1000) {
  /* 竖屏 */
  .ChargeItemsConfigDiv .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    width: 110px;
  }
}
</style>
