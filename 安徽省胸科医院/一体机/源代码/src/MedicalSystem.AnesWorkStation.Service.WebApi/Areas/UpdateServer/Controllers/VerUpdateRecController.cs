using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Areas.UpdateServer.Controllers
{
    public class VerUpdateRecController : Controller
    {
        /// <summary>
        /// 版本更新记录视图
        /// </summary>
        /// <returns></returns>
        public ActionResult VerUpdateRecView(string id)
        {
            ViewBag.VER_ID = id;
            return View();
        }

        /// <summary>
        /// 版本更新记录列表
        /// </summary>
        /// <returns></returns>
        public ActionResult VerUpdateRecList(string verionID)
        {
            DapperContext dapper = new DapperContext("docareConnString");
            List<MED_VER_UPDATE_REC> list = dapper.Set<MED_VER_UPDATE_REC>().Select(x => x.VER_ID.Equals(verionID)).OrderBy(x => x.CREATE_TIME).ToList();
            return Json(list);
        }

        /// <summary>
        /// 按条件来获取更新记录视图
        /// </summary>
        /// <param name="appID"></param>
        /// <param name="verionID"></param>
        /// <returns></returns>
        public ActionResult VerUpdateAllView()
        {
            return View();
        }

        /// <summary>
        /// 招安条件来获取更新记录
        /// </summary>
        /// <param name="appID"></param>
        /// <param name="verionID"></param>
        /// <returns></returns>
        public ActionResult VerUpdateAllList(string appID, string verionID)
        {
            DapperContext dapper = new DapperContext("docareConnString");
            string sql = string.Format(@"SELECT A.*,B.VER_NO,C.APP_KEY FROM MED_VER_UPDATE_REC A
                                        LEFT JOIN MED_VER_INFO B ON A.VER_ID =B.VER_ID 
                                        LEFT JOIN MED_APP_INFO C ON C.APP_ID=B.APP_ID 
                                        WHERE 1=1 AND (C.APP_ID='' OR '' IS NULL) AND (A.VER_ID='' OR '' IS NULL)", appID, verionID);
            List<MED_VER_UPDATE_REC_LIST> list = dapper.Set<MED_VER_UPDATE_REC_LIST>().Query(sql).OrderBy(x => x.CREATE_TIME).ToList();
            return Json(list);
        }
    }
}
