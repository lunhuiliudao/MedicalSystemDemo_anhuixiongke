-- Create table
create table MED_NURSING_TOUR
(
  PATIENT_ID VARCHAR2(40) not null,
  VISIT_ID   NUMBER(4) not null,
  OPER_ID    NUMBER(4) not null,
  ITEM_NO    NUMBER(4) not null,
  TIME_POINT DATE,
  JMSY       VARCHAR2(20),
  PFYS       VARCHAR2(20),
  ZTWZ       VARCHAR2(20),
  FJB        VARCHAR2(20),
  YQSB       VARCHAR2(20),
  NURSE      VARCHAR2(20),
  RESERVED01 VARCHAR2(20),
  RESERVED02 VARCHAR2(20),
  RESERVED03 VARCHAR2(20),
  RESERVED04 VARCHAR2(20),
  RESERVED05 VARCHAR2(20)
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
comment on table MED_NURSING_TOUR
  is '�����¼�������й۲�Ѳ����Ŀ';
-- Add comments to the columns 
comment on column MED_NURSING_TOUR.ITEM_NO
  is '���';
comment on column MED_NURSING_TOUR.TIME_POINT
  is 'ʱ���';
comment on column MED_NURSING_TOUR.JMSY
  is '������Һ';
comment on column MED_NURSING_TOUR.PFYS
  is 'Ƥ����ɫ';
comment on column MED_NURSING_TOUR.ZTWZ
  is '֫��λ��';
comment on column MED_NURSING_TOUR.FJB
  is '������';
comment on column MED_NURSING_TOUR.YQSB
  is '�����豸';
comment on column MED_NURSING_TOUR.NURSE
  is '��ʿǩ��';
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_NURSING_TOUR
  add constraint MED_NURSING_TOUR_PK primary key (PATIENT_ID, VISIT_ID, OPER_ID, ITEM_NO)
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
grant select, insert, update, delete on MED_NURSING_TOUR to ROLE_DOCARE;
