using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesIcuQuery.Models
{
    public class OperatingRoomDict : BaseModel
    {
        /// <summary>
        /// 手术间号(非空)
        /// </summary>
        public String Room_No
        {
            get { return (String)this["Room_No"]; }
            set { this["Room_No"] = value; }
        }

        /// <summary>
        /// 所属科室
        /// </summary>
        public String Dept_Code
        {
            get { return (String)this["Dept_Code"]; }
            set { this["Dept_Code"] = value; }
        }
        /// <summary>
        /// 位置(手术间所在地点)
        /// </summary>
        public String Location
        {
            get { return (String)this["Location"]; }
            set { this["Location"] = value; }
        }
        /// <summary>
        /// 状态(反映该手术间是否可用：0-可用 1-不可用)
        /// </summary>
        public String Status
        {
            get { return (String)this["Status"]; }
            set { this["Status"] = value; }
        }
        /// <summary>
        /// 床号
        /// </summary>
        public Decimal? Bed_Id
        {
            get { return (Decimal?)this["Bed_Id"]; }
            set { this["Bed_Id"] = value; }
        }
        /// <summary>
        /// 床位标号(用于显示，例如“美容1号床”)
        /// </summary>
        public String Bed_Label
        {
            get { return (String)this["Bed_Label"]; }
            set { this["Bed_Label"] = value; }
        }
        /// <summary>
        /// 监护仪代码(用于显示，例如“美容1号床”)
        /// </summary>
        public String Monitor_Code
        {
            get { return (String)this["Monitor_Code"]; }
            set { this["Monitor_Code"] = value; }
        }
        public Decimal Branch_No
        {
            get { return (Decimal)this["Branch_No"]; }
            set { this["Branch_No"] = value; }
        }
        public Decimal Sam_Space
        {
            get { return (Decimal)this["Sam_Space"]; }
            set { this["Sam_Space"] = value; }
        }
        /// <summary>
        /// 病人ID
        /// </summary>
        public String Patient_Id
        {
            get { return (String)this["Patient_Id"]; }
            set { this["Patient_Id"] = value; }
        }
        /// <summary>
        /// 住院次数
        /// </summary>
        public Decimal Visit_Id
        {
            get { return (Decimal)this["Visit_Id"]; }
            set { this["Visit_Id"] = value; }
        }
        /// <summary>
        /// 手术号
        /// </summary>
        public Decimal Oper_Id
        {
            get { return (Decimal)this["Oper_Id"]; }
            set { this["Oper_Id"] = value; }
        }
        /// <summary>
        /// 床位类型
        /// </summary>
        public String Bed_Type
        {
            get { return (String)this["Bed_Type"]; }
            set { this["Bed_Type"] = value; }
        }


    }
}
