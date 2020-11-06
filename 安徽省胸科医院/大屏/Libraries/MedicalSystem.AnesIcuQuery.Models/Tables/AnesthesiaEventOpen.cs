using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesIcuQuery.Models
{
    /// <summary>
    /// 麻醉事件定义：MED_ANESTHESIA_EVENT_OPEN
    /// </summary>
    [Description("MED_ANESTHESIA_EVENT_OPEN")]
    public class AnesthesiaEventOpen : BaseModel
    {
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
        public Decimal Dosage
        {
            get { return (Decimal)this["Dosage"]; }
            set { this["Dosage"] = value; }
        }
        public String Dosage_Units
        {
            get { return (String)this["Dosage_Units"]; }
            set { this["Dosage_Units"] = value; }
        }
        public String Administrator
        {
            get { return (String)this["Administrator"]; }
            set { this["Administrator"] = value; }
        }
        public Decimal In_Order
        {
            get { return (Decimal)this["In_Order"]; }
            set { this["In_Order"] = value; }
        }
        public Decimal Rel_Bill
        {
            get { return (Decimal)this["Rel_Bill"]; }
            set { this["Rel_Bill"] = value; }
        }
        public String Oper_Class
        {
            get { return (String)this["Oper_Class"]; }
            set { this["Oper_Class"] = value; }
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
        public String Event_Attr2
        {
            get { return (String)this["Event_Attr2"]; }
            set { this["Event_Attr2"] = value; }
        }
        public String Supplier_Name
        {
            get { return (String)this["Supplier_Name"]; }
            set { this["Supplier_Name"] = value; }
        }
        public Decimal Standard_Dosage1
        {
            get { return (Decimal)this["Standard_Dosage1"]; }
            set { this["Standard_Dosage1"] = value; }
        }
        public Decimal Standard_Dosage2
        {
            get { return (Decimal)this["Standard_Dosage2"]; }
            set { this["Standard_Dosage2"] = value; }
        }
        public Decimal Standard_Dosage3
        {
            get { return (Decimal)this["Standard_Dosage3"]; }
            set { this["Standard_Dosage3"] = value; }
        }
        public Decimal Standard_Dosage4
        {
            get { return (Decimal)this["Standard_Dosage4"]; }
            set { this["Standard_Dosage4"] = value; }
        }
        public Decimal Standard_Dosage5
        {
            get { return (Decimal)this["Standard_Dosage5"]; }
            set { this["Standard_Dosage5"] = value; }
        }
        public Decimal Standard_Dosage6
        {
            get { return (Decimal)this["Standard_Dosage6"]; }
            set { this["Standard_Dosage6"] = value; }
        }
        public Decimal Standard_Dosage7
        {
            get { return (Decimal)this["Standard_Dosage7"]; }
            set { this["Standard_Dosage7"] = value; }
        }
        public Decimal Standard_Dosage8
        {
            get { return (Decimal)this["Standard_Dosage8"]; }
            set { this["Standard_Dosage8"] = value; }
        }
        public Decimal Standard_Dosage9
        {
            get { return (Decimal)this["Standard_Dosage9"]; }
            set { this["Standard_Dosage9"] = value; }
        }
        public Decimal Standard_Dosage10
        {
            get { return (Decimal)this["Standard_Dosage10"]; }
            set { this["Standard_Dosage10"] = value; }
        }
        public Decimal Standard_Dosage11
        {
            get { return (Decimal)this["Standard_Dosage11"]; }
            set { this["Standard_Dosage11"] = value; }
        }
        public Decimal Standard_Dosage12
        {
            get { return (Decimal)this["Standard_Dosage12"]; }
            set { this["Standard_Dosage12"] = value; }
        }
        public Decimal Standard_Dosage13
        {
            get { return (Decimal)this["Standard_Dosage13"]; }
            set { this["Standard_Dosage13"] = value; }
        }
        public Decimal Standard_Dosage14
        {
            get { return (Decimal)this["Standard_Dosage14"]; }
            set { this["Standard_Dosage14"] = value; }
        }
        public Decimal Standard_Dosage15
        {
            get { return (Decimal)this["Standard_Dosage15"]; }
            set { this["Standard_Dosage15"] = value; }
        }
    }
}
