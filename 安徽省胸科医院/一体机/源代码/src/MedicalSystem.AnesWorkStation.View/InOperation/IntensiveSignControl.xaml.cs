//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      IntensiveSignControl.cs
//功能描述(Description)：    密集体征展现界面
//数据表(Tables)：		    无 
//作者(Author)：             MDSD
//日期(Create Date)：        2017/12/27 09:30
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝=
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel;
using System;
using System.Windows.Threading;

namespace MedicalSystem.AnesWorkStation.View.InOperation
{
    /// <summary>
    /// IntensiveSignControl.xaml 的交互逻辑
    /// </summary>
    public partial class IntensiveSignControl : BaseUserControl
    {
        private DispatcherTimer timer = new DispatcherTimer();
        IntensiveSignViewModel _intensiveSignModel = null;
        public IntensiveSignControl()
        {
            InitializeComponent();
            _intensiveSignModel = new IntensiveSignViewModel();
            this.DataContext = _intensiveSignModel;
            VitalSignsControl1.MoveXAxisAction = (sender, xMove) =>
            {
                dateAxis1.MoveXAxis(xMove);
            };
            dateAxis1.DrawTimeProcessAction = (time) =>
            {
                VitalSignsControl1.DrawTimeProcess(time);
            };
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = TimeSpan.FromSeconds(30);
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            Messenger.Default.Send<object>(this, EnumMessageKey.RefreshIntensiveSignVitalWindow);
        }

        public override void Dispose()
        {
            timer.Tick -= new EventHandler(timer_Tick);
            timer.Stop();
            timer = null;
            base.Dispose();
        }

        ~IntensiveSignControl()
        {
            if (timer != null)
            {
                timer.Tick -= new EventHandler(timer_Tick);
                timer.Stop();
                timer = null;
            }
        }

    }
}
