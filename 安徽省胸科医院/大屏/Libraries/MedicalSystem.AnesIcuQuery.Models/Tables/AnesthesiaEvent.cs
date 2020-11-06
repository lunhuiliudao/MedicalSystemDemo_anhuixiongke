using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesIcuQuery.Models
{
    /// <summary>
    /// 麻醉事件表：MED_ANESTHESIA_EVENT
    /// </summary>
    [Description("MED_ANESTHESIA_EVENT")]
    public class AnesthesiaEvent : BaseModel
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
        public Decimal Item_No
        {
            get { return (Decimal)this["Item_No"]; }
            set { this["Item_No"] = value; }
        }
        public String Item_Class
        {
            get { return (String)this["Item_Class"]; }
            set { this["Item_Class"] = value; }
        }
        public Decimal Event_No
        {
            get { return (Decimal)this["Event_No"]; }
            set { this["Event_No"] = value; }
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
        public String Item_Spec
        {
            get { return (String)this["Item_Spec"]; }
            set { this["Item_Spec"] = value; }
        }
        public String Dosage_Units
        {
            get { return (String)this["Dosage_Units"]; }
            set { this["Dosage_Units"] = value; }
        }
        public Decimal? Dosage
        {
            get { return (Decimal?)this["Dosage"]; }
            set { this["Dosage"] = value; }
        }
        public String Administrator
        {
            get { return (String)this["Administrator"]; }
            set { this["Administrator"] = value; }
        }
        public DateTime Start_Time
        {
            get { return (DateTime)this["Start_Time"]; }
            set { this["Start_Time"] = value; }
        }
        public DateTime End_Date
        {
            get { return (DateTime)this["End_Date"]; }
            set { this["End_Date"] = value; }
        }
        public Decimal Bill_Indicator
        {
            get { return (Decimal)this["Bill_Indicator"]; }
            set { this["Bill_Indicator"] = value; }
        }
        public Decimal Durative_Indicator
        {
            get { return (Decimal)this["Durative_Indicator"]; }
            set { this["Durative_Indicator"] = value; }
        }
        public String Method
        {
            get { return (String)this["Method"]; }
            set { this["Method"] = value; }
        }
        public Decimal Perform_Speed
        {
            get { return (Decimal)this["Perform_Speed"]; }
            set { this["Perform_Speed"] = value; }
        }
        public String Speed_Unit
        {
            get { return (String)this["Speed_Unit"]; }
            set { this["Speed_Unit"] = value; }
        }
        public Decimal Parent_Item_No
        {
            get { return (Decimal)this["Parent_Item_No"]; }
            set { this["Parent_Item_No"] = value; }
        }
        public String Event_Attr
        {
            get { return (String)this["Event_Attr"]; }
            set { this["Event_Attr"] = value; }
        }
        public Decimal Concentration
        {
            get { return (Decimal)this["Concentration"]; }
            set { this["Concentration"] = value; }
        }
        public String Concentration_Unit
        {
            get { return (String)this["Concentration_Unit"]; }
            set { this["Concentration_Unit"] = value; }
        }
        public Decimal Bill_Attr
        {
            get { return (Decimal)this["Bill_Attr"]; }
            set { this["Bill_Attr"] = value; }
        }
        public String Supplier_Name
        {
            get { return (String)this["Supplier_Name"]; }
            set { this["Supplier_Name"] = value; }
        }
        public Decimal Method_Parent_No
        {
            get { return (Decimal)this["Method_Parent_No"]; }
            set { this["Method_Parent_No"] = value; }
        }

    }
}
