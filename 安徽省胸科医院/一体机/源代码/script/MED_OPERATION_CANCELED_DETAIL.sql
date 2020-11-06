-- Create table
create table MED_OPERATION_CANCELED_DETAIL
(
  PATIENT_ID   VARCHAR2(40) not null,
  VISIT_ID     NUMBER(4) not null,
  CANCEL_ID    NUMBER(2) not null,
  CANCEL_CLASS VARCHAR2(20) not null,
  CANCEL_TYPE  VARCHAR2(40) not null
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
comment on table MED_OPERATION_CANCELED_DETAIL
  is '����ȡ����ϸ��';
-- Add comments to the columns 
comment on column MED_OPERATION_CANCELED_DETAIL.PATIENT_ID
  is '����ID;�ǿգ�Ψһȷ����������';
comment on column MED_OPERATION_CANCELED_DETAIL.VISIT_ID
  is '��Ժ����;סԺ����ÿ��סԺ��1';
comment on column MED_OPERATION_CANCELED_DETAIL.CANCEL_ID
  is '����ȡ����ʶ;����ȡ����ʶ(����һ������һ��סԺ���ȡ����¼����1��ʼ˳�����)';
comment on column MED_OPERATION_CANCELED_DETAIL.CANCEL_CLASS
  is 'ȡ�����ࣨ���ࣩ;�������ء�ҽԺ���ء�ҽ������';
comment on column MED_OPERATION_CANCELED_DETAIL.CANCEL_TYPE
  is 'ȡ�����ࣨС�ࣩ;���ݴ��࣬�ӱ�MED_ANESTHESIA_INPUT_DICT��ȡ��ѡ���';
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_OPERATION_CANCELED_DETAIL
  add constraint PK_OPERATION_CANCELED_DETAIL primary key (PATIENT_ID, VISIT_ID, CANCEL_ID, CANCEL_CLASS, CANCEL_TYPE)
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
