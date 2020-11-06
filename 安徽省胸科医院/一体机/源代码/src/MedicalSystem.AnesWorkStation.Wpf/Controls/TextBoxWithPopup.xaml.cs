using MedicalSystem.AnesWorkStation.Wpf.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// TextBoxWithPopup.xaml 的交互逻辑
    /// </summary>
    public partial class TextBoxWithPopup : UserControl
    {
        public TextBoxWithPopup()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设置焦点
        /// </summary>
        public void ResetFocus()
        {
            this.tb.Focus();
        }

        /// <summary>
        /// 查询按钮
        /// </summary>
        public ICommand SearchCommand
        {
            get { return (ICommand)GetValue(SearchCommandProperty); }
            set { SetValue(SearchCommandProperty, value); }
        }

        public static readonly DependencyProperty SearchCommandProperty =
            DependencyProperty.Register("SearchCommand", typeof(ICommand), typeof(TextBoxWithPopup), new PropertyMetadata(null));



        /// <summary>
        /// 输入的字符
        /// </summary>
        public string SearchText
        {
            get { return (string)GetValue(SearchTextProperty); }
            set { SetValue(SearchTextProperty, value); }
        }

        public static readonly DependencyProperty SearchTextProperty =
            DependencyProperty.Register("SearchText", typeof(string), typeof(TextBoxWithPopup), new PropertyMetadata("",
                new PropertyChangedCallback(PropertyChangedCallback)));


        /// <summary>
        /// 字体颜色
        /// </summary>
        public new Brush Foreground
        {
            get { return (Brush)GetValue(ForegroundProperty); }
            set { SetValue(ForegroundProperty, value); }
        }

        public new static readonly DependencyProperty ForegroundProperty =
            DependencyProperty.Register("Foreground", typeof(Brush), typeof(TextBoxWithPopup), new PropertyMetadata(Brushes.Black,
                new PropertyChangedCallback(PropertyChangedCallback)));


        /// <summary>
        /// 默认字体大小
        /// </summary>
        public new int FontSize
        {
            get { return (int)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public new static readonly DependencyProperty FontSizeProperty =
            DependencyProperty.Register("FontSize", typeof(int), typeof(TextBoxWithPopup), new PropertyMetadata(18,
                new PropertyChangedCallback(PropertyChangedCallback)));



        /// <summary>
        /// 用于查询结果显示的字段
        /// </summary>
        public string DisplayMember
        {
            get { return (string)GetValue(DisplayMemberProperty); }
            set { SetValue(DisplayMemberProperty, value); }
        }

        public static readonly DependencyProperty DisplayMemberProperty =
            DependencyProperty.Register("DisplayMember", typeof(string), typeof(TextBoxWithPopup), new PropertyMetadata("",
                new PropertyChangedCallback(PropertyChangedCallback)));


        /// <summary>
        /// 用于显示查询结果的结果集
        /// </summary>
        public IList ItemSource
        {
            get { return (IList)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemSourceProperty =
            DependencyProperty.Register("ItemSource", typeof(IList), typeof(TextBoxWithPopup), new PropertyMetadata(null,
                new PropertyChangedCallback(PropertyChangedCallback)));


        /// <summary>
        /// 选中的项目
        /// </summary>
        public object SelectItem
        {
            get { return (object)GetValue(SelectItemProperty); }
            set { SetValue(SelectItemProperty, value); }
        }

        public static readonly DependencyProperty SelectItemProperty =
            DependencyProperty.Register("SelectItem", typeof(object), typeof(TextBoxWithPopup), new PropertyMetadata(null));

        /// <summary>
        /// 响应按键
        /// </summary>
        private void Tb_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // 当前列表有数据
            if (e.Key == Key.Down && this.pop.IsOpen && this.lv.Items.Count > 0)
            {
                e.Handled = true;
                this.lv.Focus();
                this.lv.SelectedIndex = 0;
                SelectorControlHelper.SetItemFocus(this.lv, this.lv.SelectedItem);
            }
        }

        /// <summary>
        /// 搜索框获得焦点时，重置下左侧列表的数据源，实现重绘功能
        /// </summary>
        private void Tb_GotFocus(object sender, RoutedEventArgs e)
        {
            if (this.lv.Items.Count > 0)
            {
                IEnumerable tempList = this.lv.ItemsSource;
                this.lv.ItemsSource = null;
                this.lv.ItemsSource = tempList;
            }
        }

        /// <summary>
        /// 下拉框响应按键
        /// </summary>
        private void Lv_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && null != this.lv.SelectedItem)
            {
                ItemModel im = this.lv.SelectedItem as ItemModel;
                if (im != null)
                {
                    SelectItem = im.SourceItem;
                    PropertyInfo pi = SelectItem.GetType().GetProperty(DisplayMember);
                    string value = pi.GetValue(SelectItem, null).ToString();
                    this.tb.Text = value;
                    pop.IsOpen = false;
                    e.Handled = true;
                }
            }
            else if (e.Key == Key.Up && this.lv.SelectedIndex == 0)
            {
                this.ResetFocus();
                e.Handled = true;
            }
        }

        /// <summary>
        /// 鼠标选中
        /// </summary>
        private void ListViewItem_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            ItemModel im = this.lv.SelectedItem as ItemModel;
            if (im != null)
            {
                SelectItem = im.SourceItem;
                PropertyInfo pi = SelectItem.GetType().GetProperty(DisplayMember);
                string value = pi.GetValue(SelectItem, null).ToString();
                this.tb.Text = value;
                pop.IsOpen = false;
                e.Handled = true;

                ListViewItem lvi = new ListViewItem();
            }
        }

        /// <summary>
        /// 设置回掉函数
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        public static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TextBoxWithPopup tbp = d as TextBoxWithPopup;
            if (e.Property.Name == "Foreground")
            {
                tbp.tb.Foreground = tbp.Foreground;
            }

            if (e.Property.Name == "FontSize")
            {
                tbp.tb.FontSize = tbp.FontSize;
            }


            if ((e.Property.Name == "DisplayMember" || e.Property.Name == "ItemSource") &
                !string.IsNullOrEmpty(tbp.DisplayMember) & tbp.ItemSource != null)
            {
                IList valueList = (IList)e.NewValue;
                List<ItemModel> items = new List<ItemModel>();

                foreach (var item in valueList)
                {
                    PropertyInfo pi = item.GetType().GetProperty(tbp.DisplayMember);
                    string value = pi.GetValue(item, null).ToString();
                    items.Add(new ItemModel { UnifyDisplay = value, SourceItem = item });
                }
                tbp.lv.ItemsSource = items;

                if (items.Count > 0 & tbp.pop.IsOpen == false)
                {
                    tbp.pop.IsOpen = true;
                    tbp.pop.StaysOpen = false;
                }
            }
        }

        private void tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchText = this.tb.Text;
        }

        private void lv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ItemModel im = this.lv.SelectedItem as ItemModel;
            if (im != null)
            {
                //SelectItem = im.SourceItem;
                //PropertyInfo pi = SelectItem.GetType().GetProperty(DisplayMember);
                //string value = pi.GetValue(SelectItem, null).ToString();
                // this.tb.Text = value;
                // pop.IsOpen = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SearchCommand != null)
            {
                SearchCommand.Execute(tb.Text);
            }
        }
    }
}
