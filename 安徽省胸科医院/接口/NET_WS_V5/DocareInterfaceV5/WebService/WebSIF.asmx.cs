using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace NET_WS_V5.WebService
{
    /// <summary>
    /// WebSIF 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebSIF : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        /// 手麻集成平台推送消息入口
        /// </summary>
        /// <param name="method">方法名称</param>
        /// <param name="mess">消息内容</param>
        /// <returns></returns>
        public string SendMessage(string method, string mess)
        {
            return DataReaderWebService.ReceiveMessage(method, mess);
        }
    }
}
