using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class IDataBase
    {
        public static IDataHelper SelectDataBase(EnumDataBase dbType)
        {
            switch (dbType)
            {
                case  EnumDataBase.SQLSERVER:
                    return new DataSqlServerHelper();

                case  EnumDataBase.ORACLE:
                    return new DataOracleHelper();

                case  EnumDataBase.OLEDB:
                    return  new DataOracleOleHelper();

                case  EnumDataBase.ODBC:
                    return null;

                case  EnumDataBase.MYSQL:
                    return null;
                default:
                    return new DataOracleHelper();
            }
        }

        public static IDataHelper SelectDataBase(string dbtype)
        {
            switch (dbtype)
            {
                case "SQLSERVER":
                    return new DataSqlServerHelper();

                case "ORACLE":
                    return new DataOracleHelper();

                case "OLEDB":
                    return new DataOracleOleHelper();

                case "ODBC":
                    return null;
                case "MYSQL":
                    return null;
                default:
                    return new DataOracleHelper();
            }
        }
    }
}
