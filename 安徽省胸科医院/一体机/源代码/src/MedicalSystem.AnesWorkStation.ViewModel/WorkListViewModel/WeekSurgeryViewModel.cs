// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      WeekSurgeryViewModel.cs
// 功能描述(Description)：    一周手术面板对应的ViewModel
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
using MedicalSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.ViewModel.WorkListViewModel
{
    public class WeekSurgeryViewModel : BaseViewModel
    {
        /// <summary>
        /// 一周手术信息实体类
        /// </summary>
        private WeekSurgeryModel weekSurgeryModel = new WeekSurgeryModel();

        /// <summary>
        /// 异步调用
        /// </summary>
        private DelegateCommonObject.DelegateMethod DelegateRefreshWeekSurgery = null;

        /// <summary>
        /// 一周手术信息实体类
        /// </summary>
        public WeekSurgeryModel WeekSurgeryModelProperty
        {
            get { return this.weekSurgeryModel; }
            set { this.weekSurgeryModel = value; }
        }

        /// <summary>
        /// 切换到明日手术工作列表
        /// </summary>
        public ICommand WeekSurgeryWorkListCommand
        {
            get
            {
                return new RelayCommand<string>(key =>
                {
                    // 命令响应的函数是在MainWindow中定义
                    Messenger.Default.Send<string>(key, EnumMessageKey.WeekSurgeryWorkListCommand);
                });
            }
        }

        /// <summary>
        /// 无参构造方法
        /// </summary>
        public WeekSurgeryViewModel()
        {
            if (!IsInDesignMode)
            {
                this.RefreshData();
                this.RegisterMessage();
            }
        }

        /// <summary>
        /// 注册响应消息
        /// </summary>
        private void RegisterMessage()
        {
            // 刷新整个界面
            Messenger.Default.Register<object>(this, EnumMessageKey.RefreshWeekSurgery, msg =>
            {
                if (null == this.DelegateRefreshWeekSurgery)
                {
                    this.DelegateRefreshWeekSurgery = this.RefreshData;
                }

                this.DelegateRefreshWeekSurgery.BeginInvoke(null, null);
            });
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        public void RefreshData()
        {
            try
            {
                List<MED_PAT_INFO> list = PatInfoService.ClientInstance.GetPatientInfosInWeek(DateTime.Now.AddDays(-6.0), 
                                                                                              DateTime.Now.AddDays(1.0), 
                                                                                              ExtendAppContext.Current.OperDeptCode, 
                                                                                              ExtendAppContext.Current.OperRoomNo);
                this.weekSurgeryModel.AllSurgeryNum = list.Where<MED_PAT_INFO>(x => x.OPER_STATUS_CODE >= 35).Count();
                IEnumerable<MED_PAT_INFO> tempList = list.Where<MED_PAT_INFO>(x => x.OPER_STATUS_CODE >= 35 && string.IsNullOrEmpty(x.ANES_DOCTOR));
                this.weekSurgeryModel.MySurgeryNum = tempList.Count<MED_PAT_INFO>();
            }
            catch (Exception ex)
            {
                Logger.Error("刷新一周手术汇总信息异常：", ex);
                this.ShowMessageBox("刷新一周手术汇总信息异常！", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
