using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.DataServices.Domain;
using MedicalSystem.Common.SecretManage;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers.Pacu
{
    public class PacuCommonController : BaseController
    {
        IPacuCommonService _commonService = null;

        public PacuCommonController(IPacuCommonService pacuCommonService)
        {
            _commonService = pacuCommonService;
        }

        [HttpGet]
        public RequestResult<int> GetMaxCancelID(string patientID, int visitID)
        {
            return Success(_commonService.GetMaxCancelID(patientID, visitID));
        }
        [HttpGet]
        public RequestResult<List<STANDARD_KEYWORD>> GetAcsContextByKeyWord(string keyWord)
        {
            return Success(_commonService.GetAcsContextByKeyWord(keyWord));
        }
        [HttpGet]
        public RequestResult<System.Data.DataTable> GetAcsArticleKeyWord()
        {
            return Success(_commonService.GetAcsArticleKeyWord());
        }
        [HttpGet]
        public RequestResult<bool> UpdateDataTable(string sql)
        {
            return Success(_commonService.UpdateDataTable(sql));
        }
        public RequestResult<int> UpdateOperationCanceled(MED_OPERATION_CANCELED item)
        {
            return Success(_commonService.UpdateOperationCanceled(item));
        }
        //[HttpGet]
        //public RequestResult<List<MED_OPERATION_CANCELED>> GetOperationCanceled(string patientID, int visitID, string reserved1)
        //{
        //    return Success(_commonService.GetOperationCanceled(patientID, visitID, reserved1));
        //}
        [HttpGet]
        public RequestResult<List<MED_ANESTHESIA_EVENT_TEMPLET>> GetAnesEventTemplet(string templetName)
        {
            return Success(_commonService.GetAnesEventTemplet(templetName));
        }
        [HttpGet]
        public RequestResult<List<MED_ANESTHESIA_EVENT_TEMPLET>> GetAnesEventTempletAll()
        {
            return Success(_commonService.GetAnesEventTempletAll());
        }

        [HttpPost]
        public RequestResult<bool> SaveAnesEventTempletList(List<MED_ANESTHESIA_EVENT_TEMPLET> item)
        {
            return Success(_commonService.SaveAnesEventTempletList(item));
        }

        [HttpPost]
        public RequestResult<int> DelAnesEventTemplet(MED_ANESTHESIA_EVENT_TEMPLET item)
        {
            return Success(_commonService.DelAnesEventTemplet(item));
        }

        [HttpGet]
        public RequestResult<List<MED_DOCUMENT_TEMPLET>> GetDocumentTemplet()
        {
            return Success(_commonService.GetDocumentTemplet());
        }

        [HttpPost]
        public RequestResult<int> SaveDocumentTemplet(MED_DOCUMENT_TEMPLET item)
        {
            return Success(_commonService.SaveDocumentTemplet(item));
        }
        [HttpPost]
        public RequestResult<int> SaveDocumentTempletList(List<MED_DOCUMENT_TEMPLET> item)
        {
            return Success(_commonService.SaveDocumentTempletList(item));
        }
        [HttpGet]
        public RequestResult<List<MED_QIXIE_TEMPLET_MASTER>> GetQiXieTempletMaster()
        {
            return Success(_commonService.GetQiXieTempletMaster());
        }
        [HttpPost]
        public RequestResult<int> SaveQiXieMaster(MED_QIXIE_TEMPLET_MASTER item)
        {
            return Success(_commonService.SaveQiXieMaster(item));
        }
        [HttpPost]
        public RequestResult<int> SaveQiXieMasterList(List<MED_QIXIE_TEMPLET_MASTER> item)
        {
            return Success(_commonService.SaveQiXieMasterList(item));
        }
        [HttpGet]
        public RequestResult<List<MED_QIXIE_TEMPLET_DETAIL>> GetQiXieTempletDetail(string templetGuid)
        {
            return Success(_commonService.GetQiXieTempletDetail(templetGuid));
        }
        [HttpPost]
        public RequestResult<int> SaveQiXieDetailList(List<MED_QIXIE_TEMPLET_DETAIL> item)
        {
            return Success(_commonService.SaveQiXieDetailList(item));
        }
        [HttpGet]
        public RequestResult<List<MED_OPERATION_EXTENDED>> GetOperExtended(string patientID, int visitID, int operID)
        {
            return Success(_commonService.GetOperExtended(patientID, visitID, operID));
        }
        [HttpGet]
        public RequestResult<List<MED_POSTOPERATIVE_EXTENDED>> GetPostoperativeExtended(string patientID, int visitID, int operID)
        {
            return Success(_commonService.GetPostoperativeExtended(patientID, visitID, operID));
        }
        [HttpGet]
        public RequestResult<List<MED_PREOPERATIVE_EXPANSION>> GetPreoperativeExpansion(string patientID, int visitID, int operID)
        {
            return Success(_commonService.GetPreoperativeExpansion(patientID, visitID, operID));
        }
        [HttpPost]
        public RequestResult<int> SaveOperExtendedList(List<MED_OPERATION_EXTENDED> item)
        {
            return Success(_commonService.SaveOperExtendedList(item));
        }
        [HttpPost]
        public RequestResult<int> SavePostExtendedList(List<MED_POSTOPERATIVE_EXTENDED> item)
        {
            return Success(_commonService.SavePostExtendedList(item));
        }
        [HttpPost]
        public RequestResult<int> SavePreExpansionList(List<MED_PREOPERATIVE_EXPANSION> item)
        {
            return Success(_commonService.SavePreExpansionList(item));
        }
        [HttpGet]
        public RequestResult<List<MED_SCREEN_MSG>> GetScreenMsgList()
        {
            return Success(_commonService.GetScreenMsgList());
        }
        [HttpPost]
        public RequestResult<int> SaveScreenMsg(MED_SCREEN_MSG item)
        {
            return Success(_commonService.SaveScreenMsg(item));
        }
        [HttpGet]
        public RequestResult<List<MED_EMR_ARCHIVE_DETIAL>> GetEmrArchiveList(string patientID, int visitID, string operID, string docName)
        {
            return Success(_commonService.GetEmrArchiveList(patientID, visitID, operID, docName));
        }
        [HttpGet]
        public RequestResult<List<MED_EMR_ARCHIVE_DETIAL>> GetEmrArchiveListByStatus(string patientID, int visitID, string operID)
        {
            return Success(_commonService.GetEmrArchiveListByStatus(patientID, visitID, operID));
        }
        [HttpPost]
        public RequestResult<int> SaveEmrArchiveList(List<MED_EMR_ARCHIVE_DETIAL> item)
        {
            return Success(_commonService.SaveEmrArchiveList(item));
        }

        [HttpGet]
        public RequestResult<List<MED_BJCA_SIGN>> GetBjcaSignList(string patientID, int visitID, int operID)
        {
            return Success(_commonService.GetBjcaSignList(patientID, visitID, operID));
        }

        [HttpPost]
        public RequestResult<int> SaveBjcaSign(MED_BJCA_SIGN item)
        {
            return Success(_commonService.SaveBjcaSign(item));
        }

        [HttpPost]
        public RequestResult<int> UpdateBjcaSignList(List<MED_BJCA_SIGN> item)
        {
            return Success(_commonService.UpdateBjcaSignList(item));
        }

    }
}