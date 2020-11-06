-- Create table
create table MED_PRESSUREESTIMATE_DOC
(
  PATIENT_ID          VARCHAR2(20) not null,
  VISIT_ID            NUMBER(4) not null,
  OPER_ID             NUMBER(2) not null,
  AGE_SCORE           NUMBER(1),
  WEIGHT_SCORE        NUMBER(1),
  SLD_SCORE           NUMBER(1),
  POSITION_SCORE      NUMBER(1),
  SJWL_SCORE          NUMBER(1),
  SSSJ_SCORE          NUMBER(1),
  SSCX_SCORE          NUMBER(1),
  OTHER_SCORE         NUMBER(1),
  AMOUNT_SCORE        NUMBER(2),
  NURSE               VARCHAR2(40),
  DOC_DATE            DATE,
  POWER_CD            VARCHAR2(20),
  POWER_TWD           VARCHAR2(20),
  POWER_YC            VARCHAR2(20),
  POWER_YSD           VARCHAR2(20),
  POWER_OTHER         VARCHAR2(20),
  POWER_OTHER_DESC    VARCHAR2(200),
  REDPRE_ZT           VARCHAR2(20),
  REDPRE_TWD          VARCHAR2(20),
  REDPRE_HJ           VARCHAR2(20),
  REDPRE_OTHER        VARCHAR2(20),
  REDPRE_OTHER_DESC   VARCHAR2(200),
  SKIN_BN             VARCHAR2(20),
  SKIN_XD             VARCHAR2(20),
  SKIN_PJGZ           VARCHAR2(20),
  SKIN_YJM            VARCHAR2(20),
  SKIN_YKEL           VARCHAR2(20),
  SKIN_OTHER          VARCHAR2(20),
  SKIN_OTHER_DESC     VARCHAR2(200),
  POS_SAVE            VARCHAR2(20),
  POS_YC              VARCHAR2(20),
  POS_WW              VARCHAR2(20),
  POS_ZT              VARCHAR2(20),
  POS_ZTWJS           VARCHAR2(20),
  POS_GD              VARCHAR2(20),
  POS_OTHER           VARCHAR2(20),
  POS_OTHER_DESC      VARCHAR2(200),
  AFTER_SKIN_GOOD     VARCHAR2(20),
  AFTER_SKIN_YC       VARCHAR2(20),
  AFTER_SKIN_YC_ONE   VARCHAR2(20),
  AFTER_SKIN_YC_TWO   VARCHAR2(20),
  AFTER_SKIN_YC_THREE VARCHAR2(20),
  AFTER_SKIN_YC_FOUR  VARCHAR2(20),
  AFTER_SKIN_YC_NO    VARCHAR2(20),
  AFTER_SKIN_YC_SBZZ  VARCHAR2(20),
  AFTER_SHIFT         VARCHAR2(200),
  AFTER_SHIFT_CAUSE   VARCHAR2(400),
  AFTER_SHIFT_RESOLVE VARCHAR2(600),
  RESERVED01          VARCHAR2(50),
  RESERVED02          VARCHAR2(50),
  RESERVED03          VARCHAR2(50),
  RESERVED04          VARCHAR2(50),
  RESERVED05          VARCHAR2(50),
  RESERVED06          VARCHAR2(50),
  RESERVED07          VARCHAR2(50),
  RESERVED08          VARCHAR2(50),
  RESERVED09          VARCHAR2(50),
  RESERVED10          VARCHAR2(50)
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
comment on table MED_PRESSUREESTIMATE_DOC
  is '患者压疮评估文书';
-- Add comments to the columns 
comment on column MED_PRESSUREESTIMATE_DOC.AGE_SCORE
  is '年龄分值';
comment on column MED_PRESSUREESTIMATE_DOC.WEIGHT_SCORE
  is '体重分值';
comment on column MED_PRESSUREESTIMATE_DOC.SLD_SCORE
  is '受力点皮肤分值';
comment on column MED_PRESSUREESTIMATE_DOC.POSITION_SCORE
  is '手术体位分值';
comment on column MED_PRESSUREESTIMATE_DOC.SJWL_SCORE
  is '预计术中施加的外力分值';
comment on column MED_PRESSUREESTIMATE_DOC.SSSJ_SCORE
  is '预计手术时间分值';
comment on column MED_PRESSUREESTIMATE_DOC.SSCX_SCORE
  is '预计手术出血分值';
comment on column MED_PRESSUREESTIMATE_DOC.OTHER_SCORE
  is '其他因素分值';
comment on column MED_PRESSUREESTIMATE_DOC.AMOUNT_SCORE
  is '合计分值';
comment on column MED_PRESSUREESTIMATE_DOC.NURSE
  is '责任护士';
comment on column MED_PRESSUREESTIMATE_DOC.DOC_DATE
  is '日期';
comment on column MED_PRESSUREESTIMATE_DOC.POWER_CD
  is '床单平整无褶皱';
comment on column MED_PRESSUREESTIMATE_DOC.POWER_TWD
  is '体位垫与皮肤之间平顺、无皱折、无皮肤挤压';
comment on column MED_PRESSUREESTIMATE_DOC.POWER_YC
  is '控制术中摇床的次数和角度';
comment on column MED_PRESSUREESTIMATE_DOC.POWER_YSD
  is '约束带柔软、平滑，松紧适宜';
comment on column MED_PRESSUREESTIMATE_DOC.POWER_OTHER
  is '其他';
comment on column MED_PRESSUREESTIMATE_DOC.POWER_OTHER_DESC
  is '其他描述';
comment on column MED_PRESSUREESTIMATE_DOC.REDPRE_ZT
  is '吸收帖贴皮肤';
comment on column MED_PRESSUREESTIMATE_DOC.REDPRE_TWD
  is '体位垫';
comment on column MED_PRESSUREESTIMATE_DOC.REDPRE_HJ
  is '在条件允许的情况下，隔1h轻抬受压部位，缓解局部压力';
comment on column MED_PRESSUREESTIMATE_DOC.REDPRE_OTHER
  is '其他';
comment on column MED_PRESSUREESTIMATE_DOC.REDPRE_OTHER_DESC
  is '其他描述';
comment on column MED_PRESSUREESTIMATE_DOC.SKIN_BN
  is '保暖：暖风机 盖被 液体恒温 输液铺单前、手术缝皮后将室温调高';
comment on column MED_PRESSUREESTIMATE_DOC.SKIN_XD
  is '防止消毒液浸湿消毒区以外皮肤';
comment on column MED_PRESSUREESTIMATE_DOC.SKIN_PJGZ
  is '保持手术铺巾干燥、平整';
comment on column MED_PRESSUREESTIMATE_DOC.SKIN_YJM
  is '保护眼角膜';
comment on column MED_PRESSUREESTIMATE_DOC.SKIN_YKEL
  is '眼眶、耳廊不受压';
comment on column MED_PRESSUREESTIMATE_DOC.SKIN_OTHER
  is '其他';
comment on column MED_PRESSUREESTIMATE_DOC.SKIN_OTHER_DESC
  is '其他描述';
comment on column MED_PRESSUREESTIMATE_DOC.POS_SAVE
  is '安全固定';
comment on column MED_PRESSUREESTIMATE_DOC.POS_YC
  is '术中摇床后避免身体移位，变换体位后及时检查';
comment on column MED_PRESSUREESTIMATE_DOC.POS_WW
  is '保持卧位稳定、肢体舒展，衔接部位凹陷处用软垫支撑';
comment on column MED_PRESSUREESTIMATE_DOC.POS_ZT
  is '肢体功能位';
comment on column MED_PRESSUREESTIMATE_DOC.POS_ZTWJS
  is '肢体无接触金属';
comment on column MED_PRESSUREESTIMATE_DOC.POS_GD
  is '各管道电极线无受压';
comment on column MED_PRESSUREESTIMATE_DOC.POS_OTHER
  is '其他';
comment on column MED_PRESSUREESTIMATE_DOC.POS_OTHER_DESC
  is '其他描述';
comment on column MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_GOOD
  is '完好';
comment on column MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC
  is '有压疮';
comment on column MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC_ONE
  is '一期';
comment on column MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC_TWO
  is '二期';
comment on column MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC_THREE
  is '三期';
comment on column MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC_FOUR
  is '四期';
comment on column MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC_NO
  is '不可分期';
comment on column MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC_SBZZ
  is '深部组织损伤';
comment on column MED_PRESSUREESTIMATE_DOC.AFTER_SHIFT
  is '术后交接';
comment on column MED_PRESSUREESTIMATE_DOC.AFTER_SHIFT_CAUSE
  is '术后交接原因';
comment on column MED_PRESSUREESTIMATE_DOC.AFTER_SHIFT_RESOLVE
  is '术后交接整改措施';
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_PRESSUREESTIMATE_DOC
  add constraint MED_PRESSUREESTIMATE_DOC_PK primary key (PATIENT_ID, VISIT_ID, OPER_ID)
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
grant select, insert, update, delete on MED_PRESSUREESTIMATE_DOC to ROLE_DOCARE;