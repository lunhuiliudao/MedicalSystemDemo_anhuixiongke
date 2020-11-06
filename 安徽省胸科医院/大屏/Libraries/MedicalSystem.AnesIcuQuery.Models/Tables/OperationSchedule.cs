using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesIcuQuery.Models
{
    /// <summary>
    /// 手术安排表：MED_OPERATION_SCHEDULE
    /// </summary>
    [Description("MED_OPERATION_SCHEDULE")]
    public class OperationSchedule : BaseModel
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
        public Decimal Schedule_Id
        {
            get { return (Decimal)this["Schedule_Id"]; }
            set { this["Schedule_Id"] = value; }
        }
        public String Dept_Stayed
        {
            get { return (String)this["Dept_Stayed"]; }
            set { this["Dept_Stayed"] = value; }
        }
        public String Bed_No
        {
            get { return (String)this["Bed_No"]; }
            set { this["Bed_No"] = value; }
        }
        public DateTime Scheduled_Date_Time
        {
            get { return (DateTime)this["Scheduled_Date_Time"]; }
            set { this["Scheduled_Date_Time"] = value; }
        }
        public String Operating_Room
        {
            get { return (String)this["Operating_Room"]; }
            set { this["Operating_Room"] = value; }
        }
        public String Operating_Room_No
        {
            get { return (String)this["Operating_Room_No"]; }
            set { this["Operating_Room_No"] = value; }
        }
        public Decimal Sequence
        {
            get { return (Decimal)this["Sequence"]; }
            set { this["Sequence"] = value; }
        }
        public String Diag_Before_Operation
        {
            get { return (String)this["Diag_Before_Operation"]; }
            set { this["Diag_Before_Operation"] = value; }
        }
        public String Patient_Condition
        {
            get { return (String)this["Patient_Condition"]; }
            set { this["Patient_Condition"] = value; }
        }
        public String Operation_Scale
        {
            get { return (String)this["Operation_Scale"]; }
            set { this["Operation_Scale"] = value; }
        }
        public Decimal Isolation_Indicator
        {
            get { return (Decimal)this["Isolation_Indicator"]; }
            set { this["Isolation_Indicator"] = value; }
        }
        public String Operating_Dept
        {
            get { return (String)this["Operating_Dept"]; }
            set { this["Operating_Dept"] = value; }
        }
        public String Surgeon
        {
            get { return (String)this["Surgeon"]; }
            set { this["Surgeon"] = value; }
        }
        public String First_Assistant
        {
            get { return (String)this["First_Assistant"]; }
            set { this["First_Assistant"] = value; }
        }
        public String Second_Assistant
        {
            get { return (String)this["Second_Assistant"]; }
            set { this["Second_Assistant"] = value; }
        }
        public String Third_Assistant
        {
            get { return (String)this["Third_Assistant"]; }
            set { this["Third_Assistant"] = value; }
        }
        public String Fourth_Assistant
        {
            get { return (String)this["Fourth_Assistant"]; }
            set { this["Fourth_Assistant"] = value; }
        }
        public String Anesthesia_Method
        {
            get { return (String)this["Anesthesia_Method"]; }
            set { this["Anesthesia_Method"] = value; }
        }
        public String Anesthesia_Doctor
        {
            get { return (String)this["Anesthesia_Doctor"]; }
            set { this["Anesthesia_Doctor"] = value; }
        }
        public String Anesthesia_Assistant
        {
            get { return (String)this["Anesthesia_Assistant"]; }
            set { this["Anesthesia_Assistant"] = value; }
        }
        public String Blood_Tran_Doctor
        {
            get { return (String)this["Blood_Tran_Doctor"]; }
            set { this["Blood_Tran_Doctor"] = value; }
        }
        public String First_Operation_Nurse
        {
            get { return (String)this["First_Operation_Nurse"]; }
            set { this["First_Operation_Nurse"] = value; }
        }
        public String Second_Operation_Nurse
        {
            get { return (String)this["Second_Operation_Nurse"]; }
            set { this["Second_Operation_Nurse"] = value; }
        }
        public String First_Supply_Nurse
        {
            get { return (String)this["First_Supply_Nurse"]; }
            set { this["First_Supply_Nurse"] = value; }
        }
        public String Second_Supply_Nurse
        {
            get { return (String)this["Second_Supply_Nurse"]; }
            set { this["Second_Supply_Nurse"] = value; }
        }
        public String Notes_On_Operation
        {
            get { return (String)this["Notes_On_Operation"]; }
            set { this["Notes_On_Operation"] = value; }
        }
        public String Entered_By
        {
            get { return (String)this["Entered_By"]; }
            set { this["Entered_By"] = value; }
        }
        public DateTime Req_Date_Time
        {
            get { return (DateTime)this["Req_Date_Time"]; }
            set { this["Req_Date_Time"] = value; }
        }
        public String Third_Supply_Nurse
        {
            get { return (String)this["Third_Supply_Nurse"]; }
            set { this["Third_Supply_Nurse"] = value; }
        }
        public Decimal Ack_Indicator
        {
            get { return (Decimal)this["Ack_Indicator"]; }
            set { this["Ack_Indicator"] = value; }
        }
        public Decimal Emergency_Indicator
        {
            get { return (Decimal)this["Emergency_Indicator"]; }
            set { this["Emergency_Indicator"] = value; }
        }
        public String Reck_Group
        {
            get { return (String)this["Reck_Group"]; }
            set { this["Reck_Group"] = value; }
        }
        public Decimal Oper_Id
        {
            get { return (Decimal)this["Oper_Id"]; }
            set { this["Oper_Id"] = value; }
        }
        public String Second_Anesthesia_Assistant
        {
            get { return (String)this["Second_Anesthesia_Assistant"]; }
            set { this["Second_Anesthesia_Assistant"] = value; }
        }
        public String Third_Anesthesia_Assistant
        {
            get { return (String)this["Third_Anesthesia_Assistant"]; }
            set { this["Third_Anesthesia_Assistant"] = value; }
        }
        public String Fourth_Anesthesia_Assistant
        {
            get { return (String)this["Fourth_Anesthesia_Assistant"]; }
            set { this["Fourth_Anesthesia_Assistant"] = value; }
        }
        public String Second_Anesthesia_Doctor
        {
            get { return (String)this["Second_Anesthesia_Doctor"]; }
            set { this["Second_Anesthesia_Doctor"] = value; }
        }
        public String Third_Anesthesia_Doctor
        {
            get { return (String)this["Third_Anesthesia_Doctor"]; }
            set { this["Third_Anesthesia_Doctor"] = value; }
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
        public String Operation_Position
        {
            get { return (String)this["Operation_Position"]; }
            set { this["Operation_Position"] = value; }
        }
        public String Special_Equipment
        {
            get { return (String)this["Special_Equipment"]; }
            set { this["Special_Equipment"] = value; }
        }
        public String Special_Infect
        {
            get { return (String)this["Special_Infect"]; }
            set { this["Special_Infect"] = value; }
        }
        public Decimal Hepatitis_Indicator
        {
            get { return (Decimal)this["Hepatitis_Indicator"]; }
            set { this["Hepatitis_Indicator"] = value; }
        }
        public String Operation_Id
        {
            get { return (String)this["Operation_Id"]; }
            set { this["Operation_Id"] = value; }
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
        public String Reserved5
        {
            get { return (String)this["Reserved5"]; }
            set { this["Reserved5"] = value; }
        }
        public String Reserved6
        {
            get { return (String)this["Reserved6"]; }
            set { this["Reserved6"] = value; }
        }
        public String Reserved7
        {
            get { return (String)this["Reserved7"]; }
            set { this["Reserved7"] = value; }
        }
        public String Reserved8
        {
            get { return (String)this["Reserved8"]; }
            set { this["Reserved8"] = value; }
        }
        public DateTime Reserved9
        {
            get { return (DateTime)this["Reserved9"]; }
            set { this["Reserved9"] = value; }
        }
        public DateTime Reserved10
        {
            get { return (DateTime)this["Reserved10"]; }
            set { this["Reserved10"] = value; }
        }
        public Decimal Reserved11
        {
            get { return (Decimal)this["Reserved11"]; }
            set { this["Reserved11"] = value; }
        }
        public Decimal Reserved12
        {
            get { return (Decimal)this["Reserved12"]; }
            set { this["Reserved12"] = value; }
        }
        public String Third_Operation_Nurse
        {
            get { return (String)this["Third_Operation_Nurse"]; }
            set { this["Third_Operation_Nurse"] = value; }
        }
        public Decimal State
        {
            get { return (Decimal)this["State"]; }
            set { this["State"] = value; }
        }
        public String Operation_Name
        {
            get { return (String)this["Operation_Name"]; }
            set { this["Operation_Name"] = value; }
        }
        public Decimal Operating_Time
        {
            get { return (Decimal)this["Operating_Time"]; }
            set { this["Operating_Time"] = value; }
        }
    }
}
