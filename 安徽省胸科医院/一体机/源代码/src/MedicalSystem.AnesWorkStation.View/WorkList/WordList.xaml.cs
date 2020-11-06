// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      WordList.xaml.cs
// 功能描述(Description)：    工作列表
// 数据表(Tables)：		      无
// 作者(Author)：             许文龙、孙家富
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.ViewModel.WorkListViewModel;
using MedicalSystem.AnesWorkStation.Wpf.Helper;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.View.WorkList
{
    /// <summary>
    /// WordList.xaml 的交互逻辑
    /// </summary>
    public partial class WordList : UserControl
    {
        private WordListViewModel workListVM = null;                     // 界面对应的ViewModel

        /// <summary>
        /// 构造方法
        /// </summary>
        public WordList()
        {
            InitializeComponent();
            this.workListVM = new WordListViewModel();
            this.DataContext = this.workListVM;
            this.RegisterMessage();
            this.Focusable = true;
        }

        /// <summary>
        /// 判断工作列表是否有数据
        /// </summary>
        public bool HasPatientWorkList()
        {
            return this.workListVM.PatientModelList.Count > 0;
        }

        /// <summary>
        /// 设置工作列表默认选中第一项
        /// </summary>
        public void ResetWorkListFocus()
        {
            // 默认选中列表第一个
            if (this.workListVM.PatientModelList.Count > 0)
            {
                workListVM.SelectItem = this.workListVM.PatientModelList[0];
                this.patientCardList.SelectedItem = this.workListVM.PatientModelList[0];
                ExtendAppContext.Current.PatientInformationExtend = this.workListVM.PatientModelList[0].Med_Pat_Info;
                this.patientCardList.Focus();
                this.patientCardList.SelectedIndex = 0;
                SelectorControlHelper.SetItemFocus(this.patientCardList, this.patientCardList.SelectedItem);
            }
        }

        /// <summary>
        /// 当前选中项是否是第一个
        /// </summary>
        public bool IsFirstPatient()
        {
            bool isFirst = false;
            if (this.workListVM.PatientModelList.Count > 0)
            {
                isFirst = this.patientCardList.SelectedIndex == 0 || this.patientCardList.SelectedIndex == 1;
            }

            return isFirst;
        }

        /// <summary>
        /// 获取listIndex
        /// </summary>
        private int GetWorkListIndex(string PatientID, int VisitID, int OperID)
        {
            int index = -1;
            for (int i = 0; i < this.workListVM.PatientModelList.Count; i++)
            {
                if (workListVM.PatientModelList[i].PatientID == PatientID &&
                    workListVM.PatientModelList[i].VisitID == VisitID &&
                    workListVM.PatientModelList[i].OperID == OperID)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        /// <summary>
        /// 注册消息响应
        /// </summary>
        private void RegisterMessage()
        {
            // 刷新背景图片
            Messenger.Default.Register<string>(this, EnumMessageKey.RefreshEnumWorkListType, msg =>
            {
                if (msg.Equals("UnFinishWorkList"))
                {
                    this.UnFinishWorkList.IsChecked = true;
                }
                else if (msg.Equals("FinishWorkList"))
                {
                    this.FinishWorkList.IsChecked = true;
                }
            });

            // 术后患者修改手术进程时间后默认选择当前这个
            Messenger.Default.Register<string>(this, EnumMessageKey.SetWorkListSelectItem, msg =>
            {
                if (workListVM.SelectItem != null)
                {
                    this.patientCardList.SelectedItem = workListVM.SelectItem;
                    this.patientCardList.Focus();
                    this.patientCardList.SelectedIndex = GetWorkListIndex(workListVM.SelectItem.PatientID, workListVM.SelectItem.VisitID, workListVM.SelectItem.OperID);
                    SelectorControlHelper.SetItemFocus(this.patientCardList, this.patientCardList.SelectedItem);
                }
            });

            // 修改手术信息的
            Messenger.Default.Register<object>(this, EnumMessageKey.SetWorkListSelectItem, msg =>
            {
                if (msg is List<object>)
                {
                    List<object> list = msg as List<object>;
                    if (list != null && list.Count == 2)
                    {
                        this.workListVM.SetTodayWorkList(list[1]);
                        MED_OPERATION_MASTER _masterRow = list[0] as MED_OPERATION_MASTER;
                        int index = GetWorkListIndex(_masterRow.PATIENT_ID, _masterRow.VISIT_ID, _masterRow.OPER_ID);
                        if (index >= 0)
                        {
                            this.patientCardList.SelectedIndex = index;
                            this.patientCardList.Focus();
                            workListVM.SelectItem = this.workListVM.PatientModelList[index];
                            SelectorControlHelper.SetItemFocus(this.patientCardList, this.patientCardList.SelectedItem);
                        }
                    }
                }
            });
        }

        /// <summary>
        /// 主界面命令响应
        /// </summary>
        public void ExecuteCommand(EnumMessageKey messageKey, string msg)
        {
            try
            {
                this.Cursor = Cursors.Wait;
                switch (messageKey)
                {
                    case EnumMessageKey.SearchCommand:
                        if (msg != null)
                        {
                            this.workListVM.SearchCommand.Execute(msg);
                        }

                        break;

                    case EnumMessageKey.SearchTextChangedCommand:
                        this.workListVM.SearchTextChangedCommand.Execute(msg);
                        break;

                    case EnumMessageKey.TomorrowSurgeryWorkListCommand:
                        this.workListVM.TomorrowSurgeryWorkListCommand.Execute(msg);
                        break;

                    case EnumMessageKey.WeekSurgeryWorkListCommand:
                        this.workListVM.WeekSurgeryWorkListCommand.Execute(msg);
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
