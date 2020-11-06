rem=====================================================
rem     正在导入卸载...
rem=====================================================

define owner='&1'
define path='&2'
connect &owner
spool &path\安装脚本.log
start &path\卸载脚本\Oracle3.sql
exit;
spool off;
