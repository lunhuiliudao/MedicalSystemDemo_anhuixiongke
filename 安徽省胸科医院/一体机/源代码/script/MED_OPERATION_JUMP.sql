-- Create table
create table MED_OPERATION_JUMP
(
  PATIENT_ID      VARCHAR2(40) not null,
  VISIT_ID        NUMBER(4) not null,
  OPER_ID         NUMBER(2) not null,
  OPER_STATUS_OLD NUMBER(3) not null,
  OPER_STATUS_NEW NUMBER(3) not null,
  JUMP_REASON     VARCHAR2(500),
  JUMP_DATE       DATE not null,
  ENTERED_BY      VARCHAR2(20)
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
comment on table MED_OPERATION_JUMP
  is '������ת��¼��';
-- Add comments to the columns 
comment on column MED_OPERATION_JUMP.PATIENT_ID
  is '����ID;�ǿգ�Ψһȷ����������';
comment on column MED_OPERATION_JUMP.VISIT_ID
  is '��Ժ����;סԺ����ÿ��סԺ��1';
comment on column MED_OPERATION_JUMP.OPER_ID
  is '������ʶ';
comment on column MED_OPERATION_JUMP.OPER_STATUS_OLD
  is 'ԭ����״̬';
comment on column MED_OPERATION_JUMP.OPER_STATUS_NEW
  is '������״̬;��ת��������״̬��Ĭ���������״̬';
comment on column MED_OPERATION_JUMP.JUMP_REASON
  is '�˻�ԭ��';
comment on column MED_OPERATION_JUMP.JUMP_DATE
  is '�˻��ռ�';
comment on column MED_OPERATION_JUMP.ENTERED_BY
  is '������Ա';
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_OPERATION_JUMP
  add constraint PK_MED_OPERATION_JUMP primary key (PATIENT_ID, VISIT_ID, OPER_ID, JUMP_DATE)
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
