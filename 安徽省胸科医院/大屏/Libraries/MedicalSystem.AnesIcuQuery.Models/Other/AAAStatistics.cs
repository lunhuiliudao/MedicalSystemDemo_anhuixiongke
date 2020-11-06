using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace MedicalSystem.AnesIcuQuery.Models
{
    /// <summary>
    /// 配置文件解析类
    /// </summary>
    [XmlRoot("AAA")]
    public class AAAStatistics
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
            /// 内容
            /// </summary>
            [XmlElement("value")]
            public string Value { get; set; }
        }

        #region 公共方法

        /// <summary>
        /// 获取配置XML分组的信息
        /// </summary>
        /// <param name="groupname">分组名称</param>
        /// <returns></returns>
        public List<AAAGroup> GetGroups(string groupname)
        {
            if (Model != null)
            {
                return Model.Where(x => x.GroupName == groupname).Select(x => x.Group).FirstOrDefault();
            }

            return null;
        }

        /// <summary>
        /// 读取XML配置中指定节点的信息
        /// </summary>
        /// <param name="key">节点名称</param>
        /// <returns>返回指定节点的信息</returns>
        public string GetValue(string key)
        {
            if (!string.IsNullOrEmpty(key) && key.Contains("\r\n"))
                key = key.Split(new string[] { "\r\n" }, StringSplitOptions.None)[1];
            if (Group != null)
            {
                return Group.Where(x => x.Key == key).Select(x => x.Value).FirstOrDefault();
            }
            return null;
        }


        /// <summary>
        /// 是否包含此Key
        /// </summary>
        /// <param name="key">节点名称</param>
        /// <returns>bool</returns>
        public bool ExistsKey(string key)
        {
            if (!string.IsNullOrEmpty(key) && key.Contains("\r\n"))
                key = key.Split(new string[] { "\r\n" }, StringSplitOptions.None)[1];
            if (Group != null)
            {
                return Group.Exists(x => x.Key == key);
            }
            return false;
        }
        /// <summary>
        /// 跟新节点
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        public void SetValue(string key, string value)
        {
            if (Group != null)
            {
                var item = Group.Where(x => x.Key == key).ToList();
                if (item != null && item[0].Key == key)
                {
                    item[0].Value = value;
                }
            }

        }

        #endregion

    }
}