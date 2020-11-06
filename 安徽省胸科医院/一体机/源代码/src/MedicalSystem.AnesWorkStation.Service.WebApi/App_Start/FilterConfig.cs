using System.Web;
using System.Web.Mvc;
using MedicalSystem.Services;

namespace MedicalSystem.AnesWorkStation.Service.WebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new MvcHandleErrorAttribute());
        }
    }

    public class MvcHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Logger.Error("WebApi错误：" + filterContext.RequestContext.HttpContext.Request.RawUrl, filterContext.Exception);
            base.OnException(filterContext);
        }
    }
}