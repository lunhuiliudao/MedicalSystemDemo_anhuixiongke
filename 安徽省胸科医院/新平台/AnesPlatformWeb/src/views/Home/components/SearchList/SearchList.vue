<template>
  <div class="today">
    <div class="head_line"></div>
    <div class="table_main">
      <div class="table_title">
        <p>手术列表</p>
        <div style=" width:100%; float:left; margin-top:-25px;  text-align:right; ">
          <img
            @click="showMin()"
            style=" width:20px;margin-right:10px; height:20px; cursor:pointer;"
            src="@/assets/images/fullscreen_exit.png"
            alt
          />
        </div>
      </div>
      <table style="width:99%; margin-top:13px;table-layout:fixed;word-break:break-all;">
        <thead class="tableHead">
          <th width="70px">手术间</th>
          <th width="80px">手术日期</th>
          <th width="70px">姓名</th>
          <th width="100px">科室</th>
          <th width="80px">住院号</th>
          <th width="200px">术后诊断</th>
          <th width="220px">手术名称</th>
          <th width="160px">麻醉方法</th>
          <th width="100px">麻醉医生</th>
          <th width="80px">时长</th>
          <th></th>
        </thead>
      </table>
      <el-scrollbar style="height:600px; width:100%;">
        <div style="width:99%; margin:0px auto; display: flex;
        align-items: center;">
          <table style="width:99%;table-layout:fixed;word-break:break-all;">
            <thead class="tableHeadDisplay">
              <th width="70px"></th>
              <th width="80px"></th>
              <th width="70px"></th>
              <th width="100px"></th>
              <th width="80px"></th>
              <th width="200px"></th>
              <th width="220px"></th>
              <th width="160px"></th>
              <th width="100px"></th>
              <th width="80px"></th>
              <th></th>
            </thead>
            <tbody>
              <tr>
                <td colspan="11">
                  <div style="width:4px;float:left;height:43px;background:rgba(73,219,138,1);"></div>
                  <span style="line-height:43px; margin-left:15px;">已完成手术</span>
                </td>
              </tr>
              <tr
                :class="rowIndex(index)"
                :key="item.PATIENT_ID + index"
                v-for="(item,index) in FinishInfo "
              >
                <td style="width:70px;">{{item.OPERATING_ROOM_NO}}</td>

                <td style="width:80px;">
                  <p style="line-height:22px;">{{item.OPER_DATE | formatDate('YYYY-MM-DD')}}</p>
                  <p>{{item.OPER_DATE | formatDate('HH:mm')}}</p>
                </td>

                <td style="width:70px;">
                  <p style="line-height:24px;font-weight:bold;">
                    <a
                      :href="'/PatientInfo?pid=' + item.PATIENT_ID + '&vid=' + item.VISIT_ID + '&oid=' +item.OPER_ID"
                      target="_blank"
                    >{{item.NAME}}</a>
                  </p>
                  <p>{{item.SEX}} {{item.AGE}}</p>
                </td>

                <td style="width:100px;">{{item.DEPT_NAME}}</td>

                <td style="width:100px;">{{item.INP_NO}}</td>

                <td style="width:200px;">
                  <el-tooltip
                    class="item"
                    effect="dark"
                    :content="item.DIAG_AFTER_OPERATION"
                    placement="top"
                  >
                    <span style="line-height:13px;">{{item.DIAG_AFTER_OPERATION}}</span>
                  </el-tooltip>
                </td>

                <td
                  style="width:220px;;white-space: nowrap;text-overflow: ellipsis;overflow: hidden;padding-right:15px;"
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

                <td
                  style="width:160px;white-space: nowrap;text-overflow: ellipsis;overflow: hidden;"
                >
                  <el-tooltip class="item" effect="dark" :content="item.AnesMethod" placement="top">
                    <span style="line-height:13px;">{{item.AnesMethod}}</span>
                  </el-tooltip>
                </td>

                <td style="width:100px;">{{item.AnesDoctor}}</td>

                <td style="width:80px;">{{item.OPERTIME}}</td>

                <td>
                  <img
                    v-if="item.OUT_OPER_WHEREABORTS==='65'"
                    style="vertical-align:middle;"
                    src="@/assets/images/toicu.png"
                    alt
                  />
                  <img
                    v-else-if="item.OUT_OPER_WHEREABORTS==='40'"
                    style="vertical-align:middle;"
                    src="@/assets/images/topacu.png"
                    alt
                  />
                  <img v-else style="vertical-align:middle;" src="@/assets/images/toroom.png" alt />
                </td>
              </tr>
              <tr v-show="FinishInfo.length===0">
                <td colspan="11" align="center">
                  <img
                    style="vertical-align:middle; width:80px; height:80px;"
                    src="@/assets/images/blank-illus.png"
                    alt
                  />
                  没有数据...
                </td>
              </tr>
              <tr style="border-top:1px solid rgba(233, 234, 235, 1);">
                <td colspan="9">
                  <div style="width:4px;float:left;
height:43px;
background:#F1BE42;"></div>
                  <span style="line-height:43px;!important; margin-left:15px;">未完成手术</span>
                </td>
              </tr>
              <tr
                :class="rowIndex(index)"
                :key="item.PATIENT_ID + index"
                v-for="(item,index) in UnFinishInfo "
              >
                <td style="width:70px;">{{item.OPERATING_ROOM_NO}}</td>

                <td style="width:80px;">
                  <p style="line-height:22px;">{{item.OPER_DATE | formatDate('YYYY-MM-DD')}}</p>
                  <p>{{item.OPER_DATE | formatDate('HH:mm')}}</p>
                </td>

                <td style="width:70px;">
                  <p style="line-height:24px;font-weight:bold;">
                    <a
                      :href="'/PatientInfo?pid=' + item.PATIENT_ID + '&vid=' + item.VISIT_ID + '&oid=' +item.OPER_ID"
                      target="_blank"
                    >{{item.NAME}}</a>
                  </p>
                  <p>{{item.SEX}} {{item.AGE}}</p>
                </td>

                <td style="width:100px;">{{item.DEPT_NAME}}</td>

                <td style="width:100px;">{{item.INP_NO}}</td>

                <td style="width:200px;">
                  <el-tooltip
                    class="item"
                    effect="dark"
                    :content="item.DIAG_AFTER_OPERATION"
                    placement="top"
                  >
                    <span style="line-height:13px;">{{item.DIAG_AFTER_OPERATION}}</span>
                  </el-tooltip>
                </td>

                <td
                  style="width:220px;;white-space: nowrap;text-overflow: ellipsis;overflow: hidden;padding-right:15px;"
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

                <td
                  style="width:160px;white-space: nowrap;text-overflow: ellipsis;overflow: hidden;"
                >
                  <el-tooltip class="item" effect="dark" :content="item.AnesMethod" placement="top">
                    <span style="line-height:13px;">{{item.AnesMethod}}</span>
                  </el-tooltip>
                </td>

                <td style="width:100px;">{{item.AnesDoctor}}</td>

                <td style="width:80px;">{{item.OPERTIME}}</td>
                <td></td>
              </tr>
              <tr v-show="UnFinishInfo.length===0">
                <td colspan="9" align="center">
                  <img
                    style="vertical-align:middle; width:80px; height:80px;"
                    src="@/assets/images/blank-illus.png"
                    alt
                  />
                  没有数据...
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </el-scrollbar>
    </div>
  </div>
</template>

<script>
import SearchList from './SearchList.js'
export default SearchList
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";
.today {
  width: 100%;
  font-size: 14px;
  color: #3a3a3a;
  background: rgba(255, 255, 255, 1);
  .head_line {
    width: 100%;
    height: 6px;
    background: linear-gradient(
      90deg,
      rgba(103, 245, 184, 1),
      rgba(36, 197, 240, 1)
    );
  }

  .table_main {
    display: flex;
    flex-direction: column;
    align-items: center;
    width: 100%;
    min-height: 493px;
    margin-top: 0px;
    background: rgba(255, 255, 255, 1);
    border: 1px solid rgba(233, 234, 235, 1);
    border-left: 0px;
    border-right: 0px;
    border-top: 0px;
    .table_title {
      margin-top: 0px;
      width: 100%;
      height: 33px;
      background: rgba(233, 242, 245, 1);
      text-align: center;
      line-height: 33px;
    }
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
  }
}
</style>
<style>
.today .el-scrollbar__wrap {
  overflow-x: hidden;
}
.today .el-scrollbar__thumb {
  background-color: #1896ca;
}
</style>
