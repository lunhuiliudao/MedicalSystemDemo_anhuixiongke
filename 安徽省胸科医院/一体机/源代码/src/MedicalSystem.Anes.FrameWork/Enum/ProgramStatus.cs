using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.FrameWork
{/// 程序状态
    /// </summary>
    public enum ProgramStatus
    {
        /// <summary>
        /// 无患者操作
        /// </summary>
        NoPatient,
        /// <summary>
        /// 术前患者操作
        /// </summary>
        PeroperativePatient,
        /// <summary>
        /// 选中术后患者操作
        /// </summary>
        PostoperativePatient,
        /// <summary>
        /// 麻醉单
        /// </summary>
        AnesthesiaRecord,
        /// <summary>
        /// 复苏单
        /// </summary>
        PACURecord,
        /// <summary>
        /// 体外循环报告单
        /// </summary>
        CPBReport, 
    }
}
