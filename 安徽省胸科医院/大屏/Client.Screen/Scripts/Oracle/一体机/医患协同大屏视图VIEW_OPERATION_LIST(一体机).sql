CREATE OR REPLACE VIEW VIEW_OPERATION_LIST AS
SELECT
       A.PATIENT_ID,                                       --����ID (סԺ��)
       A.VISIT_ID,                                         --����סԺ��ʾ
       A.OPER_ID,                                          --��������ID
       F.NAME,                                             --����
       F.SEX,                                              --�Ա�
       D.INP_NO,                                           --סԺ��
       F.DATE_OF_BIRTH,                                    --��������
       F.NATION,                                           --����
       --�������ڿ���
      NVL((SELECT V_DEPT_DICT.DEPT_NAME   FROM V_DEPT_DICT WHERE V_DEPT_DICT.DEPT_CODE = A.DEPT_STAYED ),A.DEPT_STAYED ) DEPT_STAYED,
       --C.BED_NO,                                           --����
       A.BED_NO,
       NVL(A.START_DATE_TIME,A.SCHEDULED_DATE_TIME) SCHEDULED_DATE_TIME, --�������ڼ�ʱ��
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
      NVL((SELECT V_DEPT_DICT.DEPT_NAME   FROM V_DEPT_DICT WHERE V_DEPT_DICT.DEPT_CODE = A.OPERATING_DEPT ),A.OPERATING_DEPT ) OPERATING_DEPT,
       --������
       NVL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.SURGEON ),A.SURGEON ) SURGEON,
       --��һ��������
       NVL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.FIRST_ASSISTANT ),A.FIRST_ASSISTANT ) FIRST_ASSISTANT,
       --�ڶ���������
       NVL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.SECOND_ASSISTANT ),A.SECOND_ASSISTANT ) SECOND_ASSISTANT,
       --������������
       NVL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.THIRD_ASSISTANT ),A.THIRD_ASSISTANT ) THIRD_ASSISTANT,
       --������������
       NVL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.FOURTH_ASSISTANT ),A.FOURTH_ASSISTANT ) FOURTH_ASSISTANT,
       A.ANESTHESIA_METHOD,                                --������
       --����ҽ��
       NVL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.ANESTHESIA_DOCTOR ),A.ANESTHESIA_DOCTOR ) ANESTHESIA_DOCTOR,
       --��һ��������
       NVL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.ANESTHESIA_ASSISTANT ),A.ANESTHESIA_ASSISTANT ) ANESTHESIA_ASSISTANT,
       --�ڶ���������
       NVL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.SECOND_ANESTHESIA_ASSISTANT ),A.SECOND_ANESTHESIA_ASSISTANT ) SECOND_ANESTHESIA_DOCTOR,
       --������������
       NVL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.THIRD_ANESTHESIA_ASSISTANT ),A.THIRD_ANESTHESIA_ASSISTANT ) THIRD_ANESTHESIA_DOCTOR,
       --������������
       NVL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.FOURTH_ANESTHESIA_ASSISTANT ),A.FOURTH_ANESTHESIA_ASSISTANT ) FOURTH_ANESTHESIA_ASSISTANT,
       --��һϴ�ֻ�ʿ
       NVL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.FIRST_OPERATION_NURSE ),A.FIRST_OPERATION_NURSE ) FIRST_OPERATION_NURSE,
       --�ڶ�ϴ�ֻ�ʿ
       NVL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.SECOND_OPERATION_NURSE ),A.SECOND_OPERATION_NURSE ) SECOND_OPERATION_NURSE,
       --��һѲ�ػ�ʿ
       NVL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.FIRST_SUPPLY_NURSE ),A.FIRST_SUPPLY_NURSE ) FIRST_SUPPLY_NURSE,
       --�ڶ�Ѳ�ػ�ʿ
       NVL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.SECOND_SUPPLY_NURSE ),A.SECOND_SUPPLY_NURSE ) SECOND_SUPPLY_NURSE,
       --����Ѳ�ػ�ʿ
       NVL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.THIRD_SUPPLY_NURSE ),A.THIRD_SUPPLY_NURSE ) THIRD_SUPPLY_NURSE,
       TO_DATE(NULL,'YYYY-MM-DD') REQ_TIME,                         --��������ʱ��
       A.EMERGENCY_IND,                              --�����־
       A.ISOLATION_IND,                                    --�����־
       A.RADIATE_IND,                                      --�����־
       A.INFECTED_IND,                                     --��Ⱦ��־
       A.OPERATION_POSITION,                               --��λ
       CASE A.ANESTHESIA_METHOD WHEN '����' THEN '����' ELSE
       DECODE( A.OPER_STATUS, 0,'��ǰ',2,'��ǰ',3,'����',4,'����',5,'����',10,'����',15,'����',25,'����',30,'����',35,'����',40,'����',45,'����') END  TYPE,
       A.OPER_STATUS,
       TO_CHAR(SYSDATE,'YYYY') - TO_CHAR(F.DATE_OF_BIRTH,'YYYY') AS PAT_AGE
       FROM
       (SELECT * FROM V_OPERATION_MASTER WHERE TO_CHAR(SCHEDULED_DATE_TIME , 'yyyyMMdd') = TO_CHAR( SYSDATE,'yyyyMMdd') AND
       --TRUNC((SYSDATE-NVL(OUT_DATE_TIME,SYSDATE))*1440 ) <  5   AND  --���5��������5���Ӳ���ʾ
       OPER_STATUS < 50 AND OPER_STATUS > -80) A
       LEFT OUTER JOIN V_ANESTHESIA_PLAN C ON A.PATIENT_ID = C.PATIENT_ID AND A.VISIT_ID = C.VISIT_ID AND A.OPER_ID = C.OPER_ID
       LEFT OUTER JOIN V_PATS_IN_HOSPITAL D ON A.PATIENT_ID = D.PATIENT_ID AND A.VISIT_ID =D.VISIT_ID
       LEFT OUTER JOIN V_PAT_MASTER_INDEX F ON A.PATIENT_ID = F.PATIENT_ID
       LEFT OUTER JOIN V_OPERATING_ROOM E ON A.OPERATING_ROOM = E.DEPT_CODE AND A.OPERATING_ROOM_NO = E.ROOM_NO;