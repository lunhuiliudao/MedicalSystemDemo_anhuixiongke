using Dapper.Data;
using System;

namespace MedicalSystem.AnesWorkStation.Domain
{
    /// <summary>
    ///  字典
    /// </summary>
    public partial class MED_ANESTHESIA_INPUT_DICT
    {
        [NotMapped]
        public bool ITEM_CHECKED { get; set; }
    }
}
