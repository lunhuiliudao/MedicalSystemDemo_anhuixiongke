//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      WindowBase.cs
//功能描述(Description)：    窗口基类，提供统一消息注册等
//数据表(Tables)：		    无
//作者(Author)：             MDSD
//日期(Create Date)：        2017/12/26 14:58
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Threading;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.ViewModel.Cache;
using MedicalSystem.AnesWorkStation.Wpf.Controls;
using MedicalSystem.AnesWorkStation.Wpf.Message;
using System.Diagnostics;

namespace MedicalSystem.AnesWorkStation.View
{
    public class WindowBase : Window
    {
        public static readonly DependencyProperty ScaleValueProperty = DependencyProperty.Register("ScaleValue", typeof(double), typeof(WindowBase), new UIPropertyMetadata(1.0, new PropertyChangedCallback(OnScaleValueChanged), new CoerceValueCallback(OnCoerceScaleValue)));

        public static readonly DependencyProperty CurTimeProperty = DependencyProperty.Register("CurTime", typeof(string), typeof(WindowBase), new PropertyMetadata("11:20am", new PropertyChangedCallback(OnCurTimeValueChanged), new CoerceValueCallback(OnCoerceCurTime)));

        public static readonly DependencyProperty LoginNameProperty = DependencyProperty.Register("LoginName", typeof(string), typeof(WindowBase), new PropertyMetadata("Doct.沈"));

        public static readonly DependencyProperty SystemTitleVisibilityProperty = DependencyProperty.Register("SystemTitleVisibility", typeof(Visibility), typeof(WindowBase), new PropertyMetadata(Visibility.Visible));

        public static readonly DependencyProperty CallIconVisibilityProperty = DependencyProperty.Register("CallIconVisibility", typeof(Visibility), typeof(WindowBase), new PropertyMetadata(Visibility.Collapsed, new PropertyChangedCallback(OnCallIconVisibilityChanged)));

        public static readonly DependencyProperty LoginIconVisibilityProperty = DependencyProperty.Register("LoginIconVisibility", typeof(Visibility), typeof(WindowBase), new PropertyMetadata(Visibility.Visible));

        private System.Windows.Controls.Button btnLoginChange = null;      // 切换登录者按钮
        private System.Windows.Controls.ListBox lbChangeType = null;       // 切换用户还是锁屏还是关机
        private Popup popupChange = null;                                  // 弹出框
        private DispatcherTimer timer = new DispatcherTimer();             // 标题栏实时显示当前时间的定时器
        private double _DesignActualWidth;                                 // 设计可视宽度
        private double _DesignActualHeight;                                // 设计可视高度
        /// <summary>
        /// 窗口的宽高缩放比例
        /// </summary>
        public double ScaleValue
        {
            get { return (double)GetValue(ScaleValueProperty); }
            set { SetValue(ScaleValueProperty, value); }
        }

        /// <summary>
        /// 当前时间
        /// </summary>
        public string CurTime
        {
            get { return (string)GetValue(CurTimeProperty); }
            set { SetValue(CurTimeProperty, value); }
        }

        /// <summary>
        /// 登录用户
        /// </summary>
        public string LoginName
        {
            get { return (string)GetValue(LoginNameProperty); }
            set { SetValue(LoginNameProperty, value); }
        }

        /// <summary>
        /// 窗体标题是否显示
        /// </summary>
        public Visibility SystemTitleVisibility
        {
            get { return (Visibility)GetValue(SystemTitleVisibilityProperty); }
            set { SetValue(SystemTitleVisibilityProperty, value); }
        }

        /// <summary>
        /// 协同图标
        /// </summary>
        public Visibility CallIconVisibility
        {
            get { return (Visibility)GetValue(CallIconVisibilityProperty); }
            set { SetValue(CallIconVisibilityProperty, value); }
        }

        /// <summary>
        ///  登录图标
        /// </summary>
        public Visibility LoginIconVisibility
        {
            get { return (Visibility)GetValue(LoginIconVisibilityProperty); }
            set { SetValue(LoginIconVisibilityProperty, value); }
        }

        /// <summary>
        /// 设计可视宽度（参考实际设计分辨率，默认分辨率1920*1080）1936
        /// </summary>
        protected double DesignActualWidth
        {
            get { return _DesignActualWidth; }
            set { _DesignActualWidth = value; }
        }

        /// <summary>
        /// 设计可视高度（参考实际设计分辨率，默认分辨率1920*1080）1056
        /// </summary>
        protected double DesignActualHeight
        {
            get { return _DesignActualHeight; }
            set { _DesignActualHeight = value; }
        }

        /// <summary>
        /// 无参构造
        /// </summary>
        public WindowBase()
        {
            ResourceDictionary style = new ResourceDictionary();
            style.Source = new Uri("./Themes/WindowBase.xaml", UriKind.Relative);
            this.Style = (System.Windows.Style)style["BaseWindowStyle"];

            _DesignActualWidth = SystemParameters.PrimaryScreenWidth;
            _DesignActualHeight = SystemParameters.PrimaryScreenHeight;
            this.SizeChanged += WindowBase_SizeChanged;

            this.timer.Tick += this.Timer_Tick;
            this.timer.Interval = TimeSpan.FromSeconds(1.0);
            this.timer.Start();

            if (!string.IsNullOrEmpty(ExtendAppContext.Current.LoginUser.USER_NAME))
            {
                this.LoginName = ExtendAppContext.Current.LoginUser.USER_NAME;
            }
            else
            {
                this.LoginName = string.Empty;
            }
        }

        /// <summary>
        /// 锁屏还是切换用户还是关机
        /// </summary>
        private void LbChangeType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (this.lbChangeType.SelectedIndex)
            {
                case 0:
                    //锁屏
                    ExtendAppContext.Current.CurEnumLoginType = Anes.FrameWork.Enum.EnumLoginType.LockScreen;
                    break;
                case 1:
                    ExtendAppContext.Current.CurEnumLoginType = Anes.FrameWork.Enum.EnumLoginType.Logout;
                    //注销
                    break;
                case 2:
                    ExtendAppContext.Current.CurEnumLoginType = Anes.FrameWork.Enum.EnumLoginType.ShutDown;
                    //关机
                    break;
                case 3:
                    // 关于界面
                    var message = new ShowContentWindowMessage("About", "关于");
                    message.Height = 230;
                    message.Width = 500;
                    Messenger.Default.Send<ShowContentWindowMessage>(message);
                    this.lbChangeType.SelectedIndex = -1;
                    return;
                case 4:
                    this.WindowState = WindowState.Minimized;
                    this.lbChangeType.SelectedIndex = -1;
                    return;
                default:
                    return;
            }

            this.popupChange.IsOpen = false;

            if (ExtendAppContext.Current.CurEnumLoginType == Anes.FrameWork.Enum.EnumLoginType.ShutDown)
            {
                MessageBoxResult dr = ConfirmMessageBox.Show("", "确定要关闭麻醉信息工作站？", MessageBoxButton.YesNo, MessageBoxImage.Question, false, 2000);
                if (dr == MessageBoxResult.Yes || dr == MessageBoxResult.OK)
                {
                    Process[] pros = Process.GetProcessesByName("MedicalSystem.AnesWorkStationCoordination.View");
                    if (pros.Length == 1)
                    {
                        pros[0].Kill();
                    }

                    ExtendAppContext.Current.IsNormalClosing = true;
                    System.Windows.Application.Current.Shutdown();
                }
            }
            else
            {
                //关闭手术进程状态LED，隐藏主页面
                Messenger.Default.Send<object>(this, EnumMessageKey.HideMainWindow);
                Messenger.Default.Send<object>(this, EnumMessageKey.CloseInOperationWindow);

                KeyBoardStateCache.KeyBoard.CloseSecondKeyBoardAllLed();

                // 异步弹出登录框
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    Login login = new Login();
                    login.Topmost = true;
                    login.Show();
                }));
            }

            this.lbChangeType.SelectedIndex = -1;
        }

        /// <summary>
        /// 锁屏按钮
        /// </summary>
        private void BtnLoginChange_Click(object sender, RoutedEventArgs e)
        {
            this.popupChange.IsOpen = true;
        }

        /// <summary>
        /// 界面时钟
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime dtNow = DateTime.Now;
            this.CurTime = string.Format("{0}{1}", dtNow.ToString("hh:mm"), (dtNow.Hour < 12 ? "am" : "pm"));
            GC.Collect();
        }

        /// <summary>
        /// 窗口大小更改事件
        /// </summary>
        private void WindowBase_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.ActualWidth != 0 && this.ActualHeight != 0)
            {
                CalculateScale();
                ((FrameworkElement)this.Content).LayoutTransform = new ScaleTransform(ScaleValue, ScaleValue);
            }
        }

        /// <summary>
        /// 计算缩放比例
        /// </summary>
        private void CalculateScale()
        {
            double yScale = ActualHeight / _DesignActualHeight;
            double xScale = ActualWidth / _DesignActualWidth;
            double value = Math.Min(xScale, yScale);
            ScaleValue = (double)OnCoerceScaleValue(this, value);
        }

        #region ScaleValue Depdency Property

        /// <summary>
        /// 更改缩放比例时触发的回调方法
        /// </summary>
        private static object OnCoerceScaleValue(DependencyObject o, object value)
        {
            WindowBase mainWindow = o as WindowBase;
            if (mainWindow != null)
            {
                return mainWindow.OnCoerceScaleValue((double)value);
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// 更改缩放比例时触发的回调方法
        /// </summary>
        private static void OnScaleValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            WindowBase mainWindow = o as WindowBase;
            if (mainWindow != null)
                mainWindow.OnScaleValueChanged((double)e.OldValue, (double)e.NewValue);
        }

        private static void OnCurTimeValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
        }

        protected static object OnCoerceCurTime(DependencyObject o, object value)
        {
            return value;
        }

        protected virtual double OnCoerceScaleValue(double value)
        {
            if (double.IsNaN(value))
            {
                return 1.0f;
            }

            value = Math.Max(0.1, value);
            return value;
        }

        protected virtual void OnScaleValueChanged(double oldValue, double newValue)
        {
        }

        private static void OnCallIconVisibilityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((Visibility)e.NewValue == Visibility.Visible)
            {
                (d as WindowBase).SetLoginIconVisibility(Visibility.Collapsed);
            }
            else
            {
                (d as WindowBase).SetLoginIconVisibility(Visibility.Visible);
            }
        }

        /// <summary>
        /// 设置登录图标显示OR隐藏
        /// </summary>
        private void SetLoginIconVisibility(Visibility visible)
        {
            LoginIconVisibility = visible;
        }

        #endregion

        /// <summary>
        /// 重写 应用模板方法
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.GetTemplateChild("btnLoginChange");
            this.lbChangeType = this.GetTemplateChild("lbChangeType") as System.Windows.Controls.ListBox;
            this.btnLoginChange = this.GetTemplateChild("btnLoginChange") as System.Windows.Controls.Button;
            this.lbChangeType.SelectionChanged += this.LbChangeType_SelectionChanged;
            this.btnLoginChange.Click += this.BtnLoginChange_Click;
            this.popupChange = this.GetTemplateChild("popupChange") as Popup;
        }
    }
}
