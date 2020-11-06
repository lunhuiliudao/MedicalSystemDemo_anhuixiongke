<template>
  <div
    class="DocManage"
    v-bind:style="{'width':mainWidth + 'px', 'height':mainHeight + 'px', 'max-width':'1300px', 'max-height':'868px', 'background-color':'#E5EAED'}"
  >
    <div class="LeftView" v-bind:style="{'height':mainHeight - 10 + 'px', 'max-height':'868px'}">
      <!--搜索条件表格-->
      <div style="margin:10px 0px 0px 5px">
        <table cellpadding="0" cellspacing="0" class="Table">
          <tr>
            <td class="searchtd">住院号/姓名</td>
            <td>
              <el-input
                v-model="InpNo"
                style="width:185px"
                placeholder="住院号/患者姓名"
                @keyup.enter.native="search"
              ></el-input>
            </td>
          </tr>
          <tr>
            <td class="searchtd">麻醉医生</td>
            <td>
              <el-input
                v-model="AnesDoctor"
                style="width:185px;"
                placeholder="麻醉医生"
                @keyup.enter.native="search"
              ></el-input>
            </td>
          </tr>
          <tr>
            <td class="searchtd">手术间</td>
            <td>
              <el-select
                style="width:185px;"
                v-model="OperRoomNo"
                clearable
                placeholder="手术间"
                :filterable="true"
                :remote="true"
                :remote-method="FilterOperRoom"
                @change="SelectOperRoomNoChanged"
                @clear="ClearOperRoomNo"
              >
                <el-option
                  v-for="(item, index) in OperRoomNoList"
                  :key="index"
                  :label="item.ROOM_NO"
                  :value="item.ROOM_NO"
                ></el-option>
              </el-select>
            </td>
          </tr>
          <tr>
            <td class="searchtd">手术日期</td>
            <td>
              <el-date-picker
                class="dateCss"
                v-model="OperDate"
                style="width:185px;"
                type="date"
                v-bind:editable="true"
                v-bind:clearable="true"
                placeholder="选择日期"
              ></el-date-picker>
            </td>
          </tr>
          <tr>
            <td v-bind:colspan="2" class="searchtd" style="padding-right:0px;">
              <el-radio-group
                v-model="Status"
                size="mini"
                @change="StatusChanged"
                style="margin-top:5px;"
              >
                <el-radio-button v-bind:border="true" label="全部"></el-radio-button>
                <el-radio-button v-bind:border="true" label="术前"></el-radio-button>
                <el-radio-button v-bind:border="true" label="术中"></el-radio-button>
                <el-radio-button v-bind:border="true" label="术后"></el-radio-button>
              </el-radio-group>
            </td>
          </tr>
          <tr>
            <td v-bind:colspan="2">
              <el-checkbox
                v-model="SelfOperation"
                v-on:change="SelfOperationChanged"
                style="margin-left:45px;margin-top:5px;"
              >
                <span style="font-weight:bolder; color:#666;">本人</span>
              </el-checkbox>
              <el-select
                style="width:60px; margin-left:10px; margin-top:5px;"
                v-model="EmergencyInd"
                v-on:change="StatusChanged"
              >
                <el-option
                  v-for="(item, index) in EmergencyIndList"
                  v-bind:key="index"
                  :label="item.label"
                  v-bind:value="item.value"
                ></el-option>
              </el-select>

              <el-button
                v-on:click="Search"
                class="SearchClass"
                style="margin-right:0px;float:right;margin-top:5px;"
                type="primary"
              >查询</el-button>
            </td>
          </tr>
        </table>
      </div>
      <!--翻页控件-->
      <div style="margin-top:5px;">
        <el-pagination
          small
          background
          v-on:size-change="PaginationSizeChange"
          v-on:current-change="PaginationCurrentChange"
          v-bind:current-page.sync="CurrentPage"
          v-bind:page-size="PageSize"
          v-bind:pager-count="5"
          layout="total,prev,pager,next"
          v-bind:total="TotalCount"
        ></el-pagination>
      </div>
      <!--患者列表-->
      <div v-bind:style="{'width':'280px','height':mainHeight-25-270+'px','overflow':'auto'}">
        <div
          v-for="(item, index) in TableData"
          v-bind:key="index"
          v-bind:class="SelectPatient==item?'MenutitleOn':'Menutitle'"
        >
          <div class="Menutitlesub" v-on:click.stop="SwitchMenu(item)">
            {{item.INP_NO}}&nbsp;&nbsp;&nbsp;&nbsp;{{item.OPER_ROOM_NO}}&nbsp;&nbsp;&nbsp;&nbsp;{{item.NAME}}&nbsp;&nbsp;&nbsp;&nbsp;{{item.AnesDoctor}}
            <span
              v-bind:style="item.EMERGENCY_IND===1?'color:red;float:right;margin-right:20px;width:20px;':'loat:right;margin-right:40px;'"
            >{{item.EMERGENCY_IND===1?'急':''}}</span>
          </div>
          <hr
            v-show="SelectPatient==item?true:false"
            style="height:1px;border:none;border-top:1px dashed white;width:210px;margin:0px 15px;"
          />
          <div v-bind:class="SelectPatient==item?'SubmenuOn':'Submenu'">
            <ul class="RecordList">
              <li
                :key="item.name"
                v-for="item in DocumentList"
                v-bind:class="SelectDoc==item?'DocSelected':''"
                @click="ShowDocument(item)"
              >
                <img class="ImageIcon" src="../../assets/images/blgl/tystb.png" />
                <a>{{item.name}}</a>
                <img
                  class="ImageSelIcon"
                  v-show="SelectDoc==item?true:false"
                  src="../../assets/images/blgl/jiantou.png"
                />
              </li>
            </ul>
          </div>
        </div>
      </div>
    </div>
    <div
      class="mainView"
      v-bind:style="{'width':mainWidth-340+'px','height':mainHeight-15+'px','max-width':'1000px','max-height':'868px'}"
    >
      <el-scrollbar style="height:100%;">
        <component
          ref="docCom"
          v-bind:is="SelectDoc.component"
          v-if="typeof(MedicalBasicDoc.PatientDetail)!=='undefined' && typeof(MedicalBasicDoc.CustomData)!=='undefined'"
          v-bind:MedicalBasicDoc="MedicalBasicDoc"
          v-on:SelectMedicalBasicDoc="SelectMedicalBasicDoc"
        ></component>
      </el-scrollbar>
    </div>
  </div>
</template>

<script>
import DocManage from './DocManage.js'
export default DocManage
</script>

<style scoped>
.DocManage {
  margin-top: 25px;
}

.mainView {
  float: left;
  background-color: white;
  border-radius: 6px;
  color: black;
  font-size: 16px;
  margin-left: 10px;
}

.ImageSelIcon {
  margin-left: 30px;
  vertical-align: middle;
}

.DocSelected {
  border-radius: 3px;
  border: 1px solid white;
}

.Menutitle .Menutitlesub {
  line-height: 45px;
  cursor: pointer;
}

.MenutitleOn .Menutitlesub {
  line-height: 40px;
  cursor: pointer;
}

.menutitleOn .Menutitlesub {
  line-height: 40px;
  cursor: pointer;
}

.ImageIcon {
  margin-left: 20px;
  vertical-align: middle;
}

.RecordList {
  text-align: left;
}

.RecordList li {
  height: 28px;
  width: 200px;
  margin-left: 10px;
  line-height: 28px;
  margin: 2px auto;
}

.Submenu {
  display: none;
  padding: 10px;
}

.SubmenuOn {
  display: block;
  padding: 10px;
}

.SubmenuOn a {
  color: white;
  cursor: pointer;
  margin-left: 10px;
}

.MenutitleOn {
  margin: 8px auto;
  background-color: #2b9af0;
  color: white;
  width: 240px;
  text-align: center;
  border-radius: 5px;
  border: 1px solid #33b2ff;
}

.Menutitle {
  margin: 8px auto;
  background-color: white;
  color: #33b2ff;
  width: 240px;
  text-align: center;
  border-radius: 5px;
  border: 1px solid #33b2ff;
}

.Menutitle .Menutitlesub {
  line-height: 45px;
  cursor: pointer;
}

.LeftView {
  float: left;
  background-color: white;
  width: 280px;
  border-radius: 6px;
  font-size: 12px;
  font-family: MicrosoftYaHei;
  font-weight: 400;
}

.Table tr {
  height: 30px;
}

.Table searchtd {
  font-weight: bolder;
  text-align: right;
  padding-right: 10px;
}

.SearchClass {
  width: 60px;
  height: 32px;
  background: #2b9af0;
  box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
  border-radius: 3px;
  margin: 0 0 0 28px;
  text-align: center;
}
</style>

<style lang="scss">
@import "@/assets/styles/global.scss";
.DocManage .el-scrollbar__wrap {
  overflow-x: hidden;
}
.DocManage .el-checkbox {
  color: black;
  font-size: 14px;
  margin-right: 10px;
}

.DocManage .el-checkbox__label {
  font-size: 14px;
  font-weight: bold;
}

.DocManage .el-checkbox__inner {
  border: 1px solid black;
}
.DocManage .el-textarea__inner {
  border: 1px solid black;
  font-size: 14px;
  color: black;
}
.DocManage .el-radio__inner {
  border: 1px solid black;
}
.DocManage .el-radio__label {
  color: black;
}
.DocManage .el-input__inner {
  font-size: 14px;
  text-align: left;
  height: 30px;
  line-height: 30px;
  padding: 0 10px 0 5px;
}
.DocManage .el-checkbox__input.is-checked + .el-checkbox__label {
  color: black;
}
.DocManage .no-print {
  display: inline;
}
.DocManage .show-print {
  display: none;
}
.DocManage input[type="text"] {
  border: 1px solid black;
  font-size: 14px;

  text-align: left;
  height: 30px;
  outline-color: invert;
  outline-style: none;
  outline-width: 0px;

  border-style: none none dashed none;
  border-color: black;
  border-width: 1px;

  text-shadow: none;
  -webkit-appearance: none;
  -webkit-user-select: text;
  outline-color: transparent;
  box-shadow: none;
}
.DocManage .el-tag {
  font-size: 14px;
  color: black;
}
.DocManage .el-select__tags {
  white-space: pre-wrap;
}

.DocManage .el-button {
  display: inline-block;
  line-height: 1;
  white-space: nowrap;
  cursor: pointer;

  border: 1px solid #dcdfe6;

  -webkit-appearance: none;
  text-align: left;
  -webkit-box-sizing: border-box;
  box-sizing: border-box;
  outline: 0;
  margin: 0;
  -webkit-transition: 0.1s;
  transition: 0.1s;
  font-weight: 500;
  padding: 6px 16px;
  font-size: 14px;
  border-radius: 4px;
}

.DocManage .el-radio-button__orig-radio:checked + .el-radio-button__inner {
  color: #fff;
  background: #2b9af0;
  border-color: #2b9af0;
  -webkit-box-shadow: -1px 0 0 0 #2b9af0;
  box-shadow: -1px 0 0 0 #2b9af0;
}

.DocManage .el-pagination.is-background .el-pager li:not(.disabled).active {
  background-color: #2b9af0;
  color: #fff;
}
.dateCss .el-input__icon {
  display: none;
}

.DocManage .el-input__icon {
  color: #2b9af0;
}
.DocManage .el-select .el-input .el-select__caret {
  color: #2b9af0;
}
.DocManage .el-input__suffix {
  top: 3px;
}
</style>
