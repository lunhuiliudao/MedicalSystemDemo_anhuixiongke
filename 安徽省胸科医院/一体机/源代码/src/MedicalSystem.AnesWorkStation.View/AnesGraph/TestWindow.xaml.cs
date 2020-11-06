using MedicalSystem.AnesWorkStation.Model.AnesGraphModel;
using MedicalSystem.AnesWorkStation.Model.InOperationModel;
using MedicalSystem.AnesWorkStation.ViewModel;
using MedicalSystem.AnesWorkStation.ViewModel.AnesGraphViewModel;
using MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel;
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
using System.Windows.Shapes;

namespace MedicalSystem.AnesWorkStation.View.AnesGraph
{
    /// <summary>
    /// TestWindow.xaml 的交互逻辑
    /// </summary>
    public partial class TestWindow : WindowBase
    {
        public TestWindow()
        {
            InitializeComponent();
            this.DataContext = new TestViewModel();
            // this.DataContext = new DrugGraphViewModel();
            graph1.MoveXAxisAction = (sender, xMove) =>
            {
                dateAxis1.MoveXAxis(xMove);
                VitalSignsControl1.MoveXAxis(xMove);
            };
            VitalSignsControl1.MoveXAxisAction = (sender, xMove) =>
            {
                dateAxis1.MoveXAxis(xMove); 
                graph1.MoveXAxis(xMove);
                               
            };
            dateAxis1.DrawTimeProcessAction = (time) =>
            {
                graph1.DrawTimeProcess(time);
                VitalSignsControl1.DrawTimeProcess(time);
            };
        }
    }
}
