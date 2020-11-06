// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      AnalgesicRecordDoc.cs
// 功能描述(Description)：    术后随访单对应的实体类
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2018/01/23 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.Anes.CustomProject.AnesVisitDocHandlers;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Documents;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MedicalSystem.Anes.CustomProject
{
    public partial class AnesAfterVisiterDoc : CustomBaseDoc
    {
        private  MTextBox MTB_TotalRecord = null;                          // 汇总文本框

        /// <summary>
        /// 无参构造
        /// </summary>
        public AnesAfterVisiterDoc()
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
            // 去除通用的表格Handler，使用个性化SYRMGridViewHandler
            IUIElementHandler handlerTemp = null;
            foreach (IUIElementHandler handler in handlers)
            {
                if (handler is GridViewHandler)
                {
                    handlerTemp = handler;
                    break;
                }
            }
            if (handlerTemp != null)
            {
                handlers.Remove(handlerTemp);
            }

            SYRMGridViewHandler gridViewHandler = new SYRMGridViewHandler();
            gridViewHandler.OnRefreshTotalScore += new SYRMGridViewHandler.RefreshTotalScore(OnRefreshTotalScore);
            handlers.Add(gridViewHandler);
        }

        /// <summary>
        /// 获取数据源
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
        }

        protected override void OnViewBuilded(List<IUIElementHandler> handlers, Dictionary<string, DataTable> dataSources)
        {
            base.OnViewBuilded(handlers, dataSources);

            List<MTextBox> txtBoxList = ReportViewer.GetControls<MTextBox>();
            foreach(MTextBox tb in txtBoxList)
            {
                if(null != tb.SourceTableName && null != tb.SourceFieldName && tb.SourceTableName.Equals("MED_POSTOPERATIVE_EXTENDED") && tb.SourceFieldName.Equals("术后.日期"))
                {
                    if (tb.Data == null || tb.Data.ToString() == "")
                    {
                        tb.Data = ((DateTime)dataSources["MED_OPERATION_MASTER"].Rows[0]["SCHEDULED_DATE_TIME"]).AddDays(1.0).ToString("yyyy-MM-dd");
                        tb.Text = ((DateTime)dataSources["MED_OPERATION_MASTER"].Rows[0]["SCHEDULED_DATE_TIME"]).AddDays(1.0).ToString("yyyy-MM-dd");
                    }
                    break;
                }
            }
        }


        /// <summary>
        /// 保存数据
        /// </summary>
        protected override bool OnSaveData(Dictionary<string, DataTable> dataSource)
        {
            bool result = this.SaveDocDataPars(dataSource);
            return result;
        }

        /// <summary>
        /// 刷新计算汇总信息
        /// </summary>
        private void OnRefreshTotalScore(object sender, SYRMGridViewCellValueChangeEventArgs e)
        {
            if (MTB_TotalRecord == null)
            {
                List<MTextBox> list = base.GetControls<MTextBox>();
                if (list != null)
                {
                    foreach (MTextBox textBox in list)
                    {
                        if (textBox.Name.ToUpper().Equals("MTB_TotalRecord".ToUpper()))
                        {
                            //如果找到
                            MTB_TotalRecord = textBox;
                            break;
                        }
                    }
                }
            }

            // MTB_TotalRecord 不为null
            if (MTB_TotalRecord != null)
            {
                MTB_TotalRecord.Text = "0";
                MTB_TotalRecord.Text = e.ValueTatol.ToString();

                foreach (IUIElementHandler handler in _UIElementHandlers)
                {
                    if (handler is TextBoxHandler)
                    {
                        handler.HasDirty = false;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 重写方法：保存数据前判断
        /// </summary>
        /// <returns></returns>
        public override bool OnCustomCheckBeforeSave()
        {
            bool bl = base.OnCustomCheckBeforeSave();
            if (bl)
            {
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
            }

            return bl;
        }
    }
}
