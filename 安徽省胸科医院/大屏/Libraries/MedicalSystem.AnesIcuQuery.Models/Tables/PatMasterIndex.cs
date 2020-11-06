using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesIcuQuery.Models
{
    /// <summary>
    /// 患者基本信息：MED_PAT_MASTER_INDEX
    /// </summary>
    [Description("MED_PAT_MASTER_INDEX")]
    public class PatMasterIndex : BaseModel
    {
        public String Patient_Id
        {
            get { return (String)this["Patient_Id"]; }
            set { this["Patient_Id"] = value; }
        }
        public String Inp_No
        {
            get { return (String)this["Inp_No"]; }
            set { this["Inp_No"] = value; }
        }
        public String Name
        {
            get { return (String)this["Name"]; }
            set { this["Name"] = value; }
        }
        public String Name_Phonetic
        {
            get { return (String)this["Name_Phonetic"]; }
            set { this["Name_Phonetic"] = value; }
        }
        public String Sex
        {
            get { return (String)this["Sex"]; }
            set { this["Sex"] = value; }
        }
        public DateTime Date_Of_Birth
        {
            get { return (DateTime)this["Date_Of_Birth"]; }
            set { this["Date_Of_Birth"] = value; }
        }
        public String Birth_Place
        {
            get { return (String)this["Birth_Place"]; }
            set { this["Birth_Place"] = value; }
        }
        public String Citizenship
        {
            get { return (String)this["Citizenship"]; }
            set { this["Citizenship"] = value; }
        }
        public String Nation
        {
            get { return (String)this["Nation"]; }
            set { this["Nation"] = value; }
        }
        public String Id_No
        {
            get { return (String)this["Id_No"]; }
            set { this["Id_No"] = value; }
        }
        public String Identity
        {
            get { return (String)this["Identity"]; }
            set { this["Identity"] = value; }
        }
        public String Charge_Type
        {
            get { return (String)this["Charge_Type"]; }
            set { this["Charge_Type"] = value; }
        }
        public String Unit_In_Contract
        {
            get { return (String)this["Unit_In_Contract"]; }
            set { this["Unit_In_Contract"] = value; }
        }
        public String Mailing_Address
        {
            get { return (String)this["Mailing_Address"]; }
            set { this["Mailing_Address"] = value; }
        }
        public String Zip_Code
        {
            get { return (String)this["Zip_Code"]; }
            set { this["Zip_Code"] = value; }
        }
        public String Phone_Number_Home
        {
            get { return (String)this["Phone_Number_Home"]; }
            set { this["Phone_Number_Home"] = value; }
        }
        public String Phone_Number_Business
        {
            get { return (String)this["Phone_Number_Business"]; }
            set { this["Phone_Number_Business"] = value; }
        }
        public String Next_Of_Kin
        {
            get { return (String)this["Next_Of_Kin"]; }
            set { this["Next_Of_Kin"] = value; }
        }
        public String Relationship
        {
            get { return (String)this["Relationship"]; }
            set { this["Relationship"] = value; }
        }
        public String Next_Of_Kin_Addr
        {
            get { return (String)this["Next_Of_Kin_Addr"]; }
            set { this["Next_Of_Kin_Addr"] = value; }
        }
        public String Next_Of_Kin_Zip_Code
        {
            get { return (String)this["Next_Of_Kin_Zip_Code"]; }
            set { this["Next_Of_Kin_Zip_Code"] = value; }
        }
        public String Next_Of_Kin_Phone
        {
            get { return (String)this["Next_Of_Kin_Phone"]; }
            set { this["Next_Of_Kin_Phone"] = value; }
        }
        public DateTime Last_Visit_Date
        {
            get { return (DateTime)this["Last_Visit_Date"]; }
            set { this["Last_Visit_Date"] = value; }
        }
        public Decimal Vip_Indicator
        {
            get { return (Decimal)this["Vip_Indicator"]; }
            set { this["Vip_Indicator"] = value; }
        }
        public DateTime Create_Date
        {
            get { return (DateTime)this["Create_Date"]; }
            set { this["Create_Date"] = value; }
        }
        public String Operator
        {
            get { return (String)this["Operator"]; }
            set { this["Operator"] = value; }
        }
    }
}
