

/*********************************************************************
 * Author:    雷锋爷爷
 * Date:      2010/6/30 15:39:38
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
	/// DAL MedEmrUsers
	/// </summary>

    public class DALMedEmrUsers
    {
        private static readonly string MED_EMR_USERS_Insert_SQL = "INSERT INTO MED_EMR_USERS (USER_ID,LOGIN_NAME,LOGIN_PWD,NAME,DEPT_CODE,INPUT_CODE,JOB,TITLE,GRANT_CODE,IS_VALID) values (@UserId,@LoginName,@LoginPwd,@Name,@DeptCode,@InputCode,@Job,@Title,@GrantCode,@IsValid)";
        private static readonly string MED_EMR_USERS_Update_SQL = "UPDATE MED_EMR_USERS SET USER_ID=@UserId,LOGIN_NAME=@LoginName,LOGIN_PWD=@LoginPwd,NAME=@Name,DEPT_CODE=@DeptCode,INPUT_CODE=@InputCode,JOB=@Job,TITLE=@Title,GRANT_CODE=@GrantCode,IS_VALID=@IsValid WHERE  USER_ID=@UserId";
        private static readonly string MED_EMR_USERS_Delete_SQL = "DELETE MED_EMR_USERS WHERE  USER_ID=@UserId";
        private static readonly string MED_EMR_USERS_Select_SQL = "SELECT USER_ID,LOGIN_NAME,LOGIN_PWD,NAME,DEPT_CODE,INPUT_CODE,JOB,TITLE,GRANT_CODE,IS_VALID FROM MED_EMR_USERS where  USER_ID=@UserId";
        private static readonly string MED_EMR_USERS_Select_ALL_SQL = "SELECT USER_ID,LOGIN_NAME,LOGIN_PWD,NAME,DEPT_CODE,INPUT_CODE,JOB,TITLE,GRANT_CODE,IS_VALID FROM MED_EMR_USERS";
        private static readonly string MED_EMR_USERS_Select_ForPwd_SQL = "SELECT USER_ID,LOGIN_NAME,LOGIN_PWD,NAME,DEPT_CODE,INPUT_CODE,JOB,TITLE,GRANT_CODE,IS_VALID FROM MED_EMR_USERS where  LOGIN_NAME=@LoginName AND LOGIN_PWD = @LoginPwd ";
        private static readonly string MED_EMR_USERS_Insert = "INSERT INTO MED_EMR_USERS (USER_ID,LOGIN_NAME,LOGIN_PWD,NAME,DEPT_CODE,INPUT_CODE,JOB,TITLE,GRANT_CODE,IS_VALID) values (:UserId,:LoginName,:LoginPwd,:Name,:DeptCode,:InputCode,:Job,:Title,:GrantCode,:IsValid)";
        private static readonly string MED_EMR_USERS_Update = "UPDATE MED_EMR_USERS SET USER_ID=:UserId,LOGIN_NAME=:LoginName,LOGIN_PWD=:LoginPwd,NAME=:Name,DEPT_CODE=:DeptCode,INPUT_CODE=:InputCode,JOB=:Job,TITLE=:Title,GRANT_CODE=:GrantCode,IS_VALID=:IsValid WHERE  USER_ID=:UserId";
        private static readonly string MED_EMR_USERS_Delete = "DELETE MED_EMR_USERS WHERE  USER_ID=:UserId";
        private static readonly string MED_EMR_USERS_Select = "SELECT USER_ID,LOGIN_NAME,LOGIN_PWD,NAME,DEPT_CODE,INPUT_CODE,JOB,TITLE,GRANT_CODE,IS_VALID FROM MED_EMR_USERS where  USER_ID=:UserId";
        private static readonly string MED_EMR_USERS_Select_ALL = "SELECT USER_ID,LOGIN_NAME,LOGIN_PWD,NAME,DEPT_CODE,INPUT_CODE,JOB,TITLE,GRANT_CODE,IS_VALID FROM MED_EMR_USERS";
        private static readonly string MED_EMR_USERS_Select_ForPwd = "SELECT USER_ID,LOGIN_NAME,LOGIN_PWD,NAME,DEPT_CODE,INPUT_CODE,JOB,TITLE,GRANT_CODE,IS_VALID FROM MED_EMR_USERS where  LOGIN_NAME=:LoginName AND LOGIN_PWD = :LoginPwd ";

        public DALMedEmrUsers()
        {
        }

        #region [获取参数SQL]
        /// <summary>
        ///获取参数MedEmrUsers SQL
        /// </summary>
        public static SqlParameter[] GetParameterSQL(string sqlParms)
        {
            SqlParameter[] parms = SqlHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedEmrUsers")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@UserId",SqlDbType.VarChar),
							new SqlParameter("@LoginName",SqlDbType.VarChar),
							new SqlParameter("@LoginPwd",SqlDbType.VarChar),
							new SqlParameter("@Name",SqlDbType.VarChar),
							new SqlParameter("@DeptCode",SqlDbType.VarChar),
							new SqlParameter("@InputCode",SqlDbType.VarChar),
							new SqlParameter("@Job",SqlDbType.VarChar),
							new SqlParameter("@Title",SqlDbType.VarChar),
							new SqlParameter("@GrantCode",SqlDbType.VarChar),
							new SqlParameter("@IsValid",SqlDbType.Decimal),
                    };
                }
                else if (sqlParms == "UpdateMedEmrUsers")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@UserId",SqlDbType.VarChar),
							new SqlParameter("@LoginName",SqlDbType.VarChar),
							new SqlParameter("@LoginPwd",SqlDbType.VarChar),
							new SqlParameter("@Name",SqlDbType.VarChar),
							new SqlParameter("@DeptCode",SqlDbType.VarChar),
							new SqlParameter("@InputCode",SqlDbType.VarChar),
							new SqlParameter("@Job",SqlDbType.VarChar),
							new SqlParameter("@Title",SqlDbType.VarChar),
							new SqlParameter("@GrantCode",SqlDbType.VarChar),
							new SqlParameter("@IsValid",SqlDbType.Decimal),
							new SqlParameter("@UserId",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "DeleteMedEmrUsers")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@UserId",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedEmrUsers")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@UserId",SqlDbType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedEmrUsersForPwd")
                {
                    parms = new SqlParameter[]{
							new SqlParameter("@LoginName",SqlDbType.VarChar),
                            new SqlParameter("@LoginPwd",SqlDbType.VarChar),
                    };
                }
                SqlHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录SQL]
        /// <summary>
        ///Add    model  MedEmrUsers 
        ///Insert Table MED_EMR_USERS
        /// </summary>
        public int InsertMedEmrUsersSQL(MedEmrUsers model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneInert = GetParameterSQL("InsertMedEmrUsers");
                if (model.UserId != null)
                    oneInert[0].Value = model.UserId;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.LoginName != null)
                    oneInert[1].Value = model.LoginName;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.LoginPwd != null)
                    oneInert[2].Value = model.LoginPwd;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.Name != null)
                    oneInert[3].Value = model.Name;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.DeptCode != null)
                    oneInert[4].Value = model.DeptCode;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.InputCode != null)
                    oneInert[5].Value = model.InputCode;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.Job != null)
                    oneInert[6].Value = model.Job;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.Title != null)
                    oneInert[7].Value = model.Title;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.GrantCode != null)
                    oneInert[8].Value = model.GrantCode;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.IsValid.ToString() != null)
                    oneInert[9].Value = model.IsValid;
                else
                    oneInert[9].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_EMR_USERS_Insert_SQL, oneInert);
            }
        }
        #endregion
        #region [更新一条记录SQL]
        /// <summary>
        ///Update    model  MedEmrUsers 
        ///Update Table     MED_EMR_USERS
        /// </summary>
        public int UpdateMedEmrUsersSQL(MedEmrUsers model)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneUpdate = GetParameterSQL("UpdateMedEmrUsers");
                if (model.UserId != null)
                    oneUpdate[0].Value = model.UserId;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.LoginName != null)
                    oneUpdate[1].Value = model.LoginName;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.LoginPwd != null)
                    oneUpdate[2].Value = model.LoginPwd;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.Name != null)
                    oneUpdate[3].Value = model.Name;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.DeptCode != null)
                    oneUpdate[4].Value = model.DeptCode;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.InputCode != null)
                    oneUpdate[5].Value = model.InputCode;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.Job != null)
                    oneUpdate[6].Value = model.Job;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.Title != null)
                    oneUpdate[7].Value = model.Title;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.GrantCode != null)
                    oneUpdate[8].Value = model.GrantCode;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.IsValid.ToString() != null)
                    oneUpdate[9].Value = model.IsValid;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (model.UserId != null)
                    oneUpdate[10].Value = model.UserId;
                else
                    oneUpdate[10].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_EMR_USERS_Update_SQL, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录SQL]
        /// <summary>
        ///Delete    model  MedEmrUsers 
        ///Delete Table MED_EMR_USERS by (string USER_ID)
        /// </summary>
        public int DeleteMedEmrUsersSQL(string USER_ID)
        {
            using (SqlConnection oleCisConn = new SqlConnection(SqlHelper.ConnectionString))
            {
                SqlParameter[] oneDelete = GetParameterSQL("DeleteMedEmrUsers");
                if (USER_ID != null)
                    oneDelete[0].Value = USER_ID;
                else
                    oneDelete[0].Value = DBNull.Value;

                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString, MED_EMR_USERS_Delete_SQL, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录SQL]
        /// <summary>
        ///Select    model  MedEmrUsers 
        ///select Table MED_EMR_USERS by (string USER_ID)
        /// </summary>
        public MedEmrUsers SelectMedEmrUsersSQL(string USER_ID)
        {
            MedEmrUsers model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedEmrUsers");
            parameterValues[0].Value = USER_ID;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_EMR_USERS_Select_SQL, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedEmrUsers();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.UserId = oleReader["USER_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.LoginName = oleReader["LOGIN_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.LoginPwd = oleReader["LOGIN_PWD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.Name = oleReader["NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.Job = oleReader["JOB"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.Title = oleReader["TITLE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.GrantCode = oleReader["GRANT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.IsValid = decimal.Parse(oleReader["IS_VALID"].ToString().Trim());
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
        public List<MedEmrUsers> SelectMedEmrUsersListSQL()
        {
            List<MedEmrUsers> modelList = new List<MedEmrUsers>();
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_EMR_USERS_Select_ALL_SQL, null))
            {
                while (oleReader.Read())
                {
                    MedEmrUsers model = new MedEmrUsers();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.UserId = oleReader["USER_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.LoginName = oleReader["LOGIN_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.LoginPwd = oleReader["LOGIN_PWD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.Name = oleReader["NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.Job = oleReader["JOB"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.Title = oleReader["TITLE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.GrantCode = oleReader["GRANT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.IsValid = decimal.Parse(oleReader["IS_VALID"].ToString().Trim());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion
        #region  [获取一条记录SQL]
        /// <summary>
        ///Select    model  MedEmrUsers 
        ///select Table MED_EMR_USERS by (string USER_ID)
        /// </summary>
        public MedEmrUsers SelectMedEmrUsersForPwdSQL(string LOGIN_NAME, string LOGIN_PWD)
        {
            MedEmrUsers model;
            SqlParameter[] parameterValues = GetParameterSQL("SelectMedEmrUsersForPwd");
            parameterValues[0].Value = LOGIN_NAME;
            parameterValues[1].Value = LOGIN_PWD;
            using (SqlDataReader oleReader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString, CommandType.Text, MED_EMR_USERS_Select_ForPwd_SQL, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedEmrUsers();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.UserId = oleReader["USER_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.LoginName = oleReader["LOGIN_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.LoginPwd = oleReader["LOGIN_PWD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.Name = oleReader["NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.Job = oleReader["JOB"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.Title = oleReader["TITLE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.GrantCode = oleReader["GRANT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.IsValid = decimal.Parse(oleReader["IS_VALID"].ToString().Trim());
                    }
                }
                else
                    model = null;
            }
            return model;
        }
        #endregion

        #region [获取参数]
        /// <summary>
        ///获取参数MedEmrUsers
        /// </summary>
        public static OracleParameter[] GetParameter(string sqlParms)
        {
            OracleParameter[] parms = OracleHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "InsertMedEmrUsers")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":UserId",OracleType.VarChar),
							new OracleParameter(":LoginName",OracleType.VarChar),
							new OracleParameter(":LoginPwd",OracleType.VarChar),
							new OracleParameter(":Name",OracleType.VarChar),
							new OracleParameter(":DeptCode",OracleType.VarChar),
							new OracleParameter(":InputCode",OracleType.VarChar),
							new OracleParameter(":Job",OracleType.VarChar),
							new OracleParameter(":Title",OracleType.VarChar),
							new OracleParameter(":GrantCode",OracleType.VarChar),
							new OracleParameter(":IsValid",OracleType.Number),
                    };
                }
                else if (sqlParms == "UpdateMedEmrUsers")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":UserId",OracleType.VarChar),
							new OracleParameter(":LoginName",OracleType.VarChar),
							new OracleParameter(":LoginPwd",OracleType.VarChar),
							new OracleParameter(":Name",OracleType.VarChar),
							new OracleParameter(":DeptCode",OracleType.VarChar),
							new OracleParameter(":InputCode",OracleType.VarChar),
							new OracleParameter(":Job",OracleType.VarChar),
							new OracleParameter(":Title",OracleType.VarChar),
							new OracleParameter(":GrantCode",OracleType.VarChar),
							new OracleParameter(":IsValid",OracleType.Number),
							new OracleParameter(":UserId",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "DeleteMedEmrUsers")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":UserId",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedEmrUsers")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":UserId",OracleType.VarChar),
                    };
                }
                else if (sqlParms == "SelectMedEmrUsersForPwd")
                {
                    parms = new OracleParameter[]{
							new OracleParameter(":LoginName",OracleType.VarChar),
                            new OracleParameter(":LoginPwd",OracleType.VarChar),
                    };
                }
                OracleHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        #endregion
        #region [添加一条记录]
        /// <summary>
        ///Add    model  MedEmrUsers 
        ///Insert Table MED_EMR_USERS
        /// </summary>
        public int InsertMedEmrUsers(MedEmrUsers model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneInert = GetParameter("InsertMedEmrUsers");
                if (model.UserId != null)
                    oneInert[0].Value = model.UserId;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.LoginName != null)
                    oneInert[1].Value = model.LoginName;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.LoginPwd != null)
                    oneInert[2].Value = model.LoginPwd;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.Name != null)
                    oneInert[3].Value = model.Name;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.DeptCode != null)
                    oneInert[4].Value = model.DeptCode;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.InputCode != null)
                    oneInert[5].Value = model.InputCode;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.Job != null)
                    oneInert[6].Value = model.Job;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.Title != null)
                    oneInert[7].Value = model.Title;
                else
                    oneInert[7].Value = DBNull.Value;
                if (model.GrantCode != null)
                    oneInert[8].Value = model.GrantCode;
                else
                    oneInert[8].Value = DBNull.Value;
                if (model.IsValid.ToString() != null)
                    oneInert[9].Value = model.IsValid;
                else
                    oneInert[9].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_EMR_USERS_Insert, oneInert);
            }
        }
        #endregion
        #region [更新一条记录]
        /// <summary>
        ///Update    model  MedEmrUsers 
        ///Update Table     MED_EMR_USERS
        /// </summary>
        public int UpdateMedEmrUsers(MedEmrUsers model)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneUpdate = GetParameter("UpdateMedEmrUsers");
                if (model.UserId != null)
                    oneUpdate[0].Value = model.UserId;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.LoginName != null)
                    oneUpdate[1].Value = model.LoginName;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.LoginPwd != null)
                    oneUpdate[2].Value = model.LoginPwd;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.Name != null)
                    oneUpdate[3].Value = model.Name;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.DeptCode != null)
                    oneUpdate[4].Value = model.DeptCode;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.InputCode != null)
                    oneUpdate[5].Value = model.InputCode;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.Job != null)
                    oneUpdate[6].Value = model.Job;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.Title != null)
                    oneUpdate[7].Value = model.Title;
                else
                    oneUpdate[7].Value = DBNull.Value;
                if (model.GrantCode != null)
                    oneUpdate[8].Value = model.GrantCode;
                else
                    oneUpdate[8].Value = DBNull.Value;
                if (model.IsValid.ToString() != null)
                    oneUpdate[9].Value = model.IsValid;
                else
                    oneUpdate[9].Value = DBNull.Value;
                if (model.UserId != null)
                    oneUpdate[10].Value = model.UserId;
                else
                    oneUpdate[10].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_EMR_USERS_Update, oneUpdate);
            }
        }
        #endregion
        #region [删除一条记录]
        /// <summary>
        ///Delete    model  MedEmrUsers 
        ///Delete Table MED_EMR_USERS by (string USER_ID)
        /// </summary>
        public int DeleteMedEmrUsers(string USER_ID)
        {
            using (OracleConnection oleCisConn = new OracleConnection(OracleHelper.ConnectionString))
            {
                OracleParameter[] oneDelete = GetParameter("DeleteMedEmrUsers");
                if (USER_ID != null)
                    oneDelete[0].Value = USER_ID;
                else
                    oneDelete[0].Value = DBNull.Value;

                return OracleHelper.ExecuteNonQuery(OracleHelper.ConnectionString, MED_EMR_USERS_Delete, oneDelete);
            }
        }
        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedEmrUsers 
        ///select Table MED_EMR_USERS by (string USER_ID)
        /// </summary>
        public MedEmrUsers SelectMedEmrUsers(string USER_ID)
        {
            MedEmrUsers model;
            OracleParameter[] parameterValues = GetParameter("SelectMedEmrUsers");
            parameterValues[0].Value = USER_ID;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_EMR_USERS_Select, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedEmrUsers();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.UserId = oleReader["USER_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.LoginName = oleReader["LOGIN_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.LoginPwd = oleReader["LOGIN_PWD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.Name = oleReader["NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.Job = oleReader["JOB"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.Title = oleReader["TITLE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.GrantCode = oleReader["GRANT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.IsValid = decimal.Parse(oleReader["IS_VALID"].ToString().Trim());
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
        public List<MedEmrUsers> SelectMedEmrUsersList()
        {
            List<MedEmrUsers> modelList = new List<MedEmrUsers>();
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_EMR_USERS_Select_ALL, null))
            {
                while (oleReader.Read())
                {
                    MedEmrUsers model = new MedEmrUsers();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.UserId = oleReader["USER_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.LoginName = oleReader["LOGIN_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.LoginPwd = oleReader["LOGIN_PWD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.Name = oleReader["NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.Job = oleReader["JOB"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.Title = oleReader["TITLE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.GrantCode = oleReader["GRANT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.IsValid = decimal.Parse(oleReader["IS_VALID"].ToString().Trim());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion
        #region  [获取一条记录]
        /// <summary>
        ///Select    model  MedEmrUsers 
        ///select Table MED_EMR_USERS by (string USER_ID)
        /// </summary>
        public MedEmrUsers SelectMedEmrUsersForPwd(string LOGIN_NAME, string LOGIN_PWD)
        {
            MedEmrUsers model;
            OracleParameter[] parameterValues = GetParameter("SelectMedEmrUsersForPwd");
            parameterValues[0].Value = LOGIN_NAME;
            parameterValues[1].Value = LOGIN_PWD;
            using (OracleDataReader oleReader = OracleHelper.ExecuteReader(OracleHelper.ConnectionString, CommandType.Text, MED_EMR_USERS_Select_ForPwd, parameterValues))
            {
                if (oleReader.Read())
                {
                    model = new MedEmrUsers();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.UserId = oleReader["USER_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.LoginName = oleReader["LOGIN_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.LoginPwd = oleReader["LOGIN_PWD"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.Name = oleReader["NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.DeptCode = oleReader["DEPT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.Job = oleReader["JOB"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(7))
                    {
                        model.Title = oleReader["TITLE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(8))
                    {
                        model.GrantCode = oleReader["GRANT_CODE"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(9))
                    {
                        model.IsValid = decimal.Parse(oleReader["IS_VALID"].ToString().Trim());
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
