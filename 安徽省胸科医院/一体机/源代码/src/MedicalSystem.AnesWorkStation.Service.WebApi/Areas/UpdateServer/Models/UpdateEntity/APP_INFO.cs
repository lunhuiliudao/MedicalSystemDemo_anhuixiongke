using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DapperEx;

namespace UpdateEntity
{
    public  class APP_INFO
    {
        [Id]
        public String APP_ID { get; set; }

        public String APP_KEY { get; set; }

        public String APP_NAME { get; set; }

        public String DESCRIPTION { get; set; }

        public String CREATER { get; set; }

        public DateTime? CREATE_TIME { get; set; }

        public String MODIFYER { get; set; }

        public DateTime? MODIFY_TIME { get; set; }

    }
}
