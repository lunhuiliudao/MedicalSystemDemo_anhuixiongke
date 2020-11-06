<template>
  <div class="Search">
    <div>
      <span class="Textstatus1">患者姓名</span>
      <el-input placeholder="请输入姓名" class="inputstatus1" v-model="PatName"></el-input>
    </div>
    <div>
      <span class="Textstatus2">住院号</span>
      <el-input placeholder="请输入住院号" class="inputstatus1" v-model="InpNo"></el-input>
    </div>
    <div>
      <span class="Textstatus2">手术科室</span>
      <MedSelect
        type="DeptDict"
        class="inputstatus"
        :remote="true"
        placeholder="请输入手术科室"
        v-model="OperDept"
      ></MedSelect>
    </div>
    <div>
      <span class="Textstatus2">麻醉医生</span>
      <MedSelect
        type="AnesDoctorDict"
        remote
        placeholder="请输麻醉医生"
        class="inputstatus"
        v-model="AnesDoctor"
      ></MedSelect>
    </div>
    <div style=" display: flex;
  flex-direction: row;  align-items: center;">
      <span class="Textstatus2">日期</span>
      <el-date-picker v-model="StartDate" type="date" style="width:130px;"></el-date-picker>
    </div>
    <div class="SeatchControl mdsdCheckBoxNoBorder">
      <div class="Search_Check">
        <el-checkbox
          v-model="myOperCheck"
          style="width:120px;"
          :true-label="1"
          :false-label="0"
          label="我的手术"
        ></el-checkbox>
      </div>
      <div class="Search_button">
        <el-button
          class="btnType"
          size="mini"
          type="primary"
          icon="el-icon-search"
          v-on:click="search"
        >搜 索</el-button>
      </div>
    </div>
  </div>
</template>

<script>
import Search from './Search.js'
export default Search
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";
.Search {
  width: 100%;
  height: 100%;
  font-size: px2rem(12);
  color: #656565;
  display: flex;
  flex-direction: row;
  align-items: center;
  flex-wrap: wrap;
  .Textstatus1 {
    margin-left: px2rem(40);
    margin-right: px2rem(19);
  }
  .Textstatus2 {
    margin-left: px2rem(28);
    margin-right: px2rem(30);
  }
  .inputstatus1 {
    width: 153px;
    height: 26px;
    border-radius: px2rem(5);
  }
  .inputstatus {
    width: 153px;
    height: 26px;
    border-radius: px2rem(5);
  }
  .SeatchControl {
    display: flex;
    align-items: center;
    justify-content: flex-end;
    flex-grow: 1;
    padding-right: 22px;
    .Search_button {
      .btnType {
        width: 128px;
        height: 32px;
        background: rgba(61, 209, 138, 1);
      }
    }

    .Search_Check {
      display: flex;
      flex-direction: row;
      cursor: pointer;
      .Textstatus3 {
        margin: 4px 30px 0 8px;
      }
      .Seatch_icon1 {
        width: 20px;
        height: 20px;
      }
    }
  }
}
</style>
<style lang="scss">
@import "@/assets/styles/global.scss";
.inputstatus {
  .el-input__inner {
    height: 26px;
  }
}
.Search {
  .el-input.is-active .el-input__inner,
  .el-input__inner:focus {
    background-color: #cef3f8;
    border: 0px;
  }

  .el-input__inner {
    height: 26px;
    line-height: 25px;
  }

  ::-webkit-input-placeholder {
    font-style: italic;
  }

  .el-input--small {
    font-size: 12px;
  }
}

.Search .el-input--small .el-input__icon {
  line-height: 26px;
}

.Search .el-input__icon {
  line-height: 26px;
}
</style>
