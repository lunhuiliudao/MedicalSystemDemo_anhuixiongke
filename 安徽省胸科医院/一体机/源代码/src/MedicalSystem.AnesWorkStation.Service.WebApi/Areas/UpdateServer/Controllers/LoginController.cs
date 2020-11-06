using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Areas.UpdateServer.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /UpdateServer/Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult LoginIn(string userName, string password)
        {
            if (userName == "admin" && password == "mdsdss")
            {
                Session[System.Configuration.ConfigurationManager.AppSettings["AuthSaveKey"]] = userName;
                return Json(true);
            }
            else
                return Json(false);
        }

        public ActionResult LoginOut()
        {
            Session[System.Configuration.ConfigurationManager.AppSettings["AuthSaveKey"]] = null;
            return RedirectToAction("Index"); ;
        }
    }
}
