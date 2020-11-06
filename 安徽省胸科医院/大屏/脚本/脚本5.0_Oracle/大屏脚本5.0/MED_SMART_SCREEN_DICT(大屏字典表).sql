-- Create table
create table MED_SMART_SCREEN_DICT
(
  SCREEN_NO     VARCHAR2(20) not null,
  SCREEN_TYPE   VARCHAR2(20) not null,
  SCREEN_LABEL  VARCHAR2(100) not null,
  FULL_SCREEN   NUMBER(1) default 1,
  SCREEN_WIDTH  NUMBER(5) default 1024,
  SCREEN_HEIGHT NUMBER(5) default 768
);
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_SMART_SCREEN_DICT
  add constraint PK_SMART_SCREEN_DICT primary key (SCREEN_NO);

-- Grant/Revoke object privileges 
grant select, insert, update, delete on MED_SMART_SCREEN_DICT to ROLE_DOCARE;

-- Grant/Revoke synonym 
CREATE OR REPLACE PUBLIC SYNONYM MED_SMART_SCREEN_DICT FOR MED_SMART_SCREEN_DICT;