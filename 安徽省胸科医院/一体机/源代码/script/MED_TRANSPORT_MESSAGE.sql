-- Create table
create table MEDSURGERY.MED_TRANSPORT_MESSAGE
(
  MESSAGE_NO     NUMBER(4) not null,
  SOURCE_ROOM_NO VARCHAR2(20) not null,
  TARGET_ROOM_NO VARCHAR2(20) not null,
  TRANS_DATE     DATE,
  TRANS_ATOR     VARCHAR2(20),
  TRANS_MESSAGE  VARCHAR2(200) not null,
  HAS_READ       NUMBER(2) default 0,
  MESSAGE_CLASS  NUMBER(4) not null
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
-- Add comments to the columns 
comment on column MEDSURGERY.MED_TRANSPORT_MESSAGE.MESSAGE_NO
  is '消息编号';
comment on column MEDSURGERY.MED_TRANSPORT_MESSAGE.SOURCE_ROOM_NO
  is '消息发送的手术间';
comment on column MEDSURGERY.MED_TRANSPORT_MESSAGE.TARGET_ROOM_NO
  is '消息接收手术间';
comment on column MEDSURGERY.MED_TRANSPORT_MESSAGE.TRANS_DATE
  is '消息创建时间';
comment on column MEDSURGERY.MED_TRANSPORT_MESSAGE.TRANS_ATOR
  is '消息发送者';
comment on column MEDSURGERY.MED_TRANSPORT_MESSAGE.TRANS_MESSAGE
  is '消息';
comment on column MEDSURGERY.MED_TRANSPORT_MESSAGE.HAS_READ
  is '是否阅读';
comment on column MEDSURGERY.MED_TRANSPORT_MESSAGE.MESSAGE_CLASS
  is '消息类型';
-- Create/Recreate primary, unique and foreign key constraints 
alter table MEDSURGERY.MED_TRANSPORT_MESSAGE
  add constraint MED_TRANSPORT_MESSAGE_PK primary key (MESSAGE_NO, SOURCE_ROOM_NO, TARGET_ROOM_NO)
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
grant select, insert, update, delete on MEDSURGERY.MED_TRANSPORT_MESSAGE to ROLE_DOCARE;
