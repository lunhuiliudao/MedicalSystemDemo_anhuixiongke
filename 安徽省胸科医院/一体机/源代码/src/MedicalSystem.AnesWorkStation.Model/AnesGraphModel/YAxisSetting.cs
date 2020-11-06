// ＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
// 文件名称(File Name)：      YAxisSetting.cs
// 功能描述(Description)：    术中界面，Y时间轴对象实体
// 数据表(Tables)：		      无
// 作者(Author)：             MDSD
// 日期(Create Date)：        2017/12/26 13:28
// R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝

namespace MedicalSystem.AnesWorkStation.Model.AnesGraphModel
{
    public class YAxisSetting
    {
        /// <summary>
        /// 轴标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 是否是主轴
        /// </summary>
        public bool IsPrimary { get; set; }
        /// <summary>
        /// Y轴索引
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// 开始值
        /// </summary>
        public double MinVal { get; set; }
        /// <summary>
        /// 结束值
        /// </summary>
        public double MaxVal { get; set; }
        /// <summary>
        /// 次网格步长
        /// </summary>
        public double? MinorStep { get; set; }
        /// <summary>
        /// 主网格步长
        /// </summary>
        public double? MajorStep { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
    }
}
