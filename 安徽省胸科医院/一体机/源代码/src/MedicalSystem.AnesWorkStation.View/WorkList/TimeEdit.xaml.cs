// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      TimeEdit.cs
// 功能描述(Description)：    时间编辑控件
// 数据表(Tables)：		      无
// 作者(Author)：             许文龙、孙家富
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.View.WorkList
{
    /// <summary>
    /// TimeEdit.xaml 的交互逻辑
    /// </summary>
    public partial class TimeEdit : UserControl
    {
        // 依赖属性：时间值 
        public static DependencyProperty timeValProperty = DependencyProperty.Register("TimeVal", 
                                                                                       typeof(string), 
                                                                                       typeof(TimeEdit), 
                                                                                       new PropertyMetadata("00:00", new PropertyChangedCallback(TimeValChanged)));
        // 路由事件：编辑时间
        public static readonly RoutedEvent onEdited = EventManager.RegisterRoutedEvent("OnEdited", 
                                                                                       RoutingStrategy.Bubble, 
                                                                                       typeof(EventHandler<RoutedEventArgs>), 
                                                                                       typeof(TimeEdit));

        /// <summary>
        /// 为事件添加处理程序的接口
        /// </summary>
        public event EventHandler<RoutedEventArgs> OnEdited
        {
            add { base.AddHandler(onEdited, value); }
            remove { base.RemoveHandler(onEdited, value); }
        }

        /// <summary>
        /// 时间值
        /// </summary>
        public string TimeVal
        {
            get { return (string)GetValue(timeValProperty); }
            set { SetValue(timeValProperty, value); }
        }

        /// <summary>
        /// 无参构造
        /// </summary>
        public TimeEdit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 属性更改响应事件
        /// </summary>
        public static void TimeValChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            TimeEdit bar = sender as TimeEdit;
            if (args.Property.Equals(timeValProperty))
            {
                string newVal = args.NewValue.ToString();
                if (newVal.Length == 5)
                {
                    bar.textBox1.Text = newVal.Substring(0, 2);
                    bar.textBox2.Text = newVal.Substring(3, 2);
                }

                RoutedEventArgs e = new RoutedEventArgs(onEdited, bar);
                bar.RaiseEvent(e);
            }
        }

        /// <summary>
        /// 按键响应事件，定位焦点
        /// </summary>
        private void Tb_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null)
            {
                tb.Focus();
                e.Handled = true;
            }
        }

        /// <summary>
        /// 文本框获得焦点事件，默认选中文本框中的值，同时解除按键事件
        /// </summary>
        private void Tb_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender != null)
            {
                TextBox tbx = sender as TextBox;
                tbx.SelectAll();
                tbx.PreviewMouseDown -= new MouseButtonEventHandler(Tb_PreviewMouseDown);
            }
        }

        /// <summary>
        /// 文本框丢失焦点时绑定按键事件
        /// </summary>
        private void Tb_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null)
            {
                tb.PreviewMouseDown += new MouseButtonEventHandler(Tb_PreviewMouseDown);
            }

            if (!tb.Text.Contains('-'))
            {
                int i_value = GetNum(tb); //单数  补零,如 9  ->  09
                if (i_value >= 0)
                {
                    tb.Text = FormatNum(i_value); //补零
                }
                TimeVal = textBox1.Text + ":" + textBox2.Text;
            }
        }

        /// <summary>
        /// 获取文本框中的数值
        /// </summary>
        private int GetNum(TextBox tbox)
        {
            string val = tbox.Text.Trim();
            int outNum = -1;
            Int32.TryParse(val, out outNum);
            return outNum;
        }

        /// <summary>
        /// 数值补零，满足时间格式
        /// </summary>
        private string FormatNum(int num)
        {
            string i_str = "  ";
            if (num >= 0 && (num <= 9))
            {
                i_str = "0" + num.ToString();
            }
            else
            {
                i_str = num.ToString();
            }

            return i_str;
        }

        /// <summary>
        /// 按键弹起事件：根据录入的值显示
        /// </summary>
        private void Tb_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox tb = sender as TextBox;
            string ss = tb.Text;
            if (!ss.Contains('-'))
            {
                if (ss.Length > 2)
                {
                    tb.Text = ss.Substring(ss.Length - 2, 2); //取后两位 
                    tb.SelectAll();
                    tb.SelectionStart = 0;

                    if (tb.Name == "textBox1")
                    {
                        textBox2.Focus();
                    }
                }
                else if (ss.Length == 2)
                {
                    tb.SelectAll();
                    tb.SelectionStart = 0;
                    if (tb.Name == "textBox1")
                    {
                        textBox2.Focus();
                    }
                }
                else if (ss.Length == 1)
                {
                    tb.SelectAll();
                    tb.SelectionStart = 1;
                }
            }

            if (textBox1.Text.Length == 2 && textBox2.Text.Length == 2)
            {
                TimeVal = textBox1.Text + ":" + textBox2.Text;
            }
        }

        /// <summary>
        /// 按键按下事件:屏蔽掉非法字符
        /// </summary>
        private void Tb_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;

            //屏蔽非法按键
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || e.Key == Key.Decimal || e.Key.ToString() == "Tab" || e.Key == Key.Subtract)
            {
                if ((txt.Text.Contains(".") && e.Key == Key.Decimal) || e.Key == Key.Subtract)
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
            else if (((e.Key >= Key.D0 && e.Key <= Key.D9)) && e.KeyboardDevice.Modifiers != ModifierKeys.Shift)
            {
                if (txt.Text.Contains(".") || txt.Text.Contains("-"))
                {
                    e.Handled = true;
                    return;
                }
                e.Handled = false;
            }
            else if (e.Key == Key.OemPeriod) //按下 句点 键
            {
                if (txt.Name == "textBox1") //小时 处 按下 句点键 时 切换到 分钟处，如果小时小于10 ，则前补零
                {
                    if (!txt.Text.Contains('-'))
                    {
                        txt.Text = FormatNum(GetNum(txt));
                    }
                    textBox2.Focus();
                    e.Handled = true;
                }
            }
            else if (e.Key == Key.OemMinus)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 文本框TextChanged事件：屏蔽非法字符
        /// </summary>
        private void Tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            //屏蔽中文输入和非法字符粘贴输入
            TextBox textBox = sender as TextBox;
            TextChange[] change = new TextChange[e.Changes.Count];
            e.Changes.CopyTo(change, 0);

            int offset = change[0].Offset;
            if (change[0].AddedLength > 0)
            {
                double num = 0;
                if (textBox.Text.Contains('-'))  //不屏蔽 - 键盘
                {
                    return;
                }
                else if (!Double.TryParse(textBox.Text, out num))
                {
                    textBox.Text = textBox.Text.Remove(offset, change[0].AddedLength);
                    textBox.Select(offset, 0);
                }
            }
        }

        /// <summary>
        /// 鼠标滚轮事件：快速更改文本框中的数值
        /// </summary>
        private void Tb_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            TextBox tbox = sender as TextBox;
            if (e.Delta > 0)  //滚轮向上，减小
            {
                int i_num = GetNum(tbox);
                if (i_num > 0)
                {
                    int i_new = i_num - 1;
                    tbox.Text = FormatNum(i_new);
                }
                else if (i_num == 0) //滚动到零了，则更改为最大值
                {
                    string tboxName = tbox.Name;
                    if (tboxName == "textBox1")
                    {
                        tbox.Text = "23";
                    }
                    else if (tboxName == "textBox2")
                    {
                        tbox.Text = "59";
                    }
                }
            }
            else if (e.Delta < 0)  //滚轮向下，增大 
            {
                int i_num = GetNum(tbox);
                string tboxName = tbox.Name;

                int i_new = i_num;
                if (tboxName == "textBox1")
                {
                    if (i_num <= 22)
                    {
                        i_new = i_num + 1;
                    }
                    else if (i_num == 23)
                    {
                        i_new = 0; //到24，更改为0
                    }
                    else
                    {
                        i_new = i_num;
                    }
                }
                else if (tboxName == "textBox2")
                {
                    if (i_num <= 58)
                    {
                        i_new = i_num + 1;
                    }
                    else if (i_num == 59)
                    {
                        i_new = 0; //到59，更改为0
                    }
                    else
                    {
                        i_new = i_num;
                    }
                }
                tbox.Text = FormatNum(i_new);
            }

            TimeVal = textBox1.Text + ":" + textBox2.Text;
        }
    }
}
