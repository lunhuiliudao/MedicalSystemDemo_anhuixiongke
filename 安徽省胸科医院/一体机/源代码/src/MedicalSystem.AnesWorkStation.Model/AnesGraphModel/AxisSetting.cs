// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      AxisSetting.cs
// 功能描述(Description)：    术中界面，X时间轴对象实体
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
    public class AxisSetting
    {
        /// <summary>
        /// 轴标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? BeginTime { get; set; }
        /// <summary>
        /// 实际开始时间
        /// </summary>
        public DateTime? BeginFactTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// 次网格步长
        /// </summary>
        public double? MinorStep { get; set; }
        /// <summary>
        /// 主网格步长
        /// </summary>
        public double? MajorStep { get; set; }
        /// <summary>
        /// 次网格单位
        /// </summary>
        public DateUnit? MinorUnit { get; set; }
        /// <summary>
        /// 次网格单位
        /// </summary>
        public DateUnit? MajorUnit { get; set; }
        /// <summary>
        /// 移动时间轴最小时间
        /// </summary>
        public DateTime? MoveMinLimitTime { get; set; }
        /// <summary>
        /// 移动时间轴最大时间
        /// </summary>
        public DateTime? MoveMaxLimitTime { get; set; }
    }
}
