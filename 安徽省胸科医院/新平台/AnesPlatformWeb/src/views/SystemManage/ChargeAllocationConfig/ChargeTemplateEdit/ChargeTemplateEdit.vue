<template>
  <div class="ChargeTemplateEditDiv">
    <el-dialog
      :title="dialogEditTitle"
      :visible.sync="dialogEditVisible"
      :close-on-click-modal="false"
    >
      <span style="font-size:16px;">{{this.currentMenu}}</span>
      <span style="font-size:16px;">>{{this.currentTemplete}}</span>
      <div style="height:30px;"></div>
      <el-form :model="formData" :rules="rules" ref="formView" :inline="true" label-width="80px">
        <el-form-item label="类型" prop="ITEM_CLASS">
          <el-select
            v-model="formData.ITEM_CLASS"
            @change="SelItemClass(formData.ITEM_CLASS)"
            placeholder="请选择"
            style="width:185px"
          >
            <el-option
              style="font-size:14px;padding:0px 10px;"
              v-for="(item,index) in ItemTypeData"
              :key="index"
              :label="item.BILL_CLASS_NAME"
              :value="item.BILL_CLASS_CODE"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="项目" prop="ITEM_NAME">
          <el-select
            v-model="formData.ITEM_NAME"
            @change="SelEventCode(formData.ITEM_NAME)"
            filterable
            placeholder="请选择"
            style="width:185px"
          >
            <el-option
              style="font-size:14px;padding:0px 10px;"
              v-for="(item,index) in EventData"
              :key="index"
              :label="item.ITEM_NAME"
              :value="item.ITEM_NAME"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="单位数量">
          <el-input v-model="formData.ITEM_SPEC" style="width:185px"></el-input>
        </el-form-item>
        <el-form-item label="单位" prop="UNITS">
          <el-select v-model="formData.UNITS" placeholder="请选择" style="width:185px">
            <el-option
              style="font-size:14px;padding:0px 10px;"
              v-for="(item,index) in medUnitsList1"
              :key="index"
              :label="item.UNIT_NAME"
              :value="item.UNIT_NAME"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="数量" prop="AMOUNT">
          <el-input-number
            size="medium"
            v-model="formData.AMOUNT"
            :min="0"
            :max="9999"
            placeholder
            style="width:185px"
          ></el-input-number>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button
          type="primary"
          class="ChargeTemplateEditDivSave"
          @click="onSubmit('formView')"
          :disabled="isDisabled"
        >保 存</el-button>&nbsp;&nbsp;&nbsp;&nbsp;
        <el-button
          type="primary"
          class="ChargeTemplateEditDivSave"
          @click="dialogEditVisible = false"
        >取 消</el-button>
      </div>
    </el-dialog>
    <el-dialog :title="dialogTemplete" :visible.sync="dialogTempleteVisible">
      <el-form :model="formData" :rules="rules" ref="formView" :inline="true" label-width="80px">
        <br>
        <el-form-item label="模版分类">
          <el-select v-model="currentMenu" placeholder="请选择">
            <el-option
              style="font-size:14px;padding:0px 10px;"
              v-for="(item,index) in medAnesthesiaList"
              :key="index"
              :label="item.ANAESTHESIA_NAME"
              :value="item.ANAESTHESIA_NAME"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="模版名称">
          <el-input v-model="currentTemplete" placeholder="请输入模版名称"></el-input>
          <el-option
            style="font-size:14px;padding:0px 10px;"
            v-for="item in TempleteDta"
            :key="item.value"
            :label="item.label"
            :value="item.value"
          ></el-option>
        </el-form-item>
        <el-form-item>
          <el-button
            type="primary"
            class="ChargeTemplateEditDivSave"
            @click="onSubmitTemplete('formView')"
          >保 存</el-button>&nbsp;&nbsp;&nbsp;&nbsp;
        </el-form-item>
        <br>
        <br>
        <br>
        <br>
      </el-form>
    </el-dialog>
    <el-row style="margin-top:10px">
      <el-col :span="12">
        <el-button type="primary" class="ChargeTemplateEditDivAdd" @click="addTemplete()">新增模版</el-button>
        <el-button
          type="primary"
          class="ChargeTemplateEditDivDelete"
          @click="deleteTemplete"
          v-show="this.currentTemplete!=''"
        >删除模版</el-button>
      </el-col>
      <el-col :span="12" style=" text-align:right">
        <span style="font-size:16px;">{{this.currentMenu}}</span>
        <span style="font-size:16px;margin:0px 10px;">></span>
        <span style="font-size:16px; margin-right:50px">{{this.currentTemplete}}</span>
        <el-button
          type="primary"
          class="ChargeTemplateEditDivAdd"
          v-show="this.currentTemplete!=''"
          @click="addData"
          style="margin-right: 250px"
        >新增事件</el-button>
      </el-col>
    </el-row>
    <div style="background-color: #fff;min-height:600px;">
      <div class="report-main-top-wrapper"></div>
      <table width="100%">
        <tr style="vertical-align:top;">
          <td width="320px">
            <div
              v-bind:key="obj"
              v-for="obj in firstMenu"
              v-bind:class="currentMenu==obj?'menutitleOn':'menutitle'"
            >
              <div @click="SwitchMenu(obj)" class="menutitlesub">{{obj}}</div>
              <hr
                style="height:1px;border:none;border-top:1px dashed white;width:230px;margin:0px 35px;"
              >
              <div v-bind:class="currentMenu==obj?'submenuOn':'submenu'">
                <ul class="RecordList">
                  <li
                    @click="ShowTemplete(item.TEMPLET_NAME)"
                    v-bind:class="item.TEMPLET_NAME==currentTemplete?'DocSelected':'' "
                    v-bind:key="item.TEMPLET_NAME"
                    v-for="item in templetMenu.filter(t => t.ANESTHESIA_METHOD === obj)"
                  >
                    <a>{{item.TEMPLET_NAME}}</a>
                    <img
                      class="imageSelIcon"
                      v-show="item.TEMPLET_NAME==currentTemplete?true:false"
                    >
                  </li>
                </ul>
              </div>
            </div>
          </td>
          <td>
            <div style="margin-top:0px;">
              <div id="dataView">
                <el-table
                  :data="TempleteDta"
                  v-loading="loading"
                  element-loading-text="拼命加载中"
                  border
                  style="width: 100%"
                >
                  <el-table-column
                    prop="ITEM_CLASS"
                    header-align="center"
                    align="center"
                    label="类型"
                  >
                    <template slot-scope="scope">
                      <span>{{getItemClassName(scope.row.ITEM_CLASS)}}</span>
                    </template>
                  </el-table-column>
                  <el-table-column prop="ITEM_NAME" header-align="center" align="center" label="项目"></el-table-column>
                  <el-table-column
                    prop="ITEM_SPEC"
                    header-align="center"
                    width="120"
                    align="center"
                    label="单位数量"
                  ></el-table-column>
                  <el-table-column
                    prop="UNITS"
                    header-align="center"
                    width="60"
                    align="center"
                    label="单位"
                  ></el-table-column>
                  <el-table-column
                    prop="AMOUNT"
                    header-align="center"
                    width="60"
                    align="center"
                    label="数量"
                  ></el-table-column>
                  <el-table-column label="操作" header-align="center" width="200px" fixed="right">
                    <template slot-scope="scope">
                      <span class="czCss">
                        <el-button
                          class="ChargeTemplateEditDivEdit"
                          @click="editData(scope.$index, scope.row)"
                        >编辑</el-button>
                        <el-button
                          size="small"
                          type="danger"
                          class="ChargeTemplateEditDivDelete"
                          @click="deleteData(scope.$index, scope.row)"
                        >删除</el-button>
                      </span>
                    </template>
                  </el-table-column>
                </el-table>
              </div>
            </div>
          </td>
        </tr>
      </table>
    </div>
  </div>
</template>

<script>
import ChargeTemplateEdit from './ChargeTemplateEdit.js'
export default ChargeTemplateEdit
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";

.ChargeTemplateEditDiv {
  margin-top: 5px;
  padding: 10px 0px;
  background-color: #f5f9fb;
  font-size: 14px;
  color: #606266;
  min-height: 768px;

  .ChargeTemplateEditDivAdd {
    width: 99px;
    height: 28px;
    background: rgba(61, 209, 138, 1);
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 5px;
  }

  .ChargeTemplateEditDivEdit {
    width: 99px;
    height: 28px;
    //background: #d0dfe6;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 5px;
  }

  .ChargeTemplateEditDivDelete {
    width: 99px;
    height: 28px;
    background: #f56c6c;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 5px;
  }
  .ChargeTemplateEditDivSave {
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
    margin-left: 0px;
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

  #dataView {
    margin-top: 5px;
  }

  .menutitle {
    margin: 20px auto;
    background-color: white;
    color: #33b2ff;
    width: 300px;
    text-align: center;
    border-radius: 15px;
    border: 1px solid #33b2ff;
  }

  .menutitleOn {
    margin: 12px auto;
    background-color: #2b9af0;
    color: white;
    width: 300px;
    text-align: center;
    border-radius: 15px;
    border: 1px solid #33b2ff;
  }

  .menutitle .menutitlesub {
    line-height: 45px;
    cursor: pointer;
  }

  .menutitleOn .menutitlesub {
    line-height: 40px;
    cursor: pointer;
  }

  .submenu {
    display: none;
    padding: 10px;
  }

  .submenuOn {
    display: block;
    padding: 10px;
  }

  .submenuOn a {
    color: white;
    cursor: pointer;
    margin-left: 20px;
  }

  .searchTable tr {
    height: 45px;
  }

  .searchTable .searchtd {
    font-weight: bolder;
    text-align: right;
    padding-right: 10px;
  }

  .RecordList {
    text-align: left;
  }

  .RecordList li {
    height: 28px;
    width: 230px;
    margin-left: 25px;
    line-height: 28px;
    margin: 2px auto;
  }

  .RecordList li a {
    margin-left: 60px;
  }

  .RecordList li:hover {
    height: 26px;
    width: 228px;
    margin-left: 25px;
    line-height: 26px;
    -moz-border-radius: 3px;
    -webkit-border-radius: 3px;
    border-radius: 3px;
    border: 1px solid white;
  }

  .DocSelected {
    border-radius: 3px;
    border: 1px solid white;
  }

  .imageIcon {
    margin-left: 50px;
    vertical-align: middle;
  }

  .imageSelIcon {
    margin-left: 30px;
    vertical-align: middle;
  }
}

@media screen and (min-aspect-ratio: 1001/1000) {
  // 横屏
}

@media screen and (max-aspect-ratio: 1000/1000) {
  // 竖屏
  .ChargeTemplateEditDiv {
    .ChargeTemplateEditDivEdit {
      margin: 5px 2px;
    }
    .ChargeTemplateEditDivDelete {
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
.ChargeTemplateEditDiv .el-input__inner {
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
.ChargeTemplateEditDiv .el-input__icon {
  line-height: 25px;
}
.ChargeTemplateEditDiv .el-button {
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

.ChargeTemplateEditDiv .el-table th {
  padding: 6px 0;
}

.ChargeTemplateEditDiv .el-table td {
  padding: 4px 0;
}

.ChargeTemplateEditDiv .el-input-number {
  line-height: 24px;
}

.ChargeItemsConfigDiv .el-select-dropdown__list {
  padding: 0px 10px;
}

.ChargeTemplateEditDiv .el-radio-button__orig-radio + .el-radio-button__inner {
  line-height: 10px;
}

.ChargeTemplateEditDiv .el-radio-button__inner {
  padding: 10px 20px;
}

.ChargeTemplateEditDiv
  .el-radio-button__orig-radio:checked
  + .el-radio-button__inner {
  background-color: rgba(61, 209, 138, 1);
  border-color: rgba(61, 209, 138, 1);
  line-height: 10px;
}

.ChargeTemplateEditDiv ::-webkit-input-placeholder {
  font-style: italic;
}

@media screen and (min-aspect-ratio: 1001/1000) {
  /* 横屏 */
  .ChargeTemplateEditDiv .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    width: 200px;
  }
}

@media screen and (max-aspect-ratio: 1000/1000) {
  /* 竖屏 */
  .ChargeTemplateEditDiv .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    width: 110px;
  }
}
</style>
