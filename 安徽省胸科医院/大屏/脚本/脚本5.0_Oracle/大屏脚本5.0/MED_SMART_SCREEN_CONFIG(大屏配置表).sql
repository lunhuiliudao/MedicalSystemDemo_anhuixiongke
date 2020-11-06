-- Create table
create table MED_SMART_SCREEN_CONFIG
(
  SCREEN_NO       VARCHAR2(20) not null,
  SCREEN_TYPE     VARCHAR2(20) not null,
  OPER_DEPT_CODE  VARCHAR2(20) default '1020800',
  OPERROOM_FILTER VARCHAR2(40) default '*',
  REFRESH_TIME    NUMBER(5) default 120,
  ROW_COUNT       NUMBER(2) default 10,
  VOICE_BROADCAST NUMBER(1) default 1,
  SHOW_MODE       VARCHAR2(10) default 'Simple',
  MARK_SPEC       NUMBER(1) default 0,
  SHOW_TV         NUMBER(1) default 1,
  PROTECT_PRIVATE NUMBER(1) default 1,
  SKIN            VARCHAR2(20) default 'Default'
);
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_SMART_SCREEN_CONFIG
  add constraint PK_SMART_SCREEN_CONFIG primary key (SCREEN_NO);

-- Grant/Revoke object privileges 
grant select, insert, update, delete on MED_SMART_SCREEN_CONFIG to ROLE_DOCARE;

-- Grant/Revoke synonym 
CREATE OR REPLACE PUBLIC SYNONYM MED_SMART_SCREEN_CONFIG FOR MED_SMART_SCREEN_CONFIG;