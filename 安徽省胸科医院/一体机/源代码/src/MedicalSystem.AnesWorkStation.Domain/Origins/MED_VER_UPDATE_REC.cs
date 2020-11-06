namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using Dapper.Data;
   

    /// <summary>
    /// 实体
    /// </summary>
    [Table("MED_VER_UPDATE_REC")]
    public partial class MED_VER_UPDATE_REC : BaseModel
    {
        /// <summary>
        /// 主键 途径编码
        /// </summary>
        [Key]
        public string UP_ID { get; set; }

        public string APP_NAME { get; set; }

        public string VER_ID { get; set; }

        public string IP { get; set; }

        public string SYSTEM_NAME { get; set; }

        public Nullable<Int32> IS_DOWNLOAD { get; set; }

        public Nullable<DateTime> DOWNLOAD_TIME { get; set; }

        public Nullable<Int32> IS_UPDATED { get; set; }

        public Nullable<DateTime> UPDATED_TIME { get; set; }

        public Nullable<Int32> ROLL_BACK { get; set; }

        public Nullable<DateTime> ROLL_BACK_TIME { get; set; }

        public Nullable<DateTime> CREATE_TIME { get; set; }
    }
}