using MedicalSystem.Anes.Domain;
using MedicalSystem.DataServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.Anes.Client.Repository
{
    public class CommonRepository : BaseRepository
    {
        public RequestResult<int> GetMaxCancelID(string patientID, int visitID)
        {
            string address = "PacuCommon/GetMaxCancelID?patientID=" + patientID + "&visitID=" + visitID;
            return BaseRepository.GetCallApi<int>(address);
        }
        public RequestResult<List<STANDARD_KEYWORD>> GetAcsContextByKeyWord(string keyWord)
        {
            string address = "PacuCommon/GetAcsContextByKeyWord?keyWord=" + keyWord;
            return BaseRepository.GetCallApi<List<STANDARD_KEYWORD>>(address);
        }
        public RequestResult<System.Data.DataTable> GetAcsArticleKeyWord()
        {
            string address = "PacuCommon/GetAcsArticleKeyWord";
            return BaseRepository.GetCallApi<System.Data.DataTable>(address);
        }
        public RequestResult<bool> UpdateDataTable(string sql)
        {
            string address = "PacuCommon/UpdateDataTable?sql=" + sql;
            return BaseRepository.GetCallApi<bool>(address);
        }
        public RequestResult<int> UpdateOperationCanceled(MED_OPERATION_CANCELED item)
        {
            string address = "PacuCommon/UpdateOperationCanceled";
            return BaseRepository.PostCallApi<MED_OPERATION_CANCELED>(address, item);
        }
        //public RequestResult<List<MED_OPERATION_CANCELED>> GetOperationCanceled(string patientID, int visitID, string reserved1)
        //{
        //    string address = "PacuCommon/GetOperationCanceled?patientID=" + patientID + "&visitID=" + visitID + "&reserved1=" + reserved1;
        //    return BaseRepository.GetCallApi<List<MED_OPERATION_CANCELED>>(address);
        //}
        public RequestResult<List<MED_ANESTHESIA_EVENT_TEMPLET>> GetAnesEventTemplet(string templetName)
        {
            string address = "PacuCommon/GetAnesEventTemplet?templetName=" + templetName;
            return BaseRepository.GetCallApi<List<MED_ANESTHESIA_EVENT_TEMPLET>>(address);
        }
        public RequestResult<List<MED_ANESTHESIA_EVENT_TEMPLET>> GetAnesEventTempletAll()
        {
            string address = "PacuCommon/GetAnesEventTempletAll";
            return BaseRepository.GetCallApi<List<MED_ANESTHESIA_EVENT_TEMPLET>>(address);
        }

        public RequestResult<bool> SaveAnesEventTempletList(List<MED_ANESTHESIA_EVENT_TEMPLET> item)
        {
            string address = "PacuCommon/SaveAnesEventTempletList";
            return BaseRepository.PostCallApi<List<MED_ANESTHESIA_EVENT_TEMPLET>, bool>(address, item);
        }
        public RequestResult<bool> DelAnesEventTemplet(MED_ANESTHESIA_EVENT_TEMPLET item)
        {
            string address = "PacuCommon/DelAnesEventTemplet";
            return BaseRepository.PostCallApi<MED_ANESTHESIA_EVENT_TEMPLET, bool>(address, item);
        }
        public RequestResult<List<MED_DOCUMENT_TEMPLET>> GetDocumentTemplet()
        {
            string address = "PacuCommon/GetDocumentTemplet";
            return BaseRepository.GetCallApi<List<MED_DOCUMENT_TEMPLET>>(address);
        }
        public RequestResult<int> SaveDocumentTemplet(MED_DOCUMENT_TEMPLET item)
        {
            string address = "PacuCommon/SaveDocumentTemplet";
            return BaseRepository.PostCallApi<MED_DOCUMENT_TEMPLET>(address, item);
        }
        public RequestResult<int> SaveDocumentTempletList(List<MED_DOCUMENT_TEMPLET> item)
        {
            string address = "PacuCommon/SaveDocumentTempletList";
            return BaseRepository.PostCallApi<List<MED_DOCUMENT_TEMPLET>>(address, item);
        }
        public RequestResult<List<MED_QIXIE_TEMPLET_MASTER>> GetQiXieTempletMaster()
        {
            string address = "PacuCommon/GetQiXieTempletMaster";
            return BaseRepository.GetCallApi<List<MED_QIXIE_TEMPLET_MASTER>>(address);
        }
        public RequestResult<int> SaveQiXieMaster(MED_QIXIE_TEMPLET_MASTER item)
        {
            string address = "PacuCommon/SaveQiXieMaster";
            return BaseRepository.PostCallApi<MED_QIXIE_TEMPLET_MASTER>(address, item);
        }
        public RequestResult<int> SaveQiXieMasterList(List<MED_QIXIE_TEMPLET_MASTER> item)
        {
            string address = "PacuCommon/SaveQiXieMasterList";
            return BaseRepository.PostCallApi<List<MED_QIXIE_TEMPLET_MASTER>>(address, item);
        }
        public RequestResult<List<MED_QIXIE_TEMPLET_DETAIL>> GetQiXieTempletDetail(string templetGuid)
        {
            string address = "PacuCommon/GetQiXieTempletDetail?templetGuid=" + templetGuid;
            return BaseRepository.GetCallApi<List<MED_QIXIE_TEMPLET_DETAIL>>(address);
        }
        public RequestResult<int> SaveQiXieDetailList(List<MED_QIXIE_TEMPLET_DETAIL> item)
        {
            string address = "PacuCommon/SaveQiXieDetailList";
            return BaseRepository.PostCallApi<List<MED_QIXIE_TEMPLET_DETAIL>>(address, item);
        }
        public RequestResult<List<MED_OPERATION_EXTENDED>> GetOperExtended(string patientID, int visitID, int operID)
        {
            string address = "PacuCommon/GetOperExtended?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<List<MED_OPERATION_EXTENDED>>(address);
        }
        public RequestResult<List<MED_POSTOPERATIVE_EXTENDED>> GetPostoperativeExtended(string patientID, int visitID, int operID)
        {
            string address = "PacuCommon/GetPostoperativeExtended?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<List<MED_POSTOPERATIVE_EXTENDED>>(address);
        }
        public RequestResult<List<MED_PREOPERATIVE_EXPANSION>> GetPreoperativeExpansion(string patientID, int visitID, int operID)
        {
            string address = "PacuCommon/GetPreoperativeExpansion?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<List<MED_PREOPERATIVE_EXPANSION>>(address);
        }
        public RequestResult<int> SaveOperExtendedList(List<MED_OPERATION_EXTENDED> item)
        {
            string address = "PacuCommon/SaveOperExtendedList";
            return BaseRepository.PostCallApi<List<MED_OPERATION_EXTENDED>>(address, item);
        }

        public RequestResult<int> SavePostExtendedList(List<MED_POSTOPERATIVE_EXTENDED> item)
        {
            string address = "PacuCommon/SavePostExtendedList";
            return BaseRepository.PostCallApi<List<MED_POSTOPERATIVE_EXTENDED>>(address, item);
        }
        public RequestResult<int> SavePreExpansionList(List<MED_PREOPERATIVE_EXPANSION> item)
        {
            string address = "PacuCommon/SavePreExpansionList";
            return BaseRepository.PostCallApi<List<MED_PREOPERATIVE_EXPANSION>>(address, item);
        }
        public RequestResult<List<MED_SCREEN_MSG>> GetScreenMsgList()
        {
            string address = "PacuCommon/GetScreenMsgList";
            return BaseRepository.GetCallApi<List<MED_SCREEN_MSG>>(address);
        }
        public RequestResult<int> SaveScreenMsg(MED_SCREEN_MSG item)
        {
            string address = "PacuCommon/SaveScreenMsg";
            return BaseRepository.PostCallApi<MED_SCREEN_MSG>(address, item);
        }
        public RequestResult<List<MED_EMR_ARCHIVE_DETIAL>> GetEmrArchiveList(string patientID, int visitID, string operID, string docName)
        {
            string address = "PacuCommon/GetEmrArchiveList?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID + "&docName=" + docName;
            return BaseRepository.GetCallApi<List<MED_EMR_ARCHIVE_DETIAL>>(address);
        }
        public RequestResult<List<MED_EMR_ARCHIVE_DETIAL>> GetEmrArchiveListByStatus(string patientID, int visitID, string operID)
        {
            string address = "PacuCommon/GetEmrArchiveListByStatus?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<List<MED_EMR_ARCHIVE_DETIAL>>(address);
        }
        public RequestResult<int> SaveEmrArchiveList(List<MED_EMR_ARCHIVE_DETIAL> item)
        {
            string address = "PacuCommon/SaveEmrArchiveList";
            return BaseRepository.PostCallApi<List<MED_EMR_ARCHIVE_DETIAL>>(address, item);
        }

        public RequestResult<List<MED_BJCA_SIGN>> GetBjcaSignList(string patientID, int visitID, int operID)
        {
            string address = "PacuCommon/GetBjcaSignList?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<List<MED_BJCA_SIGN>>(address);
        }
        public RequestResult<int> SaveBjcaSign(MED_BJCA_SIGN item)
        {
            string address = "PacuCommon/SaveBjcaSign";
            return BaseRepository.PostCallApi<MED_BJCA_SIGN>(address, item);
        }
        public RequestResult<int> UpdateBjcaSignList(List<MED_BJCA_SIGN> item)
        {
            string address = "PacuCommon/UpdateBjcaSignList";
            return BaseRepository.PostCallApi<List<MED_BJCA_SIGN>, int>(address, item);
        }

        public RequestResult<List<MED_LAB_PATIENT>> GetLabPatientList(string patientID, int visitID)
        {
            string address = "PacuCommon/GetLabPatientList?patientID=" + patientID + "&visitID=" + visitID;
            return BaseRepository.GetCallApi<List<MED_LAB_PATIENT>>(address);
        }


        public RequestResult<List<MED_LAB_TEST_MASTER>> GetMedLabTestMaster(string patientID, int visitID)
        {
            string address = "PacuCommon/GetMedLabTestMaster?patientID=" + patientID + "&visitID=" + visitID;
            return BaseRepository.GetCallApi<List<MED_LAB_TEST_MASTER>>(address);
        }

        public RequestResult<List<MED_LAB_RESULT>> GetMedLabResult(string testNo)
        {
            string address = "PacuCommon/GetMedLabResult?testNo=" + testNo ;
            return BaseRepository.GetCallApi<List<MED_LAB_RESULT>>(address);
        }

        public RequestResult<List<MED_LAB_RESULT>> GetMedLabResult(string patientID, int visitID)
        {
            string address = "PacuCommon/GetMedLabResult?patientID=" + patientID + "&visitID=" + visitID;

            return BaseRepository.GetCallApi<List<MED_LAB_RESULT>>(address);
        }
    }
}
