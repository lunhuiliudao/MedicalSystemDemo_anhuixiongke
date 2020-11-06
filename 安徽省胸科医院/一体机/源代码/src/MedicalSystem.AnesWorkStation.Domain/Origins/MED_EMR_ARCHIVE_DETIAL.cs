namespace MedicalSystem.AnesWorkStation.Domain
{
    using System;
    using System.Collections.Generic;
    using Dapper.Data;



    /// <summary>
    /// 实体 
    /// </summary>
    [Table("MED_EMR_ARCHIVE_DETIAL")]
    public partial class MED_EMR_ARCHIVE_DETIAL : BaseModel
    {
        [Key]
        public string PATIENT_ID { get; set; }
        [Key]
        public Int32 VISIT_ID { get; set; }
        [Key]
        public string MR_CLASS { get; set; }
        [Key]
        public string MR_SUB_CLASS { get; set; }
        [Key]
        public string ARCHIVE_KEY { get; set; }
        [Key]
        public Int32 EMR_FILE_INDEX { get; set; }
        [Key]
        public Int32 ARCHIVE_TIMES { get; set; }
        public string TOPIC { get; set; }
        public string EMR_FILE_NAME { get; set; }
        public string EMR_TYPE { get; set; }
        public Nullable<DateTime> ARCHIVE_DATE_TIME { get; set; }
        public string ARCHIVE_TYPE { get; set; }
        private string _archiveStatus;
        public string ARCHIVE_STATUS
        {
            get { return _archiveStatus; }
            set
            {
                this._archiveStatus = value;
                RaisePropertyChanged("ARCHIVE_STATUS");
            }
        }
        public string EMR_OWNER { get; set; }
        public string OPERATOR { get; set; }
        public string ARCHIVE_PC { get; set; }
        public string ARCHIVE_MODE { get; set; }
        public string ARCHIVE_ACCESS { get; set; }
        public string MEMO { get; set; }

    }
}