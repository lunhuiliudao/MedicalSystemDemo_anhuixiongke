// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      TodaySurgery.xaml.cs
// 功能描述(Description)：    今日手术信息面板
// 数据表(Tables)：		      无
// 作者(Author)：             许文龙、孙家富
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.AnesWorkStation.ViewModel.WorkListViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace MedicalSystem.AnesWorkStation.View.WorkList
{
    /// <summary>
    /// TodaySurgery.xaml 的交互逻辑
    /// </summary>
    public partial class TodaySurgery : UserControl
    {
        /// <summary>
        /// 今日手术汇总信息VM
        /// </summary>
        private TodaySurgeryViewModel todaySurVM = null;      
        private Storyboard storyboard = null;                   // 动画版
        private double sourceFontSize = 20.0;                   // 原始大小
        private double sourceOpacity = 0.7;                     // 原始不透明度

        /// <summary>
        /// 构造方法
        /// </summary>
        public TodaySurgery()
        {
            InitializeComponent();
            this.todaySurVM = new TodaySurgeryViewModel();
            this.DataContext = this.todaySurVM;
            this.InitStoryboard();
        }

        /// <summary>
        /// 初始化动画版
        /// </summary>
        private void InitStoryboard()
        {
            this.storyboard = new Storyboard();
            this.storyboard.RepeatBehavior = RepeatBehavior.Forever;
        }

        /// <summary>
        /// 鼠标进入时显示动画，写在后台通用，如果写在前台，To属性不能更改
        /// </summary>
        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBlock tb = sender as TextBlock;
            this.sourceFontSize = tb.FontSize;
            this.sourceOpacity = tb.Opacity;
            if(null != tb && null != this.storyboard)
            {
                DoubleAnimation daChangeBigFontSize = new DoubleAnimation(this.sourceFontSize, this.sourceFontSize + 5.0, new Duration(TimeSpan.FromSeconds(1.0)));
                daChangeBigFontSize.BeginTime = new TimeSpan(0, 0, 0);
                Storyboard.SetTarget(daChangeBigFontSize, tb);
                Storyboard.SetTargetProperty(daChangeBigFontSize, new PropertyPath("FontSize"));
                this.storyboard.Children.Add(daChangeBigFontSize);

                DoubleAnimation daChangeBigOpacity = new DoubleAnimation(this.sourceOpacity, 1.0, new Duration(TimeSpan.FromSeconds(1.0)));
                daChangeBigOpacity.BeginTime = new TimeSpan(0, 0, 0);
                Storyboard.SetTarget(daChangeBigOpacity, tb);
                Storyboard.SetTargetProperty(daChangeBigOpacity, new PropertyPath("Opacity"));
                this.storyboard.Children.Add(daChangeBigOpacity);

                DoubleAnimation daChangeSmallFontSize = new DoubleAnimation(this.sourceFontSize + 5.0, this.sourceFontSize, new Duration(TimeSpan.FromSeconds(1.0)));
                daChangeSmallFontSize.BeginTime = new TimeSpan(0, 0, 1);
                Storyboard.SetTarget(daChangeSmallFontSize, tb);
                Storyboard.SetTargetProperty(daChangeSmallFontSize, new PropertyPath("FontSize"));
                this.storyboard.Children.Add(daChangeSmallFontSize);

                DoubleAnimation daChangeSmallOpacity = new DoubleAnimation(1.0, this.sourceOpacity, new Duration(TimeSpan.FromSeconds(1.0)));
                daChangeSmallOpacity.BeginTime = new TimeSpan(0, 0, 1);
                Storyboard.SetTarget(daChangeSmallOpacity, tb);
                Storyboard.SetTargetProperty(daChangeSmallOpacity, new PropertyPath("Opacity"));
                this.storyboard.Children.Add(daChangeSmallOpacity);

                this.storyboard.Begin();
            }
        }

        /// <summary>
        /// 退出
        /// </summary>
        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            if(null != this.storyboard)
            {
                this.storyboard.Stop();
                this.storyboard.Children.Clear();
            }
        }
    }
}
