<template>
  <div style="height:600px;width:200px;">
    <Steps id="steps" direction="vertical" space="1.5rem" :active="activeStep" :showNum="false">
      <Step
        :id="'step'+(index + 1)"
        v-for="(item, index) in steps"
        :key="index"
        :title="item.lable"
        @click.native="jump(index)"
      ></Step>
    </Steps>
  </div>
</template>

<script>
import ScrollBar from './ScrollBar.js'
export default ScrollBar
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";
</style>
