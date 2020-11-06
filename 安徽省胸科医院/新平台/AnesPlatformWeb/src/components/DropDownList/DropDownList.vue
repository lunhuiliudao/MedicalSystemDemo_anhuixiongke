<template>
  <el-select size="small" v-model="condition.Value" clearable :filter-method="handleFilter" filterable @change="selectChange"  placeholder="请选择">
    <el-option :key="index" v-for="(item,index) in options" :label="item.Value" :value="item.Key">
    </el-option>
  </el-select>
</template>

<script>
import DropDownList from './DropDownList.js'
export default DropDownList
</script>

<style scoped>
.el-select-dropdown__item.hover {
    background-color: #FFC27D;
}
</style>
