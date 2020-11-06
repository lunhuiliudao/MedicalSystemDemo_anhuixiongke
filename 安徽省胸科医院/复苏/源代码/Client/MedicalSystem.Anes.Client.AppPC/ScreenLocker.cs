using MedicalSystem.Anes.Client.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MedicalSystem.Anes.Client.AppPC
{
    class ScreenLocker : IMessageFilter
    {
        static MainFrm _form;
        //保存当前的锁定状态
        public static bool lockState;
        //时间计数
        static int iTimeLen;
        static Thread backThread;
        public static string userid
        {
            get;
            set;
        }

        private ScreenLocker() { }

        public static void Initialize(MainFrm form)
        {
            if (_form == form || lockState == true)
                return;
            _form = form;
            Application.AddMessageFilter(new ScreenLocker());
            RunThreadToLock();
        }
        /// <summary>
        /// 用一个后台线程去锁定系统
        /// </summary>
        private static void RunThreadToLock()
        {
            if (1 >= 1)
            {
                backThread = new Thread(new ThreadStart(CheckLockState));
                backThread.IsBackground = true;
                backThread.Start();
            }
        }

        /// <summary>
        /// 循环检查锁定状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CheckLockState()
        {
            while (true)
            {
                if (lockState)
                {
                    Thread.Sleep(1000);
                    continue;
                }
                iTimeLen = iTimeLen + 1;
                if (iTimeLen >= ExtendApplicationContext.Current.ScreenLocker)       // to do 可配置,目前为五分钟
                {
                    lockState = true;
                    iTimeLen = 0;
                   // (Form.ActiveForm ?? _form).BeginInvoke(new MethodInvoker(DoLock));
                }
                Thread.Sleep(1000); 
            }
        }

        public static void DoLock()
        {
            try
            {
                ActionLockSystem();
            }
            finally
            {
                lockState = false;
            }
        }

        /// <summary>
        /// 锁定系统
        /// </summary>
        private static void ActionLockSystem()
        {
            LoginFrm loginForm = new LoginFrm(); 
            loginForm.TopLevel = true;
            loginForm.TopMost = true;
            DialogResult dialogResult = loginForm.ShowDialog();
            if (dialogResult != DialogResult.OK)
            {
                try
                {
                    Application.Exit();
                }
                catch
                {
                    //if (!string.IsNullOrEmpty(ExtendApplicationContext.Current.LoginUserContext.LoginName))
                    //    PermissionProxy.UpdateHisTag(ExtendApplicationContext.Current.LoginUserContext.LoginName, true);
                    System.Environment.Exit(0);
                }
                return;
            }

            if (LoginFrm.IsChangeUser)
            {
               // _form.InitMainForm();
            }
        }

        public bool PreFilterMessage(ref System.Windows.Forms.Message m)
        {
            //如果检测到有鼠标或则键盘被按下的消息，则使计数为0.....
            //132 移动鼠标，按住或释放鼠标时发生,256 按下键,512 移动鼠标,513 按下鼠标左键
            if (m.Msg == 132 || m.Msg == 256 || m.Msg == 512 || m.Msg == 513)
            {
                iTimeLen = 0;
            }
            return false;
        }
    }
}