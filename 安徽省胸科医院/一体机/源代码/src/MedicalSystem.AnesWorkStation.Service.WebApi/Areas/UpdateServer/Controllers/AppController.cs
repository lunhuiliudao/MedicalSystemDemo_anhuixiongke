using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Areas.UpdateServer.Controllers
{
    public class AppController : Controller
    {
        // GET: App
        public ActionResult List()
        {
            return View();
        }

        public ActionResult GetList()
        {
            DapperContext dapper = new DapperContext("docareConnString");
            List<MED_APP_INFO> result = dapper.Set<MED_APP_INFO>().Select();
            return Json(result);
        }

        public ActionResult MoidfyView(string id)
        {
            DapperContext dapper = new DapperContext("docareConnString");
            MED_APP_INFO info = dapper.Set<MED_APP_INFO>().Single(x => x.APP_ID.Equals(id));
            if(null == info)
            {
                info = new MED_APP_INFO();
            }

            return View(info);
        }

        public ActionResult Modify(MED_APP_INFO appInfo)
        {
            DapperContext dapper = new DapperContext("docareConnString");
            bool result = false;
            if (appInfo != null)
            {
                if (string.IsNullOrEmpty(appInfo.APP_ID))
                {
                    MED_APP_INFO info = dapper.Set<MED_APP_INFO>().Single(x => x.APP_KEY.Equals(appInfo.APP_KEY));
                    //判断重复KEY
                    if (null != info)
                    {
                        return Json("应用程序Key已存在!", "text/html");
                    }
                    appInfo.APP_ID = Guid.NewGuid().ToString();
                    appInfo.CREATE_TIME = DateTime.Now;
                    appInfo.ModelStatus = ModelStatus.Add;
                }
                else
                {
                    //编辑KEY不修改TODO:这里不可编辑暂未做后台认证
                    appInfo.ModelStatus = ModelStatus.Modeified;
                    appInfo.MODIFY_TIME = DateTime.Now;
                }

                result = dapper.Set<MED_APP_INFO>().Save(appInfo);
                dapper.SaveChanges();
            }

            return Json(result, "text/html");
        }

        public ActionResult Delete(string id)
        {
            DapperContext dapper = new DapperContext("docareConnString");
            bool result = false;
            List<MED_VER_INFO> verList = dapper.Set<MED_VER_INFO>().Select(x => x.APP_ID.Equals(id));
            if (verList.Count > 0)
            {
                return Json("应用程序下存在已发布版本记录!", "text/html");
            }

            MED_APP_INFO info = dapper.Set<MED_APP_INFO>().Single(x => x.APP_ID.Equals(id));
            info.ModelStatus = ModelStatus.Deleted;
            result = dapper.Set<MED_APP_INFO>().Delete(info);
            dapper.SaveChanges();
            return Json(result);
        }

    }
}
