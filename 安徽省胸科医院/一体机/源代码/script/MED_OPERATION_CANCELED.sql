-- Create table
create table MED_OPERATION_CANCELED
(
  PATIENT_ID       VARCHAR2(40) not null,
  VISIT_ID         NUMBER(4) not null,
  CANCEL_ID        NUMBER(2) not null,
  SCHEDULE_ID      NUMBER(2),
  OPER_ID          NUMBER(2),
  OPER_STATUS_CODE NUMBER(3) not null,
  CANCEL_REASON    VARCHAR2(500),
  CANCEL_DATE      DATE not null,
  CANCEL_BY        VARCHAR2(20),
  ENTERED_BY       VARCHAR2(20)
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
comment on table MED_OPERATION_CANCELED
  is '����ȡ����';
-- Add comments to the columns 
comment on column MED_OPERATION_CANCELED.PATIENT_ID
  is '����ID;�ǿգ�Ψһȷ����������';
comment on column MED_OPERATION_CANCELED.VISIT_ID
  is '��Ժ����;סԺ����ÿ��סԺ��1';
comment on column MED_OPERATION_CANCELED.CANCEL_ID
  is '����ȡ����ʶ;����ȡ����ʶ(����һ������һ��סԺ���ȡ����¼����1��ʼ˳�����)';
comment on column MED_OPERATION_CANCELED.SCHEDULE_ID
  is '�������ű�ʶ;��ƻ����е�SCHEDULE_ID��Ӧ';
comment on column MED_OPERATION_CANCELED.OPER_ID
  is '�������ű�ʶ;�����������OPER_ID��Ӧ';
comment on column MED_OPERATION_CANCELED.OPER_STATUS_CODE
  is '����״̬;��Ӧ����״̬������¼ȡ��ʱ������״̬';
comment on column MED_OPERATION_CANCELED.CANCEL_REASON
  is 'ȡ��ԭ��';
comment on column MED_OPERATION_CANCELED.CANCEL_DATE
  is 'ȡ������';
comment on column MED_OPERATION_CANCELED.CANCEL_BY
  is 'ȡ����';
comment on column MED_OPERATION_CANCELED.ENTERED_BY
  is '������Ա';
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_OPERATION_CANCELED
  add constraint PK_OPERATION_CANCELED primary key (PATIENT_ID, VISIT_ID, CANCEL_ID)
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
