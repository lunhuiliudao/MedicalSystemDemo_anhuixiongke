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
    public class PacuCommDictController : BaseController
    {

        IPacuCommonDictService _pacuCommonService;

        public PacuCommDictController(IPacuCommonDictService pacuCommonService)
        {
            _pacuCommonService = pacuCommonService;
        }

        /// <summary>
        /// 根据科室代码获取科室字典
        /// </summary>
        /// <param name="deptCode">科室代码</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<MED_DEPT_DICT> GetDeptDict(string deptCode)
        {
            return Success(_pacuCommonService.GetDeptDict(deptCode));
        }
        /// <summary>
        /// 获取科室字典
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_DEPT_DICT>> GetDeptDictList()
        {
            return Success(_pacuCommonService.GetDeptDictList());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_EVENT_DICT>> GetEventDictList()
        {
            return Success(_pacuCommonService.GetEventDictList());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_MONITOR_FUNCTION_CODE>> GetMonitorFuctionCodeList()
        {
            return Success(_pacuCommonService.GetMonitorFuctionCodeList());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_MONITOR_DICT>> GetMonitorDictList()
        {
            return Success(_pacuCommonService.GetMonitorDictList());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventNo"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_MONITOR_DICT>> GetMonitorDictList(string eventNo)
        {
            return Success(_pacuCommonService.GetMonitorDictList(eventNo));
        }

        /// <summary>
        /// 获得单位字典表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_UNIT_DICT>> GetUnitDictList()
        {
            return Success(_pacuCommonService.GetUnitDictList());
        }

        /// <summary>
        /// 获得用药途径字典表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_ADMINISTRATION_DICT>> GetAdminstrationDictList()
        {
            return Success(_pacuCommonService.GetAdminstrationDictList());
        }

        [HttpGet]
        public RequestResult<List<MED_OPERATING_ROOM>> GetAllOperatingRoomList()
        {
            return Success(_pacuCommonService.GetAllOperatingRoomList());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bedType"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_OPERATING_ROOM>> GetOperatingRoomList(string bedType)
        {
            return Success(_pacuCommonService.GetOperatingRoomList(bedType));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bedType"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<MED_OPERATING_ROOM> GetOperatingRoomByRoomNo(string bedType,string roomNo)
        {
            return Success(_pacuCommonService.GetOperatingRoomByRoomNo(bedType, roomNo));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_HIS_USERS>> GetHisUsersList()
        {
            return Success(_pacuCommonService.GetHisUsersList());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<MED_HIS_USERS> GetHisUsersList(string userID)
        {
            return Success(_pacuCommonService.GetHisUsersList(userID));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userJob"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_HIS_USERS>> GetHisUsersListByUserJob(string userJob)
        {
            return Success(_pacuCommonService.GetHisUsersListByUserJob(userJob));
        }

        [HttpPost]
        public RequestResult<int> SaveMonitorDictList(List<MED_MONITOR_DICT> item)
        {
            return Success(_pacuCommonService.SaveMonitorDictList(item));
        }

        [HttpGet]
        public RequestResult<List<MED_EVENT_SORT>> GetEventSortList(string USER_ID)
        {
            return Success(_pacuCommonService.GetEventSortList(USER_ID));
        }

        [HttpPost]
        public RequestResult<int> SaveEventSortList(List<MED_EVENT_SORT> item)
        {
            return Success(_pacuCommonService.SaveEventSortList(item));
        }

        /// <summary>
        /// 获取麻醉方法字典
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_ANESTHESIA_DICT>> GetAnesMethodDictList()
        {
            return Success(_pacuCommonService.GetAnesMethodDictList());
        }

        /// <summary>
        /// 获取手术名称字典
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_OPERATION_DICT>> GetOperNameDictList()
        {
            return Success(_pacuCommonService.GetOperNameDictList());
        }

        /// <summary>
        /// 获取诊断字典
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_DIAGNOSIS_DICT>> GetDiagDictList()
        {
            return Success(_pacuCommonService.GetDiagDictList());
        }
        [HttpGet]
        public RequestResult<List<MED_ANESTHESIA_INPUT_DICT>> GetAnesInputDictList(string itemClass)
        {
            return Success(_pacuCommonService.GetAnesInputDictList(itemClass));
        }

        /// <summary>
        /// 获得麻醉事件字扩展表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_EVENT_DICT_EXT>> GetAnesEventDictExt()
        {
            return Success(_pacuCommonService.GetAnesEventDictExt());
        }

        /// <summary>
        /// 血气分析字典表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_BLOOD_GAS_DICT>> GetBloodGasDictList()
        {
            return Success(_pacuCommonService.GetBloodGasDictList());
        }

        /// <summary>
        /// 获得病区字典表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_WARD_DICT>> GetWardDictList()
        {
            return Success(_pacuCommonService.GetWardDictList());
        }
        /// <summary>
        /// 获取医院抬头
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<MED_HOSPITAL_CONFIG>> GetHosotalConfig()
        {
            return Success(_pacuCommonService.GetHosotalConfig());
        }
        [HttpGet]
        public RequestResult<List<MED_CONFIG>> GetConfig()
        {
            return Success(_pacuCommonService.GetConfig());
        }
        #region IComnDictDataInterface 成员

        public RequestResult<dynamic> GetAllDictList(string loginName)
        {
            dynamic data = new
            {
                //录入字典表
                EventDict = GetEventDictList().Data,
                //麻醉事件字典扩展表
                EventDictExt = GetAnesEventDictExt().Data,
                //属性单位字典表
                UnitDictExt = GetUnitDictList().Data,
                //给药途径字典表
                AdministrationDictExt = GetAdminstrationDictList().Data,
                //麻醉事件排序字典表
                EventSortDict = GetEventSortList(loginName).Data,
                //用户字典表
                HisUsersDict = GetHisUsersList().Data,
                //科室字典表
                DeptDict = GetDeptDictList().Data,
                //检测项目字典表
                MonitorFuntionDict = GetMonitorFuctionCodeList().Data,
                //手术室字典表
                OperationRoomDict = GetOperatingRoomList("0").Data,
                //通用项目字典表
                AnesInputDictDict = GetAnesInputDictList(null).Data,
                //血气字典表
                BloodGasDict = GetBloodGasDictList().Data,
                //病区字典表
                WardDict = GetWardDictList().Data,
                //麻醉方法字典表
                AnesMethodDict = GetAnesMethodDictList().Data,
                //监护仪字典表
                MonitorDict = GetMonitorDictList().Data,
                //获取医院抬头
                HosotalConfigDict = GetHosotalConfig().Data,
                //获取配置表
                ConfigDict = GetConfig().Data,
            };
            return Success(data);
        }

        [HttpPost]
        public RequestResult<int> SaveOperatingRommList(List<MED_OPERATING_ROOM> item)
        {
            return Success(_pacuCommonService.SaveOperatingRommList(item));
        }
        [HttpPost]
        public RequestResult<int> SaveOperatingRoom(MED_OPERATING_ROOM item)
        {
            return Success(_pacuCommonService.SaveOperatingRoom(item));
        }
        [HttpPost]
        public RequestResult<int> SaveEventList(List<MED_EVENT_DICT> item)
        {
            return Success(_pacuCommonService.SaveEventList(item));
        }
        [HttpPost]
        public RequestResult<int> SaveEventExtList(List<MED_EVENT_DICT_EXT> item)
        {
            return Success(_pacuCommonService.SaveEventExtList(item));
        }
        [HttpPost]
        public RequestResult<bool> DelEventDict(MED_EVENT_DICT item)
        {
            return Success(_pacuCommonService.DelEventDict(item));
        }
        [HttpPost]
        public RequestResult<bool> DelEventExtDict(MED_EVENT_DICT_EXT item)
        {
            return Success(_pacuCommonService.DelEventExtDict(item));
        }
        [HttpGet]
        public RequestResult<List<MED_PAT_MONITOR_DATA_DICT>> GetPatMonitorDict()
        {
            return Success(_pacuCommonService.GetPatMonitorDict());
        }
        [HttpPost]
        public RequestResult<int> SavePatMonitorDictList(List<MED_PAT_MONITOR_DATA_DICT> item)
        {
            return Success(_pacuCommonService.SavePatMonitorDictList(item));
        }
        [HttpPost]
        public RequestResult<bool> SavePatMonitorDict(dynamic item)
        {
            return Success(_pacuCommonService.SavePatMonitorDict(item));
        }
        [HttpGet]
        public RequestResult<List<MED_ANES_ALARM_MESSAGE>> GetAnesAlarmMsg(string patientID, int visitID, int operID)
        {
            return Success(_pacuCommonService.GetAnesAlarmMsg(patientID, visitID, operID));
        }
        [HttpPost]
        public RequestResult<int> SaveAnesAlarmMessage(List<MED_ANES_ALARM_MESSAGE> item)
        {
            return Success(_pacuCommonService.SaveAnesAlarmMessage(item));
        }
        #endregion

        #region IComnDictDataInterface 成员 保存修改的方法接口


        public RequestResult<bool> SaveAnesInputDict(dynamic item)
        {
            return Success(_pacuCommonService.SaveAnesInputDict(item));
        }

        public RequestResult<bool> SaveEventDict(dynamic item)
        {
            return Success(_pacuCommonService.SaveEventDict(item));
        }

        public RequestResult<bool> SaveEventDictExt(dynamic item)
        {
            return Success(_pacuCommonService.SaveEventDictExt(item));
        }

        public RequestResult<int> SaveUnitsDict(List<MED_UNIT_DICT> item)
        {
            return Success(_pacuCommonService.SaveUnitsDict(item));
        }

        public RequestResult<int> SaveAdministrationDict(List<MED_ADMINISTRATION_DICT> item)
        {
            return Success(_pacuCommonService.SaveAdministrationDict(item));
        }

        public RequestResult<bool> SaveAnesDict(dynamic item)
        {
            return Success(_pacuCommonService.SaveAnesDict(item));
        }

        public RequestResult<bool> SaveDiagDict(dynamic item)
        {
            return Success(_pacuCommonService.SaveDiagDict(item));
        }

        public RequestResult<bool> SaveHisUserDict(dynamic item)
        {
            return Success(_pacuCommonService.SaveHisUserDict(item));
        }

        public RequestResult<bool> SaveOperDict(dynamic item)
        {
            return Success(_pacuCommonService.SaveOperDict(item));
        }

        public RequestResult<bool> SaveMoniDict(dynamic item)
        {
            return Success(_pacuCommonService.SaveMoniDict(item));
        }

        public RequestResult<bool> SaveOperRoom(dynamic item)
        {
            return Success(_pacuCommonService.SaveOperRoom(item));
        }

        public RequestResult<int> SaveConfig(List<MED_CONFIG> item)
        {
            return Success(_pacuCommonService.SaveConfig(item));
        }

        public RequestResult<int> SaveBloodGasDict(List<MED_BLOOD_GAS_DICT> item)
        {
            return Success(_pacuCommonService.SaveBloodGasDict(item));
        }

        #endregion
    }
}