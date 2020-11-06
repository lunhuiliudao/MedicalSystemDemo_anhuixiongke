-- Create table
create table MED_PACU_SORCE
(
  order_id      NUMBER(10),
  criterion     VARCHAR2(10) not null,
  zero          VARCHAR2(50),
  one           VARCHAR2(50),
  two           VARCHAR2(50),
  eventhappen   VARCHAR2(10),
  time          DATE,
  myodynamia    NUMBER(5),
  breath        NUMBER(5),
  cycle         NUMBER(5),
  spo2          NUMBER(5),
  consciousness NUMBER(5),
  total         NUMBER(5),
  signature     VARCHAR2(10),
  patient_id    VARCHAR2(20) not null,
  visit_id      NUMBER(2) not null,
  oper_id       NUMBER(2) not null
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_PACU_SORCE
  add constraint PK_PACUSORCE primary key (PATIENT_ID, VISIT_ID, OPER_ID, CRITERION)
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
grant select, insert, update, delete, alter on MED_PACU_SORCE to ROLE_DOCARE;
