using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "麻醉信息工作站-数据服务器";
            //ViewBag.Url = 
            string host = "";
            if (System.Web.HttpContext.Current == null || System.Web.HttpContext.Current.Request == null)
                host = "";

            HttpRequest Request = System.Web.HttpContext.Current.Request;

            host = Request.Url.Scheme + "://" + Request.Url.Host;
            if (Request.Url.Port != 80)
            {
                host += ":" + Request.Url.Port;
            }
            // 虚拟目录
            host += Request.ApplicationPath;
            // 必须以斜杠结束。
            if (!host.EndsWith("/"))
            {
                host += "/";
            }
            ViewBag.Url = host;

            return View();
        }
    }
}
