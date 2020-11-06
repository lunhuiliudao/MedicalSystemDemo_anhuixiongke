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
    public interface IPacuQueryService
    {
        DataTable GetOperationList(DateTime startTime, DateTime endTime, string inpNo, string name, string operationName,
            string oper_scale, string surgeon, string oper_dept_code, string anes_doctor, string anes_method, string asa_grade, int emergency_ind);

        /// <summary>
        /// 工作量统计
        /// </summary>
        /// <param name="startTime">报表时间</param>
        /// <param name="report">报表类型,1:日报；2:月报；3:年报</param>
        /// <returns>报表结果</returns>
        DataTable GetOperationReport(DateTime startTime, int report);
    }

    public class PacuQueryService : BaseService<PacuQueryService>, IPacuQueryService
    {

        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected PacuQueryService()
            : base() { }

        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public PacuQueryService(IDapperContext context)
            : base(context)
        {
        }

        public DataTable GetOperationList(DateTime startTime, DateTime endTime, string inpNo, string name, string operationName, string oper_scale, string surgeon, string oper_dept_code, string anes_doctor, string anes_method, string asa_grade, int emergency_ind)
        {
            string sql = "没有SQL，待配置。";

            if (dapper.DBType == DatabaseType.Oracle)
            {
                sql = @"SELECT
                          M.PATIENT_ID,
                          M.VISIT_ID,
                          M.OPER_ID,
                          NVL(DD.DEPT_NAME, M.OPER_ROOM) AS OPER_ROOM,
                          M.OPER_ROOM_NO,
                          H.INP_NO,
                          I.NAME,
                          I.SEX,
                          FUN_GET_PAT_AGE(I.DATE_OF_BIRTH, M.SCHEDULED_DATE_TIME) AS AGE,
                          NVL(DOD.DEPT_NAME, M.OPER_DEPT_CODE) AS OPER_DEPT_CODE,
                          M.ANES_METHOD,
                          M.OPER_CLASS,
                          M.OPER_SCALE,
                          M.IN_DATE_TIME,
                          M.ANES_START_TIME,
                          M.START_DATE_TIME,
                          M.END_DATE_TIME,
                          M.ANES_END_TIME,
                          M.OUT_DATE_TIME,
                          TO_CHAR(TRUNC(NVL((M.END_DATE_TIME - M.START_DATE_TIME),0)*24,0)) || '时' || TO_CHAR(ROUND(MOD(NVL((M.END_DATE_TIME - M.START_DATE_TIME),0)*1440,60),0)) || '分' AS OPER_TIME,
                          TO_CHAR(TRUNC(NVL((M.ANES_END_TIME - M.ANES_START_TIME),0)*24,0)) || '时' || TO_CHAR(ROUND(MOD(NVL((M.ANES_END_TIME - M.ANES_START_TIME),0)*1440,60),0)) || '分' AS ANES_TIME
                        FROM MED_OPERATION_MASTER M
                          LEFT JOIN MED_PAT_MASTER_INDEX I ON I.PATIENT_ID = M.PATIENT_ID
                          LEFT JOIN MED_PATS_IN_HOSPITAL H ON H.PATIENT_ID = M.PATIENT_ID AND H.VISIT_ID = M.VISIT_ID
                          LEFT JOIN MED_DEPT_DICT DD ON DD.DEPT_CODE = M.OPER_ROOM
                          LEFT JOIN MED_DEPT_DICT DOD ON DOD.DEPT_CODE = M.OPER_DEPT_CODE
                        WHERE M.ANES_START_TIME >= :SDATE
                          AND M.ANES_START_TIME < :EDATE
                          AND (H.INP_NO LIKE '%'|| :INPNO || '%' OR :INPNO IS NULL)
                          AND (I.NAME LIKE '%'|| :NAME || '%' OR :NAME IS NULL)
                          AND (M.OPERATION_NAME LIKE '%'|| :OPERATION_NAME || '%' OR :OPERATION_NAME IS NULL)
                          AND (M.OPER_SCALE = :OPER_SCALE OR :OPER_SCALE IS NULL)
                          AND (M.SURGEON = :SURGEON OR M.FIRST_OPER_ASSISTANT = :SURGEON OR M.SECOND_OPER_ASSISTANT = :SURGEON OR
                            M.THIRD_OPER_ASSISTANT = :SURGEON OR M.FOURTH_OPER_ASSISTANT = :SURGEON OR :SURGEON IS NULL)
                          AND (M.OPER_DEPT_CODE = :OPER_DEPT_CODE OR :OPER_DEPT_CODE IS NULL)
                          AND (M.ANES_DOCTOR = :ANES_DOCTOR OR M.FIRST_ANES_ASSISTANT = :ANES_DOCTOR OR M.SECOND_ANES_ASSISTANT = :ANES_DOCTOR OR 
                            M.THIRD_ANES_ASSISTANT = :ANES_DOCTOR OR M.FOURTH_ANES_ASSISTANT = :ANES_DOCTOR OR :ANES_DOCTOR IS NULL)
                          AND (M.ANES_METHOD LIKE '%'|| :ANES_METHOD || '%' OR :ANES_METHOD IS NULL)
                          AND (M.ASA_GRADE = :ASA_GRADE OR :ASA_GRADE IS NULL)
                          AND (M.EMERGENCY_IND = :EMERGENCY_IND OR :EMERGENCY_IND < 0)
                        ORDER BY M.ANES_START_TIME";
            }
            else
            {
                sql = @"SELECT
                          M.PATIENT_ID,
                          M.VISIT_ID,
                          M.OPER_ID,
                          ISNULL(DD.DEPT_NAME, M.OPER_ROOM) AS OPER_ROOM,
                          M.OPER_ROOM_NO,
                          H.INP_NO,
                          I.NAME,
                          I.SEX,
                          FUN_GET_PAT_AGE(I.DATE_OF_BIRTH, M.SCHEDULED_DATE_TIME) AS AGE,
                          ISNULL(DOD.DEPT_NAME, M.OPER_DEPT_CODE) AS OPER_DEPT_CODE,
                          M.ANES_METHOD,
                          M.OPER_CLASS,
                          M.OPER_SCALE,
                          M.IN_DATE_TIME,
                          M.ANES_START_TIME,
                          M.START_DATE_TIME,
                          M.END_DATE_TIME,
                          M.ANES_END_TIME,
                          M.OUT_DATE_TIME,
                          CAST(FLOOR(ISNULL((M.END_DATE_TIME - M.START_DATE_TIME),0)*24) AS VARCHAR(10)) + '时' + CAST(FLOOR(ISNULL((M.END_DATE_TIME - M.START_DATE_TIME),0)*1440%60) AS VARCHAR(10)) + '分' AS OPER_TIME,
                          CAST(FLOOR(ISNULL((M.ANES_END_TIME - M.ANES_START_TIME),0)*24) AS VARCHAR(10)) + '时' + CAST(FLOOR(ISNULL((M.ANES_END_TIME - M.ANES_START_TIME),0)*1440%60) AS VARCHAR(10)) + '分' AS ANES_TIME
                        FROM MED_OPERATION_MASTER M
                          LEFT JOIN MED_PAT_MASTER_INDEX I ON I.PATIENT_ID = M.PATIENT_ID
                          LEFT JOIN MED_PATS_IN_HOSPITAL H ON H.PATIENT_ID = M.PATIENT_ID AND H.VISIT_ID = M.VISIT_ID
                          LEFT JOIN MED_DEPT_DICT DD ON DD.DEPT_CODE = M.OPER_ROOM
                          LEFT JOIN MED_DEPT_DICT DOD ON DOD.DEPT_CODE = M.OPER_DEPT_CODE
                        WHERE M.ANES_START_TIME >= @SDATE
                          AND M.ANES_START_TIME < @EDATE
                          AND (H.INP_NO LIKE '%'|| @INPNO || '%' OR ISNULL(LEN(@INPNO),0) = 0)
                          AND (I.NAME LIKE '%'|| @NAME || '%' OR ISNULL(LEN(@NAME),0) = 0)
                          AND (M.OPERATION_NAME LIKE '%'|| @OPERATION_NAME || '%' OR ISNULL(LEN(@OPERATION_NAME),0) = 0)
                          AND (M.OPER_SCALE = @OPER_SCALE OR ISNULL(LEN(@OPER_SCALE),0) = 0)
                          AND (M.SURGEON = @SURGEON OR M.FIRST_OPER_ASSISTANT = @SURGEON OR M.SECOND_OPER_ASSISTANT = @SURGEON OR
                            M.THIRD_OPER_ASSISTANT = @SURGEON OR M.FOURTH_OPER_ASSISTANT = @SURGEON OR ISNULL(LEN(@SURGEON),0) = 0)
                          AND (M.OPER_DEPT_CODE = @OPER_DEPT_CODE OR ISNULL(LEN(@OPER_DEPT_CODE),0) = 0)
                          AND (M.ANES_DOCTOR = @ANES_DOCTOR OR M.FIRST_ANES_ASSISTANT = @ANES_DOCTOR OR M.SECOND_ANES_ASSISTANT = @ANES_DOCTOR OR 
                            M.THIRD_ANES_ASSISTANT = @ANES_DOCTOR OR M.FOURTH_ANES_ASSISTANT = @ANES_DOCTOR OR ISNULL(LEN(@ANES_DOCTOR),0) = 0)
                          AND (M.ANES_METHOD LIKE '%'|| @ANES_METHOD || '%' OR ISNULL(LEN(@ANES_METHOD),0) = 0)
                          AND (M.ASA_GRADE = @ASA_GRADE OR ISNULL(LEN(@ASA_GRADE),0) = 0)
                          AND (M.EMERGENCY_IND = @EMERGENCY_IND OR @EMERGENCY_IND < 0)
                        ORDER BY M.ANES_START_TIME";
            }


            return dapper.Fill(sql, new
            {
                SDATE = startTime,
                EDATE = endTime,
                INPNO = inpNo,
                NAME = name,
                OPERATION_NAME = operationName,
                OPER_SCALE = oper_scale,
                SURGEON = surgeon,
                OPER_DEPT_CODE = oper_dept_code,
                ANES_DOCTOR = anes_doctor,
                ANES_METHOD = anes_method,
                ASA_GRADE = asa_grade,
                EMERGENCY_IND = emergency_ind
            });

        }

        public DataTable GetOperationReport(DateTime startTime, int report)
        {
            DataTable dt = new DataTable();

            DateTime endTime = DateTime.MaxValue;
            switch (report)
            {
                case 1:
                    startTime = startTime.Date;
                    endTime = startTime.AddDays(1);
                    break;
                case 2:
                    startTime = DateTime.Parse(startTime.ToString("yyyy-MM-01"));
                    endTime = startTime.AddMonths(1);
                    break;
                case 3:
                    startTime = DateTime.Parse(startTime.ToString("yyyy-01-01"));
                    endTime = startTime.AddYears(1);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("report", "报表类型,1:日报；2:月报；3:年报");
            }

            string sql = "没有SQL，待配置。";

            if (dapper.DBType == DatabaseType.Oracle)
            {
                switch (report)
                {
                    case 1:
                        #region 日报

                        sql = @"SELECT
                          M.PATIENT_ID,
                          M.VISIT_ID,
                          M.OPER_ID,
                          NVL(DD.DEPT_NAME, M.OPER_ROOM) AS OPER_ROOM,
                          M.OPER_ROOM_NO,
                          H.INP_NO,
                          I.NAME,
                          I.SEX,
                          FUN_GET_PAT_AGE(I.DATE_OF_BIRTH, M.SCHEDULED_DATE_TIME) AS AGE,
                          NVL(DOD.DEPT_NAME, M.OPER_DEPT_CODE) AS OPER_DEPT_CODE,
                          M.ANES_METHOD,
                          M.OPER_CLASS,
                          M.OPER_SCALE,
                          M.IN_DATE_TIME,
                          M.ANES_START_TIME,
                          M.START_DATE_TIME,
                          M.END_DATE_TIME,
                          M.ANES_END_TIME,
                          M.OUT_DATE_TIME,
                          TO_CHAR(TRUNC(NVL((M.END_DATE_TIME - M.START_DATE_TIME),0)*24,0)) || '时' || TO_CHAR(ROUND(MOD(NVL((M.END_DATE_TIME - M.START_DATE_TIME),0)*1440,60),0)) || '分' AS OPER_TIME,
                          TO_CHAR(TRUNC(NVL((M.ANES_END_TIME - M.ANES_START_TIME),0)*24,0)) || '时' || TO_CHAR(ROUND(MOD(NVL((M.ANES_END_TIME - M.ANES_START_TIME),0)*1440,60),0)) || '分' AS ANES_TIME

                        FROM MED_OPERATION_MASTER M
                          LEFT JOIN MED_PAT_MASTER_INDEX I ON I.PATIENT_ID = M.PATIENT_ID
                          LEFT JOIN MED_PATS_IN_HOSPITAL H ON H.PATIENT_ID = M.PATIENT_ID AND H.VISIT_ID = M.VISIT_ID
                          LEFT JOIN MED_DEPT_DICT DD ON DD.DEPT_CODE = M.OPER_ROOM
                          LEFT JOIN MED_DEPT_DICT DOD ON DOD.DEPT_CODE = M.OPER_DEPT_CODE
                        WHERE M.ANES_START_TIME >= :SDATE
                          AND M.ANES_START_TIME < :EDATE
                        ORDER BY M.ANES_START_TIME";

                        dt = dapper.Fill(sql, new
                        {
                            SDATE = startTime,
                            EDATE = endTime
                        });


                        #endregion

                        break;
                    case 2:
                        #region 月报

                        sql = @"SELECT L.MDAY AS ANES_START_DATE,
                                  NVL(SUM(M.OPER_SCALE1),0) AS OPER_SCALE1,
                                  NVL(SUM(M.OPER_SCALE2),0) AS OPER_SCALE2,
                                  NVL(SUM(M.OPER_SCALE3),0) AS OPER_SCALE3,
                                  NVL(SUM(M.OPER_SCALE4),0) AS OPER_SCALE4,
                                  SUM(CASE WHEN M.ANES_START_DATE IS NOT NULL THEN (1 - M.OPER_SCALE1 - M.OPER_SCALE2 - M.OPER_SCALE3 - M.OPER_SCALE4) ELSE 0 END) AS OPER_SCALE5,
                                  SUM(CASE WHEN M.ANES_START_DATE IS NOT NULL THEN 1 ELSE 0 END) AS COUNT,
                                  SUM(CASE WHEN M.EMERGENCY_IND = 0 THEN 1 ELSE 0 END) AS EMERGENCY_IND1,
                                  SUM(CASE WHEN M.EMERGENCY_IND = 1 THEN 1 ELSE 0 END) AS EMERGENCY_IND2,
                                  SUM(CASE WHEN M.ANES_START_DATE IS NOT NULL AND M.EMERGENCY_IND IS NULL OR M.EMERGENCY_IND NOT IN (0, 1) THEN 1 ELSE 0 END) AS EMERGENCY_IND3,
                                  TO_CHAR(TRUNC(NVL(SUM(M.ANES_TIME),0)*24,0)) || '时' || TO_CHAR(ROUND(MOD(NVL(SUM(M.ANES_TIME),0)*1440,60),0)) || '分' AS ANES_TIME
                                FROM (SELECT TO_CHAR(:SDATE + ROWNUM - 1, 'YYYY-MM-DD') AS MDAY, ROWNUM FROM DUAL CONNECT BY ROWNUM <= (:EDATE - :SDATE)) L
                                LEFT JOIN (SELECT TO_CHAR(M.ANES_START_TIME, 'YYYY-MM-DD') AS ANES_START_DATE,
                                            M.OPER_SCALE,
                                            (CASE WHEN M.OPER_SCALE IN ('i级','1','I级','一级','Ⅰ','I') THEN 1 ELSE 0 END) AS OPER_SCALE1,
                                            (CASE WHEN M.OPER_SCALE IN ('ii级','2','Ⅱ级','‖级','二级','Ⅱ','II','2级','11') THEN 1 ELSE 0 END) AS OPER_SCALE2,
                                            (CASE WHEN M.OPER_SCALE IN ('iii级','3','Ⅲ级','三级','Ⅲ','III','3级','111') THEN 1 ELSE 0 END) AS OPER_SCALE3,
                                            (CASE WHEN M.OPER_SCALE IN ('iv级','4','Ⅳ级','四级','Ⅳ','IV','4级','1111') THEN 1 ELSE 0 END) AS OPER_SCALE4,
                                            M.EMERGENCY_IND,
                                            (M.ANES_END_TIME - M.ANES_START_TIME) AS ANES_TIME
                                        FROM MED_OPERATION_MASTER M
                                        WHERE M.ANES_START_TIME >= :SDATE
                                        AND M.ANES_START_TIME < :EDATE) M ON L.MDAY = M.ANES_START_DATE
                                GROUP BY L.MDAY
                                ORDER BY L.MDAY";

                        dt = dapper.Fill(sql, new
                        {
                            SDATE = startTime,
                            EDATE = endTime
                        });

                        #endregion

                        break;
                    case 3:
                        #region 年报

                        sql = @"SELECT L.MDAY AS ANES_START_DATE,
                                  NVL(SUM(M.OPER_SCALE1),0) AS OPER_SCALE1,
                                  NVL(SUM(M.OPER_SCALE2),0) AS OPER_SCALE2,
                                  NVL(SUM(M.OPER_SCALE3),0) AS OPER_SCALE3,
                                  NVL(SUM(M.OPER_SCALE4),0) AS OPER_SCALE4,
                                  SUM(CASE WHEN M.ANES_START_DATE IS NOT NULL THEN (1 - M.OPER_SCALE1 - M.OPER_SCALE2 - M.OPER_SCALE3 - M.OPER_SCALE4) ELSE 0 END) AS OPER_SCALE5,
                                  SUM(CASE WHEN M.ANES_START_DATE IS NOT NULL THEN 1 ELSE 0 END) AS COUNT,
                                  SUM(CASE WHEN M.EMERGENCY_IND = 0 THEN 1 ELSE 0 END) AS EMERGENCY_IND1,
                                  SUM(CASE WHEN M.EMERGENCY_IND = 1 THEN 1 ELSE 0 END) AS EMERGENCY_IND2,
                                  SUM(CASE WHEN M.ANES_START_DATE IS NOT NULL AND M.EMERGENCY_IND IS NULL OR M.EMERGENCY_IND NOT IN (0, 1) THEN 1 ELSE 0 END) AS EMERGENCY_IND3,
                                  TO_CHAR(TRUNC(NVL(SUM(M.ANES_TIME),0)*24,0)) || '时' || TO_CHAR(ROUND(MOD(NVL(SUM(M.ANES_TIME),0)*1440,60),0)) || '分' AS ANES_TIME
                                FROM (SELECT TO_CHAR(ADD_MONTHS(:SDATE, ROWNUM - 1), 'YYYY-MM') AS MDAY,ROWNUM FROM DUAL CONNECT BY ROWNUM <= 12) L
                                LEFT JOIN (SELECT TO_CHAR(M.ANES_START_TIME, 'YYYY-MM') AS ANES_START_DATE,
                                            M.OPER_SCALE,
                                            (CASE WHEN M.OPER_SCALE IN ('i级','1','I级','一级','Ⅰ','I') THEN 1 ELSE 0 END) AS OPER_SCALE1,
                                            (CASE WHEN M.OPER_SCALE IN ('ii级','2','Ⅱ级','‖级','二级','Ⅱ','II','2级','11') THEN 1 ELSE 0 END) AS OPER_SCALE2,
                                            (CASE WHEN M.OPER_SCALE IN ('iii级','3','Ⅲ级','三级','Ⅲ','III','3级','111') THEN 1 ELSE 0 END) AS OPER_SCALE3,
                                            (CASE WHEN M.OPER_SCALE IN ('iv级','4','Ⅳ级','四级','Ⅳ','IV','4级','1111') THEN 1 ELSE 0 END) AS OPER_SCALE4,
                                            M.EMERGENCY_IND,
                                            (M.ANES_END_TIME - M.ANES_START_TIME) AS ANES_TIME
                                        FROM MED_OPERATION_MASTER M
                                        WHERE M.ANES_START_TIME >= :SDATE
                                        AND M.ANES_START_TIME < :EDATE) M ON L.MDAY = M.ANES_START_DATE
                                GROUP BY L.MDAY
                                ORDER BY L.MDAY";

                        dt = dapper.Fill(sql, new
                        {
                            SDATE = startTime,
                            EDATE = endTime
                        });

                        #endregion

                        break;
                }

            }
            else
            {
                switch (report)
                {
                    case 1:
                        #region 日报

                        sql = @"SELECT
                                  M.PATIENT_ID,
                                  M.VISIT_ID,
                                  M.OPER_ID,
                                  ISNULL(DD.DEPT_NAME, M.OPER_ROOM) AS OPER_ROOM,
                                  M.OPER_ROOM_NO,
                                  H.INP_NO,
                                  I.NAME,
                                  I.SEX,
                                  FUN_GET_PAT_AGE(I.DATE_OF_BIRTH, M.SCHEDULED_DATE_TIME) AS AGE,
                                  ISNULL(DOD.DEPT_NAME, M.OPER_DEPT_CODE) AS OPER_DEPT_CODE,
                                  M.ANES_METHOD,
                                  M.OPER_CLASS,
                                  M.OPER_SCALE,
                                  M.IN_DATE_TIME,
                                  M.ANES_START_TIME,
                                  M.START_DATE_TIME,
                                  M.END_DATE_TIME,
                                  M.ANES_END_TIME,
                                  M.OUT_DATE_TIME,
                                  CAST(FLOOR(ISNULL((M.END_DATE_TIME - M.START_DATE_TIME),0)*24) AS VARCHAR(10)) + '时' + CAST(FLOOR(ISNULL((M.END_DATE_TIME - M.START_DATE_TIME),0)*1440%60) AS VARCHAR(10)) + '分' AS OPER_TIME,
                                  CAST(FLOOR(ISNULL((M.ANES_END_TIME - M.ANES_START_TIME),0)*24) AS VARCHAR(10)) + '时' + CAST(FLOOR(ISNULL((M.ANES_END_TIME - M.ANES_START_TIME),0)*1440%60) AS VARCHAR(10)) + '分' AS ANES_TIME
                                FROM MED_OPERATION_MASTER M
                                  LEFT JOIN MED_PAT_MASTER_INDEX I ON I.PATIENT_ID = M.PATIENT_ID
                                  LEFT JOIN MED_PATS_IN_HOSPITAL H ON H.PATIENT_ID = M.PATIENT_ID AND H.VISIT_ID = M.VISIT_ID
                                  LEFT JOIN MED_DEPT_DICT DD ON DD.DEPT_CODE = M.OPER_ROOM
                                  LEFT JOIN MED_DEPT_DICT DOD ON DOD.DEPT_CODE = M.OPER_DEPT_CODE
                                WHERE M.ANES_START_TIME >= :SDATE
                                  AND M.ANES_START_TIME < :EDATE
                                ORDER BY M.ANES_START_TIME";

                        dt = dapper.Fill(sql, new
                        {
                            SDATE = startTime,
                            EDATE = endTime
                        });

                        #endregion

                        break;
                    case 2:
                        #region 月报

                        string monthSql = "(SELECT '' AS MDAY WHERE 1 = 0)";
                        for (var tmp = startTime; tmp < endTime; tmp = tmp.AddDays(1))
                        {
                            monthSql += string.Format(" UNION ALL (SELECT '{0}' AS MDAY)", tmp.ToString("yyyy-MM-dd"));
                        }

                        sql = string.Format(@"SELECT L.MDAY AS ANES_START_DATE,
                                  ISNULL(SUM(M.OPER_SCALE1),0) AS OPER_SCALE1,
                                  ISNULL(SUM(M.OPER_SCALE2),0) AS OPER_SCALE2,
                                  ISNULL(SUM(M.OPER_SCALE3),0) AS OPER_SCALE3,
                                  ISNULL(SUM(M.OPER_SCALE4),0) AS OPER_SCALE4,
                                  SUM(CASE WHEN M.ANES_START_DATE IS NOT NULL THEN (1 - M.OPER_SCALE1 - M.OPER_SCALE2 - M.OPER_SCALE3 - M.OPER_SCALE4) ELSE 0 END) AS OPER_SCALE5,
                                  SUM(CASE WHEN M.ANES_START_DATE IS NOT NULL THEN 1 ELSE 0 END) AS COUNT,
                                  SUM(CASE WHEN M.EMERGENCY_IND = 0 THEN 1 ELSE 0 END) AS EMERGENCY_IND1,
                                  SUM(CASE WHEN M.EMERGENCY_IND = 1 THEN 1 ELSE 0 END) AS EMERGENCY_IND2,
                                  SUM(CASE WHEN M.ANES_START_DATE IS NOT NULL AND M.EMERGENCY_IND IS NULL OR M.EMERGENCY_IND NOT IN (0, 1) THEN 1 ELSE 0 END) AS EMERGENCY_IND3,
                                  CAST(FLOOR(ISNULL(SUM(M.ANES_TIME),0)*24) AS VARCHAR(10)) + '时' + CAST(FLOOR(ISNULL(SUM(M.ANES_TIME),0)*1440%60) AS VARCHAR(10)) + '分' AS ANES_TIME
                                FROM ({0}) L
                                LEFT JOIN (SELECT CONVERT(VARCHAR(10), M.ANES_START_TIME, 23) AS ANES_START_DATE,
                                            M.OPER_SCALE,
                                            (CASE WHEN M.OPER_SCALE IN ('i级','1','I级','一级','Ⅰ','I') THEN 1 ELSE 0 END) AS OPER_SCALE1,
                                            (CASE WHEN M.OPER_SCALE IN ('ii级','2','Ⅱ级','‖级','二级','Ⅱ','II','2级','11') THEN 1 ELSE 0 END) AS OPER_SCALE2,
                                            (CASE WHEN M.OPER_SCALE IN ('iii级','3','Ⅲ级','三级','Ⅲ','III','3级','111') THEN 1 ELSE 0 END) AS OPER_SCALE3,
                                            (CASE WHEN M.OPER_SCALE IN ('iv级','4','Ⅳ级','四级','Ⅳ','IV','4级','1111') THEN 1 ELSE 0 END) AS OPER_SCALE4,
                                            M.EMERGENCY_IND,
                                            (M.ANES_END_TIME - M.ANES_START_TIME) AS ANES_TIME
                                        FROM MED_OPERATION_MASTER M
                                        WHERE M.ANES_START_TIME >= :SDATE
                                        AND M.ANES_START_TIME < :EDATE) M ON L.MDAY = M.ANES_START_DATE
                                GROUP BY L.MDAY
                                ORDER BY L.MDAY", monthSql);

                        dt = dapper.Fill(sql, new
                        {
                            SDATE = startTime,
                            EDATE = endTime
                        });

                        #endregion

                        break;
                    case 3:
                        #region 年报

                        string yearSql = "(SELECT '' AS MDAY WHERE 1 = 0)";
                        for (var tmp = startTime; tmp < endTime; tmp = tmp.AddMonths(1))
                        {
                            yearSql += string.Format(" UNION ALL (SELECT '{0}' AS MDAY)", tmp.ToString("yyyy-MM"));
                        }

                        sql = string.Format(@"SELECT L.MDAY AS ANES_START_DATE,
                                  ISNULL(SUM(M.OPER_SCALE1),0) AS OPER_SCALE1,
                                  ISNULL(SUM(M.OPER_SCALE2),0) AS OPER_SCALE2,
                                  ISNULL(SUM(M.OPER_SCALE3),0) AS OPER_SCALE3,
                                  ISNULL(SUM(M.OPER_SCALE4),0) AS OPER_SCALE4,
                                  SUM(CASE WHEN M.ANES_START_DATE IS NOT NULL THEN (1 - M.OPER_SCALE1 - M.OPER_SCALE2 - M.OPER_SCALE3 - M.OPER_SCALE4) ELSE 0 END) AS OPER_SCALE5,
                                  SUM(CASE WHEN M.ANES_START_DATE IS NOT NULL THEN 1 ELSE 0 END) AS COUNT,
                                  SUM(CASE WHEN M.EMERGENCY_IND = 0 THEN 1 ELSE 0 END) AS EMERGENCY_IND1,
                                  SUM(CASE WHEN M.EMERGENCY_IND = 1 THEN 1 ELSE 0 END) AS EMERGENCY_IND2,
                                  SUM(CASE WHEN M.ANES_START_DATE IS NOT NULL AND M.EMERGENCY_IND IS NULL OR M.EMERGENCY_IND NOT IN (0, 1) THEN 1 ELSE 0 END) AS EMERGENCY_IND3,
                                  CAST(FLOOR(ISNULL(SUM(M.ANES_TIME),0)*24) AS VARCHAR(10)) + '时' + CAST(FLOOR(ISNULL(SUM(M.ANES_TIME),0)*1440%60) AS VARCHAR(10)) + '分' AS ANES_TIME
                                FROM ({0}) L
                                LEFT JOIN (SELECT CONVERT(VARCHAR(7), M.ANES_START_TIME, 23) AS ANES_START_DATE,
                                            M.OPER_SCALE,
                                            (CASE WHEN M.OPER_SCALE IN ('i级','1','I级','一级','Ⅰ','I') THEN 1 ELSE 0 END) AS OPER_SCALE1,
                                            (CASE WHEN M.OPER_SCALE IN ('ii级','2','Ⅱ级','‖级','二级','Ⅱ','II','2级','11') THEN 1 ELSE 0 END) AS OPER_SCALE2,
                                            (CASE WHEN M.OPER_SCALE IN ('iii级','3','Ⅲ级','三级','Ⅲ','III','3级','111') THEN 1 ELSE 0 END) AS OPER_SCALE3,
                                            (CASE WHEN M.OPER_SCALE IN ('iv级','4','Ⅳ级','四级','Ⅳ','IV','4级','1111') THEN 1 ELSE 0 END) AS OPER_SCALE4,
                                            M.EMERGENCY_IND,
                                            (M.ANES_END_TIME - M.ANES_START_TIME) AS ANES_TIME
                                        FROM MED_OPERATION_MASTER M
                                        WHERE M.ANES_START_TIME >= :SDATE
                                        AND M.ANES_START_TIME < :EDATE) M ON L.MDAY = M.ANES_START_DATE
                                GROUP BY L.MDAY
                                ORDER BY L.MDAY", yearSql);

                        dt = dapper.Fill(sql, new
                        {
                            SDATE = startTime,
                            EDATE = endTime
                        });

                        #endregion

                        break;
                }
            }

            return dt;
        }
    }
}
