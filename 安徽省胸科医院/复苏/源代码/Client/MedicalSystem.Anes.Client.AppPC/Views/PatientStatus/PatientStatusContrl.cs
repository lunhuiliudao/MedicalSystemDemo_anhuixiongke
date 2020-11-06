using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Domain;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.Client.Repository;
using MedicalSystem.Services;

namespace MedicalSystem.Anes.Client.AppPC
{
    [Serializable(), ToolboxItem(true)]
    public partial class PatientStatusContrl : UserControl
    {
        ComnDictRepository comnDictRepository = new ComnDictRepository();

        PatientInfoRepository patientInfoRepository = new PatientInfoRepository();

        OperationInfoRepository operationInfoRepository = new OperationInfoRepository();

        AccountRepository accountRepository = new AccountRepository();

        OperationScheduleRepository operationScheduleRepository = new OperationScheduleRepository();

        SyncInfoRepository syncInfoRepository = new SyncInfoRepository();

        public enum OperationLightStatus
        {
            Nomal = 0,
            Passed = 1,
            Light = 2

        }
        private bool FlagTip = false;
        public PatientStatusContrl()
        {
            InitializeComponent();
        }
        protected Dictionary<string, DateTime> _outPatients = new Dictionary<string, DateTime>();

        private IPatientStatusAction patientStatusAction = null;
        public void SetPatientStatusAction(IPatientStatusAction patientStatusAction)
        {
            this.patientStatusAction = patientStatusAction;
        }
        private IOperationStatusObserver _ServiceObject = null;
        /// <summary>
        /// 该 SinglePatientStatusConrol 服务的控件
        /// </summary>
        public IOperationStatusObserver ServiceObject
        {
            get { return _ServiceObject; }
            set { _ServiceObject = value; }
        }
        private static readonly object _refreshPatient = new object();
        public event EventHandler RefreshPatientHandler
        {
            add
            {
                Events.AddHandler(_refreshPatient, value);
            }
            remove
            {
                Events.RemoveHandler(_refreshPatient, value);
            }
        }


        private void RaiseRefreshPatient()
        {
            EventHandler eventHandle = Events[_refreshPatient] as EventHandler;
            if (eventHandle != null)
            {
                eventHandle(this, null);
            }
        }

        /// <summary>
        /// 生成状态按钮
        /// </summary>
        public void CreatePatientStatusButtons(string sPatientStatus)
        {
            this.panelMain.Controls.Clear();
            //判断是否为有效状态
            if (sPatientStatus.Length <= 0)
            {
                return;
            }
            string[] buttons = sPatientStatus.Split(',');
            PatientStatusSingleControl singlePatientStatusConrol = null;
            int btnLeft = 5;
            int btnSpace = 5;
            for (int i = 0; i < buttons.Length; i++)
            {
                singlePatientStatusConrol = new PatientStatusSingleControl();
                singlePatientStatusConrol.StatusName = buttons[i];
                singlePatientStatusConrol.Name = "S" + singlePatientStatusConrol.StatusName;

                singlePatientStatusConrol.BackgroundImageLayout = ImageLayout.Stretch;
                singlePatientStatusConrol.SetStatusLightImage(OperationLightStatus.Nomal);
                singlePatientStatusConrol.Dock = DockStyle.Left;

                //注册观察项
                singlePatientStatusConrol.ServicePatientStatusContrl = this;
                this.panelMain.Controls.Add(singlePatientStatusConrol);
                singlePatientStatusConrol.BringToFront();
            }
            //注册观察项
            singlePatientStatusConrol.ServicePatientStatusContrl = this;
            this.panelMain.Controls.Add(singlePatientStatusConrol);
            singlePatientStatusConrol.BringToFront();
        }
        /// <summary>
        /// 设置手术状态灯
        /// </summary>
        /// <param name="operationStatus"></param>
        public void SetStatusLight(OperationStatus operationStatus)
        {
            int operationStatusValue = (int)operationStatus;
            foreach (PatientStatusSingleControl singlePatientStatusConrol in this.panelMain.Controls)
            {
                int operationStatusValueTemp = (int)OperationStatusHelper.OperationStatusFromString(singlePatientStatusConrol.StatusName);
                if (operationStatusValueTemp == -99 || !singlePatientStatusConrol.picLightImage.Visible)
                {
                    if (!ApplicationConfiguration.IsPACUProgram && operationStatus > OperationStatus.OutOperationRoom && operationStatus < OperationStatus.TurnToSickRoom)
                        singlePatientStatusConrol.SetStatusLightImage(OperationLightStatus.Passed);
                    else
                        singlePatientStatusConrol.SetStatusLightImage(OperationLightStatus.Light);
                }
                else if (operationStatusValueTemp < operationStatusValue)
                {
                    singlePatientStatusConrol.SetStatusLightImage(OperationLightStatus.Passed);
                }
                else if (operationStatusValueTemp == operationStatusValue)
                {
                    singlePatientStatusConrol.SetStatusLightImage(OperationLightStatus.Light);
                }
                else
                {
                    singlePatientStatusConrol.SetStatusLightImage(OperationLightStatus.Nomal);
                }
            }
        }
        /// <summary>
        /// 设置手术状态按扭时间
        /// </summary>
        /// <param name="operationStatus"></param>
        public void SetOperationStatusTimeText(OperationStatus operationStatus)
        {
            int operationStatusValue = (int)operationStatus;
            OperationStatus operStatus = OperationStatus.None;
            MED_OPERATION_MASTER operMaster = operationInfoRepository.GetOperMaster(ExtendApplicationContext.Current.PatientContextExtend.PatientID,
                ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID).Data;

            //判断 GetTimeFieldName
            if (operMaster != null)
            {
                foreach (PatientStatusSingleControl singlePatientStatusConrol in this.panelMain.Controls)
                {
                    int operationStatusValueTemp = (int)OperationStatusHelper.OperationStatusFromString(singlePatientStatusConrol.StatusName);
                    //先时间清空数据,
                    singlePatientStatusConrol.SetOperationStatusTimeText(DateTime.MinValue);
                    if (operationStatusValueTemp <= operationStatusValue)
                    {
                        operStatus = OperationStatusHelper.OperationStatusFromString(singlePatientStatusConrol.StatusName);
                        //获取字段
                        string dtField = OperationStatusHelper.GetTimeFieldName(operStatus);

                        OperationStatusHelper.GetTimeFieldName(operStatus);
                        DateTime StatusTime = DateTime.MinValue;
                        if (ApplicationConfiguration.IsPACUProgram && operationStatusValue >= (int)OperationStatus.TurnToSickRoom)
                        {
                            if (operMaster.IN_PACU_DATE_TIME.HasValue)
                            {
                                if (!string.IsNullOrEmpty(operMaster.GetValue(dtField).ToString()))
                                {
                                    StatusTime = Convert.ToDateTime(operMaster.GetValue(dtField));
                                }
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(operMaster.GetValue(dtField).ToString()))
                            {
                                StatusTime = Convert.ToDateTime(operMaster.GetValue(dtField));
                            }
                        }
                        singlePatientStatusConrol.SetOperationStatusTimeText(StatusTime);
                    }
                    else
                    {
                        singlePatientStatusConrol.Enabled = true;
                    }

                }
            }


        }
        /// <summary>
        /// 验证时间
        /// </summary>
        /// <param name="singleConrol">控件本身</param>
        /// <param name="validateFlag">验证标志位 0无特殊消息 1当前控件时间为空 2当前控件时间不合规范 3 多页提示</param>
        public bool OnSinglePatientStatusConrolTimeValidate(PatientStatusSingleControl singleConrol)
        {
            int operationStatusValue = (int)OperationStatusHelper.OperationStatusFromString(singleConrol.StatusName);
            if (singleConrol.ConrolLightStatus != OperationLightStatus.Nomal && operationStatusValue >= 5)
            {
                if (singleConrol.IsDateTimeEmpty())
                {
                    if (singleConrol.Enabled)
                    {
                        MessageBoxFormPC.Show("【" + singleConrol.StatusName + "】 时间 不能为空，请重新输入！",
                                       "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else
                    {
                        singleConrol.RobackTime();
                    }
                }
            }
            if (singleConrol.IsDateTimeEmpty()) return true;
            if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
            {
                MED_OPERATION_MASTER operMaster = operationInfoRepository.GetOperMaster(ExtendApplicationContext.Current.PatientContextExtend.PatientID,
                    ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID).Data;

                if (operMaster != null)
                {
                    if (operMaster.OUT_DATE_TIME.HasValue)
                    {
                        if (singleConrol.ControlDateTime < operMaster.OUT_DATE_TIME)
                        {
                            if (singleConrol.Enabled)
                            {
                                MessageBoxFormPC.Show("【" + singleConrol.StatusName + "】 时间 [" + singleConrol.ControlDateTime + "] 小于 【出手术室】时间 [" + operMaster.OUT_DATE_TIME + "]，请重新输入！",
              "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                            else
                            {
                                singleConrol.RobackTime();
                            }
                        }
                    }
                }
            }
            //循环判断前面的状态是否有时间未输入
            foreach (PatientStatusSingleControl singlePatientStatusConrol in this.panelMain.Controls)
            {
                int operationStatusValueTemp = (int)OperationStatusHelper.OperationStatusFromString(singlePatientStatusConrol.StatusName);

                //判断前面的状态是否有时间未输入
                if (operationStatusValueTemp < operationStatusValue)
                {
                    if (!singlePatientStatusConrol.IsDateTimeEmpty())
                    {
                        //判断时间录入是否正确
                        if (singlePatientStatusConrol.ControlDateTime > singleConrol.ControlDateTime)
                        {
                            if (singleConrol.Enabled)
                            {
                                MessageBoxFormPC.Show("【" + singlePatientStatusConrol.StatusName + "】 时间 [" + singlePatientStatusConrol.ControlDateTime + "] 大于 【" + singleConrol.StatusName + "】时间 [" + singleConrol.ControlDateTime + "]，请重新输入！",
                                    "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                            else
                            {
                                singleConrol.RobackTime();
                            }
                        }

                    }
                }
                else
                {
                    if (!singlePatientStatusConrol.IsDateTimeEmpty())
                    {
                        //判断时间录入是否正确
                        if (singlePatientStatusConrol.ControlDateTime < singleConrol.ControlDateTime)
                        {
                            if (singleConrol.Enabled)
                            {
                                MessageBoxFormPC.Show("【" + singleConrol.StatusName + "】 时间[" + singleConrol.ControlDateTime + "]  大于 【" + singlePatientStatusConrol.StatusName + "】时间[" + singlePatientStatusConrol.ControlDateTime + "] ，请重新输入！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                            else
                            {
                                singleConrol.RobackTime();
                            }
                        }
                    }

                }
            }
            string info = "麻醉单";
            if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
            {
                info = "复苏单";
            }
            //录入正确的话 判断是否 翻页 翻页的话 提示
            //if (!FlagTip)
            //{
            //    foreach (PatientStatusSingleControl singlePatientStatusConrol in this.panelMain.Controls)
            //    {
            //        int operationStatusValueTemp = (int)OperationStatusHelper.OperationStatusFromString(singlePatientStatusConrol.StatusName);
            //        if (!singlePatientStatusConrol.IsDateTimeEmpty())
            //        {
            //            if (singleConrol.ControlDateTime > singlePatientStatusConrol.ControlDateTime.AddHours(ExtendApplicationContext.Current.AnesDocPageHours))
            //            {
            //                if (singleConrol.Enabled)
            //                {
            //                    DialogResult dialogRes = MessageBoxFormPC.Show("您输入的 【" + singleConrol.StatusName + "】 时间 [" + singleConrol.ControlDateTime + "] 将会造成" + info + "多页，是否继续？",
            //                     "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //                    //validateFlag = 3; //验证标志位:0 =无特殊消息 1=当前控件时间为空 2=当前控件时间不合规范 3=存在多页提示
            //                    FlagTip = true;
            //                    if (dialogRes == DialogResult.No)
            //                    {
            //                        return false;
            //                    }
            //                    else
            //                    {
            //                        break;
            //                    }

            //                }
            //                else
            //                {
            //                    singleConrol.RobackTime();
            //                }
            //            }
            //            else if (singleConrol.ControlDateTime < singlePatientStatusConrol.ControlDateTime.AddHours(-ExtendApplicationContext.Current.AnesDocPageHours))
            //            //End Modify
            //            {
            //                if (singleConrol.Enabled)
            //                {
            //                    DialogResult dialogRes = MessageBoxFormPC.Show("您输入的 【" + singleConrol.StatusName + "】 时间 [" + singleConrol.ControlDateTime + "] 将会造成" + info + "多页，是否继续？",
            //                    "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //                    //validateFlag = 3; //验证标志位:0 =无特殊消息 1=当前控件时间为空 2=当前控件时间不合规范 3=存在多页提示
            //                    FlagTip = true;
            //                    if (dialogRes == DialogResult.No)
            //                    {
            //                        singleConrol.RobackTime();
            //                        return false;
            //                    }
            //                    else
            //                    {
            //                        break;
            //                    }
            //                }
            //                else
            //                {
            //                    singleConrol.RobackTime();
            //                }
            //            }
            //        }
            //    }
            //}
            SetValueAndUpdateStatus(singleConrol);
            return true;


        }
        /// <summary>
        /// 设置时间值更新状态
        /// </summary>
        private void SetValueAndUpdateStatus(PatientStatusSingleControl singleConrol)
        {
            //设置控件样式
            if (singleConrol.IsDateTimeEmpty())
            {
                singleConrol.SetStyle(false);
            }
            else
            {
                singleConrol.SetStyle(true);
                //更新时间和状态
                OperationStatus operationStatusNew = OperationStatusHelper.OperationStatusFromString(singleConrol.StatusName);
                OperationStatus operationStatusNow = ExtendApplicationContext.Current.OperationStatus;

                if ((int)operationStatusNew > (int)operationStatusNow)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatusNew, singleConrol.ControlDateTime, true, operationStatusNow))
                    {
                        NoifyOperationStatusChange(operationStatusNew);
                    }
                }
                else
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatusNew, singleConrol.ControlDateTime, false, operationStatusNow))
                    {
                        NoifyOperationTimeChange();
                    }
                }
                //更新Schedule表中 Status
                if (operationStatusNew == OperationStatus.InOperationRoom || operationStatusNew == OperationStatus.AnesthesiaStart || operationStatusNew == OperationStatus.OperationStart)
                {
                    List<MED_OPERATION_SCHEDULE> operSchedule = operationInfoRepository.GetOperScheduleList(ExtendApplicationContext.Current.PatientContextExtend.PatientID,
                        ExtendApplicationContext.Current.PatientContextExtend.VisitID).Data;
                    if (operSchedule != null && operSchedule.Count > 0)
                    {
                        List<MED_OPERATION_SCHEDULE> schedule = operSchedule.Where(x => x.OPER_ID == ExtendApplicationContext.Current.PatientContextExtend.OperID).ToList();
                        if (schedule != null && schedule.Count > 0) schedule[0].OPER_STATUS_CODE = 3;
                        operationInfoRepository.SaveOperScheduleList(schedule);
                    }
                }

                //排班状态更新回传HIS
                if (operationStatusNew == OperationStatus.InOperationRoom || operationStatusNew == OperationStatus.OutOperationRoom)
                {
                    if (ApplicationConfiguration.IsUpdateScheduleStatus)
                    {
                        syncInfoRepository.SyncWriteHisOperStatus(ExtendApplicationContext.Current.PatientContextExtend.PatientID,
                            (int)ExtendApplicationContext.Current.PatientContextExtend.VisitID,
                            (int)ExtendApplicationContext.Current.PatientContextExtend.OperID, 0);
                    }
                }

                //手术状态更新，回传His
                if (operationStatusNew == OperationStatus.InOperationRoom || operationStatusNew == OperationStatus.OutOperationRoom)
                {
                    if (ApplicationConfiguration.IsUpdateHisStatus)
                    {
                        try
                        {
                            string ret = syncInfoRepository.SyncWriteHisOperStatus(ExtendApplicationContext.Current.PatientContextExtend.PatientID,
                                (int)ExtendApplicationContext.Current.PatientContextExtend.VisitID, (int)ExtendApplicationContext.Current.PatientContextExtend.OperID, 1).Data;

                        }
                        catch (Exception ex)
                        {
                            ExceptionHandler.Handle(ex);
                        }
                    }
                }
            }

        }

        public bool OnPatientStatusSingleControlKeyDown(PatientStatusSingleControl singleConrol)
        {
            if (string.IsNullOrEmpty(ExtendApplicationContext.Current.PatientContextExtend.PatientID))
            {
                MessageBoxFormPC.Show("还未选择患者，无法输入时间！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return CanEnterConrolTime(singleConrol);
        }
        private bool CanEnterConrolTime(PatientStatusSingleControl singleConrol)
        {
            //诱导室检查
            if (ExtendApplicationContext.Current.AppType == ApplicationType.YouDao)
            {
                if (singleConrol.StatusName.Equals("出诱导室"))
                    return true;
                //End Add
                List<MED_OPERATING_ROOM> roomDict = comnDictRepository.GetOperatingRoomList("3").Data;
                bool haslest = false;
                foreach (MED_OPERATING_ROOM row in roomDict)
                {
                    if (string.IsNullOrEmpty(row.PATIENT_ID))
                    {
                        haslest = true;
                        break;
                    }
                }
                if (haslest)
                {
                    return true;
                }
                else
                {
                    MessageBoxFormPC.Show(string.Format("诱导室无剩余床位"), "提示信息");
                    return false;
                }
            }
            //如果是PACU 不检查手术室，PACU室通常只有1个 只要检查床位
            if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
            {
                return true;
            }
            if (!AccessControl.CheckModifyRight("麻醉记录单"))
            {
                MessageBoxFormPC.Show(string.Format("您没有操作该文书的权限"), "提示信息");
                return false;
            }
            if (singleConrol.ConrolLightStatus == OperationLightStatus.Nomal)
            {
                //判断该手术室是否有其他病人 
                string roomNo = ExtendApplicationContext.Current.OperRoomNo;// ExtendApplicationContext.Current.PatientInformationExtend.OPER_ROOM_NO;
                List<MED_OPERATING_ROOM> roomList = comnDictRepository.GetOperatingRoomList("0").Data.Where(p => p.ROOM_NO == roomNo && p.DEPT_CODE == ExtendApplicationContext.Current.OperRoom).ToList();
                if (roomList != null && roomList.Count > 0)
                {
                    MED_OPERATING_ROOM operRoom = roomList[0];
                    if (!string.IsNullOrEmpty(operRoom.PATIENT_ID) && operRoom.PATIENT_ID != ExtendApplicationContext.Current.PatientContextExtend.PatientID)
                    {
                        MED_PATIENT_CARD cardRow = patientInfoRepository.GetPatCard(operRoom.PATIENT_ID, (int)operRoom.VISIT_ID, (int)operRoom.OPER_ID).Data;
                        MessageBoxFormPC.Show("该手术间" + operRoom.ROOM_NO + "已存在患者【" + cardRow.NAME + " " + cardRow.INP_NO + "】！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
            }
            //获取当前控件状态
            int operationStatusValue = (int)OperationStatusHelper.OperationStatusFromString(singleConrol.StatusName);
            //循环判断前面的状态是否有时间未输入
            bool LastHasValue = true;
            PatientStatusSingleControl lastCtrl = null;
            foreach (PatientStatusSingleControl singlePatientStatusConrol in this.panelMain.Controls)
            {
                if (!singlePatientStatusConrol.picLightImage.Visible) continue;
                int operationStatusValueTemp = (int)OperationStatusHelper.OperationStatusFromString(singlePatientStatusConrol.StatusName);
                if (!singleConrol.picLightImage.Visible)
                {
                    if (operationStatusValueTemp > operationStatusValue)
                    {
                        if (string.IsNullOrEmpty(singlePatientStatusConrol.ControlDateTime.ToString()) || singlePatientStatusConrol.ControlDateTime == DateTime.MinValue
                            || singlePatientStatusConrol.ControlDateTime == DateTime.MinValue)
                        {
                            LastHasValue = false;
                            lastCtrl = singlePatientStatusConrol;
                        }
                        //else
                        //{
                        //    LastHasValue = true;
                        //}
                    }
                }
                else
                { //判断前面的状态是否有时间未输入
                    if (operationStatusValueTemp < operationStatusValue)
                    {
                        if (string.IsNullOrEmpty(singlePatientStatusConrol.ControlDateTime.ToString()) || singlePatientStatusConrol.ControlDateTime == DateTime.MinValue
                             || singlePatientStatusConrol.ControlDateTime == DateTime.MinValue)
                        {
                            LastHasValue = false;
                            lastCtrl = singlePatientStatusConrol;
                        }
                        //else
                        //{
                        //    LastHasValue = true;
                        //}
                    }
                }

            }
            if (!LastHasValue && lastCtrl != null)
            {
                MessageBoxFormPC.Show("请先输入 【" + lastCtrl.StatusName + "】状态时间！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 更新患者状态或者时间
        /// </summary>
        /// <param name="operationStatus">新状态</param>
        /// <param name="dt">状态对应时间</param>
        /// <returns></returns>
        public bool UpdateOperationStatusOrStatusTime(OperationStatus operationStatus, DateTime dt, bool updateStatus, OperationStatus oldOperationStatus)
        {
            MED_OPERATION_MASTER operMaster = operationInfoRepository.GetOperMaster(ExtendApplicationContext.Current.PatientContextExtend.PatientID,
                ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID).Data;
            if (operMaster != null)
            {
                if (updateStatus)
                {
                    ///取消诱导室采集
                    if (oldOperationStatus == OperationStatus.InYouDao || oldOperationStatus == OperationStatus.InPACU)
                    {
                        ClearPatientRoom(ExtendApplicationContext.Current.PatientContextExtend.PatientID);
                        ClearPatientMonitor(ExtendApplicationContext.Current.PatientContextExtend.PatientID, "1");

                        ClearPatientMonitor(ExtendApplicationContext.Current.PatientContextExtend.PatientID, "0");///取消诱导室采集
                    }
                    else if (operationStatus == OperationStatus.OutOperationRoom)
                    {
                        if (_outPatients.ContainsKey(ExtendApplicationContext.Current.PatientContextExtend.PatientID))
                        {
                            _outPatients[ExtendApplicationContext.Current.PatientContextExtend.PatientID] = dt;
                        }
                        else
                        {
                            _outPatients.Add(ExtendApplicationContext.Current.PatientContextExtend.PatientID, dt);
                        }
                    }
                    if (operationStatus != OperationStatus.InOperationRoom && operationStatus != OperationStatus.AnesthesiaStart
                        && operationStatus != OperationStatus.OperationStart && operationStatus != OperationStatus.AnesthesiaEnd
                        && operationStatus != OperationStatus.OperationEnd && operationStatus != OperationStatus.InPACU)
                    {
                        ClearPatientRoom(ExtendApplicationContext.Current.PatientContextExtend.PatientID);
                        ClearPatientMonitor(ExtendApplicationContext.Current.PatientContextExtend.PatientID, "0");
                    }
                    if (operationStatus == OperationStatus.InYouDao || (operationStatus == OperationStatus.InPACU && oldOperationStatus >= OperationStatus.OutPACU))//
                    {
                        string roomNo = "";
                        //加载手术间 字典
                        List<MED_OPERATING_ROOM> operRoomList = comnDictRepository.GetAllOperatingRoomList().Data;
                        if (operRoomList != null && operRoomList.Count > 0)
                        {
                            List<string> bedNos = new List<string>();
                            foreach (MED_OPERATING_ROOM row in operRoomList)
                            {
                                if (!string.IsNullOrEmpty(row.BED_TYPE) && row.BED_TYPE.Equals("1") || row.BED_TYPE.Equals("3"))
                                {
                                    bedNos.Add(row.ROOM_NO);
                                }
                            }
                            if (bedNos.Count > 0)
                            {
                                if (patientStatusAction != null)
                                {
                                    object bedNo = patientStatusAction.Excute(operationStatus);
                                    if (!string.IsNullOrEmpty(bedNo.ToString()))
                                    {
                                        roomNo = bedNo.ToString();
                                        if (operMaster.OUT_PACU_DATE_TIME.HasValue)
                                            operMaster.OUT_PACU_DATE_TIME = null;
                                    }
                                }
                            }
                        }
                        if (string.IsNullOrEmpty(roomNo))
                        {
                            return false;
                        }
                        else
                        {
                            bool isupdate = new OperatingRoomRepository().SetOperatingRoomPatient(operRoomList, roomNo, ExtendApplicationContext.Current.OperRoom, ExtendApplicationContext.Current.PatientContextExtend.PatientID
                                 , ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID);
                            if (isupdate)
                            {
                                new OperatingRoomRepository().SetMonitorDictPatient("1", ExtendApplicationContext.Current.OperRoom, roomNo, ExtendApplicationContext.Current.PatientContextExtend.PatientID, ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID);

                            }
                            else
                            {
                                MessageBoxFormPC.Show("床位被占用，请重新选择",
                    "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                        }
                    }
                    else if (operationStatus == OperationStatus.InOperationRoom)
                    {
                        string roomNo = "";
                        List<MED_OPERATING_ROOM> operRoomList = comnDictRepository.GetAllOperatingRoomList().Data;
                        if (operRoomList != null && operRoomList.Count > 0)
                        {
                            roomNo = ExtendApplicationContext.Current.PatientInformationExtend.OPER_ROOM_NO;
                        }
                        if (string.IsNullOrEmpty(roomNo))
                        {
                            if (ApplicationConfiguration.UseDefaultOperatingRoom && !string.IsNullOrEmpty(ExtendApplicationContext.Current.OperRoomNo) && !ExtendApplicationContext.Current.OperRoomNo.Contains(","))
                            {
                                operMaster.OPER_ROOM_NO = ExtendApplicationContext.Current.OperRoomNo;
                                if (operationInfoRepository.SaveOperMaster(operMaster).Data > 0)
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (ApplicationConfiguration.UseDefaultOperatingRoom && !string.IsNullOrEmpty(ExtendApplicationContext.Current.OperRoomNo) && !ExtendApplicationContext.Current.OperRoomNo.Contains(",") && !ExtendApplicationContext.Current.OperRoomNo.Equals(roomNo))
                            {
                                if (MessageBoxFormPC.Show("要把当前患者从 " + roomNo + "号间转到" + ExtendApplicationContext.Current.OperRoomNo + "号间吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                {
                                    return false;
                                }
                                //int ret = 0;
                                operMaster.OPER_ROOM_NO = ExtendApplicationContext.Current.OperRoomNo;
                                Logger.Error("patientStatusControl master表状态以及时间1:" + operMaster.PATIENT_ID + "|" + operMaster.VISIT_ID + "|" + operMaster.OPER_ID + "|" + operMaster.OPER_STATUS_CODE + "|" + operMaster.IN_PACU_DATE_TIME + "|" + operMaster.OUT_PACU_DATE_TIME);
                                if (operationInfoRepository.SaveOperMaster(operMaster).Data <= 0)
                                {
                                    return false;
                                }
                                else
                                {
                                    ExtendApplicationContext.Current.PatientInformationExtend.OPER_ROOM_NO = ExtendApplicationContext.Current.OperRoomNo;
                                }
                            }
                            new OperatingRoomRepository().SetOperatingRoomPatient(operRoomList, roomNo, ExtendApplicationContext.Current.OperRoom, ExtendApplicationContext.Current.PatientContextExtend.PatientID
                                 , ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID);
                        }
                    }
                    if (!(operationStatus == OperationStatus.OutPACU && operMaster.OPER_STATUS_CODE > (int)operationStatus))
                    {
                        if (operMaster.OPER_STATUS_CODE != (int)operationStatus)
                        {
                            operMaster.OPER_STATUS_CODE = (int)operationStatus;
                        }
                    }
                    ExtendApplicationContext.Current.MED_OPERATION_MASTER = operMaster;
                    ExtendApplicationContext.Current.OperationStatus = (OperationStatus)operMaster.OPER_STATUS_CODE;
                    Logger.Error("patientStatusControl master表状态以及时间2:" + operMaster.PATIENT_ID + "|" + operMaster.VISIT_ID + "|" + operMaster.OPER_ID + "|" + operMaster.OPER_STATUS_CODE + "|" + operMaster.IN_PACU_DATE_TIME + "|" + operMaster.OUT_PACU_DATE_TIME);
                    if (operationInfoRepository.SaveOperMaster(operMaster).Data <= 0)
                    {
                        return false;
                    }
                    else
                    {
                        if (oldOperationStatus == OperationStatus.InPACU && operMaster.OPER_STATUS_CODE == (int)OperationStatus.TurnToPACU)
                        {
                            //  UpdateAnesFiveTrunToPACU();
                        }
                    }
                }
                string fieldName = OperationStatusHelper.GetTimeFieldName(operationStatus);
                if (dt != DateTime.MinValue && dt != DateTime.MaxValue && dt != null)
                {
                    operMaster.SetValue(fieldName, dt);
                }

                Logger.Error("patientStatusControl master表状态以及时间3:" + operMaster.PATIENT_ID + "|" + operMaster.VISIT_ID + "|" + operMaster.OPER_ID + "|" + operMaster.OPER_STATUS_CODE + "|" + operMaster.IN_PACU_DATE_TIME + "|" + operMaster.OUT_PACU_DATE_TIME);
                if (operationInfoRepository.SaveOperMaster(operMaster).Data > 0)
                {
                    operMaster = operationInfoRepository.GetOperMaster(ExtendApplicationContext.Current.PatientContextExtend.PatientID,
                        ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID).Data;

                    Logger.Error("RaiseRefreshPatient前：" + operMaster.PATIENT_ID + "|" + operMaster.VISIT_ID + "|" + operMaster.OPER_ID + "|" + operMaster.OPER_STATUS_CODE + "|" + operMaster.IN_PACU_DATE_TIME + "|" + operMaster.OUT_PACU_DATE_TIME);

                    RaiseRefreshPatient();

                    operMaster = operationInfoRepository.GetOperMaster(ExtendApplicationContext.Current.PatientContextExtend.PatientID,
                        ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID).Data;

                    Logger.Error("RaiseRefreshPatient后：" + operMaster.PATIENT_ID + "|" + operMaster.VISIT_ID + "|" + operMaster.OPER_ID + "|" + operMaster.OPER_STATUS_CODE + "|" + operMaster.IN_PACU_DATE_TIME + "|" + operMaster.OUT_PACU_DATE_TIME);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 取消出复苏室手术状态写入到5.0数据库
        /// </summary>
        private void UpdateAnesFiveTrunToInPACU()
        {
            string sql = string.Format(@"update med_operation_master 
                                            set OUT_PACU_DATE_TIME=to_date('{0}', 'yyyy-mm-dd hh24:mi:ss'),
                                                OPER_STATUS={1}
                                                where patient_id='{2}' and visit_id={3} and oper_id={4}",
                                        null,
                                        45, ExtendApplicationContext.Current.PatientContextExtend.PatientID, ExtendApplicationContext.Current.PatientContextExtend.VisitID,
                                        ExtendApplicationContext.Current.PatientContextExtend.OperID);//"0011636230", 1, 1

            Logger.Error(sql);

            new CommonRepository().UpdateDataTable(sql);

            MED_OPERATION_MASTER operMaster = operationInfoRepository.GetOperMaster(ExtendApplicationContext.Current.PatientContextExtend.PatientID,
                ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID).Data;

            Logger.Error("UpdateAnesFiveTrunToInPACU：" + operMaster.PATIENT_ID + "|" + operMaster.VISIT_ID + "|" + operMaster.OPER_ID + "|" + operMaster.OPER_STATUS_CODE + "|" + operMaster.IN_PACU_DATE_TIME + "|" + operMaster.OUT_PACU_DATE_TIME);
        }
        /// <summary>
        /// 取消入复苏室手术状态写入到5.0数据库
        /// </summary>
        private void UpdateAnesFiveTrunToPACU()
        {
            string sql = string.Format(@"update med_operation_master 
                                            set IN_PACU_DATE_TIME=to_date('{0}', 'yyyy-mm-dd hh24:mi:ss'),
                                                OPER_STATUS={1}
                                                where patient_id='{2}' and visit_id={3} and oper_id={4}",
                                        null,
                                        40, ExtendApplicationContext.Current.PatientContextExtend.PatientID, ExtendApplicationContext.Current.PatientContextExtend.VisitID,
                                        ExtendApplicationContext.Current.PatientContextExtend.OperID);//"0011636230", 1, 1
            Logger.Error(sql);

            new CommonRepository().UpdateDataTable(sql);

            MED_OPERATION_MASTER operMaster = operationInfoRepository.GetOperMaster(ExtendApplicationContext.Current.PatientContextExtend.PatientID,
                ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID).Data;

            Logger.Error("UpdateAnesFiveTrunToPACU：" + operMaster.PATIENT_ID + "|" + operMaster.VISIT_ID + "|" + operMaster.OPER_ID + "|" + operMaster.OPER_STATUS_CODE + "|" + operMaster.IN_PACU_DATE_TIME + "|" + operMaster.OUT_PACU_DATE_TIME);
        }
        /// <summary>
        /// 设置手术状态,更新主界面
        /// </summary>
        /// <param name="operationStatus"></param>
        public void NoifyOperationStatusChange(OperationStatus operationStatus)
        {
            if (_ServiceObject != null && _ServiceObject is IOperationStatusObserver)
            {
                ((IOperationStatusObserver)_ServiceObject).NoifyOperationStatusChange(operationStatus);
            }
        }

        /// <summary>
        /// 设置手术时间改变,更新 文书
        /// </summary>
        /// <param name="operationStatus"></param>
        public void NoifyOperationTimeChange()
        {
            if (_ServiceObject != null && _ServiceObject is IOperationStatusObserver)
            {
                ((IOperationStatusObserver)_ServiceObject).NoifyOperationTimeChange();
            }
        }
        /// <summary>
        ///清除患者手术间安排
        /// </summary>
        /// <param name="patientID"></param>
        public bool ClearPatientRoom(string patientID)
        {
            bool result = false;
            List<MED_OPERATING_ROOM> operRoomList = comnDictRepository.GetAllOperatingRoomList().Data;

            if (operRoomList != null && operRoomList.Count > 0)
            {
                foreach (MED_OPERATING_ROOM row in operRoomList)
                {
                    if (!string.IsNullOrEmpty(row.PATIENT_ID) && row.PATIENT_ID.Equals(patientID))
                    {
                        row.PATIENT_ID = null;
                        row.VISIT_ID = null;
                        row.OPER_ID = null;
                        if (comnDictRepository.SaveOperatingRoom(row).Data > 0)
                        {
                            result = true;
                        }
                    }
                }

            }
            return result;
        }


        /// <summary>
        ///清除患者设备安排
        /// </summary>
        /// <param name="patientID"></param>
        public bool ClearPatientMonitor(string patientID, string eventNo)
        {
            bool result = false;
            List<MED_MONITOR_DICT> monitorList = comnDictRepository.GetMonitorDictList(eventNo).Data;
            if (monitorList != null && monitorList.Count > 0)
            {
                foreach (MED_MONITOR_DICT row in monitorList)
                {
                    if (!string.IsNullOrEmpty(row.PATIENT_ID) && row.PATIENT_ID.Equals(patientID))
                    {
                        row.PATIENT_ID = null;
                        row.VISIT_ID = null;
                        row.OPER_ID = null;
                        //if (eventNo == "0")
                        //    row.BED_NO = null;
                    }
                }
                if (comnDictRepository.SaveMonitorDictList(monitorList).Data > 0)
                {
                    result = true;
                }
            }
            return result;
        }


        #region "弹出菜单控制"

        /// <summary>
        /// 鼠标按下，界面事件弹出
        /// </summary>
        /// <param name="caption"></param>
        public void OnPopUpOperationSatusMouseDown(PatientStatusSingleControl singleConrol, bool isShowPOP)
        {
            OperationStatus operationStatus = OperationStatusHelper.OperationStatusFromString(singleConrol.StatusName);

            if (singleConrol.ConrolLightStatus == OperationLightStatus.Light)
            {
                if (!singleConrol.picLightImage.Visible)//
                {
                    if (ApplicationConfiguration.IsPACUProgram)
                    {
                        SetPopUpBarVisible(true);
                        SetPopUpOperationSatusManagerVisible(true);
                        SetPopUpOperationSatusPACU(false);
                        SetPopUpOperationSatusManagerCaption("转到状态【出复苏室】");
                        SetPopUpOperationSatusManagerCaption2("");
                    }
                    else
                    {
                        SetPopUpBarVisible(true);
                        SetPopUpOperationSatusManagerVisible(true);
                        SetPopUpOperationSatusPACU(false);
                        SetPopUpOperationSatusManagerCaption("转到状态【出手术室】");
                        SetPopUpOperationSatusManagerCaption2("");
                    }
                }
                //出手术室
                else if (operationStatus == OperationStatus.OutOperationRoom)//出手术室
                {
                    SetPopUpBarVisible(false);
                    SetPopUpOperationSatusManagerVisible(true);
                    SetPopUpOperationSatusPACU(false);
                    SetPopUpOperationSatusManagerCaption("转到状态【入手术室】");
                    SetPopUpOperationSatusManagerCaption2("转到状态【麻醉结束】");
                }
                else if (operationStatus == OperationStatus.InOperationRoom)//入手术室
                {
                    SetPopUpBarVisible(false);
                    SetPopUpOperationSatusManagerVisible(true);
                    SetPopUpOperationSatusPACU(false);
                    SetPopUpOperationSatusManagerCaption("取消状态【入手术室】");
                    SetPopUpOperationSatusManagerCaption2("");
                }
                else if (operationStatus == OperationStatus.AnesthesiaStart)//麻醉开始
                {
                    SetPopUpBarVisible(false);
                    SetPopUpOperationSatusManagerVisible(true);
                    SetPopUpOperationSatusPACU(false);
                    SetPopUpOperationSatusManagerCaption("转到状态【入手术室】");
                    SetPopUpOperationSatusManagerCaption2("");//转到状态【麻醉结束】
                }
                else if (operationStatus == OperationStatus.OperationStart)//手术开始
                {
                    SetPopUpBarVisible(false);
                    SetPopUpOperationSatusManagerVisible(true);
                    SetPopUpOperationSatusPACU(false);
                    SetPopUpOperationSatusManagerCaption("转到状态【麻醉开始】");
                    SetPopUpOperationSatusManagerCaption2("");
                }
                else if (operationStatus == OperationStatus.OperationEnd)//手术结束
                {
                    SetPopUpBarVisible(false);
                    SetPopUpOperationSatusManagerVisible(true);
                    SetPopUpOperationSatusManagerCaption("转到状态【手术开始】");
                    SetPopUpOperationSatusManagerCaption2("");
                }
                else if (operationStatus == OperationStatus.AnesthesiaEnd)//麻醉结束
                {
                    SetPopUpBarVisible(false);
                    SetPopUpOperationSatusManagerVisible(true);
                    SetPopUpOperationSatusPACU(false);
                    SetPopUpOperationSatusManagerCaption("转到状态【手术结束】");
                    SetPopUpOperationSatusManagerCaption2("");
                }
                else if (operationStatus == OperationStatus.InPACU)//入复苏室
                {
                    SetPopUpBarVisible(false);
                    SetPopUpOperationSatusManagerVisible(true);
                    SetPopUpOperationSatusManagerCaption("取消状态【入复苏室】");
                    SetPopUpOperationSatusManagerCaption2("");
                }
                else if (operationStatus == OperationStatus.InYouDao)//入诱导室
                {
                    SetPopUpBarVisible(false);
                    SetPopUpOperationSatusManagerVisible(true);
                    SetPopUpOperationSatusManagerCaption("取消状态【入诱导室】");
                }
                else if (operationStatus == OperationStatus.OutYouDao)//入诱导室
                {
                    SetPopUpBarVisible(false);
                    SetPopUpOperationSatusManagerVisible(false);
                }


                else if (operationStatus == OperationStatus.OutPACU)//出复苏室
                {
                    //  barButtonItemTurnToRoom.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    // barButtonItemTurnToICU.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    SetPopUpBarVisible(false);
                    SetPopUpOperationSatusManagerVisible(true);
                    SetPopUpOperationSatusManagerCaption("转到状态【入复苏室】");
                    SetPopUpOperationSatusManagerCaption2("");
                }
                popupMenuStatus.ShowPopup(Control.MousePosition);
            }
            else if (singleConrol.ConrolLightStatus == OperationLightStatus.Passed)
            {
                if (operationStatus == OperationStatus.OutPACU)
                {
                    SetPopUpBarVisible(false);
                    SetPopUpOperationSatusManagerVisible(true);
                    SetPopUpOperationSatusManagerCaption("转到状态【入复苏室】");
                    SetPopUpOperationSatusManagerCaption2("");
                }

                popupMenuStatus.ShowPopup(Control.MousePosition);

            }


        }
        /// <summary>
        /// 设置弹出菜单名称
        /// </summary>
        /// <param name="caption"></param>
        public void SetPopUpOperationSatusManagerCaption(string caption)
        {
            barButtonItemOperationSatusManager.Caption = caption;
        }
        public void SetPopUpOperationSatusManagerVisible(bool bVisible)
        {
            if (bVisible)
            {
                barButtonItemOperationSatusManager.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                barButtonItemOperationSatusManager.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }


        public void SetPopUpOperationSatusManagerCaption2(string caption)
        {
            if (string.IsNullOrEmpty(caption))
                barButtonItemToAnesEnd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            else
            {
                barButtonItemToAnesEnd.Caption = caption;
                barButtonItemToAnesEnd.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
        }

        //设置转入病房、转PACU是否可见
        public void SetPopUpBarVisible(bool bVisible)
        {
            if (bVisible)
            {
                barButtonItemTurnToRoom.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barButtonItemTrunToPACU.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barButtonItemTurnToICU.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barButtonItemDictTurnToPACU.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                barButtonItemTurnToRoom.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItemTrunToPACU.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItemTurnToICU.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItemDictTurnToPACU.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        private void PatientStatusContrl_Load(object sender, EventArgs e)
        {
            //初始化弹出框状态
            barButtonItemOperationSatusManager.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barButtonItemTurnToRoom.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barButtonItemTrunToPACU.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barButtonItemToAnesEnd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barButtonItemDictTurnToPACU.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

        }

        public void SetPopUpOperationSatusPACU(bool bVisible)
        {
            if (bVisible)
            {
                if (ApplicationConfiguration.IsPACUProcess)
                {
                    barButtonItemTrunToPACU.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    barButtonItemTrunToPACU.Caption = "入PACU室申请";
                    barButtonItemDictTurnToPACU.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    barButtonItemDictTurnToPACU.Caption = "进PACU室";
                }
                else
                {
                    barButtonItemTrunToPACU.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    barButtonItemTrunToPACU.Caption = "入PACU室申请";
                    barButtonItemDictTurnToPACU.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    barButtonItemDictTurnToPACU.Caption = "进PACU室";
                }
            }
            else
            {
                barButtonItemTrunToPACU.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItemTrunToPACU.Caption = "入PACU室申请";
                barButtonItemDictTurnToPACU.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItemDictTurnToPACU.Caption = "进PACU室";
            }
        }
        public void SetOperTurnStatus(OperationStatus operationStatus)
        {
            if (operationStatus == OperationStatus.TurnToSickRoom)
            {
                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        NoifyOperationStatusChange(operationStatus);
                    }
                }
            }
            else if (operationStatus == OperationStatus.TurnToICU)
            {
                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        NoifyOperationStatusChange(operationStatus);
                    }
                }
            }
            else if (operationStatus == OperationStatus.TurnToPACU)
            {
                if (!CheckBedForTrun())//如果没有空床
                {
                    MessageBoxFormPC.Show("PACU室内没有空缺的床位，暂时不能转入，请稍候再试！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        NoifyOperationStatusChange(operationStatus);
                    }
                }
            }
            else if (operationStatus == OperationStatus.TurnToEmergency)
            {
                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        NoifyOperationStatusChange(operationStatus);
                    }
                }
            }
            else if (operationStatus == OperationStatus.TurnToMortuary)
            {
                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        NoifyOperationStatusChange(operationStatus);
                    }
                }
            }
            foreach (PatientStatusSingleControl singlePatientStatusConrol in this.panelMain.Controls)
            {
                int operationStatusValueTemp = (int)OperationStatusHelper.OperationStatusFromString(singlePatientStatusConrol.StatusName);
            }
        }

        private void barButtonItemOperationSatusManager_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult res = MessageBoxFormPC.Show("此操作将改变状态，确定执行？", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.No)
                return;

            string statusCap = "";
            OperationStatus operationStatus = OperationStatus.IsReady;

            if (e.Item.Caption.Contains("取消状态【入手术室】"))
            {
                operationStatus = OperationStatus.OperScheduled;
                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        ClearPatientRoom(ExtendApplicationContext.Current.PatientContextExtend.PatientID);
                        ClearPatientMonitor(ExtendApplicationContext.Current.PatientContextExtend.PatientID, "0");
                        NoifyOperationStatusChange(operationStatus);
                    }
                }
                MED_OPERATION_MASTER operRow = operationInfoRepository.GetOperMaster(ExtendApplicationContext.Current.PatientContextExtend.PatientID, ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID).Data;

                if (operRow == null)
                {
                    return;
                }
                operRow.IN_DATE_TIME = null;

                operationInfoRepository.SaveOperMaster(operRow);

                //删除时间
                foreach (PatientStatusSingleControl singlePatientStatusConrol in this.panelMain.Controls)
                {
                    //先时间清空数据,
                    singlePatientStatusConrol.SetOperationStatusTimeText(DateTime.MinValue);
                }
            }
            else if (e.Item.Caption.Contains("转到状态【入手术室】"))
            {
                operationStatus = OperationStatus.InOperationRoom;
                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        NoifyOperationStatusChange(operationStatus);
                    }
                }
                statusCap = "入手术室";
            }
            else if (e.Item.Caption.Contains("转到状态【出手术室】"))
            {
                operationStatus = OperationStatus.OutOperationRoom;
                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        NoifyOperationStatusChange(operationStatus);
                    }
                }
                statusCap = "出手术室";
            }
            else if (e.Item.Caption.Contains("转到状态【出复苏室】"))
            {
                operationStatus = OperationStatus.OutPACU;
                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        NoifyOperationStatusChange(operationStatus);
                    }
                }
                statusCap = "出手术室";
            }
            else if (e.Item.Caption.Contains("转到状态【麻醉开始】"))
            {
                operationStatus = OperationStatus.AnesthesiaStart;

                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        NoifyOperationStatusChange(operationStatus);
                    }
                }
                statusCap = "麻醉开始";
            }
            else if (e.Item.Caption.Contains("转到状态【手术开始】"))
            {

                operationStatus = OperationStatus.OperationStart;

                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        NoifyOperationStatusChange(operationStatus);
                    }
                }
                statusCap = "手术开始";
            }
            else if (e.Item.Caption.Contains("转到状态【手术结束】"))
            {

                operationStatus = OperationStatus.OperationEnd;

                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        NoifyOperationStatusChange(operationStatus);
                    }
                }

                statusCap = "手术结束";
            }
            else if (e.Item.Caption.Contains("转到状态【麻醉结束】"))
            {
                operationStatus = OperationStatus.AnesthesiaEnd;
                //if (ExtendApplicationContext.Current.OperationStatus)
                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (ExtendApplicationContext.Current.OperationStatus == OperationStatus.AnesthesiaStart)
                    {
                        if (UpdateOperationStatusOrStatusTime(operationStatus, accountRepository.GetServerTime().Data, true, ExtendApplicationContext.Current.OperationStatus))
                        {
                            NoifyOperationStatusChange(operationStatus);
                        }
                    }
                    else
                    {
                        if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                        {
                            NoifyOperationStatusChange(operationStatus);
                        }
                    }
                }
                statusCap = "麻醉结束";
            }
            else if (e.Item.Caption.Contains("转入病房"))
            {
                operationStatus = OperationStatus.TurnToSickRoom;

                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        NoifyOperationStatusChange(operationStatus);
                    }
                }

                statusCap = "转入病房";
            }
            else if (e.Item.Caption.Contains("转入ICU"))
            {

                operationStatus = OperationStatus.TurnToICU;

                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        NoifyOperationStatusChange(operationStatus);
                    }
                }

                statusCap = "转入ICU";
            }
            else if (e.Item.Caption.Contains("入PACU室申请"))
            {
                //if (PACUProcess.AquireInPACU())
                //{
                //    MessageBoxFormPC.Show("已提交入PACU室申请，正在等待PACU室确认", "提示信息", MessageBoxButtons.OK);
                //}
                //else
                //    MessageBoxFormPC.Show("提交申请失败，请检查数据连接", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (e.Item.Caption.Contains("进PACU室"))
            {
                if (!CheckBedForTrun())//如果没有空床
                {
                    MessageBoxFormPC.Show("PACU室内没有空缺的床位，暂时不能转入，请稍候再试！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                operationStatus = OperationStatus.TurnToPACU;
                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        NoifyOperationStatusChange(operationStatus);
                    }
                }

                statusCap = "准备复苏";
            }
            else if (e.Item.Caption.Contains("进复苏室"))
            {
                if (!CheckBedForTrun())//如果没有空床
                {
                    MessageBoxFormPC.Show("复苏室内没有空缺的床位，暂时不能转入，请稍候再试！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                operationStatus = OperationStatus.TurnToPACU;


                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        NoifyOperationStatusChange(operationStatus);
                    }
                }

                statusCap = "准备复苏";
            }
            else if (e.Item.Caption.Contains("取消状态【入复苏室】"))
            {

                operationStatus = OperationStatus.TurnToPACU;

                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        NoifyOperationStatusChange(operationStatus);
                    }
                }
                statusCap = "准备复苏";
            }
            else if (e.Item.Caption.Contains("转到状态【入复苏室】"))
            {

                operationStatus = OperationStatus.InPACU;

                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        NoifyOperationStatusChange(operationStatus);
                    }
                    else
                        return;
                }
                statusCap = "入复苏室";
            }
            else if (e.Item.Caption.Contains("取消状态【入诱导室】"))
            {

                operationStatus = OperationStatus.OperScheduled;

                if (operationStatus != ExtendApplicationContext.Current.OperationStatus)
                {
                    if (UpdateOperationStatusOrStatusTime(operationStatus, DateTime.MinValue, true, ExtendApplicationContext.Current.OperationStatus))
                    {
                        ClearPatientRoom(ExtendApplicationContext.Current.PatientContextExtend.PatientID);
                        ClearPatientMonitor(ExtendApplicationContext.Current.PatientContextExtend.PatientID, "0");
                        NoifyOperationStatusChange(operationStatus);

                    }
                }
                //删除时间
                foreach (PatientStatusSingleControl singlePatientStatusConrol in this.panelMain.Controls)
                {
                    //先时间清空数据,
                    singlePatientStatusConrol.SetOperationStatusTimeText(DateTime.MinValue);
                }
            }
            if (statusCap == "")
                return;
            MED_OPERATION_MASTER operMaster = operationInfoRepository.GetOperMaster(ExtendApplicationContext.Current.PatientContextExtend.PatientID, ExtendApplicationContext.Current.PatientContextExtend.VisitID, ExtendApplicationContext.Current.PatientContextExtend.OperID).Data;
            if (operMaster == null)
            {
                return;
            }
            int operationStatusValue = (int)OperationStatusHelper.OperationStatusFromString(statusCap);
            //循环判断将后面的状态置空
            foreach (PatientStatusSingleControl singlePatientStatusConrol in this.panelMain.Controls)
            {
                int operationStatusValueTemp = (int)OperationStatusHelper.OperationStatusFromString(singlePatientStatusConrol.StatusName);

                //判断后面的状态是否有时间
                if (operationStatusValueTemp > operationStatusValue)
                {
                    string fdName = OperationStatusHelper.GetTimeFieldName(OperationStatusHelper.OperationStatusFromString(singlePatientStatusConrol.StatusName));
                    SetOperMasterTime(operMaster, fdName);
                    singlePatientStatusConrol.SetOperationStatusTimeText(DateTime.MinValue);
                }

            }
            operationInfoRepository.SaveOperMaster(operMaster);
        }
        private void SetOperMasterTime(MED_OPERATION_MASTER operMaster, string timeName)
        {
            switch (timeName)
            {
                case "IN_DATE_TIME":
                    operMaster.IN_DATE_TIME = null;
                    break;
                case "ANES_START_TIME":
                    operMaster.ANES_START_TIME = null;
                    break;
                case "START_DATE_TIME":
                    operMaster.START_DATE_TIME = null;
                    break;
                case "END_DATE_TIME":
                    operMaster.END_DATE_TIME = null;
                    break;
                case "ANES_END_TIME":
                    operMaster.ANES_END_TIME = null;
                    break;
                case "OUT_DATE_TIME":
                    operMaster.OUT_DATE_TIME = null;
                    break;
                case "IN_PACU_DATE_TIME":
                    operMaster.IN_PACU_DATE_TIME = null;
                    break;
                case "OUT_PACU_DATE_TIME":
                    operMaster.OUT_PACU_DATE_TIME = null;
                    break;
                default:
                    break;
            }
        }
        private bool CheckBedForTrun()
        {
            bool isFind = false;
            //加载手术间 字典
            List<MED_OPERATING_ROOM> operatingRoomDataTable = comnDictRepository.GetAllOperatingRoomList().Data;

            if (operatingRoomDataTable != null && operatingRoomDataTable.Count > 0)
            {
                //List<string> bedNos = new List<string>();
                foreach (MED_OPERATING_ROOM row in operatingRoomDataTable)
                {
                    if (row.BED_TYPE.Equals("1"))
                    {
                        if (string.IsNullOrEmpty(row.PATIENT_ID))
                        {
                            isFind = true;
                            break;
                        }
                        else
                        {
                            //string bedPatientID = row.PATIENT_ID;
                            if (string.IsNullOrEmpty(row.PATIENT_ID)) //有空床
                            {
                                isFind = true;
                                break;
                            }
                            else
                            {

                            }
                        }
                    }
                }
            }
            return isFind;
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                try
                {
                    DateTime dtNow = accountRepository.GetServerTime().Data;
                    List<string> removePat = new List<string>();
                    foreach (KeyValuePair<string, DateTime> outPat in _outPatients)
                    {
                        if (dtNow >= outPat.Value)
                        {
                            ClearPatientMonitor(outPat.Key, "0");
                            removePat.Add(outPat.Key);
                        }
                    }

                    foreach (string patId in removePat)
                    {
                        _outPatients.Remove(patId);
                    }
                }
                catch (Exception err)
                {
                    ExceptionHandler.Handle(err, false);
                }
                // 处理复苏申请
                try
                {
                    if (ExtendApplicationContext.Current.AppType == ApplicationType.Anesthesia)
                    {
                        // PACUProcess.ShowPacuMsg();
                    }
                    else if (ExtendApplicationContext.Current.AppType == ApplicationType.PACU)
                    {
                        // PACUProcess.CheckPacuWait();
                    }
                }
                catch (Exception err)
                {
                }
            }
        }
        /// <summary>
        /// 取消手术 病案提交
        /// </summary>
        public bool CancelOrCommitOperation(OperationStatus operationStatus, string cancelReason)
        {
            if (operationStatus == OperationStatus.Done || operationStatus == OperationStatus.CancelOperation)
            {
                ClearPatientRoom(ExtendApplicationContext.Current.PatientInformationExtend.PATIENT_ID);
                ClearPatientMonitor(ExtendApplicationContext.Current.PatientInformationExtend.PATIENT_ID, "0");

                MED_OPERATION_MASTER dataTable = operationInfoRepository.GetOperMaster(ExtendApplicationContext.Current.PatientInformationExtend.PATIENT_ID, ExtendApplicationContext.Current.PatientInformationExtend.VISIT_ID,
               ExtendApplicationContext.Current.PatientInformationExtend.OPER_ID).Data;
                if (dataTable != null)
                {
                    dataTable.OPER_STATUS_CODE = (int)operationStatus;
                    ExtendApplicationContext.Current.OperationStatus = operationStatus;
                    ExtendApplicationContext.Current.PatientInformationExtend.OPER_STATUS_CODE = (int)operationStatus;
                    if (operationStatus == OperationStatus.CancelOperation)
                    {
                        int maxno = new CommonRepository().GetMaxCancelID(ExtendApplicationContext.Current.PatientInformationExtend.PATIENT_ID, ExtendApplicationContext.Current.PatientInformationExtend.VISIT_ID).Data;
                        maxno++;
                        MED_OPERATION_CANCELED OperationCanceledRow = new MED_OPERATION_CANCELED();
                        OperationCanceledRow.PATIENT_ID = dataTable.PATIENT_ID;
                        OperationCanceledRow.VISIT_ID = dataTable.VISIT_ID;
                        OperationCanceledRow.CANCEL_ID = maxno;
                        OperationCanceledRow.OPER_ID = dataTable.OPER_ID;
                        OperationCanceledRow.OPER_STATUS_CODE = dataTable.OPER_STATUS_CODE;
                        OperationCanceledRow.CANCEL_REASON = cancelReason;
                        OperationCanceledRow.CANCEL_DATE = accountRepository.GetServerTime().Data;
                        OperationCanceledRow.ENTERED_BY = ExtendApplicationContext.Current.LoginUser.USER_JOB_ID;
                        OperationCanceledRow.RESERVED1 = "0";
                        if (new CommonRepository().UpdateOperationCanceled(OperationCanceledRow).Data > 0)
                        {
                            return operationInfoRepository.SaveOperMaster(dataTable).Data > 0 ? true : false;
                        }
                    }
                }
                return true;
            }
            return false;
        }

        //public bool RecoveryOperation(string recoveryReason)
        //{
        //    MED_OPERATION_MASTER operMaster = operationInfoRepository.GetOperMaster(ExtendApplicationContext.Current.PatientInformationExtend.PATIENT_ID, ExtendApplicationContext.Current.PatientInformationExtend.VISIT_ID,
        //      ExtendApplicationContext.Current.PatientInformationExtend.OPER_ID).Data;
        //    if (operMaster != null && operMaster.OPER_STATUS_CODE == (int)OperationStatus.CancelOperation)
        //    {
        //        if (!string.IsNullOrEmpty(operMaster.OPER_ROOM_NO))
        //        {
        //            SetOperatingRoomPatient();
        //        }
        //        List<MED_OPERATION_CANCELED> operCanceledList = new CommonRepository().GetOperationCanceled(ExtendApplicationContext.Current.PatientInformationExtend.PATIENT_ID, ExtendApplicationContext.Current.PatientInformationExtend.VISIT_ID, "0").Data;
        //        if (operCanceledList != null && operCanceledList.Count > 0)
        //        {
        //            foreach (MED_OPERATION_CANCELED canceledRow in operCanceledList)
        //            {
        //                if (canceledRow.OPER_ID.HasValue && canceledRow.OPER_ID == ExtendApplicationContext.Current.PatientContextExtend.OperID)
        //                {
        //                    canceledRow.RESERVED1 = "1";
        //                    canceledRow.CANCEL_REASON = recoveryReason;
        //                    operMaster.OPER_STATUS_CODE = canceledRow.OPER_STATUS_CODE;
        //                    ExtendApplicationContext.Current.PatientInformationExtend.OPER_STATUS_CODE = operMaster.OPER_STATUS_CODE;
        //                    ExtendApplicationContext.Current.OperationStatus = (OperationStatus)operMaster.OPER_STATUS_CODE;
        //                    new CommonRepository().UpdateOperationCanceled(canceledRow);
        //                    break;
        //                }
        //            }
        //            return operationInfoRepository.SaveOperMaster(operMaster).Data > 0 ? true : false;
        //        }
        //        return true;
        //    }
        //    return false;
        //}
        private void SetOperatingRoomPatient()
        {
            List<MED_OPERATING_ROOM> listRoom = ExtendApplicationContext.Current.CommDict.OperationRoomDict;
            List<MED_OPERATING_ROOM> currentRommData = listRoom.Where(p => p.ROOM_NO == ExtendApplicationContext.Current.PatientInformationExtend.OPER_ROOM_NO).ToList();
            if (currentRommData.Count > 0)
            {
                currentRommData[0].PATIENT_ID = ExtendApplicationContext.Current.PatientContextExtend.PatientID;
                currentRommData[0].VISIT_ID = ExtendApplicationContext.Current.PatientContextExtend.VisitID;
                currentRommData[0].OPER_ID = ExtendApplicationContext.Current.PatientContextExtend.OperID;
                comnDictRepository.SaveOperatingRoom(currentRommData[0]);
            }
        }
    }
}
