using System;
using System.Collections.Generic;
using System.Text;

namespace InterFaceV5
{
    public class GPublicIni
    {
        public GPublicIni()
        {
            //
        }

        private string _transName;

        private string _dbms;

        private string _serverName;

        private string _database;

        private string _logId;

        private string _logPass;

        private string _nlsLang;

        private string _dbparm;

        private string _memo;
        /// <summary>
        /// 连接标识 HIS LIS PIS EMR PACS
        /// </summary>
        public string TransName
        {
            get { return _transName; }
            set { _transName = value; }
        }
        /// <summary>
        /// 连接类型 o73 081 SQLServer Sybase ODBC
        /// </summary>
        public string Dbms
        {
            get { return _dbms; }
            set { _dbms = value; }
        }

        public string ServerName
        {
            get { return _serverName; }
            set { _serverName = value; }
        }

        public string Database
        {
            get { return _database; }
            set { _database = value; }
        }

        public string LogId
        {
            get { return _logId; }
            set { _logId = value; }
        }

        public string LogPass
        {
            get { return _logPass; }
            set { _logPass = value; }
        }

        public string NlsLang
        {
            get { return _nlsLang; }
            set { _nlsLang = value; }
        }

        public string Dbparm
        {
            get { return _dbparm; }
            set { _dbparm = value; }
        }

        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }

        private string _DoCareHisSupply;

        private string _DoCarePerformedcode;

        private string _DoCareIstransfer;

        private string _DoCareIsOrders;

        private string _DoCareRefreshtime;

        private string _DoCareIsLabResult;

        private string _DoCareIsEmr;

        private string _DoCareIsExamReport;

        private string _DoCareIsExamReportDicom;

        private string _DoCareIsPisReport;

        private string _DoCareDayNum;

        private string _DoCareForUserId;

        private string _DoCareForPassWord;
        /// <summary>
        /// 麻醉HIS公司
        /// </summary>
        public string DoCareHisSupply
        {
            get { return _DoCareHisSupply; }
            set { _DoCareHisSupply = value; }
        }
        /// <summary>
        /// 麻醉同步科室的患者信息
        /// </summary>
        public string DoCarePerformedcode
        {
            get { return _DoCarePerformedcode; }
            set { _DoCarePerformedcode = value; }
        }
        /// <summary>
        /// 是否同步转科信息
        /// </summary>
        public string DoCareIstransfer
        {
            get { return _DoCareIstransfer; }
            set { _DoCareIstransfer = value; }
        }
        /// <summary>
        /// 是否同步医嘱信息
        /// </summary>
        public string DoCareIsOrders
        {
            get { return _DoCareIsOrders; }
            set { _DoCareIsOrders = value; }
        }
        /// <summary>
        /// 麻醉同步刷新时间
        /// </summary>
        public string DoCareRefreshtime
        {
            get { return _DoCareRefreshtime; }
            set { _DoCareRefreshtime = value; }
        }
        /// <summary>
        /// LIS检验
        /// </summary>
        public string DoCareIsLabResult
        {
            get { return _DoCareIsLabResult; }
            set { _DoCareIsLabResult = value; }
        }
        /// <summary>
        /// EMR电子病历-包括004电子签名 005第三方HIS收费
        /// </summary>
        public string DoCareIsEmr
        {
            get { return _DoCareIsEmr; }
            set { _DoCareIsEmr = value; }
        }
        /// <summary>
        /// PACS检查信息
        /// </summary>
        public string DoCareIsExamReport
        {
            get { return _DoCareIsExamReport; }
            set { _DoCareIsExamReport = value; }
        }
        /// <summary>
        /// PACS检查图像
        /// </summary>
        public string DoCareIsExamReportDicom
        {
            get { return _DoCareIsExamReportDicom; }
            set { _DoCareIsExamReportDicom = value; }
        }
        /// <summary>
        /// PIS病理信息
        /// </summary>
        public string DoCareIsPisReport
        {
            get { return _DoCareIsPisReport; }
            set { _DoCareIsPisReport = value; }
        }
        /// <summary>
        /// 申请或预约有效期
        /// </summary>
        public string DoCareDayNum
        {
            get { return _DoCareDayNum; }
            set { _DoCareDayNum = value; }
        }

        /// <summary>
        /// ICU备用注册用户名
        /// </summary>
        public string DoCareForUserId
        {
            get { return _DoCareForUserId; }
            set { _DoCareForUserId = value; }
        }
        /// <summary>
        /// ICU备用注册密码
        /// </summary>
        public string DoCareForPassWord
        {
            get { return _DoCareForPassWord; }
            set { _DoCareForPassWord = value; }
        }

    }
}
