using System;
using System.Collections.Generic;
using System.Data;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Utilities;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.CustomProject
{
    public partial class OperationInformation : CustomBaseDoc
    {
        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();


        public OperationInformation()
        {
            InitializeComponent();
            base.PrintButton.Visible = false;
            base.DocKind = DocKind.Default;
            base.HideScrollBar();
        }
        bool isRoomnoORSequenceChanged = false;

        private void ctl_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((sender as MTextBox).Text))
                isRoomnoORSequenceChanged = true;
        }

        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {
            dataSource["MED_OPERATION_MASTER"] = DataContext.GetCurrent().GetData("MED_OPERATION_MASTER"); ;
            dataSource["MED_PAT_MASTER_INDEX"] = DataContext.GetCurrent().GetData("MED_PAT_MASTER_INDEX");
            dataSource["MED_PAT_VISIT"] = DataContext.GetCurrent().GetData("MED_PAT_VISIT");
            dataSource["MED_ANESTHESIA_PLAN"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN");
            dataSource["MED_ANESTHESIA_PLAN_PMH"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN_PMH");
            dataSource["MED_ANESTHESIA_PLAN_EXAM"] = DataContext.GetCurrent().GetData("MED_ANESTHESIA_PLAN_EXAM");
        }
        protected override void OnSaveData(Dictionary<string, DataTable> dataSource)
        {
            if (isRoomnoORSequenceChanged) Dialog.MessageBox("温馨提示：修改手术间号和台次将会影响当前已安排手术，请结合实际情况修改。");
            base.OnSaveData(dataSource);
            List<MED_OPERATION_MASTER> operMasterList = ModelHelper<MED_OPERATION_MASTER>.ConvertDataTableToList(dataSource["MED_OPERATION_MASTER"]);
            MED_OPERATION_MASTER operationMaster = null;
            if (operMasterList != null && operMasterList.Count > 0)
                operationMaster = operMasterList[0];

            List<MED_PAT_MASTER_INDEX> patIndexList = ModelHelper<MED_PAT_MASTER_INDEX>.ConvertDataTableToList(dataSource["MED_PAT_MASTER_INDEX"]);
            MED_PAT_MASTER_INDEX patMasterIndex = null;
            if (patIndexList != null && patIndexList.Count > 0)
                patMasterIndex = patIndexList[0];

            //OperationInfoService.SaveMedicalBasicDoc(operationMaster, patIndex, null, null, null, null, null, null, null, null);


            MED_PATS_IN_HOSPITAL patsInHospital = null;

            MED_ANESTHESIA_PLAN anesPlan = null;

            MED_ANESTHESIA_PLAN_EXAM anesPlanExam = null;

            MED_ANESTHESIA_PLAN_PMH anesPlanPmh = null;

            List<MED_OPERATION_EXTENDED> operExtended = null;

            List<MED_POSTOPERATIVE_EXTENDED> postExtended = null;

            List<MED_PREOPERATIVE_EXPANSION> preExpansion = null;

            MED_PAT_VISIT patVisit = null;

            operationInfoRepository.SaveMedicalBasicDoc(new { operationMaster, patMasterIndex, patVisit, patsInHospital, anesPlan, anesPlanExam, anesPlanPmh, operExtended, postExtended, preExpansion });



            if (ExtendApplicationContext.Current.PatientInformationExtend.OPER_ROOM_NO != operationMaster.OPER_ROOM_NO)
            {
                ExtendApplicationContext.Current.PatientInformationExtend.OPER_ROOM_NO = operationMaster.OPER_ROOM_NO;
            }
            if (operationMaster.SEQUENCE.HasValue && ExtendApplicationContext.Current.PatientInformationExtend.SEQUENCE != operationMaster.SEQUENCE)
            {
                ExtendApplicationContext.Current.PatientInformationExtend.SEQUENCE = operationMaster.SEQUENCE;
            }
            //台次
            if (operationMaster.EMERGENCY_IND.HasValue && ExtendApplicationContext.Current.PatientInformationExtend.EMERGENCY_IND != operationMaster.EMERGENCY_IND)
            {
                ExtendApplicationContext.Current.PatientInformationExtend.EMERGENCY_IND = operationMaster.EMERGENCY_IND;
            }
            if (operationMaster.ISOLATION_IND.HasValue && ExtendApplicationContext.Current.PatientInformationExtend.ISOLATION_IND != operationMaster.EMERGENCY_IND)
            {
                ExtendApplicationContext.Current.PatientInformationExtend.ISOLATION_IND = operationMaster.ISOLATION_IND;
            }
        }
    }
}
