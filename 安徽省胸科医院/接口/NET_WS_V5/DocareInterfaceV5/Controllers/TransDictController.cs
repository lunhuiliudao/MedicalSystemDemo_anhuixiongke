using BLL;
using Entitys;
using MedicalSytem.Soft.DAL;
using MedicalSytem.Soft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NET_WS_V5.Controllers
{
 
    public class TransDictController : Controller
    {
        HospitalBase hb = new HospitalBase();

        public ActionResult Index()
        {
            List<MedIfTransDict> transDict = hb.SelectMedIfTransDict();

            List<MedIfTrans> entityList = new List<MedIfTrans>();
            foreach (MedIfTransDict entity in transDict)
            { 
                var v= new  MedIfTrans(){
                    DataBase=entity.Database,
                    DBMS= entity.Dbms.ToString(),
                    DbParm= entity.Dbparm, 
                    LogId=entity.LogId,
                    LogPass=entity.LogPass,
                    Memo=entity.Memo,
                    NlsLang = entity.TransName,
                    ServerName=entity.ServerName, 
                    TransName=entity.TransName};
                if (entity.Dbms == EnumDataBase.Undefined)
                {
                    v.DBMS = "未定义";
                }
                entityList.Add(v);
            }
            return View(entityList);
        }

        public ActionResult Edit(string transName)
        {
            List<MedIfTransDict> transDict = hb.SelectMedIfTransDict();
            MedIfTransDict entity = transDict.Find(p => p.TransName == transName);

            List<string> str = new List<string>();
            str.Add("ODBC");
            str.Add("ORACLE");
            str.Add("OLEDB");
            str.Add("SQLSERVER");
            str.Add("MYSQL");
            ViewData["DDL"] = new SelectList(str);
            var v = new MedIfTrans() {  NlsLang=entity.TransName,
                DataBase = entity.Database, 
                DBMS = entity.Dbms.ToString(), 
                DbParm = entity.Dbparm,
                LogId = entity.LogId,
                LogPass = entity.LogPass, 
                ServerName = entity.ServerName,
                TransName = entity.TransName };       
            return View(v);
        }

        [HttpPost]
        public ActionResult Edit(MedIfTrans config)
        {
            List<string> str = new List<string>();
            str.Add("ODBC");
            str.Add("ORACLE");
            str.Add("OLEDB");
            str.Add("SQLSERVER");
            str.Add("MYSQL");
            ViewData["DDL"] = new SelectList(str);
            string conn = "";
            if (config.DBMS == "ORACLE")
            {
                conn = "Persist Security Info=True;Data Source=" + config.ServerName + ";Password=" + config.LogPass + ";User ID=" + config.LogId + ";Unicode=True;";
            }
            else if (config.DBMS == "ORACLEOLE")
            {
                conn = "Provider=MSDAORA;Data Source=" + config.ServerName + ";Password=" + config.LogPass + ";User ID=" + config.LogId + ";";

            }
            else if (config.DBMS == "SQLSERVER" || config.DBMS == "SQLSVR2008")
            {
                conn = "Data Source = " + config.ServerName + "; Initial Catalog = " + config.DataBase + "; User Id = " + config.LogId + "; Password = " + config.LogPass + ";";
            }
            else if (config.DBMS == "ODBC")
            {
                conn = "Dsn=" + config.ServerName + ";uid=" + config.LogId + ";pwd=" + config.LogPass + ";";
            }

            List<MedIfTransDict> transDict = hb.SelectMedIfTransDict();

            MedIfTransDict dicttemp = new MedIfTransDict();
            if (config.NlsLang != config.TransName) //修改transName
            {
                if (transDict.SingleOrDefault(p => p.TransName == config.TransName) != null)
                {
                    ModelState.AddModelError("", "已经存在此TransName");
                    return View(config);
                }
            }

            dicttemp.TransName = config.TransName;
            dicttemp.LogId = config.LogId;
            dicttemp.LogPass = config.LogPass;
            dicttemp.NlsLang = config.NlsLang;
            dicttemp.Database = config.DataBase;
            if (config.DBMS == "ORACLE")
                dicttemp.Dbms = EnumDataBase.ORACLE;
            else if (config.DBMS == "SQLSERVER")
                dicttemp.Dbms = EnumDataBase.SQLSERVER;
            else if (config.DBMS == "ORACLEOLE")
                dicttemp.Dbms = EnumDataBase.OLEDB;
            else if (config.DBMS == "ODBC")
                dicttemp.Dbms = EnumDataBase.ODBC;
            else if (config.DBMS == "MYSQL")
                dicttemp.Dbms = EnumDataBase.MYSQL;
            else
                dicttemp.Dbms = EnumDataBase.Undefined;
            dicttemp.Dbparm = conn;
            dicttemp.ServerName = config.ServerName;

            if (hb.UpdateMedIfTransDict(dicttemp) == 1)
            {
                return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError("", "更新失败");
            return View(config);
        }

        public ActionResult Create()
        {

            List<string> str = new List<string>();
            str.Add("ODBC");
            str.Add("ORACLE");
            str.Add("OLEDB");
            str.Add("SQLSERVER");
            str.Add("MYSQL");
            ViewData["DDL"] = new SelectList(str);
            return View();
        }

        [HttpPost]
        public ActionResult Create(MedIfTrans config)
        {
            List<string> str = new List<string>();
            str.Add("ODBC");
            str.Add("ORACLE");
            str.Add("OLEDB");
            str.Add("SQLSERVER");
            str.Add("MYSQL");
            ViewData["DDL"] = new SelectList(str);
            if (config.DBMS == "SQLSERVER")
            {
                if (config.DataBase == null)
                {
                    ModelState.AddModelError("", "SQLSERVER数据库数据库名称不能为空");
                    return View(config);
                }
            }

            string conn = "";
            if (config.DBMS == "ORACLE")
            {
                conn = "Persist Security Info=True;Data Source=" + config.ServerName + ";Password=" + config.LogPass + ";User ID=" + config.LogId + ";Unicode=True;";
            }
            else if (config.DBMS == "ORACLEOLE")
            {
                conn = "Provider=MSDAORA;Data Source=" + config.ServerName + ";Password=" + config.LogPass + ";User ID=" + config.LogId + ";";

            }
            else if (config.DBMS == "SQLSERVER" || config.DBMS == "SQLSVR2008")
            {
                conn = "Data Source = " + config.ServerName + "; Initial Catalog = " + config.DataBase + "; User Id = " + config.LogId + "; Password = " + config.LogPass + ";";
            }
            else if (config.DBMS == "ODBC")
            {
                conn = "Dsn=" + config.ServerName + ";uid=" + config.LogId + ";pwd=" + config.LogPass + ";";
            }

            MedIfTransDict dicttemp = new MedIfTransDict();
            dicttemp.TransName = config.NlsLang;
            dicttemp.LogId = config.LogId;
            dicttemp.LogPass = config.LogPass;
            dicttemp.Database = config.DataBase;
            if (config.DBMS == "ORACLE")
                dicttemp.Dbms = EnumDataBase.ORACLE;
            else if (config.DBMS == "SQLSERVER")
                dicttemp.Dbms = EnumDataBase.SQLSERVER;
            else if (config.DBMS == "ORACLEOLE")
                dicttemp.Dbms = EnumDataBase.OLEDB;
            else if (config.DBMS == "ODBC")
                dicttemp.Dbms = EnumDataBase.ODBC;
            else if (config.DBMS == "MYSQL")
                dicttemp.Dbms = EnumDataBase.MYSQL;
            else
                dicttemp.Dbms = EnumDataBase.Undefined;
            dicttemp.Dbparm = conn;
            dicttemp.ServerName = config.ServerName;

            if (hb.SelectMedIfTransDict().SingleOrDefault(p => p.TransName == dicttemp.TransName)!=null)
            {
                ModelState.AddModelError("", "已经存在此TransName名称");
                return View(config);
            }

            if (hb.InsertMedIfTransDict(dicttemp) == 1)
            {
                return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError("", "插入失败");

            return View(config);
        }
    }
}
