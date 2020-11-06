<template>
  <div class="main">
    <div style="height:30px;"></div>
    <div class="mainLeft">
      <p class="title1">已存报表</p>

      <div
        :key="index"
        v-for="(item,index) in reportNameList"
        :class="item.REPORT_NAME===selected?'reportNameSelected':'reportName'"
        @click="setSelected(item.REPORT_NAME)"
      >
        <span
          :class="item.REPORT_NAME===selected?'mdsd-iconfont mdsd-icon-document-selected docSelect':'mdsd-iconfont mdsd-icon-document doc'"
        ></span>
        {{item.REPORT_NAME}}
      </div>
    </div>
    <div class="mainRight">
      <div class="rightHead">
        <span class="headTitle1">{{selected}}</span>
        <el-select
          style="width:300px;font-size:14px;"
          class="rptName"
          size="mini"
          v-model="selected"
          clearable
          placeholder="请选择"
          @change="searchInfos()"
        >
          <el-option
            style="font-size:14px;margin-left:5px;"
            v-for="(item, index) in reportNameList"
            :key="index"
            :label="item.REPORT_NAME"
            :value="item.REPORT_NAME"
          ></el-option>
        </el-select>
        <a v-show="(selected!=='')" class="headTitle2">
          <span @click="editInfos()" class="mdsd-iconfont mdsd-icon-edit edit-icon"></span>
          <span @click="editInfos()">编辑</span>
        </a>
        <div>
          <el-radio-group v-model="isOutRoomOper" class="mdsdRadioSingle2">
            <el-radio @click.native.prevent="clickitemOut('全部')" label="全部">全部</el-radio>
            <el-radio @click.native.prevent="clickitemOut('室内')" label="室内">室内</el-radio>
            <el-radio @click.native.prevent="clickitemOut('室外')" label="室外">室外</el-radio>
          </el-radio-group>

          <el-button
            size="mini"
            style="width:80px;"
            :disabled="(isUpload || isOutRoomOper === '全部' || editFlag === false)?true:false"
            v-on:click="saveInfos()"
            type="primary"
          >保存</el-button>
          <el-button
            size="mini"
            style="width:80px;"
            :disabled="(isUpload || isOutRoomOper !== '全部')?true:false"
            v-on:click="uploadData()"
            type="primary"
          >上报</el-button>
          <el-button size="mini" @click="print()" type="primary" style="width:80px;">打印</el-button>
          <el-button size="mini" style="width:80px;" v-on:click="exprotExcel()" type="primary">导出</el-button>
          <a id="hrefToExportTable" style="display: none;width: 0px;height: 0px;"></a>
        </div>
      </div>

      <div class="table_main">
        <table style="width:99%; margin-top:5px;table-layout:fixed;word-break:break-all;">
          <thead class="tableHead">
            <th width="60px" style="text-align:center;">序号</th>
            <th width="38%" style="text-align:left;">名称</th>
            <th width="62%" style="text-align:left;">描述</th>
            <th width="85px">分子</th>
            <th width="88px">分母</th>
            <th width="82px">指标率</th>
            <th width="90px"></th>
          </thead>
        </table>
        <el-scrollbar style="width:99%;">
          <div style="width:100%; margin:0px auto; display: flex;margin-bottom: 30px;">
            <table style="width:99%;table-layout:fixed;word-break:break-all;">
              <thead class="tableHeadDisplay">
                <th width="60px"></th>
                <th width="38%"></th>
                <th width="62%"></th>
                <th width="85px"></th>
                <th width="88px"></th>
                <th width="82px"></th>
                <th width="90px"></th>
              </thead>
              <tbody>
                <tr :key="index" v-for="(item ,index) in tableData" :class="rowIndex(item)">
                  <td width="60px">
                    <span v-if="item.FATHER_CHILD === 1">{{calIndex(item.GROUP_NO)}}</span>
                  </td>
                  <td
                    width="38%"
                    style="padding:10px;"
                    :class="item.FATHER_CHILD === 1?'noline':(item.GROUP_NO % 2===0?'withtopline':'withbottomline' )"
                  >
                    <span>{{item.REPORT_NAME}}</span>
                  </td>
                  <td
                    width="62%"
                    style="padding:10px;"
                    :class="item.FATHER_CHILD === 1?'noline':(item.GROUP_NO % 2===0?'withtopline':'withbottomline' )"
                  >
                    <span class="tdTitle1">{{'*'+item.DESCRIBE}}</span>
                  </td>
                  <td
                    width="85px"
                    :class="item.FATHER_CHILD === 1?'noline':(item.GROUP_NO % 2===0?'withtopline':'withbottomline' )"
                    style="text-align:center;"
                  >
                    <span
                      v-if="!editFlag || item.NMRTR_CODE==null || item.NMRTR_EDIT_MARK==0"
                    >{{ item.NMRTR_CODE_VALUE }}</span>
                    <span
                      v-if="editFlag && item.NMRTR_CODE!=null && item.NMRTR_EDIT_MARK==1"
                      class="cell-edit-input"
                    >
                      <el-input-number
                        :precision="0"
                        size="small"
                        style="width:80px;"
                        v-model="item.NMRTR_CODE_VALUE"
                        controls-position="right"
                        v-on:input="valueChange(item)"
                        v-on:click.native="check_num(item)"
                        :min="0"
                      ></el-input-number>
                    </span>
                  </td>
                  <td
                    width="88px"
                    style="text-align:center;"
                    :class="item.FATHER_CHILD === 1?'noline':(item.GROUP_NO % 2===0?'withtopline':'withbottomline' )"
                  >
                    <span
                      v-if="!editFlag ||item.DNMTR_CODE==null || item.DNMTR_EDIT_MARK==0"
                    >{{ item.DNMTR_CODE_VALUE }}</span>
                    <span
                      v-if="!item.REPORT_NAME.includes('麻醉科医患比（GB）') && editFlag && item.DNMTR_CODE!=null && item.DNMTR_EDIT_MARK==1"
                      class="cell-edit-input"
                    >
                      <el-input-number
                        :precision="0"
                        size="small"
                        style="width:80px;"
                        v-model="item.DNMTR_CODE_VALUE"
                        controls-position="right"
                        v-on:input="valueChange(item)"
                        v-on:click.native="check_num(item)"
                        :min="0"
                      ></el-input-number>
                    </span>
                    <span
                      v-if="item.REPORT_NAME.includes('麻醉科医患比（GB）') && editFlag && item.DNMTR_CODE!=null && item.DNMTR_EDIT_MARK==1"
                      class="cell-edit-input"
                    >{{ item.DNMTR_CODE_VALUE }}</span>
                    <span
                      v-if="item.REPORT_NAME.includes('麻醉科医患比（DB）') && editFlag && item.DNMTR_CODE!=null && item.DNMTR_EDIT_MARK==1"
                      class="cell-edit-input"
                    >
                      <el-input
                        :precision="0"
                        v-model="item.DNMTR_CODE_VALUE"
                        controls-position="right"
                        v-on:click.native="check_num(item)"
                      ></el-input>
                    </span>
                  </td>
                  <td
                    width="82px"
                    style="text-align:center;"
                    :class="item.FATHER_CHILD === 1?'noline':(item.GROUP_NO % 2===0?'withtopline':'withbottomline' )"
                  >
                    <span class="tdTitle2">{{item.PERCENT}}</span>
                  </td>
                  <td
                    style="width:90px;"
                    :class="item.FATHER_CHILD === 1?'noline':(item.GROUP_NO % 2===0?'withtopline':'withbottomline' )"
                  >
                    <!-- <img
                      @click="showDetail()"
                      style="vertical-align:middle;"
                      src="@/assets/images/toicu.png"
                      alt
                    >-->
                    <div
                      v-show="isOutRoomOper!=='全部' && item.DETAILS_COUNT > 0"
                      @click="dialogVisible = true;searchDetailInfos(item.REPORT_NO)"
                      class="showDetal"
                    >
                      <span style="margin-right:3px;" class="mdsd-iconfont mdsd-icon-array"></span>明细
                    </div>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </el-scrollbar>

        <div style="display:none;width:100%;">
          <div id="quanlityDataPrintArea" ref="refq" style="width:100%">
            <div
              style="width:100%; height:25px; text-align:center;font-size:22px;"
            >{{printHeaderText}}</div>
            <table
              style="width:99%;table-layout:fixed;word-break:break-all; margin-top:15px;"
              width="99%"
              border="1"
              cellspacing="0"
              cellpadding="0"
            >
              <thead class="tableHead" style="line-height:20px;">
                <th width="60px">序号</th>
                <th width="235px">名称</th>
                <th width="395px">描述</th>
                <th width="85px">分子</th>
                <th width="88px">分母</th>
                <th width="82px">指标率</th>
              </thead>
              <tbody>
                <tr
                  style="vertical-align: middle;"
                  :key="index"
                  v-for="(item ,index) in tableData"
                  :class="rowIndex(item)"
                >
                  <td width="45px">
                    <span v-if="item.FATHER_CHILD === 1">{{calIndex(item.GROUP_NO)}}</span>
                  </td>
                  <td width="235px" :class="item.FATHER_CHILD === 1?'noline':'withline'">
                    <span>{{item.REPORT_NAME}}</span>
                  </td>
                  <td width="420px" :class="item.FATHER_CHILD === 1?'noline':'withline'">
                    <span class="tdTitle1">{{item.DESCRIBE}}</span>
                  </td>
                  <td
                    width="85px"
                    :class="item.FATHER_CHILD === 1?'noline':'withline'"
                    style="text-align:center;"
                  >
                    <span
                      v-if="!editFlag || item.NMRTR_CODE==null || item.NMRTR_EDIT_MARK==0"
                    >{{ item.NMRTR_CODE_VALUE }}</span>
                    <span
                      v-if="editFlag && item.NMRTR_CODE!=null && item.NMRTR_EDIT_MARK==1"
                      class="cell-edit-input"
                    >
                      <el-input-number
                        :precision="0"
                        size="small"
                        style="width:80px;"
                        v-model="item.NMRTR_CODE_VALUE"
                        controls-position="right"
                        v-on:input="valueChange(item)"
                        v-on:click.native="check_num(item)"
                        :min="0"
                      ></el-input-number>
                    </span>
                  </td>
                  <td
                    width="88px"
                    style="text-align:center;"
                    :class="item.FATHER_CHILD === 1?'noline':'withline'"
                  >
                    <span
                      v-if="!editFlag ||item.DNMTR_CODE==null || item.DNMTR_EDIT_MARK==0"
                    >{{ item.DNMTR_CODE_VALUE }}</span>
                    <span
                      v-if="!item.REPORT_NAME.includes('麻醉科医患比（GB）') && editFlag && item.DNMTR_CODE!=null && item.DNMTR_EDIT_MARK==1"
                      class="cell-edit-input"
                    >
                      <el-input-number
                        :precision="0"
                        size="small"
                        style="width:80px;"
                        v-model="item.DNMTR_CODE_VALUE"
                        controls-position="right"
                        v-on:input="valueChange(item)"
                        v-on:click.native="check_num(item)"
                        :min="0"
                      ></el-input-number>
                    </span>
                    <span
                      v-if="item.REPORT_NAME.includes('麻醉科医患比（GB）') && editFlag && item.DNMTR_CODE!=null && item.DNMTR_EDIT_MARK==1"
                      class="cell-edit-input"
                    >{{ item.DNMTR_CODE_VALUE }}</span>
                    <span
                      v-if="item.REPORT_NAME.includes('麻醉科医患比（DB）') && editFlag && item.DNMTR_CODE!=null && item.DNMTR_EDIT_MARK==1"
                      class="cell-edit-input"
                    >
                      <el-input
                        :precision="0"
                        v-model="item.DNMTR_CODE_VALUE"
                        controls-position="right"
                        v-on:click.native="check_num(item)"
                      ></el-input>
                    </span>
                  </td>
                  <td
                    width="82px"
                    style="text-align:center;"
                    :class="item.FATHER_CHILD === 1?'noline':'withline'"
                  >
                    <span class="tdTitle2">{{item.PERCENT}}</span>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </div>
    <el-dialog
      custom-class="reportMaintain"
      title="不良事件明细"
      width="1274px"
      :visible.sync="dialogVisible"
    >
      <div class="table_Dialog">
        <table style="width:99%;table-layout:fixed;word-break:break-all;">
          <thead class="tableHead">
            <th width="70px">手术间</th>
            <th width="100px">姓名</th>
            <th width="70px">住院号</th>
            <th width="25%">手术科室</th>
            <th width="30%">麻醉方法</th>
            <th width="80px">ASA分级</th>
            <th width="100px">麻醉医生</th>
            <th width="45%" style="min-width:180px;">手术名称</th>
            <th width="80px">日期</th>
            <th width="150px">不良事件</th>
            <th width="65px"></th>
            <th width="65px"></th>
          </thead>
          <tbody>
            <tr
              :key="index"
              v-for="(item,index) in tableDetailData"
              :class="calDetailClass(index+1)"
            >
              <td style="width:70px;">{{item.OPER_ROOM_NO}}</td>
              <td style="width:100px;">
                <p style="line-height:24px;font-weight:bold;">{{item.NAME}}</p>
                <p>{{item.SEX}} {{item.AGE}}</p>
              </td>
              <td style="width:70px;">{{item.PATIENT_ID}}</td>
              <td style="width:25%;">{{item.DEPT_NAME}}</td>
              <td width="30%">{{item.ANES_METHOD}}</td>
              <td width="80px">{{item.ASA_GRADE}}</td>
              <td style="width:100px;">{{item.ANES_DOCTOR}}</td>
              <td
                style="width:45%;text-align: left;white-space: nowrap;text-overflow: ellipsis;overflow: hidden; padding-left:10px;padding-right:10px;"
              >
                <el-tooltip
                  class="item"
                  effect="dark"
                  :content="item.OPERATION_NAME"
                  placement="top"
                >
                  <span style="line-height:13px;">{{item.OPERATION_NAME}}</span>
                </el-tooltip>
              </td>
              <td style="width:80px;">
                <p style="line-height:22px">{{item.SCHEDULED_DATE_TIME | formatDate('YYYY-MM-DD')}}</p>
                <p>{{item.SCHEDULED_DATE_TIME | formatDate('HH:mm')}}</p>
              </td>
              <td style="width:150px;">{{item.AE_DETAIL}}</td>
              <td style="width:65px;">
                <el-switch
                  v-model="item.UPLOAD"
                  :active-value="1"
                  :inactive-value="0"
                  :disabled="isUpload?true:false"
                  @change="uploadAdverseEvent(item)"
                  active-color="#13ce66"
                  inactive-color="#B1D9E3"
                ></el-switch>
              </td>
              <td
                class="mdsd-iconfont mdsd-icon-edit"
                style="width:65px;font-size:18px;"
                @click="searchRegisterInfo(item)"
              ></td>
            </tr>
          </tbody>
        </table>
      </div>
    </el-dialog>
    <el-dialog
      title
      width="340px"
      top="25vh"
      :visible.sync="loginDialogVisible"
      :close-on-click-modal="true"
      custom-class="viewdialogLogin"
      @close="loginDialogVisible = false"
    >
      <div style="display: flex;flex-direction: column;">
        <div class="viewdialogLogin_Header"></div>
        <div class="viewdialogLogin_Top">质控云平台登录</div>
        <div class="viewdialogLogin_Content">
          <el-form v-bind:model="acount" label-width="75px" ref="acount" v-bind:rules="rules2">
            <el-form-item label="用户名：" prop="loginname">
              <el-input
                v-model="acount.loginname"
                placeholder="请输入用户名"
                auto-complete="off"
                style="width:200px;"
              ></el-input>
            </el-form-item>
            <el-form-item label="密 码：" prop="password" style="margin-top:10px;">
              <el-input
                type="password"
                ref="pwd"
                v-model="acount.password"
                placeholder="请输入密码"
                auto-complete="off"
                style="width:200px;"
              ></el-input>
            </el-form-item>
            <el-form-item style="margin-top:10px;margin-left:110px;">
              <el-button size="mini" type="primary" style="width:80px;" v-on:click="btnOk()">确定</el-button>
            </el-form-item>
            <el-form-item></el-form-item>
          </el-form>
        </div>
      </div>
    </el-dialog>
  </div>
</template>

<script>
import QualityReportMaintain from './QualityReportMaintain.js'
export default QualityReportMaintain
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";
@media screen and (max-aspect-ratio: 1000/1000) {
  //竖版
  .mainLeft {
    display: none;
  }
  .rightHead {
    height: 70px;
    background: #f5f9fb;
    box-shadow: 0px 0px 8px 0px rgba(112, 132, 142, 0.15);
    border-radius: 10px;
  }
  .rptName {
    margin-left: 10px;
    display: inline;
  }
  .headTitle1 {
    margin-left: 10px;
    display: none;
  }
  .QualityReported .quanlityDiv {
    min-height: 1366px;
  }
}
@media screen and (min-aspect-ratio: 1001/1000) {
  //横版
  .rptName {
    display: none;
  }
  .headTitle1 {
    margin-left: 10px;
    display: inline;
  }
}
.main {
  margin-top: 50px;
  // width: px2rem(1318);
  font-size: 12px;
  color: #484848;
  display: flex;
  flex-direction: row;
  .mainLeft {
    width: 247px;
    height: 300px;
    background: rgba(255, 255, 255, 1);
    box-shadow: 0px 0px 8px 0px rgba(112, 132, 142, 0.15);
    margin-top: 35px;
    margin-right: 5px;
    .title1 {
      margin-top: 15px;
      margin-left: 15px;
      font-size: 14px;
      font-weight: 400;
      line-height: 35px;
      color: rgba(74, 74, 74, 1);
    }
    .title2 {
      margin-top: 25px;
      margin-left: 15px;

      height: 20px;
      font-size: 14px;
      font-weight: 400;
      color: rgba(134, 134, 134, 1);
    }
    .reportNameSelected {
      margin-top: 5px;
      margin-left: 10px;
      width: 229px;
      height: 29px;
      background: rgba(43, 202, 234, 0.17);
      border: 1px solid rgba(43, 202, 234, 1);
      border-radius: 5px;
      display: flex;
      align-items: center;
      .docSelect {
        color: #009de6;
        margin-left: 10px;
        margin-right: 5px;
      }
    }
    .doc {
      margin-left: 10px;
      margin-right: 5px;
    }
    .reportName {
      margin-top: 5px;
      margin-left: 10px;
      width: 229px;
      height: 29px;
      display: flex;
      align-items: center;
    }
    .reportName:hover {
      cursor: pointer;
    }
    .reportNameSelected hover {
      cursor: none;
    }
    .reportName_icon {
      width: 15px;
      height: 15px;
      margin-left: 15px;
      margin-right: 15px;
    }
  }
  .mainRight {
    width: 100%;
    min-height: 1000px;
    margin: 0px auto;
    //width: 1045px;
    // background: rgba(255, 255, 255, 1);

    .rightHead {
      display: flex;
      flex-direction: rows;
      align-items: center;
      .headTitle1 {
        font-size: 16px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: rgba(72, 72, 72, 1);
      }
      .headTitle2 {
        margin-top: 3px;
        font-size: 12px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: rgba(141, 141, 141, 1);
        margin-right: 50px;
      }
      .headTitle2 :hover {
        cursor: pointer;
      }
      .edit-icon {
        color: #00bcf1;
        margin-left: 10px;
        margin-right: 10px;
        font-size: 16px;
      }
    }
    .table_main {
      display: flex;
      flex-direction: column;
      align-items: center;
      width: 100%;
      min-height: 493px;
      margin-top: 6px;
      margin-bottom: 30px;
      background: rgba(255, 255, 255, 1);
      border: 1px solid rgba(233, 234, 235, 1);
      box-shadow: 0px 0px 8px 0px rgba(112, 132, 142, 0.15);
      border-left: 0px;
      border-right: 0px;

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
      .tableChildRow {
        height: 49px;
        color: rgba(74, 74, 74, 1);
        text-align: center;
        background: rgba(255, 255, 255, 1);
        border-right: 1px solid rgba(233, 234, 235, 1);
        vertical-align: middle;
        font-size: 12px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
      }
      td {
        vertical-align: middle;
        font-size: 12px;
      }
      .noline {
        text-align: left;
      }
      .withtopline {
        text-align: left;
        border-top: 1px solid #dcdfe6;
      }
      .withbottomline {
        text-align: left;
        border-bottom: 1px solid #dcdfe6;
      }
      .tdTitle1 {
        font-size: 11px;
        font-weight: 400;
        text-align: left;
        color: rgba(142, 142, 142, 1);
      }
      .tdTitle2 {
        font-size: 12px;
        font-family: MicrosoftYaHei-Bold;
        font-weight: bold;
        color: rgba(72, 72, 72, 1);
      }
      .fenzi {
        width: 50px;
        line-height: 29px;
        height: 29px;
        background: rgba(43, 202, 234, 0.17);
        border: 1px solid rgba(43, 202, 234, 1);
        border-radius: 5px;
      }
      .showDetal {
        color: #399f6b;
        width: 51px;
        padding: 5px 0px 5px 5px;
        font-size: 12px;
        background: #b1ebca;
        border: 1px solid #2ad086;
        border-radius: 5px;
      }
    }
  }
  .main_head {
    display: flex;
    flex-direction: row;
    .inputstatus {
      width: 153px;
      height: 26px;
      border-radius: 5px;
    }
  }

  .table_Dialog {
    display: flex;
    flex-direction: column;
    align-items: center;
    width: 100%;
    min-height: 493px;
    background: rgba(255, 255, 255, 1);
    border-left: 0px;
    border-right: 0px;

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
    .tdTitle1 {
      font-size: 11px;
      font-weight: 400;
      text-align: left;
      color: rgba(142, 142, 142, 1);
    }
    .tdTitle2 {
      font-size: 12px;
      font-family: MicrosoftYaHei-Bold;
      font-weight: bold;
      color: rgba(72, 72, 72, 1);
    }
    .fenzi {
      width: 50px;
      line-height: 29px;
      height: 29px;
      background: rgba(43, 202, 234, 0.17);
      border: 1px solid rgba(43, 202, 234, 1);
      border-radius: 5px;
    }
    .headTitle2:hover {
      cursor: help;
    }
  }
  .PrintArea {
    display: flex;
    flex-direction: column;
    .PrintAreaHeader {
      text-align: center;
      width: 100%;
      margin: 20px 0 20px 0;
    }

    .PrintAreaContent {
      margin: 5px auto 0px;
    }
  }
}

.viewdialogLogin {
  .viewdialogLogin_Header {
    width: 340px;
    height: 4px;
    background: rgba(0, 188, 241, 1);
    border-radius: 5px;
  }

  .viewdialogLogin_Top {
    height: 17px;
    font-size: 20px;
    font-family: MicrosoftYaHei;
    font-weight: 400;
    color: rgba(69, 69, 69, 1);
    margin: 13px 0 0 20px;
  }

  .viewdialogLogin_Content {
    margin: 23px 0 0 20px;
  }
}
</style>
<style lang="scss">
@import "@/assets/styles/global.scss";
.main .el-scrollbar__wrap {
  overflow-x: hidden;
  overflow-y: hidden;
}
.main .el-scrollbar__thumb {
  background-color: #1896ca;
}
.main .inputstatus {
  .el-input__inner {
    height: 26px;
  }
}
.main.inputstatus1 {
  .el-input__inner {
    height: 26px;
    background-color: #cef3f8;
  }
}

.main .el-button--primary {
  color: #fff;
  background-color: #00bcf1;
  border-color: #00bcf1;
}
.reportMaintain .el-dialog__header {
  padding: 20px 20px 10px;
  border-top: 4px solid #1daef1;
}

.reportMaintain .el-dialog__body {
  padding: 15px 20px;
  color: #606266;
  font-size: 14px;
}

.main .el-input-number--small .el-input-number__decrease,
.el-input-number--small .el-input-number__increase {
  width: 20px;
  font-size: 13px;
}
.main .el-input-number.is-controls-right .el-input__inner {
  padding-left: 2px;
  padding-right: 22px;
}
.mainRight .el-input--mini {
  font-size: 14px;
}

.viewdialogLogin .el-button--primary {
  color: #fff;
  background-color: #00bcf1;
  border-color: #00bcf1;
}

.viewdialogLogin .el-input__inner {
  height: 26px;
  background-color: #fff;
}

.viewdialogLogin .el-dialog__header {
  padding: 0px 0px 0px;
}

.viewdialogLogin .el-dialog__body {
  padding: 0px 0px;
  color: #606266;
  font-size: 14px;
  height: 220px;
  background: rgba(255, 255, 255, 1);
  box-shadow: 0px 0px 8px 0px rgba(48, 50, 51, 0.55);
  border-radius: 5px;
}
</style>
