-- Create table
create table MED_NURSING_AFTERSHIFT_WARD
(
  PATIENT_ID      VARCHAR2(40) not null,
  VISIT_ID        NUMBER(4) not null,
  OPER_ID         NUMBER(2) not null,
  JBLX_NURSE      VARCHAR2(20),
  KTJB_SSMC       VARCHAR2(20),
  KTJB_SSBW       VARCHAR2(20),
  KTJB_MZFS       VARCHAR2(20),
  KTJB_SSTW       VARCHAR2(20),
  KTJB_ZXD        VARCHAR2(20),
  KTJB_CXL        VARCHAR2(20),
  PF_STATUS       VARCHAR2(20),
  PF_OTHER        VARCHAR2(20),
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
  WX              VARCHAR2(20),
  XH_NURSE        VARCHAR2(20),
  FS_BQ           VARCHAR2(20),
  FS_BQ_NURSE     VARCHAR2(20),
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
comment on table MED_NURSING_AFTERSHIFT_WARD
  is '护理记录单：病区护士（含ICU）交接记录';
-- Add comments to the columns 
comment on column MED_NURSING_AFTERSHIFT_WARD.JBLX_NURSE
  is '与复苏室护士or病区护士';
comment on column MED_NURSING_AFTERSHIFT_WARD.KTJB_SSMC
  is '口头交班：手术名称';
comment on column MED_NURSING_AFTERSHIFT_WARD.KTJB_SSBW
  is '口头交班：手术部位';
comment on column MED_NURSING_AFTERSHIFT_WARD.KTJB_MZFS
  is '口头交班：麻醉方式';
comment on column MED_NURSING_AFTERSHIFT_WARD.KTJB_SSTW
  is '口头交班：手术体位';
comment on column MED_NURSING_AFTERSHIFT_WARD.KTJB_ZXD
  is '口头交班：止血带';
comment on column MED_NURSING_AFTERSHIFT_WARD.KTJB_CXL
  is '口头交班：出血量';
comment on column MED_NURSING_AFTERSHIFT_WARD.PF_STATUS
  is '皮肤：正常or异常';
comment on column MED_NURSING_AFTERSHIFT_WARD.PF_OTHER
  is '皮肤：其他描述';
comment on column MED_NURSING_AFTERSHIFT_WARD.DHBQYW_X
  is '带回病区用物：X光片';
comment on column MED_NURSING_AFTERSHIFT_WARD.DHBQYW_X_COUNT
  is '带回病区用物：X光片数量';
comment on column MED_NURSING_AFTERSHIFT_WARD.DHBQYW_YW
  is '带回病区用物：药物有无';
comment on column MED_NURSING_AFTERSHIFT_WARD.DHBQYW_YW_NAME
  is '带回病区用物：药物名称';
comment on column MED_NURSING_AFTERSHIFT_WARD.DHBQYW_YW_OTHER
  is '带回病区用物：药物其他';
comment on column MED_NURSING_AFTERSHIFT_WARD.SYBW_SZ
  is '输液部位：上肢';
comment on column MED_NURSING_AFTERSHIFT_WARD.SYBW_XZ
  is '输液部位：下肢';
comment on column MED_NURSING_AFTERSHIFT_WARD.SYBW_SGX
  is '输液部位：锁骨下';
comment on column MED_NURSING_AFTERSHIFT_WARD.SYBW_JN
  is '输液部位：颈内';
comment on column MED_NURSING_AFTERSHIFT_WARD.SYBW_OTHER
  is '输液部位：其他';
comment on column MED_NURSING_AFTERSHIFT_WARD.DHXZP_H
  is '带回血制品：红细胞';
comment on column MED_NURSING_AFTERSHIFT_WARD.DHXZP_X
  is '带回血制品：血浆';
comment on column MED_NURSING_AFTERSHIFT_WARD.LZNG_STATUS
  is '留置尿管：有or无';
comment on column MED_NURSING_AFTERSHIFT_WARD.WX
  is '病人体表及衣裤是否有污血';
comment on column MED_NURSING_AFTERSHIFT_WARD.XH_NURSE
  is '巡回护士';
comment on column MED_NURSING_AFTERSHIFT_WARD.FS_BQ
  is '是复苏护士还是病区护士';
comment on column MED_NURSING_AFTERSHIFT_WARD.FS_BQ_NURSE
  is '复苏护士or病区护士的姓名';
comment on column MED_NURSING_AFTERSHIFT_WARD.TIME_POINT
  is '交接时间';
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_NURSING_AFTERSHIFT_WARD
  add constraint MED_NURSING_AFTERSHIFT_WARD_PK primary key (PATIENT_ID, VISIT_ID, OPER_ID)
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
grant select, insert, update, delete on MED_NURSING_AFTERSHIFT_WARD to ROLE_DOCARE;