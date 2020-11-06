
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using MedicalSystem.AnesWorkStation.Domain.Screen;
using log4net;

namespace MedicalSystem.AnesWorkStation.Service.WebApi.Controllers
{
    /// <summary>
    /// Api基类
    /// </summary>
    public abstract class BaseApiController : ApiController
    {
        #region Success Failed Method

        /// <summary>
        /// 执行成功,返回值默认1000
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="data">返回数据</param>
        /// <returns></returns>
        public ApiResult<T> Success<T>(T data)
        {
            return Success(ApiResultCode.Success, data);
        }

        /// <summary>
        /// 执行成功,返回值默认1000
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="resultCode">成功代码1000</param>
        /// <param name="data">返回数据</param>
        /// <returns></returns>
        public ApiResult<T> Success<T>(int resultCode, T data)
        {
            return Success(resultCode, data, null);
        }

        /// <summary>
        /// 执行成功,返回值默认1000
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="resultCode">成功代码1000</param>
        /// <param name="data">返回数据</param>
        /// <param name="message">说明信息</param>
        /// <returns></returns>
        public ApiResult<T> Success<T>(int resultCode, T data, string message)
        {
            return new ApiResult<T>()
            {
                ResultCode = resultCode,
                Data = data,
                Message = message
            };
        }

        /// <summary>
        /// 执行失败
        /// </summary>
        /// <param name="message">错误信息</param>
        /// <returns></returns>
        public ApiResult<string> Failed(string message)
        {
            return Failed(ApiResultCode.FailedBusiness, message);
        }

        /// <summary>
        /// 执行失败
        /// </summary>
        /// <param name="resultCode">错误代码(非1000)</param>>
        /// <param name="message">错误信息</param>
        /// <returns></returns>
        public ApiResult<string> Failed(int resultCode, string message)
        {
            return Failed<string>(resultCode, null, message);
        }

        /// <summary>
        /// 执行失败
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="resultCode">错误代码(非1000)</param>
        /// <param name="data">错误数据</param>
        /// <param name="message">错误信息</param>
        /// <returns></returns>
        public ApiResult<T> Failed<T>(int resultCode, T data, string message)
        {
            return new ApiResult<T>()
            {
                ResultCode = resultCode,
                Data = data,
                Message = message
            };
        }

        #endregion

        #region 日志

        private ILog logger;
        public ILog Logger
        {
            get
            {
                if (logger == null)
                {
                    logger = LoggerConfig.GetLogger(this.GetType());
                }
                return logger;
            }
        }

        private const string LogInfoKey = "IsLogInfo";
        /// <summary>
        /// 是否记录普通信息日志
        /// </summary>
        public bool IsLogInfo
        {
            get
            {
                bool flag = false;
                if (ConfigurationManager.AppSettings != null
                    && ConfigurationManager.AppSettings[LogInfoKey] != null)
                {
                    bool.TryParse(ConfigurationManager.AppSettings[LogInfoKey], out flag);
                }
                return flag;
            }
        }

        public override System.Threading.Tasks.Task<HttpResponseMessage> ExecuteAsync(System.Web.Http.Controllers.HttpControllerContext controllerContext, System.Threading.CancellationToken cancellationToken)
        {
            var result = base.ExecuteAsync(controllerContext, cancellationToken);
            if (IsLogInfo)
            {
                if (result != null && result.Result != null && result.Result.Content != null)
                {
                    string info = result.Result.Content.ReadAsStringAsync().Result;
                    //如果执行正常切结果较少，则保存结果，否则简化记录
                    if (!string.IsNullOrEmpty(info)
                        && (info.Contains("<ResultCode>1000</ResultCode>") || info.Contains("\"ResultCode\":1000,")))
                    {
                        if (info.Length >= 600)
                        {
                            // 如果记录正常则简化日志记录
                            Logger.DebugFormat(@"
URL: {0}
Result: {1}...[length:{2}]。", controllerContext.Request.RequestUri, info.Substring(0, 600), info.Length);
                        }
                        else
                        {
                            // 日志
                            Logger.DebugFormat(@"
URL: {0}
Result: {1}", controllerContext.Request.RequestUri, info);
                        }
                    }
                }
            }
            return result;
        }

        #endregion

    }

}