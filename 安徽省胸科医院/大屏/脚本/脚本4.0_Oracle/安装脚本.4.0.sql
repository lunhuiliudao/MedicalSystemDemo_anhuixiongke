rem=====================================================
rem     ���ڵ���ORACLE�ű�...
rem=====================================================

define owner='&1'
define path='&2'

connect &owner

spool &path\��װ�ű�.log

start &path\�ű�4.0_Oracle\Oracle����ȡ�����OPER_ID4.0.sql
start &path\�ű�4.0_Oracle\Oracle���±�MED_ANESTHESIA_METHOD_TYPE.sql
start &path\�ű�4.0_Oracle\Oracle���±�MED_ANESTHESIA_INPUT_DATA.sql
start &path\�ű�4.0_Oracle\Oracle��Ȩ4.0.sql
start &path\�ű�4.0_Oracle\Oracle�������ͼFor4.0.sql
start &path\�ű�4.0_Oracle\Oracleͬ��ʽű�For4.0.sql
start &path\�ű�4.0_Oracle\Ȩ�޽ű�.sql


exit;

spool off;
