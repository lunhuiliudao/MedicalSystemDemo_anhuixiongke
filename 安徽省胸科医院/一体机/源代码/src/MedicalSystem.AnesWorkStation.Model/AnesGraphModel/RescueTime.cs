// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      RescueTime.cs
// 功能描述(Description)：    术中界面，涉及到抢救事件的抢救时间段
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
using System;

namespace MedicalSystem.AnesWorkStation.Model.AnesGraphModel
{
    /// <summary>
    /// 抢救时间
    /// </summary>
    [Serializable]
    public class RescueTime
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public Nullable<DateTime> BeginTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public Nullable<DateTime> EndTime { get; set; }

        /// <summary>
        /// 拍照时间
        /// </summary>
        public Nullable<DateTime> CameraTime { get; set; }

        /// <summary>
        /// 有参构造：抢救时间的时间段
        /// </summary>
        public RescueTime(Nullable<DateTime> beginTime, Nullable<DateTime> endTime)
        {
            this.BeginTime = beginTime;
            this.EndTime = endTime;
        }
        public RescueTime(Nullable<DateTime> cameraTime)
        {
            this.CameraTime = cameraTime;
        }
    }
}
