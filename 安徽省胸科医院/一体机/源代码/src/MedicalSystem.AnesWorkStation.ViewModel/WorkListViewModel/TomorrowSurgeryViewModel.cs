// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      TomorrowSurgeryViewModel.cs
// 功能描述(Description)：    明日手术面板对应的ViewModel
// 数据表(Tables)：		      无
// 作者(Author)：             许文龙
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using MedicalSystem.AnesWorkStation.Model.WorkListModel;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using MedicalSystem.AnesWorkStation.Model;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.Services;
using System.Windows;

namespace MedicalSystem.AnesWorkStation.ViewModel.WorkListViewModel
{
    public class TomorrowSurgeryViewModel : BaseViewModel
    {
        /// <summary>
        /// 明日手术信息汇总实体类
        /// </summary>
        private TomorrowSurgeryModel tomorrowSurgeryModel = new TomorrowSurgeryModel();

        /// <summary>
        /// 异步刷新
        /// </summary>
        private DelegateCommonObject.DelegateMethod DelegateRefreshTomorrowSurgery = null;

         /// <summary>
        /// 明日手术信息汇总实体类
        /// </summary>
        public TomorrowSurgeryModel TomorrowSurgeryModelProperty
        {
            get { return this.tomorrowSurgeryModel; }
            set { this.tomorrowSurgeryModel = value; }
        }

        /// <summary>
        /// 切换到明日手术工作列表
        /// </summary>
        public ICommand TomorrowSurgeryWorkListCommand
        {
            get
            {
                return new RelayCommand<string>(key =>
                {
                    // 命令响应的函数是在MainWindow中定义
                    Messenger.Default.Send<string>(key, EnumMessageKey.TomorrowSurgeryWorkListCommand);
                });
            }
        }

        /// <summary>
        /// 无参构造
        /// </summary>
        public TomorrowSurgeryViewModel()
        {
            if (!IsInDesignMode)
            {
                this.RefreshData();
                this.RegisterMessage();
            }
        }

        /// <summary>
        /// 注册消息响应
        /// </summary>
        private void RegisterMessage()
        {
            // 异步刷新整个界面
            Messenger.Default.Register<object>(this, EnumMessageKey.RefreshTomorrowSurgery, msg =>
            {
                if (null == this.DelegateRefreshTomorrowSurgery)
                {
                    this.DelegateRefreshTomorrowSurgery = this.RefreshData;
                }

                this.DelegateRefreshTomorrowSurgery.BeginInvoke(null, null);
            });
        }

        /// <summary>
        /// 数据刷新
        /// </summary>
        public void RefreshData()
        {
            try
            {
                List<MED_PAT_INFO> list = PatInfoService.ClientInstance.GetPatientInfosByDateTime(DateTime.Now.AddDays(1.0), 
                                                                                                  ExtendAppContext.Current.OperDeptCode, 
                                                                                                  ExtendAppContext.Current.OperRoomNo);
                this.tomorrowSurgeryModel.AllSurgeryNum = list.Count;
                if (null != list)
                {
                    IEnumerable<MED_PAT_INFO> myList = list.Where<MED_PAT_INFO>(x => (!string.IsNullOrEmpty(x.ANES_DOCTOR) && x.ANES_DOCTOR.Equals(ExtendAppContext.Current.LoginUser.USER_JOB_ID)) ||
                                                                                     (!string.IsNullOrEmpty(x.FIRST_ANES_ASSISTANT) && x.FIRST_ANES_ASSISTANT.Equals(ExtendAppContext.Current.LoginUser.USER_JOB_ID)) ||
                                                                                     (!string.IsNullOrEmpty(x.SECOND_ANES_ASSISTANT) && x.SECOND_ANES_ASSISTANT.Equals(ExtendAppContext.Current.LoginUser.USER_JOB_ID)) ||
                                                                                     (!string.IsNullOrEmpty(x.THIRD_ANES_ASSISTANT) && x.THIRD_ANES_ASSISTANT.Equals(ExtendAppContext.Current.LoginUser.USER_JOB_ID)) ||
                                                                                     (!string.IsNullOrEmpty(x.FOURTH_ANES_ASSISTANT) && x.FOURTH_ANES_ASSISTANT.Equals(ExtendAppContext.Current.LoginUser.USER_JOB_ID)));
                    this.tomorrowSurgeryModel.MySurgeryNum = myList.Count<MED_PAT_INFO>();
                }
            }
            catch (Exception ex)
            {
                Logger.Error("刷新明日手术汇总信息异常：", ex);
                this.ShowMessageBox("刷新明日手术汇总信息异常！", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
