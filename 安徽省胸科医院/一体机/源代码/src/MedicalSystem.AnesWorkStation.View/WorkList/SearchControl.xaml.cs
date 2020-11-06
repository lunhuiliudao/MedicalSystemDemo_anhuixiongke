// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      SearchControl.xaml.cs
// 功能描述(Description)：    主界面中的搜索框控件
// 数据表(Tables)：		      无
// 作者(Author)：             许文龙、孙家富
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.ViewModel.WorkListViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.View.WorkList
{
    /// <summary>
    /// SearchControl.xaml 的交互逻辑
    /// </summary>
    public partial class SearchControl : UserControl
    {
        /// <summary>
        /// 搜索命令
        /// </summary>
        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand<dynamic>(key =>
                {
                    searchViewModel.SendSearchCommand();
                });
            }
        }

        /// <summary>
        /// 文本改变事件，当文本框内容为空时自动还原
        /// </summary>
        public ICommand SearchTextChangedCommand
        {
            get
            {
                return new RelayCommand<dynamic>(key =>
                {
                    searchViewModel.SendSearchTextChangedCommand();
                    //dynamic result = new { inputText = this._inputText.Text.Trim(), scheduledTime = this.ScheduledTime.SelectedDate.Value.Date, roomNo = this.OperRoom.Text.Trim() };
                    //Messenger.Default.Send<dynamic>(result, EnumMessageKey.SearchTextChangedCommand);
                });
            }
        }
        private SearchViewModel searchViewModel = null;
        /// <summary>
        /// 构造方法
        /// </summary>
        public SearchControl()
        {
            InitializeComponent();
            this.searchViewModel = new SearchViewModel();
            this.DataContext = this.searchViewModel;
        }

        /// <summary>
        /// 响应回车按键
        /// </summary>
        public void InputText_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                searchViewModel.SendSearchCommand();
                //object result = new { inputText = this._inputText.Text.Trim(), scheduledTime = this.ScheduledTime.SelectedDate.Value.Date, roomNo = this.OperRoom.Text.Trim() };
                //Messenger.Default.Send<dynamic>(result, EnumMessageKey.SearchCommand);
            }
        }

        /// <summary>
        /// 设置焦点
        /// </summary>
        public void InputText_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!this._inputText.IsFocused)
            {
                this._inputText.Focus();
            }

            this.showInfo.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void InputText_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this._inputText.Text.Trim()))
            {
                this.showInfo.Visibility = Visibility;
                searchViewModel.SendSearchTextChangedCommand();
                //object result = new { inputText = this._inputText.Text.Trim(), scheduledTime = this.ScheduledTime.SelectedDate.Value.Date, roomNo = this.OperRoom.Text.Trim() };
                //Messenger.Default.Send<dynamic>(result, EnumMessageKey.SearchTextChangedCommand);
            }
        }
    }
}
