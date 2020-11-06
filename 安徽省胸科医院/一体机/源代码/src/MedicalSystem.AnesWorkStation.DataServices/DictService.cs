using MedicalSystem.AnesWorkStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MedicalSystem.DataServices.WebApi;
using Dapper.Data;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    /// <summary>
    /// 字典接口
    /// </summary>
    public interface IDictService
    {
        List<MED_ANESTHESIA_DICT> GetAnesthesiaDictList();
        List<string> GetAnesthesiaTypeDictList();
        List<MED_ANESTHESIA_INPUT_DICT> GetAnesthesiaInputDictList();
        List<MED_ANESTHESIA_INPUT_DICT> GetAnesthesiaInputDictList(string ItemClass);
        List<MED_APPLICATIONS> GetApplicationsList();
        List<MED_BILL_ITEM_CLASS_DICT> GetBillItemClassDictList();
        List<MED_BLOOD_GAS_DICT> GetBloodGasDictList();
        List<MED_CLIENT_COMPUTER> GetClientComputerList();
        List<MED_CONFIG> GetConfigList();
        List<MED_DEPT_DICT> GetDeptDictList();
        List<MED_DIAGNOSIS_DICT> GetDiagnosisDictList();
        List<MED_DOCUMENT_TEMPLET> GetDocumentTempletList();
        List<MED_EVENT_DICT> GetEventDictList();
        List<MED_EVENT_DICT> GetEventDictListByItemClass(string itemClass);
        List<MED_EVENT_DICT_EXT> GetEventDictExtList();

        List<MED_EVENT_DICT_EXT> GetEventDictExtListByEvent(string eventClassCode, string eventItemCode);
        List<MED_EVENT_ITEM_CLASS_DICT> GetEventItemClassDictClass();
        List<MED_EVENT_SORT> GetEventSortList();
        List<MED_EVENT_VS_BILL> GetEventVSBillList();
        List<MED_HIS_USERS> GetHisUsersList();
        List<MED_HIS_USERS> GetHisUsersList(string UserJob);
        List<MED_HOSP_BRANCH_DICT> GetHospBranchDictList();
        List<MED_HOSPITAL_CONFIG> GetHospitalConfigList();
        List<MED_METHOD_DICT> GetMethodDictList();
        List<MED_MONITOR_DICT> GetMonitorDictList();
        List<MED_MONITOR_DICT> GetMonitorDictListByNo(int eventNo);
        List<MED_MONITOR_DICT> GetMonitorDictListByBedNo(string bedNo);
        List<MED_MONITOR_FUNCTION_CODE> GetMonitorFuctionCodeList();
        List<MED_OPERATING_ROOM> GetOperatingRoomList();
        List<MED_OPERATING_ROOM> GetOperatingRoomListByType(string type, string deptCode);
        List<MED_OPERATING_ROOM_VS_MONITOR> GetOperatingRoomVSMonitorList();
        List<MED_OPERATION_DICT> GetOperationDictList();
        List<MED_OPERATION_STATUS_DICT> GetOperationStatusDictList();
        List<MED_OPERSCORE_DICT> GetOperscoreDictList();
        List<MED_PERIOPERATIVE_EVENT_CONFIG> GetPerioperativeEventConfigList();
        List<MED_UNIT_DICT> GetUnitDictList();
        List<MED_UNIT_DICT> GetUnitDictList(int unitType);
        List<MED_WARD_DICT> GetWardDictList();
        List<MED_ADMINISTRATION_DICT> GetAdminstrationDictList();

        List<MED_PAT_MONITOR_DATA_DICT> GetPatMonitorDict();
        List<MED_EVENT_SORT> GetEventSortList(string loginUserId);

        bool SaveEventSortList(List<MED_EVENT_SORT> dataList);

        bool DelEventDict(MED_EVENT_DICT data);
        bool DelEventExtDict(MED_EVENT_DICT_EXT data);
        bool SaveEventExtList(List<MED_EVENT_DICT_EXT> dataList);
        bool SaveAdministrationList(List<MED_ADMINISTRATION_DICT> dataList);
        bool SaveUnitsDictList(List<MED_UNIT_DICT> dataList);
        bool UpdateConfigList(List<MED_CONFIG> medConfig);
        bool UpdateMonitorDict(List<MED_MONITOR_DICT> medMonitorDict);
        bool UpdateOperRoomDict(List<MED_OPERATING_ROOM> medMonitorDict);
        int UpdateSingleOperRoom(MED_OPERATING_ROOM medMonitorDict);
    }
    /// <summary>
    /// 字典服务
    /// </summary>
    public class DictService : BaseService<DictService>, IDictService
    {
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected DictService()
            : base() { }

        public DictService(IDapperContext context)
            : base(context)
        {
        }

        /// <summary>
        /// 根据编号获取对应科室信息
        /// </summary>
        [HttpGet]
        public virtual MED_DEPT_DICT GetDeptDictByCode(string deptCode)
        {
            List<MED_DEPT_DICT> list = dapper.Set<MED_DEPT_DICT>().Select(x => x.DEPT_CODE == deptCode);
            if (list == null || list.Count == 0)
            {
                return null;
            }
            else
            {
                return list[0];
            }
        }

        /// <summary>
        /// 取科室字典表
        /// </summary>
        [HttpGet]
        public virtual List<MED_DEPT_DICT> GetDeptDictList()
        {
            List<MED_DEPT_DICT> deptList = dapper.Set<MED_DEPT_DICT>().Select();
            if (deptList != null && deptList.Count > 0)
            {
                foreach (var item in deptList)
                {
                    if (string.IsNullOrEmpty(item.INPUT_CODE))
                        item.INPUT_CODE = StringManage.GetPYString(item.DEPT_NAME);
                }
            }
            return deptList;
        }

        /// <summary>
        /// 麻醉方法字典表
        /// </summary>
        [HttpGet]
        public virtual List<MED_EVENT_DICT> GetEventDictList()
        {
            List<MED_EVENT_DICT> eventDictList = dapper.Set<MED_EVENT_DICT>().Select();
            foreach (var item in eventDictList)
            {
                item.EventNamePY = StringManage.GetPYString(item.EVENT_ITEM_NAME);
            }
            return eventDictList;
        }

        [HttpGet]
        public virtual List<MED_EVENT_DICT> GetEventDictListByItemClass(string itemClass)
        {
            return dapper.Set<MED_EVENT_DICT>().Select(x => x.EVENT_CLASS_CODE == itemClass);
        }
        /// <summary>
        /// 体征字典表
        /// </summary>
        [HttpGet]
        public virtual List<MED_MONITOR_FUNCTION_CODE> GetMonitorFuctionCodeList()
        {
            List<MED_MONITOR_FUNCTION_CODE> codeList = dapper.Set<MED_MONITOR_FUNCTION_CODE>().Select();
            foreach (var item in codeList)
            {
                item.INPUT_CODE = StringManage.GetPYString(item.ITEM_NAME);
            }
            return codeList;
        }

        /// <summary>
        /// 监护仪表
        /// </summary>
        [HttpGet]
        public virtual List<MED_MONITOR_DICT> GetMonitorDictList()
        {
            return dapper.Set<MED_MONITOR_DICT>().Select();
        }

        /// <summary>
        /// 监护仪表
        /// </summary>
        [HttpGet]
        public virtual List<MED_MONITOR_DICT> GetMonitorDictListByNo(int eventNo)
        {
            return dapper.Set<MED_MONITOR_DICT>().Select(x => x.WARD_TYPE == eventNo);
        }
        [HttpGet]
        public virtual List<MED_MONITOR_DICT> GetMonitorDictListByBedNo(string bedNo)
        {
            return dapper.Set<MED_MONITOR_DICT>().Select(x => x.BED_NO == bedNo);
        }
        /// <summary>
        /// 血气字典表
        /// </summary>
        [HttpGet]
        public virtual List<MED_BLOOD_GAS_DICT> GetBloodGasDictList()
        {
            return dapper.Set<MED_BLOOD_GAS_DICT>().Select();
        }


        /// <summary>
        /// 用药途径字典表
        /// </summary>
        [HttpGet]
        public virtual List<MED_ADMINISTRATION_DICT> GetMedAdministrationDict()
        {
            return dapper.Set<MED_ADMINISTRATION_DICT>().Select();
        }

        /// <summary>
        /// 麻醉方法字典表
        /// </summary>
        [HttpGet]
        public virtual List<MED_ANESTHESIA_DICT> GetAnesthesiaDictList()
        {
            List<MED_ANESTHESIA_DICT> dataList = dapper.Set<MED_ANESTHESIA_DICT>().Select();
            if (dataList != null && dataList.Count > 0)
            {
                foreach (var item in dataList)
                {
                    if (string.IsNullOrEmpty(item.INPUT_CODE))
                        item.INPUT_CODE = StringManage.GetPYString(item.ANAESTHESIA_CODE);
                }
            }
            return dataList;
        }

        /// <summary>
        /// 麻醉方法类型字典表
        /// </summary>
        [HttpGet]
        public virtual List<string> GetAnesthesiaTypeDictList()
        {
            List<string> resultList = new List<string>();
            List<MED_ANESTHESIA_DICT> dictList = dapper.Set<MED_ANESTHESIA_DICT>().Select();
            foreach (MED_ANESTHESIA_DICT mad in dictList)
            {
                if (!resultList.Contains(mad.ANAESTHESIA_TYPE))
                {
                    resultList.Add(mad.ANAESTHESIA_TYPE);
                }
            }
            return resultList;
        }

        /// <summary>
        /// 麻醉通用项目字典表;此表保存麻醉产品中输入项目的字典，这些输入项目直接保存次表的项目名称。
        /// </summary>
        [HttpGet]
        public virtual List<MED_ANESTHESIA_INPUT_DICT> GetAnesthesiaInputDictList()
        {
            return dapper.Set<MED_ANESTHESIA_INPUT_DICT>().Select();
        }

        /// <summary>
        /// 麻醉通用项目字典表;此表保存麻醉产品中输入项目的字典，这些输入项目直接保存次表的项目名称。
        /// </summary>
        [HttpGet]
        public virtual List<MED_ANESTHESIA_INPUT_DICT> GetAnesthesiaInputDictList(string ItemClass)
        {
            return dapper.Set<MED_ANESTHESIA_INPUT_DICT>().Select(x => x.ITEM_CLASS == ItemClass);
        }

        /// <summary>
        /// 使用程序字典表
        /// </summary>
        [HttpGet]
        public virtual List<MED_APPLICATIONS> GetApplicationsList()
        {
            return dapper.Set<MED_APPLICATIONS>().Select();
        }

        /// <summary>
        /// 收费项目分类代码表
        /// </summary>
        [HttpGet]
        public virtual List<MED_BILL_ITEM_CLASS_DICT> GetBillItemClassDictList()
        {
            List<MED_BILL_ITEM_CLASS_DICT> dataList = dapper.Set<MED_BILL_ITEM_CLASS_DICT>().Select();
            if (dataList != null && dataList.Count > 0)
            {
                foreach (var item in dataList)
                {
                    if (string.IsNullOrEmpty(item.INPUT_CODE))
                        item.INPUT_CODE = StringManage.GetPYString(item.BILL_CLASS_NAME);
                }
            }
            return dataList;
        }

        /// <summary>
        /// 实体 协同终端列表;手术间协同终端列表，保存各个终端的IP，实现点对点通讯
        /// </summary>
        [HttpGet]
        public virtual List<MED_CLIENT_COMPUTER> GetClientComputerList()
        {
            return dapper.Set<MED_CLIENT_COMPUTER>().Select();
        }

        /// <summary>
        /// 配置字典
        /// </summary>
        [HttpGet]
        public virtual List<MED_CONFIG> GetConfigList()
        {
            return dapper.Set<MED_CONFIG>().Select();
        }

        /// <summary>
        /// 诊断字典
        /// </summary>
        [HttpGet]
        public virtual List<MED_DIAGNOSIS_DICT> GetDiagnosisDictList()
        {
            List<MED_DIAGNOSIS_DICT> dataList = dapper.Set<MED_DIAGNOSIS_DICT>().Select();
            if (dataList != null && dataList.Count > 0)
            {
                foreach (var item in dataList)
                {
                    if (string.IsNullOrEmpty(item.INPUT_CODE))
                        item.INPUT_CODE = StringManage.GetPYString(item.DIAGNOSIS_NAME);
                }
            }
            return dataList;
        }

        /// <summary>
        /// 文书模板字典
        /// </summary>
        [HttpGet]
        public virtual List<MED_DOCUMENT_TEMPLET> GetDocumentTempletList()
        {
            return dapper.Set<MED_DOCUMENT_TEMPLET>().Select();
        }

        /// <summary>
        /// 麻醉事件字典自定义扩展表
        /// </summary>
        [HttpGet]
        public virtual List<MED_EVENT_DICT_EXT> GetEventDictExtList()
        {
            return dapper.Set<MED_EVENT_DICT_EXT>().Select();
        }

        /// <summary>
        /// 根据指定项目获取麻醉事件字典自定义扩展表
        /// </summary>
        [HttpGet]
        public virtual List<MED_EVENT_DICT_EXT> GetEventDictExtListByEvent(string eventClassCode, string eventItemCode)
        {
            return dapper.Set<MED_EVENT_DICT_EXT>().Select(x => x.EVENT_CLASS_CODE == eventClassCode && x.EVENT_ITEM_CODE == eventItemCode);
        }

        /// <summary>
        /// 事件类型字典表
        /// </summary>
        [HttpGet]
        public virtual List<MED_EVENT_ITEM_CLASS_DICT> GetEventItemClassDictClass()
        {
            return dapper.Set<MED_EVENT_ITEM_CLASS_DICT>().Select().OrderBy(d => d.EVENT_CLASS_CODE).ToList();
        }

        /// <summary>
        /// 麻醉事件使用频率排序表
        /// </summary>
        [HttpGet]
        public virtual List<MED_EVENT_SORT> GetEventSortList()
        {
            return dapper.Set<MED_EVENT_SORT>().Select();
        }

        /// <summary>
        /// 麻醉事件使用频率排序表
        /// </summary>
        [HttpPost]
        public virtual bool SaveEventSortList(List<MED_EVENT_SORT> dataList)
        {
            bool flag = UpdateWholeList(dataList);
            dapper.SaveChanges();
            return flag;
        }

        /// <summary>
        /// 麻醉事件收费对照表
        /// </summary>
        [HttpGet]
        public virtual List<MED_EVENT_VS_BILL> GetEventVSBillList()
        {
            return dapper.Set<MED_EVENT_VS_BILL>().Select();
        }

        /// <summary>
        /// 用户信息表
        /// </summary>
        [HttpGet]
        public virtual List<MED_HIS_USERS> GetHisUsersList()
        {
            List<MED_HIS_USERS> dataList = dapper.Set<MED_HIS_USERS>().Select();
            if (dataList != null && dataList.Count > 0)
            {
                foreach (var item in dataList)
                {
                    if (string.IsNullOrEmpty(item.INPUT_CODE))
                        item.INPUT_CODE = StringManage.GetPYString(item.USER_NAME);
                }
            }
            return dataList;
        }
        /// <summary>
        /// 用户信息表
        /// </summary>
        [HttpGet]
        public virtual List<MED_HIS_USERS> GetHisUsersList(string UserJob)
        {
            List<MED_HIS_USERS> dataList = dapper.Set<MED_HIS_USERS>().Select(x => x.USER_JOB == UserJob);
            if (dataList != null && dataList.Count > 0)
            {
                foreach (var item in dataList)
                {
                    if (string.IsNullOrEmpty(item.INPUT_CODE))
                        item.INPUT_CODE = StringManage.GetPYString(item.USER_NAME);
                }
            }
            return dataList;
        }

        /// <summary>
        /// 院区字典表
        /// </summary>
        [HttpGet]
        public virtual List<MED_HOSP_BRANCH_DICT> GetHospBranchDictList()
        {
            return dapper.Set<MED_HOSP_BRANCH_DICT>().Select();
        }

        /// <summary>
        /// 医院信息配置表
        /// </summary>
        [HttpGet]
        public virtual List<MED_HOSPITAL_CONFIG> GetHospitalConfigList()
        {
            return dapper.Set<MED_HOSPITAL_CONFIG>().Select();
        }

        /// <summary>
        /// 给药方式字典
        /// </summary>
        [HttpGet]
        public virtual List<MED_METHOD_DICT> GetMethodDictList()
        {
            return dapper.Set<MED_METHOD_DICT>().Select();
        }

        /// 手术间字典表
        /// </summary>
        [HttpGet]
        /// <summary>
        public virtual List<MED_OPERATING_ROOM> GetOperatingRoomList()
        {
            return dapper.Set<MED_OPERATING_ROOM>().Select();
        }

        /// <summary>
        /// 手术间字典表
        /// </summary>
        [HttpGet]
        public virtual List<MED_OPERATING_ROOM> GetOperatingRoomListByType(string type, string deptCode)
        {
            return dapper.Set<MED_OPERATING_ROOM>().Select(x => x.BED_TYPE == type && x.DEPT_CODE == deptCode);
        }
        /// <summary>
        /// 手术间默认仪器对应表
        /// </summary>
        [HttpGet]
        public virtual List<MED_OPERATING_ROOM_VS_MONITOR> GetOperatingRoomVSMonitorList()
        {
            return dapper.Set<MED_OPERATING_ROOM_VS_MONITOR>().Select();
        }

        /// <summary>
        /// 手术信息字典表
        /// </summary>
        [HttpGet]
        public virtual List<MED_OPERATION_DICT> GetOperationDictList()
        {
            List<MED_OPERATION_DICT> dataList = dapper.Set<MED_OPERATION_DICT>().Select();
            if (dataList != null && dataList.Count > 0)
            {
                foreach (var item in dataList)
                {
                    if (string.IsNullOrEmpty(item.INPUT_CODE))
                        item.INPUT_CODE = StringManage.GetPYString(item.OPER_NAME);
                }
            }
            return dataList;
        }

        /// <summary>
        /// 手术状态字典表
        /// </summary>
        [HttpGet]
        public virtual List<MED_OPERATION_STATUS_DICT> GetOperationStatusDictList()
        {
            return dapper.Set<MED_OPERATION_STATUS_DICT>().Select();
        }

        /// <summary>
        /// 手术分值字典
        /// </summary>
        [HttpGet]
        public virtual List<MED_OPERSCORE_DICT> GetOperscoreDictList()
        {
            return dapper.Set<MED_OPERSCORE_DICT>().Select();
        }

        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public virtual List<MED_PERIOPERATIVE_EVENT_CONFIG> GetPerioperativeEventConfigList()
        {
            return dapper.Set<MED_PERIOPERATIVE_EVENT_CONFIG>().Select();
        }

        /// <summary>
        /// 单位字典
        /// </summary>
        [HttpGet]
        public virtual List<MED_UNIT_DICT> GetUnitDictList()
        {
            return dapper.Set<MED_UNIT_DICT>().Select();
        }

        /// <summary>
        /// 根据单位类型获取单位字典
        /// </summary>
        [HttpGet]
        public virtual List<MED_UNIT_DICT> GetUnitDictList(int unitType)
        {
            return dapper.Set<MED_UNIT_DICT>().Select(x => x.UNIT_TYPE == unitType);
        }

        /// <summary>
        /// 病区字典
        /// </summary>
        [HttpGet]
        public virtual List<MED_WARD_DICT> GetWardDictList()
        {
            return dapper.Set<MED_WARD_DICT>().Select();
        }

        /// <summary>
        /// 报警个性化配置字典
        /// </summary>
        [HttpGet]
        public virtual List<MED_PAT_MONITOR_DATA_DICT> GetPatMonitorDict()
        {
            return dapper.Set<MED_PAT_MONITOR_DATA_DICT>().Select();
        }
        /// <summary>
        ///  给药途径代码表
        /// </summary>
        [HttpGet]
        public virtual List<MED_ADMINISTRATION_DICT> GetAdminstrationDictList()
        {
            return dapper.Set<MED_ADMINISTRATION_DICT>().Select();
        }
        /// <summary>
        /// 获取麻醉事件排序字典表
        /// </summary>
        /// <param name="loginUserId"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual List<MED_EVENT_SORT> GetEventSortList(string loginUserId)
        {
            List<MED_EVENT_SORT> dataList = dapper.Set<MED_EVENT_SORT>().Select(
            x => x.USER_ID == loginUserId).ToList();
            return dataList;
        }
        [HttpPost]
        public virtual bool DelEventDict(MED_EVENT_DICT data)
        {
            bool flag = dapper.Set<MED_EVENT_DICT>().Delete(data);
            dapper.SaveChanges();
            return flag;
        }
        [HttpPost]
        public virtual bool DelEventExtDict(MED_EVENT_DICT_EXT data)
        {
            bool flag = dapper.Set<MED_EVENT_DICT_EXT>().Delete(data);
            dapper.SaveChanges();
            return flag;
        }



        [HttpPost]
        public virtual bool SaveEventExtList(List<MED_EVENT_DICT_EXT> dataList)
        {
            bool flag = UpdateWholeList(dataList);
            dapper.SaveChanges();
            return flag;
        }
        [HttpPost]
        public virtual bool SaveAdministrationList(List<MED_ADMINISTRATION_DICT> dataList)
        {
            bool flag = UpdateWholeList(dataList);
            dapper.SaveChanges();
            return flag;
        }

        [HttpPost]
        public virtual bool SaveUnitsDictList(List<MED_UNIT_DICT> dataList)
        {
            bool flag = UpdateWholeList(dataList);
            dapper.SaveChanges();
            return flag;
        }

        [HttpPost]
        public virtual bool UpdateConfigList(List<MED_CONFIG> dataList)
        {
            bool flag = UpdateWholeList(dataList);
            dapper.SaveChanges();
            return flag;
        }


        /// <summary>
        /// 更新监护仪字典表
        /// </summary>
        /// <param name="anesPlanRow"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual bool UpdateMonitorDict(List<MED_MONITOR_DICT> monitorDict)
        {
            bool flag = UpdateWholeList(monitorDict);
            dapper.SaveChanges();
            return flag;
        }

        /// <summary>
        /// 更新手术间字典表
        /// </summary>
        /// <param name="anesPlanRow"></param>
        /// <returns></returns>
        [HttpPost]
        public virtual bool UpdateOperRoomDict(List<MED_OPERATING_ROOM> operRoomDict)
        {
            bool flag = UpdateWholeList(operRoomDict);
            dapper.SaveChanges();
            return flag;
        }

        /// <summary>
        /// 更新手术间字典表
        /// </summary>
        [HttpPost]
        public virtual int UpdateSingleOperRoom(MED_OPERATING_ROOM sigleOperRoom)
        {
            int flag = dapper.Set<MED_OPERATING_ROOM>().Update(sigleOperRoom);
            dapper.SaveChanges();
            return flag;
        }
    }
}
