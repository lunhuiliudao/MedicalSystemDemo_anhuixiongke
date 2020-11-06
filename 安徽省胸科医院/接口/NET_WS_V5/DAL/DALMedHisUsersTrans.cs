

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/4/10 22:01:05
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
	/// DAL MedHisUsers
	/// </summary>

    public partial class DALMedHisUsers
    {

        #region [添加一条记录SQL]
        /// <summary>
        ///Add    model  MedHisUsers 
        ///Insert Table MED_HIS_USERS
        /// </summary>
        public int InsertMedHisUsersSQL(MedHisUsers model, System.Data.Common.DbTransaction oleCisTrans)
        {
            SqlParameter[] oneInert = GetParameterSQL("InsertMedHisUsers");
            //if (model.UserId != null)
            //    oneInert[0].Value = model.UserId;
            //else
            //    oneInert[0].Value = DBNull.Value;
            //if (model.UserName != null)
            //    oneInert[1].Value = model.UserName;
            //else
            //    oneInert[1].Value = DBNull.Value;
            //if (model.UserDept != null)
            //    oneInert[2].Value = model.UserDept;
            //else
            //    oneInert[2].Value = DBNull.Value;
            //if (model.UserJob != null)
            //    oneInert[3].Value = model.UserJob;
            //else
            //    oneInert[3].Value = DBNull.Value;
            //if (model.Reserved01 != null)
            //    oneInert[4].Value = model.Reserved01;
            //else
            //    oneInert[4].Value = DBNull.Value;
            //if (model.CreateDate > DateTime.MinValue)
            //    oneInert[5].Value = model.CreateDate;
            //else
            //    oneInert[5].Value = DBNull.Value;
            //if (model.InputCode != null)
            //    oneInert[6].Value = model.InputCode;
            //else
            //    oneInert[6].Value = DBNull.Value;

            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, MED_HIS_USERS_Insert_SQL, oneInert);

        }
        #endregion
        #region [更新一条记录SQL]
        /// <summary>
        ///Update    model  MedHisUsers 
        ///Update Table     MED_HIS_USERS
        /// </summary>
        public int UpdateMedHisUsersSQL(MedHisUsers model, System.Data.Common.DbTransaction oleCisTrans)
        {
            SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedHisUsers");
            //if (model.UserId != null)
            //    oneUpdate[0].Value = model.UserId;
            //else
            //    oneUpdate[0].Value = DBNull.Value;
            //if (model.UserName != null)
            //    oneUpdate[1].Value = model.UserName;
            //else
            //    oneUpdate[1].Value = DBNull.Value;
            //if (model.UserDept != null)
            //    oneUpdate[2].Value = model.UserDept;
            //else
            //    oneUpdate[2].Value = DBNull.Value;
            //if (model.UserJob != null)
            //    oneUpdate[3].Value = model.UserJob;
            //else
            //    oneUpdate[3].Value = DBNull.Value;
            //if (model.Reserved01 != null)
            //    oneUpdate[4].Value = model.Reserved01;
            //else
            //    oneUpdate[4].Value = DBNull.Value;
            //if (model.CreateDate > DateTime.MinValue)
            //    oneUpdate[5].Value = model.CreateDate;
            //else
            //    oneUpdate[5].Value = DBNull.Value;
            //if (model.InputCode != null)
            //    oneUpdate[6].Value = model.InputCode;
            //else
            //    oneUpdate[6].Value = DBNull.Value;
            //if (model.UserId != null)
            //    oneUpdate[7].Value = model.UserId;
            //else
            //    oneUpdate[7].Value = DBNull.Value;

            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, MED_HIS_USERS_Update_SQL, oneUpdate);

        }
        #endregion
        #region [删除一条记录SQL]
        /// <summary>
        ///Delete    model  MedHisUsers 
        ///Delete Table MED_HIS_USERS by (string USER_ID)
        /// </summary>
        public int DeleteMedHisUsersSQL(string USER_ID, System.Data.Common.DbTransaction oleCisTrans)
        {
            SqlParameter[] oneDelete = GetParameterSQL("DeleteMedHisUsers");
            if (USER_ID != null)
                oneDelete[0].Value = USER_ID;
            else
                oneDelete[0].Value = DBNull.Value;

            return SqlHelper.ExecuteNonQuery((SqlTransaction)oleCisTrans, CommandType.Text, MED_HIS_USERS_Delete_SQL, oneDelete);

        }
        #endregion
        #region  [获取一条记录SQL]
        /// <summary>
        ///Select    model  MedHisUsers 
        ///select Table MED_HIS_USERS by (string USER_ID)
        /// </summary>
        public MedHisUsers SelectMedHisUsersSQL(string USER_ID, System.Data.Common.DbConnection oleCisConn)
        {
            MedHisUsers model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedHisUsers");
            parameterValues[0].Value = USER_ID;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_HIS_USERS_Select_SQL, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedHisUsers();
                    //if (!oleReader.IsDBNull(0))
                    //{
                    //    model.UserId = oleReader["USER_ID"].ToString().Trim();
                    //}
                    //if (!oleReader.IsDBNull(1))
                    //{
                    //    model.UserName = oleReader["USER_NAME"].ToString().Trim();
                    //}
                    //if (!oleReader.IsDBNull(2))
                    //{
                    //    model.UserDept = oleReader["USER_DEPT"].ToString().Trim();
                    //}
                    //if (!oleReader.IsDBNull(3))
                    //{
                    //    model.UserJob = oleReader["USER_JOB"].ToString().Trim();
                    //}
                    //if (!oleReader.IsDBNull(4))
                    //{
                    //    model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    //}
                    //if (!oleReader.IsDBNull(5))
                    //{
                    //    model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim());
                    //}
                    //if (!oleReader.IsDBNull(6))
                    //{
                    //    model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
                    //}
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion
        #region  [获取一条记录[NAME]SQL]
        /// <summary>
        ///Select    model  MedHisUsers 
        ///select Table MED_HIS_USERS by (string USER_ID)
        /// </summary>
        public MedHisUsers SelectMedHisUsersNameSQL(string USER_NAME, System.Data.Common.DbConnection oleCisConn)
        {
            MedHisUsers model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedHisUsersNAME");
            parameterValues[0].Value = USER_NAME;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_HIS_USERS_Select_Name_SQL, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedHisUsers();
                    //if (!oleReader.IsDBNull(0))
                    //{
                    //    model.UserId = oleReader["USER_ID"].ToString().Trim();
                    //}
                    //if (!oleReader.IsDBNull(1))
                    //{
                    //    model.UserName = oleReader["USER_NAME"].ToString().Trim();
                    //}
                    //if (!oleReader.IsDBNull(2))
                    //{
                    //    model.UserDept = oleReader["USER_DEPT"].ToString().Trim();
                    //}
                    //if (!oleReader.IsDBNull(3))
                    //{
                    //    model.UserJob = oleReader["USER_JOB"].ToString().Trim();
                    //}
                    //if (!oleReader.IsDBNull(4))
                    //{
                    //    model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    //}
                    //if (!oleReader.IsDBNull(5))
                    //{
                    //    model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim());
                    //}
                    //if (!oleReader.IsDBNull(6))
                    //{
                    //    model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
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
        public List<MedHisUsers> SelectMedHisUsersListSQL(System.Data.Common.DbConnection oleCisConn)
        {
            List<MedHisUsers> modelList = new List<MedHisUsers>();
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader((SqlConnection)oleCisConn, CommandType.Text, MED_HIS_USERS_Select_ALL_SQL, null))
            {
                while (oleReader.Read())
                {
                    MedHisUsers model = new MedHisUsers();
                    //if (!oleReader.IsDBNull(0))
                    //{
                    //    model.UserId = oleReader["USER_ID"].ToString().Trim();
                    //}
                    //if (!oleReader.IsDBNull(1))
                    //{
                    //    model.UserName = oleReader["USER_NAME"].ToString().Trim();
                    //}
                    //if (!oleReader.IsDBNull(2))
                    //{
                    //    model.UserDept = oleReader["USER_DEPT"].ToString().Trim();
                    //}
                    //if (!oleReader.IsDBNull(3))
                    //{
                    //    model.UserJob = oleReader["USER_JOB"].ToString().Trim();
                    //}
                    //if (!oleReader.IsDBNull(4))
                    //{
                    //    model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    //}
                    //if (!oleReader.IsDBNull(5))
                    //{
                    //    model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim());
                    //}
                    //if (!oleReader.IsDBNull(6))
                    //{
                    //    model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
                    //}
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

        #region [添加一条记录]
        /// <summary>
        ///Add    model  MedHisUsers 
        ///Insert Table MED_HIS_USERS
        /// </summary>
        public int InsertMedHisUsers(MedHisUsers model, System.Data.Common.DbTransaction oleCisTrans)
        {
            OracleParameter[] oneInert = GetParameter("InsertMedHisUsers");
            //if (model.UserId != null)
            //    oneInert[0].Value = model.UserId;
            //else
            //    oneInert[0].Value = DBNull.Value;
            //if (model.UserName != null)
            //    oneInert[1].Value = model.UserName;
            //else
            //    oneInert[1].Value = DBNull.Value;
            //if (model.UserDept != null)
            //    oneInert[2].Value = model.UserDept;
            //else
            //    oneInert[2].Value = DBNull.Value;
            //if (model.UserJob != null)
            //    oneInert[3].Value = model.UserJob;
            //else
            //    oneInert[3].Value = DBNull.Value;
            //if (model.Reserved01 != null)
            //    oneInert[4].Value = model.Reserved01;
            //else
            //    oneInert[4].Value = DBNull.Value;
            //if (model.CreateDate > DateTime.MinValue)
            //    oneInert[5].Value = model.CreateDate;
            //else
            //    oneInert[5].Value = DBNull.Value;
            //if (model.InputCode != null)
            //    oneInert[6].Value = model.InputCode;
            //else
            //    oneInert[6].Value = DBNull.Value;

            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, MED_HIS_USERS_Insert, oneInert);

        }
        #endregion
        #region [更新一条记录]
        /// <summary>
        ///Update    model  MedHisUsers 
        ///Update Table     MED_HIS_USERS
        /// </summary>
        public int UpdateMedHisUsers(MedHisUsers model, System.Data.Common.DbTransaction oleCisTrans)
        {
            OracleParameter[] oneUpdate = GetParameter("UpdateMedHisUsers");
            //if (model.UserId != null)
            //    oneUpdate[0].Value = model.UserId;
            //else
            //    oneUpdate[0].Value = DBNull.Value;
            //if (model.UserName != null)
            //    oneUpdate[1].Value = model.UserName;
            //else
            //    oneUpdate[1].Value = DBNull.Value;
            //if (model.UserDept != null)
            //    oneUpdate[2].Value = model.UserDept;
            //else
            //    oneUpdate[2].Value = DBNull.Value;
            //if (model.UserJob != null)
            //    oneUpdate[3].Value = model.UserJob;
            //else
            //    oneUpdate[3].Value = DBNull.Value;
            //if (model.Reserved01 != null)
            //    oneUpdate[4].Value = model.Reserved01;
            //else
            //    oneUpdate[4].Value = DBNull.Value;
            //if (model.CreateDate > DateTime.MinValue)
            //    oneUpdate[5].Value = model.CreateDate;
            //else
            //    oneUpdate[5].Value = DBNull.Value;
            //if (model.InputCode != null)
            //    oneUpdate[6].Value = model.InputCode;
            //else
            //    oneUpdate[6].Value = DBNull.Value;
            //if (model.UserId != null)
            //    oneUpdate[7].Value = model.UserId;
            //else
            //    oneUpdate[7].Value = DBNull.Value;

            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, MED_HIS_USERS_Update, oneUpdate);

        }
        #endregion
        #region [删除一条记录]
        /// <summary>
        ///Delete    model  MedHisUsers 
        ///Delete Table MED_HIS_USERS by (string USER_ID)
        /// </summary>
        public int DeleteMedHisUsers(string USER_ID, System.Data.Common.DbTransaction oleCisTrans)
        {
            OracleParameter[] oneDelete = GetParameter("DeleteMedHisUsers");
            if (USER_ID != null)
                oneDelete[0].Value = USER_ID;
            else
                oneDelete[0].Value = DBNull.Value;

            return OracleHelper.ExecuteNonQuery((OracleTransaction)oleCisTrans, CommandType.Text, MED_HIS_USERS_Delete, oneDelete);

        }
        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedHisUsers 
        ///select Table MED_HIS_USERS by (string USER_ID)
        /// </summary>
        public MedHisUsers SelectMedHisUsers(string USER_ID, System.Data.Common.DbConnection oleCisConn)
        {
            MedHisUsers model;
            OracleParameter[] parameterValues = GetParameter("SelectMedHisUsers");
            parameterValues[0].Value = USER_ID;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_HIS_USERS_Select, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedHisUsers();
                    //if (!oleReader.IsDBNull(0))
                    //{
                    //    model.UserId = oleReader["USER_ID"].ToString().Trim();
                    //}
                    //if (!oleReader.IsDBNull(1))
                    //{
                    //    model.UserName = oleReader["USER_NAME"].ToString().Trim();
                    //}
                    //if (!oleReader.IsDBNull(2))
                    //{
                    //    model.UserDept = oleReader["USER_DEPT"].ToString().Trim();
                    //}
                    //if (!oleReader.IsDBNull(3))
                    //{
                    //    model.UserJob = oleReader["USER_JOB"].ToString().Trim();
                    //}
                    //if (!oleReader.IsDBNull(4))
                    //{
                    //    model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    //}
                    //if (!oleReader.IsDBNull(5))
                    //{
                    //    model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim());
                    //}
                    //if (!oleReader.IsDBNull(6))
                    //{
                    //    model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
                    //}
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion
        #region  [获取一条记录[NAME]]
        /// <summary>
        ///Select    model  MedHisUsers 
        ///select Table MED_HIS_USERS by (string USER_ID)
        /// </summary>
        public MedHisUsers SelectMedHisUsersName(string USER_NAME, System.Data.Common.DbConnection oleCisConn)
        {
            MedHisUsers model;
            OracleParameter[] parameterValues = GetParameter("SelectMedHisUsersNAME");
            parameterValues[0].Value = USER_NAME;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_HIS_USERS_Select_Name, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedHisUsers();
                    //if (!oleReader.IsDBNull(0))
                    //{
                    //    model.UserId = oleReader["USER_ID"].ToString().Trim();
                    //}
                    //if (!oleReader.IsDBNull(1))
                    //{
                    //    model.UserName = oleReader["USER_NAME"].ToString().Trim();
                    //}
                    //if (!oleReader.IsDBNull(2))
                    //{
                    //    model.UserDept = oleReader["USER_DEPT"].ToString().Trim();
                    //}
                    //if (!oleReader.IsDBNull(3))
                    //{
                    //    model.UserJob = oleReader["USER_JOB"].ToString().Trim();
                    //}
                    //if (!oleReader.IsDBNull(4))
                    //{
                    //    model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    //}
                    //if (!oleReader.IsDBNull(5))
                    //{
                    //    model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim());
                    //}
                    //if (!oleReader.IsDBNull(6))
                    //{
                    //    model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
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
        public List<MedHisUsers> SelectMedHisUsersList(System.Data.Common.DbConnection oleCisConn)
        {
            List<MedHisUsers> modelList = new List<MedHisUsers>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader((OracleConnection)oleCisConn, CommandType.Text, MED_HIS_USERS_Select_ALL, null))
            {
                while (oleReader.Read())
                {
                    MedHisUsers model = new MedHisUsers();
                    //if (!oleReader.IsDBNull(0))
                    //{
                    //    model.UserId = oleReader["USER_ID"].ToString().Trim();
                    //}
                    //if (!oleReader.IsDBNull(1))
                    //{
                    //    model.UserName = oleReader["USER_NAME"].ToString().Trim();
                    //}
                    //if (!oleReader.IsDBNull(2))
                    //{
                    //    model.UserDept = oleReader["USER_DEPT"].ToString().Trim();
                    //}
                    //if (!oleReader.IsDBNull(3))
                    //{
                    //    model.UserJob = oleReader["USER_JOB"].ToString().Trim();
                    //}
                    //if (!oleReader.IsDBNull(4))
                    //{
                    //    model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    //}
                    //if (!oleReader.IsDBNull(5))
                    //{
                    //    model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim());
                    //}
                    //if (!oleReader.IsDBNull(6))
                    //{
                    //    model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
                    //}
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion

    }
}
