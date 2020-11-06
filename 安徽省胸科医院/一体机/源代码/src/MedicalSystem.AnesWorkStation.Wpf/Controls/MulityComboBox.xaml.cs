using GalaSoft.MvvmLight.Command;
using MedicalSystem.AnesWorkStation.Wpf.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// MulityComboBox.xaml 的交互逻辑
    /// </summary>
    public partial class MulityComboBox : UserControl, INotifyPropertyChanged
    {
        public MulityComboBox()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SetControlIndex();
        }

        ///// <summary>
        ///// 处理对于搜索产生的选择的为NULL
        ///// </summary>
        //private void MyTextChanged(object sender, RoutedEventArgs e)
        //{
        //    ComboBoxEx cb = sender as ComboBoxEx;
        //    if (cb != null && cb.SelectedItem == null)
        //    {
        //        IList list = ItemsSource as IList;
        //        int index = int.Parse(cb.Tag.ToString());
        //        var bewText = cb.Text;
        //        if (index >= 0)
        //        {
        //            //初始化集合内的一个项目
        //            Type t = ComboBoxItemSource.GetType();
        //            if (t.IsGenericType)
        //            {
        //                Type[] childTypes = t.GetGenericArguments();
        //                //获取第一个Type
        //                if (childTypes != null && childTypes.Count() > 0)
        //                {
        //                    Type childType = childTypes[0];
        //                    //实例化
        //                    object obj = childType.Assembly.CreateInstance(childType.ToString());
        //                    PropertyInfo pi = childType.GetProperty(DisplayMemberPath);
        //                    pi.SetValue(obj, bewText);
        //                    (ItemsSource as IList)[index] = obj;
        //                }
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// 子项目宽度
        /// </summary>
        public int PerWidth
        {
            get { return (int)GetValue(PerWidthProperty); }
            set { SetValue(PerWidthProperty, value); }
        }

        public static readonly DependencyProperty PerWidthProperty =
            DependencyProperty.Register("PerWidth", typeof(int), typeof(MulityComboBox), new PropertyMetadata(150));


        public int PerHeight
        {
            get { return (int)GetValue(PerHeightProperty); }
            set { SetValue(PerHeightProperty, value); }
        }

        public static readonly DependencyProperty PerHeightProperty =
            DependencyProperty.Register("PerHeight", typeof(int), typeof(MulityComboBox), new PropertyMetadata(30));


        /// <summary>
        /// 作为搜索的字段
        /// </summary>
        public string SearchFieldName
        {
            get { return (string)GetValue(SearchFieldNameProperty); }
            set { SetValue(SearchFieldNameProperty, value); }
        }

        public static readonly DependencyProperty SearchFieldNameProperty =
            DependencyProperty.Register("SearchFieldName", typeof(string), typeof(MulityComboBox), new PropertyMetadata(null));


        /// <summary>
        /// 显示的字段
        /// </summary>
        public string DisplayMemberPath
        {
            get { return (string)GetValue(DisplayMemberPathProperty); }
            set { SetValue(DisplayMemberPathProperty, value); }
        }

        public static readonly DependencyProperty DisplayMemberPathProperty =
            DependencyProperty.Register("DisplayMemberPath", typeof(string), typeof(MulityComboBox), new PropertyMetadata(null));


        /// <summary>
        /// 作为ComboBox数据源
        /// </summary>
        public IEnumerable ComboBoxItemSource
        {
            get { return (IEnumerable)GetValue(ComboBoxItemSourceProperty); }
            set { SetValue(ComboBoxItemSourceProperty, value); }
        }

        public static readonly DependencyProperty ComboBoxItemSourceProperty =
            DependencyProperty.Register("ComboBoxItemSource", typeof(IEnumerable), typeof(MulityComboBox), new PropertyMetadata(null));


        /// <summary>
        /// 控件的数据源
        /// </summary>
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(MulityComboBox),
            new PropertyMetadata(new List<object>(), new PropertyChangedCallback(PropertyChangedCallback)));


        public static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //等待优化修改
            MulityComboBox rp = d as MulityComboBox;
            if (rp == null)
            {
                return;
            }
            string PropertyName = e.Property.Name;
            if (PropertyName == "ItemsSource")
            {
                var oldRates = e.OldValue as INotifyCollectionChanged;
                var newRates = e.NewValue as INotifyCollectionChanged;

                if (oldRates != null)
                {
                    oldRates.CollectionChanged -= rp.OnRatesCollectionChanged;
                }

                if (newRates != null)
                {
                    newRates.CollectionChanged += rp.OnRatesCollectionChanged;
                }
            }
        }

        /// <summary>
        /// 属性修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnRatesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

        }

        public ICommand DeleteCommand
        {
            get
            {
                return new RelayCommand<object>((currentSelect) =>
                {
                    (ItemsSource as IList).Remove(currentSelect);
                });
            }
        }


        public ICommand SelectChanged
        {
            get
            {
                return new RelayCommand<object[]>((currentSelect) =>
                {
                    if (currentSelect != null)
                    {
                        var newval = currentSelect[0];
                        var oldval = currentSelect[1];

                        int index = (ItemsSource as IList).IndexOf(oldval);
                        (ItemsSource as IList)[index] = newval;
                    }
                });
            }
        }

        ///// <summary>
        ///// 处理对于搜索产生的选择的为NULL
        ///// </summary>
        //public ICommand TextSearchCommand
        //{
        //    get
        //    {
        //        return new RelayCommand<object[]>((currentSelect) =>
        //        {
        //            if (currentSelect != null)
        //            {
        //                var newval = currentSelect[0];
        //                var oldval = currentSelect[1];
        //                var bewText = currentSelect[2].ToString();
        //                int index = (ItemsSource as IList).IndexOf(oldval);

        //                if (newval == null || newval == oldval)
        //                {
        //                    string changeText = bewText;
        //                    //初始化集合内的一个项目
        //                    Type t = ComboBoxItemSource.GetType();
        //                    if (t.IsGenericType)
        //                    {
        //                        Type[] childTypes = t.GetGenericArguments();
        //                        //获取第一个Type
        //                        if (childTypes != null && childTypes.Count() > 0)
        //                        {
        //                            Type childType = childTypes[0];
        //                            //实例化
        //                            object obj = childType.Assembly.CreateInstance(childType.ToString());
        //                            PropertyInfo pi = childType.GetProperty(DisplayMemberPath);
        //                            pi.SetValue(obj, changeText);
        //                            (ItemsSource as IList)[index] = obj;
        //                        }
        //                    }
        //                }
        //            }
        //        });
        //    }
        //}

        /// <summary>
        /// 消息通知
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;


        //private object chooseSelect;

        //public object ChooseSelect
        //{
        //    get { return chooseSelect; }
        //    set
        //    {
        //        chooseSelect = value;
        //        OnPropertyChanged("ChooseSelect");

        //        if (value != null)
        //        {
        //            Type childType = value.GetType();
        //            PropertyInfo pi = childType.GetProperty(DisplayMemberPath);
        //            object obj = pi.GetValue(value);
        //            (ItemsSource as IList).Add(obj);
        //            ChooseSelect = null;
        //            this.cboex.SelectedValueEx = "";
        //        }
        //    }
        //}

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            //回车添加
            if (e.Key == Key.Enter && !string.IsNullOrEmpty(this.cboex.SelectedValueEx))
            {
                (ItemsSource as IList).Add(this.cboex.SelectedValueEx);
                this.Dispatcher.BeginInvoke((Action)delegate
                {
                    this.cboex.SelectedValueEx = "";
                }, System.Windows.Threading.DispatcherPriority.ApplicationIdle);
            }
        }

        private void cboex_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.cboex.SelectedValueEx))
            {
                (ItemsSource as IList).Add(this.cboex.SelectedValueEx);
                this.Dispatcher.BeginInvoke((Action)delegate
                {
                    this.cboex.SelectedValueEx = "";
                }, System.Windows.Threading.DispatcherPriority.ApplicationIdle);
            }
        }

        private void cboex_ClickedSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.cboex.SelectedValueEx))
            {
                (ItemsSource as IList).Add(this.cboex.SelectedValueEx);
                this.Dispatcher.BeginInvoke((Action)delegate
                {
                    this.cboex.SelectedValueEx = "";
                }, System.Windows.Threading.DispatcherPriority.ApplicationIdle);
            }
        }

        private void SetControlIndex()
        {
            List<ComboBoxEx> cbos = VisualTreeFinder.GetChildsByName<ComboBoxEx>(this, "InnerCboex");
            int count = 0;
            foreach (var item in cbos)
            {
                item.Tag = count;
                //item.RemoveHandler(TextBoxBase.TextChangedEvent, new RoutedEventHandler(MyTextChanged));
                //item.AddHandler(TextBoxBase.TextChangedEvent, new RoutedEventHandler(MyTextChanged));
                count++;
            }
        }

        private void lb_LayoutUpdated(object sender, EventArgs e)
        {
            SetControlIndex();
        }

        private void InnerCboex_ValueExChanged(ComboBox sender, ComboBoxEx.ValueExArgs args)
        {
            this.Dispatcher.BeginInvoke((Action)delegate
            {
                (ItemsSource as IList)[(int)sender.Tag] = args.ValueEx;
            }, System.Windows.Threading.DispatcherPriority.ApplicationIdle);
        }
    }
}
