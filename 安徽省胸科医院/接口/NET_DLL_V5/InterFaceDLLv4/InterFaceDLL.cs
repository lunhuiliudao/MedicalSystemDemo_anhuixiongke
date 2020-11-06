using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Runtime.Serialization.Json;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using System.Net;
using System.Xml.Serialization;
using InitDocare;


namespace InterFaceV5
{
    public partial class InterFaceV5
    {

        public InterFaceV5()
        {
        }

        public static string SysMsgExchange(string msg)
        {
            return SysMsgExchange(msg, null);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string SysMsgExchange(string msg, string wsurl = null)
        {
            try
            {
                LogHelper.LogWrite(msg);
                if (!string.IsNullOrEmpty(wsurl))
                {
                    LogHelper.LogWrite(wsurl);
                }
                GPublicConfig lnPublicConfig = new GPublicConfig();
                string url = "";
                if (string.IsNullOrEmpty(lnPublicConfig.Wsurl))
                {
                    if (wsurl == null)
                        return "接口web 服务地址为空;如果是BS 架构请传入wsurl 参数";
                    else
                        url = wsurl;
                }
                else
                    url = lnPublicConfig.Wsurl;
                ofWebSerivces.WebDocare webdocare = new ofWebSerivces.WebDocare();
                webdocare.Timeout = (int)TimeSpan.FromMinutes(5).TotalMilliseconds;
                //webdocare.Url = lnPublicConfig.Wsurl;
                webdocare.Url = url;

                string result = webdocare.Ofsysteminterface(msg);
                ParamInputDomain domain = ToParaDomain(msg);
                if (domain.OpenClient)
                {
                    try
                    {
                        System.Diagnostics.Process.Start(result);
                        LogHelper.LogWrite("成功调阅地址");
                        return GetRetMsg("");
                    }
                    catch (Exception ex)
                    {
                        return GetRetMsg("打开客户端异常：" + result + ex.Message);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                string mes = "信息接口提示[v4版本]:系统错误提示警告[" + ex.Message + "] 引发当前异常的函数为;" + ex.TargetSite.Name + "调用堆栈上的桢的字符串表现形式" + ex.StackTrace;
                LogHelper.LogWrite(mes);
                return GetRetMsg(mes);
            }
        }

        public static string GetRetMsg(string mess)
        {
            if (string.IsNullOrEmpty(mess))
                return "<RefMsg><flag>0</flag><msg></msg><content></content><tip></tip></RefMsg>";
            else
                return "<RefMsg><flag>1</flag><msg>" + mess.Replace("<", "").Replace(">", "") + "</msg><content></content><tip></tip></RefMsg>";
        }

        //private static string ToString(ParamInputDomain  domain)
        //{
        //    JavaScriptSerializer ser = new JavaScriptSerializer();
        //    string jsonString = ser.Serialize(domain);
        //    string p = @"\\/Date(\d+)\+\d+\\/";  
        //    MatchEvaluator matchEvaluator = new MatchEvaluator(ConvertJsonDateToDateString);  
        //    Regex reg = new Regex(p);  
        //    jsonString = reg.Replace(jsonString, matchEvaluator);  
        //    return jsonString;  
        //}

        private static ParamInputDomain ToParaDomain(string joson)
        {
            using (MemoryStream ms2 = new MemoryStream(Encoding.UTF8.GetBytes(joson)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ParamInputDomain));
                ParamInputDomain obj = serializer.ReadObject(ms2) as ParamInputDomain;
                return obj;
            }
        }

        ///// <summary>   
        ///// 
        ///// </summary>   
        //private static string ConvertJsonDateToDateString(Match m)
        //{
        //    string result = string.Empty;
        //    DateTime dt = new DateTime(1970, 1, 1, 8, 0, 0);
        //    dt = dt.AddMilliseconds(long.Parse(m.Groups[1].Value));
        //    dt = dt.ToLocalTime();
        //    result = dt.ToString("yyyy-MM-dd HH:mm:ss");
        //    return result;
        //}

        //private static string ConvertDateStringToJsonDate(Match m)
        //{
        //    string result = string.Empty;
        //    DateTime dt = DateTime.Parse(m.Groups[0].Value);
        //    dt = dt.ToUniversalTime();
        //    TimeSpan ts = dt - DateTime.Parse("1970-01-01");
        //    result = string.Format("\\/Date({0}+0800)\\/", ts.TotalMilliseconds);
        //    return result;
        //}


    }
}
