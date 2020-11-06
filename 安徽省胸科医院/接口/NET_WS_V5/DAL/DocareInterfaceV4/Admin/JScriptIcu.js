
function GetICUHisUsers()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ICUMGR--同步医院HIS人员信息:";
    var parmIn = new ParmInputData();
          
    WebServices.DocareSysInterface('ICUMGR','HIS','HIS002',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
    
}

function GetICUDeptDict()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ICUMGR--同步医院HIS的科室代码信息:";
    var parmIn = new ParmInputData();
    
    WebServices.DocareSysInterface('ICUMGR','HIS','HIS001',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);

}

function GetICUDeptPatientInfo()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ICUMGR--同步病区住院病人信息:";
            
    var deptPatienttemp = document.getElementById("deptPatient");
    if(deptPatienttemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "病区代码信息不全!请重新输入,谢谢!";
        return;
    }
    var parmIn = new ParmInputData();
    
    parmIn.performedcode = deptPatienttemp.value;

    if(deptPatienttemp.value.length > 0)
    {
        //parmIn.inpno = inpNoTemp;
        WebServices.DocareSysInterface('ICUMGR','HIS','HIS102',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
    }
}


function GetICUPatientIDInfo()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ICUMGR--ID号同步医院病人信息:";
          
    var patientIdtemp = document.getElementById("patientId");
    if(patientIdtemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "输入病人信息不全!请重新输入,谢谢!";
        return;
    }
    var parmIn = new ParmInputData();
    
    parmIn.patientid = patientIdtemp.value;

    if(patientIdtemp.value.length > 0)
    {
        //parmIn.patientid = patientIdtemp;
        WebServices.DocareSysInterface('ICUMGR','HIS','HIS101',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
    }

}

function GetICUPatientInpNoInfo()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ICUMGR--住院号同步病人信息:";
            
    var inpNoTemp = document.getElementById("inpNo");
    if(inpNoTemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "输入病人信息不全!请重新输入,谢谢!";
        return;
    }
    var parmIn = new ParmInputData();
    
    parmIn.inpno = inpNoTemp.value;

    if(inpNoTemp.value.length > 0)
    {
        //parmIn.inpno = inpNoTemp;
        WebServices.DocareSysInterface('ICUMGR','HIS','HIS104',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
    }
}

function GetICULabMaster()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ICUMGR--ID号同步病人检验信息:";
          
    var patientIdtemp = document.getElementById("patientId");
    if(patientIdtemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "病人ID号信息不全!请重新输入,谢谢!";
        return;
    }
    
    var visitIdtemp = document.getElementById("visitId");
    if(visitIdtemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "病人住院次数信息不全!请重新输入,谢谢!";
        return;
    }
    
    var parmIn = new ParmInputData();
    
    parmIn.patientid = patientIdtemp.value;
    parmIn.visitid = visitIdtemp.value;

    if(patientIdtemp.value.length > 0 && visitIdtemp.value.length > 0 )
    {
        //parmIn.patientid = patientIdtemp;
        WebServices.DocareSysInterface('ICUMGR','LIS','LIS001',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
    }
}


function GetICUPatientOrdersInfo()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ICUMGR--ID号同步在院病人医嘱信息:";
          
    var patientIdtemp = document.getElementById("patientId");
    if(patientIdtemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "病人ID号信息不全!请重新输入,谢谢!";
        return;
    }
    
    var visitIdtemp = document.getElementById("visitId");
    if(visitIdtemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "病人住院次数信息不全!请重新输入,谢谢!";
        return;
    }
    
    var parmIn = new ParmInputData();
    
    parmIn.patientid = patientIdtemp.value;
    parmIn.visitid = visitIdtemp.value;

    if(patientIdtemp.value.length > 0 && visitIdtemp.value.length > 0 )
    {
        //parmIn.patientid = patientIdtemp;
        WebServices.DocareSysInterface('ICUMGR','HIS','HIS103',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
    }
}


function GetICUPatientOrdersInfoOnDate()
{
    //debugger调试JAVASCRIPT
    debugger;
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ICUMGR--ID号同步病人医嘱信息(时间段):";
          
    var patientIdtemp = document.getElementById("patientId");
    if(patientIdtemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "病人ID号信息不全!请重新输入,谢谢!";
        return;
    }
    
    var visitIdtemp = document.getElementById("visitId");
    if(visitIdtemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "病人住院次数信息不全!请重新输入,谢谢!";
        return;
    }
    
    var startdatetimetemp = document.getElementById("startdatetime");
    if(startdatetimetemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "病人提取时间段医嘱时间数据信息不全!请重新输入,谢谢!";
        return;
    }
    
    var parmIn = new ParmInputData();
    
    parmIn.patientid = patientIdtemp.value;
    parmIn.visitid = visitIdtemp.value;
    var tempMouthstartdatetime = parseInt(startdatetimetemp.value.substr(5,2)) - 1;
    parmIn.startdatetime = new Date(startdatetimetemp.value.substr(0,4),tempMouthstartdatetime.toString(),startdatetimetemp.value.substr(8,2));

    if(patientIdtemp.value.length > 0 && visitIdtemp.value.length > 0 && startdatetimetemp.value.length > 0)
    {
        //parmIn.patientid = patientIdtemp;
        WebServices.DocareSysInterface('ICUMGR','HIS','HIS105',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
    }
}

function GetICUPatientEmrDocUpLoad()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ICUMGR--病人打印病历文书(单项):";
            
    var parmIn = new ParmInputData();
    
    var patientIdtemp = document.getElementById("patientId");
    if(patientIdtemp.value.length > 0)
    {
        parmIn.patientid = patientIdtemp.value;
    }
    
    var visitIdtemp = document.getElementById("visitId");
    if(visitIdtemp.value.length > 0)
    {
        parmIn.visitid = visitIdtemp.value;
    }

    var reserved01temp = document.getElementById("inpNo");
    if(reserved01temp.value.length > 0)
    {
        parmIn.reserved01 = reserved01temp.value;//MRCLASS
    }
    
    var reserved02temp = document.getElementById("deptPatient");
    if(reserved02temp.value.length > 0)
    {
        parmIn.reserved02 = reserved02temp.value;//MRSUBCLASS
    }

    var reserved03Temp = document.getElementById("reserved");
    if(reserved03Temp.value.length > 0)
    {
        parmIn.reserved03 = reserved03Temp.value;//ARCHIVEKEY
    }

    var reserved04Temp = document.getElementById("reserved02");
    if(reserved04Temp.value.length > 0)
    {
        parmIn.reserved04 = reserved04Temp.value;//EMR名称
    }
    
    
    parmIn.reserved11 = "2";//归档次数
    parmIn.reserved12 = "0";//页码

    WebServices.DocareSysInterface('ICUMGR','HIS','HIS301',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
}


function GetICUPatientAllEmrDocUpLoad()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ICUMGR--病人病历提交(所有):";
            
    var parmIn = new ParmInputData();
    
    var patientIdtemp = document.getElementById("patientId");
    if(patientIdtemp.value.length > 0)
    {
        parmIn.patientid = patientIdtemp.value;
    }
    
    var visitIdtemp = document.getElementById("visitId");
    if(visitIdtemp.value.length > 0)
    {
        parmIn.visitid = visitIdtemp.value;
    }

    var reserved01temp = document.getElementById("inpNo");
    if(reserved01temp.value.length > 0)
    {
        parmIn.reserved01 = reserved01temp.value;
    }
    
    var reserved03Temp = document.getElementById("reserved");
    if(reserved03Temp.value.length > 0)
    {
        parmIn.reserved03 = reserved03Temp.value;
    }
    
    WebServices.DocareSysInterface('ICUMGR','HIS','HIS302',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
}
