using System.ComponentModel;

namespace MedicalSystem.AnesIcuQuery.Models
{
    /// <summary>
    /// 手术状态 - 麻醉4.0库
    /// </summary>
    internal class OperationStatus4 : OperationStatus
    {
        /// <summary>
        /// 取消手术
        /// </summary>
        [Description("取消手术")]
        public override int CancelOperation { get { return -1; } }

        /// <summary>
        /// 出手术室
        /// </summary>
        [Description("出手术室")]
        public override int OutOperationRoom { get { return 3; } }
    }
}
