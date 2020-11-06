using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem.AnesWorkStation.Domain
{
    public partial class AddDetailCharge
    {
       
        [NotMapped]
        public string ITEM_CLASS { get; set; } 
        [NotMapped]
        public string ITEM_CODE { get; set; }
        [NotMapped]
        public Nullable<decimal> PRICE { get; set; }
        [NotMapped]
        public string BILL_INDICATOR { get; set; }
        [NotMapped]
        public string PRICE_METHOD { get; set; }
        public Nullable<Int32> SPEC { get; set; }
        [NotMapped]
        public Nullable<Int32> BASE_TIME { get; set; }
        [NotMapped]
        public string ITEM_CODE_ADD { get; set; }
        [NotMapped]
        public string PRICE_CLASS { get; set; }
        [NotMapped]
        public String PRICE_CLASS_NAME { get; set; }
        [NotMapped]
        public string PRICE_CODE { get; set; }
        [NotMapped]
        public string PRICE_NAME { get; set; }
        [NotMapped]
        public string PRICE_SPEC { get; set; }
        [NotMapped]
        public string ANES_ITEM_NAME { get; set; }
    }
}
