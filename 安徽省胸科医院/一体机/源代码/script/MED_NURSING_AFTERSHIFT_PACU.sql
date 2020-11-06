-- Create table
create table MED_NURSING_AFTERSHIFT_PACU
(
  PATIENT_ID      VARCHAR2(40) not null,
  VISIT_ID        NUMBER(4) not null,
  OPER_ID         NUMBER(2) not null,
  YLG_BW          VARCHAR2(20),
  YLG_COUNT       VARCHAR2(20),
  PF_STATUS       VARCHAR2(20),
  PF_OTHER        VARCHAR2(20),
  YS              VARCHAR2(20),
  DHBQYW_X        VARCHAR2(20),
  DHBQYW_X_COUNT  VARCHAR2(20),
  DHBQYW_YW       VARCHAR2(20),
  DHBQYW_YW_NAME  VARCHAR2(20),
  DHBQYW_YW_OTHER VARCHAR2(20),
  SYBW_SZ         VARCHAR2(20),
  SYBW_XZ         VARCHAR2(20),
  SYBW_SGX        VARCHAR2(20),
  SYBW_JN         VARCHAR2(20),
  SYBW_OTHER      VARCHAR2(20),
  DHXZP_H         VARCHAR2(20),
  DHXZP_X         VARCHAR2(20),
  LZNG_STATUS     VARCHAR2(20),
  LZNG_NL         VARCHAR2(20),
  WX              VARCHAR2(20),
  XH_NURSE        VARCHAR2(20),
  BQ_NURSE        VARCHAR2(20),
  TIME_POINT      DATE,
  RESERVED01      VARCHAR2(20),
  RESERVED02      VARCHAR2(20),
  RESERVED03      VARCHAR2(20),
  RESERVED04      VARCHAR2(20),
  RESERVED05      VARCHAR2(20),
  RESERVED06      VARCHAR2(20),
  RESERVED07      VARCHAR2(20),
  RESERVED08      VARCHAR2(20),
  RESERVED09      VARCHAR2(20),
  RESERVED10      VARCHAR2(20)
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
comment on table MED_NURSING_AFTERSHIFT_PACU
  is '护理记录单：病区护士（含ICU）交接记录';
-- Add comments to the columns 
comment on column MED_NURSING_AFTERSHIFT_PACU.YLG_BW
  is '引流管：部位';
comment on column MED_NURSING_AFTERSHIFT_PACU.YLG_COUNT
  is '引流管：数量';
comment on column MED_NURSING_AFTERSHIFT_PACU.PF_STATUS
  is '皮肤：正常or异常';
comment on column MED_NURSING_AFTERSHIFT_PACU.PF_OTHER
  is '皮肤：其他描述';
comment on column MED_NURSING_AFTERSHIFT_PACU.YS
  is '意识情况';
comment on column MED_NURSING_AFTERSHIFT_PACU.DHBQYW_X
  is '带回病区用物：X光片';
comment on column MED_NURSING_AFTERSHIFT_PACU.DHBQYW_X_COUNT
  is '带回病区用物：X光片数量';
comment on column MED_NURSING_AFTERSHIFT_PACU.DHBQYW_YW
  is '带回病区药物：有无';
comment on column MED_NURSING_AFTERSHIFT_PACU.DHBQYW_YW_NAME
  is '带回病区药物：名称';
comment on column MED_NURSING_AFTERSHIFT_PACU.DHBQYW_YW_OTHER
  is '带回病区药物：其他';
comment on column MED_NURSING_AFTERSHIFT_PACU.SYBW_SZ
  is '输液部位：上肢';
comment on column MED_NURSING_AFTERSHIFT_PACU.SYBW_XZ
  is '输液部位：下肢';
comment on column MED_NURSING_AFTERSHIFT_PACU.SYBW_SGX
  is '输液部位：锁骨下';
comment on column MED_NURSING_AFTERSHIFT_PACU.SYBW_JN
  is '输液部位：颈内';
comment on column MED_NURSING_AFTERSHIFT_PACU.SYBW_OTHER
  is '输液部位：其他';
comment on column MED_NURSING_AFTERSHIFT_PACU.DHXZP_H
  is '带回血制品：红细胞';
comment on column MED_NURSING_AFTERSHIFT_PACU.DHXZP_X
  is '带回血制品：血浆';
comment on column MED_NURSING_AFTERSHIFT_PACU.LZNG_STATUS
  is '留置尿管：有or无';
comment on column MED_NURSING_AFTERSHIFT_PACU.LZNG_NL
  is '留置尿管：尿量';
comment on column MED_NURSING_AFTERSHIFT_PACU.WX
  is '病人体表及衣裤是否有污血';
comment on column MED_NURSING_AFTERSHIFT_PACU.XH_NURSE
  is '巡回护士';
comment on column MED_NURSING_AFTERSHIFT_PACU.BQ_NURSE
  is '病区护士';
comment on column MED_NURSING_AFTERSHIFT_PACU.TIME_POINT
  is '交接时间';
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_NURSING_AFTERSHIFT_PACU
  add constraint MED_NURSING_AFTERSHIFT_PACU_PK primary key (PATIENT_ID, VISIT_ID, OPER_ID)
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
grant select, insert, update, delete on MED_NURSING_AFTERSHIFT_PACU to ROLE_DOCARE;
