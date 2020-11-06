using MedicalSystem.Anes.Client.FrameWork;
using MedicalSystem.Anes.Client.Repository;
using MedicalSystem.Anes.Document;
using MedicalSystem.Services;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Client.AppPC
{
    static class Program
    {

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //System.Threading.Mutex mutexMyapplication = new System.Threading.Mutex(false, "MedicalSystem.Anes.Client.AppPC.exe");
            //if (!mutexMyapplication.WaitOne(100, false))
            //{
            //    MessageBoxFormPC.Show("复苏程序已经运行！", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            foreach (Process process in processes)
            {
                if (process.Id != current.Id)
                {
                    if (process.MainModule.FileName
                    == current.MainModule.FileName)
                    {
                        MessageBoxFormPC.Show("复苏程序已经运行！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }

            #region 自动更新
            UpdateDLL.Update.CheckVerion();
            #endregion
            bool requestInitialOwnership = true;
            bool mutexWasCreated = false;

            DevHandlerLib.DevHandler.CloseDevWindowKeepRunning();

            Logger.Error(string.Format("系统启动，当前的时间{0}", DateTime.Now));
            ///显示错误定义：暂时用系统消息框显示，等美工设计好界面后替换


            //MedicalSystem.Anes.Core.ExceptionHandle.ExceptionHelper.ShowExceptionAction =
            //    (exMessage) =>
            //    {
            //        ExceptionMessageBox.Show(exMessage.SourceException);
            //    };

            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            ExtendApplicationContext.Current.ClientIP = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList[0].ToString();

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                bool loginFlag = false;
                using (LoginFrm loginFrm = new LoginFrm(args))
                {
                    if (loginFrm.ShowDialog() == DialogResult.OK)
                    {
                        loginFlag = true;
                        t = new Thread(new ThreadStart(LoadingForm));
                        t.Name = "LoadingFormThread";
                        t.IsBackground = true;
                        t.Start();
                    }
                }
                if (loginFlag)
                {
                    while (true)
                    {
                        if (LoadingFrm.EndOfTask)
                        {
                            WebApiVisitor.ApiStartRequest += WebApiVisitor_ApiStartRequest;
                            WebApiVisitor.ApiEndRequest += WebApiVisitor_ApiEndRequest;
                            Application.Run(new MainFrm());
                            break;
                        }
                        else
                        {
                            Thread.Sleep(20);
                        }
                    }
                }
                else
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                Logger.Error( "MedicalSystem.Anes.Client.AppPC.Program.Main",ex);
            }

            Logger.Error(string.Format("系统退出，当前的时间{0}", DateTime.Now));
        }

        #region 访问服务端的进度条

        static void WebApiVisitor_ApiStartRequest(object sender, EventArgs e)
        {
            //if (LoadingFrm.EndWithMainFrm)
            //{
            //    WaitingFrm.ShowWaiting();
            //}
        }

        static void WebApiVisitor_ApiEndRequest(object sender, EventArgs e)
        {
            //if (LoadingFrm.EndWithMainFrm)
            //{
            //    WaitingFrm.HideWaiting();
            //}
        }

        #endregion

        #region 异常扑捉

        /// <summary>
        /// 领域级异常扑捉
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ExceptionHandler.Handle(e.ExceptionObject as Exception);

        }

        /// <summary>
        /// 应用级异常扑捉
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            ExceptionHandler.Handle(e.Exception as Exception);
        }

        #endregion

        #region 进度条

        static Thread t = null;

        static void LoadingForm()
        {
            using (LoadingFrm loading = new LoadingFrm())
            {
                loading.ShowDialog();
            }
            t = null;
        }

        #endregion

        #region 键盘按钮处理

#if UNSAFEKEYBOARD

        static UsbKeyBoardLib.UsbKeyBoard usbLib = new UsbKeyBoardLib.UsbKeyBoard();
        static bool IsNeedRestart = false;

        public delegate void DoWithAppCodeHander(string keyCode);

        /// <summary>
        /// 打开键盘
        /// </summary>
        static void OpenKeyBoard()
        {
            usbLib.OnDataReceivedEvent += (s, e) =>
            {
                Console.Write(e.ScanCode);
                if (Form.ActiveForm != null && Form.ActiveForm is BaseForm)
                {
                    BaseForm frm = Form.ActiveForm as BaseForm;
                    string appCode = frm.KeyCode.GetKeyCode(e.ScanCode);
                    Console.Write("\t" + appCode);
                    //frm.DoWithKeyCode(keyCode);
                    frm.BeginInvoke(new DoWithAppCodeHander(frm.DoWithAppCode), new object[] { appCode });
                }
                Console.WriteLine();
            };
            usbLib.OnUsbGlobalErrorEvent += (s, e) =>
            {
                try
                {
                    IsNeedRestart = true;
                    if (Form.ActiveForm != null && Form.ActiveForm is BaseForm)
                    {
                        BaseForm frm = Form.ActiveForm as BaseForm;
                        frm.BeginInvoke(new DoWithAppCodeHander(frm.ThrowException), new object[] { e.ToString() });
                    }
                    //记录按键使用频率功能。
                    MedicalSystem.Anes.Core.Log.LogHelper.WriteErrLog(e.ToString(), new Exception());
                }
                catch { }
            };
            usbLib.OpenDevice();
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            if (usbLib != null)
            {
                usbLib.Dispose();
                usbLib = null;
            }
        }

#endif

        #endregion
    }
}
