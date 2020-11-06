using System;
using System.Linq;
using System.Text;
using Dapper.Data;
using MedicalSystem.AnesWorkStation.Domain;
using System.Security.Cryptography;
using MedicalSystem.AnesWorkStation.Domain.Screen;
using System.Data;
using System.Collections.Generic;
using Dapper;

namespace MedicalSystem.AnesWorkStation.DataServices
{
    public interface IScreenCommonService
    {

        DateTime GetServerDateTime();

        DataResult GetTodayInfo(QueryParams queryParams);
    }

    /// <summary>
    /// 账号类
    /// </summary>
    public class ScreenCommonService : BaseService<ScreenCommonService>, IScreenCommonService
    {
        ConvertSqlHelper sqlHelper = new ConvertSqlHelper();

        /// <summary>
        /// 动态代理的构造方法，必须是无参数的，且标记为protected。
        /// </summary>
        /// <remarks>如果没有参数的且使用一个构造方法，则比较为public或不写构造方法即可。</remarks>
        protected ScreenCommonService()
            : base() { }

        /// <summary>
        /// IOC容器使用的构造方法，必须标记为public，供外部使用。
        /// </summary>
        /// <param name="context">数据连接对象</param>
        public ScreenCommonService(IDapperContext context)
            : base(context) { }



    

        public DateTime GetServerDateTime()
        {

            string baseSql = "SELECT SYSDATE AS SERVER_TIME FROM DUAL ";
            DataTable dt = dapper.Fill(baseSql);

            return Convert.ToDateTime(dt.Rows[0][0]);
        }

        public DataResult GetTodayInfo(QueryParams queryParams)
        {
            string baseSql = "SELECT * FROM MED_OPERATION_MASTER WHERE OPER_ROOM = :OperDept AND TO_CHAR(SCHEDULED_DATE_TIME,'YYYY-MM-DD') = TO_CHAR(SYSDATE,'YYYY-MM-DD') AND OPER_STATUS_CODE <> -80 ";

            DynamicParameters dynamicParams = sqlHelper.GetDynamicParams(baseSql, queryParams);
            string sql = sqlHelper.FillPara(baseSql, queryParams);
            return ToResult(dapper.Fill(sql, dynamicParams));
        }


        public DataResult ToResult(DataTable dt)
        {
            DataResult result = new DataResult()
            {
                Columns = new List<ColumnDefine>(),
                Rows = new List<DataResultRow>()
            };

            if (dt != null)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    result.Columns.Add(new ColumnDefine()
                    {
                        FieldName = column.ColumnName,
                        Title = column.ColumnName,
                        Width = 0,
                        IsSHow = 1,
                        DataType = column.DataType.FullName
                    });
                }

                foreach (DataRow row in dt.Rows)
                {
                    DataResultRow rRow = new DataResultRow()
                    {
                        Data = new List<object>(row.ItemArray)
                    };

                    result.Rows.Add(rRow);
                }
            }

            return result;

        }
    }
}
