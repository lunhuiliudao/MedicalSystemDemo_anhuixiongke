/*******************************
 * 文件名称：TodaySurgeryModel.cs
 * 文件说明：今日手术信息汇总，继承ObservableObject，可以实现属性绑定界面
 * 作    者：许文龙
 * 日    期：2017-04-10
 * *****************************/
using GalaSoft.MvvmLight;

namespace MedicalSystem.AnesWorkStation.Model
{
    public class TodaySurgeryModel : ObservableObject
    {
        private int todaySurgeryNum;                      // 今日手术总量
        private int finishSurgeryNum;                     // 已完成的手术量
        private int unFinishSurgeryNum;                   // 未完成的手术量
        private double finishPercent;                     // 完成比例

        /// <summary>
        /// 今日手术总量
        /// </summary>
        public int TodaySurgeryNum 
        {
            get { return this.todaySurgeryNum;  }
            set 
            { 
                this.todaySurgeryNum = value;
                this.RaisePropertyChanged("TodaySurgeryNum");
            }
        }

        /// <summary>
        /// 已完成手术
        /// </summary>
        public int FinishSurgeryNum
        {
            get { return this.finishSurgeryNum; }
            set
            {
                this.finishSurgeryNum = value;
                this.RaisePropertyChanged("FinishSurgeryNum");
            }
        }

        /// <summary>
        /// 完成比例
        /// </summary>
        public double FinishPercent
        {
            get { return this.finishPercent; }
            set
            {
                this.finishPercent = value;
                this.RaisePropertyChanged("FinishPercent");
            }
        }

        /// <summary>
        /// 未完成的手术量
        /// </summary>
        public int UnFinishSurgeryNum 
        {
            get { return this.unFinishSurgeryNum; }
            set
            {
                this.unFinishSurgeryNum = value;
                this.RaisePropertyChanged("UnFinishSurgeryNum");
            }
        }
    }
}
