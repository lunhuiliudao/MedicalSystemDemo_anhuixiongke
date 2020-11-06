// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      SafetyCheckDoc.cs
// 功能描述(Description)：    安全核查表对应的实体类
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
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using System.Collections.Generic;
using System.Data;

namespace MedicalSystem.Anes.CustomProject
{
    /// <summary>
    /// 安全核查表
    /// </summary>
    public partial class SafetyCheckDoc : CustomBaseDoc
    {
        /// <summary>
        /// 无参构造
        /// </summary>
        public SafetyCheckDoc()
        {
            InitializeComponent();
            base.DocKind = DocKind.Default;
        }

        /// <summary>
        /// 获取数据源
        /// </summary>
        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {
            dataSource["MED_OPERATION_MASTER"] = DataContext.GetCurrent().GetData("MED_OPERATION_MASTER"); ;
            dataSource["MED_PAT_MASTER_INDEX"] = DataContext.GetCurrent().GetData("MED_PAT_MASTER_INDEX");
            dataSource["MED_PAT_VISIT"] = DataContext.GetCurrent().GetData("MED_PAT_VISIT");
            dataSource["MED_ANESTHESIA_PLAN"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN");
            dataSource["MED_SAFETY_CHECKS"] = DataContext.GetCurrent().GetData("MED_SAFETY_CHECKS");
            dataSource["MED_ANESTHESIA_PLAN_PMH"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN_PMH");
            dataSource["MED_OPER_RISK_ESTIMATE"] = DataContext.GetCurrent().GetData("MED_OPER_RISK_ESTIMATE");
            dataSource["MED_PREOPERATIVE_EXPANSION"] = DataContext.GetCurrent().GetData("MED_PREOPERATIVE_EXPANSION");
            dataSource["MED_PATS_IN_HOSPITAL"] = DataContext.GetCurrent().GetData("MED_PATS_IN_HOSPITAL");
            dataSource["MED_POSTOPERATIVE_EXTENDED"] = DataContext.GetCurrent().GetData("MED_POSTOPERATIVE_EXTENDED");
            this.IsReadOnly();
        }

        /// <summary>
        /// 根据文书状态是否为只读状态，来设置自定义控件和文本框控件是否为只读
        /// </summary>
        private void IsReadOnly()
        {
            string statusName = statusReadOnly;
            if (!string.IsNullOrEmpty(statusName))
            {
                List<CustomControl> controls = this.ReportViewer.GetControls<CustomControl>();
                List<MTextBox> txtBoxList = this.ReportViewer.GetControls<MTextBox>();
                foreach (CustomControl control in controls)
                {
                    if (control.GroupName != null && !control.GroupName.Equals(statusName)) control.ReadOnly = true;
                }
                foreach (MTextBox txt in txtBoxList)
                {
                    if (txt.SummaryName != null && !txt.SummaryName.Equals(statusName)) txt.ReadOnly = true;
                }
            }
        }

        /// <summary>
        /// 保存数据源
        /// </summary>
        protected override bool OnSaveData(Dictionary<string, DataTable> dataSource)
        {
            bool result = this.SaveDocDataPars(dataSource);
            return result;
        }
    }
}
