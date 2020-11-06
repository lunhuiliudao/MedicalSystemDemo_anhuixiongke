-- Create table
create table MED_VER_INFO
(
  VER_ID         VARCHAR2(100) not null,
  APP_ID         VARCHAR2(100),
  VER_NO         NUMBER,
  FILE_PATH      VARCHAR2(100),
  IS_FORCIBLY    NUMBER,
  IS_TEST        NUMBER,
  ROLL_BACK      NUMBER,
  ROLL_BACK_DESC VARCHAR2(100),
  DESCRIPTION    VARCHAR2(200),
  CREATER        VARCHAR2(50),
  CREATE_TIME    DATE,
  MODIFYER       VARCHAR2(50),
  MODIFY_TIME    DATE
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
alter table MED_VER_INFO
  add constraint MED_VER_INFO_PK primary key (VER_ID)
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