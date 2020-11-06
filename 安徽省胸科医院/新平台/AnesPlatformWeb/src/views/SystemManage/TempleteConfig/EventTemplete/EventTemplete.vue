<template>
  <div class="eventTempleteDiv">
    <el-dialog
      :title="dialogEditTitle"
      :visible.sync="dialogEditVisible"
      :close-on-click-modal="false"
    >
      <span style="font-size:16px;">{{this.currentMenu}}</span>
      <span style="font-size:16px;">>{{this.currentTemplete}}</span>
      <div style="height:30px;"></div>
      <el-form :model="formData" :rules="rules" ref="formView" :inline="true">
        <el-form-item label="分类" prop="EVENT_CLASS_NAME">
          <el-select
            v-model="formData.EVENT_CLASS_NAME"
            @change="SelItemClass(formData.EVENT_CLASS_NAME)"
            placeholder="请选择"
            style="width:185px"
          >
            <el-option
              style="font-size:14px;padding:0px 5px;"
              v-for="(item,index) in itemClassDict"
              :key="index"
              :label="item.EVENT_CLASS_NAME"
              :value="item.EVENT_CLASS_CODE"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="事件名称" prop="EVENT_ITEM_NAME">
          <el-select
            v-model="formData.EVENT_ITEM_NAME"
            @change="SelEventCode(formData.EVENT_ITEM_NAME)"
            filterable
            placeholder="请选择"
            style="width:185px"
          >
            <el-option
              style="font-size:14px;padding:0px 5px;"
              v-for="(item,index) in EventData"
              :key="index"
              :label="item.EVENT_ITEM_NAME"
              :value="item.EVENT_ITEM_NAME"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="用药途径">
          <el-select
            v-model="formData.ADMINISTRATOR"
            filterable
            :filter-method="filterAdministrator"
            placeholder="请选择"
            style="width:185px"
          >
            <el-option
              style="font-size:14px;padding:0px 5px;"
              v-for="(item,index) in medAdministratorList"
              :key="index"
              :label="item.ADMINISTRATION_NAME"
              :value="item.ADMINISTRATION_NAME"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="速度">
          <el-input
            v-model="formData.PERFORM_SPEED"
            type="number"
            placeholder="请输入内容"
            style="width:185px"
          ></el-input>
        </el-form-item>
        <el-form-item label="速度单位">
          <el-select v-model="formData.SPEED_UNIT" placeholder="请选择" style="width:185px">
            <el-option
              style="font-size:14px;padding:0px 5px;"
              v-for="(item,index) in medUnitsListType2"
              :key="index"
              :label="item.UNIT_NAME"
              :value="item.UNIT_NAME"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="浓度">
          <el-input v-model="formData.CONCENTRATION" placeholder="请输入内容" style="width:185px"></el-input>
        </el-form-item>
        <el-form-item label="浓度单位">
          <el-select
            v-model="formData.CONCENTRATION_UNIT"
            filterable
            :filter-method="filterUnits"
            placeholder="请选择"
            style="width:185px"
          >
            <el-option
              style="font-size:14px;padding:0px 5px;"
              v-for="(item,index) in medUnitsListType1"
              :key="index"
              :label="item.UNIT_NAME"
              :value="item.UNIT_NAME"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="剂量">
          <el-input v-model="formData.DOSAGE" placeholder="请输入内容" style="width:185px"></el-input>
        </el-form-item>
        <el-form-item label="剂量单位">
          <el-select
            v-model="formData.DOSAGE_UNITS"
            filterable
            :filter-method="filterUnits"
            placeholder="请选择"
            style="width:185px"
          >
            <el-option
              style="font-size:14px;padding:0px 5px;"
              v-for="(item,index) in medUnitsListType3"
              :key="index"
              :value="item.UNIT_NAME"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="间隔时长">
          <el-input
            v-model="formData.START_AFTER_INPUT"
            type="number"
            placeholder
            style="width:185px"
          ></el-input>
        </el-form-item>
        <el-form-item label="持续时长">
          <el-input v-model="formData.DURATIVE" type="number" placeholder style="width:185px"></el-input>
        </el-form-item>
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button type="primary" class="eventTempleteDivSave" @click="onSubmit('formView')">保 存</el-button>&nbsp;&nbsp;&nbsp;&nbsp;
        <el-button
          type="primary"
          class="eventTempleteDivSave"
          @click="dialogEditVisible = false"
        >取 消</el-button>
      </div>
    </el-dialog>
    <el-dialog :title="dialogTemplete" :visible.sync="dialogTempleteVisible">
      <el-form ref="formView" :inline="true">
        <br />
        <el-form-item label="模版分类">
          <el-select v-model="currentMenu" placeholder="请选择" style="width:175px;">
            <el-option
              style="font-size:14px;padding:0px 5px;"
              v-for="item in options"
              :key="item.value"
              :label="item.label"
              :value="item.value"
            ></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="模版名称">
          <el-input v-model="currentTemplete" placeholder="请输入模版名称" style="width:175px;"></el-input>
        </el-form-item>
        <!-- <el-form-item >
          <el-button
            type="primary"
            class="eventTempleteDivSave"
            style="margin-left:52px;margin-top:30px;"
            @click="onSubmitTemplete('formView')"
          >保 存</el-button>&nbsp;&nbsp;&nbsp;&nbsp;
          <el-button
            type="primary"
            class="eventTempleteDivSave"
            @click="dialogTempleteVisible = false"
          >取 消</el-button>
        </el-form-item>-->
      </el-form>
      <div slot="footer" class="dialog-footer">
        <el-button
          type="primary"
          class="eventTempleteDivSave"
          style="margin-left:52px;margin-top:30px;"
          @click="onSubmitTemplete('formView')"
        >保 存</el-button>&nbsp;&nbsp;&nbsp;&nbsp;
        <el-button
          type="primary"
          class="eventTempleteDivSave"
          @click="dialogTempleteVisible = false"
        >取 消</el-button>
      </div>
    </el-dialog>
    <div style="margin-top:20px;margin-left:15px;" class="mdsdRadioSingle">
      <el-radio-group v-model="radioType" @change="selectTypeChanged()">
        <el-radio label="0" style="margin-left:10px;">通用</el-radio>
        <el-radio label="1" style="margin-left:10px;">复苏</el-radio>
        <el-radio label="2" style="margin-left:10px;">麻醉</el-radio>
      </el-radio-group>
    </div>
    <div style="margin-top:30px">
      <el-button
        type="primary"
        class="eventTempleteDivAdd"
        @click="addTemplete()"
        style="margin-left:15px;"
      >新增模版</el-button>
      <el-button
        type="primary"
        class="eventTempleteDivAdd"
        @click="deleteTemplete"
        v-show="this.currentTemplete!=''"
        style="margin-left: 10px;"
      >删除模版</el-button>
      <!-- <el-button type="primary" @click="addData" v-show="this.currentTemplete!=''" style="margin-left: 10px">复制模版</el-button> -->

      <span style="font-size:16px;margin-left:10px;">{{this.currentMenu}}</span>
      <span style="font-size:16px; ">>{{this.currentTemplete}}</span>
      <el-button
        type="primary"
        class="eventTempleteDivAdd"
        v-show="this.currentTemplete!=''"
        @click="addData"
        style="margin-left:10px;"
      >新增事件</el-button>
      <!-- <el-button type="primary" @click="addData" style="margin-right: 10px">删除</el-button> -->
    </div>
    <div style="background-color: #fff;min-height:600px;">
      <div class="report-main-top-wrapper"></div>
      <div style="display:flex;width:100%;">
        <div class="menuTitleDiv">
          <div
            v-bind:key="obj"
            v-for="obj in firstMenu"
            v-bind:class="currentMenu==obj?'menutitleOn':'menutitle'"
          >
            <div @click="SwitchMenu(obj)" class="menutitlesub">{{obj}}</div>
            <hr
              style="height:1px;border:none;border-top:1px dashed white;width:180px;margin:0px 10px;"
            />
            <div v-bind:class="currentMenu==obj?'submenuOn':'submenu'">
              <ul class="RecordList">
                <li
                  @click="ShowTemplete(item.TEMPLET_NAME)"
                  v-bind:class="item.TEMPLET_NAME==currentTemplete?'DocSelected':'' "
                  v-bind:key="item.TEMPLET_NAME"
                  v-for="item in templetMenu.filter(t=>t.ANESTHESIA_METHOD==obj)"
                >
                  <a>{{item.TEMPLET_NAME}}</a>
                  <img
                    class="imageSelIcon"
                    v-show="item.TEMPLET_NAME==currentTemplete?true:false"
                    src="@/assets/images/jiantou.png"
                  />
                </li>
              </ul>
            </div>
          </div>
        </div>
        <div class="rightTable">
          <div id="dataView">
            <el-table
              :data="TempleteDta"
              v-loading="loading"
              element-loading-text="拼命加载中"
              border
              style="width: 99%;"
            >
              <el-table-column
                prop="EVENT_ITEM_NO"
                header-align="center"
                width="50"
                align="center"
                label="序号"
              ></el-table-column>
              <el-table-column
                prop="EVENT_CLASS_NAME"
                header-align="center"
                align="center"
                label="分类"
              ></el-table-column>
              <el-table-column
                prop="EVENT_ITEM_NAME"
                header-align="center"
                min-width="200px"
                align="center"
                label="名称"
              ></el-table-column>
              <el-table-column
                prop="ADMINISTRATOR"
                header-align="center"
                align="center"
                label="用药途径"
              ></el-table-column>
              <el-table-column
                prop="PERFORM_SPEED"
                header-align="center"
                width="50"
                align="center"
                label="速度"
              ></el-table-column>
              <el-table-column prop="SPEED_UNIT" header-align="center" align="center" label="单位"></el-table-column>
              <el-table-column
                prop="CONCENTRATION"
                header-align="center"
                width="50"
                align="center"
                label="浓度"
              ></el-table-column>
              <el-table-column
                prop="CONCENTRATION_UNIT"
                header-align="center"
                align="center"
                label="单位"
              ></el-table-column>
              <el-table-column
                prop="DOSAGE"
                header-align="center"
                width="50"
                align="center"
                label="剂量"
              ></el-table-column>
              <el-table-column prop="DOSAGE_UNITS" header-align="center" align="center" label="单位"></el-table-column>
              <el-table-column
                prop="START_AFTER_INPUT"
                header-align="center"
                align="center"
                label="间隔时长(min)"
              ></el-table-column>
              <el-table-column
                prop="DURATIVE"
                header-align="center"
                align="center"
                label="持续时长(min)"
              ></el-table-column>
              <el-table-column label="操作" header-align="center" fixed="right" min-width="120px">
                <template slot-scope="scope">
                  <span class="czCss">
                    <el-button
                      size="small"
                      class="eventTempleteDivEdit"
                      @click="editData(scope.$index, scope.row)"
                    >编辑</el-button>
                    <el-button
                      size="small"
                      type="danger"
                      class="eventTempleteDivDelete"
                      @click="deleteData(scope.$index, scope.row)"
                    >删除</el-button>
                  </span>
                </template>
              </el-table-column>
            </el-table>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import EventTemplete from './EventTemplete.js'
export default EventTemplete
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";

.eventTempleteDiv {
  margin-top: 5px;
  padding: 10px 0px;
  background-color: #f5f9fb;
  font-size: 14px;
  color: #606266;
  min-height: 768px;
  .eventTempleteDivAdd {
    width: 99px;
    height: 28px;
    background: rgba(61, 209, 138, 1);
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 0px 0px 0px 10px;
  }

  .eventTempleteDivEdit {
    width: 59px;
    height: 28px;
    //background: #d0dfe6;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 0px;
  }

  .eventTempleteDivDelete {
    width: 59px;
    height: 28px;
    background: #f56c6c;
    box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
    border-radius: 3px;
    margin: 5px 5px;
  }

  .eventTempleteDivSave {
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

  .rightTable {
    margin-top: 0px;
    width: 85%;
  }
}

@media screen and (min-aspect-ratio: 1001/1000) {
  // 横屏
}

@media screen and (max-aspect-ratio: 1000/1000) {
  // 竖屏
  .eventTempleteDiv {
    .eventTempleteDivEdit {
      margin: 5px 2px;
    }
    .eventTempleteDivDelete {
      margin: 5px 2px;
    }
    .czCss {
      margin-left: 0px;
    }
    .conditionName {
      margin-left: 10px;
    }
    .rightTable {
      width: 75%;
    }

    .menuTitleDiv {
      width: 25%;
    }
  }
}

.dialog-footer {
  text-align: center;
}

.menuTitleDiv {
  display: flex;
  flex-direction: column;
  width: 15%;
}

.menutitle {
  // margin: 5px auto;
  background-color: white;
  color: #33b2ff;
  text-align: center;
  border-radius: 15px;
  border: 1px solid #33b2ff;
}

.menutitleOn {
  margin-top: 1px;
  // margin: 12px auto;
  background-color: #2b9af0;
  color: white;

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
  padding: 0px;
}

.submenuOn {
  display: block;
  padding: 0px;
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
  width: 90%;
  margin-left: 15px;
  line-height: 28px;
  margin: 4px 10px;
}

.RecordList li a {
  margin-left: 10px;
}

.RecordList li:hover {
  height: 28px;
  width: 90%;
  margin-left: 10px;
  line-height: 28px;
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
</style>
<style>
.eventTempleteDiv .el-input__inner {
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
.eventTempleteDiv .el-input__icon {
  line-height: 25px;
}
.eventTempleteDiv .el-button {
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

.eventTempleteDiv .el-table th {
  padding: 6px 0;
}

.eventTempleteDiv .el-table td {
  padding: 4px 0;
}

.eventTempleteDiv .el-input-number {
  line-height: 24px;
}

.eventTempleteDiv .el-select-dropdown__list {
  padding: 0px 10px;
}

.eventTempleteDiv ::-webkit-input-placeholder {
  font-style: italic;
}

@media screen and (min-aspect-ratio: 1001/1000) {
  /* 横屏 */
  .eventTempleteDiv .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    width: 200px;
  }
}

@media screen and (max-aspect-ratio: 1000/1000) {
  /* 竖屏 */
  .eventTempleteDiv .el-form-item__label {
    font-size: 12px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(101, 101, 101, 1);
    width: 110px;
  }
}
</style>
