IF OBJECT_ID('VIEW_OPERATION_LIST') IS NOT NULL
DROP VIEW VIEW_OPERATION_LIST
GO
CREATE  VIEW VIEW_OPERATION_LIST AS
SELECT
       A.PATIENT_ID,                                       --����ID (סԺ��)
       A.VISIT_ID,                                         --����סԺ��ʾ
       A.SCHEDULE_ID,                                      --��������ID
       C.NAME,                                             --����
       C.SEX,                                              --�Ա�
       C.INP_NO,                                           --סԺ��
       C.DATE_OF_BIRTH,                                    --��������
       C.NATION,                                           --����
       --�������ڿ���
       ISNULL((SELECT V_DEPT_DICT.DEPT_NAME   FROM V_DEPT_DICT WHERE V_DEPT_DICT.DEPT_CODE = A.DEPT_STAYED ),A.DEPT_STAYED ) DEPT_STAYED,
       A.BED_NO,                                           --����
       A.SCHEDULED_DATE_TIME,                              --�������ڼ�ʱ��
       --������
       A.OPERATING_ROOM,
       A.OPERATING_ROOM_NO,                                --����������
       D.BED_LABEL,                                        --����������
       A.SEQUENCE,                                         --̨��
       A.DIAG_BEFORE_OPERATION,                            --��ǰ���
       A.PATIENT_CONDITION,                                --�������
       A.OPERATION_NAME ,                                  --��������
       A.OPERATION_SCALE,                                  --�����ȼ�
        --��������
       ISNULL((SELECT V_DEPT_DICT.DEPT_NAME   FROM V_DEPT_DICT WHERE V_DEPT_DICT.DEPT_CODE = A.OPERATING_DEPT ),A.OPERATING_DEPT ) OPERATING_DEPT,
       --������
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.SURGEON ),A.SURGEON ) SURGEON,
       --��һ��������
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.FIRST_ASSISTANT ),A.FIRST_ASSISTANT ) FIRST_ASSISTANT,
       --�ڶ���������
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.SECOND_ASSISTANT ),A.SECOND_ASSISTANT ) SECOND_ASSISTANT,
       --������������
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.THIRD_ASSISTANT ),A.THIRD_ASSISTANT ) THIRD_ASSISTANT,
       --������������
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.FOURTH_ASSISTANT ),A.FOURTH_ASSISTANT ) FOURTH_ASSISTANT,
       A.ANESTHESIA_METHOD,                                --������
       --����ҽ��
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.ANESTHESIA_DOCTOR ),A.ANESTHESIA_DOCTOR ) ANESTHESIA_DOCTOR,
       --����������
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.ANESTHESIA_ASSISTANT ),A.ANESTHESIA_ASSISTANT ) ANESTHESIA_ASSISTANT,
       --�ڶ���������
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.SECOND_ANESTHESIA_DOCTOR ),A.SECOND_ANESTHESIA_DOCTOR ) SECOND_ANESTHESIA_DOCTOR,
       --������������
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.THIRD_ANESTHESIA_DOCTOR ),A.THIRD_ANESTHESIA_DOCTOR ) THIRD_ANESTHESIA_DOCTOR,
       --������������
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.FOURTH_ANESTHESIA_ASSISTANT ),A.FOURTH_ANESTHESIA_ASSISTANT ) FOURTH_ANESTHESIA_ASSISTANT,
       --��һϴ�ֻ�ʿ
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.FIRST_OPERATION_NURSE ),A.FIRST_OPERATION_NURSE ) FIRST_OPERATION_NURSE,
       --�ڶ�ϴ�ֻ�ʿ
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.SECOND_OPERATION_NURSE ),A.SECOND_OPERATION_NURSE ) SECOND_OPERATION_NURSE,
       --��һѲ�ػ�ʿ
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.FIRST_SUPPLY_NURSE ),A.FIRST_SUPPLY_NURSE ) FIRST_SUPPLY_NURSE,
       --�ڶ�Ѳ�ػ�ʿ
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.SECOND_SUPPLY_NURSE ),A.SECOND_SUPPLY_NURSE ) SECOND_SUPPLY_NURSE,
       --����Ѳ�ػ�ʿ
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.THIRD_SUPPLY_NURSE ),A.THIRD_SUPPLY_NURSE ) THIRD_SUPPLY_NURSE,
       A.NOTES_ON_OPERATION,                               --��ע
       A.REQ_DATE_TIME,                                    --��������ʱ��
       A.EMERGENCY_IND,                                    --�����־
	   A.ISOLATION_IND,                                    --�����־
	   A.RADIATE_IND,                                      --�����־
	   A.INFECTED_IND,                                     --��Ⱦ��־
       A.OPERATION_POSITION,                               --��λ
       CASE A.ANESTHESIA_METHOD WHEN '����' THEN '����' ELSE '��ǰ' END  TYPE,
       A.OPER_STATUS,
       DATEDIFF(YEAR,GETDATE(),C.DATE_OF_BIRTH) AS PAT_AGE
       FROM
       (SELECT * FROM V_OPERATION_SCHEDULE  WHERE convert(nvarchar(10),SCHEDULED_DATE_TIME,120) = convert(nvarchar(10),GETDATE(),120) AND STATE = 2) A 
	   LEFT OUTER JOIN V_PAT_MASTER_INDEX C ON  A.PATIENT_ID = C.PATIENT_ID
       LEFT OUTER JOIN V_OPERATING_ROOM D ON  A.OPERATING_ROOM = D.DEPT_CODE AND A.OPERATING_ROOM_NO = D.ROOM_NO
UNION
SELECT
       A.PATIENT_ID,                                       --����ID (סԺ��)
       A.VISIT_ID,                                         --����סԺ��ʾ
       A.OPER_ID,                                          --��������ID
       D.NAME,                                             --����
       D.SEX,                                              --�Ա�
       D.INP_NO,                                           --סԺ��
       D.DATE_OF_BIRTH,                                    --��������
       D.NATION,                                           --����
       --�������ڿ���
      ISNULL((SELECT V_DEPT_DICT.DEPT_NAME   FROM V_DEPT_DICT WHERE V_DEPT_DICT.DEPT_CODE = A.DEPT_STAYED ),A.DEPT_STAYED ) DEPT_STAYED,
       A.BED_NO,                                           --����
       A.START_DATE_TIME,                                  --�������ڼ�ʱ��
       --������
       A.OPERATING_ROOM,
       A.OPERATING_ROOM_NO,                                --����������
       E.BED_LABEL,                                        --����������
       A.SEQUENCE,                                         --̨��
       A.DIAG_BEFORE_OPERATION,                            --��ǰ���
       A.PATIENT_CONDITION,                                --�������
       A.OPERATION_NAME ,                                       --��������
       A.OPERATION_SCALE,                                  --�����ȼ�
       --��������
      ISNULL((SELECT V_DEPT_DICT.DEPT_NAME   FROM V_DEPT_DICT WHERE V_DEPT_DICT.DEPT_CODE = A.OPERATING_DEPT ),A.OPERATING_DEPT ) OPERATING_DEPT,
       --������
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.SURGEON ),A.SURGEON ) SURGEON,
       --��һ��������
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.FIRST_ASSISTANT ),A.FIRST_ASSISTANT ) FIRST_ASSISTANT,
       --�ڶ���������
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.SECOND_ASSISTANT ),A.SECOND_ASSISTANT ) SECOND_ASSISTANT,
       --������������
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.THIRD_ASSISTANT ),A.THIRD_ASSISTANT ) THIRD_ASSISTANT,
       --������������
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.FOURTH_ASSISTANT ),A.FOURTH_ASSISTANT ) FOURTH_ASSISTANT,
       A.ANESTHESIA_METHOD,                                --������
       --����ҽ��
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.ANESTHESIA_DOCTOR ),A.ANESTHESIA_DOCTOR ) ANESTHESIA_DOCTOR,
       --����������
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.ANESTHESIA_ASSISTANT ),A.ANESTHESIA_ASSISTANT ) ANESTHESIA_ASSISTANT,
       --�ڶ���������
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.SECOND_ANESTHESIA_DOCTOR ),A.SECOND_ANESTHESIA_DOCTOR ) SECOND_ANESTHESIA_DOCTOR,
       --������������
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.THIRD_ANESTHESIA_DOCTOR ),A.THIRD_ANESTHESIA_DOCTOR ) THIRD_ANESTHESIA_DOCTOR,
       --������������
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.FOURTH_ANESTHESIA_ASSISTANT ),A.FOURTH_ANESTHESIA_ASSISTANT ) FOURTH_ANESTHESIA_ASSISTANT,
       --��һϴ�ֻ�ʿ
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.FIRST_OPERATION_NURSE ),A.FIRST_OPERATION_NURSE ) FIRST_OPERATION_NURSE,
       --�ڶ�ϴ�ֻ�ʿ
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.SECOND_OPERATION_NURSE ),A.SECOND_OPERATION_NURSE ) SECOND_OPERATION_NURSE,
       --��һѲ�ػ�ʿ
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.FIRST_SUPPLY_NURSE ),A.FIRST_SUPPLY_NURSE ) FIRST_SUPPLY_NURSE,
       --�ڶ�Ѳ�ػ�ʿ
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.SECOND_SUPPLY_NURSE ),A.SECOND_SUPPLY_NURSE ) SECOND_SUPPLY_NURSE,
       --����Ѳ�ػ�ʿ
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.THIRD_SUPPLY_NURSE ),A.THIRD_SUPPLY_NURSE ) THIRD_SUPPLY_NURSE,
       NULL,                                               --��ע
       NULL,                                      --��������ʱ��
	   A.EMERGENCY_IND,                              --�����־
       A.ISOLATION_IND,                                    --�����־
	   A.RADIATE_IND,                                      --�����־
	   A.INFECTED_IND,                                     --��Ⱦ��־
       A.OPERATION_POSITION,                               --��λ
       CASE A.OPER_STATUS WHEN  5 THEN '����' WHEN 10 THEN '����' WHEN 15 THEN '����' WHEN 25 THEN '����' WHEN 30 THEN '����' WHEN 35 THEN '����' WHEN 40 THEN '����' WHEN 45 THEN '����' END AS TYPE,
       A.OPER_STATUS,
	   DATEDIFF(YEAR,GETDATE(),D.DATE_OF_BIRTH) AS PAT_AGE
       FROM
       (SELECT * FROM V_OPERATION_MASTER WHERE OPER_STATUS > 0  AND
       (convert(nvarchar(10),START_DATE_TIME,120) = convert(nvarchar(10),GETDATE(),120)  OR
       convert(nvarchar(10),IN_DATE_TIME,120) = convert(nvarchar(10),GETDATE(),120)) AND
       --TRUNC((SYSDATE-ISNULL(OUT_DATE_TIME,SYSDATE))*1440 ) <  5   AND  --���5��������5���Ӳ���ʾ
       OPER_STATUS < 50 ) A
	   LEFT OUTER JOIN V_PAT_MASTER_INDEX D ON A.PATIENT_ID = D.PATIENT_ID
	   LEFT OUTER JOIN V_OPERATING_ROOM E ON A.OPERATING_ROOM = E.DEPT_CODE AND A.OPERATING_ROOM_NO = E.ROOM_NO;
