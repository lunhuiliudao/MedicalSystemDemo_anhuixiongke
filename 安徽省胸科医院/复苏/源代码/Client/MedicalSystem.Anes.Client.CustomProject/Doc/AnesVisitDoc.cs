using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Client.Repository;
using MedicalSystem.Services;

namespace MedicalSystem.Anes.Client.CustomProject
{
    public partial class AnesVisitDoc : CustomBaseDoc
    {
        SyncInfoRepository syncInfoRepository = new SyncInfoRepository();

        CommonRepository commonRepository = new CommonRepository();

        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();


        public AnesVisitDoc()
        {
            InitializeComponent();
            base.DocKind = DocKind.Default;
            this.OnReportViewMouseDown += (control_MouseDown);
        }
        private void control_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                ToolStripMenuItem item = new ToolStripMenuItem("提取检验数据");
                item.Click += new EventHandler(delegate(object sender1, EventArgs e1)
                {
                    syncInfoRepository.SyncLisByVisitID(ExtendApplicationContext.Current.PatientContextExtend.PatientID, ExtendApplicationContext.Current.PatientContextExtend.VisitID, new EventHandler(SyncLisCompelete));
                    //SyncLis();
                });
                menu.Items.Add(item);
                menu.Show(Control.MousePosition);
            }
        }
        private void SyncLisCompelete(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            List<MED_LAB_PATIENT> labQuery = commonRepository.GetLabPatientList(ExtendApplicationContext.Current.PatientInformationExtend.PATIENT_ID, ExtendApplicationContext.Current.PatientInformationExtend.VISIT_ID).Data;
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
                                    ctl.Text = string.IsNullOrEmpty(row.RESULT) ? "" : row.RESULT.Trim();
                                }
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(row.REPORT_ITEM_NAME) && ctl.LabItemName.Trim().Equals(row.REPORT_ITEM_NAME))
                                {
                                    ctl.Text = string.IsNullOrEmpty(row.RESULT) ? "" : row.RESULT.Trim();
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {
            dataSource["MED_OPERATION_MASTER"] = DataContext.GetCurrent().GetData("MED_OPERATION_MASTER"); ;
            List<MED_OPERATION_MASTER> lists = ModelHelper<MED_OPERATION_MASTER>.ConvertDataTableToList(dataSource["MED_OPERATION_MASTER"]);
            MED_OPERATION_MASTER operMaster = lists[0];
            Logger.Error("AnesDoc:" + operMaster.PATIENT_ID + "|" + operMaster.VISIT_ID + "|" + operMaster.OPER_ID + "|" + operMaster.OPER_STATUS_CODE + "|" + operMaster.IN_PACU_DATE_TIME + "|" + operMaster.OUT_PACU_DATE_TIME);
            dataSource["MED_PAT_MASTER_INDEX"] = DataContext.GetCurrent().GetData("MED_PAT_MASTER_INDEX");
            dataSource["MED_PAT_VISIT"] = DataContext.GetCurrent().GetData("MED_PAT_VISIT");
            dataSource["MED_PATS_IN_HOSPITAL"] = DataContext.GetCurrent().GetData("MED_PATS_IN_HOSPITAL");
            dataSource["MED_ANESTHESIA_PLAN"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN");
            dataSource["MED_ANESTHESIA_PLAN_PMH"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN_PMH");
            dataSource["MED_ANESTHESIA_PLAN_EXAM"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN_EXAM");
            dataSource["MED_PREOPERATIVE_EXPANSION"] = DataContext.GetCurrent().GetData("MED_PREOPERATIVE_EXPANSION");
            dataSource["MED_POSTOPERATIVE_EXTENDED"] = DataContext.GetCurrent().GetData("MED_POSTOPERATIVE_EXTENDED");
            //dataSource["MED_BJCA_SIGN"] = DataContext.GetCurrent().GetData("MED_BJCA_SIGN");
            //DataTable bjcaDt = DataContext.GetCurrent().GetData("MED_BJCA_SIGN");
            //if (bjcaDt.Rows.Count > 0)
            //{
            //    DataRow[] dataRows = bjcaDt.Select("SIGNDOCNAME = '" + this.Caption + "'");
            //    if (dataRows.Length > 0)
            //    {
            //        DataTable dt = bjcaDt.Clone();
            //        foreach (var item in dataRows)
            //        {
            //            dt.Rows.Add(item.ItemArray);
            //        }
            //        dataSource["MED_BJCA_SIGN"] = dt;
            //    }
            //}
        }

        protected override void OnSaveData(Dictionary<string, DataTable> dataSource)
        {

            List<MED_OPERATION_MASTER> operMasterList = ModelHelper<MED_OPERATION_MASTER>.ConvertDataTableToList(dataSource["MED_OPERATION_MASTER"]);
            MED_OPERATION_MASTER operMaster = null;
            if (operMasterList != null && operMasterList.Count > 0)
            {
                operMaster = operMasterList[0];
                if (!operMaster.OUT_PACU_DATE_TIME.HasValue && operMaster.OPER_STATUS_CODE == (int)OperationStatus.InPACU)
                {
                    MED_OPERATION_MASTER master = operationInfoRepository.GetOperMaster(ExtendApplicationContext.Current.PatientContextExtend.PatientID, 
                        ExtendApplicationContext.Current.PatientContextExtend.VisitID, 
                        ExtendApplicationContext.Current.PatientContextExtend.OperID).Data;

                    if (master.OUT_PACU_DATE_TIME.HasValue)
                    {
                        operMaster.OUT_PACU_DATE_TIME = master.OUT_PACU_DATE_TIME;
                        operMaster.OPER_STATUS_CODE = master.OPER_STATUS_CODE;
                    }
                }
                if (operMaster.IN_PACU_DATE_TIME.HasValue && !operMaster.OUT_PACU_DATE_TIME.HasValue)
                    operMaster.OPER_STATUS_CODE = 45;
            }

            List<MED_PAT_MASTER_INDEX> patIndexList = ModelHelper<MED_PAT_MASTER_INDEX>.ConvertDataTableToList(dataSource["MED_PAT_MASTER_INDEX"]);
            MED_PAT_MASTER_INDEX patMasterIndex = null;
            if (patIndexList != null && patIndexList.Count > 0)
                patMasterIndex = patIndexList[0];

            List<MED_PAT_VISIT> patVisitList = ModelHelper<MED_PAT_VISIT>.ConvertDataTableToList(dataSource["MED_PAT_VISIT"]);
            MED_PAT_VISIT patVisit = null;
            if (patVisitList != null && patVisitList.Count > 0)
                patVisit = patVisitList[0];

            List<MED_ANESTHESIA_PLAN> anesPlanList = ModelHelper<MED_ANESTHESIA_PLAN>.ConvertDataTableToList(dataSource["MED_ANESTHESIA_PLAN"]);
            MED_ANESTHESIA_PLAN anesPlan = null;
            if (anesPlanList != null && anesPlanList.Count > 0)
                anesPlan = anesPlanList[0];

            List<MED_ANESTHESIA_PLAN_PMH> anesPlanPMHList = ModelHelper<MED_ANESTHESIA_PLAN_PMH>.ConvertDataTableToList(dataSource["MED_ANESTHESIA_PLAN_PMH"]);
            MED_ANESTHESIA_PLAN_PMH anesPlanPMH = null;
            if (anesPlanPMHList != null && anesPlanPMHList.Count > 0)
                anesPlanPMH = anesPlanPMHList[0];

            List<MED_ANESTHESIA_PLAN_EXAM> anesPlanExamList = ModelHelper<MED_ANESTHESIA_PLAN_EXAM>.ConvertDataTableToList(dataSource["MED_ANESTHESIA_PLAN_EXAM"]);
            MED_ANESTHESIA_PLAN_EXAM anesPlanExam = null;
            if (anesPlanExamList != null && anesPlanExamList.Count > 0)
                anesPlanExam = anesPlanExamList[0];

            List<MED_PREOPERATIVE_EXPANSION> preExpansion = ModelHelper<MED_PREOPERATIVE_EXPANSION>.ConvertDataTableToList(dataSource["MED_PREOPERATIVE_EXPANSION"]);

            List<MED_POSTOPERATIVE_EXTENDED> postExtended = ModelHelper<MED_POSTOPERATIVE_EXTENDED>.ConvertDataTableToList(dataSource["MED_POSTOPERATIVE_EXTENDED"]);

            // OperationInfoService.SaveMedicalBasicDoc(operMaster, patIndex, patVisit, null, anesPlan, anesPlanExam, anesPlanPMH, null, posExtended, preExpansion);

            MED_PATS_IN_HOSPITAL patsInHospital = null;

            MED_ANESTHESIA_PLAN_PMH anesPlanPmh = null;

            List<MED_OPERATION_EXTENDED> operExtended = null;


            operationInfoRepository.SaveMedicalBasicDoc(new { operMaster, patMasterIndex, patVisit, patsInHospital, anesPlan, anesPlanExam, anesPlanPmh, operExtended, postExtended, preExpansion });

        }
    }
}
