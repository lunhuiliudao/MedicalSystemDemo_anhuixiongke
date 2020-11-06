<template>
  <!--每一步骤的最外层包裹div-->
  <div
    class="el-step"
    :style="style"
    :class="[
      !isSimple && `is-${$parent.direction}`,
      isSimple && 'is-simple',
      isLast && !space && !isCenter && 'is-flex',
      isCenter && !isVertical && !isSimple && 'is-center'
     ]"
  >
    <!-- 步骤条下面每一步的标题和描述 -->
    <div class="el-step__main">
      <!--每一步的标题-->
      <div class="el-step__title" ref="title" :class="['is-' + currentStatus]">
        <slot name="title">{{ title }}</slot>
      </div>
      <!--简洁模式下会有>图标-->
      <div v-if="isSimple" class="el-step__arrow"></div>
      <!--每一步的描述-->
      <div v-else class="el-step__description" :class="['is-' + currentStatus]">
        <slot name="description">{{ description }}</slot>
      </div>
    </div>
    <!-- 步骤的数字图标和步骤条直线 -->
    <div class="el-step__head" :class="`is-${currentStatus}`">
      <!--步骤条直线-->
      <!--如果是最后一步，margin-right不存在；如果不是，则为0-->
      <div class="el-step__line" :style="isLast ? '' : { marginRight: $parent.stepOffset + 'px' }">
        <i class="el-step__line-inner" :style="lineStyle"></i>
      </div>
      <!--步骤条的数字图标-->
      <div class="el-step__icon" :class="`is-${icon ? 'icon' : 'text'}`">
        <!--如果当前状态为：wait、process、finish-->
        <slot v-if="currentStatus !== 'success' && currentStatus !== 'error'" name="icon">
          <!--如果是图标则显示对应的图标-->
          <i v-if="icon" class="el-step__icon-inner" :class="[icon]"></i>
          <!--如果图标和未设置isSimple简洁风格时，则显示步骤文字-->
          <div class="el-step__icon-inner" v-if="!icon && !isSimple && isShowNum">{{ index + 1 }}</div>
        </slot>
        <!--如果当前状态为：success、error-->
        <i
          v-else
          :class="['el-icon-' + (currentStatus === 'success' ? 'check' : 'close')]"
          class="el-step__icon-inner is-status"
        ></i>
      </div>
    </div>
  </div>
</template>

<script>
import Step from './Step.js'
export default Step
</script>

<style lang="scss" scoped>
@import "@/assets/styles/global.scss";
.el-step__main {
  white-space: normal;
  text-align: right;
}

.el-step.is-vertical .el-step__main {
  padding-right: 0px;
  margin-right: 10px;
  margin-top: -8px;
  -webkit-box-flex: 1;
  -ms-flex-positive: 1;
  flex-grow: 1;
  cursor: pointer;
}

.el-step.is-vertical .el-step__head {
  -webkit-box-flex: 0;
  -ms-flex-positive: 0;
  flex-grow: 0;
  width: 12px;
}

.el-step__head.is-process {
  color: #303133;
  border-color: #303133;
}

.el-step.is-vertical .el-step__line {
  width: 2px;
  top: 0;
  bottom: 0;
  left: 5px;
}

.el-step__icon.is-text {
  position: absolute;
  width: 12px;
  height: 12px;
  background: rgba(255, 255, 255, 1);

  border-radius: 50%;
  border: 1px solid;
  border-color: inherit;
}

.el-step.is-vertical .el-step__title {
  height: 28px;
  font-size: 12px;
  font-family: MicrosoftYaHei;
  font-weight: 400;
  color: rgba(101, 101, 101, 1);
  line-height: 28px;
  padding-top: 0px;
}

.el-step.is-vertical {
  display: -webkit-box;
  display: -ms-flexbox;
  display: flex;
}
</style>
