using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace MedicalSystem.AnesIcuQuery.Models
{
    /// <summary>
    /// 自定义可配置参数
    /// </summary>
    public class QueryParams
    {
        /// <summary>
        /// 快速查询配置的脚本主键名称
        /// </summary>
        public string SqlKey { get; set; }
        /// <summary>
        /// 所有列定义
        /// </summary>
        public List<ColumnDefine> ColumnDefines { get; set; }
        /// <summary>
        /// 所有筛选条件
        /// </summary>
        public List<QueryDefine> QueryDefines { get; set; }

        #region 添加列定义

        /// <summary>
        /// 加载行定义表
        /// </summary>
        /// <param name="dt"></param>
        public List<ColumnDefine> LoadColumnDefines(DataTable dt)
        {
            if (ColumnDefines == null)
            {
                ColumnDefines = new List<ColumnDefine>();
            }

            ColumnDefines.Clear();

            if (dt == null || dt.Rows.Count == 0)
            {
                return ColumnDefines;
            }

            foreach (DataRow row in dt.Rows)
            {
                ColumnDefine column = new ColumnDefine()
                {
                    FieldName = Convert.ToString(row["FieldName"]),
                    Title = Convert.ToString(row["Title"])
                };
                int result;
                int.TryParse(Convert.ToString(row["Width"]), out result);
                column.Width = result;
                int.TryParse(Convert.ToString(row["IsSHow"]), out result);
                column.IsSHow = result;
                ColumnDefines.Add(column);
            }

            return ColumnDefines;
        }

        /// <summary>
        /// 获取行定义表
        /// </summary>
        /// <returns></returns>
        public DataTable ToColumnsTable()
        {
            DataTable resultColumnDt = new DataTable("ConfigColumn");
            resultColumnDt.Columns.Add("FieldName", typeof(string));
            resultColumnDt.Columns.Add("Title", typeof(string));
            resultColumnDt.Columns.Add("Width", typeof(int));
            resultColumnDt.Columns.Add("IsSHow", typeof(string));

            if (ColumnDefines != null)
            {
                foreach (var item in ColumnDefines)
                {
                    DataRow row = resultColumnDt.NewRow();
                    row["FieldName"] = item.FieldName;
                    row["Title"] = item.Title;
                    row["Width"] = item.Width;
                    row["IsSHow"] = item.IsSHow;
                    resultColumnDt.Rows.Add(row);
                }
            }

            return resultColumnDt;

        }

        #endregion

        #region 添加查询条件

        /// <summary>
        /// 清空条件。
        /// </summary>
        public void ClearQueryDefines()
        {
            if (QueryDefines != null)
            {
                QueryDefines.Clear();
            }
        }

        /// <summary>
        /// 添加查询条件
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        public void AddQueryDefines(String name, String value)
        {
            AddQueryDefines(name, OperationEnum.Equal, value);
        }

        /// <summary>
        /// 添加查询条件
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        /// <param name="operation">操作符</param>
        public void AddQueryDefines(String name, OperationEnum operation, String value)
        {
            AddQueryDefines(name, Convert.ToString(value), operation, typeof(String));
        }

        /// <summary>
        /// 添加查询条件
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        /// <param name="operation">操作符</param>
        /// <param name="valueType">值的类型</param>
        public void AddQueryDefines(String name, String value, Type valueType)
        {
            AddQueryDefines(name, value, OperationEnum.Equal, valueType);
        }

        /// <summary>
        /// 添加查询条件
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        public void AddQueryDefines(String name, Object value)
        {
            AddQueryDefines(name, OperationEnum.Equal, value);
        }

        /// <summary>
        /// 添加查询条件
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        /// <param name="operation">操作符</param>
        public void AddQueryDefines(String name, OperationEnum operation, Object value)
        {
            AddQueryDefines(name, Convert.ToString(value), operation, value == null ? typeof(String) : value.GetType());
        }

        /// <summary>
        /// 添加查询条件
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        /// <param name="operation">操作符</param>
        /// <param name="valueType">值的类型</param>
        public void AddQueryDefines(String name, String value, OperationEnum operation, Type valueType)
        {
            if (QueryDefines == null)
            {
                QueryDefines = new List<QueryDefine>();
            }

            QueryDefines.Add(new QueryDefine()
            {
                QueryName = name,
                QueryValue = value,
                Operation = operation,
                QueryType = valueType.Name
            });

        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 是否存在指定参数名称的定义
        /// </summary>
        /// <param name="name">参数名称</param>
        /// <returns></returns>
        public bool ContainsQueryName(string name)
        {
            if (QueryDefines != null && QueryDefines.Exists(x => x.QueryName.ToLower() == name.ToLower()))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 移除指定参数名称的定义
        /// </summary>
        /// <param name="name">参数名称</param>
        public void RemoveQueryDefine(string name)
        {
            if (QueryDefines != null)
            {
                QueryDefines.RemoveAll(x => x.QueryName.ToLower() == name.ToLower());
            }
        }

        #endregion
    }

    #region 列定义

    /// <summary>
    /// 列定义
    /// </summary>
    public class ColumnDefine
    {
        /// <summary>
        /// 列名
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 字段
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 是否显示
        /// </summary>
        public int IsSHow { get; set; }
        /// <summary>
        /// 返回的数据类型
        /// </summary>
        public string DataType { get; set; }
    }

    #endregion

    #region 查询条件单元

    /// <summary>
    /// 查询条件单元
    /// </summary>
    public class QueryDefine
    {
        /// <summary>
        /// 来自哪个表
        /// </summary>
        public string QueryTable { get; set; }
        /// <summary>
        /// 参数名称
        /// </summary>
        public string QueryName { get; set; }
        /// <summary>
        /// 查询操作符
        /// </summary>
        public OperationEnum Operation { get; set; }
        /// <summary>
        /// 参数值
        /// </summary>
        public string QueryValue { get; set; }
        /// <summary>
        /// 数据类型
        /// </summary>
        [DefaultValue("String")]
        public string QueryType { get; set; }
    }

    #endregion

    #region 查询操作符

    /// <summary>
    /// 查询操作符
    /// </summary>
    public enum OperationEnum
    {
        /// <summary>
        /// 等于
        /// </summary>
        Equal,
        /// <summary>
        /// 不等于
        /// </summary>
        NotEqual,
        /// <summary>
        /// 模糊
        /// </summary>
        Like,
        /// <summary>
        /// 以什么开始
        /// </summary>
        StartWith,
        /// <summary>
        /// 以什么结束
        /// </summary>
        EndWith,
        /// <summary>
        /// 大于
        /// </summary>
        Greater,
        /// <summary>
        /// 大于等于
        /// </summary>
        GreaterThanOrEqual,
        /// <summary>
        /// 小于
        /// </summary>
        Less,
        /// <summary>
        /// 小于等于
        /// </summary>
        LessThanOrEqual,
        /// <summary>
        /// 等于NULL
        /// </summary>
        IsNull,
        /// <summary>
        /// 不等于NULL
        /// </summary>
        NotNull,
        /// <summary>
        /// 多个包含条件,英文逗号隔开
        /// </summary>
        Or
    }
    
    #endregion

}
