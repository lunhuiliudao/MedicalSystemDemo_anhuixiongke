
create or replace view view_operation_list as
select
       A.patient_id,                                       --����ID (סԺ��)
       A.visit_id,                                         --����סԺ��ʾ
       A.schedule_id,                                      --��������ID
       C.NAME,                                             --����
       c.sex,                                              --�Ա�
       C.INP_NO,                                           --סԺ��
       C.DATE_OF_BIRTH,                                    --��������
       C.NATION,                                           --����
       --�������ڿ���
       nvl((select med_dept_dict.DEPT_NAME   from med_dept_dict where med_dept_dict.dept_code = a.dept_stayed ),a.dept_stayed ) dept_stayed,
       A.bed_no,                                           --����
       A.scheduled_date_time,                              --�������ڼ�ʱ��
       --������
       a.operating_room,
        nvl((select med_dept_dict.DEPT_NAME   from med_dept_dict where med_dept_dict.dept_code = a.operating_room ),a.operating_room ) operating_room_name,
        A.operating_room_no,                                --������
       A.sequence,                                         --̨��
       A.diag_before_operation,                            --��ǰ���
       A.patient_condition,                                --�������
       b.operation ,                                       --��������
       A.operation_scale,                                  --�����ȼ�
        --��������
       nvl((select med_dept_dict.DEPT_NAME   from med_dept_dict where med_dept_dict.dept_code = a.operating_dept ),a.operating_dept ) operating_dept,
       --������
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.surgeon ),a.surgeon ) surgeon,
       --��һ��������
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.first_assistant ),a.first_assistant ) first_assistant,
       --�ڶ���������
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.second_assistant ),a.second_assistant ) second_assistant,
       --������������
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.third_assistant ),a.third_assistant ) third_assistant,
       --������������
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.fourth_assistant ),a.fourth_assistant ) fourth_assistant,
       A.anesthesia_method,                                --������
       --����ҽ��
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.anesthesia_doctor ),a.anesthesia_doctor ) anesthesia_doctor,
       --����������
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.anesthesia_assistant ),a.anesthesia_assistant ) anesthesia_assistant,
       --�ڶ���������
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.second_anesthesia_doctor ),a.second_anesthesia_doctor ) second_anesthesia_doctor,
       --������������
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.third_anesthesia_doctor ),a.third_anesthesia_doctor ) third_anesthesia_doctor,
       --������������
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.fourth_anesthesia_assistant ),a.fourth_anesthesia_assistant ) fourth_anesthesia_assistant,
       --��һϴ�ֻ�ʿ
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.first_operation_nurse ),a.first_operation_nurse ) first_operation_nurse,
       --�ڶ�ϴ�ֻ�ʿ
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.second_operation_nurse ),a.second_operation_nurse ) second_operation_nurse,
       --��һѲ�ػ�ʿ
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.first_supply_nurse ),a.first_supply_nurse ) first_supply_nurse,
       --�ڶ�Ѳ�ػ�ʿ
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.second_supply_nurse ),a.second_supply_nurse ) second_supply_nurse,
       --����Ѳ�ػ�ʿ
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.third_supply_nurse ),a.third_supply_nurse ) third_supply_nurse,
       A.notes_on_operation,                               --��ע
       A.entered_by,                                       --¼����
       A.req_date_time,                                    --��������ʱ��
       A.emergency_indicator,                              --�����־
       A.operation_position,                               --��λ
       A.reserved4,                                        --��Ѫ
       A.reserved5,                                         --��Ⱦ���
       '��ǰ' type,
       1  OPER_STATUS
 from (select * from med_operation_schedule where to_char(scheduled_date_time,'yyyymmdd') = to_char( sysdate ,'yyyymmdd')) a , 
 med_scheduled_operation_name b , med_pat_master_index c
 where a.patient_id = b.patient_id                            and
       a.visit_id   = b.visit_id                              and
       a.schedule_id= b.schedule_id                           and
       a.patient_id = c.patient_id                            and
       b.operation_no = 1                         
union
select
       A.patient_id,                                       --����ID (סԺ��)
       A.visit_id,                                         --����סԺ��ʾ
       A.oper_id,                                          --��������ID
       D.NAME,                                             --����
       D.sex,                                              --�Ա�
       D.INP_NO,                                           --סԺ��
       D.DATE_OF_BIRTH,                                    --��������
       D.NATION,                                           --����
       --�������ڿ���
      nvl((select med_dept_dict.DEPT_NAME   from med_dept_dict where med_dept_dict.dept_code = a.dept_stayed ),a.dept_stayed ) dept_stayed,
       c.bed_no,                                           --����
       A.START_DATE_TIME,                                  --�������ڼ�ʱ��
       --������
       a.operating_room,
      nvl((select med_dept_dict.DEPT_NAME   from med_dept_dict where med_dept_dict.dept_code = a.operating_room ),a.operating_room ) operating_room_name,
       A.operating_room_no,                                --������
       A.sequence,                                         --̨��
       A.diag_before_operation,                            --��ǰ���
       A.patient_condition,                                --�������
       b.operation ,                                       --��������
       A.operation_scale,                                  --�����ȼ�
       --��������
      nvl((select med_dept_dict.DEPT_NAME   from med_dept_dict where med_dept_dict.dept_code = a.operating_dept ),a.operating_dept ) operating_dept,
       --������
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.surgeon ),a.surgeon ) surgeon,
       --��һ��������
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.first_assistant ),a.first_assistant ) first_assistant,
       --�ڶ���������
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.second_assistant ),a.second_assistant ) second_assistant,
       --������������
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.third_assistant ),a.third_assistant ) third_assistant,
       --������������
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.fourth_assistant ),a.fourth_assistant ) fourth_assistant,
       A.anesthesia_method,                                --������
       --����ҽ��
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.anesthesia_doctor ),a.anesthesia_doctor ) anesthesia_doctor,
       --����������
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.anesthesia_assistant ),a.anesthesia_assistant ) anesthesia_assistant,
       --�ڶ���������
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.second_anesthesia_doctor ),a.second_anesthesia_doctor ) second_anesthesia_doctor,
       --������������
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.third_anesthesia_doctor ),a.third_anesthesia_doctor ) third_anesthesia_doctor,
       --������������
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.fourth_anesthesia_assistant ),a.fourth_anesthesia_assistant ) fourth_anesthesia_assistant,
       --��һϴ�ֻ�ʿ
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.first_operation_nurse ),a.first_operation_nurse ) first_operation_nurse,
       --�ڶ�ϴ�ֻ�ʿ
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.second_operation_nurse ),a.second_operation_nurse ) second_operation_nurse,
       --��һѲ�ػ�ʿ
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.first_supply_nurse ),a.first_supply_nurse ) first_supply_nurse,
       --�ڶ�Ѳ�ػ�ʿ
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.second_supply_nurse ),a.second_supply_nurse ) second_supply_nurse,
       --����Ѳ�ػ�ʿ
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.third_supply_nurse ),a.third_supply_nurse ) third_supply_nurse,
       null,                                               --��ע
       A.entered_by,                                       --¼����
       to_date(null,'yyyy-mm-dd'),                         --��������ʱ��
       A.emergency_indicator,                              --�����־
       A.operation_position,                               --��λ
       A.reserved4,                                        --��Ѫ
       A.reserved5,                                         --��Ⱦ���
       DECODE( A.OPER_STATUS, 0,'������', 1 ,'�Ѱ���',2 ,'����',3 ,'PACU', 4 , '����',5 , '���ύ')   type,
       A.OPER_STATUS
	from 
	(select * from med_operation_master where  OPER_STATUS > 1                                      and
       to_char(START_DATE_TIME , 'yyyymmdd') = to_char( sysdate  ,'yyyymmdd')                      and
       --�����ζ�ŷ��Ӻ�����Ĳ���ʾ����������ֳ�ʵ�������������Ҫ�Ļ���ɾ����һ��
       trunc(sysdate-OUT_DATE_TIME  )*1440 <  5   ) a , med_operation_name b , med_anesthesia_plan c , med_pat_master_index d
       where a.patient_id = b.patient_id                            and
       a.visit_id   = b.visit_id                              and
       a.oper_id= b.oper_id                                   and
       a.patient_id = d.patient_id                            and
       a.patient_id = c.patient_id(+)                            and
       a.visit_id = c.visit_id(+)                                and
       a.oper_id = c.oper_id(+)                                  and
       b.operation_no = 1
