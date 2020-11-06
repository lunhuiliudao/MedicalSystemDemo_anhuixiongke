<template>
  <div class="ignore-elements">
      <el-popover ref="popover1" placement="right" trigger="click">
        <ul class="popUl">
          <li @click="openDialogOperCancel">手术取消</li>
          <li @click="openDialogOperEdit">申请信息</li>
        </ul>
      </el-popover>
      <span class="showSpan" v-popover:popover1> {{valSubStr(operDetail.TEMP_OPER_NAME,6)}}</span>
  </div>
</template>

<script>
import OperTr from './OperTr.js'
export default OperTr
</script>

<style scoped>
.showSpan {
  display: inline-block;
  width: 92px;
  height: 36px;
  line-height: 36px;
  text-align: center;
}
</style>
