using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using InitDocare;
using MedicalSytem.Soft.Model;
using NET_WS_V5;
using System.Data.Common;
using System.Data.OracleClient;
using System.Data.OleDb;
using System.Data.Odbc;

namespace BLL
{
    /// <summary>
    /// 基本对象
    /// </summary>
    public class BMedCommDict : HospitalBase
    {

        /// <summary>
        /// 新功能同步
        /// </summary>
        /// <param name="config"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        public override string PreDataBase(Config2 config, Init.ParamInputDomain domain)
        {
            try
            {
                List<MedIfHisViewSql2> medIfHisViewSqlList = config.SelectMedIfHisViewSql(domain.Code);  //config.MedIfHisViewSqlCommList;

                MedVsHisPat vspat = SelectMedVsHisPat(domain.Patient.PatientId, domain.Patient.VisitId.Value);

                if (vspat != null)
                {
                    domain.Patient.InpNo = vspat.Reserved01;
                }

                //ParaCode 等于1 的为需要轮训的同步
                if (medIfHisViewSqlList == null || medIfHisViewSqlList.Count == 0)
                {
                    LogA.Debug("没有需要自动回传的数据");
                    return "";
                }
                
                foreach (MedIfHisViewSql2 viewSql in medIfHisViewSqlList)
                {
                    try 
                    {
                        List<MedTableStruct> structList = GetTableStruct(config, viewSql.MedTableName);

                        DataSet ds = null;

                        MedIfTransDict oneTransEntity = config.SelectOneMedIfTransDict(viewSql.TransName);

                        DbParameter[] dbPara = GetDbPara(config,oneTransEntity.Database, viewSql.SqlPara);

                        #region 参数赋值
                        foreach (DbParameter para in dbPara)
                        {
                            if (para.ParameterName.ToUpper().Contains("PATIENTID"))
                            {
                                para.Value = domain.Patient.PatientId;
                            }
                            else if (para.ParameterName.ToUpper().Contains("VISITID"))
                            {
                                para.Value = domain.Patient.VisitId;
                            }
                            else if (para.ParameterName.ToUpper().Contains("INPNP"))
                            {
                                para.Value = domain.Patient.InpNo;
                            }
                            else if (para.ParameterName.ToUpper().Contains("PARAM1"))
                            {
                                para.Value = domain.Reserved1;
                            }
                            else if (para.ParameterName.ToUpper().Contains("PARAM2"))
                            {
                                para.Value = domain.Reserved2;
                            }
                            else if (para.ParameterName.ToUpper().Contains("PARAM3"))
                            {
                                para.Value = domain.Reserved3;
                            }
                            else if (para.ParameterName.ToUpper().Contains("PARAM4"))
                            {
                                para.Value = domain.Reserved4;
                            }
                            else if (para.ParameterName.ToUpper().Contains("PARAM5"))
                            {
                                para.Value = domain.Reserved5;
                            }
                        }
                        #endregion 

                        string sqlText = viewSql.SqlText + GetSqlPara(viewSql.SqlPara, oneTransEntity.Dbms);

                        ds = IDataBase.SelectDataBase(oneTransEntity.Database).GetDataSet(CommandType.Text, sqlText, oneTransEntity.Dbparm, dbPara);
 
                        if (ds == null || ds.Tables.Count < 1)
                        {
                            InitDocare.LogA.Debug("没有数据要同步");
                            continue;
                        }

                        SetDiBctRec(structList, ds);
                    }
                    catch (Exception ex2)
                    {
                        throw ex2;
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                InitDocare.LogA.Debug(ex.Message + "调用堆栈上的桢的字符串表现形式:" + ex.StackTrace + "\r\n引发当前异常的函数为:" + ex.TargetSite.Name + "\r\n导致错误的应用程序或对象的名称为:" + ex.Source + "\r\n");
                InitDocare.LogA.ToLogCache(EmunLog.EnumTypeCategory.程序错误, EmunLog.EnumTypeGrade.异常, EmunLog.EnumTypeModule.人员同步, EmunLog.EnumTypeSource.ICU, ex.Message, "当前用户", "His人员同步异常");
                return "信息接口提示[V4版本]:" + ex.Message;
            }
            finally
            {
                InitDocare.LogA.LogCommit();
            }
        }

        public override string PreWebServices(Config2 config, Init.ParamInputDomain domain)
        {
            return base.PreWebServices(config, domain);
        }

        public override string PreReceiveMsg(Config2 config, Init.ParamInputDomain domain)
        {
            return base.PreReceiveMsg(config, domain);
        }

        public override string DoExecute(InitDocare.Config2 config, Init.ParamInputDomain domain, MedicalSytem.Soft.Model.ModelBase obj)
        {
            return base.DoExecute(config, domain, obj);
        }


        private DbParameter[] GetDbPara(Config2 config,string database,string sqlwhere)
        {
            string[] spList = sqlwhere.Split(' ');
            DbParameter[] result = null;
            List<string> paraList = new List<string>();
            foreach (string str in spList)
            {
                if (string.IsNullOrEmpty(str))
                {
                    continue;
                }
                if (str.Contains("@@"))
                {
                    paraList.Add(str);
                }
            }
            int i=0;
            foreach (string str in spList)
            {
                switch (database)
                {
                    case "SQLSERVER":
                        result = new SqlParameter[paraList.Count];
                        result[i] = new SqlParameter("@" + str, SqlDbType.VarChar);
                        break;
                    case "ORACLE":
                        result = new OracleParameter[paraList.Count];
                        result[i] = new OracleParameter(":" + str, SqlDbType.VarChar);
                        break;
                    case "ORACLEOLE":
                        result = new OleDbParameter[paraList.Count];
                        result[i] = new OleDbParameter(str, SqlDbType.VarChar);
                        break;
                    case "ODBC":
                        result = new OdbcParameter[paraList.Count];
                        result[i] = new OdbcParameter(str, SqlDbType.VarChar);
                        break;
                    case "MYSQL":
                        break;
                }
                i++;
            }
            return result;
        }

        /// <summary>
        /// 写入数据库
        /// </summary>
        /// <param name="structList"></param>
        /// <param name="ds"></param>
        public void SetDiBctRec(List<MedTableStruct> structList, DataSet ds)
        {
            
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                foreach (MedTableStruct truct in structList)
                {
                    if (ds.Tables[0].Columns.Contains(truct.ColumnName))
                    {
                        truct.Value = dr[truct.ColumnName];
                    }
                }
                EntityToSql exec = new EntityToSql();
                if (exec.UpdateStruct(structList) == 0)
                {
                    exec.InsertStruct(structList);
                }
            }
        }

        public List<MedTableStruct> GetTableStruct(Config2 config, string tableName)
        {
            List<MedTableStruct> result = new List<MedTableStruct>();

            switch (config.DocareDbType)
            {
                case EnumDataBase.SQLSERVER:
                    {
                        string sql = @"  SELECT  syscolumns.name column_name,systypes.name as data_type,syscolumns.isnullable Nullable,
                               syscolumns.length data_length,'' IS_PRIMARY_KEY
                               FROM syscolumns, systypes 
                               WHERE syscolumns.xusertype = systypes.xusertype 
                               AND syscolumns.id = object_id('" + tableName + "')";

                        DataSet ds = IDataBase.SelectDataBase(EnumDataBase.SQLSERVER).GetDataSet(CommandType.Text, sql);

                        sql = @"SELECT TABLE_NAME,COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_NAME='" + tableName + "' ";

                        DataSet ds2 = IDataBase.SelectDataBase(EnumDataBase.SQLSERVER).GetDataSet(CommandType.Text, sql);

                        result = TableToStruct(ds, ds2);
                    }
                    break;
                case EnumDataBase.ORACLE:
                    {
                        string sql = @"select a.TABLE_NAME,a.column_name,a.data_type,  data_length ,decode(a.Nullable,'N',1,'Y',0,0) Nullable,'' IS_PRIMARY_KEY   from all_tab_columns a  
                           where a.TABLE_NAME='" + tableName.ToUpper() + "'";

                        DataSet ds = IDataBase.SelectDataBase(EnumDataBase.ORACLE).GetDataSet(CommandType.Text, sql);


                        sql = @"SELECT UC.TABLE_NAME, UCC.COLUMN_NAME 
                            FROM USER_CONSTRAINTS UC, USER_CONS_COLUMNS UCC 
                            WHERE UC.CONSTRAINT_NAME = UCC.CONSTRAINT_NAME 
                            AND UC.TABLE_NAME = UPPER('" + tableName + @"') 
                            AND CONSTRAINT_TYPE = 'P' ";

                        DataSet ds2 = IDataBase.SelectDataBase(EnumDataBase.ORACLE).GetDataSet(CommandType.Text, sql);

                        result = TableToStruct(ds, ds2);
                    }
                    break;
                case EnumDataBase.OLEDB:
                    {
                        string sql = @"select a.TABLE_NAME,a.column_name,a.data_type,  data_length ,decode(a.Nullable,'N',1,'Y',0,0) Nullable,'' IS_PRIMARY_KEY   from all_tab_columns a  
                           where a.TABLE_NAME='" + tableName.ToUpper() + "'";

                        DataSet ds = IDataBase.SelectDataBase(EnumDataBase.OLEDB).GetDataSet(CommandType.Text, sql);

                        sql = @"SELECT UC.TABLE_NAME, UCC.COLUMN_NAME 
                            FROM USER_CONSTRAINTS UC, USER_CONS_COLUMNS UCC 
                            WHERE UC.CONSTRAINT_NAME = UCC.CONSTRAINT_NAME 
                            AND UC.TABLE_NAME = UPPER('" + tableName + @"') 
                            AND CONSTRAINT_TYPE = 'P' ";

                        DataSet ds2 = IDataBase.SelectDataBase(EnumDataBase.OLEDB).GetDataSet(CommandType.Text, sql);

                        result = TableToStruct(ds, ds2);
                    }
                    break;
            }

            foreach (MedTableStruct entity in result)
            {
                entity.TableName = tableName;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds">查询数据源</param>
        /// <param name="ds2">主键</param>
        /// <returns></returns>
        public List<MedTableStruct> TableToStruct(DataSet ds, DataSet ds2)
        {
            List<MedTableStruct> result = new List<MedTableStruct>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                MedTableStruct entity = new MedTableStruct();

                entity.ColumnName = dr["column_name"].ToString();
                entity.DataLength = int.Parse(dr["data_length"].ToString());
                if (dr["Nullable"].ToString() == "0")
                {
                    entity.IsNull = true;
                }
                switch (dr["data_type"].ToString().ToUpper())
                {
                    case "NUMBER":
                        entity.DataType = DataType.numberType;
                        break;
                    case "VARCHAR2":
                        entity.DataType = DataType.varchar2;
                        break;
                    case "DATE":
                        entity.DataType = DataType.Date;
                        break;
                    default:
                        entity.DataType = DataType.varchar2;
                        break;
                }
                if (ds2.Tables.Count > 0)
                {
                    ///设置主键
                    foreach (DataRow drtemp in ds2.Tables[0].Rows)
                    {
                        if (drtemp["COLUMN_NAME"].ToString().ToUpper() == entity.ColumnName.ToUpper())
                        {
                            entity.IsPrimaryKey = true;
                            break;
                        }
                    }
                }
                result.Add(entity);
            }
            return result;
        }
    }
}
