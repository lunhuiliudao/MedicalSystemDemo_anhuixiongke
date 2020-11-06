using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DapperEx;

namespace UpdateEntity
{
    public  class VER_UPDATE_REC_LIST
    {
        [Id]
        public String UP_ID { get; set; }

        public String APP_KEY { get; set; }

        public String APP_NAME { get; set; }

        public int VER_NO { get; set; }

        public String VER_ID { get; set; }

        public String IP { get; set; }

        public string SYSTEM_NAME { get; set; }

        public int IS_DOWNLOAD { get; set; }

        public DateTime? DOWNLOAD_TIME { get; set; }

        public int IS_UPDATED { get; set; }

        public DateTime? UPDATED_TIME { get; set; }

        public int? ROLL_BACK { get; set; }

        public DateTime? ROLL_BACK_TIME { get; set; }

        public DateTime? CREATE_TIME { get; set; }
    }
}
