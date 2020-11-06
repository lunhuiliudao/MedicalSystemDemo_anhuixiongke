using BLL;
using Init;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace NET_WS_V5.WebService
{
    /// <summary>
    /// WebDocare 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebDocare : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        /// Docare 内部调用
        /// </summary>
        /// <param name="paraIn"></param>
        /// <returns></returns>
        [WebMethod(Description = "系统集成入口，仅限麦迪斯顿内部接口,客户端调用，入参为json 字符串")]
        public string Ofsysteminterface(string paraIn)
        {
            return DataReaderWebService.DocareMessage(paraIn);
        }

        //[WebMethod(Description = "麦迪斯顿集成入口，仅限麦迪斯顿内部接口，服务端调用,入参为domain 实体类")]
        //public string DocareSysInterface(ParamInputDomain domain)
        //{
        //    domain.Patient.PatientId = "366495";
        //    domain.Reserved1 = "DataBase";
        //    domain.App ="麻醉同步患者ID";
        //    domain.Code = "ANES101";
        //    return DataReaderWebService.HanderDomain(domain);
        //}

        //[WebMethod(Description = "麦迪斯顿集成入口，仅限麦迪斯顿内部接口，服务端调用")]
        //public string Test(string patientid,string   visitid,string inpno,string wardcode,string appcode)
        //{
        //    decimal dec;
        //    ParamInputDomain domain = new ParamInputDomain();
        //    domain.Patient.PatientId = patientid;
        //    if (decimal.TryParse(visitid, out dec))
        //    {
        //        domain.Patient.VisitId = dec;
        //    }
        //    domain.Patient.WardCode = wardcode;
        //    domain.Code = appcode;
        //    domain.Patient.InpNo = inpno;
        //    domain.App = "测试";
        //    return DataReaderWebService.HanderDomain(domain);
        //}
    }
}
