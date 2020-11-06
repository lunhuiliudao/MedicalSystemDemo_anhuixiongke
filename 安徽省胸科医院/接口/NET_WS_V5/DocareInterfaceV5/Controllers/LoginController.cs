using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace NET_WS_V5.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View("Login");
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel loginfo)
        {
            if (loginfo.LogId.ToUpper() == "SSCJ" && loginfo.PassWord.ToUpper() == "SSCJ")
            {
                return RedirectToAction("Index","DataConfig");
            }
            ModelState.AddModelError("", "账号密码不正确");
            return View();
        }
    }
}
