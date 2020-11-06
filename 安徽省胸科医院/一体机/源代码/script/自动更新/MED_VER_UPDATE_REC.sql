-- Create table
create table MED_VER_UPDATE_REC
(
  UP_ID          VARCHAR2(100) not null,
  APP_NAME       VARCHAR2(100),
  VER_ID         VARCHAR2(100),
  IP             VARCHAR2(100),
  SYSTEM_NAME    VARCHAR2(100),
  IS_DOWNLOAD    NUMBER,
  DOWNLOAD_TIME  DATE,
  IS_UPDATED     NUMBER,
  UPDATED_TIME   DATE,
  ROLL_BACK      NUMBER,
  ROLL_BACK_TIME DATE,
  CREATE_TIME    DATE
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
alter table MED_VER_UPDATE_REC
  add constraint MED_VER_UPDATE_REC_PK primary key (UP_ID)
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