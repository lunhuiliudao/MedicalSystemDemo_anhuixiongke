using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class ConfirmationOutRoom : BaseView
    {
        AccountRepository accountRepository = new AccountRepository();

        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        PatientInfoRepository patientInfoRepository = new PatientInfoRepository();


        private string _patientID;
        private int _visitID;
        private int _operID;
        private MED_OPERATION_MASTER _operMaster;
        private MED_ANESTHESIA_PLAN _anesPlan;
        private MED_OPERATION_MASTER_EXT _operMasterExt;
        private MED_ANESTHESIA_INPUT_DATA _anesInputData;
        private List<MED_ANESTHESIA_EVENT> _anesEventList;
        public DialogResult result = DialogResult.Cancel;
        public DateTime statusTime = DateTime.MinValue;

        public ConfirmationOutRoom()
        {
            InitializeComponent();
            _patientID = ExtendApplicationContext.Current.PatientContextExtend.PatientID;
            _visitID = ExtendApplicationContext.Current.PatientContextExtend.VisitID;
            _operID = ExtendApplicationContext.Current.PatientContextExtend.OperID;
            Caption = "出室确认";
        }
        public ConfirmationOutRoom(DateTime currentTime)
            : this()
        {
            if (currentTime != DateTime.MinValue && currentTime != DateTime.MaxValue)
            {
                timeControl.DateTimes = currentTime;
            }
            else
            {
                timeControl.DateTimes = accountRepository.GetServerTime().Data;
            }
        }
        private void InitalizationData()
        {
            using (BackgroundWorker worker = new BackgroundWorker())
            {
                worker.DoWork += delegate (object sender, DoWorkEventArgs e)
                {
                    _operMaster = operationInfoRepository.GetOperMaster(_patientID, _visitID, _operID).Data;

                    _anesPlan = operationInfoRepository.GetAnesPlan(_patientID, _visitID, _operID).Data;

                    _operMasterExt = operationInfoRepository.GetOperMasterExt(_patientID, _visitID, _operID).Data;

                    _anesInputData = operationInfoRepository.GetAnesInputData(_patientID, _visitID, _operID).Data;

                    _anesEventList = operationInfoRepository.GetAnesEventList(_patientID, _visitID, _operID).Data;
                };
                worker.RunWorkerCompleted += delegate (object sender, RunWorkerCompletedEventArgs e)
                {
                    OutRoomDataLoad();
                };
                worker.RunWorkerAsync();
            }
        }
        private void OutRoomDataLoad()
        {
            if (_operMaster != null)
            {
                lblOperRoom.Text = _operMaster.OPER_ROOM_NO;
                lblSequence.Text = _operMaster.SEQUENCE.Value.ToString();
            }
            else
            {
                _operMaster = new MED_OPERATION_MASTER();
                _operMaster.PATIENT_ID = _patientID;
                _operMaster.VISIT_ID = _visitID;
                _operMaster.OPER_ID = _operID;
            }
            if (_anesPlan != null)
            {
            }
            else
            {
                _anesPlan = new MED_ANESTHESIA_PLAN();
                _anesPlan.PATIENT_ID = _patientID;
                _anesPlan.VISIT_ID = _visitID;
                _anesPlan.OPER_ID = _operID;
            }
            if (_operMasterExt == null)
            {
                _operMasterExt = new MED_OPERATION_MASTER_EXT();
                _operMasterExt.PATIENT_ID = _patientID;
                _operMasterExt.VISIT_ID = _visitID;
                _operMasterExt.OPER_ID = _operID;
            }
            if (_anesInputData == null)
            {
                _anesInputData = new MED_ANESTHESIA_INPUT_DATA();
                _anesInputData.PATIENT_ID = _patientID;
                _anesInputData.VISIT_ID = _visitID;
                _anesInputData.OPER_ID = _operID;
            }
            else
            {
                txtAnesEffect.Text = _anesInputData.ANES_EFFECT;
                if (_anesInputData.AFTER_ANALGESIA.HasValue && _anesInputData.AFTER_ANALGESIA == 1)
                    radioGroupAnalgesia.SelectedIndex = 0;
                txtAnalgesiaMethod.Text = _anesInputData.ANALGESIA_METHOD;
                if (!string.IsNullOrEmpty(_anesInputData.CANCELED_TYPE) && _anesInputData.CANCELED_TYPE == "1")
                    chkCANCELED_TYPE.Checked = true;
                if (_anesInputData.TRACHEA_6H.HasValue && _anesInputData.TRACHEA_6H == 1)
                    chkTRACHEA_6H.Checked = true;
                if (_anesInputData.ANES_ANAPHYLAXIS.HasValue && _anesInputData.ANES_ANAPHYLAXIS == 1)
                    chkANES_ANAPHYLAXIS.Checked = true;
                if (_anesInputData.SPINAL_ANES_COMP.HasValue && _anesInputData.SPINAL_ANES_COMP == 1)
                    chkSPINAL_ANES_COMP.Checked = true;
                if (_anesInputData.CENTRAL_VENOUS.HasValue && _anesInputData.CENTRAL_VENOUS == 1)
                    chkCENTRAL_VENOUS.Checked = true;
                if (_anesInputData.TRACHEA_HOARSE.HasValue && _anesInputData.TRACHEA_HOARSE == 1)
                    chkTRACHEA_HOARSE.Checked = true;
                if (_anesInputData.CONS_DISTURBANCE.HasValue && _anesInputData.CONS_DISTURBANCE == 1)
                    chkCONS_DISTURBANCE.Checked = true;
                if (_anesInputData.ANES_DEATH.HasValue && _anesInputData.ANES_DEATH == 1)
                    chkANES_DEATH.Checked = true;
                if (_anesInputData.OXYGEN_SATURATION.HasValue && _anesInputData.OXYGEN_SATURATION == 1)
                    chkOXYGEN_SATURATION.Checked = true;
                if (_anesInputData.RES_TRACT_OBSTRUCE.HasValue && _anesInputData.RES_TRACT_OBSTRUCE == 1)
                    chkRES_TRACT_OBSTRUCE.Checked = true;
                if (_anesInputData.AFTER_ANES_COMA.HasValue && _anesInputData.AFTER_ANES_COMA == 1)
                    chkAFTER_ANES_COMA.Checked = true;
                if (_anesInputData.OTHER_NOT_EXP.HasValue && _anesInputData.OTHER_NOT_EXP == 1)
                    chkOTHER_NOT_EXP.Checked = true;

            }
            decimal inAll = 0; decimal outAll = 0; decimal inBlood = 0; decimal inZTX = 0;
            if (_anesEventList != null && _anesEventList.Count > 0)
            {
                List<MED_ANESTHESIA_EVENT> eventList = _anesEventList.Where(p => p.EVENT_CLASS_CODE == "3" || p.EVENT_CLASS_CODE == "B").ToList();

                foreach (MED_ANESTHESIA_EVENT row in eventList)
                {
                    if (row.DOSAGE.HasValue)
                        inAll += row.DOSAGE.Value;
                }
                eventList = _anesEventList.Where(p => p.EVENT_CLASS_CODE == "D").ToList();

                foreach (MED_ANESTHESIA_EVENT row in eventList)
                {
                    if (row.DOSAGE.HasValue)
                        outAll += row.DOSAGE.Value;
                }

                eventList = _anesEventList.Where(p => p.EVENT_CLASS_CODE == "B").ToList();
                foreach (MED_ANESTHESIA_EVENT row in eventList)
                {
                    if (row.DOSAGE.HasValue)
                        inBlood += row.DOSAGE.Value;
                }

                eventList = _anesEventList.Where(p => p.EVENT_CLASS_CODE == "B" && p.EVENT_ATTR == "自体血").ToList();
                foreach (MED_ANESTHESIA_EVENT row in eventList)
                {
                    if (row.DOSAGE.HasValue)
                        inZTX += row.DOSAGE.Value;
                }
            }
            txtInfluidsAmount.Text = inAll.ToString("0.00");
            txtOutFluidsAmount.Text = outAll.ToString("0.00");
            txtBolldTransfused.Text = inBlood.ToString("0.00");
            txtCryWather.Text = inZTX.ToString("0.00");
        }
        private void SaveOutRoomData()
        {
            _operMasterExt.IN_FLUIDS_AMOUNT = Convert.ToInt32(Convert.ToDecimal(txtInfluidsAmount.Text));
            _operMasterExt.OUT_FLUIDS_AMOUNT = Convert.ToInt32(Convert.ToDecimal(txtOutFluidsAmount.Text));
            _operMasterExt.BLOOD_TRANSFUSED = Convert.ToInt32(Convert.ToDecimal(txtBolldTransfused.Text));
            _operMasterExt.CRY_WATHER = Convert.ToInt32(Convert.ToDecimal(txtCryWather.Text));

            _anesInputData.ANES_EFFECT = txtAnesEffect.Text;
            if (radioGroupAnalgesia.SelectedIndex == 0)
                _anesInputData.AFTER_ANALGESIA = 1;
            _anesInputData.ANALGESIA_METHOD = txtAnalgesiaMethod.Text;
            if (chkCANCELED_TYPE.Checked) _anesInputData.CANCELED_TYPE = "1";
            if (chkTRACHEA_6H.Checked) _anesInputData.TRACHEA_6H = 1;
            if (chkANES_ANAPHYLAXIS.Checked) _anesInputData.ANES_ANAPHYLAXIS = 1;
            if (chkSPINAL_ANES_COMP.Checked) _anesInputData.SPINAL_ANES_COMP = 1;
            if (chkCENTRAL_VENOUS.Checked) _anesInputData.CENTRAL_VENOUS = 1;
            if (chkTRACHEA_HOARSE.Checked) _anesInputData.TRACHEA_HOARSE = 1;
            if (chkCONS_DISTURBANCE.Checked) _anesInputData.CONS_DISTURBANCE = 1;
            if (chkOXYGEN_SATURATION.Checked) _anesInputData.OXYGEN_SATURATION = 1;
            if (chkANES_DEATH.Checked) _anesInputData.ANES_DEATH = 1;
            if (chkRES_TRACT_OBSTRUCE.Checked) _anesInputData.RES_TRACT_OBSTRUCE = 1;
            if (chkAFTER_ANES_COMA.Checked) _anesInputData.AFTER_ANES_COMA = 1;
            if (chkOTHER_NOT_EXP.Checked) _anesInputData.OTHER_NOT_EXP = 1;

            operationInfoRepository.SavePatientOperation(new { _operMaster, _operMasterExt });

            operationInfoRepository.SaveAnesInputData(_anesInputData);
        }
        private void ConfirmationOutRoom_Load(object sender, EventArgs e)
        {
            InitalizationData();
        }

        private void btnCannel_BtnClicked(object sender, EventArgs e)
        {
            ParentForm.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_BtnClicked(object sender, EventArgs e)
        {
            if (timeControl.DateTimes != DateTime.MinValue || timeControl.DateTimes != DateTime.MaxValue)
            {
                SaveOutRoomData();
                statusTime = timeControl.DateTimes;
                result = DialogResult.OK;
                ParentForm.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBoxFormPC.Show("标*号的为必填项目，请认真填写，谢谢！");
            }
        }
    }
}
