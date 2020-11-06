using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Document.Views;
using Medicalsystem.Anes.Framework.Utilities;
using MedicalSystem.Anes.Client.AppPC.Properties;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class ConfirmationSureBase : BaseView
    {

        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        AccountRepository accountRepository = new AccountRepository();

        ComnDictRepository comnDictRepository = new ComnDictRepository();

        OperatingRoomRepository operatingRoomRepository = new OperatingRoomRepository();

        PatientInfoRepository patientInfoRepository = new PatientInfoRepository();

        SyncInfoRepository syncInfoRepository = new SyncInfoRepository();

        private int _selectLbl = 1;
        private MED_PATIENT_CARD _patientCard;
        private decimal _eventNo;
        string _patientID = string.Empty;
        int _visitID = 0;
        int _operID = 0;
        SelectMonitor monitor = null;
        private MED_PAT_MASTER_INDEX patMasterIndex = null;
        private MED_OPERATION_MASTER operationMaster = null;
        private MED_PAT_VISIT patVisit = null;
        private MED_ANESTHESIA_PLAN anesPlan = null;
        public DialogResult result = DialogResult.Cancel;
        public DateTime SelectDateTime = new AccountRepository().GetServerTime().Data;
        public ConfirmationSureBase()
        {
            InitializeComponent();
            this.label1.BackColor = Color.FromArgb(0, Color.Transparent);
            this.label2.BackColor = Color.FromArgb(0, Color.Transparent);

        }
        public ConfirmationSureBase(MED_PATIENT_CARD patientCard, decimal eventNo)
            : this()
        {
            _eventNo = ApplicationConfiguration.IsPACUProgram ? 1 : 0;
            if (patientCard == null)
            {
                panelEmergency.Visible = true;
                panel1.Visible = false;
                label1.Text = "急诊登记信息确认";
                btnUp.Visible = false;
                btnNext.Title = "确认";
                return;
            }
            else
                panelEmergency.Visible = false;
            _patientCard = patientCard;
            _patientID = patientCard.PATIENT_ID;
            _visitID = patientCard.VISIT_ID;
            _operID = patientCard.OPER_ID;
            LoadPatientInfo();
        }
        private void stepSelectIndex(bool isNext)
        {
            btnUp.Visible = true;
            btnNext.Visible = true;
            switch (_selectLbl)
            {
                case 1:
                    btnUp.Visible = false;
                    panelInfo.Visible = true;
                    panelMonitorSelect.Visible = false;
                    panelInTimeControl.Visible = false;
                    panelSure.Visible = false;
                    label1.Image = Resources.进程1_2;
                    label2.Image = Resources.进程2_4;
                    label3.Image = Resources.进程2_4;
                    label4.Image = Resources.进程2_0;
                    break;
                case 2:
                    panelInfo.Visible = false;
                    panelMonitorSelect.Visible = true;
                    panelInTimeControl.Visible = false;
                    panelSure.Visible = false;
                    LoadMonitorInfo();
                    label1.Image = Resources.进程1_3;
                    label2.Image = Resources.进程2_1;
                    label3.Image = Resources.进程2_4;
                    label4.Image = Resources.进程2_0;
                    break;
                case 3:
                    panelInfo.Visible = false;
                    panelMonitorSelect.Visible = false;
                    panelInTimeControl.Visible = true;
                    panelSure.Visible = false;
                    label1.Image = Resources.进程1_3;
                    label2.Image = Resources.进程2_2;
                    label3.Image = Resources.进程2_1;
                    label4.Image = Resources.进程2_0;
                    break;
                case 4:
                    panelInfo.Visible = false;
                    panelMonitorSelect.Visible = false;
                    panelInTimeControl.Visible = false;
                    panelSure.Visible = true;
                    btnNext.Title = "确认";
                    label1.Image = Resources.进程1_3;
                    label2.Image = Resources.进程2_2;
                    label3.Image = Resources.进程2_2;
                    label4.Image = Resources.进程2_3;
                    break;
                default:
                    break;
            }
        }
        private bool InRoom(DateTime inTime)
        {
            string roomNo = ExtendApplicationContext.Current.OperRoomNo;
            SelectDateTime = inTime;
            if (!string.IsNullOrEmpty(roomNo) && inTime != DateTime.MaxValue && inTime != DateTime.MinValue)
            {
                List<MED_OPERATING_ROOM> operatingRoomList = comnDictRepository.GetOperatingRoomList("0").Data;

                MED_OPERATION_MASTER operMaster = operationInfoRepository.GetOperMaster(ExtendApplicationContext.Current.PatientContextExtend.PatientID,
                    ExtendApplicationContext.Current.PatientContextExtend.VisitID,
                    ExtendApplicationContext.Current.PatientContextExtend.OperID).Data;
                if (string.IsNullOrEmpty(roomNo))
                {
                    return false;
                }
                bool isUpdate = operatingRoomRepository.SetOperatingRoomPatient(operatingRoomList, roomNo, ExtendApplicationContext.Current.OperRoom, _patientID, _visitID, _operID);
                if (isUpdate)
                {
                    operatingRoomRepository.SetOperMaster(_patientID, _visitID, _operID, "IN_DATE_TIME", inTime, 5);

                    // CommDictService.SaveOperatingRommList(operatingRoomList);
                    operatingRoomRepository.SetMonitorDictPatient("0", ExtendApplicationContext.Current.OperRoom, roomNo, _patientID, _visitID, _operID);

                    _patientCard.OPER_STATUS_CODE = 5;
                    _patientCard.IN_DATE_TIME = inTime;
                    ExtendApplicationContext.Current.PatientInformationExtend = _patientCard;
                    ExtendApplicationContext.Current.PatientContextExtend.PatientID = _patientID;
                    ExtendApplicationContext.Current.PatientContextExtend.VisitID = _visitID;
                    ExtendApplicationContext.Current.PatientContextExtend.OperID = _operID;
                }
                return isUpdate;

            }
            else
                return false;

            return true;
        }
        private void LoadPatientInfo()
        {
            if (_patientCard != null)
            {
                txtName.Text = _patientCard.NAME;
                txtSex.Text = _patientCard.SEX;
                txtAge.Text = string.IsNullOrEmpty(_patientCard.AGE) ? DateDiff.CalAge(_patientCard.DATE_OF_BIRTH.Value, accountRepository.GetServerTime().Data) : _patientCard.AGE;
                txtInpNo.Text = _patientCard.INP_NO;
                txtBedNo.Text = _patientCard.BED_NO;

                txtDeptName.Text = RefreshDeptCode(_patientCard.DEPT_CODE);
                txtDiagBeforeOperation.Text = _patientCard.DIAG_BEFORE_OPERATION;
                txtOperNamePlan.Text = _patientCard.OPERATION_NAME;
                txtOperScale.Text = _patientCard.OPER_SCALE;
                txtOperPosition.Text = _patientCard.OPER_POSITION;
                if (_patientCard.EMERGENCY_IND == 1 || panelEmergency.Visible) radioGroupEmergency.SelectedIndex = 0;
                else radioGroupEmergency.SelectedIndex = 1;
                memoCondition.Text = _patientCard.PATIENT_CONDITION;
                txtFirstOperDoctor.Text = RefreshHisUsers(_patientCard.SURGEON);
                txtSecondOperDoctor.Text = RefreshHisUsers(_patientCard.FIRST_OPER_ASSISTANT);
                txtThirdOperDoctor.Text = RefreshHisUsers(_patientCard.SECOND_OPER_ASSISTANT);
                txtFourthOperDoctor.Text = RefreshHisUsers(_patientCard.THIRD_OPER_ASSISTANT);
                txtCPDDoctor.Text = RefreshHisUsers(_patientCard.CPB_DOCTOR);
                txtSecondCPDDoctor.Text = RefreshHisUsers(_patientCard.SECOND_CPB_ASSISTANT);
                txtFirstOperNurse.Text = RefreshHisUsers(_patientCard.FIRST_OPER_NURSE);
                txtSecondOperNurse.Text = RefreshHisUsers(_patientCard.SECOND_OPER_NURSE);
                txtFirstSupplyNurse.Text = RefreshHisUsers(_patientCard.FIRST_SUPPLY_NURSE);
                txtSecondSupplyNurse.Text = RefreshHisUsers(_patientCard.SECOND_SUPPLY_NURSE);
                txtAnesMethod.Text = _patientCard.ANAESTHESIA_TYPE;
                txtAnesMethod.Text = _patientCard.ANES_METHOD;
                txtAnesDoctor.Text = RefreshHisUsers(_patientCard.ANES_DOCTOR);
                txtSecondAnesDoctor.Text = RefreshHisUsers(_patientCard.SECOND_ANES_ASSISTANT);
                txtThirdAnesDoctor.Text = RefreshHisUsers(_patientCard.THIRD_ANES_ASSISTANT);
                txtFourthAnesDoctor.Text = RefreshHisUsers(_patientCard.FOURTH_ANES_ASSISTANT);
                txtASAGrade.Text = _patientCard.ASA_GRADE;
                txtWoundType.Text = _patientCard.WOUND_TYPE;
                if (_patientCard.EMERGENCY_IND == 1)
                    pictureBoxJZ.Visible = true;
                if (_patientCard.ISOLATION_IND == 2)
                    pictureBoxGL.Visible = true;
                if (_patientCard.RADIATE_IND == 2)
                    pictureBoxFS.Visible = true;

            }
        }
        private bool SavePatientInfo()
        {
            operationMaster.SetValue("OPER_ROOM_NO", lblRoomNo.Text);
            operationMaster.SetValue("SEQUENCE", lblSequence.Text);
            if (this.txtDeptName.Data != null) operationMaster.SetValue("DEPT_CODE", this.txtDeptName.Data);
            operationMaster.SetValue("DIAG_BEFORE_OPERATION", this.txtDiagBeforeOperation.Text.Trim());
            if (txtOperNamePlan.Data != null) anesPlan.OPERATION_NAME = txtOperNamePlan.Data.ToString();
            operationMaster.SetValue("OPER_SCALE", this.txtOperScale.Text.Trim());
            operationMaster.SetValue("OPER_POSITION", this.txtOperPosition.Text.Trim());
            switch (radioGroupEmergency.SelectedIndex)
            {
                case 0:
                    operationMaster.EMERGENCY_IND = 1;
                    break;
                default:
                    operationMaster.EMERGENCY_IND = 0;
                    break;
            }
            operationMaster.PATIENT_CONDITION = memoCondition.Text;
            if (txtFirstOperDoctor.Data != null) operationMaster.SetValue("SURGEON", this.txtFirstOperDoctor.Data);
            if (txtSecondOperDoctor.Data != null) operationMaster.SetValue("FIRST_OPER_ASSISTANT", this.txtSecondOperDoctor.Data);
            if (txtThirdOperDoctor.Data != null) operationMaster.SetValue("SECOND_OPER_ASSISTANT", this.txtThirdOperDoctor.Data);
            if (txtFourthOperDoctor.Data != null) operationMaster.SetValue("THIRD_OPER_ASSISTANT", this.txtFourthOperDoctor.Data);
            if (txtCPDDoctor.Data != null) operationMaster.SetValue("CPB_DOCTOR", this.txtCPDDoctor.Data);
            if (txtSecondCPDDoctor.Data != null) operationMaster.SetValue("FIRST_CPB_ASSISTANT", this.txtSecondCPDDoctor.Data);
            if (txtFirstOperNurse.Data != null) operationMaster.SetValue("FIRST_OPER_NURSE", this.txtFirstOperNurse.Data);
            if (txtSecondOperNurse.Data != null) operationMaster.SetValue("SECOND_OPER_NURSE", this.txtSecondOperNurse.Data);
            if (txtFirstSupplyNurse.Data != null) operationMaster.SetValue("FIRST_SUPPLY_NURSE", this.txtFirstSupplyNurse.Data);
            if (txtSecondSupplyNurse.Data != null) operationMaster.SetValue("SECOND_SUPPLY_NURSE", this.txtSecondSupplyNurse.Data);
            operationMaster.ANAESTHESIA_TYPE = txtAnesType.Text;
            operationMaster.SetValue("ANES_METHOD", this.txtAnesMethod.Text);
            if (txtAnesDoctor.Data != null) operationMaster.SetValue("ANES_DOCTOR", this.txtAnesDoctor.Data);
            if (txtSecondAnesDoctor.Data != null) operationMaster.SetValue("FIRST_ANES_ASSISTANT", this.txtSecondAnesDoctor.Data);
            if (txtThirdAnesDoctor.Data != null) operationMaster.SetValue("SECOND_ANES_ASSISTANT", this.txtThirdAnesDoctor.Data);
            if (txtFourthAnesDoctor.Data != null) operationMaster.SetValue("THIRD_ANES_ASSISTANT", this.txtFourthAnesDoctor.Data);
            operationMaster.SetValue("ASA_GRADE", this.txtASAGrade.Text);
            operationMaster.SetValue("WOUND_TYPE", this.txtWoundType.Text);
            switch (radioGroupReturn.SelectedIndex)
            {
                case 0:
                    anesPlan.RETURN_TO_SURGERY = "1";
                    break;
                default:
                    anesPlan.RETURN_TO_SURGERY = "0";
                    break;
            }
            switch (radioGroupReturn.SelectedIndex)
            {
                case 0:
                    anesPlan.PLAN_WHEREABORTS = "65";
                    break;
                case 1:
                    anesPlan.PLAN_WHEREABORTS = "40";
                    break;
                case 2:
                    anesPlan.PLAN_WHEREABORTS = "60";
                    break;
                case 3:
                    anesPlan.PLAN_WHEREABORTS = "66";
                    break;
                case 4:
                    anesPlan.PLAN_WHEREABORTS = "67";
                    break;
                default:
                    anesPlan.PLAN_WHEREABORTS = "无计划";
                    break;
            }
            return operationInfoRepository.SavePatientOperation(new { patVisit, patMasterIndex, operationMaster, anesPlan }).Data;
            if (panelEmergency.Visible)
            {
                ExtendApplicationContext.Current.PatientInformationExtend = _patientCard;
                ExtendApplicationContext.Current.PatientContextExtend.PatientID = operationMaster.PATIENT_ID;
                ExtendApplicationContext.Current.PatientContextExtend.VisitID = operationMaster.VISIT_ID;
                ExtendApplicationContext.Current.PatientContextExtend.OperID = operationMaster.OPER_ID;
            }

        }
        private void LoadMonitorInfo()
        {
            panelMonitorSelect.Controls.Clear();
            monitor = new SelectMonitor(_patientCard, 0, ExtendApplicationContext.Current.OperRoomNo, false);
            panelMonitorSelect.Controls.Add(monitor);
            monitor.Dock = DockStyle.Top;
        }

        private string RefreshHisUsers(string userID)
        {
            string userName = userID;
            foreach (MED_HIS_USERS user in ExtendApplicationContext.Current.CommDict.HisUsersDict)
            {
                if (user.USER_JOB_ID == userID)
                {
                    userName = user.USER_NAME; break;
                }
            }
            return userName;
        }
        private string RefreshDeptCode(string deptID)
        {
            string userName = deptID;
            foreach (MED_DEPT_DICT user in ExtendApplicationContext.Current.CommDict.DeptDict)
            {
                if (user.DEPT_CODE == deptID)
                {
                    userName = user.DEPT_NAME; break;
                }
            }
            return userName;
        }
        private void ConfirmationSureBase_Load(object sender, EventArgs e)
        {
            timeControl.DateTimes = accountRepository.GetServerTime().Data;
            lblRoomNo.Text = ExtendApplicationContext.Current.OperRoomNo;
            DateTime currentTime = accountRepository.GetServerTime().Data;
            string timeFormat = ExtendApplicationContext.Current.FirstFounding;
            currentTime = Convert.ToDateTime(currentTime.ToString("yyyy-MM-dd 08:00"));
            DateTime currentTimeEnd = currentTime.AddDays(1).AddMinutes(-1);
            List<MED_PATIENT_CARD> patientLists = patientInfoRepository.GetPatientListByDate(currentTime, currentTimeEnd, 
                ExtendApplicationContext.Current.OperRoomNo, ExtendApplicationContext.Current.OperRoom, 
                ExtendApplicationContext.Current.HospBranchCode).Data;

            if (patientLists != null && patientLists.Count > 0)
            {
                patientLists = patientLists.Where(p => p.OPER_ROOM_NO == ExtendApplicationContext.Current.OperRoomNo).ToList();
                lblSequence.Text = (patientLists != null && patientLists.Count > 0) ? (patientLists.Count + 1).ToString() : "1";
            }
            else
            {
                lblSequence.Text = "1";
            }
            if (!string.IsNullOrEmpty(_patientID))
            {
                LoadPatientID();
            }
            if (!panelEmergency.Visible)
                stepSelectIndex(false);
        }
        private void LoadPatientID()
        {
            ExtendApplicationContext.Current.MED_PAT_MASTER_INDEX = operationInfoRepository.GetPatMasterIndex(_patientID).Data;

            ExtendApplicationContext.Current.MED_OPERATION_MASTER
                  = operationInfoRepository.GetOperMaster(_patientID, _visitID, _operID).Data;

            if (ExtendApplicationContext.Current.MED_OPERATION_MASTER == null)
            {
                ExtendApplicationContext.Current.MED_OPERATION_MASTER = new MED_OPERATION_MASTER();
                ExtendApplicationContext.Current.MED_OPERATION_MASTER.PATIENT_ID = _patientID;
                ExtendApplicationContext.Current.MED_OPERATION_MASTER.VISIT_ID = _visitID;
                ExtendApplicationContext.Current.MED_OPERATION_MASTER.OPER_ID = _operID;
                ExtendApplicationContext.Current.MED_OPERATION_MASTER.OPER_ROOM = ExtendApplicationContext.Current.OperRoom;
                ExtendApplicationContext.Current.MED_OPERATION_MASTER.HOSP_BRANCH = ExtendApplicationContext.Current.HospBranchCode;
            }
            ExtendApplicationContext.Current.MED_PAT_VISIT
                   = operationInfoRepository.GetPatVisit(_patientID, _visitID).Data;

            if (ExtendApplicationContext.Current.MED_PAT_VISIT == null)
            {
                ExtendApplicationContext.Current.MED_PAT_VISIT = new MED_PAT_VISIT() { PATIENT_ID = _patientID, VISIT_ID = _visitID, INP_NO = ExtendApplicationContext.Current.PatientInformationExtend.INP_NO };
            }
            patMasterIndex = ExtendApplicationContext.Current.MED_PAT_MASTER_INDEX;
            operationMaster = ExtendApplicationContext.Current.MED_OPERATION_MASTER;
            operationMaster.HOSP_BRANCH = _patientCard.HOSP_BRANCH;
            operationMaster.WARD_CODE = _patientCard.WARD_CODE;
            operationMaster.DEPT_CODE = _patientCard.DEPT_CODE;
            operationMaster.OPER_DEPT_CODE = _patientCard.OPER_DEPT_CODE;
            operationMaster.SCHEDULED_DATE_TIME = accountRepository.GetServerTime().Data;
            patVisit = ExtendApplicationContext.Current.MED_PAT_VISIT;
            anesPlan = new DocDataRepository().GetAnesthesiaPlan(_patientID, _visitID, _operID);
        }
        private void SyncPatientByPatientId(string patientID)
        {
            if (!string.IsNullOrEmpty(patientID))
            {
                if (ExtendApplicationContext.Current.IsSync)
                {
                    string ret = "";

                    ret = syncInfoRepository.SyncPatientInfoAndInHospital(patientID).Data;

                    ret += syncInfoRepository.SyncScheduleInfo(patientID, accountRepository.GetServerTime().Data).Data;

                    if (!string.IsNullOrEmpty(ret))
                    {
                        MessageBoxFormPC.Show(ret);
                    }
                }
            }
            bool flag = true;
            if (patientID != "")
            {
                patMasterIndex = operationInfoRepository.GetPatMasterIndex(patientID).Data;

                MED_PATS_IN_HOSPITAL patsInHospital = null;
                if (patMasterIndex == null)
                {
                    patsInHospital = operationInfoRepository.GetPatsInHospital(patientID).Data;
                    if (patsInHospital != null)
                    {
                        patientID = patsInHospital.PATIENT_ID;
                        patMasterIndex = operationInfoRepository.GetPatMasterIndex(patientID).Data;
                    }
                }
                List<MED_PAT_VISIT> patVisitList = operationInfoRepository.GetPatVisitList(patientID).Data;

                if (patVisitList != null && patVisitList.Count > 0)
                {
                    flag = flag & false;
                    patVisit = patVisitList[0];
                    _visitID = Convert.ToInt32(patVisitList[0].GetValue("VISIT_ID"));
                }
                else
                {
                    flag = flag & true;
                    patVisit = new MED_PAT_VISIT();
                    _visitID = 1;
                    patVisit.SetValue("PATIENT_ID", patientID);
                }
                if (patMasterIndex == null)
                {
                    flag = flag & true;
                    patMasterIndex = new MED_PAT_MASTER_INDEX();
                    patMasterIndex.SetValue("PATIENT_ID", patientID);
                    MessageBoxFormPC.Show("当前输入患者ID，需要手动输入患者信息进行急诊登记", "系统提示");
                    // return;
                }
                List<MED_OPERATION_MASTER> operMasterList = operationInfoRepository.GetOperMasterList(patientID, _visitID).Data;
                if (operMasterList != null && operMasterList.Count > 0)
                {
                    _operID = Convert.ToInt32(operMasterList[0].GetValue("OPER_ID")) + 1;
                }
                operationMaster = new MED_OPERATION_MASTER();
                operationMaster.PATIENT_ID = patientID;
                operationMaster.VISIT_ID = _visitID;
                operationMaster.OPER_ID = _operID;
                operationMaster.OPER_ROOM = ExtendApplicationContext.Current.OperRoom;
                operationMaster.OPER_ROOM_NO = ExtendApplicationContext.Current.OperRoomNo;
                operationMaster.HOSP_BRANCH = ExtendApplicationContext.Current.HospBranchCode;
                operationMaster.SCHEDULED_DATE_TIME = accountRepository.GetServerTime().Data;
                if (patsInHospital != null)
                {
                    patVisit.INP_NO = patsInHospital.INP_NO;
                    operationMaster.WARD_CODE = patsInHospital.WARD_CODE;
                    operationMaster.DEPT_CODE = patsInHospital.WARD_CODE;
                    operationMaster.BED_NO = patsInHospital.BED_NO;
                }
                else
                {
                    patsInHospital = operationInfoRepository.GetPatsInHospitalByID(patientID, _visitID).Data;

                    patVisit.INP_NO = patsInHospital.INP_NO;
                    operationMaster.WARD_CODE = patsInHospital.WARD_CODE;
                    operationMaster.DEPT_CODE = patsInHospital.WARD_CODE;
                    operationMaster.BED_NO = patsInHospital.BED_NO;
                }
                ExtendApplicationContext.Current.MED_PAT_MASTER_INDEX = patMasterIndex;
                ExtendApplicationContext.Current.MED_OPERATION_MASTER
                      = operationMaster;
                ExtendApplicationContext.Current.MED_PAT_VISIT
                       = patVisit;
                anesPlan = new DocDataRepository().GetAnesthesiaPlan(_patientID, _visitID, _operID);

                _patientCard = new MED_PATIENT_CARD();
                foreach (string column in _patientCard.GetPropsName())
                {
                    foreach (string col in patMasterIndex.GetPropsName())
                    {
                        if (column == col)
                        {
                            _patientCard.SetValue(column, patMasterIndex.GetValue(col));
                        }
                    }
                    foreach (string col in operationMaster.GetPropsName())
                    {
                        if (column == col)
                        {
                            _patientCard.SetValue(column, operationMaster.GetValue(col));
                        }
                    }
                    foreach (string col in patVisit.GetPropsName())
                    {
                        if (column == col)
                        {
                            _patientCard.SetValue(column, patVisit.GetValue(col));
                        }
                    }
                }
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            _selectLbl--;
            if (!panelEmergency.Visible)
                stepSelectIndex(false);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _selectLbl++;
            if (!panelEmergency.Visible)
                stepSelectIndex(true);
            if (btnNext.Title.Equals("确认"))
            {
                if (operationMaster != null)
                {
                    if (SavePatientInfo())
                    {
                        if (!panelEmergency.Visible)
                        {
                            if (InRoom(timeControl.DateTimes))
                            {
                                monitor.Save();
                            }
                        }
                        result = DialogResult.OK;
                        ParentForm.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    MessageBoxFormPC.Show("录入信息不完整，请重新核查！");
                }
            }
        }

        private void btnCannel_BtnClicked(object sender, EventArgs e)
        {
            ParentForm.DialogResult = DialogResult.Cancel;
        }

        private void searchTextBox1_BtnClicked(object sender, string var)
        {
            if (!string.IsNullOrEmpty(var))
            {
                _patientID = var;
                List<MED_PATIENT_CARD> _patientCardList = patientInfoRepository.GetPatientListDataTableByPatientID(
                            _patientID, ExtendApplicationContext.Current.OperRoom, 
                            ExtendApplicationContext.Current.HospBranchCode).Data;
                if (_patientCardList != null && _patientCardList.Count > 0)
                {
                    _patientCardList.ForEach(row =>
                    {
                        if (row.OPER_ID > _operID) _operID = row.OPER_ID;
                    });
                    PatientInfoSureControl sure = new PatientInfoSureControl(_patientCardList);
                    DialogHostFormPC dialogHostForm = new DialogHostFormPC("病人信息选择", sure.Width, sure.Height);
                    dialogHostForm.Text = "病人信息选择";
                    dialogHostForm.Child = sure;
                    dialogHostForm.ShowDialog();
                    if (sure.result == DialogResult.OK)
                    {
                        _patientCard = sure.SelectPatientCard;
                        _patientID = _patientCard.PATIENT_ID;
                        _visitID = _patientCard.VISIT_ID;
                        _operID = _operID + 1;
                        LoadPatientID();
                    }
                }
                else
                {
                    SyncPatientByPatientId(_patientID);
                }
                LoadPatientInfo();
            }
        }

    }
}
