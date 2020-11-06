-- Create table
create table MED_APP_INFO
(
  APP_ID      VARCHAR2(100) not null,
  APP_KEY     VARCHAR2(100),
  APP_NAME    VARCHAR2(100),
  DESCRIPTION VARCHAR2(100),
  CREATER     VARCHAR2(50),
  CREATE_TIME DATE,
  MODIFYER    VARCHAR2(50),
  MODIFY_TIME DATE
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
alter table MED_APP_INFO
  add constraint MED_APP_INFO_PK primary key (APP_ID)
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