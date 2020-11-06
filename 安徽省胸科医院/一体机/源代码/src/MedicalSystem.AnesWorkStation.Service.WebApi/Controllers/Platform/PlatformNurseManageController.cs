
using MedicalSystem.AnesPlatform.Service.WebApi.App_Start.Swagger;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Domain.RequestResult;
using MedicalSystem.AnesWorkStation.Domain.ViewModule;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers.Platform
{
    /// <summary>
    /// 护理管理
    /// </summary>
    [ControllerGroup("护理管理", "接口")]
    public class PlatformNurseManageController : PlatformBaseController
    {
        IPlatformNurseManageService nurseManageService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="nurseManageServiceParam"></param>
        public PlatformNurseManageController(IPlatformNurseManageService nurseManageServiceParam)
        {
            nurseManageService = nurseManageServiceParam;
        }
        /// <summary>
        /// 手术病人查询
        /// </summary>
        [HttpPost]
        public RequestPageResult<List<dynamic>> GetPatientInfoList(OperQueryParaModel model)
        {
            List<dynamic> list = nurseManageService.GetPatientInfoList(model);

            List<dynamic> pageList = list;
            //分页处理
            if (list.Count > model.PageSize)
            {
                pageList = pageList.Skip((model.CurrentPage - 1) * model.PageSize).Take(model.PageSize).ToList();
            }
            return PageSuccess(pageList, model.PageSize, model.CurrentPage, list.Count);
        }
        /// <summary>
        /// 手术病人查询
        /// </summary>
        [HttpGet]
        public RequestResult<dynamic> GetPatientDetailInfo(string PATIENTID, string VISITID, string OPERID)
        {
            dynamic list = nurseManageService.GetPatientDetailInfo(PATIENTID, VISITID, OPERID);
            return Success(list);
        }

        /// <summary>
        /// 获取术后自定义数据
        /// </summary>
        [HttpGet]
        public RequestResult<dynamic> GetCustomData(string PATIENTID, string VISITID, string OPERID)
        {
            dynamic list = nurseManageService.GetCustomData("med_postoperative_extended", PATIENTID, VISITID, OPERID);
            return Success(list);
        }

        /// <summary>
        /// 保存术前自定义表
        /// </summary>
        [HttpPost]
        public RequestResult<dynamic> SaveMedPreoperativeExpansion(dynamic data)
        {
            List<MED_PREOPERATIVE_EXPANSION> list = new List<MED_PREOPERATIVE_EXPANSION>();
            string patient_id = data.PATIENTID.ToString();
            int visit_id = Convert.ToInt32(data.VISITID);
            int oper_id = Convert.ToInt32(data.OPERID);
            for (int i = 0; i < ((JContainer)data.customData).Count; i++)
            {
                MED_PREOPERATIVE_EXPANSION model = new MED_PREOPERATIVE_EXPANSION();
                model.PATIENT_ID = patient_id;
                model.VISIT_ID = visit_id;
                model.OPER_ID = oper_id;
                model.ITEM_NAME = ((JProperty)((JContainer)data.customData).ToList()[i]).Name.Replace("__", ".");
                model.ITEM_VALUE = ((JProperty)((JContainer)data.customData).ToList()[i]).Value.ToString();
                list.Add(model);
            }
            return Success<dynamic>(nurseManageService.SaveMedPreoperativeExpansion(list));
        }

        /// <summary>
        /// 保存术中自定义表
        /// </summary>
        [HttpPost]
        public RequestResult<dynamic> SaveMedOperationExtended(dynamic data)
        {
            List<MED_OPERATION_EXTENDED> list = new List<MED_OPERATION_EXTENDED>();
            string patient_id = data.PATIENTID.ToString();
            int visit_id = Convert.ToInt32(data.VISITID);
            int oper_id = Convert.ToInt32(data.OPERID);
            for (int i = 0; i < ((JContainer)data.customData).Count; i++)
            {
                MED_OPERATION_EXTENDED model = new MED_OPERATION_EXTENDED();
                model.PATIENT_ID = patient_id;
                model.VISIT_ID = visit_id;
                model.OPER_ID = oper_id;
                model.ITEM_NAME = ((JProperty)((JContainer)data.customData).ToList()[i]).Name.Replace("__", ".");
                model.ITEM_VALUE = ((JProperty)((JContainer)data.customData).ToList()[i]).Value.ToString();
                list.Add(model);
            }
            return Success<dynamic>(nurseManageService.SaveMedOperationExtended(list));
        }

        /// <summary>
        /// 保存术后自定义表
        /// </summary>
        [HttpPost]
        public RequestResult<dynamic> SaveMedPostoperaticeExtended(dynamic data)
        {
            List<MED_POSTOPERATIVE_EXTENDED> list = new List<MED_POSTOPERATIVE_EXTENDED>();
            string patient_id = data.PATIENTID.ToString();
            int visit_id = Convert.ToInt32(data.VISITID);
            int oper_id = Convert.ToInt32(data.OPERID);
            for (int i = 0; i < ((JContainer)data.customData).Count; i++)
            {
                MED_POSTOPERATIVE_EXTENDED model = new MED_POSTOPERATIVE_EXTENDED();
                model.PATIENT_ID = patient_id;
                model.VISIT_ID = visit_id;
                model.OPER_ID = oper_id;
                model.ITEM_NAME = ((JProperty)((JContainer)data.customData).ToList()[i]).Name.Replace("__", ".");
                model.ITEM_VALUE = ((JProperty)((JContainer)data.customData).ToList()[i]).Value.ToString();
                list.Add(model);
            }
            return Success<dynamic>(nurseManageService.SaveMedPostoperaticeExtended(list));
        }
        /// <summary>
        /// 获取文书绑定数据
        /// </summary>
        /// <param name="PATIENTID">PATIENTID</param>
        /// <param name="VISITID">VISITID</param>
        /// <param name="OPERID">OPERID</param>
        /// <param name="StatusType">StatusType</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<MedicalBasicDoc> QueryMedicalBasicDoc(string PATIENTID, int VISITID, int OPERID, string StatusType, string DocName)
        {
            dynamic list = nurseManageService.QueryMedicalBasicDoc(PATIENTID, VISITID, OPERID, StatusType, DocName);
            return Success(list);
        }

        /// <summary>
        /// 批量保存文书 数据
        /// </summary>
        [HttpPost]
        public RequestResult<dynamic> SaveMedicalBasicDoc(MedicalBasicDoc data)
        {
            return Success<dynamic>(nurseManageService.SaveMedicalBasicDoc(data));
        }

        /// <summary>
        /// 获取字典数据
        /// </summary>
        /// <param name="data">data</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<dynamic> GetDicData(dynamic data)
        {
            return Success<dynamic>(nurseManageService.GetDicData(data));
        }


        /// <summary>
        /// 获取科室字典列表
        /// </summary>
        /// <param name="DeptName">科室名称</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<dynamic> GetMedDeptInOperRoomDict(string DeptName)
        {
            return Success<dynamic>(nurseManageService.GetMedDeptInOperRoomDict(DeptName));
        }
        /// <summary>
        /// 上传pdf文书
        /// </summary>
        /// <param name="PDFobj"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> PDFUpload(dynamic PDFobj)
        {
            return Success(nurseManageService.PDFUpload(PDFobj));

        }

        /// <summary>
        /// 获取字典
        /// </summary>
        /// <param name="itemClass"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<IList<MED_ANESTHESIA_INPUT_DICT>> GetAnesInputDict(string itemClass)
        {
            return Success(nurseManageService.GetAnesInputDict(itemClass));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="operID"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<MED_OPERATION_SCHEDULE> GetOperationSchedule(string patientID, decimal visitID, decimal operID)
        {
            return Success(nurseManageService.GetOperationSchedule(patientID, visitID, operID));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operationCanceled"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> CancelOperationSchedule(OperCancelAndDetailEntity operationCanceled)
        {
            return Success(nurseManageService.CancelOperationSchedule(operationCanceled));
        }


        /// <summary>
        /// 获取未上传、或者未上传完整的患者列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<List<AnesDocumentPDFSrcEntity>> GetUnUploadPatientInfos(OperQueryParaModel model)
        {
            return Success(nurseManageService.GetUnUploadPatientInfos(model));
        }
    }
}
