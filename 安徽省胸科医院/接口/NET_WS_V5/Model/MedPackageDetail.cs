
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:01:04
 * 
 * Notes:
 *
* ******************************************************************/
using System;

namespace MedicalSytem.Soft.Model
{
	/// <summary>
    ///MedPackageDetail
	/// </summary>
	[Serializable]
	public class MedPackageDetail
	{
		#region define variable
        private string _barcode = String.Empty;
        private string _instrumentname = String.Empty;
        private string _instrumentcode = String.Empty;
        private decimal _quantity;
		#endregion
		
		#region public property
		///<summary>
        ///器械包条形码
		///</summary>
        public string BarCode
		{
            get { return _barcode; }
            set { _barcode = value; }
		}

		///<summary>
        ///器械名称
		///</summary>
        public string InstrumentName
		{
            get { return _instrumentname; }
            set { _instrumentname = value; }
		}

		///<summary>
        ///器械编码
		///</summary>
        public string InstrumentCode
		{
            get { return _instrumentcode; }
            set { _instrumentcode = value; }
		}

		///<summary>
        ///数量
		///</summary>
        public decimal Quantity
		{
            get { return _quantity; }
            set { _quantity = value; }
		}

		#endregion
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedPackageDetail))
                return false;
            MedPackageDetail Oper = (MedPackageDetail)obj;
            if (this.BarCode != Oper.BarCode)
                return false;
            if (this.InstrumentName != Oper.InstrumentName)
                return false;
            if (this.InstrumentCode != Oper.InstrumentCode)
                return false;
            if (this.Quantity != Oper.Quantity)
                return false;
            return true;
        }
	}
}
