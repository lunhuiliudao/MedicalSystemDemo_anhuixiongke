using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesIcuQuery.Models
{
    /// <summary>
    /// 科室字典表：MED_DEPT_DICT
    /// </summary>
    [Description("MED_DEPT_DICT")]
    public class DeptDict : BaseModel
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
        public String Input_Code
        {
            get { return (String)this["Input_Code"]; }
            set { this["Input_Code"] = value; }
        }
        public String Dept_Alias
        {
            get { return (String)this["Dept_Alias"]; }
            set { this["Dept_Alias"] = value; }
        }
    }
}
