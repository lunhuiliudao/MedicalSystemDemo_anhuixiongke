// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      TextMarkPoint.cs
// 功能描述(Description)：    术中界面，事件节点的文本标记
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
    /// 文本标记点
    /// </summary>
    public class TextMarkPoint
    {
        /// <summary>
        /// 点名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 标记时间
        /// </summary>
        public DateTime MarkTime { get; set; }

        /// <summary>
        /// 标记文本（自定义格式,可以含回车“\n”）
        /// </summary>
        public string MarkText { get; set; }

        /// <summary>
        /// Tooltip
        /// </summary>
        public string ToolTip { get; set; }

        /// <summary>
        /// 有参构造
        /// </summary>
        public TextMarkPoint(DateTime MarkTime, string MarkText)
        {
            this.MarkTime = MarkTime;
            this.MarkText = MarkText;
        }
    }
}
