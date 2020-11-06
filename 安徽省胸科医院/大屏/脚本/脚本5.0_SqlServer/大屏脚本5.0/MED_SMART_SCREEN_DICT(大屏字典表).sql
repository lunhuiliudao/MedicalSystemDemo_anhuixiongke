-- Create table
create table MED_SMART_SCREEN_DICT
(
  SCREEN_NO     VARCHAR(20) not null,
  SCREEN_TYPE   VARCHAR(20) not null,
  SCREEN_LABEL  VARCHAR(100) not null,
  FULL_SCREEN   INT default 1,
  SCREEN_WIDTH  INT default 1024,
  SCREEN_HEIGHT INT default 768
);
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_SMART_SCREEN_DICT
  add constraint PK_SMART_SCREEN_DICT primary key (SCREEN_NO);
