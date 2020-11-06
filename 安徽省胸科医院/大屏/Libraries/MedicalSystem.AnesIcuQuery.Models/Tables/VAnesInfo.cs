using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesIcuQuery.Models
{
    /// <summary>
    /// 麻醉大视图：V_MED_ANES_INFO
    /// </summary>
    [Description("V_MED_ANES_INFO"), Serializable]
    public class VAnesInfo : BaseModel
    {
        public String Patient_Id
        {
            get { return (String)this["Patient_Id"]; }
            set { this["Patient_Id"] = value; }
        }
        public Decimal? Visit_Id
        {
            get { return (Decimal?)this["Visit_Id"]; }
            set { this["Visit_Id"] = value; }
        }
        public Decimal? Oper_Id
        {
            get { return (Decimal?)this["Oper_Id"]; }
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
        public String Operation_Scale_Class
        {
            get { return (String)this["Operation_Scale_Class"]; }
            set { this["Operation_Scale_Class"] = value; }
        }
        public String Diag_After_Operation
        {
            get { return (String)this["Diag_After_Operation"]; }
            set { this["Diag_After_Operation"] = value; }
        }
        public Decimal? Emergency_Indicator
        {
            get { return (Decimal?)this["Emergency_Indicator"]; }
            set { this["Emergency_Indicator"] = value; }
        }
        public String EINDICATOR
        {
            get { return (String)this["EINDICATOR"]; }
            set { this["EINDICATOR"] = value; }
        }
        public Decimal? Isolation_Indicator
        {
            get { return (Decimal?)this["Isolation_Indicator"]; }
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

        /// <summary>
        /// 多个手术医生过滤
        /// </summary>
        public String Oper_Doc
        {
            get { return (String)this["Oper_Doc"]; }
            set { this["Oper_Doc"] = value; }
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
        /// <summary>
        /// 麻醉方式分类，新加入的一个字段,表中不存在为了分组显示
        /// </summary>
        public String Anesthesia_Method_Class
        {
            get { return (String)this["Anesthesia_Method_Class"]; }
            set { this["Anesthesia_Method_Class"] = value; }
        }

        /// <summary>
        /// 多个麻醉医生过滤
        /// </summary>
        public String Anes_Doc
        {
            get { return (String)this["Anes_Doc"]; }
            set { this["Anes_Doc"] = value; }
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
        public Decimal? Nurse_Shift_Indicator
        {
            get { return (Decimal?)this["Nurse_Shift_Indicator"]; }
            set { this["Nurse_Shift_Indicator"] = value; }
        }
        public DateTime? Start_Date_Time
        {
            get { return (DateTime?)this["Start_Date_Time"]; }
            set { this["Start_Date_Time"] = value; }
        }
        public String OPER_DATE
        {
            get { return (String)this["OPER_DATE"]; }
            set { this["OPER_DATE"] = value; }
        }
        public DateTime? End_Date_Time
        {
            get { return (DateTime?)this["End_Date_Time"]; }
            set { this["End_Date_Time"] = value; }
        }
        public Decimal? Satisfaction_Degree
        {
            get { return (Decimal?)this["Satisfaction_Degree"]; }
            set { this["Satisfaction_Degree"] = value; }
        }
        public Decimal? Smooth_Indicator
        {
            get { return (Decimal?)this["Smooth_Indicator"]; }
            set { this["Smooth_Indicator"] = value; }
        }
        public Decimal? In_Fluids_Amount
        {
            get { return (Decimal?)this["In_Fluids_Amount"]; }
            set { this["In_Fluids_Amount"] = value; }
        }
        public Decimal? Out_Fluids_Amount
        {
            get { return (Decimal?)this["Out_Fluids_Amount"]; }
            set { this["Out_Fluids_Amount"] = value; }
        }
        public Decimal? Blood_Lossed
        {
            get { return (Decimal?)this["Blood_Lossed"]; }
            set { this["Blood_Lossed"] = value; }
        }
        public Decimal? Blood_Transfered
        {
            get { return (Decimal?)this["Blood_Transfered"]; }
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
        public Decimal? Order_Transfer
        {
            get { return (Decimal?)this["Order_Transfer"]; }
            set { this["Order_Transfer"] = value; }
        }
        public Decimal? Charge_Transfer
        {
            get { return (Decimal?)this["Charge_Transfer"]; }
            set { this["Charge_Transfer"] = value; }
        }
        public Decimal? End_Indicator
        {
            get { return (Decimal?)this["End_Indicator"]; }
            set { this["End_Indicator"] = value; }
        }
        public String Reck_Group
        {
            get { return (String)this["Reck_Group"]; }
            set { this["Reck_Group"] = value; }
        }
        public Decimal? Oper_Status
        {
            get { return (Decimal?)this["Oper_Status"]; }
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
        public Decimal? Operation_Equip_Indicator
        {
            get { return (Decimal?)this["Operation_Equip_Indicator"]; }
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
        public Decimal? Other_In_Amount
        {
            get { return (Decimal?)this["Other_In_Amount"]; }
            set { this["Other_In_Amount"] = value; }
        }
        public Decimal? Other_Out_Amount
        {
            get { return (Decimal?)this["Other_Out_Amount"]; }
            set { this["Other_Out_Amount"] = value; }
        }
        public DateTime? In_Date_Time
        {
            get { return (DateTime?)this["In_Date_Time"]; }
            set { this["In_Date_Time"] = value; }
        }
        public DateTime? Out_Date_Time
        {
            get { return (DateTime?)this["Out_Date_Time"]; }
            set { this["Out_Date_Time"] = value; }
        }
        public Decimal? Blood_Whole_Self
        {
            get { return (Decimal?)this["Blood_Whole_Self"]; }
            set { this["Blood_Whole_Self"] = value; }
        }
        public Decimal? Blood_Whole
        {
            get { return (Decimal?)this["Blood_Whole"]; }
            set { this["Blood_Whole"] = value; }
        }
        public Decimal? Blood_Rbc
        {
            get { return (Decimal?)this["Blood_Rbc"]; }
            set { this["Blood_Rbc"] = value; }
        }
        public Decimal? Blood_Plasm
        {
            get { return (Decimal?)this["Blood_Plasm"]; }
            set { this["Blood_Plasm"] = value; }
        }
        public Decimal? Blood_Other
        {
            get { return (Decimal?)this["Blood_Other"]; }
            set { this["Blood_Other"] = value; }
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
        public Decimal? Hepatitis_Indicator
        {
            get { return (Decimal?)this["Hepatitis_Indicator"]; }
            set { this["Hepatitis_Indicator"] = value; }
        }
        public DateTime? Anes_Start_Date_Time
        {
            get { return (DateTime?)this["Anes_Start_Date_Time"]; }
            set { this["Anes_Start_Date_Time"] = value; }
        }
        public DateTime? Return_Date_Time
        {
            get { return (DateTime?)this["Return_Date_Time"]; }
            set { this["Return_Date_Time"] = value; }
        }
        public Decimal? Sequence
        {
            get { return (Decimal?)this["Sequence"]; }
            set { this["Sequence"] = value; }
        }
        public DateTime? In_Pacu_Date_Time
        {
            get { return (DateTime?)this["In_Pacu_Date_Time"]; }
            set { this["In_Pacu_Date_Time"] = value; }
        }
        public DateTime? Out_Pacu_Date_Time
        {
            get { return (DateTime?)this["Out_Pacu_Date_Time"]; }
            set { this["Out_Pacu_Date_Time"] = value; }
        }
        public String Pacu_Time
        {
            get { return (String)this["Pacu_Time"]; }
            set { this["Pacu_Time"] = value; }
        }
        public String Operation_Id
        {
            get { return (String)this["Operation_Id"]; }
            set { this["Operation_Id"] = value; }
        }
        public Decimal? Blood_Reuse
        {
            get { return (Decimal?)this["Blood_Reuse"]; }
            set { this["Blood_Reuse"] = value; }
        }
        public Decimal? Self_Blood
        {
            get { return (Decimal?)this["Self_Blood"]; }
            set { this["Self_Blood"] = value; }
        }
        public DateTime? Entered_Datetime
        {
            get { return (DateTime?)this["Entered_Datetime"]; }
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
        public Decimal? Xj
        {
            get { return (Decimal?)this["Xj"]; }
            set { this["Xj"] = value; }
        }
        public Decimal? Ai
        {
            get { return (Decimal?)this["Ai"]; }
            set { this["Ai"] = value; }
        }
        public Decimal? At
        {
            get { return (Decimal?)this["At"]; }
            set { this["At"] = value; }
        }
        public Decimal? Jt
        {
            get { return (Decimal?)this["Jt"]; }
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
        public DateTime? Inquiry_Before_Date
        {
            get { return (DateTime?)this["Inquiry_Before_Date"]; }
            set { this["Inquiry_Before_Date"] = value; }
        }
        public DateTime? Inquiry_After_Date
        {
            get { return (DateTime?)this["Inquiry_After_Date"]; }
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
        public Decimal? Water_Jt1
        {
            get { return (Decimal?)this["Water_Jt1"]; }
            set { this["Water_Jt1"] = value; }
        }
        public Decimal? Water_Jt2
        {
            get { return (Decimal?)this["Water_Jt2"]; }
            set { this["Water_Jt2"] = value; }
        }
        public Decimal? Blood_Xb
        {
            get { return (Decimal?)this["Blood_Xb"]; }
            set { this["Blood_Xb"] = value; }
        }
        public Decimal? Cool_Thing
        {
            get { return (Decimal?)this["Cool_Thing"]; }
            set { this["Cool_Thing"] = value; }
        }
        public Decimal? Cry_Wather
        {
            get { return (Decimal?)this["Cry_Wather"]; }
            set { this["Cry_Wather"] = value; }
        }
        public Decimal? Red_Blood
        {
            get { return (Decimal?)this["Red_Blood"]; }
            set { this["Red_Blood"] = value; }
        }
        public Decimal? Blood_Amount
        {
            get { return (Decimal?)this["Blood_Amount"]; }
            set { this["Blood_Amount"] = value; }
        }
        public DateTime? Scheduled_Date_Time
        {
            get { return (DateTime?)this["Scheduled_Date_Time"]; }
            set { this["Scheduled_Date_Time"] = value; }
        }
        public String Bed_No
        {
            get { return (String)this["Bed_No"]; }
            set { this["Bed_No"] = value; }
        }
        public DateTime? Req_Date_Time
        {
            get { return (DateTime?)this["Req_Date_Time"]; }
            set { this["Req_Date_Time"] = value; }
        }
        public String Qiekou_Class
        {
            get { return (String)this["Qiekou_Class"]; }
            set { this["Qiekou_Class"] = value; }
        }
        public String Qiekou_Class_Class
        {
            get { return (String)this["Qiekou_Class_Class"]; }
            set { this["Qiekou_Class_Class"] = value; }
        }
        public Decimal? Qiekou_Number
        {
            get { return (Decimal?)this["Qiekou_Number"]; }
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
        public DateTime? First_Shift_Supply_Datetime
        {
            get { return (DateTime?)this["First_Shift_Supply_Datetime"]; }
            set { this["First_Shift_Supply_Datetime"] = value; }
        }
        public DateTime? First_Shift_Operation_Datetime
        {
            get { return (DateTime?)this["First_Shift_Operation_Datetime"]; }
            set { this["First_Shift_Operation_Datetime"] = value; }
        }
        public DateTime? Anes_Start_Time
        {
            get { return (DateTime?)this["Anes_Start_Time"]; }
            set { this["Anes_Start_Time"] = value; }
        }
        public DateTime? Anes_End_Time
        {
            get { return (DateTime?)this["Anes_End_Time"]; }
            set { this["Anes_End_Time"] = value; }
        }
        public DateTime? Induce_Start_Time
        {
            get { return (DateTime?)this["Induce_Start_Time"]; }
            set { this["Induce_Start_Time"] = value; }
        }
        public DateTime? Induce_End_Time
        {
            get { return (DateTime?)this["Induce_End_Time"]; }
            set { this["Induce_End_Time"] = value; }
        }
        public DateTime? Pacu_Start_Time
        {
            get { return (DateTime?)this["Pacu_Start_Time"]; }
            set { this["Pacu_Start_Time"] = value; }
        }
        public DateTime? Pacu_End_Time
        {
            get { return (DateTime?)this["Pacu_End_Time"]; }
            set { this["Pacu_End_Time"] = value; }
        }
        public DateTime? Done_Date_Time
        {
            get { return (DateTime?)this["Done_Date_Time"]; }
            set { this["Done_Date_Time"] = value; }
        }
        public DateTime? Cancel_Date_Time
        {
            get { return (DateTime?)this["Cancel_Date_Time"]; }
            set { this["Cancel_Date_Time"] = value; }
        }
        public String Analgesic_Pumps
        {
            get { return (String)this["Analgesic_Pumps"]; }
            set { this["Analgesic_Pumps"] = value; }
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
        public Int32? AGE
        {
            get { return (Int32?)this["AGE"]; }
            set { this["AGE"] = value; }
        }
        public DateTime? Date_Of_Birth
        {
            get { return (DateTime?)this["Date_Of_Birth"]; }
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
        public DateTime? Last_Visit_Date
        {
            get { return (DateTime?)this["Last_Visit_Date"]; }
            set { this["Last_Visit_Date"] = value; }
        }
        public Decimal? Vip_Indicator
        {
            get { return (Decimal?)this["Vip_Indicator"]; }
            set { this["Vip_Indicator"] = value; }
        }
        public DateTime? Create_Date
        {
            get { return (DateTime?)this["Create_Date"]; }
            set { this["Create_Date"] = value; }
        }
        public String Operator
        {
            get { return (String)this["Operator"]; }
            set { this["Operator"] = value; }
        }
        public String Asa_Grade
        {
            get { return (String)this["Asa_Grade"]; }
            set { this["Asa_Grade"] = value; }
        }
        /// <summary>
        /// Asa分级，新加入的一个字段,表中不存在为了分组显示
        /// </summary>
        public String Asa_Grade_Class
        {
            get { return (String)this["Asa_Grade_Class"]; }
            set { this["Asa_Grade_Class"] = value; }
        }
        public String Cancel_Reason
        {
            get { return (String)this["Cancel_Reason"]; }
            set { this["Cancel_Reason"] = value; }
        }
        public String Entered_By_Canceled
        {
            get { return (String)this["Entered_By_Canceled"]; }
            set { this["Entered_By_Canceled"] = value; }
        }

        public DateTime? Canceled_Date_Time
        {
            get { return (DateTime?)this["Canceled_Date_Time"]; }
            set { this["Canceled_Date_Time"] = value; }
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
        public String Pacu_Doctor_Input
        {
            get { return (String)this["Pacu_Doctor_Input"]; }
            set { this["Pacu_Doctor_Input"] = value; }
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
        public Decimal? NO_PLAN_IN_ICU
        {
            get { return (Decimal?)this["NO_PLAN_IN_ICU"]; }
            set { this["NO_PLAN_IN_ICU"] = value; }
        }
        public String PAT_DIRECTION
        {
            get { return (String)this["PAT_DIRECTION"]; }
            set { this["PAT_DIRECTION"] = value; }
        }

        /* 预留属性 */
        public Decimal? Dosage
        {
            get { return (Decimal?)this["Dosage"]; }
            set { this["Dosage"] = value; }
        }
        public String Item_Name
        {
            get { return (String)this["Item_Name"]; }
            set { this["Item_Name"] = value; }
        }
        public String Dosage_Units
        {
            get { return (String)this["Dosage_Units"]; }
            set { this["Dosage_Units"] = value; }
        }

        #region 获取主键的HashCode,便于快速比较匹配。

        /// <summary>
        /// 获取主键的HashCode,便于快速比较匹配。
        /// 主键：Patient_Id,Visit_Id,Oper_Id。
        /// </summary>
        /// <returns></returns>
        public override int GetKeyHashCode()
        {
            if (hashCode == 0)
            {
                hashCode = string.Format("{0},{1},{2}", Patient_Id, Visit_Id, Oper_Id).GetHashCode();
            }
            return hashCode;
        }

        #endregion

    }
}
