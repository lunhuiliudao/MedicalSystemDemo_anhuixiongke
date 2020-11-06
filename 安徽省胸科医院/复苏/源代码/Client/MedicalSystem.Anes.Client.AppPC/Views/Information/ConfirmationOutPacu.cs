using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Client.Repository;
using MedicalSystem.Services;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class ConfirmationOutPacu : BaseView
    {
        AccountRepository accountRepository = new AccountRepository();

        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        PatientInfoRepository patientInfoRepository = new PatientInfoRepository();

        ComnDictRepository comnDictRepository = new ComnDictRepository();

        string _patientID = string.Empty;
        int _visitID = 0;
        int _operID = 0;
        MED_PATIENT_CARD _patientCard;
        MED_CONFIRMATION_PACU confirmationPACU = null;
        private MED_ANESTHESIA_PLAN _anesPlan;
        public DialogResult result = DialogResult.Cancel;
        public string PacuRoom = string.Empty;
        public DateTime statusTime = DateTime.MinValue;

        private MED_ANESTHESIA_INPUT_DATA _anesInputData;

        public ConfirmationOutPacu()
        {
            InitializeComponent();
        }
        public ConfirmationOutPacu(string pacuRoomNo, string patientID, int visitID, int operID, DateTime currentTime)
            : this()
        {
            _patientID = patientID;
            _visitID = visitID;
            _operID = operID;
            PacuRoom = pacuRoomNo;
            if (currentTime != DateTime.MinValue && currentTime != DateTime.MaxValue)
            {
                timeControl.DateTimes = currentTime;
            }
            else
            {
                timeControl.DateTimes = accountRepository.GetServerTime().Data;
            }
            PatientInfoLoad();
        }
        private void PatientInfoLoad()
        {
            if (string.IsNullOrEmpty(PacuRoom))
            {
                List<MED_OPERATING_ROOM> roomList = comnDictRepository.GetOperatingRoomList("1").Data;
                roomList = roomList.Where(p => p.PATIENT_ID == _patientID && p.VISIT_ID == _visitID && p.OPER_ID == _operID).ToList();
                if (roomList != null && roomList.Count > 0)
                {
                    PacuRoom = roomList[0].ROOM_NO;
                }
            }
            _patientCard = patientInfoRepository.GetPatCard(_patientID, _visitID, _operID).Data;

            _anesPlan = operationInfoRepository.GetAnesPlan(_patientID, _visitID, _operID).Data;
            if (_anesPlan != null)
            {
                switch (_anesPlan.PLAN_WHEREABORTS)
                {
                    case "60":
                        radioStatusOperTurnTo.SelectedIndex = 0;
                        break;
                    case "65":
                        radioStatusOperTurnTo.SelectedIndex = 1;
                        break;
                    case "66":
                        radioStatusOperTurnTo.SelectedIndex = 2;
                        break;
                    case "67":
                        radioStatusOperTurnTo.SelectedIndex = 3;
                        break;
                    default:
                        radioStatusOperTurnTo.SelectedIndex = 0;
                        break;
                }
            }
            if (_patientCard != null)
            {
                lblInPacuTime.Text = _patientCard.IN_PACU_DATE_TIME.Value.ToString("yyyy-MM-dd HH:mm");
            }

            _anesInputData = operationInfoRepository.GetAnesInputData(_patientID, _visitID, _operID).Data;

            if (_patientCard.IN_PACU_DATE_TIME.HasValue && _patientCard.OUT_PACU_DATE_TIME.HasValue)
            {
                TimeSpan ts = (_patientCard.OUT_PACU_DATE_TIME - _patientCard.IN_PACU_DATE_TIME).Value;

                if (_anesInputData != null && string.IsNullOrEmpty(_anesInputData.PACU_3H) && ts.TotalHours > 3)
                {
                    _anesInputData.PACU_3H = "1";
                    chkPACU3H.Checked = true;
                }
            }

            if (_anesInputData.PACU_3H == "1")
                chkPACU3H.Checked = true;

            if (_anesInputData.PACU_TEMPERATURE.HasValue && _anesInputData.PACU_TEMPERATURE == 1)
                checkPACU_LowTemp.Checked = true;

            if (_anesInputData.NO_PLAN_IN_ICU.HasValue && _anesInputData.NO_PLAN_IN_ICU == 1)
                checkNoPlanToIcu.Checked = true;

            if (_anesInputData.AFTER_ANES_COMA.HasValue && _anesInputData.AFTER_ANES_COMA == 1)
                chkAFTER_ANES_COMA.Checked = true;

            if (_anesInputData.TRACHEA_HOARSE.HasValue && _anesInputData.TRACHEA_HOARSE == 1)
                chkTRACHEA_HOARSE.Checked = true;

            if (_anesInputData.ANES_ANAPHYLAXIS.HasValue && _anesInputData.ANES_ANAPHYLAXIS == 1)
                chkANES_ANAPHYLAXIS.Checked = true;

            if (_anesInputData.SPINAL_ANES_COMP.HasValue && _anesInputData.SPINAL_ANES_COMP == 1)
                chkSPINAL_ANES_COMP.Checked = true;

            if (_anesInputData.OTHER_NOT_EXP.HasValue && _anesInputData.OTHER_NOT_EXP == 1)
                chkOTHER_NOT_EXP.Checked = true;
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
        private bool OutPacuRoom()
        {
            List<MED_OPERATING_ROOM> operatingRoomList = comnDictRepository.GetOperatingRoomList("1").Data;
            DateTime outPacuTime = timeControl.DateTimes;
            if (_patientCard != null)
            {
                if (_patientCard.IN_PACU_DATE_TIME.HasValue)
                {
                    if (outPacuTime < _patientCard.IN_PACU_DATE_TIME)
                    {
                        MessageBoxFormPC.Show("【出复苏室】 时间 [" + outPacuTime + "] 小于 【入复苏室】时间 [" + _patientCard.IN_PACU_DATE_TIME + "]，请重新输入！",
           "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
            }
            int sataus = Convert.ToInt32(radioStatusOperTurnTo.Text);
            bool isUpdate = new OperatingRoomRepository().SetOperatingRoomPatient(operatingRoomList, PacuRoom, ExtendApplicationContext.Current.OperRoom, "", 0, 0);
            Logger.Error("更新手术间表结果:" + isUpdate.ToString() + "|" + _patientID + "|" + _visitID + "|" + _operID);
            if (_patientCard.OUT_PACU_DATE_TIME.HasValue)
            {
                isUpdate = true;
                new OperatingRoomRepository().SetOperMaster(_patientCard.PATIENT_ID, _patientCard.VISIT_ID, _patientCard.OPER_ID, "OUT_PACU_DATE_TIME", outPacuTime, sataus);
            }
            else
            {
                //  if (isUpdate)
                {
                    new OperatingRoomRepository().SetOperMaster(_patientCard.PATIENT_ID, _patientCard.VISIT_ID, _patientCard.OPER_ID, "OUT_PACU_DATE_TIME", outPacuTime, sataus);
                    new OperatingRoomRepository().SetMonitorDictPatient("1", ExtendApplicationContext.Current.OperRoom, PacuRoom, "", 0, 0);
                }
            }
            //  if (isUpdate)
            {
                _patientCard.OPER_STATUS_CODE = sataus;
                _patientCard.OUT_PACU_DATE_TIME = outPacuTime;
                ExtendApplicationContext.Current.PatientInformationExtend = _patientCard;
            }

            if (chkPACU3H.Checked)
            {
                _anesInputData.PACU_3H = "1";
            }
            else
            {
                _anesInputData.PACU_3H = "0";
            }

            if (checkPACU_LowTemp.Checked)
            {
                _anesInputData.PACU_TEMPERATURE = 1;
            }
            else
            {
                _anesInputData.PACU_TEMPERATURE = 0;
            }

            if (checkNoPlanToIcu.Checked)
            {
                _anesInputData.NO_PLAN_IN_ICU = 1;
            }
            else
            {
                _anesInputData.NO_PLAN_IN_ICU = 0;
            }


            if (chkAFTER_ANES_COMA.Checked)
            {
                _anesInputData.AFTER_ANES_COMA = 1;
            }
            else
            {
                _anesInputData.AFTER_ANES_COMA = 0;
            }

            if (chkTRACHEA_HOARSE.Checked)
            {
                _anesInputData.TRACHEA_HOARSE = 1;
            }
            else
            {
                _anesInputData.TRACHEA_HOARSE = 0;
            }

            if (chkANES_ANAPHYLAXIS.Checked)
            {
                _anesInputData.ANES_ANAPHYLAXIS = 1;
            }
            else
            {
                _anesInputData.ANES_ANAPHYLAXIS = 0;
            }

            if (chkSPINAL_ANES_COMP.Checked)
            {
                _anesInputData.SPINAL_ANES_COMP = 1;
            }
            else
            {
                _anesInputData.SPINAL_ANES_COMP = 0;
            }

            if (chkOTHER_NOT_EXP.Checked)
            {
                _anesInputData.OTHER_NOT_EXP = 1;
            }
            else
            {
                _anesInputData.OTHER_NOT_EXP = 0;
            }

            operationInfoRepository.SaveAnesInputData(_anesInputData);

            return isUpdate;
        }
        private void btnNext_BtnClicked(object sender, EventArgs e)
        {
            if (radioStatusOperTurnTo.SelectedIndex < 0)
            {
                MessageBoxFormPC.Show("请填写术后去向！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (OutPacuRoom())
            {
                statusTime = timeControl.DateTimes;
                if (ApplicationConfiguration.IsUpdateHisStatus)
                {
                    MED_OPERATION_MASTER operMaster = operationInfoRepository.GetOperMaster(ExtendApplicationContext.Current.PatientContextExtend.PatientID, ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID).Data;
                    Logger.Error("SyncOPER503W前：" + operMaster.PATIENT_ID + "|" + operMaster.VISIT_ID + "|" + operMaster.OPER_ID + "|" + operMaster.OPER_STATUS_CODE + "|" + operMaster.IN_PACU_DATE_TIME + "|" + operMaster.OUT_PACU_DATE_TIME);

                    string ret = new SyncInfoRepository().SyncOPER503W(_patientID, _visitID, _operID, 55).Data;

                    operMaster = operationInfoRepository.GetOperMaster(ExtendApplicationContext.Current.PatientContextExtend.PatientID, ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID).Data;

                    Logger.Error("SyncOPER503W后：" + operMaster.PATIENT_ID + "|" + operMaster.VISIT_ID + "|" + operMaster.OPER_ID + "|" + operMaster.OPER_STATUS_CODE + "|" + operMaster.IN_PACU_DATE_TIME + "|" + operMaster.OUT_PACU_DATE_TIME);
                }
                result = DialogResult.OK;
                ParentForm.DialogResult = DialogResult.OK;
            }
        }

        private void btnCannel_BtnClicked(object sender, EventArgs e)
        {
            ParentForm.DialogResult = DialogResult.Cancel;
        }

        private void ConfirmationOutPacu_Load(object sender, EventArgs e)
        {
            // SetDefaultControlStyle(this);
        }

        private void btnNext_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 将出室时间和手术状态写入到5.0数据库
        /// </summary>
        private void UpdateAnesFive()
        {
            string sql = string.Format(@"update med_operation_master 
                                            set OUT_PACU_DATE_TIME=to_date('{0}', 'yyyy-mm-dd hh24:mi:ss'),
                                                OPER_STATUS={1}
                                                where patient_id='{2}' and visit_id={3} and oper_id={4}",
                                        timeControl.DateTimes.ToString("yyyy-MM-dd HH:mm:ss"),
                                        Convert.ToInt32(radioStatusOperTurnTo.Text), _patientCard.PATIENT_ID, _patientCard.VISIT_ID, _patientCard.OPER_ID);//"0011636230", 1, 1
            Logger.Error(sql);

            new CommonRepository().UpdateDataTable(sql);

            MED_OPERATION_MASTER operMaster = operationInfoRepository.GetOperMaster(ExtendApplicationContext.Current.PatientContextExtend.PatientID, ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID).Data;

            Logger.Error("UpdateAnesFiveOutPacu：" + operMaster.PATIENT_ID + "|" + operMaster.VISIT_ID + "|" + operMaster.OPER_ID + "|" + operMaster.OPER_STATUS_CODE + "|" + operMaster.IN_PACU_DATE_TIME + "|" + operMaster.OUT_PACU_DATE_TIME);
        }
    }
}
