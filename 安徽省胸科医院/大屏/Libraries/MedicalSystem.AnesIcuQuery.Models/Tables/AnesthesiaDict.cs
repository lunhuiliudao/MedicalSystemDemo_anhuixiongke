using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesIcuQuery.Models
{
    /// <summary>
    /// 麻醉方法字典表：MED_ANAESTHESIA_DICT
    /// </summary>
    [Description("MED_ANAESTHESIA_DICT")]
    public class AnesthesiaDict : BaseModel
    {
        public Decimal Serial_No
        {
            get { return (Decimal)this["Serial_No"]; }
            set { this["Serial_No"] = value; }
        }
        public String Anaesthesia_Code
        {
            get { return (String)this["Anaesthesia_Code"]; }
            set { this["Anaesthesia_Code"] = value; }
        }
        public String Anaesthesia_Name
        {
            get { return (String)this["Anaesthesia_Name"]; }
            set { this["Anaesthesia_Name"] = value; }
        }
        public String Input_Code
        {
            get { return (String)this["Input_Code"]; }
            set { this["Input_Code"] = value; }
        }
        public String Anaesthesia_Type
        {
            get { return (String)this["Anaesthesia_Type"]; }
            set { this["Anaesthesia_Type"] = value; }
        }
        public String Anaesthesia_Shorten
        {
            get { return (String)this["Anaesthesia_Shorten"]; }
            set { this["Anaesthesia_Shorten"] = value; }
        }
        public Decimal Need_Anes_Doctor
        {
            get { return (Decimal)this["Need_Anes_Doctor"]; }
            set { this["Need_Anes_Doctor"] = value; }
        }
    }
}
