using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MedicalSystem.AnesWorkStation.Wpf.Controls
{
    /// <summary>
    /// BulletCheckBox.xaml 的交互逻辑
    /// </summary>
    public class BulletCheckBox : CheckBox
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text", typeof(string), typeof(BulletCheckBox), new PropertyMetadata("Off"));
        /// <summary>
        /// 默认文本（未选中）
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty CheckedTextProperty = DependencyProperty.Register(
            "CheckedText", typeof(string), typeof(BulletCheckBox), new PropertyMetadata("On"));
        /// <summary>
        /// 选中状态文本
        /// </summary>
        public string CheckedText
        {
            get { return (string)GetValue(CheckedTextProperty); }
            set { SetValue(CheckedTextProperty, value); }
        }

        public static readonly DependencyProperty CheckedForegroundProperty =
            DependencyProperty.Register("CheckedForeground", typeof(Brush), typeof(BulletCheckBox), new PropertyMetadata(Brushes.WhiteSmoke));
        /// <summary>
        /// 选中状态前景样式
        /// </summary>
        public Brush CheckedForeground
        {
            get { return (Brush)GetValue(CheckedForegroundProperty); }
            set { SetValue(CheckedForegroundProperty, value); }
        }

        public static readonly DependencyProperty CheckedBackgroundProperty =
            DependencyProperty.Register("CheckedBackground", typeof(Brush), typeof(BulletCheckBox), new PropertyMetadata(Brushes.LimeGreen));
        /// <summary>
        /// 选中状态背景色
        /// </summary>
        public Brush CheckedBackground
        {
            get { return (Brush)GetValue(CheckedBackgroundProperty); }
            set { SetValue(CheckedBackgroundProperty, value); }
        }


        /// <summary>
        /// 默认显示的图片
        /// </summary>
        public string DefaultImagePath
        {
            get { return (string)GetValue(DefaultImagePathProperty); }
            set { SetValue(DefaultImagePathProperty, value); }
        }

        public static readonly DependencyProperty DefaultImagePathProperty =
            DependencyProperty.Register("DefaultImagePath", typeof(string), typeof(BulletCheckBox), new PropertyMetadata(""));



        /// <summary>
        /// 选中状态下图片的路径
        /// </summary>
        public string CheckedImagePath
        {
            get { return (string)GetValue(CheckedImagePathProperty); }
            set { SetValue(CheckedImagePathProperty, value); }
        }

        public static readonly DependencyProperty CheckedImagePathProperty =
            DependencyProperty.Register("CheckedImagePath", typeof(string), typeof(BulletCheckBox), new PropertyMetadata(""));


        /// <summary>
        /// 选中状态下的字体颜色
        /// </summary>
        public Brush CheckForeground
        {
            get { return (Brush)GetValue(CheckForegroundProperty); }
            set { SetValue(CheckForegroundProperty, value); }
        }

        public static readonly DependencyProperty CheckForegroundProperty =
            DependencyProperty.Register("CheckForeground", typeof(Brush), typeof(BulletCheckBox), new PropertyMetadata(Brushes.Red));

        /// <summary>
        /// This is the method that responds to the KeyDown event.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            // Add aditional keys "+" and "-" when we are not in IsThreeState mode
            if (!IsThreeState)
            {
                if (e.Key == Key.Enter)
                {
                    e.Handled = true;
                    IsPressed = false;
                    SetCurrentValue(IsCheckedProperty, !IsChecked);
                }
            }
        }

        static BulletCheckBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BulletCheckBox), new FrameworkPropertyMetadata(typeof(BulletCheckBox)));
        }
    }
}
