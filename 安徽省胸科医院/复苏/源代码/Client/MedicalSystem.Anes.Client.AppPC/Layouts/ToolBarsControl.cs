using System;
using System.ComponentModel;
using System.Windows.Forms;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class ToolBarsControl : UserControl, IOperationStatusObserver, ITimeTick
    {
        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        AccountRepository accountRepository = new AccountRepository();

        [ToolboxItem(true)]
        public ToolBarsControl()
        {
            InitializeComponent();
        }

        private ProgramStatus currentSystemStatus = ProgramStatus.NoPatient;
        private bool isFirst = true;
        /// <summary>
        /// 状态改变事件
        /// </summary>
        public EventHandler RefreshStatusEvent;
        private void RaiseRefreshEvent()
        {
            if (RefreshStatusEvent != null)
                RefreshStatusEvent(this, new EventArgs());
        }
        /// <summary>
        /// 工作区域引用封装
        /// </summary>
        private MainFrm _MainFormRef = null;
        /// <summary>
        /// 工作区域引用封装
        /// </summary>
        public MainFrm MainFormRef
        {
            get { return _MainFormRef; }
            set { _MainFormRef = value; }
        }
        /// <summary>
        /// 生成状态按钮
        /// </summary>
        public void CreatePatientStatusButtons(string sPatientStatus)
        {
            patientStatusContrl1.CreatePatientStatusButtons(sPatientStatus);
        }
        /// <summary>
        /// 显示各状态时间
        /// </summary>
        /// <param name="row"></param>
        /// <param name="operationStatus"></param>
        public void SetOperationStatusTimeText(OperationStatus operationStatus)
        {
            this.patientStatusContrl1.SetOperationStatusTimeText(operationStatus);
            //if (ExtendApplicationContext.Current.OperationStatus == OperationStatus.OutOperationRoom || ExtendApplicationContext.Current.OperationStatus == OperationStatus.OutPACU)
            //{
            //    panelTurnTo.BackgroundImage = Resources.转出2;
            //    panelTurnTo.Enabled = true;
            //}
            //else
            //{
            //    panelTurnTo.BackgroundImage = Resources.转出3;
            //    panelTurnTo.Enabled = false;
            //}

        }
        DateTime startTime = DateTime.MinValue;
        DateTime endTime = DateTime.MinValue;
        public void SetStatusLight(OperationStatus operationStatus)
        {
            this.patientStatusContrl1.SetStatusLight(operationStatus);
        }
        /// <summary>
        /// 设置手术状态触发的事件
        /// </summary> 
        public void SetPatientStatusAction(IPatientStatusAction patientStatusAction)
        {
            patientStatusContrl1.SetPatientStatusAction(patientStatusAction);
        }

        private void ToolBarsControl_Load(object sender, EventArgs e)
        {
            // new ControlAddEvent(Resources.转出2, Resources.转出1, Resources.转出1).AddMouseMove(panelTurnTo);
            if (!DesignMode)
                MainFrm.MainTickFrm.Register(this);
            if (ApplicationConfiguration.IsPACUProgram)
            {
                lbOperStatusTime.Text = "复苏时长";
            }
            else
            {
                lbOperStatusTime.Text = "手术时长";
            }
            patientStatusContrl1.ServiceObject = this;
            patientStatusContrl1.RefreshPatientHandler += delegate
            {
                ExtendApplicationContext.Current.MED_OPERATION_MASTER = operationInfoRepository.GetOperMaster(ExtendApplicationContext.Current.PatientContextExtend.PatientID,
                    ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID).Data;

            };
        }
        /// <summary>
        /// 设置手术状态,更新注重界面
        /// </summary>
        /// <param name="operationStatus"></param>
        public void NoifyOperationStatusChange(OperationStatus operationStatus)
        {
            if (MainFormRef != null)
            {
                MainFormRef.SetOperationStatus(operationStatus);
                //if (operationStatus == OperationStatus.OutOperationRoom || operationStatus == OperationStatus.OutPACU)
                //{
                //    panelTurnTo.BackgroundImage = Resources.转出2;
                //    panelTurnTo.Enabled = true;
                //}
                //else
                //{
                //    panelTurnTo.BackgroundImage = Resources.转出3;
                //    panelTurnTo.Enabled = false;
                //}
            }
        }
        /// <summary>
        /// 设置手术状态,更新注重界面
        /// </summary>
        /// <param name="operationStatus"></param>
        public void NoifyOperationTimeChange()
        {
            if (MainFormRef != null)
                MainFormRef.RefreshCurrentWorkControl();
        }
        /// <summary>
        /// 取消手术 病案提交
        /// </summary>
        /// <param name="operationStatus"></param>
        public void CancelOrCommitOperation(OperationStatus operationStatus, string cancelReason)
        {
            patientStatusContrl1.CancelOrCommitOperation(operationStatus, cancelReason);
        }

        public void RecoveryOperation(string recoveryReason)
        {
            //patientStatusContrl1.RecoveryOperation(recoveryReason);
        }
        public void OnTicked()
        {
            if (ExtendApplicationContext.Current.MED_OPERATION_MASTER != null)
            {
                if (ApplicationConfiguration.IsPACUProgram)
                {
                    if (ExtendApplicationContext.Current.MED_OPERATION_MASTER.IN_PACU_DATE_TIME.HasValue)
                    {
                        startTime = ExtendApplicationContext.Current.MED_OPERATION_MASTER.IN_PACU_DATE_TIME.Value;
                        if (ExtendApplicationContext.Current.MED_OPERATION_MASTER.OUT_PACU_DATE_TIME.HasValue)
                        {
                            endTime = ExtendApplicationContext.Current.MED_OPERATION_MASTER.OUT_PACU_DATE_TIME.Value;
                        }
                        else
                        {
                            endTime = accountRepository.GetServerTime().Data;
                        }
                    }
                }
                else
                {
                    if (ExtendApplicationContext.Current.MED_OPERATION_MASTER.IN_DATE_TIME.HasValue)
                    {
                        startTime = ExtendApplicationContext.Current.MED_OPERATION_MASTER.IN_DATE_TIME.Value;
                        if (ExtendApplicationContext.Current.MED_OPERATION_MASTER.OUT_DATE_TIME.HasValue)
                        {
                            endTime = ExtendApplicationContext.Current.MED_OPERATION_MASTER.OUT_DATE_TIME.Value;
                        }
                        else
                        {
                            endTime = accountRepository.GetServerTime().Data;
                        }
                    }
                }
            }

            if (startTime != DateTime.MinValue && endTime != DateTime.MinValue)
            {
                TimeSpan span = (TimeSpan)(endTime - startTime);
                int hours = span.Days * 24;
                lblTime.Text = (hours + span.Hours).ToString("00") + ":" + span.Minutes.ToString("00") + ":" + span.Seconds.ToString("00");
            }
            else
            {
                lblTime.Text = "00:00:00";
            }
        }

        private void panelTurnTo_Click(object sender, EventArgs e)
        {
            TurnToControl control = new TurnToControl(ExtendApplicationContext.Current.OperationStatus);
            DialogHostFormPC dialogHostForm = new DialogHostFormPC("患者转出", control.Width, control.Height);
            dialogHostForm.Child = control;
            dialogHostForm.ShowDialog();
            if (control.result == DialogResult.OK)
            {
                patientStatusContrl1.SetOperTurnStatus(control.CurrentOperStatus);
            }
        }
    }
}
