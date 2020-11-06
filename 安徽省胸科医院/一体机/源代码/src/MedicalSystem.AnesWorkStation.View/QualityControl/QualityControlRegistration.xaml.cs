using MedicalSystem.AnesWorkStation.ViewModel.QualityControl;
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

namespace MedicalSystem.AnesWorkStation.View.QualityControl
{
    //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    //文件名称(File Name)：      QualityControlRegistration.xaml
    //功能描述(Description)：    麻醉质控View
    //数据表(Tables)：		        
    //作者(Author)：                 MDSD
    //日期(Create Date)：        2017/12/26 14:27:59
    //R1:
    //    修改作者:
    //    修改日期:
    //    修改理由:
    //＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝ 
    public partial class QualityControlRegistration : BaseUserControl
    {
        QualityControlViewModel _qualityViewModel = null;
        public QualityControlRegistration()
        {
            InitializeComponent();
            _qualityViewModel = new QualityControlViewModel();
            this.DataContext = _qualityViewModel;
        }
    }
}
