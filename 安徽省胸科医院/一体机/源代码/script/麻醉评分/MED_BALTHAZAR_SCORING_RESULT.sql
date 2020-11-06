-- Create table
create table MED_BALTHAZAR_SCORING_RESULT
(
  patient_id        VARCHAR2(20) not null,
  visit_id          NUMBER(2) not null,
  dep_id            NUMBER(2) not null,
  scoring_date_time DATE not null,
  s1                NUMBER(1),
  s2                NUMBER(1),
  memo              VARCHAR2(100)
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_BALTHAZAR_SCORING_RESULT
  add constraint PK_BALTHAZAR primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME)
  using index 
  tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
-- Grant/Revoke object privileges 
grant select, insert, update, delete on MED_BALTHAZAR_SCORING_RESULT to ROLE_DOCARE;
