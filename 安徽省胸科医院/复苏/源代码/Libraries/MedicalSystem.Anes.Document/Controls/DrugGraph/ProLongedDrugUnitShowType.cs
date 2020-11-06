using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MedicalSystem.Anes.Document.Controls
{

    public enum ProLongedDrugUnitShowType
    {
        [Description("默认")]
        Default,
        [Description("浓度")]
        Thick,
        [Description("速度")]
        Speed,
        [Description("速度(浓度)")]
        SpeedThick,
        [Description("速度(浓度+途径)")]
        SpeedThickRoute,
        [Description("总量")]
        Dosage,
        [Description("总量(浓度)")]
        DosageThick,
        [Description("总量(速度)")]
        DosageSpeed,
    }
}
