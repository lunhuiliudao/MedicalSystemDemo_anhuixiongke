using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain.RequestResult
{
    /// <summary>
    /// 请求返回对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RequestResult<T>
    {
        /// <summary>
        /// 请求结果
        /// </summary>
        public ResultStatus Result { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Message { get; set; }

        public RequestResult()
        {
            Result = ResultStatus.Default;
            Message = "";
            Data = default(T);
        }

    }

    public enum ResultStatus
    {
        Default = 0,
        Success = 1,
        Failed = 2,
        Exception = 3,
    }


    #region 请求结果带分页总数  add by xiaopei.y@2017-06-12 10:02:24
    /// <summary>
    /// 请求返回对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RequestPageResult<T>
    {
        /// <summary>
        /// 请求结果
        /// </summary>
        public ResultStatus Result { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 分页总数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 每页数量
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage { get; set; }

        public RequestPageResult()
        {
            Result = ResultStatus.Default;
            Message = "";
            Data = default(T);
            TotalCount = 0;
            PageSize = 0;
            CurrentPage = 0;
        }

    }

    #endregion
}
