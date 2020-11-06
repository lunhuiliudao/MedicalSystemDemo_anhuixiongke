using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Client.Repository;
using MedicalSystem.Services;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class ConfirmationInPacu : BaseView
    {
        AccountRepository accountRepository = new AccountRepository();

        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        PatientInfoRepository patientInfoRepository = new PatientInfoRepository();


        string _patientID = string.Empty;
        int _visitID = 0;
        int _operID = 0;
        MED_PATIENT_CARD _patientCard;
        SelectMonitor monitor = null;
        MED_CONFIRMATION_PACU confirmationPACU = null;
        bool _isSelectMark;
        public DialogResult result = DialogResult.Cancel;
        public string PacuRoom = string.Empty;
        public DateTime SelectDateTime = new AccountRepository().GetServerTime().Data;
        public ConfirmationInPacu()
        {
            InitializeComponent();
            ContextMenu emptyMenu = new System.Windows.Forms.ContextMenu();
            txtPacuNo.Properties.ContextMenu = emptyMenu;
        }
        public ConfirmationInPacu(string patientID, int visitID, int operID, bool isSelectMark)
            : this()
        {
            _patientID = patientID;
            _visitID = visitID;
            _operID = operID;
            txtInPacuTime.EditValue = SelectDateTime;
            lblSecond.Visible = !isSelectMark;
            if (isSelectMark) btnNext.Title = "确认";
            _isSelectMark = isSelectMark;
            PatientInfoLoad();
        }
        private void PatientInfoLoad()
        {
            _patientCard = patientInfoRepository.GetPatCard(_patientID, _visitID, _operID).Data;
            if (_patientCard != null)
            {
                PanelMMonitor.Controls.Clear();
                monitor = new SelectMonitor(_patientCard, 1, "", false);
                PanelMMonitor.Controls.Add(monitor);
                monitor.Dock = DockStyle.Fill;
                dateEditOutDateTime.DateTime = _patientCard.OUT_DATE_TIME.Value;
                lblRoomNo.Text = _patientCard.OPER_ROOM_NO;
                lblSequence.Text = _patientCard.SEQUENCE.ToString();
                patName.Text = _patientCard.NAME;
                patSex.Text = _patientCard.SEX;
                patAge.Text = _patientCard.AGE;
                patInpNo.Text = _patientCard.INP_NO;
                patBedNo.Text = _patientCard.BED_NO;
            }
        }
        private string RefareshHisUsers(string userID)
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
        private string RefareshDeptCode(string deptID)
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

        private bool InPacuRoom()
        {
            PacuRoom = txtPacuNo.Text;
            DateTime inPacuTime = Convert.ToDateTime(txtInPacuTime.EditValue);
            if (!string.IsNullOrEmpty(PacuRoom) && inPacuTime != DateTime.MaxValue && inPacuTime != DateTime.MinValue)
            {
                List<MED_OPERATING_ROOM> operatingRoomList = new ComnDictRepository().GetOperatingRoomList("1").Data;
                MED_OPERATION_MASTER operMaster = operationInfoRepository.GetOperMaster(ExtendApplicationContext.Current.PatientContextExtend.PatientID, ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID).Data;
                if (operMaster.IN_PACU_DATE_TIME.HasValue)
                {
                    MessageBoxFormPC.Show("该患者已经入室，请刷新数据！",
               "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else if (operMaster.OPER_STATUS_CODE < (int)OperationStatus.TurnToPACU)
                {
                    MessageBoxFormPC.Show("该患者已被跳转到【" + OperationStatusHelper.OperationStatusToString((OperationStatus)operMaster.OPER_STATUS_CODE) + "】状态，请刷新数据！",
                 "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (operMaster != null)
                {
                    if (operMaster.OUT_DATE_TIME.HasValue)
                    {
                        if (inPacuTime < operMaster.OUT_DATE_TIME)
                        {
                            MessageBoxFormPC.Show("【入复苏室】 时间 [" + inPacuTime + "] 小于 【出手术室】时间 [" + operMaster.OUT_DATE_TIME + "]，请重新输入！",
               "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }
                }
                if (operatingRoomList != null && operatingRoomList.Count > 0)
                {
                    List<string> bedNos = new List<string>();
                    operatingRoomList.ForEach(row =>
                    {
                        if (!string.IsNullOrEmpty(row.BED_TYPE) && row.BED_TYPE.Equals("1"))
                            bedNos.Add(row.ROOM_NO);
                    });
                }
                if (string.IsNullOrEmpty(PacuRoom))
                {
                    return false;
                }
                bool isUpdate = new OperatingRoomRepository().SetOperatingRoomPatient(operatingRoomList, PacuRoom, ExtendApplicationContext.Current.OperRoom, _patientID, _visitID, _operID);
                if (isUpdate)
                {
                    new OperatingRoomRepository().SetOperMaster(_patientID, _visitID, _operID, "IN_PACU_DATE_TIME", inPacuTime, 45);
                    new OperatingRoomRepository().SetMonitorDictPatient("1", ExtendApplicationContext.Current.OperRoom, PacuRoom, _patientID, _visitID, _operID);
                    _patientCard.OPER_STATUS_CODE = 45;
                    _patientCard.IN_PACU_DATE_TIME = inPacuTime;
                    ExtendApplicationContext.Current.PatientInformationExtend = _patientCard;
                }
                else
                {
                    MessageBoxFormPC.Show("床位被占用，请重新选择",
                  "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return isUpdate;
            }
            else
                return false;

            return true;
        }
        private void btnCannel_BtnClicked(object sender, EventArgs e)
        {
            ParentForm.DialogResult = DialogResult.Cancel;
        }

        private void btnNext_BtnClicked(object sender, EventArgs e)
        {
            // if (btnNext.Title.Equals("确认"))
            {
                if (string.IsNullOrEmpty(txtPacuNo.Text))
                {
                    MessageBoxFormPC.Show("复苏床位为必填项目！",
                 "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!_isSelectMark)
                {
                    if (!InPacuRoom()) return;
                    //monitor.Save();
                }
                SelectDateTime = Convert.ToDateTime(txtInPacuTime.EditValue);
                if (ApplicationConfiguration.IsUpdateHisStatus)
                {
                    string ret = new SyncInfoRepository().SyncOPER503W(_patientID, _visitID, _operID, 45).Data;
                }
                result = DialogResult.OK;
                ParentForm.DialogResult = DialogResult.OK;
            }
        }

        private void txtPacuNo_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPacuNo.Text))
            {
                PanelMMonitor.Controls.Clear();
                monitor = new SelectMonitor(_patientCard, 1, txtPacuNo.Text.Trim(), false);
                PanelMMonitor.Controls.Add(monitor);
                monitor.Dock = DockStyle.Fill;
            }
        }

        private void ConfirmationInPacu_Load(object sender, EventArgs e)
        {
            //this.SetDefaultControlStyle(this);
        }

        private void pnlMonitorControl_Paint(object sender, PaintEventArgs e)
        {

        }
        /// <summary>
        /// 将入室时间和手术状态写入到5.0数据库
        /// </summary>
        private void UpdateAnesFive()
        {
            string sql = string.Format(@"update med_operation_master 
                                            set IN_PACU_DATE_TIME=to_date('{0}', 'yyyy-mm-dd hh24:mi:ss'),
                                                OPER_STATUS={1}
                                                where patient_id='{2}' and visit_id={3} and oper_id={4}",
                                        Convert.ToDateTime(txtInPacuTime.EditValue).ToString("yyyy-MM-dd HH:mm:ss"),
                                        45, _patientCard.PATIENT_ID, _patientCard.VISIT_ID, _patientCard.OPER_ID);
            Logger.Error(sql);

            new CommonRepository().UpdateDataTable(sql);

        }
    }
}
