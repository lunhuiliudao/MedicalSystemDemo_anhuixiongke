rem=====================================================
rem     ���ڵ���ORACLE�ű�...
rem=====================================================

define owner='&1'
define path='&2'

connect &owner

spool &path\��װ�ű�.log

start &path\�ű�3.0_Oracle\Oracle����ȡ�����OPER_ID3.0.sql
start &path\�ű�3.0_Oracle\Oracle���±�MED_ANESTHESIA_METHOD_TYPE.sql
start &path\�ű�3.0_Oracle\Oracle���±�MED_ANESTHESIA_INPUT_DATA.sql
start &path\�ű�3.0_Oracle\ͬ���OldAddMed.sql
start &path\�ű�3.0_Oracle\Oracle�������ͼFor3.0.sql
start &path\�ű�3.0_Oracle\Oracleͬ��ʽű�For3.0.sql

exit;

spool off;
