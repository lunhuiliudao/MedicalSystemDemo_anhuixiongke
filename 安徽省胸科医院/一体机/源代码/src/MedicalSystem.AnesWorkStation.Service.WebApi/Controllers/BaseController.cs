using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MedicalSystem.DataServices.Domain;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers
{
    public class BaseController : ApiController
    {
        protected RequestResult<T> Success<T>(T data)
        {
            return Success(data, null);
        }
        protected RequestResult<T> Success<T>(T data, string message)
        {
            return RequestResult(ResultStatus.Success, data, message);
        }

        protected RequestResult<T> Failed<T>(string message)
        {
            return RequestResult<T>(ResultStatus.Failed, default(T), message);
        }

        protected RequestResult<T> RequestResult<T>(ResultStatus result, T data, string message)
        {
            return new RequestResult<T>()
            {
                Result = result,
                Data = data,
                Message = message
            };
        }
    }
}