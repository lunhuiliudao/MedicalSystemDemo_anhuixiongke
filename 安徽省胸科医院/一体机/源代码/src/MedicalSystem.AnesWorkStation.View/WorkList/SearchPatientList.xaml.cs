// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      SearchPatientList.xaml.cs
// 功能描述(Description)：    主界面中的搜索结果列表
// 数据表(Tables)：		      无
// 作者(Author)：             许文龙、孙家富
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.ViewModel.WorkListViewModel;
using MedicalSystem.AnesWorkStation.Wpf.Helper;
using System.Windows.Controls;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.View.WorkList
{
    /// <summary>
    /// SearchPatientList.xaml 的交互逻辑
    /// </summary>
    public partial class SearchPatientList : UserControl
    {
        private SearchPatientListViewModel patListVM = null;           // 界面对应的ViewModel

        /// <summary>
        /// 构造方法
        /// </summary>
        public SearchPatientList()
        {
            InitializeComponent();
            this.Focusable = true;
            this.patListVM = new SearchPatientListViewModel();
            this.DataContext = this.patListVM;
        }

        /// <summary>
        /// 判断是否有数据
        /// </summary>
        public bool HasSearchPatientList()
        {
            return this.listBox.Items.Count > 0;
        }

        /// <summary>
        /// 当前选中项是否是第一个
        /// </summary>
        public bool IsFirstPatient()
        {
            bool isFirst = false;
            if (this.patListVM.PatientModelList.Count > 0)
            {
                isFirst = this.listBox.SelectedIndex == 0;
            }

            return isFirst;
        }

        /// <summary>
        /// 当前选中项是否是最后一个
        /// </summary>
        /// <returns></returns>
        public bool IsLastPatient()
        {
            bool isLast = false;
            if (this.patListVM.PatientModelList.Count > 0)
            {
                isLast = this.listBox.SelectedIndex == this.listBox.Items.Count - 1;
            }

            return isLast;
        }

        /// <summary>
        /// 设置第一项选中
        /// </summary>
        public void ResetSearchPatientListFocus(bool isFirst)
        {
            if (this.listBox.Items.Count > 0)
            {
                this.listBox.SelectedItem = isFirst ? this.patListVM.PatientModelList[0] : this.patListVM.PatientModelList[this.patListVM.PatientModelList.Count - 1];
                ExtendAppContext.Current.PatientInformationExtend = isFirst ? this.patListVM.PatientModelList[0].Med_Pat_Info : this.patListVM.PatientModelList[this.patListVM.PatientModelList.Count - 1].Med_Pat_Info;
                this.listBox.Focus();
                this.listBox.SelectedIndex = isFirst ? 0 : this.patListVM.PatientModelList.Count - 1;
                SelectorControlHelper.SetItemFocus(this.listBox, this.listBox.SelectedItem);
            }
        }

        /// <summary>
        /// 响应主界面命令
        /// </summary>
        public void ExecuteCommand(EnumMessageKey messageKey, dynamic msg)
        {
            try
            {
                this.Cursor = Cursors.Wait;
                switch (messageKey)
                {
                    case EnumMessageKey.SearchCommand:
                        if (msg != null)
                        {
                            this.patListVM.SearchCommand.Execute(msg);
                        }

                        break;

                    case EnumMessageKey.SearchTextChangedCommand:
                        this.patListVM.SearchTextChangedCommand.Execute(msg);
                        break;

                    default:
                        break;
                }

                this.Cursor = Cursors.Arrow;
            }
            catch
            {
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }
    }
}
