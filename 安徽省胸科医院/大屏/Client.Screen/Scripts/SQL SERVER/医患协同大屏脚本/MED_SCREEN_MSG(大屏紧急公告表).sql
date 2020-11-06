-- Create table
create table MEDCOMM.MED_SCREEN_MSG
(
  ID          VARCHAR2(40) not null,
  MSG         VARCHAR2(500),
  INSERT_TIME DATE,
  COUNTS      NUMBER(2),
  STATUS      NUMBER(1),
  OTHER1      NUMBER(5),
  USER_ID     VARCHAR2(36),
  TYPE        NUMBER(5),
  DEPT_CODE   VARCHAR2(12)
)
tablespace TSP_MEDCOMM
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
alter table MEDCOMM.MED_SCREEN_MSG
  add constraint KEYS primary key (ID)
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
grant select, insert, update, delete on MEDCOMM.MED_SCREEN_MSG to ROLE_DOCARE;
