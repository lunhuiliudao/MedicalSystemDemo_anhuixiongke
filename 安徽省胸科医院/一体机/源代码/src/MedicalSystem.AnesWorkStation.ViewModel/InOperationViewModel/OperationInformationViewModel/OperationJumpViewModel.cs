//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      OperationJumpViewModel.cs
//功能描述(Description)：    术中状态跳转
//数据表(Tables)：		      
//作者(Author)：                   MDSD
//日期(Create Date)：           2017-12-27 10:49:12
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.Model.WorkListModel;
using MedicalSystem.AnesWorkStation.ViewModel.Cache;
using MedicalSystem.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.OperationInformationViewModel
{
    public class OperationJumpViewModel : BaseViewModel
    {
        private ICommand btnCancelCommand = null;                                                       // 取消按钮命令
        private ICommand btnOKCommand = null;                                                           // 确定按钮命令 
        private PatientModel curPatientModel = null;                                                    // 当前选中的患者信息
        private List<MED_OPERATING_ROOM> medOperatingRoomDict = null;                                   // 手术间字典
        private List<MED_OPERATING_ROOM> cbOperatingRoomSourceList = null;                              // 界面中的手术间数据源
        private string operRoomNo = null;                                                               // 选中的手术间号
        private string operStatus = null;   //选中跳转状态
        private string strReason = string.Empty;                                                        // 跳转原因
        private string strTimeClass = string.Empty;                                                     // 时间类型
        private string strTimeInfo = string.Empty;                                                      // 具体时间
        private string strWarning = string.Empty;                                                       // 警告信息
        private bool isOKEnable = true;                                                                 // 确认按钮是否可用
        private Visibility visibShowAnesEndTime = Visibility.Collapsed;                                 // 麻醉结束时间控件是否显示
        private DateTime anesEndTime = DateTime.Now;                                                    // 麻醉结束时间，默认当前时间
        private RichTextBox rtbResaon = null;                                                           // 界面中的原因富文本框，由于不能直接绑定，所以把控件传到VM中
        private Visibility visibShowOperRoomNo = Visibility.Collapsed;                                  // 空闲手术间下拉框是否显示
        /// <summary>
        /// 当前正在手术的患者信息
        /// </summary>
        public PatientModel CurPatientModel
        {
            get { return this.curPatientModel; }
            set
            {
                this.curPatientModel = value;
                this.RaisePropertyChanged("CurPatientModel");
            }
        }

        /// <summary>
        /// 取消按钮命令
        /// </summary>
        public ICommand BtnCancelCommand
        {
            get { return this.btnCancelCommand; }
            set { this.btnCancelCommand = value; }
        }

        /// <summary>
        /// 确定按钮命令
        /// </summary>
        public ICommand BtnOKCommand
        {
            get { return this.btnOKCommand; }
            set { this.btnOKCommand = value; }
        }
        /// <summary>
        ///  手术间字典绑定
        /// </summary>
        public List<MED_OPERATING_ROOM> MedOperatingRoomDict
        {
            get
            {
                this.medOperatingRoomDict = DictService.ClientInstance.GetOperatingRoomList().Where(x => x.DEPT_CODE.Equals(ExtendAppContext.Current.OperDeptCode) &&
                                                                                                         x.BED_TYPE.Equals(ExtendAppContext.Current.EventNo)).ToList();
                return this.medOperatingRoomDict;
            }
            set
            {
                this.medOperatingRoomDict = value;
                RaisePropertyChanged("MedOperatingRoomDict");
            }
        }

        public List<MED_OPERATING_ROOM> CbOperatingRoomSourceList
        {
            get
            {
                return this.cbOperatingRoomSourceList;
            }
            set
            {
                this.cbOperatingRoomSourceList = value;
                this.RaisePropertyChanged("CbOperatingRoomSourceList");
            }
        }

        /// <summary>
        /// 手术间号
        /// </summary>
        /// 
        public string OperRoomNo
        {
            get
            {
                return this.operRoomNo;
            }
            set
            {
                this.operRoomNo = value;
                RaisePropertyChanged("OperRoomNo");
            }
        }
        public string OperStatus
        {
            get { return this.operStatus; }
            set
            {
                this.operStatus = value;
                RaisePropertyChanged("OperStatus");
            }
        }
        /// <summary>
        /// 时间类型：出室时间，麻醉开始时间
        /// </summary>
        public string StrTimeClass
        {
            get { return this.strTimeClass; }
            set
            {
                this.strTimeClass = value;
                this.RaisePropertyChanged("StrTimeClass");
            }
        }

        /// <summary>
        /// 具体时间
        /// </summary>
        public string StrTimeInfo
        {
            get { return this.strTimeInfo; }
            set
            {
                this.strTimeInfo = value;
                this.RaisePropertyChanged("StrTimeInfo");
            }
        }

        /// <summary>
        /// 警告信息
        /// </summary>
        public string StrWarning
        {
            get { return this.strWarning; }
            set
            {
                this.strWarning = value;
                this.RaisePropertyChanged("StrWarning");
            }
        }

        /// <summary>
        /// 确认按钮是否可用
        /// </summary>
        public bool IsOKEnable
        {
            get { return this.isOKEnable; }
            set
            {
                this.isOKEnable = value;
                this.RaisePropertyChanged("IsOKEnable");
            }
        }

        /// <summary>
        /// 麻醉结束时间控件是否显示
        /// </summary>
        public Visibility VisibShowAnesEndTime
        {
            get { return this.visibShowAnesEndTime; }
            set
            {
                this.visibShowAnesEndTime = value;
                this.RaisePropertyChanged("VisibShowAnesEndTime");
            }
        }

        /// <summary>
        /// 是否显示空闲手术间列表
        /// </summary>
        public Visibility VisibShowOperRoomNo
        {
            get { return this.visibShowOperRoomNo; }
            set
            {
                this.visibShowOperRoomNo = value;
                this.RaisePropertyChanged("VisibShowOperRoomNo");
            }
        }

        /// <summary>
        /// 麻醉结束时间
        /// </summary>
        public DateTime AnesEndTime
        {
            get { return this.anesEndTime; }
            set
            {
                this.anesEndTime = value;
                this.RaisePropertyChanged("AnesEndTime");
            }
        }
        /// <summary>
        /// 跳转状态列表
        /// </summary>
        private List<MED_ANESTHESIA_INPUT_DICT> _cbOperStatusSourceList = new List<MED_ANESTHESIA_INPUT_DICT>();
        public List<MED_ANESTHESIA_INPUT_DICT> CbOperStatusSourceList
        {
            get { return _cbOperStatusSourceList; }
            set
            {
                _cbOperStatusSourceList = value;
                this.RaisePropertyChanged("CbOperStatusSourceList");
            }
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        public OperationJumpViewModel(MED_PAT_INFO patModel, RichTextBox rtb)
        {
            if (patModel != null)
            {
                this.CurPatientModel = PatientModel.CreateModel(patModel);
                OperStatus = OperationStatusHelper.OperationStatusToString(OperationStatus.IsReady);
                this.MedOperatingRoomDict = DictService.ClientInstance.GetOperatingRoomList().Where(x => x.DEPT_CODE.Equals(ExtendAppContext.Current.OperDeptCode) &&
                                                                                                         x.BED_TYPE.Equals(ExtendAppContext.Current.EventNo)).ToList();
                this.CbOperatingRoomSourceList = this.MedOperatingRoomDict.Where(x => x.BED_TYPE == ExtendAppContext.Current.EventNo && (x.PATIENT_ID == null || string.IsNullOrEmpty(x.PATIENT_ID))).ToList();
                this.rtbResaon = rtb;
                this.OperRoomNo = CurPatientModel.OperRoomNo;
                this.LoadOperStatusList();
                // 注册按钮命令
                this.RegisterCommand();
                // 设置界面显示的警告消息
                this.ResetWarningMessage();
            }
        }
        /// <summary>
        /// 设置界面跳转目标状态
        /// </summary>
        private void LoadOperStatusList()
        {
            if (CurPatientModel.OperStatusCode == OperationStatus.InOperationRoom)//入手术室
            {
                _cbOperStatusSourceList.Add(new MED_ANESTHESIA_INPUT_DICT() { ITEM_CLASS = "手术状态", ITEM_NAME = "入室前", ITEM_CODE = OperationStatusHelper.OperationStatusToString(OperationStatus.IsReady) });
            }
            else if (CurPatientModel.OperStatusCode == OperationStatus.AnesthesiaStart)//麻醉开始
            {
                _cbOperStatusSourceList.Add(new MED_ANESTHESIA_INPUT_DICT() { ITEM_CLASS = "手术状态", ITEM_NAME = "入室前", ITEM_CODE = OperationStatusHelper.OperationStatusToString(OperationStatus.IsReady) });
                _cbOperStatusSourceList.Add(new MED_ANESTHESIA_INPUT_DICT() { ITEM_CLASS = "手术状态", ITEM_NAME = "入手术室", ITEM_CODE = OperationStatusHelper.OperationStatusToString(OperationStatus.InOperationRoom) });
                _cbOperStatusSourceList.Add(new MED_ANESTHESIA_INPUT_DICT() { ITEM_CLASS = "手术状态", ITEM_NAME = "麻醉结束", ITEM_CODE = OperationStatusHelper.OperationStatusToString(OperationStatus.AnesthesiaEnd) });
            }
            else if (CurPatientModel.OperStatusCode == OperationStatus.OperationStart)//手术开始
            {
                _cbOperStatusSourceList.Add(new MED_ANESTHESIA_INPUT_DICT() { ITEM_CLASS = "手术状态", ITEM_NAME = "入室前", ITEM_CODE = OperationStatusHelper.OperationStatusToString(OperationStatus.IsReady).ToString() });
                _cbOperStatusSourceList.Add(new MED_ANESTHESIA_INPUT_DICT() { ITEM_CLASS = "手术状态", ITEM_NAME = "入手术室", ITEM_CODE = OperationStatusHelper.OperationStatusToString(OperationStatus.InOperationRoom) });
                _cbOperStatusSourceList.Add(new MED_ANESTHESIA_INPUT_DICT() { ITEM_CLASS = "手术状态", ITEM_NAME = "麻醉开始", ITEM_CODE = OperationStatusHelper.OperationStatusToString(OperationStatus.AnesthesiaStart) });
            }
            else if (CurPatientModel.OperStatusCode == OperationStatus.OperationEnd)//手术结束
            {
                _cbOperStatusSourceList.Add(new MED_ANESTHESIA_INPUT_DICT() { ITEM_CLASS = "手术状态", ITEM_NAME = "入室前", ITEM_CODE = OperationStatusHelper.OperationStatusToString(OperationStatus.IsReady).ToString() });
                _cbOperStatusSourceList.Add(new MED_ANESTHESIA_INPUT_DICT() { ITEM_CLASS = "手术状态", ITEM_NAME = "入手术室", ITEM_CODE = OperationStatusHelper.OperationStatusToString(OperationStatus.InOperationRoom) });
                _cbOperStatusSourceList.Add(new MED_ANESTHESIA_INPUT_DICT() { ITEM_CLASS = "手术状态", ITEM_NAME = "麻醉开始", ITEM_CODE = OperationStatusHelper.OperationStatusToString(OperationStatus.AnesthesiaStart) });
                _cbOperStatusSourceList.Add(new MED_ANESTHESIA_INPUT_DICT() { ITEM_CLASS = "手术状态", ITEM_NAME = "手术开始", ITEM_CODE = OperationStatusHelper.OperationStatusToString(OperationStatus.OperationStart) });
            }
            else if (CurPatientModel.OperStatusCode == OperationStatus.AnesthesiaEnd)//麻醉结束
            {
                _cbOperStatusSourceList.Add(new MED_ANESTHESIA_INPUT_DICT() { ITEM_CLASS = "手术状态", ITEM_NAME = "入室前", ITEM_CODE = OperationStatusHelper.OperationStatusToString(OperationStatus.IsReady) });
                _cbOperStatusSourceList.Add(new MED_ANESTHESIA_INPUT_DICT() { ITEM_CLASS = "手术状态", ITEM_NAME = "入手术室", ITEM_CODE = OperationStatusHelper.OperationStatusToString(OperationStatus.InOperationRoom) });
                _cbOperStatusSourceList.Add(new MED_ANESTHESIA_INPUT_DICT() { ITEM_CLASS = "手术状态", ITEM_NAME = "麻醉开始", ITEM_CODE = OperationStatusHelper.OperationStatusToString(OperationStatus.AnesthesiaStart) });
                _cbOperStatusSourceList.Add(new MED_ANESTHESIA_INPUT_DICT() { ITEM_CLASS = "手术状态", ITEM_NAME = "手术开始", ITEM_CODE = OperationStatusHelper.OperationStatusToString(OperationStatus.OperationStart) });
                _cbOperStatusSourceList.Add(new MED_ANESTHESIA_INPUT_DICT() { ITEM_CLASS = "手术状态", ITEM_NAME = "手术结束", ITEM_CODE = OperationStatusHelper.OperationStatusToString(OperationStatus.OperationEnd) });
            }
            else //其他
            {
                _cbOperStatusSourceList.Add(new MED_ANESTHESIA_INPUT_DICT() { ITEM_CLASS = "手术状态", ITEM_NAME = "入室前", ITEM_CODE = OperationStatusHelper.OperationStatusToString(OperationStatus.IsReady) });
                _cbOperStatusSourceList.Add(new MED_ANESTHESIA_INPUT_DICT() { ITEM_CLASS = "手术状态", ITEM_NAME = "入手术室", ITEM_CODE = OperationStatusHelper.OperationStatusToString(OperationStatus.InOperationRoom) });
                _cbOperStatusSourceList.Add(new MED_ANESTHESIA_INPUT_DICT() { ITEM_CLASS = "手术状态", ITEM_NAME = "麻醉开始", ITEM_CODE = OperationStatusHelper.OperationStatusToString(OperationStatus.AnesthesiaStart) });
                _cbOperStatusSourceList.Add(new MED_ANESTHESIA_INPUT_DICT() { ITEM_CLASS = "手术状态", ITEM_NAME = "手术开始", ITEM_CODE = OperationStatusHelper.OperationStatusToString(OperationStatus.OperationStart) });
                _cbOperStatusSourceList.Add(new MED_ANESTHESIA_INPUT_DICT() { ITEM_CLASS = "手术状态", ITEM_NAME = "手术结束", ITEM_CODE = OperationStatusHelper.OperationStatusToString(OperationStatus.OperationEnd) });
                _cbOperStatusSourceList.Add(new MED_ANESTHESIA_INPUT_DICT() { ITEM_CLASS = "手术状态", ITEM_NAME = "麻醉结束", ITEM_CODE = OperationStatusHelper.OperationStatusToString(OperationStatus.AnesthesiaEnd) });
            }
        }
        /// <summary>
        /// 设置界面上的警告消息
        /// </summary>
        private void ResetWarningMessage()
        {
            if (this.CurPatientModel.OperStatusCode >= OperationStatus.OutOperationRoom)
            {
                this.VisibShowOperRoomNo = Visibility.Visible;
            }
            else if (this.CurPatientModel.OperStatusCode == OperationStatus.AnesthesiaStart)
            {
                this.OperRoomNo = ExtendAppContext.Current.OperRoomNo;
            }
            this.StrWarning = "警告：确认后此患者术中记录数据全部清除！";
        }
        public void ResetVisibTime()
        {
            OperationStatus status = OperationStatusHelper.OperationStatusFromString(OperStatus);
            if (status == OperationStatus.IsReady)
            {
                this.VisibShowAnesEndTime = Visibility.Collapsed;
                this.StrWarning = "警告：确认后此患者术中记录数据全部清除！";
            }
            else
            {
                if (status == OperationStatus.InOperationRoom)
                    this.VisibShowAnesEndTime = Visibility.Collapsed;
                else if (status == OperationStatus.AnesthesiaStart)
                    this.VisibShowAnesEndTime = Visibility.Collapsed;
                else if (status == OperationStatus.OperationStart)
                    this.VisibShowAnesEndTime = Visibility.Collapsed;
                else if (status == OperationStatus.OperationEnd)
                    this.VisibShowAnesEndTime = Visibility.Collapsed;
                else if (status == OperationStatus.AnesthesiaEnd)
                {
                    if (this.CurPatientModel.OperStatusCode == OperationStatus.AnesthesiaStart)
                        this.VisibShowAnesEndTime = Visibility.Visible;
                    else
                        this.VisibShowAnesEndTime = Visibility.Collapsed;
                }

                this.StrWarning = "";
            }

        }
        /// <summary>
        /// 注册命令
        /// </summary>
        public void RegisterCommand()
        {
            // 取消按钮命令
            this.BtnCancelCommand = new RelayCommand<string>(par =>
            {
                this.CloseContentWindow();
            });

            // 确定按钮命令
            this.BtnOKCommand = new RelayCommand<object>(par =>
            {
                PublicKeyBoardMessage(KeyCode.AppCode.Save);
            });
        }

        /// <summary>
        /// 检查是否有更新数据
        /// </summary>
        protected override bool CheckDataChange()
        {
            return false;
        }

        /// <summary>
        /// 检查数据有效：根据当前的手术状态不同检查的数据逻辑不同
        /// </summary>
        protected override bool CheckData()
        {
            bool result = true;

            // 获取原因
            if (null != this.rtbResaon)
            {
                TextRange tr = new TextRange(this.rtbResaon.Document.ContentStart, this.rtbResaon.Document.ContentEnd);
                this.strReason = tr.Text;
            }

            if (this.CurPatientModel.OperStatusCode >= OperationStatus.OutOperationRoom)
            {
                if (string.IsNullOrEmpty(this.OperRoomNo))
                {
                    this.ShowMessageBox("目标手术间不能为空，请重新选择手术间！", MessageBoxButton.OK, MessageBoxImage.Warning);
                    result = false;
                }

                if (result && !this.CheckNewRoomNo(this.OperRoomNo))
                {
                    this.ShowMessageBox("该手术间有患者正在手术，请选择其他手术间！", MessageBoxButton.OK, MessageBoxImage.Warning);
                    result = false;
                }
            }

            if (result && (this.strReason.Trim().Equals("\r\n") || string.IsNullOrEmpty(this.strReason.Trim())))
            {
                this.ShowMessageBox("手术跳转原因不能为空，请输入！", MessageBoxButton.OK, MessageBoxImage.Warning);
                result = false;
            }

            return result;
        }

        public override void OnViewLoaded()
        {
            KeyBoardStateCache.AppCodeStack.Push("OperationJump");
        }

        /// <summary>
        /// 卸载窗口
        /// </summary>
        public override void OnViewUnLoaded()
        {
            List<string> tempStackList = KeyBoardStateCache.AppCodeStack.ToList();
            tempStackList.Remove("OperationJump");

            // 去除所有
            while (KeyBoardStateCache.AppCodeStack.Count > 0)
            {
                KeyBoardStateCache.AppCodeStack.Pop();
            }

            // 重新插入
            tempStackList.ForEach(x =>
            {
                KeyBoardStateCache.AppCodeStack.Push(x);
            });

            Messenger.Default.Unregister<dynamic>(this);
            UnRegisterKeyBoardMessage();
        }



        /// <summary>
        /// 保存数据
        /// </summary>
        protected override SaveResult SaveData()
        {
            TransactionParamsters tp = TransactionParamsters.Create();
            OperationStatus status = OperationStatusHelper.OperationStatusFromString(OperStatus);
            // 保存手术跳转明细记录
            this.SaveOperationJump(this.strReason, status, ref tp);
            // 更新主表手术间号
            this.SaveOperationMaster(ref tp);

            if (status == OperationStatus.IsReady)
            {
                DeleteAnesEvent();
                DeleteMonitorData();
                // 更新手术室数据
                this.SaveOperatingRoom(ref tp, true);
                // 更新监护仪数据
                this.SaveMonitorDict(ref tp, true);
            }
            if (this.CurPatientModel.OperStatusCode >= OperationStatus.OutOperationRoom && status != OperationStatus.IsReady)
            {
                // 更新手术室数据
                this.SaveOperatingRoom(ref tp, false);
                // 更新监护仪数据
                this.SaveMonitorDict(ref tp, false);
            }

            bool result = CommonService.ClientInstance.UpdateByTransaction(tp.ToString());

            // 刷新主界面信息
            Messenger.Default.Send<object>(this, EnumMessageKey.RefreshMainWindow);


            // 更新手术间字典表
            ApplicationModel.Instance.AllDictList.OperatingRoomList = DictService.ClientInstance.GetOperatingRoomList().Where(x => x.DEPT_CODE == ExtendAppContext.Current.OperDeptCode).ToList();

            // 更新字典表
            ApplicationModel.Instance.AllDictList.MonitorDictList = DictService.ClientInstance.GetMonitorDictList();

            return result ? SaveResult.Success : SaveResult.Fail;
        }
        /// <summary>
        /// 重置主表节点时间
        /// </summary>
        private MED_OPERATION_MASTER ResetOperationMaster(MED_OPERATION_MASTER master, OperationStatus status)
        {
            foreach (string s in OperationStatusHelper.OperationStatusList)
            {
                OperationStatus StatusFile = OperationStatusHelper.OperationStatusFromString(s);
                if (StatusFile == OperationStatus.TurnToEmergency || StatusFile == OperationStatus.TurnToICU || StatusFile == OperationStatus.TurnToSickRoom
                    || StatusFile == OperationStatus.TurnToMortuary || StatusFile == OperationStatus.TurnToPACU || StatusFile == OperationStatus.OutYouDao
                    || StatusFile == OperationStatus.OperScheduled || StatusFile == OperationStatus.None || StatusFile == OperationStatus.LeftHospital
                    || StatusFile == OperationStatus.InYouDao || StatusFile == OperationStatus.CancelOperation || StatusFile == OperationStatus.Done) continue;
                if (StatusFile > status)
                {
                    string dtField = OperationStatusHelper.GetTimeFieldName(StatusFile);
                    master.SetValue(dtField, null);
                }
            }
            return master;
        }
        /// <summary>
        /// 保存主表数据信息
        /// </summary>
        private void SaveOperationMaster(ref TransactionParamsters tp)
        {
            MED_OPERATION_MASTER master = AnesInfoService.ClientInstance.GetOperationMaster(this.CurPatientModel.PatientID, this.CurPatientModel.VisitID, this.CurPatientModel.OperID);

            OperationStatus status = OperationStatusHelper.OperationStatusFromString(OperStatus);

            if (status == OperationStatus.AnesthesiaEnd && this.CurPatientModel.OperStatusCode == OperationStatus.AnesthesiaStart)
            {
                master.ANES_END_TIME = this.AnesEndTime;
                master.OPER_STATUS_CODE = (int)OperationStatus.AnesthesiaEnd;
            }
            else
            {
                master = ResetOperationMaster(master, status);
                master.OPER_STATUS_CODE = (int)status;
            }

            if (this.CurPatientModel.OperStatusCode >= OperationStatus.OutOperationRoom)
            {
                master.OPER_ROOM_NO = this.OperRoomNo;
            }

            master.ModelStatus = ModelStatus.Modeified;
            tp.Append(master);
        }
        /// <summary>
        /// 删除事件表数据
        /// </summary>
        private void DeleteAnesEvent()
        {
            List<MED_ANESTHESIA_EVENT> eventList = AnesInfoService.ClientInstance.GetAnesthesiaEventList(this.CurPatientModel.PatientID, this.CurPatientModel.VisitID, this.CurPatientModel.OperID);
            AnesInfoService.ClientInstance.DeleteAnesthesiaEvent(eventList);
        }
        /// <summary>
        /// 删除体征表数据
        /// </summary>
        private void DeleteMonitorData()
        {
            List<MED_PAT_MONITOR_DATA> eventList = AnesInfoService.ClientInstance.GetPatMonitorDataList(this.CurPatientModel.PatientID, this.CurPatientModel.VisitID, this.CurPatientModel.OperID);
            List<MED_PAT_MONITOR_DATA_EXT> eventExtList = AnesInfoService.ClientInstance.GetPatMonitorExtList(this.CurPatientModel.PatientID, this.CurPatientModel.VisitID, this.CurPatientModel.OperID);
            AnesInfoService.ClientInstance.DeletePatMonitorData(eventList);
            AnesInfoService.ClientInstance.DeletePatMonitorExtData(eventExtList);
        }
        /// <summary>
        /// 保存监护仪字典信息
        /// </summary>
        private void SaveMonitorDict(ref TransactionParamsters tp, bool isDelete)
        {
            List<MED_MONITOR_DICT> tempMonitorDict = ApplicationModel.Instance.AllDictList.MonitorDictList.Where(x => x.WARD_TYPE.ToString() == ExtendAppContext.Current.EventNo && x.BED_NO == this.OperRoomNo).ToList();
            if (isDelete)
            {
                if (tempMonitorDict != null && tempMonitorDict.Count > 0)
                {
                    foreach (MED_MONITOR_DICT row in tempMonitorDict)
                    {
                        row.PATIENT_ID = "";
                        row.VISIT_ID = 0;
                        row.OPER_ID = 0;
                        row.ModelStatus = ModelStatus.Modeified;
                    }
                }
            }
            else
            {
                if (tempMonitorDict != null && tempMonitorDict.Count > 0)
                {
                    foreach (MED_MONITOR_DICT row in tempMonitorDict)
                    {
                        row.PATIENT_ID = this.CurPatientModel.PatientID;
                        row.VISIT_ID = this.CurPatientModel.VisitID;
                        row.OPER_ID = this.CurPatientModel.OperID;
                        row.ModelStatus = ModelStatus.Modeified;

                        // 如果选中的手术间是当前手术间，则自动启动监护仪
                        if (this.OperRoomNo.Equals(ExtendAppContext.Current.OperRoomNo))
                        {
                            // 自动启动监护仪
                            if (!string.IsNullOrEmpty(row.DRIVER_PROG))
                            {
                                string strPath = ExtendAppContext.Current.AppPath + row.DRIVER_PROG;
                                bool hasStart = false;
                                // 获取当前启动的所有进程
                                string strProcessName = row.DRIVER_PROG.Substring(0, row.DRIVER_PROG.ToLower().IndexOf(".exe"));
                                Process[] myProgress = Process.GetProcessesByName(strProcessName);
                                // 查看采集EXE是否启动
                                foreach (Process p in myProgress)
                                {
                                    if (p.ProcessName.Equals(strProcessName))
                                    {
                                        hasStart = true;
                                        break;
                                    }
                                }

                                // 进程没有启动同时采集EXE必须存在
                                if (!hasStart && File.Exists(strPath))
                                {
                                    System.Diagnostics.Process.Start(strPath);
                                }
                            }
                        }
                    }
                }
            }
            tp.Append(tempMonitorDict);
        }

        /// <summary>
        /// 保存手术间字典数据信息
        /// </summary>
        private void SaveOperatingRoom(ref TransactionParamsters tp, bool isDelete)
        {
            if (isDelete)
            {
                foreach (MED_OPERATING_ROOM room in this.MedOperatingRoomDict)
                {
                    // 将患者信息写入到新的手术间
                    if (room.ROOM_NO.Equals(this.OperRoomNo))
                    {
                        room.PATIENT_ID = "";
                        room.VISIT_ID = 0;
                        room.OPER_ID = 0;
                        room.ModelStatus = ModelStatus.Modeified;
                        tp.Append(room);
                        break;
                    }
                }
            }
            else
            {
                foreach (MED_OPERATING_ROOM room in this.MedOperatingRoomDict)
                {
                    // 将患者信息写入到新的手术间
                    if (room.ROOM_NO.Equals(this.OperRoomNo))
                    {
                        room.PATIENT_ID = this.CurPatientModel.PatientID;
                        room.VISIT_ID = this.CurPatientModel.VisitID;
                        room.OPER_ID = this.CurPatientModel.OperID;
                        room.ModelStatus = ModelStatus.Modeified;
                        tp.Append(room);
                        break;
                    }
                }
            }

        }

        /// <summary>
        /// 保存手术跳转记录数据
        /// </summary>
        private void SaveOperationJump(string strReason, OperationStatus status, ref TransactionParamsters tp)
        {
            List<MED_OPERATION_JUMP> list = CommonService.ClientInstance.GetOperationJump(this.CurPatientModel.PatientID, this.CurPatientModel.VisitID, this.CurPatientModel.OperID);
            MED_OPERATION_JUMP newRow = new MED_OPERATION_JUMP();
            newRow.PATIENT_ID = this.CurPatientModel.PatientID;
            newRow.VISIT_ID = this.CurPatientModel.VisitID;
            newRow.OPER_ID = this.CurPatientModel.OperID;
            newRow.JUMP_DATE = DateTime.Now;
            newRow.OPER_STATUS_OLD = (int)this.CurPatientModel.OperStatusCode;
            newRow.OPER_STATUS_NEW = (int)status;
            newRow.JUMP_REASON = strReason;
            newRow.ENTERED_BY = ExtendAppContext.Current.LoginUser.USER_JOB_ID;
            list.Add(newRow);
            tp.Append(list);
        }

        /// <summary>
        /// 在设置新的手术间前需要判断该手术间是否可以做手术
        /// </summary>
        protected bool CheckNewRoomNo(string strNewRoomNo)
        {
            bool result = true;
            MED_OPERATING_ROOM tarRoomNo = this.MedOperatingRoomDict.Where(x => x.ROOM_NO.Equals(strNewRoomNo) &&
                                                                                (null == x.PATIENT_ID || string.IsNullOrEmpty(x.PATIENT_ID))).FirstOrDefault();
            if (null == tarRoomNo)
            {
                result = false;
            }
            return result;
        }

    }
}
