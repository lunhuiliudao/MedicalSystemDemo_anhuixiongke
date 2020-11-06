using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MedicalSystem.MedScreen.Controls;
using MedicalSystem.MedScreen.Common;
using MedicalSystem.AnesIcuQuery.Common;
using MedicalSystem.AnesIcuQuery.Network;
using MedicalSystem.MedScreen.Network;

namespace MedicalSystem.MedScreen.Client.PatDocScreen
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            DevHandlerLib.DevHandler.CloseDevWindowKeepRunning();

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Skins.SkinManager.Default.RegisterAssembly(typeof(DevExpress.UserSkins.iMedStatsSkin).Assembly);
            DevExpress.Skins.SkinManager.EnableFormSkins();

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CHS");
            DevExpress.XtraEditors.Controls.Localizer.Active = new LocalizationCHS();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.ThreadException += Application_ThreadException;
            ////登录界面
            //LoginFrm loginForm = new LoginFrm();

            //DialogResult dialogResult = loginForm.ShowDialog();

            //if (dialogResult != DialogResult.OK)
            //{
            //    Application.Exit();
            //    return;
            //}

            ExtendAppContext.Current.CurntScreenNo = AppConfiguration.Read("ScreenNo");
            ExtendAppContext.Current.ShowScreenNo = int.Parse(AppConfiguration.Read("ShowScreenNo"));
            //主界面
            Application.Run(new MainScreenFrm());
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            ExceptionHandler.Handle(e.Exception);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;
            if (exception != null)
            {
                ExceptionHandler.Handle(e.ExceptionObject as Exception);
            }
        }
    }
}
