using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Client.AppPC.Properties;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Client.Repository;

namespace MedicalSystem.Anes.Client.AppPC
{
    [ToolboxItem(false)]
    public partial class OperationRoomContent : UserControl, ITimeTick
    {
        CommonRepository commonRepository = new CommonRepository();

        ComnDictRepository comnDictRepository = new ComnDictRepository();

        PatientInfoRepository patientInfoRepository = new PatientInfoRepository();

        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        AccountRepository accountRepository = new AccountRepository();

        OperationScheduleRepository operationScheduleRepository = new OperationScheduleRepository();

        SyncInfoRepository syncInfoRepository = new SyncInfoRepository();

        public OperationRoomContent()
        {
            InitializeComponent();
        }
        MED_PATIENT_CARD _patientCard;
        public string OperRoomNo = "";
        public string PatientID = "";
        public int VisitID = 0;
        public int OperID = 0;
        public string BedType = "0";
        public string OperRoomKey = "";
        public string InPacuTime = "";
        public int inTime = -1;
        public string InpNo = "";
        public string PatName = "";
        private List<MED_VITAL_SIGN> vitalSignAlarm = null;
        public string BedLabel = "";
        private bool _isSelected = false;
        private string _roomNo = string.Empty;
        private int stewardMark = 0;
        public event EventHandler OperRoomSelected;
        public event EventHandler Clicked;
        private readonly static object _doubleClickEventHandle = new object();
        public event EventHandler DoDoubleClick
        {
            add
            {
                Events.AddHandler(_doubleClickEventHandle, value);
            }
            remove
            {
                Events.RemoveHandler(_doubleClickEventHandle, value);
            }
        }
        private static int ClockPacuTick = 0;
        /// <summary>
        /// 手术间号
        /// </summary>
        public string RoomNo
        {
            get
            {
                return _roomNo;
            }
            set
            {
                _roomNo = value;
            }
        }
        private static readonly object _PACUDocClick = new object();
        public event EventHandler PACUDocClick
        {
            add
            {
                Events.AddHandler(_PACUDocClick, value);
            }
            remove
            {
                Events.RemoveHandler(_PACUDocClick, value);
            }
        }
        private static readonly object _OutPACUDocClick = new object();
        public event EventHandler OutPACUDocClick
        {
            add
            {
                Events.AddHandler(_OutPACUDocClick, value);
            }
            remove
            {
                Events.RemoveHandler(_OutPACUDocClick, value);
            }
        }
        /// <summary>
        ///清除患者手术间安排
        /// </summary>
        /// <param name="patientID"></param>
        private bool ClearPatientRoom(string patientID)
        {
            bool result = false;
            return result;
        }
        public void RefreshValue()
        {
            this.lbRoomNo.Text = "PACU-" + BedLabel;
            if (ApplicationConfiguration.IsPACUProgram)
                BedType = "1";
            if (string.IsNullOrEmpty(PatientID))
            {
                panelTop.Visible = false;
                panelMain.Visible = false;
                lblChangeRoom.Visible = false;
                lbInPacuTime.Visible = false;
                lblInPacuDoc.Visible = false;
                lblOutPacu.Visible = false;
            }
            else
            {
                panelTop.Visible = true;
                panelMain.Visible = true;
                lblChangeRoom.Visible = true;
                lbInPacuTime.Visible = true;
                lblInPacuDoc.Visible = true;
                lblOutPacu.Visible = true;
                RefreshInfo();
                RefreshVitalSign();
            }
            SetRoomStyle();
        }
        /// <summary>
        /// 设置是否选中
        /// </summary>
        public bool IsSelected
        {
            set
            {
                _isSelected = value;
                if (value)
                {
                    this.BackgroundImage = Resources.PACU_card_选中状态;
                    if (OperRoomSelected != null)
                    {
                        OperRoomSelected(this, EventArgs.Empty);
                    }
                }
                else
                {
                    this.BackgroundImage = null;
                }
            }
            get
            {
                return _isSelected;
            }
        }
        public void AddPACUInfo(MED_PATIENT_CARD patientCard, OperationRoomContent operContent)
        {
            if (!patientCard.IN_PACU_DATE_TIME.HasValue && patientCard.OPER_STATUS_CODE == 40)
            {
                TimeInPutFrmPC timeInput = new TimeInPutFrmPC();
                timeInput.Text = "入PACU时间";
                if (timeInput.ShowDialog() != DialogResult.Cancel)
                {
                    string roomNo = operContent.RoomNo;
                    List<MED_OPERATING_ROOM> operatingRoomList = comnDictRepository.GetOperatingRoomList(operContent.BedType).Data;
                    if (operatingRoomList != null && operatingRoomList.Count > 0)
                        operatingRoomList = operatingRoomList.Where(x => x.DEPT_CODE == ExtendApplicationContext.Current.OperRoom).ToList();
                    MED_OPERATION_MASTER operMaster = operationInfoRepository.GetOperMaster(ExtendApplicationContext.Current.PatientContextExtend.PatientID, 
                        ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID).Data;
                    if (operMaster != null)
                    {
                        if (operMaster.OUT_DATE_TIME.HasValue)
                        {
                            if (timeInput.SelectedDateTime.AddSeconds(0 - timeInput.SelectedDateTime.Second) < operMaster.OUT_DATE_TIME)
                            {
                                MessageBoxFormPC.Show("【入复苏室】 时间 [" + timeInput.SelectedDateTime + "] 小于 【出手术室】时间 [" + operMaster.OUT_DATE_TIME + "]，请重新输入！",
                   "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
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
                    if (string.IsNullOrEmpty(roomNo))
                    {
                        return;
                    }
                    {

                        bool isUpdate = new OperatingRoomRepository().SetOperatingRoomPatient(operatingRoomList, roomNo, ExtendApplicationContext.Current.OperRoom, patientCard.PATIENT_ID
                              , patientCard.VISIT_ID, patientCard.OPER_ID);
                        if (isUpdate)
                        {
                            new OperatingRoomRepository().SetOperMaster(patientCard.PATIENT_ID, patientCard.VISIT_ID, patientCard.OPER_ID, "IN_PACU_DATE_TIME", timeInput.SelectedDateTime, 45);
                            // CommDictService.SaveOperatingRommList(operatingRoomList);
                            new OperatingRoomRepository().SetMonitorDictPatient(operContent.BedType, ExtendApplicationContext.Current.OperRoom, roomNo, patientCard.PATIENT_ID
                                 , patientCard.VISIT_ID, patientCard.OPER_ID);
                            patientCard.OPER_STATUS_CODE = 45;
                            patientCard.IN_PACU_DATE_TIME = timeInput.SelectedDateTime;
                            ExtendApplicationContext.Current.PatientInformationExtend = patientCard;
                        }
                    }
                    RefreshControl(roomNo, operContent.BedType);
                }
            }
        }
        /// <summary>
        /// 刷新手术间组件
        /// </summary>
        public void RefreshControl(string roomNo, string bedType)
        {
            List<MED_OPERATING_ROOM> operRoom = comnDictRepository.GetOperatingRoomList(bedType).Data;
            if (operRoom != null && operRoom.Count > 0)
                operRoom = operRoom.Where(x => x.DEPT_CODE == ExtendApplicationContext.Current.OperRoom).ToList();
            MED_OPERATING_ROOM room = operRoom.Where(x => x.ROOM_NO == roomNo).FirstOrDefault();
            if (room != null)
            {
                BedLabel = room.BED_LABEL;
                OperRoomNo = room.ROOM_NO;
                OperRoomKey = room.ROOM_NO;
                BedType = bedType;
                if (!string.IsNullOrEmpty(room.PATIENT_ID))
                {
                    PatientID = room.PATIENT_ID;
                    VisitID = room.VISIT_ID.Value;
                    OperID = room.OPER_ID.Value;
                }
                else
                {
                    PatientID = "";
                    VisitID = 0;
                    OperID = 0;
                    InpNo = "";
                    PatName = "";
                }
                RefreshValue();
            }
        }
        /// <summary>
        /// 刷新手术间组件
        /// </summary>
        public void RefreshControl(string bedType)
        {
            List<MED_OPERATING_ROOM> operRoom = comnDictRepository.GetOperatingRoomList(bedType).Data;
            if (operRoom != null && operRoom.Count > 0)
                operRoom = operRoom.Where(x => x.DEPT_CODE == ExtendApplicationContext.Current.OperRoom).ToList();
            foreach (MED_OPERATING_ROOM room in operRoom)
            {
                BedLabel = room.BED_LABEL;
                OperRoomNo = room.ROOM_NO;
                OperRoomKey = room.ROOM_NO;
                BedType = bedType;
                if (!string.IsNullOrEmpty(room.PATIENT_ID))
                {
                    PatientID = room.PATIENT_ID;
                    VisitID = room.VISIT_ID.Value;
                    OperID = room.OPER_ID.Value;
                }
                else
                {
                    PatientID = "";
                    VisitID = 0;
                    OperID = 0;
                    InpNo = "";
                    PatName = "";
                }
                RefreshValue();
            }
        }
        private void RefreshVitalSign()
        {
            //string eventNo = ApplicationConfiguration.IsPACUProgram ? "1" : "0";
            //List<MED_VITAL_SIGN> vitalSignList = new OperationVitalSignService().GetVitalSignData(PatientID, VisitID, OperID, eventNo, false);
            //List<MED_VITAL_SIGN> vitalSignListOrder = vitalSignList.OrderByDescending(p => p.TIME_POINT).ToList();
            //vitalSignAlarm = new PatientSignWarning().SetSignAlarmInfo(vitalSignList);
            //DateTime currentTime = DateTime.MinValue;
            //if (vitalSignListOrder != null && vitalSignListOrder.Count > 0)
            //{
            //    currentTime = vitalSignListOrder[0].TIME_POINT;
            //}
            //lblCurrentTime.Text = currentTime != DateTime.MinValue ? currentTime.ToString("HH:mm") : DateTime.Now.ToString("HH:mm");
            //vitalSignListOrder = vitalSignList.Where(p => p.TIME_POINT == currentTime).ToList();
            //string temperature = "", pulse = "", breath = "", preHeight = "", preLow = "";
            //bool temAlarm = false, pulseAlarm = false, breathAlarm = false, preHAlarm = false, preLAlarm = false;
            //Color color = Color.White;
            //foreach (MED_VITAL_SIGN row in vitalSignListOrder)
            //{
            //    if (row.ITEM_CODE == "100") //体温
            //    {
            //        temperature = row.ITEM_VALUE;
            //        temAlarm = IsAlarm(row.TIME_POINT, row.ITEM_CODE);
            //    }
            //    if (row.ITEM_CODE == "44")//脉搏
            //    {
            //        pulse = row.ITEM_VALUE;
            //        pulseAlarm = IsAlarm(row.TIME_POINT, row.ITEM_CODE);
            //    }
            //    if (row.ITEM_CODE == "92")//呼吸
            //    {
            //        breath = row.ITEM_VALUE;
            //        breathAlarm = IsAlarm(row.TIME_POINT, row.ITEM_CODE);
            //    }
            //    if (row.ITEM_CODE == "89")//血压高
            //    {
            //        preHeight = row.ITEM_VALUE;
            //        preHAlarm = IsAlarm(row.TIME_POINT, row.ITEM_CODE);
            //    }
            //    if (row.ITEM_CODE == "90")//血压低
            //    {
            //        preLow = row.ITEM_VALUE;
            //        preLAlarm = IsAlarm(row.TIME_POINT, row.ITEM_CODE);
            //    }
            //}
            //lblTemperature.Text = string.IsNullOrEmpty(temperature) ? "体温" : "体温  " + temperature;
            //SetSignStyle(lblTemperature, temAlarm, color);

            //lblPulse.Text = string.IsNullOrEmpty(pulse) ? "脉搏" : "脉搏    " + pulse;
            //SetSignStyle(lblPulse, pulseAlarm, color);

            //lblBreathed.Text = string.IsNullOrEmpty(breath) ? "呼吸" : "呼吸    " + breath;
            //SetSignStyle(lblBreathed, breathAlarm, color);

            //if (string.IsNullOrEmpty(preHeight) && string.IsNullOrEmpty(preLow))
            //{
            //    lblBloodPressure.Text = "血压";
            //}
            //else
            //{
            //    lblBloodPressure.Text = "血压" + preHeight + "/" + preLow;
            //}
            //SetSignStyle(lblBloodPressure, (preHAlarm | preLAlarm), color);
            //if (vitalSignAlarm != null && vitalSignAlarm.Count > 0)
            //{
            //    SetRoomStyle();
            //}
        }
        private bool IsAlarm(DateTime timePoint, string itemCode)
        {
            bool isAlarm = false;
            //if (vitalSignAlarm != null && vitalSignAlarm.Count > 0)
            //{
            //    List<MED_VITAL_SIGN> vitalSign = vitalSignAlarm.Where(p => p.TIME_POINT == timePoint && p.ITEM_CODE == itemCode).ToList();
            //    if (vitalSign != null && vitalSign.Count > 0)
            //        isAlarm = true;
            //}
            return isAlarm;
        }
        private void SetSignStyle(Label label, bool isAlarm, Color color)
        {
            //if (isAlarm)
            //    label.ForeColor = Color.FromArgb(240, 69, 101);
            //else
            //    label.ForeColor = color;
        }
        private void RefreshInfo()
        {
            _patientCard = patientInfoRepository.GetPatCard(PatientID, VisitID, OperID).Data;
            if (_patientCard != null)
            {
                InpNo = _patientCard.INP_NO;
                PatName = _patientCard.NAME;
                if (_patientCard.SEX == "男")
                {
                    pictureBoxSex.Image = Resources.男;
                }
                else if (_patientCard.SEX == "女")
                {
                    pictureBoxSex.Image = Resources.女;
                }
                lbPatientName.Text = _patientCard.NAME;
                lblAge.Text = _patientCard.AGE;
                lblInPacuTime.Text = _patientCard.IN_PACU_DATE_TIME.Value.ToString("HH:mm");

                lblOutRoomTime.Text = _patientCard.OUT_DATE_TIME.Value.ToString("HH:mm");
                //  lbPatientID.Text = _patientCard.PATIENT_ID + "    " + RefareshDeptCode(_patientCard.DEPT_CODE) + "    " + _patientCard.BED_NO;
                lbOperName.Text = _patientCard.OPERATION_NAME + "  " + _patientCard.OPER_POSITION;
                lblAnesMethod.Text = _patientCard.ANES_METHOD;
                lblProcedures.Text = string.Format("术者:{0}{1}           主麻:{2}{3}", RefareshHisUsers(_patientCard.SURGEON), RefareshHisUsers(_patientCard.FIRST_OPER_ASSISTANT), RefareshHisUsers(_patientCard.ANES_DOCTOR), RefareshHisUsers(_patientCard.FIRST_ANES_ASSISTANT));
                TimeSpan span = (TimeSpan)(_patientCard.OUT_DATE_TIME - _patientCard.IN_DATE_TIME);
                int hour = span.Days * 24;
                // lbloperTime.Text = "手术时长：" + hour + span.Hours + "小时" + span.Minutes + "分钟";
                //  lbInRoomTime.Text = _patientCard.IN_DATE_TIME.Value.ToString("HH:mm");
                // lbAnesStartTime.Text = _patientCard.ANES_START_TIME.Value.ToString("HH:mm");
                // lbOperStartTime.Text = _patientCard.START_DATE_TIME.Value.ToString("HH:mm");
                // lbOperEndTime.Text = _patientCard.END_DATE_TIME.Value.ToString("HH:mm");
                // lbAnesEndTime.Text = _patientCard.ANES_END_TIME.Value.ToString("HH:mm");
                // lbOutRomTime.Text = _patientCard.OUT_DATE_TIME.Value.ToString("HH:mm");


                lblAware.Text = string.IsNullOrEmpty(_patientCard.INP_NO) ? "住院号：" : _patientCard.INP_NO;
                lblPupil.Text = string.IsNullOrEmpty(_patientCard.DEPT_CODE) ? "科室：" : RefareshDeptCode(_patientCard.DEPT_CODE);
                lblIntubation.Text = string.IsNullOrEmpty(_patientCard.BED_NO) ? "床号：" : _patientCard.BED_NO;
                // lbloperTime 
            }
            //MED_CONFIRMATION_PACU confirmationPACU = OperationInfoService.GetConfirmationPACU(PatientID, VisitID, OperID, 45);
            //if (confirmationPACU != null)
            //{
            //    lblAware.Text = string.IsNullOrEmpty(patient) ? "住院号：" : "住院号：" + confirmationPACU.CONSCIOUSNESS;
            //    lblPupil.Text = string.IsNullOrEmpty(confirmationPACU.PUPIL) ? "科室：" : "科室：" + confirmationPACU.PUPIL;
            //    lblIntubation.Text = string.IsNullOrEmpty(confirmationPACU.PUPIL) ? "床号：" : "床号：" + confirmationPACU.PUPIL;
            //}
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

        public void OnTicked()
        {
            if (_patientCard != null && _patientCard.IN_PACU_DATE_TIME.HasValue)
            {
                DateTime startTime = _patientCard.IN_PACU_DATE_TIME.Value;
                DateTime endTime = accountRepository.GetServerTime().Data;
                inTime = (int)((TimeSpan)(endTime - startTime)).TotalMinutes;
                lbInPacuTime.Text = inTime.ToString() + "min";
                if (((TimeSpan)(endTime - startTime)).TotalMinutes > ApplicationConfiguration.EarlyWarningTime)
                {
                    lbInPacuTime.ForeColor = Color.FromArgb(240, 69, 101);
                    // SetRoomStyle();
                }
                else { lbInPacuTime.ForeColor = Color.FromArgb(92, 92, 92); }
            }
            else
            {
                lbInPacuTime.Text = "0 min";
            }
        }
        /// <summary>
        ///选中卡片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SelectRoomContent(object sender, EventArgs e)
        {
            IsSelected = true;
        }
        public void CancelFocus()
        {
            IsSelected = false;
        }
        private void SetRoomStyle()
        {
            if (string.IsNullOrEmpty(PatientID))
            {
                panelMainControl.BackgroundImage = Resources.PACU_card_空闲状态;
                this.BackgroundImage = null;
            }
            else
            {
                panelMainControl.BackgroundImage = Resources.PACU_card_pacu状态;
            }
        }
        private void OperationRoomContent_DragDrop(object sender, DragEventArgs e)
        {
            this.IsSelected = true;
            if (e.Data.GetDataPresent(typeof(MED_PATIENT_CARD)))
            {
                MED_PATIENT_CARD patientCard = (MED_PATIENT_CARD)(e.Data.GetData(typeof(MED_PATIENT_CARD)));
                AddPACUInfo(patientCard, sender as OperationRoomContent);
            }
        }

        private void OperationRoomContent_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void OperationRoomContent_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && ApplicationConfiguration.IsPACUProgram)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                ToolStripMenuItem item = new ToolStripMenuItem("取消入复苏室");
                item.Click += new EventHandler(delegate(object sender1, EventArgs e1)
                {
                    OperationRoomContent operContent = sender as OperationRoomContent;
                    string roomNo = operContent.OperRoomNo;
                    List<MED_OPERATING_ROOM> operatingRoomList = comnDictRepository.GetOperatingRoomList(operContent.BedType).Data;
                    if (operatingRoomList != null && operatingRoomList.Count > 0)
                        operatingRoomList = operatingRoomList.Where(x => x.DEPT_CODE == ExtendApplicationContext.Current.OperRoom).ToList();
                    if (string.IsNullOrEmpty(roomNo) || string.IsNullOrEmpty(operContent.PatientID))
                    {
                        return;
                    }
                    else
                    {
                        new OperatingRoomRepository().SetOperatingRoomPatient(operatingRoomList, roomNo, ExtendApplicationContext.Current.OperRoom, "", 0, 0);
                        new OperatingRoomRepository().SetOperMaster(operContent.PatientID, operContent.VisitID, operContent.OperID, "IN_PACU_DATE_TIME", DateTime.MinValue, 40);
                        // CommDictService.SaveOperatingRommList(operatingRoomList);
                        new OperatingRoomRepository().SetMonitorDictPatient(operContent.BedType, ExtendApplicationContext.Current.OperRoom, roomNo, "", 0, 0);
                    }
                    var patListView = (Form.ActiveForm as MainFrm)._patients;
                    //patListView.RefreshPatientDataTable(operContent.PatientID, operContent.VisitID, operContent.OperID);
                    patListView.BeginInvoke(new Action(patListView.RefreshPatientDataTable),
                        new object[] { operContent.PatientID, operContent.VisitID, operContent.OperID });
                    RefreshControl(roomNo, operContent.BedType);
                });
                menu.Items.Add(item);
                menu.Show(Control.MousePosition);
            }
        }

        private void OperationRoomContent_Paint(object sender, PaintEventArgs e)
        {
            Graphics gac = e.Graphics;
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            if (string.IsNullOrEmpty(PatientID))
            {
                gac.DrawString("PACU-" + BedLabel, new Font("Tahoma", 40F), new SolidBrush(Color.FromArgb(139, 204, 251)), this.ClientRectangle, sf);
            }
            else
            {
                gac.DrawString("PACU-" + BedLabel, new Font("Tahoma", 10F), new SolidBrush(Color.White), this.ClientRectangle, sf);
            }

        }
        /// <summary>
        /// 修改体征
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblDetection_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(PatientID))
            {
                SelectRoomContent(sender, e);
                PatMonitorEditor monitoeEditor = new PatMonitorEditor(PatientID, VisitID, OperID, ExtendApplicationContext.Current.EventNo);
                DialogHostFormPC dialogHostForm = new DialogHostFormPC(monitoeEditor.Caption, monitoeEditor.Width, monitoeEditor.Height);
                dialogHostForm.Child = monitoeEditor;
                dialogHostForm.Text = "修改体征数据";
                dialogHostForm.ShowDialog();
                RefreshVitalSign();
            }
        }
        /// <summary>
        /// 入室评估
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblBurglaryAssessment_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(PatientID))
            {
                SelectRoomContent(sender, e);
                ConfirmationInPacu inPacu = new ConfirmationInPacu(PatientID, VisitID, OperID, true);
                DialogHostFormPC dialogHostForm = new DialogHostFormPC("入室信息确认", inPacu.Width, inPacu.Height);
                dialogHostForm.Child = inPacu;
                dialogHostForm.ShowDialog();
                if (inPacu.result == DialogResult.OK)
                {
                    RefreshInfo();
                }
                // 当前患者未进行苏醒评分，不满足出室条件，是否强制出室？
            }
        }
        /// <summary>
        /// 进入PACU复苏单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblInPacuDoc_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(PatientID))
            {
                SelectRoomContent(sender, e);
                EventHandler eventHandle = Events[_PACUDocClick] as EventHandler;
                if (eventHandle != null)
                {
                    eventHandle(this, e);
                }
            }
        }
        /// <summary>
        /// 出复苏室
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblOutPacu_Click(object sender, EventArgs e)
        {
            SelectRoomContent(sender, e);
            ConfirmationOutPacu outPacu = new ConfirmationOutPacu(OperRoomNo, PatientID, VisitID, OperID, DateTime.MinValue);
            DialogHostFormPC dialogForm = new DialogHostFormPC("出室信息确认", outPacu.Width, outPacu.Height);
            dialogForm.Child = outPacu;
            dialogForm.ShowDialog();
            if (outPacu.result == DialogResult.OK)
            {
                RefreshControl(OperRoomNo, BedType);
                inTime = -1;
                EventHandler eventHandle = Events[_OutPACUDocClick] as EventHandler;
                if (eventHandle != null)
                {
                    eventHandle(this, e);
                }
            }
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OperationRoomContent_Load(object sender, EventArgs e)
        {
            if (!DesignMode) MainFrm.MainTickFrm.Register(this);
        }

        private void lbRoomNo_Click(object sender, EventArgs e)
        {
            SelectRoomContent(sender, e);
            lbRoomNo.ForeColor = Color.FromArgb(255, 255, 255);
            SetRoomStyle();
        }

        private void labelInfo_Click(object sender, EventArgs e)
        {
            SelectRoomContent(sender, e);
            lbRoomNo.ForeColor = Color.FromArgb(92, 92, 92);
            SetRoomStyle();
        }

        private void lblInPacuDoc_MouseMove(object sender, MouseEventArgs e)
        {
            lblInPacuDoc.BackgroundImage = Resources.右下图标1_2;
        }

        private void lblInPacuDoc_MouseLeave(object sender, EventArgs e)
        {
            lblInPacuDoc.BackgroundImage = Resources.右下图标1_1;
        }

        private void lblOutPacu_MouseMove(object sender, MouseEventArgs e)
        {
            lblOutPacu.BackgroundImage = Resources.右下图标2_2;
        }

        private void lblOutPacu_MouseLeave(object sender, EventArgs e)
        {
            lblOutPacu.BackgroundImage = Resources.右下图标2_1;
        }
        private void RaiseDoubleClick()
        {
            EventHandler eventHandle = Events[_doubleClickEventHandle] as EventHandler;
            if (eventHandle != null)
            {
                eventHandle(this, null);
            }
        }
        private void OperationRoomContent_Click(object sender, EventArgs e)
        {
            if (Clicked != null)
                Clicked(this, EventArgs.Empty);
            IsSelected = true;
            RaiseDoubleClick();
            this.Focus();
        }

        private void panelPacu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblChangeRoom_DoubleClick(object sender, EventArgs e)
        {
            ChangePacuRoom changePacuRoom = new ChangePacuRoom(PatientID, VisitID, OperID);
            DialogHostFormPC dialogHostForm = new DialogHostFormPC("更换床位", changePacuRoom.Width, changePacuRoom.Height);
            dialogHostForm.Child = changePacuRoom;
            dialogHostForm.ShowDialog();
            if (changePacuRoom.result == DialogResult.OK)
            {
                RefreshControl(OperRoomNo, BedType);
                EventHandler eventHandle = Events[_OutPACUDocClick] as EventHandler;
                if (eventHandle != null)
                {
                    eventHandle(this, e);
                }
            }
        }

    }
}
