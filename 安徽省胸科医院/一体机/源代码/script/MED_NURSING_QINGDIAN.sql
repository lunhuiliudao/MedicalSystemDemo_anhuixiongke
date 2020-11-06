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
  is '护理记录单：术中物品清点记录单';
-- Add comments to the columns 
comment on column MED_NURSING_QINGDIAN.ITEM_NO
  is '行号';
comment on column MED_NURSING_QINGDIAN.ITEM_NAME1
  is '物品名称1';
comment on column MED_NURSING_QINGDIAN.SSQ1
  is '手术前';
comment on column MED_NURSING_QINGDIAN.GTQQ1
  is '关体腔前';
comment on column MED_NURSING_QINGDIAN.GTQH1
  is '关体腔后';
comment on column MED_NURSING_QINGDIAN.FPH1
  is '缝皮后';
comment on column MED_NURSING_QINGDIAN.ITEM_NAME2
  is '物品名称2';
comment on column MED_NURSING_QINGDIAN.SSQ2
  is '手术前';
comment on column MED_NURSING_QINGDIAN.GTQQ2
  is '关体腔前';
comment on column MED_NURSING_QINGDIAN.GTQH2
  is '关体腔后';
comment on column MED_NURSING_QINGDIAN.FPH2
  is '缝皮后';
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
