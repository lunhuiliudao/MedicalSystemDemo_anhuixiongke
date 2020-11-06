// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      TodaySurgeryViewModel.cs
// 功能描述(Description)：    今日手术面板对应的ViewModel
// 数据表(Tables)：		      无
// 作者(Author)：             许文龙
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight.Messaging;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model;
using MedicalSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace MedicalSystem.AnesWorkStation.ViewModel.WorkListViewModel
{
    public class TodaySurgeryViewModel : BaseViewModel
    {
        /// <summary>
        /// 今日手术实体模型 
        /// </summary>
        private TodaySurgeryModel todaySurgeryModel = new TodaySurgeryModel();

        /// <summary>
        /// 异步刷新
        /// </summary>
        private MedicalSystem.Anes.FrameWork.DelegateCommonObject.DelegateMethod DelegateRefreshTodaySurgery = null;

        /// <summary>
        /// 今日手术实体模型
        /// </summary>
        public TodaySurgeryModel TodaySurgeryModelProperty
        {
            get { return this.todaySurgeryModel; }
            set { this.todaySurgeryModel = value; }
        }

        /// <summary>
        /// 构造方法：初始化数据
        /// </summary>
        public TodaySurgeryViewModel()
        {
            // 非设计模式下
            if (!IsInDesignMode)
            {
                this.RefreshData();
                this.RegisterMessage();
            }
        }

        /// <summary>
        /// 注销响应消息
        /// </summary>
        private void RegisterMessage()
        {
            // 异步刷新整个界面
            Messenger.Default.Register<object>(this, EnumMessageKey.RefreshTodaySurgery, msg =>
            {
                if (null == this.DelegateRefreshTodaySurgery)
                {
                    this.DelegateRefreshTodaySurgery = this.RefreshData;
                }

                this.DelegateRefreshTodaySurgery.BeginInvoke(null, null);
            });
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        private void RefreshData()
        {
            try
            {
                List<MED_PAT_INFO> list = PatInfoService.ClientInstance.GetPatientInfosByDateTime(DateTime.Now,
                                                                                                  ExtendAppContext.Current.OperDeptCode,
                                                                                                  ExtendAppContext.Current.OperRoomNo);
                if (null != list)
                {
                    IEnumerable<MED_PAT_INFO> finList = from patInfo in list where patInfo.OPER_STATUS_CODE >= 35 select patInfo;
                    IEnumerable<MED_PAT_INFO> unFinList = from patInfo in list where patInfo.OPER_STATUS_CODE < 35 select patInfo;
                    this.todaySurgeryModel.TodaySurgeryNum = list.Count;
                    this.todaySurgeryModel.FinishSurgeryNum = finList.Count<MED_PAT_INFO>();
                    this.todaySurgeryModel.UnFinishSurgeryNum = unFinList.Count<MED_PAT_INFO>();
                    this.todaySurgeryModel.FinishPercent = (finList.Count<MED_PAT_INFO>() * 1.0) / (list.Count * 1.0);
                }
            }
            catch(Exception ex)
            {
                Logger.Error("刷新今日手术汇总信息异常：", ex);
                this.ShowMessageBox("刷新今日手术汇总信息异常！", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
