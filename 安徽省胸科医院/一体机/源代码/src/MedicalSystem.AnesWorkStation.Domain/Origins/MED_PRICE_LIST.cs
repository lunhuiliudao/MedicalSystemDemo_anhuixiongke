using System;
using Dapper.Data;
namespace MedicalSystem.AnesWorkStation.Domain
{
    /// <summary>
    /// 实体 
    /// </summary>
    [Table("MED_PRICE_LIST")]
    public partial class MED_PRICE_LIST : BaseModel
    {
        public string ITEM_CLASS { get; set; }
        public string ITEM_CODE { get; set; }
        public string ITEM_NAME { get; set; }
        public string ITEM_SPEC { get; set; }
        public string UNITS { get; set; }
        public Nullable<decimal> PRICE { get; set; }
        public Nullable<decimal> PREFER_PRICE { get; set; }
        public Nullable<decimal> FOREIGNER_PRICE { get; set; }
        public string PERFORMED_BY { get; set; }
        public Nullable<Int32> FEE_TYPE_MASK { get; set; }
        public string CLASS_ON_INP_RCPT { get; set; }
        public string CLASS_ON_OUTP_RCPT { get; set; }
        public string CLASS_ON_RECKONING { get; set; }
        public string SUBJ_CODE { get; set; }
        public string CLASS_ON_MR { get; set; }
        public string MEMO { get; set; }
        public Nullable<DateTime> START_DATE { get; set; }
        public Nullable<DateTime> STOP_DATE { get; set; }
        public string OPERATOR { get; set; }
        public Nullable<DateTime> ENTER_DATE { get; set; }
        public string ROWID { get; set; }
    }
}