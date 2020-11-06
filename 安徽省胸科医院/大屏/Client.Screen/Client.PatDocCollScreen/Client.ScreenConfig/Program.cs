using MedicalSystem.MedScreen.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalSystem.MedScreen.Client.ScreenConfig
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            DevHandlerLib.DevHandler.CloseDevWindow();

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Skins.SkinManager.Default.RegisterAssembly(typeof(DevExpress.UserSkins.iMedStatsSkin).Assembly);

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CHS");
            DevExpress.XtraEditors.Controls.Localizer.Active = new LocalizationCHS();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //登录界面
            ConfigLoginFrm loginForm = new ConfigLoginFrm();

            DialogResult dialogResult = loginForm.ShowDialog();

            if (dialogResult != DialogResult.OK)
            {
                Environment.Exit(0);
                return;
            }
            //配置界面
            Application.Run(new ConfigFrm());
        }
    }
}
