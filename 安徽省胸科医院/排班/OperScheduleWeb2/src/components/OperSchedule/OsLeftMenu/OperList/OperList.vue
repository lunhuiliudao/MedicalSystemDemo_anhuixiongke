<template>
    <div>
        <div class="opersortway">
            <div style="margin-left: 100px;">
                <span class="opersortway-font">排序方法</span>
                <el-radio-group v-model="opersortway" class="opersortway-botton">
                    <el-radio v-bind:label="1">术者</el-radio>
                    <el-radio v-bind:label="2">列表</el-radio>
                </el-radio-group>
            </div>
        </div>
        <div v-show="opersortway==2">
            <table class="leftoper_lb" cellspacing="0" cellpadding="0">
                <colgroup>
                    <col width="70">
                    <col width="50">
                    <col width="40">
                    <col width="40">
                    <col width="40">
                    <col width="92">
                    <col width="17">
                </colgroup>
                <thead>
                    <td>患者姓名</td>
                    <td>住院号</td>
                    <td>年龄</td>
                    <td>性别</td>
                    <td>术者</td>
                    <td>手术名称</td>
                    <td style="width:17px"></td>
                </thead>
            </table>
        </div>
        <div class="div-body-wrapper" v-show="opersortway==2" v-bind:style="{height:leftHeightObj.leftBodyHeight}">
          <el-scrollbar style="height:100%">
            <table class="table-body-wrapper" cellspacing="0" cellpadding="0" style="width:333px">
                <colgroup>
                    <col width="70">
                    <col width="50">
                    <col width="40">
                    <col width="40">
                    <col width="40">
                    <col width="92">
                </colgroup>
                <draggable element="tbody" v-model="leftOperInfo"  :options="dragOptions" :move="onMove">
                    <tr :key='index' v-for="(oper,index) in leftOperInfo">
                        <td>{{oper.NAME}}</td>
                        <td>{{oper.INP_NO}}</td>
                        <td>{{oper.AGE}}</td>
                        <td>{{oper.SEX}}</td>
                        <td>{{oper.SURGEON_NAME}}</td>
                        <!-- <td v-bind:title="oper.TEMP_OPER_NAME">{{valSubStr(oper.TEMP_OPER_NAME,5)}}</td> -->
                        <td v-bind:title="oper.TEMP_OPER_NAME">
                            <OperTr v-on:openDialogOperCancel="openDialogOperCancel" v-on:openDialogOperEdit="openDialogOperEdit"  v-bind:operDetail="oper"></OperTr>
                        </td>
                        <td style="width:0px"></td>
                    </tr>
                </draggable>
            </table>
            <!--<table class="table-body-wrapper" cellspacing="0" cellpadding="0" style="width:333px">
                <colgroup>
                    <col width="70">
                    <col width="50">
                    <col width="40">
                    <col width="40">
                    <col width="40">
                    <col width="92">
                </colgroup>
                <tbody>
                    <tr draggable="true"  v-on:dragstart="drag($event,oper)" v-for="(oper,index) in leftOperInfo">
                        <td>{{oper.NAME}}</td>
                        <td>{{oper.PATIENT_ID}}</td>
                        <td>{{oper.AGE}}</td>
                        <td>{{oper.SEX}}</td>
                        <td>{{oper.SURGEON_NAME}}</td>
                        <td v-bind:title="oper.OPERATION_NAME">{{valSubStr(oper.OPERATION_NAME,5)}}</td>
                        <td style="width:0px"></td>
                    </tr>
                </tbody>
            </table>-->
          </el-scrollbar>
        </div>
        <el-dialog  :visible.sync="dialogOperCancelVisible" custom-class="cancelView" v-bind:close-on-click-modal="false" >
            <CancelView v-on:closeView="closeDialogOperCancel" v-bind:operDetail="OperCancelObj" v-bind:endTime="comEndDateTime"></CancelView>
        </el-dialog>
        <el-dialog  :visible.sync="dialogOperEditVisible" custom-class="operEdit" v-bind:close-on-click-modal="false" >
            <OperEdit v-if="dialogOperEditVisible" v-on:closeOperEditView="closeOperEditShow" v-bind:comOperDetail="OperEditObj"  ></OperEdit>
        </el-dialog>
        <OperSurgeonList v-show="opersortway==1"></OperSurgeonList>
    </div>
</template>

<script>
import OperList from './OperList.js'
export default OperList
</script>

<style scoped>
.opersortway {
    height: 30px;
    background-color: #DCECFC;
    width: 338px;
    margin-left: 6px;
    -moz-border-radius: 6px;
    -webkit-border-radius: 6px;
    border-radius: 6px;
    clear: both;
}

.opersortway-font {
    font-size: 13px;
    color: #747E8E;
    font-weight: 600;
    line-height: 30px;
}

.opersortway-botton {
    margin-left: 20px;
}

.leftoper_lb {
    width: 100%;
}

.leftoper_lb thead td {
    font-size: 12px;
    font-weight: 600;
    text-align: center;
    height: 25px;
}

.div-body-wrapper {
    overflow: auto;
    position: relative;
}

.table-body-wrapper tbody tr td {
    font-size: 12px;
    text-align: center;
    height: 35px;
    border-top: 1px solid #E5E6EA;
}

.table-body-wrapper tbody tr:hover {
    background-color: #4498EC;
    cursor: pointer;
    color: white;
}

.flip-list-move {
  transition: transform 0.5s;
}

.ghost {
  opacity: .1;
  color: white;
  height: 0PX;
  width: 0PX;
}
</style>
