using MedicalSytem.Soft.DAL;
using MedicalSytem.Soft.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NET_WS_V5.Controllers
{
    public class HisViewSqlController : ApiController
    {
        public IEnumerable<MedIfHisViewSql2> Get()
        {
            return new DALMedIfHisViewSql2().GetMedIfHisView2();
        }

        public string PUT(string id, [FromBody]MedIfHisViewSql2 viewSql)
        {
            return id;
        }

        public string POST([FromBody]MedIfHisViewSql2 viewSql)
        {
            return "";
        }

        public string Delete([FromBody]MedIfHisViewSql2 viewSql)
        {
            return "aaa" ;
        }
    }
}
