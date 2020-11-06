using MedicalSystem.Anes.Domain;
using MedicalSystem.DataServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.Anes.Client.Repository
{
    public class SyncInfoRepository : BaseRepository
    {
        public RequestResult<string> SyncPatientInfoAndInHospital(string patientID)
        {
            string address = "PacuSyncInfo/SyncPatientInfoAndInHospital?patientID=" + patientID;
            return BaseRepository.GetCallApi<string>(address);
        }

        public RequestResult<string> SyncScheduleInfo(string patientID, DateTime operDateTime)
        {
            string address = "PacuSyncInfo/SyncScheduleInfo?patientID=" + patientID + "&operDateTime=" + operDateTime;
            return BaseRepository.GetCallApi<string>(address);
        }

        public RequestResult<string> SyncPatientInfoAndInHospitalByInpNo(string inpNo)
        {
            string address = "PacuSyncInfo/SyncPatientInfoAndInHospitalByInpNo?inpNo=" + inpNo;
            return BaseRepository.GetCallApi<string>(address);
        }
        public RequestResult<string> SyncWriteHisOper(string patientID, int visitID, int operID)
        {
            string address = "PacuSyncInfo/SyncWriteHisOper?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<string>(address);
        }
        public RequestResult<string> SyncWriteHisOperStatus(string patientID, int visitID, int operID, int state)
        {
            string address = "PacuSyncInfo/SyncWriteHisOperStatus?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID + "&state=" + state;
            return BaseRepository.GetCallApi<string>(address);
        }
        public RequestResult<string> SaveOperScheduleStateToHis(string patientID, int visitID, int operID, string State)
        {
            string address = "PacuSyncInfo/SaveOperScheduleStateToHis?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID + "&State=" + State;
            return BaseRepository.GetCallApi<string>(address);
        }
        public RequestResult<string> SyncScheduleInfoByDeptCode(string performedcode)
        {
            string address = "PacuSyncInfo/SyncScheduleInfoByDeptCode?performedcode=" + performedcode;
            return BaseRepository.GetCallApi<string>(address);
        }
        public RequestResult<string> SyncScheduleInfo(string patientID)
        {
            string address = "PacuSyncInfo/SyncScheduleInfo?patientID=" + patientID;
            return BaseRepository.GetCallApi<string>(address);
        }
        public RequestResult<string> SyncScheduleInfoByDateDiff(string patientID, int dateDiff)
        {
            string address = "PacuSyncInfo/SyncScheduleInfoByDateDiff?patientID=" + patientID + "&dateDiff=" + dateDiff;
            return BaseRepository.GetCallApi<string>(address);
        }
        public RequestResult<string> SyncScheduleInfoByDateTime(string patientID, DateTime startTime, DateTime endTime)
        {
            string address = "PacuSyncInfo/SyncScheduleInfoByDateTime?patientID=" + patientID + "&startTime=" + startTime + "&endTime=" + endTime;
            return BaseRepository.GetCallApi<string>(address);
        }
        public RequestResult<string> SyncLis(string patientID, EventHandler eventHandle)
        {
            string address = "PacuSyncInfo/SyncLis?patientID=" + patientID + "&eventHandle=" + eventHandle;
            return BaseRepository.GetCallApi<string>(address);
        }

        public RequestResult<string> SyncLis2(string patientID, decimal visitID, EventHandler eventHandle)
        {
            string address = "PacuSyncInfo/SyncLis?patientID=" + patientID + "&visitID=" + visitID + "&eventHandle=" + eventHandle;
            return BaseRepository.GetCallApi<string>(address);
        }

        public RequestResult<string> SyncLisByVisitID(string patientID, decimal visitID, EventHandler eventHandle)
        {
            string address = "PacuSyncInfo/SyncLisByVisitID?patientID=" + patientID + "&visitID=" + visitID + "&eventHandle=" + eventHandle;
            return BaseRepository.GetCallApi<string>(address);
        }
        public RequestResult<string> SyncPACS(string patientID, decimal visitID, EventHandler eventHandle)
        {
            string address = "PacuSyncInfo/SyncPACS?patientID=" + patientID + "&visitID=" + visitID + "&eventHandle=" + eventHandle;
            return BaseRepository.GetCallApi<string>(address);
        }
        public RequestResult<string> SyncEMR(string patientID, decimal visitID, EventHandler eventHandle)
        {
            string address = "PacuSyncInfo/SyncEMR?patientID=" + patientID + "&visitID=" + visitID + "&eventHandle=" + eventHandle;
            return BaseRepository.GetCallApi<string>(address);
        }

        public RequestResult<string> SyncEMR1(string patientID, decimal visitID, EventHandler eventHandle, string userJobId)
        {
            string address = "PacuSyncInfo/SyncEMR1?patientID=" + patientID + "&visitID=" + visitID + "&eventHandle=" + eventHandle + "&userJobId=" + userJobId;
            return BaseRepository.GetCallApi<string>(address);
        }

        public RequestResult<string> SyncOPER505W(MED_EMR_ARCHIVE_DETIAL item)
        {
            string address = "PacuSyncInfo/SyncOPER505W";
            return BaseRepository.PostCallApi2<MED_EMR_ARCHIVE_DETIAL>(address, item);
        }

        public RequestResult<string> SyncOPER503W(string patientID, int visitID, int operID, int operStatus)
        {
            string address = "PacuSyncInfo/SyncOPER503W?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID + "&operStatus=" + operStatus;
            return BaseRepository.GetCallApi<string>(address);
        }

        public RequestResult<string> SyncOrderInfo(string patientID, int visitID)
        {
            string address = "PacuSyncInfo/SyncOrderInfo?patientID=" + patientID + "&visitID=" + visitID;
            return BaseRepository.GetCallApi<string>(address);
        }
    }
}
