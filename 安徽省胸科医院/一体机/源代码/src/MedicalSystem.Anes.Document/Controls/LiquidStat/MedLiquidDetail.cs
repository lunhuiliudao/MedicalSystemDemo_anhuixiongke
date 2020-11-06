using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MedicalSystem.Anes.Document.Controls
{
    [Serializable]
    public class MedLiquidDetail
    {
        private string liquidName;
        [DisplayName("液体名称")]
        public string LiquidName
        {
            get { return liquidName; }
            set { liquidName = value; }
        }

        private int liquidValue;
        [DisplayName("液体用量")]
        public int LiquidValue
        {
            get { return liquidValue; }
            set { liquidValue = value; }
        }
    }
}
