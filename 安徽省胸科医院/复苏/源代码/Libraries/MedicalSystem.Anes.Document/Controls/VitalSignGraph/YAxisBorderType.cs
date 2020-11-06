using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MedicalSystem.Anes.Document.Controls
{

    /// <summary>
    /// Y坐标边框类型
    /// </summary>
    [Serializable]
    public enum YAxisBorderType
    {
        /// <summary>
        /// 圆角矩形
        /// </summary>
        [Description("圆角矩形")]
        RountRect,
        /// <summary>
        /// 矩形
        /// </summary>
        [Description("矩形")]
        Rect,
        /// <summary>
        /// 下划线
        /// </summary>
        [Description("下划线")]
        BottomLine,
        /// <summary>
        /// 下划线
        /// </summary>
        [Description("上划线")]
        TopLine,
        /// <summary>
        /// 无
        /// </summary>
        [Description("无")]
        None = 99
    }
}
