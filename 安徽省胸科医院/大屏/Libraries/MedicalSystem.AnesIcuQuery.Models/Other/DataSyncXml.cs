using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace MedicalSystem.AnesIcuQuery.Models
{
    /// <summary>
    /// 配置文件解析类
    /// </summary>
    [XmlRoot("AAA")]
    public class DataSyncXml
    {
        /// <summary>
        /// 所有模块
        /// </summary>
        [XmlElement("model")]
        public List<AAAModel> Model { get; set; }

        /// <summary>
        /// 获取所有分组
        /// </summary>
        [XmlIgnore]
        [JsonIgnore]
        public List<AAAGroup> Group
        {
            get
            {
                if (Model == null)
                    return null;
                else
                    return Model.SelectMany(x => x.Group).ToList();
            }
        }

        /// <summary>
        /// 模块定义
        /// </summary>
        public class AAAModel
        {
            /// <summary>
            /// 模块名称
            /// </summary>
            [XmlElement("groupname")]
            public string GroupName { get; set; }

            /// <summary>
            /// 分组信息
            /// </summary>
            [XmlElement("group")]
            public List<AAAGroup> Group { get; set; }

        }

        /// <summary>
        /// 分组定义
        /// </summary>
        public class AAAGroup
        {
            /// <summary>
            /// 节点名称
            /// </summary>
            [XmlElement("key")]
            public string Key { get; set; }

            /// <summary>
            /// 节点描述
            /// </summary>
            [XmlElement("desc")]
            public string Desc { get; set; }

            /// <summary>
            /// 内容
            /// </summary>
            [XmlElement("value")]
            public string Value { get; set; }
        }


        /// <summary>
        /// 读取XML配置中指定节点的信息
        /// </summary>
        /// <param name="key">节点名称</param>
        /// <returns>返回指定节点的信息</returns>
        public string GetValue(string key)
        {
            if (Group != null)
            {
                return Group.Where(x => x.Key == key).Select(x => x.Value).FirstOrDefault();
            }

            return null;
        }
    }
}