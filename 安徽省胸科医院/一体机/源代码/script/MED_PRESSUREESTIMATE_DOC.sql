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
  is '����ѹ����������';
-- Add comments to the columns 
comment on column MED_PRESSUREESTIMATE_DOC.AGE_SCORE
  is '�����ֵ';
comment on column MED_PRESSUREESTIMATE_DOC.WEIGHT_SCORE
  is '���ط�ֵ';
comment on column MED_PRESSUREESTIMATE_DOC.SLD_SCORE
  is '������Ƥ����ֵ';
comment on column MED_PRESSUREESTIMATE_DOC.POSITION_SCORE
  is '������λ��ֵ';
comment on column MED_PRESSUREESTIMATE_DOC.SJWL_SCORE
  is 'Ԥ������ʩ�ӵ�������ֵ';
comment on column MED_PRESSUREESTIMATE_DOC.SSSJ_SCORE
  is 'Ԥ������ʱ���ֵ';
comment on column MED_PRESSUREESTIMATE_DOC.SSCX_SCORE
  is 'Ԥ��������Ѫ��ֵ';
comment on column MED_PRESSUREESTIMATE_DOC.OTHER_SCORE
  is '�������ط�ֵ';
comment on column MED_PRESSUREESTIMATE_DOC.AMOUNT_SCORE
  is '�ϼƷ�ֵ';
comment on column MED_PRESSUREESTIMATE_DOC.NURSE
  is '���λ�ʿ';
comment on column MED_PRESSUREESTIMATE_DOC.DOC_DATE
  is '����';
comment on column MED_PRESSUREESTIMATE_DOC.POWER_CD
  is '����ƽ��������';
comment on column MED_PRESSUREESTIMATE_DOC.POWER_TWD
  is '��λ����Ƥ��֮��ƽ˳�������ۡ���Ƥ����ѹ';
comment on column MED_PRESSUREESTIMATE_DOC.POWER_YC
  is '��������ҡ���Ĵ����ͽǶ�';
comment on column MED_PRESSUREESTIMATE_DOC.POWER_YSD
  is 'Լ��������ƽ�����ɽ�����';
comment on column MED_PRESSUREESTIMATE_DOC.POWER_OTHER
  is '����';
comment on column MED_PRESSUREESTIMATE_DOC.POWER_OTHER_DESC
  is '��������';
comment on column MED_PRESSUREESTIMATE_DOC.REDPRE_ZT
  is '��������Ƥ��';
comment on column MED_PRESSUREESTIMATE_DOC.REDPRE_TWD
  is '��λ��';
comment on column MED_PRESSUREESTIMATE_DOC.REDPRE_HJ
  is '���������������£���1h��̧��ѹ��λ������ֲ�ѹ��';
comment on column MED_PRESSUREESTIMATE_DOC.REDPRE_OTHER
  is '����';
comment on column MED_PRESSUREESTIMATE_DOC.REDPRE_OTHER_DESC
  is '��������';
comment on column MED_PRESSUREESTIMATE_DOC.SKIN_BN
  is '��ů��ů��� �Ǳ� Һ����� ��Һ�̵�ǰ��������Ƥ�����µ���';
comment on column MED_PRESSUREESTIMATE_DOC.SKIN_XD
  is '��ֹ����Һ��ʪ����������Ƥ��';
comment on column MED_PRESSUREESTIMATE_DOC.SKIN_PJGZ
  is '���������̽���ƽ��';
comment on column MED_PRESSUREESTIMATE_DOC.SKIN_YJM
  is '�����۽�Ĥ';
comment on column MED_PRESSUREESTIMATE_DOC.SKIN_YKEL
  is '�ۿ������Ȳ���ѹ';
comment on column MED_PRESSUREESTIMATE_DOC.SKIN_OTHER
  is '����';
comment on column MED_PRESSUREESTIMATE_DOC.SKIN_OTHER_DESC
  is '��������';
comment on column MED_PRESSUREESTIMATE_DOC.POS_SAVE
  is '��ȫ�̶�';
comment on column MED_PRESSUREESTIMATE_DOC.POS_YC
  is '����ҡ�������������λ���任��λ��ʱ���';
comment on column MED_PRESSUREESTIMATE_DOC.POS_WW
  is '������λ�ȶ���֫����չ���νӲ�λ���ݴ������֧��';
comment on column MED_PRESSUREESTIMATE_DOC.POS_ZT
  is '֫�幦��λ';
comment on column MED_PRESSUREESTIMATE_DOC.POS_ZTWJS
  is '֫���޽Ӵ�����';
comment on column MED_PRESSUREESTIMATE_DOC.POS_GD
  is '���ܵ��缫������ѹ';
comment on column MED_PRESSUREESTIMATE_DOC.POS_OTHER
  is '����';
comment on column MED_PRESSUREESTIMATE_DOC.POS_OTHER_DESC
  is '��������';
comment on column MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_GOOD
  is '���';
comment on column MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC
  is '��ѹ��';
comment on column MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC_ONE
  is 'һ��';
comment on column MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC_TWO
  is '����';
comment on column MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC_THREE
  is '����';
comment on column MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC_FOUR
  is '����';
comment on column MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC_NO
  is '���ɷ���';
comment on column MED_PRESSUREESTIMATE_DOC.AFTER_SKIN_YC_SBZZ
  is '���֯����';
comment on column MED_PRESSUREESTIMATE_DOC.AFTER_SHIFT
  is '���󽻽�';
comment on column MED_PRESSUREESTIMATE_DOC.AFTER_SHIFT_CAUSE
  is '���󽻽�ԭ��';
comment on column MED_PRESSUREESTIMATE_DOC.AFTER_SHIFT_RESOLVE
  is '���󽻽����Ĵ�ʩ';
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