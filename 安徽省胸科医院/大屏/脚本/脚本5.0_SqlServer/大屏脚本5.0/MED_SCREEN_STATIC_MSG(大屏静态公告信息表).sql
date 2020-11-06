-- Create table
create table MED_SCREEN_STATIC_MSG
(
  SCREEN_NO   VARCHAR(20) not null,
  MSG_ID      VARCHAR(25) not null,
  SEQ_NO      INT,
  MSG_CONTENT VARCHAR(200),
  IS_USE      INT default 0
);
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_SCREEN_STATIC_MSG
  add constraint PK_SCREEN_STATIC_MSG primary key (SCREEN_NO, MSG_ID);