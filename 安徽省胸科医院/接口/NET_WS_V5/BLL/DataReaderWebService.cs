using Init;
using InitDocare;
using MedicalSytem.Soft.InitDocare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BLL
{
    public class DataReaderWebService
    {

        private static Config2 config = null;
        public static Config2 Config
        {
            get
            {
                if (config == null)
                {
                    config = new Config2();
                }
                return config;
            }
        }

        /// <summary>
        /// 发送send, 接收receive
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public static string HanderDomain(ParamInputDomain domain)
        {
            try
            {
                InitDocare.LogA.Debug("HanderDomain：" + domain.Code);
                string re = MessageHander.MessageSwitch(domain).PreDataBase(Config, domain);

                if (domain.OpenClient) ///客户端打开 url ,或者exe 程序
                {
                    return re;
                }
                if (domain.Route.HasValue && domain.Route.Value == 1) ///不插入数据库
                {
                    if (CheckXML(re))
                    {
                        return GetRetMsg("", re);
                    }
                    else
                    {
                        return GetRetMsg(re, "");
                    }
                }
                else  ///插入数据库
                {
                    return GetRetMsg(re, "");
                }

            }
            catch (Exception ex)
            {
                InitDocare.LogA.Debug(ex.Message + "调用堆栈上的桢的字符串表现形式:" + ex.StackTrace + "\r\n引发当前异常的函数为:" + ex.TargetSite.Name + "\r\n导致错误的应用程序或对象的名称为:" + ex.Source + "\r\n");
                return GetRetMsg(ex.Message, "");
            }
        }

        static  bool CheckXML(string mess)
        {
            try
            {
                XmlDocument xd = new XmlDocument();
                xd.LoadXml(mess);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 接收外部推送 数据
        /// </summary>
        /// <param name="method"></param>
        /// <param name="mess"></param>
        /// <returns></returns>
        public static string ReceiveMessage(string method, string mess)
        {
            ParamInputDomain domain = new ParamInputDomain();
            domain.Reserved1 = "Receive";
            domain.ReceiveMessage = mess;
            return MessageHander.MessageSwitch(domain).PreReceiveMsg(config, domain);
        }

        /// <summary>
        /// 手麻ICU 调用
        /// </summary>
        /// <param name="mess"></param>
        /// <returns></returns>
        public static string DocareMessage(string mess)
        {
            InitDocare.LogDALA.Debug("传入参数:mess" + mess);
            ParamInputDomain domain = PublicParmDoamin.ToParaDomain(mess);
            string re = DataReaderWebService.HanderDomain(domain);
            return re;
        }

        public static string GetRetMsg(string mess, string content)
        {
            if (string.IsNullOrEmpty(mess))
            {
                return "<RefMsg><flag>0</flag><msg></msg><content>" + content + "</content><tip></tip></RefMsg>";
            }
            else
            {
                //InitDocare.LogDALA.Debug("GetRetMsg:mess" + mess);

                return "<RefMsg><flag>1</flag><msg>" + mess.Replace("<", "").Replace(">", "") + "</msg><content></content><tip></tip></RefMsg>";
            }
        }

    }
}