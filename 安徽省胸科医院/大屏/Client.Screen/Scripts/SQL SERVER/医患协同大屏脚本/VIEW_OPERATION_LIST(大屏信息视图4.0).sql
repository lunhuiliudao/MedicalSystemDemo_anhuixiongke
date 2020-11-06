
create or replace view view_operation_list as
select
       A.patient_id,                                       --病人ID (住院号)
       A.visit_id,                                         --本次住院标示
       A.schedule_id,                                      --手术申请ID
       C.NAME,                                             --名称
       c.sex,                                              --性别
       C.INP_NO,                                           --住院号
       C.DATE_OF_BIRTH,                                    --出生日期
       C.NATION,                                           --民族
       --病人所在科室
       nvl((select med_dept_dict.DEPT_NAME   from med_dept_dict where med_dept_dict.dept_code = a.dept_stayed ),a.dept_stayed ) dept_stayed,
       A.bed_no,                                           --床号
       A.scheduled_date_time,                              --手术日期及时间
       --手术室
       a.operating_room,
        nvl((select med_dept_dict.DEPT_NAME   from med_dept_dict where med_dept_dict.dept_code = a.operating_room ),a.operating_room ) operating_room_name,
        A.operating_room_no,                                --手术间
       A.sequence,                                         --台次
       A.diag_before_operation,                            --术前诊断
       A.patient_condition,                                --特殊情况
       b.operation ,                                       --手术名称
       A.operation_scale,                                  --手术等级
        --手术科室
       nvl((select med_dept_dict.DEPT_NAME   from med_dept_dict where med_dept_dict.dept_code = a.operating_dept ),a.operating_dept ) operating_dept,
       --手术者
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.surgeon ),a.surgeon ) surgeon,
       --第一手术助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.first_assistant ),a.first_assistant ) first_assistant,
       --第二手术助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.second_assistant ),a.second_assistant ) second_assistant,
       --第三手术助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.third_assistant ),a.third_assistant ) third_assistant,
       --第四手术助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.fourth_assistant ),a.fourth_assistant ) fourth_assistant,
       A.anesthesia_method,                                --麻醉方法
       --麻醉医生
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.anesthesia_doctor ),a.anesthesia_doctor ) anesthesia_doctor,
       --第麻醉助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.anesthesia_assistant ),a.anesthesia_assistant ) anesthesia_assistant,
       --第二麻醉助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.second_anesthesia_doctor ),a.second_anesthesia_doctor ) second_anesthesia_doctor,
       --第三麻醉助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.third_anesthesia_doctor ),a.third_anesthesia_doctor ) third_anesthesia_doctor,
       --第四麻醉助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.fourth_anesthesia_assistant ),a.fourth_anesthesia_assistant ) fourth_anesthesia_assistant,
       --第一洗手护士
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.first_operation_nurse ),a.first_operation_nurse ) first_operation_nurse,
       --第二洗手护士
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.second_operation_nurse ),a.second_operation_nurse ) second_operation_nurse,
       --第一巡回护士
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.first_supply_nurse ),a.first_supply_nurse ) first_supply_nurse,
       --第二巡回护士
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.second_supply_nurse ),a.second_supply_nurse ) second_supply_nurse,
       --第三巡回护士
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.third_supply_nurse ),a.third_supply_nurse ) third_supply_nurse,
       A.notes_on_operation,                               --备注
       A.entered_by,                                       --录入者
       A.req_date_time,                                    --申请日期时间
       A.emergency_indicator,                              --急诊标志
       A.operation_position,                               --体位
       A.reserved4,                                        --备血
       A.reserved5,                                         --感染情况
       '术前' type,
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
       A.patient_id,                                       --病人ID (住院号)
       A.visit_id,                                         --本次住院标示
       A.oper_id,                                          --手术申请ID
       D.NAME,                                             --名称
       D.sex,                                              --性别
       D.INP_NO,                                           --住院号
       D.DATE_OF_BIRTH,                                    --出生日期
       D.NATION,                                           --民族
       --病人所在科室
      nvl((select med_dept_dict.DEPT_NAME   from med_dept_dict where med_dept_dict.dept_code = a.dept_stayed ),a.dept_stayed ) dept_stayed,
       c.bed_no,                                           --床号
       A.START_DATE_TIME,                                  --手术日期及时间
       --手术室
       a.operating_room,
      nvl((select med_dept_dict.DEPT_NAME   from med_dept_dict where med_dept_dict.dept_code = a.operating_room ),a.operating_room ) operating_room_name,
       A.operating_room_no,                                --手术间
       A.sequence,                                         --台次
       A.diag_before_operation,                            --术前诊断
       A.patient_condition,                                --特殊情况
       b.operation ,                                       --手术名称
       A.operation_scale,                                  --手术等级
       --手术科室
      nvl((select med_dept_dict.DEPT_NAME   from med_dept_dict where med_dept_dict.dept_code = a.operating_dept ),a.operating_dept ) operating_dept,
       --手术者
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.surgeon ),a.surgeon ) surgeon,
       --第一手术助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.first_assistant ),a.first_assistant ) first_assistant,
       --第二手术助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.second_assistant ),a.second_assistant ) second_assistant,
       --第三手术助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.third_assistant ),a.third_assistant ) third_assistant,
       --第四手术助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.fourth_assistant ),a.fourth_assistant ) fourth_assistant,
       A.anesthesia_method,                                --麻醉方法
       --麻醉医生
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.anesthesia_doctor ),a.anesthesia_doctor ) anesthesia_doctor,
       --第麻醉助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.anesthesia_assistant ),a.anesthesia_assistant ) anesthesia_assistant,
       --第二麻醉助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.second_anesthesia_doctor ),a.second_anesthesia_doctor ) second_anesthesia_doctor,
       --第三麻醉助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.third_anesthesia_doctor ),a.third_anesthesia_doctor ) third_anesthesia_doctor,
       --第四麻醉助手
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.fourth_anesthesia_assistant ),a.fourth_anesthesia_assistant ) fourth_anesthesia_assistant,
       --第一洗手护士
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.first_operation_nurse ),a.first_operation_nurse ) first_operation_nurse,
       --第二洗手护士
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.second_operation_nurse ),a.second_operation_nurse ) second_operation_nurse,
       --第一巡回护士
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.first_supply_nurse ),a.first_supply_nurse ) first_supply_nurse,
       --第二巡回护士
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.second_supply_nurse ),a.second_supply_nurse ) second_supply_nurse,
       --第三巡回护士
       nvl( ( select  med_his_users.USER_NAME from med_his_users where med_his_users.USER_ID = a.third_supply_nurse ),a.third_supply_nurse ) third_supply_nurse,
       null,                                               --备注
       A.entered_by,                                       --录入者
       to_date(null,'yyyy-mm-dd'),                         --申请日期时间
       A.emergency_indicator,                              --急诊标志
       A.operation_position,                               --体位
       A.reserved4,                                        --备血
       A.reserved5,                                         --感染情况
       DECODE( A.OPER_STATUS, 0,'新申请', 1 ,'已安排',2 ,'术中',3 ,'PACU', 4 , '术后',5 , '已提交')   type,
       A.OPER_STATUS
	from 
	(select * from med_operation_master where  OPER_STATUS > 1                                      and
       to_char(START_DATE_TIME , 'yyyymmdd') = to_char( sysdate  ,'yyyymmdd')                      and
       --这个意味着分钟后术后的不显示，具体更具现场实情况而定，不需要的话就删除这一行
       trunc(sysdate-OUT_DATE_TIME  )*1440 <  5   ) a , med_operation_name b , med_anesthesia_plan c , med_pat_master_index d
       where a.patient_id = b.patient_id                            and
       a.visit_id   = b.visit_id                              and
       a.oper_id= b.oper_id                                   and
       a.patient_id = d.patient_id                            and
       a.patient_id = c.patient_id(+)                            and
       a.visit_id = c.visit_id(+)                                and
       a.oper_id = c.oper_id(+)                                  and
       b.operation_no = 1
