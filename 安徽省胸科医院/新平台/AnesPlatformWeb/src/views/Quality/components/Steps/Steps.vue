<template>
  <!--设置 simple 可应用简洁风格，该条件下 align-center / description / direction / space 都将失效。-->
  <div
    class="el-steps"
    :class="[
       !simple && 'el-steps--' + direction,
       simple && 'el-steps--simple'
     ]"
  >
    <slot></slot>
  </div>
</template>

<script>
import Steps from './Steps.js'
export default Steps
</script>
