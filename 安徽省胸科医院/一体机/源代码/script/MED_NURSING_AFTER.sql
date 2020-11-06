-- Create table
create table MED_NURSING_AFTER
(
  PATIENT_ID VARCHAR2(20) not null,
  VISIT_ID   NUMBER(4) not null,
  OPER_ID    NUMBER(2) not null,
  YS         VARCHAR2(20),
  QGCG       VARCHAR2(20),
  XY         VARCHAR2(20),
  MB         VARCHAR2(20),
  HX         VARCHAR2(20),
  PF         VARCHAR2(20),
  PF_OTHER   VARCHAR2(20),
  PF_CXL     VARCHAR2(20),
  YLG_STATUS VARCHAR2(20),
  YLG_WG     VARCHAR2(20),
  YLG_NG     VARCHAR2(20),
  YLG_XYG    VARCHAR2(20),
  YLG_FQYLG  VARCHAR2(20),
  YLG_SYG    VARCHAR2(20),
  YLG_OTHER  VARCHAR2(20),
  YLG_COUNT  VARCHAR2(20),
  YLG_NL     VARCHAR2(20),
  YY_WZ      VARCHAR2(20),
  YY_ZXJM    VARCHAR2(20),
  NURSE      VARCHAR2(20),
  OUT_DATE   DATE,
  RESERVED01 VARCHAR2(20),
  RESERVED02 VARCHAR2(20),
  RESERVED03 VARCHAR2(20),
  RESERVED04 VARCHAR2(20),
  RESERVED05 VARCHAR2(20),
  RESERVED06 VARCHAR2(20),
  RESERVED07 VARCHAR2(20),
  RESERVED08 VARCHAR2(20),
  RESERVED09 VARCHAR2(20),
  RESERVED10 VARCHAR2(20)
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
comment on table MED_NURSING_AFTER
  is '护理记录单：术后记录';
-- Add comments to the columns 
comment on column MED_NURSING_AFTER.YS
  is '意识';
comment on column MED_NURSING_AFTER.QGCG
  is '气管插管：有or无';
comment on column MED_NURSING_AFTER.XY
  is '血压';
comment on column MED_NURSING_AFTER.MB
  is '脉搏';
comment on column MED_NURSING_AFTER.HX
  is '呼吸';
comment on column MED_NURSING_AFTER.PF
  is '皮肤情况';
comment on column MED_NURSING_AFTER.PF_OTHER
  is '皮肤情况：其他';
comment on column MED_NURSING_AFTER.PF_CXL
  is '皮肤情况：出血量';
comment on column MED_NURSING_AFTER.YLG_STATUS
  is '引流管：有or无';
comment on column MED_NURSING_AFTER.YLG_WG
  is '引流管：胃管';
comment on column MED_NURSING_AFTER.YLG_NG
  is '引流管：尿管';
comment on column MED_NURSING_AFTER.YLG_XYG
  is '引流管：胸引管';
comment on column MED_NURSING_AFTER.YLG_FQYLG
  is '引流管：腹腔引流管';
comment on column MED_NURSING_AFTER.YLG_SYG
  is '引流管：输液管';
comment on column MED_NURSING_AFTER.YLG_OTHER
  is '引流管：其他';
comment on column MED_NURSING_AFTER.YLG_COUNT
  is '引流管：总数量';
comment on column MED_NURSING_AFTER.YLG_NL
  is '引流管：尿量';
comment on column MED_NURSING_AFTER.YY_WZ
  is '余液：外周';
comment on column MED_NURSING_AFTER.YY_ZXJM
  is '余液：中心静脉';
comment on column MED_NURSING_AFTER.NURSE
  is '巡回护士';
comment on column MED_NURSING_AFTER.OUT_DATE
  is '离室时间';
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_NURSING_AFTER
  add constraint MED_NURSING_AFTER_PK primary key (PATIENT_ID, VISIT_ID, OPER_ID)
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
grant select, insert, update, delete on MED_NURSING_AFTER to ROLE_DOCARE;
