using BLL;
using Init;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace NET_WS_V5.Controllers
{
    public class TestICUController : Controller
    {
        //
        // GET: /TestICU/

        public ActionResult PatientInCode()
        {
            return View(new PatientInCode() { Code = "PAT109" });
        }

        [HttpPost]
        public ActionResult PatientInCode(PatientInCode config)
        {

            ParamInputDomain domain = new ParamInputDomain();
            domain.Code = config.Code;
            domain.Patient.PatientId = config.PatientId;
            domain.Patient.InpNo = config.InpNo;
            string mess = DataReaderWebService.DocareMessage(domain.ToJson());
            config.Result = mess;
            return View(config);
        }
    }
}
