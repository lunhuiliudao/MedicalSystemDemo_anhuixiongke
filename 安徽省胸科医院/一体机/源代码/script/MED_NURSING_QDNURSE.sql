-- Create table
create table MED_NURSING_QDNURSE
(
  PATIENT_ID  VARCHAR2(20) not null,
  VISIT_ID    NUMBER(4) not null,
  OPER_ID     NUMBER(2) not null,
  QX_SQQD     VARCHAR2(20),
  QX_GTQQ     VARCHAR2(20),
  QX_GTQH     VARCHAR2(20),
  QX_JB_NURSE VARCHAR2(20),
  QX_JB_DATE  DATE,
  XH_SQQD     VARCHAR2(20),
  XH_GTQQ     VARCHAR2(20),
  XH_GTQH     VARCHAR2(20),
  XH_JB_NURSE VARCHAR2(20),
  XH_JB_DATE  DATE,
  COMMEN      VARCHAR2(100),
  RESERVED01  VARCHAR2(20),
  RESERVED02  VARCHAR2(20),
  RESERVED03  VARCHAR2(20),
  RESERVED04  VARCHAR2(20),
  RESERVED05  VARCHAR2(20)
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
comment on table MED_NURSING_QDNURSE
  is '护理记录单：术中物品清点记录人员时间表';
-- Add comments to the columns 
comment on column MED_NURSING_QDNURSE.QX_SQQD
  is '器械护士：术前清点';
comment on column MED_NURSING_QDNURSE.QX_GTQQ
  is '器械护士：关体腔前';
comment on column MED_NURSING_QDNURSE.QX_GTQH
  is '器械护士：关体腔后';
comment on column MED_NURSING_QDNURSE.QX_JB_NURSE
  is '器械护士：接班者';
comment on column MED_NURSING_QDNURSE.QX_JB_DATE
  is '器械护士：接班时间';
comment on column MED_NURSING_QDNURSE.XH_SQQD
  is '巡回护士：术前清点';
comment on column MED_NURSING_QDNURSE.XH_GTQQ
  is '巡回护士：关体腔前';
comment on column MED_NURSING_QDNURSE.XH_GTQH
  is '巡回护士：关体腔后';
comment on column MED_NURSING_QDNURSE.XH_JB_NURSE
  is '巡回护士：接班者';
comment on column MED_NURSING_QDNURSE.XH_JB_DATE
  is '巡回护士：接班时间';
comment on column MED_NURSING_QDNURSE.COMMEN
  is '备注';
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_NURSING_QDNURSE
  add constraint MED_NURSING_QDNURSE_PK primary key (PATIENT_ID, VISIT_ID, OPER_ID)
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
grant select, insert, update, delete on MED_NURSING_QDNURSE to ROLE_DOCARE;
