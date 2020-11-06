
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:01:09
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
    ///MedIcuConfig
	/// </summary>
	[Serializable]
	public class MedIcuConfig
	{
		#region define variable
        private decimal _configid;
        private string _auditingcondition;
        private string _dept;
        private string _ordersinmount;
        private string _specialcare;
		#endregion
		
		#region public property
		///<summary>
        ///配置ID
		///</summary>
        public decimal ConfigId
		{
            get { return _configid; }
            set { _configid = value; }
		}

		///<summary>
        ///审核条件配置
		///</summary>
        public string AuditingCondition
		{
            get { return _auditingcondition; }
            set { _auditingcondition = value; }
		}

		///<summary>
        ///科室配置
		///</summary>
        public string Dept
		{
            get { return _dept; }
            set { _dept = value; }
		}

        ///<summary>
        ///医嘱入量配置
        ///</summary>
        public string OrdersInMount
        {
            get { return _ordersinmount; }
            set { _ordersinmount = value; }
        }

        ///<summary>
        ///特护单配置
        ///</summary>
        public string SpecialCare
        {
            get { return _specialcare; }
            set { _specialcare = value; }
        }
		#endregion
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedIcuConfig))
                return false;
            MedIcuConfig Oper = (MedIcuConfig)obj;
            if (this.ConfigId != Oper.ConfigId)
                return false;
            if (this.AuditingCondition != Oper.AuditingCondition)
                return false;
            if (this.Dept != Oper.Dept)
                return false;
            if (this.OrdersInMount != Oper.OrdersInMount)
                return false;
            if (this.SpecialCare != Oper.SpecialCare)
                return false;
            return true;
        }
	}
}
