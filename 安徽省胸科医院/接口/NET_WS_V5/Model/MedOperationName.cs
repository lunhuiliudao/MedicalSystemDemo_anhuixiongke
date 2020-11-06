
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:07:31
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
	///MedOperationName
	/// </summary>
	[Serializable]
	public class MedOperationName
	{
		#region define variable
	 
		#endregion
		
		#region public property
		///<summary>
		///
		///</summary>
		public string PatientId
		{
            get;
            set;
		}

		///<summary>
		///
		///</summary>
		public decimal VisitId
		{
            get;
            set;
		}

		///<summary>
		///
		///</summary>
		public decimal OperId
		{
            get;
            set;
		}

		///<summary>
		///手术名称
		///</summary>
        public decimal OperNo
        {
            get;
            set;
        }

		///<summary>
		///手术名称
		///</summary>
        public string OperName
        {
            get;
            set;
		}

		///<summary>
		///手术编码
		///</summary>
        public string OperCode
		{

            get;
            set;
		}

		///<summary>
        ///对应手术等级代码表,OPERATION_SCALE
		///</summary>
        public string OperScale
		{

            get;
            set;
		}

		///<summary>
        ///对应切口类型代码表,WOUND_GRADE
		///</summary>
        public string WoundType
		{

            get;
            set;
		}

		///<summary>
		///
		///</summary>
		public string Reserved1
		{
            get;
            set;
		}

		///<summary>
		///
		///</summary>
		public string Reserved2
		{
            get;
            set;
		}

		///<summary>
		///
		///</summary>
		public string Reserved3
		{
            get;
            set;
		}

		///<summary>
		///
		///</summary>
		public string Reserved4
		{
            get;
            set;
		}

	 
		#endregion
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedOperationName))
                return false;
            MedOperationName Oper = (MedOperationName)obj;
            if (this.PatientId != Oper.PatientId)
                return false;
            if (this.VisitId != Oper.VisitId)
                return false;
            if (this.OperId != Oper.OperId)
                return false;
           
            if (this.Reserved1 != Oper.Reserved1)
                return false;
            if (this.Reserved2 != Oper.Reserved2)
                return false;
            if (this.Reserved3 != Oper.Reserved3)
                return false;
            if (this.Reserved4 != Oper.Reserved4)
                return false;
         
            return true;
        }
	}
}
