using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using UpdateEntity;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Areas.UpdateServer.Controllers
{
    public class SystemManagementController : Controller
    {
        // GET: SystemManagement
        public ActionResult Index()
        {
            DapperContext dapper = new DapperContext("docareConnString");
            SystemConfig config = new SystemConfig();
            MED_SYSTEM_CONFIG entity = dapper.Set<MED_SYSTEM_CONFIG>().Select().FirstOrDefault();
            if (entity != null)
            {
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                config = jsonSerializer.Deserialize<SystemConfig>(entity.CONFIG_JSON);
                ViewBag.SYS_ID = entity.SYS_ID;
            }
            return View(config);
        }

        public ActionResult Modify(SystemConfig appInfo)
        {
            DapperContext dapper = new DapperContext("docareConnString");
            MED_SYSTEM_CONFIG entity = dapper.Set<MED_SYSTEM_CONFIG>().Select().FirstOrDefault();
            bool result = false;
            if (entity == null)
            {
                entity = new MED_SYSTEM_CONFIG();
                entity.SYS_ID = Guid.NewGuid().ToString();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                entity.CONFIG_JSON = jsonSerializer.Serialize(appInfo);
                result = dapper.Set<MED_SYSTEM_CONFIG>().Insert(entity);
                dapper.SaveChanges();
            }
            else
            {
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                entity.CONFIG_JSON = jsonSerializer.Serialize(appInfo);
                entity.ModelStatus = ModelStatus.Modeified;
                result = dapper.Set<MED_SYSTEM_CONFIG>().Save(entity);
                dapper.SaveChanges();
            }

            return Json(true, "text/html");
        }

    }
}
