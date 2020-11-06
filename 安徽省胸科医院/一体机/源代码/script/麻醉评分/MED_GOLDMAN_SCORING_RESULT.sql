-- Create table
create table MED_GOLDMAN_SCORING_RESULT
(
  patient_id        VARCHAR2(20) not null,
  visit_id          NUMBER(2) not null,
  dep_id            NUMBER(2) not null,
  scoring_date_time DATE not null,
  s1                NUMBER(2),
  s2                NUMBER(2),
  s3                NUMBER(2),
  s4                NUMBER(2),
  s5                NUMBER(2),
  s6                NUMBER(2),
  s7                NUMBER(2),
  s8                NUMBER(2),
  s9                NUMBER(2),
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
comment on table MED_GOLDMAN_SCORING_RESULT
  is 'GOLDMAN��������';
-- Add comments to the columns 
comment on column MED_GOLDMAN_SCORING_RESULT.s1
  is '����>70��';
comment on column MED_GOLDMAN_SCORING_RESULT.s3
  is '6���������ļ�����';
comment on column MED_GOLDMAN_SCORING_RESULT.s4
  is 'S3�����ʺ;�����ŭ��';
comment on column MED_GOLDMAN_SCORING_RESULT.s5
  is '�ض���������խ';
comment on column MED_GOLDMAN_SCORING_RESULT.s6
  is 'ECG��ʾ��������ɻ﷿����ǰ����';
comment on column MED_GOLDMAN_SCORING_RESULT.s7
  is '����ǰ����5��/��';
comment on column MED_GOLDMAN_SCORING_RESULT.s8
  is 'ȫ�����';
comment on column MED_GOLDMAN_SCORING_RESULT.s9
  is '��ǻ����ǻ������������';
comment on column MED_GOLDMAN_SCORING_RESULT.memo
  is '��֢����';
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_GOLDMAN_SCORING_RESULT
  add constraint PK_GOLDMAN primary key (PATIENT_ID, VISIT_ID, DEP_ID, SCORING_DATE_TIME)
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
grant select, insert, update, delete on MED_GOLDMAN_SCORING_RESULT to ROLE_DOCARE;
