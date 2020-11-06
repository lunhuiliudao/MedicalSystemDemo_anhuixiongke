
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
    ///MedIfHisViewSql
	/// </summary>
	[Serializable]
    public class MedIfHisViewSql
	{
		#region define variable
		private decimal _serialNo;
        private string _sqlText;
        private string _hisTableName;
        private string _medTableName;
        private string _paracode;
        private string _description;
        private string _sqltype;
        private string _dbmstype;
        private string _commandtype;
		#endregion
		
		#region public property
		///<summary>
		///序号
		///</summary>
		public decimal SerialNo
		{
			get {return _serialNo;}
			set {_serialNo = value;}
		}

		///<summary>
		///SQL语句
		///</summary>
        public string SqlText
		{
            get { return _sqlText; }
            set { _sqlText = value; }
		}

		///<summary>
		///HIS表名
		///</summary>
        public string HisTableName
		{
            get { return _hisTableName; }
            set { _hisTableName = value; }
		}

        ///<summary>
        ///MED表名
        ///</summary>
        public string MedTableName
        {
            get { return _medTableName; }
            set { _medTableName = value; }
        }

        ///<summary>
        ///参数代码
        ///</summary>
        public string ParaCode
        {
            get { return _paracode; }
            set { _paracode = value; }
        }

        ///<summary>
        ///描述
        ///</summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        ///<summary>
        ///SQL语句类型 如是SELECT INSERT UPDATE或其它
        ///</summary>
        public string SqlType
        {
            get { return _sqltype; }
            set { _sqltype = value; }
        }

        ///<summary>
        ///数据库类型，同WS里面配置的DOCARE系统的数据库类型
        ///</summary>
        public string DBMSType
        {
            get { return _dbmstype; }
            set { _dbmstype = value; }
        }

        /// <summary>
        /// 语句类型，是TEXT还是存储过程
        /// </summary>
        public string Commandtype
        {
            get { return _commandtype; }
            set { _commandtype = value; }
        }
        
		#endregion

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is MedIfHisViewSql))
                return false;
            MedIfHisViewSql Oper = (MedIfHisViewSql)obj;
            if (this.SerialNo != Oper.SerialNo)
                return false;
            if (this.SqlText != Oper.SqlText)
                return false;
            if (this.HisTableName != Oper.HisTableName)
                return false;
            if (this.MedTableName != Oper.MedTableName)
                return false;
            if (this.ParaCode != Oper.ParaCode)
                return false;
            if (this.Description != Oper.Description)
                return false;
            if (this.SqlType != Oper.SqlType)
                return false;
            if (this.DBMSType != Oper.DBMSType)
                return false;
            if (this.Commandtype != Oper.Commandtype)
                return false;
            return true;
        }
	}
}
