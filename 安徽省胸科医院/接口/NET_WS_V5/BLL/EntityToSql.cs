using System;
using System.Collections.Generic;
using System.Text;
using InitDocare;
using System.Data.OracleClient;
using MedicalSytem.Soft.Model;

namespace BLL
{
    public class EntityToSql
    {
        string pre = ":";
      
        /// <summary>
        /// oracle 版本
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int InsertStruct(List<MedTableStruct> list)
        {
            OracleCommand command = new OracleCommand();
            ExecCommand(list, command);
            ExecSqlInsertText(list, command);
            return IDataBase.SelectDataBase(EnumDataBase.ORACLE).ExecuteNonQuery(command);
        }

        public int UpdateStruct(List<MedTableStruct> list)
        {
            OracleCommand command = new OracleCommand();
            ExecCommand(list, command);
            ExecSqlUpdateText(list, command);
            return IDataBase.SelectDataBase(EnumDataBase.ORACLE).ExecuteNonQuery(command);
        }

        private void ExecCommand(List<MedTableStruct> list, OracleCommand command)
        {
            foreach (MedTableStruct struc in list)
            {
                OracleParameter op = new OracleParameter(pre + struc.ColumnName, GetOracleType(struc.DataType), struc.DataLength);
                if (struc.Value == null)
                {
                    struc.Value = DBNull.Value;
                }
                op.Value = struc.Value;
                command.Parameters.Add(op);
            }
        }

        private void ExecSqlInsertText(List<MedTableStruct> list, OracleCommand command)
        {
            string sqlInsert = "Insert into " + list[0].TableName + "(" + ParseInsertColumn(list, string.Empty) + ")values (" + ParseInsertColumn(list, pre) + ")";
            command.CommandText = sqlInsert;
        }

        private string ParseInsertColumn(List<MedTableStruct> list, string para)
        {
            string result = "";
            foreach (MedTableStruct ts in list)
            {
                if (result.Length == 0)
                {
                    result += para + ts.ColumnName;
                }
                else
                {
                    result += "," + para + ts.ColumnName;
                }
            }
            return result;
        }

        private void ExecSqlUpdateText(List<MedTableStruct> list, OracleCommand command)
        {
            string sqlUpdate = "Update " + list[0].TableName + " set " + ParseUpdateColumn(list, "=", " , " ,false) + " where " + ParseUpdateColumn(list, "="," and " ,true);
            command.CommandText = sqlUpdate;
        }


        public string ParseUpdateColumn(List<MedTableStruct> list, string para, bool isPara)
        {
            string result = "";
            if (isPara)
            {
                list = list.FindAll(P => P.IsPrimaryKey == true);
            }
            else
            {
                list = list.FindAll(P => P.IsPrimaryKey == false);
            }
            foreach (MedTableStruct ts in list)
            {
                if (result.Length == 0)
                {
                    result += ts.ColumnName + para + pre + ts.ColumnName;
                }
                else
                {
                    result += "," + ts.ColumnName + para + pre + ts.ColumnName;
                }
            }
            return result;
        }

        public string ParseUpdateColumn(List<MedTableStruct> list, string para, string pool, bool isPara)
        {
            string result = "";
            if (isPara)
            {
                list = list.FindAll(P => P.IsPrimaryKey == true);
            }
            else
            {
                list = list.FindAll(P => P.IsPrimaryKey == false);
            }
            foreach (MedTableStruct ts in list)
            {
                if (result.Length == 0)
                {
                    result += ts.ColumnName + para + pre + ts.ColumnName;
                }
                else
                {
                    result += pool + ts.ColumnName + para + pre + ts.ColumnName;
                }
            }
            return result;
        }
        

        private OracleType GetOracleType(DataType datatype)
        {
            OracleType oracleType = OracleType.NVarChar;
            switch (datatype)
            { 
                case DataType.Date:
                case DataType.DateTime:
                    oracleType = OracleType.DateTime;
                    break;
                case DataType.nvarchar:
                case DataType.varchar2:
                    oracleType = OracleType.NVarChar;
                    break;
                case DataType.numberType:
                case DataType.intType:
                case DataType.decimalType:
                    oracleType = OracleType.Number;
                    break;
            }
            return oracleType;
        }
    }
}
