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
  is '�����¼���������������������л���';
-- Add comments to the columns 
comment on column MED_NURSING_YWASSESS.SSQX
  is '������е׼��';
comment on column MED_NURSING_YWASSESS.YQSB
  is '�����豸';
comment on column MED_NURSING_YWASSESS.TWYP
  is '��λ��Ʒ';
comment on column MED_NURSING_YWASSESS.SSHJ
  is '��������';
comment on column MED_NURSING_YWASSESS.YFDTW_SW
  is 'Ԥ�������£�����';
comment on column MED_NURSING_YWASSESS.YFDTW_BWT
  is 'Ԥ�������£�����̺';
comment on column MED_NURSING_YWASSESS.YFDTW_WYS
  is 'Ԥ�������£�����ˮ';
comment on column MED_NURSING_YWASSESS.YFDTW_JSJG
  is 'Ԥ�������£���ʱ�ӸǷ�������';
comment on column MED_NURSING_YWASSESS.SYZLD
  is 'ʹ�Æ�ଵ�';
comment on column MED_NURSING_YWASSESS.YT
  is 'ʹ������';
comment on column MED_NURSING_YWASSESS.GHTW_STATUS
  is '������λ����or��';
comment on column MED_NURSING_YWASSESS.GHTW_DATE
  is '������λ��ʱ��';
comment on column MED_NURSING_YWASSESS.GHTW_FS
  is '������λ��������ʽ';
comment on column MED_NURSING_YWASSESS.DDSY
  is '�絶ʹ��';
comment on column MED_NURSING_YWASSESS.FJBZTWZ
  is '������ճ��λ��';
comment on column MED_NURSING_YWASSESS.JBPFQK
  is '�ֲ�Ƥ�����';
comment on column MED_NURSING_YWASSESS.QYZXD_STATUS
  is '��ѹֹѪ������or��';
comment on column MED_NURSING_YWASSESS.QYZXD_BZWZ
  is '����λ��';
comment on column MED_NURSING_YWASSESS.QYZXD_YL
  is '��ѹֹѪ����ѹ��';
comment on column MED_NURSING_YWASSESS.QYZXD_DATE
  is '��ѹֹѪ��������ʱ��';
comment on column MED_NURSING_YWASSESS.QYZXD_SBDATE
  is '��ѹֹѪ��������ʱ��';
comment on column MED_NURSING_YWASSESS.QYZXD_JBPF
  is '��ѹֹѪ�����ֲ�Ƥ��';
comment on column MED_NURSING_YWASSESS.SZBD
  is '���б���';
comment on column MED_NURSING_YWASSESS.BLBB
  is '����걾';
comment on column MED_NURSING_YWASSESS.XHHSJB_STATUS
  is 'Ѳ�ػ�ʿ���ࣺ��or��';
comment on column MED_NURSING_YWASSESS.SYBW_SZ
  is '��Һ��λ����֫';
comment on column MED_NURSING_YWASSESS.SYBW_XZ
  is '��Һ��λ����֫';
comment on column MED_NURSING_YWASSESS.SYBW_SGX
  is '��Һ��λ��������';
comment on column MED_NURSING_YWASSESS.SYBW_JN
  is '��Һ��λ������';
comment on column MED_NURSING_YWASSESS.BRDLW_X
  is '���˴����X��Ƭ';
comment on column MED_NURSING_YWASSESS.BRDLW_YW
  is '���˴��������orδ��';
comment on column MED_NURSING_YWASSESS.SYXZP
  is 'ʣ��Ѫ��Ʒ';
comment on column MED_NURSING_YWASSESS.ZZSQLYZP
  is '��������������Ʒ';
comment on column MED_NURSING_YWASSESS.SSTWPSL
  is '����̨����Ʒ����������';
comment on column MED_NURSING_YWASSESS.GZTSHC
  is '��ֵ������ĲĽ���';
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