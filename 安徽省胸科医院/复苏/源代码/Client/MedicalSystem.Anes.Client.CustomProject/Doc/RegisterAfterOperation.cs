using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.Document.Documents;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.CustomProject
{
    public partial class RegisterAfterOperation : CustomBaseDoc
    {
        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();


        MTextBox txtInRoomTime = null;
        MTextBox txtOutRoomTime = null;
        MTextBox txtOperStart = null;
        MTextBox txtOperEnd = null;
        public RegisterAfterOperation()
        {
            InitializeComponent();
            base.DocKind = DocKind.Default;
        }
        protected override void BuildData(Dictionary<string, DataTable> dataSource)
        {

            dataSource["MED_OPERATION_MASTER"] = DataContext.GetCurrent().GetData("MED_OPERATION_MASTER");
            dataSource["MED_PAT_MASTER_INDEX"] = DataContext.GetCurrent().GetData("MED_PAT_MASTER_INDEX");
            dataSource["MED_PAT_VISIT"] = DataContext.GetCurrent().GetData("MED_PAT_VISIT");
            dataSource["MED_OPERATION_EXTENDED"] = DataContext.GetCurrent().GetData("MED_OPERATION_EXTENDED");

        }
        protected override void OnSaveData(Dictionary<string, DataTable> dataSource)
        {
            base.OnSaveData(dataSource);
            List<MED_OPERATION_MASTER> operationMasterDataTable = ModelHelper<MED_OPERATION_MASTER>.ConvertDataTableToList(dataSource["MED_OPERATION_MASTER"]);
            MED_OPERATION_MASTER masterRow = operationMasterDataTable.Count > 0 ? operationMasterDataTable[0] : null;
            if (txtOutRoomTime.Text != "" && masterRow != null)
            {
                if (!string.IsNullOrEmpty(masterRow.OPER_STATUS_CODE.ToString()) || masterRow.OPER_STATUS_CODE < (int)OperationStatus.OutOperationRoom)
                {
                    masterRow.ANES_START_TIME = masterRow.START_DATE_TIME;
                    masterRow.ANES_END_TIME = masterRow.END_DATE_TIME;
                    masterRow.OPER_STATUS_CODE = (int)OperationStatus.OutOperationRoom;
                    ExtendApplicationContext.Current.PatientInformationExtend.IN_DATE_TIME = masterRow.IN_DATE_TIME;
                    ExtendApplicationContext.Current.PatientInformationExtend.OUT_DATE_TIME = masterRow.OUT_DATE_TIME;
                    ExtendApplicationContext.Current.PatientInformationExtend.START_DATE_TIME = masterRow.START_DATE_TIME;
                    ExtendApplicationContext.Current.PatientInformationExtend.END_DATE_TIME = masterRow.END_DATE_TIME;
                    ExtendApplicationContext.Current.PatientInformationExtend.OPER_STATUS_CODE = masterRow.OPER_STATUS_CODE;
                    ExtendApplicationContext.Current.OperationStatus = OperationStatus.OutOperationRoom;
                }
            }
            ExtendApplicationContext.Current.PatientInformationExtend.OPER_ROOM_NO = masterRow.OPER_ROOM_NO;
            MED_OPERATION_MASTER operMaster = null;
            if (operationMasterDataTable != null && operationMasterDataTable.Count > 0)
                operMaster = operationMasterDataTable[0];

            List<MED_PAT_MASTER_INDEX> patIndexList = ModelHelper<MED_PAT_MASTER_INDEX>.ConvertDataTableToList(dataSource["MED_PAT_MASTER_INDEX"]);
            MED_PAT_MASTER_INDEX patMasterIndex = null;
            if (patIndexList != null && patIndexList.Count > 0)
                patMasterIndex = patIndexList[0];

            List<MED_PAT_VISIT> patVisitList = ModelHelper<MED_PAT_VISIT>.ConvertDataTableToList(dataSource["MED_PAT_VISIT"]);
            MED_PAT_VISIT patVisit = null;
            if (patVisitList != null && patVisitList.Count > 0)
                patVisit = patVisitList[0];

            List<MED_OPERATION_EXTENDED> operExtended = ModelHelper<MED_OPERATION_EXTENDED>.ConvertDataTableToList(dataSource["MED_OPERATION_EXTENDED"]);

            //OperationInfoService.SaveMedicalBasicDoc(operMaster, patIndex, patVisit, null, null, null, null, operExtended, null, null);

            MED_PATS_IN_HOSPITAL patsInHospital = null;

            MED_ANESTHESIA_PLAN anesPlan = null;

            MED_ANESTHESIA_PLAN_EXAM anesPlanExam = null;

            MED_ANESTHESIA_PLAN_PMH anesPlanPmh = null;

            List<MED_POSTOPERATIVE_EXTENDED> postExtended = null;

            List<MED_PREOPERATIVE_EXPANSION> preExpansion = null;


            operationInfoRepository.SaveMedicalBasicDoc(new { operMaster, patMasterIndex, patVisit, patsInHospital, anesPlan, anesPlanExam, anesPlanPmh, operExtended, postExtended, preExpansion });

        }

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
                                MessageBoxFormPC.Show(textbox.InputNeededMessage);
                                return false;
                            }
                        }
                    }
                    foreach (Control ctl in handler.GetAllControls)
                    {
                        if (ctl is MTextBox)
                        {
                            if (ctl.Name == "txtInRoomTime")
                            {
                                txtInRoomTime = ctl as MTextBox;
                            }
                            else if (ctl.Name == "txtOutRoomTime")
                            {
                                txtOutRoomTime = ctl as MTextBox;
                            }
                            else if (ctl.Name == "txtOperStart")
                            {
                                txtOperStart = ctl as MTextBox;
                            }
                            else if (ctl.Name == "txtOperEnd")
                            {
                                txtOperEnd = ctl as MTextBox;
                            }
                        }
                    }
                    bl = checkTime();
                }
            }
            return bl;
        }

        private bool checkTime()
        {
            if (txtInRoomTime != null && txtOperStart != null && txtOperEnd != null && txtOutRoomTime != null)
            {
                if (txtInRoomTime.Text != "" && txtOperStart.Text != "" && DateTime.Parse(txtOperStart.Text) < DateTime.Parse(txtInRoomTime.Text))
                {
                    MessageBoxFormPC.Show("手术开始时间不可早于入室时间");
                    return false;
                }
                else if (txtOperEnd.Text != "" && txtOperStart.Text != "" && DateTime.Parse(txtOperEnd.Text) < DateTime.Parse(txtOperStart.Text))
                {
                    MessageBoxFormPC.Show("手术结束时间不可早于手术开始时间");
                    return false;
                }
                else if (txtOutRoomTime.Text != "" && txtOperEnd.Text != "" && DateTime.Parse(txtOutRoomTime.Text) < DateTime.Parse(txtOperEnd.Text))
                {
                    MessageBoxFormPC.Show("出室时间不可早于手术结束时间");
                    return false;
                }
            }
            return true;
        }
    }
}
