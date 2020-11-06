using System;
using System.Drawing;
using System.Windows.Forms;
using MedicalSystem.Anes.Client.AppPC.Properties;
using MedicalSystem.Anes.Client.FrameWork;

namespace MedicalSystem.Anes.Client.AppPC
{
    public partial class PatientStatusSingleControl : BaseControl
    {
        public PatientStatusSingleControl()
        {
            InitializeComponent();
        }
        private string _StatusName = "";
        private PatientStatusContrl.OperationLightStatus _ConrolLightStatus = PatientStatusContrl.OperationLightStatus.Nomal;
        private PatientStatusContrl _ServicePatientStatusContrl = null;
        public DateTime _ControlDateTime = DateTime.MinValue;
        private bool _canEdit = true;

        public string StatusName
        {
            get { return _StatusName; }
            set
            {

                _StatusName = value;
                lbOperStatus.Text = _StatusName;
            }
        }

        public bool LineImageLeftVisible
        {
            get { return picImageLeft.Visible; }
            set
            {
                picImageLeft.Visible = value;

            }
        }
        private Image _LineImageLeft = null;
        public Image LineImageLeft
        {

            get { return _LineImageLeft; }
            set
            {
                _LineImageLeft = value;
                picImageLeft.BackgroundImage = _LineImageLeft;
            }
        }

        private Image _LightImage = null;
        public Image LightImage
        {

            get { return _LightImage; }
            set
            {
                _LightImage = value;
                picLightImage.Image = _LightImage;
            }
        }
        public PatientStatusContrl.OperationLightStatus ConrolLightStatus
        {
            get { return _ConrolLightStatus; }
            set { _ConrolLightStatus = value; }
        }
        /// <summary>
        /// 获取控件时间
        /// </summary>
        public DateTime ControlDateTime
        {
            get
            {
                if (lbOperStatusTime.Text == null)
                    return DateTime.MinValue;
                else
                {
                    return _ControlDateTime;
                }

            }
        }

        /// <summary>
        /// 该 SinglePatientStatusConrol 服务的控件
        /// </summary>
        public PatientStatusContrl ServicePatientStatusContrl
        {
            get { return _ServicePatientStatusContrl; }
            set { _ServicePatientStatusContrl = value; }
        }

        /// <summary>
        /// 设置状态灯的图片
        /// </summary>
        /// <param name="operationLightStatus"></param>
        public void SetStatusLightImage(PatientStatusContrl.OperationLightStatus operationLightStatus)
        {
            _ConrolLightStatus = operationLightStatus;
            if (operationLightStatus == PatientStatusContrl.OperationLightStatus.Nomal)
            {
                //if (ApplicationConfiguration.IsPACUProgram)
                //{
                //    if (StatusName.Trim() == "出手术室")
                //    {
                //        this.picLightImage.Image = Resources.灰点; ;
                //        picImageLeft.Visible = false;
                //        picImageRight.BackgroundImage = Resources.灰线;
                //    }
                //    else if (StatusName.Trim() == "出复苏室")
                //    {
                //        this.picLightImage.Image = Resources.灰点;
                //        picImageLeft.BackgroundImage = Resources.灰线;
                //        picImageLeft.Visible = true;
                //        picImageRight.Visible = false;

                //    }
                //    else
                //    {
                //        this.picLightImage.Image = Resources.灰点;
                //        picImageLeft.BackgroundImage = Resources.灰线;
                //        picImageLeft.Visible = true;
                //        picImageRight.BackgroundImage = Resources.灰线;
                //        picImageRight.Visible = true;
                //    }
                //}
                //else
                {
                    if (StatusName.Trim() == "入手术室" || StatusName.Trim() == "入复苏室")
                    {
                        this.picLightImage.Image = Resources.灰点; ;
                        picImageLeft.Visible = false;
                        picImageRight.BackgroundImage = Resources.灰线;
                    }
                    else if (StatusName.Trim() == "出手术室" || StatusName.Trim() == "出复苏室")
                    {
                        this.picLightImage.Image = Resources.灰点;
                        picImageLeft.BackgroundImage = Resources.灰线;
                        picImageLeft.Visible = true;
                        picImageRight.Visible = false;

                    }
                    else
                    {
                        this.picLightImage.Image = Resources.灰点;
                        picImageLeft.BackgroundImage = Resources.灰线;
                        picImageLeft.Visible = true;
                        picImageRight.BackgroundImage = Resources.灰线;
                        picImageRight.Visible = true;
                    }
                }

                lbOperStatusTime.Visible = false;
                lbOperStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(186)))), ((int)(((byte)(190)))));
            }
            else if (operationLightStatus == PatientStatusContrl.OperationLightStatus.Light || operationLightStatus == PatientStatusContrl.OperationLightStatus.Passed)
            {
                //if (ApplicationConfiguration.IsPACUProgram)
                //{
                //    if (StatusName.Trim() == "出手术室")
                //    {
                //        this.picLightImage.Image = Resources.蓝点;
                //        picImageLeft.Visible = false;
                //        picImageRight.BackgroundImage = Resources.蓝线;
                //    }
                //    else if (StatusName.Trim() == "出复苏室")
                //    {
                //        this.picLightImage.Image = Resources.蓝点;
                //        picImageLeft.BackgroundImage = Resources.蓝线;
                //        picImageLeft.Visible = true;
                //        picImageRight.Visible = false;

                //    }
                //    else
                //    {
                //        this.picLightImage.Image = Resources.蓝点;
                //        picImageLeft.BackgroundImage = Resources.蓝线;
                //        picImageLeft.Visible = true;
                //        picImageRight.BackgroundImage = Resources.蓝线;
                //        picImageRight.Visible = true;
                //    }
                //}
                //else
                {
                    if (StatusName.Trim() == "入手术室" || StatusName.Trim() == "入复苏室")
                    {
                        this.picLightImage.Image = Resources.蓝点;
                        picImageLeft.Visible = false;
                        picImageRight.BackgroundImage = Resources.蓝线;
                    }
                    else if (StatusName.Trim() == "出手术室" || StatusName.Trim() == "出复苏室")
                    {
                        this.picLightImage.Image = Resources.蓝点;
                        picImageLeft.BackgroundImage = Resources.蓝线;
                        picImageLeft.Visible = true;
                        picImageRight.Visible = false;

                    }
                    else
                    {
                        this.picLightImage.Image = Resources.蓝点;
                        picImageLeft.BackgroundImage = Resources.蓝线;
                        picImageLeft.Visible = true;
                        picImageRight.BackgroundImage = Resources.蓝线;
                        picImageRight.Visible = true;
                    }
                }

                lbOperStatusTime.Visible = true;
                lbOperStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(152)))), ((int)(((byte)(217)))));
            }
            else
            {
                picLightImage.Image = null;
                picImageLeft.BackgroundImage = null;
                this.lbOperStatus.ForeColor = System.Drawing.Color.Gray;
                lbOperStatusTime.ForeColor = Color.Gray;
            }
            picImageLeft.Invalidate();
            picLightImage.Invalidate();

        }
        /// <summary>
        /// 设置状态控件是否可用
        /// </summary>
        public void SetPatientStatusContrlReadOnly(bool readonlyable)
        {
            _canEdit = readonlyable;

        }

        /// <summary>
        /// 设置状态时间
        /// </summary>
        /// <param name="operationLightStatus"> 参数如果是 DateTime.MinValue，则显示为空 </param>
        public void SetOperationStatusTimeText(DateTime operationStatusTime)
        {
            if (operationStatusTime == DateTime.MinValue)
            {
                lbOperStatusTime.Text = "";
                toolTipStatusTime.SetToolTip(lbOperStatusTime, "");
                SetStyle(false);
            }
            else
            {
                DateTime inTime = ExtendApplicationContext.Current.PatientInformationExtend.IN_PACU_DATE_TIME.Value;
                int day = (int)(operationStatusTime - inTime).TotalDays;
                if (day >= 1)
                {
                    lbOperStatusTime.Text = operationStatusTime.ToString("HH:mm") + " +" + day;
                }
                else
                {
                    lbOperStatusTime.Text = operationStatusTime.ToString("HH:mm");
                }
                lbOperStatusTime.Tag = operationStatusTime;
                toolTipStatusTime.SetToolTip(lbOperStatusTime, operationStatusTime.ToString("yyyy-MM-dd HH:mm"));
                SetStyle(true);
            }

            _ControlDateTime = operationStatusTime;
        }
        public string SetOperationStatusText()
        {
            string statusName = "";
            OperationStatus status = ExtendApplicationContext.Current.OperationStatus;
            if (ApplicationConfiguration.IsPACUProgram)
            {
                if (status > OperationStatus.OutPACU)
                    statusName = OperationStatusHelper.OperationStatusToString(status);
            }
            else
            {
                if (status > OperationStatus.OutOperationRoom)
                {
                    statusName = OperationStatusHelper.OperationStatusToString(status);
                }
            }
            return statusName;
        }
        public void RobackTime()
        {
            SetOperationStatusTimeText(_ControlDateTime);
        }

        private void PatientStatusSingleControl_Load(object sender, EventArgs e)
        {
            lbOperStatus.BackColor = Color.Transparent;
        }





        /// <summary>
        /// 根据是否有时间值来设置样式
        /// </summary>
        /// <param name="hasDate"></param>
        public void SetStyle(bool hasDate)
        {
            if (hasDate)
            {
                lbOperStatusTime.BackColor = this.BackColor;
            }
            else
            {
                lbOperStatusTime.BackColor = Color.White;
            }
        }
        private void PatientStatusSingleControl_Click(object sender, EventArgs e)
        {
            //验证是否可触发
            if ((_ControlDateTime == DateTime.MinValue || _ControlDateTime == DateTime.MinValue) && ApplicationConfiguration.ApplicationPatterns == "1")
            {
                SetOperationStatusTimeText(DateTime.MinValue);
                return;
            }
            if (!_ServicePatientStatusContrl.OnPatientStatusSingleControlKeyDown(this))
            {
                SetOperationStatusTimeText(DateTime.MinValue);
                return;
            }
            object result = null;
            if (_ControlDateTime != null && _ControlDateTime != DateTime.MinValue
                && _ControlDateTime != DateTime.MaxValue && !StatusName.Trim().Equals("出复苏室"))
            {
                TimeInPutFrmPC timeInput = new TimeInPutFrmPC();
                timeInput.Text = this.StatusName + "时间";
                if (this._ControlDateTime != null && this._ControlDateTime != DateTime.MinValue
                    && this._ControlDateTime != DateTime.MaxValue)
                    timeInput.SelectedDateTime = this._ControlDateTime;
                if (timeInput.ShowDialog() != DialogResult.Cancel)
                {
                    result = timeInput.SelectedDateTime;
                }
            }
            else
            {
                if (StatusName.Trim().Equals("出复苏室"))
                {
                    ConfirmationOutPacu outPacu = new ConfirmationOutPacu("", ExtendApplicationContext.Current.PatientContextExtend.PatientID,
                        ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID, _ControlDateTime);
                    DialogHostFormPC dialogForm = new DialogHostFormPC("出室信息确认", outPacu.Width, outPacu.Height);
                    dialogForm.Child = outPacu;
                    dialogForm.ShowDialog();
                    if (outPacu.result == DialogResult.OK)
                    {
                        result = outPacu.statusTime;
                    }
                }
                else if (StatusName.Trim().Equals("入手术室"))
                {
                    ConfirmationSureBase sure = new ConfirmationSureBase(ExtendApplicationContext.Current.PatientInformationExtend, Convert.ToDecimal(ExtendApplicationContext.Current.EventNo));
                    DialogHostFormPC dialogHostForm = new DialogHostFormPC("入室信息确认", sure.Width, sure.Height);
                    dialogHostForm.Text = "信息确认";
                    dialogHostForm.Child = sure;
                    dialogHostForm.ShowDialog();
                    if (sure.result == DialogResult.OK)
                    {
                        result = sure.SelectDateTime;
                    }
                }
                else if (StatusName.Trim().Equals("出手术室"))
                {
                    ConfirmationOutRoom timeControl = new ConfirmationOutRoom(_ControlDateTime);
                    DialogHostFormPC dialogHostForm = new DialogHostFormPC("出室确认", timeControl.Width, timeControl.Height);
                    dialogHostForm.Child = timeControl;
                    dialogHostForm.ShowDialog();
                    if (timeControl.result == DialogResult.OK)
                    {
                        result = timeControl.statusTime;
                    }
                }
                else if (StatusName.Trim().Equals("入复苏室"))
                {
                    ConfirmationInPacu inPacu = new ConfirmationInPacu(ExtendApplicationContext.Current.PatientContextExtend.PatientID,
                        ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID, false);
                    DialogHostFormPC dialogHostForm = new DialogHostFormPC("入室信息确认", inPacu.Width, inPacu.Height);
                    dialogHostForm.Child = inPacu;
                    dialogHostForm.ShowDialog();
                    if (inPacu.result == DialogResult.OK)
                    {
                        result = inPacu.SelectDateTime;
                    }
                }
                //else if (StatusName.Equals("麻醉开始") || StatusName.Equals("手术开始") || StatusName.Equals("出手术室"))
                //{
                //   ConfirmationTimeControl timeControl = new ConfirmationTimeControl(StatusName, _ControlDateTime);
                //    DialogHostFormPC dialogHostForm = new DialogHostFormPC(StatusName, timeControl.Width, timeControl.Height);
                //    dialogHostForm.Child = timeControl;
                //    dialogHostForm.ShowDialog();
                //    if (timeControl.result == DialogResult.OK)
                //    {
                //        result = timeControl.statusTime;
                //    }
                //}
                else
                {
                    TimeInPutFrmPC timeInput = new TimeInPutFrmPC();
                    timeInput.Text = this.StatusName + "时间";
                    if (this._ControlDateTime != null && this._ControlDateTime != DateTime.MinValue
                        && this._ControlDateTime != DateTime.MaxValue)
                        timeInput.SelectedDateTime = this._ControlDateTime;
                    if (timeInput.ShowDialog() != DialogResult.Cancel)
                    {
                        result = timeInput.SelectedDateTime;
                    }
                }
            }

            if (result != null)
            {
                _ControlDateTime = Convert.ToDateTime(result);
                DateTime dt = Convert.ToDateTime(result);
                if (_ServicePatientStatusContrl.OnSinglePatientStatusConrolTimeValidate(this))
                {
                    SetOperationStatusTimeText(dt);
                }
            }
        }
        public bool IsDateTimeEmpty()
        {
            string text = _ControlDateTime.ToString();

            if (string.IsNullOrEmpty(text) || _ControlDateTime == DateTime.MaxValue || _ControlDateTime == DateTime.MinValue)
            {
                return true;
            }
            return false;
        }
        private void PatientStatusSingleControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (AccessControl.PermissionProviderCustom.CheckModifyRightForOperator("麻醉记录单", "NotCheckPrint") && ApplicationConfiguration.ApplicationPatterns == "0")
            {
                //if (ApplicationConfiguration.IsPACUProgram && this.StatusName.Equals("出手术室")) return;
                if (e.Button == MouseButtons.Right)
                {
                    if (IsDateTimeEmpty())
                    {
                        _ServicePatientStatusContrl.OnPopUpOperationSatusMouseDown(this, false);
                    }
                    else
                    {
                        _ServicePatientStatusContrl.OnPopUpOperationSatusMouseDown(this, true);
                    }

                }
                else
                {
                    PatientStatusSingleControl_Click(sender, null);
                }
            }
        }
    }
}
