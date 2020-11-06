-- Create table
create table MED_OPERATION_RESCUE
(
  PATIENT_ID       VARCHAR2(40) not null,
  VISIT_ID         NUMBER(4) not null,
  OPER_ID          NUMBER(2) not null,
  RESCUE_ID        NUMBER(2) not null,
  OPER_STATUS_CODE NUMBER(3),
  START_DATE_TIME  DATE,
  END_DATE_TIME    DATE,
  REASON           VARCHAR2(200),
  MEASURES         VARCHAR2(200),
  RESULT           VARCHAR2(50),
  PARTICIPANTS     VARCHAR2(100),
  ENTERED_BY       VARCHAR2(40)
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
-- Add comments to the table 
comment on table MED_OPERATION_RESCUE
  is '������ϸ��';
-- Add comments to the columns 
comment on column MED_OPERATION_RESCUE.RESCUE_ID
  is 'ÿ�ν�������1����1��ʼ';
comment on column MED_OPERATION_RESCUE.OPER_STATUS_CODE
  is '��Ӧ����״̬������¼����ȡ��ʱ������״̬��';
comment on column MED_OPERATION_RESCUE.START_DATE_TIME
  is '���ȿ�ʼʱ��';
comment on column MED_OPERATION_RESCUE.END_DATE_TIME
  is '���Ƚ���ʱ��';
comment on column MED_OPERATION_RESCUE.REASON
  is '����ԭ��';
comment on column MED_OPERATION_RESCUE.MEASURES
  is '���ȴ�ʩ';
comment on column MED_OPERATION_RESCUE.RESULT
  is '���Ƚ�����ɹ�=1��ʧ��=0';
comment on column MED_OPERATION_RESCUE.PARTICIPANTS
  is '����������Ա';
comment on column MED_OPERATION_RESCUE.ENTERED_BY
  is '¼����';
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_OPERATION_RESCUE
  add constraint MED_OPERATION_RESCUE_PK primary key (PATIENT_ID, VISIT_ID, OPER_ID, RESCUE_ID)
  using index 
  tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
