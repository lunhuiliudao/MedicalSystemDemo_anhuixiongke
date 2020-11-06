//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      SignEntryControl.cs
//功能描述(Description)：    补录体征界面
//数据表(Tables)：		    无 
//作者(Author)：             MDSD
//日期(Create Date)：        2017/12/27 09:30
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝=
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.View.InOperation
{
    /// <summary>
    /// SignEntryControl.xaml 的交互逻辑
    /// </summary>
    public partial class SignEntryControl : BaseUserControl
    {
        private bool isFirstIntoCell = false;                                                       // 首次进入单元格
        VitalSignEditorViewModel _vitalSignEditor = null;
        public SignEntryControl()
        {
            InitializeComponent();
            _vitalSignEditor = new VitalSignEditorViewModel();
            if (!ExtendAppContext.Current.IsModify || !ExtendAppContext.Current.IsPermission)
            {
                this.DataGridSign.IsReadOnly = true;
                this.BtnAddPro.Visibility = Visibility.Hidden;
                this.BtnAddSign.Visibility = Visibility.Hidden;
            }
            this.DataContext = _vitalSignEditor;
            this.DataGridSign.Focus();
            this.DataGridSign.SelectedIndex = 0;
            this.RegisterMessage();

        }
        private void RegisterMessage()
        {
            Messenger.Default.Register<dynamic>(this, "SureCommand", msg =>
            {
                _vitalSignEditor.AddVitalSign(msg);
            });
        }

        private void DataGridSign_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
        /// <summary>
        /// isDigit是否是数字 
        /// </summary>
        /// <param name="_string"></param>
        /// <returns></returns>
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

        private void DataGridSign_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            this.isFirstIntoCell = true;
        }

        private void DataGridSign_PreviewKeyUp(object sender, KeyEventArgs e)
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
