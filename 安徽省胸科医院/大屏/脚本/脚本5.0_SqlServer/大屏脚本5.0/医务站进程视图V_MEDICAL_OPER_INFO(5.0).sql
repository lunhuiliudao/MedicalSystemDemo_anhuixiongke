IF OBJECT_ID('V_MEDICAL_OPER_INFO') IS NOT NULL
DROP VIEW V_MEDICAL_OPER_INFO
GO
CREATE VIEW V_MEDICAL_OPER_INFO AS
SELECT 
--3��ID
TOP 100 percent
A.PATIENT_ID,A.VISIT_ID,A.OPER_ID,
--����
B.NAME AS PAT_NAME,
--�Ա�
B.SEX,
--סԺ��
B.INP_NO,
--����
DATEDIFF(YEAR,GETDATE(),B.DATE_OF_BIRTH) AS PAT_AGE,
--�����ҿ��Ҵ���
A.OPERATING_ROOM,
--�������
A.OPERATING_ROOM_NO,
--̨��
A.SEQUENCE,
--��������
A.SCHEDULED_DATE_TIME,
--��������ʱ��
A.IN_DATE_TIME,
--����ʼʱ��
ISNULL(A.ANES_START_TIME ,A.START_DATE_TIME) AS ANES_START_TIME,
--������ʼʱ��
A.START_DATE_TIME,A.END_DATE_TIME,
--�������ʱ��
ISNULL(A.ANES_END_TIME,A.END_DATE_TIME) AS ANES_END_TIME,
--��������ʱ��
A.OUT_DATE_TIME,
--�����־
A.EMERGENCY_IND,
--�����־                              
A.ISOLATION_IND,
--�����־                                    
A.RADIATE_IND,
--��Ⱦ��־                                      
A.INFECTED_IND,                                     
--����״̬
A.OPER_STATUS
FROM V_OPERATION_MASTER A
LEFT OUTER JOIN V_PAT_MASTER_INDEX B ON A.PATIENT_ID = B.PATIENT_ID
--ɸѡ�����ҷ�ȡ����������Ϣ
WHERE convert(nvarchar(10),A.SCHEDULED_DATE_TIME,120) = convert(nvarchar(10),GETDATE(),120) AND A.OPER_STATUS > -80
ORDER BY A.OPERATING_ROOM,A.OPERATING_ROOM_NO,A.IN_DATE_TIME,ISNULL(A.SEQUENCE,100);
