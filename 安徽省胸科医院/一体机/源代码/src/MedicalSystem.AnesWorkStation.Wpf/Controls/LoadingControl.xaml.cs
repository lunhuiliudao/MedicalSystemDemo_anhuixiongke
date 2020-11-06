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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MedicalSystem.AnesWorkStation.Wpf.Controls
{
    /// <summary>
    /// LoadingControl.xaml 的交互逻辑
    /// </summary>
    public partial class LoadingControl : UserControl
    {
        public static readonly DependencyProperty LoadingStringProperty = DependencyProperty.Register("LoadingString", typeof(string), typeof(LoadingControl), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure, OnLoadingStringChanged));

        /// <summary>
        /// 加载描述
        /// </summary>
        public string LoadingString
        {
            get
            {
                return (string)GetValue(LoadingStringProperty);
            }
            set
            {
                SetValue(LoadingStringProperty, value);
            }
        }

        public LoadingControl()
        {
            InitializeComponent();
            //this.Loaded += Loading_Loaded;
        }

        private static void OnLoadingStringChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as LoadingControl).SetLoadingString(e.NewValue.ToString());
        }

        private void SetLoadingString(string loadString)
        {
            txtLoadString.Text = loadString;
        }

        //private void Loading_Loaded(object sender, RoutedEventArgs e)
        //{
        //    Storyboard sbd = Resources["LoadingStoryboard"] as Storyboard;
        //    sbd.Begin(this, true);
        //}

        //public void StopLoading()
        //{
        //    Storyboard sbd = Resources["LoadingStoryboard"] as Storyboard;
        //    sbd.Remove(this);
        //}

        //public void BeginLoading()
        //{
        //    Storyboard sbd = Resources["LoadingStoryboard"] as Storyboard;
        //    sbd.Begin(this, true);
        //}
    }
}
