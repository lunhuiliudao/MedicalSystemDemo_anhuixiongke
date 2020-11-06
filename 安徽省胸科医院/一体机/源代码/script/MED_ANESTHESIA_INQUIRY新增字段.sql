-- Add/modify columns 
alter table MED_ANESTHESIA_INQUIRY add TEMPETURE VARCHAR2(20);
alter table MED_ANESTHESIA_INQUIRY add PLUS VARCHAR2(20);
alter table MED_ANESTHESIA_INQUIRY add BREATH VARCHAR2(20);
alter table MED_ANESTHESIA_INQUIRY add CERVIX VARCHAR2(20);
alter table MED_ANESTHESIA_INQUIRY add LIMBS_FEEL VARCHAR2(20);
-- Add comments to the columns 
comment on column MED_ANESTHESIA_INQUIRY.TEMPETURE
  is '温度';
comment on column MED_ANESTHESIA_INQUIRY.PLUS
  is '脉搏';
comment on column MED_ANESTHESIA_INQUIRY.BREATH
  is '呼吸';
comment on column MED_ANESTHESIA_INQUIRY.CERVIX
  is '皮肤受损还是完整';
comment on column MED_ANESTHESIA_INQUIRY.LIMBS_FEEL
  is '伤口情况';
