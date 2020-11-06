// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      AnesSummaryDoc.cs
// 功能描述(Description)：    麻醉总结单对应的实体类
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2018/01/23 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Documents;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace MedicalSystem.Anes.CustomProject
{
    /// <summary>
    /// 麻醉总结单
    /// </summary>
    public partial class AnesSummaryDoc : CustomBaseDoc
    {
        /// <summary>
        /// 无参构造
        /// </summary>
        public AnesSummaryDoc()
        {
            InitializeComponent();
            base.DocKind = DocKind.Default;
            base.ApplyDataTemplate.Visible = false;
            base.SaveDataTemplate.Visible = false;
        }

        /// <summary>
        /// 初始化自定义的UIElementHandler
        /// </summary>
        protected override void AddCustomUIElementHandlers(List<IUIElementHandler> handlers)
        {
            // 去除通用文本框的Handler，使用SDTextBoxHandler，方便计算出入量信息
            IUIElementHandler handlerTemp = null;
            foreach (IUIElementHandler handler in handlers)
            {
                if (handler is TextBoxHandler)
                {
                    handlerTemp = handler;
                    break;
                }
            }
            if (handlerTemp != null)
            {
                handlers.Remove(handlerTemp);
            }

            handlers.Add(new SDTextBoxHandler());
        }

        /// <summary>
        /// 获取数据源
        /// </summary>
        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {
            List<MED_ANESTHESIA_EVENT> _anesEvent = DataContext.GetCurrent().GetAnesthesiaEvent("0");
            dataSource["AnesAllEvent"] = new ModelHandler<MED_ANESTHESIA_EVENT>().FillDataTable(_anesEvent);
            dataSource["MED_OPERATION_MASTER"] = DataContext.GetCurrent().GetData("MED_OPERATION_MASTER");
            dataSource["MED_OPERATION_MASTER_EXT"] = DataContext.GetCurrent().GetData("MED_OPERATION_MASTER_EXT");
            dataSource["MED_PAT_MASTER_INDEX"] = DataContext.GetCurrent().GetData("MED_PAT_MASTER_INDEX");
            dataSource["MED_PAT_VISIT"] = DataContext.GetCurrent().GetData("MED_PAT_VISIT");
            dataSource["MED_OPERATION_EXTENDED"] = DataContext.GetCurrent().GetData("MED_OPERATION_EXTENDED");
            dataSource["MED_POSTOPERATIVE_EXTENDED"] = DataContext.GetCurrent().GetData("MED_POSTOPERATIVE_EXTENDED");
            dataSource["MED_OPERATION_ANALGESIC_MASTER"] = DataContext.GetCurrent().GetData("MED_OPERATION_ANALGESIC_MASTER");
            dataSource["MED_OPER_ANALGESIC_MEDICINE"] = DataContext.GetCurrent().GetData("MED_OPER_ANALGESIC_MEDICINE");
            dataSource["MED_OPER_ANALGESIC_TOTAL"] = DataContext.GetCurrent().GetData("MED_OPER_ANALGESIC_TOTAL");
            dataSource["MED_ANESTHESIA_PLAN"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN");
            dataSource["MED_ANESTHESIA_PLAN_PMH"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN_PMH");
            dataSource["MED_ANESTHESIA_PLAN_EXAM"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN_EXAM");
            dataSource["MED_ANESTHESIA_INPUT_DATA"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_INPUT_DATA");
            dataSource["MED_PATS_IN_HOSPITAL"] = DataContext.GetCurrent().GetData("MED_PATS_IN_HOSPITAL");
        }

        /// <summary>
        /// 保存数据源
        /// </summary>
        protected override bool OnSaveData(Dictionary<string, DataTable> dataSource)
        {
            bool result = this.SaveDocDataPars(dataSource);
            return result;
        }

        /// <summary>
        /// 在控件全部生成和绑定数据完成后，给自定义控件添加ValueChanged事件
        /// </summary>
        /// <param name="handlers"></param>
        /// <param name="dataSources"></param>
        protected override void OnViewBuilded(List<IUIElementHandler> handlers, Dictionary<string, DataTable> dataSources)
        {
            base.OnViewBuilded(handlers, dataSources);
            List<CustomControl> listCtrl = ReportViewer.GetControls<CustomControl>().Where(x => x.Name.Contains("ctrl")).ToList();
            foreach (var item in listCtrl)
            {
                item.ValueChanged += StewardScoreBox_Click;
            }
        }

        /// <summary>
        /// 再自定义控件值变更时计算Steward分
        /// </summary>
        private void StewardScoreBox_Click(object sender, EventArgs e)
        {
            CustomControl ctrl = sender as CustomControl;
            List<CustomControl> listCtrl = ReportViewer.GetControls<CustomControl>().Where(x => x.Name.Contains("ctrl")).ToList();
            if (ctrl.SimpleValue != null && ctrl.SimpleValue.ToString() != "")
            {
                List<CustomControl> listSameType = listCtrl.FindAll(x => x.Name.Contains(ctrl.Name.Substring(0, ctrl.Name.Length - 2)));
                foreach (var item in listSameType)
                {
                    if (item != ctrl)
                    {
                        item.SimpleValue = null;
                    }
                }
            }

            this.CaluStewardScore(listCtrl);
        }

        /// <summary>
        /// 计算Steward分值
        /// </summary>
        private void CaluStewardScore(List<CustomControl> listCtrl)
        {
            int score = 0;
            foreach (var item in listCtrl)
            {
                if (item.SimpleValue!=null && item.SimpleValue.ToString() != "")
                {
                    string str = Regex.Replace(item.SimpleValue.ToString(), @"[^\d.\d]", "");
                    score += int.Parse(str);
                }
            }

            // 显示总分值
            List<MTextBox> listTextBox = ReportViewer.GetControls<MTextBox>();
            foreach (var item in listTextBox)
            {
                if (item.Name.Equals("MTextBoxStewardScore"))
                {
                    item.Text = score.ToString();
                    break;
                }
            }
        }
    }
}
