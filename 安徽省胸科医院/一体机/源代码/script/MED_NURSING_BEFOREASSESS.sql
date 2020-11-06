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
  is '�����¼��������������ǰ���Һ˶�����';
-- Add comments to the columns 
comment on column MED_NURSING_BEFOREASSESS.SSJQR
  is '������ȷ��';
comment on column MED_NURSING_BEFOREASSESS.TZD
  is '֪ͨ��';
comment on column MED_NURSING_BEFOREASSESS.BL
  is '����';
comment on column MED_NURSING_BEFOREASSESS.WD
  is '���';
comment on column MED_NURSING_BEFOREASSESS.HD_BR
  is '�벡�˺˶�';
comment on column MED_NURSING_BEFOREASSESS.HD_JS
  is '������˶�';
comment on column MED_NURSING_BEFOREASSESS.HD_XM
  is '�˶�����';
comment on column MED_NURSING_BEFOREASSESS.HD_SSMC
  is '�˶���������';
comment on column MED_NURSING_BEFOREASSESS.HD_SSBW
  is '�˶�������λ';
comment on column MED_NURSING_BEFOREASSESS.GMS
  is '����ʷ';
comment on column MED_NURSING_BEFOREASSESS.JWSSS
  is '��������ʷ';
comment on column MED_NURSING_BEFOREASSESS.MXBS
  is '���Բ�ʷ';
comment on column MED_NURSING_BEFOREASSESS.ZRW_YY
  is 'ֲ�������';
comment on column MED_NURSING_BEFOREASSESS.ZRW_XZQBQ
  is 'ֲ�����������';
comment on column MED_NURSING_BEFOREASSESS.ZRW_RGBM
  is 'ֲ����˹���Ĥ';
comment on column MED_NURSING_BEFOREASSESS.ZRW_JZ
  is 'ֲ�����֫';
comment on column MED_NURSING_BEFOREASSESS.ZRW_GB
  is 'ֲ����ְ�';
comment on column MED_NURSING_BEFOREASSESS.ZRW_ZTQ
  is 'ֲ���������';
comment on column MED_NURSING_BEFOREASSESS.ZRW_OTHER
  is 'ֲ�������';
comment on column MED_NURSING_BEFOREASSESS.YSZT
  is '��ʶ״̬';
comment on column MED_NURSING_BEFOREASSESS.YSZT_OTHER
  is '��ʶ״̬����������';
comment on column MED_NURSING_BEFOREASSESS.XLZT
  is '����״̬��ƽ�����ȶ������š����ǡ��־塢���ˡ�ѹ��';
comment on column MED_NURSING_BEFOREASSESS.PFNM_STATUS
  is 'Ƥ���Ĥ:����or����';
comment on column MED_NURSING_BEFOREASSESS.PFNM_BW
  is 'Ƥ���Ĥ����λ';
comment on column MED_NURSING_BEFOREASSESS.PFNM_XZ
  is 'Ƥ���Ĥ������';
comment on column MED_NURSING_BEFOREASSESS.SZHD_STATUS
  is '��֫�������or����';
comment on column MED_NURSING_BEFOREASSESS.SZHD_BW
  is '��֫�����λ';
comment on column MED_NURSING_BEFOREASSESS.SZHD_XZ
  is '��֫�������';
comment on column MED_NURSING_BEFOREASSESS.SZHD_OTHER
  is '��֫������ʣ�����';
comment on column MED_NURSING_BEFOREASSESS.ZTGJ_STATUS
  is '֫��о�������or�쳣';
comment on column MED_NURSING_BEFOREASSESS.ZTGJ_BW
  is '֫��о�����λ';
comment on column MED_NURSING_BEFOREASSESS.ZTGJ_XZ
  is '֫��о�������';
comment on column MED_NURSING_BEFOREASSESS.ZTGJ_OTHER
  is '֫��о������ʣ�����';
comment on column MED_NURSING_BEFOREASSESS.GD_STATUS
  is '�ܵ�����or��';
comment on column MED_NURSING_BEFOREASSESS.GD_WG
  is '�ܵ���θ��';
comment on column MED_NURSING_BEFOREASSESS.GD_NG
  is '�ܵ������';
comment on column MED_NURSING_BEFOREASSESS.GD_XYG
  is '�ܵ���������';
comment on column MED_NURSING_BEFOREASSESS.GD_FQYLG
  is '�ܵ�����ǻ������';
comment on column MED_NURSING_BEFOREASSESS.GD_SYG
  is '�ܵ�����Һ��';
comment on column MED_NURSING_BEFOREASSESS.GD_BW
  is '�ܵ�����λ';
comment on column MED_NURSING_BEFOREASSESS.GD_OTHER
  is '�ܵ�������';
comment on column MED_NURSING_BEFOREASSESS.GD__STATUS_DES
  is '�ܵ�״̬��ͨ�����������ɶ�';
comment on column MED_NURSING_BEFOREASSESS.BFDLW_SP
  is '�����������Ƭ';
comment on column MED_NURSING_BEFOREASSESS.BFDLW_SP_COUNT
  is '�����������Ƭ����';
comment on column MED_NURSING_BEFOREASSESS.BFDLW_YP
  is '���������ҩƷ';
comment on column MED_NURSING_BEFOREASSESS.BFDLW_YP_NAME
  is '���������ҩƷ����';
comment on column MED_NURSING_BEFOREASSESS.BFDLW_OTHER
  is '�������������';
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