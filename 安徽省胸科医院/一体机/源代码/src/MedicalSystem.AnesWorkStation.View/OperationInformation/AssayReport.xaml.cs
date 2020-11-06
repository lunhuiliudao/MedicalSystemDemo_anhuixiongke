using MedicalSystem.Anes.FrameWork;
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
    /// AssayReport.xaml 的交互逻辑
    /// </summary>
    public partial class AssayReport : BaseUserControl
    {
        private AssayReportViewModel assayReportViewModel = null;

        public AssayReport()
        {
            InitializeComponent();
            this.assayReportViewModel = new AssayReportViewModel(ExtendAppContext.Current.PatientInformationExtend);
            this.DataContext = this.assayReportViewModel;
        }
    }
}
