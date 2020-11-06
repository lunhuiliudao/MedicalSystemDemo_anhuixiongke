using System.Collections.Generic;
using System.Data;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.CustomProject
{
    public partial class SafetyCheckDoc : CustomBaseDoc
    {
        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        public SafetyCheckDoc()
        {
            InitializeComponent();
            base.DocKind = DocKind.Default;
        }
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
            IsReadOnly();
        }
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
        protected override void OnSaveData(Dictionary<string, DataTable> dataSource)
        {
            List<MED_OPERATION_MASTER> operMasterList = ModelHelper<MED_OPERATION_MASTER>.ConvertDataTableToList(dataSource["MED_OPERATION_MASTER"]);
            MED_OPERATION_MASTER operMaster = null;
            if (operMasterList != null && operMasterList.Count > 0)
                operMaster = operMasterList[0];

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

            List<MED_PREOPERATIVE_EXPANSION> preExpansion = ModelHelper<MED_PREOPERATIVE_EXPANSION>.ConvertDataTableToList(dataSource["MED_PREOPERATIVE_EXPANSION"]);

            List<MED_SAFETY_CHECKS> safetyCheck = ModelHelper<MED_SAFETY_CHECKS>.ConvertDataTableToList(dataSource["MED_SAFETY_CHECKS"]);
            if (safetyCheck != null && safetyCheck.Count > 0)
                operationInfoRepository.SaveSafetyCheck(safetyCheck[0]);

            List<MED_OPER_RISK_ESTIMATE> riskEstimate = ModelHelper<MED_OPER_RISK_ESTIMATE>.ConvertDataTableToList(dataSource["MED_OPER_RISK_ESTIMATE"]);
            if (riskEstimate != null && riskEstimate.Count > 0)
                operationInfoRepository.SaveRickEstimate(riskEstimate[0]);

            // OperationInfoService.SaveMedicalBasicDoc(operMaster, patIndex, patVisit, null, anesPlan, null, anesPlanPMH, null, null, preExpansion);

            MED_PATS_IN_HOSPITAL patsInHospital = null;


            MED_ANESTHESIA_PLAN_EXAM anesPlanExam = null;

            MED_ANESTHESIA_PLAN_PMH anesPlanPmh = null;

            List<MED_OPERATION_EXTENDED> operExtended = null;

            List<MED_POSTOPERATIVE_EXTENDED> postExtended = null;

            operationInfoRepository.SaveMedicalBasicDoc(new { operMaster, patMasterIndex, patVisit, patsInHospital, anesPlan, anesPlanExam, anesPlanPmh, operExtended, postExtended, preExpansion });

        }
    }
}
