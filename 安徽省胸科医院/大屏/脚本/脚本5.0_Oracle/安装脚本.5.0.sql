rem=====================================================
rem     正在导入ORACLE脚本...
rem=====================================================

define owner='&1'
define path='&2'

connect &owner

spool &path\安装脚本.log
select '开始执行DoCare围术期管理决策平台脚本' as test from dual;
start &path\脚本5.0_Oracle\Oracle手术取消表加OPER_ID5.0.sql
start &path\脚本5.0_Oracle\Oracle建新表MED_ANESTHESIA_INPUT_DATA.sql
start &path\脚本5.0_Oracle\Oracle建新表MED_ANESTHESIA_METHOD_TYPE.sql
start &path\脚本5.0_Oracle\Oracle麻醉大视图5.0.sql
start &path\脚本5.0_Oracle\Oracle同义词脚本5.0.sql
start &path\脚本5.0_Oracle\权限脚本.sql
select 'DoCare围术期管理决策平台脚本执行完毕' as RUN from dual;

select '开始执行大屏公告脚本' as RUN from dual;
start &path\脚本5.0_Oracle\大屏脚本5.0\MED_ANES_ALARM_MESSAGE(体征预警表).sql
start &path\脚本5.0_Oracle\大屏脚本5.0\MED_SCREEN_FIELDS(大屏显示字段表).sql
start &path\脚本5.0_Oracle\大屏脚本5.0\MED_SCREEN_MSG(大屏紧急公告表).sql
start &path\脚本5.0_Oracle\大屏脚本5.0\MED_SCREEN_STATIC_MSG(大屏静态公告信息表).sql
start &path\脚本5.0_Oracle\大屏脚本5.0\MED_SMART_SCREEN_CONFIG(大屏配置表).sql
start &path\脚本5.0_Oracle\大屏脚本5.0\MED_SMART_SCREEN_DICT(大屏字典表).sql
start &path\脚本5.0_Oracle\大屏脚本5.0\表视图映射(5.0).sql
start &path\脚本5.0_Oracle\大屏脚本5.0\医患协同大屏视图VIEW_OPERATION_LIST(5.0).sql
start &path\脚本5.0_Oracle\大屏脚本5.0\医务站进程视图V_MEDICAL_OPER_INFO(5.0).sql
start &path\脚本5.0_Oracle\大屏脚本5.0\主任站当前手术进程视图V_OPER_PROGRESS_INFO(5.0).sql
start &path\脚本5.0_Oracle\大屏脚本5.0\主任站手术间详情视图V_OPER_ROOM_INFOS(5.0).sql
select '大屏公告脚本执行完毕' as RUN from dual;

exit;

spool off;
