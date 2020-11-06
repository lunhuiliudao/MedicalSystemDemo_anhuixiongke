
function GetLogOn()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "����ƽ̨�����½:";
    var parmIn = new ParmInputData();
    
    var patientIdtemp = document.getElementById("patientId");
    if(patientIdtemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "��½������Ϣ��ȫ!����������,лл!";
        return;
    }
    
    var visitIdtemp = document.getElementById("visitId");
    if(visitIdtemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "��½������Ϣ��ȫ!����������,лл!";
        return;
    }
    
    var operidtemp = document.getElementById("inpNo");
//    if(operidtemp.value.length < 1)
//    {
//        rizhi.value = rizhi.value + "��������������Ϣ��ȫ!����������,лл!";
//        return;
//    }
        
    parmIn.userno = patientIdtemp.value;
    parmIn.userpassword = visitIdtemp.value;
    parmIn.userpasswordnew = operidtemp.value;      
    WebServices.DocareSysInterface('ANESMGR','HIS','HIS000',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
    
}

function GetHisUsers()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ANESMGR--ͬ��ҽԺHIS��Ա��Ϣ:";
    var parmIn = new ParmInputData();
          
    WebServices.DocareSysInterface('ANESMGR','HIS','HIS002',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
    
}


function yitiji()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ANESMGR--ͬ��ҽԺHIS��Ա��Ϣ:";
    var parmIn = new ParmInputData();
    
    var visitIdtemp = document.getElementById("reserved");

    parmIn.reserved01 = visitIdtemp.value;
    WebServices.DocareSysInterface('ANESMGR','HIS','HIS999',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
}

function GetDeptDict()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ANESMGR--ͬ��ҽԺHIS�Ŀ��Ҵ�����Ϣ:";
    var parmIn = new ParmInputData();
    WebServices.DocareSysInterface('ANESMGR','HIS','HIS001',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
}

function GetOperationDict()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ANESMGR--ͬ��ҽԺ���������ֵ�:";
    var parmIn = new ParmInputData();  
    WebServices.DocareSysInterface('ANESMGR','HIS','HIS013',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
}


function GetDiagnosis()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ANESMGR--ͬ��ҽԺ��������ֵ�:";
    var parmIn = new ParmInputData();
          
    WebServices.DocareSysInterface('ANESMGR','HIS','HIS003',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
    
}
function GetDrugdict()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ANESMGR--ͬ��HISҩƷ�ֵ�:";
    var parmIn = new ParmInputData();
    
    WebServices.DocareSysInterface('ANESMGR','HIS','HIS009',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);

}

function GetMtrldict()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ANESMGR--ͬ��HIS�Ĳ��ֵ�:";
    var parmIn = new ParmInputData();
    
    WebServices.DocareSysInterface('ANESMGR','HIS','HIS011',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);

}

function GetDrugNameDict()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ANESMGR--ͬ��HISҩƷ����:";
    var parmIn = new ParmInputData();
    
    WebServices.DocareSysInterface('ANESMGR','HIS','HIS010',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);

}

function GetMtrlSupplierCatalog()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ANESMGR--ͬ��HIS�ĲĹ�Ӧ��:";
    var parmIn = new ParmInputData();
    
    WebServices.DocareSysInterface('ANESMGR','HIS','HIS012',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);

}

function GetPatientIDInfo()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ANESMGR--ID��ͬ��ҽԺ������Ϣ:";
          
    var patientIdtemp = document.getElementById("patientId");
    if(patientIdtemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "���벡����Ϣ��ȫ!����������,лл!";
        return;
    }
    var parmIn = new ParmInputData();
    
    parmIn.patientid = patientIdtemp.value;

    if(patientIdtemp.value.length > 0)
    {
        //parmIn.patientid = patientIdtemp;
        WebServices.DocareSysInterface('ANESMGR','HIS','HIS101',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
    }

}

function GetPatientInpNoInfo()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ANESMGR--סԺ��ͬ��������Ϣ:";
            
    var inpNoTemp = document.getElementById("inpNo");
    if(inpNoTemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "���벡����Ϣ��ȫ!����������,лл!";
        return;
    }
    var parmIn = new ParmInputData();
    
    parmIn.inpno = inpNoTemp.value;

    if(inpNoTemp.value.length > 0)
    {
        //parmIn.inpno = inpNoTemp;
        WebServices.DocareSysInterface('ANESMGR','HIS','HIS104',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
    }
}

function GetLabMaster()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ANESMGR--ID��ͬ�����˼�����Ϣ:";
          
    var patientIdtemp = document.getElementById("patientId");
    if(patientIdtemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "����ID����Ϣ��ȫ!����������,лл!";
        return;
    }
    
    var visitIdtemp = document.getElementById("visitId");
    if(visitIdtemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "����סԺ������Ϣ��ȫ!����������,лл!";
        return;
    }
    
    var parmIn = new ParmInputData();
    
    parmIn.patientid = patientIdtemp.value;
    parmIn.visitid = visitIdtemp.value;

    if(patientIdtemp.value.length > 0 && visitIdtemp.value.length > 0 )
    {
        //parmIn.patientid = patientIdtemp;
        WebServices.DocareSysInterface('ANESMGR','LIS','LIS001',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
    }
}

function GetPatientNursingDataInfo()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ANESMGR--ID��ͬ�����˻���(����)��Ϣ:";
          
    var patientIdtemp = document.getElementById("patientId");
    if(patientIdtemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "����ID����Ϣ��ȫ!����������,лл!";
        return;
    }
    
    var visitIdtemp = document.getElementById("visitId");
    if(visitIdtemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "����סԺ������Ϣ��ȫ!����������,лл!";
        return;
    }
   
    
    var parmIn = new ParmInputData();
    
    parmIn.patientid = patientIdtemp.value;
    parmIn.visitid = visitIdtemp.value;

    if(patientIdtemp.value.length > 0 && visitIdtemp.value.length > 0 )
    {
        //parmIn.patientid = patientIdtemp;
        //WebServices.DocareSysInterface('ANESMGR','LIS','LIS002',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
        WebServices.DocareSysInterface('ANESMGR','HIS','HIS514',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
    }
}


function GetPatientOrdersInfo()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ANESMGR--ID��ͬ����Ժ����ҽ����Ϣ:";
          
    var patientIdtemp = document.getElementById("patientId");
    if(patientIdtemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "����ID����Ϣ��ȫ!����������,лл!";
        return;
    }
    
    var visitIdtemp = document.getElementById("visitId");
    if(visitIdtemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "����סԺ������Ϣ��ȫ!����������,лл!";
        return;
    }
    
    var parmIn = new ParmInputData();
    
    parmIn.patientid = patientIdtemp.value;
    parmIn.visitid = visitIdtemp.value;

    if(patientIdtemp.value.length > 0 && visitIdtemp.value.length > 0 )
    {
        //parmIn.patientid = patientIdtemp;
        WebServices.DocareSysInterface('ANESMGR','HIS','HIS103',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
    }
}

function GetPatientUpdateOperationSchedule()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ANESMGR--ID��ͬ����д����ԤԼ�Ű���Ϣ:";
          
    var patientIdtemp = document.getElementById("patientId");
    if(patientIdtemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "����ID����Ϣ��ȫ!����������,лл!";
        return;
    }
    
    var visitIdtemp = document.getElementById("visitId");
    if(visitIdtemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "����סԺ������Ϣ��ȫ!����������,лл!";
        return;
    }
    
    var operidtemp = document.getElementById("inpNo");
    if(operidtemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "��������������Ϣ��ȫ!����������,лл!";
        return;
    }
    
    var parmIn = new ParmInputData();
    
    parmIn.patientid = patientIdtemp.value;
    parmIn.visitid = visitIdtemp.value;
    parmIn.operid = operidtemp.value;

    if(patientIdtemp.value.length > 0 && visitIdtemp.value.length > 0 )
    {
        WebServices.DocareSysInterface('ANESMGR','HIS','HIS202',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
    }
}

function CopyBackOperationInformation()
{
    debugger;
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ANESMGR--ID��ͬ����д��������������Ϣ:";
          
    var patientIdtemp = document.getElementById("patientId");
    if(patientIdtemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "����ID����Ϣ��ȫ!����������,лл!";
        return;
    }
    
    var visitIdtemp = document.getElementById("visitId");
    if(visitIdtemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "����סԺ������Ϣ��ȫ!����������,лл!";
        return;
    }
    
    var operidtemp = document.getElementById("inpNo");
    if(operidtemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "��������������Ϣ��ȫ!����������,лл!";
        return;
    }
    
    var parmIn = new ParmInputData();
    
    parmIn.patientid = patientIdtemp.value;
    parmIn.visitid = visitIdtemp.value;
    parmIn.operid = operidtemp.value;

    if(patientIdtemp.value.length > 0 && visitIdtemp.value.length > 0 )
    {
        WebServices.DocareSysInterface('ANESMGR','HIS','HIS203',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
    }
}
function CopyBackOperationState()
{
    debugger;
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ANESMGR--ID��ͬ����д��������״̬��Ϣ:";
          
    var patientIdtemp = document.getElementById("patientId");
    if(patientIdtemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "����ID����Ϣ��ȫ!����������,лл!";
        return;
    }
    
    var visitIdtemp = document.getElementById("visitId");
    if(visitIdtemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "����סԺ������Ϣ��ȫ!����������,лл!";
        return;
    }
    
    var operidtemp = document.getElementById("inpNo");
    if(operidtemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "��������������Ϣ��ȫ!����������,лл!";
        return;
    }
//    var operstatusTemp = document.getElementById("reserved02");
//    if(operstatusTemp.value.length < 1 )
//    {
//        rizhi.value = rizhi.value + "����״̬��G-��������ȡ C-����ȡ�� F-������������־������Ϣ��ȫ!����������,лл!";
//        return;
//    }
//    
    var parmIn = new ParmInputData();
    
    parmIn.patientid = patientIdtemp.value;
    parmIn.visitid = visitIdtemp.value;
    parmIn.operid = operidtemp.value;
//    parmIn.operstatus=operstatusTemp.value;
    
    if(patientIdtemp.value.length > 0 && visitIdtemp.value.length > 0 )
    {
        WebServices.DocareSysInterface('ANESMGR','HIS','HIS211',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
    }
}
function CopyBackOperationChancel()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ANESMGR--ID��ͬ����д����ȡ������:";
          
    var patientIdtemp = document.getElementById("patientId");
    if(patientIdtemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "����ID����Ϣ��ȫ!����������,лл!";
        return;
    }
    
    var visitIdtemp = document.getElementById("visitId");
    if(visitIdtemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "����סԺ������Ϣ��ȫ!����������,лл!";
        return;
    }
    
    var operidtemp = document.getElementById("inpNo");
    if(operidtemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "��������������Ϣ��ȫ!����������,лл!";
        return;
    }
    
    var parmIn = new ParmInputData();
    
    parmIn.patientid = patientIdtemp.value;
    parmIn.visitid = visitIdtemp.value;
    parmIn.operid = operidtemp.value;
   

    if(patientIdtemp.value.length > 0 && visitIdtemp.value.length > 0 )
    {
        WebServices.DocareSysInterface('ANESMGR','HIS','HIS212',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
    }
}

function GetPatientOrdersInfoOnDate()
{
    //debugger����JAVASCRIPT
    debugger;
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ANESMGR--ID��ͬ������ҽ����Ϣ(ʱ���):";
          
    var patientIdtemp = document.getElementById("patientId");
    if(patientIdtemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "����ID����Ϣ��ȫ!����������,лл!";
        return;
    }
    
    var visitIdtemp = document.getElementById("visitId");
    if(visitIdtemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "����סԺ������Ϣ��ȫ!����������,лл!";
        return;
    }
    
    var startdatetimetemp = document.getElementById("startdatetime");
    if(startdatetimetemp.value.length < 1)
    {
        rizhi.value = rizhi.value + "������ȡʱ���ҽ��ʱ��������Ϣ��ȫ!����������,лл!";
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
        WebServices.DocareSysInterface('ANESMGR','HIS','HIS105',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
    }
}

function GetDeptOperationSchedules()
{  
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ANESMGR--�鿴����ԤԼ��Ϣ:";
            
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
    
    var deptPatienttemp = document.getElementById("deptPatient");
    if(deptPatienttemp.value.length > 0)
    {
        parmIn.performedcode = deptPatienttemp.value;
    }
    
    var startdatetimetemp = document.getElementById("startdatetime");
    if(startdatetimetemp.value.length > 0)
    {
        var tempMouthStart = parseInt(startdatetimetemp.value.substr(5,2),10) - 1;
        parmIn.startdatetime = new Date(startdatetimetemp.value.substr(0,4),tempMouthStart.toString(),startdatetimetemp.value.substr(8,2));
    }
    
    var enddatetimetemp = document.getElementById("enddatetime");
    if(enddatetimetemp.value.length > 0)
    {
        var tempMouthEnd = parseInt(enddatetimetemp.value.substr(5,2),10) - 1;
        parmIn.stopdatetime = new Date(enddatetimetemp.value.substr(0,4),tempMouthEnd.toString(),enddatetimetemp.value.substr(8,2));
    }
    
    //parmIn.stopdatetime = new Date();

    WebServices.DocareSysInterface('ANESMGR','HIS','HIS201',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
}

function GetDeptMtrlDocument()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ANESMGR--���ҺĲ������Ϣ:";

    if(deptPatienttemp.value.length > 0)
    {
        WebServices.DocareSysInterface('ANESMGR','HIS','HIS208',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
    }
}

function GetDeptDrugDocument()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ANESMGR--����ҩƷ�����Ϣ:";

    if(deptPatienttemp.value.length > 0)
    {
        WebServices.DocareSysInterface('ANESMGR','HIS','HIS207',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
    }
}

function SetPatientSchedulesInto()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ANESMGR--��дȷ������������Ϣ:";
            
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

    var operidtemp = document.getElementById("inpNo");
    if(visitIdtemp.value.length > 0)
    {
        parmIn.operid = operidtemp.value;
    }
    var deptPatienttemp = document.getElementById("deptPatient");
    if(deptPatienttemp.value.length > 0)
    {
        parmIn.itemno = deptPatienttemp.value;
    }
    var reservedTemp = document.getElementById("reserved");
    if(reservedTemp.value.length > 0)
    {
        parmIn.reserved02 = reservedTemp.value;
    }
    else
    {
        parmIn.reserved02 = 'ONLY';
    }
    

    WebServices.DocareSysInterface('ANESMGR','HIS','HIS209',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
}

function GetPatientChargesVerifyInfo()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ANESMGR--�鿴����������Ȩ��Ϣ:";
            
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

    var operidtemp = document.getElementById("inpNo");
    if(visitIdtemp.value.length > 0)
    {
        parmIn.operid = operidtemp.value;
    }
    var deptPatienttemp = document.getElementById("deptPatient");
    if(deptPatienttemp.value.length > 0)
    {
        parmIn.performedby = deptPatienttemp.value;
    }
    else
    {
        parmIn.performedby = '2140300';
    }
    var reservedTemp = document.getElementById("reserved");
    if(reservedTemp.value.length > 0)
    {
        parmIn.reserved03 = reservedTemp.value;
    }
    else
    {
        parmIn.reserved03 = '0000';
    }
    

    WebServices.DocareSysInterface('ANESMGR','HIS','HIS214',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
}

function GetPriceDict()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ANESMGR--ͬ��ҽԺ�۱���Ϣ:";
            
    var deptPatienttemp = document.getElementById("deptPatient");
    
    var parmIn = new ParmInputData();
    if(deptPatienttemp.value.length > 0)
    {
       parmIn.performedcode = deptPatienttemp.value;
    }

    WebServices.DocareSysInterface('ANESMGR','HIS','HIS007',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
}

function GetPatientEmrDocUpLoad()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ANESMGR--���˴�ӡ��������(����):";
            
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
        parmIn.reserved04 = reserved04Temp.value;//EMR����
    }
    
    parmIn.reserved11 = "1";//�鵵����
    parmIn.reserved12 = "0";//ҳ��

    WebServices.DocareSysInterface('ANESMGR','HIS','HIS301',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
}


function GetPatientAllEmrDocUpLoad()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "ANESMGR--���˲����ύ(����):";
            
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


    WebServices.DocareSysInterface('ANESMGR','HIS','HIS302',parmIn,SuccessHandler,TimeOutHandler,ErrorHandler);
}
