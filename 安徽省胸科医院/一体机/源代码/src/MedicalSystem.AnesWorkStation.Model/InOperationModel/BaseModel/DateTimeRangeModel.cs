// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      DateTimeRangeModel.cs
// 功能描述(Description)：    术中时长实体
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using GalaSoft.MvvmLight;
using System;

namespace MedicalSystem.AnesWorkStation.Model.InOperationModel
{
    /// <summary>
    /// 术中时长，可计算出入室时长，和手术开始至手术结束时长
    /// </summary>
    public class DateTimeRangeModel : ObservableObject
    {
        private Nullable<DateTime> startDateTime;                                  // 手术开始时间
        private Nullable<DateTime> endDateTime;                                    // 手术结束时间
        private Nullable<DateTime> currentStartDT;                                 // 当前开始时间
        private Nullable<DateTime> currentEntDT;                                   // 当前结束时间
        private Nullable<DateTime> selectTime;                                     // 当前选中时间

        /// <summary>
        /// 手术开始时间
        /// </summary>
        public Nullable<DateTime> StartDateTime
        {
            set { startDateTime = value; }
            get
            {
                if (startDateTime == DateTime.MinValue)
                {
                    startDateTime = null;
                }

                if (startDateTime != null)
                {
                    startDateTime = startDateTime.Value.Date.AddHours(startDateTime.Value.Hour).AddMinutes(startDateTime.Value.Minute);
                }

                return startDateTime;
            }
        }

        /// <summary>
        /// 手术结束时间
        /// </summary>
        public Nullable<DateTime> EndDateTime
        {
            set { endDateTime = value; }
            get
            {
                if (endDateTime == DateTime.MinValue)
                {
                    endDateTime = null;
                }
                if (endDateTime != null)
                {
                    endDateTime = endDateTime.Value.Date.AddHours(endDateTime.Value.Hour).AddMinutes(endDateTime.Value.Minute);
                }

                return endDateTime;
            }
        }

        /// <summary>
        /// 当前开始时间
        /// </summary>
        public Nullable<DateTime> CurrentStartDT
        {
            get { return currentStartDT; }
            set { currentStartDT = value; }
        }

        /// <summary>
        /// 当前结束时间
        /// </summary>
        public Nullable<DateTime> CurrentEntDT
        {
            get { return currentEntDT; }
            set { currentEntDT = value; }
        }

        /// <summary>
        /// 当前选中时间
        /// </summary>
        public Nullable<DateTime> SelectTime
        {
            get { return selectTime; }
            set { selectTime = value; }
        }

        /// <summary>
        /// 有参构造：设置开始时间和结束时间
        /// </summary>
        public DateTimeRangeModel(DateTime? startDateTime, DateTime? endDateTime)
        {
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
        }
    }
}

