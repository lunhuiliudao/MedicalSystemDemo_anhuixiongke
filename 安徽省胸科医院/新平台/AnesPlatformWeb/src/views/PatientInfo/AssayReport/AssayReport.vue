<template>
  <div class="AssayReport">
    <div :style="{width: '284px',height:osHeight + 'px'}" class="mainLeft">
      <p class="title1">检验项目</p>
      <el-scrollbar :style="{width: '100%',height:(osHeight - 40) + 'px'}">
        <div style="margin-left:20px; margin-top:15px;" :key="date" v-for="date in checkDateDict">
          <span class="dateTitle">{{date+'（'+ getCount(date) +'）'}}</span>
          <div style="height:10px;"></div>
          <div
            :key="index"
            v-for="(item,index) in checkResultMasterData.filter((r) => {return r.SPCM_RECEIVED_DATE_TIME_SHOW === date})"
            :class="item.TEST_NO===selected?'reportNameSelected':'reportName'"
            @click="resultMasterCurrentChange(item.TEST_NO)"
          >{{item.TEST_CAUSE}}</div>
        </div>
      </el-scrollbar>
    </div>
    <div :style="{width: (osWidth - 300) + 'px',height:osHeight + 'px'}" class="mainRight">
      <div class="table_main">
        <table style="width:99%; margin-top:5px;table-layout:fixed;word-break:break-all;">
          <thead class="tableHead">
            <th width="30%" style="text-align:center;">项目名称</th>
            <th width="15%" style="text-align:center;">结果</th>
            <th width="15%" style="text-align:center;">单位</th>
            <th width="40%">参考值</th>
          </thead>
        </table>
        <el-scrollbar :style="{width: '99%',height:osHeight-60 + 'px'}">
          <div style="width:100%; margin:0px auto; display: flex;margin-bottom: 30px;">
            <table style="width:99%;table-layout:fixed;word-break:break-all;">
              <thead class="tableHeadDisplay">
                <th width="30%"></th>
                <th width="15%"></th>
                <th width="15%"></th>
                <th width="40%"></th>
              </thead>
              <tbody>
                <tr
                  :key="index"
                  v-for="(item ,index) in checkResultDetailData"
                  :class="rowIndex(index)"
                >
                  <td width="30%">
                    <span>{{item.REPORT_ITEM_NAME}}</span>
                  </td>
                  <td width="15%" style="padding:10px;">
                    <span>{{item.RESULT}}</span>
                  </td>
                  <td width="15%" style="padding:10px;">
                    <span>{{item.UNITS}}</span>
                  </td>
                  <td width="40%" style="text-align:center;">
                    <span>{{item.REFERENCE_RESULT}}</span>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </el-scrollbar>
      </div>
    </div>
  </div>
</template>

<script>
import AssayReport from './AssayReport.js'
export default AssayReport
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";
.AssayReport {
  margin-top: -10px;
  // width: px2rem(1318);
  font-size: 12px;
  color: #484848;
  display: flex;
  flex-direction: row;
  .mainLeft {
    margin-top: 8px;
    // width: 274px;
    // height: 865px;
    background: rgba(246, 246, 246, 1);
    box-shadow: 0px 0px 8px 0px rgba(112, 132, 142, 0.15);
    margin-right: 5px;
    .title1 {
      margin-top: 10px;
      margin-left: 20px;
      font-size: 14px;
      font-weight: 400;
      line-height: 35px;
      height: 30px;
      color: rgba(53, 53, 53, 1);
    }
    .dateTitle {
      background: rgba(236, 236, 236, 1);
      border-radius: 10px;
      padding: 3px 10px;
      margin-bottom: 10px;
      font-size: 14px;
    }
    .title2 {
      margin-top: 15px;
      margin-left: 51px;

      height: 20px;
      font-size: 14px;
      font-weight: 400;
      color: rgba(15, 88, 150, 1);
    }
    .reportNameSelected {
      margin-top: 5px;
      margin-left: 10px;
      width: 180px;
      height: 29px;
      background: rgba(143, 214, 255, 1);
      border: 1px solid rgba(43, 202, 234, 1);
      border-radius: 5px;
      display: flex;
      padding-left: 20px;
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
      margin-left: 30px;
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
      .withline {
        text-align: left;
        border-top: 1px solid #dcdfe6;
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
.AssayReport .el-scrollbar__wrap {
  overflow-x: hidden;
  // overflow-y: hidden;
}
.AssayReport .el-scrollbar__thumb {
  background-color: #1896ca;
}
</style>
