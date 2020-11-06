-- Create table
create table MED_NURSING_YWASSESS
(
  PATIENT_ID    VARCHAR2(20) not null,
  VISIT_ID      NUMBER(4) not null,
  OPER_ID       NUMBER(2) not null,
  SSQX          VARCHAR2(20),
  YQSB          VARCHAR2(20),
  TWYP          VARCHAR2(20),
  SSHJ          VARCHAR2(20),
  YFDTW_SW      VARCHAR2(20),
  YFDTW_BWT     VARCHAR2(20),
  YFDTW_WYS     VARCHAR2(20),
  YFDTW_JSJG    VARCHAR2(20),
  SYZLD         VARCHAR2(20),
  YT            VARCHAR2(20),
  GHTW_STATUS   VARCHAR2(20),
  GHTW_DATE     DATE,
  GHTW_FS       VARCHAR2(20),
  DDSY          VARCHAR2(20),
  FJBZTWZ       VARCHAR2(20),
  JBPFQK        VARCHAR2(20),
  QYZXD_STATUS  VARCHAR2(20),
  QYZXD_BZWZ    VARCHAR2(20),
  QYZXD_YL      VARCHAR2(20),
  QYZXD_DATE    DATE,
  QYZXD_SBDATE  DATE,
  QYZXD_JBPF    VARCHAR2(20),
  SZBD          VARCHAR2(20),
  BLBB          VARCHAR2(20),
  XHHSJB_STATUS VARCHAR2(20),
  SYBW_SZ       VARCHAR2(20),
  SYBW_XZ       VARCHAR2(20),
  SYBW_SGX      VARCHAR2(20),
  SYBW_JN       VARCHAR2(20),
  BRDLW_X       VARCHAR2(20),
  BRDLW_YW      VARCHAR2(20),
  SYXZP         VARCHAR2(20),
  ZZSQLYZP      VARCHAR2(20),
  SSTWPSL       VARCHAR2(20),
  GZTSHC        VARCHAR2(20),
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
comment on table MED_NURSING_YWASSESS
  is '护理记录单：手术用物评估和术中护理';
-- Add comments to the columns 
comment on column MED_NURSING_YWASSESS.SSQX
  is '手术器械准备';
comment on column MED_NURSING_YWASSESS.YQSB
  is '仪器设备';
comment on column MED_NURSING_YWASSESS.TWYP
  is '体位用品';
comment on column MED_NURSING_YWASSESS.SSHJ
  is '手术环境';
comment on column MED_NURSING_YWASSESS.YFDTW_SW
  is '预防低体温：室温';
comment on column MED_NURSING_YWASSESS.YFDTW_BWT
  is '预防低体温：保温毯';
comment on column MED_NURSING_YWASSESS.YFDTW_WYS
  is '预防低体温：温盐水';
comment on column MED_NURSING_YWASSESS.YFDTW_JSJG
  is '预防低体温：及时加盖非手术区';
comment on column MED_NURSING_YWASSESS.SYZLD
  is '使用啫喱垫';
comment on column MED_NURSING_YWASSESS.YT
  is '使用眼贴';
comment on column MED_NURSING_YWASSESS.GHTW_STATUS
  is '更换体位：有or无';
comment on column MED_NURSING_YWASSESS.GHTW_DATE
  is '更换体位：时间';
comment on column MED_NURSING_YWASSESS.GHTW_FS
  is '更换体位：更换方式';
comment on column MED_NURSING_YWASSESS.DDSY
  is '电刀使用';
comment on column MED_NURSING_YWASSESS.FJBZTWZ
  is '负极板粘贴位置';
comment on column MED_NURSING_YWASSESS.JBPFQK
  is '局部皮肤情况';
comment on column MED_NURSING_YWASSESS.QYZXD_STATUS
  is '气压止血带：有or无';
comment on column MED_NURSING_YWASSESS.QYZXD_BZWZ
  is '绑扎位置';
comment on column MED_NURSING_YWASSESS.QYZXD_YL
  is '气压止血带：压力';
comment on column MED_NURSING_YWASSESS.QYZXD_DATE
  is '气压止血带：绑扎时间';
comment on column MED_NURSING_YWASSESS.QYZXD_SBDATE
  is '气压止血带：放松时间';
comment on column MED_NURSING_YWASSESS.QYZXD_JBPF
  is '气压止血带：局部皮肤';
comment on column MED_NURSING_YWASSESS.SZBD
  is '术中冰冻';
comment on column MED_NURSING_YWASSESS.BLBB
  is '病理标本';
comment on column MED_NURSING_YWASSESS.XHHSJB_STATUS
  is '巡回护士交班：有or无';
comment on column MED_NURSING_YWASSESS.SYBW_SZ
  is '输液部位：上肢';
comment on column MED_NURSING_YWASSESS.SYBW_XZ
  is '输液部位：下肢';
comment on column MED_NURSING_YWASSESS.SYBW_SGX
  is '输液部位：锁骨下';
comment on column MED_NURSING_YWASSESS.SYBW_JN
  is '输液部位：颈内';
comment on column MED_NURSING_YWASSESS.BRDLW_X
  is '病人带来物：X光片';
comment on column MED_NURSING_YWASSESS.BRDLW_YW
  is '病人带来物：已用or未用';
comment on column MED_NURSING_YWASSESS.SYXZP
  is '剩余血制品';
comment on column MED_NURSING_YWASSESS.ZZSQLYZP
  is '正在申请领用制品';
comment on column MED_NURSING_YWASSESS.SSTWPSL
  is '手术台上物品及数量交接';
comment on column MED_NURSING_YWASSESS.GZTSHC
  is '高值或特殊耗材交接';
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_NURSING_YWASSESS
  add constraint MED_NURSING_YWASSESS_PK primary key (PATIENT_ID, VISIT_ID, OPER_ID)
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
grant select, insert, update, delete on MED_NURSING_YWASSESS to ROLE_DOCARE;