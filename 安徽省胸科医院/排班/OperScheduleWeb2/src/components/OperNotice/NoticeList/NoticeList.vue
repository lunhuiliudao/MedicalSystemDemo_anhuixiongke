<template>
  <div>
    <div class="NoticeAction">
      <el-date-picker
        v-model="scheduleDateTime"
        type="date"
        v-bind:editable="false"
        v-bind:clearable="false"
        placeholder="选择日期"
        v-on:change="getOperNoticeList"
      ></el-date-picker>
      <el-button type="primary" v-on:click="getOperNoticeList">查 询</el-button>
      <el-button type="primary" v-on:click="preview(1)">打 印</el-button>
      <el-button type="primary" v-on:click="previewPage(1)">分页打印</el-button>
      <el-button type="primary" v-on:click="exprotExcel()">导出</el-button>
      <a id="hrefToExportTable" style="display: none;width: 0px;height: 0px;"></a>
    </div>
    <div class="operNoticeBody" v-bind:style="{width:width+'px',height:height+'px'}">
      <el-table
        v-if="operNoticeList.length>0"
        v-bind:data="operNoticeData"
        border
        v-bind:height="height"
        @selection-change="selectionChangeFun"
      >
        <el-table-column type="selection" header-align="center" align="center" width="55"></el-table-column>
        <el-table-column
          :prop="item.field"
          v-bind="item.widthObj"
          :label="item.lable"
          header-align="center"
          v-bind:show-overflow-tooltip="true"
          :key="index"
          v-for="(item,index) in comOperNoticeList"
        ></el-table-column>
      </el-table>
    </div>
    <div id="noticePrintArea" style="display:none">
      <div style=" font-size: 25px; font-weight: 600;text-align: center;letter-spacing: 2px">手术通知单</div>
      <div>
        <span>日期：{{comScheduleDateTime}}</span>
        <span style="float:right">总例：{{operNoticeSelectData.length}}&nbsp;</span>
      </div>
      <table style="margin-top: 5px;width:100%" border="1" cellspacing="0" cellpadding="0">
        <thead>
          <tr style="font-size:12px;height:30px">
            <th
              v-bind="item.widthObj"
              :key="index"
              v-for="(item,index) in comOperNoticeListPrint"
            >{{item.lable}}</th>
          </tr>
        </thead>
        <tbody style="font-size:12px">
          <tr :key="index" v-for="(item,index) in operNoticeSelectData">
            <td :key="index2" v-for="(item2,index2) in comOperNoticeListPrint">
              <span :key="index3" v-for="(item3,index3) in item2.field">
                {{item[item3]}}
                <span v-if="index3 < item2.field.length-1">{{item2.separator}}</span>
              </span>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
    <div id="noticePrintPageArea" style="display:none">
      <div style="page-break-after:always" :key="index" v-for="(obj,index) in operNoticeSelectData">
        <div style=" font-size: 25px; font-weight: 600;text-align: center;letter-spacing: 2px">手术通知单</div>
        <div>
          <span>日期：{{comScheduleDateTime}}</span>
          <!-- <span style="float:right">总例：{{operNoticeSelectData.length}}&nbsp;</span> -->
        </div>
        <table style="margin-top: 5px;width:100%" border="1" cellspacing="0" cellpadding="0">
          <thead>
            <tr style="font-size:12px;height:30px">
              <th
                v-bind="item.widthObj"
                :key="index"
                v-for="(item,index) in comOperNoticeListPrint"
              >{{item.lable}}</th>
            </tr>
          </thead>
          <tbody style="font-size:12px">
            <tr>
              <td :key="index2" v-for="(item2,index2) in comOperNoticeListPrint">
                <span :key="index3" v-for="(item3,index3) in item2.field">
                  {{obj[item3]}}
                  <span v-if="index3 < item2.field.length-1">{{item2.separator}}</span>
                </span>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script>
import NoticeList from './NoticeList.js'
export default NoticeList
</script>

<style scoped>
.NoticeAction {
  padding-left: 50px;
  background-color: white;
  height: 50px;
  line-height: 50px;
  font-weight: bold;
}

.operNoticeBody {
  margin: 0 auto;
}
</style>
