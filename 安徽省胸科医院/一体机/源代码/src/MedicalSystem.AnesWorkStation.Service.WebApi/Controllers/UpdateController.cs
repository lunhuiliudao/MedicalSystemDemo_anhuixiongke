using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Script.Serialization;
using UpdateEntity;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers
{
    public class UpdateController : BaseController
    {
        IUpdateService updateService;

        public UpdateController(IUpdateService _updateService)
        {
            updateService = _updateService;
        }

        /// <summary>
        /// 验证是否有更新
        /// </summary>
        /// <param name="appID">应用程序ID</param>
        /// <param name="verion">当前版本号</param>
        /// <param name="isTest">是否为测试程序,传 1为是</param>
        /// <returns></returns>
        [HttpGet]
        public ApiResult<List<UpdateInfoEntity>> CheckUpdate(string appKey,string verion,string isTest)
        {
            ApiResult<List<UpdateInfoEntity>> result = new ApiResult<List<UpdateInfoEntity>>();
            result.Data = new List<UpdateInfoEntity>();
            //判断当前版本是否为回退版
            string appID = string.Empty;
            MED_APP_INFO info = this.updateService.GetAppInfoByAppKey(appKey);
            if (info == null)
            {
                result.Msg = "应用程序主键不存在";
            }
            else
            {
                appID = info.APP_ID;
                List<MED_VER_INFO> versionList = this.updateService.GetListByAppIDAndVerio(appID, verion, isTest);
                if (versionList != null)
                {
                    foreach (MED_VER_INFO item in versionList)
                    {
                        UpdateInfoEntity entity = new UpdateInfoEntity();
                        entity.VerionNo = item.VER_NO;
                        entity.Description = item.DESCRIPTION;
                        entity.IsRollBack = item.ROLL_BACK ?? 0;
                        entity.RollBackDesc = item.ROLL_BACK_DESC;
                        entity.IsForcibly = item.IS_FORCIBLY ?? 0;
                        entity.FilePath = item.FILE_PATH;
                        result.Data.Add(entity);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 上传版本更新记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ApiResult<bool> UploadUpdateRec([FromBody]MachineInfoEntity entity)
        {
            //MachineInfoEntity entity = JsonConvert.DeserializeObject<MachineInfoEntity>(par);
            ApiResult<bool> result = new ApiResult<bool>();
            try
            {
                //根据应用程序Key和版本号判断是否存在数据
                MED_APP_INFO appInfo= this.updateService.GetAppInfoByAppKey(entity.AppKey);
                MED_VER_INFO verInfo = this.updateService.GetVer_InfoByAppIDAndVerion(appInfo.APP_ID, entity.VerionNo.ToString());
                if (verInfo != null)
                {
                    //根据IP、版ID获取更新记录 存在更新，不存插入数据
                    MED_VER_UPDATE_REC verUpdateRecEntity = this.updateService.GetVerUpdateRecByIPAndVerionID(entity.IP, verInfo.VER_ID);
                    if (verUpdateRecEntity == null)
                    {
                        //插入
                        verUpdateRecEntity = new MED_VER_UPDATE_REC();
                        verUpdateRecEntity.UP_ID = Guid.NewGuid().ToString();
                        verUpdateRecEntity.APP_NAME = appInfo.APP_NAME;
                        verUpdateRecEntity.VER_ID = verInfo.VER_ID;
                        verUpdateRecEntity.IP = entity.IP;
                        verUpdateRecEntity.SYSTEM_NAME = entity.SystemName;
                        verUpdateRecEntity.CREATE_TIME = DateTime.Now;
                        verUpdateRecEntity.ModelStatus = ModelStatus.Add;
                    }

                    if (entity.IsDownload == 1)
                    {
                        verUpdateRecEntity.IS_DOWNLOAD = entity.IsDownload;
                        verUpdateRecEntity.DOWNLOAD_TIME = entity.DownloadTime;
                    }
                    if (entity.IsUpdated == 1)
                    {
                        verUpdateRecEntity.IS_UPDATED = entity.IsUpdated;
                        verUpdateRecEntity.UPDATED_TIME = entity.UpdatedTime;
                    }
                    if (entity.IsRollBack == 1)
                    {
                        verUpdateRecEntity.ROLL_BACK = entity.IsRollBack;
                        verUpdateRecEntity.ROLL_BACK_TIME = entity.RollBackTime;
                    }

                    result.Data = this.updateService.SaveVerUpdateRec(verUpdateRecEntity);
                }
                else
                {
                    result.Msg = "此版本号不存在！";
                    result.Data = false;
                }
            }
            catch (Exception ex)
            {
                result.Msg = ex.ToString();
                result.Data = false;
            }        
            return result;
        }

        /// <summary>
        /// 获取定时长
        /// </summary>
        [HttpGet]
        public ApiResult<int> GetUpdateTime()
        {
            ApiResult<int> result = new ApiResult<int>();
            try
            {
                MED_SYSTEM_CONFIG entity = this.updateService.GetSingleTopOn();
                if (entity == null)
                    result.Data = 0;
                else
                {
                    JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                    SystemConfig config = new SystemConfig();
                    config = jsonSerializer.Deserialize<SystemConfig>(entity.CONFIG_JSON);
                    result.Data = config.TimingUpdateTime;
                }
            }
            catch (Exception ex)
            {
                result.Msg = ex.ToString();
                result.Data = 0;
            }
            return result;
        }
    }
}