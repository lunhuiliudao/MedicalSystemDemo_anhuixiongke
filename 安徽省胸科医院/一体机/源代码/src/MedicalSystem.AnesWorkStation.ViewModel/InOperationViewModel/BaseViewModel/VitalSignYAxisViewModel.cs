//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      VitalSignYAxisViewModel.cs
//功能描述(Description)：    术中体征界面对应的ViewModel
//数据表(Tables)：		     无
//作者(Author)：             MDSD
//日期(Create Date)：        2017-12-27 10:49:12
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Domain.Origins;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.Model.AnesGraphModel;
using MedicalSystem.AnesWorkStation.Model.InOperationModel;
using MedicalSystem.AnesWorkStation.ViewModel.Cache;
using MedicalSystem.AnesWorkStation.Wpf.Message;
using MedicalSystem.Services;
using MedicalSystem.UsbKeyBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel
{
    public class VitalSignYAxisViewModel : BaseViewModel
    {
        private AxisSetting _xAxisSetting;
        private BreathParaModel _breathParam;
        private List<YAxisSetting> _YAxisSettings;
        private List<VitalSignCurveDetailModel> _Curves;
        private List<RescueTime> _RescueTimeList;
        /// <summary>
        /// 定义异步刷新数据
        /// </summary>
        private MedicalSystem.Anes.FrameWork.DelegateCommonObject.DelegateMethod DelegateRefreshSignVitalWindow = null;

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
        public List<YAxisSetting> YAxisSettings
        {
            get
            {
                return _YAxisSettings;
            }
            set
            {
                _YAxisSettings = value;
                RaisePropertyChanged("YAxisSettings");
            }
        }
        public BreathParaModel BreathParam
        {
            get
            {
                return _breathParam;
            }
            set
            {
                _breathParam = value;
                RaisePropertyChanged("BreathParam");
            }
        }
        public List<VitalSignCurveDetailModel> Curves
        {
            get
            {
                return _Curves;
            }
            set
            {
                _Curves = value;
                RaisePropertyChanged("Curves");
            }
        }
        private EventMarkModel _eventMark;
        public EventMarkModel EventMark
        {
            get
            {
                return _eventMark;
            }
            set
            {
                _eventMark = value;
                RaisePropertyChanged("EventMark");
            }
        }
        private List<TextMarkPoint> _TextMarkPoints;
        public List<TextMarkPoint> TextMarkPoints
        {
            get
            {
                return _TextMarkPoints;
            }
            set
            {
                _TextMarkPoints = value;
                RaisePropertyChanged("TextMarkPoints");
            }
        }
        private Nullable<DateTime> _ProcessBeginTime;
        public Nullable<DateTime> ProcessBeginTime
        {
            get
            {
                return _ProcessBeginTime;
            }
            set
            {
                _ProcessBeginTime = value;
                RaisePropertyChanged("ProcessBeginTime");
            }
        }
        private Nullable<DateTime> _ProcessEndTime;
        public Nullable<DateTime> ProcessEndTime
        {
            get
            {
                return _ProcessEndTime;
            }
            set
            {
                _ProcessEndTime = value;
                RaisePropertyChanged("ProcessEndTime");
            }
        }
        private bool _isVitalSignsEditEnable = true;
        public bool IsVitalSignsEditEnable
        {
            get
            {
                return _isVitalSignsEditEnable;
            }
            set
            {
                _isVitalSignsEditEnable = value;
                RaisePropertyChanged("IsVitalSignsEditEnable");
            }
        }
        public List<RescueTime> RescueTimeList
        {
            get
            {
                return _RescueTimeList;
            }
            set
            {
                _RescueTimeList = value;
                RaisePropertyChanged("RescueTimeList");
            }
        }
        private List<MED_VITAL_SIGN> _vitalSignList = null;
        private List<MED_ANESTHESIA_EVENT> _anesEventList = null;
        private MED_OPERATION_MASTER _operMaster = null;

        private MedVitalSignGraph _vitalSignGraph = null;
        public VitalSignYAxisViewModel()
        {
            _YAxisSettings = new List<YAxisSetting>() { 
                new YAxisSetting(){MinVal=0,MaxVal=320,MinorStep=0,MajorStep=20,IsPrimary=true,Index=0,Title="xxx",Unit="mmHg"}
                ,new YAxisSetting(){MinVal=10,MaxVal=42,MinorStep=0,MajorStep=2,IsPrimary=false,Index=1,Title="体温",Unit="℃"}
            };

            RegisterMessage();
        }

        protected override void KeyBoardMessage(string keyCode)
        {
            ShowContentWindowMessage message;
            switch (keyCode)
            {
                case KeyCode.AppCode.VitalSigns:
                    message = new ShowContentWindowMessage("SignEntryControl", "体征录入");
                    message.Height = 680;
                    message.Width = 750;
                    message.CallBackCommand = VitalSignsEditorCommand;
                    ExtendAppContext.Current.CurntOpenForm = new OpenForm(KeyCode.AppCode.VitalSigns, null);
                    Messenger.Default.Send<ShowContentWindowMessage>(message);
                    break;
                case KeyCode.AppCode.Event:
                    message = new ShowContentWindowMessage("OperationEventNoteControl", "事件录入");
                    message.Height = 600;
                    message.Width = 750;
                    message.CallBackCommand = VitalSignsEditorCommand;
                    message.Args = new object[] { KeyCode.AppCode.Event };
                    ExtendAppContext.Current.CurntOpenForm = new OpenForm(KeyCode.AppCode.Event, null);
                    Messenger.Default.Send<ShowContentWindowMessage>(message);
                    break;
            }

        }
        private void RegisterMessage()
        {
            // 刷新整个界面
            Messenger.Default.Register<object>(this, EnumMessageKey.RefreshSignVitalWindow, msg =>
            {
                if (null == this.DelegateRefreshSignVitalWindow)
                {
                    this.DelegateRefreshSignVitalWindow = this.LoadVitalSignControl;
                }

                this.DelegateRefreshSignVitalWindow.BeginInvoke(null, null);
            });
        }

        public override void LoadData()
        {
            //加载数据
            if (ExtendAppContext.Current._VitalSignGraph == null)
            {
                ApplicationConfiguration.MedicalDocucementElement document = ApplicationConfiguration.GetMedicalDocument("麻醉记录单");
                string _reportName = ExtendAppContext.Current.AppPath + document.Path;
                Panel p = new Panel();
                AssemblyHelper.ReadFile(_reportName, p);
                ReadControl(p);
                p.Dispose();
            }
            else
            {
                _vitalSignGraph = ExtendAppContext.Current._VitalSignGraph;
            }
        }

        public void ReadControl(Control ctrl)
        {
            // MedVitalSignGraph vitalGraph = null;
            foreach (Control control in ctrl.Controls)
            {
                if (control.HasChildren)
                {
                    ReadControl(control);
                }
                if (control is MedVitalSignGraph)
                {
                    _vitalSignGraph = control as MedVitalSignGraph;
                    ExtendAppContext.Current._VitalSignGraph = _vitalSignGraph;
                    try
                    {
                        LoadVitalSignControl();
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("加载体征数据异常", ex);

                    }
                }
            }
        }
        protected void LoadVitalSignControl()
        {
            if (null == ExtendAppContext.Current.PatientInformationExtend)
            {
                return;
            }

            IsVitalSignsEditEnable = ExtendAppContext.Current.IsModify & ExtendAppContext.Current.IsPermission;
            string patientID = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
            int visitID = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
            int operID = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;
            string eventNo = ExtendAppContext.Current.EventNo;
            _vitalSignList = AnesInfoService.ClientInstance.GetVitalSignData(patientID, visitID, operID, eventNo, false);
            _anesEventList = AnesInfoService.ClientInstance.GetAnesthesiaEventByEventNo(patientID, visitID, operID, eventNo);
            _operMaster = AnesInfoService.ClientInstance.GetOperationMaster(patientID, visitID, operID);
            if (_operMaster.IN_DATE_TIME.HasValue)
                ProcessBeginTime = _operMaster.IN_DATE_TIME;
            else
                ProcessBeginTime = null;
            if (_operMaster.END_DATE_TIME.HasValue)
                ProcessEndTime = _operMaster.OUT_DATE_TIME;
            else
                ProcessEndTime = null;
            List<MED_OPERATION_RESCUE> operRescueList = CommonService.ClientInstance.GetOperationRescue(patientID, visitID, operID);
            List<MED_CAMERA_PICINFO> cameraList = CareDocService.ClientInstance.GetPicInfoList(patientID, visitID, operID);
            RescueTimeList = new List<RescueTime>();
            if (operRescueList != null && operRescueList.Count > 0)
            {
                foreach (MED_OPERATION_RESCUE row in operRescueList)
                {
                    RescueTimeList.Add(new RescueTime(row.START_DATE_TIME, row.END_DATE_TIME));
                }
            }
            if (ExtendAppContext.Current.IsOperationRescuing && ExtendAppContext.Current.OperationRescueStartTime != null && ExtendAppContext.Current.OperationRescueStartTime != DateTime.MinValue)
            {
                RescueTimeList.Add(new RescueTime(ExtendAppContext.Current.OperationRescueStartTime, null));
            }

            if (cameraList != null && cameraList.Count > 0)
            {
                foreach (MED_CAMERA_PICINFO row in cameraList)
                {
                    RescueTimeList.Add(new RescueTime(row.UPDATE_TIME));
                }
            }

            ScheduledTimeViewModel scheduledTimeViewModel = new ScheduledTimeViewModel();
            DateTimeRangeModel pageTimeRange = scheduledTimeViewModel.GetGraphDateTime(_vitalSignList, _anesEventList, eventNo, _operMaster);
            xAxisSetting = scheduledTimeViewModel.SetAxisSetting(pageTimeRange, false);

            VitalSignViewModel vitalSign = new VitalSignViewModel(_vitalSignList, _anesEventList, _vitalSignGraph, _xAxisSetting);
            Curves = vitalSign.GetVitalSignCurve(false, null);
            TextMarkPoints = vitalSign.GetBloodGasItems(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID, ExtendAppContext.Current.PatientInformationExtend.VISIT_ID,
                 ExtendAppContext.Current.PatientInformationExtend.OPER_ID);
            EventMarkViewModel eventMark = new EventMarkViewModel(_anesEventList, _operMaster, _vitalSignGraph);
            EventMark = eventMark.GetEventMark();
            BreathParaViewModel breathViewModel = new BreathParaViewModel(_vitalSignGraph);
            BreathParam = breathViewModel.GetBreathPara();

        }
        /// <summary>
        /// 移动体征
        /// </summary>
        public void MovingPoints(VitalSignPointModel point)
        {
            MED_VITAL_SIGN row = _vitalSignList.Where(x => x.ITEM_CODE == point.Curve.CurveCode && x.TIME_POINT == point.Time).FirstOrDefault();
            if (row != null)
            {
                if (row.ITEM_VALUE != point.Value.ToString())
                {
                    row.ITEM_VALUE = point.Value.ToString();
                }
                try
                {
                    SavePoints(row);
                }
                catch (Exception ex)
                {
                    Logger.Error("移动体征保存数据异常", ex);
                }
            }
            else
            {
                row = new MED_VITAL_SIGN();
                row.ITEM_CODE = point.Curve.CurveCode;
                row.ITEM_NAME = point.Curve.CurveName;
                row.TIME_POINT = point.Time;
                row.ITEM_VALUE = point.Value.ToString();
                row.Flag = "2";
                try
                {
                    SavePoints(row);
                }
                catch (Exception ex)
                {
                    Logger.Error("移动体征保存数据异常", ex);
                }
            }
        }
        public void SavePoints(MED_VITAL_SIGN row)
        {
            List<MED_PAT_MONITOR_DATA_EXT> patientMonitorExt = AnesInfoService.ClientInstance.GetPatMonitorExtListByEvent(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID,
               ExtendAppContext.Current.PatientInformationExtend.VISIT_ID, ExtendAppContext.Current.PatientInformationExtend.OPER_ID, ExtendAppContext.Current.EventNo);
            if (patientMonitorExt != null && patientMonitorExt.Count > 0)
            {
                List<MED_PAT_MONITOR_DATA_EXT> monitorExt = patientMonitorExt.Where(x => x.TIME_POINT.Equals(row.TIME_POINT) && x.ITEM_CODE.Equals(row.ITEM_CODE)).ToList();
                if (monitorExt != null && monitorExt.Count > 0)
                {
                    MED_PAT_MONITOR_DATA_EXT patientMonitorDataRow = monitorExt[0];
                    patientMonitorDataRow.ITEM_VALUE = row.ITEM_VALUE;
                    patientMonitorDataRow.LAST_MODIFY_DATE = DateTime.Now;
                    patientMonitorDataRow.OPERATOR = ExtendAppContext.Current.LoginUser == null ? "" : ExtendAppContext.Current.LoginUser.USER_JOB_ID;
                    patientMonitorDataRow.DATA_MARK = 1;
                    patientMonitorDataRow.ModelStatus = ModelStatus.Modeified;
                }
                else
                {
                    MED_PAT_MONITOR_DATA_EXT patientMonitorDataRow = new MED_PAT_MONITOR_DATA_EXT();
                    patientMonitorDataRow.PATIENT_ID = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
                    patientMonitorDataRow.VISIT_ID = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
                    patientMonitorDataRow.OPER_ID = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;
                    patientMonitorDataRow.TIME_POINT = row.TIME_POINT;
                    patientMonitorDataRow.ITEM_NAME = row.ITEM_NAME;
                    patientMonitorDataRow.ITEM_CODE = row.ITEM_CODE;
                    patientMonitorDataRow.ITEM_VALUE = row.ITEM_VALUE;
                    patientMonitorDataRow.DATA_TYPE = ExtendAppContext.Current.EventNo;
                    patientMonitorDataRow.LAST_MODIFY_DATE = DateTime.Now;
                    patientMonitorDataRow.OPERATOR = ExtendAppContext.Current.LoginUser == null ? "" : ExtendAppContext.Current.LoginUser.USER_JOB_ID;
                    patientMonitorDataRow.DATA_MARK = 1;
                    patientMonitorDataRow.ModelStatus = ModelStatus.Add;
                    patientMonitorExt.Add(patientMonitorDataRow);
                }
            }
            else
            {
                MED_PAT_MONITOR_DATA_EXT patientMonitorDataRow = new MED_PAT_MONITOR_DATA_EXT();
                patientMonitorDataRow.PATIENT_ID = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
                patientMonitorDataRow.VISIT_ID = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
                patientMonitorDataRow.OPER_ID = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;
                patientMonitorDataRow.TIME_POINT = row.TIME_POINT;
                patientMonitorDataRow.ITEM_NAME = row.ITEM_NAME;
                patientMonitorDataRow.ITEM_CODE = row.ITEM_CODE;
                patientMonitorDataRow.ITEM_VALUE = row.ITEM_VALUE;
                patientMonitorDataRow.DATA_TYPE = ExtendAppContext.Current.EventNo;
                patientMonitorDataRow.LAST_MODIFY_DATE = DateTime.Now;
                patientMonitorDataRow.OPERATOR = ExtendAppContext.Current.LoginUser == null ? "" : ExtendAppContext.Current.LoginUser.USER_JOB_ID;
                patientMonitorDataRow.DATA_MARK = 1;
                patientMonitorDataRow.ModelStatus = ModelStatus.Add;
                patientMonitorExt.Add(patientMonitorDataRow);
            }
            AnesInfoService.ClientInstance.SavePatMonitorExtList(patientMonitorExt);

        }


        /// <summary>
        /// 关闭窗体事件
        /// </summary>
        /// <param name="e"></param>
        public override void OnPreviewViewUnLoaded(System.ComponentModel.CancelEventArgs e)
        {
            base.OnPreviewViewUnLoaded(e);
            Messenger.Default.Unregister<string>(this);
        }

        #region Commands

        public ICommand VitalSignsEditorCommand
        {
            get
            {
                return new RelayCommand<string>(key =>
                {
                    LoadVitalSignControl();
                }
                  );
            }
        }

        public ICommand CurveSetCommand
        {
            get
            {
                return new RelayCommand<List<VitalSignCurveDetailModel>>(data =>
                {
                    var message = new ShowContentWindowMessage("IndividuationVitalSignControl", "体征配置");////SignSwicthControl
                    message.Height = 640;
                    message.Width = 750;
                    message.Args = new object[] { data };
                    message.CallBackCommand = VitalSignsEditorCommand;
                    Messenger.Default.Send<ShowContentWindowMessage>(message);
                });
            }
        }

        public ICommand CurvePointDoubleClickCommand
        {
            get
            {
                return new RelayCommand<CurveEventArgs>(e =>
                {
                    var point = e.Point;
                    if (point.Curve.CurveCode == "92")
                    {

                    }
                });
            }
        }
        public ICommand ChartDoubleClickCommand
        {
            get
            {
                return new RelayCommand<CurveEventArgs>(e =>
                {
                    var time = e.CurrentTime;

                });
            }
        }
        public ICommand CurvePointDragCommand
        {
            get
            {
                return new RelayCommand<CurveEventArgs>(e =>
                {
                    var point = e.Point;
                    MovingPoints(point);
                });
            }
        }
        public ICommand RescueClickCommand
        {
            get
            {
                return new RelayCommand<RescueEventArgs>(e =>
                {
                    var rescueTime = e.RescueTimePeroid;
                    if (rescueTime != null)
                    {
                        if (rescueTime.CameraTime.HasValue)
                        {
                            var message = new ShowContentWindowMessage("CameraControl", "拍照");
                            message.Height = 660;
                            message.Width = 600;
                            message.WindowType = ContentWindowType.Document;
                            message.Args = new Object[] { rescueTime.CameraTime };
                            Messenger.Default.Send<ShowContentWindowMessage>(message);
                        }
                        else
                        {
                            KeyBoardStateCache.CurrentAppCode = AppCode.Rescue;
                            var message = new ShowContentWindowMessage("IntensiveSignControl", "密集体征显示");
                            message.Height = 640;
                            message.Width = 750;
                            message.Args = new Object[] { _vitalSignGraph, rescueTime };
                            Messenger.Default.Send<ShowContentWindowMessage>(message);
                        }
                    }
                });
            }
        }
        #endregion

    }
}
