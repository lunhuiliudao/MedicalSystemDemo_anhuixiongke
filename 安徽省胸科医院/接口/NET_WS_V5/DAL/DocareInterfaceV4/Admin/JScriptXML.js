function XMLUpdateDeptDict()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "XML--更新科室信息数据:";
    var systemXMLin = document.getElementById("systemXML");
    var xmlInputin = document.getElementById("xmlInput");
    DocareTrunDataService.UpdateDeptDict(systemXMLin.value,xmlInputin.value,SuccessHandler,TimeOutHandler,ErrorHandler);
    
}

function XMLUpdateUsers()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "XML--更新工作人员信息数据:";
    var systemXMLin = document.getElementById("systemXML");
    var xmlInputin = document.getElementById("xmlInput");
    DocareTrunDataService.UpdateUsers(systemXMLin.value,xmlInputin.value,SuccessHandler,TimeOutHandler,ErrorHandler);
}

function XMLUpdatePatMasterIndex()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "XML--更新病人基本信息数据:";
    var systemXMLin = document.getElementById("systemXML");
    var xmlInputin = document.getElementById("xmlInput");
    DocareTrunDataService.UpdatePatMasterIndex(systemXMLin.value,xmlInputin.value,SuccessHandler,TimeOutHandler,ErrorHandler);
}


function XMLUpdatePatsInHospital()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "XML--更新病人住院信息数据:";
    var systemXMLin = document.getElementById("systemXML");
    var xmlInputin = document.getElementById("xmlInput");
    DocareTrunDataService.UpdatePatsInHospital( systemXMLin.value, xmlInputin.value, SuccessHandler, TimeOutHandler, ErrorHandler);
}


function XMLUpdateOperationSchedule()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "XML--更新手术预约信息数据:";
    var xmlInputin = document.getElementById("xmlInput");
    DocareTrunDataService.UpdateOperationSchedule( xmlInputin.value, SuccessHandler, TimeOutHandler, ErrorHandler);
}


function XMLGetDataPatientEmrArchiveDetial()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "XML--获取电子病历记录信息:";
    var systemXMLin = document.getElementById("systemXML");
    var xmlInputin = document.getElementById("xmlInput");
    DocareTrunDataService.GetDataPatientEmrArchiveDetial(systemXMLin.value, xmlInputin.value, SuccessHandler, TimeOutHandler, ErrorHandler);
}

function XMLGetDataPatientEmrArchiveDetialInfo()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "XML--获取电子病历详细记录:";
    var systemXMLin = document.getElementById("systemXML");
    var xmlInputin = document.getElementById("xmlInput");
    DocareTrunDataService.GetDataPatientEmrArchiveDetialInfo(systemXMLin.value, xmlInputin.value, SuccessHandler, TimeOutHandler, ErrorHandler);
}

function XMLGetAnesthesiaEvent()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "XML--获取病人麻醉药品事件等相关信息:";
    var xmlInputin = document.getElementById("xmlInput");
    DocareTrunDataService.GetAnesthesiaEvent( xmlInputin.value, SuccessHandler, TimeOutHandler, ErrorHandler);
}

