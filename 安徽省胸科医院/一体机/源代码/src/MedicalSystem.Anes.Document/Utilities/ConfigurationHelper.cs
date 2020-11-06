using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace MedicalSystem.Anes.Document.Utilities
{
    public class ConfigurationHelper
    {
        /// <summary>
        /// 读取设置
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns>对应值</returns>
        public static string Read(string key)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);


                string value = config.AppSettings.Settings[key].Value;
                return value;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ConfigurationHelper Read key " + key + "  " + ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// 读取设置
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="key">主键</param>
        /// <returns>对应值</returns>
        public static string Read(string fileName, string key)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(fileName);
                return config.AppSettings.Settings[key].Value;
            }
            catch
            {

                return null;
            }
        }

        /// <summary>
        /// 保存设置
        /// </summary>
        /// <param name="key">主键</param>
        /// <param name="value">对应值</param>
        public static void Save(string key, string value)
        {
            if (Read(key) == value) return;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove(key);
            config.AppSettings.Settings.Add(key, value);
            config.Save();
        }

        /// <summary>
        /// 保存设置
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="key">主键</param>
        /// <param name="value">对应值</param>
        public static void Save(string fileName, string key, string value)
        {
            if (Read(key) == value) return;
            Configuration config = ConfigurationManager.OpenExeConfiguration(fileName);
            config.AppSettings.Settings.Remove(key);
            config.AppSettings.Settings.Add(key, value);
            config.Save();
        }

        /// <summary>
        /// 加密连接字符串配置
        /// </summary>
        /// <param name="connectionStringsSection"></param>
        public static void ProtectSection(ConnectionStringsSection connectionStringsSection)
        {
            connectionStringsSection.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
        }

        /// <summary>
        /// 两个连接字符串配置是否相等
        /// </summary>
        /// <param name="connectionStringSettings1">连接字符串配置</param>
        /// <param name="connectionStringSettings2">连接字符串配置</param>
        /// <returns>是否相等</returns>
        public static bool IsSame(ConnectionStringSettings connectionStringSettings1, ConnectionStringSettings connectionStringSettings2)
        {
            if (connectionStringSettings1 == null || connectionStringSettings2 == null) return false;
            else
            {
                return
                    connectionStringSettings1.Name.Equals(connectionStringSettings2.Name) &&
                    connectionStringSettings1.ConnectionString.Equals(connectionStringSettings2.ConnectionString) &&
                    (
                        (
                            string.IsNullOrEmpty(connectionStringSettings1.ProviderName) && string.IsNullOrEmpty(connectionStringSettings2.ProviderName)
                        ) ||
                        (
                            !string.IsNullOrEmpty(connectionStringSettings1.ProviderName) && connectionStringSettings1.ProviderName.Equals(connectionStringSettings2.ProviderName)
                        )
                    );
            }
        }

        /// <summary>
        /// 系统配置的连接字符串集
        /// </summary>
        public static ConnectionStringSettingsCollection ConnectionStringSettingsCollections
        {
            get
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                ConnectionStringSettingsCollection connectionStringSettingsCollection = config.ConnectionStrings.ConnectionStrings;
                if (connectionStringSettingsCollection != null && connectionStringSettingsCollection.Count > 0)
                {
                    connectionStringSettingsCollection.RemoveAt(0);
                }
                return connectionStringSettingsCollection;
            }
        }

        /// <summary>
        /// 配置最后一个连接字符串
        /// </summary>
        public static bool SaveConnectionStringSettings(ConnectionStringSettingsCollection connectionStringSettingsCollections)
        {
            bool result = false;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            foreach (ConnectionStringSettings connectionStringSettings in connectionStringSettingsCollections)
            {
                ConnectionStringSettings connectionStringSettings1 = config.ConnectionStrings.ConnectionStrings[connectionStringSettings.Name];
                if (connectionStringSettings1 == null)
                {
                    config.ConnectionStrings.ConnectionStrings.Add(connectionStringSettings);
                    result = true;
                }
                else if (!IsSame(connectionStringSettings1, connectionStringSettings))
                {
                    config.ConnectionStrings.ConnectionStrings.Remove(connectionStringSettings1);
                    config.ConnectionStrings.ConnectionStrings.Add(connectionStringSettings);
                    result = true;
                }
            }
            if (result)
            {
                ProtectSection(config.ConnectionStrings);
                config.Save();
            }
            return result;
        }

        public static ConnectionStringSettings GetConnectionStringSettingsFromName(string connectionName)
        {
            ConnectionStringSettingsCollection connsets = ConfigurationManager.ConnectionStrings;
            if (connsets != null)
            {
                foreach (ConnectionStringSettings cnset in connsets)
                {
                    if (cnset.Name.Equals(connectionName))
                    {
                        return cnset;
                    }
                }
            }
            return null;
        }
    }
}
