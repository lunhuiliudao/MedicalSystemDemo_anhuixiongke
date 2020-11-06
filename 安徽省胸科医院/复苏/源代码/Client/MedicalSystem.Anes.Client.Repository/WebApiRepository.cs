using MedicalSystem.Anes.Domain;
using MedicalSystem.DataServices.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.Anes.Client.Repository
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
                if(CheckReLogin<T>(obj))
                    obj = WebApiVisitor.GetAccessApi<T>(address);
            }
            catch (Exception)
            {
                obj = new RequestResult<T>()
                {
                    Result = ResultStatus.Default,
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
        public RequestResult<T_Result> PostAccessApi<T_Request, T_Result>(string address, T_Request parameter)
        {
            RequestResult<T_Result> obj = null;
            try
            {
                obj = WebApiVisitor.PostAccessApi<T_Request, T_Result>(address, parameter);
                if (CheckReLogin<T_Result>(obj))
                    obj = WebApiVisitor.PostAccessApi<T_Request, T_Result>(address, parameter);
            }
            catch (Exception)
            {
                obj = new RequestResult<T_Result>()
                {
                    Result = ResultStatus.Default,
                    Data = default(T_Result),
                    Message = "WebApi访问失败"
                };
            }
            return obj;
        }
        /// <summary>
        /// 检测是否执行了重新登录
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="obj">访问结果</param>
        /// <returns>true:已执行重新登录，false:未执行重新登录</returns>
        private bool CheckReLogin<T>(RequestResult<T> obj)
        {
            if (obj == null)
                return false;
            if (obj.Result == ResultStatus.Success)
            {
                __LoginTimes = 0;   //登录次数清0
                return false;
            }
            else
            {
                switch (obj.Result)
                {
                    case ResultStatus.Default:
                    case ResultStatus.Failed:
                    case ResultStatus.Exception:
                        if (__LoginTimes < 3)   //重新登录次数不超过3次
                        {
                            if (ReLoginAction != null)  
                            {
                                ReLoginAction();
                                __LoginTimes++;
                                return true;
                            }
                            else
                                return false;
                        }
                        else
                            return false;
                    default:
                        return false;
                }
            }
        }
    }
}
