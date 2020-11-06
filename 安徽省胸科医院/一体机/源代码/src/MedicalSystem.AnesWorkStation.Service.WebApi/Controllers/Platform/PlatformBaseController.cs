using MedicalSystem.AnesWorkStation.Domain;
using MedicalSystem.AnesWorkStation.Domain.RequestResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers.Platform
{
    public class PlatformBaseController : ApiController
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
            return new MedicalSystem.AnesWorkStation.Domain.RequestResult.RequestResult<T>()
            {
                Result = result,
                Data = data,
                Message = message,
            };
        }


        #region 请求结果分页处理
        protected RequestPageResult<T> PageSuccess<T>(T data, int pageSize, int currentPage, int totalCount)
        {
            return PageSuccess(data, null, pageSize, currentPage, totalCount);
        }
        protected RequestPageResult<T> PageSuccess<T>(T data, string message, int pageSize, int currentPage, int totalCount)
        {
            return RequestPageResult(ResultStatus.Success, data, message, pageSize, currentPage, totalCount);
        }

        protected RequestPageResult<T> PageFailed<T>(string message)
        {
            return RequestPageResult<T>(ResultStatus.Failed, default(T), message, 0, 0, 0);
        }

        protected RequestPageResult<T> RequestPageResult<T>(ResultStatus result, T data, string message, int pageSize, int currentPage, int totalCount)
        {
            return new RequestPageResult<T>()
            {
                Result = result,
                Data = data,
                Message = message,
                TotalCount = totalCount,
                PageSize = pageSize,
                CurrentPage = currentPage
            };
        }
        #endregion
    }
}