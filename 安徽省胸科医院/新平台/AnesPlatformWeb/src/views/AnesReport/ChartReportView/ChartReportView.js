// 引入 ECharts 主模块
var echarts = require('echarts/lib/echarts')
// 引入折线图
require('echarts/lib/chart/line')
// 引入饼图
require('echarts/lib/chart/pie')
// 引入柱状图
require('echarts/lib/chart/bar')
// 引入组件
require('echarts/lib/component/tooltip')
require('echarts/lib/component/title')
require('echarts/lib/component/legendScroll')

export default {
  name: 'ChartReportView',
  data () {
    return {
      chartReport: {},
      optionChartLine: {
        tooltip: {
          trigger: 'axis',
          axisPointer: {
            type: 'cross'
          }
        },
        xAxis: { type: 'value' },
        yAxis: { type: 'value' },
        series: []
      },
      optionChartPie: {
        tooltip: {
          trigger: 'item',
          formatter: '{b} : {c} ({d}%)'
        },
        legend: {
          orient: 'horizontal',
          left: 'center',
          data: []
        },
        series: [
          {
            type: 'pie',
            radius: '55%',
            center: ['50%', '60%'],
            data: [],
            itemStyle: {
              emphasis: {
                shadowBlur: 10,
                shadowOffsetX: 0,
                shadowColor: 'rgba(0, 0, 0, 0.5)'
              }
            }
          }
        ]
      },
      optionChartBar: {
        tooltip: {
          trigger: 'axis',
          axisPointer: {
            type: 'shadow'
          }
        },
        xAxis: { type: 'value' },
        yAxis: { type: 'value' },
        series: []
      }
    }
  },
  props: ['reportInformation', 'reportData'],
  mounted: function () {
    this.chartReport = echarts.init(document.getElementById('mainChart'))
    let charinfo = this.reportInformation.ReportChartInfo
    if (charinfo.ChartType === 'Line') {
      this.getLineOption(charinfo)
      this.chartReport.setOption(this.optionChartLine)
    } else if (charinfo.ChartType === 'Pie') {
      this.getPieOption(charinfo)
      this.chartReport.setOption(this.optionChartPie)
    } else if (charinfo.ChartType === 'Bar') {
      this.getBarOption(charinfo)
      this.chartReport.setOption(this.optionChartBar)
    }
  },
  methods: {
    getBarOption (charinfo) {
      let xaxisobjdata = []
      let xaxisobj = { type: charinfo.XAxisInfo.Type, data: charinfo.XAxisInfo.Data }
      let legendobj = { data: [] }
      charinfo.SeriesData.forEach((element, i) => {
        legendobj.data.push(element.Title)
        let seriesobjdata = []
        this.reportData.currentData.forEach((element2) => {
          seriesobjdata.push(element2[element.Field])
          if (i === 0 && charinfo.XAxisInfo.DataColumn !== '') {
            xaxisobjdata.push(element2[charinfo.XAxisInfo.DataColumn])
          }
        })
        let seriesobj = {
          name: element.Title,
          type: 'bar',
          stack: '总量',
          data: seriesobjdata
        }
        this.optionChartBar.series.push(seriesobj)
      })
      this.optionChartBar.legend = legendobj
      if (charinfo.XAxisInfo.DataColumn !== '') {
        xaxisobj.data = xaxisobjdata
      }
      this.optionChartBar.xAxis = xaxisobj
    },
    getPieOption (charinfo) {
      if (charinfo.SeriesData.length > 1) {
        let legendobjdata = []
        this.reportData.currentData.forEach((element) => {
          let seriesobjdata = { name: element[charinfo.SeriesData[0].Field], value: element[charinfo.SeriesData[1].Field] }
          legendobjdata.push(seriesobjdata.name)
          this.optionChartPie.series[0].data.push(seriesobjdata)
        })
        this.optionChartPie.legend.data = legendobjdata
      }
    },
    getLineOption (charinfo) {
      let xaxisobjdata = []
      let xaxisobj = { type: charinfo.XAxisInfo.Type, data: charinfo.XAxisInfo.Data }
      charinfo.SeriesData.forEach((element, i) => {
        let seriesobjdata = []
        this.reportData.currentData.forEach((element2) => {
          seriesobjdata.push(element2[element.Field])
          if (i === 0 && charinfo.XAxisInfo.DataColumn !== '') {
            xaxisobjdata.push(element2[charinfo.XAxisInfo.DataColumn])
          }
        })
        let seriesobj = {
          name: element.Title,
          type: 'line',
          data: seriesobjdata
        }
        this.optionChartLine.series.push(seriesobj)
      })
      if (charinfo.XAxisInfo.DataColumn !== '') {
        xaxisobj.data = xaxisobjdata
      }
      this.optionChartLine.xAxis = xaxisobj
    }
  }
}
