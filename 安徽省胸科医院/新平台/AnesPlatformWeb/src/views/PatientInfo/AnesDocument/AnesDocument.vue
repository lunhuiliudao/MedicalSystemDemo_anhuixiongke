<template>
  <div class="AnesDocument">
    <div class="topMain">
      <div
        :class="item.MR_SUB_CLASS===selected?'mainSelect':'mainNoSelect'"
        :key="index"
        v-for="(item,index) in DoucumentList"
        @click="DocChange(item.MR_SUB_CLASS,item.DOCPATH)"
      >{{item.MR_SUB_CLASS}}</div>
    </div>
    <div class="mainRight">
      <div class="pdftoolbar">
        <div v-show="numPages>1" style=" display: flex;flex-direction: row;align-items: center;">
          <el-input-number style="width:120px;" size="mini" v-model="page" :min="1" :max="numPages"></el-input-number>
          <span style="font-size:14px">共{{numPages}}页</span>&nbsp;&nbsp;&nbsp;
        </div>
        <el-button-group>
          <el-button
            size="mini"
            type="primary"
            title="正旋转"
            @click="rotate += 90"
            style="font-weight: bolder"
          >&#x27F3;</el-button>
          <el-button
            size="mini"
            type="primary"
            title="逆旋转"
            @click="rotate -= 90"
            style="font-weight: bolder"
          >&#x27F2;</el-button>
          <el-button
            size="mini"
            type="primary"
            title="打印"
            @click="$refs.pdf.print()"
            icon="el-icon-printer"
          ></el-button>
          <el-button
            size="mini"
            type="primary"
            title="缩小"
            @click="pdfZoomOut"
            icon="el-icon-zoom-out"
          ></el-button>
          <el-button
            size="mini"
            type="primary"
            title="放大"
            @click="pdfZoomIn"
            icon="el-icon-zoom-in"
          ></el-button>
        </el-button-group>
      </div>
      <div
        class="pdfprogress"
        v-if="loadedRatio > 0 && loadedRatio < 1"
        :style="{ width: loadedRatio * 100 + '%' }"
      >&nbsp;</div>
      <div class="pdfmain" v-bind:style="{'height':osHeight-80+'px','width': osWidth+'px'}">
        <el-scrollbar v-bind:style="{'height':osHeight-80+'px','width': osWidth+'px'}">
          <pdf
            ref="pdf"
            class="pdf"
            :src="GetCurrentDocPDF"
            :page="page"
            :rotate="rotate"
            @password="password"
            @progress="loadedRatio = $event"
            @error="error"
            @num-pages="numPages = $event"
            v-bind:style="{'width': CalDocWidth()+'px'}"
          >></pdf>
        </el-scrollbar>
      </div>
    </div>
  </div>
</template>

<script>
import AnesDocument from './AnesDocument.js'
export default AnesDocument
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
.AnesDocument {
  .topMain {
    display: flex;
    flex-direction: row;
    margin-left: 40px;
    .mainSelect {
      color: #2b2a2a;
      font-size: 12px;
      background-color: #8fd6ff;
      border: 1px solid #2bcaea;
      border-radius: 10px;
      padding: 5px 15px;
      margin-left: 15px;
      cursor: pointer;
    }
    .mainNoSelect {
      color: #2b2a2a;
      font-size: 12px;
      border: 1px solid #2bcaea;
      border-radius: 10px;
      padding: 5px 15px;
      margin-left: 15px;
      cursor: pointer;
    }
  }

  .mainRight {
    width: 100%;
    margin: 0px auto;
    .pdftoolbar {
      text-align: center;
      margin: 10px auto;
      display: flex;
      flex-direction: row-reverse;
      align-items: center;
    }

    .pdfprogress {
      background-color: #20a0ff;
      height: 3px;
      -moz-border-radius: 4px;
      -webkit-border-radius: 4px;
      border-radius: 4px;
      text-align: center;
    }

    .pdfmain {
      overflow: auto;
      margin: 0px auto;
      .pdf {
        min-width: 760px;
        margin: 10px auto;
        max-width: 1060px;
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
}
</style>
<style lang="scss">
@import "@/assets/styles/global.scss";
.AnesDocument .el-scrollbar__wrap {
  overflow-x: hidden;
  // overflow-y: hidden;
}
.AnesDocument .el-scrollbar__thumb {
  background-color: #1896ca;
}
.AnesDocument .el-input-number--mini .el-input-number__decrease,
.el-input-number--mini .el-input-number__increase {
  line-height: 26px;
}
</style>
