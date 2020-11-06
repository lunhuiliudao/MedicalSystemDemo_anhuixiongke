using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.AnesWorkStation.Domain
{
  
    /// <summary>
    /// 手术查询条件参数model
    /// </summary>
    public class AnesDocumentPDFSrcEntity
    {
        public string Patient_Id { get; set; }
        public int Visit_Id { get; set; }
        public int Archive_Key { get; set; }
        /// <summary>
        /// 文书名称
        /// </summary>
        public string DocName { get; set; }

        /// <summary>
        /// 文书相对路径
        /// </summary>
        public string DocSrc { get; set; }
        /// <summary>
        /// 手术开始时间
        /// </summary>
        public DateTime Start_Date_Time { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        public string NAME { get; set; }

    }
}
