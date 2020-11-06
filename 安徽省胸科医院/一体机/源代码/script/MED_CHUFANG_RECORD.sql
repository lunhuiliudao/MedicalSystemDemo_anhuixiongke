-- Create table
create table MED_CHUFANG_RECORD
(
  PATIENT_ID       VARCHAR2(40) not null,
  VISIT_ID         NUMBER(4) not null,
  OPER_ID          NUMBER(2) not null,
  CHUFANG_CLASS    NUMBER(2) not null,
  CHUFANG_INDEX    NUMBER(8) not null,
  FREE_ITEM_CLASS  NUMBER(2),
  CHUFANG_DATE     DATE,
  DOCTOR           VARCHAR2(50),
  MONEY            NUMBER(8,2),
  CHECK_DOCTOR     VARCHAR2(50),
  BLEND_DOCTOR     VARCHAR2(50),
  CONFIRM_DOCTOR   VARCHAR2(50),
  EVENT_ITEM_NAME  VARCHAR2(256),
  EVENT_ITEM_SPEC  VARCHAR2(20),
  AMOUNT           NUMBER(4,2),
  AMOUNT_UNITS     VARCHAR2(10),
  DOSAGE           NUMBER(8,4),
  DOSAGE_UNITS     VARCHAR2(10),
  EVENT_METHOD     VARCHAR2(256),
  DISUSE           NUMBER(8,4),
  DISUSE_UNITS     VARCHAR2(10),
  EVENT_ITEM_NAME1 VARCHAR2(256),
  EVENT_ITEM_SPEC1 VARCHAR2(20),
  AMOUNT1          NUMBER(4,2),
  AMOUNT_UNITS1    VARCHAR2(10),
  DOSAGE1          NUMBER(8,4),
  DOSAGE_UNITS1    VARCHAR2(10),
  EVENT_METHOD1    VARCHAR2(256),
  DISUSE1          NUMBER(8,4),
  DISUSE_UNITS1    VARCHAR2(10),
  EVENT_ITEM_NAME2 VARCHAR2(256),
  EVENT_ITEM_SPEC2 VARCHAR2(20),
  AMOUNT2          NUMBER(4,2),
  AMOUNT_UNITS2    VARCHAR2(10),
  DOSAGE2          NUMBER(8,4),
  DOSAGE_UNITS2    VARCHAR2(10),
  EVENT_METHOD2    VARCHAR2(256),
  DISUSE2          NUMBER(8,4),
  DISUSE_UNITS2    VARCHAR2(10),
  EVENT_ITEM_NAME3 VARCHAR2(256),
  EVENT_ITEM_SPEC3 VARCHAR2(20),
  AMOUNT3          NUMBER(4,2),
  AMOUNT_UNITS3    VARCHAR2(10),
  DOSAGE3          NUMBER(8,4),
  DOSAGE_UNITS3    VARCHAR2(10),
  EVENT_METHOD3    VARCHAR2(256),
  DISUSE3          NUMBER(8,4),
  DISUSE_UNITS3    VARCHAR2(10),
  EVENT_ITEM_NAME4 VARCHAR2(256),
  EVENT_ITEM_SPEC4 VARCHAR2(20),
  AMOUNT4          NUMBER(4,2),
  AMOUNT_UNITS4    VARCHAR2(10),
  DOSAGE4          NUMBER(8,4),
  DOSAGE_UNITS4    VARCHAR2(10),
  EVENT_METHOD4    VARCHAR2(256),
  DISUSE4          NUMBER(8,4),
  DISUSE_UNITS4    VARCHAR2(10)
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
-- Add comments to the columns 
comment on column MED_CHUFANG_RECORD.CHUFANG_CLASS
  is '���������ͣ���һ=0������=1';
comment on column MED_CHUFANG_RECORD.CHUFANG_INDEX
  is '���������';
comment on column MED_CHUFANG_RECORD.FREE_ITEM_CLASS
  is '�շ���𣺹���=0���Է�=1��ҽ��=2������=3';
comment on column MED_CHUFANG_RECORD.CHUFANG_DATE
  is '��������ʱ��';
comment on column MED_CHUFANG_RECORD.DOCTOR
  is 'ҽʦ';
comment on column MED_CHUFANG_RECORD.MONEY
  is '���';
comment on column MED_CHUFANG_RECORD.CHECK_DOCTOR
  is '���ҩʦ';
comment on column MED_CHUFANG_RECORD.BLEND_DOCTOR
  is '����ҩʦ';
comment on column MED_CHUFANG_RECORD.CONFIRM_DOCTOR
  is '�˶ԡ���ҩҩʦ';
comment on column MED_CHUFANG_RECORD.EVENT_ITEM_NAME
  is 'ҩƷ����';
comment on column MED_CHUFANG_RECORD.EVENT_ITEM_SPEC
  is 'ҩƷ���';
comment on column MED_CHUFANG_RECORD.AMOUNT
  is 'ҩƷ����';
comment on column MED_CHUFANG_RECORD.AMOUNT_UNITS
  is 'ҩƷ������λ';
comment on column MED_CHUFANG_RECORD.DOSAGE
  is 'ҩƷ����';
comment on column MED_CHUFANG_RECORD.DOSAGE_UNITS
  is '������λ';
comment on column MED_CHUFANG_RECORD.EVENT_METHOD
  is 'ҩƷ�÷�';
comment on column MED_CHUFANG_RECORD.DISUSE
  is 'ҩƷ������';
comment on column MED_CHUFANG_RECORD.DISUSE_UNITS
  is '��������λ';
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_CHUFANG_RECORD
  add constraint MED_CHUFANG_RECORD_PK primary key (PATIENT_ID, VISIT_ID, OPER_ID, CHUFANG_INDEX)
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
grant select, insert, update, delete on MED_CHUFANG_RECORD to ROLE_DOCARE;
