//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      SignMakeupControl.cs
//功能描述(Description)：    体征录入界面
//数据表(Tables)：		    无 
//作者(Author)：             MDSD
//日期(Create Date)：        2017/12/27 09:30
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝=
using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel;
using MedicalSystem.AnesWorkStation.Wpf.Themes.Default;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.View.InOperation
{
    /// <summary>
    /// SignMakeupControl.xaml 的交互逻辑
    /// </summary>
    public partial class SignMakeupControl : BaseUserControl
    {
        private bool isFirstIntoCell = false;                                                       // 首次进入单元格
        private RecordVitalSignViewModel _recordVitalSign;
        public SignMakeupControl()
        {
            InitializeComponent();
            _recordVitalSign = new RecordVitalSignViewModel();
            this.DataContext = _recordVitalSign;
            this.StartTime.Focus();
        }

        private void EndTime_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // 往右进入表格
                e.Handled = true;
                this.SignDataGrid.Focus();
                this.SignDataGrid.SelectedIndex = 0;
                // 焦点定位到第一行的开始时间单元格
                DataGridCell timeCell = DataGridStyle.GetCell(this.SignDataGrid, 0, 1);
                if (timeCell != null)
                {
                    this.SignDataGrid.CurrentCell = new DataGridCellInfo(timeCell);
                    this.SignDataGrid.BeginEdit();
                }
            }
        }

        private void StartTime_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.EndTime.Focus();
            }
        }

        private void SignDataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            DataGridCellInfo curCellInfo = this.SignDataGrid.CurrentCell;
            this.isFirstIntoCell = true;
        }

        /// <summary>
        /// isDigit是否是数字 
        /// </summary>
        public static bool isNumberic(string _string)
        {
            bool isDigit = true;
            int newInteger = 0;
            float newdecimal = 0;
            if (((!int.TryParse(_string, out newInteger) || newInteger < 0) &&
               (!float.TryParse(_string, out newdecimal) || newdecimal < 0))
               && _string != "")
            {
                isDigit = false;
            }
            if (_string.Length > 6)
            {
                isDigit = false;
            }

            return isDigit;
        }

        private void SignDataGrid_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            TextBox tb = e.OriginalSource as TextBox;
            string text = tb == null ? "" : tb.Text;

            if (!isNumberic(text))
            {
                e.Handled = true;
                return;
            }
            else
            {
                e.Handled = false;
            }

            bool isFirstInto = isFirstIntoCell;
            if (this.isFirstIntoCell)
            {
                this.isFirstIntoCell = false;
            }

            if (text.LastIndexOf('.') != text.Length - 1 && tb != null)
            {
                BindingExpression be = tb.GetBindingExpression(TextBox.TextProperty);
                be.UpdateSource();
            }
        }
    }
}
