-- Create table
create table MED_SMART_SCREEN_CONFIG
(
  SCREEN_NO       VARCHAR(20) not null,
  SCREEN_TYPE     VARCHAR(20) not null,
  OPER_DEPT_CODE  VARCHAR(20) default '1020800',
  OPERROOM_FILTER VARCHAR(40) default '*',
  REFRESH_TIME    INT default 120,
  ROW_COUNT       INT default 10,
  VOICE_BROADCAST INT default 1,
  SHOW_MODE       VARCHAR(10) default 'Simple',
  MARK_SPEC       INT default 0,
  SHOW_TV         INT default 1,
  PROTECT_PRIVATE INT default 1,
  SKIN            VARCHAR(20) default 'Default'
);
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_SMART_SCREEN_CONFIG
  add constraint PK_SMART_SCREEN_CONFIG primary key (SCREEN_NO);
