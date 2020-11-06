using Entitys;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace NET_WS_V5.Controllers
{
    public class WebConfigController : Controller
    {
        //
        // GET: /WebConfig/

        public ActionResult Index()
        {
            DataConfig config = new DataConfig();
            config.DataBase = ConfigurationManager.AppSettings.GetValues("DataBase")[0];
            config.DataServerType = ConfigurationManager.AppSettings.GetValues("DataServerType")[0];
            config.UserId = ConfigurationManager.AppSettings.GetValues("UserId")[0];
            config.PassWord = ConfigurationManager.AppSettings.GetValues("PassWord")[0];
            config.ServerName = ConfigurationManager.AppSettings.GetValues("ServerName")[0];
            config.WebServerUrlA = ConfigurationManager.AppSettings.GetValues("WebServerUrlA")[0];
            config.WebServerUrlB = ConfigurationManager.AppSettings.GetValues("WebServerUrlB")[0];
            config.WebServerUrlC = ConfigurationManager.AppSettings.GetValues("WebServerUrlC")[0];
            config.WebServerUrlD = ConfigurationManager.AppSettings.GetValues("WebServerUrlD")[0];
            config.WebServerUrlE = ConfigurationManager.AppSettings.GetValues("WebServerUrlE")[0];
            return View(config);
        }

        public ActionResult Edit()
        {
            DataConfig config = new DataConfig();
            config.DataBase = ConfigurationManager.AppSettings.GetValues("DataBase")[0];
            config.DataServerType = ConfigurationManager.AppSettings.GetValues("DataServerType")[0];
            config.UserId = ConfigurationManager.AppSettings.GetValues("UserId")[0];
            config.PassWord = ConfigurationManager.AppSettings.GetValues("PassWord")[0];
            config.ServerName = ConfigurationManager.AppSettings.GetValues("ServerName")[0];
            config.WebServerUrlA = ConfigurationManager.AppSettings.GetValues("WebServerUrlA")[0];
            config.WebServerUrlB = ConfigurationManager.AppSettings.GetValues("WebServerUrlB")[0];
            config.WebServerUrlC = ConfigurationManager.AppSettings.GetValues("WebServerUrlC")[0];
            config.WebServerUrlD = ConfigurationManager.AppSettings.GetValues("WebServerUrlD")[0];
            config.WebServerUrlE = ConfigurationManager.AppSettings.GetValues("WebServerUrlE")[0];

            List<string> str = new List<string>();
            str.Add("SQLSERVER");
            str.Add("ORACLE");
            str.Add("ORACLEOLE");
            ViewData["DDL"] = new SelectList(str);
            return View(config);
        }

        [HttpPost]
        public ActionResult Edit(string id, DataConfig config)
        {
            Configuration objConfig = WebConfigurationManager.OpenWebConfiguration("~");
            AppSettingsSection objAppSettings = (AppSettingsSection)objConfig.GetSection("appSettings");

            //objAppSettings.Settings["DataBase"].Value = config.DataBase;
            //objAppSettings.Settings["DataServerType"].Value = config.DataServerType;
            //objAppSettings.Settings["ServerName"].Value = config.ServerName;
            //objAppSettings.Settings["UserId"].Value = config.UserId;
            //objAppSettings.Settings["PassWord"].Value = config.PassWord;

            objAppSettings.Settings["WebServerUrlA"].Value = config.WebServerUrlA;
            objAppSettings.Settings["WebServerUrlB"].Value = config.WebServerUrlB;
            objAppSettings.Settings["WebServerUrlC"].Value = config.WebServerUrlC;
            objAppSettings.Settings["WebServerUrlD"].Value = config.WebServerUrlD;
            objAppSettings.Settings["WebServerUrlE"].Value = config.WebServerUrlE;

            string sql = "";
            if (config.DataServerType == "ORACLE")
            {
                sql = "Persist Security Info=True;Data Source=" + config.ServerName + ";Password=" + config.PassWord + ";User ID=" + config.UserId + ";Unicode=True;";
            }
            else if (config.DataServerType == "SQLSERVER")
            {
                sql = "Data Source=" + config.ServerName + ";Initial Catalog =" + config.DataBase + ";Password=" + config.PassWord + ";User ID=" + config.UserId + ";";
            }
            else if (config.DataServerType == "ORAOLE")
            {
                sql = "Provider=MSDAORA;Data Source=" + config.ServerName + ";Password=" + config.PassWord + ";User ID=" + config.UserId + ";";
            }
            ConnectionStringsSection conSec = (ConnectionStringsSection)objConfig.GetSection("connectionStrings");
            conSec.ConnectionStrings["ConnString"].ConnectionString = sql;
            objConfig.Save();
            List<string> str = new List<string>();
            str.Add("SQLSERVER");
            str.Add("ORACLE");
            str.Add("ORACLEOLE");
            ViewData["DDL"] = new SelectList(str);
            return RedirectToAction("Index");
        }
    }
}
