using MedicalSystem.AnesWorkStation.Domain;
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
    /// RadioButtonList.xaml 的交互逻辑
    /// </summary>
    public partial class RadioButtonList : UserControl
    {
        public RadioButtonList()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 数据集
        /// </summary>
        public IList ItemsSource
        {
            get { return (IList)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IList), typeof(RadioButtonList), new PropertyMetadata(null, new PropertyChangedCallback(PropertyChangedCallback)));


        /// <summary>
        /// 选中的项目
        /// </summary>
        public object SelectItem
        {
            get { return (object)GetValue(SelectItemProperty); }
            set { SetValue(SelectItemProperty, value); }
        }

        public static readonly DependencyProperty SelectItemProperty =
            DependencyProperty.Register("SelectItem", typeof(object), typeof(RadioButtonList), new PropertyMetadata(null));


        /// <summary>
        /// 用于显示的字段
        /// </summary>
        public string DisplayMember
        {
            get { return (string)GetValue(DisplayMemberProperty); }
            set { SetValue(DisplayMemberProperty, value); }
        }

        public static readonly DependencyProperty DisplayMemberProperty =
            DependencyProperty.Register("DisplayMember", typeof(string), typeof(RadioButtonList), new PropertyMetadata(""));
        

        public static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RadioButtonList rb = d as RadioButtonList;
            if (e.NewValue != null & !string.IsNullOrEmpty(rb.DisplayMember) &
                (e.Property.Name == "DisplayMember" || e.Property.Name == "ItemsSource"))
            {
                IList valueList = (IList)e.NewValue;
                List<ItemModel> items = new List<ItemModel>();

                foreach (var item in valueList)
                {
                    PropertyInfo pi = item.GetType().GetProperty(rb.DisplayMember);
                    string value = pi.GetValue(item, null).ToString();
                    items.Add(new ItemModel { UnifyDisplay = value, SourceItem = item });
                }
                rb.lb.ItemsSource = items;
            }

            if (e.Property.Name == "SelectItem" & e.NewValue != null)
            {
                rb.lb.SelectedItem = e.NewValue;
            }
        }

        private void lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ItemModel im = this.lb.SelectedItem as ItemModel;
            SelectItem = im.SourceItem;
        }
    }

    public class ItemModel:BaseModel
    {
        public object SourceItem { get; set; }
    }
}
