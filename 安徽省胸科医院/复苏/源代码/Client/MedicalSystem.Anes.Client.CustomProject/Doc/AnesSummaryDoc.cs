using System.Collections.Generic;
using System.Data;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.CustomProject
{
    public partial class AnesSummaryDoc : CustomBaseDoc
    {
        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();


        public AnesSummaryDoc()
        {
            InitializeComponent();
            base.DocKind = DocKind.Default;
            base.ApplyDataTemplate.Visible = true;
            base.SaveDataTemplate.Visible = false;
        }
        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {
            dataSource["MED_OPERATION_MASTER"] = DataContext.GetCurrent().GetData("MED_OPERATION_MASTER"); ;
            dataSource["MED_PAT_MASTER_INDEX"] = DataContext.GetCurrent().GetData("MED_PAT_MASTER_INDEX");
            dataSource["MED_PAT_VISIT"] = DataContext.GetCurrent().GetData("MED_PAT_VISIT");
            dataSource["MED_OPERATION_EXTENDED"] = DataContext.GetCurrent().GetData("MED_OPERATION_EXTENDED");
            dataSource["MED_POSTOPERATIVE_EXTENDED"] = DataContext.GetCurrent().GetData("MED_POSTOPERATIVE_EXTENDED");
            dataSource["MED_OPERATION_ANALGESIC_MASTER"] = DataContext.GetCurrent().GetData("MED_OPERATION_ANALGESIC_MASTER");
            dataSource["MED_OPER_ANALGESIC_MEDICINE"] = DataContext.GetCurrent().GetData("MED_OPER_ANALGESIC_MEDICINE");
            dataSource["MED_OPER_ANALGESIC_TOTAL"] = DataContext.GetCurrent().GetData("MED_OPER_ANALGESIC_TOTAL");
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

            List<MED_OPERATION_EXTENDED> operExtended = ModelHelper<MED_OPERATION_EXTENDED>.ConvertDataTableToList(dataSource["MED_OPERATION_EXTENDED"]);

            List<MED_POSTOPERATIVE_EXTENDED> postExtended = ModelHelper<MED_POSTOPERATIVE_EXTENDED>.ConvertDataTableToList(dataSource["MED_POSTOPERATIVE_EXTENDED"]);


            List<MED_OPERATION_ANALGESIC_MASTER> analgesicMaster = ModelHelper<MED_OPERATION_ANALGESIC_MASTER>.ConvertDataTableToList(dataSource["MED_OPERATION_ANALGESIC_MASTER"]);
            if (analgesicMaster != null && analgesicMaster.Count > 0)
                operationInfoRepository.SaveAnalgesicMaster(analgesicMaster[0]);

            List<MED_OPER_ANALGESIC_MEDICINE> analgesicMedicine = ModelHelper<MED_OPER_ANALGESIC_MEDICINE>.ConvertDataTableToList(dataSource["MED_OPER_ANALGESIC_MEDICINE"]);
            if (analgesicMedicine != null)
                operationInfoRepository.SaveAnalgesicMedicineList(analgesicMedicine);

            List<MED_OPER_ANALGESIC_TOTAL> analgesicTotal = ModelHelper<MED_OPER_ANALGESIC_TOTAL>.ConvertDataTableToList(dataSource["MED_OPER_ANALGESIC_TOTAL"]);
            if (analgesicTotal != null)
                operationInfoRepository.SaveAnalgesicTotalList(analgesicTotal);

            //OperationInfoService.SaveMedicalBasicDoc(operMaster, patIndex, patVisit, null, null, null, null, operExtended, postExtended, null);

            MED_PATS_IN_HOSPITAL patsInHospital = null;

            MED_ANESTHESIA_PLAN anesPlan = null;

            MED_ANESTHESIA_PLAN_EXAM anesPlanExam = null;

            MED_ANESTHESIA_PLAN_PMH anesPlanPmh = null;

            List<MED_PREOPERATIVE_EXPANSION> preExpansion = null;


            operationInfoRepository.SaveMedicalBasicDoc(new { operMaster, patMasterIndex, patVisit, patsInHospital, anesPlan, anesPlanExam, anesPlanPmh, operExtended, postExtended, preExpansion });



        }
    }
}
