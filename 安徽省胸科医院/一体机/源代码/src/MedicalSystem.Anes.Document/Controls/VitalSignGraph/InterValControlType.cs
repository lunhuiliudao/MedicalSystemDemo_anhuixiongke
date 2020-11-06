using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MedicalSystem.Anes.Document.Controls
{
    /// <summary>
    /// 时间间隔控制类型
    /// </summary>
    [Serializable]
    public enum InterValControlType
    {
        /// <summary>
        /// 只作用数值曲线
        /// </summary>
        [Description("数值")]
        DigitOnly,
        /// <summary>
        /// 作用所有曲线
        /// </summary>
        [Description("所有")]
        ControlAll
    }

}
