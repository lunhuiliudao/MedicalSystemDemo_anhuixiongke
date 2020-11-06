

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:01:09
 * 
 * Notes:
 * 
* ******************************************************************/

using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.OracleClient;
using MedicalSytem.Soft.Model;

namespace MedicalSytem.Soft.DAL
{
	/// <summary>
	/// DAL MedDeptDict
	/// </summary>
	
	public partial class DALMedDeptDict
	{

		#region [添加一条记录SQL]
		/// <summary>
		///Add    model  MedDeptDict 
		///Insert Table MED_DEPT_DICT
		/// </summary>
        public int InsertMedDeptDictSQL(MedDeptDict model, System.Data.Common.DbTransaction oleCisTrans)
		{
			SqlParameter[] oneInert = GetParameterSQL("InsertMedDeptDict");
                //if (model.SerialNo.ToString() != null)
                //        oneInert[0].Value = model.SerialNo;
                //    else
                //        oneInert[0].Value = DBNull.Value;
                //    if (model.DeptCode != null)
                //        oneInert[1].Value = model.DeptCode;
                //    else
                //        oneInert[1].Value = DBNull.Value;
                //    if (model.DeptName != null)
                //        oneInert[2].Value = model.DeptName;
                //    else
                //        oneInert[2].Value = DBNull.Value;
                //    if (model.InputCode != null)
                //        oneInert[3].Value = model.InputCode;
                //    else
                //        oneInert[3].Value = DBNull.Value;

                    return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans,CommandType.Text, MED_DEPT_DICT_Insert_SQL, oneInert);

		}
		#endregion
		#region [更新一条记录SQL]
		/// <summary>
		///Update    model  MedDeptDict 
		///Update Table     MED_DEPT_DICT
		/// </summary>
        public int UpdateMedDeptDictSQL(MedDeptDict model, System.Data.Common.DbTransaction oleCisTrans)
		{
			SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedDeptDict");
            //if (model.SerialNo.ToString() != null)
            //    oneUpdate[0].Value = model.SerialNo;
            //else
            //    oneUpdate[0].Value = DBNull.Value;
            //if (model.DeptCode != null)
            //    oneUpdate[1].Value = model.DeptCode;
            //else
            //    oneUpdate[1].Value = DBNull.Value;
            //if (model.DeptName != null)
            //    oneUpdate[2].Value = model.DeptName;
            //else
            //    oneUpdate[2].Value = DBNull.Value;
            //if (model.InputCode != null)
            //    oneUpdate[3].Value = model.InputCode;
            //else
            //    oneUpdate[3].Value = DBNull.Value;
            //if (model.DeptCode != null)
            //    oneUpdate[4].Value =model.DeptCode;
            //else
            //    oneUpdate[4].Value = DBNull.Value;

            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, MED_DEPT_DICT_Update_SQL, oneUpdate);
		}
		#endregion	
		#region [删除一条记录SQL]
		/// <summary>
		///Delete    model  MedDeptDict 
		///Delete Table MED_DEPT_DICT by (string DEPT_CODE)
		/// </summary>
        public int DeleteMedDeptDictSQL(string DEPT_CODE, System.Data.Common.DbTransaction oleCisTrans)
		{
			SqlParameter[] oneDelete = GetParameterSQL("DeleteMedDeptDict");
			if (DEPT_CODE != null)
				oneDelete[0].Value =DEPT_CODE;
			else
				oneDelete[0].Value = DBNull.Value;
            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, MED_DEPT_DICT_Delete_SQL, oneDelete);

		}
		#endregion
		#region  [获取一条记录SQL]
		/// <summary>
		///Select    model  MedDeptDict 
		///select Table MED_DEPT_DICT by (string DEPT_CODE)
		/// </summary>
        public MedDeptDict SelectMedDeptDictSQL(string DEPT_CODE, System.Data.Common.DbConnection oleCisConn)
		{
			MedDeptDict model;
			SqlParameter[] parameterValues = GetParameterSQL("SelectMedDeptDict");
			parameterValues[0].Value=DEPT_CODE;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_DEPT_DICT_Select_SQL, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedDeptDict();
                    //if (!oleReader.IsDBNull(0))
                    //{
                    //    model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim()) ;
                    //}
                    //if (!oleReader.IsDBNull(1))
                    //{
                    //    model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim() ;
                    //}
                    //if (!oleReader.IsDBNull(2))
                    //{
                    //    model.DeptName = oleReader["DEPT_NAME"].ToString().Trim() ;
                    //}
                    //if (!oleReader.IsDBNull(3))
                    //{
                    //    model.InputCode = oleReader["INPUT_CODE"].ToString().Trim() ;
                    //}
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
		public List<MedDeptDict> SelectMedDeptDictListSQL(System.Data.Common.DbConnection oleCisConn)
		{
			List<MedDeptDict> modelList = new List<MedDeptDict>();
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_DEPT_DICT_Select_ALL_SQL, null))
			{
                while (oleReader.Read())
				{
					MedDeptDict model = new MedDeptDict();
						if (!oleReader.IsDBNull(0))
						{
                            model.SortNo = decimal.Parse(oleReader["Sort_No"].ToString().Trim());
						}
						if (!oleReader.IsDBNull(1))
						{
							model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(2))
						{
							model.DeptName = oleReader["DEPT_NAME"].ToString().Trim() ;
						}
						if (!oleReader.IsDBNull(3))
						{
							model.InputCode = oleReader["INPUT_CODE"].ToString().Trim() ;
						}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		

		#region [添加一条记录]
		/// <summary>
		///Add    model  MedDeptDict 
		///Insert Table MED_DEPT_DICT
		/// </summary>
        public int InsertMedDeptDict(MedDeptDict model, System.Data.Common.DbTransaction oleCisTrans)
		{

			OracleParameter[] oneInert = GetParameter("InsertMedDeptDict");
            //if (model.SerialNo.ToString() != null)
            //    oneInert[0].Value = model.SerialNo;
            //else
            //    oneInert[0].Value = DBNull.Value;
            //if (model.DeptCode != null)
            //    oneInert[1].Value = model.DeptCode;
            //else
            //    oneInert[1].Value = DBNull.Value;
            //if (model.DeptName != null)
            //    oneInert[2].Value = model.DeptName;
            //else
            //    oneInert[2].Value = DBNull.Value;
            //if (model.InputCode != null)
            //    oneInert[3].Value = model.InputCode;
            //else
            //    oneInert[3].Value = DBNull.Value;

            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, MED_DEPT_DICT_Insert, oneInert);

		}
		#endregion
		#region [更新一条记录]
		/// <summary>
		///Update    model  MedDeptDict 
		///Update Table     MED_DEPT_DICT
		/// </summary>
        public int UpdateMedDeptDict(MedDeptDict model, System.Data.Common.DbTransaction oleCisTrans)
		{
			OracleParameter[] oneUpdate = GetParameter("UpdateMedDeptDict");
            //if (model.SerialNo.ToString() != null)
            //    oneUpdate[0].Value = model.SerialNo;
            //else
            //    oneUpdate[0].Value = DBNull.Value;
            //if (model.DeptCode != null)
            //    oneUpdate[1].Value = model.DeptCode;
            //else
            //    oneUpdate[1].Value = DBNull.Value;
            //if (model.DeptName != null)
            //    oneUpdate[2].Value = model.DeptName;
            //else
            //    oneUpdate[2].Value = DBNull.Value;
            //if (model.InputCode != null)
            //    oneUpdate[3].Value = model.InputCode;
            //else
            //    oneUpdate[3].Value = DBNull.Value;
            //if (model.DeptCode != null)
            //    oneUpdate[4].Value =model.DeptCode;
            //else
            //    oneUpdate[4].Value = DBNull.Value;

            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, MED_DEPT_DICT_Update, oneUpdate);

		}
		#endregion	
		#region [删除一条记录]
		/// <summary>
		///Delete    model  MedDeptDict 
		///Delete Table MED_DEPT_DICT by (string DEPT_CODE)
		/// </summary>
        public int DeleteMedDeptDict(string DEPT_CODE, System.Data.Common.DbTransaction oleCisTrans)
		{
			OracleParameter[] oneDelete = GetParameter("DeleteMedDeptDict");
			if (DEPT_CODE != null)
				oneDelete[0].Value =DEPT_CODE;
			else
				oneDelete[0].Value = DBNull.Value;

            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, MED_DEPT_DICT_Delete, oneDelete);

		}
		#endregion
		#region  [获取一条记录]
		/// <summary>
		///Select    model  MedDeptDict 
		///select Table MED_DEPT_DICT by (string DEPT_CODE)
		/// </summary>
        public MedDeptDict SelectMedDeptDict(string DEPT_CODE, System.Data.Common.DbConnection oleCisConn)
		{
			MedDeptDict model;
			OracleParameter[] parameterValues = GetParameter("SelectMedDeptDict");
				parameterValues[0].Value=DEPT_CODE;
                using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_DEPT_DICT_Select, parameterValues))
			{
				if (oleReader.Read())
				{
					model = new MedDeptDict();
                        //if (!oleReader.IsDBNull(0))
                        //{
                        //    model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim()) ;
                        //}
                        //if (!oleReader.IsDBNull(1))
                        //{
                        //    model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim() ;
                        //}
                        //if (!oleReader.IsDBNull(2))
                        //{
                        //    model.DeptName = oleReader["DEPT_NAME"].ToString().Trim() ;
                        //}
                        //if (!oleReader.IsDBNull(3))
                        //{
                        //    model.InputCode = oleReader["INPUT_CODE"].ToString().Trim() ;
                        //}
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
		public List<MedDeptDict> SelectMedDeptDictList(System.Data.Common.DbConnection oleCisConn)
		{
			List<MedDeptDict> modelList = new List<MedDeptDict>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_DEPT_DICT_Select_ALL, null))
			{
                while (oleReader.Read())
				{
					MedDeptDict model = new MedDeptDict();
                        //if (!oleReader.IsDBNull(0))
                        //{
                        //    model.SerialNo = decimal.Parse(oleReader["SERIAL_NO"].ToString().Trim()) ;
                        //}
                        //if (!oleReader.IsDBNull(1))
                        //{
                        //    model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim() ;
                        //}
                        //if (!oleReader.IsDBNull(2))
                        //{
                        //    model.DeptName = oleReader["DEPT_NAME"].ToString().Trim() ;
                        //}
                        //if (!oleReader.IsDBNull(3))
                        //{
                        //    model.InputCode = oleReader["INPUT_CODE"].ToString().Trim() ;
                        //}
					modelList.Add(model);
				}
			}
			return modelList;
		}
		#endregion	
		
	}
}
