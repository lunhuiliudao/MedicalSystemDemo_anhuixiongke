using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MedicalSystem.Anes.Document.Controls
{
    [Serializable]
    public class MedBloodGasItem
    {
        private string itemCode;
        [DisplayName("项目代码")]
        public string ItemCode
        {
            get { return itemCode; }
            set { itemCode = value; }
        }

        private string itemName;
        [DisplayName("项目名称")]
        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        private string itemUnit;
        [DisplayName("单位")]
        public string ItemUnit
        {
            get{return itemUnit;}
            set {itemUnit = value;}
        }

        public override string ToString()
        {
            return itemName;
        }
    }
}
