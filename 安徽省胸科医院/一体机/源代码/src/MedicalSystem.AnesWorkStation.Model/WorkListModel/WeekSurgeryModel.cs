/*******************************
 * 文件名称：WeekSurgeryModel.cs
 * 文件说明：一周手术信息汇总，继承ObservableObject，可以实现属性绑定界面
 * 作    者：许文龙
 * 日    期：2017-04-10
 * *****************************/
using GalaSoft.MvvmLight;

namespace MedicalSystem.AnesWorkStation.Model.WorkListModel
{
    public class WeekSurgeryModel : ObservableObject
    {
        private int allSurgeryNum;                  // 一周手术总计
        private int mySurgeryNum;                   // 一周内我的手术例数

        /// <summary>
        /// 明日手术总计
        /// </summary>
        public int AllSurgeryNum
        {
            get { return this.allSurgeryNum; }
            set
            {
                this.allSurgeryNum = value;
                this.RaisePropertyChanged("AllSurgeryNum");
            }
        }

        /// <summary>
        /// 登录者的手术
        /// </summary>
        public int MySurgeryNum
        {
            get { return this.mySurgeryNum; }
            set
            {
                this.mySurgeryNum = value;
                this.RaisePropertyChanged("MySurgeryNum");
            }
        }
    }
}
