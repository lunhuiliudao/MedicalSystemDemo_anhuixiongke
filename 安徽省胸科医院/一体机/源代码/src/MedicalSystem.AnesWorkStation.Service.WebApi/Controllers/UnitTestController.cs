using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.DataServices.Domain;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers
{
    /// <summary>
    /// 常用方法类
    /// </summary>
    public class UnitTestController : BaseController
    {
        [HttpGet]
        public RequestResult<string> Test1()
        {
            return Success("111");
        }

        [HttpGet]
        public RequestResult<List<int>> Test2()
        {
            return Success(new List<int>() { 1, 2, 3 });
        }

        [HttpGet]
        public RequestResult<List<string>> Test3(string b)
        {
            return Success(new List<string>() { "1, 2, 3", b });
        }

        [HttpGet]
        public RequestResult<List<MED_USERS>> Test4()
        {
            return Success(new List<MED_USERS>() { new MED_USERS() { USER_NAME = "aaa" } });
        }

        [HttpPost]
        public RequestResult<bool> Test5(MED_USERS aaa)
        {
            return Success(true);
        }
        [HttpPost]
        public RequestResult<bool> Test6(List<MED_USERS> aaa)
        {
            return Success(true);
        }

        [HttpPost]
        public RequestResult<bool> Test7(dynamic aaa)
        {
            return Success(true);
        }

        [HttpGet]
        public RequestResult<bool> Test8()
        {
            throw new NotSupportedException("Test8");
        }

    }
}