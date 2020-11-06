create table MED_ANES_ALARM_MESSAGE
(
  patient_id  VARCHAR(20) not null,
  visit_id    INT not null,
  oper_id     INT not null,
  msg_no      VARCHAR(40) not null,
  msg_time    DATE,
  read_flag   INT,
  msg         VARCHAR(600),
  record_time DATE,
  alarm_item  VARCHAR(40) not null,
  read_time   DATE
)
alter table MED_ANES_ALARM_MESSAGE add constraint pkAnesAlarmMsg primary key(patient_id,visit_id,oper_id,msg_no);