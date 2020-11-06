using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using MedicalSystem.DataServices.WebApi;
using MedicalSystem.AnesWorkStation.Domain;
using Dapper.Data;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    public interface IPatInfoService
    {
        List<MED_PAT_INFO> GetPatInfos(string idOrName, string deptCode);
        List<MED_PAT_INFO> GetPatInfosByData(DateTime scheduledTime, string roomNo, string idOrName, string deptCode);
        MED_PAT_INFO GetPatInfoByIds(string patID, decimal visitID, decimal operID);
        List<MED_PAT_INFO> GetPatientInfosByDateTime(DateTime dt, string deptCode, string operRoomNo = "");
        List<MED_PAT_INFO> GetPatientInfosInWeek(DateTime startDt, DateTime endDt, string deptCode, string operRoomNo = "");
        List<MED_OPERATION_MASTER> GetPatientList(string inputStr, int showCount, bool isInpNo);
        List<MED_PACU_INFO> GetPACUInfos();
        List<MED_OPERATION_MASTER> GetWaitingInfos();

        /// <summary>
        /// 获取当前正在进行手术的患者
        /// </summary>
        MED_PAT_INFO GetCurPatientInfo(string deptCode, string operRoomNo = "");
    }

    /// <summary>
    /// 病人信息服务
    /// </summary>
    public class PatInfoService : BaseService<PatInfoService>, IPatInfoService
    {
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected PatInfoService()
            : base() { }

        public PatInfoService(IDapperContext context)
            : base(context)
        {
        }

        /// <summary>
        /// 搜索命令：根据对应的idOrName获取手术信息列表
        /// </summary>
        /// <param name="idOrName">病人ID,住院号或姓名</param>
        [HttpGet]
        public virtual List<MED_PAT_INFO> GetPatInfos(string idOrName, string deptCode)
        {
            string sql = string.Format(@"SELECT DISTINCT M.*, A.*, B.INP_NO FROM MED_OPERATION_MASTER M 
                                        LEFT JOIN MED_PAT_MASTER_INDEX A ON M.PATIENT_ID = A.PATIENT_ID 
                                        LEFT JOIN MED_PAT_VISIT B ON M.PATIENT_ID = B.PATIENT_ID
                                        WHERE (M.PATIENT_ID LIKE '%{0}%' OR A.NAME LIKE '%{0}%' OR B.INP_NO LIKE '%{0}%') AND OPER_ROOM ='{1}'", idOrName, deptCode);
            List<MED_PAT_INFO> list = dapper.Query<MED_PAT_INFO>(sql, null);
            return list;
        }

        /// <summary>
        /// 搜索命令：根据对应的scheduledTime获取手术信息列表
        /// </summary>
        /// <param name="scheduledTime">手术时间</param>
        ///    /// <param name="roomNo">手术间号</param>
        ///       /// <param name="idOrName">病人ID,住院号或姓名</param>
        ///          /// <param name="deptCode">科室代码</param>
        [HttpGet]
        public virtual List<MED_PAT_INFO> GetPatInfosByData(DateTime scheduledTime, string roomNo, string idOrName, string deptCode)
        {
            string sql = string.Format(@"SELECT DISTINCT M.*, A.*, B.INP_NO FROM MED_OPERATION_MASTER M 
                                        LEFT JOIN MED_PAT_MASTER_INDEX A ON M.PATIENT_ID = A.PATIENT_ID 
                                        LEFT JOIN MED_PAT_VISIT B ON M.PATIENT_ID = B.PATIENT_ID
                                        WHERE  OPER_ROOM ='{0}' ", deptCode);
            if (scheduledTime != DateTime.MaxValue && scheduledTime != DateTime.MinValue)
            {
                sql += string.Format(" AND (TO_CHAR(M.SCHEDULED_DATE_TIME,'yyyy-MM-dd')='{0}' )", scheduledTime.ToString("yyyy-MM-dd"));
            }
            if (!string.IsNullOrEmpty(idOrName))
            {
                sql += string.Format(" AND (M.PATIENT_ID LIKE '%{0}%' OR A.NAME LIKE '%{0}%' OR B.INP_NO LIKE '%{0}%')", idOrName);
            }
            if (!string.IsNullOrEmpty(roomNo))
            {
                sql += string.Format(" AND (M.OPER_ROOM_NO = '{0}' )", roomNo);
            }
            List<MED_PAT_INFO> list = dapper.Query<MED_PAT_INFO>(sql, null);
            return list;
        }
        /// <summary>
        /// 根据ID获取病人信息
        /// </summary>
        [HttpGet]
        public virtual MED_PAT_INFO GetPatInfoByIds(string patID, decimal visitID, decimal operID)
        {
            string sql = string.Format(@"SELECT DISTINCT M.*, A.*, B.INP_NO FROM MED_OPERATION_MASTER M  LEFT JOIN MED_PAT_MASTER_INDEX A ON M.PATIENT_ID = A.PATIENT_ID LEFT JOIN MED_PAT_VISIT B ON M.PATIENT_ID = B.PATIENT_ID
                                         WHERE M.PATIENT_ID='{0}' AND M.VISIT_ID={1} AND M.OPER_ID={2}", patID, visitID, operID);
            List<MED_PAT_INFO> list = dapper.Query<MED_PAT_INFO>(sql, null);
            return list.FirstOrDefault();
        }

        /// <summary>
        /// 根据日期查询手术列表
        /// </summary>
        [HttpGet]
        public virtual List<MED_PAT_INFO> GetPatientInfosByDateTime(DateTime dt, string deptCode, string operRoomNo = "")
        {
            string sql = string.Format(@"SELECT DISTINCT M.*, A.*, B.INP_NO FROM MED_OPERATION_MASTER M  LEFT JOIN MED_PAT_MASTER_INDEX A ON M.PATIENT_ID = A.PATIENT_ID LEFT JOIN MED_PAT_VISIT B ON M.PATIENT_ID = B.PATIENT_ID
                                         WHERE TO_CHAR(M.SCHEDULED_DATE_TIME, 'YYYY-MM-DD') = '{0}' AND (M.OPER_ROOM_NO = '{1}' OR '{1}' IS NULL) AND OPER_ROOM ='{2}' ORDER BY M.SEQUENCE ", dt.ToString("yyyy-MM-dd"), string.IsNullOrEmpty(operRoomNo) ? "" : operRoomNo, deptCode);
            List<MED_PAT_INFO> list = dapper.Query<MED_PAT_INFO>(sql, null);
            return list;
        }

        /// <summary>
        /// 获取一周的手术汇总信息
        /// </summary>
        [HttpGet]
        public virtual List<MED_PAT_INFO> GetPatientInfosInWeek(DateTime startDt, DateTime endDt, string deptCode, string operRoomNo = "")
        {
            string sql = string.Format(@"SELECT DISTINCT M.*, A.*, B.INP_NO FROM MED_OPERATION_MASTER M LEFT JOIN MED_PAT_MASTER_INDEX A ON M.PATIENT_ID = A.PATIENT_ID LEFT JOIN MED_PAT_VISIT B ON M.PATIENT_ID = B.PATIENT_ID
                                         WHERE M.SCHEDULED_DATE_TIME >= TO_DATE('{0}', 'yyyy-MM-dd') 
                                               AND M.SCHEDULED_DATE_TIME < TO_DATE('{1}', 'yyyy-MM-dd')
                                               AND (M.OPER_ROOM_NO = '{2}' OR '{2}' IS NULL) AND OPER_ROOM ='{3}' ORDER BY M.SEQUENCE ", startDt.ToString("yyyy-MM-dd"), endDt.ToString("yyyy-MM-dd"), string.IsNullOrEmpty(operRoomNo) ? "" : operRoomNo, deptCode);
            List<MED_PAT_INFO> list = dapper.Query<MED_PAT_INFO>(sql, null);
            return list;
        }

        /// <summary>
        /// 获取当前正在手术的患者信息
        /// </summary>
        [HttpGet]
        public virtual MED_PAT_INFO GetCurPatientInfo(string deptCode, string operRoomNo = "")
        {
            string sql = string.Format(@"SELECT DISTINCT M.*, A.*, B.INP_NO FROM MED_OPERATING_ROOM R
LEFT OUTER JOIN MED_OPERATION_MASTER M ON R.PATIENT_ID = M.PATIENT_ID
AND R.VISIT_ID = M.VISIT_ID AND R.OPER_ID = M.OPER_ID
LEFT JOIN MED_PAT_MASTER_INDEX A ON R.PATIENT_ID = A.PATIENT_ID 
LEFT JOIN MED_PAT_VISIT B ON R.PATIENT_ID = B.PATIENT_ID AND R.VISIT_ID = B.VISIT_ID
WHERE M.OPER_STATUS_CODE >= 5 AND M.OPER_STATUS_CODE < 35
AND R.ROOM_NO = '{0}'AND OPER_ROOM ='{1}'", operRoomNo, deptCode);
            List<MED_PAT_INFO> list = this.dapper.Query<MED_PAT_INFO>(sql, null);
            return list.FirstOrDefault();
        }

        /// <summary>
        /// 根据输入值获取匹配患者ID
        /// </summary>
        [HttpGet]
        public virtual List<MED_OPERATION_MASTER> GetPatientList(string inputStr, int showCount, bool isInpNo)
        {
            List<MED_OPERATION_MASTER> patientList = new List<MED_OPERATION_MASTER>();
            if (isInpNo)
            {
                string sql = string.Format(@"
SELECT DISTINCT PATIENT_LIST.INP_NO as PATIENT_ID
  FROM (SELECT M.INP_NO
          FROM MED_PATS_IN_HOSPITAL M
         WHERE M.INP_NO LIKE '%{0}%'
           AND ROWNUM <= {1}
         ORDER BY M.INP_NO DESC) PATIENT_LIST", inputStr, showCount);
                patientList = dapper.Query<MED_OPERATION_MASTER>(sql, null);
            }
            else
            {
                string sql = string.Format(@"
SELECT DISTINCT PATIENT_LIST.PATIENT_ID
  FROM (SELECT M.PATIENT_ID
          FROM MED_PAT_MASTER_INDEX M
         WHERE M.PATIENT_ID LIKE '%{0}%'
           AND ROWNUM <= {1}
         ORDER BY M.PATIENT_ID DESC) PATIENT_LIST", inputStr, showCount);
                patientList = dapper.Query<MED_OPERATION_MASTER>(sql, null);
            }

            return patientList;
        }

        /// <summary>
        /// PACU信息
        /// </summary>
        [HttpGet]
        public virtual List<MED_PACU_INFO> GetPACUInfos()
        {
            string sql = string.Format(@"SELECT NVL(MOR.BED_LABEL, MOR.ROOM_NO) AS BED_NO,
       MOR.PATIENT_ID,
       MOR.VISIT_ID,
       MOR.OPER_ID,
       MPMI.NAME,
       MPMI.SEX,
       MPMI.DATE_OF_BIRTH,
       MOM.SCHEDULED_DATE_TIME,
       MOM.OPERATION_NAME,
       MOM.IN_PACU_DATE_TIME,
       MOM.OUT_PACU_DATE_TIME
  FROM MED_OPERATING_ROOM MOR
  LEFT JOIN MED_OPERATION_MASTER MOM ON MOR.PATIENT_ID = MOM.PATIENT_ID
                                    AND MOR.VISIT_ID = MOM.VISIT_ID
                                    AND MOR.OPER_ID = MOM.OPER_ID
  LEFT JOIN MED_PAT_MASTER_INDEX MPMI ON MPMI.PATIENT_ID = MOM.PATIENT_ID
 WHERE MOR.BED_TYPE = '1'
");
            List<MED_PACU_INFO> list = dapper.Query<MED_PACU_INFO>(sql, null);
            return list;
        }

        /// <summary>
        /// 待入PACU患者信息
        /// </summary>
        [HttpGet]
        public virtual List<MED_OPERATION_MASTER> GetWaitingInfos()
        {
            string sql = string.Format(@"
SELECT MOM.PATIENT_ID AS PatsWaiting
  FROM MED_OPERATION_MASTER MOM
 WHERE TO_CHAR(MOM.SCHEDULED_DATE_TIME, 'yyyyMMdd') = '{0}'
   AND MOM.OPER_STATUS_CODE = 40", DateTime.Now.ToString("yyyyMMdd"));
            List<MED_OPERATION_MASTER> list = dapper.Query<MED_OPERATION_MASTER>(sql, null);
            return list;
        }
    }
}
