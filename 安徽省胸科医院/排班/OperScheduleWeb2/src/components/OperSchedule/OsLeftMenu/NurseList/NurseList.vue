<template>
  <div>
      <!-- <el-dialog  v-model="dialogNurseSelectRoomVisible" title="护士排班" size="tiny" custom-class="dialogNurseSelectRoom"  v-bind:close-on-click-modal="false" >
            <el-form ref="form" label-width="80px">
                <el-form-item label="护士类型">
                    <el-select v-model="dialogNurseSelectType" placeholder="请选择">
                        <el-option label="洗手护士" v-bind:value="1"></el-option>
                        <el-option label="巡回护士" v-bind:value="2"></el-option>
                    </el-select>
                </el-form-item>
            </el-form>
      </el-dialog> -->
      <div class="opersortway">
            <el-radio-group v-model="opersortway" class="opersortway-botton">
                <el-radio v-bind:label="1">洗手护士</el-radio>
                <el-radio v-bind:label="2">巡回护士</el-radio>
            </el-radio-group>
      </div>
      <div class="div-body-wrapper" v-bind:style="{height:leftBodyHeight}">
          <ul>
            <li :key="index" draggable="true" v-on:dragstart="drag($event,item)" v-for="(item,index) in nursesList">
             {{item.USER_NAME}}&nbsp;{{item.INPUT_CODE}}
            </li>
          </ul>
      </div>
  </div>
</template>

<script>
import NurseList from './NurseList.js'
export default NurseList
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
    line-height: 30px;
}

.opersortway-botton {
    margin-left: 130px;
}

.div-body-wrapper {
    overflow: auto;
    position: relative;
}

.div-body-wrapper ul {
    display: inline-block;
    position: relative;
    padding: 0px;
    margin: 0px;
    width: 332px;
}

.div-body-wrapper ul li{
    /*border-bottom: 1px solid #E5E6EA;*/
    float: left;
    list-style: none;
    height: 40px;
    line-height: 40px;
    font-size: 13px;
    width: 166px;
    text-align: center;
    letter-spacing: 2px;
    font-weight: 600;
    cursor: move;
}

.dialogNurseSelectRoom {
    width: 100%
}
</style>
