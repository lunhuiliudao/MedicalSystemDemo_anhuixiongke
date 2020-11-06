using Dapper.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesIcuQuery.Models
{
    /// <summary>
    /// 麻醉分类表：MED_ANESTHESIA_METHOD_TYPE
    /// </summary>
    [Description("MED_ANESTHESIA_METHOD_TYPE")]
    [Table("MED_ANESTHESIA_METHOD_TYPE")]
    public class AnesthesiaMethodType : BaseModel
    {
        [Key]
        public String Anesthesia_Method
        {
            get { return (String)this["Anesthesia_Method"]; }
            set { this["Anesthesia_Method"] = value; }
        }
        public Decimal? Intravertebral_Anes_Type
        {
            get { return (Decimal?)this["Intravertebral_Anes_Type"]; }
            set { this["Intravertebral_Anes_Type"] = value; }
        }
        public Decimal? Intubate_Anes_Type
        {
            get { return (Decimal?)this["Intubate_Anes_Type"]; }
            set { this["Intubate_Anes_Type"] = value; }
        }
        public Decimal? Non_Intubate_Anes_Type
        {
            get { return (Decimal?)this["Non_Intubate_Anes_Type"]; }
            set { this["Non_Intubate_Anes_Type"] = value; }
        }
        public Decimal? Combine_Anes_Type
        {
            get { return (Decimal?)this["Combine_Anes_Type"]; }
            set { this["Combine_Anes_Type"] = value; }
        }
        public Decimal? Other_Anes_Type
        {
            get { return (Decimal?)this["Other_Anes_Type"]; }
            set { this["Other_Anes_Type"] = value; }
        }

        public Decimal? All_Anesthesia
        {
            get { return (Decimal?)this["All_Anesthesia"]; }
            set { this["All_Anesthesia"] = value; }
        }
        public Decimal? Extra_Circulation
        {
            get { return (Decimal?)this["Extra_Circulation"]; }
            set { this["Extra_Circulation"] = value; }
        }
        public Decimal? Spinal_Anesthesia
        {
            get { return (Decimal?)this["Spinal_Anesthesia"]; }
            set { this["Spinal_Anesthesia"] = value; }
        }
    }
}
