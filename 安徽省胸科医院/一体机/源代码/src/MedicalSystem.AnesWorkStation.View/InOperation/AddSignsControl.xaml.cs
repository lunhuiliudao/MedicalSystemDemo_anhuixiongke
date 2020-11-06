//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      AddSignsControl.cs
//功能描述(Description)：    添加体征项目界面
//数据表(Tables)：		    无 
//作者(Author)：             MDSD
//日期(Create Date)：        2017/12/27 16:20
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝=
using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel;
using System;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.View.InOperation
{
    /// <summary>
    /// AddSignsControl.xaml 的交互逻辑
    /// </summary>
    public partial class AddSignsControl : BaseUserControl
    {
        AddVitalSignTitleViewModel _addSignTitle = null;
        public AddSignsControl()
        {
            InitializeComponent();
            _addSignTitle = new AddVitalSignTitleViewModel();
            this.DataContext = _addSignTitle;
            this.txtSearch.Focus();
        }

        /// <summary>
        /// 响应按键：方向键：Down
        /// </summary>
        private void txtSearch_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down && this.SignList.Items.Count > 0)
            {
                // 往下进入字典列表
                e.Handled = true;
                this.Dispatcher.BeginInvoke((Action)delegate
                {
                    this.SignList.Focus();
                    this.SignList.SelectedIndex = 0;
                }, System.Windows.Threading.DispatcherPriority.ApplicationIdle);
            }
        }

        /// <summary>
        /// 响应方向键，切换焦点
        /// </summary>
        private void SignList_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up && this.SignList.SelectedIndex == 0)
            {
                e.Handled = true;
                this.txtSearch.Focus();
            }
            else if (e.Key == Key.Enter && null != this.SignList.SelectedItem)
            {
                e.Handled = true;
                this._addSignTitle.SureCommand.Execute(this.SignList.SelectedItem);
            }
        }
    }
}
