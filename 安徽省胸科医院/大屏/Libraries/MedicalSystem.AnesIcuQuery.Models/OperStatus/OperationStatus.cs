using System.ComponentModel;

namespace MedicalSystem.AnesIcuQuery.Models
{
    /// <summary>
    /// 手术状态
    /// </summary>
    public abstract class OperationStatus
    {
        /// <summary>
        /// 根据版本号提取对应的手术状态 - 默认取5.0版本状态
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public static OperationStatus Parse(string version)
        {
            if (string.IsNullOrEmpty(version) || version == "5.0")
            {
                return new OperationStatus5();
            }
            else
            {
                return new OperationStatus4();
            }
        }

        /// <summary>
        /// 取消手术
        /// </summary>
        [Description("取消手术")]
        public abstract int CancelOperation { get; }

        /// <summary>
        /// 出手术室
        /// </summary>
        [Description("出手术室")]
        public abstract int OutOperationRoom { get; }
    }
}
