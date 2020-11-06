-- Alter table 
alter table MED_ANESTHESIA_INPUT_DATA
  storage
  (
    next 8
  )
;
-- Add/modify columns 
alter table MED_ANESTHESIA_INPUT_DATA add event_course VARCHAR2(200);
-- Add comments to the columns 
comment on column MED_ANESTHESIA_INPUT_DATA.event_course
  is '事件发生经过';