using MedicalSystem.AnesWorkStation.Wpf.Adorners;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MedicalSystem.AnesWorkStation.Wpf.Controls
{
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:MedicalSystem.AnesWorkStation.Wpf.Controls"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:MedicalSystem.AnesWorkStation.Wpf.Controls;assembly=MedicalSystem.AnesWorkStation.Wpf.Controls"
    ///
    /// 您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
    /// 并重新生成以避免编译错误: 
    ///
    ///     在解决方案资源管理器中右击目标项目，然后依次单击
    ///     “添加引用”->“项目”->[浏览查找并选择此项目]
    ///
    ///
    /// 步骤 2)
    /// 继续操作并在 XAML 文件中使用控件。
    ///
    ///     <MyNamespace:SearchTextBox/>
    ///
    /// </summary>
    public class SearchTextBox : TextBox
    {
        public static readonly DependencyProperty SearchToolTipProperty = DependencyProperty.Register("SearchToolTip", typeof(string), typeof(SearchTextBox), new FrameworkPropertyMetadata("搜索", FrameworkPropertyMetadataOptions.AffectsMeasure, OnSearchToolTipChanged));

        /// <summary>
        /// Placeholder
        /// </summary>
        public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.RegisterAttached(
            "Placeholder", typeof(string), typeof(SearchTextBox),
            new PropertyMetadata("请在此处输入关键字", OnPlaceholderChanged));        

        public static readonly RoutedEvent SearchClickRoutedEvent = EventManager.RegisterRoutedEvent("SearchClick", RoutingStrategy.Bubble, typeof(MouseButtonEventHandler), typeof(SearchTextBox));

        /// <summary>
        /// SearchToolTip
        /// </summary>
        public string SearchToolTip
        {
            get { return (string)GetValue(SearchToolTipProperty); }
            set { SetValue(SearchToolTipProperty, value); }
        }
        /// <summary>
        /// Placeholder
        /// </summary>
        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        [Description("点击搜索")]
        public event MouseButtonEventHandler SearchClick
        {
            add { AddHandler(SearchClickRoutedEvent, value); }
            remove { RemoveHandler(SearchClickRoutedEvent, value); }
        }

        static SearchTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchTextBox), new FrameworkPropertyMetadata(typeof(SearchTextBox)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if (Template != null)
            {
                Image SearchImage = Template.FindName("SearchImage", this) as Image;
                SearchImage.MouseLeftButtonUp += SearchImage_MouseLeftButtonUp; ;
            }
        }

        private void SearchImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MouseButtonEventArgs newEventArgs = new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton);
            newEventArgs.RoutedEvent = SearchClickRoutedEvent;
            RaiseEvent(newEventArgs);
        }

        private static void OnPlaceholderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SearchTextBox txt = d as SearchTextBox;
            if (txt == null || e.NewValue.ToString().Trim().Length == 0) return;

            RoutedEventHandler loadHandler = null;
            loadHandler = (s1, e1) =>
            {
                txt.Loaded -= loadHandler;

                var lay = AdornerLayer.GetAdornerLayer(txt);
                if (lay == null) return;

                Adorner[] ar = lay.GetAdorners(txt);
                if (ar != null)
                {
                    for (int i = 0; i < ar.Length; i++)
                    {
                        if (ar[i] is PlaceholderAdorner)
                        {
                            lay.Remove(ar[i]);
                        }
                    }
                }

                if (txt.Text.Length == 0)
                    lay.Add(new PlaceholderAdorner(txt, e.NewValue.ToString()));

            };
            txt.Loaded += loadHandler;
            txt.TextChanged += (s1, e1) =>
            {
                bool isShow = txt.Text.Length == 0;

                var lay = AdornerLayer.GetAdornerLayer(txt);
                if (lay == null) return;

                if (isShow)
                {
                    lay.Add(new PlaceholderAdorner(txt, e.NewValue.ToString()));
                }
                else
                {
                    Adorner[] ar = lay.GetAdorners(txt);
                    if (ar != null)
                    {
                        for (int i = 0; i < ar.Length; i++)
                        {
                            if (ar[i] is PlaceholderAdorner)
                            {
                                lay.Remove(ar[i]);
                            }
                        }
                    }
                }
            };
        }

        private static void OnSearchToolTipChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
