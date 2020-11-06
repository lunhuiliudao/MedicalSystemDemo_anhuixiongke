rem=====================================================
rem     正在导入ORACLE脚本...
rem=====================================================

define owner='&1'
define path='&2'

connect &owner

spool &path\安装脚本.log

start &path\脚本4.0_Oracle\Oracle手术取消表加OPER_ID4.0.sql
start &path\脚本4.0_Oracle\Oracle建新表MED_ANESTHESIA_METHOD_TYPE.sql
start &path\脚本4.0_Oracle\Oracle建新表MED_ANESTHESIA_INPUT_DATA.sql
start &path\脚本4.0_Oracle\Oracle授权4.0.sql
start &path\脚本4.0_Oracle\Oracle麻醉大视图For4.0.sql
start &path\脚本4.0_Oracle\Oracle同义词脚本For4.0.sql
start &path\脚本4.0_Oracle\权限脚本.sql


exit;

spool off;
