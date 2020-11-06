using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MedicalSystem.Anes.Document.Controls
{
    [Serializable]
    public class MedLiquidItem
    {
        private string itemName;
        [DisplayName("项目名称")]
        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        private List<MedLiquidDetail> liquidItemDetails=new List<MedLiquidDetail>();
        [DisplayName("液体明细集合"),Browsable(false)]
        public List<MedLiquidDetail> LiquidItemDetails
        {
            get { return liquidItemDetails; }
            set { liquidItemDetails = value; }
        }

        public override string ToString()
        {
            return itemName;
        }
    }
}
