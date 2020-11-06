using System.ComponentModel;

namespace MedicalSystem.AnesIcuQuery.Models
{
    /// <summary>
    /// 手术状态 - 麻醉5.0库
    /// </summary>
    internal class OperationStatus5 : OperationStatus
    {
        /// <summary>
        /// 取消手术
        /// </summary>
        [Description("取消手术")]
        public override int CancelOperation { get { return -80; } }

        /// <summary>
        /// 出手术室
        /// </summary>
        [Description("出手术室")]
        public override int OutOperationRoom { get { return 35; } }
    }
}
