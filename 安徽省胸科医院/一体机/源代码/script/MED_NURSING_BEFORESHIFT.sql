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
  is '�����¼��-��ǰ����';
-- Add comments to the columns 
comment on column MED_NURSING_BEFORESHIFT.BINGLI
  is '����';
comment on column MED_NURSING_BEFORESHIFT.YP_NAME_COUNT
  is 'ҩƷ���ƺ�����';
comment on column MED_NURSING_BEFORESHIFT.YXXZL
  is 'Ӱ��ѧ����';
comment on column MED_NURSING_BEFORESHIFT.YXXZL_COUNT
  is 'Ӱ��ѧ��������';
comment on column MED_NURSING_BEFORESHIFT.BRHD
  is '���˺˶�';
comment on column MED_NURSING_BEFORESHIFT.SSBWHD
  is '������λ�˶�';
comment on column MED_NURSING_BEFORESHIFT.JSS
  is '��ʳˮ';
comment on column MED_NURSING_BEFORESHIFT.RSQPN
  is '����ǰ����';
comment on column MED_NURSING_BEFORESHIFT.BP
  is '��Ƥ';
comment on column MED_NURSING_BEFORESHIFT.JSTYQZ
  is '����ͬ��ǩ��';
comment on column MED_NURSING_BEFORESHIFT.QCSSYXYJJA
  is 'ȥ�����μ������۾�������';
comment on column MED_NURSING_BEFORESHIFT.SQYY
  is '��ǰ��ҩ����';
comment on column MED_NURSING_BEFORESHIFT.THKC
  is '�¾���������';
comment on column MED_NURSING_BEFORESHIFT.FR
  is '��������';
comment on column MED_NURSING_BEFORESHIFT.KS
  is '��������';
comment on column MED_NURSING_BEFORESHIFT.SDY
  is '�ɶ�������';
comment on column MED_NURSING_BEFORESHIFT.MZXGZS
  is '�������֪ʶ';
comment on column MED_NURSING_BEFORESHIFT.SSXGZS
  is '�������֪ʶ';
comment on column MED_NURSING_BEFORESHIFT.YG_YING_YANG
  is '�ҸΣ���������';
comment on column MED_NURSING_BEFORESHIFT.HIV_YING_YNAG
  is 'HIV����������';
comment on column MED_NURSING_BEFORESHIFT.HIV_OTHER
  is 'HIV������';
comment on column MED_NURSING_BEFORESHIFT.BF_NURSE
  is '������ʿ';
comment on column MED_NURSING_BEFORESHIFT.SSS_NURSE
  is '�����һ�ʿ';
comment on column MED_NURSING_BEFORESHIFT.SHIFT_DATE
  is '����ʱ��';
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
