-- Create table
create table MED_OPER_ANALGESIC_TOTAL
(
  patient_id  VARCHAR2(20) not null,
  visit_id    NUMBER(2) not null,
  oper_id     NUMBER(2) not null,
  total_name  VARCHAR2(40) not null,
  total_value VARCHAR2(20),
  total_memo  VARCHAR2(100)
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255;
-- Add comments to the columns 
comment on column MED_OPER_ANALGESIC_TOTAL.total_name
  is '观察名称';
comment on column MED_OPER_ANALGESIC_TOTAL.total_value
  is '观察值';
comment on column MED_OPER_ANALGESIC_TOTAL.total_memo
  is '观察备注';
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_OPER_ANALGESIC_TOTAL
  add constraint PK_ANALGESIC_TOTAL primary key (PATIENT_ID, VISIT_ID, OPER_ID, TOTAL_NAME)
  using index 
  tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 2
  maxtrans 255;
