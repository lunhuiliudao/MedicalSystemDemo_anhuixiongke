function inita() 
{ 
    document.getElementById("logsDate").value= new Date().format("yyyy-MM-dd");
    document.getElementById("startdatetime").value= new Date().format("yyyy-MM-dd");
    document.getElementById("enddatetime").value= new Date().format("yyyy-MM-dd");
    
} 

function GetLogsTxt()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "��ȡ��������־��Ϣ:";
    
    var logsDate = document.getElementById("logsDate");
    
    WebServices.GetLogDate(logsDate.value.toString(),SuccessHandler,TimeOutHandler,ErrorHandler);

}

//WebServer���õķ������ͺ��쳣
function SuccessHandler(result)
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = rizhi.value + "WebServer���н������ȷ��'[ ]'�ڷ���ֵΪ�գ������򷵻�������������[" + result+" ]";
    //alert("OK");
}
//����WebServer Timeout
function TimeOutHandler(result)
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "WebServer���н��:ʧ��ԭ�� :[����" + result + "  ,],(������ֱ�ӷ�����������,��ȷ��˵����������!)";
    //alert("Timeout :" + result);
}
//�쳣���
function ErrorHandler(result)
{
    var msg=result.get_exceptionType() + "\r\n";
    msg += result.get_message() + "\r\n";
    msg += result.get_stackTrace();
    var rizhi = document.getElementById("rizhi");
    rizhi.value =msg; 
    //alert(msg);
}

