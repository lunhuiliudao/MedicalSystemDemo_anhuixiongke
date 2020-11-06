using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.Framework.Utilities;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.InHospitalRegisterViewModel
{
    public class DateRegisterViewModel : BaseViewModel
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public DateRegisterViewModel()
        {
            // 载入字典数据
            LoadDictData();
            //todo 测试不明情况MED_OPERATING_ROOM中数据会被清空
            MED_OPERATING_ROOM = DictService.ClientInstance.GetOperatingRoomList().Where(x => x.DEPT_CODE == ExtendAppContext.Current.OperDeptCode).ToList();

            this.RegisterMessage();
        }

        #region 界面绑定相关字段
        #region 界面控件字段绑定
        private string _OPER_ROOM_NO;                                              // 手术间号
        private Nullable<Int32> _SEQUENCE;                                         // 台次
        private string _PATIENT_ID;                                                // 患者ID
        private string _INP_NO;                                                    // 住院号
        private string _NAME;                                                      // 姓名
        private string _SEX;                                                       // 性别
        private Nullable<DateTime> _DATE_OF_BIRTH;                                 // 出生日期
        private string _AGE;                                                          // 年龄
        private string _BED_NO;                                                    // 床号
        private Nullable<DateTime> _IN_DATE_TIME;
        private Nullable<DateTime> _START_DATE_TIME;
        private Nullable<DateTime> _ANES_START_TIME;
        private Nullable<DateTime> _ANES_END_TIME;
        private Nullable<DateTime> _END_DATE_TIME;
        private Nullable<DateTime> _OUT_DATE_TIME;
        private string ViewFlag;                                                 // 记录页面具体类型，入室，手术开始，手术结束等
        private int operStatusCode;
        private int curntStatusCode;
        int visibIndex = 0;
        int enableIndex = 0;

        //分别是时间编辑是否可见、背景是否可见、时间是否可编辑和是否时间已录完
        private Visibility _inRoomVisible = Visibility.Collapsed;
        private Visibility _inRoomBackVisible = Visibility.Collapsed;
        private bool _inRoomEnable = false;
        private bool _inRoomFinish = false;

        private Visibility _anesStartVisible = Visibility.Collapsed;
        private Visibility _anesStartBackVisible = Visibility.Collapsed;
        private bool _anesStartEnable = false;
        private bool _anesStartFinish = false;

        private Visibility _operStartVisible = Visibility.Collapsed;
        private Visibility _operStartBackVisible = Visibility.Collapsed;
        private bool _operStartEnable = false;
        private bool _operStartFinish = false;

        private Visibility _operEndVisible = Visibility.Collapsed;
        private Visibility _operEndBackVisible = Visibility.Collapsed;
        private bool _operEndEnable = false;
        private bool _operEndFinish = false;

        private Visibility _anesEndVisible = Visibility.Collapsed;
        private Visibility _anesEndBackVisible = Visibility.Collapsed;
        private bool _anesEndEnable = false;
        private bool _anesEndFinish = false;

        private Visibility _outRoomVisible = Visibility.Collapsed;
        private Visibility _outRoomBackVisible = Visibility.Collapsed;
        private bool _outRoomEnable = false;
        private bool _outRoomFinish = false;

        private int _stepIndex = 0;

        private string _titleText = "";

        /// <summary>
        /// 入手术室
        /// </summary>
        public Nullable<DateTime> IN_DATE_TIME
        {
            get
            {
                return _IN_DATE_TIME;
            }
            set
            {
                this._IN_DATE_TIME = value;
                RaisePropertyChanged("IN_DATE_TIME");
            }
        }

        /// <summary>
        /// 手术开始
        /// </summary>
        public Nullable<DateTime> START_DATE_TIME
        {
            get
            {
                return _START_DATE_TIME;
            }
            set
            {
                this._START_DATE_TIME = value;
                RaisePropertyChanged("START_DATE_TIME");
            }
        }

        /// <summary>
        /// 麻醉开始
        /// </summary>
        public Nullable<DateTime> ANES_START_TIME
        {
            get
            {
                return _ANES_START_TIME;
            }
            set
            {
                this._ANES_START_TIME = value;
                RaisePropertyChanged("ANES_START_TIME");
            }
        }

        /// <summary>
        /// 麻醉结束
        /// </summary>
        public Nullable<DateTime> ANES_END_TIME
        {
            get
            {
                return _ANES_END_TIME;
            }
            set
            {
                this._ANES_END_TIME = value;
                RaisePropertyChanged("ANES_END_TIME");
            }
        }

        /// <summary>
        /// 手术结束
        /// </summary>
        public Nullable<DateTime> END_DATE_TIME
        {
            get
            {
                return _END_DATE_TIME;
            }
            set
            {
                this._END_DATE_TIME = value;
                RaisePropertyChanged("END_DATE_TIME");
            }
        }

        /// <summary>
        /// 出手术室
        /// </summary>
        public Nullable<DateTime> OUT_DATE_TIME
        {
            get
            {
                return _OUT_DATE_TIME;
            }
            set
            {
                this._OUT_DATE_TIME = value;
                RaisePropertyChanged("OUT_DATE_TIME");
            }
        }

        public Visibility InRoomVisible
        {
            get { return _inRoomVisible; }
            set
            {
                _inRoomVisible = value;
                RaisePropertyChanged("InRoomVisible");
            }
        }

        public Visibility InRoomBackVisible
        {
            get { return _inRoomBackVisible; }
            set
            {
                _inRoomBackVisible = value;
                RaisePropertyChanged("InRoomBackVisible");
            }
        }
        public bool InRoomEnable
        {
            get { return _inRoomEnable; }
            set
            {
                _inRoomEnable = value;
                RaisePropertyChanged("InRoomEnable");
            }
        }
        public bool InRoomFinish
        {
            get { return _inRoomFinish; }
            set
            {
                _inRoomFinish = value;
                RaisePropertyChanged("InRoomFinish");
            }
        }
        public Visibility AnesStartVisible
        {
            get { return _anesStartVisible; }
            set
            {
                _anesStartVisible = value;
                RaisePropertyChanged("AnesStartVisible");
            }
        }
        public Visibility AnesStartBackVisible
        {
            get { return _anesStartBackVisible; }
            set
            {
                _anesStartBackVisible = value;
                RaisePropertyChanged("AnesStartBackVisible");
            }
        }
        public bool AnesStartEnable
        {
            get { return _anesStartEnable; }
            set
            {
                _anesStartEnable = value;
                RaisePropertyChanged("AnesStartEnable");
            }
        }
        public bool AnesStartFinish
        {
            get { return _anesStartFinish; }
            set
            {
                _anesStartFinish = value;
                RaisePropertyChanged("AnesStartFinish");
            }
        }
        public Visibility OperStartVisible
        {
            get { return _operStartVisible; }
            set
            {
                _operStartVisible = value;
                RaisePropertyChanged("OperStartVisible");
            }
        }
        public Visibility OperStartBackVisible
        {
            get { return _operStartBackVisible; }
            set
            {
                _operStartBackVisible = value;
                RaisePropertyChanged("OperStartBackVisible");
            }
        }
        public bool OperStartEnable
        {
            get { return _operStartEnable; }
            set
            {
                _operStartEnable = value;
                RaisePropertyChanged("OperStartEnable");
            }
        }
        public bool OperStartFinish
        {
            get { return _operStartFinish; }
            set
            {
                _operStartFinish = value;
                RaisePropertyChanged("OperStartFinish");
            }
        }
        public Visibility OperEndVisible
        {
            get { return _operEndVisible; }
            set
            {
                _operEndVisible = value;
                RaisePropertyChanged("OperEndVisible");
            }
        }
        public Visibility OperEndBackVisible
        {
            get { return _operEndBackVisible; }
            set
            {
                _operEndBackVisible = value;
                RaisePropertyChanged("OperEndBackVisible");
            }
        }
        public bool OperEndEnable
        {
            get { return _operEndEnable; }
            set
            {
                _operEndEnable = value;
                RaisePropertyChanged("OperEndEnable");
            }
        }
        public bool OperEndFinish
        {
            get { return _operEndFinish; }
            set
            {
                _operEndFinish = value;
                RaisePropertyChanged("OperEndFinish");
            }
        }
        public Visibility AnesEndVisible
        {
            get { return _anesEndVisible; }
            set
            {
                _anesEndVisible = value;
                RaisePropertyChanged("AnesEndVisible");
            }
        }
        public Visibility AnesEndBackVisible
        {
            get { return _anesEndBackVisible; }
            set
            {
                _anesEndBackVisible = value;
                RaisePropertyChanged("AnesEndBackVisible");
            }
        }
        public bool AnesEndEnable
        {
            get { return _anesEndEnable; }
            set
            {
                _anesEndEnable = value;
                RaisePropertyChanged("AnesEndEnable");
            }
        }
        public bool AnesEndFinish
        {
            get { return _anesEndFinish; }
            set
            {
                _anesEndFinish = value;
                RaisePropertyChanged("AnesEndFinish");
            }
        }
        public Visibility OutRoomVisible
        {
            get { return _outRoomVisible; }
            set
            {
                _outRoomVisible = value;
                RaisePropertyChanged("OutRoomVisible");
            }
        }
        public Visibility OutRoomBackVisible
        {
            get { return _outRoomBackVisible; }
            set
            {
                _outRoomBackVisible = value;
                RaisePropertyChanged("OutRoomBackVisible");
            }
        }
        public bool OutRoomEnable
        {
            get { return _outRoomEnable; }
            set
            {
                _outRoomEnable = value;
                RaisePropertyChanged("OutRoomEnable");
            }
        }
        public bool OutRoomFinish
        {
            get { return _outRoomFinish; }
            set
            {
                _outRoomFinish = value;
                RaisePropertyChanged("OutRoomFinish");
            }
        }

        public int StepIndex
        {
            get { return _stepIndex; }
            set
            {
                _stepIndex = value;
                RaisePropertyChanged("StepIndex");
            }
        }
        public string TitleText
        {
            get
            {
                return _titleText;
            }
            set
            {
                _titleText = value;
                RaisePropertyChanged("TitleText");
            }
        }

        /// <summary>
        /// 手术间号
        /// </summary>
        public string OPER_ROOM_NO
        {
            get
            {
                return _OPER_ROOM_NO;
            }
            set
            {
                this._OPER_ROOM_NO = value;
                RaisePropertyChanged("OPER_ROOM_NO");
            }
        }
        /// <summary>
        /// 台次
        /// </summary>
        public Nullable<Int32> SEQUENCE
        {
            get
            {
                return _SEQUENCE;
            }
            set
            {
                this._SEQUENCE = value;
                RaisePropertyChanged("SEQUENCE");
            }
        }
        /// <summary>
        /// 患者ID
        /// </summary>
        public string PATIENT_ID
        {
            get
            {
                return _PATIENT_ID;
            }
            set
            {
                this._PATIENT_ID = value;
                RaisePropertyChanged("PATIENT_ID");
            }
        }
        /// <summary>
        /// 住院号
        /// </summary>
        public string INP_NO
        {
            get
            {
                return _INP_NO;
            }
            set
            {
                this._INP_NO = value;
                RaisePropertyChanged("INP_NO");
            }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string NAME
        {
            get
            {
                return _NAME;
            }
            set
            {
                this._NAME = value;
                RaisePropertyChanged("NAME");
            }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string SEX
        {
            get
            {
                return _SEX;
            }
            set
            {
                this._SEX = value;
                RaisePropertyChanged("SEX");
            }
        }
        /// <summary>
        /// 出生年月
        /// </summary>
        public Nullable<DateTime> DATE_OF_BIRTH
        {
            get
            {
                return _DATE_OF_BIRTH;
            }
            set
            {
                this._DATE_OF_BIRTH = value;
                RaisePropertyChanged("DATE_OF_BIRTH");
            }
        }
        /// <summary>
        /// 年龄
        /// </summary>
        public string AGE
        {
            get { return _AGE; }
            set
            {
                _AGE = value;
                RaisePropertyChanged("AGE");
            }
        }
        /// <summary>
        /// 床号
        /// </summary>
        public string BED_NO
        {
            get
            {
                return _BED_NO;
            }
            set
            {
                this._BED_NO = value;
                RaisePropertyChanged("BED_NO");
            }
        }

        #endregion

        #endregion

        #region 数据源
        MED_OPERATION_MASTER _masterRow;
        MED_PATS_IN_HOSPITAL _patsInHospitalRow;
        MED_PAT_MASTER_INDEX _patMasterIndexRow;
        MED_ANESTHESIA_PLAN _anesthesiaPlanRow;
        #endregion

        #region 方法

        /// <summary>
        /// 注册命令
        /// </summary>
        public void RegisterMessage()
        {
            Messenger.Default.Register<object>(this, EnumMessageKey.ChangeDateRegister, msg =>
            {
                if (null != msg && !string.IsNullOrEmpty(msg.ToString()) && this.CheckData())
                {
                    this.SaveData();
                    ViewFlag = msg.ToString();

                    // 执行的手术时间必须是按顺序
                    // 当前手术状态
                    OperationStatus curOperStatus = (OperationStatus)_masterRow.OPER_STATUS_CODE;
                    OperationStatus nextOperStatus = OperationStatus.None;

                    // 目标状态
                    OperationStatus targetOperStatus = OperationStatusHelper.OperationStatusFromString(ViewFlag);

                    if (curOperStatus >= targetOperStatus)
                    {
                    }
                    else
                    {
                        switch (curOperStatus)
                        {
                            case OperationStatus.InOperationRoom:
                                nextOperStatus = OperationStatus.AnesthesiaStart;
                                break;
                            case OperationStatus.AnesthesiaStart:
                                nextOperStatus = OperationStatus.OperationStart;
                                break;
                            case OperationStatus.OperationStart:
                                nextOperStatus = OperationStatus.OperationEnd;
                                break;
                            case OperationStatus.OperationEnd:
                                nextOperStatus = OperationStatus.AnesthesiaEnd;
                                break;
                            case OperationStatus.AnesthesiaEnd:
                                nextOperStatus = OperationStatus.OutOperationRoom;
                                break;
                        }

                        if (nextOperStatus == OperationStatus.None || nextOperStatus != targetOperStatus)
                        {
                            this.ShowMessageBox("请按流程顺序操作！", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        else if (nextOperStatus == targetOperStatus &&
                                 nextOperStatus == OperationStatus.OutOperationRoom)
                        {
                            this.Result = true;
                            this.CloseContentWindow();
                        }
                    }

                    this.InRoomVisible = Visibility.Collapsed;
                    this.InRoomBackVisible = Visibility.Collapsed;
                    this.InRoomEnable = false;
                    this.InRoomFinish = false;

                    this.AnesStartVisible = Visibility.Collapsed;
                    this.AnesStartBackVisible = Visibility.Collapsed;
                    this.AnesStartEnable = false;
                    this.AnesStartFinish = false;

                    this.OperStartVisible = Visibility.Collapsed;
                    this.OperStartBackVisible = Visibility.Collapsed;
                    this.OperStartEnable = false;
                    this.OperStartFinish = false;

                    this.OperEndVisible = Visibility.Collapsed;
                    this.OperEndBackVisible = Visibility.Collapsed;
                    this.OperEndEnable = false;
                    this.OperEndFinish = false;

                    this.AnesEndVisible = Visibility.Collapsed;
                    this.AnesEndBackVisible = Visibility.Collapsed;
                    this.AnesEndEnable = false;
                    this.AnesEndFinish = false;

                    this.OutRoomVisible = Visibility.Collapsed;
                    this.OutRoomBackVisible = Visibility.Collapsed;
                    this.OutRoomEnable = false;
                    this.OutRoomFinish = false;
                    this.LoadData();
                    Messenger.Default.Send<object>(true, EnumMessageKey.RefreshDateRegisterFocus);
                }
            });
        }

        /// <summary>
        /// 载入数据
        /// </summary>
        public override void LoadData()
        {
            try
            {
                if (string.IsNullOrEmpty(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID))
                    return;
                _masterRow = AnesInfoService.ClientInstance.GetOperationMaster(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID,
                    ExtendAppContext.Current.PatientInformationExtend.VISIT_ID, ExtendAppContext.Current.PatientInformationExtend.OPER_ID);
                if (_masterRow != null && !string.IsNullOrEmpty(_masterRow.PATIENT_ID))
                {
                    _patsInHospitalRow = AnesInfoService.ClientInstance.GetPatsInHospitalListByID(_masterRow.PATIENT_ID).OrderByDescending(c => c.VISIT_ID).ToList().First();
                    _patMasterIndexRow = AnesInfoService.ClientInstance.GetPatMasterIndex(_masterRow.PATIENT_ID).First();

                    _anesthesiaPlanRow = AnesInfoService.ClientInstance.GetAnesthesiaPlan(_masterRow.PATIENT_ID, _masterRow.VISIT_ID, _masterRow.OPER_ID).First();

                    OPER_ROOM_NO = _masterRow.OPER_ROOM_NO;
                    SEQUENCE = _masterRow.SEQUENCE;
                    PATIENT_ID = _masterRow.PATIENT_ID;
                    INP_NO = _patsInHospitalRow.INP_NO;
                    NAME = _patMasterIndexRow.NAME;
                    SEX = _patMasterIndexRow.SEX;
                    DATE_OF_BIRTH = _patMasterIndexRow.DATE_OF_BIRTH;
                    BED_NO = _masterRow.BED_NO;
                    operStatusCode = _masterRow.OPER_STATUS_CODE;
                    AGE = DateDiff.CalAge((DateTime)_patMasterIndexRow.DATE_OF_BIRTH, _masterRow.SCHEDULED_DATE_TIME.Value);
                    TitleText = string.Format("编辑{0}时间", ViewFlag);
                    SetOperStatusEnable();
                    SetOperStatusDate();
                }
            }
            catch (Exception ex)
            {
                Logger.Error("获取患者信息发生异常", ex);
                ShowMessageBox(ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SetOperStatusEnable()
        {
            OperationStatus operSate = OperationStatusHelper.OperationStatusFromString(ViewFlag);
            int patStatuIndex = OperationStatusHelper.GetOperStatusIndex(ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE);
            int curntEditIndex = OperationStatusHelper.GetOperStatusIndex((int)operSate);
            //当前编辑已填写的状态的时间
            if (patStatuIndex > curntEditIndex)
            {
                visibIndex = patStatuIndex;
            }
            //编辑新的状态时间
            else
            {
                visibIndex = curntEditIndex;
                operStatusCode = (int)operSate;
            }
            StepIndex = visibIndex - 1;
            curntStatusCode = (int)operSate;

            enableIndex = curntEditIndex;


            switch (visibIndex)
            {
                case 1:
                    InRoomVisible = Visibility.Visible;
                    InRoomFinish = true;
                    break;
                case 2:
                    InRoomVisible = Visibility.Visible;
                    AnesStartVisible = Visibility.Visible;
                    InRoomFinish = true;
                    AnesStartFinish = true;
                    break;
                case 3:
                    InRoomVisible = Visibility.Visible;
                    AnesStartVisible = Visibility.Visible;
                    OperStartVisible = Visibility.Visible;
                    InRoomFinish = true;
                    AnesStartFinish = true;
                    OperStartFinish = true;
                    break;
                case 4:
                    InRoomVisible = Visibility.Visible;
                    AnesStartVisible = Visibility.Visible;
                    OperStartVisible = Visibility.Visible;
                    OperEndVisible = Visibility.Visible;
                    InRoomFinish = true;
                    AnesStartFinish = true;
                    OperStartFinish = true;
                    OperEndFinish = true;
                    break;
                case 5:
                    InRoomVisible = Visibility.Visible;
                    AnesStartVisible = Visibility.Visible;
                    OperStartVisible = Visibility.Visible;
                    OperEndVisible = Visibility.Visible;
                    AnesEndVisible = Visibility.Visible;
                    InRoomFinish = true;
                    AnesStartFinish = true;
                    OperStartFinish = true;
                    OperEndFinish = true;
                    AnesEndFinish = true;
                    break;
                case 6:
                    InRoomVisible = Visibility.Visible;
                    AnesStartVisible = Visibility.Visible;
                    OperStartVisible = Visibility.Visible;
                    OperEndVisible = Visibility.Visible;
                    AnesEndVisible = Visibility.Visible;
                    OutRoomVisible = Visibility.Visible;
                    InRoomFinish = true;
                    AnesStartFinish = true;
                    OperStartFinish = true;
                    OperEndFinish = true;
                    AnesEndFinish = true;
                    OutRoomFinish = true;
                    break;
            }

            switch (enableIndex)
            {
                case 1:
                    InRoomEnable = true;
                    InRoomBackVisible = Visibility.Visible;
                    InRoomFinish = false;
                    break;
                case 2:
                    AnesStartEnable = true;
                    AnesStartBackVisible = Visibility.Visible;
                    AnesStartFinish = false;
                    break;
                case 3:
                    OperStartEnable = true;
                    OperStartBackVisible = Visibility.Visible;
                    OperStartFinish = false;
                    break;
                case 4:
                    OperEndEnable = true;
                    OperEndBackVisible = Visibility.Visible;
                    OperEndFinish = false;
                    break;
                case 5:
                    AnesEndEnable = true;
                    AnesEndBackVisible = Visibility.Visible;
                    AnesEndFinish = false;
                    break;
                case 6:
                    OutRoomEnable = true;
                    OutRoomBackVisible = Visibility.Visible;
                    OutRoomFinish = false;
                    break;
            }
        }

        private void SetOperStatusDate()
        {
            switch (visibIndex)
            {
                case 1:
                    {
                        IN_DATE_TIME = (DateTime)_masterRow.IN_DATE_TIME;
                    }
                    break;
                case 2:
                    {
                        IN_DATE_TIME = (DateTime)_masterRow.IN_DATE_TIME;
                        ANES_START_TIME = _masterRow.ANES_START_TIME == null || _masterRow.ANES_START_TIME == DateTime.MinValue ? DateTime.Now : (DateTime)_masterRow.ANES_START_TIME;
                    }
                    break;
                case 3:
                    {
                        IN_DATE_TIME = (DateTime)_masterRow.IN_DATE_TIME;
                        ANES_START_TIME = (DateTime)_masterRow.ANES_START_TIME;
                        START_DATE_TIME = _masterRow.START_DATE_TIME == null || _masterRow.START_DATE_TIME == DateTime.MinValue ? DateTime.Now : (DateTime)_masterRow.START_DATE_TIME;

                    }
                    break;
                case 4:
                    {
                        IN_DATE_TIME = (DateTime)_masterRow.IN_DATE_TIME;
                        ANES_START_TIME = (DateTime)_masterRow.ANES_START_TIME;
                        START_DATE_TIME = (DateTime)_masterRow.START_DATE_TIME;
                        END_DATE_TIME = _masterRow.END_DATE_TIME == null || _masterRow.END_DATE_TIME == DateTime.MinValue ? DateTime.Now : (DateTime)_masterRow.END_DATE_TIME;

                    }
                    break;
                case 5:
                    {
                        IN_DATE_TIME = (DateTime)_masterRow.IN_DATE_TIME;
                        ANES_START_TIME = (DateTime)_masterRow.ANES_START_TIME;
                        START_DATE_TIME = _masterRow.START_DATE_TIME;
                        END_DATE_TIME = _masterRow.END_DATE_TIME;
                        ANES_END_TIME = _masterRow.ANES_END_TIME == null || _masterRow.ANES_END_TIME == DateTime.MinValue ? DateTime.Now : (DateTime)_masterRow.ANES_END_TIME;

                    }
                    break;
                case 6:
                    {
                        IN_DATE_TIME = (DateTime)_masterRow.IN_DATE_TIME;
                        ANES_START_TIME = (DateTime)_masterRow.ANES_START_TIME;
                        START_DATE_TIME = _masterRow.START_DATE_TIME;
                        END_DATE_TIME = _masterRow.END_DATE_TIME;
                        ANES_END_TIME = (DateTime)_masterRow.ANES_END_TIME;
                        OUT_DATE_TIME = _masterRow.OUT_DATE_TIME == null || _masterRow.OUT_DATE_TIME == DateTime.MinValue ? DateTime.Now : (DateTime)_masterRow.OUT_DATE_TIME;

                    }
                    break;
                default: break;
            }
        }


        /// <summary>
        /// 检查数据有效
        /// </summary>
        /// <returns></returns>
        protected override bool CheckData()
        {
            bool result = true;
            switch (enableIndex)
            {
                case 1:
                    if (IN_DATE_TIME == null || IN_DATE_TIME == DateTime.MinValue)
                    {
                        ShowMessageBox("入室时间不能为空。", MessageBoxButton.OK, MessageBoxImage.Warning);
                        result = false;
                    }
                    if (ANES_START_TIME != null && ANES_START_TIME != DateTime.MinValue)
                    {
                        if (IN_DATE_TIME > ANES_START_TIME)
                        {
                            ShowMessageBox("入手术室时间不能大于麻醉开始时间。", MessageBoxButton.OK, MessageBoxImage.Warning);
                            result = false;
                        }
                    }
                    break;
                case 2:
                    if (ANES_START_TIME == null || ANES_START_TIME == DateTime.MinValue)
                    {
                        ShowMessageBox("麻醉开始时间不能为空。", MessageBoxButton.OK, MessageBoxImage.Warning);
                        result = false;
                    }
                    if (IN_DATE_TIME > ANES_START_TIME)
                    {
                        ShowMessageBox("麻醉开始时间不能小于入手术室时间。", MessageBoxButton.OK, MessageBoxImage.Warning);
                        result = false;
                    }
                    if (START_DATE_TIME != null && START_DATE_TIME != DateTime.MinValue)
                    {
                        if (START_DATE_TIME < ANES_START_TIME)
                        {
                            ShowMessageBox("麻醉开始时间不能大于手术开始时间。", MessageBoxButton.OK, MessageBoxImage.Warning);
                            result = false;
                        }
                    }
                    break;
                case 3:
                    if (START_DATE_TIME == null || START_DATE_TIME == DateTime.MinValue)
                    {
                        ShowMessageBox("手术开始时间不能为空。", MessageBoxButton.OK, MessageBoxImage.Warning);
                        result = false;
                    }
                    if (START_DATE_TIME < ANES_START_TIME)
                    {
                        ShowMessageBox("手术开始时间不能小于麻醉开始时间。", MessageBoxButton.OK, MessageBoxImage.Warning);
                        result = false;
                    }
                    if (END_DATE_TIME != null && END_DATE_TIME != DateTime.MinValue)
                    {
                        if (START_DATE_TIME > END_DATE_TIME)
                        {
                            ShowMessageBox("手术开始时间不能大于手术结束时间。", MessageBoxButton.OK, MessageBoxImage.Warning);
                            result = false;
                        }
                    }
                    break;
                case 4:
                    if (END_DATE_TIME == null || END_DATE_TIME == DateTime.MinValue)
                    {
                        ShowMessageBox("手术结束时间不能为空。", MessageBoxButton.OK, MessageBoxImage.Warning);
                        result = false;
                    }
                    if (START_DATE_TIME > END_DATE_TIME)
                    {
                        ShowMessageBox("手术结束时间不能小于手术开始时间。", MessageBoxButton.OK, MessageBoxImage.Warning);
                        result = false;
                    }
                    if (ANES_END_TIME != null && ANES_END_TIME != DateTime.MinValue)
                    {
                        if (END_DATE_TIME > ANES_END_TIME)
                        {
                            ShowMessageBox("手术结束时间不能大于麻醉结束时间。", MessageBoxButton.OK, MessageBoxImage.Warning);
                            result = false;
                        }
                    }
                    break;
                case 5:
                    if (ANES_END_TIME == null || ANES_END_TIME == DateTime.MinValue)
                    {
                        ShowMessageBox("麻醉结束时间不能为空。", MessageBoxButton.OK, MessageBoxImage.Warning);
                        result = false;
                    }
                    if (END_DATE_TIME > ANES_END_TIME)
                    {
                        ShowMessageBox("麻醉结束时间不能小于手术结束时间。", MessageBoxButton.OK, MessageBoxImage.Warning);
                        result = false;
                    }
                    if (OUT_DATE_TIME != null && OUT_DATE_TIME != DateTime.MinValue)
                    {
                        if (ANES_END_TIME > OUT_DATE_TIME)
                        {
                            ShowMessageBox("麻醉结束时间不能大于出手术室时间。", MessageBoxButton.OK, MessageBoxImage.Warning);
                            result = false;
                        }
                    }
                    break;
                case 6:
                    if (OUT_DATE_TIME == null || OUT_DATE_TIME == DateTime.MinValue)
                    {
                        ShowMessageBox("出手术室时间不能为空。", MessageBoxButton.OK, MessageBoxImage.Warning);
                        result = false;
                    }
                    if (ANES_END_TIME > OUT_DATE_TIME)
                    {
                        ShowMessageBox("出手术室时间不能小于麻醉结束时间。", MessageBoxButton.OK, MessageBoxImage.Warning);
                        result = false;
                    }
                    break;
            }

            return result;
        }

        /// <summary>
        /// 保存患者信息
        /// </summary>
        /// <returns></returns>
        protected override SaveResult SaveData()
        {
            bool result = true;
            SaveResult saveResult = SaveResult.Fail;

            switch (curntStatusCode)
            {
                case (int)OperationStatus.InOperationRoom:
                    _masterRow.IN_DATE_TIME = IN_DATE_TIME.Value.AddSeconds(0 - IN_DATE_TIME.Value.Second);
                    break;
                case (int)OperationStatus.AnesthesiaStart:
                    _masterRow.ANES_START_TIME = ANES_START_TIME.Value.AddSeconds(0 - ANES_START_TIME.Value.Second);
                    break;
                case (int)OperationStatus.OperationStart:
                    _masterRow.START_DATE_TIME = START_DATE_TIME.Value.AddSeconds(0 - START_DATE_TIME.Value.Second);
                    break;
                case (int)OperationStatus.OperationEnd:
                    _masterRow.END_DATE_TIME = END_DATE_TIME.Value.AddSeconds(0 - END_DATE_TIME.Value.Second);
                    break;
                case (int)OperationStatus.AnesthesiaEnd:
                    _masterRow.ANES_END_TIME = ANES_END_TIME.Value.AddSeconds(0 - ANES_END_TIME.Value.Second);
                    break;
                case (int)OperationStatus.OutOperationRoom:
                    _masterRow.OUT_DATE_TIME = OUT_DATE_TIME.Value.AddSeconds(0 - OUT_DATE_TIME.Value.Second);
                    break;
            }
            if (_masterRow.OPER_STATUS_CODE <= operStatusCode)
            {
                _masterRow.OPER_STATUS_CODE = operStatusCode;
            }
            result = AnesInfoService.ClientInstance.UpadteOperationMasterRow(_masterRow);
            if (result)
            {
                //saveResult = SaveResult.Success;
                saveResult = SaveResult.CancelMessageBox;// 六个时间点保存成功后无需弹出框

                ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE = _masterRow.OPER_STATUS_CODE;
            }

            return saveResult;
        }

        #endregion

        #region 命令


        /// <summary>
        /// 保存
        /// </summary>
        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand<string>(key =>
                {
                    PublicKeyBoardMessage(KeyCode.AppCode.Save);
                });
            }
        }

        public ICommand CancelCommand
        {
            get
            {
                return new RelayCommand<string>(key =>
                {
                    this.CloseContentWindow();
                });
            }
        }

        #endregion

        #region 事件
        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
            ViewFlag = Args[0] as string;
        }


        /// <summary>
        /// 关闭窗体事件
        /// </summary>
        /// <param name="e"></param>
        public override void OnPreviewViewUnLoaded(System.ComponentModel.CancelEventArgs e)
        {
            // 清除全局缓存
            ExtendAppContext.Current.CurrentDocName = string.Empty;
            ExtendAppContext.Current.CurntOpenForm = null;

            // 时间录入界面关闭后刷新今日列表
            if (ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE < 
                (int)OperationStatus.OutOperationRoom)
            {
                Messenger.Default.Send<object>(this, EnumMessageKey.RefreshMainWindow);
            }
            else
            {
                Messenger.Default.Send<object>(this, EnumMessageKey.RefreshWordList);
                Messenger.Default.Send<string>("SetWorkListSelectItem", EnumMessageKey.SetWorkListSelectItem);
            }
        }
        #endregion
    }
}
