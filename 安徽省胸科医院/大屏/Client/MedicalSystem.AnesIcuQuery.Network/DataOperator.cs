using MedicalSystem.AnesIcuQuery.Common;
using MedicalSystem.AnesIcuQuery.Models;
using System;
using System.Collections.Generic;

namespace MedicalSystem.AnesIcuQuery.Network
{
    /// <summary>
    /// 数据操作
    /// </summary>
    public class DataOperator
    {
        private static Dictionary<Int32, String> enumDict = null;
        /// <summary>
        /// API功能模块转字典
        /// </summary>
        protected static Dictionary<Int32, String> EnumApiUrlDict
        {
            get
            {
                if (enumDict == null)
                {
                    enumDict = EnumHelper.EnumToDictionary(typeof(ApiUrlEnum), e => e.GetDescription());
                }
                return enumDict;
            }
        }

        /// <summary>
        /// Api访问接口
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="url">选择接口模块</param>
        /// <param name="paramObj">输入参数</param>
        /// <returns></returns>
        public static T HttpWebApi<T>(ApiUrlEnum url, QueryParams queryParams)
        {
            //获取访问路径
            string ctrlAction = EnumApiUrlDict[(int)url];
            var jsonStr = HttpRequest.Instance.HttpPostJson(ctrlAction, queryParams);

            if (jsonStr != null && jsonStr.StartsWith("{\"ResultCode\":1000,"))
            {
                ApiResult<T> result = HttpRequest.Instance.SerializerResult<T>(jsonStr);
                return result.Data;
            }

            ApiResult<dynamic> dynamicResult = HttpRequest.Instance.SerializerResult<dynamic>(jsonStr);

            if (dynamicResult == null)
            {
                throw new NetworkException("JSON序列化后的结果为NULL。");
            }

            if (dynamicResult.ResultCode != ApiResultCode.Success)
            {
                if (dynamicResult.ResultCode == ApiResultCode.Fatal)
                {
                    Exception ex = HttpRequest.Instance.SerializerObject<Exception>(Convert.ToString(dynamicResult.Data));
                    throw new NetworkException(ex.Message, ex);
                }
                throw new NetworkException(string.Format("返回结果[{0}]，信息[{1}]。", dynamicResult.ResultCode, dynamicResult.Message));
            }

            T t = HttpRequest.Instance.SerializerObject<T>(Convert.ToString(dynamicResult.Data));
            return t;
        }

        /// <summary>
        /// Api访问接口
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="url">选择接口模块</param>
        /// <param name="paramObj">输入参数</param>
        /// <returns></returns>
        public static T HttpWebApi<T, O>(ApiUrlEnum url, O queryParams)
        {
            //获取访问路径
            string ctrlAction = EnumApiUrlDict[(int)url];
            var jsonStr = HttpRequest.Instance.HttpPostJson(ctrlAction, queryParams);

            if (jsonStr != null && jsonStr.StartsWith("{\"ResultCode\":1000,"))
            {
                ApiResult<T> trueResult = HttpRequest.Instance.SerializerResult<T>(jsonStr);
                return trueResult.Data;
            }

            ApiResult<dynamic> result = HttpRequest.Instance.SerializerResult<dynamic>(jsonStr);

            if (result == null)
            {
                throw new NetworkException("JSON序列化后的结果为NULL。");
            }

            if (result.ResultCode != ApiResultCode.Success)
            {
                if (result.ResultCode == ApiResultCode.Fatal)
                {
                    Exception ex = HttpRequest.Instance.SerializerObject<Exception>(Convert.ToString(result.Data));
                    throw new NetworkException(ex.Message, ex);
                }
                throw new NetworkException(string.Format("返回结果[{0}]，信息[{1}]。", result.ResultCode, result.Message));
            }

            T t = HttpRequest.Instance.SerializerObject<T>(Convert.ToString(result.Data));
            return t;
        }
    }

}
