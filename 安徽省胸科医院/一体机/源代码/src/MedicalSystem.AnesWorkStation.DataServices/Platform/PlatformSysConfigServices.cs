using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Domain.Origins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    public interface IPlatformSysConfigServices
    {
        #region 基础数据管理
        #region 科室字典
        IList<MED_DEPT_DICT> GetMedDeptDict(string DeptName);
        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="type">0:新增 1:修改</param>
        /// <param name="MedDeptDict"></param>
        /// <returns>0:失败 1：成功 2:校验主键已存在</returns>
        int EditMedDeptDict(int type, MED_DEPT_DICT MedDeptDict);

        int DeletedMedDeptDict(List<MED_DEPT_DICT> MedDeptDictList);
        #endregion

        #region 人员字典维护
        IList<MED_HIS_USERS> GetMedHisUserDict(string HisUserName);
        IList<MED_HIS_USERS> GetMedHisUserDict(string HisUserName, string DeptName, int UserStatus);
        int EditMedHisUserDict(int type, MED_HIS_USERS MedHisUserDict);
        int DeletedMedHisUserDict(List<MED_HIS_USERS> MedHisUserDict);
        #endregion

        #region 手术名称字典维护
        IList<MED_OPERATION_DICT> GetOperationDict(string OperationName);
        int EditOperationDict(int type, MED_OPERATION_DICT OperationDict);
        int DeletedOperationDict(List<MED_OPERATION_DICT> OperationDict);
        #endregion

        #region 诊断字典维护
        IList<MED_DIAGNOSIS_DICT> GetDiagnosisDict(string DiagnosisName);
        int EditDiagnosisDict(int type, MED_DIAGNOSIS_DICT DiagnosisDict);
        int DeletedDiagnosisDict(List<MED_DIAGNOSIS_DICT> DiagnosisDict);
        #endregion

        #region 常用术语维护
        IList<string> GetAnesInputDictItemClassList();
        IList<MED_ANESTHESIA_INPUT_DICT> GetAnesInputDictByItemClass(string ItemClass);
        int EditAnesInputDict(int type, MED_ANESTHESIA_INPUT_DICT AnesInputDict);
        int DeletedAnesInputDict(List<MED_ANESTHESIA_INPUT_DICT> AnesInputDict);
        #endregion

        #region 给药途径字典维护
        IList<MED_ADMINISTRATION_DICT> GetAdministrationDict(string Administration);
        int EditAdministrationDict(int type, MED_ADMINISTRATION_DICT AdministrationDict);
        int DeletedAdministrationDict(List<MED_ADMINISTRATION_DICT> AdministrationDict);
        #endregion

        #region 麻醉方法字典维护
        IList<MED_ANESTHESIA_DICT> GetAnesthesiaDict(string AnesMethodName);
        int EditAnesthesiaDict(int type, MED_ANESTHESIA_DICT AnesthesiaDict);
        int DeletedAnesthesiaDict(List<MED_ANESTHESIA_DICT> AnesthesiaDict);
        #endregion

        #region 手术间字典维护
        IList<MED_OPERATING_ROOM> GetOperatingRoomListAll();
        IList<MED_OPERATING_ROOM> GetOperatingRoomList(string OperatingRoomNo);
        int EditOperatingRoomList(int type, MED_OPERATING_ROOM OperatingRoomList);
        int DeletedOperatingRoomList(List<MED_OPERATING_ROOM> OperatingRoomList);
        #endregion

        #region 采集仪器字典维护
        IList<MED_MONITOR_DICT> GetMonitorDict();
        IList<MED_MONITOR_DICT> GetMonitorDict(string MonitorName);
        int EditMonitorDict(int type, MED_MONITOR_DICT MonitorDict);
        int DeletedMonitorDict(List<MED_MONITOR_DICT> MonitorDict);
        #endregion

        #region 单位字典维护
        IList<MED_UNIT_DICT> GetUnitDict(string UnitType);
        int EditUnitDict(int type, MED_UNIT_DICT UnitDict);
        int DeletedUnitDict(List<MED_UNIT_DICT> UnitDict);
        #endregion

        #region 采集项目维护
        IList<MED_MONITOR_FUNCTION_CODE> GetMonitorFunctionCode(string ItemName);
        int EditMonitorFunctionCodeList(int type, MED_MONITOR_FUNCTION_CODE MonitorFunctionCodeList);
        int DeletedMonitorFunctionCodeList(List<MED_MONITOR_FUNCTION_CODE> MonitorFunctionCodeList);
        #endregion
        #endregion

        #region 术中用药管理
        IList<MED_EVENT_DICT> GetMedEventDict(string itemClass);
        IList<MED_EVENT_DICT> GetMedEventDict(string itemClass, string itemName);
        int EditMedEventDict(int type, MED_EVENT_DICT MedEventDict);
        int DeletedMedEventDict(List<MED_EVENT_DICT> MedEventDict);
        MED_EVENT_DICT NewMedEventDict(string itemClass);
        IList<MED_EVENT_DICT_EXT> GetMedEventDictExt(string itemClass, string itemCode);
        int EditMedEventExtDict(int type, MED_EVENT_DICT_EXT medEventExtDict);
        MED_EVENT_DICT_EXT NewMedEventExtDict(string itemClass, string itemCode);
        int DeletedMedEventExtDict(List<MED_EVENT_DICT_EXT> medEventExtDictList);
        #endregion

        #region 其他配置
        #region 一体机配置
        string GetFromConfigTable(string key);
        int ModifyConfigTable(string key, string value);
        MED_CONFIGSET GetMedConfigSet();
        int ModifyMedConfigSet(MED_CONFIGSET medconfig);

        List<MED_INTERFACE_DETAIL> GetInterfaceDetailList();

        int SaveInterfaceDetailData(List<MED_INTERFACE_DETAIL> interfaceDetailList);

        #endregion

        #region 麻醉方法归类配置
        string GetAnesMethodClass();
        string AddAnesMethodClass(MED_ANESTHESIA_CONFIG item);
        string DeletedAnesMethodClass(int id);
        List<string> GetAnesMethodOptions(int ITEM_PARENTID);
        #endregion
        #endregion

        #region 个人模版路径
        IList<MED_TEMPLET_MENU> GetTempletMenu(string creatyBy);

        IList<MED_TEMPLET_MENU> GetTempletMenu(string creatyBy, string TempletClass);

        IList<MED_ANESTHESIA_EVENT_TEMPLET> GetTempletDetailList(MED_ANESTHESIA_EVENT_TEMPLET model);
        int EditTemplete(int type, MED_ANESTHESIA_EVENT_TEMPLET model);
        int DeleteTempleteEvent(int type, MED_ANESTHESIA_EVENT_TEMPLET model);
        #endregion

        #region HIs同步
        /// <summary>
        /// 根据患者ID同步HIS
        /// </summary>
        /// <param name="patientID">patientID</param>
        /// <returns></returns>
        string SyncPatientInfoAndInHospital(string patientID);

        /// <summary>
        /// 根据住院号同步HIS
        /// </summary>
        /// <param name="inpNo">inpNo</param>
        /// <returns></returns>
        string SyncPatientInfoAndInHospitalByInpNo(string inpNo);


        /// <summary>
        /// 回传手术状态HIS203
        /// </summary>
        string SyncHIS203(string patientID, int visitID, int operID);

        /// <summary>
        /// 文书上传OPER505W
        /// </summary>
        string SyncOPER505W(MED_EMR_ARCHIVE_DETIAL mead);


        /// <summary>
        /// 同步患者的LIS检验信息
        /// </summary>
        /// <param name="patientID">patientID</param>
        /// <param name="visitID">visitID</param>
        /// <returns></returns>
        string SyncWrite_LIS101(string patientID, int visitID);


        List<MED_LAB_TEST_MASTER> GetMedLabTestMaster(string patientId, int visitId);

        List<MED_LAB_RESULT> GetMedLabResult(string testNo);

        List<MED_LAB_RESULT> GetMedLabResult(string patientId, int visitId);

        List<dynamic> GetPatientInfo(string patientId, int visitId,int operId);

        List<dynamic> GetPatientDocument(string patientId, int visitId, int operId);

        #endregion

        #region 工具
        int SaveDictDataByTableName(string tableName);

        #endregion


    }
    public class PlatformSysConfigServices : BaseService<PlatformSysConfigServices>, IPlatformSysConfigServices
    {
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected PlatformSysConfigServices()
            : base()
        { }

        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public PlatformSysConfigServices(IDapperContext context)
            : base(context)
        {
        }

        #region 基础数据管理
        #region 科室字典
        public IList<MED_DEPT_DICT> GetMedDeptDict(string DeptName)
        {
            bool flag = string.IsNullOrEmpty(DeptName);
            return dapper.Set<MED_DEPT_DICT>().Select(d => flag || d.DEPT_NAME.Contains(DeptName)).OrderBy(t => t.SORT_NO).ToList();
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="type">0:新增 1:修改</param>
        /// <param name="MedDeptDict"></param>
        /// <returns>0:失败 1：成功 2:校验主键已存在</returns>
        public int EditMedDeptDict(int type, MED_DEPT_DICT MedDeptDict)
        {
            int result = 0;
            if (type == 0)
            {
                if (dapper.Set<MED_DEPT_DICT>().Single(d => d.DEPT_CODE == MedDeptDict.DEPT_CODE) != null)
                {
                    result = 2;
                }
                else
                {
                    result = dapper.Set<MED_DEPT_DICT>().Insert(MedDeptDict) ? 1 : 0;
                }
            }
            else
            {
                result = dapper.Set<MED_DEPT_DICT>().Update(MedDeptDict) > 0 ? 1 : 0;
            }
            dapper.SaveChanges();

            return result;
        }

        public int DeletedMedDeptDict(List<MED_DEPT_DICT> MedDeptDictList)
        {
            int result = dapper.Set<MED_DEPT_DICT>().Delete(MedDeptDictList);
            dapper.SaveChanges();
            return result;
        }
        #endregion

        #region 人员字典维护
        public IList<MED_HIS_USERS> GetMedHisUserDict(string HisUserName)
        {
            string sql = sqlDict.GetSQLByKey("GetMedHisUserDict");
            List<MED_HIS_USERS> list = dapper.Query<MED_HIS_USERS>(sql, new { HisUserName = HisUserName }).OrderBy(t => t.SORT_NO).ToList();
            return list;
        }

        public IList<MED_HIS_USERS> GetMedHisUserDict(string HisUserName, string DetptName, int UserStatus)
        {
            string sql = sqlDict.GetSQLByKey("GetMedHisUserDict2");
            List<MED_HIS_USERS> list = dapper.Query<MED_HIS_USERS>(sql, new { HisUserName = HisUserName, DetptName = DetptName, UserStatus = UserStatus }).OrderBy(t => t.SORT_NO).ToList();

            if (UserStatus == 1)
            {
                list = list.FindAll(t => t.USER_STATUS == 1);
            }
            else
            {
                list = list.FindAll(t => t.USER_STATUS != 1);
            }
            return list;
        }
        public int EditMedHisUserDict(int type, MED_HIS_USERS MedHisUserDict)
        {
            int result = 0;
            if (type == 0)
            {
                if (dapper.Set<MED_HIS_USERS>().Single(d => d.USER_JOB_ID == MedHisUserDict.USER_JOB_ID) != null)
                {
                    result = 2;
                }
                else
                {
                    MedHisUserDict.CREATE_DATE = DateTime.Now;
                    result = dapper.Set<MED_HIS_USERS>().Insert(MedHisUserDict) ? 1 : 0;
                }
            }
            else
            {
                result = dapper.Set<MED_HIS_USERS>().Update(MedHisUserDict) > 0 ? 1 : 0;
            }
            dapper.SaveChanges();
            return result;
        }
        public int DeletedMedHisUserDict(List<MED_HIS_USERS> EditMedHisUserDict)
        {
            foreach (var item in EditMedHisUserDict)
            {
                item.USER_STATUS = 0;
            }
            int result = dapper.Set<MED_HIS_USERS>().Update(EditMedHisUserDict);
            //int result = dapper.Set<MED_HIS_USERS>().Delete(EditMedHisUserDict);
            dapper.SaveChanges();
            return result;
        }
        #endregion

        #region 手术名称字典维护
        public IList<MED_OPERATION_DICT> GetOperationDict(string OperationName)
        {
            bool flag = string.IsNullOrEmpty(OperationName);
            return dapper.Set<MED_OPERATION_DICT>().Select(d => flag || d.OPER_NAME.Contains(OperationName)).OrderBy(t => t.SORT_NO).ToList();
        }
        public int EditOperationDict(int type, MED_OPERATION_DICT OperationDict)
        {
            int result = 0;
            if (type == 0)
            {
                if (dapper.Set<MED_OPERATION_DICT>().Single(d => d.OPER_CODE == OperationDict.OPER_CODE) != null)
                {
                    result = 2;
                }
                else
                {
                    OperationDict.CREATE_DATE = DateTime.Now;
                    result = dapper.Set<MED_OPERATION_DICT>().Insert(OperationDict) ? 1 : 0;
                }
            }
            else
            {
                result = dapper.Set<MED_OPERATION_DICT>().Update(OperationDict) > 0 ? 1 : 0;
            }
            dapper.SaveChanges();

            return result;
        }
        public int DeletedOperationDict(List<MED_OPERATION_DICT> OperationDict)
        {
            int result = dapper.Set<MED_OPERATION_DICT>().Delete(OperationDict);
            dapper.SaveChanges();
            return result;
        }
        #endregion

        #region 诊断字典维护
        public IList<MED_DIAGNOSIS_DICT> GetDiagnosisDict(string DiagnosisName)
        {
            bool flag = string.IsNullOrEmpty(DiagnosisName);
            return dapper.Set<MED_DIAGNOSIS_DICT>().Select(d => flag || d.DIAGNOSIS_NAME.Contains(DiagnosisName)).OrderBy(t => t.SORT_NO).ToList();
        }
        public int EditDiagnosisDict(int type, MED_DIAGNOSIS_DICT DiagnosisDict)
        {
            int result = 0;
            if (type == 0)
            {
                if (dapper.Set<MED_DIAGNOSIS_DICT>().Single(d => d.DIAGNOSIS_CODE == DiagnosisDict.DIAGNOSIS_CODE) != null)
                {
                    result = 2;
                }
                else
                {
                    DiagnosisDict.CREATE_DATE = DateTime.Now;
                    result = dapper.Set<MED_DIAGNOSIS_DICT>().Insert(DiagnosisDict) ? 1 : 0;
                }
            }
            else
            {
                result = dapper.Set<MED_DIAGNOSIS_DICT>().Update(DiagnosisDict) > 0 ? 1 : 0;
            }
            dapper.SaveChanges();

            return result;
        }
        public int DeletedDiagnosisDict(List<MED_DIAGNOSIS_DICT> DiagnosisDict)
        {
            int result = dapper.Set<MED_DIAGNOSIS_DICT>().Delete(DiagnosisDict);
            dapper.SaveChanges();
            return result;
        }
        #endregion

        #region 常用术语维护
        public IList<string> GetAnesInputDictItemClassList()
        {
            return dapper.Set<MED_ANESTHESIA_INPUT_DICT>().Select(x => new { x.ITEM_CLASS }).Select(x => x.ITEM_CLASS).Distinct().ToList();
        }
        public IList<MED_ANESTHESIA_INPUT_DICT> GetAnesInputDictByItemClass(string ItemClass)
        {
            bool flag = string.IsNullOrEmpty(ItemClass);
            return dapper.Set<MED_ANESTHESIA_INPUT_DICT>().Select(d => flag || d.ITEM_CLASS == ItemClass).OrderBy(x => x.ITEM_NAME).ToList();
        }
        public int EditAnesInputDict(int type, MED_ANESTHESIA_INPUT_DICT AnesInputDict)
        {
            int result = 0;
            if (type == 0)
            {
                if (dapper.Set<MED_ANESTHESIA_INPUT_DICT>().Single(d => d.ITEM_CLASS == AnesInputDict.ITEM_CLASS && d.ITEM_NAME == AnesInputDict.ITEM_NAME) != null)
                {
                    result = 2;
                }
                else
                {
                    result = dapper.Set<MED_ANESTHESIA_INPUT_DICT>().Insert(AnesInputDict) ? 1 : 0;
                }
            }
            else
            {
                result = dapper.Set<MED_ANESTHESIA_INPUT_DICT>().Update(AnesInputDict) > 0 ? 1 : 0;
            }
            dapper.SaveChanges();
            return result;
        }
        public int DeletedAnesInputDict(List<MED_ANESTHESIA_INPUT_DICT> AnesInputDict)
        {
            int result = dapper.Set<MED_ANESTHESIA_INPUT_DICT>().Delete(AnesInputDict);
            dapper.SaveChanges();
            return result;
        }
        #endregion

        #region 给药途径字典维护
        public IList<MED_ADMINISTRATION_DICT> GetAdministrationDict(string Administration)
        {
            bool flag = string.IsNullOrEmpty(Administration);
            return dapper.Set<MED_ADMINISTRATION_DICT>().Select(d => flag || d.ADMINISTRATION_NAME.Contains(Administration)).OrderBy(t => t.SORT_NO).ToList();
        }
        public int EditAdministrationDict(int type, MED_ADMINISTRATION_DICT AdministrationDict)
        {
            int result = 0;
            if (type == 0)
            {
                if (dapper.Set<MED_ADMINISTRATION_DICT>().Single(d => d.ADMINISTRATION_CODE == AdministrationDict.ADMINISTRATION_CODE) != null)
                {
                    result = 2;
                }
                else
                {
                    result = dapper.Set<MED_ADMINISTRATION_DICT>().Insert(AdministrationDict) ? 1 : 0;
                }
            }
            else
            {
                result = dapper.Set<MED_ADMINISTRATION_DICT>().Update(AdministrationDict) > 0 ? 1 : 0;
            }
            dapper.SaveChanges();

            return result;
        }
        public int DeletedAdministrationDict(List<MED_ADMINISTRATION_DICT> AdministrationDict)
        {
            int result = dapper.Set<MED_ADMINISTRATION_DICT>().Delete(AdministrationDict);
            dapper.SaveChanges();
            return result;
        }
        #endregion

        #region 麻醉方法字典维护
        public IList<MED_ANESTHESIA_DICT> GetAnesthesiaDict(string AnesMethodName)
        {
            bool flag = string.IsNullOrEmpty(AnesMethodName);
            return dapper.Set<MED_ANESTHESIA_DICT>().Select(d => flag || d.ANAESTHESIA_NAME.Contains(AnesMethodName)).OrderBy(t => t.SORT_NO).ToList();
        }
        public int EditAnesthesiaDict(int type, MED_ANESTHESIA_DICT AnesthesiaDict)
        {
            int result = 0;
            if (type == 0)
            {
                if (dapper.Set<MED_ANESTHESIA_DICT>().Single(d => d.ANAESTHESIA_CODE == AnesthesiaDict.ANAESTHESIA_CODE) != null)
                {
                    result = 2;
                }
                else
                {
                    result = dapper.Set<MED_ANESTHESIA_DICT>().Insert(AnesthesiaDict) ? 1 : 0;
                }
            }
            else
            {
                result = dapper.Set<MED_ANESTHESIA_DICT>().Update(AnesthesiaDict) > 0 ? 1 : 0;
            }
            dapper.SaveChanges();

            return result;
        }
        public int DeletedAnesthesiaDict(List<MED_ANESTHESIA_DICT> AnesthesiaDict)
        {
            int result = dapper.Set<MED_ANESTHESIA_DICT>().Delete(AnesthesiaDict);
            dapper.SaveChanges();
            return result;
        }
        #endregion

        #region 手术间字典维护

        public IList<MED_OPERATING_ROOM> GetOperatingRoomListAll()
        {
            string sql = sqlDict.GetSQLByKey("GetOperatingRoomListAll");
            List<MED_OPERATING_ROOM> list = dapper.Query<MED_OPERATING_ROOM>(sql).OrderBy(t => t.SORT_NO).ToList();
            return list;
        }

        public IList<MED_OPERATING_ROOM> GetOperatingRoomList(string OperatingRoomNo)
        {
            string sql = sqlDict.GetSQLByKey("GetOperatingRoomList");
            List<MED_OPERATING_ROOM> list = dapper.Query<MED_OPERATING_ROOM>(sql, new { OperatingRoomNo = OperatingRoomNo }).OrderBy(t => t.SORT_NO).ToList();
            return list;
        }

        public int EditOperatingRoomList(int type, MED_OPERATING_ROOM OperatingRoomList)
        {
            int result = 0;
            if (type == 0)
            {
                if (dapper.Set<MED_OPERATING_ROOM>().Single(d => d.ROOM_NO == OperatingRoomList.ROOM_NO) != null)
                {
                    result = 2;
                }
                else
                {
                    result = dapper.Set<MED_OPERATING_ROOM>().Insert(OperatingRoomList) ? 1 : 0;
                }
            }
            else
            {
                result = dapper.Set<MED_OPERATING_ROOM>().Update(OperatingRoomList) > 0 ? 1 : 0;
            }
            dapper.SaveChanges();

            return result;
        }
        public int DeletedOperatingRoomList(List<MED_OPERATING_ROOM> OperatingRoomList)
        {
            int result = dapper.Set<MED_OPERATING_ROOM>().Delete(OperatingRoomList);
            dapper.SaveChanges();
            return result;
        }
        #endregion

        #region 采集仪器字典维护
        public IList<MED_MONITOR_DICT> GetMonitorDict()
        {
            return dapper.Set<MED_MONITOR_DICT>().Select();
        }

        public IList<MED_MONITOR_DICT> GetMonitorDict(string MonitorName)
        {
            bool flag = string.IsNullOrEmpty(MonitorName);
            return dapper.Set<MED_MONITOR_DICT>().Select(d => flag || d.MONITOR_LABEL.Contains(MonitorName));
        }
        public int EditMonitorDict(int type, MED_MONITOR_DICT MonitorDict)
        {
            int result = 0;
            if (type == 0)
            {
                if (dapper.Set<MED_MONITOR_DICT>().Single(d => d.MONITOR_LABEL == MonitorDict.MONITOR_LABEL) != null)
                {
                    result = 2;
                }
                else
                {
                    result = dapper.Set<MED_MONITOR_DICT>().Insert(MonitorDict) ? 1 : 0;
                }
            }
            else
            {
                result = dapper.Set<MED_MONITOR_DICT>().Update(MonitorDict) > 0 ? 1 : 0;
            }
            dapper.SaveChanges();

            return result;
        }
        public int DeletedMonitorDict(List<MED_MONITOR_DICT> MonitorDict)
        {
            int result = dapper.Set<MED_MONITOR_DICT>().Delete(MonitorDict);
            dapper.SaveChanges();
            return result;
        }
        #endregion

        #region 单位字典维护
        public IList<MED_UNIT_DICT> GetUnitDict(string UnitType)
        {
            IList<MED_UNIT_DICT> UnitDict;
            if (string.IsNullOrEmpty(UnitType))
            {
                UnitDict = dapper.Set<MED_UNIT_DICT>().Select().OrderBy(t => t.SORT_NO).ToList();
            }
            else
            {
                int type = int.Parse(UnitType);
                UnitDict = dapper.Set<MED_UNIT_DICT>().Select(d => d.UNIT_TYPE == type).OrderBy(t => t.SORT_NO).ToList();
            }
            foreach (var item in UnitDict)
            {
                switch (item.UNIT_TYPE)
                {
                    case 1:
                        item.UNIT_TYPE_NAME = "浓度单位";
                        break;
                    case 2:
                        item.UNIT_TYPE_NAME = "速度单位";
                        break;
                    case 3:
                        item.UNIT_TYPE_NAME = "剂量单位";
                        break;
                    default:
                        break;
                }
            }
            return UnitDict;
        }
        public int EditUnitDict(int type, MED_UNIT_DICT UnitDict)
        {
            int result = 0;
            if (type == 0)
            {
                if (dapper.Set<MED_UNIT_DICT>().Single(d => d.UNIT_CODE == UnitDict.UNIT_CODE
                    && d.UNIT_NAME == UnitDict.UNIT_NAME && d.UNIT_TYPE == UnitDict.UNIT_TYPE) != null)
                {
                    result = 2;
                }
                else
                {
                    result = dapper.Set<MED_UNIT_DICT>().Insert(UnitDict) ? 1 : 0;
                }
            }
            else
            {
                result = dapper.Set<MED_UNIT_DICT>().Update(UnitDict) > 0 ? 1 : 0;
            }
            dapper.SaveChanges();

            return result;
        }
        public int DeletedUnitDict(List<MED_UNIT_DICT> UnitDict)
        {
            int result = dapper.Set<MED_UNIT_DICT>().Delete(UnitDict);
            dapper.SaveChanges();
            return result;
        }
        #endregion

        #region 采集项目维护
        public IList<MED_MONITOR_FUNCTION_CODE> GetMonitorFunctionCode(string ItemName)
        {
            bool flag = string.IsNullOrEmpty(ItemName);
            return dapper.Set<MED_MONITOR_FUNCTION_CODE>().Select(d => flag || d.ITEM_NAME.Contains(ItemName) || d.ITEM_CODE.Contains(ItemName));
        }

        public int EditMonitorFunctionCodeList(int type, MED_MONITOR_FUNCTION_CODE MonitorFunctionCodeList)
        {
            int result = 0;
            if (type == 0)
            {
                if (dapper.Set<MED_MONITOR_FUNCTION_CODE>().Single(d => d.ITEM_CODE == MonitorFunctionCodeList.ITEM_CODE
                    && d.ITEM_NAME == MonitorFunctionCodeList.ITEM_NAME) != null)
                {
                    result = 2;
                }
                else
                {
                    int maxItemId = dapper.Set<MED_MONITOR_FUNCTION_CODE>().Select().OrderByDescending(x => x.ITEM_ID).FirstOrDefault().ITEM_ID;
                    MonitorFunctionCodeList.ITEM_ID = maxItemId + 1;
                    result = dapper.Set<MED_MONITOR_FUNCTION_CODE>().Insert(MonitorFunctionCodeList) ? 1 : 0;
                }
            }
            else
            {
                result = dapper.Set<MED_MONITOR_FUNCTION_CODE>().Update(MonitorFunctionCodeList) > 0 ? 1 : 0;
            }
            dapper.SaveChanges();

            return result;
        }
        public int DeletedMonitorFunctionCodeList(List<MED_MONITOR_FUNCTION_CODE> MonitorFunctionCodeList)
        {
            int result = dapper.Set<MED_MONITOR_FUNCTION_CODE>().Delete(MonitorFunctionCodeList);
            dapper.SaveChanges();
            return result;
        }
        #endregion
        #endregion

        #region 术中用药管理
        private Func<string, int> IntFormat = (s) => { int i = 0; int.TryParse(s, out i); return i; };
        public IList<MED_EVENT_DICT> GetMedEventDict(string itemClass, string itemName)
        {
            bool flag = string.IsNullOrEmpty(itemName);
            return dapper.Set<MED_EVENT_DICT>().Select(d => d.EVENT_CLASS_CODE.Equals(itemClass) && (flag || d.EVENT_ITEM_NAME.Contains(itemName))).OrderBy(t => t.SORT_NO).ToList();
        }
        public IList<MED_EVENT_DICT> GetMedEventDict(string itemClass)
        {
            return dapper.Set<MED_EVENT_DICT>().Select(d => d.EVENT_CLASS_CODE.Equals(itemClass)).OrderBy(t => t.SORT_NO).ToList();
        }
        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="type">0:新增 1:修改</param>
        /// <param name="MedDeptDict"></param>
        /// <returns>0:失败 1：成功 2:校验主键已存在</returns>
        public int EditMedEventDict(int type, MED_EVENT_DICT MedEventDict)
        {
            int result = 0;
            if (type == 0)
            {
                if (dapper.Set<MED_EVENT_DICT>().Single(d => d.EVENT_CLASS_CODE == MedEventDict.EVENT_CLASS_CODE && d.EVENT_ITEM_NAME == MedEventDict.EVENT_ITEM_NAME && d.EVENT_ITEM_CODE == MedEventDict.EVENT_ITEM_CODE) != null)
                {
                    result = 2;
                }
                else
                {
                    result = dapper.Set<MED_EVENT_DICT>().Insert(MedEventDict) ? 1 : 0;
                }
            }
            else
            {
                result = dapper.Set<MED_EVENT_DICT>().Update(MedEventDict) > 0 ? 1 : 0;
            }
            dapper.SaveChanges();

            return result;
        }

        public MED_EVENT_DICT NewMedEventDict(string itemClass)
        {
            //int listcount = dapper.Set<MED_EVENT_DICT>().Select(d => d.EVENT_CLASS_CODE == itemClass)
            //    .Select(x => IntFormat(x.EVENT_ITEM_CODE)).Max();

            int listcount = dapper.Set<MED_EVENT_DICT>().Select(d => d.EVENT_CLASS_CODE == itemClass)
                .Select(x => IntFormat(x.EVENT_ITEM_CODE.Trim().Substring(1, x.EVENT_ITEM_CODE.Length - 1))).Max();

            MED_EVENT_DICT dic = new MED_EVENT_DICT();
            dic.EVENT_CLASS_CODE = itemClass;

            dic.EVENT_ITEM_CODE = itemClass + (1 + listcount).ToString();

            return dic;
        }
        public int DeletedMedEventDict(List<MED_EVENT_DICT> MedEventDictList)
        {
            int result = dapper.Set<MED_EVENT_DICT>().Delete(MedEventDictList);
            dapper.SaveChanges();
            return result;
        }

        public IList<MED_EVENT_DICT_EXT> GetMedEventDictExt(string itemClass, string itemCode)
        {
            string sql = sqlDict.GetSQLByKey("GetMedEventDictExt");
            List<MED_EVENT_DICT_EXT> list = dapper.Query<MED_EVENT_DICT_EXT>(sql, new
            {
                itemClass = itemClass,
                itemCode = itemCode
            }).OrderBy(t => t.SORT_NO).ToList();
            return list;
        }
        public int EditMedEventExtDict(int type, MED_EVENT_DICT_EXT medEventExtDict)
        {
            int result = 0;
            if (type == 0)
            {
                if (dapper.Set<MED_EVENT_DICT_EXT>().Single(d => d.EVENT_CLASS_CODE == medEventExtDict.EVENT_CLASS_CODE && d.EVENT_ITEM_CODE == medEventExtDict.EVENT_ITEM_CODE && d.DOSAGE_NO == medEventExtDict.DOSAGE_NO) != null)
                {
                    result = 2;
                }
                else
                {
                    result = dapper.Set<MED_EVENT_DICT_EXT>().Insert(medEventExtDict) ? 1 : 0;
                }
            }
            else
            {
                if (dapper.Set<MED_EVENT_DICT_EXT>().Single(d => d.EVENT_CLASS_CODE == medEventExtDict.EVENT_CLASS_CODE && d.EVENT_ITEM_CODE == medEventExtDict.EVENT_ITEM_CODE && d.DOSAGE_NO == medEventExtDict.DOSAGE_NO) != null)
                {
                    result = dapper.Set<MED_EVENT_DICT_EXT>().Update(medEventExtDict) > 0 ? 1 : 0;
                }
                else
                {
                    result = dapper.Set<MED_EVENT_DICT_EXT>().Insert(medEventExtDict) ? 1 : 0;
                }

                //result = dapper.Set<MED_EVENT_DICT_EXT>().Update(medEventExtDict) > 0 ? 1 : 0;
            }
            dapper.SaveChanges();
            return result;
        }
        public MED_EVENT_DICT_EXT NewMedEventExtDict(string itemClass, string itemCode)
        {
            List<MED_EVENT_DICT_EXT> _list = dapper.Set<MED_EVENT_DICT_EXT>().Select(d => d.EVENT_CLASS_CODE == itemClass && d.EVENT_ITEM_CODE == itemCode);

            int listcount = 0;

            if (_list.Count > 0) {
                listcount= _list
                .Select(x => x.DOSAGE_NO).Max();
            }
            
            MED_EVENT_DICT_EXT dic = new MED_EVENT_DICT_EXT();
            dic.EVENT_CLASS_CODE = itemClass;
            dic.EVENT_ITEM_CODE = itemCode;
            dic.DOSAGE_NO = listcount + 1;
            return dic;
        }
        public int DeletedMedEventExtDict(List<MED_EVENT_DICT_EXT> medEventExtDictList)
        {
            int result = dapper.Set<MED_EVENT_DICT_EXT>().Delete(medEventExtDictList);
            dapper.SaveChanges();
            return result;
        }
        #endregion

        #region 其他配置
        #region 一体机配置
        public string GetFromConfigTable(string key)
        {
            //var configTable = ExtendAppContext.Current.CommDict.ConfigDict;// ;
            var configTable = dapper.Set<MED_CONFIG>().Select();
            if (!string.IsNullOrEmpty(key) && configTable != null)
            {
                var configRow = configTable.FirstOrDefault(x => x.PARAKEY == key);
                if (configRow != null && configRow.PARAVALUE != null && configRow.PARAVALUE.Length != 0)
                {
                    // string ret = StringHelper.Arr2Str(configRow.PARAVALUE);
                    string ret = (new UnicodeEncoding()).GetString(configRow.PARAVALUE, 0, configRow.PARAVALUE.Length); ;
                    if (ret == "�") ret = string.Empty;
                    return ret;
                }
                else
                {
                    return string.Empty;
                }
            }
            return null;
        }
        public int ModifyConfigTable(string key, string value)
        {
            int result = 0;

            List<MED_CONFIG> configList = dapper.Set<MED_CONFIG>().Select(); ;
            configList = configList.Where(x => x.PARAKEY == key).ToList();
            MED_CONFIG configRow = null;
            if (configList != null && configList.Count > 0)
            {
                configRow = configList[0];
            }
            if (configRow == null)
            {
                configRow = new MED_CONFIG();
                configRow.PARAKEY = key;
                configRow.PARAVALUE = (new UnicodeEncoding()).GetBytes(value);
                result = dapper.Set<MED_CONFIG>().Insert(configRow) ? 1 : 0;
            }
            else
            {

                configRow.PARAVALUE = (new UnicodeEncoding()).GetBytes(value);
                result = dapper.Set<MED_CONFIG>().Update(configRow) > 0 ? 1 : 0;

            }

            dapper.SaveChanges();
            return result;


        }
        public MED_CONFIGSET GetMedConfigSet()
        {

            List<MED_CONFIG> configList = dapper.Set<MED_CONFIG>().Select();
            MED_CONFIGSET model = new MED_CONFIGSET();
            if (GetFromConfigTable("IsSync", configList) != "")
            {
                model.IsSync = Convert.ToBoolean(GetFromConfigTable("IsSync", configList));
            }
            if (GetFromConfigTable("AnesDocPageHours", configList) != "")
            {
                model.AnesDocPageHours = GetFromConfigTable("AnesDocPageHours", configList);
            }
            if (GetFromConfigTable("IsSyncByInpNo", configList) != "")
            {
                model.IsSyncByInpNo = Convert.ToBoolean(GetFromConfigTable("IsSyncByInpNo", configList));
            }
            if (GetFromConfigTable("DoubleSelect", configList) != "")
            {
                model.DoubleSelect = Convert.ToBoolean(GetFromConfigTable("DoubleSelect", configList));
            }
            if (GetFromConfigTable("IsOpenCoordinationCall", configList) != "")
            {
                model.IsOpenCoordinationCall = Convert.ToBoolean(GetFromConfigTable("IsOpenCoordinationCall", configList));
            }
            if (GetFromConfigTable("DrugAutoStop", configList) != "")
            {
                model.DrugAutoStop = Convert.ToBoolean(GetFromConfigTable("DrugAutoStop", configList));
            }
            if (GetFromConfigTable("IsVerificationAudit", configList) != "")
            {
                model.IsVerificationAudit = Convert.ToBoolean(GetFromConfigTable("IsVerificationAudit", configList));
            }

            if (GetFromConfigTable("DrugAutoStopOperationStatus", configList) != "")
            {
                model.YouDaoRoomTitle = GetFromConfigTable("DrugAutoStopOperationStatus", configList);
            }
            if (GetFromConfigTable("YouDaoRoomTitle", configList) != "")
            {
                model.YouDaoRoomTitle = GetFromConfigTable("YouDaoRoomTitle", configList);
            }
            if (GetFromConfigTable("DrugShow", configList) != "")
            {

                model.DrugShow = GetFromConfigTable("DrugShow", configList);
            }
            if (GetFromConfigTable("ProLonged", configList) != "")
            {
                model.ProLonged = GetFromConfigTable("ProLonged", configList);
            }

            if (GetFromConfigTable("DrugLegend", configList) != "")
            {
                model.DrugLegend = GetFromConfigTable("DrugLegend", configList);
            }
            //modified by joysola on 2018-3-26 新增输液输血显示类型属性
            if (GetFromConfigTable("BloodLiquidShow", configList) != "")
            {
                model.BloodLiquidShow = GetFromConfigTable("BloodLiquidShow", configList);
            }
            //modified end on 2018-3-26

            // modified by joysola on 2018-4-3 新增双面打印文书
            if (GetFromConfigTable("DoublePrintDocNames", configList) != "")
            {
                model.DoublePrintDocNames = GetFromConfigTable("DoublePrintDocNames", configList);
            }
            //modified end on 2018-4-3

            if (GetFromConfigTable("IsModifyVitalSignShowDifferent", configList) != "")
            {

                model.IsModifyVitalSignShowDifferent = Convert.ToBoolean(GetFromConfigTable("IsModifyVitalSignShowDifferent", configList));
            }
            if (GetFromConfigTable("IsPACUProcess", configList) != "")
            {
                model.IsPACUProcess = Convert.ToBoolean(GetFromConfigTable("IsPACUProcess", configList));
            }
            if (GetFromConfigTable("IsUpdateScheduleStatus", configList) != "")
            {
                model.IsUpdateScheduleStatus = Convert.ToBoolean(GetFromConfigTable("IsUpdateScheduleStatus", configList));
            }
            if (GetFromConfigTable("IsUpdateHisStatus", configList) != "")
            {
                model.IsUpdateHisStatus = Convert.ToBoolean(GetFromConfigTable("IsUpdateHisStatus", configList));
            }

            if (GetFromConfigTable("IsUpdateAnesCharge", configList) != "")
            {
                model.IsUpdateAnesCharge = Convert.ToBoolean(GetFromConfigTable("IsUpdateAnesCharge", configList));
            }
            if (GetFromConfigTable("AnesthesiaNumber", configList) != "")
            {
                model.AnesthesiaNumber = GetFromConfigTable("AnesthesiaNumber", configList);
            }
            if (GetFromConfigTable("PDFLocalUrl", configList) != "")
            {

                model.PDFLocalUrl = GetFromConfigTable("PDFLocalUrl", configList);
            }
            if (GetFromConfigTable("PDFServerUrl", configList) != "")
            {
                model.PDFServerUrl = GetFromConfigTable("PDFServerUrl", configList);
            }
            if (GetFromConfigTable("IsDeleteAfterCommitDoc", configList) != "")
            {
                model.IsDeleteAfterCommitDoc = Convert.ToBoolean(GetFromConfigTable("IsDeleteAfterCommitDoc", configList));
            }
            if (GetFromConfigTable("PostPDF_Names", configList) != "")
            {
                string[] value = GetFromConfigTable("PostPDF_Names", configList).Split(',');

                model.PostPDF_Names = value;
            }
            else
            {
                model.PostPDF_Names = new string[] { "麻醉记录单" };
            }
            if (GetFromConfigTable("DocNameCheckList", configList) != "")
            {
                string[] value = GetFromConfigTable("DocNameCheckList", configList).Split(',');
                model.DocNameCheckList = value;
            }
            else
            {
                model.DocNameCheckList = new string[] { "麻醉记录单" };
            }

            if (GetFromConfigTable("IsAutomaticArchiving", configList) != "")
            {

                model.IsAutomaticArchiving = Convert.ToBoolean(GetFromConfigTable("IsAutomaticArchiving", configList));
            }
            if (GetFromConfigTable("ArchivOperAfterDay", configList) != "")
            {
                model.ArchivOperAfterDay = GetFromConfigTable("ArchivOperAfterDay", configList);
            }
            if (GetFromConfigTable("PrintPageName", configList) != "")
            {
                model.PrintPageName = GetFromConfigTable("PrintPageName", configList);
            }
            if (GetFromConfigTable("PrintPaperHeight", configList) != "")
            {
                model.PrintPaperHeight = Convert.ToDecimal(GetFromConfigTable("PrintPaperHeight", configList));
            }
            if (GetFromConfigTable("PrintPaperWidth", configList) != "")
            {

                model.PrintPaperWidth = Convert.ToDecimal(GetFromConfigTable("PrintPaperWidth", configList));
            }
            if (GetFromConfigTable("PaperLeftOff", configList) != "")
            {
                model.PaperLeftOff = Convert.ToDecimal(GetFromConfigTable("PaperLeftOff", configList));
            }
            if (GetFromConfigTable("PaperTopOff", configList) != "")
            {
                model.PaperTopOff = Convert.ToDecimal(GetFromConfigTable("PaperTopOff", configList));
            }
            if (GetFromConfigTable("IsOpenPatConfirm", configList) != "")
            {
                model.IsOpenPatConfirm = Convert.ToBoolean(GetFromConfigTable("IsOpenPatConfirm", configList));
            }
            // modified by joysola on 2018-6-29 新增手术医生科室筛选
            if (GetFromConfigTable("DeptCodeStr", configList) != "")
            {
                model.DeptCodeStr = GetFromConfigTable("DeptCodeStr", configList);
            }
            // modified end

            //快捷键
            if (GetFromConfigTable("ShortCuts", configList) != "")
            {
                string shortcuts = GetFromConfigTable("ShortCuts", configList);
                string[] items = shortcuts.Split(';');  //分号区分
                List<ShortCuts> list = new List<ShortCuts>();
                foreach (var item in items)
                {
                    string[] arry = item.Split(':');  //冒号区分
                    if (arry.Length > 1)
                    {
                        ShortCuts shortCutsModel = new ShortCuts();
                        shortCutsModel.Key = arry[0];
                        shortCutsModel.Value = arry[1];
                        list.Add(shortCutsModel);
                    }
                }
                model.ShortCuts = list;
            }
            else
            {
                List<ShortCuts> list = new List<ShortCuts>();
                ShortCuts shortCutsModel = new ShortCuts();
                shortCutsModel.Key = "M1";
                shortCutsModel.Value = "";
                list.Add(shortCutsModel);
                model.ShortCuts = list;
            }

            // 检查结果调阅地址
            if (GetFromConfigTable("ExamAddress", configList) != "")
            {
                model.ExamAddress = GetFromConfigTable("ExamAddress", configList);
            }

            // 病历病程调阅地址
            if (GetFromConfigTable("DocumentAddress", configList) != "")
            {
                model.DocumentAddress = GetFromConfigTable("DocumentAddress", configList);
            }

            // 麻醉交班用药配置
            if (GetFromConfigTable("AnesShiftDrugList", configList) != "")
            {
                model.AnesShiftDrugList = GetFromConfigTable("AnesShiftDrugList", configList);
            }

            // 麻醉交班急诊患者显示行数配置
            if (GetFromConfigTable("AnesShiftEmergencyPatCount", configList) != "")
            {
                model.AnesShiftEmergencyPatCount = Convert.ToDecimal(GetFromConfigTable("AnesShiftEmergencyPatCount", configList));
            }

            return model;

        }
        public int ModifyMedConfigSet(MED_CONFIGSET medconfig)
        {


            int result = 0;

            List<MED_CONFIG> configList = dapper.Set<MED_CONFIG>().Select();
            List<MED_CONFIG> newconfigList = new List<MED_CONFIG>();

            PropertyInfo[] propertys = medconfig.GetType().GetProperties();
            foreach (PropertyInfo p in propertys)
            {
                string key = p.Name;
                string value = p.GetValue(medconfig, null) == null ? "" : p.GetValue(medconfig, null).ToString();

                if (key == "PostPDF_Names")
                {
                    value = "";
                    string[] values = (string[])p.GetValue(medconfig, null);
                    foreach (var item in values)
                    {
                        value += item + ",";
                    }
                }
                if (key == "DocNameCheckList")
                {
                    value = "";
                    string[] values = (string[])p.GetValue(medconfig, null);
                    foreach (var item in values)
                    {
                        value += item + ",";
                    }
                }
                if (key == "ShortCuts")
                {
                    value = "";

                    List<ShortCuts> list = (List<ShortCuts>)p.GetValue(medconfig, null);
                    foreach (var item in list)
                    {
                        if (item.Key != "")
                            value += item.Key.ToUpper() + ":" + item.Value + ";";
                    }
                }
                if (configList.Where(x => x.PARAKEY == key).Count() > 0)
                {
                    foreach (var item in configList)
                    {
                        if (item.PARAKEY == key)
                        {
                            item.PARAVALUE = (new UnicodeEncoding()).GetBytes(value);
                        }
                    }
                }
                else
                {
                    MED_CONFIG config = new MED_CONFIG();
                    config.PARAKEY = key;
                    config.PARAVALUE = (new UnicodeEncoding()).GetBytes(value);
                    newconfigList.Add(config);
                }
            }
            result = dapper.Set<MED_CONFIG>().Insert(newconfigList) > 0 ? 1 : 0;
            dapper.SaveChanges();
            result = dapper.Set<MED_CONFIG>().Update(configList) > 0 ? 1 : 0;
            dapper.SaveChanges();
            return result;


        }

        /// <summary>
        /// 查找第三方接口链接路径配置
        /// </summary>
        /// <returns></returns>
        public List<MED_INTERFACE_DETAIL> GetInterfaceDetailList()
        {
            return dapper.Set<MED_INTERFACE_DETAIL>().Select();
        }

        /// <summary>
        /// 保存第三方接口链接路径配置
        /// </summary>
        /// <param name="interfaceDetailList"></param>
        /// <returns></returns>
        public int SaveInterfaceDetailData(List<MED_INTERFACE_DETAIL> interfaceDetailList)
        {
            int result = 0;

            foreach (var item in interfaceDetailList)
            {
                if (string.IsNullOrEmpty(item.INT_TYPE.ToString()))
                {
                    result = 2;
                    break;
                }
                else if (string.IsNullOrEmpty(item.INT_NAME))
                {
                    result = 3;
                    break;
                }
                else if (string.IsNullOrEmpty(item.INT_ADDRESS))
                {
                    result = 4;
                    break;
                }
            }

            if (result == 0)
            {
                dapper.Set<MED_INTERFACE_DETAIL>().Delete();

                if (interfaceDetailList.Count > 0)
                {
                    result = dapper.Set<MED_INTERFACE_DETAIL>().Insert(interfaceDetailList) > 0 ? 1 : 0;
                }
                else
                {
                    result = 1;
                }
                dapper.SaveChanges();
            }

            return result;
        }

        public string GetFromConfigTable(string key, List<MED_CONFIG> configTable)
        {
            if (!string.IsNullOrEmpty(key) && configTable != null)
            {
                var configRow = configTable.FirstOrDefault(x => x.PARAKEY == key);
                if (configRow != null && configRow.PARAVALUE != null && configRow.PARAVALUE.Length != 0)
                {
                    // string ret = StringHelper.Arr2Str(configRow.PARAVALUE);
                    string ret = (new UnicodeEncoding()).GetString(configRow.PARAVALUE, 0, configRow.PARAVALUE.Length);
                    if (ret == "�") ret = string.Empty;
                    return ret;
                }
                else
                {
                    return string.Empty;
                }
            }
            return null;
        }
        #endregion

        #region 麻醉方法归类配置
        /// <summary>
        /// 获取麻醉自定义字典
        /// </summary>
        /// <returns></returns>
        public string GetAnesMethodClass()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"[");
            var configs = dapper.Set<MED_ANESTHESIA_CONFIG>().Select();

            var collection = from l in configs.OrderBy(p => p.ITEM_PARENTID).ThenBy(p => p.ITEM_ID)
                             group l by l.ITEM_PARENTID into g
                             select new
                             {
                                 key = g.Key,
                                 val = g
                             };
            Dictionary<int, List<MED_ANESTHESIA_CONFIG>> dic = new Dictionary<int, List<MED_ANESTHESIA_CONFIG>>();
            foreach (var item in collection)
                dic.Add(item.key, item.val.ToList());
            RecursionConfig(sb, 0, dic);
            sb.Append(@"]");
            return sb.ToString();
        }
        private void RecursionConfig(StringBuilder sb, int key, Dictionary<int, List<MED_ANESTHESIA_CONFIG>> dic)
        {
            if (!dic.Keys.Contains(key))
                return;

            List<MED_ANESTHESIA_CONFIG> collection = dic[key];
            if (key != 0)
            {
                sb.Append(@",""children"": [");
            }
            int i = 0;
            foreach (var item in collection)
            {
                i++;
                sb.Append(@"{");
                sb.AppendFormat(@"""label"":""{0}"",""id"":""{1}"",""ITEM_TYPE"":""{2}""", item.ITEM_VALUE, item.ITEM_ID, item.ITEM_TYPE);
                RecursionConfig(sb, item.ITEM_ID, dic);
                sb.Append(@"}");
                if (i != collection.Count) { sb.Append(","); }
            }
            if (key != 0)
            {
                sb.Append("]");
            }
        }
        /// <summary>
        /// 获取未被麻醉自定义字典使用的麻醉名称
        /// </summary>
        /// <param name="item">对象</param>
        /// <returns></returns>
        public List<string> GetAnesMethodOptions(int ITEM_PARENTID)
        {
            List<string> result = new List<string>();
            string sql = sqlDict.GetSQLByKey("GetAnesMethodOptions");
            return dapper.Query<string>(sql);
        }
        /// <summary>
        /// 麻醉自定义字典添加数据
        /// </summary>
        /// <param name="item">对象</param>
        /// <returns></returns>
        public string AddAnesMethodClass(MED_ANESTHESIA_CONFIG item)
        {
            if (item.ITEM_PARENTID == 0)
            {
                List<MED_ANESTHESIA_CONFIG> hasList = dapper.Set<MED_ANESTHESIA_CONFIG>().Select(x => x.ITEM_PARENTID == 0 && x.ITEM_TYPE == item.ITEM_TYPE);
                if (hasList.Count > 0)
                {
                    return "类别码已存在";
                }
            }

            List<MED_ANESTHESIA_CONFIG> list = dapper.Set<MED_ANESTHESIA_CONFIG>().Select();
            if (list.Count > 0)
            {
                item.ITEM_ID = list.Select(x => x.ITEM_ID).Max() + 1;
            }
            else
            {
                item.ITEM_ID = 1;
            }
            bool result = true;
            if (item.ITEM_VALUE != "")
            {
                result = dapper.Set<MED_ANESTHESIA_CONFIG>().Insert(item);
            }
            else
            {
                List<MED_ANESTHESIA_CONFIG> listAddConfig = new List<MED_ANESTHESIA_CONFIG>();
                for (int i = 0; i < item.TEMP_ITEM_VALUE.Length; i++)
                {
                    listAddConfig.Add(new MED_ANESTHESIA_CONFIG
                    {
                        ITEM_ID = item.ITEM_ID + i,
                        ITEM_PARENTID = item.ITEM_PARENTID,
                        ITEM_TYPE = item.ITEM_TYPE,
                        ITEM_VALUE = item.TEMP_ITEM_VALUE[i]
                    });
                }
                result = dapper.Set<MED_ANESTHESIA_CONFIG>().Insert(listAddConfig) > 0 ? true : false;
            }
            dapper.SaveChanges();
            if (result == true)
            {
                return string.Empty;
            }
            else
            {
                return "保存失败";
            }
        }
        /// <summary>
        /// 麻醉自定义字典删除数据
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public string DeletedAnesMethodClass(int id)
        {
            var result = dapper.Execute(string.Format("DELETE FROM MED_ANESTHESIA_CONFIG C WHERE C.ITEM_ID IN (SELECT ITEM_ID FROM MED_ANESTHESIA_CONFIG START WITH ITEM_ID = {0} CONNECT BY PRIOR ITEM_ID = ITEM_PARENTID)", id)) > 0;
            if (result == true)
            {
                dapper.SaveChanges();
                return string.Empty;
            }
            else
            {
                return "删除失败";
            }
        }
        #endregion
        #endregion

        #region 个人模版路径
        /// <summary>
        /// 获取模版菜单列表
        /// </summary>
        /// <returns></returns>
        public IList<MED_TEMPLET_MENU> GetTempletMenu(string Create_By)
        {
            string sql = "SELECT A.ANESTHESIA_METHOD,A.TEMPLET_NAME FROM MED_ANESTHESIA_EVENT_TEMPLET A where Create_By='" + Create_By + "' or  Create_By ='公用' GROUP BY A.ANESTHESIA_METHOD,A.TEMPLET_NAME";
            List<MED_TEMPLET_MENU> list = dapper.Query<MED_TEMPLET_MENU>(sql, null);
            return list;
        }

        /// <summary>
        /// 获取模版菜单列表
        /// </summary>
        /// <returns></returns>
        public IList<MED_TEMPLET_MENU> GetTempletMenu(string Create_By, string TempletClass)
        {
            string sql = "SELECT A.ANESTHESIA_METHOD,A.TEMPLET_NAME FROM MED_ANESTHESIA_EVENT_TEMPLET A where (Create_By='" + Create_By + "' or  Create_By ='公用') AND TEMPLET_CLASS = '" + TempletClass + "' GROUP BY A.ANESTHESIA_METHOD,A.TEMPLET_NAME";
            List<MED_TEMPLET_MENU> list = dapper.Query<MED_TEMPLET_MENU>(sql, null);
            return list;
        }


        public IList<MED_ANESTHESIA_EVENT_TEMPLET> GetTempletDetailList(MED_ANESTHESIA_EVENT_TEMPLET model)
        {
            string sql = @"SELECT B.EVENT_CLASS_NAME,A.*
                        FROM MED_ANESTHESIA_EVENT_TEMPLET A
                        LEFT JOIN MED_EVENT_ITEM_CLASS_DICT B ON A.EVENT_ITEM_CLASS = B.EVENT_CLASS_CODE
                        WHERE TEMPLET_NAME = '" + model.TEMPLET_NAME + "'  AND ( A.CREATE_BY='" + model.CREATE_BY + "' or Create_By ='公用' ) " +
                        " AND A.ANESTHESIA_METHOD='" + model.ANESTHESIA_METHOD + "' AND A.TEMPLET_CLASS = '" + model.TEMPLET_CLASS + "' ORDER BY EVENT_ITEM_NO";
            List<MED_ANESTHESIA_EVENT_TEMPLET> list = dapper.Query<MED_ANESTHESIA_EVENT_TEMPLET>(sql, null);
            return list;
        }
        public int EditTemplete(int type, MED_ANESTHESIA_EVENT_TEMPLET model)
        {
            int result = 0;
            if (type == 0)   //新增
            {
                MED_ANESTHESIA_EVENT_TEMPLET newModel = new MED_ANESTHESIA_EVENT_TEMPLET();
                newModel.TEMPLET_NAME = model.TEMPLET_NAME;
                newModel.ANESTHESIA_METHOD = model.ANESTHESIA_METHOD;
                newModel.CREATE_BY = model.CREATE_BY;

                MED_ANESTHESIA_EVENT_TEMPLET obj = dapper.Set<MED_ANESTHESIA_EVENT_TEMPLET>().Select(p => p.ANESTHESIA_METHOD == model.ANESTHESIA_METHOD
                && p.CREATE_BY == model.CREATE_BY && p.TEMPLET_NAME == model.TEMPLET_NAME && p.TEMPLET_CLASS == model.TEMPLET_CLASS).OrderByDescending(x => x.EVENT_ITEM_NO).FirstOrDefault();
                int maxItemId = 0;
                if (obj != null)
                {
                    maxItemId = obj.EVENT_ITEM_NO;
                }
                newModel.EVENT_ITEM_NO = maxItemId + 1;
                newModel.EVENT_ITEM_NAME = model.EVENT_ITEM_NAME;
                newModel.EVENT_ITEM_CODE = model.EVENT_ITEM_CODE;
                newModel.EVENT_ITEM_CLASS = model.EVENT_ITEM_CLASS;
                newModel.EVENT_ITEM_SPEC = model.EVENT_ITEM_SPEC;
                newModel.DOSAGE = model.DOSAGE;
                newModel.DOSAGE_UNITS = model.DOSAGE_UNITS;
                newModel.ADMINISTRATOR = model.ADMINISTRATOR;
                newModel.TEMPLET_CLASS = model.TEMPLET_CLASS;
                if (model.DURATIVE == null || model.DURATIVE == 0)
                {
                    newModel.DURATIVE_INDICATOR = 0;
                }
                else
                {
                    newModel.DURATIVE_INDICATOR = 1;
                }

                newModel.METHOD = model.METHOD;
                newModel.PERFORM_SPEED = model.PERFORM_SPEED;
                newModel.SPEED_UNIT = model.SPEED_UNIT;
                newModel.CONCENTRATION = model.CONCENTRATION;
                newModel.CONCENTRATION_UNIT = model.CONCENTRATION_UNIT;
                newModel.START_AFTER_INPUT = model.START_AFTER_INPUT;
                newModel.DURATIVE = model.DURATIVE;
                result = dapper.Set<MED_ANESTHESIA_EVENT_TEMPLET>().Insert(newModel) ? 1 : 0;
            }
            else  //修改
            {
                MED_ANESTHESIA_EVENT_TEMPLET newModel = dapper.Set<MED_ANESTHESIA_EVENT_TEMPLET>().Single(d => d.ANESTHESIA_METHOD == model.ANESTHESIA_METHOD && d.TEMPLET_NAME == model.TEMPLET_NAME
                && d.CREATE_BY == model.CREATE_BY && d.EVENT_ITEM_NO == model.EVENT_ITEM_NO);
                newModel.EVENT_ITEM_NAME = model.EVENT_ITEM_NAME;
                newModel.EVENT_ITEM_CODE = model.EVENT_ITEM_CODE;
                newModel.EVENT_ITEM_CLASS = model.EVENT_ITEM_CLASS;
                newModel.EVENT_ITEM_SPEC = model.EVENT_ITEM_SPEC;
                newModel.DOSAGE = model.DOSAGE;
                newModel.DOSAGE_UNITS = model.DOSAGE_UNITS;
                newModel.ADMINISTRATOR = model.ADMINISTRATOR;
                if (model.DURATIVE == null || model.DURATIVE == 0)
                {
                    newModel.DURATIVE_INDICATOR = 0;
                }
                else
                {
                    newModel.DURATIVE_INDICATOR = 1;
                }
                newModel.METHOD = model.METHOD;
                newModel.PERFORM_SPEED = model.PERFORM_SPEED;
                newModel.SPEED_UNIT = model.SPEED_UNIT;
                newModel.CONCENTRATION = model.CONCENTRATION;
                newModel.CONCENTRATION_UNIT = model.CONCENTRATION_UNIT;
                newModel.START_AFTER_INPUT = model.START_AFTER_INPUT;
                newModel.DURATIVE = model.DURATIVE;
                result = dapper.Set<MED_ANESTHESIA_EVENT_TEMPLET>().Update(newModel, null, d => d.ANESTHESIA_METHOD == model.ANESTHESIA_METHOD && d.TEMPLET_NAME == model.TEMPLET_NAME
                  && d.CREATE_BY == model.CREATE_BY && d.EVENT_ITEM_NO == model.EVENT_ITEM_NO) > 0 ? 1 : 0;
            }
            dapper.SaveChanges();
            return result;
        }

        public int DeleteTempleteEvent(int type, MED_ANESTHESIA_EVENT_TEMPLET model)
        {
            int result = 0;

            if (model == null)
            {
                return -1;
            }
            else
            {
                if (type == 0)
                {
                    //删除模版事件
                    result = dapper.Set<MED_ANESTHESIA_EVENT_TEMPLET>().Delete(d => d.ANESTHESIA_METHOD == model.ANESTHESIA_METHOD && d.TEMPLET_NAME == model.TEMPLET_NAME
                    && d.CREATE_BY == model.CREATE_BY && d.EVENT_ITEM_NO == model.EVENT_ITEM_NO && d.TEMPLET_CLASS == model.TEMPLET_CLASS);
                }
                else
                {
                    //删除模版
                    result = dapper.Set<MED_ANESTHESIA_EVENT_TEMPLET>().Delete(d => d.ANESTHESIA_METHOD == model.ANESTHESIA_METHOD && d.TEMPLET_NAME == model.TEMPLET_NAME
                    && d.CREATE_BY == model.CREATE_BY && d.TEMPLET_CLASS == model.TEMPLET_CLASS);
                }
                dapper.SaveChanges();
                return result;
            }
        }
        #endregion

        #region HIS同步

        ///<summary>
        /// 同步单病人基本信息及住院信息
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        public string SyncPatientInfoAndInHospital(string patientID)
        {
            if (!string.IsNullOrEmpty(patientID))
            {
                InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
                paramIn.Code = "PAT101";
                paramIn.App = "手麻系统";
                paramIn.OperatorBase.Operator = "操作人";
                paramIn.OperatorBase.OperatorDept = "操作人所属科室";

                paramIn.Patient.PatientId = patientID;
                return InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson(), AppSettings.InterFacePath);
            }
            else
            {
                return "空的患者ID";
            }


        }

        /// <summary>
        /// 同步单病人基本信息及住院信息
        /// </summary>
        /// <param name="inpno">住院号</param>
        /// <returns></returns>
        public string SyncPatientInfoAndInHospitalByInpNo(string inpNo)
        {
            if (!string.IsNullOrEmpty(inpNo))
            {
                InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
                paramIn.Code = "PAT102";
                paramIn.App = "手麻系统";
                paramIn.OperatorBase.Operator = "操作人";
                paramIn.OperatorBase.OperatorDept = "操作人所属科室";

                paramIn.Patient.InpNo = inpNo;
                string ret = InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson(), AppSettings.InterFacePath);
                return ret;
            }
            else
            {
                return "空的住院号";
            }
        }

        /// <summary>
        /// 回传手术状态HIS203
        /// </summary>
        public string SyncHIS203(string patientID, int visitID, int operID)
        {
            if (!string.IsNullOrEmpty(patientID))
            {
                InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
                paramIn.Code = "OPER502W";
                paramIn.App = "手麻系统";
                paramIn.Patient.PatientId = patientID;
                paramIn.Patient.VisitId = visitID;
                paramIn.Operation.OperId = operID;
                string ret = InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson(), AppSettings.InterFacePath);
                return ret;
            }
            else
            {
                return "空的患者ID";
            }
        }

        /// <summary>
        /// 文书上传OPER505W
        /// </summary>
        public string SyncOPER505W(MED_EMR_ARCHIVE_DETIAL mead)
        {
            if (!string.IsNullOrEmpty(mead.PATIENT_ID))
            {
                InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
                paramIn.Code = "OPER505W";
                paramIn.App = "手麻系统";
                paramIn.Patient.PatientId = mead.PATIENT_ID;
                paramIn.Patient.VisitId = mead.VISIT_ID;
                paramIn.EmrDocUpLoad.MrClass = mead.MR_CLASS;
                paramIn.EmrDocUpLoad.MrSubClass = mead.MR_SUB_CLASS;
                paramIn.EmrDocUpLoad.ArchiveKey = Convert.ToDecimal(mead.ARCHIVE_KEY);
                paramIn.EmrDocUpLoad.ArchiveTimes = mead.ARCHIVE_TIMES;
                paramIn.EmrDocUpLoad.EmrFileIndex = mead.EMR_FILE_INDEX;
                paramIn.EmrDocUpLoad.EmrFileName = mead.EMR_FILE_NAME;

                string ret = InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson(), AppSettings.InterFacePath);
                return ret;
            }
            else
            {
                return "空的患者ID";
            }
        }

        /// <summary>
        /// 同步患者的LIS检验信息
        /// </summary>
        /// <param name="patientID">patientID</param>
        /// <param name="visitID">visitID</param>
        /// <returns></returns>
        public string SyncWrite_LIS101(string patientID, int visitID)
        {
            if (!string.IsNullOrEmpty(patientID))
            {
                InterFaceV5.ParamInputDomain paramIn = new InterFaceV5.ParamInputDomain();
                paramIn.Code = "LIS101";
                paramIn.App = "排班系统";

                paramIn.Patient.PatientId = patientID;
                paramIn.Patient.VisitId = visitID;
                return InterFaceV5.InterFaceV5.SysMsgExchange(paramIn.ToJson(), AppSettings.InterFacePath);
            }
            else
            {
                return "空的患者ID";
            }
        }


        /// <summary>
        /// 获取检验信息主信息
        /// </summary>
        public List<MED_LAB_TEST_MASTER> GetMedLabTestMaster(string patientId, int visitId)
        {
            List<MED_LAB_TEST_MASTER> result = dapper.Set<MED_LAB_TEST_MASTER>().
                                                      Select(x => x.PATIENT_ID.Equals(patientId) && x.VISIT_ID == visitId).
                                                      OrderByDescending(x => x.SPCM_RECEIVED_DATE_TIME).ToList();
            return result;
        }

        /// <summary>
        /// 获取检验信息明细
        /// </summary>
        public List<MED_LAB_RESULT> GetMedLabResult(string testNo)
        {
            List<MED_LAB_RESULT> result = dapper.Set<MED_LAB_RESULT>().Select(x => x.TEST_NO.Equals(testNo)).ToList();
            return result;
        }

        /// <summary>
        /// 根据患者ID获取检验结果明细
        /// </summary>
        public List<MED_LAB_RESULT> GetMedLabResult(string patientId, int visitId)
        {
            string strSql = string.Format(@"SELECT A.* FROM MED_LAB_RESULT A
                                            LEFT JOIN MED_LAB_TEST_MASTER B ON A.TEST_NO=B.TEST_NO
                                            WHERE B.PATIENT_ID='{0}' AND B.VISIT_ID={1}", patientId, visitId);
            List<MED_LAB_RESULT> result = dapper.Query<MED_LAB_RESULT>(strSql, null);
            return result;
        }


        public List<dynamic> GetPatientInfo(string patientId, int visitId, int operId) {
            string strSql = string.Format(@"select v.NAME,v.SEX,v.AGE,V.INP_NO,v.DEPT_NAME,v.bed_no,v.ASA,v.OPER_POSITION,v.EMERGENCY_IND,v.AnesMethod,v.DIAG_BEFORE_OPERATION,m.diag_after_operation,
v.OPERATION_NAME,b.OPERATION_NAME as OPERATION_NAME_PLAN,v.SURGEON,v.AnesDoctor,v.Nurse,a.height,a.blood_type,v.PATIENT_ID ,v.VISIT_ID,v.OPER_ID,V.SCHEDULED_DATE_TIME
 from v_operation_master_v2 v
 left join med_operation_master m on v.PATIENT_ID = m.patient_id and v.VISIT_ID=m.visit_id and m.oper_id = m.oper_id
 left join MED_ANESTHESIA_PLAN_PMH a on v.PATIENT_ID = a.patient_id and v.VISIT_ID=a.visit_id and m.oper_id = a.oper_id
 left join MED_ANESTHESIA_PLAN b on v.PATIENT_ID = b.patient_id and v.VISIT_ID=b.visit_id and m.oper_id = b.oper_id

                                            WHERE v.PATIENT_ID='{0}' AND v.VISIT_ID={1} and v.oper_id = {2}", patientId, visitId,operId);
            List<dynamic> result = dapper.Query<dynamic>(strSql, null);
            return result;
        }
        public List<dynamic> GetPatientDocument(string patientId, int visitId, int operId)
        {
            string strSql = string.Format(@"
select patient_id,
                    visit_id,
                    archive_key Oper_Id,Mr_Sub_Class, archive_key Oper_Id,Mr_Sub_Class,a.archive_access||a.emr_file_name as DOCPATH
               from Med_Emr_Archive_Detial a
                                            WHERE  a.archive_status = '已归档' and a.patient_id='{0}' AND a.VISIT_ID={1} and a.archive_key = '{2}'", patientId, visitId, operId);
            List<dynamic> result = dapper.Query<dynamic>(strSql, null);
            return result;
        }
        
        #endregion



        #region 工具
        public int SaveDictDataByTableName(string tableName)
        {
            int result = 0;

            if (tableName.ToUpper() == "MED_OPERATION_DICT".ToUpper())//手术名称
            {
                List<MED_OPERATION_DICT> data = dapper.Set<MED_OPERATION_DICT>().Select();

                foreach (var item in data)
                {
                    if (string.IsNullOrEmpty(item.INPUT_CODE) && !string.IsNullOrEmpty(item.OPER_NAME))
                    {
                        string pinyin = StringManage.GetPYString(item.OPER_NAME);
                        if (pinyin.Length > 40)
                        {
                            pinyin = pinyin.Substring(0, 40);
                        }
                        else
                        {
                            item.INPUT_CODE = pinyin;
                        }
                    }

                }

                result = dapper.Set<MED_OPERATION_DICT>().Update(data) > 0 ? 1 : 0;

            }
            else if (tableName.ToUpper() == "MED_DIAGNOSIS_DICT".ToUpper())//手术诊断
            {
                List<MED_DIAGNOSIS_DICT> data1 = dapper.Set<MED_DIAGNOSIS_DICT>().Select();

                foreach (var item in data1)
                {
                    if (string.IsNullOrEmpty(item.INPUT_CODE) && !string.IsNullOrEmpty(item.DIAGNOSIS_NAME))
                    {
                        string pinyin = StringManage.GetPYString(item.DIAGNOSIS_NAME);
                        if (pinyin.Length > 40)
                        {
                            pinyin = pinyin.Substring(0, 40);
                        }
                        else
                        {
                            item.INPUT_CODE = pinyin;
                        }

                    }
                }

                result = dapper.Set<MED_DIAGNOSIS_DICT>().Update(data1) > 0 ? 1 : 0;
            }
            else if (tableName.ToUpper() == "MED_ANESTHESIA_DICT".ToUpper())//麻醉方法
            {
                List<MED_ANESTHESIA_DICT> data2 = dapper.Set<MED_ANESTHESIA_DICT>().Select();

                foreach (var item in data2)
                {
                    if (string.IsNullOrEmpty(item.INPUT_CODE) && !string.IsNullOrEmpty(item.ANAESTHESIA_NAME))
                    {
                        string pinyin = StringManage.GetPYString(item.ANAESTHESIA_NAME);
                        if (pinyin.Length > 40)
                        {
                            pinyin = pinyin.Substring(0, 40);
                        }
                        else
                        {
                            item.INPUT_CODE = pinyin;
                        }
                    }
                }

                result = dapper.Set<MED_ANESTHESIA_DICT>().Update(data2) > 0 ? 1 : 0;
            }

            dapper.SaveChanges();

            return result;

        }

        public int SaveDictDataByTableName(dynamic data)
        {
            int result = 0;

            result = dapper.Set<dynamic>().Update(data) > 0 ? 1 : 0;

            dapper.SaveChanges();

            return result;
        }
        #endregion
    }
}
