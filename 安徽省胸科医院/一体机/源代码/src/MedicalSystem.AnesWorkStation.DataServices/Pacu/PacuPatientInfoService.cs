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

    public interface IPacuPatientInfoService
    {
        /// <summary>
        /// 获取手术信息列表
        /// </summary>
        /// <param name="startDate">手术开始时间</param>
        /// <param name="patientID">病人ID</param>
        /// <param name="patientName">病人姓名</param>
        /// <param name="anesthesiaDoctor">麻醉医生</param>
        /// <param name="departCode">科室号</param>
        /// <param name="operationStatus">麻醉状态</param>
        /// <param name="asa">ASA分级</param>
        /// <param name="operationName">手术名称</param>
        /// <param name="anesthesiaMethod">麻醉方法</param>
        /// <param name="age">年龄-低值</param>
        /// <param name="age1">年龄-高值</param>
        /// <param name="isSelfOpera">是否自己相关的手术</param>
        /// <param name="isJiZhen">是否急诊</param>
        /// <param name="isZeQi">是否择期</param>
        /// <param name="userName">登陆者ID</param>
        /// <returns>List<MED_OPERATION_MASTER></returns>
        List<MED_OPERATION_MASTER> GetPatMasterInfoList(string startDate, string patientID, string patientName, string anesthesiaDoctor, string departCode
            , string operationStatus, string asa, string operationName, string anesthesiaMethod, string age, string age1, string isSelfOpera, string isJiZhen, string isZeQi, string userName);

        /// <summary>
        /// 获取患者列表信息
        /// </summary>
        /// <param name="operDateTime"></param>
        /// <param name="patientID"></param>
        /// <param name="operRoomNo"></param>
        /// <param name="operRoom"></param>
        /// <param name="hospBranch"></param>
        /// <returns></returns>
        List<MED_PATIENT_CARD> GetPatCardList(DateTime operDateTime, string inpNo, string operRoomNo, string operRoom, string hospBranch, bool IsSearch);

        MED_PATIENT_CARD GetPatCard(string patientID, int visitID, int operID);

        /// <summary>
        /// 获取当前患者列表信息
        /// </summary>
        /// <param name="operDateTime"></param>
        /// <param name="operRoomNo"></param>
        /// <param name="operRoom"></param>
        /// <param name="hospBranch"></param>
        /// <returns></returns>
        List<MED_PATIENT_CARD> GetCurrentPatCardList(DateTime operDateTime, string operRoomNo, string operRoom, string hospBranch);

        List<MED_PATIENT_CARD> GetPatientListByDate(DateTime operStartTime, DateTime operEndTime, string operRoomNo, string operRoom, string hospBranch);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="operDateTime"></param>
        /// <param name="operRoom"></param>
        /// <param name="hospBranch"></param>
        /// <returns></returns>
        List<MED_OPERATION_MASTER> GetOperMasterListByPacuTime(DateTime operDateTime, string operRoom, string hospBranch);

        List<MED_PATIENT_CARD> GetPatientListDataTable(DateTime startDate, string deptCode, string hospBranch);

        List<MED_PATIENT_CARD> GetPatientListDataTableByPACU(DateTime startDate, string deptCode, string hospBranch, string searchStr);

        List<MED_PATIENT_CARD> GetPatientListDataTableByPatientID(string patientID, string deptCode, string hospBranch);
    }
    public class PacuPatientInfoService : BaseService<PacuPatientInfoService>, IPacuPatientInfoService
    {
        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected PacuPatientInfoService()
            : base() { }

        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public PacuPatientInfoService(IDapperContext context)
            : base(context)
        {
        }

        public List<MED_OPERATION_MASTER> GetPatMasterInfoList(string startDate, string patientID, string patientName, string anesthesiaDoctor, string departCode, string operationStatus, string asa, string operationName, string anesthesiaMethod, string age, string age1, string isSelfOpera, string isJiZhen, string isZeQi, string userName)
        {

            DateTime dtStart = DateTime.Now;
            DateTime dtEnd = dtStart.AddDays(1);
            List<object> objects = new List<object>();

            string sqlText = "SELECT distinct A.PATIENT_ID,A.VISIT_ID,A.OPER_ID,OPER_STATUS,B.NAME,OPERATING_ROOM_NO,BED_NO,SEQUENCE ,  B.INP_NO,  "
            + " ANESTHESIA_DOCTOR,SECOND_ANESTHESIA_DOCTOR,THIRD_ANESTHESIA_DOCTOR,ANESTHESIA_ASSISTANT,SECOND_ANESTHESIA_ASSISTANT,SURGEON,FIRST_ASSISTANT,SECOND_ASSISTANT,THIRD_ASSISTANT,FOURTH_ASSISTANT,FOURTH_ANESTHESIA_ASSISTANT,FIRST_OPERATION_NURSE,SECOND_OPERATION_NURSE,FIRST_SUPPLY_NURSE,SECOND_SUPPLY_NURSE,THIRD_SUPPLY_NURSE,"
            + "SCHEDULED_DATE_TIME,START_DATE_TIME,SURGEON,OPERATION_NAME,OPERATION_SCALE,EMERGENCY_INDICATOR,ISOLATION_INDICATOR FROM MED_OPERATION_MASTER A "
            + " LEFT OUTER JOIN MED_PAT_MASTER_INDEX B ON A.PATIENT_ID=B.PATIENT_ID"
            + " LEFT OUTER JOIN MED_CUSTOM_DATA C ON A.PATIENT_ID=C.PATIENT_ID AND A.VISIT_ID=C.VISIT_ID AND A.OPER_ID=C.OPER_ID AND C.ITEM_NAME='镇痛泵停机时间' "
            + " WHERE 1=1 ";


            string pID = patientID;
            if (!string.IsNullOrEmpty(pID))
            {
                sqlText = sqlText + " AND (A.PATIENT_ID LIKE '%" + pID + "%' OR B.INP_NO LIKE '%" + pID + "%')";
            }
            string name = patientName;
            if (!string.IsNullOrEmpty(name))
            {
                sqlText = sqlText + " AND (B.NAME LIKE '%" + name + "%')";
            }
            string text = anesthesiaDoctor;
            if (!string.IsNullOrEmpty(text))
            {
                //text为用#分割的名字和ID组合
                string[] docsArr = text.Split(new char[] { '#' });
                sqlText = sqlText + " AND ( 1 = 2 ";
                for (int i = 0; i < docsArr.Length; i++)
                {
                    if (docsArr[i].Length > 0)
                    {

                        sqlText = sqlText + " OR (A.ANESTHESIA_DOCTOR LIKE '%" + docsArr[i] + "%' )";
                        sqlText = sqlText + " OR (A.SECOND_ANESTHESIA_DOCTOR LIKE '%" + docsArr[i] + "%' )";
                        sqlText = sqlText + " OR (A.THIRD_ANESTHESIA_DOCTOR LIKE '%" + docsArr[i] + "%' )";
                        sqlText = sqlText + " OR (A.ANESTHESIA_ASSISTANT LIKE '%" + docsArr[i] + "%' )";
                        sqlText = sqlText + " OR (A.SECOND_ANESTHESIA_ASSISTANT LIKE '%" + docsArr[i] + "%' )";
                        sqlText = sqlText + " OR (A.THIRD_ANESTHESIA_ASSISTANT LIKE '%" + docsArr[i] + "%' )";
                        sqlText = sqlText + " OR (A.FOURTH_ANESTHESIA_ASSISTANT LIKE '%" + docsArr[i] + "%' )";
                    }
                }
                sqlText = sqlText + " ) ";
            }
            text = departCode;
            if (!string.IsNullOrEmpty(text))
            {

                sqlText = sqlText + " AND (DEPT_STAYED = '" + text + "')";
            }
            text = operationStatus;
            if (!string.IsNullOrEmpty(text))
            {

                sqlText = sqlText + " AND (A.OPER_STATUS = " + text + ")";
            }

            text = operationName;
            if (!string.IsNullOrEmpty(text))
            {
                sqlText = sqlText + " AND (A.OPERATION_NAME LIKE '%" + text + "%')";
            }
            text = anesthesiaMethod;
            if (!string.IsNullOrEmpty(text))
            {
                sqlText = sqlText + " AND (A.ANESTHESIA_METHOD LIKE '%" + text + "%')";
            }
            text = age;
            if (!string.IsNullOrEmpty(text))
            {
                int theAge = 0;
                if (int.TryParse(text, out theAge))
                {
                    DateTime dtStart1 = DateTime.Now.AddYears(-theAge);
                    dtStart1 = new DateTime(dtStart1.Year, 1, 1);
                    DateTime dtEnd1 = dtStart1.AddYears(1).AddSeconds(-1);
                    if (!string.IsNullOrEmpty(age1))
                    {
                        if (int.TryParse(age1, out theAge))
                        {
                            dtStart1 = new DateTime(DateTime.Now.Year - theAge, 1, 1);
                        }
                    }

                }
            }

            if (isSelfOpera.ToLower() == "true")
            {

                sqlText = sqlText + " AND (A.ANESTHESIA_DOCTOR='" + userName.Split(',')[0].ToString() + "' OR A.ANESTHESIA_DOCTOR='" + userName.Split(',')[1].ToString() + "')";
            }

            if (isJiZhen.ToLower() == "true")
            {
                sqlText = sqlText + " AND A.EMERGENCY_INDICATOR=1 ";
            }

            if (isZeQi.ToLower() == "true")
            {
                sqlText = sqlText + " AND A.EMERGENCY_INDICATOR=0 ";
            }


            //}
            sqlText = sqlText + " ORDER BY OPER_STATUS , A.OPERATING_ROOM_NO,SEQUENCE,START_DATE_TIME  ";

            //会存在一对多的问题所以限制了下VISIT_ID='1' AND OPER_ID='1'，仅供参考
            return dapper.Set<MED_OPERATION_MASTER>().Query(sqlText);
        }

        public List<MED_PATIENT_CARD> GetPatCardList(DateTime operDateTime, string inpNo, string operRoomNo, string operRoom, string hospBranch, bool IsSearch)
        {

            string sqlText = @"SELECT M.*,I.NAME,I.SEX,I.DATE_OF_BIRTH,V.INP_NO,FUN_GET_PAT_AGE(I.DATE_OF_BIRTH,M.SCHEDULED_DATE_TIME) AS AGE,D.SORT_NO FROM MED_OPERATION_MASTER M
                                LEFT JOIN MED_PAT_MASTER_INDEX I ON I.PATIENT_ID = M.PATIENT_ID
                                LEFT JOIN MED_OPERATING_ROOM D ON M.OPER_ROOM_NO=D.ROOM_NO 
                                LEFT JOIN MED_PAT_VISIT V ON V.PATIENT_ID=M.PATIENT_ID AND V.VISIT_ID=M.VISIT_ID
                                WHERE 1=1 ";
            //string partSql = " AND (M.OPER_STATUS_CODE IS NULL OR M.OPER_STATUS_CODE='' OR M.OPER_STATUS_CODE =0)";
            string partSql = " AND (M.OPER_STATUS_CODE IS NULL OR M.OPER_STATUS_CODE='' OR M.OPER_STATUS_CODE <=35)";
            //if (string.IsNullOrEmpty(inpNo))
            if (!IsSearch)
            {
                sqlText += partSql;
            }
            //else
            if (!string.IsNullOrEmpty(inpNo))
            {
                sqlText = sqlText + " AND V.INP_NO ='" + inpNo + "'";
            }
            if (!string.IsNullOrEmpty(operRoomNo))
            {
                sqlText = sqlText + " AND M.OPER_ROOM_NO ='" + operRoomNo + "'";
            }
            if (!string.IsNullOrEmpty(operRoom))
            {
                sqlText = sqlText + " AND M.OPER_ROOM ='" + operRoom + "'";
            }
            if (!string.IsNullOrEmpty(hospBranch))
            {
                sqlText = sqlText + " AND M.HOSP_BRANCH ='" + hospBranch + "'";
            }

            if (dapper.DBType == DatabaseType.Oracle)
            {
                sqlText = sqlText + " AND TO_CHAR(M.SCHEDULED_DATE_TIME,'yyyy-MM-dd') = '" + operDateTime.ToString("yyyy-MM-dd") + "'";
            }
            else
            {
                sqlText = sqlText + " AND CONVERT(CHAR(7),M.SCHEDULED_DATE_TIME,120) = '" + operDateTime.ToString("yyyy-MM-dd") + "'";
            }

            sqlText += "  ORDER BY M.OPER_STATUS_CODE DESC ,M.SEQUENCE ASC ,M.SCHEDULED_DATE_TIME ASC";

            return dapper.Set<MED_PATIENT_CARD>().Query(sqlText);

        }

        public MED_PATIENT_CARD GetPatCard(string patientID, int visitID, int operID)
        {
            string sqlText = @"SELECT A.* , NVL(E.DEPT_NAME, A.DEPT_CODE) AS OPER_DEPT_NAME, B.NAME, B.SEX, B.DATE_OF_BIRTH,FUN_GET_PAT_AGE(B.DATE_OF_BIRTH,A.SCHEDULED_DATE_TIME) AS AGE, C.INP_NO,D.SORT_NO FROM MED_OPERATION_MASTER A
                                LEFT JOIN MED_PAT_MASTER_INDEX B ON B.PATIENT_ID = A.PATIENT_ID
                                LEFT JOIN MED_PAT_VISIT C ON C.PATIENT_ID=A.PATIENT_ID AND C.VISIT_ID=A.VISIT_ID
                                LEFT JOIN MED_OPERATING_ROOM D ON A.OPER_ROOM_NO=D.ROOM_NO
                                LEFT JOIN MED_DEPT_DICT E ON E.DEPT_CODE=A.DEPT_CODE
                                WHERE 1=1 ";
            sqlText += " AND (A.PATIENT_ID='" + patientID + "' AND A.VISIT_ID=" + visitID + " AND A.OPER_ID=" + operID + ")";

            return dapper.Set<MED_PATIENT_CARD>().Query(sqlText).FirstOrDefault();
        }

        public List<MED_PATIENT_CARD> GetCurrentPatCardList(DateTime operDateTime, string operRoomNo, string operRoom, string hospBranch)
        {

            string sqlText = @"SELECT M.*, I.NAME, I.SEX, I.DATE_OF_BIRTH, V.INP_NO,D.SORT_NO
                                  FROM MED_OPERATION_MASTER M
                                  LEFT JOIN MED_PAT_MASTER_INDEX I
                                    ON I.PATIENT_ID = M.PATIENT_ID
                                LEFT JOIN MED_OPERATING_ROOM D ON M.OPER_ROOM_NO=D.ROOM_NO
                                  LEFT JOIN MED_PAT_VISIT V
                                    ON V.PATIENT_ID = M.PATIENT_ID
                                   AND V.VISIT_ID = M.VISIT_ID ";
            //WHERE (((M.OPER_STATUS_CODE IS NULL OR M.OPER_STATUS_CODE = '' OR
            //      M.OPER_STATUS_CODE = 0) AND M.SEQUENCE = 1) OR
            //      (M.OPER_STATUS_CODE>5 AND M.OPER_STATUS_CODE<=35))";
            sqlText += " WHERE ( M.OPER_STATUS_CODE IS NULL OR M.OPER_STATUS_CODE='' OR M.OPER_STATUS_CODE < 35 )  ";
            if (!string.IsNullOrEmpty(operRoomNo))
            {
                sqlText = sqlText + " AND M.OPER_ROOM_NO ='" + operRoomNo + "'";
            }
            if (!string.IsNullOrEmpty(operRoom))
            {
                sqlText = sqlText + " AND M.OPER_ROOM ='" + operRoom + "'";
            }
            if (!string.IsNullOrEmpty(hospBranch))
            {
                sqlText = sqlText + " AND M.HOSP_BRANCH ='" + hospBranch + "'";
            }

            if (dapper.DBType == DatabaseType.Oracle)
            {
                sqlText = sqlText + " AND TO_CHAR(M.SCHEDULED_DATE_TIME,'yyyy-MM-dd') = '" + operDateTime.ToString("yyyy-MM-dd") + "'";
            }
            else
            {
                sqlText = sqlText + " AND CONVERT(CHAR(7),M.SCHEDULED_DATE_TIME,120) = '" + operDateTime.ToString("yyyy-MM-dd") + "'";
            }


            sqlText += "  ORDER BY M.OPER_STATUS_CODE DESC ,M.SEQUENCE ASC  ,M.SCHEDULED_DATE_TIME ASC";

            return dapper.Set<MED_PATIENT_CARD>().Query(sqlText);


        }

        public List<MED_PATIENT_CARD> GetPatientListByDate(DateTime operStartTime, DateTime operEndTime, string operRoomNo, string operRoom, string hospBranch)
        {
            string sqlText = @"SELECT M.*, I.NAME, I.SEX, I.DATE_OF_BIRTH, V.INP_NO,B.DEPT_NAME as OPER_DEPT_NAME,
                               FUN_GET_PAT_AGE(I.DATE_OF_BIRTH,M.SCHEDULED_DATE_TIME) AS AGE,D.SORT_NO, 
       NVL(E.USER_NAME, M.SURGEON) || ' ' ||
       NVL(F.USER_NAME, M.FIRST_OPER_ASSISTANT) AS SURGEON_NAME,
       NVL(G.USER_NAME, M.ANES_DOCTOR) || ' ' ||
       NVL(H.USER_NAME, M.FIRST_ANES_ASSISTANT) AS ANES_DOCTOR_NAME
                               FROM MED_OPERATION_MASTER M
                               LEFT JOIN MED_PAT_MASTER_INDEX I
                               ON I.PATIENT_ID = M.PATIENT_ID
                               LEFT JOIN MED_DEPT_DICT B ON M.OPER_DEPT_CODE = B.DEPT_CODE
                               LEFT JOIN MED_OPERATING_ROOM D ON M.OPER_ROOM_NO=D.ROOM_NO
                               LEFT JOIN MED_PAT_VISIT V
                               ON V.PATIENT_ID = M.PATIENT_ID
                               AND V.VISIT_ID = M.VISIT_ID
  LEFT OUTER JOIN MED_HIS_USERS E ON M.SURGEON = E.USER_JOB_ID
  LEFT OUTER JOIN MED_HIS_USERS F ON M.FIRST_OPER_ASSISTANT = E.USER_JOB_ID
  LEFT OUTER JOIN MED_HIS_USERS G ON M.ANES_DOCTOR = G.USER_JOB_ID
  LEFT OUTER JOIN MED_HIS_USERS H ON M.FIRST_ANES_ASSISTANT = H.USER_JOB_ID ";
            sqlText += " WHERE ( M.OPER_STATUS_CODE>=35";
            if (!string.IsNullOrEmpty(operRoomNo))
            {
                sqlText = sqlText + " AND M.OPER_ROOM_NO ='" + operRoomNo + "'";
            }
            if (!string.IsNullOrEmpty(operRoom))
            {
                sqlText = sqlText + " AND M.OPER_ROOM ='" + operRoom + "'";
            }
            if (!string.IsNullOrEmpty(hospBranch))
            {
                sqlText = sqlText + " AND M.HOSP_BRANCH ='" + hospBranch + "'";
            }

            if (dapper.DBType == DatabaseType.Oracle)
            {
                sqlText = sqlText + " AND TO_CHAR(M.START_DATE_TIME,'yyyy-MM-dd') >= '" + operStartTime.ToString("yyyy-MM-dd") + "'";
                sqlText = sqlText + " AND TO_CHAR(M.START_DATE_TIME,'yyyy-MM-dd') <= '" + operEndTime.ToString("yyyy-MM-dd") + "'";
            }
            else
            {
                sqlText = sqlText + " AND CONVERT(CHAR(7),M.START_DATE_TIME,120) >= '" + operStartTime.ToString("yyyy-MM-dd") + "'";
                sqlText = sqlText + " AND CONVERT(CHAR(7),M.START_DATE_TIME,120) <='" + operEndTime.ToString("yyyy-MM-dd") + "'";
            }
            sqlText += " )";
            sqlText += "  ORDER BY M.OPER_ROOM_NO ASC ,M.SCHEDULED_DATE_TIME DESC";

            return dapper.Set<MED_PATIENT_CARD>().Query(sqlText);
        }

        public List<MED_OPERATION_MASTER> GetOperMasterListByPacuTime(DateTime operDateTime, string operRoom, string hospBranch)
        {
            string sqlText = "SELECT PATIENT_ID,VISIT_ID,OPER_ID,IN_PACU_DATE_TIME,OPER_ROOM,HOSP_BRANCH FROM MED_OPERATION_MASTER  WHERE 1=1";

            if (dapper.DBType == DatabaseType.Oracle)
            {
                sqlText = sqlText + " AND TO_CHAR(IN_PACU_DATE_TIME,'yyyy-MM-dd') = '" + operDateTime.ToString("yyyy-MM-dd") + "'";
            }
            else
            {
                sqlText = sqlText + " AND CONVERT(CHAR(7),IN_PACU_DATE_TIME,120) = '" + operDateTime.ToString("yyyy-MM-dd") + "'";
            }
            if (!string.IsNullOrEmpty(operRoom))
            {
                sqlText = sqlText + " AND OPER_ROOM ='" + operRoom + "'";
            }
            if (!string.IsNullOrEmpty(hospBranch))
            {
                sqlText = sqlText + " AND HOSP_BRANCH ='" + hospBranch + "'";
            }

            return dapper.Set<MED_OPERATION_MASTER>().Query(sqlText);
        }

        public List<MED_PATIENT_CARD> GetPatientListDataTable(DateTime startDate, string deptCode, string hospBranch)
        {
            string sqlText = @"SELECT A.* ,N.SORT_NO, NVL(E.DEPT_NAME, A.DEPT_CODE) AS OPER_DEPT_NAME, B.NAME, B.SEX, B.DATE_OF_BIRTH, C.INP_NO,FUN_GET_PAT_AGE(B.DATE_OF_BIRTH,A.SCHEDULED_DATE_TIME) AS AGE,D.SORT_NO FROM MED_OPERATION_MASTER A
                                LEFT JOIN MED_PAT_MASTER_INDEX B ON B.PATIENT_ID = A.PATIENT_ID
                                LEFT JOIN MED_OPERATING_ROOM D ON A.OPER_ROOM_NO=D.ROOM_NO
                                LEFT JOIN MED_PAT_VISIT C ON C.PATIENT_ID=A.PATIENT_ID AND C.VISIT_ID=A.VISIT_ID
                                LEFT JOIN MED_DEPT_DICT E ON E.DEPT_CODE=A.DEPT_CODE
                                LEFT JOIN MED_OPERATING_ROOM N ON A.OPER_ROOM_NO=N.ROOM_NO 
                                WHERE 1=1 ";

            if (startDate > DateTime.MinValue && startDate < DateTime.MaxValue)
            {
                if (dapper.DBType == DatabaseType.Oracle)
                {
                    sqlText = sqlText + "  AND (TO_CHAR(A.SCHEDULED_DATE_TIME,'yyyy-MM-dd') = '" + startDate.ToString("yyyy-MM-dd") + "'";
                    sqlText = sqlText + " OR (TO_CHAR(A.SCHEDULED_DATE_TIME,'yyyy-MM-dd') = '" + startDate.AddDays(-1).ToString("yyyy-MM-dd") + "' AND A.OPER_STATUS_CODE>=5 AND A.OPER_STATUS_CODE<35)) ";
                }
                else
                {
                    sqlText = sqlText + " ( AND CONVERT(CHAR(7),A.SCHEDULED_DATE_TIME,120) = '" + startDate.ToString("yyyy-MM-dd") + "'";
                    sqlText = sqlText + " OR (CONVERT(CHAR(7),A.SCHEDULED_DATE_TIME,120) = '" + startDate.AddDays(-1).ToString("yyyy-MM-dd") + "' AND A.OPER_STATUS_CODE>=5 AND A.OPER_STATUS_CODE<35)) ";
                }
            }
            string text = deptCode;
            if (!string.IsNullOrEmpty(text))
            {
                sqlText = sqlText + " AND (A.OPER_ROOM = '" + text + "')";
            }
            if (!string.IsNullOrEmpty(hospBranch))
            {
                sqlText = sqlText + " AND A.HOSP_BRANCH ='" + hospBranch + "'";
            }
            sqlText += "  ORDER BY A.OPER_STATUS_CODE DESC ,A.SEQUENCE ASC ,A.SCHEDULED_DATE_TIME ASC";

            return dapper.Set<MED_PATIENT_CARD>().Query(sqlText);
        }

        public List<MED_PATIENT_CARD> GetPatientListDataTableByPACU(DateTime startDate, string deptCode, string hospBranch, string searchStr)
        {
            string sqlText = string.Format("SELECT A.*, B.NAME, B.SEX, B.DATE_OF_BIRTH, C.INP_NO,FUN_GET_PAT_AGE(B.DATE_OF_BIRTH,A.SCHEDULED_DATE_TIME) AS AGE,D.SORT_NO,CASE WHEN E.ROOM_NO IS NULL THEN A.OPER_ROOM_NO ELSE A.OPER_ROOM_NO || '-' || E.ROOM_NO END AS PACU_BED_NO FROM MED_OPERATION_MASTER A " +
            " LEFT JOIN MED_PAT_MASTER_INDEX B ON B.PATIENT_ID = A.PATIENT_ID" +
                               " LEFT JOIN MED_OPERATING_ROOM D ON A.OPER_ROOM_NO=D.ROOM_NO AND D.DEPT_CODE='{0}'" +
                                " LEFT JOIN MED_PAT_VISIT C ON C.PATIENT_ID=A.PATIENT_ID AND C.VISIT_ID=A.VISIT_ID" +
                                " LEFT JOIN MED_OPERATING_ROOM E ON E.PATIENT_ID=A.PATIENT_ID AND E.VISIT_ID=A.VISIT_ID AND E.OPER_ID = A.OPER_ID" +
                                " WHERE 1=1 ", deptCode);

            if (startDate > DateTime.MinValue && startDate < DateTime.MaxValue)
            {
                if (dapper.DBType == DatabaseType.Oracle)
                {
                    sqlText = sqlText + " AND (( TO_CHAR(A.OUT_DATE_TIME,'yyyy-MM-dd') = '" + startDate.ToString("yyyy-MM-dd") + "'";//
                }
                else
                {
                    sqlText = sqlText + " AND ( CONVERT(CHAR(7),A.OUT_DATE_TIME,120) = '" + startDate.ToString("yyyy-MM-dd") + "'";
                }
            }
            string text = deptCode;
            if (!string.IsNullOrEmpty(text))
            {
                // sqlText = sqlText + " AND ((A.OPER_ROOM = '" + text + "')";
                sqlText = sqlText + " AND (A.OPER_ROOM = '" + text + "')";
            }
            if (!string.IsNullOrEmpty(hospBranch))
            {
                sqlText = sqlText + " AND A.HOSP_BRANCH ='" + hospBranch + "'";
            }
            sqlText += " AND (A.OPER_STATUS_CODE IN('40','45')))  ";
            //if (startDate > DateTime.MinValue && startDate < DateTime.MaxValue)
            //{
            //    if (_context.DBType == DatabaseType.Oracle)
            //    {
            //        //sqlText = sqlText + " OR  (A.OPER_STATUS_CODE IN('40','45'))";//
            //        sqlText = sqlText + " OR (TO_CHAR(A.SCHEDULED_DATE_TIME,'yyyy-MM-dd') = '" + startDate.AddDays(-1).ToString("yyyy-MM-dd") + "' AND A.OPER_STATUS_CODE IN('40','45')) ";//
            //    }
            //    else
            //    {
            //        sqlText = sqlText + " OR (CONVERT(CHAR(7),A.SCHEDULED_DATE_TIME,120) = '" + startDate.AddDays(-1).ToString("yyyy-MM-dd") + "' AND A.OPER_STATUS_CODE IN('40','45')) ";
            //    }
            //}
            if (startDate > DateTime.MinValue && startDate < DateTime.MaxValue)
            {
                if (dapper.DBType == DatabaseType.Oracle)
                {
                    sqlText = sqlText + "  OR  TO_CHAR(A.In_Pacu_Date_Time,'yyyy-MM-dd') = '" + startDate.ToString("yyyy-MM-dd") + "' ";
                }
                else
                {
                    sqlText = sqlText + "  OR  CONVERT(CHAR(7),A.In_Pacu_Date_Time,120) = '" + startDate.ToString("yyyy-MM-dd") + "'";
                }
            }
            if (startDate > DateTime.MinValue && startDate < DateTime.MaxValue)
            {
                if (dapper.DBType == DatabaseType.Oracle)
                {
                    sqlText = sqlText + "  OR  TO_CHAR(A.OUT_PACU_DATE_TIME,'yyyy-MM-dd') = '" + startDate.ToString("yyyy-MM-dd") + "') ";
                }
                else
                {
                    sqlText = sqlText + "  OR  CONVERT(CHAR(7),A.OUT_PACU_DATE_TIME,120) = '" + startDate.ToString("yyyy-MM-dd") + "')";
                }
            }
            if (!string.IsNullOrEmpty(searchStr))
            {
                sqlText = sqlText + " AND (A.PATIENT_ID LIKE '%" + searchStr + "%' OR  C.INP_NO LIKE '%" + searchStr + "%' OR B.NAME LIKE '%" + searchStr + "%' )";
            }
            sqlText += "  ORDER BY A.OPER_STATUS_CODE DESC ,A.SEQUENCE ASC ,A.SCHEDULED_DATE_TIME ASC";

            return dapper.Set<MED_PATIENT_CARD>().Query(sqlText);
        }

        public List<MED_PATIENT_CARD> GetPatientListDataTableByPatientID(string patientID, string deptCode, string hospBranch)
        {
            string sqlText = @"SELECT A.*, B.NAME, B.SEX, B.DATE_OF_BIRTH, C.INP_NO,FUN_GET_PAT_AGE(B.DATE_OF_BIRTH,A.SCHEDULED_DATE_TIME) AS AGE,D.SORT_NO, 
                                 NVL(E.USER_NAME, A.SURGEON) || ' ' ||
                                 NVL(F.USER_NAME, A.FIRST_OPER_ASSISTANT) AS SURGEON_NAME FROM MED_OPERATION_MASTER A
                               LEFT JOIN MED_PAT_MASTER_INDEX B ON B.PATIENT_ID = A.PATIENT_ID
                               LEFT JOIN MED_OPERATING_ROOM D ON A.OPER_ROOM_NO=D.ROOM_NO
                               LEFT JOIN MED_PAT_VISIT C ON C.PATIENT_ID=A.PATIENT_ID AND C.VISIT_ID=A.VISIT_ID
                               LEFT OUTER JOIN MED_HIS_USERS E ON A.SURGEON = E.USER_JOB_ID
                               LEFT OUTER JOIN MED_HIS_USERS F ON A.FIRST_OPER_ASSISTANT = E.USER_JOB_ID
                               WHERE 1=1 ";

            if (!string.IsNullOrEmpty(patientID))
            {
                sqlText = sqlText + " AND A.PATIENT_ID ='" + patientID + "'";
            }
            string text = deptCode;
            if (!string.IsNullOrEmpty(text))
            {
                sqlText = sqlText + " AND (A.OPER_ROOM = '" + text + "')";
            }
            if (!string.IsNullOrEmpty(hospBranch))
            {
                sqlText = sqlText + " AND A.HOSP_BRANCH ='" + hospBranch + "'";
            }

            sqlText += "  ORDER BY A.SCHEDULED_DATE_TIME DESC";

            return dapper.Set<MED_PATIENT_CARD>().Query(sqlText);
        }
    }
}
