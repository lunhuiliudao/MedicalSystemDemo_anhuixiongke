<template>
  <div class="today">
    <div class="head_line"></div>
    <div class="top">
      <div class="top_left">
        <div class="top_left_title">
          <img class="top_title_icon1" style src="@/assets/images/mainhead.png" alt />
          <span
            class="top_title_span"
            style
          >{{getTimeDesc()}}好！{{splitUserName(userInfo.USER_NAME)}}医生 欢迎使用麻醉信息平台&nbsp;!</span>
        </div>
        <div>
          <img class="top_image" src="@/assets/images/today.png" alt />
        </div>
      </div>
      <div class="top_right">
        <div class="top_right_title">今日手术</div>
        <div class="top_right_row1">
          <span>共计</span>
          <span class="top_right_count">{{OperInfos.DayTotalCount}}</span>
          <span style="margin-left:20px;">台</span>
          <span class="top_right_Surplus">剩余{{OperInfos.DayBeforeOperCount}}台</span>
        </div>
        <div class="top_right_process">
          <div
            class="process1"
            :style="{'width':(OperInfos.DayCompletedCount/OperInfos.DayTotalCount * 100) +'%'}"
          ></div>
          <div
            class="process2"
            :style="{'width':(OperInfos.DayOperatingCount/OperInfos.DayTotalCount * 100) +'%'}"
          ></div>
        </div>
        <div class="top_right_row2">
          <div class="icon_completed"></div>
          <div class="status1">已完成台数</div>
          <div class="status2">
            <span>{{OperInfos.DayCompletedCount}}</span>
          </div>
          <div>台</div>
          <div class="icon_ICU"></div>
          <div class="status1">转ICU台数</div>
          <div class="status2">
            <span>{{OperInfos.DayToICUCount}}</span>
          </div>
          <div>台</div>
        </div>
        <div class="top_right_row2">
          <div class="icon_operating"></div>
          <div class="status1">手术中台数</div>
          <div class="status2">
            <span>{{OperInfos.DayOperatingCount}}</span>
          </div>
          <div>台</div>
          <div class="icon_FS"></div>
          <div class="status1">复苏时长≥2h</div>
          <div class="status2">
            <span>{{OperInfos.PacuCount}}</span>
          </div>
          <div>台</div>
        </div>
      </div>
    </div>
    <div class="table_main">
      <div class="table_title">
        <p>今日手术列表</p>
      </div>
      <table style="width:99%; margin-top:13px;table-layout:fixed;word-break:break-all;">
        <thead class="tableHead">
          <th width="70px">手术间</th>
          <th width="80px">手术日期</th>
          <th width="70px">姓名</th>
          <th width="100px">科室</th>
          <th width="80px">住院号</th>
          <th width="100px">术后诊断</th>
          <th width="120px">手术名称</th>
          <th width="100px">麻醉方法</th>
          <th width="100px">麻醉医生</th>
          <th width="60px">时长</th>
          <th></th>
        </thead>
      </table>
      <el-scrollbar style="height:400px; width:100%;">
        <div style="width:99%; margin:0px auto; display: flex;
        align-items: center;">
          <table style="width:99%;table-layout:fixed;word-break:break-all;">
            <thead class="tableHeadDisplay">
              <th width="70px"></th>
              <th width="80px"></th>
              <th width="70px"></th>
              <th width="100px"></th>
              <th width="80px"></th>
              <th width="100px"></th>
              <th width="120px"></th>
              <th width="100px"></th>
              <th width="100px"></th>
              <th width="60px"></th>
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

                <td style="width:100px;">
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
                  style="width:100px;;white-space: nowrap;text-overflow: ellipsis;overflow: hidden;padding-left:10px;"
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
                  style="width:100px;white-space: nowrap;text-overflow: ellipsis;overflow: hidden;"
                >
                  <el-tooltip class="item" effect="dark" :content="item.AnesMethod" placement="top">
                    <span style="line-height:13px;">{{item.AnesMethod}}</span>
                  </el-tooltip>
                </td>

                <td style="width:100px;">{{item.AnesDoctor}}</td>

                <td style="width:60px;">{{item.OPERTIME}}</td>
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
                <td colspan="9" align="center">
                  <img
                    style="vertical-align:middle; width:80px; height:80px;"
                    src="@/assets/images/blank-illus.png"
                    alt
                  />
                  没有数据...
                </td>
              </tr>
              <tr style="border-top:1px solid rgba(233, 234, 235, 1);">
                <td colspan="11">
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

                <td style="width:100px;">
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
                  style="width:100px;;white-space: nowrap;text-overflow: ellipsis;overflow: hidden;padding-left:10px;"
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
                  style="width:100px;white-space: nowrap;text-overflow: ellipsis;overflow: hidden;"
                >
                  <el-tooltip class="item" effect="dark" :content="item.AnesMethod" placement="top">
                    <span style="line-height:13px;">{{item.AnesMethod}}</span>
                  </el-tooltip>
                </td>

                <td style="width:100px;">{{item.AnesDoctor}}</td>

                <td style="width:60px;">{{item.OPERTIME}}</td>
                <td style="width:65px;"></td>
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
import Today from './Today.js'
export default Today
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
  .top {
    width: 100%;
    display: flex;
    flex-direction: row;
    .top_left {
      width: 45%;
      min-width: 350px;
      display: flex;
      flex-direction: column;
      align-items: center;
      .top_left_title {
        margin-top: 26px;
        display: flex;
        align-items: center;
        .top_title_icon1 {
          width: 28px;
          height: 27px;
        }
        .top_title_span {
          margin-left: 16px;
        }
      }
      .top_image {
        width: 309px;
      }
    }

    .top_right {
      width: 55%;
      min-width: 400px;
      margin-top: 33px;
      .top_right_title {
        font-size: 14px;
        // margin-top: px2rem(41);
      }
      .top_right_row1 {
        height: 30px;
        margin-top: 15px;
        .top_right_count {
          font-size: 30px;
          margin-left: 23px;
          color: #80b0e1;
        }
        .top_right_Surplus {
          width: 55px;
          height: 14px;
          font-size: 14px;
          font-family: MicrosoftYaHei;
          font-weight: 400;
          margin-left: 30px;
          color: rgba(174, 174, 174, 1);
        }
      }
      .top_right_process {
        margin-top: 15px;
        width: 208px;
        height: 13px;
        background: rgba(228, 228, 228, 1);
        border-radius: 7px;
        display: flex;
        .process1 {
          height: 13px;
          background: rgba(189, 238, 159, 1);
          border-radius: 7px;
          //border-top-left-radius: 7px;
          //border-bottom-left-radius: 7px;
        }
        .process2 {
          height: 13px;
          background: #4fa2ff;
          // border-radius: 7px;
        }
      }
      .top_right_row2 {
        width: 100%;
        margin-top: 20px;
        display: flex;
        align-items: center;
        .icon_completed {
          width: 12px;
          height: 12px;
          background: #bdee9f;
          border-radius: 50%;
        }

        .icon_ICU {
          width: 12px;
          height: 12px;
          margin-left: px2rem(69);
          background: rgba(197, 202, 255, 1);
          border-radius: 50%;
        }
        .icon_operating {
          width: 12px;
          height: 12px;
          background: rgba(79, 162, 255, 1);
          border-radius: 50%;
        }
        .icon_FS {
          width: 12px;
          height: 12px;
          margin-left: px2rem(69);
          background: rgba(246, 179, 127, 1);
          border-radius: 50%;
        }
        .status1 {
          margin-left: 10px;
          width: 100px;
        }
        .status2 {
          width: 30px;
          text-align: center;
        }

        .status3 {
          float: right;
        }
      }
    }
  }
  .table_main {
    display: flex;
    flex-direction: column;
    align-items: center;
    width: 100%;
    min-height: 493px;
    margin-top: 15px;
    background: rgba(255, 255, 255, 1);
    border: 1px solid rgba(233, 234, 235, 1);
    border-left: 0px;
    border-right: 0px;
    .table_title {
      margin-top: 2px;
      width: 99%;
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
