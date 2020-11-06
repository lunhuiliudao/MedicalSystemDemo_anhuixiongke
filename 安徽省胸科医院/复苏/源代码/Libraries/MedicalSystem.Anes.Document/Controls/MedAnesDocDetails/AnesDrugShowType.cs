using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MedicalSystem.Anes.Document.Controls
{
    public enum AnesDrugShowType
    {
        /// <summary>
        /// 单个点
        /// </summary>
        [Description("单个点")]
        SinglePoint,
        /// <summary>
        /// 持续用药的点
        /// </summary>
        [Description("持续用药的点")]
        ProLonged,
        /// <summary>
        /// 所有
        /// </summary>
        [Description("所有")]
        Total
    }
}
