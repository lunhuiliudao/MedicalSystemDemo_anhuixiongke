-- Add/modify columns 
alter table MED_ANESTHESIA_INQUIRY add TEMPETURE VARCHAR2(20);
alter table MED_ANESTHESIA_INQUIRY add PLUS VARCHAR2(20);
alter table MED_ANESTHESIA_INQUIRY add BREATH VARCHAR2(20);
alter table MED_ANESTHESIA_INQUIRY add CERVIX VARCHAR2(20);
alter table MED_ANESTHESIA_INQUIRY add LIMBS_FEEL VARCHAR2(20);
-- Add comments to the columns 
comment on column MED_ANESTHESIA_INQUIRY.TEMPETURE
  is '�¶�';
comment on column MED_ANESTHESIA_INQUIRY.PLUS
  is '����';
comment on column MED_ANESTHESIA_INQUIRY.BREATH
  is '����';
comment on column MED_ANESTHESIA_INQUIRY.CERVIX
  is 'Ƥ������������';
comment on column MED_ANESTHESIA_INQUIRY.LIMBS_FEEL
  is '�˿����';
