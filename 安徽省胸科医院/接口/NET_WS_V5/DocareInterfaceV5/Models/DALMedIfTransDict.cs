using BLL;
using Entitys;
using MedicalSytem.Soft.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NET_WS_V5.Models
{
    public class DALMedIfTransDict
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        public List<MedIfTrans> SelectMedIfTransAll()
        {
            string sql = "select * from med_if_trans_dict";
            List<MedIfTrans> trans = new List<MedIfTrans>();
            DataSet ds = OracleHelper.GetDataSet(conn, CommandType.Text, sql, null);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                MedIfTrans entity = new MedIfTrans();
                entity.TransName = dr["TRANS_NAME"].ToString();
                entity.DataBase = dr["DATABASE"].ToString();
                entity.DBMS = dr["DBMS"].ToString();
                entity.ServerName = dr["SERVER_NAME"].ToString();
                entity.LogPass = dr["LOG_PASS"].ToString();
                entity.LogId = dr["LOG_ID"].ToString();
                entity.NlsLang = dr["NLS_LANG"].ToString();
                entity.DbParm = dr["DBPARM"].ToString();
                entity.Memo = dr["MEMO"].ToString();
                trans.Add(entity);
            }
            return trans;
        }

        public string InsertMedIfTrans(MedIfTrans entity)
        {
            try
            {
                string sql = "Insert into med_if_trans_dict(TRANS_NAME,DATABASE,DBMS,SERVER_NAME,LOG_PASS,LOG_ID,NLS_LANG,DBPARM,MEMO) values('" + entity.TransName + "','" + entity.DataBase + "','" + entity.DBMS + "','" + entity.ServerName + "','" + entity.LogPass + "','" + entity.LogId + "','" + entity.NlsLang + "','" + entity.DbParm + "','" + entity.Memo + "')";
                int i= OracleHelper.ExecuteNonQuery(conn, sql, null);
                return i == 1 ? "" : "insert 失败";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string UpdateMedIfTrans(MedIfTrans entity,string TransId)
        {
            try
            {
                string sql = "Update med_if_trans_dict set trans_name='" + entity.TransName + "', DATABASE='" + entity.DataBase + "',DBMS='" + entity.DBMS + "',SERVER_NAME='" + entity.ServerName + "',LOG_PASS='" + entity.LogPass + "',LOG_ID='" + entity.LogId + "',NLS_LANG='" + entity.NlsLang + "',DBPARM='" + entity.DbParm + "',MEMO='" + entity.Memo + "' where TRANS_NAME='" + TransId + "'";
                int i = OracleHelper.ExecuteNonQuery(conn, sql, null);
                return i == 1 ? "" : "update 失败";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        } 

        public string DeleteMedIfTrans(MedIfTrans entity)
        {
            try
            {
                string sql = "delete from med_if_trans_dict where trans_name='" + entity.TransName + "'";
                int i = OracleHelper.ExecuteNonQuery(conn, sql, null);
                return i == 1 ? "" : "delete 失败";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}