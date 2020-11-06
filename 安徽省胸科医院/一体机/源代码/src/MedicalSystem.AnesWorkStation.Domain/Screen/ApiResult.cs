using System.Runtime.Serialization;

namespace MedicalSystem.AnesWorkStation.Domain.Screen
{
    /// <summary>
    /// 返回数据的结构
    /// </summary>
    /// <typeparam name="T">泛型类型</typeparam>
    [DataContract(Name = "ApiResult")]
    public class ApiResult<T>
    {
        private int resultCode;
        /// <summary>
        /// 结果标志
        /// </summary>
        [DataMember(Order = 0)]
        public int ResultCode { get { return resultCode; } set { resultCode = value; } }

        public int Count { get; set; }

        private T data;
        /// <summary>
        /// 数据
        /// </summary>
        [DataMember(Order = 1)]
        public T Data { get { return data; } set { data = value; } }

        private string message;
        /// <summary>
        /// 特殊情况说明
        /// </summary>
        [DataMember(Order = 2)]
        public string Message { get { return message; } set { message = value; } }
    }
}