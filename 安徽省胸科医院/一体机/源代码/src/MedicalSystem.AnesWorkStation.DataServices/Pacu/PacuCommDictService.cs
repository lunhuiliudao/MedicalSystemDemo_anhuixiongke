using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    public interface IPacuCommonDictService
    {

        MED_DEPT_DICT GetDeptDict(string deptCode);

        List<MED_DEPT_DICT> GetDeptDictList();

        List<MED_EVENT_DICT> GetEventDictList();

        List<MED_MONITOR_FUNCTION_CODE> GetMonitorFuctionCodeList();

        List<MED_MONITOR_DICT> GetMonitorDictList();

        List<MED_MONITOR_DICT> GetMonitorDictList(string eventNo);

        List<MED_UNIT_DICT> GetUnitDictList();

        List<MED_ADMINISTRATION_DICT> GetAdminstrationDictList();

        List<MED_OPERATING_ROOM> GetAllOperatingRoomList();

        List<MED_OPERATING_ROOM> GetOperatingRoomList(string bedType);

        MED_OPERATING_ROOM GetOperatingRoomByRoomNo(string bedType, string roomNo);

        List<MED_HIS_USERS> GetHisUsersList();

        MED_HIS_USERS GetHisUsersList(string userID);

        List<MED_HIS_USERS> GetHisUsersListByUserJob(string userJob);

        int SaveMonitorDictList(List<MED_MONITOR_DICT> item);

        List<MED_EVENT_SORT> GetEventSortList(string USER_ID);

        int SaveEventSortList(List<MED_EVENT_SORT> item);

        List<MED_ANESTHESIA_DICT> GetAnesMethodDictList();

        List<MED_OPERATION_DICT> GetOperNameDictList();

        List<MED_DIAGNOSIS_DICT> GetDiagDictList();

        List<MED_ANESTHESIA_INPUT_DICT> GetAnesInputDictList(string itemClass);

        List<MED_EVENT_DICT_EXT> GetAnesEventDictExt();

        List<MED_BLOOD_GAS_DICT> GetBloodGasDictList();

        List<MED_WARD_DICT> GetWardDictList();

        List<MED_HOSPITAL_CONFIG> GetHosotalConfig();

        List<MED_CONFIG> GetConfig();

        int SaveOperatingRommList(List<MED_OPERATING_ROOM> item);

        int SaveOperatingRoom(MED_OPERATING_ROOM item);

        int SaveEventList(List<MED_EVENT_DICT> item);

        int SaveEventExtList(List<MED_EVENT_DICT_EXT> item);

        bool DelEventDict(MED_EVENT_DICT item);

        bool DelEventExtDict(MED_EVENT_DICT_EXT item);

        List<MED_PAT_MONITOR_DATA_DICT> GetPatMonitorDict();

        int SavePatMonitorDictList(List<MED_PAT_MONITOR_DATA_DICT> item);

        bool SavePatMonitorDict(dynamic item);

        List<MED_ANES_ALARM_MESSAGE> GetAnesAlarmMsg(string patientID, int visitID, int operID);

        int SaveAnesAlarmMessage(List<MED_ANES_ALARM_MESSAGE> item);

        bool SaveAnesInputDict(dynamic item);

        bool SaveEventDict(dynamic item);

        bool SaveEventDictExt(dynamic item);

        int SaveUnitsDict(List<MED_UNIT_DICT> item);

        int SaveAdministrationDict(List<MED_ADMINISTRATION_DICT> item);

        bool SaveAnesDict(dynamic item);

        bool SaveDiagDict(dynamic item);

        bool SaveHisUserDict(dynamic item);

        bool SaveOperDict(dynamic item);

        bool SaveMoniDict(dynamic item);

        bool SaveOperRoom(dynamic item);

        int SaveConfig(List<MED_CONFIG> item);

        int SaveBloodGasDict(List<MED_BLOOD_GAS_DICT> item);
    }

    public class PacuCommDictService : BaseService<PacuCommDictService>, IPacuCommonDictService
    {
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected PacuCommDictService()
            : base() { }

        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public PacuCommDictService(IDapperContext context)
            : base(context)
        {
        }


        public MED_DEPT_DICT GetDeptDict(string deptCode)
        {
            return dapper.Set<MED_DEPT_DICT>().Select(d => d.DEPT_CODE.Equals(deptCode) || string.IsNullOrEmpty(deptCode)).FirstOrDefault();
        }

        public List<MED_DEPT_DICT> GetDeptDictList()
        {
            return dapper.Set<MED_DEPT_DICT>().Select();
        }

        public List<MED_EVENT_DICT> GetEventDictList()
        {
            return dapper.Set<MED_EVENT_DICT>().Select();
        }

        public List<MED_MONITOR_FUNCTION_CODE> GetMonitorFuctionCodeList()
        {
            return dapper.Set<MED_MONITOR_FUNCTION_CODE>().Select();
        }

        public List<MED_MONITOR_DICT> GetMonitorDictList()
        {
            return dapper.Set<MED_MONITOR_DICT>().Select();
        }

        public List<MED_MONITOR_DICT> GetMonitorDictList(string eventNo)
        {
            return dapper.Set<MED_MONITOR_DICT>().Select(d => d.WARD_TYPE.Equals(eventNo));
        }

        public List<MED_UNIT_DICT> GetUnitDictList()
        {
            return dapper.Set<MED_UNIT_DICT>().Select();
        }

        public List<MED_ADMINISTRATION_DICT> GetAdminstrationDictList()
        {
            return dapper.Set<MED_ADMINISTRATION_DICT>().Select();
        }

        public List<MED_OPERATING_ROOM> GetAllOperatingRoomList()
        {
            return dapper.Set<MED_OPERATING_ROOM>().Select();
        }

        public List<MED_OPERATING_ROOM> GetOperatingRoomList(string bedType)
        {
            return dapper.Set<MED_OPERATING_ROOM>().Select(d => d.BED_TYPE.Equals(bedType));
        }

        public MED_OPERATING_ROOM GetOperatingRoomByRoomNo(string bedType, string roomNo)
        {
            if (!string.IsNullOrEmpty(bedType) && !string.IsNullOrEmpty(roomNo))
            {
                return dapper.Set<MED_OPERATING_ROOM>().Single(d => d.BED_TYPE.Equals(bedType) && d.ROOM_NO == roomNo);
            }
            else
            {
                return null;
            }
        }

        public List<MED_HIS_USERS> GetHisUsersList()
        {
            return dapper.Set<MED_HIS_USERS>().Select();
        }

        public MED_HIS_USERS GetHisUsersList(string userID)
        {
            return dapper.Set<MED_HIS_USERS>().Select(d => d.USER_JOB_ID.Equals(userID)).FirstOrDefault();
        }

        public List<MED_HIS_USERS> GetHisUsersListByUserJob(string userJob)
        {
            return dapper.Set<MED_HIS_USERS>().Select(d => d.USER_JOB_ID == userJob && d.USER_STATUS == 1);
        }

        public int SaveMonitorDictList(List<MED_MONITOR_DICT> item)
        {
            int result = dapper.Set<MED_MONITOR_DICT>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public List<MED_EVENT_SORT> GetEventSortList(string USER_ID)
        {
            return dapper.Set<MED_EVENT_SORT>().Select(d => d.USER_ID.Equals(USER_ID));
        }

        public int SaveEventSortList(List<MED_EVENT_SORT> item)
        {
            int result = dapper.Set<MED_EVENT_SORT>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public List<MED_ANESTHESIA_DICT> GetAnesMethodDictList()
        {
            return dapper.Set<MED_ANESTHESIA_DICT>().Select();
        }

        public List<MED_OPERATION_DICT> GetOperNameDictList()
        {
            return dapper.Set<MED_OPERATION_DICT>().Select();
        }

        public List<MED_DIAGNOSIS_DICT> GetDiagDictList()
        {
            return dapper.Set<MED_DIAGNOSIS_DICT>().Select();
        }

        public List<MED_ANESTHESIA_INPUT_DICT> GetAnesInputDictList(string itemClass)
        {
            bool flag = string.IsNullOrEmpty(itemClass);

            return dapper.Set<MED_ANESTHESIA_INPUT_DICT>().Select(d => flag || d.ITEM_CLASS == itemClass);
        }

        public List<MED_EVENT_DICT_EXT> GetAnesEventDictExt()
        {
            return dapper.Set<MED_EVENT_DICT_EXT>().Select();
        }

        public List<MED_BLOOD_GAS_DICT> GetBloodGasDictList()
        {
            return dapper.Set<MED_BLOOD_GAS_DICT>().Select();
        }

        public List<MED_WARD_DICT> GetWardDictList()
        {
            return dapper.Set<MED_WARD_DICT>().Select();
        }

        public List<MED_HOSPITAL_CONFIG> GetHosotalConfig()
        {
            return dapper.Set<MED_HOSPITAL_CONFIG>().Select();
        }

        public List<MED_CONFIG> GetConfig()
        {
            return dapper.Set<MED_CONFIG>().Select();
        }

        public int SaveOperatingRommList(List<MED_OPERATING_ROOM> item)
        {
            int result = dapper.Set<MED_OPERATING_ROOM>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public int SaveOperatingRoom(MED_OPERATING_ROOM item)
        {
            int result = dapper.Set<MED_OPERATING_ROOM>().Save(item) == true ? 1 : 0;

            dapper.SaveChanges();

            return result;
        }

        public int SaveEventList(List<MED_EVENT_DICT> item)
        {
            int result = dapper.Set<MED_EVENT_DICT>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public int SaveEventExtList(List<MED_EVENT_DICT_EXT> item)
        {
            int result = dapper.Set<MED_EVENT_DICT_EXT>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public bool DelEventDict(MED_EVENT_DICT item)
        {
            bool result = dapper.Set<MED_EVENT_DICT>().Delete(item);

            dapper.SaveChanges();

            return result;
        }

        public bool DelEventExtDict(MED_EVENT_DICT_EXT item)
        {
            bool result = dapper.Set<MED_EVENT_DICT_EXT>().Delete(item);

            dapper.SaveChanges();

            return result;
        }

        public List<MED_PAT_MONITOR_DATA_DICT> GetPatMonitorDict()
        {
            return dapper.Set<MED_PAT_MONITOR_DATA_DICT>().Select();

        }

        public int SavePatMonitorDictList(List<MED_PAT_MONITOR_DATA_DICT> item)
        {
            int result = dapper.Set<MED_PAT_MONITOR_DATA_DICT>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public bool SavePatMonitorDict(dynamic item)
        {
            int result = 0;

            List<MED_PAT_MONITOR_DATA_DICT> newAndUpdateList = null;

            List<MED_PAT_MONITOR_DATA_DICT> delList = null;

            if (item.newAndUpdateList != null)
            {
                string value = item.newAndUpdateList.ToString();
                newAndUpdateList = JsonConvert.DeserializeObject<List<MED_PAT_MONITOR_DATA_DICT>>(value);

                foreach (var nu in newAndUpdateList)
                {
                    result += dapper.Set<MED_PAT_MONITOR_DATA_DICT>().Save(nu) == true ? 1 : 0;
                }
            }
            if (item.delList != null)
            {
                string value = item.delList.ToString();
                delList = JsonConvert.DeserializeObject<List<MED_PAT_MONITOR_DATA_DICT>>(value);

                foreach (var nu in delList)
                {
                    result += dapper.Set<MED_PAT_MONITOR_DATA_DICT>().Delete(nu) == true ? 1 : 0;
                }
            }

            dapper.SaveChanges();

            return result > 0 ? true : false;
        }

        public List<MED_ANES_ALARM_MESSAGE> GetAnesAlarmMsg(string patientID, int visitID, int operID)
        {
            return dapper.Set<MED_ANES_ALARM_MESSAGE>().Select(d => d.PATIENT_ID == patientID && d.VISIT_ID == visitID && d.OPER_ID == operID);
        }

        public int SaveAnesAlarmMessage(List<MED_ANES_ALARM_MESSAGE> item)
        {
            int result = dapper.Set<MED_ANES_ALARM_MESSAGE>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public bool SaveAnesInputDict(dynamic item)
        {
            int result = 0;

            List<MED_ANESTHESIA_INPUT_DICT> newAndUpdateList = null;

            List<MED_ANESTHESIA_INPUT_DICT> delList = null;

            if (item.newAndUpdateList != null)
            {
                string value = item.newAndUpdateList.ToString();
                newAndUpdateList = JsonConvert.DeserializeObject<List<MED_ANESTHESIA_INPUT_DICT>>(value);
                foreach (var nu in newAndUpdateList)
                {
                    result += dapper.Set<MED_ANESTHESIA_INPUT_DICT>().Save(nu) == true ? 1 : 0;
                }
            }
            if (item.delList != null)
            {
                string value = item.delList.ToString();
                delList = JsonConvert.DeserializeObject<List<MED_ANESTHESIA_INPUT_DICT>>(value);
                foreach (var nu in delList)
                {
                    result += dapper.Set<MED_ANESTHESIA_INPUT_DICT>().Delete(nu) == true ? 1 : 0;
                }
            }

            dapper.SaveChanges();

            return result > 0 ? true : false;
        }

        public bool SaveEventDict(dynamic item)
        {
            int result = 0;

            List<MED_EVENT_DICT> newAndUpdateList = null;

            List<MED_EVENT_DICT> delList = null;

            if (item.newAndUpdateList != null)
            {
                string value = item.newAndUpdateList.ToString();
                newAndUpdateList = JsonConvert.DeserializeObject<List<MED_EVENT_DICT>>(value);
                foreach (var nu in newAndUpdateList)
                {
                    result += dapper.Set<MED_EVENT_DICT>().Save(nu) == true ? 1 : 0;
                }
            }
            if (item.delList != null)
            {
                string value = item.delList.ToString();
                delList = JsonConvert.DeserializeObject<List<MED_EVENT_DICT>>(value);
                foreach (var nu in delList)
                {
                    result += dapper.Set<MED_EVENT_DICT>().Delete(nu) == true ? 1 : 0;
                }
            }

            dapper.SaveChanges();

            return result > 0 ? true : false;
        }

        public bool SaveEventDictExt(dynamic item)
        {
            int result = 0;

            List<MED_EVENT_DICT_EXT> newAndUpdateList = null;

            List<MED_EVENT_DICT_EXT> delList = null;

            if (item.newAndUpdateList != null)
            {
                string value = item.newAndUpdateList.ToString();
                newAndUpdateList = JsonConvert.DeserializeObject<List<MED_EVENT_DICT_EXT>>(value);
                foreach (var nu in newAndUpdateList)
                {
                    result += dapper.Set<MED_EVENT_DICT_EXT>().Save(nu) == true ? 1 : 0;
                }
            }
            if (item.delList != null)
            {
                string value = item.delList.ToString();
                delList = JsonConvert.DeserializeObject<List<MED_EVENT_DICT_EXT>>(value);
                foreach (var nu in delList)
                {
                    result += dapper.Set<MED_EVENT_DICT_EXT>().Delete(nu) == true ? 1 : 0;
                }
            }

            dapper.SaveChanges();

            return result > 0 ? true : false;
        }

        public int SaveUnitsDict(List<MED_UNIT_DICT> item)
        {
            int result = dapper.Set<MED_UNIT_DICT>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public int SaveAdministrationDict(List<MED_ADMINISTRATION_DICT> item)
        {
            int result = dapper.Set<MED_ADMINISTRATION_DICT>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public bool SaveAnesDict(dynamic item)
        {
            int result = 0;

            List<MED_ANESTHESIA_DICT> newAndUpdateList = null;

            List<MED_ANESTHESIA_DICT> delList = null;

            if (item.newAndUpdateList != null)
            {
                string value = item.newAndUpdateList.ToString();
                newAndUpdateList = JsonConvert.DeserializeObject<List<MED_ANESTHESIA_DICT>>(value);
                foreach (var nu in newAndUpdateList)
                {
                    result += dapper.Set<MED_ANESTHESIA_DICT>().Save(nu) == true ? 1 : 0;
                }
            }
            if (item.delList != null)
            {
                string value = item.delList.ToString();
                delList = JsonConvert.DeserializeObject<List<MED_ANESTHESIA_DICT>>(value);
                foreach (var nu in delList)
                {
                    result += dapper.Set<MED_ANESTHESIA_DICT>().Delete(nu) == true ? 1 : 0;
                }
            }

            dapper.SaveChanges();

            return result > 0 ? true : false;
        }

        public bool SaveDiagDict(dynamic item)
        {
            int result = 0;

            List<MED_DIAGNOSIS_DICT> newAndUpdateList = null;

            List<MED_DIAGNOSIS_DICT> delList = null;

            if (item.newAndUpdateList != null)
            {
                string value = item.newAndUpdateList.ToString();
                newAndUpdateList = JsonConvert.DeserializeObject<List<MED_DIAGNOSIS_DICT>>(value);
                foreach (var nu in newAndUpdateList)
                {
                    result += dapper.Set<MED_DIAGNOSIS_DICT>().Save(nu) == true ? 1 : 0;
                }
            }
            if (item.delList != null)
            {
                string value = item.delList.ToString();
                delList = JsonConvert.DeserializeObject<List<MED_DIAGNOSIS_DICT>>(value);
                foreach (var nu in delList)
                {
                    result += dapper.Set<MED_DIAGNOSIS_DICT>().Delete(nu) == true ? 1 : 0;
                }
            }

            dapper.SaveChanges();

            return result > 0 ? true : false;
        }

        public bool SaveHisUserDict(dynamic item)
        {
            int result = 0;

            List<MED_HIS_USERS> newAndUpdateList = null;

            List<MED_HIS_USERS> delList = null;

            if (item.newAndUpdateList != null)
            {
                string value = item.newAndUpdateList.ToString();
                newAndUpdateList = JsonConvert.DeserializeObject<List<MED_HIS_USERS>>(value);
                foreach (var nu in newAndUpdateList)
                {
                    result += dapper.Set<MED_HIS_USERS>().Save(nu) == true ? 1 : 0;
                }
            }
            if (item.delList != null)
            {
                string value = item.delList.ToString();
                delList = JsonConvert.DeserializeObject<List<MED_HIS_USERS>>(value);
                foreach (var nu in delList)
                {
                    result += dapper.Set<MED_HIS_USERS>().Delete(nu) == true ? 1 : 0;
                }
            }

            dapper.SaveChanges();

            return result > 0 ? true : false;
        }

        public bool SaveOperDict(dynamic item)
        {
            int result = 0;

            List<MED_OPERATION_DICT> newAndUpdateList = null;

            List<MED_OPERATION_DICT> delList = null;

            if (item.newAndUpdateList != null)
            {
                string value = item.newAndUpdateList.ToString();
                newAndUpdateList = JsonConvert.DeserializeObject<List<MED_OPERATION_DICT>>(value);
                foreach (var nu in newAndUpdateList)
                {
                    result += dapper.Set<MED_OPERATION_DICT>().Save(nu) == true ? 1 : 0;
                }
            }
            if (item.delList != null)
            {
                string value = item.delList.ToString();
                delList = JsonConvert.DeserializeObject<List<MED_OPERATION_DICT>>(value);
                foreach (var nu in delList)
                {
                    result += dapper.Set<MED_OPERATION_DICT>().Delete(nu) == true ? 1 : 0;
                }
            }

            dapper.SaveChanges();

            return result > 0 ? true : false;
        }

        public bool SaveMoniDict(dynamic item)
        {
            int result = 0;

            List<MED_MONITOR_DICT> newAndUpdateList = null;

            List<MED_MONITOR_DICT> delList = null;

            if (item.newAndUpdateList != null)
            {
                string value = item.newAndUpdateList.ToString();
                newAndUpdateList = JsonConvert.DeserializeObject<List<MED_MONITOR_DICT>>(value);
                foreach (var nu in newAndUpdateList)
                {
                    result += dapper.Set<MED_MONITOR_DICT>().Save(nu) == true ? 1 : 0;
                }
            }
            if (item.delList != null)
            {
                string value = item.delList.ToString();
                delList = JsonConvert.DeserializeObject<List<MED_MONITOR_DICT>>(value);
                foreach (var nu in delList)
                {
                    result += dapper.Set<MED_MONITOR_DICT>().Delete(nu) == true ? 1 : 0;
                }
            }

            dapper.SaveChanges();

            return result > 0 ? true : false;
        }

        public bool SaveOperRoom(dynamic item)
        {
            int result = 0;

            List<MED_OPERATING_ROOM> newAndUpdateList = null;

            List<MED_OPERATING_ROOM> delList = null;

            if (item.newAndUpdateList != null)
            {
                string value = item.newAndUpdateList.ToString();
                newAndUpdateList = JsonConvert.DeserializeObject<List<MED_OPERATING_ROOM>>(value);
                foreach (var nu in newAndUpdateList)
                {
                    result += dapper.Set<MED_OPERATING_ROOM>().Save(nu) == true ? 1 : 0;
                }
            }
            if (item.delList != null)
            {
                string value = item.delList.ToString();
                delList = JsonConvert.DeserializeObject<List<MED_OPERATING_ROOM>>(value);
                foreach (var nu in delList)
                {
                    result += dapper.Set<MED_OPERATING_ROOM>().Delete(nu) == true ? 1 : 0;
                }
            }

            dapper.SaveChanges();

            return result > 0 ? true : false;
        }

        public int SaveConfig(List<MED_CONFIG> item)
        {
            int result = dapper.Set<MED_CONFIG>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public int SaveBloodGasDict(List<MED_BLOOD_GAS_DICT> item)
        {
            int result = dapper.Set<MED_BLOOD_GAS_DICT>().Save(item);

            dapper.SaveChanges();

            return result;
        }
    }
}
