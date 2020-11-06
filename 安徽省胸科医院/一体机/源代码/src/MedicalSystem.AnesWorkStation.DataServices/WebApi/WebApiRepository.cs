
using MedicalSystem.AnesWorkStation.Domain.RequestResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.AnesWorkStation.DataServices.WebApi
{
    /// <summary>
    /// 访问WebApi
    /// </summary>
    public class WebApiRepository
    {
        /// <summary>
        /// 重新登录
        /// </summary>
        public static Action ReLoginAction;

        /// <summary>
        /// 登录次数（累计）
        /// </summary>
        private int __LoginTimes;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="LoginAction">重新登录委托</param>
        public WebApiRepository(Action LoginAction)
        {
            ReLoginAction = LoginAction;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        public WebApiRepository()
        {

        }

        /// <summary>
        /// GET方式访问WebApi
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="address">URL</param>
        /// <returns><![CDATA[RequestResult<T>]]></returns>
        public RequestResult<T> GetAccessApi<T>(string address)
        {
            RequestResult<T> obj = null;
            try
            {
                obj = WebApiVisitor.GetAccessApi<T>(address);
            }
            catch (Exception)
            {
                obj = new RequestResult<T>()
                {
                    Result =  ResultStatus.Exception,
                    Data = default(T),
                    Message = "WebApi访问失败"
                };
            }
            return obj;
        }
        /// <summary>
        /// POST方式访问WebApi
        /// </summary>
        /// <typeparam name="T_Request">参数类型</typeparam>
        /// <typeparam name="T_Result">返回类型</typeparam>
        /// <param name="address">URL</param>
        /// <param name="parameter">参数</param>
        /// <returns><![CDATA[RequestResult<T_Result>]]></returns>
        public RequestResult<dynamic> PostAccessApi<T_Request, T_Result>(string address, T_Request parameter)
        {
            RequestResult<dynamic> obj = null;
            try
            {
                obj = WebApiVisitor.PostAccessApi<T_Request, T_Result>(address, parameter);
            }
            catch (Exception)
            {
                obj = new RequestResult<dynamic>()
                {
                    Result = ResultStatus.Exception,
                    Data = default(T_Result),
                    Message = "WebApi访问失败"
                };
            }
            return obj;
        }
        
    }
}
