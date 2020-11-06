using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.AnesWorkStation.Domain.Report
{
    /// <summary>
    /// 报表图表配置
    /// </summary>
    public class ReportChartInfo
    {
        /// <summary>
        /// 如果为""前台就不显示图形报表
        /// </summary>
        [DataMember]
        public string ChartType { get; set; } = "";
        /// <summary>
        /// Series数据 动态字段
        /// </summary>
        [DataMember]
        public List<SeriesDataSet> SeriesData { get; set; } = new List<SeriesDataSet> ();
        /// <summary>
        /// x轴配置信息
        /// </summary>
        [DataMember]
        public AxisInfo XAxisInfo { get; set; } = new AxisInfo();
        /// <summary>
        /// y轴配置信息
        /// </summary>
        [DataMember]
        public AxisInfo YAxisInfo { get; set; } = new AxisInfo();
    }

    public class AxisInfo
    {
        /// <summary>
        /// 类型
        /// </summary>
        [DataMember]
        public string Type { get; set; } = "value";
        /// <summary>
        /// 动态字段 如果为""前台就获取 Data属性值
        /// </summary>
        [DataMember]
        public string DataColumn { get; set; } = "";
        /// <summary>
        /// 固定显示的数据
        /// </summary>
        [DataMember]
        public string[] Data { get; set; } = new string[] { };

    }

    public class SeriesDataSet
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Field { get; set; }

    }
}
