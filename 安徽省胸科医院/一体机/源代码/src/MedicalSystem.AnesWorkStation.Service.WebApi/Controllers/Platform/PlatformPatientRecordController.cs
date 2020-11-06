
using MedicalSystem.AnesPlatform.Service.WebApi.App_Start.Swagger;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Domain.RequestResult;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers.Platform
{
    /// <summary>
    /// 病例病程
    /// </summary>
    [ControllerGroup("病案管理", "接口")]
    public class PlatformPatientRecordController : PlatformBaseController
    {
        IPlatformPatientRecordService PatientRecord;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="PatientRecordParam"></param>
        public PlatformPatientRecordController(IPlatformPatientRecordService PatientRecordParam)
        {
            PatientRecord = PatientRecordParam;
        }
        /// <summary>
        /// 获取手术信息
        /// </summary>
        [HttpPost]
        public RequestResult<OperPatientProgressEntity> QueryOperPatientProgress(OperQueryParaModel model)
        {

            OperPatientProgressEntity list = PatientRecord.QueryOperPatientProgress(model);

            return Success(list);
        }

        /// <summary>
        /// 获取病例文书
        /// </summary>
        [HttpPost]
        public RequestResult<IList<AnesDocumentPDFSrcEntity>> QueryAnesDocumentPDF(OperQueryParaModel model)
        {
            //string docName = "";
            //switch (model.SearchMark)
            //{
            //    case "1":
            //        docName = "麻醉同意书";
            //        break;
            //    case "2":
            //        docName = "术前访视单";
            //        break;
            //    case "3":
            //        docName = "麻醉计划单";
            //        break;
            //    case "4":
            //        docName = "麻醉记录单";
            //        break;
            //    case "5":
            //        docName = "麻醉总结单";
            //        break;
            //    case "6":
            //        docName = "术后随访单";
            //        break;
            //    case "7":
            //        docName = "镇痛记录单";
            //        break;
            //    case "8":
            //        docName = "复苏记录单";
            //        break;
            //}

            //model.SearchMark = docName;
            IList<AnesDocumentPDFSrcEntity> list = PatientRecord.QueryAnesDocumentPDF(model);

            return Success(list);
        }


        /// <summary>
        /// 手术查询
        /// </summary>
        [HttpPost]
        public RequestPageResult<IList<OperQuerytForAnesQueryEntity>> QueryOperList(OperQueryParaModel model)
        {
            IList<OperQuerytForAnesQueryEntity> list = PatientRecord.GetOperList(model);


            IList<OperQuerytForAnesQueryEntity> pageList = list;
            //分页处理
            if (list.Count > model.PageSize)
            {
                pageList = pageList.Skip((model.CurrentPage - 1) * model.PageSize).Take(model.PageSize).ToList();
            }

            return PageSuccess(pageList, model.PageSize, model.CurrentPage, list.Count);

        }
    }
}
