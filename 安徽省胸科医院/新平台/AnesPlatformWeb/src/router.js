import Vue from 'vue'
import Router from 'vue-router'
import Layout from './views/layout/Layout.vue'

Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/login',
      component: () => import('./views/Login/Login.vue'),
      meta: { key: 'login' }
    },
    {
      path: '/PatientInfo',
      component: () => import('./views/PatientInfo/PatientInfo.vue'),
      meta: { key: '患者信息' }
    },
    {
      path: '*',
      component: () => import('./views/ErrorPage/404.vue'),
      meta: { key: '错误页' }
    },
    {
      path: '/',
      component: Layout,
      redirect: '/home',
      children: [
        {
          path: '/home',
          component: () => import('./views/Home/Home.vue'),
          meta: { key: '首页' }
        },
        {
          path: '/DocManage',
          component: () => import('./views/DocManage/DocManage.vue'),
          meta: { key: '文书管理' }
        },
        {
          path: '/quality',
          beforeEnter: (to, from, next) => { },
          meta: { key: '质控管理', nonext: true }
        },
        {
          path: '/quality/reported',
          component: () =>
            import('./views/Quality/QualityReported/QualityReported.vue'),
          meta: { key: '质控管理', pname: '质控上报', name: '质控数据上报' }
        },
        {
          path: '/quality/report',
          component: () =>
            import('./views/Quality/QualityReport/QualityReport.vue'),
          meta: { key: '质控管理', pname: '质控上报', name: '质控数据统计' }
        },
        {
          path: '/quality/reportmaintain',
          component: () =>
            import('./views/Quality/QualityReportMaintain/QualityReportMaintain.vue'),
          meta: { key: '质控管理', pname: '质控上报', name: '上报数据维护' }
        },
        {
          path: '/quality/register',
          component: () => import('./views/Quality/Register/Register.vue'),
          meta: { key: '质控管理', pname: '质控上报', name: '不良事件登记' }
        },
        {
          path: '/quality/:pname/:name',
          component: () =>
            import('./views/AnesReport/GeneralView/GeneralView.vue'),
          meta: { key: '质控管理' }
        },
        {
          path: '/localAnesRegister',
          component: () =>
            import('./views/LocalAnesRegister/LocalAnesRegister.vue'),
          meta: { key: '局麻登记' }
        },
        {
          path: '/anesreport',
          beforeEnter: (to, from, next) => { },
          meta: { key: '日常查询', nonext: true }
        },
        {
          path: '/anesreport/:pname/:name',
          component: () =>
            import('./views/AnesReport/GeneralView/GeneralView.vue'),
          meta: { key: '日常查询' }
        },
        {
          path: '/anesreport/demo',
          component: () => import('./views/AnesReport/Demo/Demo.vue'),
          meta: { key: '日常查询', pname: '手术查询', name: 'demo' }
        },
        {
          path: '/sysmanage',
          beforeEnter: (to, from, next) => { },
          meta: { key: '系统设置', nonext: true }
        },
        {
          path: '/sysmanage/customconfig',
          component: () =>
            import('./views/SystemManage/OtherConfig/CustomConfig/CustomConfig.vue'),
          meta: { key: '系统设置', pname: '其他配置', name: '统计配置' }
        },
        {
          path: '/sysmanage/documentconfig',
          component: () =>
            import('./views/SystemManage/OtherConfig/DocumentConfig/DocumentConfig.vue'),
          meta: { key: '系统设置', pname: '其他配置', name: '导航配置' }
        },
        {
          path: '/sysmanage/shujuconfig',
          component: () =>
            import('./views/SystemManage/OtherConfig/AnesMethodClassConfig/AnesMethodClassConfig.vue'),
          meta: { key: '系统设置', pname: '其他配置', name: '数据归类' }
        },
        {
          path: '/sysmanage/vitalsignsconfig',
          component: () =>
            import('./views/SystemManage/OtherConfig/VitalSignsConfig/VitalSignsConfig.vue'),
          meta: { key: '系统设置', pname: '其他配置', name: '默认体征配置' }
        },
        {
          path: '/sysmanage/medconfig',
          component: () =>
            import('./views/SystemManage/OtherConfig/MedConfig/MedConfig.vue'),
          meta: { key: '系统设置', pname: '其他配置', name: '一体机配置' }
        },
        {
          path: '/sysmanage/helpconfig',
          component: () =>
            import('./views/SystemManage/OtherConfig/WeChatSyn/WeChatSyn.vue'),
          meta: { key: '系统设置', pname: '其他配置', name: '工具' }
        },
        {
          path: '/sysmanage/quanlityitemedit',
          component: () =>
            import('./views/SystemManage/QualityConfig/QuanlityItemEdit/QuanlityItemEdit.vue'),
          meta: { key: '系统设置', pname: '质控配置', name: '质控项目定义' }
        },
        {
          path: '/sysmanage/quanlityreportedit',
          component: () =>
            import('./views/SystemManage/QualityConfig/QuanlityReportListEdit/QuanlityReportListEdit.vue'),
          meta: { key: '系统设置', pname: '质控配置', name: '质控报表定义' }
        },
        {
          path: '/sysmanage/quanlityuploadconfig',
          component: () =>
            import('./views/SystemManage/QualityConfig/QuanlityUploadConfig/QuanlityUploadConfig.vue'),
          meta: { key: '系统设置', pname: '质控配置', name: '质控上报项目适配' }
        },
        {
          path: '/sysmanage/deptdict',
          component: () =>
            import('./views/SystemManage/BasicDataConfig/DeptDict/DeptDict.vue'),
          meta: { key: '系统设置', pname: '基础数据管理', name: '科室字典维护' }
        },
        {
          path: '/sysmanage/hisuserdict',
          component: () =>
            import('./views/SystemManage/BasicDataConfig/HisUserDict/HisUserDict.vue'),
          meta: { key: '系统设置', pname: '基础数据管理', name: '人员字典维护' }
        },
        {
          path: '/sysmanage/operationdict',
          component: () =>
            import('./views/SystemManage/BasicDataConfig/OperationDict/OperationDict.vue'),
          meta: {
            key: '系统设置',
            pname: '基础数据管理',
            name: '手术名称字典维护'
          }
        },
        {
          path: '/sysmanage/diagnosisdict',
          component: () =>
            import('./views/SystemManage/BasicDataConfig/DiagnosisDict/DiagnosisDict.vue'),
          meta: {
            key: '系统设置',
            pname: '基础数据管理',
            name: '诊断字典维护'
          }
        },
        {
          path: '/sysmanage/anesinputdict',
          component: () =>
            import('./views/SystemManage/BasicDataConfig/AnesInputDict/AnesInputDict.vue'),
          meta: {
            key: '系统设置',
            pname: '基础数据管理',
            name: '常用术语维护'
          }
        },
        {
          path: '/sysmanage/administrationdict',
          component: () =>
            import('./views/SystemManage/BasicDataConfig/AdministrationDict/AdministrationDict.vue'),
          meta: {
            key: '系统设置',
            pname: '基础数据管理',
            name: '给药途径字典维护'
          }
        },
        {
          path: '/sysmanage/anesmethoddict',
          component: () =>
            import('./views/SystemManage/BasicDataConfig/AnesMethodDict/AnesMethodDict.vue'),
          meta: {
            key: '系统设置',
            pname: '基础数据管理',
            name: '麻醉方法字典维护'
          }
        },
        {
          path: '/sysmanage/operatingroom',
          component: () =>
            import('./views/SystemManage/BasicDataConfig/OperatingRoom/OperatingRoom.vue'),
          meta: {
            key: '系统设置',
            pname: '基础数据管理',
            name: '手术间字典维护'
          }
        },
        {
          path: '/sysmanage/monitordict',
          component: () =>
            import('./views/SystemManage/BasicDataConfig/MonitorDict/MonitorDict.vue'),
          meta: {
            key: '系统设置',
            pname: '基础数据管理',
            name: '采集仪器字典维护'
          }
        },
        {
          path: '/sysmanage/unitdict',
          component: () =>
            import('./views/SystemManage/BasicDataConfig/UnitDict/UnitDict.vue'),
          meta: {
            key: '系统设置',
            pname: '基础数据管理',
            name: '单位字典维护'
          }
        },
        {
          path: '/sysmanage/monitorfunctioncode',
          component: () =>
            import('./views/SystemManage/BasicDataConfig/MonitorFunctionCode/MonitorFunctionCode.vue'),
          meta: {
            key: '系统设置',
            pname: '基础数据管理',
            name: '采集项目字典维护'
          }
        },
        {
          path: '/sysmanage/eventtemplete',
          component: () =>
            import('./views/SystemManage/TempleteConfig/EventTemplete/EventTemplete.vue'),
          meta: {
            key: '系统设置',
            pname: '模板管理',
            name: '个人路径管理'
          }
        },
        {
          path: '/sysmanage/anesdrugedit',
          component: () =>
            import('./views/SystemManage/EventDictConfig/AnesDrugEdit/AnesDrugEdit.vue'),
          meta: {
            key: '系统设置',
            pname: '术中用药管理',
            name: '麻药维护'
          }
        },
        {
          path: '/sysmanage/drugedit',
          component: () =>
            import('./views/SystemManage/EventDictConfig/DrugEdit/DrugEdit.vue'),
          meta: {
            key: '系统设置',
            pname: '术中用药管理',
            name: '一般用药维护'
          }
        },
        {
          path: '/sysmanage/inliquidedit',
          component: () =>
            import('./views/SystemManage/EventDictConfig/InLiquidEdit/InLiquidEdit.vue'),
          meta: {
            key: '系统设置',
            pname: '术中用药管理',
            name: '输液维护'
          }
        },
        {
          path: '/sysmanage/eventedit',
          component: () =>
            import('./views/SystemManage/EventDictConfig/EventEdit/EventEdit.vue'),
          meta: {
            key: '系统设置',
            pname: '术中用药管理',
            name: '事件维护'
          }
        },
        {
          path: '/sysmanage/controlbreathedit',
          component: () =>
            import('./views/SystemManage/EventDictConfig/ControlBreathEdit/ControlBreathEdit.vue'),
          meta: {
            key: '系统设置',
            pname: '术中用药管理',
            name: '控制呼吸维护'
          }
        },
        {
          path: '/sysmanage/helpbreathedit',
          component: () =>
            import('./views/SystemManage/EventDictConfig/HelpBreathEdit/HelpBreathEdit.vue'),
          meta: {
            key: '系统设置',
            pname: '术中用药管理',
            name: '辅助呼吸维护'
          }
        },
        {
          path: '/sysmanage/freebreathedit',
          component: () =>
            import('./views/SystemManage/EventDictConfig/FreeBreathEdit/FreeBreathEdit.vue'),
          meta: {
            key: '系统设置',
            pname: '术中用药管理',
            name: '自主呼吸维护'
          }
        },
        {
          path: '/sysmanage/inoxygenedit',
          component: () =>
            import('./views/SystemManage/EventDictConfig/InOxygenEdit/InOxygenEdit.vue'),
          meta: {
            key: '系统设置',
            pname: '术中用药管理',
            name: '输氧维护'
          }
        },
        {
          path: '/sysmanage/inbloodedit',
          component: () =>
            import('./views/SystemManage/EventDictConfig/InBloodEdit/InBloodEdit.vue'),
          meta: {
            key: '系统设置',
            pname: '术中用药管理',
            name: '输血维护'
          }
        },
        {
          path: '/sysmanage/putpipeedit',
          component: () =>
            import('./views/SystemManage/EventDictConfig/PutPipeEdit/PutPipeEdit.vue'),
          meta: {
            key: '系统设置',
            pname: '术中用药管理',
            name: '插管维护'
          }
        },
        {
          path: '/sysmanage/pullpipeedit',
          component: () =>
            import('./views/SystemManage/EventDictConfig/PullPipeEdit/PullPipeEdit.vue'),
          meta: {
            key: '系统设置',
            pname: '术中用药管理',
            name: '拔管维护'
          }
        },
        {
          path: '/sysmanage/outliquidedit',
          component: () =>
            import('./views/SystemManage/EventDictConfig/OutLiquidEdit/OutLiquidEdit.vue'),
          meta: {
            key: '系统设置',
            pname: '术中用药管理',
            name: '出液维护'
          }
        },
        {
          path: '/sysmanage/anesdrugusualedit1',
          component: () =>
            import('./views/SystemManage/EventDictConfig/AnesDrugUsualEdit/AnesDrugUsualEdit.vue'),
          meta: {
            key: '系统设置',
            pname: '术中用药管理',
            name: '麻药常用剂量'
          }
        },
        {
          path: '/sysmanage/anesdrugusualedit2',
          component: () =>
            import('./views/SystemManage/EventDictConfig/AnesDrugUsualEdit/AnesDrugUsualEdit.vue'),
          meta: {
            key: '系统设置',
            pname: '术中用药管理',
            name: '一般用药常用剂量'
          }
        },
        {
          path: '/sysmanage/anesdrugusualedit3',
          component: () =>
            import('./views/SystemManage/EventDictConfig/AnesDrugUsualEdit/AnesDrugUsualEdit.vue'),
          meta: {
            key: '系统设置',
            pname: '术中用药管理',
            name: '输液常用剂量'
          }
        },
        {
          path: '/sysmanage/anesdrugusualedit4',
          component: () =>
            import('./views/SystemManage/EventDictConfig/AnesDrugUsualEdit/AnesDrugUsualEdit.vue'),
          meta: {
            key: '系统设置',
            pname: '术中用药管理',
            name: '输血常用剂量'
          }
        },
        {
          path: '/sysmanage/chargeitemsconfig',
          component: () =>
            import('./views/SystemManage/ChargeAllocationConfig/ChargeItemsConfig/ChargeItemsConfig.vue'),
          meta: {
            key: '系统设置',
            pname: '收费配置',
            name: '收费项目配置'
          }
        },
        {
          path: '/sysmanage/chargetemplateedit',
          component: () =>
            import('./views/SystemManage/ChargeAllocationConfig/ChargeTemplateEdit/ChargeTemplateEdit.vue'),
          meta: {
            key: '系统设置',
            pname: '收费配置',
            name: '收费模板管理'
          }
        }
      ]
    }
  ]
})
