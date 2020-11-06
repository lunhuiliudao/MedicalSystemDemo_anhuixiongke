-- Create table
create table MEDCOMM.MED_SMART_SCREEN_DICT
(
  SCREEN_NO     VARCHAR2(20) not null,
  SCREEN_TYPE   VARCHAR2(20) not null,
  SCREEN_LABEL  VARCHAR2(100) not null,
  FULL_SCREEN   NUMBER(1) default 1,
  SCREEN_WIDTH  NUMBER(5) default 1024,
  SCREEN_HEIGHT NUMBER(5) default 768
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
alter table MEDCOMM.MED_SMART_SCREEN_DICT
  add constraint PK_SMART_SCREEN_DICT primary key (SCREEN_NO)
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
grant select, insert, update, delete on MEDCOMM.MED_SMART_SCREEN_DICT to ROLE_DOCARE;
