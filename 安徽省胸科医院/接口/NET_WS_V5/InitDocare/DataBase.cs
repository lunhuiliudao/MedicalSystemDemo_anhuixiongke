using System;
using System.Collections.Generic;
using System.Text;
using InitDocare;

namespace Init
{
    public enum DataBase
    {
        Oracle=1,
        OleDb=2,
        SqlServer=3,
        Odbc=4,
        Other=5,
    }

    public class DBContext
    {
        public static DataBase CurrentDbType
        {
            get
            {
                string dbtype = PublicA.GetConfig("DataServerType").ToUpper();
                if (dbtype == "ORACLE")
                {
                    return DataBase.Oracle;
                }
                else if (dbtype == "ODBC")
                {
                    return DataBase.Odbc;
                }
                else if (dbtype.IndexOf("OLE") >= 0)
                {
                    return DataBase.OleDb;
                }
                else if (dbtype.IndexOf("SQLSERVER") >= 0)
                {
                    return DataBase.SqlServer;
                }
                else
                {
                    return DataBase.Other;
                }
            }
        }
    }
}
