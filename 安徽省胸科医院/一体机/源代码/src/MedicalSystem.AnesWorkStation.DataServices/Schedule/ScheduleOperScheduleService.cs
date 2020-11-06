using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain.Origins;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Domain.ViewModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MedicalSystem.DataServices.WebApi;
using System.IO;
using System.Data;
using MedicalSystem.Common.FileManage;
using Newtonsoft.Json;
using MedicalSystem.Services;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    public interface IScheduleOperScheduleService
    {
        /// <summary>
        /// 获取手术间根据科室
        /// </summary>
        /// <returns></returns>
        IList<MED_OPERATING_ROOM> GetOperRoomByDeptCode(string DeptCode);

        /// <summary>
        /// 获取手术通知单信息
        /// </summary>
        /// <param name="ScheduleDateTime">手术时间</param>
        /// <returns></returns>
        dynamic GetOperNoticeList(DateTime ScheduleDateTime);

        /// <summary>
        /// 获取手术排班结果信息
        /// </summary>
        /// <param name="ScheduleDateTime">手术时间</param>
        /// <returns></returns>
        dynamic GetOperScheduleQueryList(DateTime ScheduleDateTime, string DeptCode, string Doctor);

        /// <summary>
        /// 获取排班表信息
        /// </summary>
        /// <param name="ScheduleDateTime">日期</param>
        /// <returns></returns>
        IList<MED_OPERATION_SCHEDULE> GetOperList(DateTime ScheduleDateTime, string OperRoom);

        /// <summary>
        /// 获取手术信息信息
        /// </summary>
        /// <param name="operationSchedule"></param>
        /// <returns></returns>
        MED_OPERATION_SCHEDULE GetOperDetail(MED_OPERATION_SCHEDULE operationSchedule);

        /// <summary>
        /// 更新手术排班信息
        /// </summary>
        /// <param name="operationSchedule">手术信息</param>
        /// <returns></returns>
        int UpdateOperationSchedule(MED_OPERATION_SCHEDULE operationSchedule, Func<MED_OPERATION_SCHEDULE, object> onlyFields = null);

        /// <summary>
        /// 更新手术排班信息
        /// </summary>
        /// <param name="operationScheduleList">手术信息列表</param>
        /// <param name="onlyFields">更新字段</param>
        /// <returns></returns>
        int UpdateOperationScheduleList(List<MED_OPERATION_SCHEDULE> operationScheduleList, Func<MED_OPERATION_SCHEDULE, object> onlyFields = null);

        /// <summary>
        /// 提交手术信息
        /// </summary>
        /// <param name="operationScheduleList"></param>
        /// <returns></returns>
        List<MED_OPERATION_SCHEDULE> SubmitOperationScheduleList(List<MED_OPERATION_SCHEDULE> operationScheduleList);

        /// <summary>
        /// 手术取消
        /// </summary>
        /// <param name="operationCanceled"></param>
        /// <returns></returns>
        bool CancelOperationSchedule(OperCancelAndDetailEntity operationCanceled);

        /// <summary>
        /// 是否允许手术撤销
        /// </summary>
        /// <param name="operationSchedule"></param>
        /// <returns></returns>
        MED_OPERATION_SCHEDULE IsCanRevokedOpertionSchedule(MED_OPERATION_SCHEDULE operationSchedule);

        /// <summary>
        /// 手术撤销
        /// </summary>
        /// <param name="operationSchedule"></param>
        /// <returns></returns>
        int RevokedOpertionSchedule(MED_OPERATION_SCHEDULE operationSchedule);

        /// <summary>
        /// 获取医嘱信息
        /// </summary>
        /// <param name="patientID">patientID</param>
        /// <param name="visitID">visitID</param>
        /// <returns></returns>
        IList<dynamic> GetMedOrdersList(string patientID, int visitID);

        /// <summary>
        /// 导出EXCEL
        /// </summary>
        /// <param name="reportMonth">月份</param>
        /// <param name="reportName">模块名字</param>
        /// <param name="exprotExcelColumns">导出的列</param>
        /// <returns></returns>
        string ExportExcel(object reportMonth, string reportName, dynamic exprotExcelColumns);

    }
    public class ScheduleOperScheduleService : BaseService<ScheduleOperScheduleService>, IScheduleOperScheduleService
    {
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected ScheduleOperScheduleService()
            : base() { }

        public IScheduleSyncInfoService SyncInfoService;
        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public ScheduleOperScheduleService(IDapperContext context, IScheduleSyncInfoService syncInfoService)
            : base(context)
        {
            SyncInfoService = syncInfoService;
        }

        /// <summary>
        /// 获取手术通知单信息
        /// </summary>
        /// <param name="ScheduleDateTime">手术时间</param>
        /// <returns></returns>
        public dynamic GetOperNoticeList(DateTime ScheduleDateTime)
        {
            string sql = sqlDict.GetSQLByKey("GetOperNoticeList");
            return dapper.Set<dynamic>().Query(sql, new { StartDateTime = ScheduleDateTime, ENDDateTime = ScheduleDateTime.AddDays(1) });
        }

        /// <summary>
        /// 获取手术排班结果信息
        /// </summary>
        /// <param name="ScheduleDateTime">手术时间</param>
        /// <returns></returns>
        public dynamic GetOperScheduleQueryList(DateTime ScheduleDateTime, string DeptCode, string Doctor)
        {
            string sql = sqlDict.GetSQLByKey("GetOperScheduleQueryList");
            return dapper.Set<dynamic>().Query(sql, new { StartDateTime = ScheduleDateTime, ENDDateTime = ScheduleDateTime.AddDays(1), OPER_ROOM = DeptCode, DOCTOR = Doctor });
        }

        /// <summary>
        /// 获取排班数据
        /// </summary>
        /// <param name="ScheduleDateTime"></param>
        /// <param name="DeptCode"></param>
        /// <returns></returns>
        public IList<MED_OPERATION_SCHEDULE> GetOperList(DateTime ScheduleDateTime, string OperRoom)
        {
            string sql = sqlDict.GetSQLByKey("GetOperList");
            return dapper.Set<MED_OPERATION_SCHEDULE>().Query(sql, new { StartDateTime = ScheduleDateTime, ENDDateTime = ScheduleDateTime.AddDays(1), OperRoom = OperRoom });
        }

        /// <summary>
        /// 获取手术信息信息
        /// </summary>
        /// <param name="operationSchedule"></param>
        /// <returns></returns>
        public MED_OPERATION_SCHEDULE GetOperDetail(MED_OPERATION_SCHEDULE operationSchedule)
        {
            string sql = sqlDict.GetSQLByKey("GetOperDetail");
            return dapper.Set<MED_OPERATION_SCHEDULE>().Query(sql, new { PatientID = operationSchedule.PATIENT_ID, VisitID = operationSchedule.VISIT_ID, ScheduleID = operationSchedule.SCHEDULE_ID }).FirstOrDefault();
        }

        /// <summary>
        /// 获取手术间根据科室
        /// </summary>
        /// <returns></returns>
        public IList<MED_OPERATING_ROOM> GetOperRoomByDeptCode(string DeptCode)
        {
            string sql = sqlDict.GetSQLByKey("GetOperRoomByDeptCode");
            return dapper.Set<MED_OPERATING_ROOM>().Query(sql, new { DEPT_CODE = DeptCode });
        }

        /// <summary>
        /// 更新手术排班信息
        /// </summary>
        /// <param name="operationSchedule">手术信息</param>
        /// <returns></returns>
        public int UpdateOperationSchedule(MED_OPERATION_SCHEDULE operationSchedule, Func<MED_OPERATION_SCHEDULE, object> onlyFields = null)
        {
            int result = dapper.Set<MED_OPERATION_SCHEDULE>().Update(operationSchedule, onlyFields);
            dapper.SaveChanges();
            return result;
        }

        /// <summary>
        /// 更新手术排班信息
        /// </summary>
        /// <param name="operationScheduleList">手术信息列表</param>
        /// <param name="onlyFields">更新字段</param>
        /// <returns></returns>
        public int UpdateOperationScheduleList(List<MED_OPERATION_SCHEDULE> operationScheduleList, Func<MED_OPERATION_SCHEDULE, object> onlyFields = null)
        {
            int result = dapper.Set<MED_OPERATION_SCHEDULE>().Update(operationScheduleList, onlyFields);
            dapper.SaveChanges();
            return result;
        }

        /// <summary>
        /// 提交手术信息
        /// </summary>
        /// <param name="operationScheduleList"></param>
        /// <returns></returns>
        public List<MED_OPERATION_SCHEDULE> SubmitOperationScheduleList(List<MED_OPERATION_SCHEDULE> operationScheduleList)
        {
            List<MED_OPERATION_SCHEDULE> returnOperationScheduleList = new List<MED_OPERATION_SCHEDULE>();
            string sql_GetMaxOperID = sqlDict.GetSQLByKey("GetMaxOperID");
            string sql_GetMaxOperationNo = sqlDict.GetSQLByKey("GetMaxOperationNo");
            foreach (MED_OPERATION_SCHEDULE item in operationScheduleList)
            {
                item.OPER_ID = getMaxOperId(sql_GetMaxOperID, item);
                if (item.OPER_STATUS_CODE == 2)
                {
                    Logger.InfoFormat("{0}手术提交2：{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"), JsonConvert.SerializeObject(item));
                    MED_OPERATION_SCHEDULE returnobj = setOperationSubmit(sql_GetMaxOperationNo, item);
                    if (returnobj != null)
                    {
                        returnOperationScheduleList.Add(returnobj);
                    }
                }
                else
                {
                    MED_OPERATION_SCHEDULE dbSCHEDULE = dapper.Set<MED_OPERATION_SCHEDULE>().Single(item);
                    if ((dbSCHEDULE.NURSE_CONFIRM == 1 && item.ANES_CONFIRM == 1) || (dbSCHEDULE.ANES_CONFIRM == 1 && item.NURSE_CONFIRM == 1))
                    {
                        if (dbSCHEDULE.OPER_STATUS_CODE == 1)
                        {
                            item.NURSE_CONFIRM = 1;
                            item.ANES_CONFIRM = 1;
                            item.OPER_STATUS_CODE = 2;
                            Logger.InfoFormat("{0}手术提交：{1} 数据库中的{2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"), JsonConvert.SerializeObject(item), JsonConvert.SerializeObject(dbSCHEDULE));
                            MED_OPERATION_SCHEDULE returnobj = setOperationSubmit(sql_GetMaxOperationNo, item);
                            if (returnobj != null)
                            {
                                returnOperationScheduleList.Add(returnobj);
                            }
                        }
                        else
                        {
                            returnOperationScheduleList.Add(dbSCHEDULE);
                        }
                    }
                    else
                    {
                        int temp = 0;
                        if (dbSCHEDULE.ANES_CONFIRM == 0 && item.ANES_CONFIRM == 1)
                        {
                            temp = dapper.Set<MED_OPERATION_SCHEDULE>().Update(item, d => new { d.ANES_CONFIRM });
                        }
                        if (dbSCHEDULE.NURSE_CONFIRM == 0 && item.NURSE_CONFIRM == 1)
                        {
                            temp = dapper.Set<MED_OPERATION_SCHEDULE>().Update(item, d => new { d.NURSE_CONFIRM });
                        }
                        if (temp > 0)
                        {
                            dapper.SaveChanges();
                            returnOperationScheduleList.Add(item);
                        }
                    }
                }
                if (AppSettings.OpenHIS202)
                {
                    SyncInfoService.SyncWrite_OPER501W(item.PATIENT_ID, item.VISIT_ID, item.SCHEDULE_ID);
                }
            }
            return returnOperationScheduleList;
        }

        private MED_OPERATION_SCHEDULE setOperationSubmit(string sql_GetMaxOperationNo, MED_OPERATION_SCHEDULE item)
        {
            MED_OPERATION_SCHEDULE dbSCHEDULE = dapper.Set<MED_OPERATION_SCHEDULE>().Single(item);//判断收到已经提交
            if (dbSCHEDULE.OPER_STATUS_CODE == 1)  //实时判断，没提交才能判断
            {
                #region 获取MED_OPERATION_SCHEDULE_NAME表数据
                List<MED_OPERATION_SCHEDULE_NAME> scheduleNameItemList = dapper.Set<MED_OPERATION_SCHEDULE_NAME>().Select(d => d.PATIENT_ID == item.PATIENT_ID && d.VISIT_ID == item.VISIT_ID && d.SCHEDULE_ID == item.SCHEDULE_ID).OrderBy(d => d.OPER_NO).ToList<MED_OPERATION_SCHEDULE_NAME>();
                #endregion
                int OperationNo = GetMaxOperationNo(sql_GetMaxOperationNo, item);
                string tempOperationName = string.Empty;
                #region 向MED_OPERATION_NAME表插入数据
                List<MED_OPERATION_NAME> operNameItemList = new List<MED_OPERATION_NAME>();
                foreach (MED_OPERATION_SCHEDULE_NAME scheduleNameItem in scheduleNameItemList)
                {
                    MED_OPERATION_NAME operNameItem = new MED_OPERATION_NAME();
                    operNameItem.PATIENT_ID = scheduleNameItem.PATIENT_ID;
                    operNameItem.VISIT_ID = scheduleNameItem.VISIT_ID;
                    operNameItem.OPER_ID = item.OPER_ID;
                    operNameItem.OPER_NO = ++OperationNo;
                    operNameItem.OPER_NAME = scheduleNameItem.OPER_NAME;
                    operNameItem.OPER_CODE = scheduleNameItem.OPER_CODE;
                    operNameItem.OPER_SCALE = scheduleNameItem.OPER_SCALE;
                    operNameItem.WOUND_TYPE = scheduleNameItem.WOUND_TYPE;
                    operNameItem.RESERVED1 = scheduleNameItem.RESERVED1;
                    operNameItem.RESERVED2 = scheduleNameItem.RESERVED2;
                    operNameItem.RESERVED3 = scheduleNameItem.RESERVED3;
                    operNameItem.RESERVED4 = scheduleNameItem.RESERVED4;
                    operNameItemList.Add(operNameItem);
                    tempOperationName += "," + scheduleNameItem.RESERVED2 + scheduleNameItem.OPER_NAME;
                }
                dapper.Set<MED_OPERATION_NAME>().Insert(operNameItemList);
                #endregion
                tempOperationName = tempOperationName.TrimStart(',');
                #region 向MED_OPERATION_MASTER表插入数据
                MED_OPERATION_MASTER masterITEM = new MED_OPERATION_MASTER
                {
                    PATIENT_ID = item.PATIENT_ID,
                    VISIT_ID = item.VISIT_ID,
                    OPER_ID = Convert.ToInt32(item.OPER_ID),
                    HOSP_BRANCH = item.HOSP_BRANCH,
                    WARD_CODE = item.WARD_CODE,
                    DEPT_CODE = item.DEPT_CODE,
                    OPER_DEPT_CODE = item.OPER_DEPT_CODE,
                    OPER_ROOM = item.OPER_ROOM,
                    OPER_ROOM_NO = item.OPER_ROOM_NO,
                    SEQUENCE = item.SEQUENCE,
                    OPER_CLASS = item.OPER_CLASS,
                    DIAG_BEFORE_OPERATION = item.DIAG_BEFORE_OPERATION,
                    DIAG_AFTER_OPERATION = item.DIAG_BEFORE_OPERATION,
                    PATIENT_CONDITION = item.PATIENT_CONDITION,
                    OPER_SCALE = item.OPER_SCALE,
                    WOUND_TYPE = item.WOUND_TYPE,
                    ASA_GRADE = item.ASA_GRADE,
                    EMERGENCY_IND = item.EMERGENCY_IND,
                    OPER_SOURCE = item.OPER_SOURCE,
                    ISOLATION_IND = item.ISOLATION_IND,
                    INFECTED_IND = item.INFECTED_IND,
                    RADIATE_IND = item.RADIATE_IND,
                    SURGEON = item.SURGEON,
                    FIRST_OPER_ASSISTANT = item.FIRST_OPER_ASSISTANT,
                    SECOND_OPER_ASSISTANT = item.SECOND_OPER_ASSISTANT,
                    THIRD_OPER_ASSISTANT = item.THIRD_OPER_ASSISTANT,
                    FOURTH_OPER_ASSISTANT = item.FOURTH_OPER_ASSISTANT,
                    ANES_METHOD = item.ANES_METHOD,
                    ANES_DOCTOR = item.ANES_DOCTOR,
                    FIRST_ANES_ASSISTANT = item.FIRST_ANES_ASSISTANT,
                    SECOND_ANES_ASSISTANT = item.SECOND_ANES_ASSISTANT,
                    THIRD_ANES_ASSISTANT = item.THIRD_ANES_ASSISTANT,
                    FOURTH_ANES_ASSISTANT = item.FOURTH_ANES_ASSISTANT,
                    FIRST_ANES_NURSE = item.FIRST_ANES_NURSE,
                    SECOND_ANES_NURSE = item.SECOND_ANES_NURSE,
                    THIRD_ANES_NURSE = item.THIRD_ANES_NURSE,
                    CPB_DOCTOR = item.CPB_DOCTOR,
                    FIRST_CPB_ASSISTANT = item.FIRST_CPB_ASSISTANT,
                    SECOND_CPB_ASSISTANT = item.SECOND_CPB_ASSISTANT,
                    THIRD_CPB_ASSISTANT = item.THIRD_CPB_ASSISTANT,
                    FOURTH_CPB_ASSISTANT = item.FOURTH_CPB_ASSISTANT,
                    FIRST_OPER_NURSE = item.FIRST_OPER_NURSE,
                    SECOND_OPER_NURSE = item.SECOND_OPER_NURSE,
                    THIRD_OPER_NURSE = item.THIRD_OPER_NURSE,
                    FOURTH_OPER_NURSE = item.FOURTH_OPER_NURSE,
                    FIRST_SUPPLY_NURSE = item.FIRST_SUPPLY_NURSE,
                    SECOND_SUPPLY_NURSE = item.SECOND_SUPPLY_NURSE,
                    THIRD_SUPPLY_NURSE = item.THIRD_SUPPLY_NURSE,
                    FOURTH_SUPPLY_NURSE = item.FOURTH_SUPPLY_NURSE,
                    PACU_DOCTOR = item.PACU_DOCTOR,
                    FIRST_PACU_ASSISTANT = item.FIRST_PACU_ASSISTANT,
                    SECOND_PACU_ASSISTANT = item.SECOND_PACU_ASSISTANT,
                    FIRST_PACU_NURSE = item.FIRST_PACU_NURSE,
                    SECOND_PACU_NURSE = item.SECOND_PACU_NURSE,
                    REQ_DATE_TIME = item.REQ_DATE_TIME,
                    SCHEDULED_DATE_TIME = item.SCHEDULED_DATE_TIME,
                    OPER_POSITION = item.OPER_POSITION,
                    BED_NO = item.BED_NO,
                    OPERATION_NAME = tempOperationName,
                    SPECIAL_EQUIPMENT = item.SPECIAL_EQUIPMENT,
                    SPECIAL_INFECT = item.SPECIAL_INFECT,
                    OPER_STATUS_CODE = item.OPER_STATUS_CODE,
                    HIS_PATIENT_ID = item.HIS_PATIENT_ID,
                    HIS_VISIT_ID = item.HIS_VISIT_ID,
                    HIS_SCHEDULE_ID = item.HIS_SCHEDULE_ID,
                    HIS_OPER_STATUS = item.HIS_OPER_STATUS,
                    MEMO = item.NOTES_ON_OPERATION
                };

                bool flag = dapper.Set<MED_OPERATION_MASTER>().Insert(masterITEM);
                #endregion
                item.OPERATION_NAME = tempOperationName;
                dapper.Set<MED_OPERATION_SCHEDULE>().Update(item, d => new { d.ANES_CONFIRM, d.NURSE_CONFIRM, d.OPER_STATUS_CODE, d.OPER_ID, d.OPERATION_NAME, d.ANES_DOCTOR });
                if (flag)
                {
                    //确认成功后，从visit表中往plan表中写入手术名称，身高体重数据
                    MED_ANESTHESIA_PLAN anesPlan = dapper.Set<MED_ANESTHESIA_PLAN>().Single(d => d.PATIENT_ID == masterITEM.PATIENT_ID && d.VISIT_ID == masterITEM.VISIT_ID && d.OPER_ID == masterITEM.OPER_ID);
                    if (anesPlan == null)
                    {
                        anesPlan = new MED_ANESTHESIA_PLAN();
                        anesPlan.PATIENT_ID = masterITEM.PATIENT_ID;
                        anesPlan.VISIT_ID = masterITEM.VISIT_ID;
                        anesPlan.OPER_ID = masterITEM.OPER_ID;
                    }
                    if (!string.IsNullOrEmpty(masterITEM.OPERATION_NAME))
                    {
                        anesPlan.OPERATION_NAME = masterITEM.OPERATION_NAME;
                    }
                    dapper.Set<MED_ANESTHESIA_PLAN>().Save(anesPlan, d => d.PATIENT_ID == masterITEM.PATIENT_ID && d.VISIT_ID == masterITEM.VISIT_ID && d.OPER_ID == masterITEM.OPER_ID);

                    MED_ANESTHESIA_PLAN_PMH anesPlanPmh = dapper.Set<MED_ANESTHESIA_PLAN_PMH>().Single(d => d.PATIENT_ID == masterITEM.PATIENT_ID && d.VISIT_ID == masterITEM.VISIT_ID && d.OPER_ID == masterITEM.OPER_ID);
                    MED_PAT_VISIT patVisit = dapper.Set<MED_PAT_VISIT>().Single(d => d.PATIENT_ID == masterITEM.PATIENT_ID && d.VISIT_ID == masterITEM.VISIT_ID);
                    if (anesPlanPmh == null)
                    {
                        anesPlanPmh = new MED_ANESTHESIA_PLAN_PMH();
                        anesPlanPmh.PATIENT_ID = masterITEM.PATIENT_ID;
                        anesPlanPmh.VISIT_ID = masterITEM.VISIT_ID;
                        anesPlanPmh.OPER_ID = masterITEM.OPER_ID;
                        if (patVisit != null)
                        {
                            anesPlanPmh.HEIGHT = patVisit.BODY_HEIGHT.HasValue ? patVisit.BODY_HEIGHT.Value.ToString() : "";
                            anesPlanPmh.WEIGHT = patVisit.BODY_WEIGHT.HasValue ? patVisit.BODY_WEIGHT.Value.ToString() : "";
                            anesPlanPmh.BLOOD_TYPE = patVisit.BLOOD_TYPE + " " + patVisit.BLOOD_TYPE_RH;
                        }
                    }
                    else
                    {
                        if (patVisit != null)
                        {
                            anesPlanPmh.HEIGHT = patVisit.BODY_HEIGHT.HasValue ? patVisit.BODY_HEIGHT.Value.ToString() : ""; ;
                            anesPlanPmh.WEIGHT = patVisit.BODY_WEIGHT.HasValue ? patVisit.BODY_WEIGHT.Value.ToString() : ""; ;
                            anesPlanPmh.BLOOD_TYPE = patVisit.BLOOD_TYPE + " " + patVisit.BLOOD_TYPE_RH;
                        }
                    }
                    dapper.Set<MED_ANESTHESIA_PLAN_PMH>().Save(anesPlanPmh, d => d.PATIENT_ID == anesPlanPmh.PATIENT_ID && d.VISIT_ID == anesPlanPmh.VISIT_ID && d.OPER_ID == anesPlanPmh.OPER_ID);
                    dapper.SaveChanges();
                    return item;
                }
            }
            return null;
        }

        private int getMaxOperId(string sql_GetMaxOperID, MED_OPERATION_SCHEDULE item)
        {
            object operId = dapper.ExecuteScalar(sql_GetMaxOperID, new { PatientID = item.PATIENT_ID, VisitID = item.VISIT_ID });
            int maxOperID = 0;
            if (operId != null)
            {
                int.TryParse(operId.ToString(), out maxOperID);
            }
            return ++maxOperID;
        }

        private int GetMaxOperationNo(string sql_GetMaxOperationNo, MED_OPERATION_SCHEDULE item)
        {
            return dapper.ExecuteScalar<int>(sql_GetMaxOperationNo, new { PatientID = item.PATIENT_ID, VisitID = item.VISIT_ID, OperID = item.OPER_ID });
        }

        /// <summary>
        /// 手术取消
        /// </summary>
        /// <param name="operationCanceled"></param>
        /// <returns></returns>
        public bool CancelOperationSchedule(OperCancelAndDetailEntity operationCanceled)
        {
            MED_OPERATION_SCHEDULE opsche = dapper.Set<MED_OPERATION_SCHEDULE>().Single(d => d.PATIENT_ID == operationCanceled.OperCanceled.PATIENT_ID && d.VISIT_ID == operationCanceled.OperCanceled.VISIT_ID && d.SCHEDULE_ID == operationCanceled.OperCanceled.SCHEDULE_ID);
            int CancelID = GetMaxOperCancelCancelID(operationCanceled.OperCanceled);
            operationCanceled.OperCanceled.OPER_ID = opsche.OPER_ID;
            operationCanceled.OperCanceled.CANCEL_ID = ++CancelID;
            bool flag = dapper.Set<MED_OPERATION_CANCELED>().Insert(operationCanceled.OperCanceled);

            if (operationCanceled.AnesInputDict != null && operationCanceled.AnesInputDict.Count > 0)
            {
                foreach (var item in operationCanceled.AnesInputDict)
                {
                    dapper.Set<MED_OPERATION_CANCELED_DETAIL>().Insert(new MED_OPERATION_CANCELED_DETAIL
                    {
                        PATIENT_ID = operationCanceled.OperCanceled.PATIENT_ID,
                        VISIT_ID = operationCanceled.OperCanceled.VISIT_ID,
                        CANCEL_ID = operationCanceled.OperCanceled.CANCEL_ID,
                        CANCEL_CLASS = item.ITEM_CLASS,
                        CANCEL_TYPE = item.ITEM_NAME
                    });
                }
            }
            if (flag)
            {
                opsche.OPER_ROOM_NO = null;
                opsche.SEQUENCE = 0;
                opsche.OPERATING_TIME = 0;
                opsche.ANES_CONFIRM = 0;
                opsche.NURSE_CONFIRM = 0;
                opsche.FIRST_OPER_NURSE = null;
                opsche.FIRST_SUPPLY_NURSE = null;
                opsche.ANES_DOCTOR = null;
                opsche.FIRST_ANES_ASSISTANT = null;
                opsche.OPER_STATUS_CODE = -80;
                dapper.Set<MED_OPERATION_SCHEDULE>().Update(opsche, d => new
                {
                    d.OPER_ROOM_NO,
                    d.SEQUENCE,
                    d.OPERATING_TIME,
                    d.ANES_CONFIRM,
                    d.NURSE_CONFIRM,
                    d.FIRST_OPER_NURSE,
                    d.FIRST_SUPPLY_NURSE,
                    d.ANES_DOCTOR,
                    d.FIRST_ANES_ASSISTANT,
                    d.OPER_STATUS_CODE,
                });
                if (AppSettings.OpenHIS212)
                {
                    SyncInfoService.SyncWrite_OPER504W(opsche.PATIENT_ID, opsche.VISIT_ID, opsche.SCHEDULE_ID);
                }
            }
            dapper.SaveChanges();
            return flag;
        }

        private int GetMaxOperCancelCancelID(MED_OPERATION_CANCELED item)
        {
            string sql_GetMaxOperCancelCancelID = sqlDict.GetSQLByKey("GetMaxOperCancelCancelID");
            return dapper.ExecuteScalar<int>(sql_GetMaxOperCancelCancelID, new { PatientID = item.PATIENT_ID, VisitID = item.VISIT_ID, ScheduleID = item.SCHEDULE_ID });
        }

        /// <summary>
        /// 是否允许手术撤销
        /// </summary>
        /// <param name="operationSchedule"></param>
        /// <returns></returns>
        public MED_OPERATION_SCHEDULE IsCanRevokedOpertionSchedule(MED_OPERATION_SCHEDULE operationSchedule)
        {
            //新增已入室的手术，不允许撤销功能

            MED_OPERATION_SCHEDULE scheduleTemp = null;

            if (operationSchedule != null && !string.IsNullOrEmpty(operationSchedule.PATIENT_ID))
            {
                scheduleTemp = dapper.Set<MED_OPERATION_SCHEDULE>().Single(d => d.PATIENT_ID == operationSchedule.PATIENT_ID && d.VISIT_ID == operationSchedule.VISIT_ID && d.OPER_ID == operationSchedule.OPER_ID);
            }

            return scheduleTemp;
        }

        /// <summary>
        /// 手术撤销
        /// </summary>
        /// <param name="operationSchedule"></param>
        /// <returns></returns>
        public int RevokedOpertionSchedule(MED_OPERATION_SCHEDULE operationSchedule)
        {
            int flag = 0;
            if (operationSchedule.OPER_STATUS_CODE == 1)//从2变成1
            {
                dapper.Set<MED_OPERATION_SCHEDULE>().Update(operationSchedule, d => new
                {
                    d.OPER_STATUS_CODE,
                });
                flag = dapper.Set<MED_OPERATION_MASTER>().Delete(d => d.PATIENT_ID == operationSchedule.PATIENT_ID && d.VISIT_ID == operationSchedule.VISIT_ID && d.OPER_ID == operationSchedule.OPER_ID);
                dapper.Set<MED_OPERATION_NAME>().Delete(d => d.PATIENT_ID == operationSchedule.PATIENT_ID && d.VISIT_ID == operationSchedule.VISIT_ID && d.OPER_ID == operationSchedule.OPER_ID);
                dapper.Set<MED_ANESTHESIA_PLAN>().Delete(d => d.PATIENT_ID == operationSchedule.PATIENT_ID && d.VISIT_ID == operationSchedule.VISIT_ID && d.OPER_ID == operationSchedule.OPER_ID);
                dapper.SaveChanges();
            }
            else if (operationSchedule.OPER_STATUS_CODE == 0)//从1变成0
            {
                //获取当前撤销事件
                DateTime dtCurrentTime = Convert.ToDateTime(operationSchedule.SCHEDULED_DATE_TIME.ToString("d"));
                string operRoom = operationSchedule.OPER_ROOM;
                string operRoomNo = operationSchedule.OPER_ROOM_NO;
                int? seq = operationSchedule.SEQUENCE;

                //判断此手术后面是否全是是未提交的string 
                string sql = sqlDict.GetSQLByKey("GetOperList");
                List<MED_OPERATION_SCHEDULE> list = dapper.Set<MED_OPERATION_SCHEDULE>().Query(sql, new { StartDateTime = dtCurrentTime, ENDDateTime = dtCurrentTime.AddDays(1), OperRoom = operRoom });

                operationSchedule.OPER_ROOM_NO = null;
                operationSchedule.SEQUENCE = 0;
                operationSchedule.OPERATING_TIME = 0;
                operationSchedule.ANES_CONFIRM = 0;
                operationSchedule.NURSE_CONFIRM = 0;
                operationSchedule.FIRST_OPER_NURSE = null;
                operationSchedule.FIRST_SUPPLY_NURSE = null;
                operationSchedule.ANES_DOCTOR = null;
                operationSchedule.FIRST_ANES_ASSISTANT = null;
                flag = dapper.Set<MED_OPERATION_SCHEDULE>().Update(operationSchedule, d => new
                {
                    d.OPER_ROOM_NO,
                    d.SEQUENCE,
                    d.OPERATING_TIME,
                    d.ANES_CONFIRM,
                    d.NURSE_CONFIRM,
                    d.FIRST_OPER_NURSE,
                    d.FIRST_SUPPLY_NURSE,
                    d.ANES_DOCTOR,
                    d.FIRST_ANES_ASSISTANT,
                    d.OPER_STATUS_CODE,
                });
                dapper.SaveChanges();

                //List<MED_OPERATION_SCHEDULE> listRoom = list.Where(d => d.OPER_ROOM_NO == operRoomNo).ToList();
                //List<MED_OPERATION_SCHEDULE> listUpdate = new List<MED_OPERATION_SCHEDULE>();
                //DateTime time1 = operationSchedule.SCHEDULED_DATE_TIME;
                //DateTime time2 = DateTime.Now;
                //int mark = 0;
                //bool isUpdate = true;
                //int? seqTemp = seq;
                //foreach (var item in listRoom)
                //{
                //    if (item.SEQUENCE > seq)
                //    {
                //        if (mark == 0)
                //        {
                //            time2 = item.SCHEDULED_DATE_TIME;
                //            mark = 1;
                //        }
                //        if (item.OPER_STATUS_CODE < 2)
                //        {
                //            //item.SEQUENCE = item.SEQUENCE - 1;

                //            item.SEQUENCE = seqTemp;
                //            seqTemp++;
                //            TimeSpan ts = time1 - time2;
                //            item.SCHEDULED_DATE_TIME = item.SCHEDULED_DATE_TIME.AddMinutes(ts.TotalMinutes);
                //            listUpdate.Add(item);

                //        }
                //        else
                //        {
                //            seqTemp = item.SEQUENCE + 1;

                //            time1 = item.SCHEDULED_DATE_TIME;

                //            time2 = item.SCHEDULED_DATE_TIME;

                //            //isUpdate = false;
                //        }
                //    }
                //}
                //if (isUpdate)
                //{
                //    dapper.Set<MED_OPERATION_SCHEDULE>().Update(listUpdate);
                //    dapper.SaveChanges();
                //}


            }
            return flag;
        }
        /// <summary>
        /// 获取医嘱信息
        /// </summary>
        /// <param name="patientID">patientID</param>
        /// <param name="visitID">visitID</param>
        /// <returns></returns>
        public IList<dynamic> GetMedOrdersList(string patientID, int visitID)
        {
            string sql = sqlDict.GetSQLByKey("GetMedOrdersList");
            return dapper.Query<dynamic>(sql, new { PatientID = patientID, VisitID = visitID });
        }

        /// <summary>
        /// 导出EXCEL
        /// </summary>
        /// <param name="reportMonth">月份</param>
        /// <param name="reportName">模块名字</param>
        /// <param name="exprotExcelColumns">导出的列</param>
        /// <returns></returns>
        public string ExportExcel(object reportMonth, string reportName, dynamic exprotExcelColumns)
        {
            try
            {
                string directoryName = string.Concat(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "TempExprotExcel\\");
                if (!Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }

                DataTable dt = GetExportExcelData(reportMonth, reportName);//获取导出数据
                DateTime repMonth = DateTime.MinValue;
                DateTime.TryParse(reportMonth.ToString(), out repMonth);
                string FileName = (repMonth != DateTime.MinValue ? Convert.ToDateTime(repMonth).ToString("yyyyMMdd") : Convert.ToDateTime(reportMonth).ToString("yyyyMMdd"));

                if (reportName == "NoticeList")
                {
                    FileName += "手术通知单.xlsx";
                }
                else if (reportName == "PickUpList")
                {
                    FileName += "手术接送单.xlsx";
                }
                else
                {
                    FileName += ".xlsx";
                }
                string FilePath = string.Concat(directoryName, FileName);

                ExcelFileHelper.ExportExcelWithAspose(dt, JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(exprotExcelColumns)), FilePath);
                return FileName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataTable GetExportExcelData(object reportMonth, string reportName)
        {
            DataTable dt = null;
            if (reportName == "NoticeList" || reportName == "PickUpList")
            {
                dynamic list = GetOperNoticeList(Convert.ToDateTime(reportMonth));

                dt = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(list));
            }

            return dt;
        }
    }
}
