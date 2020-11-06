<template>
  <div>
      <div class="opersortway">
            <el-radio-group v-model="opersortway" class="opersortway-botton">
                <el-radio v-bind:label="1">主麻</el-radio>
                <el-radio v-bind:label="2">副麻</el-radio>
            </el-radio-group>
      </div>
      <div class="div-body-wrapper" v-bind:style="{height:leftBodyHeight}">
          <ul>
            <li :key="index" draggable="true"  v-on:dragstart="drag($event,item)" v-for="(item,index) in doctorList">
                {{item.USER_NAME}}&nbsp;{{item.INPUT_CODE}}
            </li>
          </ul>
      </div>
  </div>
</template>

<script>
import DoctorList from './DoctorList.js'
export default DoctorList
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
    margin-left: 190px;
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
</style>
