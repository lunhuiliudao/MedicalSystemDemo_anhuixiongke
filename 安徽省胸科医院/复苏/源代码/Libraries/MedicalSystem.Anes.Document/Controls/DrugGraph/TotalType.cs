using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// 汇总类型
    /// </summary>
    [Serializable]
    public enum TotalType
    {
        /// <summary>
        /// 总量
        /// </summary>
        [Description("总量")]
        SummeryValue,
        /// <summary>
        /// 单位
        /// </summary>
        [Description("单位")]
        Unit,
        /// <summary>
        /// 空
        /// </summary>
        [Description("无汇总")]
        Empty
    }
}
