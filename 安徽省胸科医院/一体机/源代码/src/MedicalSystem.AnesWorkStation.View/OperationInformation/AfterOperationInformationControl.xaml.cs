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
    //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    //文件名称(File Name)：      AfterOperationInformationControl.xaml
    //功能描述(Description)：    术后登记View
    //数据表(Tables)：		       
    //作者(Author)：            MDSD
    //日期(Create Date)：        2017/12/26 14:27:59
    //R1:
    //    修改作者:
    //    修改日期:
    //    修改理由:
    //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝  
    public partial class AfterOperationInformationControl : BaseUserControl
    {
        OperInfoViewModel _operInfoViewModel;

        public AfterOperationInformationControl()
        {
            InitializeComponent();
            _operInfoViewModel = new OperInfoViewModel(true);
            this.DataContext = _operInfoViewModel;
        }
    }
}
