

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/5/15 14:44:05
 * 
 * Notes:
 * 
* ******************************************************************/

using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.Data.OracleClient;
using MedicalSytem.Soft.Model;
namespace MedicalSytem.Soft.DAL
{
	/// <summary>
	/// DAL MedPerformDefaultSchedule
	/// </summary>
	
	public partial class DALMedPerformDefaultSchedule
	{

		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedPerformDefaultSchedule 
		///Insert Table MED_PERFORM_DEFAULT_SCHEDULE
		/// </summary>
        public int InsertMedPerformDefaultScheduleSQL(MedPerformDefaultSchedule model, System.Data.Common.DbTransaction oleCisTrans)
		{
            SqlParameter[] oneInert = GetParameterSQL("InsertMedPerformDefaultSchedule");
			if (model.SerialNo.ToString() != null)
				oneInert[0].Value = model.SerialNo;
			else
				oneInert[0].Value = DBNull.Value;
			if (model.FreqDesc != null)
				oneInert[1].Value = model.FreqDesc;
			else
				oneInert[1].Value = DBNull.Value;
			if (model.Administration != null)
				oneInert[2].Value = model.Administration;
			else
				oneInert[2].Value = DBNull.Value;
			if (model.DefaultSchedule != null)
				oneInert[3].Value = model.DefaultSchedule;
			else
				oneInert[3].Value = DBNull.Value;

            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, MED_PERFORM_DEFAULT_SCHEDULE_Insert_SQL, oneInert);

		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedPerformDefaultSchedule 
		///Update Table     MED_PERFORM_DEFAULT_SCHEDULE
		/// </summary>
        public int UpdateMedPerformDefaultScheduleSQL(MedPerformDefaultSchedule model, System.Data.Common.DbTransaction oleCisTrans)
		{
			SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedPerformDefaultSchedule");
            if (model.SerialNo.ToString() != null)
				oneUpdate[0].Value = model.SerialNo;
			else
				oneUpdate[0].Value = DBNull.Value;
			if (model.FreqDesc != null)
				oneUpdate[1].Value = model.FreqDesc;
			else
				oneUpdate[1].Value = DBNull.Value;
			if (model.Administration != null)
				oneUpdate[2].Value = model.Administration;
			else
				oneUpdate[2].Value = DBNull.Value;
			if (model.DefaultSchedule != null)
				oneUpdate[3].Value = model.DefaultSchedule;
			else
				oneUpdate[3].Value = DBNull.Value;
			if (model.FreqDesc != null)
				oneUpdate[4].Value =model.FreqDesc;
			else
				oneUpdate[4].Value = DBNull.Value;
			if (model.Administration != null)
				oneUpdate[5].Value =model.Administration;
			else
				oneUpdate[5].Value = DBNull.Value;

            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, MED_PERFORM_DEFAULT_SCHEDULE_Update_SQL, oneUpdate);

		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedPerformDefaultSchedule 
		///Delete Table MED_PERFORM_DEFAULT_SCHEDULE by (string FREQ_DESC,string ADMINISTRATION)
		/// </summary>
        public int DeleteMedPerformDefaultScheduleSQL(string FREQ_DESC, string ADMINISTRATION, System.Data.Common.DbTransaction oleCisTrans)
		{
			SqlParameter[] oneDelete = GetParameterSQL("DeleteMedPerformDefaultSchedule");
			if (FREQ_DESC != null)
				oneDelete[0].Value =FREQ_DESC;
			else
				oneDelete[0].Value = DBNull.Value;
			if (ADMINISTRATION != null)
				oneDelete[1].Value =ADMINISTRATION;
			else
				oneDelete[1].Value = DBNull.Value;

            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, MED_PERFORM_DEFAULT_SCHEDULE_Delete_SQL, oneDelete);

		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedPerformDefaultSchedule 
		///select Table MED_PERFORM_DEFAULT_SCHEDULE by (string FREQ_DESC,string ADMINISTRATION)
		/// </summary>
        public MedPerformDefaultSchedule SelectMedPerformDefaultScheduleSQL(string FREQ_DESC, string ADMINISTRATION, System.Data.Common.DbConnection oleCisConn)
		{
			MedPerformDefaultSchedule model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedPerformDefaultSchedule");
				parameterValues[0].Value=FREQ_DESC;
				parameterValues[1].Value=ADMINISTRATION;
                using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_PERFORM_DEFAULT_SCHEDULE_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedPerformDefaultSchedule();
						if (!oleReader.IsDBNull(0))
						{
							model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.FreqDesc = oleReader["FREQ_DESC"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.Administration = oleReader["ADMINISTRATION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.DefaultSchedule = oleReader["DEFAULT_SCHEDULE"].ToString().Trim() ;
						}
				}
				else
                    model = null;
			}
			return model;
		}
		#endregion	
		#region  [获取所有记录SQL]
		/// <summary>
		///获取所有记录
		/// </summary>
		public List<MedPerformDefaultSchedule> SelectMedPerformDefaultScheduleListSQL( System.Data.Common.DbConnection oleCisConn)
		{
			List<MedPerformDefaultSchedule> modelList = new List<MedPerformDefaultSchedule>();
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_PERFORM_DEFAULT_SCHEDULE_Select_ALL_SQL, null))
			{
                while (oleReader.Read())
				{
					MedPerformDefaultSchedule model = new MedPerformDefaultSchedule();
						if (!oleReader.IsDBNull(0))
						{
							model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.FreqDesc = oleReader["FREQ_DESC"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.Administration = oleReader["ADMINISTRATION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.DefaultSchedule = oleReader["DEFAULT_SCHEDULE"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
        #region  [获取一条记录SQL--FREQ_DESC]
        /// <summary>
        ///Select    model  MedPerformDefaultSchedule 
        ///select Table MED_PERFORM_DEFAULT_SCHEDULE by (string FREQ_DESC)
        /// </summary>
        public MedPerformDefaultSchedule SelectMedPerformDefaultScheduleSQL(string FREQ_DESC, System.Data.Common.DbConnection oleCisConn)
        {
            MedPerformDefaultSchedule model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedPerformDefaultScheduleFreq");
            parameterValues[0].Value = FREQ_DESC;

            using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_PERFORM_DEFAULT_SCHEDULE_Select_Freq_SQL, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedPerformDefaultSchedule();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.FreqDesc = oleReader["FREQ_DESC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.Administration = oleReader["ADMINISTRATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.DefaultSchedule = oleReader["DEFAULT_SCHEDULE"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion	

		#region [添加一条记录]
		/// <summary>
		///Add    model  MedPerformDefaultSchedule 
		///Insert Table MED_PERFORM_DEFAULT_SCHEDULE
		/// </summary>
        public int InsertMedPerformDefaultSchedule(MedPerformDefaultSchedule model, System.Data.Common.DbTransaction oleCisTrans)
		{
			OracleParameter[] oneInert = GetParameter("InsertMedPerformDefaultSchedule");
            if (model.SerialNo.ToString() != null)
				oneInert[0].Value = model.SerialNo;
			else
				oneInert[0].Value = DBNull.Value;
			if (model.FreqDesc != null)
				oneInert[1].Value = model.FreqDesc;
			else
				oneInert[1].Value = DBNull.Value;
			if (model.Administration != null)
				oneInert[2].Value = model.Administration;
			else
				oneInert[2].Value = DBNull.Value;
			if (model.DefaultSchedule != null)
				oneInert[3].Value = model.DefaultSchedule;
			else
				oneInert[3].Value = DBNull.Value;
	
			return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans,CommandType.Text, MED_PERFORM_DEFAULT_SCHEDULE_Insert, oneInert);

		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedPerformDefaultSchedule 
		///Update Table     MED_PERFORM_DEFAULT_SCHEDULE
		/// </summary>
        public int UpdateMedPerformDefaultSchedule(MedPerformDefaultSchedule model, System.Data.Common.DbTransaction oleCisTrans)
		{
			OracleParameter[] oneUpdate = GetParameter("UpdateMedPerformDefaultSchedule");
            if (model.SerialNo.ToString() != null)
				oneUpdate[0].Value = model.SerialNo;
			else
				oneUpdate[0].Value = DBNull.Value;
			if (model.FreqDesc != null)
				oneUpdate[1].Value = model.FreqDesc;
			else
				oneUpdate[1].Value = DBNull.Value;
			if (model.Administration != null)
				oneUpdate[2].Value = model.Administration;
			else
				oneUpdate[2].Value = DBNull.Value;
			if (model.DefaultSchedule != null)
				oneUpdate[3].Value = model.DefaultSchedule;
			else
				oneUpdate[3].Value = DBNull.Value;
			if (model.FreqDesc != null)
				oneUpdate[4].Value =model.FreqDesc;
			else
				oneUpdate[4].Value = DBNull.Value;
			if (model.Administration != null)
				oneUpdate[5].Value =model.Administration;
			else
				oneUpdate[5].Value = DBNull.Value;

            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, MED_PERFORM_DEFAULT_SCHEDULE_Update, oneUpdate);

		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedPerformDefaultSchedule 
		///Delete Table MED_PERFORM_DEFAULT_SCHEDULE by (string FREQ_DESC,string ADMINISTRATION)
		/// </summary>
        public int DeleteMedPerformDefaultSchedule(string FREQ_DESC, string ADMINISTRATION, System.Data.Common.DbTransaction oleCisTrans)
		{
			OracleParameter[] oneDelete = GetParameter("DeleteMedPerformDefaultSchedule");
			if (FREQ_DESC != null)
				oneDelete[0].Value =FREQ_DESC;
			else
				oneDelete[0].Value = DBNull.Value;
			if (ADMINISTRATION != null)
				oneDelete[1].Value =ADMINISTRATION;
			else
				oneDelete[1].Value = DBNull.Value;

            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, MED_PERFORM_DEFAULT_SCHEDULE_Delete, oneDelete);

		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedPerformDefaultSchedule 
		///select Table MED_PERFORM_DEFAULT_SCHEDULE by (string FREQ_DESC,string ADMINISTRATION)
		/// </summary>
        public MedPerformDefaultSchedule SelectMedPerformDefaultSchedule(string FREQ_DESC, string ADMINISTRATION, System.Data.Common.DbConnection oleCisConn)
		{
			MedPerformDefaultSchedule model;
			OracleParameter[] parameterValues = GetParameter("SelectMedPerformDefaultSchedule");
			parameterValues[0].Value=FREQ_DESC;
			parameterValues[1].Value=ADMINISTRATION;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_PERFORM_DEFAULT_SCHEDULE_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedPerformDefaultSchedule();
						if (!oleReader.IsDBNull(0))
						{
							model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.FreqDesc = oleReader["FREQ_DESC"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.Administration = oleReader["ADMINISTRATION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.DefaultSchedule = oleReader["DEFAULT_SCHEDULE"].ToString().Trim() ;
						}
				}
				else
                    model = null;
			}
			return model;
		}
		#endregion	
		#region  [获取所有记录]
		/// <summary>
		///获取所有记录
		/// </summary>
		public List<MedPerformDefaultSchedule> SelectMedPerformDefaultScheduleList(System.Data.Common.DbConnection oleCisConn)
		{
			List<MedPerformDefaultSchedule> modelList = new List<MedPerformDefaultSchedule>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_PERFORM_DEFAULT_SCHEDULE_Select_ALL, null))
			{
                while (oleReader.Read())
				{
					MedPerformDefaultSchedule model = new MedPerformDefaultSchedule();
						if (!oleReader.IsDBNull(0))
						{
							model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim()) ;
						}
						if (!oleReader.IsDBNull(1))
						{
							model.FreqDesc = oleReader["FREQ_DESC"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.Administration = oleReader["ADMINISTRATION"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.DefaultSchedule = oleReader["DEFAULT_SCHEDULE"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
        #region  [获取一条记录--FREQ_DESC]
        /// <summary>
        ///Select    model  MedPerformDefaultSchedule 
        ///select Table MED_PERFORM_DEFAULT_SCHEDULE by (string FREQ_DESC)
        /// </summary>
        public MedPerformDefaultSchedule SelectMedPerformDefaultSchedule(string FREQ_DESC, System.Data.Common.DbConnection oleCisConn)
        {
            MedPerformDefaultSchedule model;
            OracleParameter[] parameterValues = GetParameter("SelectMedPerformDefaultScheduleFreq");
            parameterValues[0].Value = FREQ_DESC;

            using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_PERFORM_DEFAULT_SCHEDULE_Select_Freq, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedPerformDefaultSchedule();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.FreqDesc = oleReader["FREQ_DESC"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.Administration = oleReader["ADMINISTRATION"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.DefaultSchedule = oleReader["DEFAULT_SCHEDULE"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion	
	}
}
