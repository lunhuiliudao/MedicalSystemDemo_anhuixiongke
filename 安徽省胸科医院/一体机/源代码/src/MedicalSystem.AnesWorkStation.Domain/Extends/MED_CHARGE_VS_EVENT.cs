using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
    /// <summary>
    /// 实体 根据计价单得出事件中的收费项目
    /// </summary>
    public partial class MED_CHARGE_VS_EVENT
    {
        public virtual string ITEM_CALSS { get; set; }
        public virtual string ITEM_CODE { get; set; }
        public virtual string ITEM_NAME { get; set; }
        public virtual string ITEM_SPEC { get; set; }
        public virtual string EVENT_CLASS_CODE { get; set; }
        public virtual string EVENT_ITEM_CODE { get; set; }
        public virtual Nullable<int> VS_NO { get; set; }
        public virtual Nullable<int> AMOUNT { get; set; }
        public virtual string UNITS { get; set; }
        public virtual Nullable<decimal> DOSAGE { get; set; }
        public virtual string ITEM_CLASS_NAME { get; set; }
    }
}
