<template>
  <div class="report-wrapper">
    <div id="condition-wrapper">
      <div id="condition-top-wrapper"></div>
        <span class="title-wrapper">
          开始时间：
        </span>
        <div class="control-wrapper">
          <el-date-picker size="small" style="width:100%" v-model="startTime" :clearable="false" :editable="false" placeholder="选择日期"></el-date-picker>
        </div>
        <span class="title-wrapper">
          结束时间：
        </span>
        <div class="control-wrapper">
          <el-date-picker size="small" style="width:100%" v-model="endTime" :clearable="false" :editable="false" placeholder="选择日期"></el-date-picker>
        </div>
      <div class="SeatchControl">
        <div class="Search_button">
          <el-button class="btnType" size="mini" type="primary" icon="el-icon-search" v-on:click="searchData(1)">搜 索</el-button>
        </div>
      </div>
    </div>
    <div class="report-main-wrapper">
      <div class="report-main-top-wrapper"></div>
      <div class="fun-wrapper">
        <div class="result-wrapper">搜索结果：{{tableData.length}}个结果</div>
        <div class="fun-button-wrapper">
          <el-button size="mini" type="primary" class="hs-button">导出</el-button>
          <a id="hrefToExportTable" style="display: none;"></a>
          <el-button size="mini" type="primary" class="hs-button" v-print="'#printTable'">打印</el-button>
        </div>
      </div>
      <div class="report-data-wrapper">
        <div class="data-title-wrapper">手术列表</div>
        <div class="data-view-wrapper">
          <el-table :data="tableData" class="anesreport-table" :row-class-name="tableRowClassName" :header-cell-style="{'padding': '0px', 'height':'43px' ,'background-color':'white', 'color': '#4a4a4a'}" :cell-style="{'padding': '0px','height':'43px'}" border style="width: 100%">
            <el-table-column prop="date"  label="日期" width="180">
            </el-table-column>
            <el-table-column  prop="name" label="姓名" width="180">
            </el-table-column>
            <el-table-column prop="address" label="地址">
            </el-table-column>
          </el-table>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Demo from './Demo.js'
export default Demo
</script>

<style lang="scss" scoped>
@import "@/assets/styles/mixinscss.scss";
.report-wrapper {
  width: 100%;
  height: 100%;
  margin-top: 37px;
  #condition-wrapper {
    width: 100%;
    height: 100%;
    font-size: px2rem(12);
    color: #656565;
    display: flex;
    align-items: center;
    flex-wrap: wrap;
    margin-bottom: -5px;
    box-shadow:0px 0px 8px 0px #70848e26;
    background-color: white;
    #condition-top-wrapper {
      width: 100%;
      height:32px;
      background:#1896ca;
      margin-bottom: 6px;
    }
    .title-wrapper {
      text-align: right;
      font-family:MicrosoftYaHei;
      font-weight:400;
      color:#656565;
      font-size: 12px;
      margin-bottom: 5px;
    }
    .control-wrapper {
      margin-bottom: 5px;
    }
    .SeatchControl {
      display: flex;
      align-items: center;
      justify-content: flex-end;
      flex-grow: 1;
      padding-right: 42px;
      margin-bottom: 5px;
      .Search_button {
        .btnType {
          @include buttonStyle(128px,32px,#3dd18a,#88e7b9)
        }
      }
    }
  }
}
#sqlarea {
  top: -1000px;
  position: absolute;
}

@media screen and (min-aspect-ratio: 1001/1000) {
  .report-wrapper {
    min-width: 1300px;
    #condition-wrapper {
      .title-wrapper {
        width: 100px;
      }
      .control-wrapper {
        width: 215px;
      }
    }
  }
}
@media screen and (max-aspect-ratio: 1000/1000) {
  .report-wrapper {
    min-width: 730px;
    max-width: 1080px;
    #condition-wrapper {
      .title-wrapper {
        width: 71px;
      }
      .control-wrapper {
        width: 172px;
      }
    }
  }
}
</style>
<style lang="scss">
@import "@/assets/styles/mixinscss.scss";
.report-main-wrapper {
  width: 100%;
  box-shadow:0px 0px 8px 0px #70848e26;
  margin-top: 26px;
  background-color: white;
  .report-main-top-wrapper {
    height:5px;
    background:linear-gradient(90deg,rgba(36,197,240,1),rgba(103,245,184,1));
  }
  .fun-wrapper {
    display: flex;
    height: 62px;
    align-items: center;
    justify-content: space-between;
    .result-wrapper {
      padding-left: 14px;
      font-size:12px;
      font-family:MicrosoftYaHei;
      font-weight:400;
      color:rgba(24,150,202,1);
    }
    .fun-button-wrapper {
      padding-right: 46px;
      .hs-button {
        @include buttonStyle(99px,28px,#c7d5db,#c1cacf,#505050)
      }
      .ls-button {
        @include buttonStyle(99px,28px,#00bcf1,#5cd2f3)
      }
    }
  }
  .report-data-wrapper {
    width: 97%;
    background:#ffffff;
    border:1px solid #e9eaeb;
    padding: 5px;
    margin: 0px auto;
    .data-title-wrapper {
      width:100%;
      height: 28px;
      line-height: 28px;
      text-align: center;
      background:#e9f2f5;
      font-size:12px;
      font-family:MicrosoftYaHei;
      font-weight:400;
      color:#505050;
    }
    .data-view-wrapper {
      margin-top: 2px;
      font-size: 12px;
      font-family:MicrosoftYaHei;
      font-weight:400;
      color:rgba(80,80,80,1);
    }
  }
  .PaginationView {
    text-align: center;
    padding: 10px 0px;
  }
}
</style>
<style>
  .anesreport-table .success-row {
    background:#d8f0fa;
  }
  .anesreport-table .default-row {
    background:white;
  }
  .el-table tbody .success-row:hover>td {
    background-color: #F9F2D4;
  }
  .el-table tbody .default-row:hover>td {
    background-color: #F9F2D4;
  }
  .el-table--enable-row-hover .el-table__body .success-row:hover>td {
    background-color: #F9F2D4;
  }
  .el-table--enable-row-hover .el-table__body .default-row:hover>td {
    background:#F9F2D4;
  }
  .el-table__body .success-row.hover-row>td {
    background-color: #F9F2D4;
  }
  .el-table__body .default-row.hover-row>td {
    background-color: #F9F2D4;
  }
</style>
