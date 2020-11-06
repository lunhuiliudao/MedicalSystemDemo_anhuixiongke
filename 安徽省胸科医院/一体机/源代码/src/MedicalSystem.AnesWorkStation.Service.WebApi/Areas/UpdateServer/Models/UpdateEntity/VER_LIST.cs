using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateEntity
{
    public class VER_LIST
    {
        public String VER_ID { get; set; }

        public String APP_ID { get; set; }

        public String APP_KEY { get; set; }

        public String APP_NAME { get; set; }

        public int VER_NO { get; set; }

        public String FILE_PATH { get; set; }

        public int? IS_FORCIBLY { get; set; }

        public int? IS_TEST { get; set; }

        public string ROLL_BACK { get; set; }

        public string ROLL_BACK_DESC { get; set; }

        public string DESCRIPTION { get; set; }

        public String CREATER { get; set; }

        public DateTime? CREATE_TIME { get; set; }

        public String MODIFYER { get; set; }

        public DateTime? MODIFY_TIME { get; set; }

        public string DOWNLOAD_NUM { get; set; }

        public string UPDATED_NUM { get; set; }
    }
}
