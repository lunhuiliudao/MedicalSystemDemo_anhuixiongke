// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      SearchPatientListViewModel.cs
// 功能描述(Description)：    主界面中的搜索框查询的结果列表面板对应的ViewModel
// 数据表(Tables)：		      无
// 作者(Author)：             许文龙
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.AnesWorkStation.Model.WorkListModel;
using MedicalSystem.AnesWorkStation.Wpf.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.ViewModel.WorkListViewModel
{
    public class SearchPatientListViewModel : BaseViewModel
    {
        private List<PatientModel> patientModelList = null;                                        // 当前日期的患者列表
        private int patientModelListCount = 0;                                                     // 搜索结果记录总数
        private ICommand searchCommand = null;                                                     // 搜索命令
        private ICommand searchTextChangedCommand;                                                 // 搜索文本框文本改变命令
        private ICommand showPatientDocCommand;                                                    // 查看文书
        private ICommand selectionChangedCommand;                                                  // 搜索列表切换事件
        private DelegateCommonObject.DelegateParsMethod DelegateCreatePageList = null;             // 异步批量转换列表

        /// <summary>
        /// 患者列表
        /// </summary>
        public List<PatientModel> PatientModelList
        {
            get { return this.patientModelList; }
            set
            {
                this.patientModelList = value;
                this.RaisePropertyChanged("PatientModelList");
            }
        }

        /// <summary>
        /// 搜索结果记录总数
        /// </summary>
        public int PatientModelListCount
        {
            get { return this.patientModelListCount; }
            set
            {
                this.patientModelListCount = value;
                this.RaisePropertyChanged("PatientModelListCount");
            }
        }

        /// <summary>
        /// 搜索命令
        /// </summary>
        public ICommand SearchCommand
        {
            get { return this.searchCommand; }
            set { this.searchCommand = value; }
        }

        /// <summary>
        /// 搜索文本框文本改变命令
        /// </summary>
        public ICommand SearchTextChangedCommand
        {
            get { return this.searchTextChangedCommand; }
            set { this.searchTextChangedCommand = value; }
        }

        /// <summary>
        /// 显示当前选中的患者文书
        /// </summary>
        public ICommand ShowPatientDocCommand
        {
            get { return this.showPatientDocCommand; }
            set { this.showPatientDocCommand = value; }
        }

        /// <summary>
        /// 搜索列表切换事件
        /// </summary>
        public ICommand SelectionChangedCommand
        {
            get { return this.selectionChangedCommand; }
            set { this.selectionChangedCommand = value; }
        }

        /// <summary>
        /// 构造
        /// </summary>
        public SearchPatientListViewModel()
        {
            if (!this.IsInDesignMode)
            {
                this.RegisterMessage();
            }
        }

        /// <summary>
        /// 注册命令
        /// </summary>
        private void RegisterMessage()
        {
            // 搜索命令
            this.SearchCommand = new RelayCommand<dynamic>(key =>
            {
                this.RefreshPatientList(key);
            });

            // 搜索框文本内容更改命令：当文本为空时隐藏列表同时主动释放资源
            this.SearchTextChangedCommand = new RelayCommand<dynamic>(key =>
            {
                this.ResetPatientList(key);
            });

            // 选中其中一项，根据患者状态进入对应的文书命令
            this.ShowPatientDocCommand = new RelayCommand<object>(key =>
            {
                this.ShowPatientDoc(key);
            });

            // 搜索结果列表选中项切换时对应的后台全局变量也要跟随变动
            this.SelectionChangedCommand = new RelayCommand<object>(key =>
            {
                ListBoxItem lbi = null;
                PatientModel pm = null;
                if (key is ListBoxItem)
                {
                    lbi = key as ListBoxItem;
                    pm = lbi.Content as PatientModel;
                }
                else if (key is PatientModel)
                {
                    pm = key as PatientModel;
                }

                if (null == pm)
                {
                    return;
                }

                ExtendAppContext.Current.PatientInformationExtend = pm.Med_Pat_Info;
                this.RefreshPermissions();
                this.UpdateAnesthesiaPlan();
                Messenger.Default.Send<object>(typeof(SearchPatientListViewModel), EnumMessageKey.RefreshSelectedCurPatientInfoBorder);
            });

            // 刷新选中边框
            Messenger.Default.Register<object>(this, EnumMessageKey.RefreshSearchSelectedCurPatientInfoBorder, action =>
            {
                if (!(bool)action && null != this.PatientModelList)
                {
                    List<PatientModel> tempList = this.PatientModelList;
                    this.PatientModelList = null;
                    this.PatientModelList = tempList;
                    this.PatientModelListCount = this.PatientModelList.Count<PatientModel>();
                }
            });
        }

        /// <summary>
        /// 当选中的患者还未入手术室时，判断计划表数据
        /// </summary>
        private void UpdateAnesthesiaPlan()
        {
            if (ExtendAppContext.Current.PatientInformationExtend.OPER_STATUS_CODE < 5)
            {
                bool isChanged = false;
                List<MED_ANESTHESIA_PLAN> anesthesiaPlanList = AnesInfoService.ClientInstance.GetAnesthesiaPlan(ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID,
                                                                                                                ExtendAppContext.Current.PatientInformationExtend.VISIT_ID,
                                                                                                                ExtendAppContext.Current.PatientInformationExtend.OPER_ID);
                MED_ANESTHESIA_PLAN anesthesiaPlanRow = new MED_ANESTHESIA_PLAN();
                if (anesthesiaPlanList.Count > 0)
                {
                    anesthesiaPlanRow = anesthesiaPlanList.First();
                    if (anesthesiaPlanRow.OPERATION_NAME == null || anesthesiaPlanRow.OPERATION_NAME == "")
                    {
                        anesthesiaPlanRow.OPERATION_NAME = ExtendAppContext.Current.PatientInformationExtend.OPERATION_NAME;
                        isChanged = true;
                    }
                    if (anesthesiaPlanRow.ANESTHESIA_METHOD == null || anesthesiaPlanRow.ANESTHESIA_METHOD == "")
                    {
                        anesthesiaPlanRow.ANESTHESIA_METHOD = ExtendAppContext.Current.PatientInformationExtend.ANES_METHOD;
                        isChanged = true;
                    }
                }
                else
                {
                    anesthesiaPlanRow.PATIENT_ID = ExtendAppContext.Current.PatientInformationExtend.PATIENT_ID;
                    anesthesiaPlanRow.VISIT_ID = ExtendAppContext.Current.PatientInformationExtend.VISIT_ID;
                    anesthesiaPlanRow.OPER_ID = ExtendAppContext.Current.PatientInformationExtend.OPER_ID;
                    anesthesiaPlanRow.OPERATION_NAME = ExtendAppContext.Current.PatientInformationExtend.OPERATION_NAME;
                    anesthesiaPlanRow.ANESTHESIA_METHOD = ExtendAppContext.Current.PatientInformationExtend.ANES_METHOD;
                    isChanged = true;
                }
                if (isChanged)
                {
                    AnesInfoService.ClientInstance.UpadteAnesPlanRow(anesthesiaPlanRow);
                }
            }
        }

        /// <summary>
        /// 根据选中患者的手术状态进入对应的文书
        /// </summary>
        private void ShowPatientDoc(object sender)
        {
            ListBoxItem lbi = null;
            PatientModel pm = null;
            if (sender is ListBoxItem)
            {
                lbi = sender as ListBoxItem;
                pm = lbi.Content as PatientModel;
            }
            else if (sender is PatientModel)
            {
                pm = sender as PatientModel;
            }

            if (null == pm)
            {
                return;
            }

            ExtendAppContext.Current.PatientInformationExtend = pm.Med_Pat_Info;
            this.RefreshPermissions();

            var contentType = "LoadReport";
            var windowAnimation = MED_CONSTANT.MA_ZUI_JI_LU;
            var windowType = ContentWindowType.Document;
            var height = SystemParameters.PrimaryScreenHeight;
            var width = SystemParameters.PrimaryScreenWidth;

            if (pm.OperStatusCode >= OperationStatus.InOperationRoom) // 术中及术后
            {

            }
            else // 术前
            {
                contentType = "OperationInformationControl";
                windowAnimation = MED_CONSTANT.OPERATION_INFOMATION;
                windowType = ContentWindowType.Common;
                height = MED_CONSTANT.POPUP_WINDOW_HEIGHT; ;
                width = MED_CONSTANT.POPUP_WINDOW_WIDTH;
            }

            var message = new ShowContentWindowMessage(contentType, windowAnimation);
            message.Height = height;
            message.Width = width;
            message.WindowType = windowType;
            message.Args = new object[] { windowAnimation };
            Messenger.Default.Send<ShowContentWindowMessage>(message);
        }

        /// <summary>
        /// 刷新界面数据
        /// </summary>
        /// <param name="msg">搜索框中的文本信息</param>
        private void RefreshPatientList(dynamic msg)
        {
            DateTime scheduledTime = Convert.ToDateTime(msg.scheduledTime);
            string RoomNo = msg.roomNo;
            string msg1 = msg.inputText;
            // List<MED_PAT_INFO> list = PatInfoService.ClientInstance.GetPatInfos(msg1, ExtendAppContext.Current.OperDeptCode);
            List<MED_PAT_INFO> list = PatInfoService.ClientInstance.GetPatInfosByData(scheduledTime, RoomNo, msg1, ExtendAppContext.Current.OperDeptCode);
            List<MED_OPERATING_ROOM> listOperatingRoom = DictService.ClientInstance.GetOperatingRoomList();
            if (ApplicationConfiguration.IsOpenPatConfirm && this.CheckIsNumberic(msg1) &&
                listOperatingRoom.Find(x => x.ROOM_NO == ExtendAppContext.Current.OperRoomNo).PATIENT_ID == null)
            {
                if (list.Count > 0)
                {
                    var ls = list.GroupBy(x => x.PATIENT_ID);
                    if (ls.Count() == 1)
                    {
                        var item = list.OrderByDescending(x => x.SCHEDULED_DATE_TIME).FirstOrDefault();
                        ShowContentWindowMessage message;
                        message = new ShowContentWindowMessage("PatConfirmControl", "患者核对")
                        {
                            Height = 500,
                            Width = 600,
                            Args = new object[] { PatientModel.CreateModel(item) }
                        };

                        Messenger.Default.Send<ShowContentWindowMessage>(message);
                    }
                }
            }

            this.PatientModelListCount = list.Count;
            // 先转换8条数据
            this.PatientModelList = PatientModel.CreateListModel(list, new EventHandler(this.CreatePageList)).ToList<PatientModel>();
        }

        /// <summary>
        /// 判断信息是否为数字
        /// </summary>
        protected bool CheckIsNumberic(string message)
        {
            System.Text.RegularExpressions.Regex rex = new System.Text.RegularExpressions.Regex(@"^\d+$");
            if (rex.IsMatch(message))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 分页转换
        /// </summary>
        private void CreatePageList(object sender, EventArgs e)
        {
            if (sender is List<MED_PAT_INFO>)
            {
                List<MED_PAT_INFO> list = (List<MED_PAT_INFO>)sender;
                this.DelegateCreatePageList = this.RealCreatePageList;
                this.DelegateCreatePageList.BeginInvoke(new object[] { list }, null, null);
            }
        }

        /// <summary>
        /// 真正开始转换
        /// </summary>
        private void RealCreatePageList(object[] par)
        {
            if (par.Length == 1 && par[0] is List<MED_PAT_INFO>)
            {
                List<MED_PAT_INFO> list = par[0] as List<MED_PAT_INFO>;
                this.PatientModelList = PatientModel.CreateListModel(list).ToList<PatientModel>();
                this.PatientModelListCount = this.PatientModelList.Count;
            }
        }

        /// <summary>
        /// 重置列表
        /// </summary>
        private void ResetPatientList(dynamic msg)
        {
            if (null != this.PatientModelList)
            {
                this.PatientModelList.Clear();
            }

            this.PatientModelListCount = 0;

            // 主动释放资源清空内存
            GC.Collect();
            GC.Collect();
        }

        private void RefreshPermissions()
        {
            if (!ExtendAppContext.Current.LoginUser.isMDSD)
            {
                if (ExtendAppContext.Current.PatientInformationExtend.ANES_DOCTOR == ExtendAppContext.Current.LoginUser.USER_JOB_ID || ExtendAppContext.Current.PatientInformationExtend.ANES_DOCTOR == ExtendAppContext.Current.LoginUser.USER_NAME ||
                    ExtendAppContext.Current.PatientInformationExtend.FIRST_ANES_ASSISTANT == ExtendAppContext.Current.LoginUser.USER_JOB_ID || ExtendAppContext.Current.PatientInformationExtend.FIRST_ANES_ASSISTANT == ExtendAppContext.Current.LoginUser.USER_NAME ||
                    ExtendAppContext.Current.PatientInformationExtend.SECOND_ANES_ASSISTANT == ExtendAppContext.Current.LoginUser.USER_JOB_ID || ExtendAppContext.Current.PatientInformationExtend.SECOND_ANES_ASSISTANT == ExtendAppContext.Current.LoginUser.USER_NAME ||
                    ExtendAppContext.Current.PatientInformationExtend.THIRD_ANES_ASSISTANT == ExtendAppContext.Current.LoginUser.USER_JOB_ID || ExtendAppContext.Current.PatientInformationExtend.THIRD_ANES_ASSISTANT == ExtendAppContext.Current.LoginUser.USER_NAME ||
                    ExtendAppContext.Current.PatientInformationExtend.FOURTH_ANES_ASSISTANT == ExtendAppContext.Current.LoginUser.USER_JOB_ID || ExtendAppContext.Current.PatientInformationExtend.FOURTH_ANES_ASSISTANT == ExtendAppContext.Current.LoginUser.USER_NAME)
                {
                    ExtendAppContext.Current.IsPermission = true;
                }
                else
                {
                    ExtendAppContext.Current.IsPermission = false;
                }
            }
        }
    }
}
