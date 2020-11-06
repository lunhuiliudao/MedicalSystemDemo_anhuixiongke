
using MedicalSystem.AnesPlatform.Service.WebApi.App_Start.Swagger;
using MedicalSystem.AnesWorkStation.DataServices;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Domain.Origins;
using MedicalSystem.AnesWorkStation.Domain.Report;
using MedicalSystem.AnesWorkStation.Domain.RequestResult;
using MedicalSystem.Common.FileManage;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.Http;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers.Platform
{
    /// <summary>
    /// 系统管理
    /// </summary>
    [ControllerGroup("系统管理", "接口")]
    public class PlatformSysConfigController : PlatformBaseController
    {
        IPlatformSysConfigServices sysConfig;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sysConfigParam"></param>
        public PlatformSysConfigController(IPlatformSysConfigServices sysConfigParam)
        {
            sysConfig = sysConfigParam;
        }
        #region 基础数据管理
        #region 科室字典维护
        /// <summary>
        /// 获取科室字典列表
        /// </summary>
        /// <param name="DeptName">科室名称</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="CurrentPage">当前页码</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<dynamic> GetMedDeptDict(string DeptName, int PageSize = 20, int CurrentPage = 1)
        {
            IList<MED_DEPT_DICT> MedDeptDictList = sysConfig.GetMedDeptDict(DeptName);
            dynamic dynamicInfo = new { Total = MedDeptDictList.Count, CurrentData = MedDeptDictList.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList() };
            return Success<dynamic>(dynamicInfo);
        }

        /// <summary>
        /// 编辑科室字典数据
        /// </summary>
        /// <param name="type">0:新增 1:修改</param>
        /// <param name="MedDeptDict">科室对象</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> EditMedDeptDict(int type, MED_DEPT_DICT MedDeptDict)
        {
            return Success(sysConfig.EditMedDeptDict(type, MedDeptDict));
        }

        /// <summary>
        /// 删除科室字典数据
        /// </summary>
        /// <param name="MedDeptDictList">科室对象列表</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> DeletedMedDeptDict(List<MED_DEPT_DICT> MedDeptDictList)
        {
            return Success(sysConfig.DeletedMedDeptDict(MedDeptDictList));
        }
        #endregion

        #region 人员字典维护
        /// <summary>
        /// 获取人员字典列表
        /// </summary>
        /// <param name="HisUserName">人员名称</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="CurrentPage">当前页码</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<dynamic> GetMedHisUserDict(string HisUserName, int PageSize = 20, int CurrentPage = 1)
        {
            IList<MED_HIS_USERS> MedHisUserDict = sysConfig.GetMedHisUserDict(HisUserName);
            dynamic dynamicInfo = new { Total = MedHisUserDict.Count, CurrentData = MedHisUserDict.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList() };
            return Success<dynamic>(dynamicInfo);
        }
        /// <summary>
        /// 获取人员字典列表
        /// </summary>
        /// <param name="HisUserName">人员名称</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="CurrentPage">当前页码</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<dynamic> GetMedHisUserDict(string HisUserName,string DeptName,int UserStatus = 1, int PageSize = 20, int CurrentPage = 1)
        {
            IList<MED_HIS_USERS> MedHisUserDict = sysConfig.GetMedHisUserDict(HisUserName, DeptName, UserStatus);
            dynamic dynamicInfo = new { Total = MedHisUserDict.Count, CurrentData = MedHisUserDict.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList() };
            return Success<dynamic>(dynamicInfo);
        }

        /// <summary>
        /// 编辑人员字典数据
        /// </summary>
        /// <param name="type">0:新增 1:修改</param>
        /// <param name="MedHisUserDict">人员对象</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> EditMedHisUserDict(int type, MED_HIS_USERS MedHisUserDict)
        {
            return Success(sysConfig.EditMedHisUserDict(type, MedHisUserDict));
        }

        /// <summary>
        /// 删除人员字典数据
        /// </summary>
        /// <param name="MedHisUserDict">人员列表</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> DeletedMedHisUserDict(List<MED_HIS_USERS> MedHisUserDict)
        {
            return Success(sysConfig.DeletedMedHisUserDict(MedHisUserDict));
        }
        #endregion

        #region 手术名称字典维护
        /// <summary>
        /// 获取手术字典列表
        /// </summary>
        /// <param name="OperationName">手术名称</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="CurrentPage">当前页码</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<dynamic> GetOperationDict(string OperationName, int PageSize = 20, int CurrentPage = 1)
        {
            IList<MED_OPERATION_DICT> OperationDict = sysConfig.GetOperationDict(OperationName);
            dynamic dynamicInfo = new { Total = OperationDict.Count, CurrentData = OperationDict.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList() };
            return Success<dynamic>(dynamicInfo);
        }

        /// <summary>
        /// 编辑手术字典数据
        /// </summary>
        /// <param name="type">0:新增 1:修改</param>
        /// <param name="OperationDict">手术对象</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> EditOperationDict(int type, MED_OPERATION_DICT OperationDict)
        {
            return Success(sysConfig.EditOperationDict(type, OperationDict));
        }

        /// <summary>
        /// 删除手术字典数据
        /// </summary>
        /// <param name="OperationDict">手术列表</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> DeletedOperationDict(List<MED_OPERATION_DICT> OperationDict)
        {
            return Success(sysConfig.DeletedOperationDict(OperationDict));
        }
        #endregion

        #region 诊断字典维护
        /// <summary>
        /// 诊断字典维护
        /// </summary>
        /// <param name="DiagnosisName">诊断名称</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="CurrentPage">当前页码</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<dynamic> GetDiagnosisDict(string DiagnosisName, int PageSize = 20, int CurrentPage = 1)
        {
            IList<MED_DIAGNOSIS_DICT> OperationDict = sysConfig.GetDiagnosisDict(DiagnosisName);
            dynamic dynamicInfo = new { Total = OperationDict.Count, CurrentData = OperationDict.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList() };
            return Success<dynamic>(dynamicInfo);
        }
        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="type">0:新增 1:修改</param>
        /// <param name="DiagnosisDict">对象</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> EditDiagnosisDict(int type, MED_DIAGNOSIS_DICT DiagnosisDict)
        {
            return Success(sysConfig.EditDiagnosisDict(type, DiagnosisDict));
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="DiagnosisDict">对象</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> DeletedDiagnosisDict(List<MED_DIAGNOSIS_DICT> DiagnosisDict)
        {
            return Success(sysConfig.DeletedDiagnosisDict(DiagnosisDict));
        }

        #endregion

        #region 常用术语维护
        /// <summary>
        /// 获取常用术语类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<dynamic> GetAnesInputDictItemClassList()
        {
            IList<string> ItemClassList = sysConfig.GetAnesInputDictItemClassList();
            return Success<dynamic>(ItemClassList);
        }

        /// <summary>
        /// 获取常用术语类型
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<IList<MED_ANESTHESIA_INPUT_DICT>> GetAnesInputDictByItemClassNoPage(string ItemClass)
        {
            IList<MED_ANESTHESIA_INPUT_DICT> ItemClassList = sysConfig.GetAnesInputDictByItemClass(ItemClass);
            return Success<IList<MED_ANESTHESIA_INPUT_DICT>>(ItemClassList);
        }

        /// <summary>
        /// 获取麻醉通用项目字典表
        /// </summary>
        /// <param name="ItemClass"></param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="CurrentPage">当前页码</param>
        /// <returns></returns>
        public RequestResult<dynamic> GetAnesInputDictByItemClass(string ItemClass, int PageSize = 20, int CurrentPage = 1)
        {
            IList<MED_ANESTHESIA_INPUT_DICT> MedAnesInputDict = sysConfig.GetAnesInputDictByItemClass(ItemClass);
            dynamic dynamicInfo = new { Total = MedAnesInputDict.Count, CurrentData = MedAnesInputDict.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList() };
            return Success<dynamic>(dynamicInfo);
        }
        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="type">0:新增 1:修改</param>
        /// <param name="AnesInputDict">对象</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> EditAnesInputDict(int type, MED_ANESTHESIA_INPUT_DICT AnesInputDict)
        {
            return Success(sysConfig.EditAnesInputDict(type, AnesInputDict));
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="AnesInputDict">对象</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> DeletedAnesInputDict(List<MED_ANESTHESIA_INPUT_DICT> AnesInputDict)
        {
            return Success(sysConfig.DeletedAnesInputDict(AnesInputDict));
        }
        #endregion

        #region 给药途径字典维护
        /// <summary>
        /// 给药途径字典维护
        /// </summary>
        /// <param name="Administration">途径名称</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="CurrentPage">当前页码</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<dynamic> GetAdministrationDict(string Administration, int PageSize = 20, int CurrentPage = 1)
        {
            IList<MED_ADMINISTRATION_DICT> AdministrationDict = sysConfig.GetAdministrationDict(Administration);
            dynamic dynamicInfo = new { Total = AdministrationDict.Count, CurrentData = AdministrationDict.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList() };
            return Success<dynamic>(dynamicInfo);
        }
        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="type">0:新增 1:修改</param>
        /// <param name="AdministrationDict">对象</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> EditAdministrationDict(int type, MED_ADMINISTRATION_DICT AdministrationDict)
        {
            return Success(sysConfig.EditAdministrationDict(type, AdministrationDict));
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="AdministrationDict"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> DeletedAdministrationDict(List<MED_ADMINISTRATION_DICT> AdministrationDict)
        {
            return Success(sysConfig.DeletedAdministrationDict(AdministrationDict));
        }

        #endregion

        #region 麻醉方法字典维护
        /// <summary>
        /// 麻醉方法字典维护
        /// </summary>
        /// <param name="AnesMethodName">麻醉方法名称</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="CurrentPage">当前页码</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<dynamic> GetAnesthesiaDict(string AnesMethodName, int PageSize = 20, int CurrentPage = 1)
        {
            IList<MED_ANESTHESIA_DICT> AnesthesiaDict = sysConfig.GetAnesthesiaDict(AnesMethodName);
            dynamic dynamicInfo = new { Total = AnesthesiaDict.Count, CurrentData = AnesthesiaDict.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList() };
            return Success<dynamic>(dynamicInfo);
        }
        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="type">0:新增 1:修改</param>
        /// <param name="AnesthesiaDict">对象</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> EditAnesthesiaDict(int type, MED_ANESTHESIA_DICT AnesthesiaDict)
        {
            return Success(sysConfig.EditAnesthesiaDict(type, AnesthesiaDict));
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="AnesthesiaDict"></param>
        /// <returns>对象</returns>
        [HttpPost]
        public RequestResult<int> DeletedAnesthesiaDict(List<MED_ANESTHESIA_DICT> AnesthesiaDict)
        {
            return Success(sysConfig.DeletedAnesthesiaDict(AnesthesiaDict));
        }
        #endregion

        #region 手术间字典维护

        /// <summary>
        /// 手术间字典维护
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<IList<MED_OPERATING_ROOM>> GetOperatingRoomListAll()
        {
            IList<MED_OPERATING_ROOM> OperatingRoomList = sysConfig.GetOperatingRoomListAll();
            return Success<IList<MED_OPERATING_ROOM>>(OperatingRoomList);
        }

        /// <summary>
        /// 手术间字典维护
        /// </summary>
        /// <param name="OperatingRoomNo">手术间号</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<IList<MED_OPERATING_ROOM>> GetOperatingRoomListNoPage(string OperatingRoomNo)
        {
            IList<MED_OPERATING_ROOM> OperatingRoomList = sysConfig.GetOperatingRoomList(OperatingRoomNo);
            return Success<IList<MED_OPERATING_ROOM>>(OperatingRoomList);
        }

        /// <summary>
        /// 手术间字典维护
        /// </summary>
        /// <param name="OperatingRoomNo">手术间号</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="CurrentPage">当前页码</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<dynamic> GetOperatingRoomList(string OperatingRoomNo, int PageSize = 20, int CurrentPage = 1)
        {
            IList<MED_OPERATING_ROOM> OperatingRoomList = sysConfig.GetOperatingRoomList(OperatingRoomNo);
            dynamic dynamicInfo = new { Total = OperatingRoomList.Count, CurrentData = OperatingRoomList.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList() };
            return Success<dynamic>(dynamicInfo);
        }
        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="type">0:新增 1:修改</param>
        /// <param name="OperatingRoomList">对象</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> EditOperatingRoomList(int type, MED_OPERATING_ROOM OperatingRoomList)
        {
            return Success(sysConfig.EditOperatingRoomList(type, OperatingRoomList));
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="OperatingRoomList">对象</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> DeletedOperatingRoomList(List<MED_OPERATING_ROOM> OperatingRoomList)
        {
            return Success(sysConfig.DeletedOperatingRoomList(OperatingRoomList));
        }
        #endregion

        #region 采集仪器字典维护

        /// <summary>
        /// 采集仪器字典维护
        /// </summary>
        /// <param name="MonitorName">名称</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<IList<MED_MONITOR_DICT>> GetMonitorDict()
        {
            IList<MED_MONITOR_DICT> MonitorDictList = sysConfig.GetMonitorDict();
            return Success<IList<MED_MONITOR_DICT>>(MonitorDictList);
        }

        /// <summary>
        /// 采集仪器字典维护
        /// </summary>
        /// <param name="MonitorName">名称</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<IList<MED_MONITOR_DICT>> GetMonitorDictNoPage(string MonitorName)
        {
            IList<MED_MONITOR_DICT> MonitorDictList = sysConfig.GetMonitorDict(MonitorName);
            return Success<IList<MED_MONITOR_DICT>>(MonitorDictList);
        }

        /// <summary>
        /// 采集仪器字典维护
        /// </summary>
        /// <param name="MonitorName">名称</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="CurrentPage">当前页码</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<dynamic> GetMonitorDict(string MonitorName, int PageSize = 20, int CurrentPage = 1)
        {
            IList<MED_MONITOR_DICT> OperatingRoomList = sysConfig.GetMonitorDict(MonitorName);
            dynamic dynamicInfo = new { Total = OperatingRoomList.Count, CurrentData = OperatingRoomList.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList() };
            return Success<dynamic>(dynamicInfo);
        }
        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="type">0:新增 1:修改</param>
        /// <param name="MonitorDict">对象</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> EditMonitorDict(int type, MED_MONITOR_DICT MonitorDict)
        {
            return Success(sysConfig.EditMonitorDict(type, MonitorDict));
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="MonitorDict">对象</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> DeletedMonitorDict(List<MED_MONITOR_DICT> MonitorDict)
        {
            return Success(sysConfig.DeletedMonitorDict(MonitorDict));
        }
        #endregion

        #region 单位字典维护
        /// <summary>
        /// 单位字典维护
        /// </summary>
        /// <param name="UnitType">类型</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="CurrentPage">当前页码</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<dynamic> GetUnitDict(string UnitType, int PageSize = 20, int CurrentPage = 1)
        {
            IList<MED_UNIT_DICT> UnitDict = sysConfig.GetUnitDict(UnitType);

            dynamic dynamicInfo = new { Total = UnitDict.Count, CurrentData = UnitDict.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList() };
            return Success<dynamic>(dynamicInfo);
        }
        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="type">0:新增 1:修改</param>
        /// <param name="UnitDict">对象</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> EditUnitDict(int type, MED_UNIT_DICT UnitDict)
        {
            return Success(sysConfig.EditUnitDict(type, UnitDict));
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="UnitDict">对象</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> DeletedUnitDict(List<MED_UNIT_DICT> UnitDict)
        {
            return Success(sysConfig.DeletedUnitDict(UnitDict));
        }
        #endregion

        #region 采集项目维护

        /// <summary>
        /// 采集项目维护
        /// </summary>
        /// <param name="ItemName">名称</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<IList<MED_MONITOR_FUNCTION_CODE>> GetMonitorFunctionCodeNoPage(string ItemName)
        {
            IList<MED_MONITOR_FUNCTION_CODE> MonitorFunctionCodeList = sysConfig.GetMonitorFunctionCode(ItemName);
            return Success<IList<MED_MONITOR_FUNCTION_CODE>>(MonitorFunctionCodeList);
        }

        /// <summary>
        /// 采集项目维护
        /// </summary>
        /// <param name="ItemName">名称</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="CurrentPage">当前页码</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<dynamic> GetMonitorFunctionCode(string ItemName, int PageSize = 20, int CurrentPage = 1)
        {
            IList<MED_MONITOR_FUNCTION_CODE> MonitorFunctionCodeList = sysConfig.GetMonitorFunctionCode(ItemName);
            dynamic dynamicInfo = new { Total = MonitorFunctionCodeList.Count, CurrentData = MonitorFunctionCodeList.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList() };
            return Success<dynamic>(dynamicInfo);
        }
        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="type">0:新增 1:修改</param>
        /// <param name="MonitorFunctionCodeList">对象</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> EditMonitorFunctionCodeList(int type, MED_MONITOR_FUNCTION_CODE MonitorFunctionCodeList)
        {
            return Success(sysConfig.EditMonitorFunctionCodeList(type, MonitorFunctionCodeList));
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="MonitorFunctionCodeList"></param>
        /// <returns>对象</returns>
        [HttpPost]
        public RequestResult<int> DeletedMonitorFunctionCodeList(List<MED_MONITOR_FUNCTION_CODE> MonitorFunctionCodeList)
        {
            return Success(sysConfig.DeletedMonitorFunctionCodeList(MonitorFunctionCodeList));
        }
        #endregion
        #endregion

        #region 术中用药管理
        #region 麻醉事件

        /// <summary>
        /// 获取麻醉事件列表
        /// </summary>
        /// <param name="itemClass">类型</param>
        /// <param name="itemName">名称</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<IList<MED_EVENT_DICT>> GetMedEventDictNoPage(string itemClass, string itemName)
        {
            IList<MED_EVENT_DICT> MedEventDictList = sysConfig.GetMedEventDict(itemClass, itemName);
            return Success<IList<MED_EVENT_DICT>>(MedEventDictList);
        }

        /// <summary>
        /// 获取麻醉事件列表
        /// </summary>
        /// <param name="itemClass">类型</param>
        /// <param name="itemName">名称</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="CurrentPage">当前页码</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<dynamic> GetMedEventDict(string itemClass, string itemName, int PageSize = 20, int CurrentPage = 1)
        {
            IList<MED_EVENT_DICT> MedEventDictList = sysConfig.GetMedEventDict(itemClass, itemName);
            dynamic dynamicInfo = new { Total = MedEventDictList.Count, CurrentData = MedEventDictList.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList() };
            return Success<dynamic>(dynamicInfo);
        }
        /// <summary>
        /// 获取麻醉事件列表
        /// </summary>
        /// <param name="itemClass">类型</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<IList<MED_EVENT_DICT>> GetMedEventDict(string itemClass)
        {
            return Success(sysConfig.GetMedEventDict(itemClass));
        }
        /// <summary>
        /// 新建麻醉事件
        /// </summary>
        /// <param name="itemClass">类型</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<MED_EVENT_DICT> NewMedEventDict(string itemClass)
        {
            return Success(sysConfig.NewMedEventDict(itemClass));
        }
        /// <summary>
        /// 编辑麻醉事件
        /// </summary>
        /// <param name="type">0:新增 1:修改</param>
        /// <param name="MedEventDict">麻醉事件对象</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> EditMedEventDict(int type, MED_EVENT_DICT MedEventDict)
        {
            return Success(sysConfig.EditMedEventDict(type, MedEventDict));
        }
        /// <summary>
        /// 删除麻醉事件
        /// </summary>
        /// <param name="MedEventDict">麻醉事件列表</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> DeletedMedEventDict(List<MED_EVENT_DICT> MedEventDict)
        {
            return Success(sysConfig.DeletedMedEventDict(MedEventDict));
        }
        #endregion

        #region 麻醉事件定义扩展
        /// <summary>
        /// 获取麻醉事件定义扩展列表
        /// </summary>
        /// <param name="itemClass">事件类别</param>
        /// <param name="itemCode">事件代码</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="CurrentPage">当前页码</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<dynamic> GetMedEventDictExt(string itemClass, string itemCode, int PageSize = 20, int CurrentPage = 1)
        {
            IList<MED_EVENT_DICT_EXT> MedEventDictList = sysConfig.GetMedEventDictExt(itemClass, itemCode);
            dynamic dynamicInfo = new { Total = MedEventDictList.Count, CurrentData = MedEventDictList.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList() };
            return Success<dynamic>(dynamicInfo);
        }
        /// <summary>
        /// 新建麻醉事件定义扩展
        /// </summary>
        /// <param name="itemClass">类别</param>
        /// <param name="itemCode">代码</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<MED_EVENT_DICT_EXT> NewMedEventExtDict(string itemClass, string itemCode)
        {
            return Success(sysConfig.NewMedEventExtDict(itemClass, itemCode));
        }
        /// <summary>
        /// 编辑麻醉事件定义扩展
        /// </summary>
        /// <param name="type">0:新增 1:修改</param>
        /// <param name="medEventExtDict">麻醉事件定义扩展对象</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> EditMedEventExtDict(int type, MED_EVENT_DICT_EXT medEventExtDict)
        {
            return Success(sysConfig.EditMedEventExtDict(type, medEventExtDict));
        }
        /// <summary>
        /// 删除麻醉事件定义扩展
        /// </summary>
        /// <param name="medEventExtDictList">麻醉事件定义扩展列表</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> DeletedMedEventExtDict(List<MED_EVENT_DICT_EXT> medEventExtDictList)
        {
            return Success(sysConfig.DeletedMedEventExtDict(medEventExtDictList));
        }
        #endregion
        #endregion

        #region 其他配置
        #region 统计配置
        /// <summary>
        /// 保存统计配置文件
        /// </summary>
        /// <param name="reportInfo"></param>
        /// <returns></returns>
        public RequestResult<string> SaveReportInformation(ReportInformation reportInfo)
        {
            string message = string.Empty;
            try
            {
                string directoryName = string.Concat(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Config\\ReportData\\");
                if (!Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }
                List<ReportInformation> result = new List<ReportInformation>();
                //模板名称保存时默认加上模板所在的路径，保存全路径，方便模板导出时通过路径找到模板
                if (!string.IsNullOrEmpty(reportInfo.ReportTitle.ModelFileName))
                {
                    reportInfo.ReportTitle.ModelFileName = "\\Config\\ExcelModel\\AnesQueryExcelModel\\" + reportInfo.ReportTitle.ModelFileName;
                }
                else
                {
                    reportInfo.ReportTitle.ModelFileName = "";
                }
                result.Add(reportInfo);
                DataSet dts = XmlHelper.IListToDataSet(result);
                string filePath = directoryName + reportInfo.ReportTitle.ReportName + ".xml";
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                XMLFileHelper.ConvertDataSetToXMLFile(dts, filePath);
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return Success(message);
        }
        #endregion

        #region 麻醉方法归类配置
        /// <summary>
        /// 获取麻醉自定义字典
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<string> GetAnesMethodClass()
        {
            return Success(sysConfig.GetAnesMethodClass());
        }
        /// <summary>
        /// 获取未被麻醉自定义字典使用的麻醉名称
        /// </summary>
        /// <param name="ITEM_PARENTID">父ID</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<List<string>> GetAnesMethodOptions(int ITEM_PARENTID)
        {
            return Success(sysConfig.GetAnesMethodOptions(ITEM_PARENTID));
        }
        /// <summary>
        /// 麻醉自定义字典添加数据
        /// </summary>
        /// <param name="item">对象</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<string> AddAnesMethodClass(MED_ANESTHESIA_CONFIG item)
        {
            return Success(sysConfig.AddAnesMethodClass(item));
        }
        /// <summary>
        /// 麻醉自定义字典删除数据
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<string> DeletedAnesMethodClass(int id)
        {
            return Success(sysConfig.DeletedAnesMethodClass(id));
        }
        #endregion

        #region 文书导航
        /// <summary>
        /// 获取文书导航配置
        /// </summary>
        /// <param name="key">手术状态key  文书： 1术前  2术中 3术后   功能： 4术前 5术中 6术后</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<string[]> GetMedConfig(string key)
        {
            string keyStr = "";
            switch (key)
            {
                case "1":
                    keyStr = "SignleBottomMenuControlListBeforeOperation";
                    break;
                case "2":
                    keyStr = "SignleBottomMenuControlListInOperation";
                    break;
                case "3":
                    keyStr = "SignleBottomMenuControlListAfterOperation";
                    break;
                case "4":
                    keyStr = "BottomMenuFunctionListBeforeOperation";
                    break;
                case "5":
                    keyStr = "BottomMenuFunctionListInOperation";
                    break;
                case "6":
                    keyStr = "BottomMenuFunctionListAfterOperation";
                    break;

            }

            string[] medconfig = sysConfig.GetFromConfigTable(keyStr).Split(',');
            return Success<string[]>(medconfig);
        }
        /// <summary>
        /// 编辑文书导航配置
        /// </summary>
        /// <param name="config">手术状态对应文书字符串</param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> ModifyConfigTable(MED_CONFIGPara config)
        {
            string key = "";
            switch (config.KeyStr)
            {
                case "1":
                    key = "SignleBottomMenuControlListBeforeOperation";
                    break;
                case "2":
                    key = "SignleBottomMenuControlListInOperation";
                    break;
                case "3":
                    key = "SignleBottomMenuControlListAfterOperation";
                    break;
                case "4":
                    key = "BottomMenuFunctionListBeforeOperation";
                    break;
                case "5":
                    key = "BottomMenuFunctionListInOperation";
                    break;
                case "6":
                    key = "BottomMenuFunctionListAfterOperation";
                    break;
            }
            string values = "";
            foreach (var item in config.ValueStr)
            {
                if (item != "")
                {
                    values += item + ",";
                }
            }
            if (values != "")
            {
                values = values.Substring(0, values.Length - 1);
            }
            return Success(sysConfig.ModifyConfigTable(key, values));
        }


        /// <summary>
        /// 获取一体机配置项
        /// </summary>
        /// <returns></returns>
        public RequestResult<dynamic> GetMedConfigSet()
        {
            MED_CONFIGSET medconfig = sysConfig.GetMedConfigSet();
            return Success<dynamic>(medconfig);
        }

        /// <summary>
        /// 获取一体机配置项
        /// </summary>
        /// <returns></returns>
        public RequestResult<dynamic> ModifyMedConfigSet(MED_CONFIGSET medconfig)
        {

            return Success<dynamic>(sysConfig.ModifyMedConfigSet(medconfig));
        }

        /// <summary>
        /// 查找第三方接口链接路径配置
        /// </summary>
        /// <returns></returns>
        public RequestResult<List<MED_INTERFACE_DETAIL>> GetInterfaceDetailList()
        {
            return Success(sysConfig.GetInterfaceDetailList());
        }

        /// <summary>
        /// 获取一体机配置项
        /// </summary>
        /// <returns></returns>
        public RequestResult<dynamic> SaveInterfaceDetailData(List<MED_INTERFACE_DETAIL> interfaceDetailList)
        {

            return Success<dynamic>(sysConfig.SaveInterfaceDetailData(interfaceDetailList));
        }

        #endregion
        #endregion

        #region 个人模版路径模块
        /// <summary>
        /// 获取模版列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<dynamic> GetTempletMenu(string Create_By)
        {
            IList<MED_TEMPLET_MENU> templetMenu = sysConfig.GetTempletMenu(Create_By);
            return Success<dynamic>(templetMenu);
        }

        [HttpGet]
        public RequestResult<dynamic> GetTempletMenu(string Create_By, string TempletClass)
        {
            IList<MED_TEMPLET_MENU> templetMenu = sysConfig.GetTempletMenu(Create_By, TempletClass);
            return Success<dynamic>(templetMenu);
        }


        /// <summary>
        /// 获取模版操作详细
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<dynamic> GetTempletDetailList(string TEMPLET_NAME, string CREATE_BY, string ANESTHESIA_METHOD)
        {
            MED_ANESTHESIA_EVENT_TEMPLET model = new MED_ANESTHESIA_EVENT_TEMPLET();
            model.TEMPLET_NAME = TEMPLET_NAME;
            model.CREATE_BY = CREATE_BY;
            model.ANESTHESIA_METHOD = ANESTHESIA_METHOD;
            IList<MED_ANESTHESIA_EVENT_TEMPLET> templetMenu = sysConfig.GetTempletDetailList(model);
            return Success<dynamic>(templetMenu);
        }

        /// <summary>
        /// 获取模版操作详细
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<dynamic> GetTempletDetailList(string TEMPLET_NAME, string CREATE_BY, string ANESTHESIA_METHOD, string TEMPLET_CLASS)
        {
            MED_ANESTHESIA_EVENT_TEMPLET model = new MED_ANESTHESIA_EVENT_TEMPLET();
            model.TEMPLET_NAME = TEMPLET_NAME;
            model.CREATE_BY = CREATE_BY;
            model.ANESTHESIA_METHOD = ANESTHESIA_METHOD;
            model.TEMPLET_CLASS = TEMPLET_CLASS;
            IList<MED_ANESTHESIA_EVENT_TEMPLET> templetMenu = sysConfig.GetTempletDetailList(model);
            return Success<dynamic>(templetMenu);
        }

        /// <summary>
        /// 编辑模版事件
        /// </summary>
        /// <param name="type">0:新增 1:修改</param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> EditTemplete(int type, MED_ANESTHESIA_EVENT_TEMPLET model)
        {
            return Success(sysConfig.EditTemplete(type, model));
        }
        /// <summary>
        /// 删除模版事件
        /// </summary>
        /// <param name="type">0:删除事件 1:删除模版</param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> DeleteTempleteEvent(int type, MED_ANESTHESIA_EVENT_TEMPLET model)
        {
            return Success(sysConfig.DeleteTempleteEvent(type, model));
        }
        /// <summary>
        /// 新增获取基础数据
        /// </summary>
        /// <param name="TEMPLET_NAME"></param>
        /// <param name="CREATE_BY"></param>
        /// <param name="ANESTHESIA_METHOD"></param>
        /// <returns></returns>
        [HttpGet]
        public MED_ANESTHESIA_EVENT_TEMPLET GetNewTEMPLETE(string TEMPLET_NAME, string CREATE_BY, string ANESTHESIA_METHOD)
        {
            MED_ANESTHESIA_EVENT_TEMPLET newModel = new MED_ANESTHESIA_EVENT_TEMPLET();
            newModel.TEMPLET_NAME = TEMPLET_NAME;
            newModel.ANESTHESIA_METHOD = ANESTHESIA_METHOD;
            newModel.CREATE_BY = CREATE_BY;
            newModel.EVENT_CLASS_NAME = "";
            return newModel;
        }
        #endregion

        #region 工具

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<int> SaveDictDataByTableName(string tableName)
        {
            return Success(sysConfig.SaveDictDataByTableName(tableName));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public RequestResult<int> SaveDictDataByTableName(dynamic data)
        {
            return Success(sysConfig.SaveDictDataByTableName(data));
        }

        #endregion

        #region 同步

        /// <summary>
        /// 同步病人检验结果
        /// </summary>
        /// <param name="patientID">patientID</param>
        /// <param name="visitID">visitID</param>
        /// <returns></returns>
        [HttpGet]
        public RequestResult<string> SyncLIS101(string patientID, int visitID)
        {
            return Success(sysConfig.SyncWrite_LIS101(patientID, visitID));
        }

        #endregion

        #region 获取检验数据

        /// <summary>
        /// 获取检验信息主信息
        /// </summary>
        [HttpGet]
        public RequestResult<List<MED_LAB_TEST_MASTER>> GetMedLabTestMaster(string patientId, int visitId)
        {
            return Success(sysConfig.GetMedLabTestMaster(patientId, visitId));
        }


        /// <summary>
        /// 获取检验信息明细
        /// </summary>
        [HttpGet]
        public RequestResult<List<MED_LAB_RESULT>> GetMedLabResult(string testNo)
        {
            return Success(sysConfig.GetMedLabResult(testNo));
        }

        #endregion

        #region 获取检查数据

        #endregion

        #region 患者信息基本数据
        /// <summary>
        /// 患者信息基本数据
        /// </summary>
        [HttpGet]
        public RequestResult<List<dynamic>> GetPatientInfo(string patientId, int visitId,int operId)
        {
            return Success(sysConfig.GetPatientInfo(patientId, visitId, operId));
        }

        /// <summary>
        /// 患者信息基本数据
        /// </summary>
        [HttpGet]
        public RequestResult<List<dynamic>> GetPatientDocument(string patientId, int visitId, int operId)
        {
            return Success(sysConfig.GetPatientDocument(patientId, visitId, operId));
        }
        #endregion
    }
}
