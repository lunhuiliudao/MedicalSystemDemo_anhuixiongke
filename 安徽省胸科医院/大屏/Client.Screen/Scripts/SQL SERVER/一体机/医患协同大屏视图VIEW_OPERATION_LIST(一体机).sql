CREATE VIEW VIEW_OPERATION_LIST AS
SELECT
       A.PATIENT_ID,                                       --����ID (סԺ��)
       A.VISIT_ID,                                         --����סԺ��ʾ
       A.SCHEDULE_ID,                                      --��������ID
       E.NAME,                                             --����
       E.SEX,                                              --�Ա�
       C.INP_NO,                                           --סԺ��
       E.DATE_OF_BIRTH,                                    --��������
       E.NATION,                                           --����
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
       --��һ��������
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.ANESTHESIA_ASSISTANT ),A.ANESTHESIA_ASSISTANT ) ANESTHESIA_ASSISTANT,
       --�ڶ���������
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.SECOND_ANESTHESIA_ASSISTANT ),A.SECOND_ANESTHESIA_ASSISTANT ) SECOND_ANESTHESIA_DOCTOR,
       --������������
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.THIRD_ANESTHESIA_ASSISTANT ),A.THIRD_ANESTHESIA_ASSISTANT ) THIRD_ANESTHESIA_DOCTOR,
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
       A.EMERGENCY_IND,                              --�����־
			 A.ISOLATION_IND,                                    --�����־
			 A.RADIATE_IND,                                      --�����־
			 A.INFECTED_IND,                                     --��Ⱦ��־
       A.OPERATION_POSITION,                               --��λ
       CASE A.ANESTHESIA_METHOD WHEN '����' THEN '����' ELSE '��ǰ' END  TYPE,
       A.OPER_STATUS,
       TO_CHAR(SYSDATE,'YYYY') - TO_CHAR(E.DATE_OF_BIRTH,'YYYY') AS PAT_AGE
       FROM
       (SELECT * FROM V_OPERATION_SCHEDULE  WHERE TO_CHAR(SCHEDULED_DATE_TIME,'yyyyMMdd') = TO_CHAR(SYSDATE ,'yyyyMMdd')  AND STATE = 2) A , V_PATS_IN_HOSPITAL C,
       V_OPERATING_ROOM D,V_PAT_MASTER_INDEX E
       WHERE
       A.PATIENT_ID = C.PATIENT_ID              AND
			 A.VISIT_ID = C.VISIT_ID                  AND
       A.OPERATING_ROOM = D.DEPT_CODE AND A.OPERATING_ROOM_NO = D.ROOM_NO  AND
			 A.PATIENT_ID = E.PATIENT_ID
UNION
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
      ISNULL((SELECT V_DEPT_DICT.DEPT_NAME   FROM V_DEPT_DICT WHERE V_DEPT_DICT.DEPT_CODE = A.DEPT_STAYED ),A.DEPT_STAYED ) DEPT_STAYED,
       --C.BED_NO,                                           --����
       A.BED_NO,
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
       --��һ��������
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.ANESTHESIA_ASSISTANT ),A.ANESTHESIA_ASSISTANT ) ANESTHESIA_ASSISTANT,
       --�ڶ���������
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.SECOND_ANESTHESIA_ASSISTANT ),A.SECOND_ANESTHESIA_ASSISTANT ) SECOND_ANESTHESIA_DOCTOR,
       --������������
       ISNULL( ( SELECT  V_HIS_USERS.USER_NAME FROM V_HIS_USERS WHERE V_HIS_USERS.USER_ID = A.THIRD_ANESTHESIA_ASSISTANT ),A.THIRD_ANESTHESIA_ASSISTANT ) THIRD_ANESTHESIA_DOCTOR,
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
       TO_DATE(NULL,'YYYY-MM-DD'),                         --��������ʱ��
			 A.EMERGENCY_IND,                              --�����־
			 A.ISOLATION_IND,                                    --�����־
			 A.RADIATE_IND,                                      --�����־
			 A.INFECTED_IND,                                     --��Ⱦ��־
       A.OPERATION_POSITION,                               --��λ
       CASE A.ANESTHESIA_METHOD WHEN '����' THEN '����' ELSE
       DECODE( A.OPER_STATUS, 5,'����',10,'����',15,'����',25,'����',30,'����',35,'����',40,'������',45,'������') END  TYPE,
       A.OPER_STATUS,
       TO_CHAR(SYSDATE,'YYYY') - TO_CHAR(F.DATE_OF_BIRTH,'YYYY') AS PAT_AGE
       FROM
       (SELECT * FROM V_OPERATION_MASTER WHERE OPER_STATUS > 0  AND
       --2011.05.31��������ʱ�ı��IN_DATE_TIME������ʼ�����ı����START_DATE_TIME������Ҫ����ʱ�䶼�ж�
       (TO_CHAR(START_DATE_TIME , 'yyyyMMdd') = TO_CHAR( SYSDATE,'yyyyMMdd')  OR
       TO_CHAR(IN_DATE_TIME , 'yyyyMMdd') = TO_CHAR( SYSDATE ,'yyyyMMdd')) AND
       --TRUNC((SYSDATE-ISNULL(OUT_DATE_TIME,SYSDATE))*1440 ) <  5   AND  --���5��������5���Ӳ���ʾ
       OPER_STATUS < 50 ) A , V_ANESTHESIA_PLAN C , V_PATS_IN_HOSPITAL D,V_OPERATING_ROOM E,V_PAT_MASTER_INDEX F
       WHERE
       A.PATIENT_ID = D.PATIENT_ID                            AND
			 A.VISIT_ID =D.VISIT_ID                                AND
       A.PATIENT_ID = C.PATIENT_ID(+)                            AND
       A.VISIT_ID = C.VISIT_ID(+)                                AND
       A.OPER_ID = C.OPER_ID(+)                                  AND
       A.OPERATING_ROOM = E.DEPT_CODE                            AND 
			 A.OPERATING_ROOM_NO = E.ROOM_NO                           AND
			 A.PATIENT_ID = F.PATIENT_ID
;
