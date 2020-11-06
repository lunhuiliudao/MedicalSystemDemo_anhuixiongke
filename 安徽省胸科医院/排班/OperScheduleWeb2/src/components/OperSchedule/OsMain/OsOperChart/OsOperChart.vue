<template>
  <div v-bind:style="{width:operChartWith+'px'}">
    <div>
      <canvas id="timeLineCanvas" v-bind:width="operChartWith" height="32">
        浏览器不支持canvas标签.
      </canvas>
    </div>
    <div v-bind:style="{width:operChartWith+'px',height:(operChartHeight-46-39)+'px',overflow:'auto'}">
      <el-scrollbar style="height:100%">
        <OsOperRoom v-bind:operChartWith="operChartWith"  v-bind:RoomNo="itemRoom.ROOM_NO" v-bind:spanWidth="spanWidth" v-bind:key="index" v-for="(itemRoom, index) in operRoomNoList"></OsOperRoom>
      </el-scrollbar>
    </div>
    <!-- <div v-bind:style="{width:operChartWith+'px',height:(operChartHeight-56-40)+'px',overflow:'auto'}">
      <OsOperRoom v-bind:operChartWith="operChartWith"  v-bind:RoomNo="itemRoom.ROOM_NO" v-bind:spanWidth="spanWidth" v-bind:key="index" v-for="(itemRoom, index) in operRoomNoList"></OsOperRoom>
    </div> -->
  </div>
</template>

<script>
import OsOperChart from './OsOperChart.js'
export default OsOperChart
</script>

<style scoped>
#timeLineCanvas {
  background-color: #FCEBAF;
  -moz-border-radius: 3px;
  -webkit-border-radius: 3px;
  border-radius: 3px;
}
</style>

<style>
.el-scrollbar__wrap {
  overflow-x: hidden;
}
</style>
