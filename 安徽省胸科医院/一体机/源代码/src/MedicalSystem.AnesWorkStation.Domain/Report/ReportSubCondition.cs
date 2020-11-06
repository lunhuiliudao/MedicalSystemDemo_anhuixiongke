using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain.Report
{
    [DataContract]
    public class ReportSubCondition
    {
        /// <summary>
        /// 字段名
        /// </summary>
        [DataMember]
        public string FieldName { get; set; }

        /// <summary>
        /// 参数名称
        /// </summary>
        [DataMember]
        public string ParamName { get; set; }
        /// <summary>
        /// 数据类型 
        /// </summary>
        [DataMember]
        [JsonConverter(typeof(StringEnumConverter))]
        public EnumDataType DataType { get; set; }
        /// <summary>
        /// 选中值
        /// </summary>
        [DataMember]
        public string Value { get; set; }
    }
}
