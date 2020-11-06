namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using Dapper.Data;
   

    /// <summary>
    /// 实体
    /// </summary>
    [Table("MED_APP_INFO")]
    public partial class MED_APP_INFO : BaseModel
    {
        /// <summary>
        /// 主键 途径编码
        /// </summary>
        [Key]
        public string APP_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string APP_KEY { get; set; }
        /// <summary>
        /// 简称
        /// </summary>
        public string APP_NAME { get; set; }
        /// <summary>
        /// 输入码
        /// </summary>
        public string DESCRIPTION { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        public string CREATER { get; set; }

        public Nullable<DateTime> CREATE_TIME { get; set; }

        public string MODIFYER { get; set; }

        public Nullable<DateTime> MODIFY_TIME { get; set; }
    }
}