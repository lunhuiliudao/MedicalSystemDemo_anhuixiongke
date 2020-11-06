 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Areas.UpdateServer.Controllers
{
    public class MainController : Controller
    {
        //
        // GET: /UpdateServer/Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Helper()
        {
            return View();
        }
    }
}
