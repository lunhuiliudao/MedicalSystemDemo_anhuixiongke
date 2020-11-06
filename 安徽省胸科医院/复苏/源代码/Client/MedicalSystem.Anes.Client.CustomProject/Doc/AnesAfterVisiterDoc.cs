using System.Collections.Generic;
using System.Data;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.CustomProject
{
    public partial class AnesAfterVisiterDoc : CustomBaseDoc
    {
        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        public AnesAfterVisiterDoc()
        {
            InitializeComponent();
            base.DocKind = DocKind.Default;
        }
        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {
            dataSource["MED_OPERATION_MASTER"] = DataContext.GetCurrent().GetData("MED_OPERATION_MASTER"); ;
            dataSource["MED_PAT_MASTER_INDEX"] = DataContext.GetCurrent().GetData("MED_PAT_MASTER_INDEX");
            dataSource["MED_PAT_VISIT"] = DataContext.GetCurrent().GetData("MED_PAT_VISIT");
            dataSource["MED_ANESTHESIA_RECOVER"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_RECOVER");
            dataSource["MED_ANESTHESIA_INQUIRY"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_INQUIRY");
            dataSource["MED_POSTOPERATIVE_EXTENDED"] = DataContext.GetCurrent().GetData("MED_POSTOPERATIVE_EXTENDED");
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

            List<MED_ANESTHESIA_RECOVER> anesReconver = ModelHelper<MED_ANESTHESIA_RECOVER>.ConvertDataTableToList(dataSource["MED_ANESTHESIA_RECOVER"]);
            if (anesReconver != null && anesReconver.Count > 0)
                operationInfoRepository.SaveAnesRecoverData(anesReconver[0]);

            List<MED_ANESTHESIA_INQUIRY> anesInquiry = ModelHelper<MED_ANESTHESIA_INQUIRY>.ConvertDataTableToList(dataSource["MED_ANESTHESIA_INQUIRY"]);
            if (anesInquiry != null && anesInquiry.Count > 0)
                operationInfoRepository.SaveAnesInquiryData(anesInquiry[0]);

            List<MED_POSTOPERATIVE_EXTENDED> postExtended = ModelHelper<MED_POSTOPERATIVE_EXTENDED>.ConvertDataTableToList(dataSource["MED_POSTOPERATIVE_EXTENDED"]);

            MED_PATS_IN_HOSPITAL patsInHospital = null;

            MED_ANESTHESIA_PLAN anesPlan = null;

            MED_ANESTHESIA_PLAN_EXAM anesPlanExam = null;

            MED_ANESTHESIA_PLAN_PMH anesPlanPmh = null;

            List<MED_OPERATION_EXTENDED> operExtended = null;

            List<MED_PREOPERATIVE_EXPANSION> preExpansion = null;

            operationInfoRepository.SaveMedicalBasicDoc(new { operMaster, patMasterIndex, patVisit, patsInHospital, anesPlan, anesPlanExam, anesPlanPmh, operExtended, postExtended, preExpansion });

        }
    }
}
