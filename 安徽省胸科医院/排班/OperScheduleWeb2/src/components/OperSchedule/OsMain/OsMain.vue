<template>
  <div class="osMainContent" v-bind:style="{width:osmainWith+'px',height:osmainHeight+'px'}">
    <div style="margin:0px;height:46px; line-height:46px;">
      <div style="float:left;width:19%;padding-left:10px;">
        <i v-bind:class="{'el-icon-menu':true,'select-li':showtype==1,'noselect-li':showtype!=1}" @click="selectchange(1)"> 图形 </i>
        <i v-bind:class="{'el-icon-menu':true,'select-li':showtype==2,'noselect-li':showtype!=2}" @click="selectchange(2)"> 列表 </i>
      </div>
      <div style="float:left" class="summary">
        总台数：{{totalcnt}} 已安排：{{finishedcnt}} 未安排：{{nofinishedcnt}}
      </div>
      <div style="float:left;width:48%" class="title">
        手术人员排班表
      </div>
      <div style="float:right;clear:right;margin-right:10px">
        <el-button type="primary" size="small" class="submit" v-on:click="submitOpertionList">手术提交</el-button>
      </div>
    </div>
    <OsOperChart v-show="showtype==1" v-bind:operChartWith="osmainWith"  v-bind:operChartHeight="osmainHeight"></OsOperChart>
    <OsOperList v-show="showtype==2" v-bind:inWidth="osmainWith" v-bind:inHeight="osmainHeight"></OsOperList>
  </div>
</template>
<script>
import OsMain from './OsMain.js'
export default OsMain
</script>

<style scoped>
.osMainContent {
    float: left;
    margin-left: 10px;
    background: white;
    -moz-border-radius: 5px;
    -webkit-border-radius: 5px;
    border-radius: 5px;
}

.select-li {
    display: inline;
    font-size: 13px;
    color: #1089E7;
    text-align: center;
    letter-spacing: 2px;
    font-weight: 600;
    cursor: default;
    background: white;
    padding: 6px;
    border-radius: 4px;
}

.noselect-li {
    display: inline;
    font-size: 13px;
    color: white;
    text-align: center;
    letter-spacing: 2px;
    cursor: pointer;
    background: #9FC1D8;
    padding: 6px;
    border-radius: 4px;
}

.summary {
    color: #2B9AF0;
    font-size: 12px;
    font-weight: bolder;
    height: 36px;
    line-height: 36px;
    padding-top: 10px;
}

.title {
    font-size: 20px;
    font-weight: bolder;
    text-align: center
}

.submit {
    background-color: #33C88A;
    border-color: #33C88A;
    width: 100px;
}
</style>
