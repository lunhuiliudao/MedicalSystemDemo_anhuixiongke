
using MedicalSystem.AnesPlatform.Service.WebApi.App_Start.Swagger;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Domain.RequestResult;
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
    [ControllerGroup("麻醉交班管理", "接口")]
    public class PlatformAnesShiftController : PlatformBaseController
    {
        IPlatformAnesShiftService anesShiftService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="anesShiftServiceParam"></param>
        public PlatformAnesShiftController(IPlatformAnesShiftService anesShiftServiceParam)
        {
            anesShiftService = anesShiftServiceParam;
        }

        /// <summary>
        /// 麻醉患者手术信息
        /// </summary>
        [HttpPost]
        public RequestPageResult<List<dynamic>> GetAnesShiftOperInfoList(OperQueryParaModel model)
        {
            List<dynamic> list = anesShiftService.GetAnesShiftOperInfoList(model);

            List<dynamic> pageList = list;
            //分页处理
            if (list.Count > model.PageSize)
            {
                pageList = pageList.Skip((model.CurrentPage - 1) * model.PageSize).Take(model.PageSize).ToList();
            }
            return PageSuccess(pageList, model.PageSize, model.CurrentPage, list.Count);
        }

        /// <summary>
        /// 麻醉交班记录查询
        /// </summary>
        [HttpPost]
        public RequestPageResult<List<MED_ANES_SHIFT_MASTER>> GetAnesShiftInfoList(OperQueryParaModel model)
        {
            List<MED_ANES_SHIFT_MASTER> list = anesShiftService.GetAnesShiftInfoList(model);

            List<MED_ANES_SHIFT_MASTER> pageList = list;
            //分页处理
            if (list.Count > model.PageSize)
            {
                pageList = pageList.Skip((model.CurrentPage - 1) * model.PageSize).Take(model.PageSize).ToList();
            }
            return PageSuccess(pageList, model.PageSize, model.CurrentPage, list.Count);
        }

        /// <summary>
        /// 麻醉交班毒麻药查询
        /// </summary>
        [HttpPost]
        public RequestPageResult<List<MED_ANES_SHIFT_DRUGS>> GetAnesShiftDrugInfoList(OperQueryParaModel model)
        {
            List<MED_ANES_SHIFT_DRUGS> list = anesShiftService.GetAnesShiftDrugInfoList(model);


            return PageSuccess(list, model.PageSize, model.CurrentPage, list.Count);
        }

        /// <summary>
        /// 麻醉交班急救插管患者信息查询
        /// </summary>
        [HttpPost]
        public RequestPageResult<List<MED_ANES_SHIFT_PATIENTINFO>> GetAnesShiftPatientInfoList(OperQueryParaModel model)
        {
            List<MED_ANES_SHIFT_PATIENTINFO> list = anesShiftService.GetAnesShiftPatientInfoList(model);


            return PageSuccess(list, model.PageSize, model.CurrentPage, list.Count);
        }

        /// <summary>
        /// 保存麻醉交班数据
        /// </summary>
        [HttpPost]
        public RequestResult<dynamic> SaveAnesShiftMasterInfoList(MED_ANES_SHIFT_MASTER data)
        {
            return Success<dynamic>(anesShiftService.SaveAnesShiftMasterInfoList(data));
        }

        /// <summary>
        /// 保存麻醉交班毒麻药数据
        /// </summary>
        [HttpPost]
        public RequestResult<dynamic> SaveAnesShiftDrugInfoList(List<MED_ANES_SHIFT_DRUGS> data)
        {
            return Success<dynamic>(anesShiftService.SaveAnesShiftDrugInfoList(data));
        }

        /// <summary>
        /// 保存急救插管信息
        /// </summary>
        [HttpPost]
        public RequestResult<dynamic> SaveAnesShiftPatientInfoList(List<MED_ANES_SHIFT_PATIENTINFO> data)
        {
            return Success<dynamic>(anesShiftService.SaveAnesShiftPatientInfoList(data));
        }
    }
}