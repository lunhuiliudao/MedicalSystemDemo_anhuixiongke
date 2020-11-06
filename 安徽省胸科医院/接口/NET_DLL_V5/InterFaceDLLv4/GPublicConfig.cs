using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace InterFaceV5
{
    public class GPublicConfig
    {
        public GPublicConfig()
        {
            string filePath = Application.StartupPath + "\\MDEP.ini";
            _wsurl = Publicini.ReadIniDataString("Run_Config", "WSURL", "", filePath);

            if (_wsurl.ToUpper().Contains("?WSDL"))
            {
                _wsurl = _wsurl.Replace("?WSDL", "");
            }

            _emrName = Publicini.ReadIniDataString("Run_Config", "EMRNAME", "", filePath);
            _emrIp = Publicini.ReadIniDataString("Run_Config", "EMRIP", "", filePath);
            _emrParm = Publicini.ReadIniDataString("Run_Config", "EMRPARM", "", filePath);
            _pacsName = Publicini.ReadIniDataString("Run_Config", "PACSNAME", "", filePath);
            _pacsIp = Publicini.ReadIniDataString("Run_Config", "PACSIP", "", filePath);
            _pacsParm = Publicini.ReadIniDataString("Run_Config", "PACSPARM", "", filePath);

            _dbms = Publicini.ReadIniDataString("Database", "DBMS", "o73", filePath);

            //string _serverName = Publicini.ReadIniDataString("Database", "ServerName", "", filePath).Replace("@", "").Trim();
            //string _database = Publicini.ReadIniDataString("Database", "Database", "", filePath);
            //string _logId = Publicini.ReadIniDataString("Database", "LogId", "", filePath);
            //string _logPassword = CryptUtil.DecryptString(Publicini.ReadIniDataString("Database", "LogPassword", "", filePath));

        }

        private string _wsurl;

        private string _transName;

        private string _dbms;

        private string _emrIp;

        private string _pacsIp;

        private string _pacsParm;

        private string _emrParm;

        private string _pacsName;

        private string _emrName;
        /// <summary>
        /// DoCare的WebService地址
        /// </summary>
        public string Wsurl
        {
            get { return _wsurl;}
            set { _wsurl = value; }
        }
         
        /// <summary>
        /// EMR地址IP
        /// </summary>
        public string EmrIp
        {
            get { return _emrIp; }
            set { _emrIp = value; }
        }
        /// <summary>
        /// PACS地址IP
        /// </summary>
        public string PacsIp
        {
            get { return _pacsIp; }
            set { _pacsIp = value; }
        }


        /// <summary>
        /// PACS的参数
        /// </summary>
        public string PacsParm
        {
            get { return _pacsParm; }
            set { _pacsParm = value; }
        }


        /// <summary>
        /// EMR的参数
        /// </summary>
        public string EmrParm
        {
            get { return _emrParm; }
            set { _emrParm = value; }
        }
        /// <summary>
        /// PACS厂家
        /// </summary>
        public string PacsName
        {
            get { return _pacsName; }
            set { _pacsName = value; }
        }


        /// <summary>
        /// EMR厂家
        /// </summary>
        public string EmrName
        {
            get { return _emrName; }
            set { _emrName = value; }
        }
    }
}
