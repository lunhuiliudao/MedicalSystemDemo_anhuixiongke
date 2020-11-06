rem=====================================================
rem     正在导入ORACLE脚本...
rem=====================================================

define owner='&1'
define path='&2'

connect &owner

spool &path\安装脚本.log

start &path\脚本3.0_Oracle\Oracle手术取消表加OPER_ID3.0.sql
start &path\脚本3.0_Oracle\Oracle建新表MED_ANESTHESIA_METHOD_TYPE.sql
start &path\脚本3.0_Oracle\Oracle建新表MED_ANESTHESIA_INPUT_DATA.sql
start &path\脚本3.0_Oracle\同义词OldAddMed.sql
start &path\脚本3.0_Oracle\Oracle麻醉大视图For3.0.sql
start &path\脚本3.0_Oracle\Oracle同义词脚本For3.0.sql

exit;

spool off;
