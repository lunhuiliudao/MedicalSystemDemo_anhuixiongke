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
    public sealed class AnesWorkStationInstaller
    {
        /// <summary>
        /// 必须在程序启动前，注册配置信息。
        /// </summary>
        public static void RegistConfig()
        {
            MdkConfiguration.AddCustomConfig<AnesWorkStationConfig>();
        }

        /// <summary>
        /// 获取当前配置信息
        /// </summary>
        /// <returns></returns>
        internal static IDataServiceConfig GetConfig()
        {
            return MdkConfiguration.GetConfig().GetCustomConfig<AnesWorkStationConfig>();
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
    public sealed class AnesWorkStationConfig : DataServiceConfig, IDataServiceConfig, ISerializedConfig
    {
        #region ISerializedConfig 成员

        public override string NodeName
        {
            get { return "anesWorkStation"; }
        }

        #endregion

    }

}
