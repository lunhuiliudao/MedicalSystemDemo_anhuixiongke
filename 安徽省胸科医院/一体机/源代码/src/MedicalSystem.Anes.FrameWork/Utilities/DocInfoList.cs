using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedicalSystem.Anes.FrameWork.Utilities
{
    public class DocInfoList
    {
        public string OperationStatus { get; set; }
        public List<Item> Items { get; set; }

        public class Item
        {
            public string Text { get; set; }
            public string SourceTableName { get; set; }
            public string SourceFieldName { get; set; }
            public string DictTableName { get; set; }
            public string DictWhereString { get; set; }
            public string DefaultValue { get; set; }
            public string DictSourceName { get; set; }
        }
    }

}
