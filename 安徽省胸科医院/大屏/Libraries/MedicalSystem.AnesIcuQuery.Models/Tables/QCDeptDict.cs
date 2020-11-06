using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesIcuQuery.Models
{
    /// <summary>
    /// 科室字典表：MED_QCDEPT_DICT
    /// </summary>
    [Description("MED_QCDEPT_DICT")]
    public class QCDeptDict : BaseModel
    {
        public Decimal Serial_No
        {
            get { return (Decimal)this["Serial_No"]; }
            set { this["Serial_No"] = value; }
        }
        public String Dept_Code
        {
            get { return (String)this["Dept_Code"]; }
            set { this["Dept_Code"] = value; }
        }
        public String Dept_Name
        {
            get { return (String)this["Dept_Name"]; }
            set { this["Dept_Name"] = value; }
        }
        public String QCDept_Code
        {
            get { return (String)this["QCDept_Code"]; }
            set { this["QCDept_Code"] = value; }
        }
        public String QCDept_Name
        {
            get { return (String)this["QCDept_Name"]; }
            set { this["QCDept_Name"] = value; }
        }
    }
}
