using System.Collections.Generic;
using System.Data;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.CustomProject
{
    /// <summary>
    /// 麻醉同意书
    /// </summary>
    public partial class AnesAgreementDoc : CustomBaseDoc
    {
        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();


        public AnesAgreementDoc()
        {
            // _pageFromHeight = true;
            InitializeComponent();
            base.DocKind = DocKind.Default;
            // pageCount = 2;
            //base.ApplyDataTemplate.Visible = false ;
            //base.SaveDataTemplate.Visible = false;
        }
        int pageCount = 1;
        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {
            dataSource["MED_OPERATION_MASTER"] = DataContext.GetCurrent().GetData("MED_OPERATION_MASTER"); ;
            dataSource["MED_PAT_MASTER_INDEX"] = DataContext.GetCurrent().GetData("MED_PAT_MASTER_INDEX");
            dataSource["MED_PAT_VISIT"] = DataContext.GetCurrent().GetData("MED_PAT_VISIT");
            dataSource["MED_ANESTHESIA_PLAN_PMH"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN_PMH");
            dataSource["MED_PREOPERATIVE_EXPANSION"] = DataContext.GetCurrent().GetData("MED_PREOPERATIVE_EXPANSION");
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

            List<MED_ANESTHESIA_PLAN_PMH> anesPlanPMHList = ModelHelper<MED_ANESTHESIA_PLAN_PMH>.ConvertDataTableToList(dataSource["MED_ANESTHESIA_PLAN_PMH"]);
            MED_ANESTHESIA_PLAN_PMH anesPlanPMH = null;
            if (anesPlanPMHList != null && anesPlanPMHList.Count > 0)
                anesPlanPMH = anesPlanPMHList[0];

            List<MED_PREOPERATIVE_EXPANSION> preExpansion = ModelHelper<MED_PREOPERATIVE_EXPANSION>.ConvertDataTableToList(dataSource["MED_PREOPERATIVE_EXPANSION"]);

            // OperationInfoService.SaveMedicalBasicDoc(operMaster, patIndex, patVisit, null, null, null, anesPlanPMH, null, null, preExpansion);
            MED_PATS_IN_HOSPITAL patsInHospital = null;

            MED_ANESTHESIA_PLAN anesPlan = null;

            MED_ANESTHESIA_PLAN_EXAM anesPlanExam = null;

            MED_ANESTHESIA_PLAN_PMH anesPlanPmh = null;

            List<MED_OPERATION_EXTENDED> operExtended = null;

            List<MED_POSTOPERATIVE_EXTENDED> postExtended = null;

            operationInfoRepository.SaveMedicalBasicDoc(new { operMaster, patMasterIndex, patVisit, patsInHospital, anesPlan, anesPlanExam, anesPlanPmh, operExtended, postExtended, preExpansion });

        }
        protected override void OnPagerSetting(PagerSetting pagerSetting)
        {
            if (_pageFromHeight)
            {
                pagerSetting.PagerDesc.Clear();
                pagerSetting.AllowPage = true;
                for (int i = 0; i < pageCount; i++)
                {
                    pagerSetting.PagerDesc.Add(new PageDesc(i, true));

                }
            }
        }

    }
}
