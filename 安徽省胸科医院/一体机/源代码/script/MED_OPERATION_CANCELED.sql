-- Create table
create table MED_OPERATION_CANCELED
(
  PATIENT_ID       VARCHAR2(40) not null,
  VISIT_ID         NUMBER(4) not null,
  CANCEL_ID        NUMBER(2) not null,
  SCHEDULE_ID      NUMBER(2),
  OPER_ID          NUMBER(2),
  OPER_STATUS_CODE NUMBER(3) not null,
  CANCEL_REASON    VARCHAR2(500),
  CANCEL_DATE      DATE not null,
  CANCEL_BY        VARCHAR2(20),
  ENTERED_BY       VARCHAR2(20)
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
comment on table MED_OPERATION_CANCELED
  is '手术取消表';
-- Add comments to the columns 
comment on column MED_OPERATION_CANCELED.PATIENT_ID
  is '病人ID;非空，唯一确定手术病人';
comment on column MED_OPERATION_CANCELED.VISIT_ID
  is '入院次数;住院病人每次住院加1';
comment on column MED_OPERATION_CANCELED.CANCEL_ID
  is '手术取消标识;手术取消标识(区分一个病人一次住院多次取消记录，从1开始顺序递增)';
comment on column MED_OPERATION_CANCELED.SCHEDULE_ID
  is '手术安排标识;与计划表中的SCHEDULE_ID对应';
comment on column MED_OPERATION_CANCELED.OPER_ID
  is '手术安排标识;与手术主表的OPER_ID对应';
comment on column MED_OPERATION_CANCELED.OPER_STATUS_CODE
  is '手术状态;对应手术状态代码表记录取消时的手术状态';
comment on column MED_OPERATION_CANCELED.CANCEL_REASON
  is '取消原因';
comment on column MED_OPERATION_CANCELED.CANCEL_DATE
  is '取消日期';
comment on column MED_OPERATION_CANCELED.CANCEL_BY
  is '取消人';
comment on column MED_OPERATION_CANCELED.ENTERED_BY
  is '操作人员';
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_OPERATION_CANCELED
  add constraint PK_OPERATION_CANCELED primary key (PATIENT_ID, VISIT_ID, CANCEL_ID)
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
