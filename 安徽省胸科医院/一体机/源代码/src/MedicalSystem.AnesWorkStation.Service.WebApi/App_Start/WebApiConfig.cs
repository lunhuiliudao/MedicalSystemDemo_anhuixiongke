using MedicalSystem.AnesWorkStation.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using MedicalSystem.Services;
using MedicalSystem.AnesWorkStation.Domain.RequestResult;

namespace MedicalSystem.AnesWorkStation.Service.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

#if DEBUG
            // 若要在应用程序中禁用跟踪，请注释掉或删除以下代码行
            // 有关详细信息，请参阅: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
#endif

            config.Filters.Add(new WebApiExceptionFilter());
        }

        public class WebApiExceptionFilter : ExceptionFilterAttribute
        {
            public override void OnException(HttpActionExecutedContext context)
            {
                Logger.Error("WebApi错误：" + HttpContext.Current.Request.RawUrl, context.Exception);

                string message = JsonConvert.SerializeObject(new RequestResult<Exception>()
                {
                    Result = ResultStatus.Exception,
                    Data = context.Exception,
                    Message = "WebAPI内部错误," + context.Exception.Message
                },
                    GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings);

                context.Response = new HttpResponseMessage() { Content = new StringContent(message) };

                base.OnException(context);
            }
        }
    }
}
