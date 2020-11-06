using MedicalSystem.Anes.Domain;
using MedicalSystem.DataServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.Anes.Client.Repository
{
    public class ComnDictRepository : BaseRepository
    {

        public RequestResult<MED_DEPT_DICT> GetDeptDict(string deptCode)
        {
            string address = "PacuCommDict/GetDeptDict?deptCode=" + deptCode;
            return BaseRepository.GetCallApi<MED_DEPT_DICT>(address);
        }
        public RequestResult<List<MED_DEPT_DICT>> GetDeptDictList()
        {
            string address = "PacuCommDict/GetDeptDictList";
            return BaseRepository.GetCallApi<List<MED_DEPT_DICT>>(address);
        }
        public RequestResult<List<MED_EVENT_DICT>> GetEventDictList()
        {
            string address = "PacuCommDict/GetEventDictList";
            return BaseRepository.GetCallApi<List<MED_EVENT_DICT>>(address);
        }
        public RequestResult<List<MED_MONITOR_FUNCTION_CODE>> GetMonitorFuctionCodeList()
        {
            string address = "PacuCommDict/GetMonitorFuctionCodeList";
            return BaseRepository.GetCallApi<List<MED_MONITOR_FUNCTION_CODE>>(address);
        }
        public RequestResult<List<MED_MONITOR_DICT>> GetMonitorDictList()
        {
            string address = "PacuCommDict/GetMonitorDictList";
            return BaseRepository.GetCallApi<List<MED_MONITOR_DICT>>(address);
        }
        public RequestResult<List<MED_MONITOR_DICT>> GetMonitorDictList(string eventNo)
        {
            string address = "PacuCommDict/GetMonitorDictList?eventNo=" + eventNo;
            return BaseRepository.GetCallApi<List<MED_MONITOR_DICT>>(address);
        }

        /// <summary>
        /// 获得单位字典表
        /// </summary>
        /// <returns></returns>
        public RequestResult<List<MED_UNIT_DICT>> GetUnitDictList()
        {
            string address = "PacuCommDict/GetUnitDictList";
            return BaseRepository.GetCallApi<List<MED_UNIT_DICT>>(address);
        }

        /// <summary>
        /// 获得用药途径字典表
        /// </summary>
        /// <returns></returns>
        public RequestResult<List<MED_ADMINISTRATION_DICT>> GetAdminstrationDictList()
        {
            string address = "PacuCommDict/GetAdminstrationDictList";
            return BaseRepository.GetCallApi<List<MED_ADMINISTRATION_DICT>>(address);
        }

        public RequestResult<List<MED_OPERATING_ROOM>> GetAllOperatingRoomList()
        {
            string address = "PacuCommDict/GetAllOperatingRoomList";
            return BaseRepository.GetCallApi<List<MED_OPERATING_ROOM>>(address);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bedType"></param>
        /// <returns></returns>
        public RequestResult<List<MED_OPERATING_ROOM>> GetOperatingRoomList(string bedType)
        {
            string address = "PacuCommDict/GetOperatingRoomList?bedType=" + bedType;
            return BaseRepository.GetCallApi<List<MED_OPERATING_ROOM>>(address);
        }

        public RequestResult<MED_OPERATING_ROOM> GetOperatingRoomByRoomNo(string bedType, string roomNo)
        {
            string address = "PacuCommDict/GetOperatingRoomByRoomNo?bedType=" + bedType + "&roomNo=" + roomNo;
            return BaseRepository.GetCallApi<MED_OPERATING_ROOM>(address);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public RequestResult<List<MED_HIS_USERS>> GetHisUsersList()
        {
            string address = "PacuCommDict/GetHisUsersList";
            return BaseRepository.GetCallApi<List<MED_HIS_USERS>>(address);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public RequestResult<MED_HIS_USERS> GetHisUsersList(string userID)
        {
            string address = "PacuCommDict/GetHisUsersList?userID=" + userID;
            return BaseRepository.GetCallApi<MED_HIS_USERS>(address);
        }

        public RequestResult<List<MED_HIS_USERS>> GetHisUsersListByUserJob(string userJob)
        {
            string address = "PacuCommDict/GetHisUsersListByUserJob?userJob=" + userJob;
            return BaseRepository.GetCallApi<List<MED_HIS_USERS>>(address);
        }

        public RequestResult<int> SaveMonitorDictList(List<MED_MONITOR_DICT> item)
        {
            string address = "PacuCommDict/SaveMonitorDictList";
            return BaseRepository.PostCallApi<List<MED_MONITOR_DICT>>(address, item);
        }

        public RequestResult<List<MED_EVENT_SORT>> GetEventSortList(string loginUserId)
        {
            string address = "PacuCommDict/GetEventSortList?USER_ID=" + loginUserId;
            return BaseRepository.GetCallApi<List<MED_EVENT_SORT>>(address);
        }

        public RequestResult<int> SaveEventSortList(List<MED_EVENT_SORT> item)
        {
            string address = "PacuCommDict/SaveEventSortList";
            return BaseRepository.PostCallApi<List<MED_EVENT_SORT>>(address, item);
        }
        public RequestResult<List<MED_ANESTHESIA_DICT>> GetAnesMethodDictList()
        {
            string address = "PacuCommDict/GetAnesMethodDictList";
            return BaseRepository.GetCallApi<List<MED_ANESTHESIA_DICT>>(address);
        }
        public RequestResult<List<MED_OPERATION_DICT>> GetOperNameDictList()
        {
            string address = "PacuCommDict/GetOperNameDictList";
            return BaseRepository.GetCallApi<List<MED_OPERATION_DICT>>(address);
        }

        public RequestResult<List<MED_DIAGNOSIS_DICT>> GetDiagDictList()
        {
            string address = "PacuCommDict/GetDiagDictList";
            return BaseRepository.GetCallApi<List<MED_DIAGNOSIS_DICT>>(address);
        }
        public RequestResult<List<MED_ANESTHESIA_INPUT_DICT>> GetAnesInputDictList(string itemClass)
        {
            string address = "PacuCommDict/GetAnesInputDictList?itemClass=" + itemClass;
            return BaseRepository.GetCallApi<List<MED_ANESTHESIA_INPUT_DICT>>(address);
        }

        /// <summary>
        /// 获得麻醉事件字典扩展表
        /// </summary>
        /// <returns></returns>
        public RequestResult<List<MED_EVENT_DICT_EXT>> GetAnesEventDictExt()
        {
            string address = "PacuCommDict/GetAnesEventDictExt";
            return BaseRepository.GetCallApi<List<MED_EVENT_DICT_EXT>>(address);
        }


        public RequestResult<List<MED_BLOOD_GAS_DICT>> GetBloodGasDictList()
        {
            string address = "PacuCommDict/GetBloodGasDictList";
            return BaseRepository.GetCallApi<List<MED_BLOOD_GAS_DICT>>(address);
        }

        public RequestResult<List<MED_WARD_DICT>> GetWardDictList()
        {
            string address = "PacuCommDict/GetWardDictList";
            return BaseRepository.GetCallApi<List<MED_WARD_DICT>>(address);
        }

        public RequestResult<List<MED_HOSPITAL_CONFIG>> GetHosotalConfig()
        {
            string address = "PacuCommDict/GetHosotalConfig";
            return BaseRepository.GetCallApi<List<MED_HOSPITAL_CONFIG>>(address);
        }
        public RequestResult<List<MED_PAT_MONITOR_DATA_DICT>> GetPatMonitorDict()
        {
            string address = "PacuCommDict/GetPatMonitorDict";
            return BaseRepository.GetCallApi<List<MED_PAT_MONITOR_DATA_DICT>>(address);
        }
        public RequestResult<List<MED_ANES_ALARM_MESSAGE>> GetAnesAlarmMsg(string patientID, int visitID, int operID)
        {
            string address = "PacuCommDict/GetAnesAlarmMsg?patientID=" + patientID + "&visitID=" + visitID + "&operID=" + operID;
            return BaseRepository.GetCallApi<List<MED_ANES_ALARM_MESSAGE>>(address);
        }
        #region IComnDictDataInterface 成员

        public RequestResult<dynamic> GetAllDictList(string loginName)
        {
            string address = "PacuCommDict/GetAllDictList?loginName=" + loginName;
            return BaseRepository.GetCallApi<dynamic>(address);
        }

        public RequestResult<int> SaveOperatingRommList(List<MED_OPERATING_ROOM> item)
        {
            string address = "PacuCommDict/SaveOperatingRommList";
            return BaseRepository.PostCallApi<List<MED_OPERATING_ROOM>>(address, item);
        }
        public RequestResult<int> SaveOperatingRoom(MED_OPERATING_ROOM item)
        {
            string address = "PacuCommDict/SaveOperatingRoom";
            return BaseRepository.PostCallApi<MED_OPERATING_ROOM>(address, item);
        }
        public RequestResult<int> SaveEventList(List<MED_EVENT_DICT> item)
        {
            string address = "PacuCommDict/SaveEventList";
            return BaseRepository.PostCallApi<List<MED_EVENT_DICT>>(address, item);
        }
        public RequestResult<bool> DelEventDict(MED_EVENT_DICT item)
        {
            string address = "PacuCommDict/DelEventDict";
            return BaseRepository.PostCallApi<MED_EVENT_DICT, bool>(address, item);
        }
        public RequestResult<bool> DelEventExtDict(MED_EVENT_DICT_EXT item)
        {
            string address = "PacuCommDict/DelEventExtDict";
            return BaseRepository.PostCallApi<MED_EVENT_DICT_EXT, bool>(address, item);
        }
        public RequestResult<int> SaveEventExtList(List<MED_EVENT_DICT_EXT> item)
        {
            string address = "PacuCommDict/SaveEventExtList";
            return BaseRepository.PostCallApi<List<MED_EVENT_DICT_EXT>>(address, item);
        }
        public RequestResult<int> SavePatMonitorDictList(List<MED_PAT_MONITOR_DATA_DICT> item)
        {
            string address = "PacuCommDict/SavePatMonitorDictList";
            return BaseRepository.PostCallApi<List<MED_PAT_MONITOR_DATA_DICT>>(address, item);
        }
        public RequestResult<bool> SavePatMonitorDict(dynamic item)
        {
            string address = "PacuCommDict/SavePatMonitorDict";
            return BaseRepository.PostCallApi<dynamic, bool>(address, item);
        }
        public RequestResult<int> SaveAnesAlarmMessage(List<MED_ANES_ALARM_MESSAGE> item)
        {
            string address = "PacuCommDict/SaveAnesAlarmMessage";
            return BaseRepository.PostCallApi<List<MED_ANES_ALARM_MESSAGE>>(address, item);
        }
        #endregion

        public RequestResult<bool> SaveAnesInputDict(dynamic item)
        {
            string address = "PacuCommDict/SaveAnesInputDict";
            return BaseRepository.PostCallApi<dynamic, bool>(address, item);
        }

        public RequestResult<bool> SaveEventDict(dynamic item)
        {
            string address = "PacuCommDict/SaveEventDict";
            return BaseRepository.PostCallApi<dynamic, bool>(address, item);
        }

        public RequestResult<bool> SaveEventDictExt(dynamic item)
        {
            string address = "PacuCommDict/SaveEventDictExt";
            return BaseRepository.PostCallApi<dynamic, bool>(address, item);
        }

        public RequestResult<bool> SaveAnesDict(dynamic item)
        {
            string address = "PacuCommDict/SaveAnesDict";
            return BaseRepository.PostCallApi<dynamic, bool>(address, item);
        }
        public RequestResult<int> SaveUnitsDict(List<MED_UNIT_DICT> item)
        {
            string address = "PacuCommDict/SaveUnitsDict";
            return BaseRepository.PostCallApi<List<MED_UNIT_DICT>>(address, item);
        }
        public RequestResult<int> SaveAdministrationDict(List<MED_ADMINISTRATION_DICT> item)
        {
            string address = "PacuCommDict/SaveAdministrationDict";
            return BaseRepository.PostCallApi<List<MED_ADMINISTRATION_DICT>>(address, item);
        }
        public RequestResult<bool> SaveDiagDict(dynamic item)
        {
            string address = "PacuCommDict/SaveDiagDict";
            return BaseRepository.PostCallApi<dynamic, bool>(address, item);
        }

        public RequestResult<bool> SaveHisUserDict(dynamic item)
        {
            string address = "PacuCommDict/SaveHisUserDict";
            return BaseRepository.PostCallApi<dynamic, bool>(address, item);
        }

        public RequestResult<bool> SaveOperDict(dynamic item)
        {
            string address = "PacuCommDict/SaveOperDict";
            return BaseRepository.PostCallApi<dynamic, bool>(address, item);
        }

        public RequestResult<bool> SaveMoniDict(dynamic item)
        {
            string address = "PacuCommDict/SaveMoniDict";
            return BaseRepository.PostCallApi<dynamic, bool>(address, item);
        }

        public RequestResult<bool> SaveOperRoom(dynamic item)
        {
            string address = "PacuCommDict/SaveOperRoom";
            return BaseRepository.PostCallApi<dynamic, bool>(address, item);
        }
        public RequestResult<int> SaveConfig(List<MED_CONFIG> item)
        {
            string address = "PacuCommDict/SaveConfig";
            return BaseRepository.PostCallApi<List<MED_CONFIG>, int>(address, item);
        }
        public RequestResult<List<MED_CONFIG>> GetConfig()
        {
            string address = "PacuCommDict/GetConfig";
            return BaseRepository.GetCallApi<List<MED_CONFIG>>(address);
        }
        public RequestResult<int> SaveBloodGasDict(List<MED_BLOOD_GAS_DICT> item)
        {
            string address = "PacuCommDict/SaveBloodGasDict";
            return BaseRepository.PostCallApi<List<MED_BLOOD_GAS_DICT>, int>(address, item);
        }

        public RequestResult<List<MED_VER_INFO>> GetVerInfoList(string appID)
        {
            string address = "Common/GetVerInfoList?appID=" + appID;
            return BaseRepository.GetCallApi<List<MED_VER_INFO>>(address);
        }
    }
}
