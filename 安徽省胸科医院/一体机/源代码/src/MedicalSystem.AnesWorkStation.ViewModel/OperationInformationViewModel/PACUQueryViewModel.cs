//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      PACUQueryViewModel.cs
//功能描述(Description)：    入复苏室信息查询
//数据表(Tables)：		      
//作者(Author)：                   MDSD
//日期(Create Date)：           2017-12-27 15:23:35
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight.Command;
using MedicalSystem.Anes.Framework.Utilities;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Model.PACUQueryModel;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace MedicalSystem.AnesWorkStation.ViewModel.OperationInformationViewModel
{
    /// <summary>
    /// PACU功能
    /// </summary>
    public class PACUQueryViewModel : BaseViewModel
    {
        #region 界面绑定相关字段
        private List<PACUQueryModel> _PACURecord;
        /// <summary>
        /// PACU床位数
        /// </summary>
        private string _TotalBed;

        public string TotalBed
        {
            get { return "共有床位：" + _TotalBed + "个"; }
            set
            {
                _TotalBed = value;
                RaisePropertyChanged("TotalBed");
            }
        }
        /// <summary>
        /// PACU空余床位
        /// </summary>
        private string _RemainBed;

        public string RemainBed
        {
            get { return "空余床位：" + _RemainBed + "个"; }
            set
            {
                _RemainBed = value;
                RaisePropertyChanged("RemainBed");
            }
        }
        /// <summary>
        /// 待入患者
        /// </summary>
        private string _PatsWaiting;

        public string PatsWaiting
        {
            get { return "待入患者数：" + _PatsWaiting + "个"; }
            set
            {
                _PatsWaiting = value;
                RaisePropertyChanged("PatsWaiting");
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        public List<PACUQueryModel> PACURecord
        {
            get
            {
                return _PACURecord;
            }
            set
            {
                _PACURecord = value;
                RaisePropertyChanged("PACURecord");
            }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 载入信息
        /// </summary>
        public override void LoadData()
        {
            // 初始化数据
            PACURecord = new List<PACUQueryModel>();
            TotalBed = string.Empty;
            RemainBed = string.Empty;
            PatsWaiting = string.Empty;
            List<MED_PACU_INFO> MED_PACU_INFOList = PatInfoService.ClientInstance.GetPACUInfos();
            List<MED_OPERATION_MASTER> MED_OPERATION_MASTERList = PatInfoService.ClientInstance.GetWaitingInfos();
            int remainNum = 0; // 用于计算空PACU房间数

            // 绑定数据
            foreach (MED_PACU_INFO mpi in MED_PACU_INFOList)
            {
                if (string.IsNullOrEmpty(mpi.PATIENT_ID))
                {
                    remainNum++;
                    continue;
                }
                PACUQueryModel pACUQueryModel = new PACUQueryModel();
                pACUQueryModel.BED_NO = mpi.BED_NO;
                pACUQueryModel.PATIENT_ID = mpi.PATIENT_ID;
                pACUQueryModel.NAME = mpi.NAME;
                pACUQueryModel.SEX = mpi.SEX;
                pACUQueryModel.AGE = DateDiff.CalAge(mpi.DATE_OF_BIRTH.Value, mpi.SCHEDULED_DATE_TIME.Value);
                pACUQueryModel.OPERATION_NAME = mpi.OPERATION_NAME;
                if (mpi.OUT_PACU_DATE_TIME != null && mpi.IN_PACU_DATE_TIME != null)
                {
                    TimeSpan tsPACU = mpi.OUT_PACU_DATE_TIME.Value - mpi.IN_PACU_DATE_TIME.Value;
                    pACUQueryModel.PACU_TIME_RANGE = tsPACU.Hours + "小时" + tsPACU.Minutes + "分钟";
                }
                PACURecord.Add(pACUQueryModel);
            }
            TotalBed = MED_PACU_INFOList.Count.ToString();
            RemainBed = remainNum.ToString();
            PatsWaiting = MED_OPERATION_MASTERList.Count.ToString(); ;
        }
        #endregion

        #region 命令
        /// <summary>
        /// 确定
        /// </summary>
        public ICommand BtnOKCommand
        {
            get
            {
                return new RelayCommand<string>(key =>
                {
                    this.CloseContentWindow();
                });
            }
        }
        #endregion

    }
}
