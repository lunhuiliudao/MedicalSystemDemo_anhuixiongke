// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      RiskAssessmentDoc.cs
// 功能描述(Description)：    手术风险评估单对应的实体类
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
using System.Collections.Generic;
using System.Data;

namespace MedicalSystem.Anes.CustomProject
{
    /// <summary>
    /// 手术风险评估单
    /// </summary>
    public partial class RiskAssessmentDoc : CustomBaseDoc
    {
        /// <summary>
        /// 无参构造
        /// </summary>
        public RiskAssessmentDoc()
        {
            InitializeComponent();
            base.DocKind = DocKind.Default;
        }

        /// <summary>
        /// 重新控件Handler的绑定
        /// </summary>
        protected override void AddCustomUIElementHandlers(List<IUIElementHandler> handlers)
        {
            // 去除通用自定义控件的Handler，使用ExtendCustomControlHandler，计算对应的分值
            IUIElementHandler handlerTemp2 = null;
            foreach (IUIElementHandler handler in handlers)
            {
                if (handler is CustomControlHandler)
                {
                    handlerTemp2 = handler;
                }
            }
            if (handlerTemp2 != null)
            {
                handlers.Remove(handlerTemp2);
            }

            handlers.Add(new ExtendCustomControlHandler());
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
                    if (!control.Name.Equals(statusName)) control.ReadOnly = true;
                }
                foreach (MTextBox txt in txtBoxList)
                {
                    if (!txt.Name.Equals(statusName)) txt.ReadOnly = true;
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
