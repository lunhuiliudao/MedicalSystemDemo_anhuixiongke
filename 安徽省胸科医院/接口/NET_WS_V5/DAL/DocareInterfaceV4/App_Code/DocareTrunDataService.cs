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
[WebService(Description = "Docareҽ�����ݼ���ƽ̨", Namespace = "http://www.medicalsystem.com.cn")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class DocareTrunDataService : System.Web.Services.WebService
{

    public DocareTrunDataService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    [WebMethod(Description = "Docareҽ�����ݼ���ƽ̨���Ŷ���ӿں���")]
    public string SendInfoToDocare(string Message)
    {
        return DataReaderWebServiceUpdate.ReceiveMessage(Message);
    }
    [WebMethod(Description = "Docareҽ�����ݼ���ƽ̨-HelloWorld���Ժ���")]
    public string HelloWorld()
    {
        return "Hello World";
    }

}
   

