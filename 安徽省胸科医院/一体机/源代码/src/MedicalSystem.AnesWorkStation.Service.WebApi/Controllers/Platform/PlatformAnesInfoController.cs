using Dapper.Data;
using MedicalSystem.AnesPlatform.Service.WebApi.App_Start.Swagger;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Domain.RequestResult;
using MedicalSystem.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers.Platform
{
    /// <summary>
    /// 手术室外麻醉记录
    /// </summary>
    [ControllerGroup("手术室外麻醉记录", "接口")]
    public class PlatformAnesInfoController : PlatformBaseController
    {
        IPlatformAnesInfoService AnesInfo;
        IPlatformSysConfigServices sysConfig;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="AnesInfoParam"></param>
        /// <param name="SysConfigPara"></param>
        public PlatformAnesInfoController(IPlatformAnesInfoService AnesInfoParam, IPlatformSysConfigServices SysConfigPara)
        {
            AnesInfo = AnesInfoParam;
            sysConfig = SysConfigPara;
        }

        /// <summary>
        /// 获取麻醉事件列表
        /// </summary>
        /// <param name="model">查询条件实体</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<dynamic> QueryOutOperatingAnesRecord(OperQueryParaModel model)
        {
            IList<dynamic> MedOperationMasterList = AnesInfo.GetOutOperatingAnesRecord(model);



            dynamic dynamicInfo = new { Total = MedOperationMasterList.Count, CurrentData = MedOperationMasterList.Skip((model.CurrentPage - 1) * model.PageSize).Take(model.PageSize).ToList() };
            return Success<dynamic>(dynamicInfo);
        }

        #region 同步患者信息
        /// <summary>
        /// 获取患者基本信息数据
        /// </summary>
        /// <param name="inpNo">  </param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<MED_PATS_IN_HOSPITAL> GetPatientMastInfo(string inpNo)
        {

            //获取系统配置是否根据住院号同步
            bool IsSyncByInpNo = Convert.ToBoolean(sysConfig.GetFromConfigTable("IsSyncByInpNo"));
            string result = "";
            if (IsSyncByInpNo)
            {
                result = sysConfig.SyncPatientInfoAndInHospitalByInpNo(inpNo);
            }
            else
            {
                result = sysConfig.SyncPatientInfoAndInHospital(inpNo);
            }

            MED_PATS_IN_HOSPITAL patModel = new MED_PATS_IN_HOSPITAL();
            //同步成功获取
            if (result == "")
            {
                if (IsSyncByInpNo)
                {
                    patModel = AnesInfo.GetPatsInHospitalListByInpNo(inpNo)[0];
                }
                else
                {
                    patModel = AnesInfo.GetPatsInHospitalListByID(inpNo)[0];
                }
            }
            else
            {
                return Success(patModel);
            }

            return Success(patModel);
        }



        /// <summary>
        /// 获取患者基本信息数据
        /// </summary>
        /// <param name="inpNo">  </param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<MED_PATS_IN_HOSPITAL> GetOpeartionMaster(string inpNo)
        {

            //获取系统配置是否根据住院号同步
            bool IsSyncByInpNo = Convert.ToBoolean(sysConfig.GetFromConfigTable("IsSyncByInpNo"));
            string result = "";
            if (IsSyncByInpNo)
            {
                result = sysConfig.SyncPatientInfoAndInHospitalByInpNo(inpNo);
            }
            else
            {
                result = sysConfig.SyncPatientInfoAndInHospital(inpNo);
            }

            MED_PATS_IN_HOSPITAL patModel = new MED_PATS_IN_HOSPITAL();
            //同步成功获取
            if (result == "")
            {
                if (IsSyncByInpNo)
                {
                    patModel = AnesInfo.GetPatsInHospitalListByInpNo(inpNo)[0];
                }
                else
                {
                    patModel = AnesInfo.GetPatsInHospitalListByID(inpNo)[0];
                }
            }
            else
            {
                return Success(patModel);
            }

            return Success(patModel);
        }

        /// <summary>
        /// 获取病人手术信息列表
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public virtual RequestResult<List<OutOperatingRoomAnesRecordEntity>> GetOutOperatingRoomAnesRecord(string inpNo)
        {
            List<OutOperatingRoomAnesRecordEntity> list = AnesInfo.GetOperationMaster(inpNo);
            //if (list.Count == 0)
            //{
            //    //没有数据 去同步
            //    //获取系统配置是否根据住院号同步
            //    bool IsSyncByInpNo = Convert.ToBoolean(sysConfig.GetFromConfigTable("IsSyncByInpNo"));
            //    string result = "";
            //    if (IsSyncByInpNo)
            //    {
            //        result = sysConfig.SyncPatientInfoAndInHospitalByInpNo(inpNo);
            //    }
            //    else
            //    {
            //        result = sysConfig.SyncPatientInfoAndInHospital(inpNo);
            //    }

            //    if (result == "")
            //    {
            //        list = AnesInfo.GetOperationMaster(inpNo);
            //    }
            //}

            //foreach (var item in list)
            //{
            //    if (item.OPERATION_NAME != null)
            //    {
            //        item.OPERATION_NAMES = item.OPERATION_NAME.Split('+');
            //    }
            //    else
            //    {
            //        item.OPERATION_NAMES = new string[] { };
            //    }

            //    if (item.diag_before_operation != null)
            //    {
            //        item.diag_before_operations = item.diag_before_operation.Split(';');
            //    }
            //    else
            //    {
            //        item.diag_before_operations = new string[] { };
            //    }
            //}
            return Success(list);
        }


        /// <summary>
        /// 获取病人手术信息列表
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public virtual RequestResult<List<OutOperatingRoomAnesRecordEntity>> GetOutOperatingRoomAnesRecordByPatient(string patientId, int visitId, int operId)
        {
            List<OutOperatingRoomAnesRecordEntity> list = new List<OutOperatingRoomAnesRecordEntity>();
            try
            {
                list = AnesInfo.GetOperationMaster(patientId, visitId, operId);

                foreach (var item in list)
                {
                    if (item.OPERATION_NAME != null)
                    {
                        item.OPERATION_NAMES = item.OPERATION_NAME.Split('+');
                    }

                    if (item.DIAG_BEFORE_OPERATION != null)
                    {
                        item.DIAG_BEFORE_OPERATIONS = item.DIAG_BEFORE_OPERATION.Split(';');
                    }
                }
                return Success(list);
            }
            catch (Exception ex)
            {
            }
            return Success(list);
        }

        /// <summary>
        /// 保存手术室外麻醉
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> SaveOutOperatingRoomAnesRecordData(OutOperatingRoomAnesRecordEntity model)
        {
            return Success(AnesInfo.SaveOutOperatingRoomAnesRecordData(model));
        }

        #endregion
    }
}
