using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MedicalSystem.Anes.Document.Controls
{
    public enum NormalDrugUnitShowType
    {
        [Description("默认")]
        Default,
        [Description("浓度")]
        Thick,
        [Description("总量")]
        Dosage,
        [Description("总量(浓度)")]
        DosageThick,
        [Description("总量(浓度途径)")]
        DosageThickRoute,
        [Description("总量+单位")]
        DosageUnit,
    }
}
