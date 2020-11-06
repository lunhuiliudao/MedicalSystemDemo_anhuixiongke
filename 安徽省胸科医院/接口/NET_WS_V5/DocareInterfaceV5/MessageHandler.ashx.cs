using BLL;
using Init;
using MedicalSytem.Soft.InitDocare;
using MedicalSytem.Soft.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;

namespace NET_WS_V5
{
    /// <summary>
    /// MessageHandler 的摘要说明
    /// </summary>
    public class MessageHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");

            string mess = context.Request.Params["Json"];
            if (mess == null)
            {
                context.Response.Write("测试页面");
                context.Response.End();
                return;
            }
            try
            {
                ParamInputDomain domain = ToParaDomain(mess);
                string re = DataReaderWebService.HanderDomain(domain);
                context.Response.Write(ToUTF8(re));
                context.Response.End();
                return;
            }
            catch (Exception ex)
            {
                InitDocare.LogA.Debug("错误日志: &#xA;事件消息为: &#xA;" + ex.Message + "异常发生时，调用堆栈上的桢的字符串表现形式: &#xA;" + ex.StackTrace + "引发当前异常的函数为: &#xA;" + ex.TargetSite.Name + "导致错误的应用程序或对象的名称为: &#xA;" + ex.Source);

                context.Response.Write(ToUTF8(ex.Message));
                context.Response.End();
                return;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private   ParamInputDomain ToParaDomain(string joson)
        {
            using (MemoryStream ms2 = new MemoryStream(Encoding.UTF8.GetBytes(joson)))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ParamInputDomain));
                ParamInputDomain obj = serializer.ReadObject(ms2) as ParamInputDomain;
                return obj;
            }
        }

        private string ToUTF8(string re)
        {

            byte[] bytes = System.Text.Encoding.Default.GetBytes(re);
            string mess = System.Text.Encoding.Default.GetString(bytes);
            return mess;
        }
    }
}