
/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 21:56:34
 * 
 * Notes:
 *
* ******************************************************************/
using System;
namespace MedicalSytem.Soft.Model
{
    /// <summary>
    ///MedIfTransDict
    /// </summary>
    [Serializable]
    public class MedIfTransDict
    {
        #region define variable
        private string _transName;
        private EnumDataBase _dbms;
        private string _serverName = String.Empty;
        private string _database = String.Empty;
        private string _logId = String.Empty;
        private string _logPass = String.Empty;
        private string _nlsLang = String.Empty;
        private string _dbparm = String.Empty;
        private string _memo = String.Empty;
        #endregion

        #region public property
        ///<summary>
        ///事务对象;数据库事务对象名称，系统定义:HIS 医院信息系统 LIS 检验信息系统 PACS 检查信息系统 PIS 病理信息系统 EMR 电子病历系统
        ///</summary>
        public string TransName
        {
            get { return _transName; }
            set { _transName = value; }
        }

        ///<summary>
        ///数据库管理系统;
        ///</summary>
        public EnumDataBase Dbms
        {
            get { return _dbms; }
            set { _dbms = value; }
        }

        ///<summary>
        ///服务名
        ///</summary>
        public string ServerName
        {
            get { return _serverName; }
            set { _serverName = value; }
        }

        ///<summary>
        ///数据库;适用于SQL_Serve
        ///</summary>
        public string Database
        {
            get { return _database; }
            set { _database = value; }
        }

        ///<summary>
        ///登陆名;数据库登陆名称
        ///</summary>
        public string LogId
        {
            get { return _logId; }
            set { _logId = value; }
        }

        ///<summary>
        ///登陆密码;数据库登陆密码
        ///</summary>
        public string LogPass
        {
            get { return _logPass; }
            set { _logPass = value; }
        }

        ///<summary>
        ///字符集
        ///</summary>
        public string NlsLang
        {
            get { return _nlsLang; }
            set { _nlsLang = value; }
        }

        ///<summary>
        ///连接字符串
        ///</summary>
        public string Dbparm
        {
            get { return _dbparm; }
            set { _dbparm = value; }
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
            if (!(obj is MedIfTransDict))
                return false;
            MedIfTransDict Oper = (MedIfTransDict)obj;
            if (this.TransName != Oper.TransName)
                return false;
            if (this.Dbms != Oper.Dbms)
                return false;
            if (this.ServerName != Oper.ServerName)
                return false;
            if (this.Database != Oper.Database)
                return false;
            if (this.LogId != Oper.LogId)
                return false;
            if (this.LogPass != Oper.LogPass)
                return false;
            if (this.NlsLang != Oper.NlsLang)
                return false;
            if (this.Dbparm != Oper.Dbparm)
                return false;
            if (this.Memo != Oper.Memo)
                return false;
            return true;
        }
    }
}
