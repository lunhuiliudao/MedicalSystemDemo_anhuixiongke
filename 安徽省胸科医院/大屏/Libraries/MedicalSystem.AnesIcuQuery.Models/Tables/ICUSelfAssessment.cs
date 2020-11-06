using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using Dapper.Data;

namespace MedicalSystem.AnesIcuQuery.Models
{
    [Table("med_self_assessment")]
    public class ICUSelfAssessment : BaseModel
    {
        /// <summary>
        /// 病人ID
        /// </summary>
        [Key]
        public String Patient_Id
        {
            get { return (String)this["Patient_Id"];}
            set { this["Patient_Id"] = value; }
        }

        /// <summary>
        /// 入院次数
        /// </summary>
        [Key]
        public Decimal? Visit_Id
        {
            get { return (Decimal?)this["Visit_Id"]; }
            set { this["Visit_Id"] = value; }
        }

        /// <summary>
        /// 入科次数
        /// </summary>
        [Key]
        public Decimal? Dep_Id
        {
            get { return (Decimal?)this["Dep_Id"]; }
            set { this["Dep_Id"] = value; }
        }

        /// <summary>
        /// 3H感染休克
        /// </summary>
        public String Infect_Shock_3H
        {
            get { return (String)this["Infect_Shock_3H"]; }
            set { this["Infect_Shock_3H"] = value; }
        }

        /// <summary>
        /// 3H测乳酸
        /// </summary>
        public String Lactic_Acid_3H
        {
            get { return (String)this["Lactic_Acid_3H"]; }
            set { this["Lactic_Acid_3H"] = value; }
        }

        /// <summary>
        /// 3H血培养
        /// </summary>
        public String Blood_Culture_3H
        {
            get { return (String)this["Blood_Culture_3H"]; }
            set { this["Blood_Culture_3H"] = value; }
        }

        /// <summary>
        /// 3H抗菌药
        /// </summary>
        public String Antibacterial_Drug_3H
        {
            get { return (String)this["Antibacterial_Drug_3H"]; }
            set { this["Antibacterial_Drug_3H"] = value; }
        }

        /// <summary>
        /// 3H晶体液
        /// </summary>
        public String Crystalloid_Solutions_3H
        {
            get { return (String)this["Crystalloid_Solutions_3H"]; }
            set { this["Crystalloid_Solutions_3H"] = value; }
        }

        /// <summary>
        /// 3H完成
        /// </summary>
        public String Complete_3H
        {
            get { return (String)this["Complete_3H"]; }
            set { this["Complete_3H"] = value; }
        }

        /// <summary>
        /// 3H没完成
        /// </summary>
        public String Uncomplete_3H
        {
            get { return (String)this["Uncomplete_3H"]; }
            set { this["Uncomplete_3H"] = value; }
        }

        /// <summary>
        /// 6H感染休克
        /// </summary>
        public String Infect_Shock_6H
        {
            get { return (String)this["Infect_Shock_6H"]; }
            set { this["Infect_Shock_6H"] = value; }
        }

        /// <summary>
        /// 6H测乳酸
        /// </summary>
        public String Lactic_Acid_6H
        {
            get { return (String)this["Lactic_Acid_6H"]; }
            set { this["Lactic_Acid_6H"] = value; }
        }

        /// <summary>
        /// 6H血培养
        /// </summary>
        public String Blood_Culture_6H
        {
            get { return (String)this["Blood_Culture_6H"]; }
            set { this["Blood_Culture_6H"] = value; }
        }

        /// <summary>
        /// 6H抗菌药
        /// </summary>
        public String Antibacterial_Drug_6H
        {
            get { return (String)this["Antibacterial_Drug_6H"]; }
            set { this["Antibacterial_Drug_6H"] = value; }
        }

        /// <summary>
        /// 6H晶体液
        /// </summary>
        public String Crystalloid_Solutions_6H
        {
            get { return (String)this["Crystalloid_Solutions_6H"]; }
            set { this["Crystalloid_Solutions_6H"] = value; }
        }

        /// <summary>
        /// 6H升压药
        /// </summary>
        public String Vasopressor_6H
        {
            get { return (String)this["Vasopressor_6H"]; }
            set { this["Vasopressor_6H"] = value; }
        }

        /// <summary>
        /// 6HCVP
        /// </summary>
        public String Cvp_6H
        {
            get { return (String)this["Cvp_6H"]; }
            set { this["Cvp_6H"] = value; }
        }

        /// <summary>
        /// 6H再测乳酸
        /// </summary>
        public String Re_Lactic_Acid_6H
        {
            get { return (String)this["Re_Lactic_Acid_6H"]; }
            set { this["Re_Lactic_Acid_6H"] = value; }
        }

        /// <summary>
        /// 6H完成
        /// </summary>
        public String Complete_6H
        {
            get { return (String)this["Complete_6H"]; }
            set { this["Complete_6H"] = value; }
        }

        /// <summary>
        /// 6H没完成
        /// </summary>
        public String Uncomplete_6H
        {
            get { return (String)this["Uncomplete_6H"]; }
            set { this["Uncomplete_6H"] = value; }
        }

        /// <summary>
        /// 使用抗菌药物
        /// </summary>
        public String Use_Antibacterial_Drug
        {
            get { return (String)this["Use_Antibacterial_Drug"]; }
            set { this["Use_Antibacterial_Drug"] = value; }
        }

        /// <summary>
        /// 送检
        /// </summary>
        public String Submit_For_Censorship
        {
            get { return (String)this["Submit_For_Censorship"]; }
            set { this["Submit_For_Censorship"] = value; }
        }

        /// <summary>
        /// dvt预防
        /// </summary>
        public String Use_Dvt
        {
            get { return (String)this["Use_Dvt"]; }
            set { this["Use_Dvt"] = value; }
        }

        /// <summary>
        /// 是否死亡（统计ICU死亡人数）
        /// </summary>
        public String Is_Death
        {
            get { return (String)this["Is_Death"]; }
            set { this["Is_Death"] = value; }
        }

        /// <summary>
        /// 非计划气管插管拔管
        /// </summary>
        public String Unplanned_Trachea
        {
            get { return (String)this["Unplanned_Trachea"]; }
            set { this["Unplanned_Trachea"] = value; }
        }

        /// <summary>
        /// ICU气管插管拔管
        /// </summary>
        public String Trachea
        {
            get { return (String)this["Trachea"]; }
            set { this["Trachea"] = value; }
        }

        /// <summary>
        /// 气管插管计划拔管后48h内再插管例数
        /// </summary>
        public String In48Hours_Intubation
        {
            get { return (String)this["In48Hours_Intubation"]; }
            set { this["In48Hours_Intubation"] = value; }
        }

        /// <summary>
        /// 非计划转入ICU患者数
        /// </summary>
        public String Unplanned_In_Icu
        {
            get { return (String)this["Unplanned_In_Icu"]; }
            set { this["Unplanned_In_Icu"] = value; }
        }

        /// <summary>
        /// 转出ICU后48h内重返ICU的患者数
        /// </summary>
        public String Return48Hour_In_Icu
        {
            get { return (String)this["Return48Hour_In_Icu"]; }
            set { this["Return48Hour_In_Icu"] = value; }
        }

        /// <summary>
        /// 呼吸机相关肺炎（VAP）感染
        /// </summary>
        public String Is_Vap
        {
            get { return (String)this["Is_Vap"]; }
            set { this["Is_Vap"] = value; }
        }

        /// <summary>
        /// 有创机械通气天数
        /// </summary>
        public Decimal? Vap_Day
        {
            get { return (Decimal?)this["Vap_Day"]; }
            set { this["Vap_Day"] = value; }
        }

        /// <summary>
        /// 血管内导管相关血流感染（CRBSI）
        /// </summary>
        public String Is_Crbsi
        {
            get { return (String)this["Is_Crbsi"]; }
            set { this["Is_Crbsi"] = value; }
        }

        /// <summary>
        /// 血管内导管留置天数
        /// </summary>
        public Decimal? Crbsi_Day
        {
            get { return (Decimal?)this["Crbsi_Day"]; }
            set { this["Crbsi_Day"] = value; }
        }

        /// <summary>
        /// 导尿管相关泌尿系感染（CAUTI）
        /// </summary>
        public String Is_Cauti
        {
            get { return (String)this["Is_Cauti"]; }
            set { this["Is_Cauti"] = value; }
        }

        /// <summary>
        /// 导尿管留置天数
        /// </summary>
        public Decimal? Cauti_Day
        {
            get { return (Decimal?)this["Cauti_Day"]; }
            set { this["Cauti_Day"] = value; }
        }

        /// <summary>
        /// 操作人
        /// </summary>
        public String Operator
        {
            get { return (String)this["Operator"]; }
            set { this["Operator"] = value; }
        }

        /// <summary>
        /// 操作日期
        /// </summary>
        public DateTime? Record_Date
        {
            get { return (DateTime?)this["Record_Date"]; }
            set { this["Record_Date"] = value; }
        }

        /// <summary>
        /// 预留1
        /// </summary>
        public String Reserved01
        {
            get { return (String)this["Reserved01"]; }
            set { this["Reserved01"] = value; }
        }

        /// <summary>
        /// 预留2
        /// </summary>
        public String Reserved02
        {
            get { return (String)this["Reserved02"]; }
            set { this["Reserved02"] = value; }
        }

        /// <summary>
        /// 预留3
        /// </summary>
        public String Reserved03
        {
            get { return (String)this["Reserved03"]; }
            set { this["Reserved03"] = value; }
        }

        /// <summary>
        /// 预留4
        /// </summary>
        public String Reserved04
        {
            get { return (String)this["Reserved04"]; }
            set { this["Reserved04"] = value; }
        }

        /// <summary>
        /// 预留5
        /// </summary>
        public String Reserved05
        {
            get { return (String)this["Reserved05"]; }
            set { this["Reserved05"] = value; }
        }

        /// <summary>
        /// 预留6
        /// </summary>
        public String Reserved06
        {
            get { return (String)this["Reserved06"]; }
            set { this["Reserved06"] = value; }
        }

        /// <summary>
        /// 预留7
        /// </summary>
        public String Reserved07
        {
            get { return (String)this["Reserved07"]; }
            set { this["Reserved07"] = value; }
        }

        /// <summary>
        /// 预留8
        /// </summary>
        public String Reserved08
        {
            get { return (String)this["Reserved08"]; }
            set { this["Reserved08"] = value; }
        }

        /// <summary>
        /// 预留9
        /// </summary>
        public String Reserved09
        {
            get { return (String)this["Reserved09"]; }
            set { this["Reserved09"] = value; }
        }

        /// <summary>
        /// 预留10
        /// </summary>
        public String Reserved10
        {
            get { return (String)this["Reserved10"]; }
            set { this["Reserved10"] = value; }
        }
    }
}
