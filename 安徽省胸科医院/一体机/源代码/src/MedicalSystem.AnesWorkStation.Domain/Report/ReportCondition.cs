//＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
//文件名称(File Name)：      ReportCondition.cs
//功能描述(Description)：    
//数据表(Tables)：		     
//作者(Author)：             吴文蛟
//日期(Create Date)：        2017/8/31 16:22:31
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
    /// 数据类型
    /// </summary>
    public enum EnumDataType
    {
        [EnumMemberAttribute]
        String,
        [EnumMemberAttribute]
        DateTime,
        [EnumMemberAttribute]
        Int,
        [EnumMemberAttribute]
        Double,
        [EnumMemberAttribute]
        Bool
    }
    [DataContract]
    /// <summary>
    /// 控件类型
    /// </summary>
    public enum EnumControlType
    {
        [EnumMemberAttribute]
        DatePick,
        [EnumMemberAttribute]
        TextBox,
        [EnumMemberAttribute]
        CheckBox,
        [EnumMemberAttribute]
        DropDownList
    }
    [DataContract]
    /// <summary>
    /// 自定类型
    /// </summary>
    public enum EnumDictType
    {
        [EnumMemberAttribute]
        DoctorNurseDict,
        [EnumMemberAttribute]
        NurseDict,
        [EnumMemberAttribute]
        DoctorDict,
        [EnumMemberAttribute]
        DeptDict,
        [EnumMemberAttribute]
        DiyDict,
        [EnumMemberAttribute]
        DynamicDict
    }

    [DataContract]
    /// <summary>
    /// 动态字典需要的信息
    /// </summary>
    public class DynamicDictDes
    {
        [DataMember]
        /// <summary>
        /// 表名字或视图名
        /// </summary>
        public string TableName { get; set; } = "";
        [DataMember]
        /// <summary>
        /// 键字段
        /// </summary>
        public string KeyColumn { get; set; } = "";
        [DataMember]
        /// <summary>
        /// 显示字段
        /// </summary>
        public string ValColumn { get; set; } = "";
        [DataMember]
        /// <summary>
        /// 查询条件
        /// </summary>
        public string Condition { get; set; } = "";
    }

    [DataContract]
    /// <summary>
    /// 时间控件类型
    /// </summary>
    public enum EnumDateControlType
    {
        [EnumMemberAttribute]
        date,
        [EnumMemberAttribute]
        datetime,
        [EnumMemberAttribute]
        year,
        [EnumMemberAttribute]
        month
    }

    [DataContract]
    /// <summary>
    /// 时间控件默认值
    /// </summary>
    public enum EnumDateDefaultVal
    {
        /// <summary>
        /// 当前日期
        /// </summary>
        [EnumMemberAttribute]
        CurrentDate,
        /// <summary>
        /// 当前月第一天
        /// </summary>
        [EnumMemberAttribute]
        CurrentFirstDate,
        /// <summary>
        /// 当前月最后一天
        /// </summary>
        [EnumMemberAttribute]
        CurrentLastDate,
        /// <summary>
        /// 固定值
        /// </summary>
        [EnumMemberAttribute]
        FixedVal
    }

    [DataContract]
    /// <summary>
    /// 键值对
    /// </summary>
    public class KeyValue
    {
        [DataMember]
        public string Key { get; set; }
        [DataMember]
        public string Value { get; set; }
        [DataMember]
        public int flag { get; set; }
        [DataMember]
        public string InputCode { get; set; }
    }
    [DataContract]
    public class ReportCondition
    {

        /// <summary>
        /// 标题
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// 控件类型
        /// </summary>
        [DataMember]
        [JsonConverter(typeof(StringEnumConverter))]
        public EnumControlType ControlType { get; set; }

        /// <summary>
        /// 字段名
        /// </summary>
        [DataMember]
        public string FieldName { get; set; }
        /// <summary>
        /// 数据类型 
        /// </summary>
        [DataMember]
        [JsonConverter(typeof(StringEnumConverter))]
        public EnumDataType DataType { get; set; }
        /// <summary>
        /// 字典类型
        /// </summary>
        [DataMember]
        [JsonConverter(typeof(StringEnumConverter))]
        public EnumDictType DictType { get; set; }
        /// <summary>
        /// 字典数据
        /// </summary>
        [DataMember]
        public List<KeyValue> BindDict { get; set; }

        /// <summary>
        /// 动态字典需要的信息
        /// </summary>
        [DataMember]
        public DynamicDictDes DynamicDictDes { get; set; } = new DynamicDictDes();

        /// <summary>
        /// 时间控件类型
        /// </summary>
        [DataMember]
        [JsonConverter(typeof(StringEnumConverter))]
        public EnumDateControlType DateControlType { get; set; }

        /// <summary>
        /// 时间控件默认值
        /// </summary>
        [DataMember]
        [JsonConverter(typeof(StringEnumConverter))]
        public EnumDateDefaultVal DateDefaultVal { get; set; }

        /// <summary>
        /// 选中值
        /// </summary>
        [DataMember]
        public string Value { get; set; }
    }
}
