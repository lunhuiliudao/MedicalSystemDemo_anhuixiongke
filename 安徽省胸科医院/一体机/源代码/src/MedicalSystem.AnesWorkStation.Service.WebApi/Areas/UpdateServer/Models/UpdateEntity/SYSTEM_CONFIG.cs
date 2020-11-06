using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DapperEx;

namespace UpdateEntity
{
    public class SYSTEM_CONFIG
    {
        [Id]
        public string SYS_ID { get; set; }

        public string CONFIG_JSON { get; set; }

    }
}
