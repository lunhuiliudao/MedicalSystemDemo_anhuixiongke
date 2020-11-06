<template>
  <div style="height:116px;background-color: #E3F5FF;">
    <div class="roomNo" v-on:dragover="allowDrop" v-on:drop="drop">{{RoomNo}}</div>
    <draggable class="roomContent" v-bind:style="{width:(operChartWith - 65 - 10)+'px'}" v-model="operInfoList"  :options="dragOptions" :move="onMove" @add="onAddOper" @update="datadragEnd" >
      <transition-group tag="div" type="transition" :name="'flip-list'" v-bind:style="{width:(operChartWith - 65 - 10)+'px',height:'115px'}">
        <OsOperCard v-bind:secondWidth="comSecondWidth" v-bind:timeSpanWidth="comTimeSpanWidth" v-bind:operList="operInfoList"  v-bind:operIndex="index" v-bind:operDetail="itemOper" v-bind:isFirst="(index===0?true:false)"  v-bind:key="itemOper.PATIENT_ID+itemOper.VISIT_ID+itemOper.SCHEDULE_ID" v-for="(itemOper,index) in operInfoList" ></OsOperCard>
      </transition-group>
    </draggable>
    <!--<div class="roomContent" v-bind:style="{width:(operChartWith - 65 - 17)+'px'}"  v-on:dragover="allowDrop" v-on:drop="drop" >
      <OsOperCard v-bind:secondWidth="comSecondWidth" v-bind:timeSpanWidth="comTimeSpanWidth"  v-bind:operDetail="itemOper" v-bind:isFirst="(index===0?true:false)"  v-bind:key="index" v-for="(itemOper,index) in operInfoList" ></OsOperCard>
    </div>-->
  </div>
</template>

<script>
import OsOperRoom from './OsOperRoom.js'
export default OsOperRoom
</script>

<style scoped>
.roomNo {
  width: 60px;
  height: 115px;
  background-color: #55A8FB;
  text-align: center;
  line-height: 115px;
  overflow: hidden;
  font-size: 17px;
  font-weight: 600;
  float: left;
  border-bottom: 1px #E4E6E9 solid;
  color:white;
}

.roomContent {
  height: 115px;
  overflow: hidden;
  float: left;
  clear: right;
  margin-left: 5px;
  border-bottom: 1px solid white
}

.flip-list-move {
  transition: transform 0.5s;
}

.ghost {
  opacity: .5;
  background: #C8EBFB;
}
</style>
