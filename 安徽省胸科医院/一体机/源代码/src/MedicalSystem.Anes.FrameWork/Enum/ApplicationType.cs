using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.FrameWork
{

    /// <summary>
    /// 应用程序类型
    /// </summary>
    public enum ApplicationType
    {
        /// <summary>
        /// 麻醉
        /// </summary>
        Anesthesia,
        /// <summary>
        /// 复苏
        /// </summary>
        PACU,
        /// <summary>
        /// 手术排班
        /// </summary>
        OperationSchedule,
        /// <summary>
        /// 体外循环（灌注）
        /// </summary>
        CardiopulmonaryBypass,
        /// <summary>
        /// 诱导（准备间）
        /// </summary>
        YouDao,
        /// <summary>
        /// 护理
        /// </summary>
        Nurse,
        /// <summary>
        /// 主任工作站
        /// </summary>
        Director,
        /// <summary>
        /// 无效的
        /// </summary>
        InValid,
    }
}
