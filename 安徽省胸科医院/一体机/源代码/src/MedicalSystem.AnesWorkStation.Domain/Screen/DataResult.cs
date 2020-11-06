using System;
using System.Collections.Generic;
using System.Data;

namespace MedicalSystem.AnesWorkStation.Domain.Screen
{
    /// <summary>
    /// 返回数据集合
    /// </summary>
    public class DataResult
    {
        /// <summary>
        /// 列定义
        /// </summary>
        public List<ColumnDefine> Columns { get; set; }

        /// <summary>
        /// 行数据
        /// </summary>
        public List<DataResultRow> Rows { get; set; }

        /// <summary>
        /// 行定义表
        /// </summary>
        /// <returns></returns>
        public DataTable ToColumnsTable()
        {
            DataTable resultColumnDt = new DataTable("ConfigColumn");
            resultColumnDt.Columns.Add("FieldName", typeof(string));
            resultColumnDt.Columns.Add("Title", typeof(string));
            resultColumnDt.Columns.Add("Width", typeof(int));
            resultColumnDt.Columns.Add("IsSHow", typeof(string));

            if (Columns != null)
            {
                foreach (var item in Columns)
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

        /// <summary>
        /// 数据记录表
        /// </summary>
        /// <returns></returns>
        public DataTable ToDataTable()
        {
            DataTable tmp = new DataTable();
            if (Columns != null)
            {
                foreach (var item in Columns)
                {
                    tmp.Columns.Add(item.FieldName, string.IsNullOrEmpty(item.DataType) ? typeof(string) : Type.GetType(item.DataType));
                }
            }

            if (Rows != null)
            {
                foreach (var item in Rows)
                {
                    DataRow row = tmp.NewRow();
                    for (int i = 0; i < item.Data.Count; i++)
                    {
                        row[i] = item.Data[i] ?? DBNull.Value;
                    }
                    tmp.Rows.Add(row);
                }
            }

            return tmp;

        }

    }

    #region 列定义读取传送过来的查询

    /*
    /// <summary>
    /// 列定义
    /// </summary>
    public class DataResultColumn
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
    }
    */
    
    #endregion

    /// <summary>
    /// 行定义
    /// </summary>
    public class DataResultRow
    {
        /// <summary>
        /// 数据
        /// </summary>
        public List<object> Data { get; set; }

        /// <summary>
        /// 添加行数据
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public object Add(object val)
        {
            if (Data == null)
            {
                Data = new List<object>();
            }
            Data.Add(val);

            return val;
        }

    }

}
