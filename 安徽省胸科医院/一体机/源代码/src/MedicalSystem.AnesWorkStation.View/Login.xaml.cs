// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      Login.xaml.cs
// 功能描述(Description)：    登录界面
// 数据表(Tables)：		      无
// 作者(Author)：             袁乐、孙家富
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.ViewModel;
using MedicalSystem.AnesWorkStation.Wpf.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MedicalSystem.AnesWorkStation.View
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        private LoginViewModel loginViewModel = null;           // 界面对应的ViewModel

        /// <summary>
        /// 无参构造
        /// </summary>
        public Login()
        {
            InitializeComponent();
            this.RegisterMessage();
            this.loginViewModel = new LoginViewModel();
            this.DataContext = this.loginViewModel;
            // 设置默认焦点
            if (string.IsNullOrWhiteSpace(this.loginViewModel.StrLoginName))
            {
                this.TextUserName.Focus();
            }
            else
            {
                this.TextPassword.Focus();
            }

            // 窗口关闭事件
            this.Closing += Login_Closing;

            this.SetTextEnable();
        }

        /// <summary>
        /// 窗口关闭事件
        /// </summary>
        private void Login_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ExtendAppContext.Current.CurEnumLoginType == Anes.FrameWork.Enum.EnumLoginType.Logined ||
                ExtendAppContext.Current.CurEnumLoginType == Anes.FrameWork.Enum.EnumLoginType.NormalLogin)
            {
                Messenger.Default.Unregister<object>(this, EnumMessageKey.CloseLogin);
                Messenger.Default.Unregister<object>(this, EnumMessageKey.ExitLogin);
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 根据登录类型不同设置文本框的显示
        /// </summary>
        private void SetTextEnable()
        {
            // 锁屏状态下，登录名使用当前登录名，不可编辑
            if (ExtendAppContext.Current.CurEnumLoginType == Anes.FrameWork.Enum.EnumLoginType.LockScreen)
            {
                this.TextUserName.IsReadOnly = true;
                this.TextUserName.Text = ExtendAppContext.Current.LoginUser.USER_NAME;
            }
            else if (ExtendAppContext.Current.CurEnumLoginType == Anes.FrameWork.Enum.EnumLoginType.Logout)
            {
                this.TextUserName.IsReadOnly = false;
                this.TextUserName.Text = string.Empty;
            }
        }

        /// <summary>
        /// 接收关闭登录界面消息
        /// </summary>
        private void RegisterMessage()
        {
            // 登录成功后显示主界面
            Messenger.Default.Register<object>(this, EnumMessageKey.CloseLogin, msg =>
            {
                if (Dispatcher.Thread != System.Threading.Thread.CurrentThread)
                {
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        this.ShowMainWindow();
                    }));
                }
                else
                {
                    this.ShowMainWindow();
                }
            });

            // 关闭窗口，因为指令是从ViewModel中传来的
            Messenger.Default.Register<object>(this, EnumMessageKey.ExitLogin, msg =>
            {
                this.Close();
            });
        }

        /// <summary>
        /// 显示主界面
        /// </summary>
        private void ShowMainWindow()
        {
            bool hasNoPostPDF = false;
            if (ExtendAppContext.Current.CurEnumLoginType == Anes.FrameWork.Enum.EnumLoginType.NormalLogin)
            {
                ExtendAppContext.Current.CurntOpenForm = new OpenForm(typeof(MainWindow).Name, null);
                MainWindow main = new MainWindow();
                main.Show();
                main.ShowActivated = true;
                Application.Current.MainWindow = main;
                hasNoPostPDF = this.GetNoPostPDF();
            }
            else
            {
                Messenger.Default.Send<object>(this, EnumMessageKey.RefreshMainWindow);
                Messenger.Default.Send<object>(this, EnumMessageKey.ShowMainWindow);
            }

            ExtendAppContext.Current.CurEnumLoginType = Anes.FrameWork.Enum.EnumLoginType.Logined;
            this.Close();

            //if (hasNoPostPDF)
            //{
            //    ShowContentWindowMessage messagePopup = new ShowContentWindowMessage("UnPostPDFControl", "批量归档");
            //    messagePopup.Height = 730;
            //    messagePopup.Width = 600;
            //    Messenger.Default.Send<ShowContentWindowMessage>(messagePopup);
            //}
        }

        /// <summary>
        /// 判断未归档的记录是否存在
        /// </summary>
        /// <returns></returns>
        private bool GetNoPostPDF()
        {
            bool hasExist = false;
            List<MED_POSTPDF_SHOW> result = new List<MED_POSTPDF_SHOW>();
            List<MED_POSTPDF_SHOW> tempList = AnesInfoService.ClientInstance.GetPostPDFShowList(ExtendAppContext.Current.LoginUser.USER_JOB_ID);
            string NeedPostPDF = ApplicationConfiguration.PostPDF_Names;
            List<string> needPostPDFList = NeedPostPDF.Split(new char[] { ',' },
                                                           StringSplitOptions.RemoveEmptyEntries).ToList();

            List<string> existDocNamesList = new List<string>();
            List<string> noExistDocNamesList = new List<string>();
            foreach (MED_POSTPDF_SHOW item in tempList)
            {
                existDocNamesList.Clear();
                noExistDocNamesList.Clear();

                if (!string.IsNullOrEmpty(item.EXIST_DOCNAMES))
                {
                    existDocNamesList = item.EXIST_DOCNAMES.Split(new char[] { ',' },
                                                                  StringSplitOptions.RemoveEmptyEntries).ToList();
                }

                if (null == existDocNamesList || existDocNamesList.Count == 0)
                {
                    // 一张文书都没有上传
                    noExistDocNamesList.AddRange(needPostPDFList);
                }
                else if (null != existDocNamesList && existDocNamesList.Count > 0)
                {
                    // 上传了部分文书
                    needPostPDFList.ForEach(row =>
                    {
                        if (!existDocNamesList.Contains(row))
                        {
                            noExistDocNamesList.Add(row);
                        }
                    });
                }

                if (noExistDocNamesList.Count > 0)
                {
                    hasExist = true;
                    break;
                }
            }

            return hasExist;
        }

        ~Login()
        {
            this.Destroy(true);
        }
    }

    /// <summary>
    /// 密码框监视类：没看懂
    /// </summary>
    public class PasswordBoxMonitor : DependencyObject
    {
        public static bool GetIsMonitoring(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsMonitoringProperty);
        }

        public static void SetIsMonitoring(DependencyObject obj, bool value)
        {
            obj.SetValue(IsMonitoringProperty, value);
        }

        public static readonly DependencyProperty IsMonitoringProperty =
          DependencyProperty.RegisterAttached("IsMonitoring", typeof(bool), typeof(PasswordBoxMonitor), new UIPropertyMetadata(false, OnIsMonitoringChanged));

        public static int GetPasswordLength(DependencyObject obj)
        {
            return (int)obj.GetValue(PasswordLengthProperty);
        }

        public static void SetPasswordLength(DependencyObject obj, int value)
        {
            obj.SetValue(PasswordLengthProperty, value);
        }

        public static readonly DependencyProperty PasswordLengthProperty =
          DependencyProperty.RegisterAttached("PasswordLength", typeof(int), typeof(PasswordBoxMonitor), new UIPropertyMetadata(0));

        private static void OnIsMonitoringChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var pb = d as PasswordBox;
            if (pb == null)
            {
                return;
            }
            if ((bool)e.NewValue)
            {
                pb.PasswordChanged += PasswordChanged;
            }
            else
            {
                pb.PasswordChanged -= PasswordChanged;
            }
        }

        static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            var pb = sender as PasswordBox;
            if (pb == null)
            {
                return;
            }

            SetPasswordLength(pb, pb.Password.Length);
        }
    }
}
