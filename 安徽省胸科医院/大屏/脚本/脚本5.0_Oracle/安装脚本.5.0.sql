rem=====================================================
rem     ���ڵ���ORACLE�ű�...
rem=====================================================

define owner='&1'
define path='&2'

connect &owner

spool &path\��װ�ű�.log
select '��ʼִ��DoCareΧ���ڹ������ƽ̨�ű�' as test from dual;
start &path\�ű�5.0_Oracle\Oracle����ȡ�����OPER_ID5.0.sql
start &path\�ű�5.0_Oracle\Oracle���±�MED_ANESTHESIA_INPUT_DATA.sql
start &path\�ű�5.0_Oracle\Oracle���±�MED_ANESTHESIA_METHOD_TYPE.sql
start &path\�ű�5.0_Oracle\Oracle�������ͼ5.0.sql
start &path\�ű�5.0_Oracle\Oracleͬ��ʽű�5.0.sql
start &path\�ű�5.0_Oracle\Ȩ�޽ű�.sql
select 'DoCareΧ���ڹ������ƽ̨�ű�ִ�����' as RUN from dual;

select '��ʼִ�д�������ű�' as RUN from dual;
start &path\�ű�5.0_Oracle\�����ű�5.0\MED_ANES_ALARM_MESSAGE(����Ԥ����).sql
start &path\�ű�5.0_Oracle\�����ű�5.0\MED_SCREEN_FIELDS(������ʾ�ֶα�).sql
start &path\�ű�5.0_Oracle\�����ű�5.0\MED_SCREEN_MSG(�������������).sql
start &path\�ű�5.0_Oracle\�����ű�5.0\MED_SCREEN_STATIC_MSG(������̬������Ϣ��).sql
start &path\�ű�5.0_Oracle\�����ű�5.0\MED_SMART_SCREEN_CONFIG(�������ñ�).sql
start &path\�ű�5.0_Oracle\�����ű�5.0\MED_SMART_SCREEN_DICT(�����ֵ��).sql
start &path\�ű�5.0_Oracle\�����ű�5.0\����ͼӳ��(5.0).sql
start &path\�ű�5.0_Oracle\�����ű�5.0\ҽ��Эͬ������ͼVIEW_OPERATION_LIST(5.0).sql
start &path\�ű�5.0_Oracle\�����ű�5.0\ҽ��վ������ͼV_MEDICAL_OPER_INFO(5.0).sql
start &path\�ű�5.0_Oracle\�����ű�5.0\����վ��ǰ����������ͼV_OPER_PROGRESS_INFO(5.0).sql
start &path\�ű�5.0_Oracle\�����ű�5.0\����վ������������ͼV_OPER_ROOM_INFOS(5.0).sql
select '��������ű�ִ�����' as RUN from dual;

exit;

spool off;
