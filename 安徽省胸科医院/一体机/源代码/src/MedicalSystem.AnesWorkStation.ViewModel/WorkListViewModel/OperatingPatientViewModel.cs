// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      OperatingPatientViewModel.cs
// 功能描述(Description)：    正在手术的患者信息面板对应的ViewModel
// 数据表(Tables)：		      无
// 作者(Author)：             许文龙
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.AnesWorkStation.Model.WorkListModel;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using MedicalSystem.AnesWorkStation.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.ViewModel.Cache;
using MedicalSystem.Services;

namespace MedicalSystem.AnesWorkStation.ViewModel.WorkListViewModel
{
    /// <summary>
    /// 当前正在手术患者
    /// </summary>
    public class OperatingPatientViewModel : BaseViewModel
    {
        private object locker = new object();
        private PatientModel curPatientModel = null;                                                       // 当前正在手术的患者
        private ObservableCollection<SignInfoModel> signinfolist = null;                                   // 实时体征列表
        private Visibility noOperationVisibility = Visibility.Collapsed;                                   // 当前没有手术时显示的背景图片
        private Visibility hasOperationVisibility = Visibility.Visible;                                    // 当前有手术时显示的内容
        private System.Timers.Timer refreshOperationLengthTime = new System.Timers.Timer();                // 体征试试刷新timer
        private Visibility monitorVisibility = Visibility.Visible;                                         // 监护仪图标显示或隐藏
        private Visibility anesMachineVisibility = Visibility.Collapsed;                                   // 麻醉机图标显示或隐藏
        private Visibility monitorAndAnesMachineVis = Visibility.Collapsed;                                // 麻醉机和监护仪都显示成×
        private string operationLength = string.Empty;                                                     // 手术时长=出室-入室或当前时间-入室
        private Visibility isSelectedBorderVisibility = Visibility.Visible;                                // 边框是否显示

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
        /// 实时体征列表
        /// </summary>
        public ObservableCollection<SignInfoModel> Signinfolist
        {
            get { return this.signinfolist; }
            set
            {
                this.signinfolist = value;
                this.RaisePropertyChanged("Signinfolist");
            }
        }

        /// <summary>
        /// 当前没有手术时显示的背景图片
        /// </summary>
        public Visibility NoOperationVisibility
        {
            get { return this.noOperationVisibility; }
            set
            {
                this.noOperationVisibility = value;
                this.RaisePropertyChanged("NoOperationVisibility");
            }
        }

        /// <summary>
        /// 当前有手术时显示的内容
        /// </summary>
        public Visibility HasOperationVisibility
        {
            get { return this.hasOperationVisibility; }
            set
            {
                this.hasOperationVisibility = value;
                this.RaisePropertyChanged("HasOperationVisibility");
            }
        }

        /// <summary>
        /// 监护仪图标显示或隐藏
        /// </summary>
        public Visibility MonitorVisibility
        {
            get { return this.monitorVisibility; }
            set
            {
                this.monitorVisibility = value;
                this.RaisePropertyChanged("MonitorVisibility");
            }
        }

        /// <summary>
        /// 麻醉机图标显示或隐藏
        /// </summary>
        public Visibility AnesMachineVisibility
        {
            get { return this.anesMachineVisibility; }
            set
            {
                this.anesMachineVisibility = value;
                this.RaisePropertyChanged("AnesMachineVisibility");
            }
        }

        /// <summary>
        /// 麻醉机和监护仪都显示成 ×
        /// </summary>
        public Visibility MonitorAndAnesMachineVis
        {
            get { return this.monitorAndAnesMachineVis; }
            set
            {
                this.monitorAndAnesMachineVis = value;
                this.RaisePropertyChanged("MonitorAndAnesMachineVis");
            }
        }

        /// <summary>
        /// 手术时长=出室-入室或当前时间-入室
        /// </summary>
        public string OperationLength
        {
            get { return this.operationLength; }
            set
            {
                this.operationLength = value;
                this.RaisePropertyChanged("OperationLength");
            }
        }

        /// <summary>
        /// 查看术中登记窗口
        /// </summary>
        public ICommand ShowOperatingInfoCommand
        {
            get
            {
                return new RelayCommand<string>(key =>
                {
                    ExtendAppContext.Current.PatientInformationExtend = this.CurPatientModel.Med_Pat_Info;
                    ExtendAppContext.Current.IsPermission = true;
                    Messenger.Default.Send<object>(this, EnumMessageKey.ShowInOperationWindow);
                });
            }
        }

        /// <summary>
        /// 选中边框是否显示
        /// </summary>
        public Visibility IsSelectedBorderVisibility
        {
            get { return this.isSelectedBorderVisibility; }
            set
            {
                this.isSelectedBorderVisibility = value;
                this.RaisePropertyChanged("IsSelectedBorderVisibility");
            }
        }

        /// <summary>
        /// 无参构造方法：表示是当前正在进行手术的患者
        /// </summary>
        public OperatingPatientViewModel()
        {
            // 非设计模式下
            if (!IsInDesignMode)
            {
                this.RefreshData();
                this.refreshOperationLengthTime.Interval = 60 * 1000;
                this.refreshOperationLengthTime.Elapsed += this.RefreshTimer_Elapsed;
                this.refreshOperationLengthTime.Start();
                this.RegisterMessage();
            }
        }

        /// <summary>
        /// 注册消息响应
        /// </summary>
        private void RegisterMessage()
        {
            // 刷新界面数据
            Messenger.Default.Register<object>(this, EnumMessageKey.RefreshOperatingPatient, msg =>
            {
                this.RefreshData();
            });

            // 刷新选中边框
            Messenger.Default.Register<object>(this, EnumMessageKey.RefreshOperatingSelectedCurPatientInfoBorder, action =>
            {
                if ((bool)action && null != this.CurPatientModel)
                {
                    this.IsSelectedBorderVisibility = Visibility.Visible;
                    ExtendAppContext.Current.PatientInformationExtend = this.CurPatientModel.Med_Pat_Info;
                    ExtendAppContext.Current.IsPermission = true;
                }
                else
                {
                    this.IsSelectedBorderVisibility = Visibility.Collapsed;
                }
            });

            // 在隐藏主界面时暂停时间器，节约不必要的资源开销
            Messenger.Default.Register<object>(this, EnumMessageKey.HideMainWindow, msg =>
            {
                this.refreshOperationLengthTime.Stop();
            });

            // 显示主界面时启动时间器
            Messenger.Default.Register<object>(this, EnumMessageKey.ShowMainWindow, msg =>
            {
                this.refreshOperationLengthTime.Start();
            });
        }

        /// <summary>
        /// 刷新手术时长信息
        /// </summary>
        public void RefreshOperationLength()
        {
            if (null != this.CurPatientModel)
            {
                if (this.CurPatientModel.OperStatusCode == OperationStatus.OutOperationRoom)
                {
                    TimeSpan ts = this.CurPatientModel.OutDateTime - this.CurPatientModel.InDateTime;
                    this.OperationLength = string.Format("{0}:{1}", string.Format("{0:00}", ts.Days * 24 + ts.Hours), string.Format("{0:00}", ts.Minutes));
                }
                else
                {
                    DateTime result = DateTime.MinValue;
                    switch (this.CurPatientModel.OperStatusCode)
                    {
                        case OperationStatus.IsReady:
                            result = this.CurPatientModel.ScheduledDateTime;
                            break;

                        case OperationStatus.OperScheduled:
                            result = this.CurPatientModel.ScheduledDateTime;
                            break;

                        case OperationStatus.InOperationRoom:
                            result = this.CurPatientModel.InDateTime;
                            break;

                        case OperationStatus.AnesthesiaStart:
                            result = this.CurPatientModel.AnesStartTime;
                            break;

                        case OperationStatus.OperationStart:
                            result = this.CurPatientModel.StartDateTime;
                            break;

                        case OperationStatus.OperationEnd:
                            result = this.CurPatientModel.EndDateTime;
                            break;

                        case OperationStatus.AnesthesiaEnd:
                            result = this.CurPatientModel.AnesEndTime;
                            break;

                        case OperationStatus.OutOperationRoom:
                            result = this.CurPatientModel.OutDateTime;
                            break;

                        default:
                            break;
                    }

                    TimeSpan ts = DateTime.Now - this.CurPatientModel.InDateTime;
                    this.OperationLength = string.Format("{0}:{1}", string.Format("{0:00}", ts.Days * 24 + ts.Hours), string.Format("{0:00}", ts.Minutes));
                }
            }
        }

        /// <summary>
        /// 刷新界面数据
        /// </summary>
        public void RefreshData()
        {
            // 在刷新数据时可能是定时器刷新也可能是消息指令刷新，为了防止数据冲突，使用对象锁
            lock (this.locker)
            {
                try
                {
                    // 每次刷新时从数据库中获取患者信息
                    MED_PAT_INFO patInfo = PatInfoService.ClientInstance.GetCurPatientInfo(ExtendAppContext.Current.OperDeptCode, ExtendAppContext.Current.OperRoomNo);
                    this.CurPatientModel = PatientModel.CreateModel(patInfo);

                    if (null != this.CurPatientModel)
                    {
                        this.IsSelectedBorderVisibility = Visibility.Visible;
                        ExtendAppContext.Current.PatientInformationExtend = this.CurPatientModel.Med_Pat_Info;
                        //设置状态灯亮
                        int lightIndex = OperationStatusHelper.GetOperStatusIndex(ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE);
                        KeyBoardStateCache.KeyBoard.OpenSecondKeyBoardAllLed(lightIndex);
                        // 刷新患者的体征数据
                        this.RefreshVitalSignList();
                        // 刷新监护仪和麻醉机的图标显示
                        this.RefreshMonitor();
                    }
                    else
                    {
                        this.IsSelectedBorderVisibility = Visibility.Collapsed;
                        ExtendAppContext.Current.PatientInformationExtend = null;
                        //关闭状态灯
                        if (KeyBoardStateCache.KeyBoard != null)
                        {
                            KeyBoardStateCache.KeyBoard.CloseSecondKeyBoardAllLed();
                        }
                    }

                    // 设置图片显示或隐藏
                    this.SetOperationVisibility();
                    // 刷新手术时长信息
                    this.RefreshOperationLength();
                }
                catch (Exception ex)
                {
                    Logger.Error("获取术中信息异常", ex);
                    this.ShowMessageBox("获取术中信息发生异常。", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// 刷新患者的体征数据
        /// </summary>
        private void RefreshVitalSignList()
        {
            try
            {
                // 获取手术患者的实时体征数据
                this.Signinfolist = null;
                if (null != this.CurPatientModel)
                {
                    // 获取患者的体征数据
                    List<MED_VITAL_SIGN> vitalSignList = AnesInfoService.ClientInstance.GetVitalSignData(this.CurPatientModel.PatientID,
                                                                                                         this.CurPatientModel.VisitID,
                                                                                                         this.CurPatientModel.OperID,
                                                                                                         "0",
                                                                                                         false);
                    // 仅显示脉搏：44, 呼吸：92, 血压High:89, 血压Low:90 , 温度：100
                    IEnumerable<MED_VITAL_SIGN> tempList = vitalSignList.Where<MED_VITAL_SIGN>(x => x.ITEM_CODE.Equals("44") ||
                                                                                                    x.ITEM_CODE.Equals("92") ||
                                                                                                    x.ITEM_CODE.Equals("89") ||
                                                                                                    x.ITEM_CODE.Equals("90") ||
                                                                                                    x.ITEM_CODE.Equals("100"));
                    // 仅显示最新时间的体征
                    IEnumerable<DateTime> timePointList = tempList.Select(a => a.TIME_POINT);
                    if (null != timePointList && timePointList.Count() > 0)
                    {
                        DateTime maxDateTime = tempList.Select(a => a.TIME_POINT).Max();
                        tempList = tempList.Where<MED_VITAL_SIGN>(x => x.TIME_POINT.Equals(maxDateTime));
                        this.Signinfolist = new ObservableCollection<SignInfoModel>(SignInfoModel.CreateListModel(tempList));
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("获取正在手术患者的最新体征异常：", ex);
                // this.ShowMessageBox("获取正在手术患者的最新体征异常！", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// 刷新监护仪和麻醉机的图标显示
        /// </summary>
        private void RefreshMonitor()
        {
            if (null != this.CurPatientModel)
            {
                // 显示监护仪和麻醉机的图标
                List<MED_MONITOR_DICT> monitorDict = DictService.ClientInstance.GetMonitorDictList();
                var curMonitor = monitorDict.FirstOrDefault<MED_MONITOR_DICT>(x => null != x.PATIENT_ID && x.PATIENT_ID.Equals(this.CurPatientModel.PatientID) && x.VISIT_ID == this.CurPatientModel.VisitID && x.OPER_ID == this.CurPatientModel.OperID);
                if (null != curMonitor)
                {
                    string itemType = curMonitor.ITEM_TYPE;
                    switch (curMonitor.ITEM_TYPE)
                    {
                        case "1": // 麻醉机
                            this.AnesMachineVisibility = Visibility.Visible;
                            this.MonitorVisibility = Visibility.Collapsed;
                            break;

                        case "0": // 监护仪
                            this.AnesMachineVisibility = Visibility.Collapsed;
                            this.MonitorVisibility = Visibility.Visible;
                            break;

                        default:
                            this.AnesMachineVisibility = Visibility.Collapsed;
                            this.MonitorVisibility = Visibility.Collapsed;
                            this.MonitorAndAnesMachineVis = Visibility.Visible;
                            break;
                    }
                }
                else
                {
                    this.AnesMachineVisibility = Visibility.Collapsed;
                    this.MonitorVisibility = Visibility.Collapsed;
                    this.MonitorAndAnesMachineVis = Visibility.Visible;
                }
            }
        }

        /// <summary>
        /// 设置界面的图片显示或隐藏
        /// </summary>
        private void SetOperationVisibility()
        {
            this.NoOperationVisibility = null == this.CurPatientModel ? Visibility.Visible : Visibility.Collapsed;
            this.HasOperationVisibility = null == this.CurPatientModel ? Visibility.Collapsed : Visibility.Visible;
        }

        /// <summary>
        /// 自动刷新手术列表汇总信息
        /// </summary>
        private void RefreshTimer_Elapsed(object sender, EventArgs e)
        {
            lock (this.locker)
            {
                // 刷新手术时长
                this.RefreshOperationLength();
                // 刷新体征
                this.RefreshVitalSignList();
            }
        }
    }
}
