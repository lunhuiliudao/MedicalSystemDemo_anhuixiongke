create table medsurgery.MED_ANES_ALARM_MESSAGE
(
  patient_id  VARCHAR2(20) not null,
  visit_id    NUMBER(2) not null,
  oper_id     NUMBER(2) not null,
  msg_no      VARCHAR2(40) not null,
  msg_time    DATE,
  read_flag   NUMBER(2),
  msg         VARCHAR2(600),
  record_time DATE,
  alarm_item  VARCHAR2(40) not null,
  read_time   DATE
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 16
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table medsurgery.MED_ANES_ALARM_MESSAGE
  add constraint PK_MED_ANES_ALARM_MESSAGE primary key (PATIENT_ID, VISIT_ID, OPER_ID, MSG_NO)
  using index 
  tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );

-- Grant/Revoke object privileges 
grant select, insert, update, delete on medsurgery.MED_ANES_ALARM_MESSAGE to ROLE_DOCARE;

-- Grant/Revoke synonym 
CREATE OR REPLACE PUBLIC SYNONYM MED_ANES_ALARM_MESSAGE FOR medsurgery.MED_ANES_ALARM_MESSAGE;