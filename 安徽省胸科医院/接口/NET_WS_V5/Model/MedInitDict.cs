using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalSytem.Soft.Model
{
    public class MedInitDict
    {
        public MedInitDict()
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
        /// 应该类型 DOCARE HIS LIS PACS PIS
        /// </summary>
        public string TransName
        {
            get { return _transName; }
            set { _transName = value; }
        }
        /// <summary>
        /// 数据库类型
        /// </summary>
        public string Dbms
        {
            get { return _dbms; }
            set { _dbms = value; }
        }
        /// <summary>
        /// 服务名(别名)
        /// </summary>
        public string ServerName
        {
            get { return _serverName; }
            set { _serverName = value; }
        }
        /// <summary>
        /// 数据库名称
        /// </summary>
        public string Database
        {
            get { return _database; }
            set { _database = value; }
        }
        /// <summary>
        /// 登录名
        /// </summary>
        public string LogId
        {
            get { return _logId; }
            set { _logId = value; }
        }
        /// <summary>
        /// 密码
        /// </summary>
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
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }


        private string _DoCareHisSupply;

        private string _DoCarePerformedcode;

        private string _DoCareIsTransfer;

        private string _DoCareIsOrders;

        private string _DoCareRefreshtime;

        private string _DoCareIsLabResult;

        private string _DoCareIsEmr;

        private string _DoCareIsExamReport;

        private string _DoCareIsExamReportDicom;

        private string _DoCareEleAuto;

        private string _DoCareIsCharge;

        private string _DoCareDayNum;

        private string _DoCareForUserId;

        private string _DoCareForPassWord;

        private string _DoCareOperMaster;

        private string _DoCareIsOperScheduleToHis;

        private string _DoCareIsOperMasterToHis;

        private string _DoCareIsOperStatusToHis;

        private string _IsLog;
        /// <summary>
        /// HIS公司
        /// </summary>
        public string DoCareHisSupply
        {
            get { return _DoCareHisSupply; }
            set { _DoCareHisSupply = value; }
        }
        /// <summary>
        /// 同步科室的病人信息
        /// </summary>
        public string DoCarePerformedcode
        {
            get { return _DoCarePerformedcode; }
            set { _DoCarePerformedcode = value; }
        }
        /// <summary>
        /// 是否同步转科信息
        /// </summary>
        public string DoCareIsTransfer
        {
            get { return _DoCareIsTransfer; }
            set { _DoCareIsTransfer = value; }
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
        /// EMR包括
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
        /// 是否电子签名 EMR004电子签名 
        /// </summary>
        public string DoCareEleAuto
        {
            get { return _DoCareEleAuto; }
            set { _DoCareEleAuto = value; }
        }
        //
        /// <summary>
        /// 是否使用收费信息 EMR005第三方HIS收费
        /// </summary>
        public string DoCareIsCharge
        {
            get { return _DoCareIsCharge; }
            set { _DoCareIsCharge = value; }
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
        /// 备用注册用户名
        /// </summary>
        public string DoCareForUserId
        {
            get { return _DoCareForUserId; }
            set { _DoCareForUserId = value; }
        }
        /// <summary>
        /// 备用注册密码
        /// </summary>
        public string DoCareForPassWord
        {
            get { return _DoCareForPassWord; }
            set { _DoCareForPassWord = value; }
        }
        /// <summary>
        /// 同步时写手术Operation_master,Operation_Name信息(解决进入术前) 
        /// </summary>
        public string DoCareOperMaster
        {
            get { return _DoCareOperMaster; }
            set { _DoCareOperMaster = value; }
        }
        /// <summary>
        /// 是否回传手术排班信息 
        /// </summary>
        public string DoCareIsOperCheduleToHis
        {
            get { return _DoCareIsOperScheduleToHis; }
            set { _DoCareIsOperScheduleToHis = value; }
        }
        /// <summary>
        /// 是否回传手术信息 
        /// </summary>
        public string DoCareIsOperMasterToHis
        {
            get { return _DoCareIsOperMasterToHis; }
            set { _DoCareIsOperMasterToHis = value; }
        }
        /// <summary>
        /// 是否回传手术状态信息 
        /// </summary>
        public string DoCareIsOperStatusToHis
        {
            get { return _DoCareIsOperStatusToHis; }
            set { _DoCareIsOperStatusToHis = value; }
        }
        /// <summary>
        /// 是否显示接口程序中的日志
        /// </summary>
        public string IsLog
        {
            get { return _IsLog; }
            set { _IsLog = value; }
        }
    }
}
