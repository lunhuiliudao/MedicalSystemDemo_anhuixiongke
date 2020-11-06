//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      DrugGraphViewModel.cs
//功能描述(Description)：    术中大事件界面对应的ViewModel
//数据表(Tables)：		     无
//作者(Author)：             MDSD
//日期(Create Date)：        2017-12-27 10:49:12
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.Model.AnesGraphModel;
using MedicalSystem.AnesWorkStation.Model.InOperationModel;
using MedicalSystem.AnesWorkStation.ViewModel.Cache;
using MedicalSystem.AnesWorkStation.Wpf.Message;
using MedicalSystem.Services;
using MedicalSystem.UsbKeyBoard;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel
{
    /// <summary>
    /// 当前用药明细
    /// </summary>
    public class DrugGraphViewModel : BaseViewModel
    {
        #region 变量和构造函数
        private List<IntakeAndOutputData> _InputOutData;
        private AxisSetting _xAxisSetting;
        /// <summary>
        /// 定义异步刷新方法
        /// </summary>
        private MedicalSystem.Anes.FrameWork.DelegateCommonObject.DelegateMethod DelegateRefreshAnesEventWindow = null;

        /// <summary>
        /// 传入数据
        /// </summary>
        public List<IntakeAndOutputData> InputOutData
        {
            get
            {
                return _InputOutData;
            }
            set
            {
                _InputOutData = value;
                RaisePropertyChanged("InputOutData");
            }
        }

        /// <summary>
        /// 网格设置
        /// </summary>
        public AxisSetting xAxisSetting
        {
            get
            {
                return _xAxisSetting;
            }
            set
            {
                _xAxisSetting = value;
                RaisePropertyChanged("xAxisSetting");
            }
        }

        private string _patientID;
        private int _visitID;
        private int _operID;
        private string _eventNo;

        #endregion

        public DrugGraphViewModel()
        {
            try
            {
                RegisterMessage();
            }
            catch (Exception ex)
            {
                Logger.Error("用药栏异常信息", ex);
                ShowMessageBox(ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        protected override void KeyBoardMessage(string keyCode)
        {
            ShowContentWindowMessage message;
            switch (keyCode)
            {
                case KeyCode.AppCode.AnesDrug:
                    message = new ShowContentWindowMessage("OperationMedNoteControl", "麻药录入");
                    message.Height = 600;
                    message.Width = 750;
                    message.CallBackCommand = ClosingWindow;
                    message.Args = new object[] { KeyCode.AppCode.AnesDrug };
                    ExtendAppContext.Current.CurntOpenForm = new OpenForm(KeyCode.AppCode.AnesDrug, null);
                    Messenger.Default.Send<ShowContentWindowMessage>(message);
                    break;
                case KeyCode.AppCode.Drug:
                    message = new ShowContentWindowMessage("OperationMedNoteControl", "用药录入");
                    message.Height = 600;
                    message.Width = 750;
                    message.CallBackCommand = ClosingWindow;
                    message.Args = new object[] { KeyCode.AppCode.Drug };
                    ExtendAppContext.Current.CurntOpenForm = new OpenForm(KeyCode.AppCode.Drug, null);
                    Messenger.Default.Send<ShowContentWindowMessage>(message);
                    break;
                case KeyCode.AppCode.InLiquid:
                    message = new ShowContentWindowMessage("OperationMedNoteControl", "输液录入");
                    message.Height = 600;
                    message.Width = 750;
                    message.CallBackCommand = ClosingWindow;
                    message.Args = new object[] { KeyCode.AppCode.InLiquid };
                    ExtendAppContext.Current.CurntOpenForm = new OpenForm(KeyCode.AppCode.InLiquid, null);
                    Messenger.Default.Send<ShowContentWindowMessage>(message);
                    break;
                case KeyCode.AppCode.Breath:
                    message = new ShowContentWindowMessage("OperationMedNoteControl", "呼吸录入");
                    message.Height = 600;
                    message.Width = 750;
                    message.CallBackCommand = ClosingWindow;
                    message.Args = new object[] { KeyCode.AppCode.Breath };
                    ExtendAppContext.Current.CurntOpenForm = new OpenForm(KeyCode.AppCode.Breath, null);
                    Messenger.Default.Send<ShowContentWindowMessage>(message);
                    break;
                case KeyCode.AppCode.Oxygen:
                    message = new ShowContentWindowMessage("OperationMedNoteControl", "输氧录入");
                    message.Height = 600;
                    message.Width = 750;
                    message.CallBackCommand = ClosingWindow;
                    message.Args = new object[] { KeyCode.AppCode.Oxygen };
                    ExtendAppContext.Current.CurntOpenForm = new OpenForm(KeyCode.AppCode.Oxygen, null);
                    Messenger.Default.Send<ShowContentWindowMessage>(message);
                    break;
                case KeyCode.AppCode.Blood:
                    message = new ShowContentWindowMessage("OperationMedNoteControl", "输血录入");
                    message.Height = 600;
                    message.Width = 750;
                    message.CallBackCommand = ClosingWindow;
                    message.Args = new object[] { KeyCode.AppCode.Blood };
                    ExtendAppContext.Current.CurntOpenForm = new OpenForm(KeyCode.AppCode.Blood, null);
                    Messenger.Default.Send<ShowContentWindowMessage>(message);
                    break;
                case KeyCode.AppCode.Intubatton:
                    message = new ShowContentWindowMessage("OperationEventNoteControl", "插管录入");
                    message.Height = 600;
                    message.Width = 750;
                    message.CallBackCommand = ClosingWindow;
                    message.Args = new object[] { KeyCode.AppCode.Intubatton };
                    ExtendAppContext.Current.CurntOpenForm = new OpenForm(KeyCode.AppCode.Intubatton, null);
                    Messenger.Default.Send<ShowContentWindowMessage>(message);
                    break;
                case KeyCode.AppCode.Extubation:
                    message = new ShowContentWindowMessage("OperationEventNoteControl", "拔管录入");
                    message.Height = 600;
                    message.Width = 750;
                    message.CallBackCommand = ClosingWindow;
                    message.Args = new object[] { KeyCode.AppCode.Extubation };
                    ExtendAppContext.Current.CurntOpenForm = new OpenForm(KeyCode.AppCode.Extubation, null);
                    Messenger.Default.Send<ShowContentWindowMessage>(message);
                    break;
                case KeyCode.AppCode.OutLiquid:
                    message = new ShowContentWindowMessage("OperationMedNoteControl", "出液录入");
                    message.Height = 600;
                    message.Width = 750;
                    message.CallBackCommand = ClosingWindow;
                    message.Args = new object[] { KeyCode.AppCode.OutLiquid };
                    ExtendAppContext.Current.CurntOpenForm = new OpenForm(KeyCode.AppCode.OutLiquid, null);
                    Messenger.Default.Send<ShowContentWindowMessage>(message);
                    break;
                case KeyCode.AppCode.AnesPath:
                    message = new ShowContentWindowMessage("AnesthesiaPathControl", "麻醉路径");
                    message.Height = 600;
                    message.Width = 750;
                    message.CallBackCommand = ClosingWindow;
                    message.Args = new object[] { KeyCode.AppCode.AnesPath };
                    ExtendAppContext.Current.CurntOpenForm = new OpenForm(KeyCode.AppCode.AnesPath, null);
                    Messenger.Default.Send<ShowContentWindowMessage>(message);
                    break;
            }
        }

        private void RegisterMessage()
        {
            // 刷新整个界面
            Messenger.Default.Register<object>(this, EnumMessageKey.RefreshAnesEventWindow, msg =>
            {
                if (null == this.DelegateRefreshAnesEventWindow)
                {
                    this.DelegateRefreshAnesEventWindow = this.LoadData;
                }
                this.DelegateRefreshAnesEventWindow.BeginInvoke(null, null);
            });
        }

        public override void LoadData()
        {
            if (ExtendAppContext.Current.PatientInformationExtend == null)
                return;
            _patientID = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
            _visitID = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
            _operID = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;
            _eventNo = "0";


            var anesEvent = AnesInfoService.ClientInstance.GetAnesthesiaEventByEventNo(_patientID, _visitID, _operID, _eventNo);
            var vitalSign = AnesInfoService.ClientInstance.GetVitalSignData(_patientID, _visitID, _operID, _eventNo, false);
            var operMaster = AnesInfoService.ClientInstance.GetOperationMaster(_patientID, _visitID, _operID);
            ScheduledTimeViewModel scheduledTimeViewModel = new ScheduledTimeViewModel();
            DateTimeRangeModel pageTimeRange = scheduledTimeViewModel.GetGraphDateTime(vitalSign, anesEvent, _eventNo, operMaster);
            xAxisSetting = scheduledTimeViewModel.SetAxisSetting(pageTimeRange, false);

            List<IntakeAndOutputData> DataList = new List<IntakeAndOutputData>();
            var listItem = anesEvent.FindAll(delegate(MED_ANESTHESIA_EVENT a)
            {
                return a.EVENT_CLASS_CODE == "2" || a.EVENT_CLASS_CODE == "3"
                    || a.EVENT_CLASS_CODE == "4" || a.EVENT_CLASS_CODE == "B"
                    || a.EVENT_CLASS_CODE == "C" || a.EVENT_CLASS_CODE == "D";
            });

            var oxygen = listItem.FindAll(delegate(MED_ANESTHESIA_EVENT a)
            {
                return a.EVENT_CLASS_CODE == "4";
            });
            if (oxygen.Count > 0)
            {
                foreach (var item in oxygen)
                {
                    double showNum = 0;
                    double.TryParse(item.PERFORM_SPEED.ToString(), out showNum);
                    IntakeAndOutputData data = new IntakeAndOutputData(item.EVENT_ITEM_NAME, showNum, item.SPEED_UNIT);
                    data.BeginTime = item.START_TIME.Value.AddSeconds(0 - item.START_TIME.Value.Second);
                    if (item.END_TIME != null)
                    {
                        data.EndTime = item.END_TIME.Value.AddSeconds(0 - item.END_TIME.Value.Second);
                    }
                    data.ToolTip = "";
                    DataList.Add(data);
                }
            }

            foreach (var item in listItem)
            {
                if (item.EVENT_CLASS_CODE == "2" || item.EVENT_CLASS_CODE == "C")
                {
                    IntakeAndOutputData data;
                    if (item.DURATIVE_INDICATOR == 1)
                    {
                        double showNum = 0;
                        if (item.PERFORM_SPEED.HasValue || item.PERFORM_SPEED > 0)
                        {
                            double.TryParse(item.PERFORM_SPEED.ToString(), out showNum);
                            data = new IntakeAndOutputData(item.EVENT_ITEM_NAME, showNum, item.SPEED_UNIT);
                        }
                        else
                        {
                            double.TryParse(item.DOSAGE.ToString(), out showNum);
                            data = new IntakeAndOutputData(item.EVENT_ITEM_NAME, showNum, item.DOSAGE_UNITS);
                        }
                        data.BeginTime = item.START_TIME.Value.AddSeconds(0 - item.START_TIME.Value.Second);
                        if (item.END_TIME != null)
                            data.EndTime = item.END_TIME.Value.AddSeconds(0 - item.END_TIME.Value.Second);
                    }
                    else
                    {
                        double showNum = 0;
                        double.TryParse(item.DOSAGE.ToString(), out showNum);
                        data = new IntakeAndOutputData(item.EVENT_ITEM_NAME, showNum, item.DOSAGE_UNITS);
                        data.OnetimeData = new IntakeAndOutputData.OneTimeIntakeAndOut(item.START_TIME != null ? item.START_TIME.Value.AddSeconds(0 - item.START_TIME.Value.Second) : DateTime.Now);
                    }
                    DataList.Add(data);
                }
                else if (item.EVENT_CLASS_CODE == "D")
                {
                    double showNum = 0;
                    double.TryParse(item.DOSAGE.ToString(), out showNum);
                    IntakeAndOutputData data = new IntakeAndOutputData(item.EVENT_ITEM_NAME, showNum, item.DOSAGE_UNITS, IntakeAndOutputType.Output);
                    if (item.DURATIVE_INDICATOR == 1)
                    {
                        data.BeginTime = item.START_TIME.Value.AddSeconds(0 - item.START_TIME.Value.Second);
                        if (item.END_TIME != null)
                            data.EndTime = item.END_TIME.Value.AddSeconds(0 - item.END_TIME.Value.Second);
                    }
                    else
                    {
                        if (item.EVENT_ITEM_NAME.Contains("尿"))
                        {
                            data.OnetimeData = new IntakeAndOutputData.OneTimeIntakeAndOut(item.START_TIME != null ? item.START_TIME.Value.AddSeconds(0 - item.START_TIME.Value.Second) : DateTime.Now, "尿", Color.FromRgb(0x66, 0xFF, 0xCC));
                        }
                        else if (item.EVENT_ITEM_NAME.Contains("血"))
                        {
                            data.OnetimeData = new IntakeAndOutputData.OneTimeIntakeAndOut(item.START_TIME != null ? item.START_TIME.Value.AddSeconds(0 - item.START_TIME.Value.Second) : DateTime.Now, "血", Color.FromRgb(0xCC, 0xCC, 0x00));
                        }
                        else
                        {
                            data.OnetimeData = new IntakeAndOutputData.OneTimeIntakeAndOut(item.START_TIME != null ? item.START_TIME.Value.AddSeconds(0 - item.START_TIME.Value.Second) : DateTime.Now, "引", Color.FromRgb(0xCC, 0xCC, 0x00));
                        }
                    }
                    DataList.Add(data);
                }
                else if (item.EVENT_CLASS_CODE == "3" || item.EVENT_CLASS_CODE == "B")
                {
                    IntakeAndOutputData data;
                    if (item.DURATIVE_INDICATOR == 1)
                    {
                        double showNum = 0;
                        //if (item.PERFORM_SPEED.HasValue || item.PERFORM_SPEED > 0)
                        //{
                        //    double.TryParse(item.PERFORM_SPEED.ToString(), out showNum);
                        //    data = new IntakeAndOutputData(item.EVENT_ITEM_NAME, showNum, item.SPEED_UNIT, IntakeAndOutputType.Infusion);
                        //}
                        //else
                        //{
                        double.TryParse(item.DOSAGE.ToString(), out showNum);
                        data = new IntakeAndOutputData(item.EVENT_ITEM_NAME, showNum, item.DOSAGE_UNITS, IntakeAndOutputType.Infusion);
                        //}
                        data.BeginTime = item.START_TIME.Value.AddSeconds(0 - item.START_TIME.Value.Second);
                        if (item.END_TIME != null)
                            data.EndTime = item.END_TIME.Value.AddSeconds(0 - item.END_TIME.Value.Second);
                    }
                    else
                    {
                        double showNum = 0;
                        double.TryParse(item.DOSAGE.ToString(), out showNum);
                        data = new IntakeAndOutputData(item.EVENT_ITEM_NAME, showNum, item.DOSAGE_UNITS, IntakeAndOutputType.Infusion);
                        data.OnetimeData = new IntakeAndOutputData.OneTimeIntakeAndOut(item.START_TIME != null ? item.START_TIME.Value.AddSeconds(0 - item.START_TIME.Value.Second) : DateTime.Now);
                    }
                    DataList.Add(data);
                }
            }
            InputOutData = DataList;
        }

        public void UpdateDataPoint(IntakeAndOutputData data, DateTime? time)
        {
            var anesEvent = AnesInfoService.ClientInstance.GetAnesthesiaEventByEventNo(_patientID, _visitID, _operID, _eventNo);
            foreach (MED_ANESTHESIA_EVENT row in anesEvent)
            {
                if (row.EVENT_ITEM_NAME == data.Name)
                {
                    if (row.DURATIVE_INDICATOR == 1)
                    {
                        // 会导致所有的数据都跟着变
                        if ((data.BeginTime.HasValue && row.START_TIME.HasValue && data.BeginTime.Value == row.START_TIME.Value) ||
                           (data.EndTime.HasValue && row.END_TIME.HasValue && data.EndTime.Value == row.END_TIME.Value))
                        {
                            row.START_TIME = data.BeginTime;
                            row.END_TIME = data.EndTime;
                            row.ModelStatus = ModelStatus.Modeified;
                            break;
                        }
                    }
                    else
                    {
                        if (row.START_TIME >= time.Value.AddMinutes(-1) && row.START_TIME <= time.Value.AddMinutes(1))
                        {
                            row.START_TIME = data.OnetimeData.ExcuteTime;
                            row.ModelStatus = ModelStatus.Modeified;
                            break;
                        }
                    }
                }
            }
            AnesInfoService.ClientInstance.UpadteAnesthesiaEvent(anesEvent);
        }
        /// <summary>
        /// 关闭窗体事件
        /// </summary>
        /// <param name="e"></param>
        public override void OnPreviewViewUnLoaded(System.ComponentModel.CancelEventArgs e)
        {
            base.OnPreviewViewUnLoaded(e);
        }

        #region Commands


        public ICommand DataPointDragCommand
        {
            get
            {
                return new RelayCommand<IntakeAndOutputDataEventArgs>(data =>
                {
                    var point = data.DataPoint;
                    var time = data.BeforeTime;
                    UpdateDataPoint(point, time);
                });
            }
        }
        public ICommand GraphDoubleClickCommand
        {
            get
            {
                return new RelayCommand<IntakeAndOutputClickData>(data =>
                {
                    var message = new ShowContentWindowMessage("OperationMedNoteControl", "用药录入");
                    if (data.InAndOutType == IntakeAndOutputType.Medicine)
                    {
                        message.Title = "用药录入";
                    }
                    else if (data.InAndOutType == IntakeAndOutputType.Output)
                    {
                        message.Title = "出量录入";
                    }
                    else if (data.InAndOutType == IntakeAndOutputType.Infusion)
                    {
                        message.Title = "输液&输血录入";
                    }
                    message.Height = 600;
                    message.Width = 750;
                    message.CallBackCommand = ClosingWindow;
                    message.Args = new object[] { data };
                    KeyBoardStateCache.CurrentAppCode = AppCode.AnesDrug;
                    Messenger.Default.Send<ShowContentWindowMessage>(message);
                });
            }
        }

        public ICommand ClosingWindow
        {
            get
            {
                return new RelayCommand<string>(key =>
                  {
                      Messenger.Default.Send<object>(this, EnumMessageKey.RefreshAnesEventWindow);
                      //Messenger.Default.Send<object>(this, EnumMessageKey.RefreshSignVitalWindow);
                  }
                  );
            }
        }
        #endregion
    }
}
