using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(MedicalSystem.AnesWorkStation.Service.WebApi.Startup))]

namespace MedicalSystem.AnesWorkStation.Service.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkID=316888

            // app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
            //消息总线--集线器Hub配置
            //app.Map("/MessageHub", map => {
            //    //SignalR允许跨域调用
            //    map.UseCors(CorsOptions.AllowAll);
            //    HubConfiguration config = new HubConfiguration()
            //    {
            //        //禁用JavaScript代理
            //        EnableJavaScriptProxies = false,
            //        //启用JSONP跨域
            //        EnableJSONP = true,
            //        //反馈结果给客户端
            //        EnableDetailedErrors = true
            //    };
            //    map.RunSignalR(config);
            //});

            ////WebApi允许跨域调用
            //app.UseCors(CorsOptions.AllowAll);
        }
    }
}
