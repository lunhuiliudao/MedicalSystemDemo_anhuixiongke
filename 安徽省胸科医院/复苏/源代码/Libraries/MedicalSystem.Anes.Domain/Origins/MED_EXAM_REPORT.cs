namespace MedicalSystem.Anes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 实体 
    /// </summary>
    [Table("MED_EXAM_REPORT")]
    public partial class MED_EXAM_REPORT : BaseModel
    {
                [Key]
        public string EXAM_NO { get; set; }
        public string EXAM_PARA { get; set; }
        public string DESCRIPTION { get; set; }
        public string IMPRESSION { get; set; }
        public string RECOMMENDATION { get; set; }
        public string IS_ABNORMAL { get; set; }
        public string USE_IMAGE { get; set; }
        public string STUDY_UID { get; set; }
        public string MEMO { get; set; }

    }
}