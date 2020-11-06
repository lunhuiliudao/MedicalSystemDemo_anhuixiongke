-- Alter table 
alter table MED_EVENT_DICT
  storage
  (
    next 1
  )
;
-- Add/modify columns 
alter table MED_EVENT_DICT add antibiotic varchar2(20);
-- Add comments to the columns 
comment on column MED_EVENT_DICT.antibiotic
  is '¿¹ÉúËØµÈ¼¶';