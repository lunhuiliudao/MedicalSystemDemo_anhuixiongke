//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      AssayReportViewModel.cs
//功能描述(Description)：    检验信息
//数据表(Tables)：		      
//作者(Author)：                 MDSD
//日期(Create Date)：         2017-12-26 15:57:48
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

using GalaSoft.MvvmLight.CommandWpf;
using MedicalSystem.Anes.FrameWork;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
namespace MedicalSystem.AnesWorkStation.ViewModel.InOperationViewModel.OperationInformationViewModel
{
    /// <summary>
    /// Defines the <see cref="AssayReportViewModel" />
    /// </summary>
    public class AssayReportViewModel : BaseViewModel
    {
        #region 声明变量

        /// <summary>
        /// 一次性获取当前患者的所有检验信息明细
        /// </summary>
        private List<MED_LAB_RESULT> curPatAllResult = null;

        /// <summary>
        /// 刷新数据锁
        /// </summary>
        private object locker = new object();

        /// <summary>
        /// 检验结果明细信息
        /// </summary>
        private List<MED_LAB_RESULT> medLabResult = null;

        /// <summary>
        /// 检验结果主信息
        /// </summary>
        private List<MED_LAB_TEST_MASTER> medLabTestMaster = null;

        /// <summary>
        /// 当前检验信息的患者信息
        /// </summary>
        private MED_PAT_INFO medPatInfo = null;

        /// <summary>
        /// 根据选中的主信息显示对应的明细信息
        /// </summary>
        private ICommand showResultDetailCommon = null;

        /// <summary>
        /// 检验结果明细信息
        /// </summary>
        public List<MED_LAB_RESULT> MedLabResult
        {
            get { return this.medLabResult; }
            set
            {
                this.medLabResult = value;
                this.RaisePropertyChanged("MedLabResult");
            }
        }

        /// <summary>
        /// 检验结果主信息
        /// </summary>
        public List<MED_LAB_TEST_MASTER> MedLabTestMaster
        {
            get { return this.medLabTestMaster; }
            set
            {
                this.medLabTestMaster = value;
                this.RaisePropertyChanged("MedLabTestMaster");
            }
        }

        /// <summary>
        /// 根据选中的主信息显示对应的明细信息
        /// </summary>
        public ICommand ShowResultDetailCommon
        {
            get { return this.showResultDetailCommon; }
            set { this.showResultDetailCommon = value; }
        }

        #endregion

        #region  方法
        /// <summary>
        /// 构造函数
        /// </summary>
        public AssayReportViewModel(MED_PAT_INFO patModel)
        {
            this.medPatInfo = patModel;
            this.RegisterCommand();
            this.SyncMedLab();
        }
        /// <summary>
        /// 刷新检验信息明细数据
        /// </summary>
        private void RefreshMedLabResult(string testNo)
        {
            if (!string.IsNullOrEmpty(testNo) && null != this.curPatAllResult && this.curPatAllResult.Count > 0)
            {
                this.MedLabResult = this.curPatAllResult.FindAll(x => null != x.TEST_NO && !string.IsNullOrEmpty(x.TEST_NO) && x.TEST_NO.Equals(testNo));
            }
        }

        /// <summary>
        /// 检验结果主信息
        /// </summary>
        private void RefreshMedLabTestMaster()
        {
            lock (this.locker)
            {
                if (null != this.medPatInfo)
                {
                    // 获取检验信息主项
                    this.MedLabTestMaster = CommonService.ClientInstance.GetMedLabTestMaster(this.medPatInfo.PATIENT_ID, this.medPatInfo.VISIT_ID);
                    // 根据患者ID一次性获取所有检验结果明细，在切换数据时直接从内存中获取而不是每次读取数据
                    this.curPatAllResult = CommonService.ClientInstance.GetMedLabResult(this.medPatInfo.PATIENT_ID, this.medPatInfo.VISIT_ID);
                    MED_LAB_TEST_MASTER firstItem = this.MedLabTestMaster.FirstOrDefault();
                    if (null != firstItem)
                    {
                        this.RefreshMedLabResult(firstItem.TEST_NO);
                    }
                }
            }
        }

        /// <summary>
        /// 注册命令信息
        /// </summary>
        private void RegisterCommand()
        {
            // 切换检验结果明细信息
            this.ShowResultDetailCommon = new RelayCommand<object>(par =>
            {
                MED_LAB_TEST_MASTER tempMaster = par as MED_LAB_TEST_MASTER;
                if (null != tempMaster)
                {
                    this.RefreshMedLabResult(tempMaster.TEST_NO);
                }
            });
        }

        /// <summary>
        /// 调用接口同步检验结果信息后执行，从数据库中获取最新数据
        /// </summary>
        private void SyncCompleted(object sender, EventArgs e)
        {
            this.RefreshMedLabTestMaster();
        }

        /// <summary>
        /// 调用接口同步检验结果信息
        /// </summary>
        private void SyncMedLab()
        {
            if (null != this.medPatInfo)
            {
                if (ApplicationConfiguration.IsSync)
                {
                    string ret = "";
                    ret = SyncInfoService.ClientInstance.SyncLis(this.medPatInfo.PATIENT_ID, this.medPatInfo.VISIT_ID, this.SyncCompleted);
                }

                this.RefreshMedLabTestMaster();
            }
        }

        #endregion
    }
}
