//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      AnesthesiaPathControl.cs
//功能描述(Description)：    麻醉路径
//数据表(Tables)：		    无
//作者(Author)：             MDSD
//日期(Create Date)：        2017/12/27 16:20
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝=
using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.AnesthesiaPathViewModel;
using MedicalSystem.AnesWorkStation.Wpf.Controls.TreeView;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MedicalSystem.AnesWorkStation.View.InOperation
{
    /// <summary>
    /// AnesthesiaPathControl.xaml 的交互逻辑
    /// </summary>
    public partial class AnesthesiaPathControl : BaseUserControl
    {
        private AnesthesiaPathViewModel anesPathViewModel = null;

        public AnesthesiaPathControl()
        {
            InitializeComponent();
            this.anesPathViewModel = new AnesthesiaPathViewModel();
            this.DataContext = this.anesPathViewModel;
        }

        /// <summary>
        /// 删除事件
        /// </summary>
        private void ButtonDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            int rowIndex = this.datagrid.SelectedIndex;
            this.anesPathViewModel.DeleteTemplate(this.datagrid.SelectedItem);
        }

        private void TreeView_PreviewMouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            TreeViewItem treeViewItem = VisualUpwardSearch<TreeViewItem>(e.OriginalSource as DependencyObject) as TreeViewItem;
            if (treeViewItem != null)
            {
                treeViewItem.Focus();
                e.Handled = true;
                this.anesPathViewModel.TreeViewItemClickCommand.Execute(this.treeView.SelectedItem);

                TreeNode node = this.treeView.SelectedItem as TreeNode;
                if (null != node && node.Level == 4 && null != node.Parent &&
                    null != node.Parent.Parent && node.Parent.Parent.Label.Equals("私有"))
                {
                    MenuItem item = new MenuItem();
                    item.Click += delegate (object t, RoutedEventArgs es)
                    {
                        this.anesPathViewModel.TreeViewItemDeleteCommand.Execute(node);
                    };
                    item.Header = "删除";
                    ContextMenu men = new ContextMenu();
                    men.Items.Add(item);
                    this.treeView.ContextMenu = men;
                }
                else
                {
                    this.treeView.ContextMenu = null;
                }
            }
        }

        static DependencyObject VisualUpwardSearch<T>(DependencyObject source)
        {
            while (source != null && source.GetType() != typeof(T))
                source = VisualTreeHelper.GetParent(source);

            return source;
        }

    }
}
