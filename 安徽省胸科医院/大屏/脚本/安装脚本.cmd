cls
@ECHO OFF
CLS
color 0a
Title DoCare围术期管理决策平台数据库脚本安装
echo.
echo  ============================================
echo     DoCare围术期管理决策平台数据库脚本安装
echo  ============================================
echo       1、安装到Oracle5.0数据库
echo       2、安装到Oracle4.0数据库
echo       3、安装到SqlServer5.0数据库
echo       4、安装到SqlServer4.0数据库
echo       5、安装到Oracle3.0数据库
echo       6、卸载增量脚本
echo       7、退出安装
:cl
echo.
set /p choice=         请选择要进行的操作，然后按回车: 
IF NOT "%choice%"=="" SET choice=%choice:~0,1%
if /i "%choice%"=="1" goto s1
if /i "%choice%"=="2" goto s2
if /i "%choice%"=="3" goto s3
if /i "%choice%"=="4" goto s4
if /i "%choice%"=="5" goto s5
if /i "%choice%"=="6" goto s6
if /i "%choice%"=="7" goto EX

echo.
echo         选择无效，请重新输入
echo.
goto cl

:s1
echo.
set /p databasename=         请输入ORACLE数据库信息(账号/密码@服务名)[默认system/docare@docare]: 
IF "%databasename%"=="" SET databasename=system/docare@docare
echo 确认Oracle数据库信息%databasename%
pause
sqlplus %databasename% @%cd%\脚本5.0_Oracle\安装脚本.5.0.sql %databasename% %cd%
goto end

:s2
echo.
set /p databasename=         请输入ORACLE数据库信息(账号/密码@服务名)[默认system/docare@docare]: 
IF "%databasename%"=="" SET databasename=system/docare@docare
echo 确认Oracle数据库信息%databasename%
pause
sqlplus %databasename% @%cd%\脚本4.0_Oracle\安装脚本.4.0.sql %databasename% %cd%
goto end

:s3
echo.
set /p serverip=         请输入SQL SERVER数据库的服务器地址[默认本地.]: 
IF "%serverip%"=="" SET serverip=.

set /p serveruser=         请输入SQL SERVER数据库的账号[默认sa]: 
IF "%serveruser%"=="" SET serveruser=sa

set /p serverpwd=         请输入SQL SERVER数据库的密码[默认docare]: 
IF "%serverpwd%"=="" SET serverpwd=docare

set /p servername=         请输入SQL SERVER数据库的实例名称[默认docare]: 
IF "%servername%"=="" SET servername=docare

echo 确认SqlServer数据库信息ip: %serverip% 用户名：%serveruser% 密码： %serverpwd% 实例名：%servername%
pause
echo.
echo         执行追加字段
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\脚本5.0_SqlServer\SqlServer手术取消表加OPER_ID5.0.sql"
echo.
echo         执行新建表
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\脚本5.0_SqlServer\SqlServer建新表MED_ANESTHESIA_INPUT_DATA.sql"
echo.
echo         执行新建表
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\脚本5.0_SqlServer\SqlServer建新表MED_ANESTHESIA_METHOD_TYPE.sql"
echo.
echo         执行新建视图 
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\脚本5.0_SqlServer\SqlServer麻醉大视图5.0.sql"
echo.
echo         执行功能权限授权 
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\脚本5.0_SqlServer\权限脚本.sql"
echo.
echo         执行字符串转临时表函数 
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\脚本5.0_SqlServer\大屏脚本5.0\字符串转临时表函数.sql"
echo.
echo         执行体征预警表 
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\脚本5.0_SqlServer\大屏脚本5.0\MED_ANES_ALARM_MESSAGE(体征预警表).sql"
echo.
echo         执行大屏显示字段表
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\脚本5.0_SqlServer\大屏脚本5.0\MED_SCREEN_FIELDS(大屏显示字段表).sql"
echo.
echo         执行大屏紧急公告表
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\脚本5.0_SqlServer\大屏脚本5.0\MED_SCREEN_MSG(大屏紧急公告表).sql"
echo.
echo         执行大屏静态公告信息表
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\脚本5.0_SqlServer\大屏脚本5.0\MED_SCREEN_STATIC_MSG(大屏静态公告信息表).sql"
echo.
echo         执行大屏配置表
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\脚本5.0_SqlServer\大屏脚本5.0\MED_SMART_SCREEN_CONFIG(大屏配置表).sql"
echo.
echo         执行大屏字典表
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\脚本5.0_SqlServer\大屏脚本5.0\MED_SMART_SCREEN_DICT(大屏字典表).sql"
echo.
echo         执行表视图映射
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\脚本5.0_SqlServer\大屏脚本5.0\表视图映射(5.0).sql"
echo.
echo         执行医患协同大屏视图
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\脚本5.0_SqlServer\大屏脚本5.0\医患协同大屏视图VIEW_OPERATION_LIST(5.0).sql"
echo.
echo         执行医务站进程视图
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\脚本5.0_SqlServer\大屏脚本5.0\医务站进程视图V_MEDICAL_OPER_INFO(5.0).sql"
echo.
echo         执行主任站当前手术进程视图
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\脚本5.0_SqlServer\大屏脚本5.0\主任站当前手术进程视图V_OPER_PROGRESS_INFO(5.0).sql"
echo.
echo         执行主任站手术间详情视图
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\脚本5.0_SqlServer\大屏脚本5.0\主任站手术间详情视图V_OPER_ROOM_INFOS(5.0).sql"
goto end

:s4
echo.
set /p serverip=         请输入SQL SERVER数据库的服务器地址[默认本地.]: 
IF "%serverip%"=="" SET serverip=.

set /p serveruser=         请输入SQL SERVER数据库的账号[默认sa]: 
IF "%serveruser%"=="" SET serveruser=sa

set /p serverpwd=         请输入SQL SERVER数据库的密码[默认docare]: 
IF "%serverpwd%"=="" SET serverpwd=docare

set /p servername=         请输入SQL SERVER数据库的实例名称[默认docare]: 
IF "%servername%"=="" SET servername=docare

echo 确认SqlServer数据库信息ip: %serverip% 用户名：%serveruser% 密码： %serverpwd% 实例名：%servername%
pause
echo.
echo         执行追加字段
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\脚本4.0_SqlServer\SqlServer手术取消表加OPER_ID4.0.sql"
echo.
echo         执行新建表
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\脚本4.0_SqlServer\SqlServer建新表MED_ANESTHESIA_METHOD_TYPE.sql"
echo.
echo         执行新建表
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\脚本4.0_SqlServer\SqlServer建新表MED_ANESTHESIA_INPUT_DATA.sql"
echo.
echo         执行新建视图 
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\脚本4.0_SqlServer\SqlServer麻醉大视图For4.0.sql"
echo.
echo         执行功能权限授权 
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\脚本4.0_SqlServer\权限脚本.sql"
goto end


:s5
echo.
set /p databasename=         请输入ORACLE数据库信息(账号/密码@服务名)[默认system/docare@docare]: 
IF "%databasename%"=="" SET databasename=system/docare@docare
echo 确认Oracle数据库信息%databasename%
pause
sqlplus %databasename% @%cd%\脚本3.0_Oracle\安装脚本.3.0.sql %databasename% %cd%
goto end


:s6
CLS
echo.
echo  ============================================
echo   DoCare围术期管理决策平台数据库增量脚本卸载
echo  ============================================
echo      1、卸载Oracle4.0或5.0数据库增量脚本
echo      2、卸载Oracle3.0数据库增量脚本
echo      3、卸载SqlServer4.0或5.0数据库增量脚本
echo.
:subl
set /p choice=         请选择要进行的操作，然后按回车: 
IF NOT "%choice%"=="" SET choice=%choice:~0,1%
if /i "%choice%"=="1" goto sub_1
if /i "%choice%"=="2" goto sub_2
if /i "%choice%"=="3" goto sub_3

echo.
echo         选择无效，请重新输入
echo.
goto :subl

:sub_1
set /p databasename=         请输入ORACLE数据库信息(账号/密码@服务名)[默认system/docare@docare]: 
IF "%databasename%"=="" SET databasename=system/docare@docare

echo 确认Oracle数据库信息%databasename%
pause
sqlplus %databasename% @%cd%\卸载脚本\卸载脚本Oracle4Or5.sql %databasename% %cd%
goto end

:sub_2
set /p databasename=         请输入ORACLE数据库信息(账号/密码@服务名)[默认system/docare@docare]: 
IF "%databasename%"=="" SET databasename=system/docare@docare

echo 确认Oracle数据库信息%databasename%
echo. & pause
sqlplus %databasename% @%cd%\卸载脚本\卸载脚本Oracle3.sql %databasename% %cd%
goto end

:sub_3
set /p serverip=         请输入SQL SERVER数据库的服务器地址[默认本地.]: 
IF "%serverip%"=="" SET serverip=.

set /p serveruser=         请输入SQL SERVER数据库的账号[默认sa]: 
IF "%serveruser%"=="" SET serveruser=sa

set /p serverpwd=         请输入SQL SERVER数据库的密码[默认docare]: 
IF "%serverpwd%"=="" SET serverpwd=docare

set /p servername=         请输入SQL SERVER数据库的实例名称[默认docare]: 
IF "%servername%"=="" SET servername=docare

echo 确认SqlServer数据库信息ip: %serverip% 用户名：%serveruser% 密码： %serverpwd% 实例名：%servername%
pause
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\卸载脚本\SqlServer4Or5.sql"
goto end



:end
echo.
echo         执行脚本结束.
echo.
echo. & pause
goto EX


:EX
exit
