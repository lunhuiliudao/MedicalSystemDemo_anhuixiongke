using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data.Odbc;
using MedicalSytem.Soft.Model;

namespace MedicalSytem.Soft.DAL
{
	/// <summary>
	/// DAL MedHisUsers
	/// </summary>
	
	public partial class DALMedHisUsers
    {
        private static readonly string Select_MedHisUsers_OLE_ALL = "select USER_JOB_ID,USER_NAME,USER_DEPT_CODE,USER_JOB,RESERVED01,CREATE_DATE,INPUT_CODE,USER_STATUS,SORT_NO from med_his_users";
        private static readonly string Select_MedHisUsers_OLE = "select USER_JOB_ID,USER_NAME,USER_DEPT_CODE,USER_JOB,RESERVED01,CREATE_DATE,INPUT_CODE,USER_STATUS,SORT_NO from med_his_users WHERE user_id = ? ";
        private static readonly string Select_MedHisUsersName_OLE = "select USER_JOB_ID,USER_NAME,USER_DEPT_CODE,USER_JOB,RESERVED01,CREATE_DATE,INPUT_CODE,USER_STATUS,SORT_NO from med_his_users WHERE user_name = ? ";
        private static readonly string Insert_MedHisUsers_OLE = "INSERT INTO MED_HIS_USERS (USER_JOB_ID,USER_NAME,USER_DEPT_CODE,USER_JOB,RESERVED01,CREATE_DATE,INPUT_CODE,USER_STATUS) values (?,?,?,?,?,?,?,? )";
        private static readonly string Update_MedHisUsers_OLE = "UPDATE MED_HIS_USERS SET USER_NAME=?,USER_DEPT_CODE=?,USER_JOB=?,RESERVED01=?,CREATE_DATE=?,INPUT_CODE=?,USER_STATUS=?  WHERE USER_JOB_ID=?";

        public static OleDbParameter[] GetParameterOLE(string sqlParms)
        {
            OleDbParameter[] parms = OleDbHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedHisUsers")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("userId",OleDbType.VarChar)
                    };
                }
                else if (sqlParms == "InsertMedHisUsers")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("userId",OleDbType.VarChar),
                        new OleDbParameter("userName",OleDbType.VarChar), 
                        new OleDbParameter("userDept",OleDbType.VarChar), 
                        new OleDbParameter("userJob",OleDbType.VarChar),
                        new OleDbParameter("reserved01",OleDbType.VarChar),
                        new OleDbParameter("createDate",OleDbType.DBTimeStamp),
                        new OleDbParameter("inputCode",OleDbType.VarChar)
                    };
                }
                else if (sqlParms == "UpdateMedHisUsers")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("userName",OleDbType.VarChar), 
                        new OleDbParameter("userDept",OleDbType.VarChar), 
                        new OleDbParameter("userJob",OleDbType.VarChar),
                        new OleDbParameter("reserved01",OleDbType.VarChar),
                        new OleDbParameter("createDate",OleDbType.DBTimeStamp),
                        new OleDbParameter("inputCode",OleDbType.VarChar),
                        new OleDbParameter("userId",OleDbType.VarChar)
                    };
                }
                else if (sqlParms == "SelectMedHisUsersName")
                {
                    parms = new OleDbParameter[]{
                        new OleDbParameter("userName",OleDbType.VarChar)
                    };
                }
                OleDbHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        /// <summary>
        /// 根据USERID查看人员信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Model.MedHisUsers SelectMedHisUsersOLE(string userId)
        {
            Model.MedHisUsers model = null;

            OleDbParameter[] paramHisUsers = GetParameterOLE("SelectMedHisUsers");
            paramHisUsers[0].Value = userId;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_MedHisUsers_OLE, paramHisUsers))
            {
                if (oleReader.Read())
                {
                    model = new Model.MedHisUsers();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.UserJobId = oleReader["USER_JOB_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.UserName = oleReader["USER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.UserDeptCode = oleReader["USER_DEPT_Code"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.UserJob = oleReader["USER_JOB"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }

        public Model.MedHisUsers SelectMedHisUsersNameOLE(string userName)
        {
            Model.MedHisUsers model = null;

            OleDbParameter[] paramHisUsers = GetParameterOLE("SelectMedHisUsersName");
            paramHisUsers[0].Value = userName;

            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_MedHisUsersName_OLE, paramHisUsers))
            {
                if (oleReader.Read())
                {
                    model = new Model.MedHisUsers();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.UserJobId = oleReader["USER_JOB_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.UserName = oleReader["USER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.UserDeptCode = oleReader["USER_DEPT_Code"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.UserJob = oleReader["USER_JOB"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
                    }
                }
                else
                    model = null;
            }
            return model;
        }

        public int InsertMedHisUsersOLE(Model.MedHisUsers model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneInert = GetParameterOLE("InsertMedHisUsers");
                if (model.UserJobId != null)
                    oneInert[0].Value = model.UserJobId;
                else
                    oneInert[0].Value = DBNull.Value;
                if (model.UserName != null)
                    oneInert[1].Value = model.UserName;
                else
                    oneInert[1].Value = DBNull.Value;
                if (model.UserDeptCode != null)
                    oneInert[2].Value = model.UserDeptCode;
                else
                    oneInert[2].Value = DBNull.Value;
                if (model.UserJob != null)
                    oneInert[3].Value = model.UserJob;
                else
                    oneInert[3].Value = DBNull.Value;
                if (model.Reserved01 != null)
                    oneInert[4].Value = model.Reserved01;
                else
                    oneInert[4].Value = DBNull.Value;
                if (model.CreateDate > DateTime.MinValue)
                    oneInert[5].Value = model.CreateDate;
                else
                    oneInert[5].Value = DBNull.Value;
                if (model.InputCode != null)
                    oneInert[6].Value = model.InputCode;
                else
                    oneInert[6].Value = DBNull.Value;
                if (model.UserStatus != null)
                    oneInert[7].Value = model.UserStatus;
                else
                    oneInert[7].Value = DBNull.Value;
			

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Insert_MedHisUsers_OLE, oneInert);
            }
        }

        public int UpdateMedHisUsersOLE(Model.MedHisUsers model)
        {
            using (OleDbConnection oleCisConn = new OleDbConnection(OleDbHelper.ConnectionString))
            {
                OleDbParameter[] oneUpdate = GetParameterOLE("UpdateMedHisUsers");

                if (model.UserName != null)
                    oneUpdate[0].Value = model.UserName;
                else
                    oneUpdate[0].Value = DBNull.Value;
                if (model.UserDeptCode != null)
                    oneUpdate[1].Value = model.UserDeptCode;
                else
                    oneUpdate[1].Value = DBNull.Value;
                if (model.UserJob != null)
                    oneUpdate[2].Value = model.UserJob;
                else
                    oneUpdate[2].Value = DBNull.Value;
                if (model.Reserved01 != null)
                    oneUpdate[3].Value = model.Reserved01;
                else
                    oneUpdate[3].Value = DBNull.Value;
                if (model.CreateDate > DateTime.MinValue)
                    oneUpdate[4].Value = model.CreateDate;
                else
                    oneUpdate[4].Value = DBNull.Value;
                if (model.InputCode != null)
                    oneUpdate[5].Value = model.InputCode;
                else
                    oneUpdate[5].Value = DBNull.Value;
                if (model.UserStatus != null)
                    oneUpdate[6].Value = model.UserStatus;
                else
                    oneUpdate[6].Value = DBNull.Value;
                if (model.UserJobId != null)
                    oneUpdate[7].Value = model.UserJobId;
                else
                    oneUpdate[7].Value = DBNull.Value;
			

                return OleDbHelper.ExecuteNonQuery(oleCisConn, CommandType.Text, Update_MedHisUsers_OLE, oneUpdate);
            }
        }

        public List<Model.MedHisUsers> SelectMedHisUserListOLE()
        {
            List<MedHisUsers> result = new List<MedHisUsers>();
            using (OleDbDataReader oleReader = OleDbHelper.ExecuteReader(OleDbHelper.ConnectionString, CommandType.Text, Select_MedHisUsers_OLE_ALL, null))
            {
                while (oleReader.Read())
                {
                    MedHisUsers model = new Model.MedHisUsers();
                    if (!oleReader.IsDBNull(0))
                    {
                        model.UserJobId = oleReader["USER_JOB_ID"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(1))
                    {
                        model.UserName = oleReader["USER_NAME"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(2))
                    {
                        model.UserDeptCode = oleReader["USER_DEPT_Code"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(3))
                    {
                        model.UserJob = oleReader["USER_JOB"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(4))
                    {
                        model.Reserved01 = oleReader["RESERVED01"].ToString().Trim();
                    }
                    if (!oleReader.IsDBNull(5))
                    {
                        model.CreateDate = DateTime.Parse(oleReader["CREATE_DATE"].ToString().Trim());
                    }
                    if (!oleReader.IsDBNull(6))
                    {
                        model.InputCode = oleReader["INPUT_CODE"].ToString().Trim();
                    }
                    result.Add(model);
                }
             
            }
            return result;
        }

        private static readonly string Select_MedHisUsers_Odbc = "select user_id, user_name, user_dept, user_job, reserved01, create_date, input_code from med_his_users WHERE user_id = ? ";
        private static readonly string Select_MedHisUsersName_Odbc = "select user_id, user_name, user_dept, user_job, reserved01, create_date, input_code from med_his_users WHERE user_name = ? ";
        private static readonly string Insert_MedHisUsers_Odbc = "insert into med_his_users(user_id, user_name, user_dept, user_job, reserved01, create_date, input_code)values(?, ?, ?, ?,?,?,?)";
        private static readonly string Update_MedHisUsers_Odbc = "update med_his_users set user_name = ?,user_dept = ?,user_job = ?,reserved01 = ?,create_date = ?,input_code = ? where user_id = ?";

        public static OdbcParameter[] GetParameterOdbc(string sqlParms)
        {
            OdbcParameter[] parms = OdbcHelper.GetCachedParameters(sqlParms);
            if (parms == null)
            {
                if (sqlParms == "SelectMedHisUsers")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("userId",OdbcType.VarChar)
                    };
                }
                else if (sqlParms == "InsertMedHisUsers")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("userId",OdbcType.VarChar),
                        new OdbcParameter("userName",OdbcType.VarChar), 
                        new OdbcParameter("userDept",OdbcType.VarChar), 
                        new OdbcParameter("userJob",OdbcType.VarChar),
                        new OdbcParameter("reserved01",OdbcType.VarChar),
                        new OdbcParameter("createDate",OdbcType.DateTime),
                        new OdbcParameter("inputCode",OdbcType.VarChar)
                    };
                }
                else if (sqlParms == "UpdateMedHisUsers")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("userName",OdbcType.VarChar), 
                        new OdbcParameter("userDept",OdbcType.VarChar), 
                        new OdbcParameter("userJob",OdbcType.VarChar),
                        new OdbcParameter("reserved01",OdbcType.VarChar),
                        new OdbcParameter("createDate",OdbcType.DateTime),
                        new OdbcParameter("inputCode",OdbcType.VarChar),
                        new OdbcParameter("userId",OdbcType.VarChar)
                    };
                }
                else if (sqlParms == "SelectMedHisUsersName")
                {
                    parms = new OdbcParameter[]{
                        new OdbcParameter("userName",OdbcType.VarChar)
                    };
                }
                OdbcHelper.CacheParameters(sqlParms, parms);
            }
            return parms;
        }
        /// <summary>
        /// 根据USERID查看人员信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Model.MedHisUsers SelectMedHisUsersOdbc(string userId)
        {
            Model.MedHisUsers OneMedHisUsers = null;

            OdbcParameter[] paramHisUsers = GetParameterOdbc("SelectMedHisUsers");
            paramHisUsers[0].Value = userId;

            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_MedHisUsers_Odbc, paramHisUsers))
            {
                if (OdbcReader.Read())
                {
                    OneMedHisUsers = new Model.MedHisUsers();
                    //if (!OdbcReader.IsDBNull(0))
                    //    OneMedHisUsers.UserId = OdbcReader.GetString(0);
                    //if (!OdbcReader.IsDBNull(2))
                    //    OneMedHisUsers.UserName = OdbcReader.GetString(1);
                    //if (!OdbcReader.IsDBNull(2))
                    //    OneMedHisUsers.UserDept = OdbcReader.GetString(2);
                    //if (!OdbcReader.IsDBNull(3))
                    //    OneMedHisUsers.UserJob = OdbcReader.GetString(3);
                    //if (!OdbcReader.IsDBNull(4))
                    //    OneMedHisUsers.Reserved01 = OdbcReader.GetString(4);
                    //if (!OdbcReader.IsDBNull(5))
                    //    OneMedHisUsers.CreateDate = OdbcReader.GetDateTime(5);
                    //if (!OdbcReader.IsDBNull(6))
                    //    OneMedHisUsers.InputCode = OdbcReader.GetString(6);
                }
                else
                    OneMedHisUsers = null;
            }
            return OneMedHisUsers;
        }

        public Model.MedHisUsers SelectMedHisUsersNameOdbc(string userName)
        {
            Model.MedHisUsers OneMedHisUsers = null;

            OdbcParameter[] paramHisUsers = GetParameterOdbc("SelectMedHisUsersName");
            paramHisUsers[0].Value = userName;

            using (OdbcDataReader OdbcReader = OdbcHelper.ExecuteReader(OdbcHelper.ConnectionString, CommandType.Text, Select_MedHisUsersName_Odbc, paramHisUsers))
            {
                if (OdbcReader.Read())
                {
                    OneMedHisUsers = new Model.MedHisUsers();
                    //if (!OdbcReader.IsDBNull(0))
                    //    OneMedHisUsers.UserId = OdbcReader.GetString(0);
                    //if (!OdbcReader.IsDBNull(2))
                    //    OneMedHisUsers.UserName = OdbcReader.GetString(1);
                    //if (!OdbcReader.IsDBNull(2))
                    //    OneMedHisUsers.UserDept = OdbcReader.GetString(2);
                    //if (!OdbcReader.IsDBNull(3))
                    //    OneMedHisUsers.UserJob = OdbcReader.GetString(3);
                    //if (!OdbcReader.IsDBNull(4))
                    //    OneMedHisUsers.Reserved01 = OdbcReader.GetString(4);
                    //if (!OdbcReader.IsDBNull(5))
                    //    OneMedHisUsers.CreateDate = OdbcReader.GetDateTime(5);
                    //if (!OdbcReader.IsDBNull(6))
                    //    OneMedHisUsers.InputCode = OdbcReader.GetString(6);
                }
                else
                    OneMedHisUsers = null;
            }
            return OneMedHisUsers;
        }

        public int InsertMedHisUsersOdbc(Model.MedHisUsers MedHisUsers)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneInert = GetParameterOdbc("InsertMedHisUsers");
                //if (MedHisUsers.UserId != null)
                //    oneInert[0].Value = MedHisUsers.UserId;
                //else
                //    oneInert[0].Value = DBNull.Value;
                //if (MedHisUsers.UserName != null)
                //    oneInert[1].Value = MedHisUsers.UserName;
                //else
                //    oneInert[1].Value = DBNull.Value;
                //if (MedHisUsers.UserDept != null)
                //    oneInert[2].Value = MedHisUsers.UserDept;
                //else
                //    oneInert[2].Value = DBNull.Value;
                //if (MedHisUsers.UserJob != null)
                //    oneInert[3].Value = MedHisUsers.UserJob;
                //else
                //    oneInert[3].Value = DBNull.Value;
                //if (MedHisUsers.Reserved01 != null)
                //    oneInert[4].Value = MedHisUsers.Reserved01;
                //else
                //    oneInert[4].Value = DBNull.Value;
                //if (MedHisUsers.CreateDate > DateTime.MinValue)
                //    oneInert[5].Value = MedHisUsers.CreateDate;
                //else
                //    oneInert[5].Value = DBNull.Value;
                //if (MedHisUsers.InputCode != null)
                //    oneInert[6].Value = MedHisUsers.InputCode;
                //else
                //    oneInert[6].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Insert_MedHisUsers_Odbc, oneInert);
            }
        }

        public int UpdateMedHisUsersOdbc(Model.MedHisUsers MedHisUsers)
        {
            using (OdbcConnection OdbcCisConn = new OdbcConnection(OdbcHelper.ConnectionString))
            {
                OdbcParameter[] oneUpdate = GetParameterOdbc("UpdateMedHisUsers");

                //if (MedHisUsers.UserName != null)
                //    oneUpdate[0].Value = MedHisUsers.UserName;
                //else
                //    oneUpdate[0].Value = DBNull.Value;

                //if (MedHisUsers.UserDept != null)
                //    oneUpdate[1].Value = MedHisUsers.UserDept;
                //else
                //    oneUpdate[1].Value = DBNull.Value;

                //if (MedHisUsers.UserJob != null)
                //    oneUpdate[2].Value = MedHisUsers.UserJob;
                //else
                //    oneUpdate[2].Value = DBNull.Value;

                //if (MedHisUsers.Reserved01 != null)
                //    oneUpdate[3].Value = MedHisUsers.Reserved01;
                //else
                //    oneUpdate[3].Value = DBNull.Value;

                //if (MedHisUsers.CreateDate > DateTime.MinValue)
                //    oneUpdate[4].Value = MedHisUsers.CreateDate;
                //else
                //    oneUpdate[4].Value = DBNull.Value;

                //if (MedHisUsers.InputCode != null)
                //    oneUpdate[5].Value = MedHisUsers.InputCode;
                //else
                //    oneUpdate[5].Value = DBNull.Value;

                //if (MedHisUsers.UserId != null)
                //    oneUpdate[6].Value = MedHisUsers.UserId;
                //else
                //    oneUpdate[6].Value = DBNull.Value;

                return OdbcHelper.ExecuteNonQuery(OdbcCisConn, CommandType.Text, Update_MedHisUsers_Odbc, oneUpdate);
            }
        }

    }
}
