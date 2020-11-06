using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Areas.UpdateServer.Controllers
{
    public class VersionController : Controller
    {
        // GET: Verion
        public ActionResult Index(string id)
        {
            return View();
        }

        /// <summary>
        /// 根据应用程序ID获取最新版本号
        /// </summary>
        /// <param name="appID"></param>
        /// <returns></returns>
        public ActionResult GetAppVerion(string appID)
        {
            DapperContext dapper = new DapperContext("docareConnString");
            if (appID == null)
            {
                appID = "";
            }

            int no = 1001;
            MED_VER_INFO info = dapper.Set<MED_VER_INFO>().Select(x => x.APP_ID.Equals(appID)).OrderByDescending(x => x.VER_NO).FirstOrDefault();
            if(info != null)
            {
                no = info.VER_NO + 1;
            }
            
            return Json(no);
        }

        /// <summary>
        /// 根据应用程序ID获取版本列表
        /// </summary>
        /// <param name="appID"></param>
        /// <returns></returns>
        public ActionResult GetList(string appID)
        {
            DapperContext dapper = new DapperContext("docareConnString");
            string sql = string.Format(@"SELECT A.*,B.APP_KEY,B.APP_NAME,C.DOWNLOAD_NUM,C.UPDATED_NUM FROM MED_VER_INFO A
                                        LEFT JOIN MED_APP_INFO B ON A.APP_ID=B.APP_ID
                                        LEFT JOIN (SELECT R.VER_ID,SUM(R.IS_DOWNLOAD) DOWNLOAD_NUM,SUM(R.IS_UPDATED) UPDATED_NUM FROM MED_VER_UPDATE_REC R
                                                    GROUP BY R.VER_ID) C ON A.VER_ID=C.VER_ID 
                                        WHERE 1=1 AND (A.APP_ID='{0}' OR '{0}' IS NULL)", appID);
            List<MED_VER_LIST> list = dapper.Set<MED_VER_LIST>().Query(sql);
            return Json(list);
        }

        public ActionResult GetAllList(string appID)
        {
            DapperContext dapper = new DapperContext("docareConnString");
            List<MED_VER_INFO> list = dapper.Set<MED_VER_INFO>().Select(x => x.APP_ID.Equals(appID)).OrderBy(x => x.VER_NO).ToList();
            return Json(list);
        }

        /// <summary>
        /// 根据版本ID修改版为强制更新
        /// </summary>
        /// <param name="verionID"></param>
        /// <returns></returns>
        public ActionResult UpdateVerInfoByForcibly(string id)
        {
            DapperContext dapper = new DapperContext("docareConnString");
            MED_VER_INFO info = dapper.Set<MED_VER_INFO>().Single(x => x.VER_ID.Equals(id));
            info.IS_FORCIBLY = 1;
            info.ModelStatus = ModelStatus.Modeified;
            bool result = dapper.Set<MED_VER_INFO>().Save(info);
            dapper.SaveChanges();
            return Json(result);
        }

        /// <summary>
        /// 测试转正式版
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult UpdateVerInfoByPublish(string id)
        {
            DapperContext dapper = new DapperContext("docareConnString");
            MED_VER_INFO info = dapper.Set<MED_VER_INFO>().Single(x => x.VER_ID.Equals(id));
            info.IS_TEST = 0;
            info.ModelStatus = ModelStatus.Modeified;
            bool result = dapper.Set<MED_VER_INFO>().Save(info);
            dapper.SaveChanges();
            return Json(result);
        }

        /// <summary>
        /// 回退版本视图
        /// </summary>
        /// <param name="verInfo"></param>
        /// <returns></returns>
        public ActionResult RollBackVerionView(string id)
        {
            DapperContext dapper = new DapperContext("docareConnString");
            MED_VER_INFO info = dapper.Set<MED_VER_INFO>().Single(x => x.VER_ID.Equals(id));
            if(null == info)
            {
                info = new MED_VER_INFO();
            }

            return View(info);
        }

        /// <summary>
        /// 更新回退原因
        /// </summary>
        /// <param name="verInfo"></param>
        /// <returns></returns>
        public ActionResult UpdateRollBackDesc(MED_VER_INFO verInfo)
        {
            DapperContext dapper = new DapperContext("docareConnString");
            try
            {
                if (verInfo == null || string.IsNullOrEmpty(verInfo.VER_ID))
                {
                    return Json("请选择应用程序版本来编辑！");
                }

                MED_VER_INFO info = dapper.Set<MED_VER_INFO>().Single(x => x.VER_ID.Equals(verInfo.VER_ID));
                //验证是否为最大版本号，并且是否已回退
                MED_VER_INFO maxVerInfo = dapper.Set<MED_VER_INFO>().Select(x => x.APP_ID.Equals(info.APP_ID)).OrderByDescending(x => x.VER_NO).FirstOrDefault();
                if (info.VER_NO != maxVerInfo.VER_NO)
                {
                    return Json("不是最大版本号！", "text/html");
                }
                if (info.ROLL_BACK == 1)
                {
                    return Json("此版本已回退！", "text/html");
                }
                info.ROLL_BACK = 1;
                info.ROLL_BACK_DESC = verInfo.ROLL_BACK_DESC;
                info.MODIFYER = " ";
                info.MODIFY_TIME = DateTime.Now;
                info.ModelStatus = ModelStatus.Modeified;
                bool rest = dapper.Set<MED_VER_INFO>().Save(info);
                dapper.SaveChanges();
                if (!rest)
                {
                    return Json("数据保存失败", "text/html");
                }
                else
                    return Json(true, "text/html");
            }
            catch (Exception ex)
            {
                return Json(ex.Message, "text/html");
            }
        }

        public ActionResult Delete(string id)
        {
            DapperContext dapper = new DapperContext("docareConnString");
            bool result = false;
            MED_VER_INFO verEntity = dapper.Set<MED_VER_INFO>().Single(x => x.VER_ID.Equals(id));
            if (verEntity != null)
            {
                List<MED_VER_INFO> verList = dapper.Set<MED_VER_INFO>().Select(x => x.APP_ID.Equals(verEntity.APP_ID)).OrderByDescending(x => x.VER_NO).ToList();
                if (verList[0].VER_NO != verEntity.VER_NO)
                {
                    return Json("您的版号不是最新版号!", "text/html");
                }
                else
                {
                    List<MED_VER_UPDATE_REC> logList = dapper.Set<MED_VER_UPDATE_REC>().Select(x => x.VER_ID.Equals(id));
                    if (logList.Count > 0)
                    {
                        return Json("此版号已有客户端更新过，不能删除!", "text/html");
                    }
                }
            }
            
            string baseUrl = Server.MapPath("/");
            string filePath = baseUrl + verEntity.FILE_PATH;
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
                //清空程序根目录下空文件夹         
                string path = Path.GetDirectoryName(filePath);
                if (Directory.Exists(path))
                {
                    DirectoryInfo subdir = new DirectoryInfo(path);
                    FileSystemInfo[] subFiles = subdir.GetFileSystemInfos();
                    if (subFiles.Length == 0)
                    {
                        Directory.Delete(path);
                    }
                }
            }

            result = dapper.Set<MED_VER_INFO>().Delete(verEntity);
            dapper.SaveChanges();
            return Json(result);
        }

    }
}
