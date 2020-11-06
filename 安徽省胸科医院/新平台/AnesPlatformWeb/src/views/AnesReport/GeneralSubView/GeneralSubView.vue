<template>
  <div class="report-main-wrapper" style="margin-top:10px">
    <div class="report-main-top-wrapper"></div>
    <div class="fun-wrapper">
      <div class="result-wrapper">搜索结果：{{newReportData.total}}个结果</div>
      <div class="fun-button-wrapper">
        <slot name="funbutton"></slot>
      </div>
    </div>
    <div class="report-data-wrapper">
      <div class="data-title-wrapper">手术列表</div>
      <div class="data-view-wrapper" v-if="reportInformation!=null">
        <el-table class="anesreport-table" :key="reportInformation.ReportTitle.ReportName" :row-class-name="tableRowClassName" :header-cell-style="{'padding': '0px', 'height':'43px' ,'background-color':'white', 'color': '#4a4a4a'}" :cell-style="{'padding': '0px','height':'43px'}" :data="newReportData.currentData" v-loading="loading" element-loading-text="拼命加载中" border style="width: 100%">
          <el-table-column v-bind="item.widthObj" :prop="item.FieldName" :label="item.Title" :sortable="item.IsSort" :header-align="item.Align" :show-overflow-tooltip="true" :key="item.FieldName" v-for="item in reportInformation.ReportColumnList.filter(x=>{return x.IsSHow})">
            <el-table-column v-bind="item2.widthObj" :prop="item2.FieldName" :label="item2.Title" :sortable="item2.IsSort" :header-align="item2.Align" :show-overflow-tooltip="true" :key="item2.FieldName" v-for="item2 in item.ReportColumnList.filter(x=>{return x.IsSHow})">
              <template slot-scope="scope">
                <el-button type="text" v-if="item2.IsSubReportCondition">{{scope.row[item2.FieldName]}}</el-button>
                <span v-else>{{scope.row[item2.FieldName]}}</span>
              </template>
            </el-table-column>
            <template slot-scope="scope">
              <el-button type="text" v-if="item.IsSubReportCondition">{{scope.row[item.FieldName]}}</el-button>
              <span v-else>{{scope.row[item.FieldName]}}</span>
            </template>
          </el-table-column>
          <el-table-column fixed="right" width="60" v-if="reportInformation.ReportTitle.IsLinkButton" label="">
            <template slot-scope="scope">
              <div style="display:flex;justify-content:center;cursor: pointer;">
                <img src="@/assets/images/bglink.png" @click="inMedicalRecordPath(scope.row)" alt="" title="病案">
              </div>
            </template>
          </el-table-column>
        </el-table>
      </div>
    </div>
    <div class="PaginationView" v-if="reportInformation!=null">
      <el-pagination
      :current-page="newReportData.currentPage"
      background
      :page-size="reportInformation.ReportTitle.PageSize"
      :total="newReportData.total"
      v-if="newReportData.total > reportInformation.ReportTitle.PageSize?true:true"
      @current-change="handleCurrentChange"
      layout="total, prev, pager, next">
      </el-pagination>
    </div>
  </div>
</template>

<script>
import GeneralSubView from './GeneralSubView.js'
export default GeneralSubView
</script>
