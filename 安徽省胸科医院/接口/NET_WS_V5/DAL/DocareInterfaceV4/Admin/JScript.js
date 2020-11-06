function inita() 
{ 
    document.getElementById("logsDate").value= new Date().format("yyyy-MM-dd");
    document.getElementById("startdatetime").value= new Date().format("yyyy-MM-dd");
    document.getElementById("enddatetime").value= new Date().format("yyyy-MM-dd");
    
} 

function GetLogsTxt()
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "获取服务器日志信息:";
    
    var logsDate = document.getElementById("logsDate");
    
    WebServices.GetLogDate(logsDate.value.toString(),SuccessHandler,TimeOutHandler,ErrorHandler);

}

//WebServer调用的返回类型和异常
function SuccessHandler(result)
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = rizhi.value + "WebServer运行结果（正确则'[ ]'内返回值为空，错误则返回问题描述）：[" + result+" ]";
    //alert("OK");
}
//调用WebServer Timeout
function TimeOutHandler(result)
{
    var rizhi = document.getElementById("rizhi");
    rizhi.value = "WebServer运行结果:失败原因 :[错误" + result + "  ,],(错误则直接返回问题描述,正确则说明都不返回!)";
    //alert("Timeout :" + result);
}
//异常情况
function ErrorHandler(result)
{
    var msg=result.get_exceptionType() + "\r\n";
    msg += result.get_message() + "\r\n";
    msg += result.get_stackTrace();
    var rizhi = document.getElementById("rizhi");
    rizhi.value =msg; 
    //alert(msg);
}

