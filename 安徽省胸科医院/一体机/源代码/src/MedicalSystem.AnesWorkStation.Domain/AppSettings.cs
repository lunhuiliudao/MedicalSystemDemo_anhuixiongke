using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace MedicalSystem.AnesWorkStation.Domain
{ 
    public class AppSettings
    {
        public static string SecureKey { get { return ConfigurationManager.AppSettings["SecureKey"]; } }

        /// <summary>
        /// 接口调用地址
        /// </summary>
        public static string InterFacePath { get { return ConfigurationManager.AppSettings["InterFacePath"]; } }

        /// <summary>
        /// 消息平台IP地址
        /// </summary>
        public static string MedicalSystemMessageServerURL { get { return ConfigurationManager.AppSettings["MedicalSystemMessageServerURL"]; } }

        /// <summary>
        /// 上报质控平台接口地址
        /// </summary>
        public static string PostQcUri { get { return ConfigurationManager.AppSettings["PostQcUri"]; } }

        /// <summary>
        /// 上报质控平台省区密钥
        /// </summary>
        public static string QcScriectKey { get { return ConfigurationManager.AppSettings["QcScriectKey"]; } }

        /// <summary>
        /// 上报质控平台省区编号
        /// </summary>
        public static string ProvincialNo { get { return ConfigurationManager.AppSettings["ProvincialNo"]; } }

        /// <summary>
        /// 文件上传的文件存储地址
        /// </summary>
        public static string QcUpLoadFileAddress { get { return ConfigurationManager.AppSettings["QcUpLoadFileAddress"]; } }

        /// <summary>
        /// 内外网是否互通
        /// </summary>
        public static string NetInterFlow { get { return ConfigurationManager.AppSettings["NetInterFlow"]; } }

        /// <summary>
        /// 前置机内网地址
        /// </summary>
        public static string FontEndIP { get { return ConfigurationManager.AppSettings["FontEndIP"]; } }

        /// <summary>
        /// 手术护理文书用户字典表麻醉科室代码
        /// </summary>
        public static string AnesWardCode { get { return ConfigurationManager.AppSettings["AnesWardCode"]; } }

        /// <summary>
        /// 手术护理文书用户字典表手术科室代码
        /// </summary>
        public static string OperDeptCode { get { return ConfigurationManager.AppSettings["OperDeptCode"]; } }


        /// <summary>
        /// 在数据库中医生角色名
        /// </summary>
        public static string DoctorUserJob
        {
            get
            {
                string doctorUserJob = ConfigurationManager.AppSettings["DoctorUserJob"];
                if (doctorUserJob == null)
                {
                    return "医生";
                }
                else
                {
                    return doctorUserJob;
                }
            }
        }
        /// <summary>
        /// 在数据库中护士角色名
        /// </summary>
        public static string NurseUserJob
        {
            get
            {
                string nurseUserJob = ConfigurationManager.AppSettings["NurseUserJob"];
                if (nurseUserJob == null)
                {
                    return "护士";
                }
                else
                {
                    return nurseUserJob;
                }
            }
        }
        /// <summary>
        /// 开启手术排版信息回传OPER501W(HIS202)
        /// </summary>
        public static Boolean OpenHIS202
        {
            get
            {
                string openHIS202 = ConfigurationManager.AppSettings["OpenHIS202"];
                if (openHIS202 == null)
                {
                    return false;
                }
                else
                {
                    return Convert.ToBoolean(openHIS202);
                }
            }
        }
        /// <summary>
        /// 开启手术取消OPER504W(HIS212)
        /// </summary>
        public static Boolean OpenHIS212
        {
            get
            {
                string openHIS212 = ConfigurationManager.AppSettings["OpenHIS212"];
                if (openHIS212 == null)
                {
                    return false;
                }
                else
                {
                    return Convert.ToBoolean(openHIS212);
                }
            }
        }


        /// <summary>
        /// 获取当前SQL,通过异常的方式抛给服务端。
        /// </summary>
        public const string GET_SQL_EXCEPTION = "GET_SQL_EXCEPTION";

        private static string _appPath = string.Empty;
        /// <summary>
        /// 当前应用程序的所在根目录
        /// </summary>
        public static string ScreenAppPath
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
        /// 是否是Web使用
        /// </summary>
        public static bool IsWebOrForm
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

        /// <summary>
        /// 麻醉5.0登录
        /// </summary>
        public static Boolean IsFor5
        {
            get
            {
                string ISFOR5 = ConfigurationManager.AppSettings["ISFOR5"];
                if (ISFOR5 == null)
                {
                    return false;
                }
                else
                {
                    return Convert.ToBoolean(ISFOR5);
                }
            }
        }


    }
}
