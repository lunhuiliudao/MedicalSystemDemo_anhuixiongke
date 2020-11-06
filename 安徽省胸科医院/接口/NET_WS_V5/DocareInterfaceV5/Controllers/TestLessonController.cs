using BLL;
using Init;
using NET_WS_V5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NET_WS_V5.Controllers
{
    public class TestLessonController : ApiController
    {
        public string Post(TestLesson less)
        {
            try
            {
                decimal dec;
                ParamInputDomain domain = new ParamInputDomain();
                domain.Patient.PatientId = less.PatientId;
                domain.Patient.InpNo = less.InpNo;
                if (decimal.TryParse(less.VisitId, out dec))
                {
                    domain.Patient.VisitId = dec;
                }
                domain.Code = less.AppCode;
                domain.Patient.WardCode = less.WardCode;
                domain.Patient.StartDate = DateTime.Now.AddDays(-2);
                domain.Patient.StopDate = DateTime.Now;
                domain.Patient.DEP_ID = 1;
                domain.OpenClient = false;

                string mess=  domain.ToString();
                string re = DataReaderWebService.DocareMessage(mess);
                return re;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
