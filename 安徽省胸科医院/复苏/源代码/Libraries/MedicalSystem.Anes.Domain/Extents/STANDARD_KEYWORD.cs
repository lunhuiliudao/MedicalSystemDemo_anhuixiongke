using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.Domain
{
    public class STANDARD_KEYWORD : BaseModel
    {
        public string WORD { get; set; }
        /// <summary>
        /// 入院次数	;	住院病人每次住院加1
        /// </summary> 
        public string ART_ID { get; set; }
        public string ART_NAME { get; set; }
        public byte[] CONTENT { get; set; }
        public string CAT_ID { get; set; }
        public Int32 ORDER_NUM { get; set; }
    }
}
