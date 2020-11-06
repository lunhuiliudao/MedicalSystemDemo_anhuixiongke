<template>
  <div :style="{width:osWidth + 'px',height:osHeight - 53 + 'px'}" class="main">
    <el-dialog custom-class="viewdialog" v-if="this.webconfig.openLIS101" :close-on-click-modal="false" :visible.sync="dialogLIS101Visible">
      <div slot="title">
       <span style="font-size:18px;">检验结果查询</span>  <span style=" font-size:12px;margin-left:20px;">患者姓名 ：{{currentRow.NAME}}   &nbsp;&nbsp; &nbsp; 住院号：{{currentRow.INP_NO}}   &nbsp;&nbsp; &nbsp;科室：{{currentRow.DEPT_NAME}}   &nbsp;&nbsp; &nbsp; 床号：{{currentRow.NAME}}   &nbsp;&nbsp; &nbsp; 年龄：{{currentRow.AGE}}    &nbsp;&nbsp; &nbsp;性别：{{currentRow.SEX}}</span>
      </div>
      <el-container v-loading="checkResultLoading">
        <el-aside width="200px">
            <el-table :data="checkResultMasterData" ref="checkResultMaster" :show-header="false" highlight-current-row @current-change="resultMasterCurrentChange" max-height="600">
              <el-table-column show-overflow-tooltip width="200">
                <template slot-scope="scope">
                  {{ scope.row.SPCM_RECEIVED_DATE_TIME_SHOW }} {{ scope.row.TEST_CAUSE }}
                </template>
              </el-table-column>
            </el-table>
        </el-aside>
        <el-main>
          <el-table :data="checkResultDetailData" stripe border height="600">
            <el-table-column prop="REPORT_ITEM_NAME" label="项目名称" header-align="center" align="center">
            </el-table-column>
            <el-table-column prop="RESULT" label="结果" header-align="center" align="center">
              <template slot-scope="scope">
                <span style="color:red;font-size:16px;">{{ scope.row.RESULT_SYMBOL }}</span> {{ scope.row.RESULT }}
              </template>
            </el-table-column>
            <el-table-column prop="UNITS" label="单位" header-align="center" align="center">
            </el-table-column>
            <el-table-column prop="REFERENCE_RESULT" label="参考值" header-align="center" align="center">
            </el-table-column>
          </el-table>
        </el-main>
      </el-container>
    </el-dialog>
    <el-dialog custom-class="viewdialog" v-if="this.webconfig.openORDER103" :close-on-click-modal="false" :visible.sync="dialogORDER103Visible">
      <div slot="title">
       <span style="font-size:18px;">医嘱信息</span>  <span style=" font-size:12px;margin-left:20px;">患者姓名 ：{{currentRow.NAME}}   &nbsp;&nbsp; &nbsp; 住院号：{{currentRow.INP_NO}}   &nbsp;&nbsp; &nbsp;科室：{{currentRow.DEPT_NAME}}   &nbsp;&nbsp; &nbsp; 床号：{{currentRow.NAME}}   &nbsp;&nbsp; &nbsp; 年龄：{{currentRow.AGE}}    &nbsp;&nbsp; &nbsp;性别：{{currentRow.SEX}}</span>
      </div>
      <el-table :data="ordersData" v-loading="ordersViewLoading" stripe border height="600">
        <el-table-column prop="ENTER_DATE_TIME" label="下医嘱日期" header-align="center" align="center">
        </el-table-column>
        <el-table-column prop="DOCTOR" label="医生" width="80" header-align="center" align="center">
        </el-table-column>
        <el-table-column prop="REPEAT_INDICATOR" label="医嘱类型" header-align="center" align="center">
        </el-table-column>
        <el-table-column prop="ORDER_TEXT" label="医嘱" header-align="center" align="center" show-overflow-tooltip>
        </el-table-column>
        <el-table-column prop="START_DATE_TIME" label="执行时间" header-align="center" align="center">
        </el-table-column>
        <el-table-column prop="NURSE" label="护士" width="80" header-align="center" align="center">
        </el-table-column>
        <el-table-column prop="STOP_DATE_TIME" label="停止时间" header-align="center" align="center">
        </el-table-column>
      </el-table>
    </el-dialog>
    <div class="columntitle">
      <table :style="{width:colunmtitlewidth + 'px'}">
        <thead>
          <tr>
            <th :key="index" v-for="(col,index) in columns" :style="{width : col.width + 'px'}" v-if="col.visible">{{col.columnname}}</th>
            <th style="width:17px;"></th>
          </tr>
        </thead>
      </table>
    </div>
    <div :style="{width:osWidth + 'px',height:osHeight - 73 + 'px',overflow:'auto'}" @scroll="onscroll()" class="mainDiv">
      <div :style="{width: colunmtitlewidth - 17 + 'px'}">
        <div :key="index" v-for="(room, index) in operRoomNoList.filter((r) => {return tableData.filter((i) => {return i.OPER_ROOM_NO == r.ROOM_NO}).length > 0})" class="room" :style="{background: randomcolor[index%randomcolor.length],height:tableData.filter((r)=>{return r.OPER_ROOM_NO == room.ROOM_NO; }).length * 38 +'px'}">
          <div class="roomtitle">{{room.ROOM_NO}}</div>
          <div class="roommain">
            <table class="operroom">
              <tbody>
                <tr :key="r1" v-for="(row,r1) in tableData.filter((r) => {return r.OPER_ROOM_NO == room.ROOM_NO }).sort((a, b) => { return a.SEQUENCE - b.SEQUENCE })">
                  <td :key="c1" v-for="(col,c1) in columns.filter((c) => {return c.fieldname != 'OPER_ROOM_NO';})" :style="{width : col.width + 'px'}" v-if="col.visible">
                    <el-button v-if="col.columnname === '检验信息'"  type="primary" icon="el-icon-document" @click="operLIS101(row)"></el-button>
                    <a v-else-if="col.columnname === '护理信息'" target="_blank" :href="getHLHref(row)">
                      <el-button type="primary" icon="el-icon-document"></el-button>
                    </a>
                    <el-button v-else-if="col.columnname === '医嘱信息'"  type="primary" icon="el-icon-document" @click="openORDER103(row)"></el-button>
                    <div v-else-if="col.columnname ==='状态'" class="autocut" :style="{width : col.width + 'px'}">
                      {{row[col.fieldname] === 3 ? '术中': row[col.fieldname] === 4 ? '术后' : ''}}
                    </div>
                    <div v-else class="autocut" :style="{width : col.width + 'px'}" :title="row[col.fieldname]">
                      {{row[col.fieldname]}}
                    </div>
                  </td>
                  <td style="width:0px;"></td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import OsOperList from './OsOperList.js'
export default OsOperList
</script>
<style scoped>
* {
  margin: 0;
  padding: 0;
}

table {
  border-collapse: collapse;
}

tr {
  font-size: 12px;
}

th {
  text-align: center;
  padding-top: 5px;
  padding-bottom: 5px;
  background-color: #FDFDFD;
  height:17px;
}

td {
  padding-top: 5px;
  padding-bottom: 5px;
  text-align: center;
}

tr:hover td {
  background: none;
}

.operroom tbody tr {
  border-top: 1px solid #E5E6EA;
}

.operroom tbody tr:hover {
  background: #FEEFC5;
  font-weight: bolder;
  color: lightslategray;
}

.columntitle {
  overflow: hidden;
}

.mainDiv {
  overflow: auto;
}

.room {
  position: relative;
  border-radius: 5px;
  margin-top: 5px;
}

.roomtitle {
  position: absolute;
  width: 65px;
  height: 21px;
  top: 0;
  left: 0;
  bottom: 0;
  margin: auto;
  float: left;
  text-align: center;
  font-size: 16x;
  font-weight: bolder;
  color: white;
}

.roommain {
  margin-left: 65px;
  background: white;
}

.roommain:hover {
  background: #FDFDE5;
}

.autocut {
  height: 17px;
  padding-top: 5px;
  padding-bottom: 5px;
  overflow: hidden;
  white-space: nowrap;
  text-overflow: ellipsis;
  -o-text-overflow: ellipsis;
  -icab-text-overflow: ellipsis;
  -khtml-text-overflow: ellipsis;
  -moz-text-overflow: ellipsis;
  -webkit-text-overflow: ellipsis;
}
</style>
