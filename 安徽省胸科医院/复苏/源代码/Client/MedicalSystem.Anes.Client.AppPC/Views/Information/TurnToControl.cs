using System;
using System.ComponentModel;
using System.Windows.Forms;
using MedicalSystem.Anes.Document.Views;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class TurnToControl : BaseView
    {
        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        AccountRepository accountRepository = new AccountRepository();

        private string _patientID;
        private int _visitID;
        private int _operID;
        private MED_OPERATION_MASTER _operMaster;
        private MED_ANESTHESIA_PLAN _anesPlan;
        public DialogResult result = DialogResult.Cancel;
        private OperationStatus _currentOperStatus;
        public OperationStatus CurrentOperStatus
        {
            get { return _currentOperStatus; }
            set { _currentOperStatus = value; }
        }
        public TurnToControl()
        {
            InitializeComponent();
            Caption = "患者转出";
        }
        public TurnToControl(OperationStatus operStatus)
            : this()
        {
            if (ApplicationConfiguration.IsPACUProgram && operStatus == OperationStatus.OutPACU)
            {
                radioStatusOperTurnTo.Properties.Items.RemoveAt(1);
                radioStatusOperTurnTo.SelectedIndex = 1;
            }
            _patientID = ExtendApplicationContext.Current.PatientContextExtend.PatientID;
            _visitID = ExtendApplicationContext.Current.PatientContextExtend.VisitID;
            _operID = ExtendApplicationContext.Current.PatientContextExtend.OperID;
        }

        private void InitalizationData()
        {
            using (BackgroundWorker worker = new BackgroundWorker())
            {
                worker.DoWork += delegate(object sender, DoWorkEventArgs e)
                {
                    _operMaster = operationInfoRepository.GetOperMaster(_patientID, _visitID, _operID).Data;
                    _anesPlan = operationInfoRepository.GetAnesPlan(_patientID, _visitID, _operID).Data;
                };
                worker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
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
                if (!ApplicationConfiguration.IsPACUProgram)
                {
                    switch (_anesPlan.PLAN_WHEREABORTS)
                    {
                        case "65":
                            radioStatusOperTurnTo.SelectedIndex = 0;
                            break;
                        case "40":
                            radioStatusOperTurnTo.SelectedIndex = 1;
                            break;
                        case "60":
                            radioStatusOperTurnTo.SelectedIndex = 2;
                            break;
                        case "66":
                            radioStatusOperTurnTo.SelectedIndex = 3;
                            break;
                        case "67":
                            radioStatusOperTurnTo.SelectedIndex = 4;
                            break;
                        case "68":
                            radioStatusOperTurnTo.SelectedIndex = 5;
                            break;
                        default:
                            radioStatusOperTurnTo.SelectedIndex = 2;
                            break;
                    }
                }
            }
            else
            {
                _anesPlan = new MED_ANESTHESIA_PLAN();
                _anesPlan.PATIENT_ID = _patientID;
                _anesPlan.VISIT_ID = _visitID;
                _anesPlan.OPER_ID = _operID;
            }
        }
        private void TurnToControl_Load(object sender, EventArgs e)
        {
            InitalizationData();
        }

        private void btnOK_BtnClicked(object sender, EventArgs e)
        {
            if (ApplicationConfiguration.IsPACUProgram)
            {
                switch (radioStatusOperTurnTo.SelectedIndex)
                {
                    case 0:
                        _operMaster.OUT_PACU_WHEREABORTS = 65;
                        _operMaster.PAT_WHEREABORTS = "ICU";
                        break;
                    case 1:
                        _operMaster.OUT_PACU_WHEREABORTS = 60;
                        _operMaster.PAT_WHEREABORTS = "病房";
                        break;
                    case 2:
                        _operMaster.OUT_PACU_WHEREABORTS = 66;
                        _operMaster.PAT_WHEREABORTS = "门/急诊观察室";
                        break;
                    case 3:
                        _operMaster.OUT_PACU_WHEREABORTS = 67;
                        _operMaster.PAT_WHEREABORTS = "离院";
                        break;
                    case 4:
                        _operMaster.OUT_PACU_WHEREABORTS = 68;
                        _operMaster.PAT_WHEREABORTS = "死亡";
                        break;
                }
                _operMaster.OUT_PACU_OVERTIME = accountRepository.GetServerTime().Data;
                _currentOperStatus = (OperationStatus)_operMaster.OUT_PACU_WHEREABORTS;
            }
            else
            {
                switch (radioStatusOperTurnTo.SelectedIndex)
                {
                    case 0:
                        _operMaster.OUT_OPER_WHEREABORTS = 65;
                        _operMaster.PAT_WHEREABORTS = "ICU";
                        break;
                    case 1:
                        _operMaster.OUT_OPER_WHEREABORTS = 40;
                        _operMaster.PAT_WHEREABORTS = "恢复室";
                        break;
                    case 2:
                        _operMaster.OUT_OPER_WHEREABORTS = 60;
                        _operMaster.PAT_WHEREABORTS = "病房";
                        break;
                    case 3:
                        _operMaster.OUT_OPER_WHEREABORTS = 66;
                        _operMaster.PAT_WHEREABORTS = "门/急诊观察室";
                        break;
                    case 4:
                        _operMaster.OUT_OPER_WHEREABORTS = 67;
                        _operMaster.PAT_WHEREABORTS = "离院";
                        break;
                    case 5:
                        _operMaster.OUT_OPER_WHEREABORTS = 68;
                        _operMaster.PAT_WHEREABORTS = "死亡";
                        break;
                }
                _operMaster.OUT_OPER_OVERTIME = accountRepository.GetServerTime().Data;
                _currentOperStatus = (OperationStatus)_operMaster.OUT_OPER_WHEREABORTS;
            }
            operationInfoRepository.SaveOperMaster(_operMaster);

            ParentForm.DialogResult = DialogResult.OK;
            result = DialogResult.OK;
        }

        private void btnCannel_BtnClicked(object sender, EventArgs e)
        {
            ParentForm.DialogResult = DialogResult.Cancel;
        }
    }
}
