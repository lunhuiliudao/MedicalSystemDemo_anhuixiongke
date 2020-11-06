using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesIcuQuery.Models
{
    /// <summary>
    /// 病人手术主记录：MED_OPERATION_MASTER
    /// </summary>
    [Description("MED_OPERATION_MASTER")]
    public class AnesthesiaMaster : BaseModel
    {
        public String Patient_Id
        {
            get { return (String)this["Patient_Id"]; }
            set { this["Patient_Id"] = value; }
        }
        public Decimal Visit_Id
        {
            get { return (Decimal)this["Visit_Id"]; }
            set { this["Visit_Id"] = value; }
        }
        public Decimal Oper_Id
        {
            get { return (Decimal)this["Oper_Id"]; }
            set { this["Oper_Id"] = value; }
        }
        public String Laryngoscope
        {
            get { return (String)this["Laryngoscope"]; }
            set { this["Laryngoscope"] = value; }
        }
        public String Trachea_Tube
        {
            get { return (String)this["Trachea_Tube"]; }
            set { this["Trachea_Tube"] = value; }
        }
        public Decimal Heart_Lung_Time
        {
            get { return (Decimal)this["Heart_Lung_Time"]; }
            set { this["Heart_Lung_Time"] = value; }
        }
        public Decimal Low_Flow_Time
        {
            get { return (Decimal)this["Low_Flow_Time"]; }
            set { this["Low_Flow_Time"] = value; }
        }
        public Decimal Stop_Loop_Time
        {
            get { return (Decimal)this["Stop_Loop_Time"]; }
            set { this["Stop_Loop_Time"] = value; }
        }
        public Decimal Separate_Loop_Time
        {
            get { return (Decimal)this["Separate_Loop_Time"]; }
            set { this["Separate_Loop_Time"] = value; }
        }
        public Decimal Pre_Stuff_Volume
        {
            get { return (Decimal)this["Pre_Stuff_Volume"]; }
            set { this["Pre_Stuff_Volume"] = value; }
        }
        public Decimal Remain_Volume
        {
            get { return (Decimal)this["Remain_Volume"]; }
            set { this["Remain_Volume"] = value; }
        }
        public Decimal Filter_Volume
        {
            get { return (Decimal)this["Filter_Volume"]; }
            set { this["Filter_Volume"] = value; }
        }
        public Decimal Backflow_Volume
        {
            get { return (Decimal)this["Backflow_Volume"]; }
            set { this["Backflow_Volume"] = value; }
        }
        public Decimal Est_Bloodlost_Volume
        {
            get { return (Decimal)this["Est_Bloodlost_Volume"]; }
            set { this["Est_Bloodlost_Volume"] = value; }
        }
        public String Heart_Lung_Operator
        {
            get { return (String)this["Heart_Lung_Operator"]; }
            set { this["Heart_Lung_Operator"] = value; }
        }
        public String Anesthesia_Doctor
        {
            get { return (String)this["Anesthesia_Doctor"]; }
            set { this["Anesthesia_Doctor"] = value; }
        }
    }
}
