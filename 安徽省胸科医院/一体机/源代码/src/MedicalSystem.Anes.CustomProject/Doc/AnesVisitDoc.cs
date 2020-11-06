// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      AnesVisitDoc.cs
// 功能描述(Description)：    术前访视单对应的实体类
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
using MedicalSystem.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace MedicalSystem.Anes.CustomProject
{
    /// <summary>
    /// 术前访视单
    /// </summary>
    public partial class AnesVisitDoc : CustomBaseDoc
    {
        /// <summary>
        /// 无参构造
        /// </summary>
        public AnesVisitDoc()
        {
            InitializeComponent();
            base.DocKind = DocKind.Default;
            this.OnReportViewMouseDown += (control_MouseDown);
        }

        /// <summary>
        /// 在所有控件生成和数据绑定完成后，给Panel添加MouseDown事件
        /// </summary>
        protected override void OnViewBuilded(List<Document.Documents.IUIElementHandler> handlers, Dictionary<string, DataTable> dataSources)
        {
            base.OnViewBuilded(handlers, dataSources);
            List<Panel> lists = this.ReportViewer.GetControls<Panel>();
            foreach (Panel panel in lists)
            {
                panel.MouseDown += (control_MouseDown);
            }
        }

        /// <summary>
        /// 面板鼠标点击事件，实现提取检验数据
        /// </summary>
        private void control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                ToolStripMenuItem item = new ToolStripMenuItem("提取检验数据");
                item.Click += new EventHandler(delegate(object sender1, EventArgs e1)
                {
                    string tt = SyncInfoService.ClientInstance.SyncAnesVisit(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID, ExtendAppContext.Current.PatientInformationExtend.VISIT_ID, ExtendAppContext.Current.PatientInformationExtend.OPER_ID);
                    string ret = SyncInfoService.ClientInstance.SyncLis(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID, ExtendAppContext.Current.PatientInformationExtend.VISIT_ID, new EventHandler(SyncLisCompelete));
                    if (ret != "")
                    {
                        Logger.Error("调用接口异常信息", new Exception(ret));
                    }
                });

                menu.Items.Add(item);
                menu.Show(Control.MousePosition);
            }
        }

        /// <summary>
        /// 同步接口，提取完检验信息数据后，将对应的数据显示到对应的文本框中
        /// </summary>
        private void SyncLisCompelete(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            List<MED_LAB_PATIENT> labQuery = CommonService.ClientInstance.GetLabPatientList(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID, ExtendAppContext.Current.PatientInformationExtend.VISIT_ID);
            if (labQuery != null && labQuery.Count > 0)
            {
                foreach (MTextBox ctl in GetControls<MTextBox>())
                {
                    if (!string.IsNullOrEmpty(ctl.LabItemName))
                    {
                        foreach (MED_LAB_PATIENT row in labQuery)
                        {
                            if (!string.IsNullOrEmpty(ctl.LabItemType))
                            {
                                if (!string.IsNullOrEmpty(row.REPORT_ITEM_NAME) && !string.IsNullOrEmpty(row.TEST_CAUSE) && ctl.LabItemType.Trim().Equals(row.TEST_CAUSE) && ctl.LabItemName.Trim().Equals(row.REPORT_ITEM_NAME))
                                {
                                    if (!string.IsNullOrEmpty(row.RESULT)&& !string.IsNullOrEmpty(row.RESULT))
                                    {
                                        ctl.Text = row.RESULT.Trim();
                                        ctl.Data = ctl.Text;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(row.REPORT_ITEM_NAME) && ctl.LabItemName.Trim().Equals(row.REPORT_ITEM_NAME))
                                {
                                    if (!string.IsNullOrEmpty(row.RESULT) && !string.IsNullOrEmpty(row.RESULT))
                                    {
                                        ctl.Text = row.RESULT.Trim();
                                        ctl.Data = ctl.Text;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 绑定数据源
        /// </summary>
        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {
            dataSource["MED_OPERATION_MASTER"] = DataContext.GetCurrent().GetData("MED_OPERATION_MASTER"); ;
            dataSource["MED_PAT_MASTER_INDEX"] = DataContext.GetCurrent().GetData("MED_PAT_MASTER_INDEX");
            dataSource["MED_PAT_VISIT"] = DataContext.GetCurrent().GetData("MED_PAT_VISIT");
            dataSource["MED_ANESTHESIA_PLAN"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN");
            dataSource["MED_ANESTHESIA_PLAN_PMH"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN_PMH");
            dataSource["MED_ANESTHESIA_PLAN_EXAM"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN_EXAM");
            dataSource["MED_PREOPERATIVE_EXPANSION"] = DataContext.GetCurrent().GetData("MED_PREOPERATIVE_EXPANSION");
            dataSource["MED_PATS_IN_HOSPITAL"] = DataContext.GetCurrent().GetData("MED_PATS_IN_HOSPITAL");
            dataSource["MED_ANESTHESIA_INPUT_DATA"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_INPUT_DATA");
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
