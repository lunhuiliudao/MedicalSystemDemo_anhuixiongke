using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.AnesWorkStation.DataServices.WebApi
{
    public class MyHttpClienHanlder : HttpClientHandler
    { 
        /// <summary>
        /// 重载异步发送
        /// </summary>
        /// <param name="request">请求消息</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(WebApiVisitor.Token))
            {
                CookieContainer objCookie = new CookieContainer();
                objCookie.Add(new Uri(WebApiVisitor.WebApiUri), new Cookie(WebApiSetting.TOKENKEY, WebApiVisitor.Token));
                this.CookieContainer = objCookie;
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}
