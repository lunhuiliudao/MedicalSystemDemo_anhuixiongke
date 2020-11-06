using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesIcuQuery.Models
{
    /// <summary>
    /// 用户信息（HIS）：MED_HIS_USERS
    /// </summary>
    [Description("MED_HIS_USERS")]
    public class HisUsers : BaseModel
    {
        public String User_Id
        {
            get { return (String)this["User_Id"]; }
            set { this["User_Id"] = value; }
        }
        public String User_Name
        {
            get { return (String)this["User_Name"]; }
            set { this["User_Name"] = value; }
        }
        public String User_Dept
        {
            get { return (String)this["User_Dept"]; }
            set { this["User_Dept"] = value; }
        }
        public String Input_Code
        {
            get { return (String)this["Input_Code"]; }
            set { this["Input_Code"] = value; }
        }
        public String User_Job
        {
            get { return (String)this["User_Job"]; }
            set { this["User_Job"] = value; }
        }
        public String Reserved01
        {
            get { return (String)this["Reserved01"]; }
            set { this["Reserved01"] = value; }
        }
        public DateTime? Create_Date
        {
            get { return (DateTime?)this["Create_Date"]; }
            set { this["Create_Date"] = value; }
        }

    }
}
