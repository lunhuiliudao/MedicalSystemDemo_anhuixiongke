-- Create table
create table MED_OPER_ANALGESIC_MEDICINE
(
  patient_id            VARCHAR2(20) not null,
  visit_id              NUMBER(2) not null,
  oper_id               NUMBER(2) not null,
  medicine_name         VARCHAR2(40) not null,
  medicine_dosage       NUMBER(8,4),
  medicine_dosage_units VARCHAR2(8)
)
tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 1
  maxtrans 255;
-- Add comments to the columns 
comment on column MED_OPER_ANALGESIC_MEDICINE.medicine_name
  is '药物名称';
comment on column MED_OPER_ANALGESIC_MEDICINE.medicine_dosage
  is '药物剂量';
comment on column MED_OPER_ANALGESIC_MEDICINE.medicine_dosage_units
  is '药物单位';
-- Create/Recreate primary, unique and foreign key constraints 
alter table MED_OPER_ANALGESIC_MEDICINE
  add constraint PK_ANALGESIC_MEDICINE primary key (PATIENT_ID, VISIT_ID, OPER_ID, MEDICINE_NAME)
  using index 
  tablespace TSP_MEDSURGERY
  pctfree 10
  initrans 2
  maxtrans 255;
