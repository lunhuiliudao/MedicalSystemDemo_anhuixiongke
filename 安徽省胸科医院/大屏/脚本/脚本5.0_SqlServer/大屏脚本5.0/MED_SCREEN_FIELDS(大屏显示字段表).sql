-- Create table
create table MED_SCREEN_FIELDS
(
  SCREEN_NO   VARCHAR(20) not null,
  ORDER_NO    INT,
  FIELD_NAME  VARCHAR(40) not null,
  CAPTION     VARCHAR(40),
  COL_PERCENT INT,
  SEQ_SHOW    INT default 0
);
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_SCREEN_FIELDS
  add constraint PK_MED_SCREEN_FIELDS primary key (SCREEN_NO, FIELD_NAME);
