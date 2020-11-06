-- Create table
create table MED_SCREEN_FIELDS
(
  SCREEN_NO   VARCHAR2(20) not null,
  ORDER_NO    NUMBER(3),
  FIELD_NAME  VARCHAR2(40) not null,
  CAPTION     VARCHAR2(40),
  COL_PERCENT NUMBER(3),
  SEQ_SHOW    NUMBER(1) default 0
);
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_SCREEN_FIELDS
  add constraint PK_MED_SCREEN_FIELDS primary key (SCREEN_NO, FIELD_NAME);

-- Grant/Revoke object privileges 
grant select, insert, update, delete on MED_SCREEN_FIELDS to ROLE_DOCARE;

-- Grant/Revoke synonym 
CREATE OR REPLACE PUBLIC SYNONYM MED_SCREEN_FIELDS FOR MED_SCREEN_FIELDS;