-- Create table
create table MEDCOMM.MED_SCREEN_FIELDS
(
  SCREEN_NO   VARCHAR2(20) not null,
  ORDER_NO    NUMBER(3),
  FIELD_NAME  VARCHAR2(40) not null,
  CAPTION     VARCHAR2(40),
  COL_PERCENT NUMBER(3),
  SEQ_SHOW    NUMBER(1) default 0
)
tablespace TSP_MEDCOMM
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
alter table MEDCOMM.MED_SCREEN_FIELDS
  add constraint PK_MED_SCREEN_FIELDS primary key (SCREEN_NO, FIELD_NAME)
  using index 
  tablespace TSP_MEDCOMM
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
grant select, insert, update, delete on MEDCOMM.MED_SCREEN_FIELDS to ROLE_DOCARE;
