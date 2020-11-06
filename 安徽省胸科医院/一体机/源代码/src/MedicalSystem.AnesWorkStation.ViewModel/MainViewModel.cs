// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      MainViewModel.cs
// 功能描述(Description)：    主界面对应的ViewModel
// 数据表(Tables)：		      许文龙
// 作者(Author)：             MDSD
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.Document.Utilities;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.ViewModel.Cache;
using MedicalSystem.AnesWorkStation.ViewModel.WorkListViewModel;
using MedicalSystem.AnesWorkStation.Wpf.Message;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MedicalSystem.AnesWorkStation.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private object locker = new object();                                             // 刷新锁
        private Visibility tomorrowSurgeryVisibility = Visibility.Visible;                // 明日手术信息汇总 默认显示 
        private Visibility weekSurgeryVisibility = Visibility.Collapsed;                  // 一周手术信息汇总 默认不显示
        private Visibility searchPatientListVisibility = Visibility.Collapsed;            // 搜索结果列表显示与否，默认不显示
        private int patientListHeight = 262;  //查询列表高度
        private int wordListHeight = 860;  //工作列表高度
        /// <summary>
        /// 明日手术信息汇总 默认显示 
        /// </summary>
        public Visibility TomorrowSurgeryVisibility
        {
            get { return this.tomorrowSurgeryVisibility; }
            set
            {
                this.tomorrowSurgeryVisibility = value;
                this.RaisePropertyChanged("TomorrowSurgeryVisibility");
            }
        }

        /// <summary>
        /// 一周手术信息汇总 默认不显示
        /// </summary>
        public Visibility WeekSurgeryVisibility
        {
            get { return this.weekSurgeryVisibility; }
            set
            {
                this.weekSurgeryVisibility = value;
                this.RaisePropertyChanged("WeekSurgeryVisibility");
            }
        }

        /// <summary>
        /// 搜索结果列表显示与否，默认不显示
        /// </summary>
        public Visibility SearchPatientListVisibility
        {
            get { return this.searchPatientListVisibility; }
            set
            {
                this.searchPatientListVisibility = value;
                this.RaisePropertyChanged("SearchPatientListVisibility");
            }
        }
        /// <summary>
        /// 查询列表高度
        /// </summary>
        public int PatientListHeight
        {
            get { return this.patientListHeight; }
            set
            {
                this.patientListHeight = value;
                this.RaisePropertyChanged("PatientListHeight");
            }
        }
        /// <summary>
        /// 工作列表高度
        /// </summary>
        public int WordListHeight
        {
            get { return this.wordListHeight; }
            set
            {
                this.wordListHeight = value;
                this.RaisePropertyChanged("WordListHeight");
            }
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        public MainViewModel()
        {
            // 根据服务器时间设置本地电脑时间
            SetLocalSystemDate();
            this.RegisterMessage();
        }

        /// <summary>
        /// 注册响应消息
        /// </summary>
        public void RegisterMessage()
        {
            this.RegisterPublicKeyBoard = false;
            this.RegisterKeyBoardMessage();
        }

        /// <summary>
        /// 注销键盘响应消息
        /// </summary>
        public void UnRegisterMessage()
        {
            this.UnRegisterKeyBoardMessage();
        }

        /// <summary>
        /// 键盘响应事件，提供各个模块调用
        /// </summary>
        /// <param name="keyCode">按键编码</param>
        protected override void KeyBoardMessage(string keyCode)
        {
            if (KeyBoardStateCache.AppCodeStack.Count == 0 &&
                (null == ExtendAppContext.Current.CurntOpenForm ||
                 ExtendAppContext.Current.CurntOpenForm.FormName.Equals("MainWindow")))
            {
                // 响应快捷键调用文书
                if (ApplicationConfiguration.ShortCuts.ContainsKey(keyCode))
                {
                    string value = ApplicationConfiguration.ShortCuts[keyCode];
                    // 判断是不是文书
                    if (!string.IsNullOrEmpty(ApplicationConfiguration.GetMedicalDocument(value).Caption))
                    {
                        ExtendAppContext.Current.CurntOpenForm = new OpenForm(value, null);
                        this.ShowDocByDocName(value);
                    }
                    else
                    {
                        // 快捷键响应功能按键
                        switch (value)
                        {
                            case "血气分析":
                                this.BloodGasAnalysisControlMethod();
                                break;
                            case "手术跳转":
                                this.OperatioinJumpMethod();
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 将本地时间保持和服务器时间一致
        /// </summary>
        public static void SetLocalSystemDate()
        {
            DateTime dt = CommonService.ClientInstance.GetServerTime();
            WinAPI.SYSTEMTIME st;

            st.year = (short)dt.Year;
            st.month = (short)dt.Month;
            st.dayOfWeek = (short)dt.DayOfWeek;
            st.day = (short)dt.Day;
            st.hour = (short)dt.Hour;
            st.minute = (short)dt.Minute;
            st.second = (short)dt.Second;
            st.milliseconds = (short)dt.Millisecond;

            WinAPI.SetLocalTime(ref st);
        }

        /// <summary>
        /// 根据命令参数判断是显示明日手术汇总信息还是一周手术汇总信息
        /// </summary>
        public void SwitchSurgeryExecute(object parameter)
        {
            EnumWorkListType tarWorkList = EnumWorkListType.Unknow;
            if (null != parameter && Enum.TryParse<EnumWorkListType>(parameter.ToString(), out tarWorkList) && tarWorkList != EnumWorkListType.Unknow)
            {
                this.TomorrowSurgeryVisibility = tarWorkList == EnumWorkListType.UnFinishWorkList ? Visibility.Visible : Visibility.Collapsed;
                this.WeekSurgeryVisibility = tarWorkList == EnumWorkListType.FinishWorkList ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        /// <summary>
        /// 功能菜单按钮命令
        /// </summary>
        public ICommand BottomMenu
        {
            get
            {
                return new RelayCommand<string>(key =>
                {
                    var message = new ShowContentWindowMessage("BottomMenu", "");
                    message.WindowType = ContentWindowType.ToolBox;
                    message.Height = MED_CONSTANT.TOOL_BAR_HEIGHT;
                    message.Width = SystemParameters.PrimaryScreenWidth;
                    message.IsModal = false;
                    message.PositionX = 0;
                    message.PositionY = SystemParameters.PrimaryScreenHeight - message.Height;
                    message.TileBackground = Brushes.Transparent;
                    Messenger.Default.Send<ShowContentWindowMessage>(message);
                });
            }
        }

        /// <summary>
        /// 关闭窗体事件
        /// </summary>
        public override void OnPreviewViewUnLoaded(System.ComponentModel.CancelEventArgs e)
        {
            base.OnPreviewViewUnLoaded(e);
            // 关闭程序时，所有键盘灯重置
            KeyBoardStateCache.KeyBoard.CloseMainKeyBoardAllLed();
            KeyBoardStateCache.KeyBoard.CloseSecondKeyBoardAllLed();
            Messenger.Default.Unregister<string>(this);
        }
    }
}