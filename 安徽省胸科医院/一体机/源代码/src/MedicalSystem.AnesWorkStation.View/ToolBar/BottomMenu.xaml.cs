using MedicalSystem.AnesWorkStation.View;
using MedicalSystem.AnesWorkStation.ViewModel.ToolBarViewModel;
using MedicalSystem.AnesWorkStation.Wpf.Helper;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MedicalSystem.AnesWorkStation.View.ToolBar
{
    /// <summary>
    /// BottomMenu.xaml 的交互逻辑
    /// </summary>
    public partial class BottomMenu : BaseUserControl
    {
        BottomMenuViewModel _bottomMenuViewModel;

        public BottomMenu()
        {
            InitializeComponent();
            _bottomMenuViewModel = new BottomMenuViewModel();
            this.DataContext = _bottomMenuViewModel;
            this.rbDocList.Focus();
        }

        /// <summary>
        /// 响应方向键切换焦点
        /// </summary>
        private void StackPanel_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if(e.Key == Key.Down)
            {
                this.rbFunList.IsChecked = true;
            }
            else if(e.Key == Key.Up)
            {
                this.rbDocList.IsChecked = true;
            }
            else if (e.Key == Key.Right && this.lbMenuControl.Items.Count > 0)
            {
                this.lbMenuControl.Focus();
                this.lbMenuControl.SelectedIndex = 0;
                SelectorControlHelper.SetItemFocus(this.lbMenuControl, this.lbMenuControl.SelectedItem);
            }
        }

        /// <summary>
        /// 响应按键
        /// </summary>
        private void LbMenuControl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && null != this.lbMenuControl.SelectedItem)
            {
                // 响应回车键
                e.Handled = true;
                this._bottomMenuViewModel.ChooseCommand.Execute(this.lbMenuControl.SelectedItem);
            }
            else if (e.Key == Key.Left && (this.lbMenuControl.SelectedIndex == 0 || this.lbMenuControl.SelectedIndex == 5))
            { 
                // 回到左侧的菜单类型：文书菜单、功能菜单
                e.Handled = true;
                this.lbMenuControl.SelectedIndex = -1;
                this.rbDocList.Focus();
            }
        }
    }
}
