//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      LoadReport.xaml.cs
//功能描述(Description)：    文书加载界面
//数据表(Tables)：		     无
//作者(Author)：             MDSD
//日期(Create Date)：        2017-12-27 10:05:39
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.ViewModel.LoadReportViewModel;
using System;
using System.Windows;

namespace MedicalSystem.AnesWorkStation.View.OperationInformation
{
    /// <summary>
    /// LoadReport.xaml 的交互逻辑
    /// </summary>
    public partial class LoadReport : BaseUserControl
    {
        private LoadReportViewModel loadReportViewModel;

        public LoadReport()
        {
            InitializeComponent();
            this.loadReportViewModel = new LoadReportViewModel();
            this.DataContext = this.loadReportViewModel;
            this.Register();
        }

        /// <summary>
        /// 注册消息
        /// </summary>
        private void Register()
        {
            // 在窗口内部实现文书切换
            Messenger.Default.Register<string>(this, EnumMessageKey.ResetLoadReport, msg =>
            {
                this.Dispatcher.BeginInvoke((Action)delegate
                {
                    if (null != this.loadReportViewModel.CurBaseDoc)
                    {
                        this.winPanelContent.Controls.Clear();
                        this.winPanelContent.Controls.Add(this.loadReportViewModel.CurBaseDoc);
                        Window.GetWindow(this).Title = msg;
                    }
                }, System.Windows.Threading.DispatcherPriority.ApplicationIdle);
            });
        }

        /// <summary>
        /// 载入文书
        /// </summary>
        private void BaseUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                double containerWidth = SystemParameters.PrimaryScreenWidth;
                double containerHeight = SystemParameters.PrimaryScreenHeight - 30;
                winHostMain.Width = containerWidth;
                winHostMain.Height = containerHeight;
                winPanelContent.Width = (int)containerWidth;
                winPanelContent.Height = (int)containerHeight;
                winPanelContent.Controls.Add(this.loadReportViewModel.CurBaseDoc);
            }
            catch
            {
            }
        }
    }
}
