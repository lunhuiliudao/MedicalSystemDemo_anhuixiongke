<template>
  <div class="LocalAnesRegister">
    <el-dialog
      custom-class="LoacalAnesRegister_viewdialog"
      width="835px"
      top="8vh"
      :visible.sync="dialogVisible"
    >
      <LoacalAnesEdit
        :key="key"
        ref="refEditOut"
        @closeForm="closeForm()"
        :patientInfo="patientInfo"
        @refreshList="searchData(1)"
      ></LoacalAnesEdit>
    </el-dialog>
    <div class="LocalAnesRegister_Top">
      <div class="LocalAnesRegister_Top_RiQi">手术日期</div>
      <div class="LocalAnesRegister_Top_RiQi2">
        <el-date-picker
          v-model="StartDate"
          type="date"
          placeholder="选择日期"
          style="width:151px;"
          :clearable="false"
        ></el-date-picker>
      </div>
      <div class="LocalAnesRegister_Top_RiQi_To">~</div>
      <div class="LocalAnesRegister_Top_RiQi2">
        <el-date-picker
          v-model="EndDate"
          type="date"
          placeholder="选择日期"
          style="width:151px;"
          :clearable="false"
        ></el-date-picker>
      </div>
      <div class="LocalAnesRegister_Top_InpNo">住院号</div>
      <div class="LocalAnesRegister_Top_InpNo2">
        <el-input v-model="InpNo" placeholder="住院号" clearable></el-input>
      </div>
      <div class="LocalAnesRegister_Top_Search">
        <div class="LocalAnesRegister_Top_Search_Check mdsdCheckBoxNoBorder">
          <el-checkbox
            v-model="myOperCheck"
            style="width:120px;margin-top:5px;"
            :true-label="1"
            :false-label="0"
            label="我的手术"
          ></el-checkbox>
        </div>
        <div class="LocalAnesRegister_Top_Search_Button">
          <el-button
            class="LocalAnesRegister_Top_Search_Left"
            type="primary"
            icon="el-icon-search"
            @click="searchData(1)"
          >查询</el-button>
          <el-button class="LocalAnesRegister_Top_Search_Right" type="primary" @click="addData">新增</el-button>
        </div>
      </div>
    </div>

    <div class="LocalAnesRegister_Main">
      <div class="LocalAnesRegister_Main_Top"></div>
      <table style="width:99.2%; table-layout:fixed;word-break:break-all;">
        <thead class="tableHead">
          <th width="100px" style="text-align:center">住院号</th>
          <th width="70px">姓名</th>
          <th width="60px">体重</th>
          <th width="150px">科室</th>
          <th width="60%" style="min-width:180px;">手术名称</th>
          <th width="80px">麻醉方法</th>
          <th width="80px" style="text-align:center">手术类型</th>
          <th width="80px" style="text-align:center">ASA分级</th>
          <th width="80px">入手术室</th>
          <th width="80px">手术开始</th>
          <th width="80px">手术结束</th>
          <th width="80px">出手术室</th>
          <th width="65px">操作</th>
        </thead>
      </table>
      <el-scrollbar style="height:600px; width:100%;">
        <div style="width:100%; margin:0px auto; display: flex;
        align-items: left;">
          <table style="width:99.2%;table-layout:fixed;word-break:break-all;">
            <thead class="tableHeadDisplay">
              <th width="100px"></th>
              <th width="70px"></th>
              <th width="60px"></th>
              <th width="150px"></th>
              <th width="60%" style="min-width:180px;"></th>
              <th width="80px"></th>
              <th width="80px"></th>
              <th width="80px"></th>
              <th width="80px"></th>
              <th width="80px"></th>
              <th width="80px"></th>
              <th width="80px"></th>
              <th width="65px"></th>
            </thead>
            <tbody>
              <tr
                :class="rowIndex(index)"
                :key="item.PATIENT_ID + index"
                v-for="(item,index) in paginationInfo.currentData "
              >
                <td style="width:100px;margin-left:5px;text-align:center">{{item.INP_NO}}</td>
                <td style="width:70px;">
                  <p style="line-height:24px;font-weight:bold;">{{item.NAME}}</p>
                  <p>{{item.SEX}} {{item.AGE}}</p>
                </td>
                <td style="width:60px;">{{item.WEIGHT}}</td>
                <td style="width:150px;">{{item.DEPTNAME}}</td>
                <td style="width:60%;padding-right:20px;">
                  <span style="line-height:13px;">{{item.OPERATION_NAME}}</span>
                </td>
                <td style="width:80px;">{{item.ANES_METHOD}}</td>
                <td style="width:80px;text-align:center">{{item.EMERGENCY_IND}}</td>
                <td style="width:80px;text-align:center">{{item.ASA_GRADE}}</td>
                <td style="width:80px;">
                  <p style="line-height:22px">{{item.IN_DATE_TIME | formatDate('YYYY-MM-DD')}}</p>
                  <p>{{item.IN_DATE_TIME | formatDate('HH:mm')}}</p>
                </td>
                <td style="width:80px;">
                  <p style="line-height:22px">{{item.START_DATE_TIME | formatDate('YYYY-MM-DD')}}</p>
                  <p>{{item.START_DATE_TIME | formatDate('HH:mm')}}</p>
                </td>
                <td style="width:80px;">
                  <p style="line-height:22px">{{item.END_DATE_TIME | formatDate('YYYY-MM-DD')}}</p>
                  <p>{{item.END_DATE_TIME | formatDate('HH:mm')}}</p>
                </td>
                <td style="width:80px;">
                  <p style="line-height:22px">{{item.OUT_DATE_TIME | formatDate('YYYY-MM-DD')}}</p>
                  <p>{{item.OUT_DATE_TIME | formatDate('HH:mm')}}</p>
                </td>

                <td
                  class="mdsd-iconfont mdsd-icon-edit"
                  style="width:65px;font-size:18px;"
                  @click="editData(index,item)"
                ></td>
              </tr>
            </tbody>
          </table>
        </div>
      </el-scrollbar>
    </div>
  </div>
</template>

<script>
import LocalAnesRegister from './LocalAnesRegister.js'
export default LocalAnesRegister
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";
.LocalAnesRegister {
  width: 1300px;
  height: 768px;
  display: flex;
  flex-direction: column;
  margin: 37px 0 0 0;
  .LocalAnesRegister_Top {
    display: flex;
    flex-direction: row;
    margin: 20px 0px 0px 0px;
    .LocalAnesRegister_Top_RiQi {
      width: 48px;
      height: 26px;
      font-size: 12px;
      font-family: MicrosoftYaHei;
      font-weight: 400;
      color: rgba(101, 101, 101, 1);
      margin: 10px 0px 0px 0px;
    }
    .LocalAnesRegister_Top_RiQi_To {
      width: 8px;
      height: 3px;
      font-size: 14px;
      font-family: MicrosoftYaHei;
      font-weight: 400;
      color: rgba(101, 101, 101, 1);
      margin: 10px 0px 0px 6px;
    }
    .LocalAnesRegister_Top_RiQi2 {
      width: 153px;
      height: 26px;
      background: rgba(20, 68, 109, 1);
      border: 1px solid rgba(220, 220, 220, 1);
      border-radius: 5px;
      margin: 3px 0px 0px 10px;
    }
    .datepickerCss {
      height: 26px;
      width: 68px;

      font-size: 12px;
      font-family: MicrosoftYaHei;
      font-weight: 400;
      font-style: italic;
      color: rgba(158, 160, 163, 1);
    }
    .LocalAnesRegister_Top_InpNo {
      width: 48px;
      height: 26px;
      font-size: 12px;
      font-family: MicrosoftYaHei;
      font-weight: 400;
      color: rgba(101, 101, 101, 1);
      margin: 10px 0px 0px 47px;
    }
    .LocalAnesRegister_Top_InpNo2 {
      width: 153px;
      height: 26px;
      background: rgba(20, 68, 109, 1);
      border-radius: 5px;
      margin: 3px 0px 0px 30px;
    }
    .LocalAnesRegister_Top_Search {
      display: flex;
      flex-direction: row;
      margin: 0 0 0 28px;
      .LocalAnesRegister_Top_Search_Check {
        width: 100px;
        height: 26px;
        cursor: pointer;
        display: flex;
        flex-direction: row;
        .Search_icon1 {
          width: 20px;
          height: 20px;
        }
        .Textstatus3 {
          height: 20px;
          font-size: 12px;
          font-family: MicrosoftYaHei;
          font-weight: 400;
          color: rgba(119, 119, 119, 1);
          background-color: #f5f9fb;
        }
      }
      .LocalAnesRegister_Top_Search_Button {
        display: flex;
        flex-direction: row;
        .LocalAnesRegister_Top_Search_Left {
          width: 128px;
          height: 32px;
          background: rgba(61, 209, 138, 1);
          box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
          border-radius: 3px;
          margin: 0 0 0 39px;
          text-align: center;
        }
        .LocalAnesRegister_Top_Search_Right {
          width: 128px;
          height: 32px;
          background: rgba(61, 209, 138, 1);
          box-shadow: 0px 0px 1px 0px rgba(46, 53, 56, 0.32);
          border-radius: 3px;
          margin: 0 0 0 28px;
          text-align: center;
        }
      }
    }
  }
  .LocalAnesRegister_Main {
    width: 1300px;
    //height: 440px;
    background: rgba(255, 255, 255, 1);
    box-shadow: 0px 0px 8px 0px rgba(112, 132, 142, 0.15);
    border-radius: 5px;
    margin: 26px 0px 0px 0px;

    .LocalAnesRegister_Main_Top {
      width: 99.2%;
      height: 4px;
      background: rgba(29, 174, 241, 1);
      border-radius: 5px;
    }
    .tableHead {
      text-align: left;
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
      text-align: left;
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
      text-align: left;
      border-right: 1px solid #d8f0fa;
    }
    .tableDoubleRow {
      height: 53px;
      color: rgba(74, 74, 74, 1);
      text-align: left;
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
.LocalAnesRegister_Top .el-input__prefix {
  /* left: 125px;
   -webkit-transition: all 0.3s;
  transition: all 0.3s; */
  font-size: 14px;
}
.LocalAnesRegister_Top .el-input__inner {
  width: 153px;
  height: 26px;
  font-size: 12px;
  line-height: 25px;
  /* padding-left: 20px; */
  /* padding-right: 10px; */
}

.LocalAnesRegister_Top_RiQi2 .el-input__icon {
  height: 100%;
  width: 25px;
  font-size: 14px;
  /* text-align: left; */
  -webkit-transition: all 0.3s;
  transition: all 0.3s;
  line-height: 25px;
}

.LocalAnesRegister_Main .el-dialog__header {
  padding: 0px 0px 0px;
}
.LocalAnesRegister_Main .el-dialog__body {
  padding: 0px 0px;
  color: #606266;
  font-size: 14px;
  height: 818px;
  background: rgba(255, 255, 255, 1);
  box-shadow: 0px 0px 8px 0px rgba(48, 50, 51, 0.55);
  border-radius: 5px;
}

.LocalAnesRegister .el-scrollbar__wrap {
  overflow-x: hidden;
}
.LocalAnesRegister .el-scrollbar__thumb {
  background-color: #1896ca;
}

.LocalAnesRegister_Top_Search .el-button {
  display: inline-block;
  line-height: 1;
  white-space: nowrap;
  cursor: pointer;
  background: #fff;
  border: 1px solid #dcdfe6;

  -webkit-appearance: none;
  text-align: left;
  -webkit-box-sizing: border-box;
  box-sizing: border-box;
  outline: 0;
  margin: 0;
  -webkit-transition: 0.1s;
  transition: 0.1s;
  font-weight: 500;
  padding: 6px 20px;
  font-size: 14px;
  border-radius: 4px;
}
.LocalAnesRegister ::-webkit-input-placeholder {
  font-style: italic;
}
.LocalAnesRegister_Top .el-checkbox__input.is-checked + .el-checkbox__label {
  color: #4a4a4a;
}
</style>
