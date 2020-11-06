using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using MedicalSystem.DataServices.Domain;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers
{
    public class DictController : BaseController
    {
        IDictService dictService;
        public DictController(IDictService iDictService)
        {
            dictService = iDictService;
        }

        [HttpGet]
        public RequestResult<List<MED_DEPT_DICT>> GetDeptDictList()
        {
            List<MED_DEPT_DICT> deptDictList = dictService.GetDeptDictList();
            return Success(deptDictList);
        }

        [HttpGet]
        public RequestResult<List<MED_EVENT_DICT>> GetEventDictList()
        {
            List<MED_EVENT_DICT> eventDictList = dictService.GetEventDictList();
            return Success(eventDictList);
        }

        public RequestResult<List<MED_EVENT_DICT>> GetEventDictListByItemClass(string itemClass)
        {
            List<MED_EVENT_DICT> eventDictList = dictService.GetEventDictListByItemClass(itemClass);
            return Success(eventDictList);
        }

        [HttpGet]
        public RequestResult<List<MED_MONITOR_FUNCTION_CODE>> GetMonitorFuctionCodeList()
        {
            List<MED_MONITOR_FUNCTION_CODE> fuctionCodeList = dictService.GetMonitorFuctionCodeList();
            return Success(fuctionCodeList);
        }

        [HttpGet]
        public RequestResult<List<MED_MONITOR_DICT>> GetMonitorDictList()
        {
            List<MED_MONITOR_DICT> monitorDictList = dictService.GetMonitorDictList();
            return Success(monitorDictList);
        }

        [HttpGet]
        public RequestResult<List<MED_BLOOD_GAS_DICT>> GetBloodGasDictList()
        {
            List<MED_BLOOD_GAS_DICT> bloodGasDictList = dictService.GetBloodGasDictList();
            return Success(bloodGasDictList);
        }

        [HttpGet]
        public RequestResult<List<MED_MONITOR_DICT>> GetMonitorDictListByNo(int eventNo)
        {
            List<MED_MONITOR_DICT> result = dictService.GetMonitorDictListByNo(eventNo);
            return Success(result);
        }

        [HttpGet]
        public RequestResult<List<MED_MONITOR_DICT>> GetMonitorDictListByBedNo(string bedNo)
        {
            List<MED_MONITOR_DICT> result = dictService.GetMonitorDictListByBedNo(bedNo);
            return Success(result);
        }

        [HttpGet]
        public RequestResult<List<MED_ANESTHESIA_DICT>> GetAnesthesiaDictList()
        {
            List<MED_ANESTHESIA_DICT> result = dictService.GetAnesthesiaDictList();
            return Success(result);
        }

        [HttpGet]
        public RequestResult<List<string>> GetAnesthesiaTypeDictList()
        {
            List<string> result = dictService.GetAnesthesiaTypeDictList();
            return Success(result);
        }

        [HttpGet]
        public RequestResult<List<MED_ANESTHESIA_INPUT_DICT>> GetAnesthesiaInputDictList()
        {
            List<MED_ANESTHESIA_INPUT_DICT> result = dictService.GetAnesthesiaInputDictList();
            return Success(result);
        }

        [HttpGet]
        public RequestResult<List<MED_ANESTHESIA_INPUT_DICT>> GetAnesthesiaInputDictList(string ItemClass)
        {
            List<MED_ANESTHESIA_INPUT_DICT> result = dictService.GetAnesthesiaInputDictList(ItemClass);
            return Success(result);
        }

        [HttpGet]
        public RequestResult<List<MED_APPLICATIONS>> GetApplicationsList()
        {
            List<MED_APPLICATIONS> result = dictService.GetApplicationsList();
            return Success(result);
        }

        [HttpGet]
        public RequestResult<List<MED_BILL_ITEM_CLASS_DICT>> GetBillItemClassDictList()
        {
            List<MED_BILL_ITEM_CLASS_DICT> result = dictService.GetBillItemClassDictList();
            return Success(result);
        }

        [HttpGet]
        public RequestResult<List<MED_CLIENT_COMPUTER>> GetClientComputerList()
        {
            List<MED_CLIENT_COMPUTER> result = dictService.GetClientComputerList();
            return Success(result);
        }

        [HttpGet]
        public RequestResult<List<MED_CONFIG>> GetConfigList()
        {
            List<MED_CONFIG> result = dictService.GetConfigList();
            return Success(result);
        }

        [HttpGet]
        public RequestResult<List<MED_DIAGNOSIS_DICT>> GetDiagnosisDictList()
        {
            List<MED_DIAGNOSIS_DICT> result = dictService.GetDiagnosisDictList();
            return Success(result);
        }

        [HttpGet]
        public RequestResult<List<MED_DOCUMENT_TEMPLET>> GetDocumentTempletList()
        {
            List<MED_DOCUMENT_TEMPLET> result = dictService.GetDocumentTempletList();
            return Success(result);
        }

        [HttpGet]
        public RequestResult<List<MED_EVENT_DICT_EXT>> GetEventDictExtList()
        {
            List<MED_EVENT_DICT_EXT> result = dictService.GetEventDictExtList();
            return Success(result);
        }

        public RequestResult<List<MED_EVENT_DICT_EXT>> GetEventDictExtListByEvent(string eventClassCode, string eventItemCode)
        {
            List<MED_EVENT_DICT_EXT> result = dictService.GetEventDictExtListByEvent(eventClassCode, eventItemCode);
            return Success(result);
        }

        [HttpGet]
        public RequestResult<List<MED_EVENT_ITEM_CLASS_DICT>> GetEventItemClassDictClass()
        {
            List<MED_EVENT_ITEM_CLASS_DICT> result = dictService.GetEventItemClassDictClass();
            return Success(result);
        }

        [HttpGet]
        public RequestResult<List<MED_EVENT_SORT>> GetEventSortList()
        {
            List<MED_EVENT_SORT> result = dictService.GetEventSortList();
            return Success(result);
        }

        [HttpGet]
        public RequestResult<List<MED_EVENT_VS_BILL>> GetEventVSBillList()
        {
            List<MED_EVENT_VS_BILL> result = dictService.GetEventVSBillList();
            return Success(result);
        }

        [HttpGet]
        public RequestResult<List<MED_HIS_USERS>> GetHisUsersList()
        {
            List<MED_HIS_USERS> result = dictService.GetHisUsersList();
            return Success(result);
        }

        [HttpGet]
        public RequestResult<List<MED_HIS_USERS>> GetHisUsersList(string UserJob)
        {
            List<MED_HIS_USERS> result = dictService.GetHisUsersList(UserJob);
            return Success(result);
        }

        [HttpGet]
        public RequestResult<List<MED_HOSP_BRANCH_DICT>> GetHospBranchDictList()
        {
            List<MED_HOSP_BRANCH_DICT> result = dictService.GetHospBranchDictList();
            return Success(result);
        }

        [HttpGet]
        public RequestResult<List<MED_HOSPITAL_CONFIG>> GetHospitalConfigList()
        {
            List<MED_HOSPITAL_CONFIG> result = dictService.GetHospitalConfigList();
            return Success(result);
        }

        [HttpGet]
        public RequestResult<List<MED_METHOD_DICT>> GetMethodDictList()
        {
            List<MED_METHOD_DICT> result = dictService.GetMethodDictList();
            return Success(result);
        }

        [HttpGet]
        public RequestResult<List<MED_OPERATING_ROOM>> GetOperatingRoomList()
        {
            List<MED_OPERATING_ROOM> result = dictService.GetOperatingRoomList();
            return Success(result);
        }

        [HttpGet]
        public RequestResult<List<MED_OPERATING_ROOM>> GetOperatingRoomListByType(string type, string deptCode)
        {
            List<MED_OPERATING_ROOM> result = dictService.GetOperatingRoomListByType(type, deptCode);
            return Success(result);
        }

        [HttpGet]
        public RequestResult<List<MED_OPERATING_ROOM_VS_MONITOR>> GetOperatingRoomVSMonitorList()
        {
            List<MED_OPERATING_ROOM_VS_MONITOR> result = dictService.GetOperatingRoomVSMonitorList();
            return Success(result);
        }

        [HttpGet]
        public RequestResult<List<MED_OPERATION_DICT>> GetOperationDictList()
        {
            List<MED_OPERATION_DICT> result = dictService.GetOperationDictList();
            return Success(result);
        }

        [HttpGet]
        public RequestResult<List<MED_OPERATION_STATUS_DICT>> GetOperationStatusDictList()
        {
            List<MED_OPERATION_STATUS_DICT> result = dictService.GetOperationStatusDictList();
            return Success(result);
        }

        [HttpGet]
        public RequestResult<List<MED_OPERSCORE_DICT>> GetOperscoreDictList()
        {
            List<MED_OPERSCORE_DICT> result = dictService.GetOperscoreDictList();
            return Success(result);
        }

        [HttpGet]
        public RequestResult<List<MED_PERIOPERATIVE_EVENT_CONFIG>> GetPerioperativeEventConfigList()
        {
            List<MED_PERIOPERATIVE_EVENT_CONFIG> result = dictService.GetPerioperativeEventConfigList();
            return Success(result);
        }

        [HttpGet]
        public RequestResult<List<MED_UNIT_DICT>> GetUnitDictList()
        {
            List<MED_UNIT_DICT> result = dictService.GetUnitDictList();
            return Success(result);
        }

        [HttpGet]
        public RequestResult<List<MED_UNIT_DICT>> GetUnitDictList(int unitType)
        {
            List<MED_UNIT_DICT> result = dictService.GetUnitDictList(unitType);
            return Success(result);
        }

        [HttpGet]
        public RequestResult<List<MED_WARD_DICT>> GetWardDictList()
        {
            List<MED_WARD_DICT> result = dictService.GetWardDictList();
            return Success(result);
        }
        [HttpGet]
        public RequestResult<List<MED_PAT_MONITOR_DATA_DICT>> GetPatMonitorDict()
        {
            List<MED_PAT_MONITOR_DATA_DICT> result = dictService.GetPatMonitorDict();
            return Success(result);
        }
        [HttpGet]
        public RequestResult<List<MED_EVENT_SORT>> GetEventSortList(string loginUserId)
        {
            List<MED_EVENT_SORT> result = dictService.GetEventSortList(loginUserId);
            return Success(result);
        }

        [HttpPost]
        public RequestResult<bool> SaveEventSortList(List<MED_EVENT_SORT> dataList)
        {
            return Success(dictService.SaveEventSortList(dataList));
        }
        [HttpGet]
        public RequestResult<List<MED_ADMINISTRATION_DICT>> GetAdminstrationDictList()
        {
            List<MED_ADMINISTRATION_DICT> result = dictService.GetAdminstrationDictList();
            return Success(result);
        }

        [HttpGet]
        public RequestResult<bool> DelEventDict(MED_EVENT_DICT data)
        {
            return Success(dictService.DelEventDict(data));
        }
        [HttpGet]
        public RequestResult<bool> DelEventExtDict(MED_EVENT_DICT_EXT data)
        {
            return Success(dictService.DelEventExtDict(data));
        }
        [HttpGet]
        public RequestResult<bool> SaveEventExtList(List<MED_EVENT_DICT_EXT> dataList)
        {
            return Success(dictService.SaveEventExtList(dataList));
        }
        [HttpGet]
        public RequestResult<bool> SaveAdministrationList(List<MED_ADMINISTRATION_DICT> dataList)
        {
            return Success(dictService.SaveAdministrationList(dataList));
        }
        [HttpGet]
        public RequestResult<bool> SaveUnitsDictList(List<MED_UNIT_DICT> dataList)
        {
            return Success(dictService.SaveUnitsDictList(dataList));
        }

        [HttpPost]
        public RequestResult<bool> UpdateConfigList(List<MED_CONFIG> dataList)
        {
            return Success(dictService.UpdateConfigList(dataList));
        }

        [HttpPost]
        public RequestResult<bool> UpdateMonitorDict(List<MED_MONITOR_DICT> monitorDict)
        {
            return Success(dictService.UpdateMonitorDict(monitorDict));
        }

        [HttpPost]
        public RequestResult<bool> UpdateOperRoomDict(List<MED_OPERATING_ROOM> operRoomDict)
        {
            return Success(dictService.UpdateOperRoomDict(operRoomDict));
        }

        [HttpPost]
        public RequestResult<int> UpdateSingleOperRoom(MED_OPERATING_ROOM operRoomDict)
        {
            return Success(dictService.UpdateSingleOperRoom(operRoomDict));
        }
    }
}