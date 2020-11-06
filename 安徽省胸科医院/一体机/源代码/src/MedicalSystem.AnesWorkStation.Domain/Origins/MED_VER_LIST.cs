namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using Dapper.Data;
   

    /// <summary>
    /// 实体
    /// </summary>
    [Table("MED_VER_LIST")]
    public partial class MED_VER_LIST : BaseModel
    {
        /// <summary>
        /// 主键 途径编码
        /// </summary>
        [Key]
        public string VER_ID { get; set; }

        public string APP_ID { get; set; }

        public string APP_KEY { get; set; }

        public string APP_NAME { get; set; }

        public Int32 VER_NO { get; set; }

        public string FILE_PATH { get; set; }

        public Nullable<Int32> IS_FORCIBLY { get; set; }

        public Nullable<Int32> IS_TEST { get; set; }

        public string ROLL_BACK { get; set; }

        public string ROLL_BACK_DESC { get; set; }

        public string DESCRIPTION { get; set; }

        public string CREATER { get; set; }

        public Nullable<DateTime> CREATE_TIME { get; set; }

        public string MODIFYER { get; set; }

        public Nullable<DateTime> MODIFY_TIME { get; set; }

        public string DOWNLOAD_NUM { get; set; }

        public string UPDATED_NUM { get; set; }
    }
}