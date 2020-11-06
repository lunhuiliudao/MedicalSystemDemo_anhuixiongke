alter table med_operation_master
add (local_anesthesia number(2) default 0 null);
comment on column med_operation_master.local_anesthesia is '0-·Ç¾ÖÂé¡¢1-¾ÖÂé'