-- Create table
create table MED_SCREEN_MSG
(
  ID          VARCHAR(40) not null,
  MSG         VARCHAR(500),
  INSERT_TIME DATE,
  COUNTS      INT,
  STATUS      INT,
  OTHER1      INT,
  USER_ID     VARCHAR(36),
  TYPE        INT,
  DEPT_CODE   VARCHAR(12)
)
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_SCREEN_MSG
  add constraint KEYS primary key (ID)