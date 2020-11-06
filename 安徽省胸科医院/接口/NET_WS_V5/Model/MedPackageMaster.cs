
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
    ///MedPackageMaster
	/// </summary>
	[Serializable]
	public class MedPackageMaster
	{
		#region define variable
        private string _barcode = String.Empty;
        private string _packagename = String.Empty;
        private DateTime _sterilizedate;
        private string _todayusetimes = String.Empty;
        private DateTime _expdate;
        private string _packageoperator = String.Empty;
        private string _memo = String.Empty;
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
        ///器械包名称
		///</summary>
        public string PackageName
		{
            get { return _packagename; }
            set { _packagename = value; }
		}

		///<summary>
        ///灭菌日期
		///</summary>
        public DateTime SterilizeDate
		{
            get { return _sterilizedate; }
            set { _sterilizedate = value; }
		}

		///<summary>
        ///锅次
		///</summary>
        public string TodayUseTimes
		{
            get { return _todayusetimes; }
            set { _todayusetimes = value; }
		}

		///<summary>
        ///有效日期
		///</summary>
        public DateTime ExpDate
		{
            get { return _expdate; }
            set { _expdate = value; }
		}

        ///<summary>
        ///打包人
        ///</summary>
        public string PackageOperator
        {
            get { return _packageoperator; }
            set { _packageoperator = value; }
        }

        ///<summary>
        ///备注
        ///</summary>
        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
		#endregion
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedPackageMaster))
                return false;
            MedPackageMaster Oper = (MedPackageMaster)obj;
            if (this.BarCode != Oper.BarCode)
                return false;
            if (this.PackageName != Oper.PackageName)
                return false;
            if (this.SterilizeDate != Oper.SterilizeDate)
                return false;
            if (this.TodayUseTimes != Oper.TodayUseTimes)
                return false;
            if (this.ExpDate != Oper.ExpDate)
                return false;
            if (this.PackageOperator != Oper.PackageOperator)
                return false;
            if (this.Memo != Oper.Memo)
                return false;
            return true;
        }
	}
}
