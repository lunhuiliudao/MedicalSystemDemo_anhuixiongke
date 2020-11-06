using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesIcuQuery.Models
{

    public interface IQCInfo
    {
 
    }
    /// <summary>
    /// 病人信息表
    /// </summary>
    public class IcuQCPatInfo : BaseModel, IQCInfo
    {
        /// <summary>
        /// 病人ID
        /// </summary>
        public String Patient_Id
        {
            get { return (String)this["Patient_Id"]; }
            set { this["Patient_Id"] = value; }
        }

        /// <summary>
        /// 入院次数
        /// </summary>
        public Decimal Visit_Id
        {
            get { return (Decimal)this["Visit_Id"]; }
            set { this["Visit_Id"] = value; }
        }

        /// <summary>
        /// 入科次数
        /// </summary>
        public Decimal Dep_Id
        {
            get { return (Decimal)this["Dep_Id"]; }
            set { this["Dep_Id"] = value; }
        }
        
        /// <summary>
        /// 住院号
        /// </summary>
        public String Inp_No
        {
            get { return (String)this["Inp_No"]; }
            set { this["Inp_No"] = value; }
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public String Name
        {
            get { return (String)this["Name"]; }
            set { this["Name"] = value; }
        }

        /// <summary>
        /// 性别
        /// </summary>
        public String Sex
        {
            get { return (String)this["Sex"]; }
            set { this["Sex"] = value; }
        }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime Date_Of_Birth
        {
            get { return (DateTime)this["Date_Of_Birth"]; }
            set { this["Date_Of_Birth"] = value; }
        }

        /// <summary>
        /// 入科日期
        /// </summary>
        public DateTime? Adm_Ward_Date_Time
        {
            get { return (DateTime?)this["Adm_Ward_Date_Time"]; }
            set { this["Adm_Ward_Date_Time"] = value; }
        }

        /// <summary>
        /// 出科日期
        /// </summary>
        public DateTime? Out_Icu_DateTime
        {
            get { return (DateTime?)this["Out_Icu_DateTime"]; }
            set { this["Out_Icu_DateTime"] = value; }
        }

        /// <summary>
        /// APACHE2分值
        /// </summary>
        public String Scoring_Value
        {
            get { return (String)this["Scoring_Value"]; }
            set { this["Scoring_Value"] = value; }
        }

        /// <summary>
        /// APACHE2死亡率
        /// </summary>
        public Decimal? Death_Probability
        {
            get { return (Decimal?)this["Death_Probability"]; }
            set { this["Death_Probability"] = value; }
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
        /// 血管内导管留置天数
        /// </summary>
        public Decimal? Crbsi_Day
        {
            get { return (Decimal?)this["Crbsi_Day"]; }
            set { this["Crbsi_Day"] = value; }
        }

        /// <summary>
        /// 导尿管留置天数
        /// </summary>
        public Decimal? Cauti_Day
        {
            get { return (Decimal?)this["Cauti_Day"]; }
            set { this["Cauti_Day"] = value; }
        }
    }
}
