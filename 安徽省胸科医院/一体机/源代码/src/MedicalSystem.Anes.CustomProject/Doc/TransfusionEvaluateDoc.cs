// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      TransfusionEvaluateDoc.cs
// 功能描述(Description)：    输液输血评估单对应的实体类
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
using System.Windows.Forms;

namespace MedicalSystem.Anes.CustomProject
{
    /// <summary>
    /// 输液输血评估单
    /// </summary>
    public partial class TransfusionEvaluateDoc : CustomBaseDoc
    {
        private string _eventNo = "0";                         // 系统类型：麻醉（0）OR复苏（1）

        /// <summary>
        /// 无参构造
        /// </summary>
        public TransfusionEvaluateDoc()
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
            // 去除通用的文本框Handler，使用SDTextBoxHandler，计算出入量数据
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
        /// 数据源绑定
        /// </summary>
        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {
            dataSource["MED_OPERATION_MASTER"] = DataContext.GetCurrent().GetData("MED_OPERATION_MASTER"); ;
            dataSource["MED_PAT_MASTER_INDEX"] = DataContext.GetCurrent().GetData("MED_PAT_MASTER_INDEX");
            dataSource["MED_PAT_VISIT"] = DataContext.GetCurrent().GetData("MED_PAT_VISIT");
            dataSource["MED_ANESTHESIA_RECOVER"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_RECOVER");
            dataSource["MED_ANESTHESIA_INQUIRY"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_INQUIRY");
            dataSource["MED_POSTOPERATIVE_EXTENDED"] = DataContext.GetCurrent().GetData("MED_POSTOPERATIVE_EXTENDED");
            dataSource["MED_PATS_IN_HOSPITAL"] = DataContext.GetCurrent().GetData("MED_PATS_IN_HOSPITAL");
            dataSource["MED_PACU_SORCE"] = DataContext.GetCurrent().GetData("MED_PACU_SORCE");
            dataSource["MED_ANESTHESIA_PLAN"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN");
            dataSource["MED_ANESTHESIA_PLAN_PMH"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN_PMH");
            dataSource["MED_ANESTHESIA_PLAN_EXAM"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN_EXAM");
            dataSource["MED_ANESTHESIA_INPUT_DATA"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_INPUT_DATA");
            dataSource["MED_OPERATION_ANALGESIC_MASTER"] = DataContext.GetCurrent().GetData("MED_OPERATION_ANALGESIC_MASTER");
            dataSource["MED_OPERATION_EXTENDED"] = DataContext.GetCurrent().GetData("MED_OPERATION_EXTENDED");
            List<MED_ANESTHESIA_EVENT> _anesEvent = DataContext.GetCurrent().GetAnesthesiaEvent(_eventNo);
            dataSource["AnesAllEvent"] = new ModelHandler<MED_ANESTHESIA_EVENT>().FillDataTable(_anesEvent);
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
        /// 重新数据保存前判断逻辑：必填项提示
        /// </summary>
        public override bool OnCustomCheckBeforeSave()
        {
            bool bl = base.OnCustomCheckBeforeSave();
            foreach (IUIElementHandler handler in _UIElementHandlers)
            {
                if (handler.GetControlType == typeof(MTextBox) && handler.GetAllControls != null)
                {
                    foreach (Control ctl in handler.GetAllControls)
                    {
                        if (ctl is MTextBox)
                        {
                            MTextBox textbox = ctl as MTextBox;
                            if (!string.IsNullOrEmpty(textbox.InputNeededMessage) && string.IsNullOrEmpty(textbox.Text.Trim()))
                            {
                                MessageBox.Show(textbox.InputNeededMessage, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                                return false;
                            }
                        }
                    }
                }
            }

            return bl;
        }
    }
}
