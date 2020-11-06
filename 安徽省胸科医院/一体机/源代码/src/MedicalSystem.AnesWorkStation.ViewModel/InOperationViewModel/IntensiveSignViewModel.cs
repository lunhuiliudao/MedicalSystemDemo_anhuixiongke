//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      IntensiveSignViewModel.cs
//功能描述(Description)：    密集体征展现界面
//数据表(Tables)：		    MED_VITAL_SIGN 
//作者(Author)：             MDSD
//日期(Create Date)：        2017/12/27 09:30
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝=
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.Document.Controls;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.Model.AnesGraphModel;
using MedicalSystem.AnesWorkStation.Model.InOperationModel;
using System;
using System.Collections.Generic;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel
{
    public class IntensiveSignViewModel : BaseViewModel
    {
        private AxisSetting _xAxisSetting;
        /// <summary>
        /// X轴
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

        private List<YAxisSetting> _YAxis;
        /// <summary>
        /// Y轴
        /// </summary>
        public List<YAxisSetting> YAxis
        {
            get
            {
                return _YAxis;
            }
            set
            {
                _YAxis = value;
                RaisePropertyChanged("YAxis");
            }
        }
        private List<VitalSignCurveDetailModel> _Curves;
        /// <summary>
        /// 曲线list
        /// </summary>
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
        private Nullable<DateTime> _ProcessBeginTime;
        /// <summary>
        /// 开始时间
        /// </summary>
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
        /// <summary>
        /// 结束时间
        /// </summary>
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
        private MedVitalSignGraph _vitalSignGraph = null;
        private RescueTime _rescueTime = null;
        private List<MED_VITAL_SIGN> _vitalSignList = null;
        public IntensiveSignViewModel()
        {
            YAxis = new List<YAxisSetting>();
            YAxis = new List<YAxisSetting>() { 
                new YAxisSetting(){MinVal=0,MaxVal=320,MinorStep=0,MajorStep=20,IsPrimary=true,Index=0,Title="xxx",Unit="mmHg"}
                ,new YAxisSetting(){MinVal=10,MaxVal=42,MinorStep=0,MajorStep=2,IsPrimary=false,Index=1,Title="体温",Unit="℃"}
            };
        }

        /// <summary>
        /// 加载接受参数
        /// </summary>
        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
            _vitalSignGraph = Args[0] as MedVitalSignGraph;
            _rescueTime = Args[1] as RescueTime;

        }

        /// <summary>
        /// 载入数据
        /// </summary>
        public override void LoadData()
        {
            IntensiveSignRefresh();
            RegisterMessage();
        }

        /// <summary>
        /// 初始化体征数据
        /// </summary>
        private void IntensiveSignRefresh()
        {
            string patientID = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
            int visitID = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
            int operID = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;
            string eventNo = ExtendAppContext.Current.EventNo;
            if (_rescueTime.BeginTime.HasValue)
                ProcessBeginTime = _rescueTime.BeginTime.Value;
            else
                ProcessBeginTime = null;
            if (_rescueTime.EndTime.HasValue)
                ProcessEndTime = _rescueTime.EndTime.Value;
            _vitalSignList = AnesInfoService.ClientInstance.GetVitalSignData(patientID, visitID, operID, eventNo, true);
            ScheduledTimeViewModel scheduledTimeViewModel = new ScheduledTimeViewModel();
            DateTimeRangeModel timeRange = new DateTimeRangeModel(_rescueTime.BeginTime.Value, _rescueTime.EndTime == null ? _rescueTime.BeginTime.Value.AddMinutes(20) : _rescueTime.EndTime);
            xAxisSetting = scheduledTimeViewModel.SetAxisSetting(timeRange, true);

            VitalSignViewModel vitalSign = new VitalSignViewModel(_vitalSignList, null, _vitalSignGraph, _xAxisSetting);
            Curves = vitalSign.GetVitalSignCurve(true, _rescueTime);
        }
        private void RegisterMessage()
        {
            // 刷新整个界面
            Messenger.Default.Register<object>(this, EnumMessageKey.RefreshIntensiveSignVitalWindow, msg =>
            {
                IntensiveSignRefresh();
            });
        }

        /// <summary>
        /// 卸载消息
        /// </summary>
        public override void OnViewUnLoaded()
        {
            base.OnViewUnLoaded();
            Messenger.Default.Unregister<object>(this, EnumMessageKey.RefreshIntensiveSignVitalWindow);
        }

    }
}
