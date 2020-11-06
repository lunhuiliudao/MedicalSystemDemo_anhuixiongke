<template>
  <div class="report-wrapper">
    <el-dialog
      width="80%"
      :close-on-click-modal="false"
      :visible.sync="dialogSubDataVisible"
      custom-class="queryViewdialog"
      v-if="reportInformation!=null"
    >
      <div slot="title">
        <span style="font-size:17px">详情</span>
      </div>
      <GeneralSubView
        ref="genesuview"
        :parentReportName="reportInformation.ReportTitle.ReportName"
        :reportInformation="reportSubInformation"
      >
        <template slot="funbutton">
          <el-button type="primary" @click="exprotSubReportExcel" class="hs-button" size="mini">导 出</el-button>&nbsp;&nbsp;
          <a id="hrefToExportSubTable" style="display: none;width: 0px;height: 0px;"></a>
          <el-button type="primary" @click="showSubSqlDialog" class="ls-button" size="mini">查看SQL</el-button>
        </template>
      </GeneralSubView>
    </el-dialog>

    <el-dialog
      :close-on-click-modal="false"
      :visible.sync="dialogSubSQLViewVisible"
      v-if="reportSubInformation!=null"
      custom-class="sqlqueryViewdialog"
    >
      <div class="sqlClass">
        <div class="sqlHeader"></div>
        <div class="sqlTop">
          <div class="sqlTitle">SQL语句</div>
          <div class="sqlCopy">
            <el-button type="text" @click="copySql">[复 制]</el-button>
          </div>
        </div>
        <div class="sqlMain">
          <textarea
            id="sqlarea"
            cols="20"
            rows="10"
            v-text="reportSubInformation.ReportTitle.StrSql"
          ></textarea>
          <pre
            v-highlightjs="reportSubInformation.ReportTitle.StrSql"
            style="max-height:500px;overflow: auto;margin-top:0px;"
          ><code class="sql"></code></pre>
        </div>
      </div>
    </el-dialog>

    <el-dialog
      title
      :close-on-click-modal="false"
      :visible.sync="dialogSQLViewVisible"
      v-if="reportInformation!=null"
      custom-class="sqlqueryViewdialog"
    >
      <div class="sqlClass">
        <div class="sqlHeader"></div>
        <div class="sqlTop">
          <div class="sqlTitle">SQL语句</div>
          <div class="sqlCopy">
            <el-button type="text" @click="copySql">[复 制]</el-button>
          </div>
        </div>
        <div class="sqlMain">
          <textarea id="sqlarea" cols="20" rows="10" v-text="reportInformation.ReportTitle.StrSql"></textarea>
          <pre
            v-highlightjs="reportInformation.ReportTitle.StrSql"
            style="max-height:500px;overflow: auto;margin-top:0px;"
          ><code class="sql"></code></pre>
        </div>
      </div>
    </el-dialog>
    <el-dialog
      :close-on-click-modal="false"
      :visible.sync="dialogChartViewVisible"
      v-if="reportInformation!=null"
      custom-class="queryViewdialog"
    >
     <div slot="title">
        <span style="font-size:17px">图表</span>
      </div>
      <!-- <div class="chartClass">
        <div class="chartHeader"></div>
        <div class="chartTop">
          <div class="chartTitle">图表</div>
        </div>
        <div class="chartMain"> -->
          <ChartReportView
            :key="comChartReportKey"
            :reportInformation="reportInformation"
            :reportData="reportData"
          ></ChartReportView>
        <!-- </div>
      </div> -->
    </el-dialog>
    <div id="condition-wrapper" v-if="reportInformation!=null">
      <div id="condition-top-wrapper"></div>
      <template v-for="(colItem,colIndex) in comReportConditionList">
        <span :key="'t'+colIndex" class="title-wrapper">{{colItem.Title}}：</span>
        <div :key="'c'+colIndex+colItem" class="control-wrapper">
          <el-date-picker
            size="small"
            style="width:100%"
            v-model="colItem.Value"
            v-if="colItem.ControlType==='DatePick'"
            :type="colItem.DateControlType"
            :clearable="false"
            :editable="false"
            placeholder="选择日期"
          ></el-date-picker>
          <el-date-picker
            size="small"
            style="width:100%"
            v-model="colItem.Value"
            v-if="colItem.ControlType==='DateTimePicker'"
            :type="colItem.DateControlType"
            :clearable="true"
            :editable="false"
            placeholder="选择日期时间"
          ></el-date-picker>
          <el-input
            size="small"
            v-model="colItem.Value"
            v-if="colItem.ControlType==='TextBox'"
            style="width:100%"
          ></el-input>
          <DropDownList :condition="colItem" v-if="colItem.ControlType==='DropDownList'"></DropDownList>
        </div>
      </template>
      <div class="SeatchControl">
        <!-- <div class="GeneralView_Search_Check mdsdCheckBoxNoBorder">
          <el-checkbox
            v-model="myOperCheck"
            style="width:120px;margin-top:5px;"
            :true-label="1"
            :false-label="0"
            label="我的手术"
          ></el-checkbox>
        </div> -->
        <div class="Search_button">
          <el-button
            class="btnType"
            size="mini"
            type="primary"
            icon="el-icon-search"
            v-on:click="searchData(1)"
          >搜 索</el-button>
        </div>
      </div>
    </div>

    <div class="report-main-wrapper">
      <div class="report-main-top-wrapper"></div>
      <div class="fun-wrapper" v-if="reportInformation!=null">
        <div class="result-wrapper">搜索结果：{{reportData.total}}个结果</div>
        <div class="fun-button-wrapper">
          <el-checkbox
            v-model="item.Value"
            true-label="1"
            false-label="0"
            :key="index"
            v-for="(item,index) in comCheckBoxConditionList"
          >{{item.Title}}</el-checkbox>
          <el-button size="mini" type="primary" class="hs-button" @click="exprotExcel">导出</el-button>
          <a id="hrefToExportTable" style="display: none;"></a>
          <el-button size="mini" type="primary" class="hs-button" v-print="'#printTable'">打印</el-button>
          <el-button
            size="mini"
            type="primary"
            class="hs-button"
            @click="showChartData"
            v-if="reportInformation.ReportChartInfo !==null &&reportInformation.ReportChartInfo.ChartType!==''"
          >图表数据</el-button>
          <el-button size="mini" type="primary" class="ls-button" @click="showSqlDialog">查看SQL</el-button>
        </div>
      </div>
      <div class="report-data-wrapper">
        <div class="data-title-wrapper">手术列表</div>
        <div class="data-view-wrapper" v-if="reportInformation!=null">
          <el-table
            class="anesreport-table"
            :key="reportInformation.ReportTitle.ReportName"
            :row-class-name="tableRowClassName"
            :show-summary="reportInformation.ReportTitle.ShowSummary"
            :summary-method="getSummaries"
            :header-cell-style="{'padding': '0px', 'height':'43px' ,'background-color':'white', 'color': '#4a4a4a'}"
            :cell-style="{'padding': '0px','height':'43px','font-size':'12px'}"
            :data="reportData.currentData"
            border
            v-loading="loading"
            element-loading-text="拼命加载中"
            style="width: 100%"
          >
            <el-table-column
              show-overflow-tooltip
              :prop="item.FieldName"
              v-bind="item.widthObj"
              :label="item.Title"
              :sortable="item.IsSort"
              :align="item.Align"
              :key="item.FieldName + index"
              v-for="(item, index) in reportInformation.ReportColumnList.filter(x=>{return x.IsSHow})"
            >
              <el-table-column
                show-overflow-tooltip
                :prop="item2.FieldName"
                :label-class-name="item.Title"
                v-bind="item2.widthObj"
                :label="item2.Title"
                :sortable="item2.IsSort"
                :align="item2.Align"
                :key="item2.FieldName+index+index2"
                v-for="(item2, index2) in item.ReportColumnList.filter(x=>{return x.IsSHow})"
              >
                <template slot-scope="scope">
                  <el-button
                    type="text"
                    @click="searchSubData(scope.column, scope.row, scope.$index,scope.store)"
                    v-if="item2.IsSubReportCondition"
                  >{{scope.row[item2.FieldName]}}</el-button>
                  <span v-else>{{scope.row[item2.FieldName]}}</span>
                </template>
              </el-table-column>
              <template slot-scope="scope">
                <el-button
                  type="text"
                  @click="searchSubData(scope.column, scope.row, scope.$index,scope.store)"
                  v-if="item.IsSubReportCondition"
                >{{scope.row[item.FieldName]}}</el-button>
                <span v-else>{{scope.row[item.FieldName]}}</span>
              </template>
            </el-table-column>
            <el-table-column
              fixed="right"
              width="60"
              v-if="reportInformation.ReportTitle.IsLinkButton"
              label
            >
              <template slot-scope="scope">
                <div style="display:flex;justify-content:center;cursor: pointer;">
                  <img
                    src="@/assets/images/bglink.png"
                    @click="inMedicalRecordPath(scope.row)"
                    alt
                    title="病案"
                  >
                </div>
              </template>
            </el-table-column>
          </el-table>
        </div>
      </div>
      <div class="PaginationView" v-if="reportInformation!=null">
        <el-pagination
          :current-page="reportData.currentPage"
          background
          :page-size="reportInformation.ReportTitle.PageSize"
          :total="reportData.total"
          v-if="reportData.total > reportInformation.ReportTitle.PageSize?true:false"
          @current-change="handleCurrentChange"
          layout="total, prev, pager, next"
        ></el-pagination>
      </div>
    </div>
    <div v-show="false">
      <table id="printTable" width="100%" border="1" style="text-align: center;">
        <tr>
          <td
            v-bind="tablePrintCom(item)"
            :key="'td'+item.FieldName+index"
            v-for="(item, index) in reportInformation.ReportColumnList.filter(x=>{return x.IsSHow})"
          >{{item.Title}}</td>
        </tr>
        <tr>
          <template
            v-for="(item) in reportInformation.ReportColumnList.filter(x=>{return x.IsSHow})"
          >
            <td
              :key="'td'+item2.FieldName+index"
              v-for="(item2, index) in item.ReportColumnList.filter(x=>{return x.IsSHow})"
            >{{item2.Title}}</td>
          </template>
        </tr>
        <tr :key="'tr'+index" v-for="(data, index) in reportData.currentData">
          <td
            :key="'tr'+index+'_'+index2"
            v-for="(item, index2) in tableColumnList()"
          >{{data[item.FieldName]}}</td>
        </tr>
      </table>
    </div>
  </div>
</template>

<script>
import 'highlight.js/styles/vs.css'
import GeneralView from './GeneralView.js'
export default GeneralView
</script>

<style lang="scss" scoped>
@import "@/assets/styles/mixinscss.scss";
.report-wrapper {
  width: 100%;
  height: 100%;
  margin-top: 5px;
  #condition-wrapper {
    width: 100%;
    height: 100%;
    font-size: px2rem(12);
    color: #656565;
    display: flex;
    align-items: center;
    flex-wrap: wrap;
    margin-bottom: -5px;
    box-shadow: 0px 0px 8px 0px #70848e26;
    background-color: white;
    #condition-top-wrapper {
      width: 100%;
      height: 32px;
      background: #1896ca;
      margin-bottom: 6px;
    }
    .title-wrapper {
      text-align: right;
      font-family: MicrosoftYaHei;
      font-weight: 400;
      color: #656565;
      font-size: 12px;
      margin-bottom: 5px;

      height: 12px;
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
          @include buttonStyle(128px, 32px, #3dd18a, #88e7b9);
        }
      }
      .GeneralView_Search_Check {
        width: 100px;
        height: 26px;
        cursor: pointer;
      }
    }
  }

  .sqlClass {
    width: 100%;
    height: 540px;
    background: rgba(255, 255, 255, 1);
    box-shadow: 0px 0px 8px 0px rgba(48, 50, 51, 0.55);
    border-radius: 5px;
    display: flex;
    flex-direction: column;

    .sqlHeader {
      width: 100%;
      height: 4px;
      background: rgba(29, 174, 241, 1);
      border-radius: 5px;
    }
    .sqlTop {
      height: 45px;
      display: flex;
      flex-direction: row;
      .sqlTitle {
        font-size: 16px;
        width: 800px;
        height: 40px;
        line-height: 40px;
        margin-left: 10px;
      }
      .sqlCopy {
        text-align: right;
        margin-right: 50px;
      }
    }
  }

  .chartClass {
    // width: 1000px;
    // height: 640px;
    background: rgba(255, 255, 255, 1);
    box-shadow: 0px 0px 8px 0px rgba(48, 50, 51, 0.55);
    border-radius: 5px;
    display: flex;
    flex-direction: column;

    .chartHeader {
      // width: 1000px;
      height: 4px;
      background: rgba(29, 174, 241, 1);
      border-radius: 5px;
    }
    .chartTop {
      height: 40px;
      display: flex;
      flex-direction: row;
      .chartTitle {
        font-size: 16px;
        width: 700px;
        height: 35px;
        line-height: 35px;
        margin-left: 10px;
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
  box-shadow: 0px 0px 8px 0px #70848e26;
  margin-top: 26px;
  background-color: white;
  .report-main-top-wrapper {
    height: 5px;
    background: linear-gradient(
      90deg,
      rgba(36, 197, 240, 1),
      rgba(103, 245, 184, 1)
    );
  }
  .fun-wrapper {
    display: flex;
    height: 62px;
    align-items: center;
    justify-content: space-between;
    .result-wrapper {
      padding-left: 14px;
      font-size: 12px;
      font-family: MicrosoftYaHei;
      font-weight: 400;
      color: rgba(24, 150, 202, 1);
    }
    .fun-button-wrapper {
      padding-right: 46px;
      .hs-button {
        @include buttonStyle(99px, 28px, #c7d5db, #c1cacf, #505050);
      }
      .ls-button {
        @include buttonStyle(99px, 28px, #00bcf1, #5cd2f3);
      }
    }
  }
  .report-data-wrapper {
    width: 97%;
    background: #ffffff;
    border: 1px solid #e9eaeb;
    padding: 5px;
    margin: 0px auto;
    .data-title-wrapper {
      width: 100%;
      height: 28px;
      line-height: 28px;
      text-align: center;
      background: #e9f2f5;
      font-size: 12px;
      font-family: MicrosoftYaHei;
      font-weight: 400;
      color: #505050;
    }
    .data-view-wrapper {
      margin-top: 2px;
      font-size: 12px;
      font-family: MicrosoftYaHei;
      font-weight: 400;
      color: rgba(80, 80, 80, 1);
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
  background: #d8f0fa;
}
.anesreport-table .default-row {
  background: white;
}
.el-table tbody .success-row:hover > td {
  background-color: #f9f2d4;
}
.el-table tbody .default-row:hover > td {
  background-color: #f9f2d4;
}
.el-table--enable-row-hover .el-table__body .success-row:hover > td {
  background-color: #f9f2d4;
}
.el-table--enable-row-hover .el-table__body .default-row:hover > td {
  background: #f9f2d4;
}
.el-table__body .success-row.hover-row > td {
  background-color: #f9f2d4;
}
.el-table__body .default-row.hover-row > td {
  background-color: #f9f2d4;
}

.report-wrapper .el-input__inner {
  height: 26px;
  background: #f7f7f7;
  border-radius: 5px;
}
.report-wrapper .el-input--small .el-input__inner {
  height: 26px;
  line-height: 26px;
}
.report-wrapper .el-input--small .el-input__icon {
  line-height: 22px;
}

.el-select-dropdown__item {
  font-size: 12px;
  height: 26px;
  line-height: 26px;
}

.el-table--border th {
  border-right: 0px solid #ebeef5;
}

.el-table th > .cell {
  font-size: 12px;
}

.sqlqueryViewdialog .el-dialog__header {
  padding: 0px 0px 0px;
}

.sqlqueryViewdialog .el-dialog__body {
  /* width: 90%; */
  padding: 0px 0px;
  color: #606266;
  font-size: 14px;
  height: 540px;
  background: rgba(255, 255, 255, 1);
  box-shadow: 0px 0px 8px 0px rgba(48, 50, 51, 0.55);
  border-radius: 5px;
}

/* .sqlqueryViewdialog .el-dialog__headerbtn {
  right: -20px;
} */

/* .chartqueryViewdialog .el-dialog__header {
  padding: 0px 0px 0px;
}

.chartqueryViewdialog .el-dialog__body {
  width: 1000px;
  padding: 0px 0px;
  color: #606266;
  font-size: 14px;
  height: 540px;
  background: rgba(255, 255, 255, 1);
  box-shadow: 0px 0px 8px 0px rgba(48, 50, 51, 0.55);
  border-radius: 5px;
}

.chartqueryViewdialog .el-dialog__headerbtn {
  right: -20px;
} */

.report-wrapper .el-table--scrollable-x .el-table__body-wrapper {
  overflow-x: auto;
}
</style>
