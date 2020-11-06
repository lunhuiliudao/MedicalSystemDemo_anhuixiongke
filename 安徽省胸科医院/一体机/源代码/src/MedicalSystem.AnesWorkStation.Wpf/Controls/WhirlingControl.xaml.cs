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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MedicalSystem.AnesWorkStation.Wpf.Controls
{
    /// <summary>
    /// WhirlingControl.xaml 的交互逻辑
    /// </summary>
    public partial class WhirlingControl : Window
    {
        private DispatcherTimer timer = null;             // 定时器
        private EventHandler tickEvent = null;

        public void SetTimerTick(EventHandler e)
        {
            if (timer == null)
            {
                tickEvent = e;

                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(2);
                timer.Tick += tickEvent;
                timer.Start();
            }
        }

        /// <summary>
        /// 构造方法，启动动画
        /// </summary>
        public WhirlingControl()
        {
            InitializeComponent();
            this.Topmost = true;
            this.Closing += WhirlingControl_Closing;
        }

        void WhirlingControl_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (timer != null)
            {
                if (tickEvent != null)
                {
                    timer.Tick -= tickEvent;
                    tickEvent = null;
                }
                timer.Stop();
                timer = null;
            }
        }

    }
}
