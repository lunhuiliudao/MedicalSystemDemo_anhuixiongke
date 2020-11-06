-- Create table
create table MEDSURGERY.MED_CHANGE_ROOM_NO
(
  CHANGE_NO     NUMBER(4) not null,
  PATIENT_ID    VARCHAR2(40) not null,
  VISIT_ID      NUMBER(4) not null,
  OPER_ID       NUMBER(2) not null,
  OLD_ROOM_NO   VARCHAR2(20),
  NEW_ROOM_NO   VARCHAR2(20),
  CHANGE_DATE   DATE,
  CHANGE_ATOR   VARCHAR2(20),
  CHANGE_REASON VARCHAR2(200)
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table MEDSURGERY.MED_CHANGE_ROOM_NO
  add constraint MED_CHANGE_ROOM_NO_PK primary key (CHANGE_NO, PATIENT_ID, VISIT_ID, OPER_ID)
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
grant select, insert, update, delete on MEDSURGERY.MED_CHANGE_ROOM_NO to ROLE_DOCARE;
