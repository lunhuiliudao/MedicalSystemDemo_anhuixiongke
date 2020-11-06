-- Create table
create table MED_OPERATION_CANCELED_DETAIL
(
  PATIENT_ID   VARCHAR2(40) not null,
  VISIT_ID     NUMBER(4) not null,
  CANCEL_ID    NUMBER(2) not null,
  CANCEL_CLASS VARCHAR2(20) not null,
  CANCEL_TYPE  VARCHAR2(40) not null
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
comment on table MED_OPERATION_CANCELED_DETAIL
  is '手术取消明细表';
-- Add comments to the columns 
comment on column MED_OPERATION_CANCELED_DETAIL.PATIENT_ID
  is '病人ID;非空，唯一确定手术病人';
comment on column MED_OPERATION_CANCELED_DETAIL.VISIT_ID
  is '入院次数;住院病人每次住院加1';
comment on column MED_OPERATION_CANCELED_DETAIL.CANCEL_ID
  is '手术取消标识;手术取消标识(区分一个病人一次住院多次取消记录，从1开始顺序递增)';
comment on column MED_OPERATION_CANCELED_DETAIL.CANCEL_CLASS
  is '取消分类（大类）;患者因素、医院因素、医护因素';
comment on column MED_OPERATION_CANCELED_DETAIL.CANCEL_TYPE
  is '取消分类（小类）;根据大类，从表MED_ANESTHESIA_INPUT_DICT提取可选结果';
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_OPERATION_CANCELED_DETAIL
  add constraint PK_OPERATION_CANCELED_DETAIL primary key (PATIENT_ID, VISIT_ID, CANCEL_ID, CANCEL_CLASS, CANCEL_TYPE)
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
