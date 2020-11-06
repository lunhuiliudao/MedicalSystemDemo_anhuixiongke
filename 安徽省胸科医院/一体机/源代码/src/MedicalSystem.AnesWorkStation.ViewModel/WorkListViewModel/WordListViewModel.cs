// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      WordListViewModel.cs
// 功能描述(Description)：    工作列表面板对应的ViewModel
// 数据表(Tables)：		      无
// 作者(Author)：             许文龙
// 日期(Create Date)：        2017/12/26 13:28
// R1:
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
using MedicalSystem.AnesWorkStation.Model.WorkListModel;
using MedicalSystem.AnesWorkStation.Wpf.Controls;
using MedicalSystem.AnesWorkStation.Wpf.Message;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;

namespace MedicalSystem.AnesWorkStation.ViewModel.WorkListViewModel
{
    /// <summary>
    /// 工作列表显示的手术列表类型枚举
    /// </summary>
    public enum EnumWorkListType
    {
        /// <summary>
        /// 未完成手术列表
        /// </summary>
        [Description("未完成手术列表")]
        UnFinishWorkList,

        /// <summary>
        /// 已完成手术列表
        /// </summary>
        [Description("已完成手术列表")]
        FinishWorkList,

        /// <summary>
        /// 搜索结果手术列表
        /// </summary>
        [Description("搜索结果手术列表")]
        SearchCommandWorkList,

        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        Unknow,
    }

    /// <summary>
    /// 工作列表当前选中的时间类别：今天、明天、一周
    /// </summary>
    public enum EnumDayType
    {
        /// <summary>
        /// 今日
        /// </summary>
        [Description("今日")]
        Today,

        /// <summary>
        /// 明日
        /// </summary>
        [Description("明日")]
        Tomorrow,

        /// <summary>
        /// 一周
        /// </summary>
        [Description("一周")]
        Week,

        /// <summary>
        /// 未知
        /// </summary>
        Unknow = -1,
    }

    /// <summary>
    /// 工作列表ViewModel
    /// </summary>
    public class WordListViewModel : BaseViewModel
    {
        private ICommand searchCommand;                                                            // 搜索命令
        private ICommand searchTextChangedCommand;                                                 // 搜索文本框文本改变命令
        private ICommand switchWorkListCommand;                                                    // 切换工作列表命令
        private ICommand tomorrowSurgeryWorkListCommand;                                           // 查询显示明日手术列表
        private ICommand weekSurgeryWorkListCommand;                                               // 查询显示一周手术列表
        private ICommand emergencyRegisterControl;                                                 // 急诊登记
        private ICommand spreadCommand;                                                            // 还原工作列表
        private ICommand selectionChangedCommand;                                                  // 工作列表SelectionChanged事件命令
        private ICommand refreshWordListCommand;                                                   // 刷新当前界面
        private ICommand mouseDoubleClickCommand;                                                  // 工作列表MouseDoubleClick事件命令
        private EnumDayType curEnumDayType = EnumDayType.Today;                                    // 当前选中的日期
        private EnumWorkListType curEnumWorkList = EnumWorkListType.UnFinishWorkList;              // 当前手术列表类型
        private EnumWorkListType beforCurEnumWorkList = EnumWorkListType.UnFinishWorkList;         // 手术列表类型记录
        private List<PatientModel> patientModelList = null;                                        // 当前日期的患者列表
        private string workListTitle;                                                              // 列表标题：今日完成手术列表，今日未完成手术列表.....
        private bool isQuerySelfWorkList = false;                                                  // 是否查询登录者的手术列表
        private System.Windows.Visibility spreadVisibility = System.Windows.Visibility.Hidden;     // 还原按钮显示还是隐藏 

        /// <summary>           
        /// 当前手术列表所处的日期类别：今天、明天、一周
        /// </summary>
        public EnumDayType CurEnumDayType
        {
            get { return this.curEnumDayType; }
            set
            {
                this.curEnumDayType = value;
                this.RaisePropertyChanged("CurEnumDayType");
                this.RefreshData();
            }
        }

        /// <summary>
        /// 当前手术列表类型:已完成，未完成，登录者
        /// </summary>
        public EnumWorkListType CurEnumWorkList
        {
            get { return this.curEnumWorkList; }
            set
            {
                if (this.beforCurEnumWorkList != this.curEnumWorkList)
                {
                    this.beforCurEnumWorkList = this.curEnumWorkList;
                }

                this.curEnumWorkList = value;
                this.RaisePropertyChanged("CurEnumWorkList");
            }
        }

        /// <summary>
        /// 患者列表
        /// </summary>
        public List<PatientModel> PatientModelList
        {
            get { return this.patientModelList; }
            set
            {
                this.patientModelList = value;
                this.RaisePropertyChanged("PatientModelList");
            }
        }

        /// <summary>
        /// 列表标题：今日完成手术列表，今日未完成手术列表
        /// </summary>
        public string WorkListTitle
        {
            get { return this.workListTitle; }
            set
            {
                this.workListTitle = value;
                this.RaisePropertyChanged("WorkListTitle");
            }
        }

        /// <summary>
        /// 还原按钮显示隐藏状态
        /// </summary>
        public System.Windows.Visibility SpreadVisibility
        {
            get { return this.spreadVisibility; }
            set
            {
                this.spreadVisibility = value;
                this.RaisePropertyChanged("SpreadVisibility");
            }
        }

        /// <summary>
        /// 当前选择项
        /// </summary>
        public PatientModel SelectItem { get; set; }

        /// <summary>
        /// 搜索命令
        /// </summary>
        public ICommand SearchCommand
        {
            get { return this.searchCommand; }
            set { this.searchCommand = value; }
        }

        /// <summary>
        /// 搜索文本框文本改变命令
        /// </summary>
        public ICommand SearchTextChangedCommand
        {
            get { return this.searchTextChangedCommand; }
            set { this.searchTextChangedCommand = value; }
        }

        /// <summary>
        /// 切换工作量列表命令
        /// </summary>
        public ICommand SwitchWorkListCommand
        {
            get { return this.switchWorkListCommand; }
            set { this.switchWorkListCommand = value; }
        }

        /// <summary>
        /// 急诊登记
        /// </summary>
        public ICommand EmergencyRegisterControl
        {
            get { return this.emergencyRegisterControl; }
            set { this.emergencyRegisterControl = value; }
        }

        /// <summary>
        /// 查询显示明日手术列表
        /// </summary>
        public ICommand TomorrowSurgeryWorkListCommand
        {
            get { return this.tomorrowSurgeryWorkListCommand; }
            set { this.tomorrowSurgeryWorkListCommand = value; }
        }

        /// <summary>
        /// 查询显示一周手术列表
        /// </summary>
        public ICommand WeekSurgeryWorkListCommand
        {
            get { return this.weekSurgeryWorkListCommand; }
            set { this.weekSurgeryWorkListCommand = value; }
        }

        /// <summary>
        /// 由明日手术列表还原到今日手术列表
        /// </summary>
        public ICommand SpreadCommand
        {
            get { return this.spreadCommand; }
            set { this.spreadCommand = value; }
        }

        /// <summary>
        /// ListBox 切换选中项事件命令
        /// </summary>
        public ICommand SelectionChangedCommand
        {
            get { return this.selectionChangedCommand; }
            set { this.selectionChangedCommand = value; }
        }

        /// <summary>
        /// 刷新当前界面
        /// </summary>
        public ICommand RefreshWordListCommand
        {
            get { return this.refreshWordListCommand; }
            set { this.refreshWordListCommand = value; }
        }

        /// <summary>
        /// ListBox 双击事件命令
        /// </summary>
        public ICommand MouseDoubleClickCommand
        {
            get { return this.mouseDoubleClickCommand; }
            set { this.mouseDoubleClickCommand = value; }
        }

        /// <summary>
        /// 无参构造函数：时间默认为当前时间
        /// </summary>
        public WordListViewModel()
        {
            if (!IsInDesignMode)
            {
                this.RegisterMessage();
                this.RefreshData();
            }
        }

        /// <summary>
        /// 注册搜索事件
        /// </summary>
        private void RegisterMessage()
        {
            this.SearchCommand = new RelayCommand<string>(key =>
            {
                this.Search(key);
            });

            this.SearchTextChangedCommand = new RelayCommand<string>(key =>
            {
                this.ResetWorkList(key);
            });

            this.SwitchWorkListCommand = new RelayCommand<object>(key =>
            {
                SetTodayWorkList(key);
            });


            this.TomorrowSurgeryWorkListCommand = new RelayCommand<string>(key =>
            {
                this.SwitchWorkList(key);
            });

            this.WeekSurgeryWorkListCommand = new RelayCommand<string>(key =>
            {
                this.SwitchWorkList(key);
            });

            // 急症登记按钮
            this.EmergencyRegisterControl = new RelayCommand<object>(key =>
            {
                this.ShowEmergencyRegister();
            });

            // 还原命令
            this.SpreadCommand = new RelayCommand<string>(key =>
            {
                this.SpreadVisibility = System.Windows.Visibility.Hidden;
                this.CurEnumDayType = EnumDayType.Today;
                this.CurEnumWorkList = this.beforCurEnumWorkList;
                this.SwitchWorkList(this.CurEnumWorkList.ToString());
                Messenger.Default.Send<object>(this.CurEnumWorkList, EnumMessageKey.SwitchSurgery);
            });

            // 切换选中项命令
            this.SelectionChangedCommand = new RelayCommand<object>(key =>
            {
                if (key != null && key is PatientModel)
                {
                    SelectItem = key as PatientModel;
                    ExtendAppContext.Current.PatientInformationExtend = (key as PatientModel).Med_Pat_Info;
                    ExtendAppContext.Current.IsPermission = true;
                    this.UpdateAnesthesiaPlan();
                    Messenger.Default.Send<object>(typeof(WorkListViewModel.WordListViewModel), EnumMessageKey.RefreshSelectedCurPatientInfoBorder);
                }
            });

            // 双击术后病人，直接进入术中界面
            this.MouseDoubleClickCommand = new RelayCommand<object>(key =>
            {
                if (key != null && key is PatientModel)
                {
                    MED_PAT_INFO patient = (key as PatientModel).Med_Pat_Info;
                    if (patient.OPER_STATUS_CODE >= 35)
                    {
                        Messenger.Default.Send<object>(this, EnumMessageKey.ShowInOperationWindow);
                    }
                }
            });

            // 刷新工作列表界面，不能使用异步
            Messenger.Default.Register<object>(this, EnumMessageKey.RefreshWordList, msg =>
            {
                this.RefreshData();
            });

            // 刷新选中项边框是否显示
            Messenger.Default.Register<object>(this, EnumMessageKey.RefreshWorkListSelectedCurPatientInfoBorder, action =>
            {
                if (!(bool)action)
                {
                    this.RefreshData();
                }
            });
        }

        /// <summary>
        /// 当选中的患者还未入手术室时，判断计划表数据
        /// </summary>
        private void UpdateAnesthesiaPlan()
        {
            if (ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE < 5)
            {
                bool isChanged = false;
                List<MED_ANESTHESIA_PLAN> anesthesiaPlanList = AnesInfoService.ClientInstance.GetAnesthesiaPlan(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID,
                                                                                                                ExtendAppContext.Current.PatientInformationExtend.VISIT_ID,
                                                                                                                ExtendAppContext.Current.PatientInformationExtend.OPER_ID);
                MED_ANESTHESIA_PLAN anesthesiaPlanRow = new MED_ANESTHESIA_PLAN();
                if (anesthesiaPlanList.Count > 0)
                {
                    anesthesiaPlanRow = anesthesiaPlanList.First();
                    if (anesthesiaPlanRow.OPERATION_NAME == null || anesthesiaPlanRow.OPERATION_NAME == "")
                    {
                        anesthesiaPlanRow.OPERATION_NAME = ExtendAppContext.Current.PatientInformationExtend.OPERATION_NAME;
                        isChanged = true;
                    }
                    if (anesthesiaPlanRow.ANESTHESIA_METHOD == null || anesthesiaPlanRow.ANESTHESIA_METHOD == "")
                    {
                        anesthesiaPlanRow.ANESTHESIA_METHOD = ExtendAppContext.Current.PatientInformationExtend.ANES_METHOD;
                        isChanged = true;
                    }
                }
                else
                {
                    anesthesiaPlanRow.PATIENT_ID = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
                    anesthesiaPlanRow.VISIT_ID = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
                    anesthesiaPlanRow.OPER_ID = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;
                    anesthesiaPlanRow.OPERATION_NAME = ExtendAppContext.Current.PatientInformationExtend.OPERATION_NAME;
                    anesthesiaPlanRow.ANESTHESIA_METHOD = ExtendAppContext.Current.PatientInformationExtend.ANES_METHOD;
                    isChanged = true;
                }
                if (isChanged)
                {
                    AnesInfoService.ClientInstance.UpadteAnesPlanRow(anesthesiaPlanRow);
                }
            }
        }

        /// <summary>
        /// 根据参数显示本人或者全部的数据
        /// </summary>
        public void SetTodayWorkList(object key)
        {
            // 查询登录者的手术
            if (key is bool)
            {
            }
            else
            {
                this.SpreadVisibility = System.Windows.Visibility.Hidden;
                this.CurEnumDayType = EnumDayType.Today;
            }

            this.SwitchWorkList(key);
            // 根据工作列表类型显示界面下方的汇总信息：未完成列表显示明日手术汇总，已完成列表显示一周手术汇总
            Messenger.Default.Send<object>(this.CurEnumWorkList, EnumMessageKey.SwitchSurgery);
        }

        /// <summary>
        /// 显示急诊登记界面
        /// </summary>
        private void ShowEmergencyRegister()
        {
            var message = new ShowContentWindowMessage("EmergencyRegisterControl", MED_CONSTANT.EMERGENCY_REGISTER);
            message.Height = MED_CONSTANT.POPUP_WINDOW_HEIGHT;
            message.Width = MED_CONSTANT.POPUP_WINDOW_WIDTH;
            message.TileBackground = (Brush)(new BrushConverter()).ConvertFromString("#F2806D");
            Messenger.Default.Send<ShowContentWindowMessage>(message);
        }

        /// <summary>
        /// 刷新数据列表
        /// </summary>
        public void RefreshData()
        {
            List<MED_PAT_INFO> list = new List<MED_PAT_INFO>();
            IEnumerable<MED_PAT_INFO> result = null;
            // 根据日期列表获取总数据
            switch (this.CurEnumDayType)
            {
                case EnumDayType.Today:
                    list = PatInfoService.ClientInstance.GetPatientInfosByDateTime(DateTime.Now, ExtendAppContext.Current.OperDeptCode, ExtendAppContext.Current.OperRoomNo);
                    break;

                case EnumDayType.Tomorrow:
                    this.beforCurEnumWorkList = EnumWorkListType.UnFinishWorkList;
                    list = PatInfoService.ClientInstance.GetPatientInfosByDateTime(DateTime.Now.AddDays(1.0), ExtendAppContext.Current.OperDeptCode, ExtendAppContext.Current.OperRoomNo);
                    break;

                case EnumDayType.Week:
                    this.beforCurEnumWorkList = EnumWorkListType.FinishWorkList;
                    list = PatInfoService.ClientInstance.GetPatientInfosInWeek(DateTime.Now.AddDays(-6.0), DateTime.Now.AddDays(1.0), ExtendAppContext.Current.OperDeptCode, ExtendAppContext.Current.OperRoomNo);
                    break;

                default:
                    break;
            }

            // 根据列表类别过滤数据
            switch (this.CurEnumWorkList)
            {
                case EnumWorkListType.UnFinishWorkList:
                    result = from patInfo in list where patInfo.OPER_STATUS_CODE < 35 && patInfo.OPER_STATUS_CODE > -80 select patInfo;
                    break;

                case EnumWorkListType.FinishWorkList:
                    result = from patInfo in list where patInfo.OPER_STATUS_CODE >= 35 select patInfo;
                    break;

                default:
                    break;
            }

            // 判断当前是否只查找登录者数据
            if (this.isQuerySelfWorkList)
            {
                result = result.Where<MED_PAT_INFO>(x => (!string.IsNullOrEmpty(x.ANES_DOCTOR) && x.ANES_DOCTOR.Equals(ExtendAppContext.Current.LoginUser.USER_JOB_ID)) ||
                                                         (!string.IsNullOrEmpty(x.FIRST_ANES_ASSISTANT) && x.FIRST_ANES_ASSISTANT.Equals(ExtendAppContext.Current.LoginUser.USER_JOB_ID)) ||
                                                         (!string.IsNullOrEmpty(x.SECOND_ANES_ASSISTANT) && x.SECOND_ANES_ASSISTANT.Equals(ExtendAppContext.Current.LoginUser.USER_JOB_ID)) ||
                                                         (!string.IsNullOrEmpty(x.THIRD_ANES_ASSISTANT) && x.THIRD_ANES_ASSISTANT.Equals(ExtendAppContext.Current.LoginUser.USER_JOB_ID)) ||
                                                         (!string.IsNullOrEmpty(x.FOURTH_ANES_ASSISTANT) && x.FOURTH_ANES_ASSISTANT.Equals(ExtendAppContext.Current.LoginUser.USER_JOB_ID)));
            }

            this.RefreshWorkList(result);
        }

        /// <summary>
        /// 刷新界面
        /// </summary>
        private void RefreshWorkList(IEnumerable<MED_PAT_INFO> patList)
        {
            this.PatientModelList = PatientModel.CreateListModel(patList).ToList<PatientModel>();
            this.WorkListTitle = this.CurEnumWorkList == EnumWorkListType.SearchCommandWorkList ?
                                 ApplicationModel.Instance.GetEnumDescription<EnumWorkListType>(this.CurEnumWorkList) + "  " +
                                 this.PatientModelList.Count() :
                                 ApplicationModel.Instance.GetEnumDescription<EnumDayType>(this.CurEnumDayType) +
                                 ApplicationModel.Instance.GetEnumDescription<EnumWorkListType>(this.CurEnumWorkList) + "  " +
                                 this.PatientModelList.Count();
        }

        /// <summary>
        /// 搜索事件，根据姓名，住院号，ID 搜索
        /// </summary>
        private void Search(string msg)
        {
            this.CurEnumWorkList = EnumWorkListType.SearchCommandWorkList;
            List<MED_PAT_INFO> list = PatInfoService.ClientInstance.GetPatInfos(msg, ExtendAppContext.Current.OperDeptCode);
            this.RefreshWorkList(list);
        }

        /// <summary>
        /// 当搜索文本框为空时，恢复当前的工作列表
        /// </summary>
        private void ResetWorkList(string msg)
        {
            if (string.IsNullOrEmpty(msg))
            {
                this.CurEnumWorkList = EnumWorkListType.UnFinishWorkList;
                this.CurEnumDayType = EnumDayType.Today;
                this.RefreshData();
            }
        }

        /// <summary>
        /// 切换列表
        /// </summary>
        private void SwitchWorkList(object parameter)
        {
            EnumDayType tarDayType = EnumDayType.Unknow;
            EnumWorkListType tarWorkList = EnumWorkListType.Unknow;
            if (null != parameter && Enum.TryParse<EnumWorkListType>(parameter.ToString(), out tarWorkList) && tarWorkList != EnumWorkListType.Unknow)
            {
                this.CurEnumWorkList = tarWorkList;
                if (tarWorkList == EnumWorkListType.UnFinishWorkList)
                {
                    Messenger.Default.Send<string>("UnFinishWorkList", EnumMessageKey.RefreshEnumWorkListType);
                }
                else if (tarWorkList == EnumWorkListType.FinishWorkList)
                {
                    Messenger.Default.Send<string>("FinishWorkList", EnumMessageKey.RefreshEnumWorkListType);
                }
            }
            else if (null != parameter && parameter is bool)
            {
                this.isQuerySelfWorkList = (bool)parameter;
            }
            else if (null != parameter && Enum.TryParse<EnumDayType>(parameter.ToString(), out tarDayType) && tarDayType != EnumDayType.Unknow && tarDayType == EnumDayType.Tomorrow)
            {
                this.CurEnumDayType = tarDayType;
                this.CurEnumWorkList = EnumWorkListType.UnFinishWorkList;
                this.SpreadVisibility = System.Windows.Visibility.Visible;
            }
            else if (null != parameter && Enum.TryParse<EnumDayType>(parameter.ToString(), out tarDayType) && tarDayType != EnumDayType.Unknow && tarDayType == EnumDayType.Week)
            {
                this.CurEnumDayType = tarDayType;
                this.CurEnumWorkList = EnumWorkListType.FinishWorkList;
                this.SpreadVisibility = System.Windows.Visibility.Visible;
            }

            this.RefreshData();
        }
    }
}
