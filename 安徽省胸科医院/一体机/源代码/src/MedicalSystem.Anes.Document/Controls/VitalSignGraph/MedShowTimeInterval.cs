using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MedicalSystem.Anes.Document.Controls
{
    public enum MedShowTimeInterval
    {
        [Description("5分钟")]
        Five=5,
        [Description("10分钟")]
        Ten=10,
        [Description("15分钟")]
        Fifiteen=15,
        [Description("20分钟")]
        Twenty=20,
        [Description("半小时")]
        HalfHour=30,
        [Description("1小时")]
        Hour=60,
        [Description("不限制")]
        AnyTime = 1
    }
}
