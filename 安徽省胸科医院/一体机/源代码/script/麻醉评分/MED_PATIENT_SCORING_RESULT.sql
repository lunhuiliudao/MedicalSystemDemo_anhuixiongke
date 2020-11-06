-- Create table
create table MED_PATIENT_SCORING_RESULT
(
  patient_id        VARCHAR2(20) not null,
  visit_id          NUMBER(2) not null,
  dep_id            NUMBER(2) not null,
  scoring_date_time DATE not null,
  scoring_method    VARCHAR2(20) not null,
  scoring_value     NUMBER(8),
  degree            VARCHAR2(40),
  death_probability NUMBER(5,4),
  pat_condition     VARCHAR2(80),
  ward_code         VARCHAR2(8),
  operator          VARCHAR2(30),
  memo              VARCHAR2(1000),
  enter_date_time   DATE,
  death_rate        NUMBER(6,2),
  iss_score         NUMBER(6,2),
  trs_score         NUMBER(6,2)
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
alter table MED_PATIENT_SCORING_RESULT
  add constraint PK_PATIENT_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME, SCORING_METHOD)
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
grant select, insert, update, delete on MED_PATIENT_SCORING_RESULT to ROLE_DOCARE;
