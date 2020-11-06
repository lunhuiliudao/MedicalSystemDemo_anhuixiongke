using MedicalSystem.Anes.Domain;
using MedicalSystem.DataServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.Anes.Client.Repository
{
    public class PatientInfoRepository : BaseRepository
    {
        /// <summary>
        /// 获取手术信息列表
        /// </summary>
        /// <param name="startDate">手术开始时间</param>
        /// <param name="patientID">病人ID</param>
        /// <param name="patientName">病人姓名</param>
        /// <param name="anesthesiaDoctor">麻醉医生</param>
        /// <param name="departCode">科室号</param>
        /// <param name="operationStatus">麻醉状态</param>
        /// <param name="asa">ASA分级</param>
        /// <param name="operationName">手术名称</param>
        /// <param name="anesthesiaMethod">麻醉方法</param>
        /// <param name="age">年龄-低值</param>
        /// <param name="age1">年龄-高值</param>
        /// <param name="isSelfOpera">是否自己相关的手术</param>
        /// <param name="isJiZhen">是否急诊</param>
        /// <param name="isZeQi">是否择期</param>
        /// <param name="userName">登陆者ID</param>
        /// <returns>List<MED_OPERATION_MASTER></returns>
        public RequestResult<List<MED_OPERATION_MASTER>> GetPatMasterInfoList(string startDate, string patientID, string patientName, string anesthesiaDoctor, string departCode
            , string operationStatus, string asa, string operationName, string anesthesiaMethod, string age, string age1, string isSelfOpera, string isJiZhen, string isZeQi, string userName)
        {
            string address = "PacuPatientInfo/GetPatMasterInfoList?startDate=" + startDate + "&patientID=" + patientID
                + "&patientName=" + patientName
                + "&anesthesiaDoctor=" + anesthesiaDoctor
                 + "&departCode=" + departCode
                + "&operationStatus=" + operationStatus
                + "&asa=" + asa
                + "&operationName=" + operationName
                + "&anesthesiaMethod=" + anesthesiaMethod
                + "&age=" + age
                + "&age1=" + age1
                + "&isSelfOpera=" + isSelfOpera
                + "&isJiZhen=" + isJiZhen
                + "&isZeQi=" + isZeQi
                 + "&userName=" + userName;
            return BaseRepository.GetCallApi<List<MED_OPERATION_MASTER>>(address);
        }

        /// <summary>
        /// 获取患者列表信息
        /// </summary>
        /// <param name="operDateTime"></param>
        /// <param name="patientID"></param>
        /// <param name="operRoomNo"></param>
        /// <param name="operRoom"></param>
        /// <param name="hospBranch"></param>
        /// <returns></returns>
        public RequestResult<List<MED_PATIENT_CARD>> GetPatCardList(DateTime operDateTime, string inpNo, string operRoomNo, string operRoom, string hospBranch, bool IsSearch)
        {
            string address = "PacuPatientInfo/GetPatCardList?operDateTime=" + operDateTime + "&operRoomNo=" + operRoomNo + "&inpNo=" + inpNo
                + "&operRoom=" + operRoom
                 + "&hospBranch=" + hospBranch + "&IsSearch=" + IsSearch;
            return BaseRepository.GetCallApi<List<MED_PATIENT_CARD>>(address);
        }
        public RequestResult<MED_PATIENT_CARD> GetPatCard(string patientID, int visitID, int operID)
        {
            string address = "PacuPatientInfo/GetPatCard?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<MED_PATIENT_CARD>(address);
        }
        /// <summary>
        /// 获取患者列表信息
        /// </summary>
        /// <param name="operDateTime"></param>
        /// <param name="operRoomNo"></param>
        /// <param name="operRoom"></param>
        /// <param name="hospBranch"></param>
        /// <returns></returns>
        public RequestResult<List<MED_PATIENT_CARD>> GetCurrentPatCardList(DateTime operDateTime, string operRoomNo, string operRoom, string hospBranch)
        {
            string address = "PacuPatientInfo/GetCurrentPatCardList?operDateTime=" + operDateTime + "&operRoomNo=" + operRoomNo
                + "&operRoom=" + operRoom
                 + "&hospBranch=" + hospBranch;
            return BaseRepository.GetCallApi<List<MED_PATIENT_CARD>>(address);
        }
        public RequestResult<List<MED_PATIENT_CARD>> GetPatientListByDate(DateTime operStartTime, DateTime operEndTime, string operRoomNo, string operRoom, string hospBranch)
        {
            string address = "PacuPatientInfo/GetPatientListByDate?operStartTime=" + operStartTime + "&operEndTime=" + operEndTime
                 + "&operRoomNo=" + operRoomNo
                   + "&operRoom=" + operRoom
                    + "&hospBranch=" + hospBranch;
            return BaseRepository.GetCallApi<List<MED_PATIENT_CARD>>(address);
        }
        public RequestResult<List<MED_OPERATION_MASTER>> GetOperMasterListByPacuTime(DateTime operDateTime, string operRoom, string hospBranch)
        {
            string address = "PacuPatientInfo/GetOperMasterListByPacuTime?operDateTime=" + operDateTime + "&operRoom=" + operRoom + "&hospBranch=" + hospBranch;
            return BaseRepository.GetCallApi<List<MED_OPERATION_MASTER>>(address);
        }
        public RequestResult<List<MED_PATIENT_CARD>> GetPatientListDataTable(DateTime startDate, string deptCode, string hospBranch)
        {
            string address = "PacuPatientInfo/GetPatientListDataTable?startDate=" + startDate + "&deptCode=" + deptCode + "&hospBranch=" + hospBranch;
            return BaseRepository.GetCallApi<List<MED_PATIENT_CARD>>(address);
        }
        public RequestResult<List<MED_PATIENT_CARD>> GetPatientListDataTableByPACU(DateTime startDate, string deptCode, string hospBranch, string searchStr)
        {
            string address = "PacuPatientInfo/GetPatientListDataTableByPACU?startDate=" + startDate + "&deptCode=" + deptCode + "&hospBranch=" + hospBranch + "&searchStr=" + searchStr;
            return BaseRepository.GetCallApi<List<MED_PATIENT_CARD>>(address);
        }
        public RequestResult<List<MED_PATIENT_CARD>> GetPatientListDataTableByPatientID(string patientID, string deptCode, string hospBranch)
        {
            string address = "PacuPatientInfo/GetPatientListDataTableByPatientID?patientID=" + patientID + "&deptCode=" + deptCode + "&hospBranch=" + hospBranch;
            return BaseRepository.GetCallApi<List<MED_PATIENT_CARD>>(address);
        }
    }
}
