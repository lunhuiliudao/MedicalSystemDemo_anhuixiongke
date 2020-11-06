using System;
using System.Collections;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using System.Collections.Generic;
using BLL;

/// <summary>
/// Summary description for DocareTrunDataService
/// </summary>
[WebService(Description = "Docare医疗数据集成平台", Namespace = "http://www.medicalsystem.com.cn")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class DocareTrunDataService : System.Web.Services.WebService
{

    public DocareTrunDataService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [WebMethod(Description = "Docare医疗数据集成平台开放对外接口函数")]
    public string SendInfoToDocare(string Message)
    {
        return DataReaderWebServiceUpdate.ReceiveMessage(Message);
    }
    [WebMethod(Description = "Docare医疗数据集成平台-HelloWorld调试函数")]
    public string HelloWorld()
    {
        return "Hello World";
    }

}
   

