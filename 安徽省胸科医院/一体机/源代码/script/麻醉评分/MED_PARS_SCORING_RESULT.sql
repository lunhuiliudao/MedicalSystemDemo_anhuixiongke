-- Create table
create table MED_PARS_SCORING_RESULT
(
  patient_id        VARCHAR2(20) not null,
  visit_id          NUMBER(2) not null,
  dep_id            NUMBER(2) not null,
  scoring_date_time DATE not null,
  s1                NUMBER(1),
  s2                NUMBER(1),
  s3                NUMBER(1),
  s4                NUMBER(1),
  s5                NUMBER(1),
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
-- Add comments to the table 
comment on table MED_PARS_SCORING_RESULT
  is 'PARS麻醉评分';
-- Add comments to the columns 
comment on column MED_PARS_SCORING_RESULT.s1
  is '活动';
comment on column MED_PARS_SCORING_RESULT.s2
  is '呼吸';
comment on column MED_PARS_SCORING_RESULT.s3
  is '循环';
comment on column MED_PARS_SCORING_RESULT.s4
  is '意识';
comment on column MED_PARS_SCORING_RESULT.s5
  is '颜色';
comment on column MED_PARS_SCORING_RESULT.memo
  is '病情描述';
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_PARS_SCORING_RESULT
  add constraint PK_PARS primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME)
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
grant select, insert, update, delete on MED_PARS_SCORING_RESULT to ROLE_DOCARE;
