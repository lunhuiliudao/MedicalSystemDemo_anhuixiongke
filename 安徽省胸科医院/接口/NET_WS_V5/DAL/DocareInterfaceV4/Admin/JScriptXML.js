function XMLUpdateDeptDict()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "XML--���¿�����Ϣ����:";
    var systemXMLin = document.getElementById("systemXML");
    var xmlInputin = document.getElementById("xmlInput");
    DocareTrunDataService.UpdateDeptDict(systemXMLin.value,xmlInputin.value,SuccessHandler,TimeOutHandler,ErrorHandler);
    
}

function XMLUpdateUsers()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "XML--���¹�����Ա��Ϣ����:";
    var systemXMLin = document.getElementById("systemXML");
    var xmlInputin = document.getElementById("xmlInput");
    DocareTrunDataService.UpdateUsers(systemXMLin.value,xmlInputin.value,SuccessHandler,TimeOutHandler,ErrorHandler);
}

function XMLUpdatePatMasterIndex()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "XML--���²��˻�����Ϣ����:";
    var systemXMLin = document.getElementById("systemXML");
    var xmlInputin = document.getElementById("xmlInput");
    DocareTrunDataService.UpdatePatMasterIndex(systemXMLin.value,xmlInputin.value,SuccessHandler,TimeOutHandler,ErrorHandler);
}


function XMLUpdatePatsInHospital()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "XML--���²���סԺ��Ϣ����:";
    var systemXMLin = document.getElementById("systemXML");
    var xmlInputin = document.getElementById("xmlInput");
    DocareTrunDataService.UpdatePatsInHospital( systemXMLin.value, xmlInputin.value, SuccessHandler, TimeOutHandler, ErrorHandler);
}


function XMLUpdateOperationSchedule()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "XML--��������ԤԼ��Ϣ����:";
    var xmlInputin = document.getElementById("xmlInput");
    DocareTrunDataService.UpdateOperationSchedule( xmlInputin.value, SuccessHandler, TimeOutHandler, ErrorHandler);
}


function XMLGetDataPatientEmrArchiveDetial()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "XML--��ȡ���Ӳ�����¼��Ϣ:";
    var systemXMLin = document.getElementById("systemXML");
    var xmlInputin = document.getElementById("xmlInput");
    DocareTrunDataService.GetDataPatientEmrArchiveDetial(systemXMLin.value, xmlInputin.value, SuccessHandler, TimeOutHandler, ErrorHandler);
}

function XMLGetDataPatientEmrArchiveDetialInfo()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "XML--��ȡ���Ӳ�����ϸ��¼:";
    var systemXMLin = document.getElementById("systemXML");
    var xmlInputin = document.getElementById("xmlInput");
    DocareTrunDataService.GetDataPatientEmrArchiveDetialInfo(systemXMLin.value, xmlInputin.value, SuccessHandler, TimeOutHandler, ErrorHandler);
}

function XMLGetAnesthesiaEvent()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "XML--��ȡ��������ҩƷ�¼��������Ϣ:";
    var xmlInputin = document.getElementById("xmlInput");
    DocareTrunDataService.GetAnesthesiaEvent( xmlInputin.value, SuccessHandler, TimeOutHandler, ErrorHandler);
}

