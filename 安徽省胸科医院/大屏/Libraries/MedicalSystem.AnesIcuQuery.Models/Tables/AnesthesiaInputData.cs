using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Dapper.Data;

namespace MedicalSystem.AnesIcuQuery.Models
{
    /// <summary>
    /// 用户输入的信息表：MED_ANESTHESIA_INPUT_DATA
    /// </summary>
    [Description("MED_ANESTHESIA_INPUT_DATA")]
    [Table("MED_ANESTHESIA_INPUT_DATA")]
    public class AnesthesiaInputData : BaseModel
    {
        [Key]
        public String Patient_Id
        {
            get { return (String)this["Patient_Id"]; }
            set { this["Patient_Id"] = value; }
        }
        [Key]
        public Decimal? Visit_Id
        {
            get { return (Decimal?)this["Visit_Id"]; }
            set { this["Visit_Id"] = value; }
        }
        [Key]
        public Decimal? Oper_Id
        {
            get { return (Decimal?)this["Oper_Id"]; }
            set { this["Oper_Id"] = value; }
        }
        public String Canceled_Type
        {
            get { return (String)this["Canceled_Type"]; }
            set { this["Canceled_Type"] = value; }
        }
        public Decimal? Pacu_Temperature
        {
            get { return (Decimal?)this["Pacu_Temperature"]; }
            set { this["Pacu_Temperature"] = value; }
        }
        public Decimal? In_Icu
        {
            get { return (Decimal?)this["In_Icu"]; }
            set { this["In_Icu"] = value; }
        }
        public Decimal? Trachea_6H
        {
            get { return (Decimal?)this["Trachea_6H"]; }
            set { this["Trachea_6H"] = value; }
        }
        public Decimal? Trachea_Remove
        {
            get { return (Decimal?)this["Trachea_Remove"]; }
            set { this["Trachea_Remove"] = value; }
        }
        public Decimal? Anes_Start_24H_Death
        {
            get { return (Decimal?)this["Anes_Start_24H_Death"]; }
            set { this["Anes_Start_24H_Death"] = value; }
        }
        public Decimal? Anes_Start_24H_Stop
        {
            get { return (Decimal?)this["Anes_Start_24H_Stop"]; }
            set { this["Anes_Start_24H_Stop"] = value; }
        }
        public Decimal? Anes_Anaphylaxis
        {
            get { return (Decimal?)this["Anes_Anaphylaxis"]; }
            set { this["Anes_Anaphylaxis"] = value; }
        }
        public Decimal? Spinal_Anes_Comp
        {
            get { return (Decimal?)this["Spinal_Anes_Comp"]; }
            set { this["Spinal_Anes_Comp"] = value; }
        }
        public Decimal? Central_Venous
        {
            get { return (Decimal?)this["Central_Venous"]; }
            set { this["Central_Venous"] = value; }
        }
        public Decimal? Spinal_Anes
        {
            get { return (Decimal?)this["Spinal_Anes"]; }
            set { this["Spinal_Anes"] = value; }
        }
        public Decimal? Trachea_Hoarse
        {
            get { return (Decimal?)this["Trachea_Hoarse"]; }
            set { this["Trachea_Hoarse"] = value; }
        }
        public Decimal? After_Anes_Coma
        {
            get { return (Decimal?)this["After_Anes_Coma"]; }
            set { this["After_Anes_Coma"] = value; }
        }
        public Decimal? Gen_Anes_Trachea
        {
            get { return (Decimal?)this["Gen_Anes_Trachea"]; }
            set { this["Gen_Anes_Trachea"] = value; }
        }
        public String Pacu_Situation
        {
            get { return (String)this["Pacu_Situation"]; }
            set { this["Pacu_Situation"] = value; }
        }
        public Decimal? Pacu_Steward
        {
            get { return (Decimal?)this["Pacu_Steward"]; }
            set { this["Pacu_Steward"] = value; }
        }
        public String Pacu_Doctor
        {
            get { return (String)this["Pacu_Doctor"]; }
            set { this["Pacu_Doctor"] = value; }
        }
        public String Pacu_Nurse
        {
            get { return (String)this["Pacu_Nurse"]; }
            set { this["Pacu_Nurse"] = value; }
        }
        public String Analgesia_Pump
        {
            get { return (String)this["Analgesia_Pump"]; }
            set { this["Analgesia_Pump"] = value; }
        }
        public String Analgesia_Method
        {
            get { return (String)this["Analgesia_Method"]; }
            set { this["Analgesia_Method"] = value; }
        }
        public String Analgesia_Drugs
        {
            get { return (String)this["Analgesia_Drugs"]; }
            set { this["Analgesia_Drugs"] = value; }
        }
        public String Analgesia_Effect
        {
            get { return (String)this["Analgesia_Effect"]; }
            set { this["Analgesia_Effect"] = value; }
        }
        public Decimal? Extra_Circulation
        {
            get { return (Decimal?)this["Extra_Circulation"]; }
            set { this["Extra_Circulation"] = value; }
        }
        public Decimal? Analgesia_Therapy
        {
            get { return (Decimal?)this["Analgesia_Therapy"]; }
            set { this["Analgesia_Therapy"] = value; }
        }
        public Decimal? After_Analgesia
        {
            get { return (Decimal?)this["After_Analgesia"]; }
            set { this["After_Analgesia"] = value; }
        }
        public Decimal? Monary_Res
        {
            get { return (Decimal?)this["Monary_Res"]; }
            set { this["Monary_Res"] = value; }
        }
        public Decimal? Monary_Res_Ok
        {
            get { return (Decimal?)this["Monary_Res_Ok"]; }
            set { this["Monary_Res_Ok"] = value; }
        }
        public Decimal? Cons_Disturbance
        {
            get { return (Decimal?)this["Cons_Disturbance"]; }
            set { this["Cons_Disturbance"] = value; }
        }
        public Decimal? Oxygen_Saturation
        {
            get { return (Decimal?)this["Oxygen_Saturation"]; }
            set { this["Oxygen_Saturation"] = value; }
        }
        public Decimal? Use_Reminders
        {
            get { return (Decimal?)this["Use_Reminders"]; }
            set { this["Use_Reminders"] = value; }
        }
        public Decimal? Res_Tract_Obstruce
        {
            get { return (Decimal?)this["Res_Tract_Obstruce"]; }
            set { this["Res_Tract_Obstruce"] = value; }
        }
        public Decimal? Anes_Death
        {
            get { return (Decimal?)this["Anes_Death"]; }
            set { this["Anes_Death"] = value; }
        }
        public Decimal? Other_Not_Exp
        {
            get { return (Decimal?)this["Other_Not_Exp"]; }
            set { this["Other_Not_Exp"] = value; }
        }
        public Decimal? Death_After_Oper
        {
            get { return (Decimal?)this["Death_After_Oper"]; }
            set { this["Death_After_Oper"] = value; }
        }
        public Decimal? No_Plan_In_Icu
        {
            get { return (Decimal?)this["No_Plan_In_Icu"]; }
            set { this["No_Plan_In_Icu"] = value; }
        }
        public String Pat_Direction
        {
            get { return (String)this["Pat_Direction"]; }
            set { this["Pat_Direction"] = value; }
        }
    }
}
