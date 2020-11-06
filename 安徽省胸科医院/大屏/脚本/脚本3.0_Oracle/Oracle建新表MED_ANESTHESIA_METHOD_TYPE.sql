-- Create table
create table SURGERY.MED_ANESTHESIA_METHOD_TYPE
(
  anesthesia_method        VARCHAR2(60) not null,
  intravertebral_anes_type NUMBER(2),
  intubate_anes_type       NUMBER(2),
  non_intubate_anes_type   NUMBER(2),
  combine_anes_type        NUMBER(2),
  other_anes_type          NUMBER(2),
  all_anesthesia           NUMBER(2),
  extra_circulation        NUMBER(2),
  spinal_anesthesia        NUMBER(2)
)
tablespace TSP_SURGERY
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 16K
    minextents 1
    maxextents unlimited
  );
-- Add comments to the columns 
comment on column SURGERY.MED_ANESTHESIA_METHOD_TYPE.anesthesia_method
  is '麻醉方法';
comment on column SURGERY.MED_ANESTHESIA_METHOD_TYPE.intravertebral_anes_type
  is '椎管内麻醉大类';
comment on column SURGERY.MED_ANESTHESIA_METHOD_TYPE.intubate_anes_type
  is '插管全麻大类';
comment on column SURGERY.MED_ANESTHESIA_METHOD_TYPE.non_intubate_anes_type
  is '非插管全麻大类';
comment on column SURGERY.MED_ANESTHESIA_METHOD_TYPE.combine_anes_type
  is '复合麻醉大类';
comment on column SURGERY.MED_ANESTHESIA_METHOD_TYPE.other_anes_type
  is '其他麻醉方式大类';
comment on column SURGERY.MED_ANESTHESIA_METHOD_TYPE.all_anesthesia
  is '全身麻醉小类';
comment on column SURGERY.MED_ANESTHESIA_METHOD_TYPE.extra_circulation
  is '体外循环小类';
comment on column SURGERY.MED_ANESTHESIA_METHOD_TYPE.spinal_anesthesia
  is '脊髓麻醉小类';
-- Create/Recreate primary, unique and foreign key constraints 
alter table SURGERY.MED_ANESTHESIA_METHOD_TYPE
  add constraint PK_MED_ANESTHESIA_METHOD_TYPE primary key (ANESTHESIA_METHOD)
  using index 
  tablespace TSP_SURGERY
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 2M
    minextents 1
    maxextents unlimited
  );
-- Grant/Revoke object privileges 
grant select, insert, update, delete on SURGERY.MED_ANESTHESIA_METHOD_TYPE to ROLE_DOCARE;
-- Grant/Revoke synonym 
CREATE OR REPLACE PUBLIC SYNONYM MED_ANESTHESIA_METHOD_TYPE FOR SURGERY.MED_ANESTHESIA_METHOD_TYPE;