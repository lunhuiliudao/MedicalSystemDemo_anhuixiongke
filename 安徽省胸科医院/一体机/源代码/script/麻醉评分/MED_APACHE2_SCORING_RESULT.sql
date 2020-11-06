-- Create table
create table MED_APACHE2_SCORING_RESULT
(
  patient_id        VARCHAR2(20) not null,
  visit_id          NUMBER(2) not null,
  dep_id            NUMBER(2) not null,
  scoring_date_time DATE not null,
  age               NUMBER(3),
  hr                NUMBER(5),
  map               NUMBER(5),
  br                NUMBER(5),
  tmp               NUMBER(5,2),
  aado2             NUMBER(6,2),
  pao2              NUMBER(6,2),
  fio2              NUMBER(6,2),
  ph                NUMBER(6,2),
  hct               NUMBER(6,2),
  cr                NUMBER(6,2),
  wbc               NUMBER(6,2),
  k                 NUMBER(6,2),
  na                NUMBER(6,2),
  eyes_reflect      NUMBER(1),
  talk_reflect      NUMBER(1),
  limb_reflect      NUMBER(1),
  health_status     NUMBER(1),
  key_indicator     NUMBER(1),
  memo              VARCHAR2(100),
  ji_zhen_oper      NUMBER(1),
  no_oper_pat       VARCHAR2(80),
  after_oper_pat    VARCHAR2(80)
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
alter table MED_APACHE2_SCORING_RESULT
  add constraint PK_APACHE2_SCORING_RESULT primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME)
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
grant select, insert, update, delete on MED_APACHE2_SCORING_RESULT to ROLE_DOCARE;
