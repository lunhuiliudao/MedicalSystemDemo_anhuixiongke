-- Create table
create table MED_NURSING_QINGDIAN
(
  PATIENT_ID VARCHAR2(20) not null,
  VISIT_ID   NUMBER(4) not null,
  OPER_ID    NUMBER(2) not null,
  ITEM_NO    NUMBER(4) not null,
  ITEM_NAME1 VARCHAR2(40),
  SSQ1       NUMBER(2),
  GTQQ1      NUMBER(2),
  GTQH1      NUMBER(2),
  FPH1       NUMBER(2),
  ITEM_NAME2 VARCHAR2(40),
  SSQ2       NUMBER(2),
  GTQQ2      NUMBER(2),
  GTQH2      NUMBER(2),
  FPH2       NUMBER(2),
  RESERVED01 VARCHAR2(40),
  RESERVED02 VARCHAR2(40),
  RESERVED03 VARCHAR2(40),
  RESERVED04 VARCHAR2(40),
  RESERVED05 VARCHAR2(40)
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
comment on table MED_NURSING_QINGDIAN
  is '�����¼����������Ʒ����¼��';
-- Add comments to the columns 
comment on column MED_NURSING_QINGDIAN.ITEM_NO
  is '�к�';
comment on column MED_NURSING_QINGDIAN.ITEM_NAME1
  is '��Ʒ����1';
comment on column MED_NURSING_QINGDIAN.SSQ1
  is '����ǰ';
comment on column MED_NURSING_QINGDIAN.GTQQ1
  is '����ǻǰ';
comment on column MED_NURSING_QINGDIAN.GTQH1
  is '����ǻ��';
comment on column MED_NURSING_QINGDIAN.FPH1
  is '��Ƥ��';
comment on column MED_NURSING_QINGDIAN.ITEM_NAME2
  is '��Ʒ����2';
comment on column MED_NURSING_QINGDIAN.SSQ2
  is '����ǰ';
comment on column MED_NURSING_QINGDIAN.GTQQ2
  is '����ǻǰ';
comment on column MED_NURSING_QINGDIAN.GTQH2
  is '����ǻ��';
comment on column MED_NURSING_QINGDIAN.FPH2
  is '��Ƥ��';
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_NURSING_QINGDIAN
  add constraint MED_NURSING_QINGDIAN_PK primary key (PATIENT_ID, VISIT_ID, OPER_ID, ITEM_NO)
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
-- Grant/Revoke object privileges 
grant select, insert, update, delete on MED_NURSING_QINGDIAN to ROLE_DOCARE;
