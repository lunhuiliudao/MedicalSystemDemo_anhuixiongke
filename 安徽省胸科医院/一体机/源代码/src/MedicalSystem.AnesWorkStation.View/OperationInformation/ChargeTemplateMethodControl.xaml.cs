using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.OperationInformationViewModel;
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

namespace MedicalSystem.AnesWorkStation.View.OperationInformation
{
    /// <summary>
    /// ChargeTemplateMethodControl.xaml 的交互逻辑
    /// </summary>
    public partial class ChargeTemplateMethodControl : BaseUserControl
    {
        private ChargeTemplateMethodViewModel chargeTemplateMethod = null;                            // 界面对应的ViewModel         

        /// <summary>
        /// 无参构造
        /// </summary> 
        public ChargeTemplateMethodControl()
        {
            InitializeComponent();
            this.chargeTemplateMethod = new ChargeTemplateMethodViewModel();
            this.DataContext = this.chargeTemplateMethod;
        }
    }
}
