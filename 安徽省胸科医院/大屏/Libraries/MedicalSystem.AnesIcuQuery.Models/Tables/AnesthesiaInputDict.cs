using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesIcuQuery.Models
{
    /// <summary>
    /// 麻醉输入项目字典：MED_ANESTHESIA_INPUT_DICT
    /// </summary>
    [Description("MED_ANESTHESIA_INPUT_DICT")]
    public class AnesthesiaInputDict : BaseModel
    {
        public Decimal Serial_No
        {
            get { return (Decimal)this["Serial_No"]; }
            set { this["Serial_No"] = value; }
        }
        public String Item_Class
        {
            get { return (String)this["Item_Class"]; }
            set { this["Item_Class"] = value; }
        }
        public String Item_Name
        {
            get { return (String)this["Item_Name"]; }
            set { this["Item_Name"] = value; }
        }
        public String Item_Code
        {
            get { return (String)this["Item_Code"]; }
            set { this["Item_Code"] = value; }
        }
        public String Input_Code
        {
            get { return (String)this["Input_Code"]; }
            set { this["Input_Code"] = value; }
        }
    }
}
