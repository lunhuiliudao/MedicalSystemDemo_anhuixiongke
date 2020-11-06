<template>
  <el-select
    size="small"
    v-model="model"
    :clearable="clearable"
    :remote="remote"
    :filterable="filterable"
    :placeholder="placeholder"
    :remote-method="remoteMethod"
    :disabled="disabled"
    @change="SetChange()"
  >
    <el-option :key="index" v-for="(item,index) in options" :label="item.Value" :value="item.Key">
      <span style="float: left;">{{ item.Value }}</span>
      <span
        v-if="type==='DoctorDict'||type==='NurseDict'||type==='DoctorNurseDict'"
        style="float: right;margin-left:20px;"
      >{{ item.Value===item.Key?'': item.Key }}</span>
    </el-option>
  </el-select>
</template>

<script>
import MedSelect from './MedSelect.js'
export default MedSelect
</script>

<style scoped>
</style>
