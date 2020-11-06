using MedicalSystem.Services;
using MedicalSystem.AnesWorkStation.Model.AnesGraphModel;
using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.AnesWorkStation.Model;
using System.Windows.Threading;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.Wpf.Controls;

namespace MedicalSystem.AnesWorkStation.View.AnesGraph
{
    /// <summary>
    /// InOperationWindow.xaml 的交互逻辑
    /// </summary>
    public partial class InOperationWindow : WindowBase
    {
        private DispatcherTimer timer = new DispatcherTimer();
        private bool isMouseDown = false;
        private double mousedownX;
        private double mousedownY;
        private Point mouseDownPoint;
        private int SystemRunClockTick = 0;
        InOperationViewModel inOperationViewModel;
        DrugGraphViewModel drugGraphViewModel;
        VitalSignYAxisViewModel vitalSignYAxisViewModel;

        /// <summary>
        /// 无参构造
        /// </summary>
        public InOperationWindow()
        {
            InitializeComponent();

            inOperationViewModel = new InOperationViewModel();
            drugGraphViewModel = new DrugGraphViewModel();
            vitalSignYAxisViewModel = new VitalSignYAxisViewModel();
            inOperationViewModel.IsResueShow = Visibility.Collapsed;
            //注册消息
            RegisterKeyBoardMessage();
            // 绑定关闭事件
            this.Closing += this.InOperationWindow_Closing;
            this.DataContext = inOperationViewModel;
            graph1.DataContext = drugGraphViewModel;
            VitalSignsControl1.DataContext = vitalSignYAxisViewModel;
            dateAxis1.DataContext = vitalSignYAxisViewModel;

            graph1.MoveXAxisAction = (sender, xMove) =>
            {
                dateAxis1.MoveXAxis(xMove);
                VitalSignsControl1.MoveXAxis(xMove);
            };
            VitalSignsControl1.MoveXAxisAction = (sender, xMove) =>
            {
                dateAxis1.MoveXAxis(xMove);
                graph1.MoveXAxis(xMove);
            };
            dateAxis1.DrawTimeProcessAction = (time) =>
            {
                graph1.DrawTimeProcess(time);
                VitalSignsControl1.DrawTimeProcess(time);
            };

            //this.Unloaded += (sender, e) => Messenger.Default.Unregister(this);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = TimeSpan.FromSeconds(30);
            timer.Start();
        }

        /// <summary>
        /// 退出程序用户下线，正常做到切换账号的时候触发
        /// </summary>
        private void InOperationWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!ExtendAppContext.Current.IsNormalClosing)
            {
                ConfirmMessageBox.Show("系统提示", "非正常关闭操作，请使用右上角的关闭流程！",
                                        MessageBoxButton.OK, MessageBoxImage.Warning);
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 定时刷新
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {
            SystemRunClockTick++;
            if (SystemRunClockTick % 4 == 0 && ExtendAppContext.Current.IsRefVitalSigns)
            {
                Messenger.Default.Send<object>(this, EnumMessageKey.RefreshAnesEventWindow);
                Messenger.Default.Send<object>(this, EnumMessageKey.RefreshSignVitalWindow);
            }
            Messenger.Default.Send<object>(this, EnumMessageKey.IsOperationRescuing);
        }

        /// <summary>
        /// 注册键盘事件
        /// </summary>
        public void RegisterKeyBoardMessage()
        {
            inOperationViewModel.RegisterPublicKeyBoard = false;
            inOperationViewModel.RegisterKeyBoardMessage();

            drugGraphViewModel.RegisterPublicKeyBoard = false;
            drugGraphViewModel.RegisterKeyBoardMessage();

            vitalSignYAxisViewModel.RegisterPublicKeyBoard = false;
            vitalSignYAxisViewModel.RegisterKeyBoardMessage();

            topInfo.ViewModel.RegisterPublicKeyBoard = false;
            topInfo.ViewModel.RegisterKeyBoardMessage();

            drugGraphViewModel.LoadData();
            vitalSignYAxisViewModel.LoadData();
            Messenger.Default.Send<object>(this, EnumMessageKey.RefreshInOperationInformation);

            RegisterMessage();
        }

        /// <summary>
        /// 卸载键盘事件
        /// </summary>
        public void UnRegisterKeyBoardMessage()
        {
            //注销消息
            inOperationViewModel.UnRegisterKeyBoardMessage();
            drugGraphViewModel.UnRegisterKeyBoardMessage();
            vitalSignYAxisViewModel.UnRegisterKeyBoardMessage();
            topInfo.ViewModel.UnRegisterKeyBoardMessage();

            Messenger.Default.Unregister<object>(this, EnumMessageKey.RefreshInOperationWindow);
            Messenger.Default.Unregister<object>(this, EnumMessageKey.CloseInOperationWindow);
        }

        /// <summary>
        /// 注册消息：用于不同的ViewModel之间进行通信
        /// </summary>
        private void RegisterMessage()
        {
            // 刷新整个界面
            Messenger.Default.Register<object>(this, EnumMessageKey.RefreshInOperationWindow, msg =>
            {
                timer.Stop();
                timer.Start();

                if (!string.IsNullOrEmpty(ExtendAppContext.Current.LoginName))
                {
                    this.LoginName = ExtendAppContext.Current.LoginUser.USER_NAME;
                }
                else
                {
                    this.LoginName = string.Empty;
                }

                Messenger.Default.Send<object>(this, EnumMessageKey.RefreshAnesEventWindow);
                Messenger.Default.Send<object>(this, EnumMessageKey.RefreshSignVitalWindow);
            });
            Messenger.Default.Register<object>(this, EnumMessageKey.HideMainWindow, mes =>
            {
                timer.Start();
            });
            Messenger.Default.Register<object>(this, EnumMessageKey.ShowMainWindow, mes =>
            {
                timer.Stop();
            });
            // 关闭术中界面
            Messenger.Default.Register<object>(this, EnumMessageKey.CloseInOperationWindow, msg =>
            {
                CloseInOperationWindow();
            });
        }

        /// <summary>
        /// 关闭术中窗口刷新主界面
        /// </summary>
        private void CloseInOperationWindow()
        {
            Messenger.Default.Send<object>(this, EnumMessageKey.ShowMainWindow);

            if (ExtendAppContext.Current.PatientInformationExtend != null &&
                ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE >= (int)OperationStatus.InOperationRoom &&
                   ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE < (int)OperationStatus.OutOperationRoom)
            {
                //当前术中
                Messenger.Default.Send<object>(this, EnumMessageKey.RefreshMainWindow);
            }

            Messenger.Default.Unregister<dynamic>(this);
            ExtendAppContext.Current.CurntOpenForm = new OpenForm(typeof(MainWindow).Name, null);
            UnRegisterKeyBoardMessage();
            this.Hide();
        }

        private void Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isMouseDown = true;
            (sender as Image).CaptureMouse();
            mouseDownPoint = e.GetPosition(this);
            mousedownX = mouseDownPoint.X;
            mousedownY = mouseDownPoint.Y;
        }

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point movePoint = e.GetPosition(this);
                double deltx = movePoint.X - mouseDownPoint.X;
                double delty = movePoint.Y - mouseDownPoint.Y;

                _trans.X += deltx;
                _trans.Y += delty;
                mouseDownPoint = movePoint;
            }
        }

        private void Button_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isMouseDown = false;
            Point uppoint = e.GetPosition(this);
            (sender as Image).ReleaseMouseCapture();
            if (Math.Abs(uppoint.X - mousedownX) < 3 && Math.Abs(uppoint.Y - mousedownY) < 3)
            {
                if (_btnSet.Command != null)
                {
                    _btnSet.Command.Execute("");
                }
            }
        }

        private void IMG_Rescue_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            inOperationViewModel.IsPopupShow = true;
            inOperationViewModel.IsResueShow = Visibility.Collapsed;
            e.Handled = true;
        }
        private void ImgRescueTitle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            inOperationViewModel.IsPopupShow = false;
            inOperationViewModel.IsResueShow = Visibility.Visible;
            e.Handled = true;
        }
    }
}
