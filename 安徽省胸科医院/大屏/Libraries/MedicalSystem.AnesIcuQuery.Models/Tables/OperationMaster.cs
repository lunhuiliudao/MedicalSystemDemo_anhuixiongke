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
    public class OperationMaster : BaseModel
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
        public String Dept_Stayed
        {
            get { return (String)this["Dept_Stayed"]; }
            set { this["Dept_Stayed"] = value; }
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
        public String Diag_After_Operation
        {
            get { return (String)this["Diag_After_Operation"]; }
            set { this["Diag_After_Operation"] = value; }
        }
        public Decimal Emergency_Indicator
        {
            get { return (Decimal)this["Emergency_Indicator"]; }
            set { this["Emergency_Indicator"] = value; }
        }
        public Decimal Isolation_Indicator
        {
            get { return (Decimal)this["Isolation_Indicator"]; }
            set { this["Isolation_Indicator"] = value; }
        }
        public String Operation_Class
        {
            get { return (String)this["Operation_Class"]; }
            set { this["Operation_Class"] = value; }
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
        public Decimal Nurse_Shift_Indicator
        {
            get { return (Decimal)this["Nurse_Shift_Indicator"]; }
            set { this["Nurse_Shift_Indicator"] = value; }
        }
        public DateTime Start_Date_Time
        {
            get { return (DateTime)this["Start_Date_Time"]; }
            set { this["Start_Date_Time"] = value; }
        }
        public DateTime End_Date_Time
        {
            get { return (DateTime)this["End_Date_Time"]; }
            set { this["End_Date_Time"] = value; }
        }
        public Decimal Satisfaction_Degree
        {
            get { return (Decimal)this["Satisfaction_Degree"]; }
            set { this["Satisfaction_Degree"] = value; }
        }
        public Decimal Smooth_Indicator
        {
            get { return (Decimal)this["Smooth_Indicator"]; }
            set { this["Smooth_Indicator"] = value; }
        }
        public Decimal In_Fluids_Amount
        {
            get { return (Decimal)this["In_Fluids_Amount"]; }
            set { this["In_Fluids_Amount"] = value; }
        }
        public Decimal Out_Fluids_Amount
        {
            get { return (Decimal)this["Out_Fluids_Amount"]; }
            set { this["Out_Fluids_Amount"] = value; }
        }
        public Decimal Blood_Lossed
        {
            get { return (Decimal)this["Blood_Lossed"]; }
            set { this["Blood_Lossed"] = value; }
        }
        public Decimal Blood_Transfered
        {
            get { return (Decimal)this["Blood_Transfered"]; }
            set { this["Blood_Transfered"] = value; }
        }
        public String Entered_By
        {
            get { return (String)this["Entered_By"]; }
            set { this["Entered_By"] = value; }
        }
        public String Third_Supply_Nurse
        {
            get { return (String)this["Third_Supply_Nurse"]; }
            set { this["Third_Supply_Nurse"] = value; }
        }
        public Decimal Order_Transfer
        {
            get { return (Decimal)this["Order_Transfer"]; }
            set { this["Order_Transfer"] = value; }
        }
        public Decimal Charge_Transfer
        {
            get { return (Decimal)this["Charge_Transfer"]; }
            set { this["Charge_Transfer"] = value; }
        }
        public Decimal End_Indicator
        {
            get { return (Decimal)this["End_Indicator"]; }
            set { this["End_Indicator"] = value; }
        }
        public String Reck_Group
        {
            get { return (String)this["Reck_Group"]; }
            set { this["Reck_Group"] = value; }
        }
        public Decimal Oper_Status
        {
            get { return (Decimal)this["Oper_Status"]; }
            set { this["Oper_Status"] = value; }
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
        public String Operation_Position
        {
            get { return (String)this["Operation_Position"]; }
            set { this["Operation_Position"] = value; }
        }
        public Decimal Operation_Equip_Indicator
        {
            get { return (Decimal)this["Operation_Equip_Indicator"]; }
            set { this["Operation_Equip_Indicator"] = value; }
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
        public Decimal Other_In_Amount
        {
            get { return (Decimal)this["Other_In_Amount"]; }
            set { this["Other_In_Amount"] = value; }
        }
        public Decimal Other_Out_Amount
        {
            get { return (Decimal)this["Other_Out_Amount"]; }
            set { this["Other_Out_Amount"] = value; }
        }
        public DateTime In_Date_Time
        {
            get { return (DateTime)this["In_Date_Time"]; }
            set { this["In_Date_Time"] = value; }
        }
        public DateTime Out_Date_Time
        {
            get { return (DateTime)this["Out_Date_Time"]; }
            set { this["Out_Date_Time"] = value; }
        }
        public String Reserved1
        {
            get { return (String)this["Reserved1"]; }
            set { this["Reserved1"] = value; }
        }
        public Decimal Blood_Whole_Self
        {
            get { return (Decimal)this["Blood_Whole_Self"]; }
            set { this["Blood_Whole_Self"] = value; }
        }
        public Decimal Blood_Whole
        {
            get { return (Decimal)this["Blood_Whole"]; }
            set { this["Blood_Whole"] = value; }
        }
        public Decimal Blood_Rbc
        {
            get { return (Decimal)this["Blood_Rbc"]; }
            set { this["Blood_Rbc"] = value; }
        }
        public Decimal Blood_Plasm
        {
            get { return (Decimal)this["Blood_Plasm"]; }
            set { this["Blood_Plasm"] = value; }
        }
        public Decimal Blood_Other
        {
            get { return (Decimal)this["Blood_Other"]; }
            set { this["Blood_Other"] = value; }
        }
        public String Reserved2
        {
            get { return (String)this["Reserved2"]; }
            set { this["Reserved2"] = value; }
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
        public DateTime Anes_Start_Date_Time
        {
            get { return (DateTime)this["Anes_Start_Date_Time"]; }
            set { this["Anes_Start_Date_Time"] = value; }
        }
        public DateTime Return_Date_Time
        {
            get { return (DateTime)this["Return_Date_Time"]; }
            set { this["Return_Date_Time"] = value; }
        }
        public Decimal Sequence
        {
            get { return (Decimal)this["Sequence"]; }
            set { this["Sequence"] = value; }
        }
        public DateTime In_Pacu_Date_Time
        {
            get { return (DateTime)this["In_Pacu_Date_Time"]; }
            set { this["In_Pacu_Date_Time"] = value; }
        }
        public DateTime Out_Pacu_Date_Time
        {
            get { return (DateTime)this["Out_Pacu_Date_Time"]; }
            set { this["Out_Pacu_Date_Time"] = value; }
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
        public Decimal Blood_Reuse
        {
            get { return (Decimal)this["Blood_Reuse"]; }
            set { this["Blood_Reuse"] = value; }
        }
        public Decimal Self_Blood
        {
            get { return (Decimal)this["Self_Blood"]; }
            set { this["Self_Blood"] = value; }
        }
        public DateTime Entered_Datetime
        {
            get { return (DateTime)this["Entered_Datetime"]; }
            set { this["Entered_Datetime"] = value; }
        }
        public String Memo
        {
            get { return (String)this["Memo"]; }
            set { this["Memo"] = value; }
        }
        public String Anesthesia_Id
        {
            get { return (String)this["Anesthesia_Id"]; }
            set { this["Anesthesia_Id"] = value; }
        }
        public Decimal Xj
        {
            get { return (Decimal)this["Xj"]; }
            set { this["Xj"] = value; }
        }
        public Decimal Ai
        {
            get { return (Decimal)this["Ai"]; }
            set { this["Ai"] = value; }
        }
        public Decimal At
        {
            get { return (Decimal)this["At"]; }
            set { this["At"] = value; }
        }
        public Decimal Jt
        {
            get { return (Decimal)this["Jt"]; }
            set { this["Jt"] = value; }
        }
        public String Body_Area
        {
            get { return (String)this["Body_Area"]; }
            set { this["Body_Area"] = value; }
        }
        public String Gas_Pipe
        {
            get { return (String)this["Gas_Pipe"]; }
            set { this["Gas_Pipe"] = value; }
        }
        public String Pat_Leave_Show
        {
            get { return (String)this["Pat_Leave_Show"]; }
            set { this["Pat_Leave_Show"] = value; }
        }
        public String Whole_Anes
        {
            get { return (String)this["Whole_Anes"]; }
            set { this["Whole_Anes"] = value; }
        }
        public String Stop_Anes_Area
        {
            get { return (String)this["Stop_Anes_Area"]; }
            set { this["Stop_Anes_Area"] = value; }
        }
        public String Stop_Anes_Area_Med
        {
            get { return (String)this["Stop_Anes_Area_Med"]; }
            set { this["Stop_Anes_Area_Med"] = value; }
        }
        public String Hole_Piple_Anes
        {
            get { return (String)this["Hole_Piple_Anes"]; }
            set { this["Hole_Piple_Anes"] = value; }
        }
        public String Stop_Anes_Area_Tech
        {
            get { return (String)this["Stop_Anes_Area_Tech"]; }
            set { this["Stop_Anes_Area_Tech"] = value; }
        }
        public String Pin_Size
        {
            get { return (String)this["Pin_Size"]; }
            set { this["Pin_Size"] = value; }
        }
        public String Piple_Up
        {
            get { return (String)this["Piple_Up"]; }
            set { this["Piple_Up"] = value; }
        }
        public String Piple_Down
        {
            get { return (String)this["Piple_Down"]; }
            set { this["Piple_Down"] = value; }
        }
        public String Irritate_Nerve
        {
            get { return (String)this["Irritate_Nerve"]; }
            set { this["Irritate_Nerve"] = value; }
        }
        public String Anes_Range
        {
            get { return (String)this["Anes_Range"]; }
            set { this["Anes_Range"] = value; }
        }
        public String Bak_Med
        {
            get { return (String)this["Bak_Med"]; }
            set { this["Bak_Med"] = value; }
        }
        public String Watch_Anes
        {
            get { return (String)this["Watch_Anes"]; }
            set { this["Watch_Anes"] = value; }
        }
        public String All_Anes_Med_Lead1
        {
            get { return (String)this["All_Anes_Med_Lead1"]; }
            set { this["All_Anes_Med_Lead1"] = value; }
        }
        public String All_Anes_Med_Lead2
        {
            get { return (String)this["All_Anes_Med_Lead2"]; }
            set { this["All_Anes_Med_Lead2"] = value; }
        }
        public String All_Anes_Med_Keep1
        {
            get { return (String)this["All_Anes_Med_Keep1"]; }
            set { this["All_Anes_Med_Keep1"] = value; }
        }
        public String All_Anes_Med_Keep2
        {
            get { return (String)this["All_Anes_Med_Keep2"]; }
            set { this["All_Anes_Med_Keep2"] = value; }
        }
        public String Chest_Water
        {
            get { return (String)this["Chest_Water"]; }
            set { this["Chest_Water"] = value; }
        }
        public String Abdomen_Water
        {
            get { return (String)this["Abdomen_Water"]; }
            set { this["Abdomen_Water"] = value; }
        }
        public DateTime Inquiry_Before_Date
        {
            get { return (DateTime)this["Inquiry_Before_Date"]; }
            set { this["Inquiry_Before_Date"] = value; }
        }
        public DateTime Inquiry_After_Date
        {
            get { return (DateTime)this["Inquiry_After_Date"]; }
            set { this["Inquiry_After_Date"] = value; }
        }
        public String Third_Operation_Nurse
        {
            get { return (String)this["Third_Operation_Nurse"]; }
            set { this["Third_Operation_Nurse"] = value; }
        }
        public String Pacu_Doctor
        {
            get { return (String)this["Pacu_Doctor"]; }
            set { this["Pacu_Doctor"] = value; }
        }
        public Decimal Water_Jt1
        {
            get { return (Decimal)this["Water_Jt1"]; }
            set { this["Water_Jt1"] = value; }
        }
        public Decimal Water_Jt2
        {
            get { return (Decimal)this["Water_Jt2"]; }
            set { this["Water_Jt2"] = value; }
        }
        public Decimal Blood_Xb
        {
            get { return (Decimal)this["Blood_Xb"]; }
            set { this["Blood_Xb"] = value; }
        }
        public Decimal Cool_Thing
        {
            get { return (Decimal)this["Cool_Thing"]; }
            set { this["Cool_Thing"] = value; }
        }
        public Decimal Cry_Wather
        {
            get { return (Decimal)this["Cry_Wather"]; }
            set { this["Cry_Wather"] = value; }
        }
        public Decimal Red_Blood
        {
            get { return (Decimal)this["Red_Blood"]; }
            set { this["Red_Blood"] = value; }
        }
        public Decimal Blood_Amount
        {
            get { return (Decimal)this["Blood_Amount"]; }
            set { this["Blood_Amount"] = value; }
        }
        public DateTime Scheduled_Date_Time
        {
            get { return (DateTime)this["Scheduled_Date_Time"]; }
            set { this["Scheduled_Date_Time"] = value; }
        }
        public String Bed_No
        {
            get { return (String)this["Bed_No"]; }
            set { this["Bed_No"] = value; }
        }
        public DateTime Req_Date_Time
        {
            get { return (DateTime)this["Req_Date_Time"]; }
            set { this["Req_Date_Time"] = value; }
        }
        public String Qiekou_Class
        {
            get { return (String)this["Qiekou_Class"]; }
            set { this["Qiekou_Class"] = value; }
        }
        public Decimal Qiekou_Number
        {
            get { return (Decimal)this["Qiekou_Number"]; }
            set { this["Qiekou_Number"] = value; }
        }
        public String Memo1
        {
            get { return (String)this["Memo1"]; }
            set { this["Memo1"] = value; }
        }
        public String Operation_Name
        {
            get { return (String)this["Operation_Name"]; }
            set { this["Operation_Name"] = value; }
        }
        public String Men_Zhen
        {
            get { return (String)this["Men_Zhen"]; }
            set { this["Men_Zhen"] = value; }
        }
        public String Anesthesia_Result
        {
            get { return (String)this["Anesthesia_Result"]; }
            set { this["Anesthesia_Result"] = value; }
        }
        public String Simple_Sick
        {
            get { return (String)this["Simple_Sick"]; }
            set { this["Simple_Sick"] = value; }
        }
        public String Isolation_Need
        {
            get { return (String)this["Isolation_Need"]; }
            set { this["Isolation_Need"] = value; }
        }
        public String Danbingzhong
        {
            get { return (String)this["Danbingzhong"]; }
            set { this["Danbingzhong"] = value; }
        }
        public String Yibao
        {
            get { return (String)this["Yibao"]; }
            set { this["Yibao"] = value; }
        }
        public String First_Shift_Supply_Nurse
        {
            get { return (String)this["First_Shift_Supply_Nurse"]; }
            set { this["First_Shift_Supply_Nurse"] = value; }
        }
        public String First_Shift_Operation_Nurse
        {
            get { return (String)this["First_Shift_Operation_Nurse"]; }
            set { this["First_Shift_Operation_Nurse"] = value; }
        }
        public DateTime First_Shift_Supply_Datetime
        {
            get { return (DateTime)this["First_Shift_Supply_Datetime"]; }
            set { this["First_Shift_Supply_Datetime"] = value; }
        }
        public DateTime First_Shift_Operation_Datetime
        {
            get { return (DateTime)this["First_Shift_Operation_Datetime"]; }
            set { this["First_Shift_Operation_Datetime"] = value; }
        }
        public DateTime Anes_Start_Time
        {
            get { return (DateTime)this["Anes_Start_Time"]; }
            set { this["Anes_Start_Time"] = value; }
        }
        public DateTime Anes_End_Time
        {
            get { return (DateTime)this["Anes_End_Time"]; }
            set { this["Anes_End_Time"] = value; }
        }
        public DateTime Induce_Start_Time
        {
            get { return (DateTime)this["Induce_Start_Time"]; }
            set { this["Induce_Start_Time"] = value; }
        }
        public DateTime Induce_End_Time
        {
            get { return (DateTime)this["Induce_End_Time"]; }
            set { this["Induce_End_Time"] = value; }
        }
        public DateTime Pacu_Start_Time
        {
            get { return (DateTime)this["Pacu_Start_Time"]; }
            set { this["Pacu_Start_Time"] = value; }
        }
        public DateTime Pacu_End_Time
        {
            get { return (DateTime)this["Pacu_End_Time"]; }
            set { this["Pacu_End_Time"] = value; }
        }
        public DateTime Done_Date_Time
        {
            get { return (DateTime)this["Done_Date_Time"]; }
            set { this["Done_Date_Time"] = value; }
        }
        public DateTime Cancel_Date_Time
        {
            get { return (DateTime)this["Cancel_Date_Time"]; }
            set { this["Cancel_Date_Time"] = value; }
        }
        public String Analgesic_Pumps
        {
            get { return (String)this["Analgesic_Pumps"]; }
            set { this["Analgesic_Pumps"] = value; }
        }

    }
}
