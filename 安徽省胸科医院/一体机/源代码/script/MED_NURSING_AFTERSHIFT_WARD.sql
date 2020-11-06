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
  is '�����¼����������ʿ����ICU�����Ӽ�¼';
-- Add comments to the columns 
comment on column MED_NURSING_AFTERSHIFT_WARD.JBLX_NURSE
  is '�븴���һ�ʿor������ʿ';
comment on column MED_NURSING_AFTERSHIFT_WARD.KTJB_SSMC
  is '��ͷ���ࣺ��������';
comment on column MED_NURSING_AFTERSHIFT_WARD.KTJB_SSBW
  is '��ͷ���ࣺ������λ';
comment on column MED_NURSING_AFTERSHIFT_WARD.KTJB_MZFS
  is '��ͷ���ࣺ����ʽ';
comment on column MED_NURSING_AFTERSHIFT_WARD.KTJB_SSTW
  is '��ͷ���ࣺ������λ';
comment on column MED_NURSING_AFTERSHIFT_WARD.KTJB_ZXD
  is '��ͷ���ֹࣺѪ��';
comment on column MED_NURSING_AFTERSHIFT_WARD.KTJB_CXL
  is '��ͷ���ࣺ��Ѫ��';
comment on column MED_NURSING_AFTERSHIFT_WARD.PF_STATUS
  is 'Ƥ��������or�쳣';
comment on column MED_NURSING_AFTERSHIFT_WARD.PF_OTHER
  is 'Ƥ������������';
comment on column MED_NURSING_AFTERSHIFT_WARD.DHBQYW_X
  is '���ز������X��Ƭ';
comment on column MED_NURSING_AFTERSHIFT_WARD.DHBQYW_X_COUNT
  is '���ز������X��Ƭ����';
comment on column MED_NURSING_AFTERSHIFT_WARD.DHBQYW_YW
  is '���ز������ҩ������';
comment on column MED_NURSING_AFTERSHIFT_WARD.DHBQYW_YW_NAME
  is '���ز������ҩ������';
comment on column MED_NURSING_AFTERSHIFT_WARD.DHBQYW_YW_OTHER
  is '���ز������ҩ������';
comment on column MED_NURSING_AFTERSHIFT_WARD.SYBW_SZ
  is '��Һ��λ����֫';
comment on column MED_NURSING_AFTERSHIFT_WARD.SYBW_XZ
  is '��Һ��λ����֫';
comment on column MED_NURSING_AFTERSHIFT_WARD.SYBW_SGX
  is '��Һ��λ��������';
comment on column MED_NURSING_AFTERSHIFT_WARD.SYBW_JN
  is '��Һ��λ������';
comment on column MED_NURSING_AFTERSHIFT_WARD.SYBW_OTHER
  is '��Һ��λ������';
comment on column MED_NURSING_AFTERSHIFT_WARD.DHXZP_H
  is '����Ѫ��Ʒ����ϸ��';
comment on column MED_NURSING_AFTERSHIFT_WARD.DHXZP_X
  is '����Ѫ��Ʒ��Ѫ��';
comment on column MED_NURSING_AFTERSHIFT_WARD.LZNG_STATUS
  is '������ܣ���or��';
comment on column MED_NURSING_AFTERSHIFT_WARD.WX
  is '��������¿��Ƿ�����Ѫ';
comment on column MED_NURSING_AFTERSHIFT_WARD.XH_NURSE
  is 'Ѳ�ػ�ʿ';
comment on column MED_NURSING_AFTERSHIFT_WARD.FS_BQ
  is '�Ǹ��ջ�ʿ���ǲ�����ʿ';
comment on column MED_NURSING_AFTERSHIFT_WARD.FS_BQ_NURSE
  is '���ջ�ʿor������ʿ������';
comment on column MED_NURSING_AFTERSHIFT_WARD.TIME_POINT
  is '����ʱ��';
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