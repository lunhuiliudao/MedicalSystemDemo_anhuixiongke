export default {
  name: 'Step',

  props: {
    title: String, // 标题
    icon: String, // 图标
    description: String, // 描述性文字
    status: String // 设置当前步骤的状态，不设置则根据 steps 确定状态。 wait（灰色）/ process（黑色）/ finish（蓝色）/ error / success（绿色）
  },

  data () {
    return {
      index: -1,
      lineStyle: {}, // 步骤条直线的样式
      internalStatus: ''
    }
  },

  beforeCreate () {
    this.$parent.steps.push(this)
  },
  mounted () {
    const unwatch = this.$watch('index', val => {
      this.$watch('$parent.active', this.updateStatus, { immediate: true })
      unwatch()
    })
  },
  beforeDestroy () {
    const steps = this.$parent.steps
    const index = steps.indexOf(this)
    if (index >= 0) {
      steps.splice(index, 1)
    }
  },

  computed: {
    // 返回当前步骤的状态
    currentStatus () {
      return this.status || this.internalStatus
    },
    prevStatus () {
      const prevStep = this.$parent.steps[this.index - 1]
      return prevStep ? prevStep.currentStatus : 'wait'
    },
    // 返回是否是居中对齐
    isCenter () {
      return this.$parent.alignCenter
    },
    // 返回显示的方向:竖直(false)或者水平(true)
    isVertical () {
      return this.$parent.direction === 'vertical'
    },
    // 返回是否应用简洁风格
    isSimple () {
      return this.$parent.simple
    },
    // 返回是否显示数字
    isShowNum () {
      return this.$parent.showNum
    },
    // 判断当前是不是最后步骤
    isLast () {
      const parent = this.$parent
      return parent.steps[parent.steps.length - 1] === this
    },
    //  返回总步骤数
    stepsCount () {
      return this.$parent.steps.length
    },
    // 返回每个step的间距。
    space () {
      const {
        isSimple,
        $parent: { space }
      } = this
      // isSimple为true时，space将失效
      return isSimple ? '' : space
    },
    style: function () {
      const style = {}
      const parent = this.$parent
      const len = parent.steps.length // 总步骤
      // 每个step的间距
      const space =
        typeof this.space === 'number' // 如果设置的space是number
          ? this.space + 'px' // space等于设置的space
          : this.space
            ? this.space
            : 100 / (len - (this.isCenter ? 0 : 1)) + '%' // 如果未设置space，未设置居中，则等于100除以（总步骤数-1）；设置居中显示，则等于00除以总步骤数。
      // flex-basis 属性用于设置或检索弹性盒伸缩基准值。
      style.flexBasis = space
      // 如果是水平方向则直接返回设置的样式
      if (this.isVertical) return style
      // 如果是最后的步骤，设置最大宽度等于(100/总步骤数)%
      if (this.isLast) {
        style.maxWidth = 100 / this.stepsCount + '%'
      } else {
        // 如果不是最后的步骤，marginRight为0
        style.marginRight = -this.$parent.stepOffset + 'px'
      }
      return style
    }
  },

  methods: {
    updateStatus (val) {
      const prevChild = this.$parent.$children[this.index - 1]
      if (val > this.index) {
        // 如果是下一步
        //  internalStatus 等于用户设置的结束步骤状态
        this.internalStatus = this.$parent.finishStatus
      } else if (val === this.index && this.prevStatus !== 'error') {
        //  internalStatus 等于用户设置的当前步骤状态
        this.internalStatus = this.$parent.processStatus
      } else {
        this.internalStatus = 'wait'
      }
      if (prevChild) prevChild.calcProgress(this.internalStatus)
    },
    // 设置步骤间直线的样式
    calcProgress (status) {
      let step = 100
      const style = {}
      // transitionDelay在过渡效果开始前等待的秒数：
      style.transitionDelay = 150 * this.index + 'ms'
      if (status === this.$parent.processStatus) {
        step = this.currentStatus !== 'error' ? 0 : 0
      } else if (status === 'wait') {
        step = 0
        // 为负数的时候过渡的动作会从该时间点开始显示，之前的动作被截断；为正数的时候过渡的动作会延迟触发。
        style.transitionDelay = -150 * this.index + 'ms'
      }

      style.borderWidth = step ? '1px' : 0
      this.$parent.direction === 'vertical'
        ? (style.height = step + '%')
        : (style.width = step + '%')

      this.lineStyle = style
    }
  }
}
