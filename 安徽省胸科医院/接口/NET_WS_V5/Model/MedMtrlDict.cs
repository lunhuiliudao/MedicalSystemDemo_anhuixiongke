
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/5/6 15:24:54
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
	/// <summary>
    /// 耗材字典
	/// </summary>
	[Serializable]
	public class MedMtrlDict
	{
		#region define variable
		private string _mtrlCode;
		private string _mtrlName = String.Empty;
		private string _mtrlSpec;
		private string _units = String.Empty;
		private string _mtrlClass = String.Empty;
		private string _codeInHis = String.Empty;
		private string _inputCode = String.Empty;
		#endregion
		
		#region public property
		///<summary>
        ///耗材代码  耗材的唯一标识
		///</summary>
		public string MtrlCode
		{
			get {return _mtrlCode;}
			set {_mtrlCode = value;}
		}

		///<summary>
        ///耗材名称 耗材的标准名称
		///</summary>
		public string MtrlName
		{
			get {return _mtrlName;}
			set {_mtrlName = value;}
		}

		///<summary>
        ///规格 消耗品规格
		///</summary>
		public string MtrlSpec
		{
			get {return _mtrlSpec;}
			set {_mtrlSpec = value;}
		}

		///<summary>
        ///单位 对应规格的最小单位，使用规范名称，见计量单位字典
		///</summary>
		public string Units
		{
			get {return _units;}
			set {_units = value;}
		}

		///<summary>
        ///耗材分类 耗材的分类，如高值耗材、低值耗材等，使用规范名称，见耗材分类字典
		///</summary>
		public string MtrlClass
		{
			get {return _mtrlClass;}
			set {_mtrlClass = value;}
		}

		///<summary>
        /// HIS对照码 耗材在HIS中的代码。如果本项为空，说明耗材代码与HIS中的代码完全一致，或不需要对照。
		///</summary>
		public string CodeInHis
		{
			get {return _codeInHis;}
			set {_codeInHis = value;}
		}

		///<summary>
		///
		///</summary>
		public string InputCode
		{
			get {return _inputCode;}
			set {_inputCode = value;}
		}
		#endregion
		
		public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedMtrlDict))
                return false;
            MedMtrlDict Oper = (MedMtrlDict)obj;
			if (this.MtrlCode != Oper.MtrlCode)
                return false;
			if (this.MtrlName != Oper.MtrlName)
                return false;
			if (this.MtrlSpec != Oper.MtrlSpec)
                return false;
			if (this.Units != Oper.Units)
                return false;
			if (this.MtrlClass != Oper.MtrlClass)
                return false;
			if (this.CodeInHis != Oper.CodeInHis)
                return false;
			if (this.InputCode != Oper.InputCode)
                return false;
            return true;
        }
	}
}
