<template>
  <div>
    <div class="pickUpListAction">
      <el-date-picker
        v-model="scheduleDateTime"
        type="date"
        v-bind:editable="false"
        v-bind:clearable="false"
        placeholder="选择日期"
        v-on:change="getPickUpListData"
      ></el-date-picker>
      <el-button type="primary" v-on:click="getPickUpListData">查 询</el-button>
      <el-button type="primary" v-on:click="preview()">打 印</el-button>
      <el-button type="primary" v-on:click="exprotExcel()">导出</el-button>
      <a id="hrefToExportTable" style="display: none;width: 0px;height: 0px;"></a>
    </div>
    <div class="pickUpListBody" v-bind:style="{width:width+'px',height:height+'px'}">
      <el-table
        v-if="pickUpList.length>0"
        v-bind:data="pickUpListData"
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
          v-for="(item,index) in comPickUpList"
        ></el-table-column>
      </el-table>
    </div>
    <div id="pickUpListPrintArea" style="display:none">
      <table style="margin-top: 5px;width:100%" border="1" cellspacing="0" cellpadding="0">
        <thead>
          <tr style="font-size:12px;height:30px">
            <th
              v-bind="item.widthObj"
              :key="index"
              v-for="(item,index) in comPickUpListPrint"
            >{{item.lable}}</th>
          </tr>
        </thead>
        <tbody style="font-size:12px;">
          <tr style="height:40px" :key="index" v-for="(item,index) in pickUpListSelectData">
            <td :key="index2" v-for="(item2,index2) in comPickUpListPrint">
              <span :key="index3" v-for="(item3,index3) in item2.field">
                {{item[item3]}}
                <span v-if="index3 < item2.field.length-1">{{item2.separator}}</span>
              </span>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
import PickUpList from './PickUpList.js'
export default PickUpList
</script>

<style scoped>
.pickUpListAction {
  padding-left: 50px;
  background-color: white;
  height: 50px;
  line-height: 50px;
  font-weight: bold;
}

.pickUpListBody {
  margin: 0 auto;
}
</style>
