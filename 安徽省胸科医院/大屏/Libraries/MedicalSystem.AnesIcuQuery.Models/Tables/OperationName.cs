using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesIcuQuery.Models
{
    /// <summary>
    /// 手术名称字典表：MED_OPERATION_NAME
    /// </summary>
    [Description("MED_OPERATION_NAME")]
    public class OperationName : BaseModel
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
        public Decimal Operation_No
        {
            get { return (Decimal)this["Operation_No"]; }
            set { this["Operation_No"] = value; }
        }
        public String Operation
        {
            get { return (String)this["Operation"]; }
            set { this["Operation"] = value; }
        }
        public String Operation_Code
        {
            get { return (String)this["Operation_Code"]; }
            set { this["Operation_Code"] = value; }
        }
        public String Operation_Scale
        {
            get { return (String)this["Operation_Scale"]; }
            set { this["Operation_Scale"] = value; }
        }
        public String Wound_Grade
        {
            get { return (String)this["Wound_Grade"]; }
            set { this["Wound_Grade"] = value; }
        }
        public String Reserved1
        {
            get { return (String)this["Reserved1"]; }
            set { this["Reserved1"] = value; }
        }
        public String Reserved2
        {
            get { return (String)this["Reserved2"]; }
            set { this["Reserved2"] = value; }
        }
        public String Reserved3
        {
            get { return (String)this["Reserved3"]; }
            set { this["Reserved3"] = value; }
        }
        public String Reserved4
        {
            get { return (String)this["Reserved4"]; }
            set { this["Reserved4"] = value; }
        }
        public Decimal Reserved5
        {
            get { return (Decimal)this["Reserved5"]; }
            set { this["Reserved5"] = value; }
        }
    }
}
