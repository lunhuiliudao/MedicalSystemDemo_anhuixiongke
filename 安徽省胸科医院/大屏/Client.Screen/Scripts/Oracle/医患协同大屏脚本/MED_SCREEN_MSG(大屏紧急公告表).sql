-- Grant/Revoke object privileges 
grant select, insert, update, delete on MEDCOMM.MED_SCREEN_MSG to ROLE_DOCARE;


-- Grant/Revoke synonym 
CREATE OR REPLACE PUBLIC SYNONYM MED_SCREEN_MSG FOR MEDCOMM.MED_SCREEN_MSG;