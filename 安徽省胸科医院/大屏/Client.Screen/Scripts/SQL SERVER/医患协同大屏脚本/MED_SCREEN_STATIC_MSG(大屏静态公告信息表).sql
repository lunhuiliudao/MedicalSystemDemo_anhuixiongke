-- Create table
create table MEDCOMM.MED_SCREEN_STATIC_MSG
(
  SCREEN_NO   VARCHAR2(20) not null,
  MSG_ID      VARCHAR2(25) not null,
  SEQ_NO      NUMBER(3),
  MSG_CONTENT VARCHAR2(200),
  IS_USE      NUMBER(1) default 0
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
alter table MEDCOMM.MED_SCREEN_STATIC_MSG
  add constraint PK_SCREEN_STATIC_MSG primary key (SCREEN_NO, MSG_ID)
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
grant select, insert, update, delete on MEDCOMM.MED_SCREEN_STATIC_MSG to ROLE_DOCARE;
