IF OBJECT_ID('VIEW_OPERATION_LIST') IS NOT NULL
DROP VIEW VIEW_OPERATION_LIST
GO
CREATE  VIEW VIEW_OPERATION_LIST AS
SELECT
       A.PATIENT_ID,                                       --病人ID (住院号)
       A.VISIT_ID,                                         --本次住院标示
       A.SCHEDULE_ID,                                      --手术申请ID
       C.NAME,                                             --名称
       C.SEX,                                              --性别
       C.INP_NO,                                           --住院号
       C.DATE_OF_BIRTH,                                    --出生日期
       C.NATION,                                           --民族
       --病人所在科室
       ISNULL((SELECT V_DEPT_DICT.DEPT_NAME   FROM V_DEPT_DICT WHERE V_DEPT_DICT.DEPT_CODE = A.DEPT_STAYED ),A.DEPT_STAYED ) DEPT_STAYED,
       A.BED_NO,                                           --床号
       A.SCHEDULED_DATE_TIME,                              --手术日期及时间
       --手术室
       A.OPERATING_ROOM,
       A.OPERATING_ROOM_NO,                                --手术间索引
       D.BED_LABEL,                                        --手术间名称
       A.SEQUENCE,                                         --台次
       A.DIAG_BEFORE_OPERATION,                            --术前诊断
       A.PATIENT_CONDITION,                                --特殊情况
       A.OPERATION_NAME ,                                  --手术名称
       A.OPERATION_SCALE,                                  --手术等级
        --手术科室
       ISNULL((SELECT V_DEPT_DICT.DEPT_NAME   FROM V_DEPT_DICT WHERE V_DEPT_DICT.DEPT_CODE = A.OPERATING_DEPT ),A.OPERATING_DEPT ) OPERATING_DEPT,
       --手术者
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.SURGEON ),A.SURGEON ) SURGEON,
       --第一手术助手
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.FIRST_ASSISTANT ),A.FIRST_ASSISTANT ) FIRST_ASSISTANT,
       --第二手术助手
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.SECOND_ASSISTANT ),A.SECOND_ASSISTANT ) SECOND_ASSISTANT,
       --第三手术助手
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.THIRD_ASSISTANT ),A.THIRD_ASSISTANT ) THIRD_ASSISTANT,
       --第四手术助手
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.FOURTH_ASSISTANT ),A.FOURTH_ASSISTANT ) FOURTH_ASSISTANT,
       A.ANESTHESIA_METHOD,                                --麻醉方法
       --麻醉医生
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.ANESTHESIA_DOCTOR ),A.ANESTHESIA_DOCTOR ) ANESTHESIA_DOCTOR,
       --第麻醉助手
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.ANESTHESIA_ASSISTANT ),A.ANESTHESIA_ASSISTANT ) ANESTHESIA_ASSISTANT,
       --第二麻醉助手
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.SECOND_ANESTHESIA_DOCTOR ),A.SECOND_ANESTHESIA_DOCTOR ) SECOND_ANESTHESIA_DOCTOR,
       --第三麻醉助手
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.THIRD_ANESTHESIA_DOCTOR ),A.THIRD_ANESTHESIA_DOCTOR ) THIRD_ANESTHESIA_DOCTOR,
       --第四麻醉助手
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.FOURTH_ANESTHESIA_ASSISTANT ),A.FOURTH_ANESTHESIA_ASSISTANT ) FOURTH_ANESTHESIA_ASSISTANT,
       --第一洗手护士
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.FIRST_OPERATION_NURSE ),A.FIRST_OPERATION_NURSE ) FIRST_OPERATION_NURSE,
       --第二洗手护士
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.SECOND_OPERATION_NURSE ),A.SECOND_OPERATION_NURSE ) SECOND_OPERATION_NURSE,
       --第一巡回护士
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.FIRST_SUPPLY_NURSE ),A.FIRST_SUPPLY_NURSE ) FIRST_SUPPLY_NURSE,
       --第二巡回护士
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.SECOND_SUPPLY_NURSE ),A.SECOND_SUPPLY_NURSE ) SECOND_SUPPLY_NURSE,
       --第三巡回护士
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.THIRD_SUPPLY_NURSE ),A.THIRD_SUPPLY_NURSE ) THIRD_SUPPLY_NURSE,
       A.NOTES_ON_OPERATION,                               --备注
       A.REQ_DATE_TIME,                                    --申请日期时间
       A.EMERGENCY_IND,                                    --急诊标志
	   A.ISOLATION_IND,                                    --隔离标志
	   A.RADIATE_IND,                                      --放射标志
	   A.INFECTED_IND,                                     --感染标志
       A.OPERATION_POSITION,                               --体位
       CASE A.ANESTHESIA_METHOD WHEN '局麻' THEN '术中' ELSE '术前' END  TYPE,
       A.OPER_STATUS,
       DATEDIFF(YEAR,GETDATE(),C.DATE_OF_BIRTH) AS PAT_AGE
       FROM
       (SELECT * FROM V_OPERATION_SCHEDULE  WHERE convert(nvarchar(10),SCHEDULED_DATE_TIME,120) = convert(nvarchar(10),GETDATE(),120) AND STATE = 2) A 
	   LEFT OUTER JOIN V_PAT_MASTER_INDEX C ON  A.PATIENT_ID = C.PATIENT_ID
       LEFT OUTER JOIN V_OPERATING_ROOM D ON  A.OPERATING_ROOM = D.DEPT_CODE AND A.OPERATING_ROOM_NO = D.ROOM_NO
UNION
SELECT
       A.PATIENT_ID,                                       --病人ID (住院号)
       A.VISIT_ID,                                         --本次住院标示
       A.OPER_ID,                                          --手术申请ID
       D.NAME,                                             --名称
       D.SEX,                                              --性别
       D.INP_NO,                                           --住院号
       D.DATE_OF_BIRTH,                                    --出生日期
       D.NATION,                                           --民族
       --病人所在科室
      ISNULL((SELECT V_DEPT_DICT.DEPT_NAME   FROM V_DEPT_DICT WHERE V_DEPT_DICT.DEPT_CODE = A.DEPT_STAYED ),A.DEPT_STAYED ) DEPT_STAYED,
       A.BED_NO,                                           --床号
       A.START_DATE_TIME,                                  --手术日期及时间
       --手术室
       A.OPERATING_ROOM,
       A.OPERATING_ROOM_NO,                                --手术间索引
       E.BED_LABEL,                                        --手术间名称
       A.SEQUENCE,                                         --台次
       A.DIAG_BEFORE_OPERATION,                            --术前诊断
       A.PATIENT_CONDITION,                                --特殊情况
       A.OPERATION_NAME ,                                       --手术名称
       A.OPERATION_SCALE,                                  --手术等级
       --手术科室
      ISNULL((SELECT V_DEPT_DICT.DEPT_NAME   FROM V_DEPT_DICT WHERE V_DEPT_DICT.DEPT_CODE = A.OPERATING_DEPT ),A.OPERATING_DEPT ) OPERATING_DEPT,
       --手术者
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.SURGEON ),A.SURGEON ) SURGEON,
       --第一手术助手
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.FIRST_ASSISTANT ),A.FIRST_ASSISTANT ) FIRST_ASSISTANT,
       --第二手术助手
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.SECOND_ASSISTANT ),A.SECOND_ASSISTANT ) SECOND_ASSISTANT,
       --第三手术助手
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.THIRD_ASSISTANT ),A.THIRD_ASSISTANT ) THIRD_ASSISTANT,
       --第四手术助手
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.FOURTH_ASSISTANT ),A.FOURTH_ASSISTANT ) FOURTH_ASSISTANT,
       A.ANESTHESIA_METHOD,                                --麻醉方法
       --麻醉医生
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.ANESTHESIA_DOCTOR ),A.ANESTHESIA_DOCTOR ) ANESTHESIA_DOCTOR,
       --第麻醉助手
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.ANESTHESIA_ASSISTANT ),A.ANESTHESIA_ASSISTANT ) ANESTHESIA_ASSISTANT,
       --第二麻醉助手
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.SECOND_ANESTHESIA_DOCTOR ),A.SECOND_ANESTHESIA_DOCTOR ) SECOND_ANESTHESIA_DOCTOR,
       --第三麻醉助手
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.THIRD_ANESTHESIA_DOCTOR ),A.THIRD_ANESTHESIA_DOCTOR ) THIRD_ANESTHESIA_DOCTOR,
       --第四麻醉助手
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.FOURTH_ANESTHESIA_ASSISTANT ),A.FOURTH_ANESTHESIA_ASSISTANT ) FOURTH_ANESTHESIA_ASSISTANT,
       --第一洗手护士
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.FIRST_OPERATION_NURSE ),A.FIRST_OPERATION_NURSE ) FIRST_OPERATION_NURSE,
       --第二洗手护士
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.SECOND_OPERATION_NURSE ),A.SECOND_OPERATION_NURSE ) SECOND_OPERATION_NURSE,
       --第一巡回护士
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.FIRST_SUPPLY_NURSE ),A.FIRST_SUPPLY_NURSE ) FIRST_SUPPLY_NURSE,
       --第二巡回护士
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.SECOND_SUPPLY_NURSE ),A.SECOND_SUPPLY_NURSE ) SECOND_SUPPLY_NURSE,
       --第三巡回护士
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.THIRD_SUPPLY_NURSE ),A.THIRD_SUPPLY_NURSE ) THIRD_SUPPLY_NURSE,
       NULL,                                               --备注
       NULL,                                      --申请日期时间
	   A.EMERGENCY_IND,                              --急诊标志
       A.ISOLATION_IND,                                    --隔离标志
	   A.RADIATE_IND,                                      --放射标志
	   A.INFECTED_IND,                                     --感染标志
       A.OPERATION_POSITION,                               --体位
       CASE A.OPER_STATUS WHEN  5 THEN '术中' WHEN 10 THEN '术中' WHEN 15 THEN '术中' WHEN 25 THEN '术中' WHEN 30 THEN '术中' WHEN 35 THEN '术中' WHEN 40 THEN '复苏' WHEN 45 THEN '复苏' END AS TYPE,
       A.OPER_STATUS,
	   DATEDIFF(YEAR,GETDATE(),D.DATE_OF_BIRTH) AS PAT_AGE
       FROM
       (SELECT * FROM V_OPERATION_MASTER WHERE OPER_STATUS > 0  AND
       (convert(nvarchar(10),START_DATE_TIME,120) = convert(nvarchar(10),GETDATE(),120)  OR
       convert(nvarchar(10),IN_DATE_TIME,120) = convert(nvarchar(10),GETDATE(),120)) AND
       --TRUNC((SYSDATE-ISNULL(OUT_DATE_TIME,SYSDATE))*1440 ) <  5   AND  --这个5代表术后5分钟不显示
       OPER_STATUS < 50 ) A
	   LEFT OUTER JOIN V_PAT_MASTER_INDEX D ON A.PATIENT_ID = D.PATIENT_ID
	   LEFT OUTER JOIN V_OPERATING_ROOM E ON A.OPERATING_ROOM = E.DEPT_CODE AND A.OPERATING_ROOM_NO = E.ROOM_NO;
