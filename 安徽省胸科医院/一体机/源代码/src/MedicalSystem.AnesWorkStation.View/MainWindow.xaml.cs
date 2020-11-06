// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      MainWindow.xaml.cs
// 功能描述(Description)：    主界面
// 数据表(Tables)：		      无
// 作者(Author)：             许文龙、孙家富
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using MedicalSystem.Anes.Document;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.Anes.FrameWork.Common;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.View.AnesGraph;
using MedicalSystem.AnesWorkStation.View.WorkList;
using MedicalSystem.AnesWorkStation.ViewModel;
using MedicalSystem.AnesWorkStation.ViewModel.Cache;
using MedicalSystem.AnesWorkStation.ViewModel.WorkListViewModel;
using MedicalSystem.AnesWorkStation.Wpf.Controls;
using MedicalSystem.AnesWorkStation.Wpf.Message;
using MedicalSystem.UsbKeyBoard;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MedicalSystem.AnesWorkStation.View
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : WindowBase
    {
        private MainViewModel mainViewModel;                            // 主界面对应的ViewModel
        private bool isMouseDown = false;                               // 标记鼠标释放按下
        private double mousedownX;                                      // 鼠标按下时的X位置
        private double mousedownY;                                      // 鼠标按下时的Y位置
        private Point mouseDownPoint;                                   // 鼠标按下时的坐标
        private InOperationWindow inOperWin = null;                     // 术中界面采用单例模式
        public bool keyBoardMessageLock = false;                        // 键盘消息锁

        /// <summary>
        /// 术中界面采用单例模式
        /// </summary>
        public InOperationWindow InOperWin
        {
            get
            {
                if (inOperWin == null)
                {
                    inOperWin = new InOperationWindow();
                }
                else
                {
                    inOperWin.RegisterKeyBoardMessage();
                    //如果当前窗口没有关闭，则立即刷新内容。
                    Messenger.Default.Send<object>(this, EnumMessageKey.RefreshInOperationWindow);
                }

                return inOperWin;
            }
        }

        /// <summary>
        /// MainWindow构造
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            mainViewModel = new MainViewModel();
            this.DataContext = mainViewModel;
            this.RegisterMessage();
            // 绑定关闭事件
            this.Closing += MainWindow_Closing;


            this.InitCustomSetting();

            // 启动跨平台消息的连接
            ViewModel.TransMessageManager.Instance.OpenConnection();

            // 绑定刷新手术进程LED灯
            ExtendAppContext.Current.RefreshCurrentPatientInfo += this.RefreshCurrentPatientInfo;

            // 设置焦点位置
            this.ResetControlFocus();
        }

        /// <summary>
        /// 初始化ICustomSetting
        /// </summary>
        private void InitCustomSetting()
        {
            try
            {
                string customSettingKey = "MedicalSystem.Anes.CustomProject.CustomSetting,MedicalSystem.Anes.CustomProject";
                Type t = Type.GetType(customSettingKey);
                ICustomSetting customSetting = Activator.CreateInstance(t) as ICustomSetting;
                if (customSetting != null)
                {
                    customSetting.InitCustomSetting();
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.Handle(e);
            }
        }

        /// <summary>
        /// 重置窗口中的焦点位置：术中 > 今日未完成工作列表 > 搜索框
        /// </summary>
        private void ResetControlFocus()
        {
            this.operatingPatient.Focusable = true;
            this.wordList.Focusable = true;

            // 术中面板
            if (this.operatingPatient.HasOperatingPatient())
            {
                this.operatingPatient.Focus();
            }
            else if (this.wordList.HasPatientWorkList())
            {
                // 工作列表
                this.wordList.ResetWorkListFocus();
            }
            else if (null == ExtendAppContext.Current.PatientInformationExtend)
            {
                // 搜索框
                this.searchControl.InputText_GotFocus(null, null);
            }
        }

        /// <summary>
        /// 搜索框方向键
        /// </summary>
        private void SearchControl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                e.Handled = true;
                if (this.searchPatientList.Visibility == System.Windows.Visibility.Visible && this.searchPatientList.HasSearchPatientList())
                {
                    // 进入搜索结果列表
                    Messenger.Default.Send<object>(typeof(SearchPatientListViewModel), EnumMessageKey.RefreshSelectedCurPatientInfoBorder);
                    this.searchPatientList.ResetSearchPatientListFocus(true);
                }
                else if (this.operatingPatient.HasOperatingPatient())
                {
                    // 进入正在手术面板
                    Messenger.Default.Send<object>(typeof(OperatingPatient), EnumMessageKey.RefreshSelectedCurPatientInfoBorder);
                    this.operatingPatient.Focus();
                }
                else if (this.wordList.HasPatientWorkList())
                {
                    // 进入工作列表
                    Messenger.Default.Send<object>(typeof(WordListViewModel), EnumMessageKey.RefreshSelectedCurPatientInfoBorder);
                    this.wordList.Focus();
                    this.wordList.ResetWorkListFocus();
                }
            }
        }

        /// <summary>
        /// 搜索结果列表
        /// </summary>
        private void SearchPatientList_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                if (this.searchPatientList.IsFirstPatient())
                {
                    e.Handled = true;
                    this.searchControl.InputText_GotFocus(null, null);
                }
            }
            else if (e.Key == Key.Down && this.searchPatientList.IsLastPatient())
            {
                e.Handled = true;
                if (this.operatingPatient.HasOperatingPatient())
                {
                    // 正在手术面板
                    Messenger.Default.Send<object>(typeof(OperatingPatient), EnumMessageKey.RefreshSelectedCurPatientInfoBorder);
                    this.operatingPatient.Focus();
                }
                else if (this.wordList.HasPatientWorkList())
                {
                    // 进入工作列表
                    Messenger.Default.Send<object>(typeof(WordListViewModel), EnumMessageKey.RefreshSelectedCurPatientInfoBorder);
                    this.wordList.Focus();
                    this.wordList.ResetWorkListFocus();
                }
            }
        }

        /// <summary>
        /// 正在手术面板
        /// </summary>
        private void OperatingPatient_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                e.Handled = true;
                // 工作列表
                if (this.wordList.HasPatientWorkList())
                {
                    Messenger.Default.Send<object>(typeof(WordListViewModel), EnumMessageKey.RefreshSelectedCurPatientInfoBorder);
                    this.wordList.Focus();
                    this.wordList.ResetWorkListFocus();
                }
            }
            else if (e.Key == Key.Up)
            {
                e.Handled = true;
                if (this.searchPatientList.Visibility == System.Windows.Visibility.Visible && this.searchPatientList.HasSearchPatientList())
                {
                    Messenger.Default.Send<object>(typeof(SearchPatientListViewModel), EnumMessageKey.RefreshSelectedCurPatientInfoBorder);
                    this.searchPatientList.ResetSearchPatientListFocus(false);
                }
                else
                {
                    this.searchControl.InputText_GotFocus(null, null);
                }
            }
            else if ((e.Key == Key.Enter || e.Key == Key.Return) && this.operatingPatient.IsFocused)
            {
                e.Handled = true;
                Messenger.Default.Send<object>(this, EnumMessageKey.ShowInOperationWindow);
            }
        }

        /// <summary>
        /// 工作列表方向键
        /// </summary>
        private void WordList_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up && this.wordList.IsFirstPatient())
            {
                e.Handled = true;
                // 进入正在手术面板
                if (this.operatingPatient.HasOperatingPatient())
                {
                    Messenger.Default.Send<object>(typeof(OperatingPatient), EnumMessageKey.RefreshSelectedCurPatientInfoBorder);
                    this.operatingPatient.Focus();
                }
                else if (this.searchPatientList.Visibility == System.Windows.Visibility.Visible && this.searchPatientList.HasSearchPatientList())
                {
                    // 进入搜索结果列表
                    Messenger.Default.Send<object>(typeof(SearchPatientListViewModel), EnumMessageKey.RefreshSelectedCurPatientInfoBorder);
                    this.searchPatientList.ResetSearchPatientListFocus(false);
                }
                else
                {
                    // 进入搜索框
                    this.searchControl.InputText_GotFocus(null, null);
                }
            }
        }

        /// <summary>
        /// 退出程序用户下线，正常做到切换账号的时候触发
        /// </summary>
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!ExtendAppContext.Current.IsNormalClosing)
            {
                this.ShowMessageBox("非正常关闭操作，请使用右上角的关闭流程！");
                e.Cancel = true;
            }
            else
            {
                KeyBoardStateCache.KeyBoard.StopVirtualKeyBoardService();
                KeyBoardStateCache.KeyBoard.UnLoadKeyBoard();
                ViewModel.TransMessageManager.Instance.CloseConnection();
            }
        }

        /// <summary
        /// 注册消息：用于不同的ViewModel之间进行通信
        /// </summary>
        private void RegisterMessage()
        {
            // 搜索功能
            Messenger.Default.Register<dynamic>(this, EnumMessageKey.SearchCommand, msg =>
            {
                if (msg != null)
                {
                    this.searchPatientList.ExecuteCommand(EnumMessageKey.SearchCommand, msg);
                    this.mainViewModel.SearchPatientListVisibility = System.Windows.Visibility.Visible;
                    this.mainViewModel.PatientListHeight = 370;
                    this.mainViewModel.WordListHeight = 740;
                    this.todaySurgery.Visibility = System.Windows.Visibility.Collapsed;
                }
            });

            // 搜索框文本更改，当文本内容为空时隐藏搜索列表控件
            Messenger.Default.Register<dynamic>(this, EnumMessageKey.SearchTextChangedCommand, msg =>
            {
                if (msg != null)
                {
                    this.searchPatientList.ExecuteCommand(EnumMessageKey.SearchTextChangedCommand, msg);
                    this.mainViewModel.SearchPatientListVisibility = System.Windows.Visibility.Collapsed;
                    this.mainViewModel.PatientListHeight = 262;
                    this.mainViewModel.WordListHeight = 600;
                    this.todaySurgery.Visibility = System.Windows.Visibility.Visible;
                }
            });

            // 查看明日手术列表
            Messenger.Default.Register<string>(this, EnumMessageKey.TomorrowSurgeryWorkListCommand, msg =>
            {
                this.wordList.ExecuteCommand(EnumMessageKey.TomorrowSurgeryWorkListCommand, msg);
            });

            // 查看一周手术信息列表
            Messenger.Default.Register<string>(this, EnumMessageKey.WeekSurgeryWorkListCommand, msg =>
            {
                this.wordList.ExecuteCommand(EnumMessageKey.WeekSurgeryWorkListCommand, msg);
            });

            // 切换列表显示
            Messenger.Default.Register<object>(this, EnumMessageKey.SwitchSurgery, msg =>
            {
                this.mainViewModel.SwitchSurgeryExecute(msg);
            });

            // 查看术中窗口
            Messenger.Default.Register<object>(this, EnumMessageKey.ShowInOperationWindow, msg =>
            {
                try
                {
                    WhirlingControlManager.ShowWaitingForm();
                    this.InOperWin.Show();
                    ExtendAppContext.Current.CurntOpenForm = new OpenForm(typeof(InOperationWindow).Name, null);
                    Messenger.Default.Send<object>(this, EnumMessageKey.HideMainWindow);
                    this.mainViewModel.UnRegisterMessage();
                }
                finally
                {
                    WhirlingControlManager.CloseWaitingForm();
                }
            });

            // 刷新选中患者的边框
            Messenger.Default.Register<object>(this, EnumMessageKey.RefreshSelectedCurPatientInfoBorder, action =>
            {
                Type type = action as Type;
                Messenger.Default.Send<object>(type.Equals(typeof(SearchPatientListViewModel)), EnumMessageKey.RefreshSearchSelectedCurPatientInfoBorder);
                Messenger.Default.Send<object>(type.Equals(typeof(OperatingPatient)), EnumMessageKey.RefreshOperatingSelectedCurPatientInfoBorder);
                Messenger.Default.Send<object>(type.Equals(typeof(WordListViewModel)), EnumMessageKey.RefreshWorkListSelectedCurPatientInfoBorder);
            });

            // 进入术中界面时隐藏主窗口
            Messenger.Default.Register<object>(this, EnumMessageKey.HideMainWindow, msg =>
            {
                this.Hide();
            });

            // 从术中界面返回显示主界面
            Messenger.Default.Register<object>(this, EnumMessageKey.ShowMainWindow, msg =>
            {
                this.mainViewModel.RegisterMessage();
                this.Show();
            });

            Messenger.Default.Register<object>(this, EnumMessageKey.HasNewVersion, msg =>
            {
                DispatcherHelper.UIDispatcher.Invoke(() =>
                {
                    var message = new ShowContentWindowMessage("About", "关于");
                    message.Height = 230;
                    message.Width = 500;
                    Messenger.Default.Send<ShowContentWindowMessage>(message);
                });
            });

            // 刷新整个界面
            Messenger.Default.Register<object>(this, EnumMessageKey.RefreshMainWindow, msg =>
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    if (!string.IsNullOrEmpty(ExtendAppContext.Current.LoginUser.USER_NAME))
                    {
                        this.LoginName = ExtendAppContext.Current.LoginUser.USER_NAME;
                    }
                    else
                    {
                        this.LoginName = string.Empty;
                    }

                    // 刷新主界面上的所有控件
                    Messenger.Default.Send<object>(this, EnumMessageKey.RefreshTodaySurgery);
                    Messenger.Default.Send<object>(this, EnumMessageKey.RefreshTomorrowSurgery);
                    Messenger.Default.Send<object>(this, EnumMessageKey.RefreshWeekSurgery);
                    Messenger.Default.Send<object>(this, EnumMessageKey.RefreshOperatingPatient);
                    Messenger.Default.Send<object>(this, EnumMessageKey.RefreshWordList);

                    // 重置焦点
                    this.ResetControlFocus();
                }));
            });

            // 协同窗口最大化最小化显示按钮
            Messenger.Default.Register<WindowState>(this, EnumMessageKey.CoordinationSizeChange, msg =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    switch (msg)
                    {
                        case WindowState.Maximized:
                            break;
                        case WindowState.Minimized:
                            this.CallIconVisibility = System.Windows.Visibility.Visible;// 本机的协同图标出现
                            break;
                        case WindowState.Normal:
                            this.CallIconVisibility = System.Windows.Visibility.Collapsed;
                            break;
                    }
                });
            });

            // 接收到新消息时显示右上角动画图标
            Messenger.Default.Register<bool>(this, EnumMessageKey.NewUnreadMessage, key =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    Process[] pros = Process.GetProcessesByName("MedicalSystem.AnesWorkStationCoordination.View");
                    if (pros.Length == 0)
                    {
                        this.CallIconVisibility = System.Windows.Visibility.Visible;
                    }
                    else if (pros.Length == 1)
                    {
                        IntPtr hWnd = pros[0].MainWindowHandle;
                        if (hWnd != IntPtr.Zero)
                        {
                            // 判断小麦助手当前是不是最小化
                            if (IsIconic(hWnd))
                            {
                                this.CallIconVisibility = System.Windows.Visibility.Visible; // 本机的协同图标出现
                            }
                        }
                    }
                });
            });

            // 刷新手术进程LED状态灯
            Messenger.Default.Register<object>(this, EnumMessageKey.RefreshSecondKeyBoardAllLed, mes =>
            {
                this.RefreshCurrentPatientInfo(null, null);
            });

            //注册键盘响应消息
            Messenger.Default.Register<AppCodeMessage>(this, message =>
            {
                ShowContentWindowMessage messagePopup;
                DispatcherHelper.UIDispatcher.Invoke(() =>
                {
                    // 判断按键消息是否过滤
                    if ((KeyBoardStateCache.AppCodeStack.Count > 0 && !KeyBoardStateCache.AppCodeEnable.Contains(message.AppCode)) || this.keyBoardMessageLock)
                    {
                        if (KeyBoardStateCache.AppCodeStack.Count > 0 && null != ExtendAppContext.Current.CurntOpenForm)
                        {
                            // 当弹出的是手术时间界面时，可直接修改
                            string formName = ExtendAppContext.Current.CurntOpenForm.FormName;
                            if (formName.Equals("InOperRoomDateRegister") || formName.Equals(AppCode.AnesStart) ||
                                formName.Equals(AppCode.OperationStart) || formName.Equals(AppCode.OperationEnd) ||
                                formName.Equals(AppCode.AnesEnd) || formName.Equals("OutOperRoomDateRegister"))
                            {
                                string strDateRegisterArgs = string.Empty;
                                switch (message.AppCode)
                                {
                                    case AppCode.InOperRoom:
                                        strDateRegisterArgs = MED_CONSTANT.RU_SHOU_SHU_SHI;
                                        break;
                                    case AppCode.AnesStart:
                                        strDateRegisterArgs = MED_CONSTANT.ANESTHESIA_START;
                                        break;
                                    case AppCode.OperationStart:
                                        strDateRegisterArgs = MED_CONSTANT.OPERATION_START;
                                        break;
                                    case AppCode.OperationEnd:
                                        strDateRegisterArgs = MED_CONSTANT.OPERATION_END;
                                        break;
                                    case AppCode.AnesEnd:
                                        strDateRegisterArgs = MED_CONSTANT.ANESTHESIA_END;
                                        break;
                                    case AppCode.OutOperRoom:
                                        strDateRegisterArgs = MED_CONSTANT.OUT_ROOM;
                                        break;
                                }

                                if (!string.IsNullOrEmpty(strDateRegisterArgs))
                                {
                                    Messenger.Default.Send<object>(strDateRegisterArgs,
                                                                   EnumMessageKey.ChangeDateRegister);
                                }
                            }
                            else if (ApplicationConfiguration.ShortCuts.ContainsKey(message.AppCode) &&
                                    !ApplicationConfiguration.ShortCuts[message.AppCode].Equals(formName))
                            {
                                // 大事件的快速切换不能和快捷键交叉
                                if (null != ExtendAppContext.Current.OperEventInfoList.FirstOrDefault(
                                                                         x => x.AppCode.Equals(formName)))
                                {
                                    return;
                                }

                                // 如果是文书之间互相切换，则无需关闭窗口
                                string value = ApplicationConfiguration.ShortCuts[message.AppCode];
                                if (!string.IsNullOrEmpty(ApplicationConfiguration.GetMedicalDocument(formName).Caption) &&
                                    !string.IsNullOrEmpty(ApplicationConfiguration.GetMedicalDocument(value).Caption) &&
                                    !value.Equals(formName))
                                {
                                    Messenger.Default.Send<string>(value,
                                                                   EnumMessageKey.QuickChangeDoc);
                                    return;
                                }

                                // 退出当前窗口
                                Messenger.Default.Send<string>(AppCode.Back, MessageTokens.KEYBOARDMSG);

                                // 确保当前文书完全退出
                                for (int i = 0; i < 10; i++)
                                {
                                    if (KeyBoardStateCache.AppCodeStack.Count > 0)
                                    {
                                        ExtendAppContext.Current.Sleep(500);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                Messenger.Default.Send<string>(message.AppCode, MessageTokens.KEYBOARDMSG);
                            }
                            else if (!formName.Equals(message.AppCode) &&
                                     null != ExtendAppContext.Current.OperEventInfoList.FirstOrDefault(
                                                                         x => x.AppCode.Equals(message.AppCode)) &&
                                     null != ExtendAppContext.Current.OperEventInfoList.FirstOrDefault(x =>
                                                                         x.AppCode.Equals(formName)))
                            {
                                // 大事件的快速切换
                                // 相同类型的直接刷新数据
                                if (ExtendAppContext.Current.OperEventInfoList.First(x => x.AppCode.Equals(message.AppCode)).
                                                                    EventType.Equals(
                                    ExtendAppContext.Current.OperEventInfoList.First(x => x.AppCode.Equals(formName)).EventType))
                                {
                                    Messenger.Default.Send<object>(message.AppCode,
                                                                   EnumMessageKey.QuickChangeOperEventWindow);
                                }
                                else
                                {
                                    // 不同类型的先退出再进入
                                    Messenger.Default.Send<string>(AppCode.Back, MessageTokens.KEYBOARDMSG);

                                    // 确保当前大事件界面完全退出
                                    for (int i = 0; i < 10; i++)
                                    {
                                        if (KeyBoardStateCache.AppCodeStack.Count > 0)
                                        {
                                            ExtendAppContext.Current.Sleep(500);
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }

                                    Messenger.Default.Send<string>(message.AppCode, MessageTokens.KEYBOARDMSG);
                                }
                            }
                        }

                        return;
                    }

                    if (!KeyBoardStateCache.AppCodeEnable.Contains(message.AppCode))
                    {
                        KeyBoardStateCache.CurrentAppCode = message.AppCode;
                    }

                    switch (message.AppCode)
                    {
                        case AppCode.Emergency:
                            messagePopup = new ShowContentWindowMessage("EmergencyRegisterControl", MED_CONSTANT.EMERGENCY_REGISTER);
                            messagePopup.Height = MED_CONSTANT.POPUP_WINDOW_HEIGHT;
                            messagePopup.Width = MED_CONSTANT.POPUP_WINDOW_WIDTH;
                            messagePopup.TileBackground = (Brush)(new BrushConverter()).ConvertFromString("#F2806D");
                            Messenger.Default.Send<ShowContentWindowMessage>(messagePopup);
                            ExtendAppContext.Current.CurntOpenForm = new OpenForm(AppCode.Emergency, null);
                            break;

                        case AppCode.OperInfo:
                            if (CheckCurrentPatient())
                            {
                                messagePopup = new ShowContentWindowMessage("OperationInformationControl", MED_CONSTANT.OPERATION_INFOMATION);
                                messagePopup.Height = MED_CONSTANT.POPUP_WINDOW_HEIGHT;
                                messagePopup.Width = MED_CONSTANT.POPUP_WINDOW_WIDTH;
                                Messenger.Default.Send<ShowContentWindowMessage>(messagePopup);
                                ExtendAppContext.Current.CurntOpenForm = new OpenForm(AppCode.OperInfo, null);
                            }
                            break;
                        case AppCode.FunctionMenu:
                            messagePopup = new ShowContentWindowMessage("BottomMenu", "");
                            messagePopup.WindowType = ContentWindowType.ToolBox;
                            messagePopup.Height = MED_CONSTANT.TOOL_BAR_HEIGHT;
                            messagePopup.Width = SystemParameters.PrimaryScreenWidth;
                            messagePopup.IsModal = false;
                            messagePopup.PositionX = 0;
                            messagePopup.PositionY = SystemParameters.PrimaryScreenHeight - messagePopup.Height;
                            messagePopup.TileBackground = Brushes.Transparent;
                            Messenger.Default.Send<ShowContentWindowMessage>(messagePopup);
                            ExtendAppContext.Current.CurntOpenForm = new OpenForm(AppCode.FunctionMenu, null);
                            break;

                        case AppCode.PreoperativeInterview:
                            if (CheckCurrentPatient())
                            {
                                messagePopup = new ShowContentWindowMessage("LoadReport", MED_CONSTANT.SHU_QIAN_FANG_SHI);
                                messagePopup.Height = SystemParameters.PrimaryScreenHeight;
                                messagePopup.Width = SystemParameters.PrimaryScreenWidth;
                                messagePopup.WindowType = ContentWindowType.Document;
                                messagePopup.Args = new object[] { MED_CONSTANT.SHU_QIAN_FANG_SHI };
                                Messenger.Default.Send<ShowContentWindowMessage>(messagePopup);
                                ExtendAppContext.Current.CurntOpenForm = new OpenForm(AppCode.PreoperativeInterview, null);
                            }
                            break;

                        case AppCode.PostoperativeFollowUp:
                            if (CheckCurrentPatient())
                            {
                                messagePopup = new ShowContentWindowMessage("LoadReport", MED_CONSTANT.SHU_HOU_SUI_FANG);
                                messagePopup.Height = SystemParameters.PrimaryScreenHeight;
                                messagePopup.Width = SystemParameters.PrimaryScreenWidth;
                                messagePopup.WindowType = ContentWindowType.Document;
                                messagePopup.Args = new object[] { MED_CONSTANT.SHU_HOU_SUI_FANG };
                                Messenger.Default.Send<ShowContentWindowMessage>(messagePopup);
                                ExtendAppContext.Current.CurntOpenForm = new OpenForm(AppCode.PostoperativeFollowUp, null);
                            }
                            break;

                        case AppCode.InformedConsent:
                            if (CheckCurrentPatient())
                            {
                                messagePopup = new ShowContentWindowMessage("LoadReport", MED_CONSTANT.MA_ZUI_TONG_YI);
                                messagePopup.Height = SystemParameters.PrimaryScreenHeight;
                                messagePopup.Width = SystemParameters.PrimaryScreenWidth;
                                messagePopup.WindowType = ContentWindowType.Document;
                                messagePopup.Args = new object[] { MED_CONSTANT.MA_ZUI_TONG_YI };
                                Messenger.Default.Send<ShowContentWindowMessage>(messagePopup);
                                ExtendAppContext.Current.CurntOpenForm = new OpenForm(AppCode.InformedConsent, null);
                            }
                            break;

                        case AppCode.AnesRecord:
                            if (CheckCurrentPatient())
                            {
                                messagePopup = new ShowContentWindowMessage("LoadReport", MED_CONSTANT.MA_ZUI_JI_LU);
                                messagePopup.Height = SystemParameters.PrimaryScreenHeight;
                                messagePopup.Width = SystemParameters.PrimaryScreenWidth;
                                messagePopup.WindowType = ContentWindowType.Document;
                                messagePopup.Args = new object[] { MED_CONSTANT.MA_ZUI_JI_LU };
                                Messenger.Default.Send<ShowContentWindowMessage>(messagePopup);
                                ExtendAppContext.Current.CurntOpenForm = new OpenForm(AppCode.AnesRecord, null);
                            }
                            break;

                        case AppCode.InOperRoom:   // 入手术室
                            bool isCheck = true;
                            if (CheckCurrentPatient())
                            {
                                if (isCheck && ExtendAppContext.Current.PatientInformationExtend.OPER_ROOM_NO != ExtendAppContext.Current.OperRoomNo)
                                {
                                    ShowMessageBox("选中病人非安排到当前手术室，请确认或者修改手术室编号。");
                                    isCheck = false;
                                }

                                // 判断当前是否已经存在正在手术的患者
                                if (isCheck && ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE < (int)OperationStatus.OutOperationRoom)
                                {
                                    MED_PAT_INFO patInfo = PatInfoService.ClientInstance.GetCurPatientInfo(ExtendAppContext.Current.OperDeptCode, ExtendAppContext.Current.OperRoomNo);
                                    if (patInfo != null && ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID != patInfo.PATIENT_ID)
                                    {
                                        ShowMessageBox("当前手术间有患者正在手术，请稍后。");
                                        isCheck = false;
                                    }
                                }

                                // 当前已有正在手术的患者，编辑这个患者的入室时间
                                if (isCheck && ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE > (int)OperationStatus.OperScheduled)
                                {
                                    messagePopup = new ShowContentWindowMessage("DateRegister", MED_CONSTANT.RU_SHOU_SHU_SHI);
                                    messagePopup.Height = 1330;
                                    messagePopup.Width = 748;
                                    messagePopup.Args = new object[] { MED_CONSTANT.RU_SHOU_SHU_SHI };
                                    messagePopup.IsModal = false;
                                    messagePopup.CallBackCommand = this.CloseContentWindow;
                                    Messenger.Default.Send<ShowContentWindowMessage>(messagePopup);
                                    ExtendAppContext.Current.CurntOpenForm = new OpenForm("InOperRoomDateRegister", null);
                                    isCheck = false;
                                }

                                if (isCheck)
                                {
                                    if (ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE !=
                                        (int)OperationStatus.OperScheduled &&
                                        ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE !=
                                        (int)OperationStatus.IsReady)
                                    {
                                        ShowMessageBox("当前选中患者不是术前状态，无法进行入室操作。");
                                    }
                                    else
                                    {
                                        messagePopup = new ShowContentWindowMessage("InHospitalRegister", MED_CONSTANT.RU_SHI_QUE_REN);
                                        messagePopup.Height = 1330;
                                        messagePopup.Width = 748;
                                        messagePopup.IsModal = false;
                                        messagePopup.CallBackCommand = this.ShowInOperationWindow;
                                        Messenger.Default.Send<ShowContentWindowMessage>(messagePopup);
                                        ExtendAppContext.Current.CurntOpenForm = new OpenForm(AppCode.InOperRoom, null);
                                    }
                                }
                            }
                            break;

                        case AppCode.AnesStart:
                            if (CheckCurrentPatient())
                            {
                                if (ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE <
                                    (int)OperationStatus.InOperationRoom)
                                {
                                    ShowMessageBox("请按流程顺序操作。");
                                }
                                else if (ExtendAppContext.Current.PatientInformationExtend.OPER_ROOM_NO !=
                                         ExtendAppContext.Current.OperRoomNo)
                                {
                                    this.ShowMessageBox("当前患者不是本手术间患者，不能执行跨手术间操作！");
                                }
                                else
                                {
                                    messagePopup = new ShowContentWindowMessage("DateRegister", MED_CONSTANT.ANESTHESIA_START);
                                    messagePopup.Height = 1330;
                                    messagePopup.Width = 748;
                                    messagePopup.IsModal = false;
                                    messagePopup.Args = new object[] { MED_CONSTANT.ANESTHESIA_START };
                                    messagePopup.CallBackCommand = this.CloseContentWindow;
                                    Messenger.Default.Send<ShowContentWindowMessage>(messagePopup);
                                    ExtendAppContext.Current.CurntOpenForm = new OpenForm(AppCode.AnesStart, null);
                                }
                            }
                            break;

                        case AppCode.OperationStart:
                            if (CheckCurrentPatient())
                            {
                                if (ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE <
                                    (int)OperationStatus.AnesthesiaStart)
                                {
                                    ShowMessageBox("请按流程顺序操作。");
                                }
                                else if (ExtendAppContext.Current.PatientInformationExtend.OPER_ROOM_NO !=
                                         ExtendAppContext.Current.OperRoomNo)
                                {
                                    this.ShowMessageBox("当前患者不是本手术间患者，不能执行跨手术间操作！");
                                }
                                else
                                {
                                    messagePopup = new ShowContentWindowMessage("DateRegister", MED_CONSTANT.OPERATION_START);
                                    messagePopup.Height = 1330;
                                    messagePopup.Width = 748;
                                    messagePopup.IsModal = false;
                                    messagePopup.Args = new object[] { MED_CONSTANT.OPERATION_START };
                                    messagePopup.CallBackCommand = this.CloseContentWindow;
                                    Messenger.Default.Send<ShowContentWindowMessage>(messagePopup);
                                    ExtendAppContext.Current.CurntOpenForm = new OpenForm(AppCode.OperationStart, null);
                                }
                            }
                            break;

                        case AppCode.OperationEnd:
                            if (CheckCurrentPatient())
                            {
                                if (ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE <
                                    (int)OperationStatus.OperationStart)
                                {
                                    ShowMessageBox("请按流程顺序操作。");
                                }
                                else if (ExtendAppContext.Current.PatientInformationExtend.OPER_ROOM_NO !=
                                         ExtendAppContext.Current.OperRoomNo)
                                {
                                    this.ShowMessageBox("当前患者不是本手术间患者，不能执行跨手术间操作！");
                                }
                                else
                                {
                                    messagePopup = new ShowContentWindowMessage("DateRegister", MED_CONSTANT.OPERATION_END);
                                    messagePopup.Height = 1330;
                                    messagePopup.Width = 748;
                                    messagePopup.IsModal = false;
                                    messagePopup.Args = new object[] { MED_CONSTANT.OPERATION_END };
                                    messagePopup.CallBackCommand = this.CloseContentWindow;
                                    Messenger.Default.Send<ShowContentWindowMessage>(messagePopup);
                                    ExtendAppContext.Current.CurntOpenForm = new OpenForm(AppCode.OperationEnd, null);
                                }
                            }
                            break;

                        case AppCode.AnesEnd:
                            if (CheckCurrentPatient())
                            {
                                if (ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE <
                                    (int)OperationStatus.OperationEnd)
                                {
                                    ShowMessageBox("请按流程顺序操作。");
                                }
                                else if (ExtendAppContext.Current.PatientInformationExtend.OPER_ROOM_NO !=
                                         ExtendAppContext.Current.OperRoomNo)
                                {
                                    this.ShowMessageBox("当前患者不是本手术间患者，不能执行跨手术间操作！");
                                }
                                else
                                {
                                    messagePopup = new ShowContentWindowMessage("DateRegister", MED_CONSTANT.ANESTHESIA_END);
                                    messagePopup.Height = 1330;
                                    messagePopup.Width = 748;
                                    messagePopup.IsModal = false;
                                    messagePopup.Args = new object[] { MED_CONSTANT.ANESTHESIA_END };
                                    messagePopup.CallBackCommand = this.CloseContentWindow;
                                    Messenger.Default.Send<ShowContentWindowMessage>(messagePopup);
                                    ExtendAppContext.Current.CurntOpenForm = new OpenForm(AppCode.AnesEnd, null);
                                }
                            }
                            break;

                        case AppCode.OutOperRoom:
                            if (CheckCurrentPatient())
                            {
                                if (ExtendAppContext.Current.IsOperationRescuing)
                                {
                                    this.ShowMessageBox("当前患者处于抢救状态，请先退出抢救模式再出手术室！");
                                }
                                else if (ExtendAppContext.Current.PatientInformationExtend.OPER_ROOM_NO !=
                                         ExtendAppContext.Current.OperRoomNo)
                                {
                                    this.ShowMessageBox("当前患者不是本手术间患者，不能执行跨手术间操作！");
                                }
                                else
                                {
                                    if (ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE ==
                                        (int)OperationStatus.AnesthesiaEnd)
                                    {
                                        messagePopup = new ShowContentWindowMessage("OutRegister", MED_CONSTANT.OUT_ROOM_CONFIRM);
                                        messagePopup.Height = 1330;
                                        messagePopup.Width = 748;
                                        messagePopup.IsModal = false;
                                        Messenger.Default.Send<ShowContentWindowMessage>(messagePopup);
                                        ExtendAppContext.Current.CurntOpenForm = new OpenForm(AppCode.OutOperRoom, null);
                                    }
                                    else if (ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE <
                                             (int)OperationStatus.AnesthesiaEnd)
                                    {
                                        ShowMessageBox("请按流程顺序操作。");
                                    }
                                    else if (ExtendAppContext.Current.PatientInformationExtend != null &&
                                             ExtendAppContext.Current.PatientInformationExtend.OUT_DATE_TIME != null &&
                                             ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE >=
                                             (int)OperationStatus.OutOperationRoom)
                                    {
                                        //当前已有正在手术的患者，编辑这个患者的出室时间
                                        messagePopup = new ShowContentWindowMessage("DateRegister", MED_CONSTANT.OUT_ROOM);
                                        messagePopup.Height = 1330;
                                        messagePopup.Width = 748;
                                        messagePopup.IsModal = false;
                                        messagePopup.Args = new object[] { MED_CONSTANT.OUT_ROOM };
                                        Messenger.Default.Send<ShowContentWindowMessage>(messagePopup);
                                        ExtendAppContext.Current.CurntOpenForm = new OpenForm("OutOperRoomDateRegister", null);
                                        return;
                                    }
                                    ExtendAppContext.Current.CurntOpenForm = new OpenForm(AppCode.OutOperRoom, null);
                                }
                            }
                            break;

                        case AppCode.QC://质控上报
                            if (CheckCurrentPatient())
                            {
                                messagePopup = new ShowContentWindowMessage("QualityControlRegistration", "质控登记");
                                messagePopup.Height = MED_CONSTANT.POPUP_WINDOW_HEIGHT;
                                messagePopup.Width = MED_CONSTANT.POPUP_WINDOW_WIDTH;
                                Messenger.Default.Send<ShowContentWindowMessage>(messagePopup);
                            }
                            break;

                        case AppCode.PACU://PACU
                            messagePopup = new ShowContentWindowMessage("PACUQuery", "PACU床位情况一览");
                            messagePopup.Height = 820;
                            messagePopup.Width = 748;
                            Messenger.Default.Send<ShowContentWindowMessage>(messagePopup);
                            break;

                        case AppCode.OperationScreen://家属公告
                            if (CheckCurrentPatient())
                            {
                                messagePopup = new ShowContentWindowMessage("OperationScreen", "术中家属协同");
                                messagePopup.Height = 650;
                                messagePopup.Width = 600;
                                Messenger.Default.Send<ShowContentWindowMessage>(messagePopup);
                            }
                            break;

                        //case AppCode.InstrumentValidation://仪器确认
                        //    if (CheckCurrentPatient())
                        //    {
                        //        if (ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE >= (int)OperationStatus.InOperationRoom &&
                        //            ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE < (int)OperationStatus.OutOperationRoom)
                        //        {
                        //            messagePopup = new ShowContentWindowMessage("MonitorBind", "仪器设置");
                        //            messagePopup.Height = 1200;
                        //            messagePopup.Width = 760;
                        //            Messenger.Default.Send<ShowContentWindowMessage>(messagePopup);
                        //        }
                        //        else
                        //        {
                        //            ShowMessageBox("请按流程顺序操作。");
                        //        }
                        //    }
                        //    break;

                        case AppCode.OperationChange://手术换台                           
                            if (CheckCurrentPatient())
                            {
                                if (ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE >= (int)OperationStatus.InOperationRoom &&
                                    ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE < (int)OperationStatus.OutOperationRoom)
                                {
                                    messagePopup = new ShowContentWindowMessage("OperationShift", "手术交接班");
                                    messagePopup.Height = 660;
                                    messagePopup.Width = 700;
                                    Messenger.Default.Send<ShowContentWindowMessage>(messagePopup);
                                }
                                else
                                {
                                    ShowMessageBox("无正在进行的手术，无法手术交接班。");
                                }
                            }
                            break;

                        case AppCode.Rescue: // 抢救模式
                            if (this.CheckCurrentPatient())
                            {
                                if (ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE >= (int)OperationStatus.InOperationRoom &&
                                    ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE < (int)OperationStatus.OutOperationRoom)
                                {
                                    if (!ExtendAppContext.Current.IsOperationRescuing)
                                    {
                                        // 进入抢救模式
                                        ExtendAppContext.Current.IsOperationRescuing = true;
                                        Messenger.Default.Send<object>(this, EnumMessageKey.IsOperationRescuing);
                                    }
                                    else
                                    {
                                        // 弹出抢救结束窗口
                                        messagePopup = new ShowContentWindowMessage("OperationRescue", "抢救结束确认");
                                        messagePopup.Height = 660;
                                        messagePopup.Width = 600;
                                        Messenger.Default.Send<ShowContentWindowMessage>(messagePopup);
                                    }
                                    Messenger.Default.Send<object>(this, EnumMessageKey.RefreshInOperationWindow);
                                }
                                else
                                {
                                    this.ShowMessageBox("当前患者不是处于术中状态，无法进入或者退出抢救模式！");
                                }
                            }

                            break;
                        case AppCode.Interface: // 信息接口窗口
                            if (this.CheckCurrentPatient())
                            {
                                List<MED_INTERFACE_DETAIL> interList = CommonService.ClientInstance.GetInterfaceDetail();
                                int count = interList.Where(x => x.INT_ENABLE == 1).Count();
                                if (count > 0)
                                {
                                    // 弹出抢救结束窗口
                                    messagePopup = new ShowContentWindowMessage("OperationInterfaceControl", "信息接口");
                                    messagePopup.Height = 124 + 5;
                                    messagePopup.Width = 164 * count + 10 * count;
                                    messagePopup.WindowType = ContentWindowType.ToolBox;
                                    messagePopup.IsModal = false;
                                    messagePopup.PositionX = (SystemParameters.PrimaryScreenWidth - messagePopup.Width) / 2;
                                    messagePopup.PositionY = (SystemParameters.PrimaryScreenHeight - messagePopup.Height) / 2;
                                    messagePopup.TileBackground = Brushes.Transparent;
                                    if(count == 1)
                                    {
                                        messagePopup.Args = new object[] 
                                        { interList.Where(x => x.INT_ENABLE == 1).FirstOrDefault() };
                                    }
                                    Messenger.Default.Send<ShowContentWindowMessage>(messagePopup);
                                    ExtendAppContext.Current.CurntOpenForm = new OpenForm(AppCode.Interface, null);
                                }
                                else
                                {
                                    this.ShowMessageBox("信息接口功能未配置，请先在平台配置！");
                                }
                            }
                            break;
                        case AppCode.TomorrowOperation:
                        case AppCode.OtherReport:
                            ShowMessageBox("该功能暂未开放，无法使用。");
                            break;
                        //case AppCode.M8:
                        //    UploadLogFile();
                        //    break;
                        default:
                            Messenger.Default.Send<string>(message.AppCode, MessageTokens.KEYBOARDMSG);
                            break;
                    }
                });
            });
        }

        /// <summary>
        /// 检查当前患者信息是否为空
        /// </summary>
        private bool CheckCurrentPatient()
        {
            bool result = true;
            if (ExtendAppContext.Current.PatientInformationExtend == null ||    
                ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID == "")
            {
                result = false;
                ShowMessageBox("请先选中一个患者后重试。");
            }
            return result;
        }

        /// <summary>
        /// 弹框封装，在显示弹出框时屏蔽按键消息
        /// </summary>
        private void ShowMessageBox(string text)
        {
            this.keyBoardMessageLock = true;
            ConfirmMessageBox.Show("系统提示", text, MessageBoxButton.OK, MessageBoxImage.Warning);
            this.keyBoardMessageLock = false;
        }

        /// <summary>
        /// 菜单图片鼠标点击事件
        /// </summary>
        private void Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.isMouseDown = true;
            (sender as Image).CaptureMouse();
            this.mouseDownPoint = e.GetPosition(myPad);
            this.mousedownX = mouseDownPoint.X;
            this.mousedownY = mouseDownPoint.Y;
        }

        /// <summary>
        /// 当选中患者切换时刷新指示灯
        /// </summary>
        private void RefreshCurrentPatientInfo(object sender, EventArgs e)
        {
            if (null != ExtendAppContext.Current.PatientInformationExtend)
            {
                // 设置LED灯状态
                int lightIndex = OperationStatusHelper.GetOperStatusIndex(ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE);
                KeyBoardStateCache.KeyBoard.OpenSecondKeyBoardAllLed(lightIndex);
            }
        }

        /// <summary>
        /// 菜单图片鼠标拖动事件
        /// </summary>
        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isMouseDown)
            {
                Point movePoint = e.GetPosition(myPad);
                double deltx = movePoint.X - mouseDownPoint.X;
                double delty = movePoint.Y - mouseDownPoint.Y;
                this._trans.X += deltx;
                this._trans.Y += delty;
                this.mouseDownPoint = movePoint;
            }
        }

        /// <summary>
        /// 菜单图片鼠标释放事件
        /// </summary>
        private void Button_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.isMouseDown = false;
            Point uppoint = e.GetPosition(myPad);
            (sender as Image).ReleaseMouseCapture();
            if (Math.Abs(uppoint.X - mousedownX) < 3 && Math.Abs(uppoint.Y - mousedownY) < 3)
            {
                if (this._btnSet.Command != null)
                {
                    this._btnSet.Command.Execute("");
                }
            }
        }

        /// <summary>
        /// 按M1上传最新的日志文件
        /// </summary>
        private void UploadLogFile()
        {
            string dir = Environment.CurrentDirectory + "\\logs\\";
            string fileName = GetLastUpdateFile(dir);
            using (FileStream fs = new FileStream(dir + fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                long size = fs.Length;
                byte[] array = new byte[size];

                //将文件读到byte数组中
                fs.Read(array, 0, array.Length);
                fs.Close();

                CommonService.ClientInstance.PostFile(
                    new { FILE = array, FileName = fileName, ExtendAppContext.Current.OperRoomNo });
            }
        }

        /// <summary>
        /// 获取目录下最新修改文件名
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        private string GetLastUpdateFile(string dir)
        {
            DirectoryInfo d = new DirectoryInfo(dir);

            var qry = from x in d.GetFiles()
                      orderby x.LastWriteTime
                      select x.Name;
            return qry.LastOrDefault();
        }

        public ICommand CloseContentWindow
        {
            get
            {
                return new RelayCommand<object>(key =>
                {
                    if (null != key && key is bool)
                    {
                        Dispatcher.BeginInvoke((Action)delegate
                        {
                            Messenger.Default.Send<AppCodeMessage>(new AppCodeMessage() { AppCode = AppCode.OutOperRoom });
                        }, System.Windows.Threading.DispatcherPriority.Send);
                    }
                });
            }
        }

        /// <summary>
        /// 入室成功后自动进入术中界面
        /// </summary>
        public ICommand ShowInOperationWindow
        {
            get
            {
                return new RelayCommand<object>(key =>
                {
                    // 入室成功后才能进入术中界面
                    if (null != key && key is bool && (bool)key)
                    {
                        Messenger.Default.Send<object>(this, EnumMessageKey.ShowInOperationWindow);
                    }
                });
            }
        }

        /// <summary>
        /// 判断窗口是否是最小化
        /// </summary>
        [DllImport("user32.dll")]
        public static extern bool IsIconic(IntPtr hWnd);
    }
}
