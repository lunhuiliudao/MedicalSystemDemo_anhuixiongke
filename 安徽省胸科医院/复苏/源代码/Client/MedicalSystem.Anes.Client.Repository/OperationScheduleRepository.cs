using MedicalSystem.Anes.Domain;
using MedicalSystem.DataServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.Anes.Client.Repository
{
    public class OperationScheduleRepository : BaseRepository
    {
        public RequestResult<List<MED_OPERATION_SCHEDULE>> GetOperationScheduleList(DateTime startTime, DateTime endTime, string emergencyFlg, string hospBranch, string operRoom)
        {
            string address = "PacuOperationSchedule/GetOperationScheduleList?startTime=" + startTime + "&endTime=" +
                endTime + "&emergencyFlg=" + emergencyFlg + "&hospBranch=" + hospBranch + "&operRoom=" + operRoom;
            return BaseRepository.GetCallApi<List<MED_OPERATION_SCHEDULE>>(address);
        }

        public RequestResult<int> UpdateOperationSchedule(List<MED_OPERATION_SCHEDULE> item, string type)
        {
            string address = "PacuOperationSchedule/UpdateOperationSchedule?type=" + type;
            return BaseRepository.PostCallApi<List<MED_OPERATION_SCHEDULE>>(address, item);
        }

        public RequestResult<int> UpdateOperationScheduleByPatientInfo(MED_OPERATION_SCHEDULE item, string type)
        {
            string address = "PacuOperationSchedule/UpdateOperationScheduleByPatientInfo?type=" + type;
            return BaseRepository.PostCallApi<MED_OPERATION_SCHEDULE>(address, item);
        }

        public RequestResult<int> GetMaxOperID(string patientID, int visitID)
        {
            string address = "PacuOperationSchedule/GetMaxOperID?patientID=" + patientID + "&visitID=" + visitID;
            return BaseRepository.GetCallApi<int>(address);
        }

        public RequestResult<MED_OPERATION_SCHEDULE> GetOperationScheduleListByPatientInfo(string patientID, int visitID, int scheduleID)
        {
            string address = "PacuOperationSchedule/GetOperationScheduleListByPatientInfo?patientID=" + patientID + "&visitID=" + visitID + "&scheduleID=" + scheduleID;
            return BaseRepository.GetCallApi<MED_OPERATION_SCHEDULE>(address);
        }

        public RequestResult<List<MED_OPERATION_SCHEDULE_NAME>> GetOperationScheduleNameListByPatientInfo(string patientID, int visitID, int scheduleID)
        {
            string address = "PacuOperationSchedule/GetOperationScheduleNameListByPatientInfo?patientID=" + patientID + "&visitID=" + visitID + "&scheduleID=" + scheduleID;
            return BaseRepository.GetCallApi<List<MED_OPERATION_SCHEDULE_NAME>>(address);
        }

        public RequestResult<int> GetMaxOperationNo(string patientID, int visitID, int operID)
        {
            string address = "PacuOperationSchedule/GetMaxOperationNo?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<int>(address);
        }


    }
}
