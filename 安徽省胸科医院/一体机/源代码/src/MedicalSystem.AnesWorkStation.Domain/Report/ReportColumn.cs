//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      ReportColumn.cs
//功能描述(Description)：    
//数据表(Tables)：		     
//作者(Author)：             吴文蛟
//日期(Create Date)：        2017/8/31 16:19:56
//R1:
//    修改作者:
//    修改日期:
//    修改理由:
//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝=
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain.Report
{
    [DataContract]
    /// <summary>
    /// 对其方式
    /// </summary>
    public enum EnumAlign
    {
        [EnumMemberAttribute]
        left,
        [EnumMemberAttribute]
        center,
        [EnumMemberAttribute]
        right
    }
    [DataContract]
    public class ReportColumn
    {

        /// <summary>
        /// 字段名
        /// </summary>
        [DataMember]
        public string FieldName { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [DataMember]
        public string Title { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        [DataMember]
        public string Width { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        [DataMember]
        public bool IsSHow { get; set; }
        /// <summary>
        /// 是否可排序
        /// </summary>
        [DataMember]
        public bool IsSort { get; set; }
        /// <summary>
        /// 是否合计列
        /// </summary>
        [DataMember]
        public bool IsSum { get; set; }
        /// <summary>
        /// 是否为子报表查询条件
        /// </summary>
        [DataMember]
        public bool IsSubReportCondition { get; set; }
        /// <summary>
        /// 子报表名称
        /// </summary>
        [DataMember]
        public string SubReportName { get; set; }
        /// <summary>
        /// 是否需要导出该列
        /// </summary>
        [DataMember]
        public bool IsExport { get; set; }
        /// <summary>
        /// 对齐方式
        /// </summary>
        [DataMember]
        [JsonConverter(typeof(StringEnumConverter))]
        public EnumAlign Align { get; set; }

        /// <summary>
        /// 子列头
        /// </summary>
        [DataMember]
        public List<ReportColumn> ReportColumnList { get; set; }
    }
}
