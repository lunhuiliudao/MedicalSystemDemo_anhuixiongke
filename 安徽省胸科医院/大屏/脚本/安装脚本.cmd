cls
@ECHO OFF
CLS
color 0a
Title DoCareΧ���ڹ������ƽ̨���ݿ�ű���װ
echo.
echo  ============================================
echo     DoCareΧ���ڹ������ƽ̨���ݿ�ű���װ
echo  ============================================
echo       1����װ��Oracle5.0���ݿ�
echo       2����װ��Oracle4.0���ݿ�
echo       3����װ��SqlServer5.0���ݿ�
echo       4����װ��SqlServer4.0���ݿ�
echo       5����װ��Oracle3.0���ݿ�
echo       6��ж�������ű�
echo       7���˳���װ
:cl
echo.
set /p choice=         ��ѡ��Ҫ���еĲ�����Ȼ�󰴻س�: 
IF NOT "%choice%"=="" SET choice=%choice:~0,1%
if /i "%choice%"=="1" goto s1
if /i "%choice%"=="2" goto s2
if /i "%choice%"=="3" goto s3
if /i "%choice%"=="4" goto s4
if /i "%choice%"=="5" goto s5
if /i "%choice%"=="6" goto s6
if /i "%choice%"=="7" goto EX

echo.
echo         ѡ����Ч������������
echo.
goto cl

:s1
echo.
set /p databasename=         ������ORACLE���ݿ���Ϣ(�˺�/����@������)[Ĭ��system/docare@docare]: 
IF "%databasename%"=="" SET databasename=system/docare@docare
echo ȷ��Oracle���ݿ���Ϣ%databasename%
pause
sqlplus %databasename% @%cd%\�ű�5.0_Oracle\��װ�ű�.5.0.sql %databasename% %cd%
goto end

:s2
echo.
set /p databasename=         ������ORACLE���ݿ���Ϣ(�˺�/����@������)[Ĭ��system/docare@docare]: 
IF "%databasename%"=="" SET databasename=system/docare@docare
echo ȷ��Oracle���ݿ���Ϣ%databasename%
pause
sqlplus %databasename% @%cd%\�ű�4.0_Oracle\��װ�ű�.4.0.sql %databasename% %cd%
goto end

:s3
echo.
set /p serverip=         ������SQL SERVER���ݿ�ķ�������ַ[Ĭ�ϱ���.]: 
IF "%serverip%"=="" SET serverip=.

set /p serveruser=         ������SQL SERVER���ݿ���˺�[Ĭ��sa]: 
IF "%serveruser%"=="" SET serveruser=sa

set /p serverpwd=         ������SQL SERVER���ݿ������[Ĭ��docare]: 
IF "%serverpwd%"=="" SET serverpwd=docare

set /p servername=         ������SQL SERVER���ݿ��ʵ������[Ĭ��docare]: 
IF "%servername%"=="" SET servername=docare

echo ȷ��SqlServer���ݿ���Ϣip: %serverip% �û�����%serveruser% ���룺 %serverpwd% ʵ������%servername%
pause
echo.
echo         ִ��׷���ֶ�
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\�ű�5.0_SqlServer\SqlServer����ȡ�����OPER_ID5.0.sql"
echo.
echo         ִ���½���
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\�ű�5.0_SqlServer\SqlServer���±�MED_ANESTHESIA_INPUT_DATA.sql"
echo.
echo         ִ���½���
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\�ű�5.0_SqlServer\SqlServer���±�MED_ANESTHESIA_METHOD_TYPE.sql"
echo.
echo         ִ���½���ͼ 
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\�ű�5.0_SqlServer\SqlServer�������ͼ5.0.sql"
echo.
echo         ִ�й���Ȩ����Ȩ 
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\�ű�5.0_SqlServer\Ȩ�޽ű�.sql"
echo.
echo         ִ���ַ���ת��ʱ���� 
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\�ű�5.0_SqlServer\�����ű�5.0\�ַ���ת��ʱ����.sql"
echo.
echo         ִ������Ԥ���� 
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\�ű�5.0_SqlServer\�����ű�5.0\MED_ANES_ALARM_MESSAGE(����Ԥ����).sql"
echo.
echo         ִ�д�����ʾ�ֶα�
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\�ű�5.0_SqlServer\�����ű�5.0\MED_SCREEN_FIELDS(������ʾ�ֶα�).sql"
echo.
echo         ִ�д������������
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\�ű�5.0_SqlServer\�����ű�5.0\MED_SCREEN_MSG(�������������).sql"
echo.
echo         ִ�д�����̬������Ϣ��
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\�ű�5.0_SqlServer\�����ű�5.0\MED_SCREEN_STATIC_MSG(������̬������Ϣ��).sql"
echo.
echo         ִ�д������ñ�
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\�ű�5.0_SqlServer\�����ű�5.0\MED_SMART_SCREEN_CONFIG(�������ñ�).sql"
echo.
echo         ִ�д����ֵ��
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\�ű�5.0_SqlServer\�����ű�5.0\MED_SMART_SCREEN_DICT(�����ֵ��).sql"
echo.
echo         ִ�б���ͼӳ��
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\�ű�5.0_SqlServer\�����ű�5.0\����ͼӳ��(5.0).sql"
echo.
echo         ִ��ҽ��Эͬ������ͼ
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\�ű�5.0_SqlServer\�����ű�5.0\ҽ��Эͬ������ͼVIEW_OPERATION_LIST(5.0).sql"
echo.
echo         ִ��ҽ��վ������ͼ
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\�ű�5.0_SqlServer\�����ű�5.0\ҽ��վ������ͼV_MEDICAL_OPER_INFO(5.0).sql"
echo.
echo         ִ������վ��ǰ����������ͼ
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\�ű�5.0_SqlServer\�����ű�5.0\����վ��ǰ����������ͼV_OPER_PROGRESS_INFO(5.0).sql"
echo.
echo         ִ������վ������������ͼ
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\�ű�5.0_SqlServer\�����ű�5.0\����վ������������ͼV_OPER_ROOM_INFOS(5.0).sql"
goto end

:s4
echo.
set /p serverip=         ������SQL SERVER���ݿ�ķ�������ַ[Ĭ�ϱ���.]: 
IF "%serverip%"=="" SET serverip=.

set /p serveruser=         ������SQL SERVER���ݿ���˺�[Ĭ��sa]: 
IF "%serveruser%"=="" SET serveruser=sa

set /p serverpwd=         ������SQL SERVER���ݿ������[Ĭ��docare]: 
IF "%serverpwd%"=="" SET serverpwd=docare

set /p servername=         ������SQL SERVER���ݿ��ʵ������[Ĭ��docare]: 
IF "%servername%"=="" SET servername=docare

echo ȷ��SqlServer���ݿ���Ϣip: %serverip% �û�����%serveruser% ���룺 %serverpwd% ʵ������%servername%
pause
echo.
echo         ִ��׷���ֶ�
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\�ű�4.0_SqlServer\SqlServer����ȡ�����OPER_ID4.0.sql"
echo.
echo         ִ���½���
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\�ű�4.0_SqlServer\SqlServer���±�MED_ANESTHESIA_METHOD_TYPE.sql"
echo.
echo         ִ���½���
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\�ű�4.0_SqlServer\SqlServer���±�MED_ANESTHESIA_INPUT_DATA.sql"
echo.
echo         ִ���½���ͼ 
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\�ű�4.0_SqlServer\SqlServer�������ͼFor4.0.sql"
echo.
echo         ִ�й���Ȩ����Ȩ 
echo.
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\�ű�4.0_SqlServer\Ȩ�޽ű�.sql"
goto end


:s5
echo.
set /p databasename=         ������ORACLE���ݿ���Ϣ(�˺�/����@������)[Ĭ��system/docare@docare]: 
IF "%databasename%"=="" SET databasename=system/docare@docare
echo ȷ��Oracle���ݿ���Ϣ%databasename%
pause
sqlplus %databasename% @%cd%\�ű�3.0_Oracle\��װ�ű�.3.0.sql %databasename% %cd%
goto end


:s6
CLS
echo.
echo  ============================================
echo   DoCareΧ���ڹ������ƽ̨���ݿ������ű�ж��
echo  ============================================
echo      1��ж��Oracle4.0��5.0���ݿ������ű�
echo      2��ж��Oracle3.0���ݿ������ű�
echo      3��ж��SqlServer4.0��5.0���ݿ������ű�
echo.
:subl
set /p choice=         ��ѡ��Ҫ���еĲ�����Ȼ�󰴻س�: 
IF NOT "%choice%"=="" SET choice=%choice:~0,1%
if /i "%choice%"=="1" goto sub_1
if /i "%choice%"=="2" goto sub_2
if /i "%choice%"=="3" goto sub_3

echo.
echo         ѡ����Ч������������
echo.
goto :subl

:sub_1
set /p databasename=         ������ORACLE���ݿ���Ϣ(�˺�/����@������)[Ĭ��system/docare@docare]: 
IF "%databasename%"=="" SET databasename=system/docare@docare

echo ȷ��Oracle���ݿ���Ϣ%databasename%
pause
sqlplus %databasename% @%cd%\ж�ؽű�\ж�ؽű�Oracle4Or5.sql %databasename% %cd%
goto end

:sub_2
set /p databasename=         ������ORACLE���ݿ���Ϣ(�˺�/����@������)[Ĭ��system/docare@docare]: 
IF "%databasename%"=="" SET databasename=system/docare@docare

echo ȷ��Oracle���ݿ���Ϣ%databasename%
echo. & pause
sqlplus %databasename% @%cd%\ж�ؽű�\ж�ؽű�Oracle3.sql %databasename% %cd%
goto end

:sub_3
set /p serverip=         ������SQL SERVER���ݿ�ķ�������ַ[Ĭ�ϱ���.]: 
IF "%serverip%"=="" SET serverip=.

set /p serveruser=         ������SQL SERVER���ݿ���˺�[Ĭ��sa]: 
IF "%serveruser%"=="" SET serveruser=sa

set /p serverpwd=         ������SQL SERVER���ݿ������[Ĭ��docare]: 
IF "%serverpwd%"=="" SET serverpwd=docare

set /p servername=         ������SQL SERVER���ݿ��ʵ������[Ĭ��docare]: 
IF "%servername%"=="" SET servername=docare

echo ȷ��SqlServer���ݿ���Ϣip: %serverip% �û�����%serveruser% ���룺 %serverpwd% ʵ������%servername%
pause
osql -S%serverip%  -U%serveruser% -P%serverpwd% -d%servername%  -i "%cd%\ж�ؽű�\SqlServer4Or5.sql"
goto end



:end
echo.
echo         ִ�нű�����.
echo.
echo. & pause
goto EX


:EX
exit
