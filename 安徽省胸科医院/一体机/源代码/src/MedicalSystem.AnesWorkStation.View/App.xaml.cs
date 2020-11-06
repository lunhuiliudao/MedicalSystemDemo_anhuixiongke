// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      App.xaml.cs
// 功能描述(Description)：    项目工程起始入口
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.View.Actions;
using MedicalSystem.AnesWorkStation.View.InOperation;
using MedicalSystem.AnesWorkStation.View.OperationInformation;
using MedicalSystem.AnesWorkStation.View.QualityControl;
using MedicalSystem.AnesWorkStation.View.ToolBar;
using MedicalSystem.AnesWorkStation.View.WorkList;
using MedicalSystem.AnesWorkStation.ViewModel.Cache;
using MedicalSystem.AnesWorkStation.Wpf.Controls;
using MedicalSystem.AnesWorkStation.Wpf.Message;
using MedicalSystem.Services;
using MedicalSystem.UsbKeyBoard;
using System.Diagnostics;
using Newtonsoft.Json;
using MedicalSystem.AnesWorkStation.ViewModel;
using MedicalSystem.AnesWorkStation.Model;

namespace MedicalSystem.AnesWorkStation.View
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : System.Windows.Application
    {
        /// <summary>
        /// API：根据窗口名称查找窗口
        /// </summary>
        /// <returns></returns>
        [DllImport("user32", CharSet = CharSet.Unicode)]
        static extern IntPtr FindWindow(string cls, string win);

        /// <summary>
        /// API：切换窗口
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

        /// <summary>
        ///  显示/隐藏窗口  
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="nCmdShow">0：不显示，1：普通显示，2：最小化，3：最大化</param>

        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);

        /// <summary>
        /// 判断窗口是否是最小化
        /// </summary>
        [DllImport("user32.dll")]
        public static extern bool IsIconic(IntPtr hWnd);

        private Mutex mut = null;            // 线程信息，判断软件是否已经启动

        /// <summary>
        /// 构造方法：判断软件是否已经启动。该软件使用单例进程
        /// </summary>
        public App()
        {
            bool requestInitialOwnership = true;
            bool mutexWasCreated = false;
            mut = new System.Threading.Mutex(requestInitialOwnership, "MedicalSystem.AnesWorkStation", out mutexWasCreated);
            if (!(requestInitialOwnership && mutexWasCreated))
            {
                MessageBoxResult result =  ConfirmMessageBox.Show("", "麻醉信息工作站正在运行，是否关闭当前系统重新启动？", 
                                           MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes || result == MessageBoxResult.OK)
                {
                    // 杀掉当前正在运行的窗口
                    this.KillWindow();
                    System.Threading.Thread.Sleep(1000);
                    System.Windows.Forms.Application.Restart();
                    //System.Windows.Application.Current.Shutdown();
                }
                else
                {
                    this.ActivateWindow();
                    System.Windows.Application.Current.Shutdown();
                }
            }

            // 新的网页版自动更新
            UpdateDLL.Update.CheckVerion();
        }

        /// <summary>
        /// 重写启动方法，绑定捕获全局异常方法
        /// </summary>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            DataServices.AnesWorkStationInstaller.RegistConfig();
            Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            DispatcherHelper.Initialize();
            ExtendAppContext.Current.CurEnumLoginType = Anes.FrameWork.Enum.EnumLoginType.NormalLogin;

            this.RegisterMessage();

            #region 注册弹出窗体
            Messenger.Default.Register<ShowContentWindowMessage>(this, message =>
            {
                switch (message.ContentName)
                {
                    case "EmergencyRegisterControl":
                        message.Content = typeof(EmergencyRegisterControl);
                        break;
                    case "DateRegister":
                        message.Content = typeof(DateRegister);
                        break;
                    case "InHospitalRegister":
                        message.Content = typeof(InHospitalRegister);
                        break;
                    case "MonitorBind":
                        message.Content = typeof(MonitorBind);
                        break;
                    case "OutRegister":
                        message.Content = typeof(OutRegister);
                        break;
                    case "OperationInformationTopControl":
                        message.Content = typeof(OperationInformationTopControl);
                        break;
                    case "OperationMedNoteControl":
                        message.Content = typeof(OperationMedNoteControl);
                        break;
                    //case "OperationOutputNoteControl":
                    //    message.Content = typeof(OperationOutputNoteControl);
                    //    break;暂时无此方法
                    case "OperationInformationControl":
                        message.Content = typeof(OperationInformationControl);
                        break;
                    case "ChangeOperRoomNo":
                        message.Content = typeof(ChangeOperRoomNo);
                        break;
                    case "AssayReport":
                        message.Content = typeof(AssayReport);
                        break;
                    case "BloodGasAnalysisControl":
                        message.Content = typeof(MedicalSystem.AnesWorkStation.View.InOperation.BloodGasAnalysisControl);
                        break;
                    case "OperationShift":
                        message.Content = typeof(OperationShift);
                        break;
                    case "AfterOperationInformationControl":
                        message.Content = typeof(AfterOperationInformationControl);
                        break;
                    case "OperationEventNoteControl":
                        message.Content = typeof(OperationEventNoteControl);
                        break;
                    case "BottomMenu":
                        message.Content = typeof(BottomMenu);
                        break;
                    case "LoadReport":
                        message.Content = typeof(LoadReport);
                        break;
                    case "SignEntryControl":
                        message.Content = typeof(SignEntryControl);
                        break;
                    case "SignSwicthControl":
                        message.Content = typeof(SignSwicthControl);
                        break;
                    case "IndividuationVitalSignControl":
                        message.Content = typeof(IndividuationVitalSignControl);
                        break;
                    case "IntensiveSignControl":
                        message.Content = typeof(IntensiveSignControl);
                        break;
                    case "SignMakeupControl":
                        message.Content = typeof(SignMakeupControl);
                        break;
                    case "AddSignsControl":
                        message.Content = typeof(AddSignsControl);
                        break;
                    case "AnesthesiaPathControl":
                        message.Content = typeof(AnesthesiaPathControl);
                        break;
                    case "QualityControlRegistration":
                        message.Content = typeof(QualityControlRegistration);
                        break;
                    case "AnesthesiaRouteControl":
                        message.Content = typeof(AnesthesiaRouteControl);
                        break;
                    case "PACUQuery":
                        message.Content = typeof(PACUQuery);
                        break;
                    case "AddBloodGasMaster":
                        message.Content = typeof(AddBloodGasMaster);
                        break;
                    case "OperationJump":
                        message.Content = typeof(OperationJump);
                        break;
                    case "OperationCanceled":
                        message.Content = typeof(OperationCanceled);
                        break;
                    case "OperationScreen":
                        message.Content = typeof(OperationScreen);
                        break;
                    case "PatConfirmControl":
                        message.Content = typeof(PatConfirmControl);
                        break;
                    case "OperationRescue":
                        message.Content = typeof(OperationRescue);
                        break;
                    case "OperationShiftChange":
                        message.Content = typeof(OperationShiftChange);
                        break;
                    case "AnesFree":
                        message.Content = typeof(AnesFree);
                        break;
                    case "ChargeTempletControl":
                        message.Content = typeof(ChargeTempletControl);
                        break;
                    case "ChargeTemplateMethodControl":
                        message.Content = typeof(ChargeTemplateMethodControl);
                        break;
                    case "ChargeSubmitControl":
                        message.Content = typeof(ChargeSubmitControl);
                        break;
                    case "UnPostPDFControl":
                        message.Content = typeof(UnPostPDFControl);
                        break;
                    case "OperationInterfaceControl":
                        message.Content = typeof(OperationInterfaceControl);
                        break;
                    case "CameraControl":
                        message.Content = typeof(CameraControl);
                        break;
                    case "Balthazar":
                        message.Content = typeof(MedicalSystem.AnesWorkStation.View.AnesScore.Balthazar);
                        break;
                    case "About":
                        message.Content = typeof(About);
                        break;
                    case "PacsInterface":
                        message.Content = typeof(PacsInterface);
                        break;
                    default:
                        break;
                }

                GC.Collect();
                var action = new ShowContentWindowAction(message);
                action.CallInvoke();
                GC.Collect();
            });
            #endregion

            #region 注册消息提示窗
            Messenger.Default.Register<ShowMessageBoxMessage>(this, message =>
            {
                if (message.IsAsyncShow)
                {
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        var result = ConfirmMessageBox.Show(message.Text, message.SubMessage, message.Button, message.Icon, message.IsAutoClose, message.AutoCloseTime);
                        if (message.CallBack != null)
                        {
                            message.CallBack(result);
                        }
                    }));
                }
                else
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        var result = ConfirmMessageBox.Show(message.Text, message.SubMessage, message.Button, message.Icon, message.IsAutoClose, message.AutoCloseTime);
                        if (message.CallBack != null)
                        {
                            message.CallBack(result);
                        }
                    }));
                }
            });
            #endregion

            #region 加载键盘驱动
            KeyBoardStateCache.KeyBoard = new KeyBoardEvent();
            KeyBoardStateCache.KeyBoard.KeyStandardEvent += keyBoard_KeyStandardEvent;
            KeyBoardStateCache.KeyBoard.KeyFunctionEvent += keyBoard_KeyFunctionEvent;
            KeyBoardStateCache.KeyBoard.LoadKeyBoard();
            KeyBoardStateCache.IsEN = true;
            #endregion

            #region 自动更新

            Updater.Lib.Update.FileUpdater();

            #endregion
        }

        #region 键盘功能

        /// <summary>
        /// 键盘标准按键响应
        /// </summary>
        void keyBoard_KeyStandardEvent(uint keycode, uint fnkeys)
        {
            //模拟键盘输入
            if (fnkeys == 1)
            {
                switch (keycode)
                {
                    case 48://0
                        keycode = 188;//,
                        System_API.keybd_event((Keys)keycode, 0, 0, 0);
                        System_API.keybd_event((Keys)keycode, 0, 2, 0);
                        break;
                    case 49://1
                        keycode = 189;//-
                        System_API.keybd_event((Keys)keycode, 0, 0, 0);
                        System_API.keybd_event((Keys)keycode, 0, 2, 0);
                        break;
                    case 50://2
                        keycode = 186;//:
                        System_API.keybd_event(Keys.ShiftKey, 0, 0, 0);
                        System_API.keybd_event((Keys)keycode, 0, 0, 0);
                        System_API.keybd_event((Keys)keycode, 0, 2, 0);
                        System_API.keybd_event(Keys.ShiftKey, 0, 2, 0);
                        break;
                    case 51://3
                        keycode = 187;//=
                        System_API.keybd_event((Keys)keycode, 0, 0, 0);
                        System_API.keybd_event((Keys)keycode, 0, 2, 0);
                        break;
                    case 52://4
                        keycode = 57;//(
                        System_API.keybd_event(Keys.ShiftKey, 0, 0, 0);
                        System_API.keybd_event((Keys)keycode, 0, 0, 0);
                        System_API.keybd_event((Keys)keycode, 0, 2, 0);
                        System_API.keybd_event(Keys.ShiftKey, 0, 2, 0);
                        break;
                    case 53://5
                        keycode = 111;//、
                        System_API.keybd_event((Keys)keycode, 0, 0, 0);
                        System_API.keybd_event((Keys)keycode, 0, 2, 0);
                        break;
                    case 54://6
                        keycode = 48;//)
                        System_API.keybd_event(Keys.ShiftKey, 0, 0, 0);
                        System_API.keybd_event((Keys)keycode, 0, 0, 0);
                        System_API.keybd_event((Keys)keycode, 0, 2, 0);
                        System_API.keybd_event(Keys.ShiftKey, 0, 2, 0);
                        break;
                    case 55://7
                        keycode = 53;//%
                        System_API.keybd_event(Keys.ShiftKey, 0, 0, 0);
                        System_API.keybd_event((Keys)keycode, 0, 0, 0);
                        System_API.keybd_event((Keys)keycode, 0, 2, 0);
                        System_API.keybd_event(Keys.ShiftKey, 0, 2, 0);
                        break;
                    case 56://8
                        keycode = 186;//;
                        System_API.keybd_event((Keys)keycode, 0, 0, 0);
                        System_API.keybd_event((Keys)keycode, 0, 2, 0);
                        break;
                    case 57://9
                        keycode = 56;//*
                        System_API.keybd_event(Keys.ShiftKey, 0, 0, 0);
                        System_API.keybd_event((Keys)keycode, 0, 0, 0);
                        System_API.keybd_event((Keys)keycode, 0, 2, 0);
                        System_API.keybd_event(Keys.ShiftKey, 0, 2, 0);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                if (keycode == 188)
                {
                    keycode = 187;
                    System_API.keybd_event(Keys.ShiftKey, 0, 0, 0);
                    System_API.keybd_event((Keys)keycode, 0, 0, 0);
                    System_API.keybd_event((Keys)keycode, 0, 2, 0);
                    System_API.keybd_event(Keys.ShiftKey, 0, 2, 0);
                }
                else
                {
                    Keys key = (Keys)keycode;
                    System_API.keybd_event(key, 0, 0, 0);
                    System_API.keybd_event(key, 0, 0x02, 0);
                }
            }
        }

        /// <summary>
        /// 键盘功能按键响应
        /// </summary>
        void keyBoard_KeyFunctionEvent(string keycode)
        {
            switch (keycode)
            {
                case AppCode.TAB:
                    //定位按钮切换Tab按键
                    System_API.keybd_event(Keys.Tab, 0, 0, 0);
                    System_API.keybd_event(Keys.Tab, 0, 0x02, 0);
                    break;
                case AppCode.ENTER:
                    //定位按钮切换Tab按键
                    System_API.keybd_event(Keys.Enter, 0, 0, 0);
                    System_API.keybd_event(Keys.Enter, 0, 0x02, 0);
                    break;
                case AppCode.Upper:
                    KeyBoardStateCache.CapsLock = !KeyBoardStateCache.CapsLock;
                    KeyBoardStateCache.KeyBoard.SetMainKeyboardLedStatus(0, KeyBoardStateCache.CapsLock);
                    System_API.keybd_event(Keys.CapsLock, 0, 0, 0);
                    System_API.keybd_event(Keys.CapsLock, 0, 0x02, 0);
                    break;

                case AppCode.Language:
                    if (!KeyBoardStateCache.IsEN)//中文
                    {
                        KeyBoardStateCache.IsEN = true;//英文
                        KeyBoardStateCache.KeyBoard.SetMainKeyboardLedStatus(1, false);
                        KeyBoardStateCache.KeyBoard.SetMainKeyboardLedStatus(2, true);
                    }
                    else
                    {
                        //切换中文  英文LED关闭，大写LED关闭 ,中文LED开启
                        KeyBoardStateCache.IsEN = false;//中文                        
                        KeyBoardStateCache.KeyBoard.SetMainKeyboardLedStatus(2, false);
                        KeyBoardStateCache.KeyBoard.SetMainKeyboardLedStatus(1, true);
                    }
                    //切换中英文，大写灯自动关闭
                    KeyBoardStateCache.KeyBoard.SetMainKeyboardLedStatus(0, false);
                    KeyBoardStateCache.CapsLock = false;
                    //模拟键盘Shift切换中英文输入法
                    System_API.keybd_event(Keys.ShiftKey, 0, 0, 0);
                    System_API.keybd_event(Keys.ShiftKey, 0, 0x02, 0);
                    break;

                case AppCode.Symbol:
                    //符号键模拟 Control+Shift+Z 调取搜狗输入法符号页面
                    System_API.keybd_event(Keys.ControlKey, 0, 0, 0);
                    System_API.keybd_event(Keys.ShiftKey, 0, 0, 0);
                    System_API.keybd_event(Keys.Z, 0, 0, 0);
                    System_API.keybd_event(Keys.ControlKey, 0, 0x02, 0);
                    System_API.keybd_event(Keys.ShiftKey, 0, 0x02, 0);
                    System_API.keybd_event(Keys.Z, 0, 0x02, 0);
                    break;

                case AppCode.Coordination:
                    this.ControlXiaoMai();
                    break;

                default:
                    Dispatcher.BeginInvoke((Action)delegate
                    {
                        Messenger.Default.Send<AppCodeMessage>(new AppCodeMessage() { AppCode = keycode });
                    }, System.Windows.Threading.DispatcherPriority.Send);
                    break;
            }
        }

        /// <summary>
        /// 操作小麦助手，显示还是隐藏
        /// </summary>
        private void ControlXiaoMai()
        {
            Process[] pros = Process.GetProcessesByName("MedicalSystem.AnesWorkStationCoordination.View");
            if (pros.Length == 0)
            {
                this.StartAnesWorkStationCoordination();
            }
            else if (pros.Length == 1)
            {
                IntPtr hWnd = pros[0].MainWindowHandle;
                if (hWnd != IntPtr.Zero)
                {
                    // 判断小麦助手当前是不是最小化
                    if (IsIconic(hWnd))
                    {
                        // 普通显示
                        ShowWindow(hWnd, 1);
                    }
                    else
                    {
                        // 最小化
                        ShowWindow(hWnd, 2);
                    }
                }
            }

            Messenger.Default.Send<WindowState>(WindowState.Normal, EnumMessageKey.CoordinationSizeChange);
        }

        /// <summary>
        /// 注册消息
        /// </summary>
        private void RegisterMessage()
        {
            Messenger.Default.Register<object>(this, EnumMessageKey.ResponseVideoComm, msg =>
            {
                this.ResponseVideoComm();
            });
        }

        /// <summary>
        /// 响应视频请求通讯
        /// </summary>
        private void ResponseVideoComm()
        {
            Process[] pros = Process.GetProcessesByName("MedicalSystem.AnesWorkStationCoordination.View");
            if (pros.Length == 0)
            {
                this.StartAnesWorkStationCoordination();
            }
            else if (pros.Length == 1)
            {
                IntPtr hWnd = pros[0].MainWindowHandle;
                // 强制弹出小麦助手
                if (hWnd != IntPtr.Zero && IsIconic(hWnd))
                {
                    ShowWindow(hWnd, 1);
                }
            }

            Messenger.Default.Send<WindowState>(WindowState.Normal, EnumMessageKey.CoordinationSizeChange);
        }

        /// <summary>
        /// 启动小麦助手
        /// </summary>
        private void StartAnesWorkStationCoordination()
        {
            // 在bin目录的AnesWorkStationCoordination文件夹下面放置“小麦助手”
            string add = System.Environment.CurrentDirectory + "\\AnesWorkStationCoordination\\MedicalSystem.AnesWorkStationCoordination.View.exe";
            if (System.IO.File.Exists(add))
            {
                string args = JsonConvert.SerializeObject(TransMessageManager.Instance.ChildLoginModel);
                args = args.Replace("\"", "\"\"\"");
                Process.Start(add, args);
            }
            else
            {
                ConfirmMessageBox.Show("", "小麦助手文件未找到！", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        #endregion

        /// <summary>
        /// 激活原先窗口
        /// </summary>
        private void ActivateWindow()
        {
            var login = FindWindow(null, "Login");
            var mainWindow = FindWindow(null, "MainWindow");
            var inOperationWindow = FindWindow(null, "InOperationWindow");
            if (inOperationWindow != IntPtr.Zero)
            {
                SwitchToThisWindow(inOperationWindow, true);
            }
            else if (mainWindow != IntPtr.Zero)
            {
                SwitchToThisWindow(mainWindow, true);
            }
            else if (login != IntPtr.Zero)
            {
                SwitchToThisWindow(login, true);
            }
        }

        private void KillWindow()
        {
            Process[] pros = Process.GetProcessesByName("MedicalSystem.AnesWorkStation.View");
            foreach(Process item in pros)
            {
                if(!string.IsNullOrEmpty(item.MainWindowTitle))
                {
                    item.Kill();
                }
            }
        }

        /// <summary>
        /// UI线程抛出全局异常处理
        /// </summary>
        void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            try
            {
                Logger.Error("UI线程全局异常", e.Exception);
                e.Handled = true;
            }
            catch (Exception ex)
            {
                Logger.Error("不可恢复的UI线程全局异常", ex);
                ConfirmMessageBox.Show("应用程序发生不可恢复的异常，即将退出！", "系统提示", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// 非UI线程抛出全局异常处理
        /// </summary>
        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                var exception = e.ExceptionObject as Exception;
                if (exception != null)
                {
                    Logger.Error("非UI线程全局异常", exception);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("不可恢复的非UI线程全局异常", ex);
                ConfirmMessageBox.Show("应用程序发生不可恢复的异常，即将退出！", "系统提示", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
