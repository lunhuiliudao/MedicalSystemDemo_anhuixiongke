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
    public interface IPacuShiftOperationInfoService
    {
        MED_SHIFT_OPERATION_SIGN GetShiftOperationSign(string patientID, int visitID, int operID, int shiftType, int shiftDivision);

        List<SHIFT_OPERATION_INFO> GetShiftOperationInfoList(DateTime shiftDate, string timeOffset, string operRoom, int shiftType);

        List<SHIFT_OPERATION_INFO> GetUnShiftOperationInfoList(DateTime shiftDate, string timeOffset, string operRoom, int shiftType, int shiftDivision);

        List<SHIFT_OPERATION_INFO> GetShiftOperationInfoExtList(DateTime startDate, DateTime endDate, string inpNo, string patientName, string dept, string keyWords, string operRoom, int shiftType);

        List<MED_SHIFT_OPERATION_FILES> GetShiftOperationFiles(string patientID, int visitID, int operID, int shiftType, int shiftDivision);

        bool FileIsExist(string patientID, int visitID, int operID, int shiftType, int shiftDivision, string fileName);

        bool SaveShiftFileInfo(MED_SHIFT_OPERATION_FILES item);

        bool DeleteShiftFileInfo(MED_SHIFT_OPERATION_FILES item);

        int GetRecordNo(string patientID, int visitID, int operID, int shiftType, int shiftDivision);

        List<MED_SHIFT_OPERATION_DATA> GetShiftOperationData(string patientID, int visitID, int operID, int shiftType, int shiftDivision);

        bool SaveShiftOperationData(MED_SHIFT_OPERATION_DATA item);

        bool DeleteSehiftOperationData(MED_SHIFT_OPERATION_DATA item);

        bool SaveShiftOperationSign(MED_SHIFT_OPERATION_SIGN item);

        int DeleteAllShiftFileInfo(List<MED_SHIFT_OPERATION_FILES> item);

        int DeleteAllShiftSignData(List<MED_SHIFT_OPERATION_DATA> item);

        bool DeleteShiftSignData(MED_SHIFT_OPERATION_SIGN item);

    }

    public class PacuShiftOperationInfoService : BaseService<PacuShiftOperationInfoService>, IPacuShiftOperationInfoService
    {

        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected PacuShiftOperationInfoService()
            : base() { }

        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public PacuShiftOperationInfoService(IDapperContext context)
            : base(context)
        {
        }

        public MED_SHIFT_OPERATION_SIGN GetShiftOperationSign(string patientID, int visitID, int operID, int shiftType, int shiftDivision)
        {
            return dapper.Set<MED_SHIFT_OPERATION_SIGN>().Single(x => x.PATIENT_ID == patientID &&
                         x.VISIT_ID == visitID &&
                         x.OPER_ID == operID &&
                         x.SHIFT_TYPE == shiftType &&
                         x.SHIFT_DIVISION == shiftDivision);
        }

        public List<SHIFT_OPERATION_INFO> GetShiftOperationInfoList(DateTime shiftDate, string timeOffset, string operRoom, int shiftType)
        {
            string sqlText = @"SELECT M.PATIENT_ID,
                                   M.VISIT_ID,
                                   M.OPER_ID,
                                   TO_CHAR(M.IN_DATE_TIME, 'yyyy-mm-dd') IN_DATE,
                                   NVL(D.DEPT_NAME, M.DEPT_CODE) DEPT_NAME,
                                   M.OPER_ROOM_NO,
                                   H.INP_NO,
                                   I.NAME,
                                   M.BED_NO,
                                   I.SEX,
                                   FUN_GET_PAT_AGE(I.DATE_OF_BIRTH, SYSDATE) AS AGE,
                                   M.OPERATION_NAME,
                                   NVL(SUR.USER_NAME, M.SURGEON) SURGEON_NAME,
                                   NVL(FIRO.USER_NAME, M.FIRST_OPER_ASSISTANT) FIRST_OPER_ASSISTANT_NAME,
                                   M.ANES_METHOD,
                                   NVL(ANES.USER_NAME, M.ANES_DOCTOR) ANES_DOCTOR_NAME,
                                   NVL(FIRA.USER_NAME, M.FIRST_ANES_ASSISTANT) FIRST_ANES_ASSISTANT_NAME,
                                   NVL(FIRON.USER_NAME, M.FIRST_OPER_NURSE) FIRST_OPER_NURSE_NAME,
                                   NVL(FIRSN.USER_NAME, M.FIRST_SUPPLY_NURSE) FIRST_SUPPLY_NURSE_NAME,
                                   M.IN_DATE_TIME,
                                   M.ANES_START_TIME,
                                   M.START_DATE_TIME,
                                   M.END_DATE_TIME,
                                   M.ANES_END_TIME,
                                   M.OUT_DATE_TIME,
                                   M.IN_PACU_DATE_TIME,
                                   M.OUT_PACU_DATE_TIME,
                                   M.PAT_WHEREABORTS,
                                   M.ASA_GRADE,
                                   M.ANESTHESIA_ID,
                                   M.EMERGENCY_IND,
                                   M.SCHEDULED_DATE_TIME,
                                   I.DATE_OF_BIRTH,
                                   DECODE(M.ISOLATION_IND, 1, '正常', 2, '隔离') AS ISOLATION_IND,
                                   S.SHIFT_TYPE,
                                   S.SHIFT_DIVISION,
                                   S.SHIFT_CONTENT
                              FROM MED_OPERATION_MASTER M
                              INNER JOIN MED_SHIFT_OPERATION_SIGN S
                                ON M.PATIENT_ID = S.PATIENT_ID
                                   AND M.VISIT_ID = S.VISIT_ID
                                   AND M.OPER_ID = S.OPER_ID
                              LEFT JOIN MED_PAT_MASTER_INDEX I
                                ON M.PATIENT_ID = I.PATIENT_ID
                              LEFT JOIN MED_DEPT_DICT D
                                ON M.DEPT_CODE = D.DEPT_CODE
                              LEFT JOIN MED_PATS_IN_HOSPITAL H
                                ON M.PATIENT_ID = H.PATIENT_ID
                              LEFT JOIN MED_HIS_USERS SUR
                                ON M.SURGEON = SUR.USER_JOB_ID
                              LEFT JOIN MED_HIS_USERS FIRO
                                ON M.FIRST_OPER_ASSISTANT = FIRO.USER_JOB_ID
                              LEFT JOIN MED_HIS_USERS ANES
                                ON M.ANES_DOCTOR = ANES.USER_JOB_ID
                              LEFT JOIN MED_HIS_USERS FIRA
                                ON M.FIRST_ANES_ASSISTANT = FIRA.USER_JOB_ID
                              LEFT JOIN MED_HIS_USERS FIRON
                                ON M.FIRST_OPER_NURSE = FIRON.USER_JOB_ID
                              LEFT JOIN MED_HIS_USERS FIRSN
                                ON M.FIRST_SUPPLY_NURSE = FIRSN.USER_JOB_ID
                              WHERE ((S.SHIFT_DIVISION = 1
                                     AND M.SCHEDULED_DATE_TIME BETWEEN :SHIFTDATE AND :SHIFTDATE + 1)
                              OR (S.SHIFT_DIVISION = 2
                                  AND M.IN_DATE_TIME BETWEEN :SHIFTDATE - 1 AND :SHIFTDATE))
                              AND (M.OPER_ROOM = :OPERROOM 
                                OR M.OPER_ROOM IN (SELECT REGEXP_SUBSTR(:OPERROOM, '[^,]+', 1, ROWNUM)
                                    FROM DUAL
                                CONNECT BY ROWNUM <= LENGTH(REGEXP_REPLACE(:OPERROOM, '[^,]+', '')) + 1 ))
                              AND S.SHIFT_TYPE = :SHIFTTYPE";

            return dapper.Set<SHIFT_OPERATION_INFO>().Query(sqlText, new
            {
                SHIFTDATE = DateTime.Parse(string.Format("{0} {1}:00", shiftDate.ToString("yyyy-MM-dd"), timeOffset)),
                OPERROOM = operRoom,
                SHIFTTYPE = shiftType
            });
        }

        public List<SHIFT_OPERATION_INFO> GetUnShiftOperationInfoList(DateTime shiftDate, string timeOffset, string operRoom, int shiftType, int shiftDivision)
        {
            string sqlText = @"SELECT M.PATIENT_ID,
                                   M.VISIT_ID,
                                   M.OPER_ID,
                                   TO_CHAR(M.IN_DATE_TIME, 'yyyy-mm-dd') IN_DATE,
                                   NVL(D.DEPT_NAME, M.DEPT_CODE) DEPT_NAME,
                                   M.OPER_ROOM_NO,
                                   H.INP_NO,
                                   I.NAME,
                                   M.BED_NO,
                                   I.SEX,
                                   FUN_GET_PAT_AGE(I.DATE_OF_BIRTH, SYSDATE) AS AGE,
                                   M.OPERATION_NAME,
                                   NVL(SUR.USER_NAME, M.SURGEON) SURGEON_NAME,
                                   NVL(FIRO.USER_NAME, M.FIRST_OPER_ASSISTANT) FIRST_OPER_ASSISTANT_NAME,
                                   M.ANES_METHOD,
                                   NVL(ANES.USER_NAME, M.ANES_DOCTOR) ANES_DOCTOR_NAME,
                                   NVL(FIRA.USER_NAME, M.FIRST_ANES_ASSISTANT) FIRST_ANES_ASSISTANT_NAME,
                                   NVL(FIRON.USER_NAME, M.FIRST_OPER_NURSE) FIRST_OPER_NURSE_NAME,
                                   NVL(FIRSN.USER_NAME, M.FIRST_SUPPLY_NURSE) FIRST_SUPPLY_NURSE_NAME,
                                   M.IN_DATE_TIME,
                                   M.ANES_START_TIME,
                                   M.START_DATE_TIME,
                                   M.END_DATE_TIME,
                                   M.ANES_END_TIME,
                                   M.OUT_DATE_TIME,
                                   M.IN_PACU_DATE_TIME,
                                   M.OUT_PACU_DATE_TIME,
                                   M.PAT_WHEREABORTS,
                                   M.ASA_GRADE,
                                   M.ANESTHESIA_ID,
                                   M.EMERGENCY_IND,
                                   M.SCHEDULED_DATE_TIME,
                                   I.DATE_OF_BIRTH,
                                   DECODE(M.ISOLATION_IND, 1, '正常', 2, '隔离') AS ISOLATION_IND
                              FROM MED_OPERATION_MASTER M
                              LEFT JOIN MED_SHIFT_OPERATION_SIGN S
                                ON M.PATIENT_ID = S.PATIENT_ID
                                   AND M.VISIT_ID = S.VISIT_ID
                                   AND M.OPER_ID = S.OPER_ID
                              LEFT JOIN MED_PAT_MASTER_INDEX I
                                ON M.PATIENT_ID = I.PATIENT_ID
                              LEFT JOIN MED_DEPT_DICT D
                                ON M.DEPT_CODE = D.DEPT_CODE
                              LEFT JOIN MED_PATS_IN_HOSPITAL H
                                ON M.PATIENT_ID = H.PATIENT_ID
                              LEFT JOIN MED_HIS_USERS SUR
                                ON M.SURGEON = SUR.USER_JOB_ID
                              LEFT JOIN MED_HIS_USERS FIRO
                                ON M.FIRST_OPER_ASSISTANT = FIRO.USER_JOB_ID
                              LEFT JOIN MED_HIS_USERS ANES
                                ON M.ANES_DOCTOR = ANES.USER_JOB_ID
                              LEFT JOIN MED_HIS_USERS FIRA
                                ON M.FIRST_ANES_ASSISTANT = FIRA.USER_JOB_ID
                              LEFT JOIN MED_HIS_USERS FIRON
                                ON M.FIRST_OPER_NURSE = FIRON.USER_JOB_ID
                              LEFT JOIN MED_HIS_USERS FIRSN
                                ON M.FIRST_SUPPLY_NURSE = FIRSN.USER_JOB_ID
                              WHERE S.PATIENT_ID IS NULL 
                              AND {0}
                              AND (M.OPER_ROOM = :OPERROOM 
                                OR M.OPER_ROOM IN (SELECT REGEXP_SUBSTR(:OPERROOM, '[^,]+', 1, ROWNUM)
                                    FROM DUAL
                                CONNECT BY ROWNUM <= LENGTH(REGEXP_REPLACE(:OPERROOM, '[^,]+', '')) + 1 ))";

            sqlText = string.Format(sqlText, shiftDivision == 1 ? @"M.SCHEDULED_DATE_TIME BETWEEN :SHIFTDATE AND :SHIFTDATE + 1"
                                                                : @"M.IN_DATE_TIME BETWEEN :SHIFTDATE - 1 AND :SHIFTDATE");

            return dapper.Set<SHIFT_OPERATION_INFO>().Query(sqlText, new
            {
                SHIFTDATE = DateTime.Parse(string.Format("{0} {1}:00", shiftDate.ToString("yyyy-MM-dd"), timeOffset)),
                OPERROOM = operRoom
            });
        }

        public List<SHIFT_OPERATION_INFO> GetShiftOperationInfoExtList(DateTime startDate, DateTime endDate, string inpNo, string patientName, string dept, string keyWords, string operRoom, int shiftType)
        {
            string sqlText = @"SELECT M.PATIENT_ID,
                                   M.VISIT_ID,
                                   M.OPER_ID,
                                   TO_CHAR(M.IN_DATE_TIME, 'yyyy-mm-dd') IN_DATE,
                                   NVL(D.DEPT_NAME, M.DEPT_CODE) DEPT_NAME,
                                   M.OPER_ROOM_NO,
                                   H.INP_NO,
                                   I.NAME,
                                   M.BED_NO,
                                   I.SEX,
                                   FUN_GET_PAT_AGE(I.DATE_OF_BIRTH, SYSDATE) AS AGE,
                                   M.OPERATION_NAME,
                                   NVL(SUR.USER_NAME, M.SURGEON) SURGEON_NAME,
                                   NVL(FIRO.USER_NAME, M.FIRST_OPER_ASSISTANT) FIRST_OPER_ASSISTANT_NAME,
                                   M.ANES_METHOD,
                                   NVL(ANES.USER_NAME, M.ANES_DOCTOR) ANES_DOCTOR_NAME,
                                   NVL(FIRA.USER_NAME, M.FIRST_ANES_ASSISTANT) FIRST_ANES_ASSISTANT_NAME,
                                   NVL(FIRON.USER_NAME, M.FIRST_OPER_NURSE) FIRST_OPER_NURSE_NAME,
                                   NVL(FIRSN.USER_NAME, M.FIRST_SUPPLY_NURSE) FIRST_SUPPLY_NURSE_NAME,
                                   M.IN_DATE_TIME,
                                   M.ANES_START_TIME,
                                   M.START_DATE_TIME,
                                   M.END_DATE_TIME,
                                   M.ANES_END_TIME,
                                   M.OUT_DATE_TIME,
                                   M.IN_PACU_DATE_TIME,
                                   M.OUT_PACU_DATE_TIME,
                                   M.PAT_WHEREABORTS,
                                   M.ASA_GRADE,
                                   M.ANESTHESIA_ID,
                                   M.EMERGENCY_IND,
                                   M.SCHEDULED_DATE_TIME,
                                   I.DATE_OF_BIRTH,
                                   DECODE(M.ISOLATION_IND, 1, '正常', 2, '隔离') AS ISOLATION_IND,
                                   SC.SHIFT_CONTENT
                              FROM MED_OPERATION_MASTER M
                              LEFT JOIN (SELECT PATIENT_ID,
                                                VISIT_ID,
                                                OPER_ID,
                                                SHIFT_TYPE,
                                                WM_CONCAT(SHIFT_CONTENT) SHIFT_CONTENT
                                           FROM (SELECT S.PATIENT_ID,
                                                        S.VISIT_ID,
                                                        S.OPER_ID,
                                                        S.SHIFT_TYPE,
                                                        DECODE(S.SHIFT_DIVISION, 1, '术前：', 2, '术后：') ||
                                                        S.SHIFT_CONTENT || D.DETAIL_CONTENT SHIFT_CONTENT
                                                   FROM MED_SHIFT_OPERATION_SIGN S
                                                   LEFT JOIN (SELECT PATIENT_ID,
                                                                    VISIT_ID,
                                                                    OPER_ID,
                                                                    SHIFT_TYPE,
                                                                    SHIFT_DIVISION,
                                                                    WM_CONCAT(RECORD_NO || '.' ||
                                                                              SPOKESMEN || ':' ||
                                                                              SHIFT_DETAIL_CONTENT) DETAIL_CONTENT
                                                               FROM MED_SHIFT_OPERATION_DATA
                                                              GROUP BY PATIENT_ID,
                                                                       VISIT_ID,
                                                                       OPER_ID,
                                                                       SHIFT_TYPE,
                                                                       SHIFT_DIVISION) D
                                                     ON S.PATIENT_ID = D.PATIENT_ID
                                                        AND S.VISIT_ID = D.VISIT_ID
                                                        AND S.OPER_ID = D.OPER_ID
                                                        AND S.SHIFT_TYPE = D.SHIFT_TYPE
                                                        AND S.SHIFT_DIVISION = D.SHIFT_DIVISION)
                                          GROUP BY PATIENT_ID, VISIT_ID, OPER_ID, SHIFT_TYPE) SC
                                ON M.PATIENT_ID = SC.PATIENT_ID
                                   AND M.VISIT_ID = SC.VISIT_ID
                                   AND M.OPER_ID = SC.OPER_ID
                              LEFT JOIN MED_PAT_MASTER_INDEX I
                                ON M.PATIENT_ID = I.PATIENT_ID
                              LEFT JOIN MED_DEPT_DICT D
                                ON M.DEPT_CODE = D.DEPT_CODE
                              LEFT JOIN MED_PATS_IN_HOSPITAL H
                                ON M.PATIENT_ID = H.PATIENT_ID
                              LEFT JOIN MED_HIS_USERS SUR
                                ON M.SURGEON = SUR.USER_JOB_ID
                              LEFT JOIN MED_HIS_USERS FIRO
                                ON M.FIRST_OPER_ASSISTANT = FIRO.USER_JOB_ID
                              LEFT JOIN MED_HIS_USERS ANES
                                ON M.ANES_DOCTOR = ANES.USER_JOB_ID
                              LEFT JOIN MED_HIS_USERS FIRA
                                ON M.FIRST_ANES_ASSISTANT = FIRA.USER_JOB_ID
                              LEFT JOIN MED_HIS_USERS FIRON
                                ON M.FIRST_OPER_NURSE = FIRON.USER_JOB_ID
                              LEFT JOIN MED_HIS_USERS FIRSN
                                ON M.FIRST_SUPPLY_NURSE = FIRSN.USER_JOB_ID
                             WHERE ((M.IN_DATE_TIME >= :SDATE - 1
                                   AND M.IN_DATE_TIME <= :EDATE)
                                   OR (M.SCHEDULED_DATE_TIME >= :SDATE - 1
                                   AND M.SCHEDULED_DATE_TIME <= :EDATE + 1))
                                   AND (:INPNO IS NULL OR H.INP_NO LIKE '%' || :INPNO || '%')
                                   AND (:PATIENTNAME IS NULL OR I.NAME LIKE '%' || :PATIENTNAME || '%')
                                   AND (:DEPT IS NULL OR M.DEPT_CODE = :DEPT)
                                   AND
                                   (:KEYWORDS IS NULL OR SC.SHIFT_CONTENT LIKE '%' || :KEYWORDS || '%' OR
                                   M.DIAG_BEFORE_OPERATION LIKE '%' || :KEYWORDS || '%' OR
                                   M.OPERATION_NAME LIKE '%' || :KEYWORDS || '%')
                                   AND (:OPERROOM IS NULL
                                        OR M.OPER_ROOM IN (SELECT REGEXP_SUBSTR(:OPERROOM, '[^,]+', 1, ROWNUM)
                                            FROM DUAL
                                        CONNECT BY ROWNUM <= LENGTH(REGEXP_REPLACE(:OPERROOM, '[^,]+', '')) + 1 ))
                                   AND SC.SHIFT_TYPE = :SHIFTTYPE";
            return dapper.Set<SHIFT_OPERATION_INFO>()
             .Query(sqlText,
             new
             {
                 SDATE = startDate,
                 EDATE = endDate,
                 INPNO = inpNo,
                 PATIENTNAME = patientName,
                 DEPT = dept,
                 KEYWORDS = keyWords,
                 OPERROOM = operRoom,
                 SHIFTTYPE = shiftType
             });
        }

        public List<MED_SHIFT_OPERATION_FILES> GetShiftOperationFiles(string patientID, int visitID, int operID, int shiftType, int shiftDivision)
        {
            return dapper.Set<MED_SHIFT_OPERATION_FILES>().Select(x => x.PATIENT_ID == patientID &&
                               x.VISIT_ID == visitID &&
                               x.OPER_ID == operID &&
                               x.SHIFT_TYPE == shiftType &&
                               x.SHIFT_DIVISION == shiftDivision).OrderBy(x1 => x1.UPLOAD_DATETIME).ToList();
        }

        public bool FileIsExist(string patientID, int visitID, int operID, int shiftType, int shiftDivision, string fileName)
        {
            return dapper.Set<MED_SHIFT_OPERATION_FILES>().Single(x => x.PATIENT_ID == patientID &&
                               x.VISIT_ID == visitID &&
                               x.OPER_ID == operID &&
                               x.SHIFT_TYPE == shiftType &&
                               x.SHIFT_DIVISION == shiftDivision &&
                               x.FILE_NAME == fileName) != null ? true : false;
        }

        public bool SaveShiftFileInfo(MED_SHIFT_OPERATION_FILES item)
        {
            bool result = dapper.Set<MED_SHIFT_OPERATION_FILES>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public bool DeleteShiftFileInfo(MED_SHIFT_OPERATION_FILES item)
        {
            bool result = dapper.Set<MED_SHIFT_OPERATION_FILES>().Delete(item);

            dapper.SaveChanges();

            return result;
        }

        public int GetRecordNo(string patientID, int visitID, int operID, int shiftType, int shiftDivision)
        {
            int result = 0;

            var item = GetShiftOperationData(patientID, visitID, operID, shiftType, shiftDivision);

            if (item == null || item.Count == 0)
            {
                result = 1;
            }
            else
            {
                result = item.Max(x => x.RECORD_NO) + 1;
            }

            return result;
        }

        public List<MED_SHIFT_OPERATION_DATA> GetShiftOperationData(string patientID, int visitID, int operID, int shiftType, int shiftDivision)
        {
            return dapper.Set<MED_SHIFT_OPERATION_DATA>().Select(x => x.PATIENT_ID == patientID &&
                                x.VISIT_ID == visitID &&
                                x.OPER_ID == operID &&
                                x.SHIFT_TYPE == shiftType &&
                                x.SHIFT_DIVISION == shiftDivision);
        }

        public bool SaveShiftOperationData(MED_SHIFT_OPERATION_DATA item)
        {
            bool result = dapper.Set<MED_SHIFT_OPERATION_DATA>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public bool DeleteSehiftOperationData(MED_SHIFT_OPERATION_DATA item)
        {
            bool result = dapper.Set<MED_SHIFT_OPERATION_DATA>().Delete(item);

            dapper.SaveChanges();

            return result;
        }

        public bool SaveShiftOperationSign(MED_SHIFT_OPERATION_SIGN item)
        {
            bool result = dapper.Set<MED_SHIFT_OPERATION_SIGN>().Save(item);

            dapper.SaveChanges();

            return result;
        }

        public int DeleteAllShiftFileInfo(List<MED_SHIFT_OPERATION_FILES> item)
        {
            int result = dapper.Set<MED_SHIFT_OPERATION_FILES>().Delete(item);

            dapper.SaveChanges();

            return result;
        }

        public int DeleteAllShiftSignData(List<MED_SHIFT_OPERATION_DATA> item)
        {
            int result = dapper.Set<MED_SHIFT_OPERATION_DATA>().Delete(item);

            dapper.SaveChanges();

            return result;
        }

        public bool DeleteShiftSignData(MED_SHIFT_OPERATION_SIGN item)
        {
            bool result = dapper.Set<MED_SHIFT_OPERATION_SIGN>().Delete(item);

            dapper.SaveChanges();

            return result;
        }
    }
}
