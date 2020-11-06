-- Create table
create table MED_SCREEN_STATIC_MSG
(
  SCREEN_NO   VARCHAR2(20) not null,
  MSG_ID      VARCHAR2(25) not null,
  SEQ_NO      NUMBER(3),
  MSG_CONTENT VARCHAR2(200),
  IS_USE      NUMBER(1) default 0
);
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_SCREEN_STATIC_MSG
  add constraint PK_SCREEN_STATIC_MSG primary key (SCREEN_NO, MSG_ID);

-- Grant/Revoke object privileges 
grant select, insert, update, delete on MED_SCREEN_STATIC_MSG to ROLE_DOCARE;

-- Grant/Revoke synonym 
CREATE OR REPLACE PUBLIC SYNONYM MED_SCREEN_STATIC_MSG FOR MED_SCREEN_STATIC_MSG;
