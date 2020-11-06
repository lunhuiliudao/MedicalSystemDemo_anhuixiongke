<template>
  <el-autocomplete
    :placeholder="placeholder"
    v-model="model"
    :fetch-suggestions="querySearchAsync"
    :disabled="disabled"
    :clearable="clearable"
    value-key="Key"
    @select="handleSelect"
    @change="SetChange()"
  >
    <template slot-scope="{ item }">
      <div>{{ item.Key }}</div>
    </template>
  </el-autocomplete>
</template>

<script>
import InputSelect from './InputSelect.js'
export default InputSelect
</script>

<style scoped>
</style>
