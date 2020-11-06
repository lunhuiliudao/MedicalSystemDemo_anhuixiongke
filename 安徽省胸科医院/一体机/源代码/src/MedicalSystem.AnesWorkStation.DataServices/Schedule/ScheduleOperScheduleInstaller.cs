using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using MedicalSystem.Configurations;
using MedicalSystem.DataServices;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    /// <summary>
    /// 安装配置服务
    /// </summary>
    public class ScheduleOperScheduleInstaller
    {/// <summary>
        /// 必须在程序启动前，注册配置信息。
        /// </summary>
        public static void RegistConfig()
        {
            MdkConfiguration.AddCustomConfig<ScheduleOperScheduleConfig>();
        }

        /// <summary>
        /// 获取当前配置信息
        /// </summary>
        /// <returns></returns>
        internal static IDataServiceConfig GetConfig()
        {
            return MdkConfiguration.GetConfig().GetCustomConfig<ScheduleOperScheduleConfig>();
        }

        /// <summary>
        /// 获取当前程序集信息
        /// </summary>
        /// <returns></returns>
        public static Assembly GetExecutingAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }
    }

    /// <summary>
    /// 配置文件类
    /// </summary>
    public class ScheduleOperScheduleConfig : IDataServiceConfig, ISerializedConfig
    {
        #region ISerializedConfig 成员

        public string NodeName
        {
            get { return "operSchedule"; }
        }

        public void Deserialize(System.Xml.XmlNode section)
        {
            var WebApiUriAtt = section.Attributes["WebApiUri"];
            var ConnectionNameAtt = section.Attributes["ConnectionName"];

            if (WebApiUriAtt != null && WebApiUriAtt.Value != String.Empty)
            {
                WebApiUri = WebApiUriAtt.Value;
            }
            else
            {
                WebApiUri = null;
            }

            if (ConnectionNameAtt != null && ConnectionNameAtt.Value != String.Empty)
            {
                ConnectionName = ConnectionNameAtt.Value;
            }
            else
            {
                ConnectionName = null;
            }
        }

        #endregion

        #region IDataServiceConfig 成员

        public string WebApiUri { get; private set; }

        public string ConnectionName { get; private set; }

        public int TimeOut { get; private set; }

        #endregion
    }
}
