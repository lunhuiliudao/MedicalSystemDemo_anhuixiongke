using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using Dapper;

namespace MedicalSystem.AutoGenerateCode
{
    /// <summary>
    /// Dapper.Orm的对象处理方法集合
    /// </summary>
    /// <typeparam name="T">数据对象</typeparam>
    public class DapperRepository: IDisposable
    {
        #region Fields

        private readonly IDbConnection _context;

        /// <summary>
        /// 当前数据库连接,主要用于事务处理。
        /// 例如：var conn = this.Connection;
        /// conn.Open(); 打开连接
        /// var trans=conn.BeginTransaction(); 开始事务
        /// trans.Commit(); 提交
        /// trans.Rollback(); 回滚
        /// </summary>
        public IDbConnection Connection
        {
            get { return _context; }
        }

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public DapperRepository(DapperContext dapper)
        {
            this._context = dapper.DbConnecttion;
        }

        #endregion
        
        /*====Dapper.Orm原生的SQL脚本查询方式【Start】====*/

        #region Fill方法

        /// <summary>
        /// 查询SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public DataTable Fill(string sql, object param = null)
        {
            DataTable table = new DataTable();

            using (var reader = _context.ExecuteReader(sql, param))
            {
                table.Load(reader);
            }

            return table;
        }

        #endregion

        /*====Dapper.Orm原生的SQL脚本查询方式【End】====*/

        #region IDisposable

        public void Dispose()
        {
            _context.Close();
            _context.Dispose();
        }

        #endregion

    }
}
