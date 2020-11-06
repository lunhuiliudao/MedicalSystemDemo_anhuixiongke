using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.Model.AnesGraphModel;
using MedicalSystem.AnesWorkStation.Model.InOperationModel;
using MedicalSystem.AnesWorkStation.Wpf.Message;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MedicalSystem.AnesWorkStation.ViewModel.AnesGraphViewModel
{
    public class TestViewModel : ViewModelBase
    {
        private List<IntakeAndOutputData> _InputOutData;
        private AxisSetting _xAxisSetting;
        private BreathParaModel _breathParam;
        private List<YAxisSetting> _YAxisSettings;
        private List<VitalSignCurveDetailModel> _Curves;
        private EventMarkModel _EventMark;
        private List<TextMarkPoint> _TextMarkPoints;
        private Nullable<DateTime> _ProcessBeginTime;
        private bool _IsEditEnable;
        private List<RescueTime> _RescueTimeList;
        private bool _IsHiddenEventMarkArea;

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
        public EventMarkModel EventMark
        {
            get
            {
                return _EventMark;
            }
            set
            {
                _EventMark = value;
                RaisePropertyChanged("EventMark");
            }
        }

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
        public bool IsEditEnable
        {
            get
            {
                return _IsEditEnable;
            }
            set
            {
                _IsEditEnable = value;
                RaisePropertyChanged("IsEditEnable");
            }
        }

        public bool IsHiddenEventMarkArea
        {
            get
            {
                return _IsHiddenEventMarkArea;
            }
            set
            {
                _IsHiddenEventMarkArea = value;
                RaisePropertyChanged("IsHiddenEventMarkArea");
            }
        }        

        /// <summary>
        /// 构造方法
        /// </summary>
        public TestViewModel()
        {
            //OperationDocLib lr = new OperationDocLib();
            //lr.GetAnesDoc("麻醉记录单");
            //var aaa = AnesInfoService.ClientInstance.GetAnesthesiaPlan("1153772", 1, 1);
            //LoadReport lr = new LoadReport();
            //lr.LoadReportByName("麻醉单");

            DateTime begin = DateTime.Now.Date.AddHours(9);
            List<IntakeAndOutputData> DataList = new List<IntakeAndOutputData>();

            IntakeAndOutputData data = new IntakeAndOutputData("氧气（吸入）", 5, "L/min");
            data.BeginTime = begin.AddMinutes(22);
            //data.EndTime = data.BeginTime.Value.AddMinutes(26);
            DataList.Add(data);

            data = new IntakeAndOutputData("5%葡萄糖", 500, "mL");
            data.OnetimeData = new IntakeAndOutputData.OneTimeIntakeAndOut(begin.AddMinutes(53));
            DataList.Add(data);
            data = new IntakeAndOutputData("10%葡萄糖", 500, "mL");
            data.OnetimeData = new IntakeAndOutputData.OneTimeIntakeAndOut(begin.AddMinutes(53));
            DataList.Add(data);
            data = new IntakeAndOutputData("15%葡萄糖", 500, "mL");
            data.OnetimeData = new IntakeAndOutputData.OneTimeIntakeAndOut(begin.AddMinutes(53));
            DataList.Add(data);

            data = new IntakeAndOutputData("尿", 1, "L", IntakeAndOutputType.Output);
            data.OnetimeData = new IntakeAndOutputData.OneTimeIntakeAndOut(begin.AddMinutes(33));
            DataList.Add(data);
            data = new IntakeAndOutputData("血", 500, "mL", IntakeAndOutputType.Output);
            data.OnetimeData = new IntakeAndOutputData.OneTimeIntakeAndOut(begin.AddMinutes(33));
            DataList.Add(data);
            data = new IntakeAndOutputData("引流", 500, "mL", IntakeAndOutputType.Output);
            data.OnetimeData = new IntakeAndOutputData.OneTimeIntakeAndOut(begin.AddMinutes(33));
            DataList.Add(data);
            data = new IntakeAndOutputData("引流1", 500, "mL", IntakeAndOutputType.Output);
            data.OnetimeData = new IntakeAndOutputData.OneTimeIntakeAndOut(begin.AddMinutes(33));
            DataList.Add(data);
            data = new IntakeAndOutputData("引流2", 500, "mL", IntakeAndOutputType.Output);
            data.OnetimeData = new IntakeAndOutputData.OneTimeIntakeAndOut(begin.AddMinutes(33));
            DataList.Add(data);
            data = new IntakeAndOutputData("引流3", 500, "mL", IntakeAndOutputType.Output);
            data.OnetimeData = new IntakeAndOutputData.OneTimeIntakeAndOut(begin.AddMinutes(33));
            DataList.Add(data);

            data = new IntakeAndOutputData("复方氯化钠注射液", 500, "ml", IntakeAndOutputType.Infusion);
            data.BeginTime = begin.AddMinutes(22);
            data.EndTime = data.BeginTime.Value.AddMinutes(39);
            DataList.Add(data);
            _InputOutData = DataList;

            AxisSetting axisSetting = new AxisSetting();
            axisSetting.BeginTime = begin;
            axisSetting.EndTime = begin.AddHours(3).AddMinutes(3);
            axisSetting.MoveMinLimitTime = begin.AddHours(-3);
            axisSetting.MoveMaxLimitTime = axisSetting.EndTime.Value.AddHours(1);
            xAxisSetting = axisSetting;

            _YAxisSettings = new List<YAxisSetting>() { 
                new YAxisSetting(){MinVal=0,MaxVal=320,MinorStep=0,MajorStep=20,IsPrimary=true,Index=0,Title="xxx",Unit="mmHg"}
                ,new YAxisSetting(){MinVal=10,MaxVal=42,MinorStep=0,MajorStep=2,IsPrimary=false,Index=1,Title="体温",Unit="℃"}
            };

            _RescueTimeList = new List<RescueTime>() { 
                new RescueTime(begin.AddMinutes(30), begin.AddHours(1))
                ,new RescueTime(begin.AddHours(2), begin.AddHours(2).AddMinutes(30))};           

            //画潮气量图标
            _breathParam = new BreathParaModel();
            _breathParam.TopParamName = "I:E";
            _breathParam.LeftParamName = "TVE";
            _breathParam.RightParamName = "f";
            _breathParam.BreathParalList.Add(begin.AddMinutes(68), new BreathParaDetail("30", "120", "40"));
            _breathParam.BreathParalList.Add(begin.AddMinutes(83), new BreathParaDetail("30", "120", "40"));
            _breathParam.BreathParalList.Add(begin.AddMinutes(95), new BreathParaDetail("30", "120", "40"));
            _breathParam.BreathParalList.Add(begin.AddMinutes(110), new BreathParaDetail("30", "120", "40"));

            //曲线
            _Curves = new List<VitalSignCurveDetailModel>();
            List<SymbolModel> symbolList = new List<SymbolModel>();
            symbolList.Add(new SymbolModel(SymbolType.None) { Text = "#" });
            Model.InOperationModel.VitalSignCurveDetailModel curve = new Model.InOperationModel.VitalSignCurveDetailModel("测试", 0, System.Drawing.Color.Blue, true);
            curve.Points = new List<VitalSignPointModel>();
            curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(68), "#", curve, null, string.Empty));
            curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(72), "#", curve, null, string.Empty));
            curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(83), "#", curve, null, string.Empty));
            curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(97), "#", curve, null, string.Empty));
            _Curves.Add(curve);

            curve = new Model.InOperationModel.VitalSignCurveDetailModel("测试2", 0, System.Drawing.Color.Blue, true);
            curve.Points = new List<VitalSignPointModel>();
            curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(68), "#", curve, null, string.Empty));
            curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(72), "#", curve, null, string.Empty));
            curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(83), "#", curve, null, string.Empty));
            curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(97), "#", curve, null, string.Empty));
            _Curves.Add(curve);

            curve = new Model.InOperationModel.VitalSignCurveDetailModel("舒张压", 0, System.Drawing.Color.FromArgb(0xFF, 0x1D, 0xAD, 0xE7));
            curve.Points = new List<VitalSignPointModel>();
            SymbolType stype = SymbolType.VLetter;
            SymbolModel smodel = new SymbolModel(stype);            
            curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(14), 100, curve, smodel, string.Empty));
            curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(32), 1300, curve, smodel, string.Empty));
            curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(64), 200, curve, smodel, string.Empty));
            curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(92), -100, curve, smodel, string.Empty));
            curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(120), 300, curve, smodel, string.Empty));
            curve.LegendList = new List<LegendItem>() { new LegendItem() { DisplayName = "舒张压", Symbol = smodel } };
            _Curves.Add(curve);

            curve = new Model.InOperationModel.VitalSignCurveDetailModel("收缩压", 0, System.Drawing.Color.RoyalBlue);
            curve.Points = new List<VitalSignPointModel>();
            stype = SymbolType.VLetterDown;
            smodel = new SymbolModel(stype);
            curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(11), 80, curve, smodel, string.Empty));
            curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(50), 110, curve, smodel, string.Empty));
            curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(64), 130, curve, smodel, string.Empty));
            curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(92), 150, curve, smodel, string.Empty));
            curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(120), 220, curve, smodel, string.Empty));
            curve.LegendList = new List<LegendItem>() { new LegendItem() { DisplayName = "收缩压", Symbol = smodel } };
            _Curves.Add(curve);

            curve = new Model.InOperationModel.VitalSignCurveDetailModel("测试的", 0, System.Drawing.Color.Chocolate);
            curve.Points = new List<VitalSignPointModel>();
            stype = SymbolType.Triangle;
            smodel = new SymbolModel(stype);
            curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(23), 60, curve, smodel, string.Empty));
            curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(32), 78, curve, smodel, string.Empty));
            curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(64), 82, curve, smodel, string.Empty));
            curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(92), 90, curve, smodel, string.Empty));
            curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(120), 110, curve, smodel, string.Empty));
            curve.LegendList = new List<LegendItem>() { new LegendItem() { DisplayName = "测试的", Symbol = smodel } };
            curve.HideTime = new List<DateTimeRangeModel>() { new DateTimeRangeModel(begin.AddMinutes(65), begin.AddMinutes(90)) };
            _Curves.Add(curve);

            curve = new Model.InOperationModel.VitalSignCurveDetailModel("测试的2", 0, System.Drawing.Color.Gray);
            curve.Points = new List<VitalSignPointModel>();
            stype = SymbolType.Circle;
            smodel = new SymbolModel(stype);
            curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(23), 80, curve, smodel, string.Empty));
            curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(32), 168, curve, smodel, string.Empty));
            curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(64), 172, curve, smodel, string.Empty));
            curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(92), 199, curve, smodel, string.Empty));
            curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(120), 153, curve, smodel, string.Empty));
            curve.LegendList = new List<LegendItem>() { new LegendItem() { DisplayName = "测试的2", Symbol = smodel } };
            _Curves.Add(curve);

            //事件
            _EventMark = new EventMarkModel();
            _EventMark.AddPoint(begin.AddMinutes(37), 12, "测试事件", new SymbolModel(SymbolType.CircleXCross), System.Drawing.Color.Red, "测试事件");
            _EventMark.AddPoint(begin.AddMinutes(50), 12, "测试事件1", new SymbolModel(SymbolType.CircleDot), System.Drawing.Color.Red, "测试事件1");
            _EventMark.AddPoint(begin.AddMinutes(53), 12, "测试事件2", new SymbolModel(SymbolType.CircleHArrow), System.Drawing.Color.Red, "测试事件2");
            _EventMark.AddPoint(begin.AddMinutes(54), 12, "测试事件3", new SymbolModel(SymbolType.CircleHLine), System.Drawing.Color.Red, "测试事件3");
            _EventMark.AddPoint(begin.AddMinutes(55), 12, "测试事件4", new SymbolModel(SymbolType.CirclePlus), System.Drawing.Color.Red, "测试事件4");
            _EventMark.AddPoint(begin.AddMinutes(59), 12, "测试事件6", new SymbolModel(SymbolType.CircleXCrossDot), System.Drawing.Color.Red, "测试事件5");
            _EventMark.AddPoint(begin.AddMinutes(65), 12, "测试事件7", new SymbolModel(SymbolType.Diamond), System.Drawing.Color.Red, "测试事件6");
            _EventMark.AddPoint(begin.AddMinutes(85), 12, "测试事件8", new SymbolModel(SymbolType.MiniCircle), System.Drawing.Color.Red, "测试事件7");

            _TextMarkPoints = new List<TextMarkPoint>();
            _TextMarkPoints.Add(new TextMarkPoint(begin.AddMinutes(53), "血气分析二\n血气分析二\n血气分析二\n血气分析二\n血气分析二\n血气分析二"));
            _TextMarkPoints.Add(new TextMarkPoint(begin.AddMinutes(85), "血气分析三\n血气分析三\n血气分析三\n血气分析三\n血气分析三\n血气分析三"));
            _TextMarkPoints.Add(new TextMarkPoint(begin.AddMinutes(147), "血气分析四\n血气分析四\n血气分析四\n血气分析四\n血气分析四\n血气分析四"));

            _ProcessBeginTime = begin.AddMinutes(54);

            _IsEditEnable = true;
            IsHiddenEventMarkArea = true;
        }
        #region Commands

        public ICommand GraphDoubleClickCommand
        {
            get
            {
                return new RelayCommand<IntakeAndOutputClickData>(data =>
                {
                    
                });
            }
        }

        public ICommand CurveSetCommand
        {
            get
            {
                return new RelayCommand<List<VitalSignCurveDetailModel>>(data =>
                {
                    RefreshDataCommand.Execute(null);
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
                    ProcessBeginTime = DateTime.Now.Date.AddHours(11).AddMinutes(20);
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
                });
            }
        }

        public ICommand RefreshDataCommand
        {
            get
            {
                return new RelayCommand<object>(e =>
                {
                    //EventMark.ClearPoints();
                    //EventMark = null;

                    DateTime begin = DateTime.Now.Date.AddHours(9);                     

                    EventMarkModel _EventMark1 = new EventMarkModel();
                    //_EventMark1.AddPoint(begin.AddMinutes(37), 12, "测试事件", new SymbolModel(SymbolType.CircleXCross), System.Drawing.Color.Red, "测试事件");
                    //_EventMark1.AddPoint(begin.AddMinutes(50), 12, "测试事件1", new SymbolModel(SymbolType.CircleDot), System.Drawing.Color.Red, "测试事件1");
                    //_EventMark1.AddPoint(begin.AddMinutes(53), 12, "测试事件2", new SymbolModel(SymbolType.CircleHArrow), System.Drawing.Color.Red, "测试事件2");
                    //_EventMark1.AddPoint(begin.AddMinutes(54), 12, "测试事件3", new SymbolModel(SymbolType.CircleHLine), System.Drawing.Color.Red, "测试事件3");
                    //_EventMark1.AddPoint(begin.AddMinutes(55), 12, "测试事件4", new SymbolModel(SymbolType.CirclePlus), System.Drawing.Color.Red, "测试事件4");
                    //_EventMark1.AddPoint(begin.AddMinutes(59), 12, "测试事件6", new SymbolModel(SymbolType.CircleXCrossDot), System.Drawing.Color.Red, "测试事件5");
                    _EventMark1.AddPoint(begin.AddMinutes(65), 12, "测试事件7", new SymbolModel(SymbolType.Diamond), System.Drawing.Color.Red, "测试事件6");
                    _EventMark1.AddPoint(begin.AddMinutes(85), 12, "测试事件8", new SymbolModel(SymbolType.MiniCircle), System.Drawing.Color.Red, "测试事件7");
                    _EventMark1.AddPoint(begin.AddMinutes(86), 12, "测试事件9", new SymbolModel(SymbolType.MiniCircle), System.Drawing.Color.Red, "测试事件9");
                    _EventMark1.AddPoint(begin.AddMinutes(87), 12, "测试事件10", new SymbolModel(SymbolType.MiniCircle), System.Drawing.Color.Red, "测试事件10");
                    _EventMark1.AddPoint(begin.AddMinutes(88), 12, "测试事件11", new SymbolModel(SymbolType.MiniCircle), System.Drawing.Color.Red, "测试事件11");
                    _EventMark1.AddPoint(begin.AddMinutes(89), 12, "测试事件12", new SymbolModel(SymbolType.MiniCircle), System.Drawing.Color.Red, "测试事件12");
                    _EventMark1.AddPoint(begin.AddMinutes(90), 12, "测试事件13", new SymbolModel(SymbolType.MiniCircle), System.Drawing.Color.Red, "测试事件13");
                    _EventMark1.AddPoint(begin.AddMinutes(91), 12, "测试事件14", new SymbolModel(SymbolType.MiniCircle), System.Drawing.Color.Red, "测试事件14");
                    _EventMark1.AddPoint(begin.AddMinutes(92), 12, "测试事件15", new SymbolModel(SymbolType.MiniCircle), System.Drawing.Color.Red, "测试事件15");
                    _EventMark1.AddPoint(begin.AddMinutes(93), 12, "测试事件16", new SymbolModel(SymbolType.MiniCircle), System.Drawing.Color.Red, "测试事件16");
                    _EventMark1.AddPoint(begin.AddMinutes(94), 12, "测试事件17", new SymbolModel(SymbolType.MiniCircle), System.Drawing.Color.Red, "测试事件17");
                    _EventMark1.AddPoint(begin.AddMinutes(95), 12, "测试事件18", new SymbolModel(SymbolType.MiniCircle), System.Drawing.Color.Red, "测试事件18");

                    EventMark = _EventMark1;

                    //曲线
                    List<VitalSignCurveDetailModel> _Curves2 = new List<VitalSignCurveDetailModel>();
                    List<SymbolModel> symbolList = new List<SymbolModel>();
                    symbolList.Add(new SymbolModel(SymbolType.None) { Text = "#" });
                    Model.InOperationModel.VitalSignCurveDetailModel curve = new Model.InOperationModel.VitalSignCurveDetailModel("测试", 0, System.Drawing.Color.Blue, true);
                    curve.Points = new List<VitalSignPointModel>();
                    curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(68), "#", curve, null, string.Empty));
                    curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(72), "#", curve, null, string.Empty));
                    curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(83), "#", curve, null, string.Empty));
                    curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(97), "#", curve, null, string.Empty));
                    _Curves2.Add(curve);

                    if (_Curves.FindAll(p => p.ShowType == CurveShowType.Digit && p.Visible).Count > 1)
                    {
                        curve = new Model.InOperationModel.VitalSignCurveDetailModel("测试X", 0, System.Drawing.Color.Blue, true);
                        curve.Visible = false;
                        curve.Points = new List<VitalSignPointModel>();
                        curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(68), "#", curve, null, string.Empty));
                        curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(72), "#", curve, null, string.Empty));
                        curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(83), "#", curve, null, string.Empty));
                        curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(97), "#", curve, null, string.Empty));
                        _Curves2.Add(curve);
                    }
                    else
                    {
                        curve = new Model.InOperationModel.VitalSignCurveDetailModel("测试2", 0, System.Drawing.Color.Blue, true);
                        curve.Points = new List<VitalSignPointModel>();
                        curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(68), "#", curve, null, string.Empty));
                        curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(72), "#", curve, null, string.Empty));
                        curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(83), "#", curve, null, string.Empty));
                        curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(97), "#", curve, null, string.Empty));
                        _Curves2.Add(curve);
                    }

                    //curve = new Model.InOperationModel.VitalSignCurveDetailModel("测试2", 0, System.Drawing.Color.Blue, true);
                    //curve.Points = new List<VitalSignPointModel>();
                    //curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(68), "#", curve, null, string.Empty));
                    //curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(72), "#", curve, null, string.Empty));
                    //curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(83), "#", curve, null, string.Empty));
                    //curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(97), "#", curve, null, string.Empty));
                    //_Curves2.Add(curve);

                    //curve = new Model.InOperationModel.VitalSignCurveDetailModel("测试X", 0, System.Drawing.Color.Blue, true);
                    //curve.Points = new List<VitalSignPointModel>();
                    //curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(68), "#", curve, null, string.Empty));
                    //curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(72), "#", curve, null, string.Empty));
                    //curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(83), "#", curve, null, string.Empty));
                    //curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(97), "#", curve, null, string.Empty));
                    //_Curves2.Add(curve);

                    curve = new Model.InOperationModel.VitalSignCurveDetailModel("舒张压", 0, System.Drawing.Color.FromArgb(0xFF, 0x1D, 0xAD, 0xE7));
                    curve.Points = new List<VitalSignPointModel>();
                    SymbolType stype = SymbolType.VLetter;
                    SymbolModel smodel = new SymbolModel(stype);
                    curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(14), 100, curve, smodel, string.Empty));
                    curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(32), 1300, curve, smodel, string.Empty));
                    curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(64), 200, curve, smodel, string.Empty));
                    curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(92), -100, curve, smodel, string.Empty));
                    curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(120), 300, curve, smodel, string.Empty));
                    curve.LegendList = new List<LegendItem>() { new LegendItem() { DisplayName = "舒张压", Symbol = smodel } };
                    _Curves2.Add(curve);

                    curve = new Model.InOperationModel.VitalSignCurveDetailModel("收缩压", 0, System.Drawing.Color.RoyalBlue);
                    curve.Points = new List<VitalSignPointModel>();
                    stype = SymbolType.VLetterDown;
                    smodel = new SymbolModel(stype);
                    curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(11), 80, curve, smodel, string.Empty));
                    curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(50), 110, curve, smodel, string.Empty));
                    curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(64), 130, curve, smodel, string.Empty));
                    curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(92), 150, curve, smodel, string.Empty));
                    curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(120), 220, curve, smodel, string.Empty));
                    curve.LegendList = new List<LegendItem>() { new LegendItem() { DisplayName = "收缩压", Symbol = smodel } };
                    _Curves2.Add(curve);

                    curve = new Model.InOperationModel.VitalSignCurveDetailModel("测试的", 0, System.Drawing.Color.Chocolate);
                    curve.Points = new List<VitalSignPointModel>();
                    stype = SymbolType.Triangle;
                    smodel = new SymbolModel(stype);
                    curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(23), 60, curve, smodel, string.Empty));
                    curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(32), 78, curve, smodel, string.Empty));
                    curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(64), 82, curve, smodel, string.Empty));
                    curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(92), 89.6, curve, smodel, string.Empty));
                    curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(120), 110.7, curve, smodel, string.Empty));
                    curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(130), 100.1, curve, smodel, string.Empty));
                    curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(140), 110.6, curve, smodel, string.Empty));
                    curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(150), 88.5, curve, smodel, string.Empty));
                    curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(160), 77.6, curve, smodel, string.Empty));
                    curve.LegendList = new List<LegendItem>() { new LegendItem() { DisplayName = "测试的", Symbol = smodel } };
                    curve.HideTime = new List<DateTimeRangeModel>() { new DateTimeRangeModel(begin.AddMinutes(65), begin.AddMinutes(95)) 
                        ,new DateTimeRangeModel(begin.AddMinutes(131), begin.AddMinutes(155))
                        ,new DateTimeRangeModel(begin.AddMinutes(161), null)};
                    _Curves2.Add(curve);

                    curve = new Model.InOperationModel.VitalSignCurveDetailModel("测试的2", 0, System.Drawing.Color.Gray);
                    curve.Points = new List<VitalSignPointModel>();
                    stype = SymbolType.Circle;
                    smodel = new SymbolModel(stype);
                    curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(23), 80, curve, smodel, string.Empty));
                    curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(32), 168, curve, smodel, string.Empty));
                    curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(64), 172, curve, smodel, string.Empty));
                    curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(92), 199, curve, smodel, string.Empty));
                    curve.Points.Add(new VitalSignPointModel(begin.AddMinutes(120), 153, curve, smodel, string.Empty));
                    curve.LegendList = new List<LegendItem>() { new LegendItem() { DisplayName = "测试的2", Symbol = smodel } };
                    _Curves2.Add(curve);
                    Curves = _Curves2;

                    IsEditEnable = true;
                });
            }
        }
        
        #endregion
        
    }
}