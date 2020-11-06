<template>
  <div class="main">
    <div class="main_head">
      <span class="main_head_span">统计月份：</span>
      <el-date-picker
        v-model="searchDate"
        type="month"
        class="main_head_date"
        placeholder="选择月份"
        style="width:110px;"
        :clearable="false"
        @change="searchInfos()"
      ></el-date-picker>
      <el-button
        class="main_head_btn"
        size="mini"
        type="primary"
        @click="extractInfos"
        :disabled="isUpload"
      >更新统计</el-button>
      <el-button
        class="main_head_btn"
        size="mini"
        type="primary"
        @click="dialogVisible = true"
        :disabled="isUpload"
      >生成质控报告</el-button>
      <el-button class="main_head_btn" size="mini" type="primary" @click="print()">打印</el-button>
      <el-button class="main_head_btn" size="mini" type="primary" @click="exprotExcel()">导出</el-button>
      <a id="hrefToExportTable" style="display: none;width: 0px;height: 0px;"></a>
      <el-dialog
        custom-class="QuanlityReport_viewdialog"
        width="351px"
        top="27vh"
        :visible.sync="dialogVisible"
        :close-on-click-modal="true"
        :key="key"
        :append-to-body="false"
        @open="handleOpen()"
        center
      >
        <div class="reportDialogDiv">
          <div class="reportDialogDiv_Header"></div>
          <div class="reportDialogDiv_Top">生成质控报告数据</div>
          <div class="reportDialogDiv_Top2">重命名为</div>
          <div class="reportDialogDiv_Content">
            <el-input v-model="tipInfos" placeholder="请输入"></el-input>
          </div>
          <div class="reportDialogDiv_Remark">注：质控报告生成后可进行调整，形成上报数据</div>
          <div class="reportDialogDiv_Bottom">
            <el-button class="reportDialogDiv_Bottom_Cancel" @click="dialogVisible = false">取 消</el-button>
            <el-button class="reportDialogDiv_Bottom_Sure" type="primary" @click="saveInfos()">确 定</el-button>
          </div>
        </div>
      </el-dialog>
    </div>
    <div class="main_content">
      <div class="main_content_header"></div>
      <div class="main_content_middle">
        <table style="width:100%;">
          <thead class="tableHead">
            <th width="5%">序号</th>
            <th width="20%" style="text-align: left;">名称</th>
            <th style="text-align: left;">说明</th>
            <th width="8%" style="text-align: left;">
              <span style="margin-left:20px;">分子</span>
            </th>
            <th width="8%" style="text-align: left;">
              <span style="margin-left:20px;">分母</span>
            </th>
            <th width="8%" style="text-align: left;">
              <span style="margin-left:20px;">指标率</span>
            </th>
            <th width="4%"></th>
          </thead>
          <tbody>
            <tr :class="rowIndex(item)" v-for="(item,index) in tableData" :key="index">
              <td style="width:5%;vertical-align: middle;">
                <span v-if="item.FATHER_CHILD === 1">{{calIndex(item.GROUP_NO)}}</span>
              </td>
              <td
                v-bind:style="item.FATHER_CHILD === 1?{'width':'20%','vertical-align':'middle','text-align':'left'}:{'width':'20%','vertical-align':'middle','text-align':'left','border-top':'1px solid #dcdfe6'}"
              >{{item.REPORT_NAME}}</td>
              <td
                v-bind:style="item.FATHER_CHILD === 1?{'vertical-align':'middle','text-align':'left','font-size':'11px','font-family':'MicrosoftYaHei','font-weight':'400','color':'rgba(142,142,142,1)'}:{'vertical-align':'middle','text-align':'left','font-size':'11px','font-family':'MicrosoftYaHei','font-weight':'400','color':'rgba(142,142,142,1)','border-top':'1px solid #dcdfe6'}"
              >{{'*'+item.DESCRIBE}}</td>
              <td
                v-bind:style="item.FATHER_CHILD === 1?{'width':'8%','vertical-align':'middle','text-align':'left'}:{'width':'8%','vertical-align':'middle','text-align':'left','border-top':'1px solid #dcdfe6'}"
              >
                <span style="margin-left:20px;">{{item.NMRTR_CODE}}</span>
              </td>
              <td
                v-bind:style="item.FATHER_CHILD === 1?{'width':'8%','vertical-align':'middle','text-align':'left'}:{'width':'8%','vertical-align':'middle','text-align':'left','border-top':'1px solid #dcdfe6'}"
              >
                <span style="margin-left:20px;">{{item.DNMTR_CODE}}</span>
              </td>
              <td
                v-bind:style="item.FATHER_CHILD === 1?{'width':'8%','vertical-align':'middle','text-align':'left'}:{'width':'8%','vertical-align':'middle','text-align':'left','border-top':'1px solid #dcdfe6'}"
              >
                <span style="margin-left:20px;">{{item.PERCENT}}</span>
              </td>
              <td style="width:4%;"></td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
    <div style="display:none;width:100%;">
      <div id="quanlityDataPrintArea" ref="refq" class="PrintArea">
        <div class="PrintAreaHeader" style="text-align:center;font-size:22px;">{{printHeaderText}}</div>
        <div style="height:30px;"></div>
        <table class="PrintAreaContent" width="100%" border="1" cellspacing="0" cellpadding="0">
          <thead>
            <tr>
              <th>序号</th>
              <th>名称</th>
              <th>分子</th>
              <th>分母</th>
              <th>指标率</th>
            </tr>
          </thead>
          <tbody>
            <tr :key="index" v-for="(item,index) in tableData">
              <td style="text-align: center">{{item.FATHER_CHILD ===0?'': item.GROUP_NO }}</td>
              <td>{{item.REPORT_NAME}}</td>
              <td style="text-align: center">{{item.NMRTR_CODE}}</td>
              <td style="text-align: center">{{item.DNMTR_CODE}}</td>
              <td style="text-align: center">{{item.PERCENT}}</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script>
import QualityReport from './QualityReport.js'
export default QualityReport
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";
.main {
  margin: 50px auto;

  height: 100%;
  font-size: 12px;
  color: #484848;
  .main_head {
    display: flex;
    flex-direction: row;

    height: 70px;
    .main_head_span {
      margin: 30px 0 28px 53px;
      font-weight: 600;
    }
    .main_head_date {
      height: 26px;
      background: rgba(247, 247, 247, 1);
      border: 1px solid rgba(220, 220, 220, 1);
      border-radius: 5px;
      margin: 23px 0 21px 7px;
      // font-size: 18px;
    }
    .main_head_btn {
      width: 99px;
      height: 28px;
      background: rgba(0, 188, 241, 1);
      box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
      border-radius: 3px;
      margin: 22px 0 20px 12px;
    }

    .reportDialogDiv {
      display: flex;
      flex-direction: column;
      .reportDialogDiv_Header {
        width: 351px;
        height: 4px;
        background: rgba(0, 188, 241, 1);
        border-radius: 5px;
      }
      .reportDialogDiv_Top {
        height: 17px;
        font-size: 16px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: rgba(69, 69, 69, 1);
        margin: 13px 0 0 20px;
      }
      .reportDialogDiv_Top2 {
        height: 15px;
        font-size: 14px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: rgba(100, 100, 100, 1);
        margin: 30px 0 0 37px;
      }
      .reportDialogDiv_Content {
        height: 36px;
        background: rgba(255, 255, 255, 1);
        color: #dcdcdc;
        border: 1px solid rgba(220, 220, 220, 1);
        border-radius: 5px;
        margin: 8px 31px 0 32px;
      }
      .reportDialogDiv_Remark {
        color: red;
        margin: 10px 0 0 29px;
      }
      .reportDialogDiv_Bottom {
        display: flex;
        flex-direction: row;
        margin: 25px 0 0 71px;
        .reportDialogDiv_Bottom_Cancel {
          width: 99px;
          height: 28px;
          background: rgba(247, 247, 247, 1);
          box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
          border-radius: 3px;
        }
        .reportDialogDiv_Bottom_Sure {
          width: 99px;
          height: 28px;
          background: rgba(0, 188, 241, 1);
          box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
          border-radius: 3px;
        }
      }
    }
  }
  .main_content {
    margin-top: 15px;
    display: flex;
    flex-direction: column;

    .main_content_header {
      height: 4px;
      background: rgba(43, 202, 234, 1);
    }
    .main_content_middle {
      height: 1470px;
      background: rgba(255, 255, 255, 1);
      box-shadow: 0px 0px 8px 0px rgba(112, 132, 142, 0.15);

      .tableHead {
        text-align: center;
        height: 53px;
        background: rgba(255, 255, 255, 1);
        border: 1px solid rgba(233, 234, 235, 1);
        font-size: 12px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
        color: rgba(12, 170, 210, 1);
        vertical-align: middle;
        line-height: 53px;
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
      .tableSingleRow {
        height: 49px;
        color: rgba(74, 74, 74, 1);
        background: rgba(255, 255, 255, 1);
        text-align: center;
        border-right: 1px solid #d8f0fa;
        font-size: 12px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
      }
      .tableDoubleRow {
        height: 49px;
        color: rgba(74, 74, 74, 1);
        text-align: center;
        background: #e9f2f5;
        border-right: 1px solid rgba(233, 234, 235, 1);
        vertical-align: middle;
        font-size: 12px;
        font-family: MicrosoftYaHei;
        font-weight: 400;
      }
    }
  }
}

.PrintArea {
  width: 100%;
  display: flex;
  flex-direction: column;
  .PrintAreaHeader {
    width: 100%;
  }

  .PrintAreaContent {
    font-size: 14px;
    margin: 5px auto 0px;
  }
}

@media screen and (min-aspect-ratio: 1001/1000) {
  //横板
  .main {
    margin: 40px auto;
  }
}
@media screen and (max-aspect-ratio: 1000/1000) {
  // 竖版
  .main_head {
    background: #f5f9fb;
    box-shadow: 0px 0px 8px 0px rgba(112, 132, 142, 0.15);
    border-radius: 10px;
  }
}
</style>
<style lang="scss">
@import "@/assets/styles/global.scss";
.el-scrollbar__wrap {
  overflow-x: hidden;
}
.el-scrollbar__thumb {
  background-color: #1896ca;
}

.main_head .el-input__inner {
  height: 26px;
  line-height: 25px;
}

.main_head .el-input__icon {
  height: 100%;
  width: 25px;
  text-align: left;
  -webkit-transition: all 0.3s;
  transition: all 0.3s;
  line-height: 25px;
  margin-left: 5px;
}

.el-button--primary {
  color: #fff;
  background-color: #00bcf1;
  border-color: #00bcf1;
}

.reportDialogDiv_Bottom .el-button {
  padding: 4px 20px;
}

.QuanlityReport_viewdialog .el-dialog__header {
  padding: 0px 0px 0px;
}

.QuanlityReport_viewdialog .el-dialog__body {
  padding: 0px 0px;
  color: #606266;
  font-size: 14px;
  height: 220px;
  background: rgba(255, 255, 255, 1);
  box-shadow: 0px 0px 8px 0px rgba(48, 50, 51, 0.55);
  border-radius: 5px;
}

.reportDialogDiv_Content .el-input__inner {
  height: 36px;
}

// 改变全局的弹出框的位置
.el-message {
  top: 50px;
}
</style>
