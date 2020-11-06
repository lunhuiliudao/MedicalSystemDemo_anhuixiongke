
namespace MedicalSystem.AnesIcuQuery.Models
{
    /// <summary>
    /// 返回结果标识
    /// </summary>
    public class ApiResultCode
    {
        /// <summary>
        /// 成功并且有结果
        /// </summary>
        public const int Success = 1000;

        /// <summary>
        /// 成功但没有结果
        /// </summary>
        public const int SuccessNoResult = 1100;

        /// <summary>
        /// 业务逻辑代码内错误
        /// </summary>
        public const int FailedBusiness = 1200;

        /// <summary>
        /// 账号密码错误
        /// </summary>
        public const int FailedNoUserAndPassword = 1201;

        /// <summary>
        /// 参数错误
        /// </summary>
        public const int FailedParams = 1210;

        /// <summary>
        /// 数据库执行错误
        /// </summary>
        public const int FailedDatabase = 1300;

        /// <summary>
        /// 网站程序崩溃错误
        /// </summary>
        public const int Fatal = 1400;

        /// <summary>
        /// 没有Session验证
        /// </summary>
        public const int NoSession = 2100;
    }
}
