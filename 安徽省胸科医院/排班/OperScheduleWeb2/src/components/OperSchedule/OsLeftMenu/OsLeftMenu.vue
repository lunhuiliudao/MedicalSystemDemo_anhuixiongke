<template>
    <div class="left-content"  v-bind:style="{height:leftHeightObj.leftContentHeight}">
        <el-row style="margin:10px 0px 10px 0px;height:36px;vertical-align:middle;">
            <div class="datefont">日期</div>
            <el-date-picker type="date" size="medium" v-model="scheduleDateTime" v-loading.fullscreen="fullscreenLoading" v-bind:editable="false" v-bind:clearable="false" v-on:change="changeScheduleDateTime" placeholder="选择日期" class="datebutton"></el-date-picker>
            <el-button type="primary" size="small" v-bind:loading="syncLoading" v-on:click="SyncOperinfoList" style="background-color:#33C88A;border-color:#33C88A;width:100px ">同步列表</el-button>
        </el-row>
        <el-row class="left-maincontent">
            <ul class="left-ul">
                <li v-bind:class="listType==1?'left-ul-select-li':'left-ul-noselect-li'" @click="selectTab(1)" >手术列表</li>
                <li v-if="userRole.indexOf('护士')>-1?true:false" v-bind:class="listType==2?'left-ul-select-li':'left-ul-noselect-li'"  @click="selectTab(2)">护士列表</li>
                <li v-if="userRole.indexOf('医生')>-1?true:false" v-bind:class="listType==3?'left-ul-select-li':'left-ul-noselect-li'"  @click="selectTab(3)">医生列表</li>
            </ul>
            <OperList v-show="listType==1"></OperList>
            <NurseList v-if="userRole.indexOf('护士')>-1?true:false" v-show="listType==2"></NurseList>
            <DoctorList v-if="userRole.indexOf('医生')>-1?true:false" v-show="listType==3"></DoctorList>
        </el-row>
    </div>
</template>

<script>
import OsLeftMenu from './OsLeftMenu.js'
export default OsLeftMenu
</script>

<style scoped>
.left-content {
    width: 350px;
    float: left;
    margin-left: 10px;
}

.datefont {
    color: #599EE3;
    font-size: 13px;
    font-weight: 600;
    display:inline;
}

.datebutton {
    margin: 0px 20px 0px 10px;
    width: 150px;
    vertical-align: middle
}

.left-maincontent {
    background-color: white;
    margin-top: 5px;
    -moz-border-radius: 5px;
    -webkit-border-radius: 5px;
    border-radius: 5px;
}

.left-ul {
    display: inline-block;
    position: relative;
    padding: 0px;
    margin: 0px;
}

.left-ul-select-li{
    border-bottom: 2px solid #68A9ED;
    float: left;
    list-style: none;
    height: 30px;
    line-height: 30px;
    font-size: 13px;
    color: #599EE3;
    width: 175px;
    text-align: center;
    letter-spacing: 2px;
    font-weight: 600;
    cursor: default;
}

.left-ul-noselect-li {
    float: left;
    list-style: none;
    height: 30px;
    line-height: 30px;
    font-size: 13px;
    color: #B1B1B1;
    border-bottom: 1px solid #E5E6EA;
    width: 175px;
    text-align: center;
    letter-spacing: 2px;
    cursor: pointer;
}
</style>
