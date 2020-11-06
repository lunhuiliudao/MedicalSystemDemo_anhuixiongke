-- Create table
create table MED_NURSING_BEFORESHIFT
(
  PATIENT_ID    VARCHAR2(40) not null,
  VISIT_ID      NUMBER(4) not null,
  OPER_ID       NUMBER(2) not null,
  BINGLI        VARCHAR2(20),
  YP_NAME_COUNT VARCHAR2(100),
  YXXZL         VARCHAR2(20),
  YXXZL_COUNT   VARCHAR2(20),
  BRHD          VARCHAR2(20),
  SSBWHD        VARCHAR2(20),
  JSS           VARCHAR2(20),
  RSQPN         VARCHAR2(20),
  BP            VARCHAR2(20),
  JSTYQZ        VARCHAR2(20),
  QCSSYXYJJA    VARCHAR2(20),
  SQYY          VARCHAR2(20),
  THKC          VARCHAR2(20),
  FR            VARCHAR2(20),
  KS            VARCHAR2(20),
  SDY           VARCHAR2(20),
  MZXGZS        VARCHAR2(20),
  SSXGZS        VARCHAR2(20),
  YG_YING_YANG  VARCHAR2(20),
  HIV_YING_YNAG VARCHAR2(20),
  HIV_OTHER     VARCHAR2(60),
  BF_NURSE      VARCHAR2(20),
  SSS_NURSE     VARCHAR2(20),
  SHIFT_DATE    DATE,
  RESERVED01    VARCHAR2(20),
  RESERVED02    VARCHAR2(20),
  RESERVED03    VARCHAR2(20),
  RESERVED04    VARCHAR2(20),
  RESERVED05    VARCHAR2(20),
  RESERVED06    VARCHAR2(20),
  RESERVED07    VARCHAR2(20),
  RESERVED08    VARCHAR2(20),
  RESERVED09    VARCHAR2(20),
  RESERVED10    VARCHAR2(20)
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
comment on table MED_NURSING_BEFORESHIFT
  is '护理记录单-术前交接';
-- Add comments to the columns 
comment on column MED_NURSING_BEFORESHIFT.BINGLI
  is '病历';
comment on column MED_NURSING_BEFORESHIFT.YP_NAME_COUNT
  is '药品名称和数量';
comment on column MED_NURSING_BEFORESHIFT.YXXZL
  is '影像学资料';
comment on column MED_NURSING_BEFORESHIFT.YXXZL_COUNT
  is '影像学资料数量';
comment on column MED_NURSING_BEFORESHIFT.BRHD
  is '病人核对';
comment on column MED_NURSING_BEFORESHIFT.SSBWHD
  is '手术部位核对';
comment on column MED_NURSING_BEFORESHIFT.JSS
  is '禁食水';
comment on column MED_NURSING_BEFORESHIFT.RSQPN
  is '入室前排尿';
comment on column MED_NURSING_BEFORESHIFT.BP
  is '备皮';
comment on column MED_NURSING_BEFORESHIFT.JSTYQZ
  is '家属同意签字';
comment on column MED_NURSING_BEFORESHIFT.QCSSYXYJJA
  is '去除首饰及隐形眼镜、假牙';
comment on column MED_NURSING_BEFORESHIFT.SQYY
  is '术前用药有无';
comment on column MED_NURSING_BEFORESHIFT.THKC
  is '月经来潮有无';
comment on column MED_NURSING_BEFORESHIFT.FR
  is '发热有无';
comment on column MED_NURSING_BEFORESHIFT.KS
  is '咳嗽有无';
comment on column MED_NURSING_BEFORESHIFT.SDY
  is '松动牙有无';
comment on column MED_NURSING_BEFORESHIFT.MZXGZS
  is '麻醉相关知识';
comment on column MED_NURSING_BEFORESHIFT.SSXGZS
  is '手术相关知识';
comment on column MED_NURSING_BEFORESHIFT.YG_YING_YANG
  is '乙肝：阴性阳性';
comment on column MED_NURSING_BEFORESHIFT.HIV_YING_YNAG
  is 'HIV：阴性阳性';
comment on column MED_NURSING_BEFORESHIFT.HIV_OTHER
  is 'HIV：其他';
comment on column MED_NURSING_BEFORESHIFT.BF_NURSE
  is '病房护士';
comment on column MED_NURSING_BEFORESHIFT.SSS_NURSE
  is '手术室护士';
comment on column MED_NURSING_BEFORESHIFT.SHIFT_DATE
  is '交接时间';
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_NURSING_BEFORESHIFT
  add constraint MED_NURSING_BEFORESHIFT_PK primary key (PATIENT_ID, VISIT_ID, OPER_ID)
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
grant select, insert, update, delete on MED_NURSING_BEFORESHIFT to ROLE_DOCARE;
