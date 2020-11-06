import Steps from '../Steps/Steps.vue'
import Step from '../Step/Step.vue'
export default {
  name: 'ScrollBar',
  data () {
    return {
      steps: [
        { lable: '基本信息', pos: [{ y1: 0, y2: 322 }] },
        { lable: '阅读注意事项', pos: [{ y1: 323, y2: 496 }] },
        { lable: '简述发生经过', pos: [{ y1: 497, y2: 710 }] },
        { lable: '不良事件选择', pos: [{ y1: 711, y2: 922 }] },
        { lable: '不良事件分级', pos: [{ y1: 923, y2: 1127 }] },
        { lable: '事件发生原因', pos: [{ y1: 1128, y2: 1264 }] },
        { lable: '预防措施', pos: [{ y1: 1265, y2: 1475 }] },
        { lable: '添加附件', pos: [{ y1: 1476, y2: 1920 }] }
      ],
      activeStep: 0
    }
  },
  components: { Steps, Step },
  methods: {
    // 跳转事件
    jump (index) {
      // 改变点击的背景色
      this.changeCssStyle(index)
      // 跳转到指定区域
      var rollid = '#roll' + (index + 1) + '_top'
      document.querySelector(rollid).scrollIntoView(true)
    },
    changeCssStyle (val) {
      // 改变点击的背景色

      var steps = document.querySelector('#steps')
      if (steps !== null) {
        for (let i = 0; i < steps.childNodes.length; i++) {
          var el = steps.childNodes[i]
          if (el !== null) {
            for (let j = 0; j < el.childNodes.length; j++) {
              var element = el.childNodes[j]
              if (element !== null) {
                for (var k = 0; k < element.childNodes.length; k++) {
                  var element2 = element.childNodes[k]
                  if (k === 0) {
                    element2.style.color = '#656565'
                  } else {
                    element2.style.backgroundColor = '#FFFFFF'
                  }
                }
              }
            }
          }
        }

        var stepid = '#step' + (val + 1)
        var step = document.querySelector(stepid)
        if (step !== null) {
          for (let j = 0; j < step.childNodes.length; j++) {
            var element3 = step.childNodes[j]
            for (var i = 0; i < element3.childNodes.length; i++) {
              var element4 = element3.childNodes[i]
              if (i === 0) {
                element4.style.color = '#0084BA'
              } else {
                element4.style.backgroundColor = '#0084BA'
              }
            }
          }
        }

        // steps.childNodes.forEach(el => {
        //   el.childNodes.forEach(element => {
        //     for (var i = 0; i < element.childNodes.length; i++) {
        //       var element2 = element.childNodes[i]
        //       if (i === 0) {
        //         element2.style.color = '#656565'
        //       } else {
        //         element2.style.backgroundColor = '#FFFFFF'
        //       }
        //     }
        //   })
        // })

        // var stepid = '#step' + (val + 1)
        // var step = document.querySelector(stepid)
        // step.childNodes.forEach(element => {
        //   for (var i = 0; i < element.childNodes.length; i++) {
        //     var element2 = element.childNodes[i]
        //     if (i === 0) {
        //       element2.style.color = '#0084BA'
        //     } else {
        //       element2.style.backgroundColor = '#0084BA'
        //     }
        //   }
        // })
      }
    }
  },

  mounted () {
    var _this = this
    var stepsTemp = _this.steps
    // 页面加载完成之后，设置默认值
    this.jump(0)

    // 滚动条关联左侧功能列表 ------核心开始-------

    // 将自定义方法绑定到窗口滚动条事件
    var elscrollbarList = document.getElementsByClassName('el-scrollbar__wrap')
    if (elscrollbarList.length > 0) {
      var elscrollbar = elscrollbarList[0]
      elscrollbar.onscroll = () => {
        var ccc = document.getElementsByClassName('el-scrollbar__wrap')
        if (ccc.length > 0) {
          var scrollTop = ccc[0].scrollTop

          for (let j = 0; j < stepsTemp.length; j++) {
            let s = stepsTemp[j]
            let posList = s.pos
            let min = posList[0].y1
            let max = posList[0].y2

            if (
              scrollTop + (2 * (max - min)) / 3 >= min &&
              scrollTop + (2 * (max - min)) / 3 <= max
            ) {
              this.changeCssStyle(j)
            }
          }
        }
      }
    }
  }
}
