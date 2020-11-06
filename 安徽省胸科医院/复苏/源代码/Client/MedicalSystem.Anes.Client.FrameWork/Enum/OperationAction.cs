using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Client.FrameWork
{
    public enum OperationAction
    {
        /// <summary>
        /// 无患者操作
        /// </summary>
        NoPatient,
        /// <summary>
        /// 病历病程操作
        /// </summary>
        MedicalRecord,
        /// <summary>
        /// 医疗文书
        /// </summary>
        MedicalDocument,
        /// <summary>
        /// 术中操作
        /// </summary>
        OperationDuring, 
    }
}
