using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    /// <summary>
    /// 实体 给药途径代码表
    /// </summary>
    public partial class MED_ANESTHESIA_EVENT_TEMPLET
    {
        [NotMapped]
        public string EVENT_CLASS_NAME { get; set; }
    }
}
