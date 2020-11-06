-- Create table
create table MED_NURSING_BEFOREASSESS
(
  PATIENT_ID     VARCHAR2(40) not null,
  VISIT_ID       NUMBER(4) not null,
  OPER_ID        NUMBER(2) not null,
  SSJQR          VARCHAR2(20),
  TZD            VARCHAR2(20),
  BL             VARCHAR2(20),
  WD             VARCHAR2(20),
  HD_BR          VARCHAR2(20),
  HD_JS          VARCHAR2(20),
  HD_XM          VARCHAR2(20),
  HD_SSMC        VARCHAR2(20),
  HD_SSBW        VARCHAR2(20),
  GMS            VARCHAR2(20),
  JWSSS          VARCHAR2(20),
  MXBS           VARCHAR2(20),
  ZRW_YY         VARCHAR2(20),
  ZRW_XZQBQ      VARCHAR2(20),
  ZRW_RGBM       VARCHAR2(20),
  ZRW_JZ         VARCHAR2(20),
  ZRW_GB         VARCHAR2(20),
  ZRW_ZTQ        VARCHAR2(20),
  ZRW_OTHER      VARCHAR2(20),
  YSZT           VARCHAR2(20),
  YSZT_OTHER     VARCHAR2(40),
  XLZT           VARCHAR2(20),
  PFNM_STATUS    VARCHAR2(20),
  PFNM_BW        VARCHAR2(20),
  PFNM_XZ        VARCHAR2(20),
  SZHD_STATUS    VARCHAR2(20),
  SZHD_BW        VARCHAR2(20),
  SZHD_XZ        VARCHAR2(20),
  SZHD_OTHER     VARCHAR2(20),
  ZTGJ_STATUS    VARCHAR2(20),
  ZTGJ_BW        VARCHAR2(20),
  ZTGJ_XZ        VARCHAR2(20),
  ZTGJ_OTHER     VARCHAR2(20),
  GD_STATUS      VARCHAR2(20),
  GD_WG          VARCHAR2(20),
  GD_NG          VARCHAR2(20),
  GD_XYG         VARCHAR2(20),
  GD_FQYLG       VARCHAR2(20),
  GD_SYG         VARCHAR2(20),
  GD_BW          VARCHAR2(20),
  GD_OTHER       VARCHAR2(20),
  GD__STATUS_DES VARCHAR2(20),
  BFDLW_SP       VARCHAR2(20),
  BFDLW_SP_COUNT VARCHAR2(20),
  BFDLW_YP       VARCHAR2(20),
  BFDLW_YP_NAME  VARCHAR2(20),
  BFDLW_OTHER    VARCHAR2(20),
  RESERVED01     VARCHAR2(20),
  RESERVED02     VARCHAR2(20),
  RESERVED03     VARCHAR2(20),
  RESERVED04     VARCHAR2(20),
  RESERVED05     VARCHAR2(20),
  RESERVED06     VARCHAR2(20),
  RESERVED07     VARCHAR2(20),
  RESERVED08     VARCHAR2(20),
  RESERVED09     VARCHAR2(20),
  RESERVED10     VARCHAR2(20)
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
comment on table MED_NURSING_BEFOREASSESS
  is '护理记录单：手术病人术前入室核对评估';
-- Add comments to the columns 
comment on column MED_NURSING_BEFOREASSESS.SSJQR
  is '手术间确认';
comment on column MED_NURSING_BEFOREASSESS.TZD
  is '通知单';
comment on column MED_NURSING_BEFOREASSESS.BL
  is '病历';
comment on column MED_NURSING_BEFOREASSESS.WD
  is '腕带';
comment on column MED_NURSING_BEFOREASSESS.HD_BR
  is '与病人核对';
comment on column MED_NURSING_BEFOREASSESS.HD_JS
  is '与家属核对';
comment on column MED_NURSING_BEFOREASSESS.HD_XM
  is '核对姓名';
comment on column MED_NURSING_BEFOREASSESS.HD_SSMC
  is '核对手术名称';
comment on column MED_NURSING_BEFOREASSESS.HD_SSBW
  is '核对手术部位';
comment on column MED_NURSING_BEFOREASSESS.GMS
  is '过敏史';
comment on column MED_NURSING_BEFOREASSESS.JWSSS
  is '既往手术史';
comment on column MED_NURSING_BEFOREASSESS.MXBS
  is '慢性病史';
comment on column MED_NURSING_BEFOREASSESS.ZRW_YY
  is '植入物：义眼';
comment on column MED_NURSING_BEFOREASSESS.ZRW_XZQBQ
  is '植入物：心脏起搏器';
comment on column MED_NURSING_BEFOREASSESS.ZRW_RGBM
  is '植入物：人工瓣膜';
comment on column MED_NURSING_BEFOREASSESS.ZRW_JZ
  is '植入物：假肢';
comment on column MED_NURSING_BEFOREASSESS.ZRW_GB
  is '植入物：钢板';
comment on column MED_NURSING_BEFOREASSESS.ZRW_ZTQ
  is '植入物：助听器';
comment on column MED_NURSING_BEFOREASSESS.ZRW_OTHER
  is '植入物：其他';
comment on column MED_NURSING_BEFOREASSESS.YSZT
  is '意识状态';
comment on column MED_NURSING_BEFOREASSESS.YSZT_OTHER
  is '意识状态：其他描述';
comment on column MED_NURSING_BEFOREASSESS.XLZT
  is '心理状态：平静、稳定、紧张、焦虑、恐惧、悲伤、压抑';
comment on column MED_NURSING_BEFOREASSESS.PFNM_STATUS
  is '皮肤黏膜:正常or破损';
comment on column MED_NURSING_BEFOREASSESS.PFNM_BW
  is '皮肤黏膜：部位';
comment on column MED_NURSING_BEFOREASSESS.PFNM_XZ
  is '皮肤黏膜：性质';
comment on column MED_NURSING_BEFOREASSESS.SZHD_STATUS
  is '四肢活动：正常or破损';
comment on column MED_NURSING_BEFOREASSESS.SZHD_BW
  is '四肢活动：部位';
comment on column MED_NURSING_BEFOREASSESS.SZHD_XZ
  is '四肢活动：性质';
comment on column MED_NURSING_BEFOREASSESS.SZHD_OTHER
  is '四肢活动：性质：其他';
comment on column MED_NURSING_BEFOREASSESS.ZTGJ_STATUS
  is '肢体感觉：正常or异常';
comment on column MED_NURSING_BEFOREASSESS.ZTGJ_BW
  is '肢体感觉：部位';
comment on column MED_NURSING_BEFOREASSESS.ZTGJ_XZ
  is '肢体感觉：性质';
comment on column MED_NURSING_BEFOREASSESS.ZTGJ_OTHER
  is '肢体感觉：性质：其他';
comment on column MED_NURSING_BEFOREASSESS.GD_STATUS
  is '管道：有or无';
comment on column MED_NURSING_BEFOREASSESS.GD_WG
  is '管道：胃管';
comment on column MED_NURSING_BEFOREASSESS.GD_NG
  is '管道：尿管';
comment on column MED_NURSING_BEFOREASSESS.GD_XYG
  is '管道：胸引管';
comment on column MED_NURSING_BEFOREASSESS.GD_FQYLG
  is '管道：腹腔引流管';
comment on column MED_NURSING_BEFOREASSESS.GD_SYG
  is '管道：输液管';
comment on column MED_NURSING_BEFOREASSESS.GD_BW
  is '管道：部位';
comment on column MED_NURSING_BEFOREASSESS.GD_OTHER
  is '管道：其他';
comment on column MED_NURSING_BEFOREASSESS.GD__STATUS_DES
  is '管道状态：通畅、堵塞、松动';
comment on column MED_NURSING_BEFOREASSESS.BFDLW_SP
  is '病房带来物：摄片';
comment on column MED_NURSING_BEFOREASSESS.BFDLW_SP_COUNT
  is '病房带来物：摄片张数';
comment on column MED_NURSING_BEFOREASSESS.BFDLW_YP
  is '病房带来物：药品';
comment on column MED_NURSING_BEFOREASSESS.BFDLW_YP_NAME
  is '病房带来物：药品名称';
comment on column MED_NURSING_BEFOREASSESS.BFDLW_OTHER
  is '病房带来物：其他';
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_NURSING_BEFOREASSESS
  add constraint MED_NURSING_BEFOREASSESS_PK primary key (PATIENT_ID, VISIT_ID, OPER_ID)
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
grant select, insert, update, delete on MED_NURSING_BEFOREASSESS to ROLE_DOCARE;