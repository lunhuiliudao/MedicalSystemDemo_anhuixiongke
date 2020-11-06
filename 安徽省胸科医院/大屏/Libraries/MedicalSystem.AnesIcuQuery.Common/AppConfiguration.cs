using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Windows.Forms;

namespace MedicalSystem.AnesIcuQuery.Common
{
    /// <summary>
    /// APP全局变量
    /// </summary>
    public class AppConfiguration : Singleton<AppConfiguration>
    {
        /// <summary>
        /// 是否是Web使用
        /// </summary>
        public bool IsWebOrForm
        {
            get
            {
                HttpContext context = HttpContext.Current;
                if (context != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private string _appPath = string.Empty;
        /// <summary>
        /// 当前应用程序的所在根目录
        /// </summary>
        public string AppPath
        {
            get
            {
                if (string.IsNullOrEmpty(_appPath))
                {
                    if (IsWebOrForm)
                    {
                        _appPath = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath);
                    }
                    else
                    {
                        string path = Application.ExecutablePath;
                        if (path.Contains(@"\"))
                        {
                            int pos = path.LastIndexOf(@"\");
                            path = path.Remove(pos + 1);
                        }
                        if (!path.EndsWith(@"\"))
                            path += @"\";
                        _appPath = path;
                    }
                }
                return _appPath;
            }
        }

        /// <summary>
        /// 获取config["HostUrl"]配置文件中的服务端网址
        /// </summary>
        public string GetWebHostUrl
        {
            get
            {
                return Read("HostUrl");
            }
        }
        /// <summary>
        /// 麦迪斯顿跨平台通信的服务端地址
        /// </summary>
        public static string MedicalSystemMessageServerURL
        {
            get
            {
                string key = "MedicalSystemMessageServerURL";
                string value = Read(key);

                if (string.IsNullOrEmpty(value))
                {
                    value = "localhost:9999";
                }

                return value;
            }
        }
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

        private Dictionary<string, object> _syncProcess = new Dictionary<string, object>();
        /// <summary>
        /// 当前用户同步的进度条
        /// </summary>
        public Dictionary<string, object> SyncProcessDict
        {
            get { return _syncProcess; }
        }

        /// <summary>
        /// 获取当前SQL,通过异常的方式抛给服务端。
        /// </summary>
        public const string GET_SQL_EXCEPTION = "GET_SQL_EXCEPTION";

    }
}
