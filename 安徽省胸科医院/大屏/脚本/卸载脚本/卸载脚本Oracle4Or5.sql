rem=====================================================
rem     ���ڵ���ж��...
rem=====================================================

define owner='&1'
define path='&2'
connect &owner
spool &path\��װ�ű�.log
start &path\ж�ؽű�\Oracle4Or5.sql
exit;
spool off;
