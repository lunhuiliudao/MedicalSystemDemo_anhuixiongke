using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStationCoordination.Model;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Areas.UpdateServer.Controllers
{
    public class PublishController : Controller
    {
        Stream uploadStream = null;
        FileStream fs = null;

        // GET: Publish
        public ActionResult Index(string id)
        {
            DapperContext dapper = new DapperContext("docareConnString");
            MED_VER_INFO info = new MED_VER_INFO();
            if (string.IsNullOrEmpty(id))
            {
                ViewBag.Action = "Create";
                info.IS_FORCIBLY = 1;
                info.IS_TEST = 1;
                return View(info);
            }
            else
            {
                ViewBag.ReadOnly = "readonly";
                ViewBag.Action = "Update";
                info = dapper.Set<MED_VER_INFO>().Single(x => x.VER_ID.Equals(id));
                return View(info);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(MED_VER_INFO verInfo, HttpPostedFileBase postFileBase)
        {
            DapperContext dapper = new DapperContext("docareConnString");
            string erroMsg = string.Empty;
            try
            {
                //检测应用程序最大版本号，是否为测试版，如果为测试版又未回退，就不能发布新版
                if (!string.IsNullOrEmpty(verInfo.APP_ID))
                {
                    MED_VER_INFO maxNoVerInfo = dapper.Set<MED_VER_INFO>().Select(x => x.APP_ID.Equals(verInfo.APP_ID)).OrderByDescending(x => x.VER_NO).FirstOrDefault();
                    if (maxNoVerInfo == null || maxNoVerInfo.IS_TEST != 1 || (maxNoVerInfo.IS_TEST == 1 && maxNoVerInfo.ROLL_BACK == 1))
                    {
                        if (Request.Files.Count > 0)
                        {
                            MED_APP_INFO appInfo = dapper.Set<MED_APP_INFO>().Single(x => x.APP_ID.Equals(verInfo.APP_ID));
                            postFileBase = Request.Files[0];
                            //文件上传，一次上传1M的数据，防止出现大文件无法上传  
                            uploadStream = postFileBase.InputStream;
                            int bufferLen = 1024;
                            byte[] buffer = new byte[bufferLen];
                            int contentLen = 0;

                            string fileName = Path.GetFileName(postFileBase.FileName);
                            //判断扩展名
                            string[] extens = new string[] { ".zip" };
                            if (Array.Exists(extens, p => p.ToUpper() == System.IO.Path.GetExtension(fileName).ToUpper()))
                            {
                                string baseUrl = Server.MapPath("/");
                                string uploadPath = "UpdateFile" + @"\" + appInfo.APP_KEY + @"\";
                                //创建文件夹
                                string[] folderFile = uploadPath.Split(new String[] { @"\" }, StringSplitOptions.RemoveEmptyEntries);
                                String l = folderFile.LastOrDefault();
                                string cPath = baseUrl;
                                foreach (var item in folderFile)
                                {
                                    if (!item.Contains(":"))
                                    {
                                        cPath += @"\" + item;
                                        if (!Directory.Exists(cPath))
                                            Directory.CreateDirectory(cPath);
                                    }
                                }
                                //保存文件
                                string newFilename = verInfo.VER_NO + Path.GetExtension(fileName);
                                string newFilePath = baseUrl + @"\" + uploadPath + newFilename;
                                fs = new FileStream(newFilePath, FileMode.Create, FileAccess.ReadWrite);
                                while ((contentLen = uploadStream.Read(buffer, 0, bufferLen)) != 0)
                                {
                                    fs.Write(buffer, 0, bufferLen);
                                    fs.Flush();
                                }
                                fs.Close();
                                verInfo.FILE_PATH = uploadPath + newFilename;
                                //保存数据
                                verInfo.VER_ID = Guid.NewGuid().ToString();
                                verInfo.CREATE_TIME = DateTime.Now;
                                verInfo.ModelStatus = ModelStatus.Add;
                                bool rest = dapper.Set<MED_VER_INFO>().Save(verInfo);
                                dapper.SaveChanges();
                                MedicalSystem.Services.Logger.Info("上传完成");
                                if (!rest)
                                {
                                    //删除文件
                                    System.IO.File.Delete(newFilePath);
                                    erroMsg = "数据保存失败";
                                }
                                else
                                {
                                    MedicalSystem.Services.Logger.Info("发消息给客户端");
                                    // 发布消息给客户端
                                    MED_USERS user = new MED_USERS { LOGIN_NAME = "admin", USER_NAME = "admin", USER_JOB_ID = "admin", USER_JOB = "医生", USER_ROLE = "主任,管理员", isMDSD = true };

                                    if (System.Web.HttpContext.Current.Application["admin"] == null)
                                    {
                                        try
                                        {
                                            MedicalSystem.Services.Logger.Info("消息平台连接");
                                            TransMessageManager tmm = new TransMessageManager(user);
                                            tmm.OpenConnection();
                                            System.Web.HttpContext.Current.Application["admin"] = tmm;
                                            MedicalSystem.Services.Logger.Info("消息平台连接成功");
                                            // 设置消息体
                                            TransMessageModel tm = new TransMessageModel()
                                            {
                                                TargetClientEnumAppType = EnumAppType.AnesWorkStation,
                                                CurEnumMessageType = EnumMessageType.Broadcase,
                                                CurEnumFunctionType = EnumFunctionType.HasNewVersion,
                                                SourceClientEnumAppType = EnumAppType.Platform,
                                                MessageContent = appInfo.APP_KEY
                                            };
                                            MedicalSystem.Services.Logger.Info("发送消息");
                                            tmm.SendMsg(tm);
                                            MedicalSystem.Services.Logger.Info("发送消息完");
                                        }
                                        catch(Exception ex)
                                        {
                                            MedicalSystem.Services.Logger.Info("消息平台错误：" + ex.Message);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                erroMsg = "扩展名必须为zip";
                            }
                        }
                        else
                        {
                            erroMsg = "未选择要上传文件！";
                        }
                    }
                    else
                    {
                        erroMsg = "版本号" + maxNoVerInfo.VER_NO + "是测试版并没有回退版本！";
                    }
                }
                else
                {
                    erroMsg = "没有选择应用程序！";
                }
                if (!string.IsNullOrEmpty(erroMsg))
                    return Json(erroMsg, "text/html");
                else
                    return Json(true, "text/html");
            }
            catch (Exception ex)
            {
                erroMsg = ex.Message;
                return Json(erroMsg, "text/html");
            }
            finally
            {
                if (System.Web.HttpContext.Current.Application["admin"] != null)
                {
                    TransMessageManager tmm = System.Web.HttpContext.Current.Application["admin"] as TransMessageManager;
                    tmm.CloseConnection();
                    System.Web.HttpContext.Current.Application.Remove("admin");
                }
            }
        }

        public ActionResult Update(MED_VER_INFO verInfo)
        {
            DapperContext dapper = new DapperContext("docareConnString");
            try
            {
                if (verInfo == null || string.IsNullOrEmpty(verInfo.VER_ID))
                {
                    return Json("请选择应用程序版本来编辑！", "text/html");
                }
                MED_VER_INFO info = dapper.Set<MED_VER_INFO>().Single(x => x.VER_ID.Equals(verInfo.VER_ID)); 
                info.IS_FORCIBLY = verInfo.IS_FORCIBLY == null ? 0 : (int)verInfo.IS_FORCIBLY;
                info.IS_TEST = verInfo.IS_TEST == null ? 0 : (int)verInfo.IS_TEST;
                info.DESCRIPTION = verInfo.DESCRIPTION;
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
    }
}
