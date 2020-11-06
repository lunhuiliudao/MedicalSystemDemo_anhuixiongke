namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    /// <summary>
    /// 实体
    /// </summary>
    [Table("MED_VER_INFO")]
    public partial class MED_VER_INFO : BaseModel
    {
        /// <summary>
        /// 主键 途径编码
        /// </summary>
        [Key]
        public string VER_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string APP_ID { get; set; }

        public int VER_NO { get; set; }
        /// <summary>
        /// 简称
        /// </summary>
        public string FILE_PATH { get; set; }

        public Nullable<Int32> IS_FORCIBLY { get; set; }

        public Nullable<Int32> IS_TEST { get; set; }

        public Nullable<Int32> ROLL_BACK { get; set; }

        public string ROLL_BACK_DESC { get; set; }

        public string DESCRIPTION { get; set; }

        public string CREATER { get; set; }

        public Nullable<DateTime> CREATE_TIME { get; set; }

        public string MODIFYER { get; set; }

        public Nullable<DateTime> MODIFY_TIME { get; set; }
    }
}